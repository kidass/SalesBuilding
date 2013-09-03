Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.BusinessFacade
    ' 类名    ：IMEstateRsYongjinJitiBiaozhun
    '
    ' 功能描述： 
    '     estate_rs_yongjinjitibiaozhun.aspx模块本身恢复现场需要的信息
    '----------------------------------------------------------------
    <Serializable()> Public Class IMEstateRsYongjinJitiBiaozhun
        Implements IDisposable

        '----------------------------------------------------------------
        ' 模块属性
        '----------------------------------------------------------------
        Private m_strhtxtDivLeftBody As String              'htxtDivLeftBody
        Private m_strhtxtDivTopBody As String               'htxtDivTopBody
        Private m_strhtxtDivLeftMain As String              'htxtDivLeftMain
        Private m_strhtxtDivTopMain As String               'htxtDivTopMain

        Private m_strhtxtSessionId_GY As String             'htxtSessionId_GY
        Private m_strhtxtSessionId_SYZB As String           'htxtSessionId_SYZB
        Private m_strhtxtSessionId_SYZJ As String           'htxtSessionId_SYZJ

        Private m_intCurrentPageIndex_grdGY As Integer      'grdGY_CurrentPageIndex
        Private m_intSelectedIndex_grdGY As Integer         'grdGY_SelectedIndex
        Private m_intPageSize_grdGY As Integer              'grdGY_PageSize

        Private m_intCurrentPageIndex_grdSYZB As Integer    'grdSYZB_CurrentPageIndex
        Private m_intSelectedIndex_grdSYZB As Integer       'grdSYZB_SelectedIndex
        Private m_intPageSize_grdSYZB As Integer            'grdSYZB_PageSize

        Private m_intCurrentPageIndex_grdSYZJ As Integer    'grdSYZJ_CurrentPageIndex
        Private m_intSelectedIndex_grdSYZJ As Integer       'grdSYZJ_SelectedIndex
        Private m_intPageSize_grdSYZJ As Integer            'grdSYZJ_PageSize







        '----------------------------------------------------------------
        ' 构造函数
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()

            m_strhtxtDivLeftBody = ""
            m_strhtxtDivTopBody = ""
            m_strhtxtDivLeftMain = ""
            m_strhtxtDivTopMain = ""

            m_strhtxtSessionId_GY = ""
            m_strhtxtSessionId_SYZB = ""
            m_strhtxtSessionId_SYZJ = ""

            m_intCurrentPageIndex_grdGY = 0
            m_intSelectedIndex_grdGY = -1
            m_intPageSize_grdGY = 30

            m_intCurrentPageIndex_grdSYZB = 0
            m_intSelectedIndex_grdSYZB = -1
            m_intPageSize_grdSYZB = 30

            m_intCurrentPageIndex_grdSYZJ = 0
            m_intSelectedIndex_grdSYZJ = -1
            m_intPageSize_grdSYZJ = 30

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
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IMEstateRsYongjinJitiBiaozhun)
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
        ' htxtSessionId_GY属性
        '----------------------------------------------------------------
        Public Property htxtSessionId_GY() As String
            Get
                htxtSessionId_GY = m_strhtxtSessionId_GY
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSessionId_GY = Value
                Catch ex As Exception
                    m_strhtxtSessionId_GY = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtSessionId_SYZB属性
        '----------------------------------------------------------------
        Public Property htxtSessionId_SYZB() As String
            Get
                htxtSessionId_SYZB = m_strhtxtSessionId_SYZB
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSessionId_SYZB = Value
                Catch ex As Exception
                    m_strhtxtSessionId_SYZB = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtSessionId_SYZJ属性
        '----------------------------------------------------------------
        Public Property htxtSessionId_SYZJ() As String
            Get
                htxtSessionId_SYZJ = m_strhtxtSessionId_SYZJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSessionId_SYZJ = Value
                Catch ex As Exception
                    m_strhtxtSessionId_SYZJ = ""
                End Try
            End Set
        End Property










        '----------------------------------------------------------------
        ' grdGY_CurrentPageIndex属性
        '----------------------------------------------------------------
        Public Property grdGY_CurrentPageIndex() As Integer
            Get
                grdGY_CurrentPageIndex = m_intCurrentPageIndex_grdGY
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdGY = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdGY = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdGY_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property grdGY_SelectedIndex() As Integer
            Get
                grdGY_SelectedIndex = m_intSelectedIndex_grdGY
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdGY = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdGY = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdGY_PageSize属性
        '----------------------------------------------------------------
        Public Property grdGY_PageSize() As Integer
            Get
                grdGY_PageSize = m_intPageSize_grdGY
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdGY = Value
                Catch ex As Exception
                    m_intPageSize_grdGY = 0
                End Try
            End Set
        End Property













        '----------------------------------------------------------------
        ' grdSYZB_CurrentPageIndex属性
        '----------------------------------------------------------------
        Public Property grdSYZB_CurrentPageIndex() As Integer
            Get
                grdSYZB_CurrentPageIndex = m_intCurrentPageIndex_grdSYZB
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdSYZB = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdSYZB = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdSYZB_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property grdSYZB_SelectedIndex() As Integer
            Get
                grdSYZB_SelectedIndex = m_intSelectedIndex_grdSYZB
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdSYZB = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdSYZB = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdSYZB_PageSize属性
        '----------------------------------------------------------------
        Public Property grdSYZB_PageSize() As Integer
            Get
                grdSYZB_PageSize = m_intPageSize_grdSYZB
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdSYZB = Value
                Catch ex As Exception
                    m_intPageSize_grdSYZB = 0
                End Try
            End Set
        End Property









        '----------------------------------------------------------------
        ' grdSYZJ_CurrentPageIndex属性
        '----------------------------------------------------------------
        Public Property grdSYZJ_CurrentPageIndex() As Integer
            Get
                grdSYZJ_CurrentPageIndex = m_intCurrentPageIndex_grdSYZJ
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdSYZJ = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdSYZJ = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdSYZJ_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property grdSYZJ_SelectedIndex() As Integer
            Get
                grdSYZJ_SelectedIndex = m_intSelectedIndex_grdSYZJ
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdSYZJ = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdSYZJ = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdSYZJ_PageSize属性
        '----------------------------------------------------------------
        Public Property grdSYZJ_PageSize() As Integer
            Get
                grdSYZJ_PageSize = m_intPageSize_grdSYZJ
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdSYZJ = Value
                Catch ex As Exception
                    m_intPageSize_grdSYZJ = 0
                End Try
            End Set
        End Property

    End Class

End Namespace
