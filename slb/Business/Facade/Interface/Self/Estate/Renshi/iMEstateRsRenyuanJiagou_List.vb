Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.BusinessFacade
    ' ����    ��IMEstateRsRenyuanJiagou_List
    '
    ' ���������� 
    '     estate_rs_renyuanjiagou_list.aspxģ�鱾��ָ��ֳ���Ҫ����Ϣ
    '----------------------------------------------------------------
    <Serializable()> Public Class IMEstateRsRenyuanJiagou_List
        Implements IDisposable

        '----------------------------------------------------------------
        ' ģ������
        '----------------------------------------------------------------
        Private m_strhtxtDivLeftBody As String              'htxtDivLeftBody
        Private m_strhtxtDivTopBody As String               'htxtDivTopBody
        Private m_strhtxtDivLeftMain As String              'htxtDivLeftMain
        Private m_strhtxtDivTopMain As String               'htxtDivTopMain
        Private m_strhtxtDivLeftRY As String                'htxtDivLeftRY
        Private m_strhtxtDivTopRY As String                 'htxtDivTopRY

        Private m_strhtxtRYSessionIdQuery As String         'htxtRYSessionIdQuery
        Private m_strhtxtRYQuery As String                  'htxtRYQuery
        Private m_strhtxtRYRows As String                   'htxtRYRows
        Private m_strhtxtRYSort As String                   'htxtRYSort
        Private m_strhtxtRYSortColumnIndex As String        'htxtRYSortColumnIndex
        Private m_strhtxtRYSortType As String               'htxtRYSortType

        Private m_intCurrentPageIndex_grdRY As Integer      'grdRY_CurrentPageIndex
        Private m_intSelectedIndex_grdRY As Integer         'grdRY_SelectedIndex
        Private m_intPageSize_grdRY As Integer              'grdRY_PageSize

        Private m_strtxtSearch_RY_RYDM As String            'txtSearch_RY_RYDM
        Private m_strtxtSearch_RY_RYMC As String            'txtSearch_RY_RYMC
        Private m_strtxtSearch_RY_DWMC As String            'txtSearch_RY_DWMC
        Private m_strtxtSearch_RY_BDSJ As String            'txtSearch_RY_BDSJ
        Private m_strtxtSearch_RY_KSSJMin As String         'txtSearch_RY_KSSJMin
        Private m_strtxtSearch_RY_KSSJMax As String         'txtSearch_RY_KSSJMax
        Private m_strtxtSearch_RY_JSSJMin As String         'txtSearch_RY_JSSJMin
        Private m_strtxtSearch_RY_JSSJMax As String         'txtSearch_RY_JSSJMax

        Private m_strtxtRYPageIndex As String               'txtRYPageIndex
        Private m_strtxtRYPageSize As String                'txtRYPageSize

        Private m_strtxtKSSJ As String                      'txtKSSJ
        Private m_strtxtJSSJ As String                      'txtJSSJ
        Private m_strhtxtSJLD As String                     'htxtSJLD
        Private m_strtxtSJLD As String                      'txtSJLD
        Private m_strtxtZZDM As String                      'txtZZDM
        Private m_strhtxtZZDM As String                     'htxtZZDM
        Private m_intSelectedIndex_ddlZJDM As Integer       'ddlZJDM_SelectedIndex
        Private m_intSelectedIndex_ddlSSFZ As Integer       'ddlSSFZ_SelectedIndex
        Private m_intSelectedIndex_rblRYZT As Integer       'rblRYZT_SelectedIndex
        Private m_intSelectedIndex_rblSFZB As Integer       'rblSFZB_SelectedIndex
        'zengxianglin 2008-11-18
        Private m_strtxtZGDW As String                      'txtZGDW
        Private m_strhtxtZGDW As String                     'htxtZGDW
        'zengxianglin 2008-11-18

        'zengxianglin 2010-01-02
        Private m_strhtxtSessionId_TDZH As String           'htxtSessionId_TDZH
        Private m_strhtxtBZXL As String                     'htxtBZXL
        Private m_strhtxtZGTD As String                     'htxtZGTD
        Private m_strhtxtXGTD As String                     'htxtXGTD
        Private m_strtxtTDBH As String                      'txtTDBH
        Private m_intSelectedIndex_lstZGTD As Integer       'lstZGTD_SelectedIndex
        Private m_intSelectedIndex_lstXGTD As Integer       'lstXGTD_SelectedIndex
        Private m_intSelectedIndex_ddlYDYY As Integer       'ddlYDYY_SelectedIndex
        'zengxianglin 2010-01-02









        '----------------------------------------------------------------
        ' ���캯��
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()

            m_strhtxtDivLeftBody = ""
            m_strhtxtDivTopBody = ""
            m_strhtxtDivLeftMain = ""
            m_strhtxtDivTopMain = ""
            m_strhtxtDivLeftRY = ""
            m_strhtxtDivTopRY = ""

            m_strhtxtRYSessionIdQuery = ""
            m_strhtxtRYQuery = ""
            m_strhtxtRYRows = ""
            m_strhtxtRYSort = ""
            m_strhtxtRYSortColumnIndex = ""
            m_strhtxtRYSortType = ""

            m_intCurrentPageIndex_grdRY = 0
            m_intSelectedIndex_grdRY = -1
            m_intPageSize_grdRY = 30

            m_strtxtSearch_RY_RYDM = ""
            m_strtxtSearch_RY_RYMC = ""
            m_strtxtSearch_RY_DWMC = ""
            m_strtxtSearch_RY_BDSJ = ""
            m_strtxtSearch_RY_KSSJMin = ""
            m_strtxtSearch_RY_KSSJMax = ""
            m_strtxtSearch_RY_JSSJMin = ""
            m_strtxtSearch_RY_JSSJMax = ""

            m_strtxtRYPageIndex = ""
            m_strtxtRYPageSize = "30"

            m_strtxtKSSJ = ""
            m_strtxtJSSJ = ""
            m_strhtxtSJLD = ""
            m_strtxtSJLD = ""
            m_strtxtZZDM = ""
            m_strhtxtZZDM = ""
            m_intSelectedIndex_ddlZJDM = -1
            m_intSelectedIndex_ddlSSFZ = -1
            m_intSelectedIndex_rblRYZT = -1
            m_intSelectedIndex_rblSFZB = -1
            'zengxianglin 2008-11-18
            m_strtxtZGDW = ""
            m_strhtxtZGDW = ""
            'zengxianglin 2008-11-18

            'zengxianglin 2010-01-02
            m_strhtxtSessionId_TDZH = ""
            m_strhtxtBZXL = ""
            m_strhtxtZGTD = ""
            m_strhtxtXGTD = ""
            m_strtxtTDBH = ""
            m_intSelectedIndex_lstZGTD = -1
            m_intSelectedIndex_lstXGTD = -1
            m_intSelectedIndex_ddlYDYY = -1
            'zengxianglin 2010-01-02

        End Sub

        '----------------------------------------------------------------
        ' ������������
        '----------------------------------------------------------------
        Public Sub Dispose() Implements System.IDisposable.Dispose
            Dispose(True)
        End Sub

        '----------------------------------------------------------------
        ' �ͷű�����Դ
        '----------------------------------------------------------------
        Protected Sub Dispose(ByVal disposing As Boolean)
            If (Not disposing) Then
                Exit Sub
            End If
        End Sub

        '----------------------------------------------------------------
        ' ��ȫ�ͷű�����Դ
        '----------------------------------------------------------------
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IMEstateRsRenyuanJiagou_List)
            Try
                If Not (obj Is Nothing) Then
                    obj.Dispose()
                End If
            Catch ex As Exception
            End Try
            obj = Nothing
        End Sub













        '----------------------------------------------------------------
        ' htxtDivLeftBody����
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
        ' htxtDivTopBody����
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
        ' htxtDivLeftMain����
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
        ' htxtDivTopMain����
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
        ' htxtDivLeftRY����
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
        ' htxtDivTopRY����
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
        ' htxtRYSessionIdQuery����
        '----------------------------------------------------------------
        Public Property htxtRYSessionIdQuery() As String
            Get
                htxtRYSessionIdQuery = m_strhtxtRYSessionIdQuery
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtRYSessionIdQuery = Value
                Catch ex As Exception
                    m_strhtxtRYSessionIdQuery = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtRYQuery����
        '----------------------------------------------------------------
        Public Property htxtRYQuery() As String
            Get
                htxtRYQuery = m_strhtxtRYQuery
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtRYQuery = Value
                Catch ex As Exception
                    m_strhtxtRYQuery = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtRYRows����
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

        '----------------------------------------------------------------
        ' htxtRYSort����
        '----------------------------------------------------------------
        Public Property htxtRYSort() As String
            Get
                htxtRYSort = m_strhtxtRYSort
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtRYSort = Value
                Catch ex As Exception
                    m_strhtxtRYSort = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtRYSortColumnIndex����
        '----------------------------------------------------------------
        Public Property htxtRYSortColumnIndex() As String
            Get
                htxtRYSortColumnIndex = m_strhtxtRYSortColumnIndex
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtRYSortColumnIndex = Value
                Catch ex As Exception
                    m_strhtxtRYSortColumnIndex = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtRYSortType����
        '----------------------------------------------------------------
        Public Property htxtRYSortType() As String
            Get
                htxtRYSortType = m_strhtxtRYSortType
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtRYSortType = Value
                Catch ex As Exception
                    m_strhtxtRYSortType = ""
                End Try
            End Set
        End Property












        '----------------------------------------------------------------
        ' grdRY_CurrentPageIndex����
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
        ' grdRY_SelectedIndex����
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
        ' grdRY_PageSize����
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
        ' txtSearch_RY_RYDM����
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
        ' txtSearch_RY_BDSJ����
        '----------------------------------------------------------------
        Public Property txtSearch_RY_BDSJ() As String
            Get
                txtSearch_RY_BDSJ = m_strtxtSearch_RY_BDSJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtSearch_RY_BDSJ = Value
                Catch ex As Exception
                    m_strtxtSearch_RY_BDSJ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtSearch_RY_RYMC����
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
        ' txtSearch_RY_DWMC����
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
        ' txtSearch_RY_KSSJMin����
        '----------------------------------------------------------------
        Public Property txtSearch_RY_KSSJMin() As String
            Get
                txtSearch_RY_KSSJMin = m_strtxtSearch_RY_KSSJMin
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtSearch_RY_KSSJMin = Value
                Catch ex As Exception
                    m_strtxtSearch_RY_KSSJMin = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtSearch_RY_KSSJMax����
        '----------------------------------------------------------------
        Public Property txtSearch_RY_KSSJMax() As String
            Get
                txtSearch_RY_KSSJMax = m_strtxtSearch_RY_KSSJMax
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtSearch_RY_KSSJMax = Value
                Catch ex As Exception
                    m_strtxtSearch_RY_KSSJMax = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtSearch_RY_JSSJMin����
        '----------------------------------------------------------------
        Public Property txtSearch_RY_JSSJMin() As String
            Get
                txtSearch_RY_JSSJMin = m_strtxtSearch_RY_JSSJMin
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtSearch_RY_JSSJMin = Value
                Catch ex As Exception
                    m_strtxtSearch_RY_JSSJMin = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtSearch_RY_JSSJMax����
        '----------------------------------------------------------------
        Public Property txtSearch_RY_JSSJMax() As String
            Get
                txtSearch_RY_JSSJMax = m_strtxtSearch_RY_JSSJMax
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtSearch_RY_JSSJMax = Value
                Catch ex As Exception
                    m_strtxtSearch_RY_JSSJMax = ""
                End Try
            End Set
        End Property












        '----------------------------------------------------------------
        ' txtRYPageSize����
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
        ' txtRYPageIndex����
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
        ' txtKSSJ����
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
        ' txtJSSJ����
        '----------------------------------------------------------------
        Public Property txtJSSJ() As String
            Get
                txtJSSJ = m_strtxtJSSJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJSSJ = Value
                Catch ex As Exception
                    m_strtxtJSSJ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtSJLD����
        '----------------------------------------------------------------
        Public Property htxtSJLD() As String
            Get
                htxtSJLD = m_strhtxtSJLD
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSJLD = Value
                Catch ex As Exception
                    m_strhtxtSJLD = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtSJLD����
        '----------------------------------------------------------------
        Public Property txtSJLD() As String
            Get
                txtSJLD = m_strtxtSJLD
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtSJLD = Value
                Catch ex As Exception
                    m_strtxtSJLD = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtZZDM����
        '----------------------------------------------------------------
        Public Property htxtZZDM() As String
            Get
                htxtZZDM = m_strhtxtZZDM
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtZZDM = Value
                Catch ex As Exception
                    m_strhtxtZZDM = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtZZDM����
        '----------------------------------------------------------------
        Public Property txtZZDM() As String
            Get
                txtZZDM = m_strtxtZZDM
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtZZDM = Value
                Catch ex As Exception
                    m_strtxtZZDM = ""
                End Try
            End Set
        End Property

        'zengxianglin 2008-11-18
        '----------------------------------------------------------------
        ' htxtZGDW����
        '----------------------------------------------------------------
        Public Property htxtZGDW() As String
            Get
                htxtZGDW = m_strhtxtZGDW
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtZGDW = Value
                Catch ex As Exception
                    m_strhtxtZGDW = ""
                End Try
            End Set
        End Property
        'zengxianglin 2008-11-18

        'zengxianglin 2008-11-18
        '----------------------------------------------------------------
        ' txtZGDW����
        '----------------------------------------------------------------
        Public Property txtZGDW() As String
            Get
                txtZGDW = m_strtxtZGDW
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtZGDW = Value
                Catch ex As Exception
                    m_strtxtZGDW = ""
                End Try
            End Set
        End Property
        'zengxianglin 2008-11-18

        '----------------------------------------------------------------
        ' ddlZJDM_SelectedIndex
        '----------------------------------------------------------------
        Public Property ddlZJDM_SelectedIndex() As Integer
            Get
                ddlZJDM_SelectedIndex = m_intSelectedIndex_ddlZJDM
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlZJDM = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlZJDM = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' ddlSSFZ_SelectedIndex
        '----------------------------------------------------------------
        Public Property ddlSSFZ_SelectedIndex() As Integer
            Get
                ddlSSFZ_SelectedIndex = m_intSelectedIndex_ddlSSFZ
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlSSFZ = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlSSFZ = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' rblRYZT_SelectedIndex
        '----------------------------------------------------------------
        Public Property rblRYZT_SelectedIndex() As Integer
            Get
                rblRYZT_SelectedIndex = m_intSelectedIndex_rblRYZT
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_rblRYZT = Value
                Catch ex As Exception
                    m_intSelectedIndex_rblRYZT = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' rblSFZB_SelectedIndex
        '----------------------------------------------------------------
        Public Property rblSFZB_SelectedIndex() As Integer
            Get
                rblSFZB_SelectedIndex = m_intSelectedIndex_rblSFZB
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_rblSFZB = Value
                Catch ex As Exception
                    m_intSelectedIndex_rblSFZB = -1
                End Try
            End Set
        End Property










        '----------------------------------------------------------------
        ' htxtSessionId_TDZH����
        '----------------------------------------------------------------
        Public Property htxtSessionId_TDZH() As String
            Get
                htxtSessionId_TDZH = m_strhtxtSessionId_TDZH
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSessionId_TDZH = Value
                Catch ex As Exception
                    m_strhtxtSessionId_TDZH = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtBZXL����
        '----------------------------------------------------------------
        Public Property htxtBZXL() As String
            Get
                htxtBZXL = m_strhtxtBZXL
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtBZXL = Value
                Catch ex As Exception
                    m_strhtxtBZXL = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtZGTD����
        '----------------------------------------------------------------
        Public Property htxtZGTD() As String
            Get
                htxtZGTD = m_strhtxtZGTD
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtZGTD = Value
                Catch ex As Exception
                    m_strhtxtZGTD = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtXGTD����
        '----------------------------------------------------------------
        Public Property htxtXGTD() As String
            Get
                htxtXGTD = m_strhtxtXGTD
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtXGTD = Value
                Catch ex As Exception
                    m_strhtxtXGTD = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtTDBH����
        '----------------------------------------------------------------
        Public Property txtTDBH() As String
            Get
                txtTDBH = m_strtxtTDBH
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtTDBH = Value
                Catch ex As Exception
                    m_strtxtTDBH = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' lstZGTD_SelectedIndex����
        '----------------------------------------------------------------
        Public Property lstZGTD_SelectedIndex() As Integer
            Get
                lstZGTD_SelectedIndex = m_intSelectedIndex_lstZGTD
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_lstZGTD = Value
                Catch ex As Exception
                    m_intSelectedIndex_lstZGTD = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' lstXGTD_SelectedIndex����
        '----------------------------------------------------------------
        Public Property lstXGTD_SelectedIndex() As Integer
            Get
                lstXGTD_SelectedIndex = m_intSelectedIndex_lstXGTD
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_lstXGTD = Value
                Catch ex As Exception
                    m_intSelectedIndex_lstXGTD = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' ddlYDYY_SelectedIndex����
        '----------------------------------------------------------------
        Public Property ddlYDYY_SelectedIndex() As Integer
            Get
                ddlYDYY_SelectedIndex = Me.m_intSelectedIndex_ddlYDYY
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlYDYY = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlYDYY = -1
                End Try
            End Set
        End Property

    End Class

End Namespace
