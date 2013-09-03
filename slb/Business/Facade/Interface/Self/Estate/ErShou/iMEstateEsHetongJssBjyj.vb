Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.BusinessFacade
    ' 类名    ：IMEstateEsHetongJssBjyj
    '
    ' 功能描述： 
    '     estate_es_hetong_bjyj.aspx模块本身恢复现场需要的信息
    '----------------------------------------------------------------
    <Serializable()> Public Class IMEstateEsHetongJssBjyj
        Implements IDisposable

        Private m_strhtxtDivLeftBody As String                      'htxtDivLeftBody
        Private m_strhtxtDivTopBody As String                       'htxtDivTopBody
        Private m_strhtxtDivLeftJSS As String                       'htxtDivLeftJSS
        Private m_strhtxtDivTopJSS As String                        'htxtDivTopJSS

        Private m_strhtxtJSSQuery As String                         'htxtJSSQuery
        Private m_strhtxtJSSRows As String                          'htxtJSSRows
        Private m_strhtxtJSSSort As String                          'htxtJSSSort
        Private m_strhtxtJSSSortColumnIndex As String               'htxtJSSSortColumnIndex
        Private m_strhtxtJSSSortType As String                      'htxtJSSSortType

        Private m_strhtxtSessionIdQueryJSS As String                'htxtSessionIdQueryJSS

        Private m_strtxtJSSPageIndex As String                      'txtJSSPageIndex
        Private m_strtxtJSSPageSize As String                       'txtJSSPageSize

        Private m_strtxtJSSSearch_QRSH As String                    'txtJSSSearch_QRSH
        Private m_strtxtJSSSearch_JSSH As String                    'txtJSSSearch_JSSH
        Private m_strtxtJSSSearch_HTRQMin As String                 'txtJSSSearch_HTRQMin
        Private m_strtxtJSSSearch_HTRQMax As String                 'txtJSSSearch_HTRQMax
        Private m_intSelectedIndex_ddlJSSSearch_HTZT As Integer     'ddlJSSSearch_HTZT_SelectedIndex

        Private m_intPageSize_grdJSS As Integer
        Private m_intSelectedIndex_grdJSS As Integer
        Private m_intCurrentPageIndex_grdJSS As Integer











        '----------------------------------------------------------------
        ' 构造函数
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()

            m_strhtxtDivLeftJSS = ""
            m_strhtxtDivTopJSS = ""
            m_strhtxtDivLeftBody = ""
            m_strhtxtDivTopBody = ""

            m_strhtxtJSSQuery = ""
            m_strhtxtJSSRows = ""
            m_strhtxtJSSSort = ""
            m_strhtxtJSSSortColumnIndex = ""
            m_strhtxtJSSSortType = ""

            m_strhtxtSessionIdQueryJSS = ""

            m_strtxtJSSPageIndex = ""
            m_strtxtJSSPageSize = ""

            m_strtxtJSSSearch_JSSH = ""
            m_strtxtJSSSearch_QRSH = ""
            m_strtxtJSSSearch_HTRQMin = ""
            m_strtxtJSSSearch_HTRQMax = ""
            m_intSelectedIndex_ddlJSSSearch_HTZT = -1

            m_intPageSize_grdJSS = 0
            m_intCurrentPageIndex_grdJSS = 0
            m_intSelectedIndex_grdJSS = -1
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
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IMEstateEsHetongJssBjyj)
            Try
                If Not (obj Is Nothing) Then
                    obj.Dispose()
                End If
            Catch ex As Exception
            End Try
            obj = Nothing
        End Sub












        '----------------------------------------------------------------
        ' htxtJSSQuery属性
        '----------------------------------------------------------------
        Public Property htxtJSSQuery() As String
            Get
                htxtJSSQuery = m_strhtxtJSSQuery
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtJSSQuery = Value
                Catch ex As Exception
                    m_strhtxtJSSQuery = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtJSSRows属性
        '----------------------------------------------------------------
        Public Property htxtJSSRows() As String
            Get
                htxtJSSRows = m_strhtxtJSSRows
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtJSSRows = Value
                Catch ex As Exception
                    m_strhtxtJSSRows = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtJSSSort属性
        '----------------------------------------------------------------
        Public Property htxtJSSSort() As String
            Get
                htxtJSSSort = m_strhtxtJSSSort
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtJSSSort = Value
                Catch ex As Exception
                    m_strhtxtJSSSort = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtJSSSortColumnIndex属性
        '----------------------------------------------------------------
        Public Property htxtJSSSortColumnIndex() As String
            Get
                htxtJSSSortColumnIndex = m_strhtxtJSSSortColumnIndex
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtJSSSortColumnIndex = Value
                Catch ex As Exception
                    m_strhtxtJSSSortColumnIndex = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtJSSSortType属性
        '----------------------------------------------------------------
        Public Property htxtJSSSortType() As String
            Get
                htxtJSSSortType = m_strhtxtJSSSortType
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtJSSSortType = Value
                Catch ex As Exception
                    m_strhtxtJSSSortType = ""
                End Try
            End Set
        End Property












        '----------------------------------------------------------------
        ' htxtDivLeftJSS属性
        '----------------------------------------------------------------
        Public Property htxtDivLeftJSS() As String
            Get
                htxtDivLeftJSS = m_strhtxtDivLeftJSS
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivLeftJSS = Value
                Catch ex As Exception
                    m_strhtxtDivLeftJSS = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopJSS属性
        '----------------------------------------------------------------
        Public Property htxtDivTopJSS() As String
            Get
                htxtDivTopJSS = m_strhtxtDivTopJSS
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivTopJSS = Value
                Catch ex As Exception
                    m_strhtxtDivTopJSS = ""
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
        ' htxtSessionIdQueryJSS属性
        '----------------------------------------------------------------
        Public Property htxtSessionIdQueryJSS() As String
            Get
                htxtSessionIdQueryJSS = m_strhtxtSessionIdQueryJSS
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSessionIdQueryJSS = Value
                Catch ex As Exception
                    m_strhtxtSessionIdQueryJSS = ""
                End Try
            End Set
        End Property













        '----------------------------------------------------------------
        ' txtJSSPageIndex属性
        '----------------------------------------------------------------
        Public Property txtJSSPageIndex() As String
            Get
                txtJSSPageIndex = m_strtxtJSSPageIndex
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJSSPageIndex = Value
                Catch ex As Exception
                    m_strtxtJSSPageIndex = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtJSSPageSize属性
        '----------------------------------------------------------------
        Public Property txtJSSPageSize() As String
            Get
                txtJSSPageSize = m_strtxtJSSPageSize
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJSSPageSize = Value
                Catch ex As Exception
                    m_strtxtJSSPageSize = ""
                End Try
            End Set
        End Property











        '----------------------------------------------------------------
        ' txtJSSSearch_JSSH属性
        '----------------------------------------------------------------
        Public Property txtJSSSearch_JSSH() As String
            Get
                txtJSSSearch_JSSH = m_strtxtJSSSearch_JSSH
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJSSSearch_JSSH = Value
                Catch ex As Exception
                    m_strtxtJSSSearch_JSSH = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtJSSSearch_QRSH属性
        '----------------------------------------------------------------
        Public Property txtJSSSearch_QRSH() As String
            Get
                txtJSSSearch_QRSH = m_strtxtJSSSearch_QRSH
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJSSSearch_QRSH = Value
                Catch ex As Exception
                    m_strtxtJSSSearch_QRSH = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtJSSSearch_HTRQMin属性
        '----------------------------------------------------------------
        Public Property txtJSSSearch_HTRQMin() As String
            Get
                txtJSSSearch_HTRQMin = m_strtxtJSSSearch_HTRQMin
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJSSSearch_HTRQMin = Value
                Catch ex As Exception
                    m_strtxtJSSSearch_HTRQMin = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtJSSSearch_HTRQMax属性
        '----------------------------------------------------------------
        Public Property txtJSSSearch_HTRQMax() As String
            Get
                txtJSSSearch_HTRQMax = m_strtxtJSSSearch_HTRQMax
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJSSSearch_HTRQMax = Value
                Catch ex As Exception
                    m_strtxtJSSSearch_HTRQMax = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' ddlJSSSearch_HTZT_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property ddlJSSSearch_HTZT_SelectedIndex() As Integer
            Get
                ddlJSSSearch_HTZT_SelectedIndex = m_intSelectedIndex_ddlJSSSearch_HTZT
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlJSSSearch_HTZT = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlJSSSearch_HTZT = -1
                End Try
            End Set
        End Property














        '----------------------------------------------------------------
        ' grdJSSPageSize属性
        '----------------------------------------------------------------
        Public Property grdJSSPageSize() As Integer
            Get
                grdJSSPageSize = m_intPageSize_grdJSS
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdJSS = Value
                Catch ex As Exception
                    m_intPageSize_grdJSS = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdJSSCurrentPageIndex属性
        '----------------------------------------------------------------
        Public Property grdJSSCurrentPageIndex() As Integer
            Get
                grdJSSCurrentPageIndex = m_intCurrentPageIndex_grdJSS
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdJSS = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdJSS = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdJSSSelectedIndex属性
        '----------------------------------------------------------------
        Public Property grdJSSSelectedIndex() As Integer
            Get
                grdJSSSelectedIndex = m_intSelectedIndex_grdJSS
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdJSS = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdJSS = -1
                End Try
            End Set
        End Property

    End Class

End Namespace
