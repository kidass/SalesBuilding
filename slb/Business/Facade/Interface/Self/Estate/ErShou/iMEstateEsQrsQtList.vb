Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.BusinessFacade
    ' 类名    ：IMEstateEsQrsQtList
    '
    ' 功能描述： 
    '     estate_es_qrsqt_list.aspx模块本身恢复现场需要的信息
    '----------------------------------------------------------------
    <Serializable()> Public Class IMEstateEsQrsQtList
        Implements IDisposable

        Private m_strhtxtDivLeftQRS As String                       'htxtDivLeftQRS
        Private m_strhtxtDivTopQRS As String                        'htxtDivTopQRS
        Private m_strhtxtDivLeftBody As String                      'htxtDivLeftBody
        Private m_strhtxtDivTopBody As String                       'htxtDivTopBody

        Private m_strhtxtQRSQuery As String                         'htxtQRSQuery
        Private m_strhtxtQRSRows As String                          'htxtQRSRows
        Private m_strhtxtQRSSort As String                          'htxtQRSSort
        Private m_strhtxtQRSSortColumnIndex As String               'htxtQRSSortColumnIndex
        Private m_strhtxtQRSSortType As String                      'htxtQRSSortType

        Private m_strhtxtSessionIdQuery As String                   'htxtSessionIdQuery

        Private m_strtxtQRSPageIndex As String                      'txtQRSPageIndex
        Private m_strtxtQRSPageSize As String                       'txtQRSPageSize

        Private m_strtxtQRSSearch_QRSH As String                    'txtQRSSearch_QRSH
        Private m_strtxtQRSSearch_JFMC As String                    'txtQRSSearch_JFMC
        Private m_strtxtQRSSearch_YFMC As String                    'txtQRSSearch_YFMC
        Private m_strtxtQRSSearch_FWDZ As String                    'txtQRSSearch_FWDZ
        Private m_strtxtQRSSearch_DGRQMin As String                 'txtQRSSearch_DGRQMin
        Private m_strtxtQRSSearch_DGRQMax As String                 'txtQRSSearch_DGRQMax
        Private m_intSelectedIndex_ddlQRSSearch_DGZT As Integer     'ddlQRSSearch_DGZT_SelectedIndex

        '----------------------------------------------------------------
        'asp:datagrid - grdQRS
        '----------------------------------------------------------------
        Private m_intPageSize_grdQRS As Integer
        Private m_intSelectedIndex_grdQRS As Integer
        Private m_intCurrentPageIndex_grdQRS As Integer











        '----------------------------------------------------------------
        ' 构造函数
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()

            m_strhtxtDivLeftQRS = ""
            m_strhtxtDivTopQRS = ""
            m_strhtxtDivLeftBody = ""
            m_strhtxtDivTopBody = ""

            m_strhtxtQRSQuery = ""
            m_strhtxtQRSRows = ""
            m_strhtxtQRSSort = ""
            m_strhtxtQRSSortColumnIndex = ""
            m_strhtxtQRSSortType = ""

            m_strhtxtSessionIdQuery = ""

            m_strtxtQRSPageIndex = ""
            m_strtxtQRSPageSize = ""

            m_strtxtQRSSearch_QRSH = ""
            m_strtxtQRSSearch_JFMC = ""
            m_strtxtQRSSearch_YFMC = ""
            m_strtxtQRSSearch_FWDZ = ""
            m_strtxtQRSSearch_DGRQMin = ""
            m_strtxtQRSSearch_DGRQMax = ""
            m_intSelectedIndex_ddlQRSSearch_DGZT = -1

            m_intPageSize_grdQRS = 0
            m_intCurrentPageIndex_grdQRS = 0
            m_intSelectedIndex_grdQRS = -1

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
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IMEstateEsQrsQtList)
            Try
                If Not (obj Is Nothing) Then
                    obj.Dispose()
                End If
            Catch ex As Exception
            End Try
            obj = Nothing
        End Sub












        '----------------------------------------------------------------
        ' htxtQRSQuery属性
        '----------------------------------------------------------------
        Public Property htxtQRSQuery() As String
            Get
                htxtQRSQuery = m_strhtxtQRSQuery
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtQRSQuery = Value
                Catch ex As Exception
                    m_strhtxtQRSQuery = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtQRSRows属性
        '----------------------------------------------------------------
        Public Property htxtQRSRows() As String
            Get
                htxtQRSRows = m_strhtxtQRSRows
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtQRSRows = Value
                Catch ex As Exception
                    m_strhtxtQRSRows = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtQRSSort属性
        '----------------------------------------------------------------
        Public Property htxtQRSSort() As String
            Get
                htxtQRSSort = m_strhtxtQRSSort
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtQRSSort = Value
                Catch ex As Exception
                    m_strhtxtQRSSort = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtQRSSortColumnIndex属性
        '----------------------------------------------------------------
        Public Property htxtQRSSortColumnIndex() As String
            Get
                htxtQRSSortColumnIndex = m_strhtxtQRSSortColumnIndex
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtQRSSortColumnIndex = Value
                Catch ex As Exception
                    m_strhtxtQRSSortColumnIndex = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtQRSSortType属性
        '----------------------------------------------------------------
        Public Property htxtQRSSortType() As String
            Get
                htxtQRSSortType = m_strhtxtQRSSortType
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtQRSSortType = Value
                Catch ex As Exception
                    m_strhtxtQRSSortType = ""
                End Try
            End Set
        End Property












        '----------------------------------------------------------------
        ' htxtDivLeftQRS属性
        '----------------------------------------------------------------
        Public Property htxtDivLeftQRS() As String
            Get
                htxtDivLeftQRS = m_strhtxtDivLeftQRS
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivLeftQRS = Value
                Catch ex As Exception
                    m_strhtxtDivLeftQRS = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopQRS属性
        '----------------------------------------------------------------
        Public Property htxtDivTopQRS() As String
            Get
                htxtDivTopQRS = m_strhtxtDivTopQRS
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivTopQRS = Value
                Catch ex As Exception
                    m_strhtxtDivTopQRS = ""
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
        ' txtQRSPageIndex属性
        '----------------------------------------------------------------
        Public Property txtQRSPageIndex() As String
            Get
                txtQRSPageIndex = m_strtxtQRSPageIndex
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtQRSPageIndex = Value
                Catch ex As Exception
                    m_strtxtQRSPageIndex = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtQRSPageSize属性
        '----------------------------------------------------------------
        Public Property txtQRSPageSize() As String
            Get
                txtQRSPageSize = m_strtxtQRSPageSize
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtQRSPageSize = Value
                Catch ex As Exception
                    m_strtxtQRSPageSize = ""
                End Try
            End Set
        End Property











        '----------------------------------------------------------------
        ' txtQRSSearch_QRSH属性
        '----------------------------------------------------------------
        Public Property txtQRSSearch_QRSH() As String
            Get
                txtQRSSearch_QRSH = m_strtxtQRSSearch_QRSH
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtQRSSearch_QRSH = Value
                Catch ex As Exception
                    m_strtxtQRSSearch_QRSH = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtQRSSearch_JFMC属性
        '----------------------------------------------------------------
        Public Property txtQRSSearch_JFMC() As String
            Get
                txtQRSSearch_JFMC = m_strtxtQRSSearch_JFMC
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtQRSSearch_JFMC = Value
                Catch ex As Exception
                    m_strtxtQRSSearch_JFMC = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtQRSSearch_YFMC属性
        '----------------------------------------------------------------
        Public Property txtQRSSearch_YFMC() As String
            Get
                txtQRSSearch_YFMC = m_strtxtQRSSearch_YFMC
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtQRSSearch_YFMC = Value
                Catch ex As Exception
                    m_strtxtQRSSearch_YFMC = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtQRSSearch_FWDZ属性
        '----------------------------------------------------------------
        Public Property txtQRSSearch_FWDZ() As String
            Get
                txtQRSSearch_FWDZ = m_strtxtQRSSearch_FWDZ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtQRSSearch_FWDZ = Value
                Catch ex As Exception
                    m_strtxtQRSSearch_FWDZ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtQRSSearch_DGRQMin属性
        '----------------------------------------------------------------
        Public Property txtQRSSearch_DGRQMin() As String
            Get
                txtQRSSearch_DGRQMin = m_strtxtQRSSearch_DGRQMin
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtQRSSearch_DGRQMin = Value
                Catch ex As Exception
                    m_strtxtQRSSearch_DGRQMin = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtQRSSearch_DGRQMax属性
        '----------------------------------------------------------------
        Public Property txtQRSSearch_DGRQMax() As String
            Get
                txtQRSSearch_DGRQMax = m_strtxtQRSSearch_DGRQMax
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtQRSSearch_DGRQMax = Value
                Catch ex As Exception
                    m_strtxtQRSSearch_DGRQMax = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' ddlQRSSearch_DGZT_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property ddlQRSSearch_DGZT_SelectedIndex() As Integer
            Get
                ddlQRSSearch_DGZT_SelectedIndex = m_intSelectedIndex_ddlQRSSearch_DGZT
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlQRSSearch_DGZT = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlQRSSearch_DGZT = -1
                End Try
            End Set
        End Property













        '----------------------------------------------------------------
        ' grdQRSPageSize属性
        '----------------------------------------------------------------
        Public Property grdQRSPageSize() As Integer
            Get
                grdQRSPageSize = m_intPageSize_grdQRS
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdQRS = Value
                Catch ex As Exception
                    m_intPageSize_grdQRS = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdQRSCurrentPageIndex属性
        '----------------------------------------------------------------
        Public Property grdQRSCurrentPageIndex() As Integer
            Get
                grdQRSCurrentPageIndex = m_intCurrentPageIndex_grdQRS
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdQRS = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdQRS = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdQRSSelectedIndex属性
        '----------------------------------------------------------------
        Public Property grdQRSSelectedIndex() As Integer
            Get
                grdQRSSelectedIndex = m_intSelectedIndex_grdQRS
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdQRS = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdQRS = -1
                End Try
            End Set
        End Property

    End Class

End Namespace
