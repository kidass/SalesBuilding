Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.BusinessFacade
    ' 类名    ：IMEstateCwSssfJh
    '
    ' 功能描述： 
    '     estate_cw_sssf_jh.aspx模块本身恢复现场需要的信息
    '----------------------------------------------------------------
    <Serializable()> Public Class IMEstateCwSssfJh
        Implements IDisposable

        Private m_strhtxtDivLeftJHSZ As String                      'htxtDivLeftJHSZ
        Private m_strhtxtDivTopJHSZ As String                       'htxtDivTopJHSZ
        Private m_strhtxtDivLeftMain As String                      'htxtDivLeftMain
        Private m_strhtxtDivTopMain As String                       'htxtDivTopMain
        Private m_strhtxtDivLeftBody As String                      'htxtDivLeftBody
        Private m_strhtxtDivTopBody As String                       'htxtDivTopBody

        Private m_strhtxtJHSZQuery As String                        'htxtJHSZQuery
        Private m_strhtxtJHSZRows As String                         'htxtJHSZRows
        Private m_strhtxtJHSZSort As String                         'htxtJHSZSort
        Private m_strhtxtJHSZSortColumnIndex As String              'htxtJHSZSortColumnIndex
        Private m_strhtxtJHSZSortType As String                     'htxtJHSZSortType
        Private m_strhtxtJHSZSessionIdQuery As String               'htxtJHSZSessionIdQuery
        Private m_strtxtJHSZPageIndex As String                     'txtJHSZPageIndex
        Private m_strtxtJHSZPageSize As String                      'txtJHSZPageSize

        Private m_intSelectedIndex_ddlJHSZSearch_SFDM As Integer    'ddlJHSZSearch_SFDM
        Private m_intSelectedIndex_ddlJHSZSearch_SFDX As Integer    'ddlJHSZSearch_SFDX
        Private m_intSelectedIndex_ddlJHSZSearch_SFBZ As Integer    'ddlJHSZSearch_SFBZ
        Private m_strtxtJHSZSearch_YSRQMin As String                'txtJHSZSearch_YSRQMin
        Private m_strtxtJHSZSearch_YSRQMax As String                'txtJHSZSearch_YSRQMax

        Private m_intPageSize_grdJHSZ As Integer
        Private m_intSelectedIndex_grdJHSZ As Integer
        Private m_intCurrentPageIndex_grdJHSZ As Integer

        Private m_strhtxtJHJBRY As String                           'htxtJHJBRY
        Private m_strhtxtJHJBDW As String                           'htxtJHJBDW
        Private m_strtxtJHJBRY As String                            'txtJHJBRY
        Private m_strtxtJHJBDW As String                            'txtJHJBDW
        Private m_strtxtJHKHMC As String                            'txtJHKHMC
        Private m_strtxtJHZYSM As String                            'txtJHZYSM
        Private m_strtxtJHPJHM As String                            'txtJHPJHM
        Private m_strtxtJHFSJE As String                            'txtJHFSJE












        '----------------------------------------------------------------
        ' 构造函数
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()

            m_strhtxtDivLeftJHSZ = ""
            m_strhtxtDivTopJHSZ = ""
            m_strhtxtDivLeftMain = ""
            m_strhtxtDivTopMain = ""
            m_strhtxtDivLeftBody = ""
            m_strhtxtDivTopBody = ""

            m_strhtxtJHSZQuery = ""
            m_strhtxtJHSZRows = ""
            m_strhtxtJHSZSort = ""
            m_strhtxtJHSZSortColumnIndex = ""
            m_strhtxtJHSZSortType = ""
            m_strhtxtJHSZSessionIdQuery = ""
            m_strtxtJHSZPageIndex = ""
            m_strtxtJHSZPageSize = ""

            m_intSelectedIndex_ddlJHSZSearch_SFDM = -1
            m_intSelectedIndex_ddlJHSZSearch_SFDX = -1
            m_intSelectedIndex_ddlJHSZSearch_SFBZ = -1
            m_strtxtJHSZSearch_YSRQMin = ""
            m_strtxtJHSZSearch_YSRQMax = ""

            m_intPageSize_grdJHSZ = 0
            m_intCurrentPageIndex_grdJHSZ = 0
            m_intSelectedIndex_grdJHSZ = -1

            m_strtxtJHFSJE = ""
            m_strtxtJHPJHM = ""
            m_strtxtJHZYSM = ""
            m_strtxtJHJBRY = ""
            m_strtxtJHJBDW = ""
            m_strtxtJHKHMC = ""
            m_strhtxtJHJBRY = ""
            m_strhtxtJHJBDW = ""
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
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IMEstateCwSssfJh)
            Try
                If Not (obj Is Nothing) Then
                    obj.Dispose()
                End If
            Catch ex As Exception
            End Try
            obj = Nothing
        End Sub












        '----------------------------------------------------------------
        ' htxtJHSZQuery属性
        '----------------------------------------------------------------
        Public Property htxtJHSZQuery() As String
            Get
                htxtJHSZQuery = m_strhtxtJHSZQuery
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtJHSZQuery = Value
                Catch ex As Exception
                    m_strhtxtJHSZQuery = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtJHSZRows属性
        '----------------------------------------------------------------
        Public Property htxtJHSZRows() As String
            Get
                htxtJHSZRows = m_strhtxtJHSZRows
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtJHSZRows = Value
                Catch ex As Exception
                    m_strhtxtJHSZRows = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtJHSZSort属性
        '----------------------------------------------------------------
        Public Property htxtJHSZSort() As String
            Get
                htxtJHSZSort = m_strhtxtJHSZSort
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtJHSZSort = Value
                Catch ex As Exception
                    m_strhtxtJHSZSort = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtJHSZSortColumnIndex属性
        '----------------------------------------------------------------
        Public Property htxtJHSZSortColumnIndex() As String
            Get
                htxtJHSZSortColumnIndex = m_strhtxtJHSZSortColumnIndex
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtJHSZSortColumnIndex = Value
                Catch ex As Exception
                    m_strhtxtJHSZSortColumnIndex = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtJHSZSortType属性
        '----------------------------------------------------------------
        Public Property htxtJHSZSortType() As String
            Get
                htxtJHSZSortType = m_strhtxtJHSZSortType
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtJHSZSortType = Value
                Catch ex As Exception
                    m_strhtxtJHSZSortType = ""
                End Try
            End Set
        End Property











        '----------------------------------------------------------------
        ' htxtDivLeftJHSZ属性
        '----------------------------------------------------------------
        Public Property htxtDivLeftJHSZ() As String
            Get
                htxtDivLeftJHSZ = m_strhtxtDivLeftJHSZ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivLeftJHSZ = Value
                Catch ex As Exception
                    m_strhtxtDivLeftJHSZ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopJHSZ属性
        '----------------------------------------------------------------
        Public Property htxtDivTopJHSZ() As String
            Get
                htxtDivTopJHSZ = m_strhtxtDivTopJHSZ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivTopJHSZ = Value
                Catch ex As Exception
                    m_strhtxtDivTopJHSZ = ""
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
        ' htxtJHSZSessionIdQuery属性
        '----------------------------------------------------------------
        Public Property htxtJHSZSessionIdQuery() As String
            Get
                htxtJHSZSessionIdQuery = m_strhtxtJHSZSessionIdQuery
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtJHSZSessionIdQuery = Value
                Catch ex As Exception
                    m_strhtxtJHSZSessionIdQuery = ""
                End Try
            End Set
        End Property













        '----------------------------------------------------------------
        ' txtJHSZPageIndex属性
        '----------------------------------------------------------------
        Public Property txtJHSZPageIndex() As String
            Get
                txtJHSZPageIndex = m_strtxtJHSZPageIndex
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJHSZPageIndex = Value
                Catch ex As Exception
                    m_strtxtJHSZPageIndex = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtJHSZPageSize属性
        '----------------------------------------------------------------
        Public Property txtJHSZPageSize() As String
            Get
                txtJHSZPageSize = m_strtxtJHSZPageSize
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJHSZPageSize = Value
                Catch ex As Exception
                    m_strtxtJHSZPageSize = ""
                End Try
            End Set
        End Property











        '----------------------------------------------------------------
        ' ddlJHSZSearch_SFDM_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property ddlJHSZSearch_SFDM_SelectedIndex() As Integer
            Get
                ddlJHSZSearch_SFDM_SelectedIndex = m_intSelectedIndex_ddlJHSZSearch_SFDM
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlJHSZSearch_SFDM = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlJHSZSearch_SFDM = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' ddlJHSZSearch_SFDX_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property ddlJHSZSearch_SFDX_SelectedIndex() As Integer
            Get
                ddlJHSZSearch_SFDX_SelectedIndex = m_intSelectedIndex_ddlJHSZSearch_SFDX
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlJHSZSearch_SFDX = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlJHSZSearch_SFDX = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' ddlJHSZSearch_SFBZ_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property ddlJHSZSearch_SFBZ_SelectedIndex() As Integer
            Get
                ddlJHSZSearch_SFBZ_SelectedIndex = m_intSelectedIndex_ddlJHSZSearch_SFBZ
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlJHSZSearch_SFBZ = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlJHSZSearch_SFBZ = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtJHSZSearch_YSRQMin属性
        '----------------------------------------------------------------
        Public Property txtJHSZSearch_YSRQMin() As String
            Get
                txtJHSZSearch_YSRQMin = m_strtxtJHSZSearch_YSRQMin
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJHSZSearch_YSRQMin = Value
                Catch ex As Exception
                    m_strtxtJHSZSearch_YSRQMin = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtJHSZSearch_YSRQMax属性
        '----------------------------------------------------------------
        Public Property txtJHSZSearch_YSRQMax() As String
            Get
                txtJHSZSearch_YSRQMax = m_strtxtJHSZSearch_YSRQMax
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJHSZSearch_YSRQMax = Value
                Catch ex As Exception
                    m_strtxtJHSZSearch_YSRQMax = ""
                End Try
            End Set
        End Property












        '----------------------------------------------------------------
        ' grdJHSZPageSize属性
        '----------------------------------------------------------------
        Public Property grdJHSZPageSize() As Integer
            Get
                grdJHSZPageSize = m_intPageSize_grdJHSZ
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdJHSZ = Value
                Catch ex As Exception
                    m_intPageSize_grdJHSZ = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdJHSZCurrentPageIndex属性
        '----------------------------------------------------------------
        Public Property grdJHSZCurrentPageIndex() As Integer
            Get
                grdJHSZCurrentPageIndex = m_intCurrentPageIndex_grdJHSZ
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdJHSZ = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdJHSZ = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdJHSZSelectedIndex属性
        '----------------------------------------------------------------
        Public Property grdJHSZSelectedIndex() As Integer
            Get
                grdJHSZSelectedIndex = m_intSelectedIndex_grdJHSZ
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdJHSZ = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdJHSZ = -1
                End Try
            End Set
        End Property












        '----------------------------------------------------------------
        ' txtJHFSJE属性
        '----------------------------------------------------------------
        Public Property txtJHFSJE() As String
            Get
                txtJHFSJE = m_strtxtJHFSJE
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJHFSJE = Value
                Catch ex As Exception
                    m_strtxtJHFSJE = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtJHPJHM属性
        '----------------------------------------------------------------
        Public Property txtJHPJHM() As String
            Get
                txtJHPJHM = m_strtxtJHPJHM
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJHPJHM = Value
                Catch ex As Exception
                    m_strtxtJHPJHM = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtJHZYSM属性
        '----------------------------------------------------------------
        Public Property txtJHZYSM() As String
            Get
                txtJHZYSM = m_strtxtJHZYSM
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJHZYSM = Value
                Catch ex As Exception
                    m_strtxtJHZYSM = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtJHKHMC属性
        '----------------------------------------------------------------
        Public Property txtJHKHMC() As String
            Get
                txtJHKHMC = m_strtxtJHKHMC
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJHKHMC = Value
                Catch ex As Exception
                    m_strtxtJHKHMC = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtJHJBRY属性
        '----------------------------------------------------------------
        Public Property txtJHJBRY() As String
            Get
                txtJHJBRY = m_strtxtJHJBRY
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJHJBRY = Value
                Catch ex As Exception
                    m_strtxtJHJBRY = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtJHJBDW属性
        '----------------------------------------------------------------
        Public Property txtJHJBDW() As String
            Get
                txtJHJBDW = m_strtxtJHJBDW
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJHJBDW = Value
                Catch ex As Exception
                    m_strtxtJHJBDW = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtJHJBRY属性
        '----------------------------------------------------------------
        Public Property htxtJHJBRY() As String
            Get
                htxtJHJBRY = m_strhtxtJHJBRY
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtJHJBRY = Value
                Catch ex As Exception
                    m_strhtxtJHJBRY = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtJHJBDW属性
        '----------------------------------------------------------------
        Public Property htxtJHJBDW() As String
            Get
                htxtJHJBDW = m_strhtxtJHJBDW
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtJHJBDW = Value
                Catch ex As Exception
                    m_strhtxtJHJBDW = ""
                End Try
            End Set
        End Property

    End Class

End Namespace
