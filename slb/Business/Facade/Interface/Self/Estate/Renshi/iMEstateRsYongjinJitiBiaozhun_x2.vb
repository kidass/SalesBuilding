Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.BusinessFacade
    ' 类名    ：IMEstateRsYongjinJitiBiaozhun_X2
    '
    ' 功能描述： 
    '     estate_rs_yongjinjitibiaozhun_X2.aspx模块本身恢复现场需要的信息
    '----------------------------------------------------------------
    <Serializable()> Public Class IMEstateRsYongjinJitiBiaozhun_X2
        Implements IDisposable

        '----------------------------------------------------------------
        ' 模块属性
        '----------------------------------------------------------------
        Private m_strhtxtFunctionId As String                   'htxtFunctionId
        Private m_strhtxtDivLeftBody As String                  'htxtDivLeftBody
        Private m_strhtxtDivTopBody As String                   'htxtDivTopBody
        Private m_strhtxtDivLeftMain As String                  'htxtDivLeftMain
        Private m_strhtxtDivTopMain As String                   'htxtDivTopMain

        Private m_strhtxtSessionId_SY As String                 'htxtSessionId_SY
        Private m_strhtxtSessionId_GYZG As String               'htxtSessionId_GYZG
        Private m_strhtxtSessionId_GYZGZB As String             'htxtSessionId_GYZGZB
        Private m_strhtxtSessionId_GYXG As String               'htxtSessionId_GYXG
        Private m_strhtxtSessionId_GYXGZB As String             'htxtSessionId_GYXGZB
        Private m_strhtxtSessionId_GYZT As String               'htxtSessionId_GYZT

        Private m_intCurrentPageIndex_grdSYZB As Integer        'grdSYZB_CurrentPageIndex
        Private m_intSelectedIndex_grdSYZB As Integer           'grdSYBZ_SelectedIndex
        Private m_intPageSize_grdSYZB As Integer                'grdSYZB_PageSize

        Private m_intCurrentPageIndex_grdGYZG As Integer        'grdGYZG_CurrentPageIndex
        Private m_intSelectedIndex_grdGYZG As Integer           'grdGYZG_SelectedIndex
        Private m_intPageSize_grdGYZG As Integer                'grdGYZG_PageSize

        Private m_intCurrentPageIndex_grdGYZGZB As Integer      'grdGYZGZB_CurrentPageIndex
        Private m_intSelectedIndex_grdGYZGZB As Integer         'grdGYZGZB_SelectedIndex
        Private m_intPageSize_grdGYZGZB As Integer              'grdGYZGZB_PageSize

        Private m_intCurrentPageIndex_grdGYXG As Integer        'grdGYXG_CurrentPageIndex
        Private m_intSelectedIndex_grdGYXG As Integer           'grdGYXG_SelectedIndex
        Private m_intPageSize_grdGYXG As Integer                'grdGYXG_PageSize

        Private m_intCurrentPageIndex_grdGYXGZB As Integer      'grdGYXGZB_CurrentPageIndex
        Private m_intSelectedIndex_grdGYXGZB As Integer         'grdGYXGZB_SelectedIndex
        Private m_intPageSize_grdGYXGZB As Integer              'grdGYXGZB_PageSize

        Private m_intCurrentPageIndex_grdGYZT As Integer        'grdGYZT_CurrentPageIndex
        Private m_intSelectedIndex_grdGYZT As Integer           'grdGYZT_SelectedIndex
        Private m_intPageSize_grdGYZT As Integer                'grdGYZT_PageSize







        '----------------------------------------------------------------
        ' 构造函数
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()

            m_strhtxtFunctionId = ""
            m_strhtxtDivLeftBody = ""
            m_strhtxtDivTopBody = ""
            m_strhtxtDivLeftMain = ""
            m_strhtxtDivTopMain = ""

            m_strhtxtSessionId_SY = ""
            m_strhtxtSessionId_GYZG = ""
            m_strhtxtSessionId_GYZGZB = ""
            m_strhtxtSessionId_GYXG = ""
            m_strhtxtSessionId_GYXGZB = ""
            m_strhtxtSessionId_GYZT = ""

            m_intCurrentPageIndex_grdSYZB = 0
            m_intSelectedIndex_grdSYZB = -1
            m_intPageSize_grdSYZB = 30

            m_intCurrentPageIndex_grdGYZG = 0
            m_intSelectedIndex_grdGYZG = -1
            m_intPageSize_grdGYZG = 30

            m_intCurrentPageIndex_grdGYZGZB = 0
            m_intSelectedIndex_grdGYZGZB = -1
            m_intPageSize_grdGYZGZB = 30

            m_intCurrentPageIndex_grdGYXG = 0
            m_intSelectedIndex_grdGYXG = -1
            m_intPageSize_grdGYXG = 30

            m_intCurrentPageIndex_grdGYXGZB = 0
            m_intSelectedIndex_grdGYXGZB = -1
            m_intPageSize_grdGYXGZB = 30

            m_intCurrentPageIndex_grdGYZT = 0
            m_intSelectedIndex_grdGYZT = -1
            m_intPageSize_grdGYZT = 30


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
        ' htxtFunctionId属性
        '----------------------------------------------------------------
        Public Property htxtFunctionId() As String
            Get
                htxtFunctionId = m_strhtxtFunctionId
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtFunctionId = Value
                Catch ex As Exception
                    m_strhtxtFunctionId = ""
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
        ' htxtSessionId_SY属性
        '----------------------------------------------------------------
        Public Property htxtSessionId_SY() As String
            Get
                htxtSessionId_SY = m_strhtxtSessionId_SY
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSessionId_SY = Value
                Catch ex As Exception
                    m_strhtxtSessionId_SY = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtSessionId_GYZG属性
        '----------------------------------------------------------------
        Public Property htxtSessionId_GYZG() As String
            Get
                htxtSessionId_GYZG = m_strhtxtSessionId_GYZG
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSessionId_GYZG = Value
                Catch ex As Exception
                    m_strhtxtSessionId_GYZG = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtSessionId_GYZGZB属性
        '----------------------------------------------------------------
        Public Property htxtSessionId_GYZGZB() As String
            Get
                htxtSessionId_GYZGZB = m_strhtxtSessionId_GYZGZB
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSessionId_GYZGZB = Value
                Catch ex As Exception
                    m_strhtxtSessionId_GYZGZB = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtSessionId_GYXG属性
        '----------------------------------------------------------------
        Public Property htxtSessionId_GYXG() As String
            Get
                htxtSessionId_GYXG = m_strhtxtSessionId_GYXG
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSessionId_GYXG = Value
                Catch ex As Exception
                    m_strhtxtSessionId_GYXG = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtSessionId_GYXGZB属性
        '----------------------------------------------------------------
        Public Property htxtSessionId_GYXGZB() As String
            Get
                htxtSessionId_GYXGZB = m_strhtxtSessionId_GYXGZB
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSessionId_GYXGZB = Value
                Catch ex As Exception
                    m_strhtxtSessionId_GYXGZB = ""
                End Try
            End Set
        End Property


        '----------------------------------------------------------------
        ' htxtSessionId_GYZT属性
        '----------------------------------------------------------------
        Public Property htxtSessionId_GYZT() As String
            Get
                htxtSessionId_GYZT = m_strhtxtSessionId_GYZT
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSessionId_GYZT = Value
                Catch ex As Exception
                    m_strhtxtSessionId_GYZT = ""
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
        ' grdGYZG_CurrentPageIndex属性
        '----------------------------------------------------------------
        Public Property grdGYZG_CurrentPageIndex() As Integer
            Get
                grdGYZG_CurrentPageIndex = m_intCurrentPageIndex_grdGYZG
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdGYZG = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdGYZG = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        'grdGYZG_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property grdGYZG_SelectedIndex() As Integer
            Get
                grdGYZG_SelectedIndex = m_intSelectedIndex_grdGYZG
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdGYZG = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdGYZG = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdGYZG_PageSize属性
        '----------------------------------------------------------------
        Public Property grdGYZG_PageSize() As Integer
            Get
                grdGYZG_PageSize = m_intPageSize_grdGYZG
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdGYZG = Value
                Catch ex As Exception
                    m_intPageSize_grdGYZG = 0
                End Try
            End Set
        End Property







        '----------------------------------------------------------------
        ' grdGYZGZB_CurrentPageIndex属性
        '----------------------------------------------------------------
        Public Property grdGYZGZB_CurrentPageIndex() As Integer
            Get
                grdGYZGZB_CurrentPageIndex = m_intCurrentPageIndex_grdGYZGZB
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdGYZGZB = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdGYZGZB = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        'grdGYZGZB_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property grdGYZGZB_SelectedIndex() As Integer
            Get
                grdGYZGZB_SelectedIndex = m_intSelectedIndex_grdGYZGZB
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdGYZGZB = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdGYZGZB = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdGYZGZB_PageSize属性
        '----------------------------------------------------------------
        Public Property grdGYZGZB_PageSize() As Integer
            Get
                grdGYZGZB_PageSize = m_intPageSize_grdGYZGZB
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdGYZGZB = Value
                Catch ex As Exception
                    m_intPageSize_grdGYZGZB = 0
                End Try
            End Set
        End Property







        '----------------------------------------------------------------
        ' grdGYXG_CurrentPageIndex属性
        '----------------------------------------------------------------
        Public Property grdGYXG_CurrentPageIndex() As Integer
            Get
                grdGYXG_CurrentPageIndex = m_intCurrentPageIndex_grdGYXG
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdGYXG = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdGYXG = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        'grdGYXG_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property grdGYXG_SelectedIndex() As Integer
            Get
                grdGYXG_SelectedIndex = m_intSelectedIndex_grdGYXG
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdGYXG = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdGYXG = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdGYXG_PageSize属性
        '----------------------------------------------------------------
        Public Property grdGYXG_PageSize() As Integer
            Get
                grdGYXG_PageSize = m_intPageSize_grdGYXG
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdGYXG = Value
                Catch ex As Exception
                    m_intPageSize_grdGYXG = 0
                End Try
            End Set
        End Property







        '----------------------------------------------------------------
        ' grdGYXGZB_CurrentPageIndex属性
        '----------------------------------------------------------------
        Public Property grdGYXGZB_CurrentPageIndex() As Integer
            Get
                grdGYXGZB_CurrentPageIndex = m_intCurrentPageIndex_grdGYXGZB
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdGYXGZB = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdGYXGZB = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        'grdGYXGZB_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property grdGYXGZB_SelectedIndex() As Integer
            Get
                grdGYXGZB_SelectedIndex = m_intSelectedIndex_grdGYXGZB
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdGYXGZB = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdGYXGZB = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdGYXGZB_PageSize属性
        '----------------------------------------------------------------
        Public Property grdGYXGZB_PageSize() As Integer
            Get
                grdGYXGZB_PageSize = m_intPageSize_grdGYXGZB
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdGYXGZB = Value
                Catch ex As Exception
                    m_intPageSize_grdGYXGZB = 0
                End Try
            End Set
        End Property






        '----------------------------------------------------------------
        ' grdGYZT_CurrentPageIndex属性
        '----------------------------------------------------------------
        Public Property grdGYZT_CurrentPageIndex() As Integer
            Get
                grdGYZT_CurrentPageIndex = m_intCurrentPageIndex_grdGYZT
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdGYZT = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdGYZT = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        'grdGYZT_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property grdGYZT_SelectedIndex() As Integer
            Get
                grdGYZT_SelectedIndex = m_intSelectedIndex_grdGYZT
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdGYZT = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdGYZT = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdGYZT_PageSize属性
        '----------------------------------------------------------------
        Public Property grdGYZT_PageSize() As Integer
            Get
                grdGYZT_PageSize = m_intPageSize_grdGYZT
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdGYZT = Value
                Catch ex As Exception
                    m_intPageSize_grdGYZT = 0
                End Try
            End Set
        End Property

    End Class

End Namespace

