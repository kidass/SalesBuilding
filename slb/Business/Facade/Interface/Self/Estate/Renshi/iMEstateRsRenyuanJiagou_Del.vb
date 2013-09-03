Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.BusinessFacade
    ' 类名    ：IMEstateRsRenyuanJiagou_Del
    '
    ' 功能描述： 
    '     estate_rs_renyuanjiagou_del.aspx模块本身恢复现场需要的信息
    '----------------------------------------------------------------
    <Serializable()> Public Class IMEstateRsRenyuanJiagou_Del
        Implements IDisposable

        '----------------------------------------------------------------
        ' 模块属性
        '----------------------------------------------------------------
        Private m_strhtxtDivLeftBody As String              'htxtDivLeftBody
        Private m_strhtxtDivTopBody As String               'htxtDivTopBody
        Private m_strhtxtDivLeftMain As String              'htxtDivLeftMain
        Private m_strhtxtDivTopMain As String               'htxtDivTopMain
        Private m_strhtxtDivLeftRY As String                'htxtDivLeftRY
        Private m_strhtxtDivTopRY As String                 'htxtDivTopRY
        Private m_strhtxtDivLeftXJ As String                'htxtDivLeftXJ
        Private m_strhtxtDivTopXJ As String                 'htxtDivTopXJ

        Private m_strhtxtSessionIdQuery_RY As String        'htxtSessionIdQuery_RY
        Private m_strhtxtQuery_RY As String                 'htxtQuery_RY
        Private m_intCurrentPageIndex_grdRY As Integer      'grdRY_CurrentPageIndex
        Private m_intSelectedIndex_grdRY As Integer         'grdRY_SelectedIndex
        Private m_intPageSize_grdRY As Integer              'grdRY_PageSize

        Private m_strhtxtSessionId_XJ As String             'htxtSessionId_XJ
        Private m_intCurrentPageIndex_grdXJ As Integer      'grdXJ_CurrentPageIndex
        Private m_intSelectedIndex_grdXJ As Integer         'grdXJ_SelectedIndex
        Private m_intPageSize_grdXJ As Integer              'grdXJ_PageSize

        Private m_intSelectedIndex_ddlYDYY As Integer       'ddlYDYY_SelectedIndex
        Private m_intSelectedIndex_rblBDLX As Integer       'rblBDLX_SelectedIndex
        Private m_strtxtSXSJ As String                      'txtSXSJ

        Private m_strtxtSearch_RY_RYDM As String            'txtSearch_RY_RYDM
        Private m_strtxtSearch_RY_ZJDM As String            'txtSearch_RY_ZJDM
        Private m_strtxtSearch_RY_RYMC As String            'txtSearch_RY_RYMC
        Private m_strtxtSearch_RY_DWMC As String            'txtSearch_RY_DWMC

        'zengxianglin 2008-10-14
        Private m_strtxtRYPageIndex As String               'txtRYPageIndex
        Private m_strtxtRYPageSize As String                'txtRYPageSize
        Private m_strhtxtRYRows As String                   'htxtRYRows
        Private m_strtxtXJPageIndex As String               'txtXJPageIndex
        Private m_strtxtXJPageSize As String                'txtXJPageSize
        Private m_strhtxtXJRows As String                   'htxtXJRows
        'zengxianglin 2008-10-14
        Private m_strtxtZZDM_XJ As String                   'txtZZDM_XJ
        Private m_strhtxtZZDM_XJ As String                  'htxtZZDM_XJ
        Private m_intSelectedIndex_ddlZJDM_XJ As Integer    'ddlZJDM_XJ_SelectedIndex
        Private m_intSelectedIndex_ddlSSFZ_XJ As Integer    'ddlSSFZ_XJ_SelectedIndex
        Private m_intSelectedIndex_ddlYDYY_XJ As Integer    'ddlYDYY_XJ_SelectedIndex
        Private m_intSelectedIndex_rblRYZT_XJ As Integer    'rblRYZT_XJ_SelectedIndex
        Private m_intSelectedIndex_rblSFZB_XJ As Integer    'rblSFZB_XJ_SelectedIndex
        'zengxianglin 2008-10-14
        Private m_strhtxtSJLD_XJ As String                  'htxtSJLD_XJ
        Private m_strtxtSJLD_XJ As String                   'txtSJLD_XJ

        'zengxianglin 2008-11-18
        Private m_strtxtZGDW As String                      'txtZGDW
        Private m_strhtxtZGDW As String                     'htxtZGDW
        Private m_strtxtZGDW_XJ As String                   'txtZGDW_XJ
        Private m_strhtxtZGDW_XJ As String                  'htxtZGDW_XJ
        'zengxianglin 2008-11-18










        '----------------------------------------------------------------
        ' 构造函数
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()

            m_strhtxtDivLeftBody = ""
            m_strhtxtDivTopBody = ""
            m_strhtxtDivLeftMain = ""
            m_strhtxtDivTopMain = ""
            m_strhtxtDivLeftRY = ""
            m_strhtxtDivTopRY = ""
            m_strhtxtDivLeftXJ = ""
            m_strhtxtDivTopXJ = ""

            m_strhtxtSessionIdQuery_RY = ""
            m_strhtxtQuery_RY = ""
            m_intCurrentPageIndex_grdRY = 0
            m_intSelectedIndex_grdRY = -1
            m_intPageSize_grdRY = 30

            m_strhtxtSessionId_XJ = ""
            m_intCurrentPageIndex_grdXJ = 0
            m_intSelectedIndex_grdXJ = -1
            m_intPageSize_grdXJ = 30

            m_intSelectedIndex_ddlYDYY = -1
            m_intSelectedIndex_rblBDLX = -1
            m_strtxtSXSJ = ""

            m_strhtxtSJLD_XJ = ""
            m_strtxtSJLD_XJ = ""

            m_strtxtSearch_RY_RYDM = ""
            m_strtxtSearch_RY_ZJDM = ""
            m_strtxtSearch_RY_RYMC = ""
            m_strtxtSearch_RY_DWMC = ""

            'zengxianglin 2008-10-14
            m_strtxtRYPageIndex = ""
            m_strtxtRYPageSize = "30"
            m_strhtxtRYRows = ""
            m_strtxtXJPageIndex = ""
            m_strtxtXJPageSize = "30"
            m_strhtxtXJRows = ""
            'zengxianglin 2008-10-14
            m_strtxtZZDM_XJ = ""
            m_strhtxtZZDM_XJ = ""
            m_intSelectedIndex_ddlZJDM_XJ = -1
            m_intSelectedIndex_ddlSSFZ_XJ = -1
            m_intSelectedIndex_ddlYDYY_XJ = -1
            m_intSelectedIndex_rblRYZT_XJ = -1
            m_intSelectedIndex_rblSFZB_XJ = -1
            'zengxianglin 2008-10-14

            'zengxianglin 2008-11-18
            m_strtxtZGDW = ""
            m_strhtxtZGDW = ""
            m_strtxtZGDW_XJ = ""
            m_strhtxtZGDW_XJ = ""
            'zengxianglin 2008-11-18

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
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IMEstateRsRenyuanJiagou_Del)
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
        ' htxtDivLeftRY属性
        '----------------------------------------------------------------
        Public Property htxtDivLeftRY() As String
            Get
                htxtDivLeftRY = m_strhtxtDivLeftRY
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivLeftRY = Value
                Catch ex As Exception
                    m_strhtxtDivLeftRY = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopRY属性
        '----------------------------------------------------------------
        Public Property htxtDivTopRY() As String
            Get
                htxtDivTopRY = m_strhtxtDivTopRY
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivTopRY = Value
                Catch ex As Exception
                    m_strhtxtDivTopRY = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivLeftXJ属性
        '----------------------------------------------------------------
        Public Property htxtDivLeftXJ() As String
            Get
                htxtDivLeftXJ = m_strhtxtDivLeftXJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivLeftXJ = Value
                Catch ex As Exception
                    m_strhtxtDivLeftXJ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopXJ属性
        '----------------------------------------------------------------
        Public Property htxtDivTopXJ() As String
            Get
                htxtDivTopXJ = m_strhtxtDivTopXJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivTopXJ = Value
                Catch ex As Exception
                    m_strhtxtDivTopXJ = ""
                End Try
            End Set
        End Property









        '----------------------------------------------------------------
        ' htxtSessionIdQuery_RY属性
        '----------------------------------------------------------------
        Public Property htxtSessionIdQuery_RY() As String
            Get
                htxtSessionIdQuery_RY = m_strhtxtSessionIdQuery_RY
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSessionIdQuery_RY = Value
                Catch ex As Exception
                    m_strhtxtSessionIdQuery_RY = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtQuery_RY属性
        '----------------------------------------------------------------
        Public Property htxtQuery_RY() As String
            Get
                htxtQuery_RY = m_strhtxtQuery_RY
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtQuery_RY = Value
                Catch ex As Exception
                    m_strhtxtQuery_RY = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdRY_CurrentPageIndex属性
        '----------------------------------------------------------------
        Public Property grdRY_CurrentPageIndex() As Integer
            Get
                grdRY_CurrentPageIndex = m_intCurrentPageIndex_grdRY
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdRY = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdRY = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdRY_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property grdRY_SelectedIndex() As Integer
            Get
                grdRY_SelectedIndex = m_intSelectedIndex_grdRY
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdRY = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdRY = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdRY_PageSize属性
        '----------------------------------------------------------------
        Public Property grdRY_PageSize() As Integer
            Get
                grdRY_PageSize = m_intPageSize_grdRY
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdRY = Value
                Catch ex As Exception
                    m_intPageSize_grdRY = 0
                End Try
            End Set
        End Property










        '----------------------------------------------------------------
        ' htxtSessionId_XJ属性
        '----------------------------------------------------------------
        Public Property htxtSessionId_XJ() As String
            Get
                htxtSessionId_XJ = m_strhtxtSessionId_XJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSessionId_XJ = Value
                Catch ex As Exception
                    m_strhtxtSessionId_XJ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdXJ_CurrentPageIndex属性
        '----------------------------------------------------------------
        Public Property grdXJ_CurrentPageIndex() As Integer
            Get
                grdXJ_CurrentPageIndex = m_intCurrentPageIndex_grdXJ
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdXJ = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdXJ = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdXJ_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property grdXJ_SelectedIndex() As Integer
            Get
                grdXJ_SelectedIndex = m_intSelectedIndex_grdXJ
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdXJ = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdXJ = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdXJ_PageSize属性
        '----------------------------------------------------------------
        Public Property grdXJ_PageSize() As Integer
            Get
                grdXJ_PageSize = m_intPageSize_grdXJ
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdXJ = Value
                Catch ex As Exception
                    m_intPageSize_grdXJ = 0
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
        ' rblBDLX_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property rblBDLX_SelectedIndex() As Integer
            Get
                rblBDLX_SelectedIndex = m_intSelectedIndex_rblBDLX
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_rblBDLX = Value
                Catch ex As Exception
                    m_intSelectedIndex_rblBDLX = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtSXSJ属性
        '----------------------------------------------------------------
        Public Property txtSXSJ() As String
            Get
                txtSXSJ = m_strtxtSXSJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtSXSJ = Value
                Catch ex As Exception
                    m_strtxtSXSJ = ""
                End Try
            End Set
        End Property









        '----------------------------------------------------------------
        ' htxtSJLD_XJ属性
        '----------------------------------------------------------------
        Public Property htxtSJLD_XJ() As String
            Get
                htxtSJLD_XJ = m_strhtxtSJLD_XJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSJLD_XJ = Value
                Catch ex As Exception
                    m_strhtxtSJLD_XJ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtSJLD_XJ属性
        '----------------------------------------------------------------
        Public Property txtSJLD_XJ() As String
            Get
                txtSJLD_XJ = m_strtxtSJLD_XJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtSJLD_XJ = Value
                Catch ex As Exception
                    m_strtxtSJLD_XJ = ""
                End Try
            End Set
        End Property









        '----------------------------------------------------------------
        ' txtSearch_RY_RYDM属性
        '----------------------------------------------------------------
        Public Property txtSearch_RY_RYDM() As String
            Get
                txtSearch_RY_RYDM = m_strtxtSearch_RY_RYDM
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtSearch_RY_RYDM = Value
                Catch ex As Exception
                    m_strtxtSearch_RY_RYDM = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtSearch_RY_ZJDM属性
        '----------------------------------------------------------------
        Public Property txtSearch_RY_ZJDM() As String
            Get
                txtSearch_RY_ZJDM = m_strtxtSearch_RY_ZJDM
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtSearch_RY_ZJDM = Value
                Catch ex As Exception
                    m_strtxtSearch_RY_ZJDM = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtSearch_RY_RYMC属性
        '----------------------------------------------------------------
        Public Property txtSearch_RY_RYMC() As String
            Get
                txtSearch_RY_RYMC = m_strtxtSearch_RY_RYMC
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtSearch_RY_RYMC = Value
                Catch ex As Exception
                    m_strtxtSearch_RY_RYMC = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtSearch_RY_DWMC属性
        '----------------------------------------------------------------
        Public Property txtSearch_RY_DWMC() As String
            Get
                txtSearch_RY_DWMC = m_strtxtSearch_RY_DWMC
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtSearch_RY_DWMC = Value
                Catch ex As Exception
                    m_strtxtSearch_RY_DWMC = ""
                End Try
            End Set
        End Property









        'zengxianglin 2008-10-14
        '----------------------------------------------------------------
        ' txtRYPageSize属性
        '----------------------------------------------------------------
        Public Property txtRYPageSize() As String
            Get
                txtRYPageSize = m_strtxtRYPageSize
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtRYPageSize = Value
                Catch ex As Exception
                    m_strtxtRYPageSize = ""
                End Try
            End Set
        End Property
        'zengxianglin 2008-10-14

        'zengxianglin 2008-10-14
        '----------------------------------------------------------------
        ' txtRYPageIndex属性
        '----------------------------------------------------------------
        Public Property txtRYPageIndex() As String
            Get
                txtRYPageIndex = m_strtxtRYPageIndex
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtRYPageIndex = Value
                Catch ex As Exception
                    m_strtxtRYPageIndex = ""
                End Try
            End Set
        End Property
        'zengxianglin 2008-10-14

        'zengxianglin 2008-10-14
        '----------------------------------------------------------------
        ' htxtRYRows属性
        '----------------------------------------------------------------
        Public Property htxtRYRows() As String
            Get
                htxtRYRows = m_strhtxtRYRows
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtRYRows = Value
                Catch ex As Exception
                    m_strhtxtRYRows = ""
                End Try
            End Set
        End Property
        'zengxianglin 2008-10-14











        'zengxianglin 2008-10-14
        '----------------------------------------------------------------
        ' txtXJPageSize属性
        '----------------------------------------------------------------
        Public Property txtXJPageSize() As String
            Get
                txtXJPageSize = m_strtxtXJPageSize
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtXJPageSize = Value
                Catch ex As Exception
                    m_strtxtXJPageSize = ""
                End Try
            End Set
        End Property
        'zengxianglin 2008-10-14

        'zengxianglin 2008-10-14
        '----------------------------------------------------------------
        ' txtXJPageIndex属性
        '----------------------------------------------------------------
        Public Property txtXJPageIndex() As String
            Get
                txtXJPageIndex = m_strtxtXJPageIndex
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtXJPageIndex = Value
                Catch ex As Exception
                    m_strtxtXJPageIndex = ""
                End Try
            End Set
        End Property
        'zengxianglin 2008-10-14

        'zengxianglin 2008-10-14
        '----------------------------------------------------------------
        ' htxtXJRows属性
        '----------------------------------------------------------------
        Public Property htxtXJRows() As String
            Get
                htxtXJRows = m_strhtxtXJRows
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtXJRows = Value
                Catch ex As Exception
                    m_strhtxtXJRows = ""
                End Try
            End Set
        End Property
        'zengxianglin 2008-10-14









        'zengxianglin 2008-10-14
        '----------------------------------------------------------------
        ' htxtZZDM_XJ属性
        '----------------------------------------------------------------
        Public Property htxtZZDM_XJ() As String
            Get
                htxtZZDM_XJ = m_strhtxtZZDM_XJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtZZDM_XJ = Value
                Catch ex As Exception
                    m_strhtxtZZDM_XJ = ""
                End Try
            End Set
        End Property
        'zengxianglin 2008-10-14

        'zengxianglin 2008-10-14
        '----------------------------------------------------------------
        ' txtZZDM_XJ属性
        '----------------------------------------------------------------
        Public Property txtZZDM_XJ() As String
            Get
                txtZZDM_XJ = m_strtxtZZDM_XJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtZZDM_XJ = Value
                Catch ex As Exception
                    m_strtxtZZDM_XJ = ""
                End Try
            End Set
        End Property
        'zengxianglin 2008-10-14

        'zengxianglin 2008-10-14
        '----------------------------------------------------------------
        ' ddlZJDM_XJ_SelectedIndex
        '----------------------------------------------------------------
        Public Property ddlZJDM_XJ_SelectedIndex() As Integer
            Get
                ddlZJDM_XJ_SelectedIndex = m_intSelectedIndex_ddlZJDM_XJ
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlZJDM_XJ = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlZJDM_XJ = -1
                End Try
            End Set
        End Property
        'zengxianglin 2008-10-14

        'zengxianglin 2008-10-14
        '----------------------------------------------------------------
        ' ddlSSFZ_XJ_SelectedIndex
        '----------------------------------------------------------------
        Public Property ddlSSFZ_XJ_SelectedIndex() As Integer
            Get
                ddlSSFZ_XJ_SelectedIndex = m_intSelectedIndex_ddlSSFZ_XJ
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlSSFZ_XJ = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlSSFZ_XJ = -1
                End Try
            End Set
        End Property
        'zengxianglin 2008-10-14

        'zengxianglin 2008-10-14
        '----------------------------------------------------------------
        ' ddlYDYY_XJ_SelectedIndex
        '----------------------------------------------------------------
        Public Property ddlYDYY_XJ_SelectedIndex() As Integer
            Get
                ddlYDYY_XJ_SelectedIndex = m_intSelectedIndex_ddlYDYY_XJ
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlYDYY_XJ = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlYDYY_XJ = -1
                End Try
            End Set
        End Property
        'zengxianglin 2008-10-14

        'zengxianglin 2008-10-14
        '----------------------------------------------------------------
        ' rblRYZT_XJ_SelectedIndex
        '----------------------------------------------------------------
        Public Property rblRYZT_XJ_SelectedIndex() As Integer
            Get
                rblRYZT_XJ_SelectedIndex = m_intSelectedIndex_rblRYZT_XJ
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_rblRYZT_XJ = Value
                Catch ex As Exception
                    m_intSelectedIndex_rblRYZT_XJ = -1
                End Try
            End Set
        End Property
        'zengxianglin 2008-10-14

        'zengxianglin 2008-10-14
        '----------------------------------------------------------------
        ' rblSFZB_XJ_SelectedIndex
        '----------------------------------------------------------------
        Public Property rblSFZB_XJ_SelectedIndex() As Integer
            Get
                rblSFZB_XJ_SelectedIndex = m_intSelectedIndex_rblSFZB_XJ
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_rblSFZB_XJ = Value
                Catch ex As Exception
                    m_intSelectedIndex_rblSFZB_XJ = -1
                End Try
            End Set
        End Property
        'zengxianglin 2008-10-14










        'zengxianglin 2008-11-18
        '----------------------------------------------------------------
        ' htxtZGDW_XJ属性
        '----------------------------------------------------------------
        Public Property htxtZGDW_XJ() As String
            Get
                htxtZGDW_XJ = m_strhtxtZGDW_XJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtZGDW_XJ = Value
                Catch ex As Exception
                    m_strhtxtZGDW_XJ = ""
                End Try
            End Set
        End Property
        'zengxianglin 2008-11-18

        'zengxianglin 2008-11-18
        '----------------------------------------------------------------
        ' txtZGDW_XJ属性
        '----------------------------------------------------------------
        Public Property txtZGDW_XJ() As String
            Get
                txtZGDW_XJ = m_strtxtZGDW_XJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtZGDW_XJ = Value
                Catch ex As Exception
                    m_strtxtZGDW_XJ = ""
                End Try
            End Set
        End Property
        'zengxianglin 2008-11-18

        'zengxianglin 2008-11-18
        '----------------------------------------------------------------
        ' htxtZGDW属性
        '----------------------------------------------------------------
        Public Property htxtZGDW() As String
            Get
                htxtZGDW = m_strhtxtZGDW
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtZGDW = Value
                Catch ex As Exception
                    m_strhtxtZGDW = ""
                End Try
            End Set
        End Property
        'zengxianglin 2008-11-18

        'zengxianglin 2008-11-18
        '----------------------------------------------------------------
        ' txtZGDW属性
        '----------------------------------------------------------------
        Public Property txtZGDW() As String
            Get
                txtZGDW = m_strtxtZGDW
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtZGDW = Value
                Catch ex As Exception
                    m_strtxtZGDW = ""
                End Try
            End Set
        End Property
        'zengxianglin 2008-11-18

    End Class

End Namespace
