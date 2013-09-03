Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.BusinessFacade
    ' ����    ��IMEstateRsBbKhJy
    '
    ' ���������� 
    '     estate_rs_bb_kh_jy.aspxģ�鱾��ָ��ֳ���Ҫ����Ϣ
    '----------------------------------------------------------------
    <Serializable()> Public Class IMEstateRsBbKhJy
        Implements IDisposable

        '----------------------------------------------------------------
        'hidden textbox
        '----------------------------------------------------------------
        Private m_strhtxtTJSJSessionId As String                  'htxtTJSJSessionId
        Private m_strhtxtTJSJQuery As String                      'htxtTJSJQuery
        Private m_strhtxtTJSJRows As String                       'htxtTJSJRows
        Private m_strhtxtTJSJSort As String                       'htxtTJSJSort
        Private m_strhtxtTJSJSortColumnIndex As String            'htxtTJSJSortColumnIndex
        Private m_strhtxtTJSJSortType As String                   'htxtTJSJSortType
        Private m_strhtxtDivLeftTJSJ As String                    'htxtDivLeftTJSJ
        Private m_strhtxtDivTopTJSJ As String                     'htxtDivTopTJSJ

        Private m_strhtxtDivLeftBody As String                    'htxtDivLeftBody
        Private m_strhtxtDivTopBody As String                     'htxtDivTopBody

        '----------------------------------------------------------------
        'asp:textbox
        '----------------------------------------------------------------
        Private m_strtxtTJSJPageIndex As String                    'txtTJSJPageIndex
        Private m_strtxtTJSJPageSize As String                     'txtTJSJPageSize

        Private m_intSelectedIndex_ddlTJSJSearch_XSJB As Integer   'ddlTJSJSearch_XSJB

        Private m_intSelectedIndex_ddlTJJD As Integer              'ddlTJJD
        Private m_strtxtTJND As String                             'txtTJND
        Private m_strtxtYJZR As String                             'txtYJZR
        Private m_strtxtJDKS As String                             'txtJDKS
        Private m_strtxtJDJS As String                             'txtJDJS

        '----------------------------------------------------------------
        'asp:datagrid - grdTJSJ
        '----------------------------------------------------------------
        Private m_intPageSize_grdTJSJ As Integer
        Private m_intSelectedIndex_grdTJSJ As Integer
        Private m_intCurrentPageIndex_grdTJSJ As Integer











        '----------------------------------------------------------------
        ' ���캯��
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()

            'hidden
            m_strhtxtTJSJSessionId = ""
            m_strhtxtTJSJQuery = ""
            m_strhtxtTJSJRows = ""
            m_strhtxtTJSJSort = ""
            m_strhtxtTJSJSortColumnIndex = ""
            m_strhtxtTJSJSortType = ""
            m_strhtxtDivLeftTJSJ = ""
            m_strhtxtDivTopTJSJ = ""

            m_strhtxtDivLeftBody = ""
            m_strhtxtDivTopBody = ""

            'textbox
            m_strtxtTJSJPageIndex = ""
            m_strtxtTJSJPageSize = ""

            m_intSelectedIndex_ddlTJSJSearch_XSJB = -1

            m_intSelectedIndex_ddlTJJD = -1
            m_strtxtTJND = ""
            m_strtxtYJZR = ""
            m_strtxtJDKS = ""
            m_strtxtJDJS = ""

            'datagrid
            m_intPageSize_grdTJSJ = 0
            m_intSelectedIndex_grdTJSJ = -1
            m_intCurrentPageIndex_grdTJSJ = 0
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
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IMEstateRsBbKhJy)
            Try
                If Not (obj Is Nothing) Then
                    obj.Dispose()
                End If
            Catch ex As Exception
            End Try
            obj = Nothing
        End Sub









        '----------------------------------------------------------------
        ' htxtTJSJSessionId����
        '----------------------------------------------------------------
        Public Property htxtTJSJSessionId() As String
            Get
                htxtTJSJSessionId = m_strhtxtTJSJSessionId
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtTJSJSessionId = Value
                Catch ex As Exception
                    m_strhtxtTJSJSessionId = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtTJSJQuery����
        '----------------------------------------------------------------
        Public Property htxtTJSJQuery() As String
            Get
                htxtTJSJQuery = m_strhtxtTJSJQuery
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtTJSJQuery = Value
                Catch ex As Exception
                    m_strhtxtTJSJQuery = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtTJSJRows����
        '----------------------------------------------------------------
        Public Property htxtTJSJRows() As String
            Get
                htxtTJSJRows = m_strhtxtTJSJRows
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtTJSJRows = Value
                Catch ex As Exception
                    m_strhtxtTJSJRows = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtTJSJSort����
        '----------------------------------------------------------------
        Public Property htxtTJSJSort() As String
            Get
                htxtTJSJSort = m_strhtxtTJSJSort
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtTJSJSort = Value
                Catch ex As Exception
                    m_strhtxtTJSJSort = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtTJSJSortColumnIndex����
        '----------------------------------------------------------------
        Public Property htxtTJSJSortColumnIndex() As String
            Get
                htxtTJSJSortColumnIndex = m_strhtxtTJSJSortColumnIndex
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtTJSJSortColumnIndex = Value
                Catch ex As Exception
                    m_strhtxtTJSJSortColumnIndex = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtTJSJSortType����
        '----------------------------------------------------------------
        Public Property htxtTJSJSortType() As String
            Get
                htxtTJSJSortType = m_strhtxtTJSJSortType
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtTJSJSortType = Value
                Catch ex As Exception
                    m_strhtxtTJSJSortType = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivLeftTJSJ����
        '----------------------------------------------------------------
        Public Property htxtDivLeftTJSJ() As String
            Get
                htxtDivLeftTJSJ = m_strhtxtDivLeftTJSJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivLeftTJSJ = Value
                Catch ex As Exception
                    m_strhtxtDivLeftTJSJ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopTJSJ����
        '----------------------------------------------------------------
        Public Property htxtDivTopTJSJ() As String
            Get
                htxtDivTopTJSJ = m_strhtxtDivTopTJSJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivTopTJSJ = Value
                Catch ex As Exception
                    m_strhtxtDivTopTJSJ = ""
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
        ' txtTJSJPageIndex����
        '----------------------------------------------------------------
        Public Property txtTJSJPageIndex() As String
            Get
                txtTJSJPageIndex = m_strtxtTJSJPageIndex
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtTJSJPageIndex = Value
                Catch ex As Exception
                    m_strtxtTJSJPageIndex = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtTJSJPageSize����
        '----------------------------------------------------------------
        Public Property txtTJSJPageSize() As String
            Get
                txtTJSJPageSize = m_strtxtTJSJPageSize
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtTJSJPageSize = Value
                Catch ex As Exception
                    m_strtxtTJSJPageSize = ""
                End Try
            End Set
        End Property








        '----------------------------------------------------------------
        ' ddlTJSJSearch_XSJB_SelectedIndex����
        '----------------------------------------------------------------
        Public Property ddlTJSJSearch_XSJB_SelectedIndex() As Integer
            Get
                ddlTJSJSearch_XSJB_SelectedIndex = m_intSelectedIndex_ddlTJSJSearch_XSJB
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlTJSJSearch_XSJB = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlTJSJSearch_XSJB = -1
                End Try
            End Set
        End Property









        '----------------------------------------------------------------
        ' txtTJND����
        '----------------------------------------------------------------
        Public Property txtTJND() As String
            Get
                txtTJND = m_strtxtTJND
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtTJND = Value
                Catch ex As Exception
                    m_strtxtTJND = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' ddlTJJD_SelectedIndex����
        '----------------------------------------------------------------
        Public Property ddlTJJD_SelectedIndex() As Integer
            Get
                ddlTJJD_SelectedIndex = m_intSelectedIndex_ddlTJJD
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlTJJD = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlTJJD = -1
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
        ' grdTJSJPageSize����
        '----------------------------------------------------------------
        Public Property grdTJSJPageSize() As Integer
            Get
                grdTJSJPageSize = m_intPageSize_grdTJSJ
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdTJSJ = Value
                Catch ex As Exception
                    m_intPageSize_grdTJSJ = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdTJSJCurrentPageIndex����
        '----------------------------------------------------------------
        Public Property grdTJSJCurrentPageIndex() As Integer
            Get
                grdTJSJCurrentPageIndex = m_intCurrentPageIndex_grdTJSJ
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdTJSJ = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdTJSJ = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdTJSJSelectedIndex����
        '----------------------------------------------------------------
        Public Property grdTJSJSelectedIndex() As Integer
            Get
                grdTJSJSelectedIndex = m_intSelectedIndex_grdTJSJ
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdTJSJ = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdTJSJ = 0
                End Try
            End Set
        End Property










        '----------------------------------------------------------------
        ' txtJDKS����
        '----------------------------------------------------------------
        Public Property txtJDKS() As String
            Get
                txtJDKS = m_strtxtJDKS
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJDKS = Value
                Catch ex As Exception
                    m_strtxtJDKS = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtJDJS����
        '----------------------------------------------------------------
        Public Property txtJDJS() As String
            Get
                txtJDJS = m_strtxtJDJS
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJDJS = Value
                Catch ex As Exception
                    m_strtxtJDJS = ""
                End Try
            End Set
        End Property

    End Class

End Namespace
