Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.BusinessFacade
    ' 类名    ：IMEstateEsHetongFpbl
    '
    ' 功能描述： 
    '     estate_es_hetong_fpbl.aspx模块本身恢复现场需要的信息
    '----------------------------------------------------------------
    <Serializable()> Public Class IMEstateEsHetongFpbl
        Implements IDisposable

        Private m_strhtxtDivLeftBody As String                      'htxtDivLeftBody
        Private m_strhtxtDivTopBody As String                       'htxtDivTopBody
        Private m_strhtxtDivLeftMain As String                      'htxtDivLeftMain
        Private m_strhtxtDivTopMain As String                       'htxtDivTopMain
        Private m_strhtxtDivLeftSYBL As String                      'htxtDivLeftSYBL
        Private m_strhtxtDivTopSYBL As String                       'htxtDivTopSYBL
        Private m_strhtxtDivLeftGYBL As String                      'htxtDivLeftGYBL
        Private m_strhtxtDivTopGYBL As String                       'htxtDivTopGYBL

        Private m_strhtxtSY_RYDM As String                          'htxtSY_RYDM
        Private m_strtxtSY_RYDM As String                           'txtSY_RYDM
        Private m_strhtxtSY_DWDM As String                          'htxtSY_DWDM
        Private m_strtxtSY_DWDM As String                           'txtSY_DWDM
        Private m_strtxtSY_FPBL As String                           'txtSY_FPBL
        Private m_intSelectedIndex_ddlSY_ZJDM As Integer            'ddlSY_ZJDM_SelectedIndex
        'zengxianglin 2008-10-14
        Private m_intSelectedIndex_ddlSY_SSFZ As Integer            'ddlSY_SSFZ_SelectedIndex
        'zengxianglin 2008-10-14
        'zengxianglin 2010-01-06
        Private m_strtxtSY_TDBH As String                           'txtSY_TDBH
        'zengxianglin 2010-01-06


        Private m_strhtxtSessionIdSYBL As String                    'htxtSessionIdSYBL
        Private m_strhtxtSessionIdGYBL As String                    'htxtSessionIdGYBL

        Private m_strhtxtGY_RYDM As String                          'htxtGY_RYDM
        Private m_strhtxtGY_DWDM As String                          'htxtGY_DWDM
        Private m_strtxtGY_RYDM As String                           'txtGY_RYDM
        Private m_strtxtGY_DWDM As String                           'txtGY_DWDM
        Private m_strtxtGY_FPBL As String                           'txtGY_FPBL
        Private m_intSelectedIndex_ddlGY_ZJDM As Integer            'ddlGY_ZJDM_SelectedIndex
        Private m_intSelectedIndex_rblGY_ZGBZ As Integer            'rblGY_ZGBZ_SelectedIndex
        'zengxianglin 2008-10-14
        Private m_intSelectedIndex_ddlGY_SSFZ As Integer            'ddlGY_SSFZ_SelectedIndex
        'zengxianglin 2008-10-14
        'zengxianglin 2010-01-06
        Private m_strtxtGY_TDBH As String                           'txtGY_TDBH
        'zengxianglin 2010-01-06

        Private m_intPageSize_grdSYBL As Integer
        Private m_intSelectedIndex_grdSYBL As Integer
        Private m_intCurrentPageIndex_grdSYBL As Integer

        Private m_intPageSize_grdGYBL As Integer
        Private m_intSelectedIndex_grdGYBL As Integer
        Private m_intCurrentPageIndex_grdGYBL As Integer











        '----------------------------------------------------------------
        ' 构造函数
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()

            m_strhtxtDivLeftBody = ""
            m_strhtxtDivTopBody = ""
            m_strhtxtDivLeftMain = ""
            m_strhtxtDivTopMain = ""
            m_strhtxtDivLeftSYBL = ""
            m_strhtxtDivTopSYBL = ""
            m_strhtxtDivLeftGYBL = ""
            m_strhtxtDivTopGYBL = ""

            m_strhtxtSY_RYDM = ""
            m_strtxtSY_RYDM = ""
            m_strhtxtSY_DWDM = ""
            m_strtxtSY_DWDM = ""
            m_strtxtSY_FPBL = ""
            m_intSelectedIndex_ddlSY_ZJDM = -1
            'zengxianglin 2008-10-14
            m_intSelectedIndex_ddlSY_SSFZ = -1
            'zengxianglin 2008-10-14
            'zengxianglin 2010-01-06
            m_strtxtSY_TDBH = ""
            'zengxianglin 2010-01-06

            m_strhtxtSessionIdSYBL = ""
            m_strhtxtSessionIdGYBL = ""

            m_strhtxtGY_DWDM = ""
            m_strhtxtGY_RYDM = ""
            m_strtxtGY_RYDM = ""
            m_strtxtGY_DWDM = ""
            m_strtxtGY_FPBL = ""
            m_intSelectedIndex_ddlGY_ZJDM = -1
            m_intSelectedIndex_rblGY_ZGBZ = -1
            'zengxianglin 2008-10-14
            m_intSelectedIndex_ddlGY_SSFZ = -1
            'zengxianglin 2008-10-14
            'zengxianglin 2010-01-06
            m_strtxtGY_TDBH = ""
            'zengxianglin 2010-01-06

            m_intPageSize_grdSYBL = 0
            m_intCurrentPageIndex_grdSYBL = 0
            m_intSelectedIndex_grdSYBL = -1

            m_intPageSize_grdGYBL = 0
            m_intCurrentPageIndex_grdGYBL = 0
            m_intSelectedIndex_grdGYBL = -1

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
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IMEstateEsHetongFpbl)
            Try
                If Not (obj Is Nothing) Then
                    obj.Dispose()
                End If
            Catch ex As Exception
            End Try
            obj = Nothing
        End Sub












        '----------------------------------------------------------------
        ' htxtSY_RYDM属性
        '----------------------------------------------------------------
        Public Property htxtSY_RYDM() As String
            Get
                htxtSY_RYDM = m_strhtxtSY_RYDM
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSY_RYDM = Value
                Catch ex As Exception
                    m_strhtxtSY_RYDM = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtSY_DWDM属性
        '----------------------------------------------------------------
        Public Property txtSY_DWDM() As String
            Get
                txtSY_DWDM = m_strtxtSY_DWDM
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtSY_DWDM = Value
                Catch ex As Exception
                    m_strtxtSY_DWDM = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' ddlSY_ZJDM_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property ddlSY_ZJDM_SelectedIndex() As Integer
            Get
                ddlSY_ZJDM_SelectedIndex = m_intSelectedIndex_ddlSY_ZJDM
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlSY_ZJDM = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlSY_ZJDM = -1
                End Try
            End Set
        End Property

        'zengxianglin 2008-10-14
        '----------------------------------------------------------------
        ' ddlSY_SSFZ_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property ddlSY_SSFZ_SelectedIndex() As Integer
            Get
                ddlSY_SSFZ_SelectedIndex = m_intSelectedIndex_ddlSY_SSFZ
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlSY_SSFZ = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlSY_SSFZ = -1
                End Try
            End Set
        End Property
        'zengxianglin 2008-10-14

        '----------------------------------------------------------------
        ' htxtSY_DWDM属性
        '----------------------------------------------------------------
        Public Property htxtSY_DWDM() As String
            Get
                htxtSY_DWDM = m_strhtxtSY_DWDM
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSY_DWDM = Value
                Catch ex As Exception
                    m_strhtxtSY_DWDM = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtSY_RYDM属性
        '----------------------------------------------------------------
        Public Property txtSY_RYDM() As String
            Get
                txtSY_RYDM = m_strtxtSY_RYDM
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtSY_RYDM = Value
                Catch ex As Exception
                    m_strtxtSY_RYDM = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtSY_FPBL属性
        '----------------------------------------------------------------
        Public Property txtSY_FPBL() As String
            Get
                txtSY_FPBL = m_strtxtSY_FPBL
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtSY_FPBL = Value
                Catch ex As Exception
                    m_strtxtSY_FPBL = ""
                End Try
            End Set
        End Property











        '----------------------------------------------------------------
        ' htxtDivLeftSYBL属性
        '----------------------------------------------------------------
        Public Property htxtDivLeftSYBL() As String
            Get
                htxtDivLeftSYBL = m_strhtxtDivLeftSYBL
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivLeftSYBL = Value
                Catch ex As Exception
                    m_strhtxtDivLeftSYBL = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopSYBL属性
        '----------------------------------------------------------------
        Public Property htxtDivTopSYBL() As String
            Get
                htxtDivTopSYBL = m_strhtxtDivTopSYBL
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivTopSYBL = Value
                Catch ex As Exception
                    m_strhtxtDivTopSYBL = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivLeftGYBL属性
        '----------------------------------------------------------------
        Public Property htxtDivLeftGYBL() As String
            Get
                htxtDivLeftGYBL = m_strhtxtDivLeftGYBL
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivLeftGYBL = Value
                Catch ex As Exception
                    m_strhtxtDivLeftGYBL = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopGYBL属性
        '----------------------------------------------------------------
        Public Property htxtDivTopGYBL() As String
            Get
                htxtDivTopGYBL = m_strhtxtDivTopGYBL
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivTopGYBL = Value
                Catch ex As Exception
                    m_strhtxtDivTopGYBL = ""
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
        ' htxtSessionIdSYBL属性
        '----------------------------------------------------------------
        Public Property htxtSessionIdSYBL() As String
            Get
                htxtSessionIdSYBL = m_strhtxtSessionIdSYBL
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSessionIdSYBL = Value
                Catch ex As Exception
                    m_strhtxtSessionIdSYBL = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtSessionIdGYBL属性
        '----------------------------------------------------------------
        Public Property htxtSessionIdGYBL() As String
            Get
                htxtSessionIdGYBL = m_strhtxtSessionIdGYBL
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSessionIdGYBL = Value
                Catch ex As Exception
                    m_strhtxtSessionIdGYBL = ""
                End Try
            End Set
        End Property














        '----------------------------------------------------------------
        ' htxtGY_DWDM属性
        '----------------------------------------------------------------
        Public Property htxtGY_DWDM() As String
            Get
                htxtGY_DWDM = m_strhtxtGY_DWDM
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtGY_DWDM = Value
                Catch ex As Exception
                    m_strhtxtGY_DWDM = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtGY_RYDM属性
        '----------------------------------------------------------------
        Public Property htxtGY_RYDM() As String
            Get
                htxtGY_RYDM = m_strhtxtGY_RYDM
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtGY_RYDM = Value
                Catch ex As Exception
                    m_strhtxtGY_RYDM = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtGY_RYDM属性
        '----------------------------------------------------------------
        Public Property txtGY_RYDM() As String
            Get
                txtGY_RYDM = m_strtxtGY_RYDM
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtGY_RYDM = Value
                Catch ex As Exception
                    m_strtxtGY_RYDM = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtGY_DWDM属性
        '----------------------------------------------------------------
        Public Property txtGY_DWDM() As String
            Get
                txtGY_DWDM = m_strtxtGY_DWDM
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtGY_DWDM = Value
                Catch ex As Exception
                    m_strtxtGY_DWDM = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtGY_FPBL属性
        '----------------------------------------------------------------
        Public Property txtGY_FPBL() As String
            Get
                txtGY_FPBL = m_strtxtGY_FPBL
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtGY_FPBL = Value
                Catch ex As Exception
                    m_strtxtGY_FPBL = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' ddlGY_ZJDM_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property ddlGY_ZJDM_SelectedIndex() As Integer
            Get
                ddlGY_ZJDM_SelectedIndex = m_intSelectedIndex_ddlGY_ZJDM
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlGY_ZJDM = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlGY_ZJDM = -1
                End Try
            End Set
        End Property

        'zengxianglin 2008-10-14
        '----------------------------------------------------------------
        ' ddlGY_SSFZ_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property ddlGY_SSFZ_SelectedIndex() As Integer
            Get
                ddlGY_SSFZ_SelectedIndex = m_intSelectedIndex_ddlGY_SSFZ
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlGY_SSFZ = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlGY_SSFZ = -1
                End Try
            End Set
        End Property
        'zengxianglin 2008-10-14

        '----------------------------------------------------------------
        ' rblGY_ZGBZ_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property rblGY_ZGBZ_SelectedIndex() As Integer
            Get
                rblGY_ZGBZ_SelectedIndex = m_intSelectedIndex_rblGY_ZGBZ
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_rblGY_ZGBZ = Value
                Catch ex As Exception
                    m_intSelectedIndex_rblGY_ZGBZ = -1
                End Try
            End Set
        End Property













        '----------------------------------------------------------------
        ' grdSYBLPageSize属性
        '----------------------------------------------------------------
        Public Property grdSYBLPageSize() As Integer
            Get
                grdSYBLPageSize = m_intPageSize_grdSYBL
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdSYBL = Value
                Catch ex As Exception
                    m_intPageSize_grdSYBL = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdSYBLCurrentPageIndex属性
        '----------------------------------------------------------------
        Public Property grdSYBLCurrentPageIndex() As Integer
            Get
                grdSYBLCurrentPageIndex = m_intCurrentPageIndex_grdSYBL
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdSYBL = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdSYBL = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdSYBLSelectedIndex属性
        '----------------------------------------------------------------
        Public Property grdSYBLSelectedIndex() As Integer
            Get
                grdSYBLSelectedIndex = m_intSelectedIndex_grdSYBL
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdSYBL = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdSYBL = -1
                End Try
            End Set
        End Property












        '----------------------------------------------------------------
        ' grdGYBLPageSize属性
        '----------------------------------------------------------------
        Public Property grdGYBLPageSize() As Integer
            Get
                grdGYBLPageSize = m_intPageSize_grdGYBL
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdGYBL = Value
                Catch ex As Exception
                    m_intPageSize_grdGYBL = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdGYBLCurrentPageIndex属性
        '----------------------------------------------------------------
        Public Property grdGYBLCurrentPageIndex() As Integer
            Get
                grdGYBLCurrentPageIndex = m_intCurrentPageIndex_grdGYBL
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdGYBL = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdGYBL = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdGYBLSelectedIndex属性
        '----------------------------------------------------------------
        Public Property grdGYBLSelectedIndex() As Integer
            Get
                grdGYBLSelectedIndex = m_intSelectedIndex_grdGYBL
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdGYBL = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdGYBL = -1
                End Try
            End Set
        End Property









        'zengxianglin 2010-01-06
        '----------------------------------------------------------------
        ' txtSY_TDBH属性
        '----------------------------------------------------------------
        Public Property txtSY_TDBH() As String
            Get
                txtSY_TDBH = m_strtxtSY_TDBH
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtSY_TDBH = Value
                Catch ex As Exception
                    m_strtxtSY_TDBH = ""
                End Try
            End Set
        End Property
        'zengxianglin 2010-01-06

        'zengxianglin 2010-01-06
        '----------------------------------------------------------------
        ' txtGY_TDBH属性
        '----------------------------------------------------------------
        Public Property txtGY_TDBH() As String
            Get
                txtGY_TDBH = m_strtxtGY_TDBH
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtGY_TDBH = Value
                Catch ex As Exception
                    m_strtxtGY_TDBH = ""
                End Try
            End Set
        End Property
        'zengxianglin 2010-01-06

    End Class

End Namespace
