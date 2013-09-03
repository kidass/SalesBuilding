Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.BusinessFacade
    ' 类名    ：IMEstateCwSssfJz
    '
    ' 功能描述： 
    '     estate_cw_sssf_jz.aspx模块本身恢复现场需要的信息
    '----------------------------------------------------------------
    <Serializable()> Public Class IMEstateCwSssfJz
        Implements IDisposable

        Private m_strhtxtDivLeftSJSZ As String                      'htxtDivLeftSJSZ
        Private m_strhtxtDivTopSJSZ As String                       'htxtDivTopSJSZ
        Private m_strhtxtDivLeftMain As String                      'htxtDivLeftMain
        Private m_strhtxtDivTopMain As String                       'htxtDivTopMain
        Private m_strhtxtDivLeftBody As String                      'htxtDivLeftBody
        Private m_strhtxtDivTopBody As String                       'htxtDivTopBody

        Private m_strhtxtSJSZQuery As String                        'htxtSJSZQuery
        Private m_strhtxtSJSZRows As String                         'htxtSJSZRows
        Private m_strhtxtSJSZSort As String                         'htxtSJSZSort
        Private m_strhtxtSJSZSortColumnIndex As String              'htxtSJSZSortColumnIndex
        Private m_strhtxtSJSZSortType As String                     'htxtSJSZSortType
        Private m_strhtxtSJSZSessionIdQuery As String               'htxtSJSZSessionIdQuery
        Private m_strtxtSJSZPageIndex As String                     'txtSJSZPageIndex
        Private m_strtxtSJSZPageSize As String                      'txtSJSZPageSize

        Private m_intSelectedIndex_ddlSJSZSearch_SHBZ As Integer    'ddlSJSZSearch_SHBZ
        Private m_intSelectedIndex_ddlSJSZSearch_SFSH As Integer    'ddlSJSZSearch_SFSH
        Private m_intSelectedIndex_ddlSJSZSearch_SFDM As Integer    'ddlSJSZSearch_SFDM
        Private m_intSelectedIndex_ddlSJSZSearch_SFDX As Integer    'ddlSJSZSearch_SFDX
        Private m_intSelectedIndex_ddlSJSZSearch_SFBZ As Integer    'ddlSJSZSearch_SFBZ
        Private m_strtxtSJSZSearch_FSRQMin As String                'txtSJSZSearch_FSRQMin
        Private m_strtxtSJSZSearch_FSRQMax As String                'txtSJSZSearch_FSRQMax
        Private m_strtxtSJSZSearch_PJHM As String                   'txtSJSZSearch_PJHM

        Private m_intPageSize_grdSJSZ As Integer
        Private m_intSelectedIndex_grdSJSZ As Integer
        Private m_intCurrentPageIndex_grdSJSZ As Integer

        Private m_intSelectedIndex_ddlSFDM As Integer               'ddlSFDM
        Private m_intSelectedIndex_rblSFDX As Integer               'rblSFDX
        Private m_intSelectedIndex_rblSFBZ As Integer               'rblSFBZ
        Private m_strtxtFSJE As String                              'txtFSJE

        Private m_strtxtJYBH As String                              'txtJYBH












        '----------------------------------------------------------------
        ' 构造函数
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()

            m_strhtxtDivLeftSJSZ = ""
            m_strhtxtDivTopSJSZ = ""
            m_strhtxtDivLeftMain = ""
            m_strhtxtDivTopMain = ""
            m_strhtxtDivLeftBody = ""
            m_strhtxtDivTopBody = ""

            m_strhtxtSJSZQuery = ""
            m_strhtxtSJSZRows = ""
            m_strhtxtSJSZSort = ""
            m_strhtxtSJSZSortColumnIndex = ""
            m_strhtxtSJSZSortType = ""
            m_strhtxtSJSZSessionIdQuery = ""
            m_strtxtSJSZPageIndex = ""
            m_strtxtSJSZPageSize = ""

            m_intSelectedIndex_ddlSJSZSearch_SHBZ = -1
            m_intSelectedIndex_ddlSJSZSearch_SFSH = -1
            m_intSelectedIndex_ddlSJSZSearch_SFDM = -1
            m_intSelectedIndex_ddlSJSZSearch_SFDX = -1
            m_intSelectedIndex_ddlSJSZSearch_SFBZ = -1
            m_strtxtSJSZSearch_FSRQMin = ""
            m_strtxtSJSZSearch_FSRQMax = ""
            m_strtxtSJSZSearch_PJHM = ""

            m_intPageSize_grdSJSZ = 0
            m_intCurrentPageIndex_grdSJSZ = 0
            m_intSelectedIndex_grdSJSZ = -1

            m_intSelectedIndex_ddlSFDM = -1
            m_intSelectedIndex_rblSFDX = -1
            m_intSelectedIndex_rblSFBZ = -1
            m_strtxtFSJE = ""

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
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IMEstateCwSssfJz)
            Try
                If Not (obj Is Nothing) Then
                    obj.Dispose()
                End If
            Catch ex As Exception
            End Try
            obj = Nothing
        End Sub












        '----------------------------------------------------------------
        ' htxtSJSZQuery属性
        '----------------------------------------------------------------
        Public Property htxtSJSZQuery() As String
            Get
                htxtSJSZQuery = m_strhtxtSJSZQuery
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSJSZQuery = Value
                Catch ex As Exception
                    m_strhtxtSJSZQuery = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtSJSZRows属性
        '----------------------------------------------------------------
        Public Property htxtSJSZRows() As String
            Get
                htxtSJSZRows = m_strhtxtSJSZRows
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSJSZRows = Value
                Catch ex As Exception
                    m_strhtxtSJSZRows = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtSJSZSort属性
        '----------------------------------------------------------------
        Public Property htxtSJSZSort() As String
            Get
                htxtSJSZSort = m_strhtxtSJSZSort
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSJSZSort = Value
                Catch ex As Exception
                    m_strhtxtSJSZSort = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtSJSZSortColumnIndex属性
        '----------------------------------------------------------------
        Public Property htxtSJSZSortColumnIndex() As String
            Get
                htxtSJSZSortColumnIndex = m_strhtxtSJSZSortColumnIndex
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSJSZSortColumnIndex = Value
                Catch ex As Exception
                    m_strhtxtSJSZSortColumnIndex = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtSJSZSortType属性
        '----------------------------------------------------------------
        Public Property htxtSJSZSortType() As String
            Get
                htxtSJSZSortType = m_strhtxtSJSZSortType
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSJSZSortType = Value
                Catch ex As Exception
                    m_strhtxtSJSZSortType = ""
                End Try
            End Set
        End Property












        '----------------------------------------------------------------
        ' htxtDivLeftSJSZ属性
        '----------------------------------------------------------------
        Public Property htxtDivLeftSJSZ() As String
            Get
                htxtDivLeftSJSZ = m_strhtxtDivLeftSJSZ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivLeftSJSZ = Value
                Catch ex As Exception
                    m_strhtxtDivLeftSJSZ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopSJSZ属性
        '----------------------------------------------------------------
        Public Property htxtDivTopSJSZ() As String
            Get
                htxtDivTopSJSZ = m_strhtxtDivTopSJSZ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivTopSJSZ = Value
                Catch ex As Exception
                    m_strhtxtDivTopSJSZ = ""
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
        ' htxtSJSZSessionIdQuery属性
        '----------------------------------------------------------------
        Public Property htxtSJSZSessionIdQuery() As String
            Get
                htxtSJSZSessionIdQuery = m_strhtxtSJSZSessionIdQuery
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSJSZSessionIdQuery = Value
                Catch ex As Exception
                    m_strhtxtSJSZSessionIdQuery = ""
                End Try
            End Set
        End Property













        '----------------------------------------------------------------
        ' ddlSJSZSearch_SHBZ_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property ddlSJSZSearch_SHBZ_SelectedIndex() As Integer
            Get
                ddlSJSZSearch_SHBZ_SelectedIndex = m_intSelectedIndex_ddlSJSZSearch_SHBZ
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlSJSZSearch_SHBZ = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlSJSZSearch_SHBZ = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' ddlSJSZSearch_SFSH_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property ddlSJSZSearch_SFSH_SelectedIndex() As Integer
            Get
                ddlSJSZSearch_SFSH_SelectedIndex = m_intSelectedIndex_ddlSJSZSearch_SFSH
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlSJSZSearch_SFSH = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlSJSZSearch_SFSH = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' ddlSJSZSearch_SFDM_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property ddlSJSZSearch_SFDM_SelectedIndex() As Integer
            Get
                ddlSJSZSearch_SFDM_SelectedIndex = m_intSelectedIndex_ddlSJSZSearch_SFDM
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlSJSZSearch_SFDM = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlSJSZSearch_SFDM = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' ddlSJSZSearch_SFDX_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property ddlSJSZSearch_SFDX_SelectedIndex() As Integer
            Get
                ddlSJSZSearch_SFDX_SelectedIndex = m_intSelectedIndex_ddlSJSZSearch_SFDX
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlSJSZSearch_SFDX = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlSJSZSearch_SFDX = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' ddlSJSZSearch_SFBZ_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property ddlSJSZSearch_SFBZ_SelectedIndex() As Integer
            Get
                ddlSJSZSearch_SFBZ_SelectedIndex = m_intSelectedIndex_ddlSJSZSearch_SFBZ
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlSJSZSearch_SFBZ = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlSJSZSearch_SFBZ = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtSJSZSearch_FSRQMin属性
        '----------------------------------------------------------------
        Public Property txtSJSZSearch_FSRQMin() As String
            Get
                txtSJSZSearch_FSRQMin = m_strtxtSJSZSearch_FSRQMin
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtSJSZSearch_FSRQMin = Value
                Catch ex As Exception
                    m_strtxtSJSZSearch_FSRQMin = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtSJSZSearch_FSRQMax属性
        '----------------------------------------------------------------
        Public Property txtSJSZSearch_FSRQMax() As String
            Get
                txtSJSZSearch_FSRQMax = m_strtxtSJSZSearch_FSRQMax
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtSJSZSearch_FSRQMax = Value
                Catch ex As Exception
                    m_strtxtSJSZSearch_FSRQMax = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtSJSZSearch_PJHM属性
        '----------------------------------------------------------------
        Public Property txtSJSZSearch_PJHM() As String
            Get
                txtSJSZSearch_PJHM = m_strtxtSJSZSearch_PJHM
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtSJSZSearch_PJHM = Value
                Catch ex As Exception
                    m_strtxtSJSZSearch_PJHM = ""
                End Try
            End Set
        End Property











        '----------------------------------------------------------------
        ' txtSJSZPageIndex属性
        '----------------------------------------------------------------
        Public Property txtSJSZPageIndex() As String
            Get
                txtSJSZPageIndex = m_strtxtSJSZPageIndex
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtSJSZPageIndex = Value
                Catch ex As Exception
                    m_strtxtSJSZPageIndex = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtSJSZPageSize属性
        '----------------------------------------------------------------
        Public Property txtSJSZPageSize() As String
            Get
                txtSJSZPageSize = m_strtxtSJSZPageSize
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtSJSZPageSize = Value
                Catch ex As Exception
                    m_strtxtSJSZPageSize = ""
                End Try
            End Set
        End Property














        '----------------------------------------------------------------
        ' grdSJSZPageSize属性
        '----------------------------------------------------------------
        Public Property grdSJSZPageSize() As Integer
            Get
                grdSJSZPageSize = m_intPageSize_grdSJSZ
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdSJSZ = Value
                Catch ex As Exception
                    m_intPageSize_grdSJSZ = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdSJSZCurrentPageIndex属性
        '----------------------------------------------------------------
        Public Property grdSJSZCurrentPageIndex() As Integer
            Get
                grdSJSZCurrentPageIndex = m_intCurrentPageIndex_grdSJSZ
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdSJSZ = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdSJSZ = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdSJSZSelectedIndex属性
        '----------------------------------------------------------------
        Public Property grdSJSZSelectedIndex() As Integer
            Get
                grdSJSZSelectedIndex = m_intSelectedIndex_grdSJSZ
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdSJSZ = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdSJSZ = -1
                End Try
            End Set
        End Property










        '----------------------------------------------------------------
        ' ddlSFDM_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property ddlSFDM_SelectedIndex() As Integer
            Get
                ddlSFDM_SelectedIndex = m_intSelectedIndex_ddlSFDM
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlSFDM = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlSFDM = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' rblSFDX_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property rblSFDX_SelectedIndex() As Integer
            Get
                rblSFDX_SelectedIndex = m_intSelectedIndex_rblSFDX
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_rblSFDX = Value
                Catch ex As Exception
                    m_intSelectedIndex_rblSFDX = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' rblSFBZ_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property rblSFBZ_SelectedIndex() As Integer
            Get
                rblSFBZ_SelectedIndex = m_intSelectedIndex_rblSFBZ
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_rblSFBZ = Value
                Catch ex As Exception
                    m_intSelectedIndex_rblSFBZ = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtFSJE属性
        '----------------------------------------------------------------
        Public Property txtFSJE() As String
            Get
                txtFSJE = m_strtxtFSJE
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtFSJE = Value
                Catch ex As Exception
                    m_strtxtFSJE = ""
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
