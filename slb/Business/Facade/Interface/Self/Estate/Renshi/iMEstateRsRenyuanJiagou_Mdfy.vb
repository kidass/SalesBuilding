Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.BusinessFacade
    ' 类名    ：IMEstateRsRenyuanJiagou_Mdfy
    '
    ' 功能描述： 
    '     estate_rs_renyuanjiagou_mdfy.aspx模块本身恢复现场需要的信息
    '----------------------------------------------------------------
    <Serializable()> Public Class IMEstateRsRenyuanJiagou_Mdfy
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
        Private m_strhtxtDivLeftNXJ As String               'htxtDivLeftNXJ
        Private m_strhtxtDivTopNXJ As String                'htxtDivTopNXJ

        Private m_strhtxtSessionIdQuery_RY As String        'htxtSessionIdQuery_RY
        Private m_strhtxtQuery_RY As String                 'htxtQuery_RY
        Private m_strhtxtSessionId_NXJ As String            'htxtSessionId_NXJ

        Private m_intCurrentPageIndex_grdRY As Integer      'grdRY_CurrentPageIndex
        Private m_intSelectedIndex_grdRY As Integer         'grdRY_SelectedIndex
        Private m_intPageSize_grdRY As Integer              'grdRY_PageSize

        Private m_strhtxtSessionId_XJ As String             'htxtSessionId_XJ
        Private m_intCurrentPageIndex_grdXJ As Integer      'grdXJ_CurrentPageIndex
        Private m_intSelectedIndex_grdXJ As Integer         'grdXJ_SelectedIndex
        Private m_intPageSize_grdXJ As Integer              'grdXJ_PageSize

        Private m_strhtxtSessionIdQuery_NXJ As String       'htxtSessionIdQuery_NXJ
        Private m_strhtxtQuery_NXJ As String                'htxtQuery_NXJ
        Private m_intCurrentPageIndex_grdNXJ As Integer     'grdNXJ_CurrentPageIndex
        Private m_intSelectedIndex_grdNXJ As Integer        'grdNXJ_SelectedIndex
        Private m_intPageSize_grdNXJ As Integer             'grdNXJ_PageSize

        Private m_intSelectedIndex_ddlYDYY As Integer       'ddlYDYY_SelectedIndex
        Private m_intSelectedIndex_ddlZJDM As Integer       'ddlZJDM_SelectedIndex
        Private m_intSelectedIndex_ddlSSFZ As Integer       'ddlSSFZ_SelectedIndex
        Private m_intSelectedIndex_rblRYZT As Integer       'rblRYZT_SelectedIndex
        Private m_intSelectedIndex_rblSFZB As Integer       'rblRYZB_SelectedIndex
        Private m_strtxtSSDW As String                      'txtSSDW
        Private m_strhtxtSSDW As String                     'htxtSSDW
        Private m_strtxtSJLD As String                      'txtSJLD
        Private m_strhtxtSJLD As String                     'htxtSJLD
        Private m_strtxtSXSJ As String                      'txtSXSJ
        Private m_blnChecked_chkTZYXJ As Boolean            'chkTZYXJ_Checked
        Private m_blnChecked_chkTZNXJ As Boolean            'chkTZNXJ_Checked

        Private m_strtxtSJLD_XJ As String                   'txtSJLD_XJ
        Private m_strhtxtSJLD_XJ As String                  'htxtSJLD_XJ

        Private m_strtxtSearch_RY_RYDM As String            'txtSearch_RY_RYDM
        Private m_strtxtSearch_RY_ZJDM As String            'txtSearch_RY_ZJDM
        Private m_strtxtSearch_RY_RYMC As String            'txtSearch_RY_RYMC
        Private m_strtxtSearch_RY_DWMC As String            'txtSearch_RY_DWMC

        Private m_strtxtSearch_NXJ_RYDM As String           'txtSearch_NXJ_RYDM
        Private m_strtxtSearch_NXJ_ZJDM As String           'txtSearch_NXJ_ZJDM
        Private m_strtxtSearch_NXJ_RYMC As String           'txtSearch_NXJ_RYMC
        Private m_strtxtSearch_NXJ_DWMC As String           'txtSearch_NXJ_DWMC

        'zengxianglin 2008-10-14
        Private m_strtxtRYPageIndex As String               'txtRYPageIndex
        Private m_strtxtRYPageSize As String                'txtRYPageSize
        Private m_strhtxtRYRows As String                   'htxtRYRows
        Private m_strtxtXJPageIndex As String               'txtXJPageIndex
        Private m_strtxtXJPageSize As String                'txtXJPageSize
        Private m_strhtxtXJRows As String                   'htxtXJRows
        Private m_strtxtNXJPageIndex As String              'txtNXJPageIndex
        Private m_strtxtNXJPageSize As String               'txtNXJPageSize
        Private m_strhtxtNXJRows As String                  'htxtNXJRows
        'zengxianglin 2008-10-14

        'zengxianglin 2008-10-14
        Private m_strtxtZZDM_XJ As String                   'txtZZDM_XJ
        Private m_strhtxtZZDM_XJ As String                  'htxtZZDM_XJ
        Private m_intSelectedIndex_ddlZJDM_XJ As Integer    'ddlZJDM_XJ_SelectedIndex
        Private m_intSelectedIndex_ddlSSFZ_XJ As Integer    'ddlSSFZ_XJ_SelectedIndex
        Private m_intSelectedIndex_ddlYDYY_XJ As Integer    'ddlYDYY_XJ_SelectedIndex
        Private m_intSelectedIndex_rblRYZT_XJ As Integer    'rblRYZT_XJ_SelectedIndex
        Private m_intSelectedIndex_rblSFZB_XJ As Integer    'rblRYZB_XJ_SelectedIndex
        'zengxianglin 2008-10-14

        'zengxianglin 2008-10-14
        Private m_strtxtZZDM_NXJ As String                  'txtZZDM_NXJ
        Private m_strhtxtZZDM_NXJ As String                 'htxtZZDM_NXJ
        Private m_intSelectedIndex_ddlZJDM_NXJ As Integer   'ddlZJDM_NXJ_SelectedIndex
        Private m_intSelectedIndex_ddlSSFZ_NXJ As Integer   'ddlSSFZ_NXJ_SelectedIndex
        Private m_intSelectedIndex_ddlYDYY_NXJ As Integer   'ddlYDYY_NXJ_SelectedIndex
        Private m_intSelectedIndex_rblRYZT_NXJ As Integer   'rblRYZT_NXJ_SelectedIndex
        Private m_intSelectedIndex_rblSFZB_NXJ As Integer   'rblRYZB_NXJ_SelectedIndex
        'zengxianglin 2008-10-14

        'zengxianglin 2008-11-18
        Private m_strtxtZGDW As String                      'txtZGDW
        Private m_strhtxtZGDW As String                     'htxtZGDW
        Private m_strtxtZGDW_XJ As String                   'txtZGDW_XJ
        Private m_strhtxtZGDW_XJ As String                  'htxtZGDW_XJ
        Private m_strtxtZGDW_NXJ As String                  'txtZGDW_NXJ
        Private m_strhtxtZGDW_NXJ As String                 'htxtZGDW_NXJ
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
            m_strhtxtDivLeftNXJ = ""
            m_strhtxtDivTopNXJ = ""

            m_strhtxtSessionIdQuery_RY = ""
            m_strhtxtQuery_RY = ""
            m_strhtxtSessionId_NXJ = ""

            m_intCurrentPageIndex_grdRY = 0
            m_intSelectedIndex_grdRY = -1
            m_intPageSize_grdRY = 30

            m_strhtxtSessionId_XJ = ""
            m_intCurrentPageIndex_grdXJ = 0
            m_intSelectedIndex_grdXJ = -1
            m_intPageSize_grdXJ = 30

            m_strhtxtSessionIdQuery_NXJ = ""
            m_strhtxtQuery_NXJ = ""
            m_intCurrentPageIndex_grdNXJ = 0
            m_intSelectedIndex_grdNXJ = -1
            m_intPageSize_grdNXJ = 30

            m_intSelectedIndex_ddlYDYY = -1
            m_intSelectedIndex_ddlZJDM = -1
            m_intSelectedIndex_ddlSSFZ = -1
            m_intSelectedIndex_rblRYZT = -1
            m_intSelectedIndex_rblSFZB = -1
            m_strtxtSSDW = ""
            m_strhtxtSSDW = ""
            m_strhtxtSJLD = ""
            m_strtxtSJLD = ""
            m_strtxtSXSJ = ""
            m_blnChecked_chkTZYXJ = False
            m_blnChecked_chkTZNXJ = False

            m_strtxtSearch_RY_RYDM = ""
            m_strtxtSearch_RY_ZJDM = ""
            m_strtxtSearch_RY_RYMC = ""
            m_strtxtSearch_RY_DWMC = ""

            m_strtxtSearch_NXJ_RYDM = ""
            m_strtxtSearch_NXJ_ZJDM = ""
            m_strtxtSearch_NXJ_RYMC = ""
            m_strtxtSearch_NXJ_DWMC = ""

            'zengxianglin 2008-10-14
            m_strtxtRYPageIndex = ""
            m_strtxtRYPageSize = "30"
            m_strhtxtRYRows = ""
            m_strtxtXJPageIndex = ""
            m_strtxtXJPageSize = "30"
            m_strhtxtXJRows = ""
            m_strtxtNXJPageIndex = ""
            m_strtxtNXJPageSize = "30"
            m_strhtxtNXJRows = ""
            'zengxianglin 2008-10-14

            m_strtxtSJLD_XJ = ""
            m_strhtxtSJLD_XJ = ""
            'zengxianglin 2008-10-14
            m_strtxtZZDM_XJ = ""
            m_strhtxtZZDM_XJ = ""
            m_intSelectedIndex_ddlZJDM_XJ = -1
            m_intSelectedIndex_ddlSSFZ_XJ = -1
            m_intSelectedIndex_ddlYDYY_XJ = -1
            m_intSelectedIndex_rblRYZT_XJ = -1
            m_intSelectedIndex_rblSFZB_XJ = -1
            'zengxianglin 2008-10-14

            'zengxianglin 2008-10-14
            m_strtxtZZDM_NXJ = ""
            m_strhtxtZZDM_NXJ = ""
            m_intSelectedIndex_ddlZJDM_NXJ = -1
            m_intSelectedIndex_ddlSSFZ_NXJ = -1
            m_intSelectedIndex_ddlYDYY_NXJ = -1
            m_intSelectedIndex_rblRYZT_NXJ = -1
            m_intSelectedIndex_rblSFZB_NXJ = -1
            'zengxianglin 2008-10-14

            'zengxianglin 2008-11-18
            m_strtxtZGDW = ""
            m_strhtxtZGDW = ""
            m_strtxtZGDW_XJ = ""
            m_strhtxtZGDW_XJ = ""
            m_strtxtZGDW_NXJ = ""
            m_strhtxtZGDW_NXJ = ""
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
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IMEstateRsRenyuanJiagou_Mdfy)
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
        ' htxtDivLeftNXJ属性
        '----------------------------------------------------------------
        Public Property htxtDivLeftNXJ() As String
            Get
                htxtDivLeftNXJ = m_strhtxtDivLeftNXJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivLeftNXJ = Value
                Catch ex As Exception
                    m_strhtxtDivLeftNXJ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopNXJ属性
        '----------------------------------------------------------------
        Public Property htxtDivTopNXJ() As String
            Get
                htxtDivTopNXJ = m_strhtxtDivTopNXJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivTopNXJ = Value
                Catch ex As Exception
                    m_strhtxtDivTopNXJ = ""
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
        ' htxtSessionIdQuery_NXJ属性
        '----------------------------------------------------------------
        Public Property htxtSessionIdQuery_NXJ() As String
            Get
                htxtSessionIdQuery_NXJ = m_strhtxtSessionIdQuery_NXJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSessionIdQuery_NXJ = Value
                Catch ex As Exception
                    m_strhtxtSessionIdQuery_NXJ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtQuery_NXJ属性
        '----------------------------------------------------------------
        Public Property htxtQuery_NXJ() As String
            Get
                htxtQuery_NXJ = m_strhtxtQuery_NXJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtQuery_NXJ = Value
                Catch ex As Exception
                    m_strhtxtQuery_NXJ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtSessionId_NXJ属性
        '----------------------------------------------------------------
        Public Property htxtSessionId_NXJ() As String
            Get
                htxtSessionId_NXJ = m_strhtxtSessionId_NXJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSessionId_NXJ = Value
                Catch ex As Exception
                    m_strhtxtSessionId_NXJ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdNXJ_CurrentPageIndex属性
        '----------------------------------------------------------------
        Public Property grdNXJ_CurrentPageIndex() As Integer
            Get
                grdNXJ_CurrentPageIndex = m_intCurrentPageIndex_grdNXJ
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdNXJ = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdNXJ = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdNXJ_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property grdNXJ_SelectedIndex() As Integer
            Get
                grdNXJ_SelectedIndex = m_intSelectedIndex_grdNXJ
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdNXJ = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdNXJ = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdNXJ_PageSize属性
        '----------------------------------------------------------------
        Public Property grdNXJ_PageSize() As Integer
            Get
                grdNXJ_PageSize = m_intPageSize_grdNXJ
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdNXJ = Value
                Catch ex As Exception
                    m_intPageSize_grdNXJ = 0
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
        ' ddlZJDM_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property ddlZJDM_SelectedIndex() As Integer
            Get
                ddlZJDM_SelectedIndex = m_intSelectedIndex_ddlZJDM
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlZJDM = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlZJDM = -1
                End Try
            End Set
        End Property



        '----------------------------------------------------------------
        ' ddlSSFZ_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property ddlSSFZ_SelectedIndex() As Integer
            Get
                ddlSSFZ_SelectedIndex = m_intSelectedIndex_ddlSSFZ
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlSSFZ = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlSSFZ = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' rblRYZT_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property rblRYZT_SelectedIndex() As Integer
            Get
                rblRYZT_SelectedIndex = m_intSelectedIndex_rblRYZT
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_rblRYZT = Value
                Catch ex As Exception
                    m_intSelectedIndex_rblRYZT = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' rblSFZB_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property rblSFZB_SelectedIndex() As Integer
            Get
                rblSFZB_SelectedIndex = m_intSelectedIndex_rblSFZB
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_rblSFZB = Value
                Catch ex As Exception
                    m_intSelectedIndex_rblSFZB = -1
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
        ' htxtSJLD属性
        '----------------------------------------------------------------
        Public Property htxtSJLD() As String
            Get
                htxtSJLD = m_strhtxtSJLD
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSJLD = Value
                Catch ex As Exception
                    m_strhtxtSJLD = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtSJLD属性
        '----------------------------------------------------------------
        Public Property txtSJLD() As String
            Get
                txtSJLD = m_strtxtSJLD
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtSJLD = Value
                Catch ex As Exception
                    m_strtxtSJLD = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtSSDW属性
        '----------------------------------------------------------------
        Public Property htxtSSDW() As String
            Get
                htxtSSDW = m_strhtxtSSDW
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSSDW = Value
                Catch ex As Exception
                    m_strhtxtSSDW = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtSSDW属性
        '----------------------------------------------------------------
        Public Property txtSSDW() As String
            Get
                txtSSDW = m_strtxtSSDW
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtSSDW = Value
                Catch ex As Exception
                    m_strtxtSSDW = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' chkTJYXJ_Checked属性
        '----------------------------------------------------------------
        Public Property chkTJYXJ_Checked() As Boolean
            Get
                chkTJYXJ_Checked = m_blnChecked_chkTZYXJ
            End Get
            Set(ByVal Value As Boolean)
                Try
                    m_blnChecked_chkTZYXJ = Value
                Catch ex As Exception
                    m_blnChecked_chkTZYXJ = False
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' chkTJNXJ_Checked属性
        '----------------------------------------------------------------
        Public Property chkTJNXJ_Checked() As Boolean
            Get
                chkTJNXJ_Checked = m_blnChecked_chkTZNXJ
            End Get
            Set(ByVal Value As Boolean)
                Try
                    m_blnChecked_chkTZNXJ = Value
                Catch ex As Exception
                    m_blnChecked_chkTZNXJ = False
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












        '----------------------------------------------------------------
        ' txtSearch_NXJ_RYDM属性
        '----------------------------------------------------------------
        Public Property txtSearch_NXJ_RYDM() As String
            Get
                txtSearch_NXJ_RYDM = m_strtxtSearch_NXJ_RYDM
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtSearch_NXJ_RYDM = Value
                Catch ex As Exception
                    m_strtxtSearch_NXJ_RYDM = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtSearch_NXJ_ZJDM属性
        '----------------------------------------------------------------
        Public Property txtSearch_NXJ_ZJDM() As String
            Get
                txtSearch_NXJ_ZJDM = m_strtxtSearch_NXJ_ZJDM
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtSearch_NXJ_ZJDM = Value
                Catch ex As Exception
                    m_strtxtSearch_NXJ_ZJDM = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtSearch_NXJ_RYMC属性
        '----------------------------------------------------------------
        Public Property txtSearch_NXJ_RYMC() As String
            Get
                txtSearch_NXJ_RYMC = m_strtxtSearch_NXJ_RYMC
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtSearch_NXJ_RYMC = Value
                Catch ex As Exception
                    m_strtxtSearch_NXJ_RYMC = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtSearch_NXJ_DWMC属性
        '----------------------------------------------------------------
        Public Property txtSearch_NXJ_DWMC() As String
            Get
                txtSearch_NXJ_DWMC = m_strtxtSearch_NXJ_DWMC
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtSearch_NXJ_DWMC = Value
                Catch ex As Exception
                    m_strtxtSearch_NXJ_DWMC = ""
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
        ' txtNXJPageSize属性
        '----------------------------------------------------------------
        Public Property txtNXJPageSize() As String
            Get
                txtNXJPageSize = m_strtxtNXJPageSize
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtNXJPageSize = Value
                Catch ex As Exception
                    m_strtxtNXJPageSize = ""
                End Try
            End Set
        End Property
        'zengxianglin 2008-10-14

        'zengxianglin 2008-10-14
        '----------------------------------------------------------------
        ' txtNXJPageIndex属性
        '----------------------------------------------------------------
        Public Property txtNXJPageIndex() As String
            Get
                txtNXJPageIndex = m_strtxtNXJPageIndex
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtNXJPageIndex = Value
                Catch ex As Exception
                    m_strtxtNXJPageIndex = ""
                End Try
            End Set
        End Property
        'zengxianglin 2008-10-14

        'zengxianglin 2008-10-14
        '----------------------------------------------------------------
        ' htxtNXJRows属性
        '----------------------------------------------------------------
        Public Property htxtNXJRows() As String
            Get
                htxtNXJRows = m_strhtxtNXJRows
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtNXJRows = Value
                Catch ex As Exception
                    m_strhtxtNXJRows = ""
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
        ' htxtZZDM_NXJ属性
        '----------------------------------------------------------------
        Public Property htxtZZDM_NXJ() As String
            Get
                htxtZZDM_NXJ = m_strhtxtZZDM_NXJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtZZDM_NXJ = Value
                Catch ex As Exception
                    m_strhtxtZZDM_NXJ = ""
                End Try
            End Set
        End Property
        'zengxianglin 2008-10-14

        'zengxianglin 2008-10-14
        '----------------------------------------------------------------
        ' txtZZDM_NXJ属性
        '----------------------------------------------------------------
        Public Property txtZZDM_NXJ() As String
            Get
                txtZZDM_NXJ = m_strtxtZZDM_NXJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtZZDM_NXJ = Value
                Catch ex As Exception
                    m_strtxtZZDM_NXJ = ""
                End Try
            End Set
        End Property
        'zengxianglin 2008-10-14

        'zengxianglin 2008-10-14
        '----------------------------------------------------------------
        ' ddlZJDM_NXJ_SelectedIndex
        '----------------------------------------------------------------
        Public Property ddlZJDM_NXJ_SelectedIndex() As Integer
            Get
                ddlZJDM_NXJ_SelectedIndex = m_intSelectedIndex_ddlZJDM_NXJ
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlZJDM_NXJ = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlZJDM_NXJ = -1
                End Try
            End Set
        End Property
        'zengxianglin 2008-10-14

        'zengxianglin 2008-10-14
        '----------------------------------------------------------------
        ' ddlSSFZ_NXJ_SelectedIndex
        '----------------------------------------------------------------
        Public Property ddlSSFZ_NXJ_SelectedIndex() As Integer
            Get
                ddlSSFZ_NXJ_SelectedIndex = m_intSelectedIndex_ddlSSFZ_NXJ
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlSSFZ_NXJ = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlSSFZ_NXJ = -1
                End Try
            End Set
        End Property
        'zengxianglin 2008-10-14









        'zengxianglin 2008-10-14
        '----------------------------------------------------------------
        ' ddlYDYY_NXJ_SelectedIndex
        '----------------------------------------------------------------
        Public Property ddlYDYY_NXJ_SelectedIndex() As Integer
            Get
                ddlYDYY_NXJ_SelectedIndex = m_intSelectedIndex_ddlYDYY_NXJ
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlYDYY_NXJ = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlYDYY_NXJ = -1
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

        '----------------------------------------------------------------
        ' rblRYZT_XJ_SelectedIndex属性
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

        '----------------------------------------------------------------
        ' rblSFZB_XJ_SelectedIndex属性
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

        '----------------------------------------------------------------
        ' rblRYZT_NXJ_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property rblRYZT_NXJ_SelectedIndex() As Integer
            Get
                rblRYZT_NXJ_SelectedIndex = m_intSelectedIndex_rblRYZT_NXJ
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_rblRYZT_NXJ = Value
                Catch ex As Exception
                    m_intSelectedIndex_rblRYZT_NXJ = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' rblSFZB_NXJ_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property rblSFZB_NXJ_SelectedIndex() As Integer
            Get
                rblSFZB_NXJ_SelectedIndex = m_intSelectedIndex_rblSFZB_NXJ
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_rblSFZB_NXJ = Value
                Catch ex As Exception
                    m_intSelectedIndex_rblSFZB_NXJ = -1
                End Try
            End Set
        End Property












        'zengxianglin 2008-11-18
        '----------------------------------------------------------------
        ' htxtZGDW_NXJ属性
        '----------------------------------------------------------------
        Public Property htxtZGDW_NXJ() As String
            Get
                htxtZGDW_NXJ = m_strhtxtZGDW_NXJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtZGDW_NXJ = Value
                Catch ex As Exception
                    m_strhtxtZGDW_NXJ = ""
                End Try
            End Set
        End Property
        'zengxianglin 2008-11-18

        'zengxianglin 2008-11-18
        '----------------------------------------------------------------
        ' txtZGDW_NXJ属性
        '----------------------------------------------------------------
        Public Property txtZGDW_NXJ() As String
            Get
                txtZGDW_NXJ = m_strtxtZGDW_NXJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtZGDW_NXJ = Value
                Catch ex As Exception
                    m_strtxtZGDW_NXJ = ""
                End Try
            End Set
        End Property
        'zengxianglin 2008-11-18

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
