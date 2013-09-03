Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.BusinessFacade
    ' ����    ��IMEstateCwXzPiaoju
    '
    ' ���������� 
    '     estate_cw_xz_piaoju.aspxģ�鱾��ָ��ֳ���Ҫ����Ϣ
    '----------------------------------------------------------------
    <Serializable()> Public Class IMEstateCwXzPiaoju
        Implements IDisposable

        Private m_strhtxtDivLeftPIAOJU As String                    'htxtDivLeftPIAOJU
        Private m_strhtxtDivTopPIAOJU As String                     'htxtDivTopPIAOJU
        Private m_strhtxtDivLeftBody As String                      'htxtDivLeftBody
        Private m_strhtxtDivTopBody As String                       'htxtDivTopBody

        Private m_strhtxtPIAOJUQuery As String                      'htxtPIAOJUQuery
        Private m_strhtxtPIAOJURows As String                       'htxtPIAOJURows
        Private m_strhtxtPIAOJUSort As String                       'htxtPIAOJUSort
        Private m_strhtxtPIAOJUSortColumnIndex As String            'htxtPIAOJUSortColumnIndex
        Private m_strhtxtPIAOJUSortType As String                   'htxtPIAOJUSortType

        Private m_strhtxtSessionIdQuery As String                   'htxtSessionIdQuery

        Private m_strtxtPIAOJUPageIndex As String                  'txtPIAOJUPageIndex
        Private m_strtxtPIAOJUPageSize As String                   'txtPIAOJUPageSize

        Private m_strtxtPIAOJUSearch_JBRY As String                'txtPIAOJUSearch_JBRY
        Private m_strtxtPIAOJUSearch_YWBH As String                'txtPIAOJUSearch_YWBH
        Private m_strtxtPIAOJUSearch_PJHM As String                'txtPIAOJUSearch_PJHM
        Private m_strtxtPIAOJUSearch_KPRQMin As String             'txtPIAOJUSearch_KPRQMin
        Private m_strtxtPIAOJUSearch_KPRQMax As String             'txtPIAOJUSearch_KPRQMax
        Private m_intSelectedIndex_ddlPIAOJUSearch_ZTBZ As Integer 'ddlPIAOJUSearch_ZTBZ_SelectedIndex
        'zengxianglin 2008-11-22
        Private m_intSelectedIndex_ddlPIAOJUSearch_YKPZ As Integer 'ddlPIAOJUSearch_YKPZ_SelectedIndex
        'zengxianglin 2008-11-22

        '----------------------------------------------------------------
        'asp:datagrid - grdPIAOJU
        '----------------------------------------------------------------
        Private m_intPageSize_grdPIAOJU As Integer
        Private m_intSelectedIndex_grdPIAOJU As Integer
        Private m_intCurrentPageIndex_grdPIAOJU As Integer











        '----------------------------------------------------------------
        ' ���캯��
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()

            m_strhtxtDivLeftPIAOJU = ""
            m_strhtxtDivTopPIAOJU = ""
            m_strhtxtDivLeftBody = ""
            m_strhtxtDivTopBody = ""

            m_strhtxtPIAOJUQuery = ""
            m_strhtxtPIAOJURows = ""
            m_strhtxtPIAOJUSort = ""
            m_strhtxtPIAOJUSortColumnIndex = ""
            m_strhtxtPIAOJUSortType = ""

            m_strhtxtSessionIdQuery = ""

            m_strtxtPIAOJUPageIndex = ""
            m_strtxtPIAOJUPageSize = ""

            m_strtxtPIAOJUSearch_JBRY = ""
            m_strtxtPIAOJUSearch_YWBH = ""
            m_strtxtPIAOJUSearch_PJHM = ""
            m_strtxtPIAOJUSearch_KPRQMin = ""
            m_strtxtPIAOJUSearch_KPRQMax = ""
            m_intSelectedIndex_ddlPIAOJUSearch_ZTBZ = -1
            'zengxianglin 2008-11-22
            m_intSelectedIndex_ddlPIAOJUSearch_YKPZ = -1
            'zengxianglin 2008-11-22

            m_intPageSize_grdPIAOJU = 0
            m_intCurrentPageIndex_grdPIAOJU = 0
            m_intSelectedIndex_grdPIAOJU = -1

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
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IMEstateCwXzPiaoju)
            Try
                If Not (obj Is Nothing) Then
                    obj.Dispose()
                End If
            Catch ex As Exception
            End Try
            obj = Nothing
        End Sub












        '----------------------------------------------------------------
        ' htxtPIAOJUQuery����
        '----------------------------------------------------------------
        Public Property htxtPIAOJUQuery() As String
            Get
                htxtPIAOJUQuery = m_strhtxtPIAOJUQuery
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtPIAOJUQuery = Value
                Catch ex As Exception
                    m_strhtxtPIAOJUQuery = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtPIAOJURows����
        '----------------------------------------------------------------
        Public Property htxtPIAOJURows() As String
            Get
                htxtPIAOJURows = m_strhtxtPIAOJURows
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtPIAOJURows = Value
                Catch ex As Exception
                    m_strhtxtPIAOJURows = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtPIAOJUSort����
        '----------------------------------------------------------------
        Public Property htxtPIAOJUSort() As String
            Get
                htxtPIAOJUSort = m_strhtxtPIAOJUSort
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtPIAOJUSort = Value
                Catch ex As Exception
                    m_strhtxtPIAOJUSort = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtPIAOJUSortColumnIndex����
        '----------------------------------------------------------------
        Public Property htxtPIAOJUSortColumnIndex() As String
            Get
                htxtPIAOJUSortColumnIndex = m_strhtxtPIAOJUSortColumnIndex
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtPIAOJUSortColumnIndex = Value
                Catch ex As Exception
                    m_strhtxtPIAOJUSortColumnIndex = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtPIAOJUSortType����
        '----------------------------------------------------------------
        Public Property htxtPIAOJUSortType() As String
            Get
                htxtPIAOJUSortType = m_strhtxtPIAOJUSortType
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtPIAOJUSortType = Value
                Catch ex As Exception
                    m_strhtxtPIAOJUSortType = ""
                End Try
            End Set
        End Property












        '----------------------------------------------------------------
        ' htxtDivLeftPIAOJU����
        '----------------------------------------------------------------
        Public Property htxtDivLeftPIAOJU() As String
            Get
                htxtDivLeftPIAOJU = m_strhtxtDivLeftPIAOJU
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivLeftPIAOJU = Value
                Catch ex As Exception
                    m_strhtxtDivLeftPIAOJU = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopPIAOJU����
        '----------------------------------------------------------------
        Public Property htxtDivTopPIAOJU() As String
            Get
                htxtDivTopPIAOJU = m_strhtxtDivTopPIAOJU
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivTopPIAOJU = Value
                Catch ex As Exception
                    m_strhtxtDivTopPIAOJU = ""
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
        ' txtPIAOJUPageIndex����
        '----------------------------------------------------------------
        Public Property txtPIAOJUPageIndex() As String
            Get
                txtPIAOJUPageIndex = m_strtxtPIAOJUPageIndex
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtPIAOJUPageIndex = Value
                Catch ex As Exception
                    m_strtxtPIAOJUPageIndex = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtPIAOJUPageSize����
        '----------------------------------------------------------------
        Public Property txtPIAOJUPageSize() As String
            Get
                txtPIAOJUPageSize = m_strtxtPIAOJUPageSize
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtPIAOJUPageSize = Value
                Catch ex As Exception
                    m_strtxtPIAOJUPageSize = ""
                End Try
            End Set
        End Property











        '----------------------------------------------------------------
        ' txtPIAOJUSearch_JBRY����
        '----------------------------------------------------------------
        Public Property txtPIAOJUSearch_JBRY() As String
            Get
                txtPIAOJUSearch_JBRY = m_strtxtPIAOJUSearch_JBRY
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtPIAOJUSearch_JBRY = Value
                Catch ex As Exception
                    m_strtxtPIAOJUSearch_JBRY = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtPIAOJUSearch_YWBH����
        '----------------------------------------------------------------
        Public Property txtPIAOJUSearch_YWBH() As String
            Get
                txtPIAOJUSearch_YWBH = m_strtxtPIAOJUSearch_YWBH
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtPIAOJUSearch_YWBH = Value
                Catch ex As Exception
                    m_strtxtPIAOJUSearch_YWBH = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtPIAOJUSearch_PJHM����
        '----------------------------------------------------------------
        Public Property txtPIAOJUSearch_PJHM() As String
            Get
                txtPIAOJUSearch_PJHM = m_strtxtPIAOJUSearch_PJHM
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtPIAOJUSearch_PJHM = Value
                Catch ex As Exception
                    m_strtxtPIAOJUSearch_PJHM = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtPIAOJUSearch_KPRQMin����
        '----------------------------------------------------------------
        Public Property txtPIAOJUSearch_KPRQMin() As String
            Get
                txtPIAOJUSearch_KPRQMin = m_strtxtPIAOJUSearch_KPRQMin
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtPIAOJUSearch_KPRQMin = Value
                Catch ex As Exception
                    m_strtxtPIAOJUSearch_KPRQMin = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtPIAOJUSearch_KPRQMax����
        '----------------------------------------------------------------
        Public Property txtPIAOJUSearch_KPRQMax() As String
            Get
                txtPIAOJUSearch_KPRQMax = m_strtxtPIAOJUSearch_KPRQMax
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtPIAOJUSearch_KPRQMax = Value
                Catch ex As Exception
                    m_strtxtPIAOJUSearch_KPRQMax = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' ddlPIAOJUSearch_ZTBZ_SelectedIndex����
        '----------------------------------------------------------------
        Public Property ddlPIAOJUSearch_ZTBZ_SelectedIndex() As Integer
            Get
                ddlPIAOJUSearch_ZTBZ_SelectedIndex = m_intSelectedIndex_ddlPIAOJUSearch_ZTBZ
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlPIAOJUSearch_ZTBZ = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlPIAOJUSearch_ZTBZ = -1
                End Try
            End Set
        End Property

        'zengxianglin 2008-11-22
        '----------------------------------------------------------------
        ' ddlPIAOJUSearch_YKPZ_SelectedIndex����
        '----------------------------------------------------------------
        Public Property ddlPIAOJUSearch_YKPZ_SelectedIndex() As Integer
            Get
                ddlPIAOJUSearch_YKPZ_SelectedIndex = m_intSelectedIndex_ddlPIAOJUSearch_YKPZ
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlPIAOJUSearch_YKPZ = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlPIAOJUSearch_YKPZ = -1
                End Try
            End Set
        End Property
        'zengxianglin 2008-11-22














        '----------------------------------------------------------------
        ' grdPIAOJUPageSize����
        '----------------------------------------------------------------
        Public Property grdPIAOJUPageSize() As Integer
            Get
                grdPIAOJUPageSize = m_intPageSize_grdPIAOJU
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdPIAOJU = Value
                Catch ex As Exception
                    m_intPageSize_grdPIAOJU = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdPIAOJUCurrentPageIndex����
        '----------------------------------------------------------------
        Public Property grdPIAOJUCurrentPageIndex() As Integer
            Get
                grdPIAOJUCurrentPageIndex = m_intCurrentPageIndex_grdPIAOJU
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdPIAOJU = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdPIAOJU = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdPIAOJUSelectedIndex����
        '----------------------------------------------------------------
        Public Property grdPIAOJUSelectedIndex() As Integer
            Get
                grdPIAOJUSelectedIndex = m_intSelectedIndex_grdPIAOJU
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdPIAOJU = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdPIAOJU = -1
                End Try
            End Set
        End Property

    End Class

End Namespace
