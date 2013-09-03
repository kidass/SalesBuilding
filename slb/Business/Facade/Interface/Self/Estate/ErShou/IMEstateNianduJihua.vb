Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.BusinessFacade
    ' 类名    ：IMEstateRsZhengzhiMianmao
    '
    ' 功能描述： 
    '     estate_rs_zhengzhimianmao.aspx模块本身恢复现场需要的信息
    '----------------------------------------------------------------
    <Serializable()> Public Class IMEstateNianduJihua
        Implements IDisposable

        '----------------------------------------------------------------
        ' 模块属性
        '----------------------------------------------------------------
        Private m_strhtxtDivLeftBody As String                  'htxtDivLeftBody
        Private m_strhtxtDivTopBody As String                   'htxtDivTopBody
        Private m_strhtxtDivLeftObject As String                'htxtDivLeftObject
        Private m_strhtxtDivTopObject As String                 'htxtDivTopObject

        Private m_strtxtPageIndex As String                     'txtPageIndex
        Private m_strtxtPageSize As String                      'txtPageSize

        Private m_strtxtSearch_JHND As String                   'txtSearch_JHND
        Private m_intrblSearch_JHLX_SelectedIndex As Integer    'rblSearch_JHLX_SelectedIndex

        Private m_strtxtJHND As String                          'txtJHND
        Private m_strtxtJHED As String                          'txtJHED
        Private m_intrblJHLX_SelectedIndex As Integer           'rblJHLX_SelectedIndex

        Private m_strhtxtCurrentPage As String                  'htxtCurrentPage
        Private m_strhtxtCurrentRow As String                   'htxtCurrentRow
        Private m_strhtxtEditMode As String                     'htxtEditMode
        Private m_strhtxtEditType As String                     'htxtEditType

        Private m_strhtxtQuery As String                        'htxtQuery
        Private m_strhtxtRows As String                         'htxtRows
        Private m_strhtxtSort As String                         'htxtSort
        Private m_strhtxtSortColumnIndex As String              'htxtSortColumnIndex
        Private m_strhtxtSortType As String                     'htxtSortType

        Private m_intCurrentPageIndex_grdObjects As Integer     'grdObjects_CurrentPageIndex
        Private m_intSelectedIndex_grdObjects As Integer        'grdObjects_SelectedIndex
        Private m_intPageSize_grdObjects As Integer             'grdObjects_PageSize





        '----------------------------------------------------------------
        ' 构造函数
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()

            m_strhtxtDivLeftBody = ""
            m_strhtxtDivTopBody = ""
            m_strhtxtDivLeftObject = ""
            m_strhtxtDivTopObject = ""

            m_strtxtPageIndex = ""
            m_strtxtPageSize = ""

            m_strtxtSearch_JHND = ""
            m_intrblSearch_JHLX_SelectedIndex = -1

            m_strtxtJHND = ""
            m_strtxtJHED = ""
            m_intrblJHLX_SelectedIndex = -1

            m_strhtxtCurrentPage = ""
            m_strhtxtCurrentRow = ""
            m_strhtxtEditMode = ""
            m_strhtxtEditType = ""

            m_strhtxtQuery = ""
            m_strhtxtRows = ""
            m_strhtxtSort = ""
            m_strhtxtSortColumnIndex = ""
            m_strhtxtSortType = ""

            m_intCurrentPageIndex_grdObjects = 0
            m_intSelectedIndex_grdObjects = -1
            m_intPageSize_grdObjects = 30

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
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IMEstateNianduJihua)
            Try
                If Not (obj Is Nothing) Then
                    obj.Dispose()
                End If
            Catch ex As Exception
            End Try
            obj = Nothing
        End Sub




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
        ' htxtDivLeftObject属性
        '----------------------------------------------------------------
        Public Property htxtDivLeftObject() As String
            Get
                htxtDivLeftObject = m_strhtxtDivLeftObject
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivLeftObject = Value
                Catch ex As Exception
                    m_strhtxtDivLeftObject = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopObject属性
        '----------------------------------------------------------------
        Public Property htxtDivTopObject() As String
            Get
                htxtDivTopObject = m_strhtxtDivTopObject
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivTopObject = Value
                Catch ex As Exception
                    m_strhtxtDivTopObject = ""
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
        ' txtSearch_JHND属性
        '----------------------------------------------------------------
        Public Property txtSearch_JHND() As String
            Get
                txtSearch_JHND = m_strtxtSearch_JHND
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtSearch_JHND = Value
                Catch ex As Exception
                    m_strtxtSearch_JHND = ""
                End Try
            End Set
        End Property




        '----------------------------------------------------------------
        ' rblSearch_JHLX_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property rblSearch_JHLX_SelectedIndex() As Integer
            Get
                rblSearch_JHLX_SelectedIndex = m_intrblSearch_JHLX_SelectedIndex
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intrblSearch_JHLX_SelectedIndex = Value
                Catch ex As Exception
                    m_intrblSearch_JHLX_SelectedIndex = -1
                End Try
            End Set
        End Property





        '----------------------------------------------------------------
        ' txtSearch_JHND属性
        '----------------------------------------------------------------
        Public Property txtJHND() As String
            Get
                txtJHND = m_strtxtJHND
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJHND = Value
                Catch ex As Exception
                    m_strtxtJHND = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtJHED属性
        '----------------------------------------------------------------
        Public Property txtJHED() As String
            Get
                txtJHED = m_strtxtJHED
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJHED = Value
                Catch ex As Exception
                    m_strtxtJHED = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' rblJHLX_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property rblJHLX_SelectedIndex() As Integer
            Get
                rblJHLX_SelectedIndex = m_intrblJHLX_SelectedIndex
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intrblJHLX_SelectedIndex = Value
                Catch ex As Exception
                    m_intrblJHLX_SelectedIndex = -1
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
        ' grdObjects_CurrentPageIndex属性
        '----------------------------------------------------------------
        Public Property grdObjects_CurrentPageIndex() As Integer
            Get
                grdObjects_CurrentPageIndex = m_intCurrentPageIndex_grdObjects
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdObjects = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdObjects = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdObjects_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property grdObjects_SelectedIndex() As Integer
            Get
                grdObjects_SelectedIndex = m_intSelectedIndex_grdObjects
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdObjects = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdObjects = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdObjects_PageSize属性
        '----------------------------------------------------------------
        Public Property grdObjects_PageSize() As Integer
            Get
                grdObjects_PageSize = m_intPageSize_grdObjects
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdObjects = Value
                Catch ex As Exception
                    m_intPageSize_grdObjects = 0
                End Try
            End Set
        End Property


    End Class
End Namespace


