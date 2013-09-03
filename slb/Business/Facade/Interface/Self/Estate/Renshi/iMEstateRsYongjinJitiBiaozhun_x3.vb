Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.BusinessFacade
    ' 类名    ：IMEstateRsYongjinJitiBiaozhun_X3
    '
    ' 功能描述： 
    '     estate_rs_yongjinjitibiaozhun_x3.aspx模块本身恢复现场需要的信息
    '----------------------------------------------------------------
    <Serializable()> Public Class IMEstateRsYongjinJitiBiaozhun_X3
        Implements IDisposable

        '----------------------------------------------------------------
        ' 模块属性
        '----------------------------------------------------------------
        Private m_strhtxtFunctionId As String                   'htxtFunctionId

        Private m_strhtxtDivLeftBody As String                  'htxtDivLeftBody
        Private m_strhtxtDivTopBody As String                   'htxtDivTopBody
        Private m_strhtxtDivLeftMain As String                  'htxtDivLeftMain
        Private m_strhtxtDivTopMain As String                   'htxtDivTopMain

        Private m_strhtxtDivLeftSY As String                    'htxtDivLeftSY
        Private m_strhtxtDivTopSY As String                     'htxtDivTopSY

        Private m_strhtxtDivLeftGYZGZJ As String                'htxtDivLeftGYZGZJ
        Private m_strhtxtDivTopGYZGZJ As String                 'htxtDivTopGYZGZJ
        Private m_strhtxtDivLeftGYZG As String                  'htxtDivLeftGYZG
        Private m_strhtxtDivTopGYZG As String                   'htxtDivTopGYZG

        Private m_strhtxtDivLeftGYXG As String                  'htxtDivLeftGYXG
        Private m_strhtxtDivTopGYXG As String                   'htxtDivTopGYXG

        Private m_strhtxtDivLeftGYZTZJ As String                'htxtDivLeftGYZTZJ
        Private m_strhtxtDivTopGYZTZJ As String                 'htxtDivTopGYZTZJ
        Private m_strhtxtDivLeftGYZT As String                  'htxtDivLeftGYZT
        Private m_strhtxtDivTopGYZT As String                   'htxtDivTopGYZT

        Private m_strhtxtSessionId_SY As String                 'htxtSessionId_SY

        Private m_strhtxtSessionId_GYZGZJ As String             'htxtSessionId_GYZGZJ
        Private m_strhtxtSessionId_GYZG As String               'htxtSessionId_GYZG

        Private m_strhtxtSessionId_GYXG As String               'htxtSessionId_GYXG

        Private m_strhtxtSessionId_GYZTZJ As String             'htxtSessionId_GYZTZJ
        Private m_strhtxtSessionId_GYZT As String               'htxtSessionId_GYZT

        Private m_intCurrentPageIndex_grdSY As Integer          'grdSY_CurrentPageIndex
        Private m_intSelectedIndex_grdSY As Integer             'grdSY_SelectedIndex
        Private m_intPageSize_grdSY As Integer                  'grdSY_PageSize

        Private m_intCurrentPageIndex_grdGYZGZJ As Integer      'grdGYZGZJ_CurrentPageIndex
        Private m_intSelectedIndex_grdGYZGZJ As Integer         'grdGYZGZJ_SelectedIndex
        Private m_intPageSize_grdGYZGZJ As Integer              'grdGYZGZJ_PageSize

        Private m_intCurrentPageIndex_grdGYZG As Integer        'grdGYZG_CurrentPageIndex
        Private m_intSelectedIndex_grdGYZG As Integer           'grdGYZG_SelectedIndex
        Private m_intPageSize_grdGYZG As Integer                'grdGYZG_PageSize

        Private m_intCurrentPageIndex_grdGYXG As Integer        'grdGYXG_CurrentPageIndex
        Private m_intSelectedIndex_grdGYXG As Integer           'grdGYXG_SelectedIndex
        Private m_intPageSize_grdGYXG As Integer                'grdGYXG_PageSize

        Private m_intCurrentPageIndex_grdGYZTZJ As Integer      'grdGYZTZJ_CurrentPageIndex
        Private m_intSelectedIndex_grdGYZTZJ As Integer         'grdGYZTZJ_SelectedIndex
        Private m_intPageSize_grdGYZTZJ As Integer              'grdGYZTZJ_PageSize

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
            m_strhtxtDivLeftSY = ""
            m_strhtxtDivTopSY = ""
            m_strhtxtDivLeftGYZGZJ = ""
            m_strhtxtDivTopGYZGZJ = ""
            m_strhtxtDivLeftGYZG = ""
            m_strhtxtDivTopGYZG = ""
            m_strhtxtDivLeftGYXG = ""
            m_strhtxtDivTopGYXG = ""
            m_strhtxtDivLeftGYZTZJ = ""
            m_strhtxtDivTopGYZTZJ = ""
            m_strhtxtDivLeftGYZT = ""
            m_strhtxtDivTopGYZT = ""

            m_strhtxtSessionId_SY = ""
            m_strhtxtSessionId_GYZGZJ = ""
            m_strhtxtSessionId_GYZG = ""
            m_strhtxtSessionId_GYXG = ""
            m_strhtxtSessionId_GYZTZJ = ""
            m_strhtxtSessionId_GYZT = ""

            m_intCurrentPageIndex_grdSY = 0
            m_intSelectedIndex_grdSY = -1
            m_intPageSize_grdSY = 30

            m_intCurrentPageIndex_grdGYZGZJ = 0
            m_intSelectedIndex_grdGYZGZJ = -1
            m_intPageSize_grdGYZGZJ = 30

            m_intCurrentPageIndex_grdGYZG = 0
            m_intSelectedIndex_grdGYZG = -1
            m_intPageSize_grdGYZG = 30

            m_intCurrentPageIndex_grdGYXG = 0
            m_intSelectedIndex_grdGYXG = -1
            m_intPageSize_grdGYXG = 30

            m_intCurrentPageIndex_grdGYZTZJ = 0
            m_intSelectedIndex_grdGYZTZJ = -1
            m_intPageSize_grdGYZTZJ = 30

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
        ' htxtDivLeftSY属性
        '----------------------------------------------------------------
        Public Property htxtDivLeftSY() As String
            Get
                htxtDivLeftSY = m_strhtxtDivLeftSY
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivLeftSY = Value
                Catch ex As Exception
                    m_strhtxtDivLeftSY = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopSY属性
        '----------------------------------------------------------------
        Public Property htxtDivTopSY() As String
            Get
                htxtDivTopSY = m_strhtxtDivTopSY
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivTopSY = Value
                Catch ex As Exception
                    m_strhtxtDivTopSY = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivLeftGYZGZJ属性
        '----------------------------------------------------------------
        Public Property htxtDivLeftGYZGZJ() As String
            Get
                htxtDivLeftGYZGZJ = m_strhtxtDivLeftGYZGZJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivLeftGYZGZJ = Value
                Catch ex As Exception
                    m_strhtxtDivLeftGYZGZJ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopGYZGZJ属性
        '----------------------------------------------------------------
        Public Property htxtDivTopGYZGZJ() As String
            Get
                htxtDivTopGYZGZJ = m_strhtxtDivTopGYZGZJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivTopGYZGZJ = Value
                Catch ex As Exception
                    m_strhtxtDivTopGYZGZJ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivLeftGYZG属性
        '----------------------------------------------------------------
        Public Property htxtDivLeftGYZG() As String
            Get
                htxtDivLeftGYZG = m_strhtxtDivLeftGYZG
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivLeftGYZG = Value
                Catch ex As Exception
                    m_strhtxtDivLeftGYZG = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopGYZG属性
        '----------------------------------------------------------------
        Public Property htxtDivTopGYZG() As String
            Get
                htxtDivTopGYZG = m_strhtxtDivTopGYZG
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivTopGYZG = Value
                Catch ex As Exception
                    m_strhtxtDivTopGYZG = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivLeftGYXG属性
        '----------------------------------------------------------------
        Public Property htxtDivLeftGYXG() As String
            Get
                htxtDivLeftGYXG = m_strhtxtDivLeftGYXG
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivLeftGYXG = Value
                Catch ex As Exception
                    m_strhtxtDivLeftGYXG = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopGYXG属性
        '----------------------------------------------------------------
        Public Property htxtDivTopGYXG() As String
            Get
                htxtDivTopGYXG = m_strhtxtDivTopGYXG
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivTopGYXG = Value
                Catch ex As Exception
                    m_strhtxtDivTopGYXG = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivLeftGYZTZJ属性
        '----------------------------------------------------------------
        Public Property htxtDivLeftGYZTZJ() As String
            Get
                htxtDivLeftGYZTZJ = m_strhtxtDivLeftGYZTZJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivLeftGYZTZJ = Value
                Catch ex As Exception
                    m_strhtxtDivLeftGYZTZJ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopGYZTZJ属性
        '----------------------------------------------------------------
        Public Property htxtDivTopGYZTZJ() As String
            Get
                htxtDivTopGYZTZJ = m_strhtxtDivTopGYZTZJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivTopGYZTZJ = Value
                Catch ex As Exception
                    m_strhtxtDivTopGYZTZJ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivLeftGYZT属性
        '----------------------------------------------------------------
        Public Property htxtDivLeftGYZT() As String
            Get
                htxtDivLeftGYZT = m_strhtxtDivLeftGYZT
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivLeftGYZT = Value
                Catch ex As Exception
                    m_strhtxtDivLeftGYZT = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopGYZT属性
        '----------------------------------------------------------------
        Public Property htxtDivTopGYZT() As String
            Get
                htxtDivTopGYZT = m_strhtxtDivTopGYZT
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivTopGYZT = Value
                Catch ex As Exception
                    m_strhtxtDivTopGYZT = ""
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
        ' htxtSessionId_GYZGZJ属性
        '----------------------------------------------------------------
        Public Property htxtSessionId_GYZGZJ() As String
            Get
                htxtSessionId_GYZGZJ = m_strhtxtSessionId_GYZGZJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSessionId_GYZGZJ = Value
                Catch ex As Exception
                    m_strhtxtSessionId_GYZGZJ = ""
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
        ' htxtSessionId_GYZTZJ属性
        '----------------------------------------------------------------
        Public Property htxtSessionId_GYZTZJ() As String
            Get
                htxtSessionId_GYZTZJ = m_strhtxtSessionId_GYZTZJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSessionId_GYZTZJ = Value
                Catch ex As Exception
                    m_strhtxtSessionId_GYZTZJ = ""
                End Try
            End Set
        End Property















        '----------------------------------------------------------------
        ' grdSY_CurrentPageIndex属性
        '----------------------------------------------------------------
        Public Property grdSY_CurrentPageIndex() As Integer
            Get
                grdSY_CurrentPageIndex = m_intCurrentPageIndex_grdSY
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdSY = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdSY = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdSY_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property grdSY_SelectedIndex() As Integer
            Get
                grdSY_SelectedIndex = m_intSelectedIndex_grdSY
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdSY = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdSY = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdSY_PageSize属性
        '----------------------------------------------------------------
        Public Property grdSY_PageSize() As Integer
            Get
                grdSY_PageSize = m_intPageSize_grdSY
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdSY = Value
                Catch ex As Exception
                    m_intPageSize_grdSY = 0
                End Try
            End Set
        End Property








        '----------------------------------------------------------------
        ' grdGYZGZJ_CurrentPageIndex属性
        '----------------------------------------------------------------
        Public Property grdGYZGZJ_CurrentPageIndex() As Integer
            Get
                grdGYZGZJ_CurrentPageIndex = m_intCurrentPageIndex_grdGYZGZJ
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdGYZGZJ = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdGYZGZJ = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        'grdGYZGZJ_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property grdGYZGZJ_SelectedIndex() As Integer
            Get
                grdGYZGZJ_SelectedIndex = m_intSelectedIndex_grdGYZGZJ
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdGYZGZJ = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdGYZGZJ = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdGYZGZJ_PageSize属性
        '----------------------------------------------------------------
        Public Property grdGYZGZJ_PageSize() As Integer
            Get
                grdGYZGZJ_PageSize = m_intPageSize_grdGYZGZJ
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdGYZGZJ = Value
                Catch ex As Exception
                    m_intPageSize_grdGYZGZJ = 0
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






        '----------------------------------------------------------------
        ' grdGYZTZJ_CurrentPageIndex属性
        '----------------------------------------------------------------
        Public Property grdGYZTZJ_CurrentPageIndex() As Integer
            Get
                grdGYZTZJ_CurrentPageIndex = m_intCurrentPageIndex_grdGYZTZJ
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdGYZTZJ = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdGYZTZJ = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        'grdGYZTZJ_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property grdGYZTZJ_SelectedIndex() As Integer
            Get
                grdGYZTZJ_SelectedIndex = m_intSelectedIndex_grdGYZTZJ
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdGYZTZJ = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdGYZTZJ = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdGYZTZJ_PageSize属性
        '----------------------------------------------------------------
        Public Property grdGYZTZJ_PageSize() As Integer
            Get
                grdGYZTZJ_PageSize = m_intPageSize_grdGYZTZJ
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdGYZTZJ = Value
                Catch ex As Exception
                    m_intPageSize_grdGYZTZJ = 0
                End Try
            End Set
        End Property

    End Class

End Namespace

