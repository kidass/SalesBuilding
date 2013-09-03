Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.BusinessFacade
    ' ����    ��IMEstateRsRskpPxjl
    '
    ' ���������� 
    '     estate_rs_rskp_pxjl.aspxģ�鱾��ָ��ֳ���Ҫ����Ϣ
    '----------------------------------------------------------------
    <Serializable()> Public Class IMEstateRsRskpPxjl
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

        Private m_strtxtRYLISTPageIndex As String                   'txtRYLISTPageIndex
        Private m_strtxtRYLISTPageSize As String                    'txtRYLISTPageSize

        Private m_strtxtRYLISTSearch_RYDM As String                 'txtRYLISTSearch_RYDM
        Private m_strtxtRYLISTSearch_PXMC As String                 'txtRYLISTSearch_PXMC
        Private m_strtxtRYLISTSearch_PXXG As String                 'txtRYLISTSearch_PXXG
        Private m_strtxtRYLISTSearch_PXSJMin As String              'txtRYLISTSearch_PXSJMin
        Private m_strtxtRYLISTSearch_PXSJMax As String              'txtRYLISTSearch_PXSJMax
        Private m_intSelectedIndex_ddlRYLISTSearch_PXLX As Integer  'ddlRYLISTSearch_PXLX_SelectedIndex

        Private m_strhtxtWYBS As String                             'htxtWYBS
        Private m_strhtxtRYDM As String                             'htxtRYDM
        Private m_strtxtRYMC As String                              'txtRYMC
        Private m_strtxtPXMC As String                              'txtPXMC
        Private m_strtxtKSSJ As String                              'txtKSSJ
        Private m_strtxtJSSJ As String                              'txtJSSJ
        Private m_strtxtPXXG As String                              'txtPXXG
        Private m_strtxtBZXX As String                              'txtBZXX
        Private m_strtxtPXKS As String                              'txtPXKS
        Private m_intSelectedIndex_rblPXLX As Integer               'rblPXLX_SelectedIndex

        Private m_strhtxtCurrentPage As String                      'htxtCurrentPage
        Private m_strhtxtCurrentRow As String                       'htxtCurrentRow
        Private m_strhtxtEditMode As String                         'htxtEditMode
        Private m_strhtxtEditType As String                         'htxtEditType

        '----------------------------------------------------------------
        'asp:datagrid - grdRYLIST
        '----------------------------------------------------------------
        Private m_intPageSize_grdRYLIST As Integer
        Private m_intSelectedIndex_grdRYLIST As Integer
        Private m_intCurrentPageIndex_grdRYLIST As Integer











        '----------------------------------------------------------------
        ' ���캯��
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

            m_strtxtRYLISTSearch_RYDM = ""
            m_strtxtRYLISTSearch_PXMC = ""
            m_strtxtRYLISTSearch_PXXG = ""
            m_strtxtRYLISTSearch_PXSJMin = ""
            m_strtxtRYLISTSearch_PXSJMax = ""
            m_intSelectedIndex_ddlRYLISTSearch_PXLX = -1

            m_strhtxtWYBS = ""
            m_strhtxtRYDM = ""
            m_strtxtRYMC = ""
            m_strtxtPXMC = ""
            m_strtxtKSSJ = ""
            m_strtxtJSSJ = ""
            m_strtxtPXXG = ""
            m_strtxtBZXX = ""
            m_strtxtPXKS = ""
            m_intSelectedIndex_rblPXLX = -1

            m_strhtxtCurrentPage = ""
            m_strhtxtCurrentRow = ""
            m_strhtxtEditMode = ""
            m_strhtxtEditType = ""

            m_intPageSize_grdRYLIST = 0
            m_intCurrentPageIndex_grdRYLIST = 0
            m_intSelectedIndex_grdRYLIST = -1

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
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IMEstateRsRskpPxjl)
            Try
                If Not (obj Is Nothing) Then
                    obj.Dispose()
                End If
            Catch ex As Exception
            End Try
            obj = Nothing
        End Sub












        '----------------------------------------------------------------
        ' htxtRYLISTQuery����
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
        ' htxtRYLISTRows����
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
        ' htxtRYLISTSort����
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
        ' htxtRYLISTSortColumnIndex����
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
        ' htxtRYLISTSortType����
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
        ' htxtDivLeftRYLIST����
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
        ' htxtDivTopRYLIST����
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
        ' htxtSessionIdQuery����
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
        ' txtRYLISTPageIndex����
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
        ' txtRYLISTPageSize����
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
        ' txtRYLISTSearch_RYDM����
        '----------------------------------------------------------------
        Public Property txtRYLISTSearch_RYDM() As String
            Get
                txtRYLISTSearch_RYDM = m_strtxtRYLISTSearch_RYDM
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtRYLISTSearch_RYDM = Value
                Catch ex As Exception
                    m_strtxtRYLISTSearch_RYDM = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtRYLISTSearch_PXMC����
        '----------------------------------------------------------------
        Public Property txtRYLISTSearch_PXMC() As String
            Get
                txtRYLISTSearch_PXMC = m_strtxtRYLISTSearch_PXMC
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtRYLISTSearch_PXMC = Value
                Catch ex As Exception
                    m_strtxtRYLISTSearch_PXMC = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtRYLISTSearch_PXXG����
        '----------------------------------------------------------------
        Public Property txtRYLISTSearch_PXXG() As String
            Get
                txtRYLISTSearch_PXXG = m_strtxtRYLISTSearch_PXXG
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtRYLISTSearch_PXXG = Value
                Catch ex As Exception
                    m_strtxtRYLISTSearch_PXXG = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtRYLISTSearch_PXSJMin����
        '----------------------------------------------------------------
        Public Property txtRYLISTSearch_PXSJMin() As String
            Get
                txtRYLISTSearch_PXSJMin = m_strtxtRYLISTSearch_PXSJMin
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtRYLISTSearch_PXSJMin = Value
                Catch ex As Exception
                    m_strtxtRYLISTSearch_PXSJMin = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtRYLISTSearch_PXSJMax����
        '----------------------------------------------------------------
        Public Property txtRYLISTSearch_PXSJMax() As String
            Get
                txtRYLISTSearch_PXSJMax = m_strtxtRYLISTSearch_PXSJMax
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtRYLISTSearch_PXSJMax = Value
                Catch ex As Exception
                    m_strtxtRYLISTSearch_PXSJMax = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' ddlRYLISTSearch_PXLX_SelectedIndex����
        '----------------------------------------------------------------
        Public Property ddlRYLISTSearch_PXLX_SelectedIndex() As Integer
            Get
                ddlRYLISTSearch_PXLX_SelectedIndex = m_intSelectedIndex_ddlRYLISTSearch_PXLX
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlRYLISTSearch_PXLX = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlRYLISTSearch_PXLX = -1
                End Try
            End Set
        End Property













        '----------------------------------------------------------------
        ' htxtWYBS����
        '----------------------------------------------------------------
        Public Property htxtWYBS() As String
            Get
                htxtWYBS = m_strhtxtWYBS
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtWYBS = Value
                Catch ex As Exception
                    m_strhtxtWYBS = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtRYDM����
        '----------------------------------------------------------------
        Public Property htxtRYDM() As String
            Get
                htxtRYDM = m_strhtxtRYDM
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtRYDM = Value
                Catch ex As Exception
                    m_strhtxtRYDM = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtRYMC����
        '----------------------------------------------------------------
        Public Property txtRYMC() As String
            Get
                txtRYMC = m_strtxtRYMC
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtRYMC = Value
                Catch ex As Exception
                    m_strtxtRYMC = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtPXMC����
        '----------------------------------------------------------------
        Public Property txtPXMC() As String
            Get
                txtPXMC = m_strtxtPXMC
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtPXMC = Value
                Catch ex As Exception
                    m_strtxtPXMC = ""
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
        ' txtPXXG����
        '----------------------------------------------------------------
        Public Property txtPXXG() As String
            Get
                txtPXXG = m_strtxtPXXG
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtPXXG = Value
                Catch ex As Exception
                    m_strtxtPXXG = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtBZXX����
        '----------------------------------------------------------------
        Public Property txtBZXX() As String
            Get
                txtBZXX = m_strtxtBZXX
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtBZXX = Value
                Catch ex As Exception
                    m_strtxtBZXX = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtPXKS����
        '----------------------------------------------------------------
        Public Property txtPXKS() As String
            Get
                txtPXKS = m_strtxtPXKS
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtPXKS = Value
                Catch ex As Exception
                    m_strtxtPXKS = ""
                End Try
            End Set
        End Property


        '----------------------------------------------------------------
        ' rblPXLX_SelectedIndex����
        '----------------------------------------------------------------
        Public Property rblPXLX_SelectedIndex() As Integer
            Get
                rblPXLX_SelectedIndex = m_intSelectedIndex_rblPXLX
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_rblPXLX = Value
                Catch ex As Exception
                    m_intSelectedIndex_rblPXLX = -1
                End Try
            End Set
        End Property












        '----------------------------------------------------------------
        ' htxtCurrentPage����
        '----------------------------------------------------------------
        Public Property htxtCurrentPage() As String
            Get
                htxtCurrentPage = m_strhtxtCurrentPage
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtCurrentPage = Value
                Catch ex As Exception
                    m_strhtxtCurrentPage = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtCurrentRow����
        '----------------------------------------------------------------
        Public Property htxtCurrentRow() As String
            Get
                htxtCurrentRow = m_strhtxtCurrentRow
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtCurrentRow = Value
                Catch ex As Exception
                    m_strhtxtCurrentRow = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtEditMode����
        '----------------------------------------------------------------
        Public Property htxtEditMode() As String
            Get
                htxtEditMode = m_strhtxtEditMode
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtEditMode = Value
                Catch ex As Exception
                    m_strhtxtEditMode = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtEditType����
        '----------------------------------------------------------------
        Public Property htxtEditType() As String
            Get
                htxtEditType = m_strhtxtEditType
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtEditType = Value
                Catch ex As Exception
                    m_strhtxtEditType = ""
                End Try
            End Set
        End Property











        '----------------------------------------------------------------
        ' grdRYLISTPageSize����
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
        ' grdRYLISTCurrentPageIndex����
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
        ' grdRYLISTSelectedIndex����
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
