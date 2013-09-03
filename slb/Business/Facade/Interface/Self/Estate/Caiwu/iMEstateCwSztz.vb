Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.BusinessFacade
    ' 类名    ：IMEstateCwSztz
    '
    ' 功能描述： 
    '     estate_cw_sztz.aspx模块本身恢复现场需要的信息
    '----------------------------------------------------------------
    <Serializable()> Public Class IMEstateCwSztz
        Implements IDisposable

        Private m_strhtxtDivLeftQTFY As String                      'htxtDivLeftQTFY
        Private m_strhtxtDivTopQTFY As String                       'htxtDivTopQTFY
        Private m_strhtxtDivLeftFK As String                        'htxtDivLeftFK
        Private m_strhtxtDivTopFK As String                         'htxtDivTopFK
        Private m_strhtxtDivLeftZJF As String                       'htxtDivLeftZJF
        Private m_strhtxtDivTopZJF As String                        'htxtDivTopZJF
        Private m_strhtxtDivLeftMain As String                      'htxtDivLeftMain
        Private m_strhtxtDivTopMain As String                       'htxtDivTopMain
        Private m_strhtxtDivLeftBody As String                      'htxtDivLeftBody
        Private m_strhtxtDivTopBody As String                       'htxtDivTopBody

        Private m_strhtxtZJFQuery As String                         'htxtZJFQuery
        Private m_strhtxtZJFRows As String                          'htxtZJFRows
        Private m_strhtxtZJFSort As String                          'htxtZJFSort
        Private m_strhtxtZJFSortColumnIndex As String               'htxtZJFSortColumnIndex
        Private m_strhtxtZJFSortType As String                      'htxtZJFSortType

        Private m_strhtxtFKQuery As String                          'htxtFKQuery
        Private m_strhtxtFKRows As String                           'htxtFKRows
        Private m_strhtxtFKSort As String                           'htxtFKSort
        Private m_strhtxtFKSortColumnIndex As String                'htxtFKSortColumnIndex
        Private m_strhtxtFKSortType As String                       'htxtFKSortType

        Private m_strhtxtQTFYQuery As String                        'htxtQTFYQuery
        Private m_strhtxtQTFYRows As String                         'htxtQTFYRows
        Private m_strhtxtQTFYSort As String                         'htxtQTFYSort
        Private m_strhtxtQTFYSortColumnIndex As String              'htxtQTFYSortColumnIndex
        Private m_strhtxtQTFYSortType As String                     'htxtQTFYSortType

        Private m_intPageSize_grdZJF As Integer
        Private m_intSelectedIndex_grdZJF As Integer
        Private m_intCurrentPageIndex_grdZJF As Integer

        Private m_intPageSize_grdFK As Integer
        Private m_intSelectedIndex_grdFK As Integer
        Private m_intCurrentPageIndex_grdFK As Integer

        Private m_intPageSize_grdQTFY As Integer
        Private m_intSelectedIndex_grdQTFY As Integer
        Private m_intCurrentPageIndex_grdQTFY As Integer

        Private m_strtxtJYBH As String                              'txtJYBH

        Private m_strtxtZJF_JF_SR As String                         'txtZJF_JF_SR
        Private m_strtxtZJF_JF_ZC As String                         'txtZJF_JF_ZC
        Private m_strtxtZJF_JF_YE As String                         'txtZJF_JF_YE
        Private m_strtxtZJF_YF_SR As String                         'txtZJF_YF_SR
        Private m_strtxtZJF_YF_ZC As String                         'txtZJF_YF_ZC
        Private m_strtxtZJF_YF_YE As String                         'txtZJF_YF_YE
        Private m_strtxtZJF_HT_SR As String                         'txtZJF_HT_SR
        Private m_strtxtZJF_HT_ZC As String                         'txtZJF_HT_ZC
        Private m_strtxtZJF_HT_YE As String                         'txtZJF_HT_YE

        Private m_strtxtFK_JF_SR As String                          'txtFK_JF_SR
        Private m_strtxtFK_JF_ZC As String                          'txtFK_JF_ZC
        Private m_strtxtFK_JF_YE As String                          'txtFK_JF_YE
        Private m_strtxtFK_YF_SR As String                          'txtFK_YF_SR
        Private m_strtxtFK_YF_ZC As String                          'txtFK_YF_ZC
        Private m_strtxtFK_YF_YE As String                          'txtFK_YF_YE
        Private m_strtxtFK_HT_SR As String                          'txtFK_HT_SR
        Private m_strtxtFK_HT_ZC As String                          'txtFK_HT_ZC
        Private m_strtxtFK_HT_YE As String                          'txtFK_HT_YE

        Private m_strtxtQTFY_JF_SR As String                        'txtQTFY_JF_SR
        Private m_strtxtQTFY_JF_ZC As String                        'txtQTFY_JF_ZC
        Private m_strtxtQTFY_JF_YE As String                        'txtQTFY_JF_YE
        Private m_strtxtQTFY_YF_SR As String                        'txtQTFY_YF_SR
        Private m_strtxtQTFY_YF_ZC As String                        'txtQTFY_YF_ZC
        Private m_strtxtQTFY_YF_YE As String                        'txtQTFY_YF_YE
        Private m_strtxtQTFY_HT_SR As String                        'txtQTFY_HT_SR
        Private m_strtxtQTFY_HT_ZC As String                        'txtQTFY_HT_ZC
        Private m_strtxtQTFY_HT_YE As String                        'txtQTFY_HT_YE

        Private m_strtxtZKSH_YJKS As String                         'txtZKSH_YJKS
        Private m_strtxtZKSH_YJZZ As String                         'txtZKSH_YJZZ
        Private m_strtxtZKSH_EJKS As String                         'txtZKSH_EJKS
        Private m_strtxtZKSH_EJZZ As String                         'txtZKSH_EJZZ
        Private m_strtxtZKSH_SJKS As String                         'txtZKSH_SJKS
        Private m_strtxtZKSH_SJZZ As String                         'txtZKSH_SJZZ
        Private m_strtxtZKSH_SFBZ As String                         'txtZKSH_SFBZ
        Private m_strtxtZKSH_HTYS As String                         'txtZKSH_HTYS
        Private m_strtxtZKSH_HTZK As String                         'txtZKSH_HTZK
        Private m_strtxtZKSH_LJSS As String                         'txtZKSH_LJSS
        Private m_strtxtZKSH_YE As String                           'txtZKSH_YE
        Private m_strtxtZKSH_YJSH As String                         'txtZKSH_YJSH
        Private m_strtxtZKSH_EJSH As String                         'txtZKSH_EJSH
        Private m_strtxtZKSH_SJSH As String                         'txtZKSH_SJSH
        Private m_strtxtZKSH_BZXX As String                         'txtZKSH_BZXX
        Private m_intSelectedIndex_rblZKSH_JA As Integer            'rblZKSH_JA










        '----------------------------------------------------------------
        ' 构造函数
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()

            m_strhtxtDivLeftQTFY = ""
            m_strhtxtDivTopQTFY = ""
            m_strhtxtDivLeftFK = ""
            m_strhtxtDivTopFK = ""
            m_strhtxtDivLeftZJF = ""
            m_strhtxtDivTopZJF = ""
            m_strhtxtDivLeftMain = ""
            m_strhtxtDivTopMain = ""
            m_strhtxtDivLeftBody = ""
            m_strhtxtDivTopBody = ""

            m_strhtxtZJFQuery = ""
            m_strhtxtZJFRows = ""
            m_strhtxtZJFSort = ""
            m_strhtxtZJFSortColumnIndex = ""
            m_strhtxtZJFSortType = ""

            m_strhtxtFKQuery = ""
            m_strhtxtFKRows = ""
            m_strhtxtFKSort = ""
            m_strhtxtFKSortColumnIndex = ""
            m_strhtxtFKSortType = ""

            m_strhtxtQTFYQuery = ""
            m_strhtxtQTFYRows = ""
            m_strhtxtQTFYSort = ""
            m_strhtxtQTFYSortColumnIndex = ""
            m_strhtxtQTFYSortType = ""

            m_intPageSize_grdZJF = 0
            m_intCurrentPageIndex_grdZJF = 0
            m_intSelectedIndex_grdZJF = -1

            m_intPageSize_grdFK = 0
            m_intCurrentPageIndex_grdFK = 0
            m_intSelectedIndex_grdFK = -1

            m_intPageSize_grdQTFY = 0
            m_intCurrentPageIndex_grdQTFY = 0
            m_intSelectedIndex_grdQTFY = -1

            m_strtxtJYBH = ""

            m_strtxtFK_JF_SR = ""
            m_strtxtFK_JF_ZC = ""
            m_strtxtFK_JF_YE = ""
            m_strtxtFK_YF_SR = ""
            m_strtxtFK_YF_ZC = ""
            m_strtxtFK_YF_YE = ""
            m_strtxtFK_HT_SR = ""
            m_strtxtFK_HT_ZC = ""
            m_strtxtFK_HT_YE = ""

            m_strtxtZJF_JF_SR = ""
            m_strtxtZJF_JF_ZC = ""
            m_strtxtZJF_JF_YE = ""
            m_strtxtZJF_YF_SR = ""
            m_strtxtZJF_YF_ZC = ""
            m_strtxtZJF_YF_YE = ""
            m_strtxtZJF_HT_SR = ""
            m_strtxtZJF_HT_ZC = ""
            m_strtxtZJF_HT_YE = ""

            m_strtxtQTFY_JF_SR = ""
            m_strtxtQTFY_JF_ZC = ""
            m_strtxtQTFY_JF_YE = ""
            m_strtxtQTFY_YF_SR = ""
            m_strtxtQTFY_YF_ZC = ""
            m_strtxtQTFY_YF_YE = ""
            m_strtxtQTFY_HT_SR = ""
            m_strtxtQTFY_HT_ZC = ""
            m_strtxtQTFY_HT_YE = ""

            m_strtxtZKSH_YJKS = ""
            m_strtxtZKSH_YJZZ = ""
            m_strtxtZKSH_EJKS = ""
            m_strtxtZKSH_EJZZ = ""
            m_strtxtZKSH_SJKS = ""
            m_strtxtZKSH_SJZZ = ""
            m_strtxtZKSH_SFBZ = ""
            m_strtxtZKSH_HTYS = ""
            m_strtxtZKSH_HTZK = ""
            m_strtxtZKSH_LJSS = ""
            m_strtxtZKSH_YE = ""
            m_strtxtZKSH_YJSH = ""
            m_strtxtZKSH_EJSH = ""
            m_strtxtZKSH_SJSH = ""
            m_strtxtZKSH_BZXX = ""
            m_intSelectedIndex_rblZKSH_JA = -1

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
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IMEstateCwSztz)
            Try
                If Not (obj Is Nothing) Then
                    obj.Dispose()
                End If
            Catch ex As Exception
            End Try
            obj = Nothing
        End Sub












        '----------------------------------------------------------------
        ' htxtZJFQuery属性
        '----------------------------------------------------------------
        Public Property htxtZJFQuery() As String
            Get
                htxtZJFQuery = m_strhtxtZJFQuery
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtZJFQuery = Value
                Catch ex As Exception
                    m_strhtxtZJFQuery = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtZJFRows属性
        '----------------------------------------------------------------
        Public Property htxtZJFRows() As String
            Get
                htxtZJFRows = m_strhtxtZJFRows
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtZJFRows = Value
                Catch ex As Exception
                    m_strhtxtZJFRows = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtZJFSort属性
        '----------------------------------------------------------------
        Public Property htxtZJFSort() As String
            Get
                htxtZJFSort = m_strhtxtZJFSort
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtZJFSort = Value
                Catch ex As Exception
                    m_strhtxtZJFSort = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtZJFSortColumnIndex属性
        '----------------------------------------------------------------
        Public Property htxtZJFSortColumnIndex() As String
            Get
                htxtZJFSortColumnIndex = m_strhtxtZJFSortColumnIndex
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtZJFSortColumnIndex = Value
                Catch ex As Exception
                    m_strhtxtZJFSortColumnIndex = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtZJFSortType属性
        '----------------------------------------------------------------
        Public Property htxtZJFSortType() As String
            Get
                htxtZJFSortType = m_strhtxtZJFSortType
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtZJFSortType = Value
                Catch ex As Exception
                    m_strhtxtZJFSortType = ""
                End Try
            End Set
        End Property












        '----------------------------------------------------------------
        ' htxtFKQuery属性
        '----------------------------------------------------------------
        Public Property htxtFKQuery() As String
            Get
                htxtFKQuery = m_strhtxtFKQuery
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtFKQuery = Value
                Catch ex As Exception
                    m_strhtxtFKQuery = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtFKRows属性
        '----------------------------------------------------------------
        Public Property htxtFKRows() As String
            Get
                htxtFKRows = m_strhtxtFKRows
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtFKRows = Value
                Catch ex As Exception
                    m_strhtxtFKRows = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtFKSort属性
        '----------------------------------------------------------------
        Public Property htxtFKSort() As String
            Get
                htxtFKSort = m_strhtxtFKSort
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtFKSort = Value
                Catch ex As Exception
                    m_strhtxtFKSort = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtFKSortColumnIndex属性
        '----------------------------------------------------------------
        Public Property htxtFKSortColumnIndex() As String
            Get
                htxtFKSortColumnIndex = m_strhtxtFKSortColumnIndex
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtFKSortColumnIndex = Value
                Catch ex As Exception
                    m_strhtxtFKSortColumnIndex = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtFKSortType属性
        '----------------------------------------------------------------
        Public Property htxtFKSortType() As String
            Get
                htxtFKSortType = m_strhtxtFKSortType
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtFKSortType = Value
                Catch ex As Exception
                    m_strhtxtFKSortType = ""
                End Try
            End Set
        End Property












        '----------------------------------------------------------------
        ' htxtQTFYQuery属性
        '----------------------------------------------------------------
        Public Property htxtQTFYQuery() As String
            Get
                htxtQTFYQuery = m_strhtxtQTFYQuery
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtQTFYQuery = Value
                Catch ex As Exception
                    m_strhtxtQTFYQuery = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtQTFYRows属性
        '----------------------------------------------------------------
        Public Property htxtQTFYRows() As String
            Get
                htxtQTFYRows = m_strhtxtQTFYRows
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtQTFYRows = Value
                Catch ex As Exception
                    m_strhtxtQTFYRows = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtQTFYSort属性
        '----------------------------------------------------------------
        Public Property htxtQTFYSort() As String
            Get
                htxtQTFYSort = m_strhtxtQTFYSort
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtQTFYSort = Value
                Catch ex As Exception
                    m_strhtxtQTFYSort = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtQTFYSortColumnIndex属性
        '----------------------------------------------------------------
        Public Property htxtQTFYSortColumnIndex() As String
            Get
                htxtQTFYSortColumnIndex = m_strhtxtQTFYSortColumnIndex
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtQTFYSortColumnIndex = Value
                Catch ex As Exception
                    m_strhtxtQTFYSortColumnIndex = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtQTFYSortType属性
        '----------------------------------------------------------------
        Public Property htxtQTFYSortType() As String
            Get
                htxtQTFYSortType = m_strhtxtQTFYSortType
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtQTFYSortType = Value
                Catch ex As Exception
                    m_strhtxtQTFYSortType = ""
                End Try
            End Set
        End Property












        '----------------------------------------------------------------
        ' htxtDivLeftQTFY属性
        '----------------------------------------------------------------
        Public Property htxtDivLeftQTFY() As String
            Get
                htxtDivLeftQTFY = m_strhtxtDivLeftQTFY
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivLeftQTFY = Value
                Catch ex As Exception
                    m_strhtxtDivLeftQTFY = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopQTFY属性
        '----------------------------------------------------------------
        Public Property htxtDivTopQTFY() As String
            Get
                htxtDivTopQTFY = m_strhtxtDivTopQTFY
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivTopQTFY = Value
                Catch ex As Exception
                    m_strhtxtDivTopQTFY = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivLeftFK属性
        '----------------------------------------------------------------
        Public Property htxtDivLeftFK() As String
            Get
                htxtDivLeftFK = m_strhtxtDivLeftFK
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivLeftFK = Value
                Catch ex As Exception
                    m_strhtxtDivLeftFK = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopFK属性
        '----------------------------------------------------------------
        Public Property htxtDivTopFK() As String
            Get
                htxtDivTopFK = m_strhtxtDivTopFK
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivTopFK = Value
                Catch ex As Exception
                    m_strhtxtDivTopFK = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivLeftZJF属性
        '----------------------------------------------------------------
        Public Property htxtDivLeftZJF() As String
            Get
                htxtDivLeftZJF = m_strhtxtDivLeftZJF
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivLeftZJF = Value
                Catch ex As Exception
                    m_strhtxtDivLeftZJF = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopZJF属性
        '----------------------------------------------------------------
        Public Property htxtDivTopZJF() As String
            Get
                htxtDivTopZJF = m_strhtxtDivTopZJF
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivTopZJF = Value
                Catch ex As Exception
                    m_strhtxtDivTopZJF = ""
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
        ' grdZJFPageSize属性
        '----------------------------------------------------------------
        Public Property grdZJFPageSize() As Integer
            Get
                grdZJFPageSize = m_intPageSize_grdZJF
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdZJF = Value
                Catch ex As Exception
                    m_intPageSize_grdZJF = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdZJFCurrentPageIndex属性
        '----------------------------------------------------------------
        Public Property grdZJFCurrentPageIndex() As Integer
            Get
                grdZJFCurrentPageIndex = m_intCurrentPageIndex_grdZJF
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdZJF = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdZJF = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdZJFSelectedIndex属性
        '----------------------------------------------------------------
        Public Property grdZJFSelectedIndex() As Integer
            Get
                grdZJFSelectedIndex = m_intSelectedIndex_grdZJF
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdZJF = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdZJF = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdFKPageSize属性
        '----------------------------------------------------------------
        Public Property grdFKPageSize() As Integer
            Get
                grdFKPageSize = m_intPageSize_grdFK
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdFK = Value
                Catch ex As Exception
                    m_intPageSize_grdFK = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdFKCurrentPageIndex属性
        '----------------------------------------------------------------
        Public Property grdFKCurrentPageIndex() As Integer
            Get
                grdFKCurrentPageIndex = m_intCurrentPageIndex_grdFK
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdFK = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdFK = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdFKSelectedIndex属性
        '----------------------------------------------------------------
        Public Property grdFKSelectedIndex() As Integer
            Get
                grdFKSelectedIndex = m_intSelectedIndex_grdFK
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdFK = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdFK = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdQTFYPageSize属性
        '----------------------------------------------------------------
        Public Property grdQTFYPageSize() As Integer
            Get
                grdQTFYPageSize = m_intPageSize_grdQTFY
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdQTFY = Value
                Catch ex As Exception
                    m_intPageSize_grdQTFY = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdQTFYCurrentPageIndex属性
        '----------------------------------------------------------------
        Public Property grdQTFYCurrentPageIndex() As Integer
            Get
                grdQTFYCurrentPageIndex = m_intCurrentPageIndex_grdQTFY
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdQTFY = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdQTFY = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdQTFYSelectedIndex属性
        '----------------------------------------------------------------
        Public Property grdQTFYSelectedIndex() As Integer
            Get
                grdQTFYSelectedIndex = m_intSelectedIndex_grdQTFY
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdQTFY = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdQTFY = -1
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












        '----------------------------------------------------------------
        ' txtZJF_JF_SR属性
        '----------------------------------------------------------------
        Public Property txtZJF_JF_SR() As String
            Get
                txtZJF_JF_SR = m_strtxtZJF_JF_SR
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtZJF_JF_SR = Value
                Catch ex As Exception
                    m_strtxtZJF_JF_SR = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtZJF_JF_ZC属性
        '----------------------------------------------------------------
        Public Property txtZJF_JF_ZC() As String
            Get
                txtZJF_JF_ZC = m_strtxtZJF_JF_ZC
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtZJF_JF_ZC = Value
                Catch ex As Exception
                    m_strtxtZJF_JF_ZC = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtZJF_JF_YE属性
        '----------------------------------------------------------------
        Public Property txtZJF_JF_YE() As String
            Get
                txtZJF_JF_YE = m_strtxtZJF_JF_YE
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtZJF_JF_YE = Value
                Catch ex As Exception
                    m_strtxtZJF_JF_YE = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtZJF_YF_SR属性
        '----------------------------------------------------------------
        Public Property txtZJF_YF_SR() As String
            Get
                txtZJF_YF_SR = m_strtxtZJF_YF_SR
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtZJF_YF_SR = Value
                Catch ex As Exception
                    m_strtxtZJF_YF_SR = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtZJF_YF_ZC属性
        '----------------------------------------------------------------
        Public Property txtZJF_YF_ZC() As String
            Get
                txtZJF_YF_ZC = m_strtxtZJF_YF_ZC
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtZJF_YF_ZC = Value
                Catch ex As Exception
                    m_strtxtZJF_YF_ZC = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtZJF_YF_YE属性
        '----------------------------------------------------------------
        Public Property txtZJF_YF_YE() As String
            Get
                txtZJF_YF_YE = m_strtxtZJF_YF_YE
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtZJF_YF_YE = Value
                Catch ex As Exception
                    m_strtxtZJF_YF_YE = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtZJF_HT_SR属性
        '----------------------------------------------------------------
        Public Property txtZJF_HT_SR() As String
            Get
                txtZJF_HT_SR = m_strtxtZJF_HT_SR
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtZJF_HT_SR = Value
                Catch ex As Exception
                    m_strtxtZJF_HT_SR = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtZJF_HT_ZC属性
        '----------------------------------------------------------------
        Public Property txtZJF_HT_ZC() As String
            Get
                txtZJF_HT_ZC = m_strtxtZJF_HT_ZC
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtZJF_HT_ZC = Value
                Catch ex As Exception
                    m_strtxtZJF_HT_ZC = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtZJF_HT_YE属性
        '----------------------------------------------------------------
        Public Property txtZJF_HT_YE() As String
            Get
                txtZJF_HT_YE = m_strtxtZJF_HT_YE
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtZJF_HT_YE = Value
                Catch ex As Exception
                    m_strtxtZJF_HT_YE = ""
                End Try
            End Set
        End Property














        '----------------------------------------------------------------
        ' txtFK_JF_SR属性
        '----------------------------------------------------------------
        Public Property txtFK_JF_SR() As String
            Get
                txtFK_JF_SR = m_strtxtFK_JF_SR
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtFK_JF_SR = Value
                Catch ex As Exception
                    m_strtxtFK_JF_SR = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtFK_JF_ZC属性
        '----------------------------------------------------------------
        Public Property txtFK_JF_ZC() As String
            Get
                txtFK_JF_ZC = m_strtxtFK_JF_ZC
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtFK_JF_ZC = Value
                Catch ex As Exception
                    m_strtxtFK_JF_ZC = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtFK_JF_YE属性
        '----------------------------------------------------------------
        Public Property txtFK_JF_YE() As String
            Get
                txtFK_JF_YE = m_strtxtFK_JF_YE
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtFK_JF_YE = Value
                Catch ex As Exception
                    m_strtxtFK_JF_YE = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtFK_YF_SR属性
        '----------------------------------------------------------------
        Public Property txtFK_YF_SR() As String
            Get
                txtFK_YF_SR = m_strtxtFK_YF_SR
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtFK_YF_SR = Value
                Catch ex As Exception
                    m_strtxtFK_YF_SR = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtFK_YF_ZC属性
        '----------------------------------------------------------------
        Public Property txtFK_YF_ZC() As String
            Get
                txtFK_YF_ZC = m_strtxtFK_YF_ZC
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtFK_YF_ZC = Value
                Catch ex As Exception
                    m_strtxtFK_YF_ZC = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtFK_YF_YE属性
        '----------------------------------------------------------------
        Public Property txtFK_YF_YE() As String
            Get
                txtFK_YF_YE = m_strtxtFK_YF_YE
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtFK_YF_YE = Value
                Catch ex As Exception
                    m_strtxtFK_YF_YE = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtFK_HT_SR属性
        '----------------------------------------------------------------
        Public Property txtFK_HT_SR() As String
            Get
                txtFK_HT_SR = m_strtxtFK_HT_SR
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtFK_HT_SR = Value
                Catch ex As Exception
                    m_strtxtFK_HT_SR = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtFK_HT_ZC属性
        '----------------------------------------------------------------
        Public Property txtFK_HT_ZC() As String
            Get
                txtFK_HT_ZC = m_strtxtFK_HT_ZC
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtFK_HT_ZC = Value
                Catch ex As Exception
                    m_strtxtFK_HT_ZC = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtFK_HT_YE属性
        '----------------------------------------------------------------
        Public Property txtFK_HT_YE() As String
            Get
                txtFK_HT_YE = m_strtxtFK_HT_YE
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtFK_HT_YE = Value
                Catch ex As Exception
                    m_strtxtFK_HT_YE = ""
                End Try
            End Set
        End Property













        '----------------------------------------------------------------
        ' txtQTFY_JF_SR属性
        '----------------------------------------------------------------
        Public Property txtQTFY_JF_SR() As String
            Get
                txtQTFY_JF_SR = m_strtxtQTFY_JF_SR
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtQTFY_JF_SR = Value
                Catch ex As Exception
                    m_strtxtQTFY_JF_SR = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtQTFY_JF_ZC属性
        '----------------------------------------------------------------
        Public Property txtQTFY_JF_ZC() As String
            Get
                txtQTFY_JF_ZC = m_strtxtQTFY_JF_ZC
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtQTFY_JF_ZC = Value
                Catch ex As Exception
                    m_strtxtQTFY_JF_ZC = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtQTFY_JF_YE属性
        '----------------------------------------------------------------
        Public Property txtQTFY_JF_YE() As String
            Get
                txtQTFY_JF_YE = m_strtxtQTFY_JF_YE
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtQTFY_JF_YE = Value
                Catch ex As Exception
                    m_strtxtQTFY_JF_YE = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtQTFY_YF_SR属性
        '----------------------------------------------------------------
        Public Property txtQTFY_YF_SR() As String
            Get
                txtQTFY_YF_SR = m_strtxtQTFY_YF_SR
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtQTFY_YF_SR = Value
                Catch ex As Exception
                    m_strtxtQTFY_YF_SR = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtQTFY_YF_ZC属性
        '----------------------------------------------------------------
        Public Property txtQTFY_YF_ZC() As String
            Get
                txtQTFY_YF_ZC = m_strtxtQTFY_YF_ZC
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtQTFY_YF_ZC = Value
                Catch ex As Exception
                    m_strtxtQTFY_YF_ZC = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtQTFY_YF_YE属性
        '----------------------------------------------------------------
        Public Property txtQTFY_YF_YE() As String
            Get
                txtQTFY_YF_YE = m_strtxtQTFY_YF_YE
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtQTFY_YF_YE = Value
                Catch ex As Exception
                    m_strtxtQTFY_YF_YE = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtQTFY_HT_SR属性
        '----------------------------------------------------------------
        Public Property txtQTFY_HT_SR() As String
            Get
                txtQTFY_HT_SR = m_strtxtQTFY_HT_SR
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtQTFY_HT_SR = Value
                Catch ex As Exception
                    m_strtxtQTFY_HT_SR = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtQTFY_HT_ZC属性
        '----------------------------------------------------------------
        Public Property txtQTFY_HT_ZC() As String
            Get
                txtQTFY_HT_ZC = m_strtxtQTFY_HT_ZC
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtQTFY_HT_ZC = Value
                Catch ex As Exception
                    m_strtxtQTFY_HT_ZC = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtQTFY_HT_YE属性
        '----------------------------------------------------------------
        Public Property txtQTFY_HT_YE() As String
            Get
                txtQTFY_HT_YE = m_strtxtQTFY_HT_YE
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtQTFY_HT_YE = Value
                Catch ex As Exception
                    m_strtxtQTFY_HT_YE = ""
                End Try
            End Set
        End Property













        '----------------------------------------------------------------
        ' txtZKSH_YJKS属性
        '----------------------------------------------------------------
        Public Property txtZKSH_YJKS() As String
            Get
                txtZKSH_YJKS = m_strtxtZKSH_YJKS
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtZKSH_YJKS = Value
                Catch ex As Exception
                    m_strtxtZKSH_YJKS = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtZKSH_YJZZ属性
        '----------------------------------------------------------------
        Public Property txtZKSH_YJZZ() As String
            Get
                txtZKSH_YJZZ = m_strtxtZKSH_YJZZ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtZKSH_YJZZ = Value
                Catch ex As Exception
                    m_strtxtZKSH_YJZZ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtZKSH_EJKS属性
        '----------------------------------------------------------------
        Public Property txtZKSH_EJKS() As String
            Get
                txtZKSH_EJKS = m_strtxtZKSH_EJKS
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtZKSH_EJKS = Value
                Catch ex As Exception
                    m_strtxtZKSH_EJKS = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtZKSH_EJZZ属性
        '----------------------------------------------------------------
        Public Property txtZKSH_EJZZ() As String
            Get
                txtZKSH_EJZZ = m_strtxtZKSH_EJZZ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtZKSH_EJZZ = Value
                Catch ex As Exception
                    m_strtxtZKSH_EJZZ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtZKSH_SJKS属性
        '----------------------------------------------------------------
        Public Property txtZKSH_SJKS() As String
            Get
                txtZKSH_SJKS = m_strtxtZKSH_SJKS
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtZKSH_SJKS = Value
                Catch ex As Exception
                    m_strtxtZKSH_SJKS = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtZKSH_SJZZ属性
        '----------------------------------------------------------------
        Public Property txtZKSH_SJZZ() As String
            Get
                txtZKSH_SJZZ = m_strtxtZKSH_SJZZ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtZKSH_SJZZ = Value
                Catch ex As Exception
                    m_strtxtZKSH_SJZZ = ""
                End Try
            End Set
        End Property











        '----------------------------------------------------------------
        ' txtZKSH_SFBZ属性
        '----------------------------------------------------------------
        Public Property txtZKSH_SFBZ() As String
            Get
                txtZKSH_SFBZ = m_strtxtZKSH_SFBZ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtZKSH_SFBZ = Value
                Catch ex As Exception
                    m_strtxtZKSH_SFBZ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtZKSH_HTYS属性
        '----------------------------------------------------------------
        Public Property txtZKSH_HTYS() As String
            Get
                txtZKSH_HTYS = m_strtxtZKSH_HTYS
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtZKSH_HTYS = Value
                Catch ex As Exception
                    m_strtxtZKSH_HTYS = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtZKSH_HTZK属性
        '----------------------------------------------------------------
        Public Property txtZKSH_HTZK() As String
            Get
                txtZKSH_HTZK = m_strtxtZKSH_HTZK
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtZKSH_HTZK = Value
                Catch ex As Exception
                    m_strtxtZKSH_HTZK = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtZKSH_LJSS属性
        '----------------------------------------------------------------
        Public Property txtZKSH_LJSS() As String
            Get
                txtZKSH_LJSS = m_strtxtZKSH_LJSS
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtZKSH_LJSS = Value
                Catch ex As Exception
                    m_strtxtZKSH_LJSS = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtZKSH_YE属性
        '----------------------------------------------------------------
        Public Property txtZKSH_YE() As String
            Get
                txtZKSH_YE = m_strtxtZKSH_YE
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtZKSH_YE = Value
                Catch ex As Exception
                    m_strtxtZKSH_YE = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtZKSH_YJSH属性
        '----------------------------------------------------------------
        Public Property txtZKSH_YJSH() As String
            Get
                txtZKSH_YJSH = m_strtxtZKSH_YJSH
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtZKSH_YJSH = Value
                Catch ex As Exception
                    m_strtxtZKSH_YJSH = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtZKSH_EJSH属性
        '----------------------------------------------------------------
        Public Property txtZKSH_EJSH() As String
            Get
                txtZKSH_EJSH = m_strtxtZKSH_EJSH
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtZKSH_EJSH = Value
                Catch ex As Exception
                    m_strtxtZKSH_EJSH = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtZKSH_SJSH属性
        '----------------------------------------------------------------
        Public Property txtZKSH_SJSH() As String
            Get
                txtZKSH_SJSH = m_strtxtZKSH_SJSH
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtZKSH_SJSH = Value
                Catch ex As Exception
                    m_strtxtZKSH_SJSH = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtZKSH_BZXX属性
        '----------------------------------------------------------------
        Public Property txtZKSH_BZXX() As String
            Get
                txtZKSH_BZXX = m_strtxtZKSH_BZXX
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtZKSH_BZXX = Value
                Catch ex As Exception
                    m_strtxtZKSH_BZXX = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' rblZKSH_JA_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property rblZKSH_JA_SelectedIndex() As Integer
            Get
                rblZKSH_JA_SelectedIndex = m_intSelectedIndex_rblZKSH_JA
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_rblZKSH_JA = Value
                Catch ex As Exception
                    m_intSelectedIndex_rblZKSH_JA = -1
                End Try
            End Set
        End Property

    End Class

End Namespace
