Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.BusinessFacade
    ' ����    ��IMEstateRsXzTeam
    '
    ' ���������� 
    '     estate_rs_xz_team.aspxģ�鱾��ָ��ֳ���Ҫ����Ϣ
    '----------------------------------------------------------------
    <Serializable()> Public Class IMEstateRsXzTeam
        Implements IDisposable

        Private m_strhtxtDivLeftBody As String                      'htxtDivLeftBody
        Private m_strhtxtDivTopBody As String                       'htxtDivTopBody

        Private m_strhtxtDivLeftTDXX As String                      'htxtDivLeftTDXX
        Private m_strhtxtDivTopTDXX As String                       'htxtDivTopTDXX
        Private m_strhtxtTDXXQuery As String                        'htxtTDXXQuery
        Private m_strhtxtTDXXRows As String                         'htxtTDXXRows
        Private m_strhtxtTDXXSort As String                         'htxtTDXXSort
        Private m_strhtxtTDXXSortColumnIndex As String              'htxtTDXXSortColumnIndex
        Private m_strhtxtTDXXSortType As String                     'htxtTDXXSortType

        Private m_strhtxtSessionIdQuery As String                   'htxtSessionIdQuery

        Private m_strtxtTDXXPageIndex As String                     'txtTDXXPageIndex
        Private m_strtxtTDXXPageSize As String                      'txtTDXXPageSize

        Private m_strtxtTDXXSearch_SSDW As String                   'txtTDXXSearch_SSDW
        Private m_strtxtTDXXSearch_DWMC As String                   'txtTDXXSearch_DWMC
        Private m_strtxtTDXXSearch_TDBH As String                   'txtTDXXSearch_TDBH

        '----------------------------------------------------------------
        'asp:datagrid - grdTDXX
        '----------------------------------------------------------------
        Private m_intPageSize_grdTDXX As Integer
        Private m_intSelectedIndex_grdTDXX As Integer
        Private m_intCurrentPageIndex_grdTDXX As Integer











        '----------------------------------------------------------------
        ' ���캯��
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()

            m_strhtxtDivLeftBody = ""
            m_strhtxtDivTopBody = ""

            m_strhtxtDivLeftTDXX = ""
            m_strhtxtDivTopTDXX = ""
            m_strhtxtTDXXQuery = ""
            m_strhtxtTDXXRows = ""
            m_strhtxtTDXXSort = ""
            m_strhtxtTDXXSortColumnIndex = ""
            m_strhtxtTDXXSortType = ""

            m_strhtxtSessionIdQuery = ""

            m_strtxtTDXXPageIndex = ""
            m_strtxtTDXXPageSize = ""

            m_strtxtTDXXSearch_SSDW = ""
            m_strtxtTDXXSearch_DWMC = ""
            m_strtxtTDXXSearch_TDBH = ""

            m_intPageSize_grdTDXX = 0
            m_intCurrentPageIndex_grdTDXX = 0
            m_intSelectedIndex_grdTDXX = -1

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
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IMEstateRsXzTeam)
            Try
                If Not (obj Is Nothing) Then
                    obj.Dispose()
                End If
            Catch ex As Exception
            End Try
            obj = Nothing
        End Sub












        '----------------------------------------------------------------
        ' htxtTDXXQuery����
        '----------------------------------------------------------------
        Public Property htxtTDXXQuery() As String
            Get
                htxtTDXXQuery = m_strhtxtTDXXQuery
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtTDXXQuery = Value
                Catch ex As Exception
                    m_strhtxtTDXXQuery = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtTDXXRows����
        '----------------------------------------------------------------
        Public Property htxtTDXXRows() As String
            Get
                htxtTDXXRows = m_strhtxtTDXXRows
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtTDXXRows = Value
                Catch ex As Exception
                    m_strhtxtTDXXRows = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtTDXXSort����
        '----------------------------------------------------------------
        Public Property htxtTDXXSort() As String
            Get
                htxtTDXXSort = m_strhtxtTDXXSort
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtTDXXSort = Value
                Catch ex As Exception
                    m_strhtxtTDXXSort = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtTDXXSortColumnIndex����
        '----------------------------------------------------------------
        Public Property htxtTDXXSortColumnIndex() As String
            Get
                htxtTDXXSortColumnIndex = m_strhtxtTDXXSortColumnIndex
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtTDXXSortColumnIndex = Value
                Catch ex As Exception
                    m_strhtxtTDXXSortColumnIndex = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtTDXXSortType����
        '----------------------------------------------------------------
        Public Property htxtTDXXSortType() As String
            Get
                htxtTDXXSortType = m_strhtxtTDXXSortType
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtTDXXSortType = Value
                Catch ex As Exception
                    m_strhtxtTDXXSortType = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivLeftTDXX����
        '----------------------------------------------------------------
        Public Property htxtDivLeftTDXX() As String
            Get
                htxtDivLeftTDXX = m_strhtxtDivLeftTDXX
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivLeftTDXX = Value
                Catch ex As Exception
                    m_strhtxtDivLeftTDXX = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopTDXX����
        '----------------------------------------------------------------
        Public Property htxtDivTopTDXX() As String
            Get
                htxtDivTopTDXX = m_strhtxtDivTopTDXX
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivTopTDXX = Value
                Catch ex As Exception
                    m_strhtxtDivTopTDXX = ""
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
        ' txtTDXXPageIndex����
        '----------------------------------------------------------------
        Public Property txtTDXXPageIndex() As String
            Get
                txtTDXXPageIndex = m_strtxtTDXXPageIndex
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtTDXXPageIndex = Value
                Catch ex As Exception
                    m_strtxtTDXXPageIndex = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtTDXXPageSize����
        '----------------------------------------------------------------
        Public Property txtTDXXPageSize() As String
            Get
                txtTDXXPageSize = m_strtxtTDXXPageSize
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtTDXXPageSize = Value
                Catch ex As Exception
                    m_strtxtTDXXPageSize = ""
                End Try
            End Set
        End Property











        '----------------------------------------------------------------
        ' txtTDXXSearch_SSDW����
        '----------------------------------------------------------------
        Public Property txtTDXXSearch_SSDW() As String
            Get
                txtTDXXSearch_SSDW = m_strtxtTDXXSearch_SSDW
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtTDXXSearch_SSDW = Value
                Catch ex As Exception
                    m_strtxtTDXXSearch_SSDW = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtTDXXSearch_DWMC����
        '----------------------------------------------------------------
        Public Property txtTDXXSearch_DWMC() As String
            Get
                txtTDXXSearch_DWMC = m_strtxtTDXXSearch_DWMC
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtTDXXSearch_DWMC = Value
                Catch ex As Exception
                    m_strtxtTDXXSearch_DWMC = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtTDXXSearch_TDBH����
        '----------------------------------------------------------------
        Public Property txtTDXXSearch_TDBH() As String
            Get
                txtTDXXSearch_TDBH = m_strtxtTDXXSearch_TDBH
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtTDXXSearch_TDBH = Value
                Catch ex As Exception
                    m_strtxtTDXXSearch_TDBH = ""
                End Try
            End Set
        End Property













        '----------------------------------------------------------------
        ' grdTDXXPageSize����
        '----------------------------------------------------------------
        Public Property grdTDXXPageSize() As Integer
            Get
                grdTDXXPageSize = m_intPageSize_grdTDXX
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdTDXX = Value
                Catch ex As Exception
                    m_intPageSize_grdTDXX = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdTDXXCurrentPageIndex����
        '----------------------------------------------------------------
        Public Property grdTDXXCurrentPageIndex() As Integer
            Get
                grdTDXXCurrentPageIndex = m_intCurrentPageIndex_grdTDXX
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdTDXX = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdTDXX = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdTDXXSelectedIndex����
        '----------------------------------------------------------------
        Public Property grdTDXXSelectedIndex() As Integer
            Get
                grdTDXXSelectedIndex = m_intSelectedIndex_grdTDXX
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdTDXX = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdTDXX = -1
                End Try
            End Set
        End Property

    End Class

End Namespace
