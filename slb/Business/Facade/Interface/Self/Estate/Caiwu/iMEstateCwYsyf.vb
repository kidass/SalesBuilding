Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.BusinessFacade
    ' 类名    ：IMEstateCwYsyf
    '
    ' 功能描述： 
    '     estate_cw_ysyf.aspx模块本身恢复现场需要的信息
    '----------------------------------------------------------------
    <Serializable()> Public Class IMEstateCwYsyf
        Implements IDisposable

        Private m_strhtxtDivLeftYSYFJH As String                    'htxtDivLeftYSYFJH
        Private m_strhtxtDivTopYSYFJH As String                     'htxtDivTopYSYFJH
        Private m_strhtxtDivLeftBody As String                      'htxtDivLeftBody
        Private m_strhtxtDivTopBody As String                       'htxtDivTopBody

        Private m_strhtxtYSYFJHQuery As String                      'htxtYSYFJHQuery
        Private m_strhtxtYSYFJHRows As String                       'htxtYSYFJHRows
        Private m_strhtxtYSYFJHSort As String                       'htxtYSYFJHSort
        Private m_strhtxtYSYFJHSortColumnIndex As String            'htxtYSYFJHSortColumnIndex
        Private m_strhtxtYSYFJHSortType As String                   'htxtYSYFJHSortType

        Private m_strhtxtSessionIdQuery As String                   'htxtSessionIdQuery

        Private m_strtxtYSYFJHPageIndex As String                  'txtYSYFJHPageIndex
        Private m_strtxtYSYFJHPageSize As String                   'txtYSYFJHPageSize

        Private m_intSelectedIndex_ddlYSYFJHSearch_SFDM As Integer 'ddlYSYFJHSearch_SFDM
        Private m_intSelectedIndex_ddlYSYFJHSearch_SFDX As Integer 'ddlYSYFJHSearch_SFDX
        Private m_intSelectedIndex_ddlYSYFJHSearch_SFBZ As Integer 'ddlYSYFJHSearch_SFBZ
        Private m_strtxtYSYFJHSearch_YSRQMin As String             'txtYSYFJHSearch_YSRQMin
        Private m_strtxtYSYFJHSearch_YSRQMax As String             'txtYSYFJHSearch_YSRQMax

        '----------------------------------------------------------------
        'asp:datagrid - grdYSYFJH
        '----------------------------------------------------------------
        Private m_intPageSize_grdYSYFJH As Integer
        Private m_intSelectedIndex_grdYSYFJH As Integer
        Private m_intCurrentPageIndex_grdYSYFJH As Integer

        Private m_strhtxtCurrentPage As String                      'htxtCurrentPage
        Private m_strhtxtCurrentRow As String                       'htxtCurrentRow
        Private m_strhtxtEditMode As String                         'htxtEditMode
        Private m_strhtxtEditType As String                         'htxtEditType

        Private m_intSelectedIndex_ddlFKFS As Integer               'ddlFKFS
        Private m_blnChecked_chkQCXY As Boolean                     'chkQCXY

        Private m_intSelectedIndex_ddlSFDM As Integer               'ddlSFDM
        Private m_intSelectedIndex_rblSFDX As Integer               'rblSFDX
        Private m_intSelectedIndex_rblSFBZ As Integer               'rblSFBZ
        Private m_strtxtYSRQ As String                              'txtYSRQ
        Private m_strtxtYSJE As String                              'txtYSJE
        Private m_strtxtQTMS As String                              'txtQTMS
        Private m_strhtxtSFZT As String                             'htxtSFZT
        Private m_strhtxtWYBS As String                             'htxtWYBS
        Private m_strhtxtQRSH As String                             'htxtQRSH












        '----------------------------------------------------------------
        ' 构造函数
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()

            m_strhtxtDivLeftYSYFJH = ""
            m_strhtxtDivTopYSYFJH = ""
            m_strhtxtDivLeftBody = ""
            m_strhtxtDivTopBody = ""

            m_strhtxtYSYFJHQuery = ""
            m_strhtxtYSYFJHRows = ""
            m_strhtxtYSYFJHSort = ""
            m_strhtxtYSYFJHSortColumnIndex = ""
            m_strhtxtYSYFJHSortType = ""

            m_strhtxtSessionIdQuery = ""

            m_strtxtYSYFJHPageIndex = ""
            m_strtxtYSYFJHPageSize = ""

            m_intSelectedIndex_ddlYSYFJHSearch_SFDM = -1
            m_intSelectedIndex_ddlYSYFJHSearch_SFDX = -1
            m_intSelectedIndex_ddlYSYFJHSearch_SFBZ = -1
            m_strtxtYSYFJHSearch_YSRQMin = ""
            m_strtxtYSYFJHSearch_YSRQMax = ""

            m_intPageSize_grdYSYFJH = 0
            m_intCurrentPageIndex_grdYSYFJH = 0
            m_intSelectedIndex_grdYSYFJH = -1

            m_strhtxtCurrentPage = ""
            m_strhtxtCurrentRow = ""
            m_strhtxtEditMode = ""
            m_strhtxtEditType = ""

            m_intSelectedIndex_ddlFKFS = -1
            m_blnChecked_chkQCXY = False

            m_intSelectedIndex_ddlSFDM = -1
            m_intSelectedIndex_rblSFDX = -1
            m_intSelectedIndex_rblSFBZ = -1
            m_strtxtYSRQ = ""
            m_strtxtYSJE = ""
            m_strtxtQTMS = ""
            m_strhtxtSFZT = ""
            m_strhtxtWYBS = ""
            m_strhtxtQRSH = ""
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
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IMEstateCwYsyf)
            Try
                If Not (obj Is Nothing) Then
                    obj.Dispose()
                End If
            Catch ex As Exception
            End Try
            obj = Nothing
        End Sub












        '----------------------------------------------------------------
        ' htxtYSYFJHQuery属性
        '----------------------------------------------------------------
        Public Property htxtYSYFJHQuery() As String
            Get
                htxtYSYFJHQuery = m_strhtxtYSYFJHQuery
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtYSYFJHQuery = Value
                Catch ex As Exception
                    m_strhtxtYSYFJHQuery = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtYSYFJHRows属性
        '----------------------------------------------------------------
        Public Property htxtYSYFJHRows() As String
            Get
                htxtYSYFJHRows = m_strhtxtYSYFJHRows
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtYSYFJHRows = Value
                Catch ex As Exception
                    m_strhtxtYSYFJHRows = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtYSYFJHSort属性
        '----------------------------------------------------------------
        Public Property htxtYSYFJHSort() As String
            Get
                htxtYSYFJHSort = m_strhtxtYSYFJHSort
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtYSYFJHSort = Value
                Catch ex As Exception
                    m_strhtxtYSYFJHSort = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtYSYFJHSortColumnIndex属性
        '----------------------------------------------------------------
        Public Property htxtYSYFJHSortColumnIndex() As String
            Get
                htxtYSYFJHSortColumnIndex = m_strhtxtYSYFJHSortColumnIndex
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtYSYFJHSortColumnIndex = Value
                Catch ex As Exception
                    m_strhtxtYSYFJHSortColumnIndex = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtYSYFJHSortType属性
        '----------------------------------------------------------------
        Public Property htxtYSYFJHSortType() As String
            Get
                htxtYSYFJHSortType = m_strhtxtYSYFJHSortType
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtYSYFJHSortType = Value
                Catch ex As Exception
                    m_strhtxtYSYFJHSortType = ""
                End Try
            End Set
        End Property












        '----------------------------------------------------------------
        ' htxtDivLeftYSYFJH属性
        '----------------------------------------------------------------
        Public Property htxtDivLeftYSYFJH() As String
            Get
                htxtDivLeftYSYFJH = m_strhtxtDivLeftYSYFJH
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivLeftYSYFJH = Value
                Catch ex As Exception
                    m_strhtxtDivLeftYSYFJH = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopYSYFJH属性
        '----------------------------------------------------------------
        Public Property htxtDivTopYSYFJH() As String
            Get
                htxtDivTopYSYFJH = m_strhtxtDivTopYSYFJH
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivTopYSYFJH = Value
                Catch ex As Exception
                    m_strhtxtDivTopYSYFJH = ""
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
        ' txtYSYFJHPageIndex属性
        '----------------------------------------------------------------
        Public Property txtYSYFJHPageIndex() As String
            Get
                txtYSYFJHPageIndex = m_strtxtYSYFJHPageIndex
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtYSYFJHPageIndex = Value
                Catch ex As Exception
                    m_strtxtYSYFJHPageIndex = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtYSYFJHPageSize属性
        '----------------------------------------------------------------
        Public Property txtYSYFJHPageSize() As String
            Get
                txtYSYFJHPageSize = m_strtxtYSYFJHPageSize
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtYSYFJHPageSize = Value
                Catch ex As Exception
                    m_strtxtYSYFJHPageSize = ""
                End Try
            End Set
        End Property











        '----------------------------------------------------------------
        ' ddlYSYFJHSearch_SFDM_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property ddlYSYFJHSearch_SFDM_SelectedIndex() As Integer
            Get
                ddlYSYFJHSearch_SFDM_SelectedIndex = m_intSelectedIndex_ddlYSYFJHSearch_SFDM
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlYSYFJHSearch_SFDM = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlYSYFJHSearch_SFDM = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' ddlYSYFJHSearch_SFDX_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property ddlYSYFJHSearch_SFDX_SelectedIndex() As Integer
            Get
                ddlYSYFJHSearch_SFDX_SelectedIndex = m_intSelectedIndex_ddlYSYFJHSearch_SFDX
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlYSYFJHSearch_SFDX = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlYSYFJHSearch_SFDX = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' ddlYSYFJHSearch_SFBZ_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property ddlYSYFJHSearch_SFBZ_SelectedIndex() As Integer
            Get
                ddlYSYFJHSearch_SFBZ_SelectedIndex = m_intSelectedIndex_ddlYSYFJHSearch_SFBZ
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlYSYFJHSearch_SFBZ = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlYSYFJHSearch_SFBZ = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtYSYFJHSearch_YSRQMin属性
        '----------------------------------------------------------------
        Public Property txtYSYFJHSearch_YSRQMin() As String
            Get
                txtYSYFJHSearch_YSRQMin = m_strtxtYSYFJHSearch_YSRQMin
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtYSYFJHSearch_YSRQMin = Value
                Catch ex As Exception
                    m_strtxtYSYFJHSearch_YSRQMin = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtYSYFJHSearch_YSRQMax属性
        '----------------------------------------------------------------
        Public Property txtYSYFJHSearch_YSRQMax() As String
            Get
                txtYSYFJHSearch_YSRQMax = m_strtxtYSYFJHSearch_YSRQMax
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtYSYFJHSearch_YSRQMax = Value
                Catch ex As Exception
                    m_strtxtYSYFJHSearch_YSRQMax = ""
                End Try
            End Set
        End Property














        '----------------------------------------------------------------
        ' grdYSYFJHPageSize属性
        '----------------------------------------------------------------
        Public Property grdYSYFJHPageSize() As Integer
            Get
                grdYSYFJHPageSize = m_intPageSize_grdYSYFJH
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdYSYFJH = Value
                Catch ex As Exception
                    m_intPageSize_grdYSYFJH = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdYSYFJHCurrentPageIndex属性
        '----------------------------------------------------------------
        Public Property grdYSYFJHCurrentPageIndex() As Integer
            Get
                grdYSYFJHCurrentPageIndex = m_intCurrentPageIndex_grdYSYFJH
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdYSYFJH = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdYSYFJH = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdYSYFJHSelectedIndex属性
        '----------------------------------------------------------------
        Public Property grdYSYFJHSelectedIndex() As Integer
            Get
                grdYSYFJHSelectedIndex = m_intSelectedIndex_grdYSYFJH
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdYSYFJH = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdYSYFJH = -1
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
        ' ddlFKFS_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property ddlFKFS_SelectedIndex() As Integer
            Get
                ddlFKFS_SelectedIndex = m_intSelectedIndex_ddlFKFS
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlFKFS = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlFKFS = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' chkQCXY_Checked属性
        '----------------------------------------------------------------
        Public Property chkQCXY_Checked() As Boolean
            Get
                chkQCXY_Checked = m_blnChecked_chkQCXY
            End Get
            Set(ByVal Value As Boolean)
                Try
                    m_blnChecked_chkQCXY = Value
                Catch ex As Exception
                    m_blnChecked_chkQCXY = False
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
        ' txtYSRQ属性
        '----------------------------------------------------------------
        Public Property txtYSRQ() As String
            Get
                txtYSRQ = m_strtxtYSRQ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtYSRQ = Value
                Catch ex As Exception
                    m_strtxtYSRQ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtYSJE属性
        '----------------------------------------------------------------
        Public Property txtYSJE() As String
            Get
                txtYSJE = m_strtxtYSJE
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtYSJE = Value
                Catch ex As Exception
                    m_strtxtYSJE = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtQTMS属性
        '----------------------------------------------------------------
        Public Property txtQTMS() As String
            Get
                txtQTMS = m_strtxtQTMS
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtQTMS = Value
                Catch ex As Exception
                    m_strtxtQTMS = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtSFZT属性
        '----------------------------------------------------------------
        Public Property htxtSFZT() As String
            Get
                htxtSFZT = m_strhtxtSFZT
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSFZT = Value
                Catch ex As Exception
                    m_strhtxtSFZT = ""
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
        ' htxtQRSH属性
        '----------------------------------------------------------------
        Public Property htxtQRSH() As String
            Get
                htxtQRSH = m_strhtxtQRSH
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtQRSH = Value
                Catch ex As Exception
                    m_strhtxtQRSH = ""
                End Try
            End Set
        End Property

    End Class

End Namespace
