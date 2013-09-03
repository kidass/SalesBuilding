Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.BusinessFacade
    ' 类名    ：IMEstateRsGrllMain
    '
    ' 功能描述： 
    '     estate_rs_grll_main.aspx模块本身恢复现场需要的信息
    '----------------------------------------------------------------
    <Serializable()> Public Class IMEstateRsGrllMain
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

        Private m_strtxtRYLISTPageIndex As String                  'txtRYLISTPageIndex
        Private m_strtxtRYLISTPageSize As String                   'txtRYLISTPageSize

        Private m_strtxtRYLISTSearch_JGHJ As String                'txtRYLISTSearch_JGHJ
        Private m_strtxtRYLISTSearch_MZ As String                  'txtRYLISTSearch_MZ
        Private m_strtxtRYLISTSearch_NNMin As String               'txtRYLISTSearch_NNMin
        Private m_strtxtRYLISTSearch_NNMax As String               'txtRYLISTSearch_NNMax
        'zengxianglin 2009-05-15
        Private m_strtxtRYLISTSearch_DJSJMin As String             'txtRYLISTSearch_DJSJMin
        Private m_strtxtRYLISTSearch_DJSJMax As String             'txtRYLISTSearch_DJSJMax
        Private m_strtxtRYLISTSearch_JLBH As String                'txtRYLISTSearch_JLBH
        Private m_strtxtRYLISTSearch_RYXM As String                'txtRYLISTSearch_RYXM
        'zengxianglin 2009-05-15
        Private m_intSelectedIndex_ddlRYLISTSearch_XB As Integer   'ddlRYLISTSearch_XB_SelectedIndex
        Private m_intSelectedIndex_ddlRYLISTSearch_XL As Integer   'ddlRYLISTSearch_XL_SelectedIndex
        Private m_intSelectedIndex_ddlRYLISTSearch_ZC As Integer   'ddlRYLISTSearch_ZC_SelectedIndex
        Private m_intSelectedIndex_ddlRYLISTSearch_ZYZG As Integer 'ddlRYLISTSearch_ZYZG_SelectedIndex
        Private m_intSelectedIndex_ddlRYLISTSearch_ZZMM As Integer 'ddlRYLISTSearch_ZZMM_SelectedIndex
        Private m_intSelectedIndex_ddlRYLISTSearch_SFLY As Integer 'ddlRYLISTSearch_SFLY_SelectedIndex

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

            m_strtxtRYLISTSearch_JGHJ = ""
            m_strtxtRYLISTSearch_MZ = ""
            m_strtxtRYLISTSearch_NNMin = ""
            m_strtxtRYLISTSearch_NNMax = ""
            'zengxianglin 2009-05-15
            m_strtxtRYLISTSearch_DJSJMin = ""
            m_strtxtRYLISTSearch_DJSJMax = ""
            m_strtxtRYLISTSearch_JLBH = ""
            m_strtxtRYLISTSearch_RYXM = ""
            'zengxianglin 2009-05-15

            m_intSelectedIndex_ddlRYLISTSearch_XB = -1
            m_intSelectedIndex_ddlRYLISTSearch_XL = -1
            m_intSelectedIndex_ddlRYLISTSearch_ZC = -1
            m_intSelectedIndex_ddlRYLISTSearch_ZYZG = -1
            m_intSelectedIndex_ddlRYLISTSearch_ZZMM = -1
            m_intSelectedIndex_ddlRYLISTSearch_SFLY = -1

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
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IMEstateRsGrllMain)
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
        ' txtRYLISTSearch_JGHJ属性
        '----------------------------------------------------------------
        Public Property txtRYLISTSearch_JGHJ() As String
            Get
                txtRYLISTSearch_JGHJ = m_strtxtRYLISTSearch_JGHJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtRYLISTSearch_JGHJ = Value
                Catch ex As Exception
                    m_strtxtRYLISTSearch_JGHJ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtRYLISTSearch_MZ属性
        '----------------------------------------------------------------
        Public Property txtRYLISTSearch_MZ() As String
            Get
                txtRYLISTSearch_MZ = m_strtxtRYLISTSearch_MZ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtRYLISTSearch_MZ = Value
                Catch ex As Exception
                    m_strtxtRYLISTSearch_MZ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtRYLISTSearch_NNMin属性
        '----------------------------------------------------------------
        Public Property txtRYLISTSearch_NNMin() As String
            Get
                txtRYLISTSearch_NNMin = m_strtxtRYLISTSearch_NNMin
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtRYLISTSearch_NNMin = Value
                Catch ex As Exception
                    m_strtxtRYLISTSearch_NNMin = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtRYLISTSearch_NNMax属性
        '----------------------------------------------------------------
        Public Property txtRYLISTSearch_NNMax() As String
            Get
                txtRYLISTSearch_NNMax = m_strtxtRYLISTSearch_NNMax
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtRYLISTSearch_NNMax = Value
                Catch ex As Exception
                    m_strtxtRYLISTSearch_NNMax = ""
                End Try
            End Set
        End Property

        'zengxianglin 2009-05-15
        '----------------------------------------------------------------
        ' txtRYLISTSearch_DJSJMin属性
        '----------------------------------------------------------------
        Public Property txtRYLISTSearch_DJSJMin() As String
            Get
                txtRYLISTSearch_DJSJMin = m_strtxtRYLISTSearch_DJSJMin
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtRYLISTSearch_DJSJMin = Value
                Catch ex As Exception
                    m_strtxtRYLISTSearch_DJSJMin = ""
                End Try
            End Set
        End Property
        '----------------------------------------------------------------
        ' txtRYLISTSearch_DJSJMax属性
        '----------------------------------------------------------------
        Public Property txtRYLISTSearch_DJSJMax() As String
            Get
                txtRYLISTSearch_DJSJMax = m_strtxtRYLISTSearch_DJSJMax
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtRYLISTSearch_DJSJMax = Value
                Catch ex As Exception
                    m_strtxtRYLISTSearch_DJSJMax = ""
                End Try
            End Set
        End Property
        '----------------------------------------------------------------
        ' txtRYLISTSearch_JLBH属性
        '----------------------------------------------------------------
        Public Property txtRYLISTSearch_JLBH() As String
            Get
                txtRYLISTSearch_JLBH = m_strtxtRYLISTSearch_JLBH
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtRYLISTSearch_JLBH = Value
                Catch ex As Exception
                    m_strtxtRYLISTSearch_JLBH = ""
                End Try
            End Set
        End Property
        '----------------------------------------------------------------
        ' txtRYLISTSearch_RYXM属性
        '----------------------------------------------------------------
        Public Property txtRYLISTSearch_RYXM() As String
            Get
                txtRYLISTSearch_RYXM = m_strtxtRYLISTSearch_RYXM
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtRYLISTSearch_RYXM = Value
                Catch ex As Exception
                    m_strtxtRYLISTSearch_RYXM = ""
                End Try
            End Set
        End Property
        'zengxianglin 2009-05-15










        '----------------------------------------------------------------
        ' ddlRYLISTSearch_XL_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property ddlRYLISTSearch_XL_SelectedIndex() As Integer
            Get
                ddlRYLISTSearch_XL_SelectedIndex = m_intSelectedIndex_ddlRYLISTSearch_XL
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlRYLISTSearch_XL = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlRYLISTSearch_XL = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' ddlRYLISTSearch_XB_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property ddlRYLISTSearch_XB_SelectedIndex() As Integer
            Get
                ddlRYLISTSearch_XB_SelectedIndex = m_intSelectedIndex_ddlRYLISTSearch_XB
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlRYLISTSearch_XB = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlRYLISTSearch_XB = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' ddlRYLISTSearch_ZC_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property ddlRYLISTSearch_ZC_SelectedIndex() As Integer
            Get
                ddlRYLISTSearch_ZC_SelectedIndex = m_intSelectedIndex_ddlRYLISTSearch_ZC
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlRYLISTSearch_ZC = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlRYLISTSearch_ZC = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' ddlRYLISTSearch_ZYZG_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property ddlRYLISTSearch_ZYZG_SelectedIndex() As Integer
            Get
                ddlRYLISTSearch_ZYZG_SelectedIndex = m_intSelectedIndex_ddlRYLISTSearch_ZYZG
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlRYLISTSearch_ZYZG = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlRYLISTSearch_ZYZG = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' ddlRYLISTSearch_ZZMM_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property ddlRYLISTSearch_ZZMM_SelectedIndex() As Integer
            Get
                ddlRYLISTSearch_ZZMM_SelectedIndex = m_intSelectedIndex_ddlRYLISTSearch_ZZMM
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlRYLISTSearch_ZZMM = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlRYLISTSearch_ZZMM = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' ddlRYLISTSearch_SFLY_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property ddlRYLISTSearch_SFLY_SelectedIndex() As Integer
            Get
                ddlRYLISTSearch_SFLY_SelectedIndex = m_intSelectedIndex_ddlRYLISTSearch_SFLY
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlRYLISTSearch_SFLY = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlRYLISTSearch_SFLY = -1
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
