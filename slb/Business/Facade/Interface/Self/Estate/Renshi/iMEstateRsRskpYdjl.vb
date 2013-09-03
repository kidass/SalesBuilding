Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.BusinessFacade
    ' 类名    ：IMEstateRsRskpYdjl
    '
    ' 功能描述： 
    '     estate_rs_rskp_ydjl.aspx模块本身恢复现场需要的信息
    '----------------------------------------------------------------
    <Serializable()> Public Class IMEstateRsRskpYdjl
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
        Private m_strtxtRYLISTSearch_YDSJMin As String              'txtRYLISTSearch_YDSJMin
        Private m_strtxtRYLISTSearch_YDSJMax As String              'txtRYLISTSearch_YDSJMax
        Private m_strtxtRYLISTSearch_RZDW As String                 'txtRYLISTSearch_RZDW
        Private m_strtxtRYLISTSearch_YRDW As String                 'txtRYLISTSearch_YRDW
        Private m_intSelectedIndex_ddlRYLISTSearch_YDYY As Integer  'ddlRYLISTSearch_YDYY_SelectedIndex
        Private m_intSelectedIndex_ddlRYLISTSearch_GWSX As Integer  'ddlRYLISTSearch_GWSX_SelectedIndex
        Private m_intSelectedIndex_ddlRYLISTSearch_ZGSX As Integer  'ddlRYLISTSearch_ZGSX_SelectedIndex

        'zengxianglin 2008-10-14
        Private m_strtxtSSFZ As String                              'txtSSFZ
        Private m_strtxtYSFZ As String                              'txtYSFZ
        'zengxianglin 2008-10-14
        Private m_strhtxtWYBS As String                             'htxtWYBS
        Private m_strhtxtRYDM As String                             'htxtRYDM
        Private m_strhtxtGLBS As String                             'htxtGLBS
        Private m_strhtxtRZDW As String                             'htxtRZDW
        Private m_strhtxtYRDW As String                             'htxtYRDW
        Private m_strtxtRYMC As String                              'txtRYMC
        Private m_strtxtKSSJ As String                              'txtKSSJ
        Private m_strtxtJSSJ As String                              'txtJSSJ
        Private m_strtxtRZDW As String                              'txtRZDW
        Private m_strtxtRZJB As String                              'txtRZJB
        Private m_strtxtYRDW As String                              'txtYRDW
        Private m_strtxtYRJB As String                              'txtYRJB
        Private m_strtxtFGGZ As String                              'txtFGGZ
        Private m_strtxtBZXX As String                              'txtBZXX
        Private m_intSelectedIndex_rblGWSX As Integer               'rblGWSX_SelectedIndex
        Private m_intSelectedIndex_rblJBBZ As Integer               'rblJBBZ_SelectedIndex
        Private m_intSelectedIndex_ddlYDYY As Integer               'ddlYDYY_SelectedIndex
        Private m_intSelectedIndex_ddlZGSX As Integer               'ddlZGSX_SelectedIndex
        'zengxianglin 2010-01-06
        Private m_intSelectedIndex_rblYGSX As Integer               'rblYGSX_SelectedIndex
        Private m_intSelectedIndex_ddlYZSX As Integer               'ddlYZSX_SelectedIndex
        Private m_intSelectedIndex_rblBCZB As Integer               'rblBCZB_SelectedIndex
        Private m_intSelectedIndex_rblSCZB As Integer               'rblSCZB_SelectedIndex
        Private m_strtxtXSTD As String                              'txtXSTD
        Private m_strtxtYSTD As String                              'txtYSTD
        'zengxianglin 2010-01-06


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
            m_strtxtRYLISTSearch_YDSJMin = ""
            m_strtxtRYLISTSearch_YDSJMax = ""
            m_strtxtRYLISTSearch_RZDW = ""
            m_strtxtRYLISTSearch_YRDW = ""
            m_intSelectedIndex_ddlRYLISTSearch_YDYY = -1
            m_intSelectedIndex_ddlRYLISTSearch_GWSX = -1
            m_intSelectedIndex_ddlRYLISTSearch_ZGSX = -1

            'zengxianglin 2008-10-14
            m_strtxtSSFZ = ""
            m_strtxtYSFZ = ""
            'zengxianglin 2008-10-14
            m_strhtxtWYBS = ""
            m_strhtxtRYDM = ""
            m_strhtxtGLBS = ""
            m_strhtxtRZDW = ""
            m_strhtxtYRDW = ""
            m_strtxtRYMC = ""
            m_strtxtKSSJ = ""
            m_strtxtJSSJ = ""
            m_strtxtRZDW = ""
            m_strtxtRZJB = ""
            m_strtxtYRDW = ""
            m_strtxtYRJB = ""
            m_strtxtFGGZ = ""
            m_strtxtBZXX = ""
            m_intSelectedIndex_rblGWSX = -1
            m_intSelectedIndex_rblJBBZ = -1
            m_intSelectedIndex_ddlYDYY = -1
            m_intSelectedIndex_ddlZGSX = -1

            m_strhtxtCurrentPage = ""
            m_strhtxtCurrentRow = ""
            m_strhtxtEditMode = ""
            m_strhtxtEditType = ""

            m_intPageSize_grdRYLIST = 0
            m_intCurrentPageIndex_grdRYLIST = 0
            m_intSelectedIndex_grdRYLIST = -1

            'zengxianglin 2010-01-06
            m_intSelectedIndex_rblYGSX = -1
            m_intSelectedIndex_ddlYZSX = -1
            m_intSelectedIndex_rblBCZB = -1
            m_intSelectedIndex_rblSCZB = -1
            m_strtxtXSTD = ""
            m_strtxtYSTD = ""
            'zengxianglin 2010-01-06
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
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IMEstateRsRskpYdjl)
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
        ' txtRYLISTSearch_YDSJMin属性
        '----------------------------------------------------------------
        Public Property txtRYLISTSearch_YDSJMin() As String
            Get
                txtRYLISTSearch_YDSJMin = m_strtxtRYLISTSearch_YDSJMin
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtRYLISTSearch_YDSJMin = Value
                Catch ex As Exception
                    m_strtxtRYLISTSearch_YDSJMin = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtRYLISTSearch_YDSJMax属性
        '----------------------------------------------------------------
        Public Property txtRYLISTSearch_YDSJMax() As String
            Get
                txtRYLISTSearch_YDSJMax = m_strtxtRYLISTSearch_YDSJMax
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtRYLISTSearch_YDSJMax = Value
                Catch ex As Exception
                    m_strtxtRYLISTSearch_YDSJMax = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtRYLISTSearch_RZDW属性
        '----------------------------------------------------------------
        Public Property txtRYLISTSearch_RZDW() As String
            Get
                txtRYLISTSearch_RZDW = m_strtxtRYLISTSearch_RZDW
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtRYLISTSearch_RZDW = Value
                Catch ex As Exception
                    m_strtxtRYLISTSearch_RZDW = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtRYLISTSearch_YRDW属性
        '----------------------------------------------------------------
        Public Property txtRYLISTSearch_YRDW() As String
            Get
                txtRYLISTSearch_YRDW = m_strtxtRYLISTSearch_YRDW
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtRYLISTSearch_YRDW = Value
                Catch ex As Exception
                    m_strtxtRYLISTSearch_YRDW = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' ddlRYLISTSearch_YDYY_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property ddlRYLISTSearch_YDYY_SelectedIndex() As Integer
            Get
                ddlRYLISTSearch_YDYY_SelectedIndex = m_intSelectedIndex_ddlRYLISTSearch_YDYY
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlRYLISTSearch_YDYY = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlRYLISTSearch_YDYY = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' ddlRYLISTSearch_GWSX_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property ddlRYLISTSearch_GWSX_SelectedIndex() As Integer
            Get
                ddlRYLISTSearch_GWSX_SelectedIndex = m_intSelectedIndex_ddlRYLISTSearch_GWSX
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlRYLISTSearch_GWSX = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlRYLISTSearch_GWSX = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' ddlRYLISTSearch_ZGSX_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property ddlRYLISTSearch_ZGSX_SelectedIndex() As Integer
            Get
                ddlRYLISTSearch_ZGSX_SelectedIndex = m_intSelectedIndex_ddlRYLISTSearch_ZGSX
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlRYLISTSearch_ZGSX = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlRYLISTSearch_ZGSX = -1
                End Try
            End Set
        End Property












        'zengxianglin 2008-10-14
        '----------------------------------------------------------------
        ' txtSSFZ属性
        '----------------------------------------------------------------
        Public Property txtSSFZ() As String
            Get
                txtSSFZ = m_strtxtSSFZ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtSSFZ = Value
                Catch ex As Exception
                    m_strtxtSSFZ = ""
                End Try
            End Set
        End Property
        'zengxianglin 2008-10-14

        'zengxianglin 2008-10-14
        '----------------------------------------------------------------
        ' txtYSFZ属性
        '----------------------------------------------------------------
        Public Property txtYSFZ() As String
            Get
                txtYSFZ = m_strtxtYSFZ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtYSFZ = Value
                Catch ex As Exception
                    m_strtxtYSFZ = ""
                End Try
            End Set
        End Property
        'zengxianglin 2008-10-14

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
        ' htxtGLBS属性
        '----------------------------------------------------------------
        Public Property htxtGLBS() As String
            Get
                htxtGLBS = m_strhtxtGLBS
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtGLBS = Value
                Catch ex As Exception
                    m_strhtxtGLBS = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtRZDW属性
        '----------------------------------------------------------------
        Public Property htxtRZDW() As String
            Get
                htxtRZDW = m_strhtxtRZDW
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtRZDW = Value
                Catch ex As Exception
                    m_strhtxtRZDW = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtYRDW属性
        '----------------------------------------------------------------
        Public Property htxtYRDW() As String
            Get
                htxtYRDW = m_strhtxtYRDW
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtYRDW = Value
                Catch ex As Exception
                    m_strhtxtYRDW = ""
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

        '----------------------------------------------------------------
        ' txtRZDW属性
        '----------------------------------------------------------------
        Public Property txtRZDW() As String
            Get
                txtRZDW = m_strtxtRZDW
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtRZDW = Value
                Catch ex As Exception
                    m_strtxtRZDW = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtRZJB属性
        '----------------------------------------------------------------
        Public Property txtRZJB() As String
            Get
                txtRZJB = m_strtxtRZJB
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtRZJB = Value
                Catch ex As Exception
                    m_strtxtRZJB = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtYRDW属性
        '----------------------------------------------------------------
        Public Property txtYRDW() As String
            Get
                txtYRDW = m_strtxtYRDW
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtYRDW = Value
                Catch ex As Exception
                    m_strtxtYRDW = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtYRJB属性
        '----------------------------------------------------------------
        Public Property txtYRJB() As String
            Get
                txtYRJB = m_strtxtYRJB
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtYRJB = Value
                Catch ex As Exception
                    m_strtxtYRJB = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtFGGZ属性
        '----------------------------------------------------------------
        Public Property txtFGGZ() As String
            Get
                txtFGGZ = m_strtxtFGGZ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtFGGZ = Value
                Catch ex As Exception
                    m_strtxtFGGZ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtBZXX属性
        '----------------------------------------------------------------
        Public Property txtBZXX() As String
            Get
                txtBZXX = m_strtxtBZXX
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtBZXX = Value
                Catch ex As Exception
                    m_strtxtBZXX = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' rblGWSX_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property rblGWSX_SelectedIndex() As Integer
            Get
                rblGWSX_SelectedIndex = m_intSelectedIndex_rblGWSX
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_rblGWSX = Value
                Catch ex As Exception
                    m_intSelectedIndex_rblGWSX = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' rblJBBZ_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property rblJBBZ_SelectedIndex() As Integer
            Get
                rblJBBZ_SelectedIndex = m_intSelectedIndex_rblJBBZ
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_rblJBBZ = Value
                Catch ex As Exception
                    m_intSelectedIndex_rblJBBZ = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' ddlYDYY_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property ddlYDYY_SelectedIndex() As Integer
            Get
                ddlYDYY_SelectedIndex = m_intSelectedIndex_ddlYDYY
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlYDYY = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlYDYY = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' ddlZGSX_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property ddlZGSX_SelectedIndex() As Integer
            Get
                ddlZGSX_SelectedIndex = m_intSelectedIndex_ddlZGSX
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlZGSX = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlZGSX = -1
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











        'zengxianglin 2010-01-06
        '----------------------------------------------------------------
        ' rblYGSX_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property rblYGSX_SelectedIndex() As Integer
            Get
                rblYGSX_SelectedIndex = m_intSelectedIndex_rblYGSX
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_rblYGSX = Value
                Catch ex As Exception
                    m_intSelectedIndex_rblYGSX = -1
                End Try
            End Set
        End Property
        'zengxianglin 2010-01-06

        'zengxianglin 2010-01-06
        '----------------------------------------------------------------
        ' ddlYZSX_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property ddlYZSX_SelectedIndex() As Integer
            Get
                ddlYZSX_SelectedIndex = m_intSelectedIndex_ddlYZSX
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlYZSX = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlYZSX = -1
                End Try
            End Set
        End Property
        'zengxianglin 2010-01-06

        'zengxianglin 2010-01-06
        '----------------------------------------------------------------
        ' rblBCZB_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property rblBCZB_SelectedIndex() As Integer
            Get
                rblBCZB_SelectedIndex = m_intSelectedIndex_rblBCZB
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_rblBCZB = Value
                Catch ex As Exception
                    m_intSelectedIndex_rblBCZB = -1
                End Try
            End Set
        End Property
        'zengxianglin 2010-01-06

        'zengxianglin 2010-01-06
        '----------------------------------------------------------------
        ' rblSCZB_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property rblSCZB_SelectedIndex() As Integer
            Get
                rblSCZB_SelectedIndex = m_intSelectedIndex_rblSCZB
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_rblSCZB = Value
                Catch ex As Exception
                    m_intSelectedIndex_rblSCZB = -1
                End Try
            End Set
        End Property
        'zengxianglin 2010-01-06

        'zengxianglin 2010-01-06
        '----------------------------------------------------------------
        ' txtXSTD属性
        '----------------------------------------------------------------
        Public Property txtXSTD() As String
            Get
                txtXSTD = m_strtxtXSTD
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtXSTD = Value
                Catch ex As Exception
                    m_strtxtXSTD = ""
                End Try
            End Set
        End Property
        'zengxianglin 2010-01-06

        'zengxianglin 2010-01-06
        '----------------------------------------------------------------
        ' txtYSTD属性
        '----------------------------------------------------------------
        Public Property txtYSTD() As String
            Get
                txtYSTD = m_strtxtYSTD
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtYSTD = Value
                Catch ex As Exception
                    m_strtxtYSTD = ""
                End Try
            End Set
        End Property
        'zengxianglin 2010-01-06

    End Class

End Namespace
