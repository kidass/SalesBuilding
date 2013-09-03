Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.BusinessFacade
    ' 类名    ：IMEstateRsRskpLdht
    '
    ' 功能描述： 
    '     estate_rs_rskp_ldht.aspx模块本身恢复现场需要的信息
    '----------------------------------------------------------------
    <Serializable()> Public Class IMEstateRsRskpLdht
        Implements IDisposable

        Private m_strhtxtDivLeftRYLIST As String                    'htxtDivLeftRYLIST
        Private m_strhtxtDivTopRYLIST As String                     'htxtDivTopRYLIST
        Private m_strhtxtDivLeftBody As String                      'htxtDivLeftBody
        Private m_strhtxtDivTopBody As String                       'htxtDivTopBody

        Private m_strhtxtRYLISTQuery As String                      'htxtRYLISTQuery
        Private m_strhtxtRYLISTRows As String                       'htxtRYLISTRows
        Private m_strhtxtRYLISTSort As String                       'htxtRYLISTSort
        Private m_strhtxtRYLISTSortColumnIndex As String            'htxtRYLISTSortColumnIndex
        Private m_strhtxtRYLISTSortType As String                   'htxtRYLISTSortType

        Private m_strhtxtSessionIdQuery As String                   'htxtSessionIdQuery

        Private m_strtxtRYLISTPageIndex As String                   'txtRYLISTPageIndex
        Private m_strtxtRYLISTPageSize As String                    'txtRYLISTPageSize

        Private m_strtxtRYLISTSearch_RYDM As String                 'txtRYLISTSearch_RYDM
        Private m_strtxtRYLISTSearch_HTSJMin As String              'txtRYLISTSearch_HTSJMin
        Private m_strtxtRYLISTSearch_HTSJMax As String              'txtRYLISTSearch_HTSJMax
        Private m_intSelectedIndex_ddlRYLISTSearch_HTLX As Integer  'ddlRYLISTSearch_HTLX_SelectedIndex
        Private m_intSelectedIndex_ddlRYLISTSearch_SFXY As Integer  'ddlRYLISTSearch_SFXY_SelectedIndex

        Private m_strhtxtWYBS As String                             'htxtWYBS
        Private m_strhtxtRYDM As String                             'htxtRYDM
        Private m_strtxtRYMC As String                              'txtRYMC
        Private m_strtxtKSSJ As String                              'txtKSSJ
        Private m_strtxtJSSJ As String                              'txtJSSJ
        'zengxianglin 2009-01-12
        Private m_strtxtSYKS As String                              'txtSYKS
        Private m_strtxtSYJS As String                              'txtSYJS
        'zengxianglin 2009-01-12
        Private m_strhtxtHTWJ As String                             'htxtHTWJ
        Private m_strhtxtUploadFile As String                       'htxtUploadFile
        Private m_intSelectedIndex_rblHTLX As Integer               'rblHTLX_SelectedIndex
        Private m_intSelectedIndex_rblSFXY As Integer               'rblSFXY_SelectedIndex

        Private m_strhtxtCurrentPage As String                      'htxtCurrentPage
        Private m_strhtxtCurrentRow As String                       'htxtCurrentRow
        Private m_strhtxtEditMode As String                         'htxtEditMode
        Private m_strhtxtEditType As String                         'htxtEditType

        '----------------------------------------------------------------
        'asp:datagrid - grdRYLIST
        '----------------------------------------------------------------
        Private m_intPageSize_grdRYLIST As Integer
        Private m_intSelectedIndex_grdRYLIST As Integer
        Private m_intCurrentPageIndex_grdRYLIST As Integer











        '----------------------------------------------------------------
        ' 构造函数
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()

            m_strhtxtDivLeftRYLIST = ""
            m_strhtxtDivTopRYLIST = ""
            m_strhtxtDivLeftBody = ""
            m_strhtxtDivTopBody = ""

            m_strhtxtRYLISTQuery = ""
            m_strhtxtRYLISTRows = ""
            m_strhtxtRYLISTSort = ""
            m_strhtxtRYLISTSortColumnIndex = ""
            m_strhtxtRYLISTSortType = ""

            m_strhtxtSessionIdQuery = ""

            m_strtxtRYLISTPageIndex = ""
            m_strtxtRYLISTPageSize = ""

            m_strtxtRYLISTSearch_RYDM = ""
            m_strtxtRYLISTSearch_HTSJMin = ""
            m_strtxtRYLISTSearch_HTSJMax = ""
            m_intSelectedIndex_ddlRYLISTSearch_HTLX = -1
            m_intSelectedIndex_ddlRYLISTSearch_SFXY = -1

            m_strhtxtWYBS = ""
            m_strhtxtRYDM = ""
            m_strtxtRYMC = ""
            m_strtxtKSSJ = ""
            m_strtxtJSSJ = ""
            'zengxianglin 2009-01-12
            m_strtxtSYKS = ""
            m_strtxtSYJS = ""
            'zengxianglin 2009-01-12
            m_strhtxtHTWJ = ""
            m_strhtxtUploadFile = ""
            m_intSelectedIndex_rblHTLX = -1
            m_intSelectedIndex_rblSFXY = -1

            m_strhtxtCurrentPage = ""
            m_strhtxtCurrentRow = ""
            m_strhtxtEditMode = ""
            m_strhtxtEditType = ""

            m_intPageSize_grdRYLIST = 0
            m_intCurrentPageIndex_grdRYLIST = 0
            m_intSelectedIndex_grdRYLIST = -1

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
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IMEstateRsRskpLdht)
            Try
                If Not (obj Is Nothing) Then
                    obj.Dispose()
                End If
            Catch ex As Exception
            End Try
            obj = Nothing
        End Sub












        '----------------------------------------------------------------
        ' htxtRYLISTQuery属性
        '----------------------------------------------------------------
        Public Property htxtRYLISTQuery() As String
            Get
                htxtRYLISTQuery = m_strhtxtRYLISTQuery
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtRYLISTQuery = Value
                Catch ex As Exception
                    m_strhtxtRYLISTQuery = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtRYLISTRows属性
        '----------------------------------------------------------------
        Public Property htxtRYLISTRows() As String
            Get
                htxtRYLISTRows = m_strhtxtRYLISTRows
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtRYLISTRows = Value
                Catch ex As Exception
                    m_strhtxtRYLISTRows = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtRYLISTSort属性
        '----------------------------------------------------------------
        Public Property htxtRYLISTSort() As String
            Get
                htxtRYLISTSort = m_strhtxtRYLISTSort
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtRYLISTSort = Value
                Catch ex As Exception
                    m_strhtxtRYLISTSort = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtRYLISTSortColumnIndex属性
        '----------------------------------------------------------------
        Public Property htxtRYLISTSortColumnIndex() As String
            Get
                htxtRYLISTSortColumnIndex = m_strhtxtRYLISTSortColumnIndex
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtRYLISTSortColumnIndex = Value
                Catch ex As Exception
                    m_strhtxtRYLISTSortColumnIndex = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtRYLISTSortType属性
        '----------------------------------------------------------------
        Public Property htxtRYLISTSortType() As String
            Get
                htxtRYLISTSortType = m_strhtxtRYLISTSortType
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtRYLISTSortType = Value
                Catch ex As Exception
                    m_strhtxtRYLISTSortType = ""
                End Try
            End Set
        End Property












        '----------------------------------------------------------------
        ' htxtDivLeftRYLIST属性
        '----------------------------------------------------------------
        Public Property htxtDivLeftRYLIST() As String
            Get
                htxtDivLeftRYLIST = m_strhtxtDivLeftRYLIST
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivLeftRYLIST = Value
                Catch ex As Exception
                    m_strhtxtDivLeftRYLIST = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopRYLIST属性
        '----------------------------------------------------------------
        Public Property htxtDivTopRYLIST() As String
            Get
                htxtDivTopRYLIST = m_strhtxtDivTopRYLIST
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivTopRYLIST = Value
                Catch ex As Exception
                    m_strhtxtDivTopRYLIST = ""
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
        ' txtRYLISTPageIndex属性
        '----------------------------------------------------------------
        Public Property txtRYLISTPageIndex() As String
            Get
                txtRYLISTPageIndex = m_strtxtRYLISTPageIndex
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtRYLISTPageIndex = Value
                Catch ex As Exception
                    m_strtxtRYLISTPageIndex = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtRYLISTPageSize属性
        '----------------------------------------------------------------
        Public Property txtRYLISTPageSize() As String
            Get
                txtRYLISTPageSize = m_strtxtRYLISTPageSize
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtRYLISTPageSize = Value
                Catch ex As Exception
                    m_strtxtRYLISTPageSize = ""
                End Try
            End Set
        End Property











        '----------------------------------------------------------------
        ' txtRYLISTSearch_RYDM属性
        '----------------------------------------------------------------
        Public Property txtRYLISTSearch_RYDM() As String
            Get
                txtRYLISTSearch_RYDM = m_strtxtRYLISTSearch_RYDM
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtRYLISTSearch_RYDM = Value
                Catch ex As Exception
                    m_strtxtRYLISTSearch_RYDM = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtRYLISTSearch_HTSJMin属性
        '----------------------------------------------------------------
        Public Property txtRYLISTSearch_HTSJMin() As String
            Get
                txtRYLISTSearch_HTSJMin = m_strtxtRYLISTSearch_HTSJMin
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtRYLISTSearch_HTSJMin = Value
                Catch ex As Exception
                    m_strtxtRYLISTSearch_HTSJMin = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtRYLISTSearch_HTSJMax属性
        '----------------------------------------------------------------
        Public Property txtRYLISTSearch_HTSJMax() As String
            Get
                txtRYLISTSearch_HTSJMax = m_strtxtRYLISTSearch_HTSJMax
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtRYLISTSearch_HTSJMax = Value
                Catch ex As Exception
                    m_strtxtRYLISTSearch_HTSJMax = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' ddlRYLISTSearch_HTLX_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property ddlRYLISTSearch_HTLX_SelectedIndex() As Integer
            Get
                ddlRYLISTSearch_HTLX_SelectedIndex = m_intSelectedIndex_ddlRYLISTSearch_HTLX
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlRYLISTSearch_HTLX = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlRYLISTSearch_HTLX = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' ddlRYLISTSearch_SFXY_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property ddlRYLISTSearch_SFXY_SelectedIndex() As Integer
            Get
                ddlRYLISTSearch_SFXY_SelectedIndex = m_intSelectedIndex_ddlRYLISTSearch_SFXY
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlRYLISTSearch_SFXY = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlRYLISTSearch_SFXY = -1
                End Try
            End Set
        End Property













        '----------------------------------------------------------------
        ' htxtWYBS属性
        '----------------------------------------------------------------
        Public Property htxtWYBS() As String
            Get
                htxtWYBS = m_strhtxtWYBS
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtWYBS = Value
                Catch ex As Exception
                    m_strhtxtWYBS = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtRYDM属性
        '----------------------------------------------------------------
        Public Property htxtRYDM() As String
            Get
                htxtRYDM = m_strhtxtRYDM
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtRYDM = Value
                Catch ex As Exception
                    m_strhtxtRYDM = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtHTWJ属性
        '----------------------------------------------------------------
        Public Property htxtHTWJ() As String
            Get
                htxtHTWJ = m_strhtxtHTWJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtHTWJ = Value
                Catch ex As Exception
                    m_strhtxtHTWJ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtUploadFile属性
        '----------------------------------------------------------------
        Public Property htxtUploadFile() As String
            Get
                htxtUploadFile = m_strhtxtUploadFile
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtUploadFile = Value
                Catch ex As Exception
                    m_strhtxtUploadFile = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtRYMC属性
        '----------------------------------------------------------------
        Public Property txtRYMC() As String
            Get
                txtRYMC = m_strtxtRYMC
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtRYMC = Value
                Catch ex As Exception
                    m_strtxtRYMC = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtKSSJ属性
        '----------------------------------------------------------------
        Public Property txtKSSJ() As String
            Get
                txtKSSJ = m_strtxtKSSJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtKSSJ = Value
                Catch ex As Exception
                    m_strtxtKSSJ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtJSSJ属性
        '----------------------------------------------------------------
        Public Property txtJSSJ() As String
            Get
                txtJSSJ = m_strtxtJSSJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJSSJ = Value
                Catch ex As Exception
                    m_strtxtJSSJ = ""
                End Try
            End Set
        End Property

        'zengxianglin 2009-01-12
        '----------------------------------------------------------------
        ' txtSYKS属性
        '----------------------------------------------------------------
        Public Property txtSYKS() As String
            Get
                txtSYKS = m_strtxtSYKS
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtSYKS = Value
                Catch ex As Exception
                    m_strtxtSYKS = ""
                End Try
            End Set
        End Property
        '----------------------------------------------------------------
        ' txtSYJS属性
        '----------------------------------------------------------------
        Public Property txtSYJS() As String
            Get
                txtSYJS = m_strtxtSYJS
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtSYJS = Value
                Catch ex As Exception
                    m_strtxtSYJS = ""
                End Try
            End Set
        End Property
        'zengxianglin 2009-01-12

        '----------------------------------------------------------------
        ' rblHTLX_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property rblHTLX_SelectedIndex() As Integer
            Get
                rblHTLX_SelectedIndex = m_intSelectedIndex_rblHTLX
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_rblHTLX = Value
                Catch ex As Exception
                    m_intSelectedIndex_rblHTLX = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' rblSFXY_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property rblSFXY_SelectedIndex() As Integer
            Get
                rblSFXY_SelectedIndex = m_intSelectedIndex_rblSFXY
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_rblSFXY = Value
                Catch ex As Exception
                    m_intSelectedIndex_rblSFXY = -1
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
        ' grdRYLISTPageSize属性
        '----------------------------------------------------------------
        Public Property grdRYLISTPageSize() As Integer
            Get
                grdRYLISTPageSize = m_intPageSize_grdRYLIST
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdRYLIST = Value
                Catch ex As Exception
                    m_intPageSize_grdRYLIST = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdRYLISTCurrentPageIndex属性
        '----------------------------------------------------------------
        Public Property grdRYLISTCurrentPageIndex() As Integer
            Get
                grdRYLISTCurrentPageIndex = m_intCurrentPageIndex_grdRYLIST
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdRYLIST = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdRYLIST = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdRYLISTSelectedIndex属性
        '----------------------------------------------------------------
        Public Property grdRYLISTSelectedIndex() As Integer
            Get
                grdRYLISTSelectedIndex = m_intSelectedIndex_grdRYLIST
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdRYLIST = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdRYLIST = -1
                End Try
            End Set
        End Property

    End Class

End Namespace
