Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.BusinessFacade
    ' ����    ��IMEstateRsKaoheBiaozhun_X2
    '
    ' ���������� 
    '     estate_rs_kaohebiaozhun_x2.aspxģ�鱾��ָ��ֳ���Ҫ����Ϣ
    '----------------------------------------------------------------
    <Serializable()> Public Class IMEstateRsKaoheBiaozhun_X2
        Implements IDisposable

        '----------------------------------------------------------------
        ' ģ������
        '----------------------------------------------------------------
        Private m_strhtxtDivLeftBody As String              'htxtDivLeftBody
        Private m_strhtxtDivTopBody As String               'htxtDivTopBody
        Private m_strhtxtDivLeftYWJY As String              'htxtDivLeftYWJY
        Private m_strhtxtDivTopYWJY As String               'htxtDivTopYWJY
        Private m_strhtxtDivLeftYWZG As String              'htxtDivLeftYWZG
        Private m_strhtxtDivTopYWZG As String               'htxtDivTopYWZG

        Private m_strhtxtSessionIdYWJY As String            'htxtSessionIdYWJY
        Private m_strhtxtSessionIdYWZG As String            'htxtSessionIdYWZG

        Private m_intCurrentPageIndex_grdYWJY As Integer    'grdYWJY_CurrentPageIndex
        Private m_intSelectedIndex_grdYWJY As Integer       'grdYWJY_SelectedIndex
        Private m_intPageSize_grdYWJY As Integer            'grdYWJY_PageSize

        Private m_intCurrentPageIndex_grdYWZG As Integer    'grdYWZG_CurrentPageIndex
        Private m_intSelectedIndex_grdYWZG As Integer       'grdYWZG_SelectedIndex
        Private m_intPageSize_grdYWZG As Integer            'grdYWZG_PageSize










        '----------------------------------------------------------------
        ' ���캯��
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()

            m_strhtxtDivLeftBody = ""
            m_strhtxtDivTopBody = ""
            m_strhtxtDivLeftYWJY = ""
            m_strhtxtDivTopYWJY = ""
            m_strhtxtDivLeftYWZG = ""
            m_strhtxtDivTopYWZG = ""

            m_strhtxtSessionIdYWJY = ""
            m_strhtxtSessionIdYWZG = ""

            m_intCurrentPageIndex_grdYWJY = 0
            m_intSelectedIndex_grdYWJY = -1
            m_intPageSize_grdYWJY = 30

            m_intCurrentPageIndex_grdYWZG = 0
            m_intSelectedIndex_grdYWZG = -1
            m_intPageSize_grdYWZG = 30
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
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IMEstateRsKaoheBiaozhun_X2)
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
        ' htxtDivLeftYWJY����
        '----------------------------------------------------------------
        Public Property htxtDivLeftYWJY() As String
            Get
                htxtDivLeftYWJY = m_strhtxtDivLeftYWJY
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivLeftYWJY = Value
                Catch ex As Exception
                    m_strhtxtDivLeftYWJY = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopYWJY����
        '----------------------------------------------------------------
        Public Property htxtDivTopYWJY() As String
            Get
                htxtDivTopYWJY = m_strhtxtDivTopYWJY
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivTopYWJY = Value
                Catch ex As Exception
                    m_strhtxtDivTopYWJY = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivLeftYWZG����
        '----------------------------------------------------------------
        Public Property htxtDivLeftYWZG() As String
            Get
                htxtDivLeftYWZG = m_strhtxtDivLeftYWZG
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivLeftYWZG = Value
                Catch ex As Exception
                    m_strhtxtDivLeftYWZG = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopYWZG����
        '----------------------------------------------------------------
        Public Property htxtDivTopYWZG() As String
            Get
                htxtDivTopYWZG = m_strhtxtDivTopYWZG
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivTopYWZG = Value
                Catch ex As Exception
                    m_strhtxtDivTopYWZG = ""
                End Try
            End Set
        End Property









        '----------------------------------------------------------------
        ' htxtSessionIdYWJY����
        '----------------------------------------------------------------
        Public Property htxtSessionIdYWJY() As String
            Get
                htxtSessionIdYWJY = m_strhtxtSessionIdYWJY
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSessionIdYWJY = Value
                Catch ex As Exception
                    m_strhtxtSessionIdYWJY = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtSessionIdYWZG����
        '----------------------------------------------------------------
        Public Property htxtSessionIdYWZG() As String
            Get
                htxtSessionIdYWZG = m_strhtxtSessionIdYWZG
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSessionIdYWZG = Value
                Catch ex As Exception
                    m_strhtxtSessionIdYWZG = ""
                End Try
            End Set
        End Property











        '----------------------------------------------------------------
        ' grdYWJY_CurrentPageIndex����
        '----------------------------------------------------------------
        Public Property grdYWJY_CurrentPageIndex() As Integer
            Get
                grdYWJY_CurrentPageIndex = m_intCurrentPageIndex_grdYWJY
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdYWJY = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdYWJY = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdYWJY_SelectedIndex����
        '----------------------------------------------------------------
        Public Property grdYWJY_SelectedIndex() As Integer
            Get
                grdYWJY_SelectedIndex = m_intSelectedIndex_grdYWJY
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdYWJY = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdYWJY = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdYWJY_PageSize����
        '----------------------------------------------------------------
        Public Property grdYWJY_PageSize() As Integer
            Get
                grdYWJY_PageSize = m_intPageSize_grdYWJY
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdYWJY = Value
                Catch ex As Exception
                    m_intPageSize_grdYWJY = 0
                End Try
            End Set
        End Property













        '----------------------------------------------------------------
        ' grdYWZG_CurrentPageIndex����
        '----------------------------------------------------------------
        Public Property grdYWZG_CurrentPageIndex() As Integer
            Get
                grdYWZG_CurrentPageIndex = m_intCurrentPageIndex_grdYWZG
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdYWZG = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdYWZG = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdYWZG_SelectedIndex����
        '----------------------------------------------------------------
        Public Property grdYWZG_SelectedIndex() As Integer
            Get
                grdYWZG_SelectedIndex = m_intSelectedIndex_grdYWZG
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdYWZG = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdYWZG = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdYWZG_PageSize����
        '----------------------------------------------------------------
        Public Property grdYWZG_PageSize() As Integer
            Get
                grdYWZG_PageSize = m_intPageSize_grdYWZG
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdYWZG = Value
                Catch ex As Exception
                    m_intPageSize_grdYWZG = 0
                End Try
            End Set
        End Property

    End Class

End Namespace
