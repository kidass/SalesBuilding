Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.BusinessFacade
    ' 类名    ：IMEstateRsRenyuanJiagou_Del_X2
    '
    ' 功能描述： 
    '     estate_rs_renyuanjiagou_del.aspx模块本身恢复现场需要的信息
    '----------------------------------------------------------------
    <Serializable()> Public Class IMEstateRsRenyuanJiagou_Del_X2
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

        Private m_strhtxtSessionIdQuery_RY As String        'htxtSessionIdQuery_RY
        Private m_strhtxtQuery_RY As String                 'htxtQuery_RY
        Private m_intCurrentPageIndex_grdRY As Integer      'grdRY_CurrentPageIndex
        Private m_intSelectedIndex_grdRY As Integer         'grdRY_SelectedIndex
        Private m_intPageSize_grdRY As Integer              'grdRY_PageSize

        Private m_intSelectedIndex_ddlYDYY As Integer       'ddlYDYY_SelectedIndex
        Private m_intSelectedIndex_rblBDLX As Integer       'rblBDLX_SelectedIndex
        Private m_strtxtSXSJ As String                      'txtSXSJ
        Private m_strtxtKSSJ As String                      'txtKSSJ

        Private m_strtxtSearch_RY_RYDM As String            'txtSearch_RY_RYDM
        Private m_strtxtSearch_RY_ZJDM As String            'txtSearch_RY_ZJDM
        Private m_strtxtSearch_RY_RYMC As String            'txtSearch_RY_RYMC
        Private m_strtxtSearch_RY_DWMC As String            'txtSearch_RY_DWMC

        Private m_strtxtRYPageIndex As String               'txtRYPageIndex
        Private m_strtxtRYPageSize As String                'txtRYPageSize
        Private m_strhtxtRYRows As String                   'htxtRYRows
        Private m_strtxtXJPageIndex As String               'txtXJPageIndex
        Private m_strtxtXJPageSize As String                'txtXJPageSize
        Private m_strhtxtXJRows As String                   'htxtXJRows











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

            m_strhtxtSessionIdQuery_RY = ""
            m_strhtxtQuery_RY = ""
            m_intCurrentPageIndex_grdRY = 0
            m_intSelectedIndex_grdRY = -1
            m_intPageSize_grdRY = 30

            m_intSelectedIndex_ddlYDYY = -1
            m_intSelectedIndex_rblBDLX = -1
            m_strtxtSXSJ = ""
            m_strtxtKSSJ = ""

            m_strtxtSearch_RY_RYDM = ""
            m_strtxtSearch_RY_ZJDM = ""
            m_strtxtSearch_RY_RYMC = ""
            m_strtxtSearch_RY_DWMC = ""

            m_strtxtRYPageIndex = ""
            m_strtxtRYPageSize = "30"
            m_strhtxtRYRows = ""
            m_strtxtXJPageIndex = ""
            m_strtxtXJPageSize = "30"
            m_strhtxtXJRows = ""

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
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IMEstateRsRenyuanJiagou_Del_X2)
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

    End Class

End Namespace
