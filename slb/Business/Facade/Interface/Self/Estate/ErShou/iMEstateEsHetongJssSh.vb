Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.BusinessFacade
    ' ����    ��IMEstateEsHetongJssSh
    '
    ' ���������� 
    '     estate_es_hetong_sh.aspxģ�鱾��ָ��ֳ���Ҫ����Ϣ
    '----------------------------------------------------------------
    <Serializable()> Public Class IMEstateEsHetongJssSh
        Implements IDisposable

        Private m_strhtxtDivLeftBody As String                      'htxtDivLeftBody
        Private m_strhtxtDivTopBody As String                       'htxtDivTopBody
        Private m_strhtxtDivLeftHT As String                        'htxtDivLeftHT
        Private m_strhtxtDivTopHT As String                         'htxtDivTopHT
        Private m_strhtxtDivLeftSHQK As String                        'htxtDivLeftSHQK
        Private m_strhtxtDivTopSHQK As String                         'htxtDivTopSHQK

        Private m_strhtxtHTQuery As String                          'htxtHTQuery
        Private m_strhtxtHTRows As String                           'htxtHTRows
        Private m_strhtxtHTSort As String                           'htxtHTSort
        Private m_strhtxtHTSortColumnIndex As String                'htxtHTSortColumnIndex
        Private m_strhtxtHTSortType As String                       'htxtHTSortType

        Private m_strhtxtSessionIdQueryHT As String                 'htxtSessionIdQueryHT

        Private m_strtxtHTPageIndex As String                       'txtHTPageIndex
        Private m_strtxtHTPageSize As String                        'txtHTPageSize

        Private m_strtxtHTSearch_QRSH As String                     'txtHTSearch_QRSH
        Private m_strtxtHTSearch_JSSH As String                     'txtHTSearch_JSSH
        Private m_strtxtHTSearch_HTRQMin As String                  'txtHTSearch_HTRQMin
        Private m_strtxtHTSearch_HTRQMax As String                  'txtHTSearch_HTRQMax
        Private m_intSelectedIndex_ddlHTSearch_HTZT As Integer      'ddlHTSearch_HTZT_SelectedIndex

        Private m_intPageSize_grdHT As Integer
        Private m_intSelectedIndex_grdHT As Integer
        Private m_intCurrentPageIndex_grdHT As Integer

        Private m_intPageSize_grdSHQK As Integer
        Private m_intSelectedIndex_grdSHQK As Integer
        Private m_intCurrentPageIndex_grdSHQK As Integer











        '----------------------------------------------------------------
        ' ���캯��
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()

            m_strhtxtDivLeftSHQK = ""
            m_strhtxtDivTopSHQK = ""
            m_strhtxtDivLeftHT = ""
            m_strhtxtDivTopHT = ""
            m_strhtxtDivLeftBody = ""
            m_strhtxtDivTopBody = ""

            m_strhtxtHTQuery = ""
            m_strhtxtHTRows = ""
            m_strhtxtHTSort = ""
            m_strhtxtHTSortColumnIndex = ""
            m_strhtxtHTSortType = ""

            m_strhtxtSessionIdQueryHT = ""

            m_strtxtHTPageIndex = ""
            m_strtxtHTPageSize = ""

            m_strtxtHTSearch_JSSH = ""
            m_strtxtHTSearch_QRSH = ""
            m_strtxtHTSearch_HTRQMin = ""
            m_strtxtHTSearch_HTRQMax = ""
            m_intSelectedIndex_ddlHTSearch_HTZT = -1

            m_intPageSize_grdHT = 0
            m_intCurrentPageIndex_grdHT = 0
            m_intSelectedIndex_grdHT = -1

            m_intPageSize_grdSHQK = 0
            m_intCurrentPageIndex_grdSHQK = 0
            m_intSelectedIndex_grdSHQK = -1

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
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IMEstateEsHetongJssSh)
            Try
                If Not (obj Is Nothing) Then
                    obj.Dispose()
                End If
            Catch ex As Exception
            End Try
            obj = Nothing
        End Sub












        '----------------------------------------------------------------
        ' htxtHTQuery����
        '----------------------------------------------------------------
        Public Property htxtHTQuery() As String
            Get
                htxtHTQuery = m_strhtxtHTQuery
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtHTQuery = Value
                Catch ex As Exception
                    m_strhtxtHTQuery = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtHTRows����
        '----------------------------------------------------------------
        Public Property htxtHTRows() As String
            Get
                htxtHTRows = m_strhtxtHTRows
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtHTRows = Value
                Catch ex As Exception
                    m_strhtxtHTRows = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtHTSort����
        '----------------------------------------------------------------
        Public Property htxtHTSort() As String
            Get
                htxtHTSort = m_strhtxtHTSort
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtHTSort = Value
                Catch ex As Exception
                    m_strhtxtHTSort = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtHTSortColumnIndex����
        '----------------------------------------------------------------
        Public Property htxtHTSortColumnIndex() As String
            Get
                htxtHTSortColumnIndex = m_strhtxtHTSortColumnIndex
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtHTSortColumnIndex = Value
                Catch ex As Exception
                    m_strhtxtHTSortColumnIndex = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtHTSortType����
        '----------------------------------------------------------------
        Public Property htxtHTSortType() As String
            Get
                htxtHTSortType = m_strhtxtHTSortType
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtHTSortType = Value
                Catch ex As Exception
                    m_strhtxtHTSortType = ""
                End Try
            End Set
        End Property












        '----------------------------------------------------------------
        ' htxtDivLeftSHQK����
        '----------------------------------------------------------------
        Public Property htxtDivLeftSHQK() As String
            Get
                htxtDivLeftSHQK = m_strhtxtDivLeftSHQK
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivLeftSHQK = Value
                Catch ex As Exception
                    m_strhtxtDivLeftSHQK = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopSHQK����
        '----------------------------------------------------------------
        Public Property htxtDivTopSHQK() As String
            Get
                htxtDivTopSHQK = m_strhtxtDivTopSHQK
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivTopSHQK = Value
                Catch ex As Exception
                    m_strhtxtDivTopSHQK = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivLeftHT����
        '----------------------------------------------------------------
        Public Property htxtDivLeftHT() As String
            Get
                htxtDivLeftHT = m_strhtxtDivLeftHT
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivLeftHT = Value
                Catch ex As Exception
                    m_strhtxtDivLeftHT = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopHT����
        '----------------------------------------------------------------
        Public Property htxtDivTopHT() As String
            Get
                htxtDivTopHT = m_strhtxtDivTopHT
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivTopHT = Value
                Catch ex As Exception
                    m_strhtxtDivTopHT = ""
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
        ' htxtSessionIdQueryHT����
        '----------------------------------------------------------------
        Public Property htxtSessionIdQueryHT() As String
            Get
                htxtSessionIdQueryHT = m_strhtxtSessionIdQueryHT
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSessionIdQueryHT = Value
                Catch ex As Exception
                    m_strhtxtSessionIdQueryHT = ""
                End Try
            End Set
        End Property













        '----------------------------------------------------------------
        ' txtHTPageIndex����
        '----------------------------------------------------------------
        Public Property txtHTPageIndex() As String
            Get
                txtHTPageIndex = m_strtxtHTPageIndex
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtHTPageIndex = Value
                Catch ex As Exception
                    m_strtxtHTPageIndex = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtHTPageSize����
        '----------------------------------------------------------------
        Public Property txtHTPageSize() As String
            Get
                txtHTPageSize = m_strtxtHTPageSize
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtHTPageSize = Value
                Catch ex As Exception
                    m_strtxtHTPageSize = ""
                End Try
            End Set
        End Property











        '----------------------------------------------------------------
        ' txtHTSearch_JSSH����
        '----------------------------------------------------------------
        Public Property txtHTSearch_JSSH() As String
            Get
                txtHTSearch_JSSH = m_strtxtHTSearch_JSSH
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtHTSearch_JSSH = Value
                Catch ex As Exception
                    m_strtxtHTSearch_JSSH = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtHTSearch_QRSH����
        '----------------------------------------------------------------
        Public Property txtHTSearch_QRSH() As String
            Get
                txtHTSearch_QRSH = m_strtxtHTSearch_QRSH
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtHTSearch_QRSH = Value
                Catch ex As Exception
                    m_strtxtHTSearch_QRSH = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtHTSearch_HTRQMin����
        '----------------------------------------------------------------
        Public Property txtHTSearch_HTRQMin() As String
            Get
                txtHTSearch_HTRQMin = m_strtxtHTSearch_HTRQMin
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtHTSearch_HTRQMin = Value
                Catch ex As Exception
                    m_strtxtHTSearch_HTRQMin = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtHTSearch_HTRQMax����
        '----------------------------------------------------------------
        Public Property txtHTSearch_HTRQMax() As String
            Get
                txtHTSearch_HTRQMax = m_strtxtHTSearch_HTRQMax
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtHTSearch_HTRQMax = Value
                Catch ex As Exception
                    m_strtxtHTSearch_HTRQMax = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' ddlHTSearch_HTZT_SelectedIndex����
        '----------------------------------------------------------------
        Public Property ddlHTSearch_HTZT_SelectedIndex() As Integer
            Get
                ddlHTSearch_HTZT_SelectedIndex = m_intSelectedIndex_ddlHTSearch_HTZT
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlHTSearch_HTZT = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlHTSearch_HTZT = -1
                End Try
            End Set
        End Property














        '----------------------------------------------------------------
        ' grdHTPageSize����
        '----------------------------------------------------------------
        Public Property grdHTPageSize() As Integer
            Get
                grdHTPageSize = m_intPageSize_grdHT
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdHT = Value
                Catch ex As Exception
                    m_intPageSize_grdHT = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdHTCurrentPageIndex����
        '----------------------------------------------------------------
        Public Property grdHTCurrentPageIndex() As Integer
            Get
                grdHTCurrentPageIndex = m_intCurrentPageIndex_grdHT
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdHT = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdHT = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdHTSelectedIndex����
        '----------------------------------------------------------------
        Public Property grdHTSelectedIndex() As Integer
            Get
                grdHTSelectedIndex = m_intSelectedIndex_grdHT
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdHT = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdHT = -1
                End Try
            End Set
        End Property













        '----------------------------------------------------------------
        ' grdSHQKPageSize����
        '----------------------------------------------------------------
        Public Property grdSHQKPageSize() As Integer
            Get
                grdSHQKPageSize = m_intPageSize_grdSHQK
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdSHQK = Value
                Catch ex As Exception
                    m_intPageSize_grdSHQK = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdSHQKCurrentPageIndex����
        '----------------------------------------------------------------
        Public Property grdSHQKCurrentPageIndex() As Integer
            Get
                grdSHQKCurrentPageIndex = m_intCurrentPageIndex_grdSHQK
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdSHQK = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdSHQK = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdSHQKSelectedIndex����
        '----------------------------------------------------------------
        Public Property grdSHQKSelectedIndex() As Integer
            Get
                grdSHQKSelectedIndex = m_intSelectedIndex_grdSHQK
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdSHQK = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdSHQK = -1
                End Try
            End Set
        End Property

    End Class

End Namespace
