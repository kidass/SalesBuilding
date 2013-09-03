Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.BusinessFacade
    ' 类名    ：IMEstateCwPiaojuShiyong
    '
    ' 功能描述： 
    '     estate_cw_piaoju_shiyong.aspx模块本身恢复现场需要的信息
    '----------------------------------------------------------------
    <Serializable()> Public Class IMEstateCwPiaojuShiyong
        Implements IDisposable

        Private m_strhtxtDivLeftPIAOJU As String                    'htxtDivLeftPIAOJU
        Private m_strhtxtDivTopPIAOJU As String                     'htxtDivTopPIAOJU
        Private m_strhtxtDivLeftBody As String                      'htxtDivLeftBody
        Private m_strhtxtDivTopBody As String                       'htxtDivTopBody

        Private m_strhtxtPIAOJUQuery As String                      'htxtPIAOJUQuery
        Private m_strhtxtPIAOJURows As String                       'htxtPIAOJURows
        Private m_strhtxtPIAOJUSort As String                       'htxtPIAOJUSort
        Private m_strhtxtPIAOJUSortColumnIndex As String            'htxtPIAOJUSortColumnIndex
        Private m_strhtxtPIAOJUSortType As String                   'htxtPIAOJUSortType

        Private m_strhtxtSessionIdQuery As String                   'htxtSessionIdQuery

        Private m_strtxtPIAOJUPageIndex As String                  'txtPIAOJUPageIndex
        Private m_strtxtPIAOJUPageSize As String                   'txtPIAOJUPageSize

        Private m_strtxtPIAOJUSearch_JBRY As String                'txtPIAOJUSearch_JBRY
        Private m_strtxtPIAOJUSearch_YWBH As String                'txtPIAOJUSearch_YWBH
        Private m_strtxtPIAOJUSearch_PJHM As String                'txtPIAOJUSearch_PJHM
        Private m_strtxtPIAOJUSearch_KPRQMin As String             'txtPIAOJUSearch_KPRQMin
        Private m_strtxtPIAOJUSearch_KPRQMax As String             'txtPIAOJUSearch_KPRQMax
        Private m_intSelectedIndex_ddlPIAOJUSearch_ZTBZ As Integer 'ddlPIAOJUSearch_ZTBZ_SelectedIndex

        Private m_strtxtYWBH As String                             'txtYWBH
        Private m_strhtxtYWBH As String                            'htxtYWBH
        Private m_strtxtJBRY As String                             'txtJBRY
        Private m_strhtxtJBRY As String                            'htxtJBRY
        Private m_strtxtKPJE As String                             'txtKPJE
        Private m_strtxtZYSM As String                             'txtZYSM
        'zengxianglin 2008-11-18
        Private m_strtxtKPRQ As String                             'txtKPRQ
        Private m_strtxtBJRY As String                             'txtBJRY
        Private m_strhtxtBJRY As String                            'htxtBJRY
        Private m_intSelectedIndex_ddlSFDM As Integer              'ddlSFDM_SelectedIndex
        Private m_intSelectedIndex_rblSFDX As Integer              'rblSFDX_SelectedIndex
        Private m_intSelectedIndex_rblSFBZ As Integer              'rblSFBZ_SelectedIndex
        'zengxianglin 2008-11-18

        '----------------------------------------------------------------
        'asp:datagrid - grdPIAOJU
        '----------------------------------------------------------------
        Private m_intPageSize_grdPIAOJU As Integer
        Private m_intSelectedIndex_grdPIAOJU As Integer
        Private m_intCurrentPageIndex_grdPIAOJU As Integer











        '----------------------------------------------------------------
        ' 构造函数
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()

            m_strhtxtDivLeftPIAOJU = ""
            m_strhtxtDivTopPIAOJU = ""
            m_strhtxtDivLeftBody = ""
            m_strhtxtDivTopBody = ""

            m_strhtxtPIAOJUQuery = ""
            m_strhtxtPIAOJURows = ""
            m_strhtxtPIAOJUSort = ""
            m_strhtxtPIAOJUSortColumnIndex = ""
            m_strhtxtPIAOJUSortType = ""

            m_strhtxtSessionIdQuery = ""

            m_strtxtPIAOJUPageIndex = ""
            m_strtxtPIAOJUPageSize = ""

            m_strtxtPIAOJUSearch_JBRY = ""
            m_strtxtPIAOJUSearch_YWBH = ""
            m_strtxtPIAOJUSearch_PJHM = ""
            m_strtxtPIAOJUSearch_KPRQMin = ""
            m_strtxtPIAOJUSearch_KPRQMax = ""
            m_intSelectedIndex_ddlPIAOJUSearch_ZTBZ = -1

            m_strtxtYWBH = ""
            m_strhtxtYWBH = ""
            m_strtxtJBRY = ""
            m_strhtxtJBRY = ""
            m_strtxtKPJE = ""
            m_strtxtZYSM = ""
            'zengxianglin 2008-11-18
            m_strtxtKPRQ = ""
            m_strtxtBJRY = ""
            m_strhtxtBJRY = ""
            m_intSelectedIndex_ddlSFDM = -1
            m_intSelectedIndex_rblSFDX = -1
            m_intSelectedIndex_rblSFBZ = -1
            'zengxianglin 2008-11-18

            m_intPageSize_grdPIAOJU = 0
            m_intCurrentPageIndex_grdPIAOJU = 0
            m_intSelectedIndex_grdPIAOJU = -1

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
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IMEstateCwPiaojuShiyong)
            Try
                If Not (obj Is Nothing) Then
                    obj.Dispose()
                End If
            Catch ex As Exception
            End Try
            obj = Nothing
        End Sub












        '----------------------------------------------------------------
        ' htxtPIAOJUQuery属性
        '----------------------------------------------------------------
        Public Property htxtPIAOJUQuery() As String
            Get
                htxtPIAOJUQuery = m_strhtxtPIAOJUQuery
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtPIAOJUQuery = Value
                Catch ex As Exception
                    m_strhtxtPIAOJUQuery = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtPIAOJURows属性
        '----------------------------------------------------------------
        Public Property htxtPIAOJURows() As String
            Get
                htxtPIAOJURows = m_strhtxtPIAOJURows
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtPIAOJURows = Value
                Catch ex As Exception
                    m_strhtxtPIAOJURows = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtPIAOJUSort属性
        '----------------------------------------------------------------
        Public Property htxtPIAOJUSort() As String
            Get
                htxtPIAOJUSort = m_strhtxtPIAOJUSort
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtPIAOJUSort = Value
                Catch ex As Exception
                    m_strhtxtPIAOJUSort = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtPIAOJUSortColumnIndex属性
        '----------------------------------------------------------------
        Public Property htxtPIAOJUSortColumnIndex() As String
            Get
                htxtPIAOJUSortColumnIndex = m_strhtxtPIAOJUSortColumnIndex
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtPIAOJUSortColumnIndex = Value
                Catch ex As Exception
                    m_strhtxtPIAOJUSortColumnIndex = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtPIAOJUSortType属性
        '----------------------------------------------------------------
        Public Property htxtPIAOJUSortType() As String
            Get
                htxtPIAOJUSortType = m_strhtxtPIAOJUSortType
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtPIAOJUSortType = Value
                Catch ex As Exception
                    m_strhtxtPIAOJUSortType = ""
                End Try
            End Set
        End Property












        '----------------------------------------------------------------
        ' htxtDivLeftPIAOJU属性
        '----------------------------------------------------------------
        Public Property htxtDivLeftPIAOJU() As String
            Get
                htxtDivLeftPIAOJU = m_strhtxtDivLeftPIAOJU
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivLeftPIAOJU = Value
                Catch ex As Exception
                    m_strhtxtDivLeftPIAOJU = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopPIAOJU属性
        '----------------------------------------------------------------
        Public Property htxtDivTopPIAOJU() As String
            Get
                htxtDivTopPIAOJU = m_strhtxtDivTopPIAOJU
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivTopPIAOJU = Value
                Catch ex As Exception
                    m_strhtxtDivTopPIAOJU = ""
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
        ' txtPIAOJUPageIndex属性
        '----------------------------------------------------------------
        Public Property txtPIAOJUPageIndex() As String
            Get
                txtPIAOJUPageIndex = m_strtxtPIAOJUPageIndex
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtPIAOJUPageIndex = Value
                Catch ex As Exception
                    m_strtxtPIAOJUPageIndex = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtPIAOJUPageSize属性
        '----------------------------------------------------------------
        Public Property txtPIAOJUPageSize() As String
            Get
                txtPIAOJUPageSize = m_strtxtPIAOJUPageSize
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtPIAOJUPageSize = Value
                Catch ex As Exception
                    m_strtxtPIAOJUPageSize = ""
                End Try
            End Set
        End Property











        '----------------------------------------------------------------
        ' txtPIAOJUSearch_JBRY属性
        '----------------------------------------------------------------
        Public Property txtPIAOJUSearch_JBRY() As String
            Get
                txtPIAOJUSearch_JBRY = m_strtxtPIAOJUSearch_JBRY
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtPIAOJUSearch_JBRY = Value
                Catch ex As Exception
                    m_strtxtPIAOJUSearch_JBRY = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtPIAOJUSearch_YWBH属性
        '----------------------------------------------------------------
        Public Property txtPIAOJUSearch_YWBH() As String
            Get
                txtPIAOJUSearch_YWBH = m_strtxtPIAOJUSearch_YWBH
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtPIAOJUSearch_YWBH = Value
                Catch ex As Exception
                    m_strtxtPIAOJUSearch_YWBH = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtPIAOJUSearch_PJHM属性
        '----------------------------------------------------------------
        Public Property txtPIAOJUSearch_PJHM() As String
            Get
                txtPIAOJUSearch_PJHM = m_strtxtPIAOJUSearch_PJHM
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtPIAOJUSearch_PJHM = Value
                Catch ex As Exception
                    m_strtxtPIAOJUSearch_PJHM = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtPIAOJUSearch_KPRQMin属性
        '----------------------------------------------------------------
        Public Property txtPIAOJUSearch_KPRQMin() As String
            Get
                txtPIAOJUSearch_KPRQMin = m_strtxtPIAOJUSearch_KPRQMin
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtPIAOJUSearch_KPRQMin = Value
                Catch ex As Exception
                    m_strtxtPIAOJUSearch_KPRQMin = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtPIAOJUSearch_KPRQMax属性
        '----------------------------------------------------------------
        Public Property txtPIAOJUSearch_KPRQMax() As String
            Get
                txtPIAOJUSearch_KPRQMax = m_strtxtPIAOJUSearch_KPRQMax
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtPIAOJUSearch_KPRQMax = Value
                Catch ex As Exception
                    m_strtxtPIAOJUSearch_KPRQMax = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' ddlPIAOJUSearch_ZTBZ_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property ddlPIAOJUSearch_ZTBZ_SelectedIndex() As Integer
            Get
                ddlPIAOJUSearch_ZTBZ_SelectedIndex = m_intSelectedIndex_ddlPIAOJUSearch_ZTBZ
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlPIAOJUSearch_ZTBZ = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlPIAOJUSearch_ZTBZ = -1
                End Try
            End Set
        End Property













        '----------------------------------------------------------------
        ' txtYWBH属性
        '----------------------------------------------------------------
        Public Property txtYWBH() As String
            Get
                txtYWBH = m_strtxtYWBH
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtYWBH = Value
                Catch ex As Exception
                    m_strtxtYWBH = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtYWBH属性
        '----------------------------------------------------------------
        Public Property htxtYWBH() As String
            Get
                htxtYWBH = m_strhtxtYWBH
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtYWBH = Value
                Catch ex As Exception
                    m_strhtxtYWBH = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtJBRY属性
        '----------------------------------------------------------------
        Public Property txtJBRY() As String
            Get
                txtJBRY = m_strtxtJBRY
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJBRY = Value
                Catch ex As Exception
                    m_strtxtJBRY = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtJBRY属性
        '----------------------------------------------------------------
        Public Property htxtJBRY() As String
            Get
                htxtJBRY = m_strhtxtJBRY
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtJBRY = Value
                Catch ex As Exception
                    m_strhtxtJBRY = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtKPJE属性
        '----------------------------------------------------------------
        Public Property txtKPJE() As String
            Get
                txtKPJE = m_strtxtKPJE
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtKPJE = Value
                Catch ex As Exception
                    m_strtxtKPJE = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtZYSM属性
        '----------------------------------------------------------------
        Public Property txtZYSM() As String
            Get
                txtZYSM = m_strtxtZYSM
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtZYSM = Value
                Catch ex As Exception
                    m_strtxtZYSM = ""
                End Try
            End Set
        End Property














        '----------------------------------------------------------------
        ' grdPIAOJUPageSize属性
        '----------------------------------------------------------------
        Public Property grdPIAOJUPageSize() As Integer
            Get
                grdPIAOJUPageSize = m_intPageSize_grdPIAOJU
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdPIAOJU = Value
                Catch ex As Exception
                    m_intPageSize_grdPIAOJU = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdPIAOJUCurrentPageIndex属性
        '----------------------------------------------------------------
        Public Property grdPIAOJUCurrentPageIndex() As Integer
            Get
                grdPIAOJUCurrentPageIndex = m_intCurrentPageIndex_grdPIAOJU
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdPIAOJU = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdPIAOJU = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdPIAOJUSelectedIndex属性
        '----------------------------------------------------------------
        Public Property grdPIAOJUSelectedIndex() As Integer
            Get
                grdPIAOJUSelectedIndex = m_intSelectedIndex_grdPIAOJU
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdPIAOJU = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdPIAOJU = -1
                End Try
            End Set
        End Property










        'zengxianglin 2008-11-18
        '----------------------------------------------------------------
        ' txtKPRQ属性
        '----------------------------------------------------------------
        Public Property txtKPRQ() As String
            Get
                txtKPRQ = m_strtxtKPRQ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtKPRQ = Value
                Catch ex As Exception
                    m_strtxtKPRQ = ""
                End Try
            End Set
        End Property
        'zengxianglin 2008-11-18

        'zengxianglin 2008-11-18
        '----------------------------------------------------------------
        ' txtBJRY属性
        '----------------------------------------------------------------
        Public Property txtBJRY() As String
            Get
                txtBJRY = m_strtxtBJRY
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtBJRY = Value
                Catch ex As Exception
                    m_strtxtBJRY = ""
                End Try
            End Set
        End Property
        'zengxianglin 2008-11-18

        'zengxianglin 2008-11-18
        '----------------------------------------------------------------
        ' htxtBJRY属性
        '----------------------------------------------------------------
        Public Property htxtBJRY() As String
            Get
                htxtBJRY = m_strhtxtBJRY
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtBJRY = Value
                Catch ex As Exception
                    m_strhtxtBJRY = ""
                End Try
            End Set
        End Property
        'zengxianglin 2008-11-18

        'zengxianglin 2008-11-18
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
        'zengxianglin 2008-11-18

        'zengxianglin 2008-11-18
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
        'zengxianglin 2008-11-18

        'zengxianglin 2008-11-18
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
        'zengxianglin 2008-11-18

    End Class

End Namespace
