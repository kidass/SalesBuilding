Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.BusinessFacade
    ' ����    ��IMEstateRsRenyuanJiagou_Add
    '
    ' ���������� 
    '     estate_rs_renyuanjiagou_add.aspxģ�鱾��ָ��ֳ���Ҫ����Ϣ
    '----------------------------------------------------------------
    <Serializable()> Public Class IMEstateRsRenyuanJiagou_Add
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

        Private m_strhtxtSessionId_RY As String             'htxtSessionId_RY
        Private m_strhtxtQuery_RY As String                 'htxtQuery_RY
        Private m_intCurrentPageIndex_grdRY As Integer      'grdRY_CurrentPageIndex
        Private m_intSelectedIndex_grdRY As Integer         'grdRY_SelectedIndex
        Private m_intPageSize_grdRY As Integer              'grdRY_PageSize

        Private m_intSelectedIndex_ddlZJDM As Integer       'ddlZJDM_SelectedIndex
        Private m_intSelectedIndex_ddlYDYY As Integer       'ddlYDYY_SelectedIndex
        Private m_intSelectedIndex_ddlSSFZ As Integer       'ddlSSFZ_SelectedIndex

        Private m_intSelectedIndex_rblRYLX As Integer       'rblRYLX_SelectedIndex
        Private m_intSelectedIndex_rblRYZT As Integer       'rblRYZT_SelectedIndex
        Private m_intSelectedIndex_rblSFZB As Integer       'rblSFZB_SelectedIndex
        Private m_blnChecked_chkSFJZ As Boolean             'chkSFJZ_Checked
        Private m_strhtxtSSDW As String                     'htxtSSDW
        Private m_strtxtSSDW As String                      'txtSSDW
        Private m_strhtxtSJLD As String                     'htxtSJLD
        Private m_strtxtSJLD As String                      'txtSJLD
        Private m_strtxtSXSJ As String                      'txtSXSJ
        'zengxianglin 2008-11-18
        Private m_strhtxtZGDW As String                     'htxtZGDW
        Private m_strtxtZGDW As String                      'txtZGDW
        'zengxianglin 2008-11-18

        Private m_strtxtSearch_RY_RYDM As String            'txtSearch_RY_RYDM
        Private m_strtxtSearch_RY_ZJDM As String            'txtSearch_RY_ZJDM
        Private m_strtxtSearch_RY_RYMC As String            'txtSearch_RY_RYMC
        Private m_strtxtSearch_RY_DWMC As String            'txtSearch_RY_DWMC

        'zengxianglin 2008-10-14
        Private m_strtxtRYPageIndex As String               'txtRYPageIndex
        Private m_strtxtRYPageSize As String                'txtRYPageSize
        Private m_strhtxtRYRows As String                   'htxtRYRows
        'zengxianglin 2008-10-14









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

            m_strhtxtSessionId_RY = ""
            m_strhtxtQuery_RY = ""

            m_intCurrentPageIndex_grdRY = 0
            m_intSelectedIndex_grdRY = -1
            m_intPageSize_grdRY = 30

            m_intSelectedIndex_ddlZJDM = -1
            m_intSelectedIndex_ddlYDYY = -1
            m_intSelectedIndex_ddlSSFZ = -1
            m_intSelectedIndex_rblRYLX = -1
            m_intSelectedIndex_rblRYZT = -1
            m_intSelectedIndex_rblSFZB = -1
            m_blnChecked_chkSFJZ = False
            m_strhtxtSSDW = ""
            m_strtxtSSDW = ""
            m_strhtxtSJLD = ""
            m_strtxtSJLD = ""
            m_strtxtSXSJ = ""
            'zengxianglin 2008-11-18
            m_strhtxtZGDW = ""
            m_strtxtZGDW = ""
            'zengxianglin 2008-11-18

            m_strtxtSearch_RY_RYDM = ""
            m_strtxtSearch_RY_ZJDM = ""
            m_strtxtSearch_RY_RYMC = ""
            m_strtxtSearch_RY_DWMC = ""

            'zengxianglin 2008-10-14
            m_strtxtRYPageIndex = ""
            m_strtxtRYPageSize = "30"
            m_strhtxtRYRows = ""
            'zengxianglin 2008-10-14

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
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IMEstateRsRenyuanJiagou_Add)
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
        ' htxtSessionId_RY����
        '----------------------------------------------------------------
        Public Property htxtSessionId_RY() As String
            Get
                htxtSessionId_RY = m_strhtxtSessionId_RY
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSessionId_RY = Value
                Catch ex As Exception
                    m_strhtxtSessionId_RY = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtQuery_RY����
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
        ' ddlZJDM_SelectedIndex����
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
        ' ddlYDYY_SelectedIndex����
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
        ' ddlSSFZ_SelectedIndex����
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
        ' rblRYZT_SelectedIndex����
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
        ' rblRYLX_SelectedIndex����
        '----------------------------------------------------------------
        Public Property rblRYLX_SelectedIndex() As Integer
            Get
                rblRYLX_SelectedIndex = m_intSelectedIndex_rblRYLX
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_rblRYLX = Value
                Catch ex As Exception
                    m_intSelectedIndex_rblRYLX = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' rblSFZB_SelectedIndex����
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
        ' chkSFJZ_Checked����
        '----------------------------------------------------------------
        Public Property chkSFJZ_Checked() As Boolean
            Get
                chkSFJZ_Checked = m_blnChecked_chkSFJZ
            End Get
            Set(ByVal Value As Boolean)
                Try
                    m_blnChecked_chkSFJZ = Value
                Catch ex As Exception
                    m_blnChecked_chkSFJZ = False
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtSSDW����
        '----------------------------------------------------------------
        Public Property htxtSSDW() As String
            Get
                htxtSSDW = m_strhtxtSSDW
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSSDW = Value
                Catch ex As Exception
                    m_strhtxtSSDW = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtSSDW����
        '----------------------------------------------------------------
        Public Property txtSSDW() As String
            Get
                txtSSDW = m_strtxtSSDW
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtSSDW = Value
                Catch ex As Exception
                    m_strtxtSSDW = ""
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
        ' txtSXSJ����
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
        ' txtSearch_RY_ZJDM����
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


        'zengxianglin 2008-10-14
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
        'zengxianglin 2008-10-14

        'zengxianglin 2008-10-14
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
        'zengxianglin 2008-10-14

        'zengxianglin 2008-10-14
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
        'zengxianglin 2008-10-14

    End Class

End Namespace
