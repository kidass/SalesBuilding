Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.BusinessFacade
    ' ����    ��IMEstateEsBbEsNddb
    '
    ' ���������� 
    '     estate_es_bb_esnddb.aspxģ�鱾��ָ��ֳ���Ҫ����Ϣ
    '----------------------------------------------------------------
    <Serializable()> Public Class IMEstateEsBbEsNddb
        Implements IDisposable

        '----------------------------------------------------------------
        Private m_strhtxtQuery As String                          'htxtQuery
        Private m_strhtxtRows As String                           'htxtRows
        Private m_strhtxtSort As String                           'htxtSort
        Private m_strhtxtSortColumnIndex As String                'htxtSortColumnIndex
        Private m_strhtxtSortType As String                       'htxtSortType
        '----------------------------------------------------------------
        Private m_strhtxtDivLeftContent As String                 'htxtDivLeftContent
        Private m_strhtxtDivTopContent As String                  'htxtDivTopContent
        Private m_strhtxtDivLeftBody As String                    'htxtDivLeftBody
        Private m_strhtxtDivTopBody As String                     'htxtDivTopBody
        '----------------------------------------------------------------
        Private m_strtxtPageIndex As String                       'txtPageIndex
        Private m_strtxtPageSize As String                        'txtPageSize
        '----------------------------------------------------------------
        Private m_intSelectedIndex_ddlZZDM As Integer             'ddlZZDM_SelectedIndex
        Private m_intSelectedIndex_ddlYWLX As Integer             'ddlYWLX_SelectedIndex
        Private m_intSelectedIndex_ddlTJZB As Integer             'ddlTJZB_SelectedIndex
        Private m_intSelectedIndex_ddlType As Integer             'ddlType_SelectedIndex
        Private m_strtxtKSND As String                            'txtKSND
        Private m_strtxtZZND As String                            'txtZZND
        Private m_strtxtYJZR As String                            'txtYJZR
        '----------------------------------------------------------------
        Private m_strhtxtSessionIdQuery As String                 'htxtSessionIdQuery
        Private m_strhtxtSessionIdBuffer As String                'htxtSessionIdBuffer
        '----------------------------------------------------------------
        Private m_intPageSize_grdContent As Integer
        Private m_intSelectedIndex_grdContent As Integer
        Private m_intCurrentPageIndex_grdContent As Integer









        '----------------------------------------------------------------
        ' ���캯��
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()

            '----------------------------------------------------------------
            m_strhtxtQuery = ""
            m_strhtxtRows = ""
            m_strhtxtSort = ""
            m_strhtxtSortColumnIndex = ""
            m_strhtxtSortType = ""
            '----------------------------------------------------------------
            m_strhtxtDivLeftContent = ""
            m_strhtxtDivTopContent = ""
            m_strhtxtDivLeftBody = ""
            m_strhtxtDivTopBody = ""
            '----------------------------------------------------------------
            m_strtxtPageIndex = ""
            m_strtxtPageSize = ""
            '----------------------------------------------------------------
            m_intSelectedIndex_ddlZZDM = -1
            m_intSelectedIndex_ddlYWLX = -1
            m_intSelectedIndex_ddlTJZB = -1
            m_intSelectedIndex_ddlType = -1
            m_strtxtKSND = ""
            m_strtxtZZND = ""
            m_strtxtYJZR = ""
            '----------------------------------------------------------------
            m_strhtxtSessionIdQuery = ""
            m_strhtxtSessionIdBuffer = ""
            '----------------------------------------------------------------
            m_intPageSize_grdContent = 0
            m_intSelectedIndex_grdContent = -1
            m_intCurrentPageIndex_grdContent = 0

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
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IMEstateEsBbEsNddb)
            Try
                If Not (obj Is Nothing) Then
                    obj.Dispose()
                End If
            Catch ex As Exception
            End Try
            obj = Nothing
        End Sub








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
        ' htxtSessionIdBuffer����
        '----------------------------------------------------------------
        Public Property htxtSessionIdBuffer() As String
            Get
                htxtSessionIdBuffer = m_strhtxtSessionIdBuffer
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSessionIdBuffer = Value
                Catch ex As Exception
                    m_strhtxtSessionIdBuffer = ""
                End Try
            End Set
        End Property










        '----------------------------------------------------------------
        ' htxtQuery����
        '----------------------------------------------------------------
        Public Property htxtQuery() As String
            Get
                htxtQuery = m_strhtxtQuery
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtQuery = Value
                Catch ex As Exception
                    m_strhtxtQuery = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtRows����
        '----------------------------------------------------------------
        Public Property htxtRows() As String
            Get
                htxtRows = m_strhtxtRows
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtRows = Value
                Catch ex As Exception
                    m_strhtxtRows = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtSort����
        '----------------------------------------------------------------
        Public Property htxtSort() As String
            Get
                htxtSort = m_strhtxtSort
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSort = Value
                Catch ex As Exception
                    m_strhtxtSort = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtSortColumnIndex����
        '----------------------------------------------------------------
        Public Property htxtSortColumnIndex() As String
            Get
                htxtSortColumnIndex = m_strhtxtSortColumnIndex
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSortColumnIndex = Value
                Catch ex As Exception
                    m_strhtxtSortColumnIndex = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtSortType����
        '----------------------------------------------------------------
        Public Property htxtSortType() As String
            Get
                htxtSortType = m_strhtxtSortType
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSortType = Value
                Catch ex As Exception
                    m_strhtxtSortType = ""
                End Try
            End Set
        End Property












        '----------------------------------------------------------------
        ' htxtDivLeftContent����
        '----------------------------------------------------------------
        Public Property htxtDivLeftContent() As String
            Get
                htxtDivLeftContent = m_strhtxtDivLeftContent
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivLeftContent = Value
                Catch ex As Exception
                    m_strhtxtDivLeftContent = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopContent����
        '----------------------------------------------------------------
        Public Property htxtDivTopContent() As String
            Get
                htxtDivTopContent = m_strhtxtDivTopContent
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivTopContent = Value
                Catch ex As Exception
                    m_strhtxtDivTopContent = ""
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
        ' txtPageIndex����
        '----------------------------------------------------------------
        Public Property txtPageIndex() As String
            Get
                txtPageIndex = m_strtxtPageIndex
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtPageIndex = Value
                Catch ex As Exception
                    m_strtxtPageIndex = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtPageSize����
        '----------------------------------------------------------------
        Public Property txtPageSize() As String
            Get
                txtPageSize = m_strtxtPageSize
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtPageSize = Value
                Catch ex As Exception
                    m_strtxtPageSize = ""
                End Try
            End Set
        End Property










        '----------------------------------------------------------------
        ' grdContentPageSize����
        '----------------------------------------------------------------
        Public Property grdContentPageSize() As Integer
            Get
                grdContentPageSize = m_intPageSize_grdContent
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdContent = Value
                Catch ex As Exception
                    m_intPageSize_grdContent = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdContentCurrentPageIndex����
        '----------------------------------------------------------------
        Public Property grdContentCurrentPageIndex() As Integer
            Get
                grdContentCurrentPageIndex = m_intCurrentPageIndex_grdContent
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdContent = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdContent = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdContentSelectedIndex����
        '----------------------------------------------------------------
        Public Property grdContentSelectedIndex() As Integer
            Get
                grdContentSelectedIndex = m_intSelectedIndex_grdContent
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdContent = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdContent = 0
                End Try
            End Set
        End Property











        '----------------------------------------------------------------
        ' txtKSND����
        '----------------------------------------------------------------
        Public Property txtKSND() As String
            Get
                txtKSND = m_strtxtKSND
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtKSND = Value
                Catch ex As Exception
                    m_strtxtKSND = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtZZND����
        '----------------------------------------------------------------
        Public Property txtZZND() As String
            Get
                txtZZND = m_strtxtZZND
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtZZND = Value
                Catch ex As Exception
                    m_strtxtZZND = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtYJZR����
        '----------------------------------------------------------------
        Public Property txtYJZR() As String
            Get
                txtYJZR = m_strtxtYJZR
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtYJZR = Value
                Catch ex As Exception
                    m_strtxtYJZR = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' ddlType_SelectedIndex����
        '----------------------------------------------------------------
        Public Property ddlType_SelectedIndex() As Integer
            Get
                ddlType_SelectedIndex = m_intSelectedIndex_ddlType
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlType = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlType = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' ddlTJZB_SelectedIndex����
        '----------------------------------------------------------------
        Public Property ddlTJZB_SelectedIndex() As Integer
            Get
                ddlTJZB_SelectedIndex = m_intSelectedIndex_ddlTJZB
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlTJZB = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlTJZB = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' ddlYWLX_SelectedIndex����
        '----------------------------------------------------------------
        Public Property ddlYWLX_SelectedIndex() As Integer
            Get
                ddlYWLX_SelectedIndex = m_intSelectedIndex_ddlYWLX
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlYWLX = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlYWLX = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' ddlZZDM_SelectedIndex����
        '----------------------------------------------------------------
        Public Property ddlZZDM_SelectedIndex() As Integer
            Get
                ddlZZDM_SelectedIndex = m_intSelectedIndex_ddlZZDM
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlZZDM = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlZZDM = 0
                End Try
            End Set
        End Property

    End Class

End Namespace
