Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.BusinessFacade
    ' ����    ��IMEstateRsKaoheBiaozhun
    '
    ' ���������� 
    '     estate_rs_kaohebiaozhun.aspxģ�鱾��ָ��ֳ���Ҫ����Ϣ
    '----------------------------------------------------------------
    <Serializable()> Public Class IMEstateRsKaoheBiaozhun
        Implements IDisposable

        '----------------------------------------------------------------
        ' ģ������
        '----------------------------------------------------------------
        Private m_strhtxtDivLeftBody As String              'htxtDivLeftBody
        Private m_strhtxtDivTopBody As String               'htxtDivTopBody
        Private m_strhtxtDivLeftMain As String              'htxtDivLeftMain
        Private m_strhtxtDivTopMain As String               'htxtDivTopMain

        Private m_strhtxtSessionId_XL As String             'htxtSessionId_XL
        Private m_strhtxtSessionId_DWFH01 As String         'htxtSessionId_DWFH01
        Private m_strhtxtSessionId_DWFH02 As String         'htxtSessionId_DWFH02
        Private m_strhtxtSessionId_DWFH03 As String         'htxtSessionId_DWFH03
        Private m_strhtxtSessionId_DWGLC01 As String        'htxtSessionId_DWGLC01
        Private m_strhtxtSessionId_DWGLC02 As String        'htxtSessionId_DWGLC02
        Private m_strhtxtSessionId_DWGLC03 As String        'htxtSessionId_DWGLC03

        Private m_intCurrentPageIndex_grdXL As Integer      'grdXL_CurrentPageIndex
        Private m_intSelectedIndex_grdXL As Integer         'grdXL_SelectedIndex
        Private m_intPageSize_grdXL As Integer              'grdXL_PageSize

        Private m_intCurrentPageIndex_grdDWFH01 As Integer  'grdDWFH01_CurrentPageIndex
        Private m_intSelectedIndex_grdDWFH01 As Integer     'grdDWFH01_SelectedIndex
        Private m_intPageSize_grdDWFH01 As Integer          'grdDWFH01_PageSize

        Private m_intCurrentPageIndex_grdDWFH02 As Integer  'grdDWFH02_CurrentPageIndex
        Private m_intSelectedIndex_grdDWFH02 As Integer     'grdDWFH02_SelectedIndex
        Private m_intPageSize_grdDWFH02 As Integer          'grdDWFH02_PageSize

        Private m_intCurrentPageIndex_grdDWFH03 As Integer  'grdDWFH03_CurrentPageIndex
        Private m_intSelectedIndex_grdDWFH03 As Integer     'grdDWFH03_SelectedIndex
        Private m_intPageSize_grdDWFH03 As Integer          'grdDWFH03_PageSize

        Private m_intCurrentPageIndex_grdDWGLC01 As Integer 'grdDWGLC01_CurrentPageIndex
        Private m_intSelectedIndex_grdDWGLC01 As Integer    'grdDWGLC01_SelectedIndex
        Private m_intPageSize_grdDWGLC01 As Integer         'grdDWGLC01_PageSize

        Private m_intCurrentPageIndex_grdDWGLC02 As Integer 'grdDWGLC02_CurrentPageIndex
        Private m_intSelectedIndex_grdDWGLC02 As Integer    'grdDWGLC02_SelectedIndex
        Private m_intPageSize_grdDWGLC02 As Integer         'grdDWGLC02_PageSize

        Private m_intCurrentPageIndex_grdDWGLC03 As Integer 'grdDWGLC03_CurrentPageIndex
        Private m_intSelectedIndex_grdDWGLC03 As Integer    'grdDWGLC03_SelectedIndex
        Private m_intPageSize_grdDWGLC03 As Integer         'grdDWGLC03_PageSize







        '----------------------------------------------------------------
        ' ���캯��
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()

            m_strhtxtDivLeftBody = ""
            m_strhtxtDivTopBody = ""
            m_strhtxtDivLeftMain = ""
            m_strhtxtDivTopMain = ""

            m_strhtxtSessionId_XL = ""
            m_strhtxtSessionId_DWFH01 = ""
            m_strhtxtSessionId_DWFH02 = ""
            m_strhtxtSessionId_DWFH03 = ""
            m_strhtxtSessionId_DWGLC01 = ""
            m_strhtxtSessionId_DWGLC02 = ""
            m_strhtxtSessionId_DWGLC03 = ""

            m_intCurrentPageIndex_grdXL = 0
            m_intSelectedIndex_grdXL = -1
            m_intPageSize_grdXL = 30

            m_intCurrentPageIndex_grdDWFH01 = 0
            m_intSelectedIndex_grdDWFH01 = -1
            m_intPageSize_grdDWFH01 = 30

            m_intCurrentPageIndex_grdDWFH02 = 0
            m_intSelectedIndex_grdDWFH02 = -1
            m_intPageSize_grdDWFH02 = 30

            m_intCurrentPageIndex_grdDWFH03 = 0
            m_intSelectedIndex_grdDWFH03 = -1
            m_intPageSize_grdDWFH03 = 30

            m_intCurrentPageIndex_grdDWGLC01 = 0
            m_intSelectedIndex_grdDWGLC01 = -1
            m_intPageSize_grdDWGLC01 = 30

            m_intCurrentPageIndex_grdDWGLC02 = 0
            m_intSelectedIndex_grdDWGLC02 = -1
            m_intPageSize_grdDWGLC02 = 30

            m_intCurrentPageIndex_grdDWGLC03 = 0
            m_intSelectedIndex_grdDWGLC03 = -1
            m_intPageSize_grdDWGLC03 = 30

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
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IMEstateRsKaoheBiaozhun)
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
        ' htxtSessionId_XL����
        '----------------------------------------------------------------
        Public Property htxtSessionId_XL() As String
            Get
                htxtSessionId_XL = m_strhtxtSessionId_XL
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSessionId_XL = Value
                Catch ex As Exception
                    m_strhtxtSessionId_XL = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtSessionId_DWFH01����
        '----------------------------------------------------------------
        Public Property htxtSessionId_DWFH01() As String
            Get
                htxtSessionId_DWFH01 = m_strhtxtSessionId_DWFH01
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSessionId_DWFH01 = Value
                Catch ex As Exception
                    m_strhtxtSessionId_DWFH01 = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtSessionId_DWFH02����
        '----------------------------------------------------------------
        Public Property htxtSessionId_DWFH02() As String
            Get
                htxtSessionId_DWFH02 = m_strhtxtSessionId_DWFH02
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSessionId_DWFH02 = Value
                Catch ex As Exception
                    m_strhtxtSessionId_DWFH02 = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtSessionId_DWFH03����
        '----------------------------------------------------------------
        Public Property htxtSessionId_DWFH03() As String
            Get
                htxtSessionId_DWFH03 = m_strhtxtSessionId_DWFH03
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSessionId_DWFH03 = Value
                Catch ex As Exception
                    m_strhtxtSessionId_DWFH03 = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtSessionId_DWGLC01����
        '----------------------------------------------------------------
        Public Property htxtSessionId_DWGLC01() As String
            Get
                htxtSessionId_DWGLC01 = m_strhtxtSessionId_DWGLC01
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSessionId_DWGLC01 = Value
                Catch ex As Exception
                    m_strhtxtSessionId_DWGLC01 = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtSessionId_DWGLC02����
        '----------------------------------------------------------------
        Public Property htxtSessionId_DWGLC02() As String
            Get
                htxtSessionId_DWGLC02 = m_strhtxtSessionId_DWGLC02
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSessionId_DWGLC02 = Value
                Catch ex As Exception
                    m_strhtxtSessionId_DWGLC02 = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtSessionId_DWGLC03����
        '----------------------------------------------------------------
        Public Property htxtSessionId_DWGLC03() As String
            Get
                htxtSessionId_DWGLC03 = m_strhtxtSessionId_DWGLC03
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSessionId_DWGLC03 = Value
                Catch ex As Exception
                    m_strhtxtSessionId_DWGLC03 = ""
                End Try
            End Set
        End Property










        '----------------------------------------------------------------
        ' grdXL_CurrentPageIndex����
        '----------------------------------------------------------------
        Public Property grdXL_CurrentPageIndex() As Integer
            Get
                grdXL_CurrentPageIndex = m_intCurrentPageIndex_grdXL
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdXL = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdXL = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdXL_SelectedIndex����
        '----------------------------------------------------------------
        Public Property grdXL_SelectedIndex() As Integer
            Get
                grdXL_SelectedIndex = m_intSelectedIndex_grdXL
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdXL = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdXL = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdXL_PageSize����
        '----------------------------------------------------------------
        Public Property grdXL_PageSize() As Integer
            Get
                grdXL_PageSize = m_intPageSize_grdXL
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdXL = Value
                Catch ex As Exception
                    m_intPageSize_grdXL = 0
                End Try
            End Set
        End Property













        '----------------------------------------------------------------
        ' grdDWFH01_CurrentPageIndex����
        '----------------------------------------------------------------
        Public Property grdDWFH01_CurrentPageIndex() As Integer
            Get
                grdDWFH01_CurrentPageIndex = m_intCurrentPageIndex_grdDWFH01
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdDWFH01 = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdDWFH01 = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdDWFH01_SelectedIndex����
        '----------------------------------------------------------------
        Public Property grdDWFH01_SelectedIndex() As Integer
            Get
                grdDWFH01_SelectedIndex = m_intSelectedIndex_grdDWFH01
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdDWFH01 = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdDWFH01 = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdDWFH01_PageSize����
        '----------------------------------------------------------------
        Public Property grdDWFH01_PageSize() As Integer
            Get
                grdDWFH01_PageSize = m_intPageSize_grdDWFH01
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdDWFH01 = Value
                Catch ex As Exception
                    m_intPageSize_grdDWFH01 = 0
                End Try
            End Set
        End Property









        '----------------------------------------------------------------
        ' grdDWFH02_CurrentPageIndex����
        '----------------------------------------------------------------
        Public Property grdDWFH02_CurrentPageIndex() As Integer
            Get
                grdDWFH02_CurrentPageIndex = m_intCurrentPageIndex_grdDWFH02
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdDWFH02 = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdDWFH02 = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdDWFH02_SelectedIndex����
        '----------------------------------------------------------------
        Public Property grdDWFH02_SelectedIndex() As Integer
            Get
                grdDWFH02_SelectedIndex = m_intSelectedIndex_grdDWFH02
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdDWFH02 = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdDWFH02 = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdDWFH02_PageSize����
        '----------------------------------------------------------------
        Public Property grdDWFH02_PageSize() As Integer
            Get
                grdDWFH02_PageSize = m_intPageSize_grdDWFH02
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdDWFH02 = Value
                Catch ex As Exception
                    m_intPageSize_grdDWFH02 = 0
                End Try
            End Set
        End Property







        '----------------------------------------------------------------
        ' grdDWFH03_CurrentPageIndex����
        '----------------------------------------------------------------
        Public Property grdDWFH03_CurrentPageIndex() As Integer
            Get
                grdDWFH03_CurrentPageIndex = m_intCurrentPageIndex_grdDWFH03
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdDWFH03 = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdDWFH03 = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdDWFH03_SelectedIndex����
        '----------------------------------------------------------------
        Public Property grdDWFH03_SelectedIndex() As Integer
            Get
                grdDWFH03_SelectedIndex = m_intSelectedIndex_grdDWFH03
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdDWFH03 = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdDWFH03 = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdDWFH03_PageSize����
        '----------------------------------------------------------------
        Public Property grdDWFH03_PageSize() As Integer
            Get
                grdDWFH03_PageSize = m_intPageSize_grdDWFH03
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdDWFH03 = Value
                Catch ex As Exception
                    m_intPageSize_grdDWFH03 = 0
                End Try
            End Set
        End Property









        '----------------------------------------------------------------
        ' grdDWGLC01_CurrentPageIndex����
        '----------------------------------------------------------------
        Public Property grdDWGLC01_CurrentPageIndex() As Integer
            Get
                grdDWGLC01_CurrentPageIndex = m_intCurrentPageIndex_grdDWGLC01
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdDWGLC01 = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdDWGLC01 = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdDWGLC01_SelectedIndex����
        '----------------------------------------------------------------
        Public Property grdDWGLC01_SelectedIndex() As Integer
            Get
                grdDWGLC01_SelectedIndex = m_intSelectedIndex_grdDWGLC01
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdDWGLC01 = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdDWGLC01 = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdDWGLC01_PageSize����
        '----------------------------------------------------------------
        Public Property grdDWGLC01_PageSize() As Integer
            Get
                grdDWGLC01_PageSize = m_intPageSize_grdDWGLC01
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdDWGLC01 = Value
                Catch ex As Exception
                    m_intPageSize_grdDWGLC01 = 0
                End Try
            End Set
        End Property









        '----------------------------------------------------------------
        ' grdDWGLC02_CurrentPageIndex����
        '----------------------------------------------------------------
        Public Property grdDWGLC02_CurrentPageIndex() As Integer
            Get
                grdDWGLC02_CurrentPageIndex = m_intCurrentPageIndex_grdDWGLC02
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdDWGLC02 = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdDWGLC02 = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdDWGLC02_SelectedIndex����
        '----------------------------------------------------------------
        Public Property grdDWGLC02_SelectedIndex() As Integer
            Get
                grdDWGLC02_SelectedIndex = m_intSelectedIndex_grdDWGLC02
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdDWGLC02 = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdDWGLC02 = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdDWGLC02_PageSize����
        '----------------------------------------------------------------
        Public Property grdDWGLC02_PageSize() As Integer
            Get
                grdDWGLC02_PageSize = m_intPageSize_grdDWGLC02
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdDWGLC02 = Value
                Catch ex As Exception
                    m_intPageSize_grdDWGLC02 = 0
                End Try
            End Set
        End Property







        '----------------------------------------------------------------
        ' grdDWGLC03_CurrentPageIndex����
        '----------------------------------------------------------------
        Public Property grdDWGLC03_CurrentPageIndex() As Integer
            Get
                grdDWGLC03_CurrentPageIndex = m_intCurrentPageIndex_grdDWGLC03
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdDWGLC03 = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdDWGLC03 = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdDWGLC03_SelectedIndex����
        '----------------------------------------------------------------
        Public Property grdDWGLC03_SelectedIndex() As Integer
            Get
                grdDWGLC03_SelectedIndex = m_intSelectedIndex_grdDWGLC03
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdDWGLC03 = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdDWGLC03 = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdDWGLC03_PageSize����
        '----------------------------------------------------------------
        Public Property grdDWGLC03_PageSize() As Integer
            Get
                grdDWGLC03_PageSize = m_intPageSize_grdDWGLC03
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdDWGLC03 = Value
                Catch ex As Exception
                    m_intPageSize_grdDWGLC03 = 0
                End Try
            End Set
        End Property

    End Class

End Namespace
