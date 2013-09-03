Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.BusinessFacade
    ' ����    ��IMEstateEsHetongMmInfo
    '
    ' ���������� 
    '     estate_es_hetongmm_info.aspxģ�鱾��ָ��ֳ���Ҫ����Ϣ
    '----------------------------------------------------------------
    <Serializable()> Public Class IMEstateEsHetongMmInfo
        Implements IDisposable

        '----------------------------------------------------------------
        ' ģ������
        '----------------------------------------------------------------
        Private m_strhtxtDivLeftBody As String                'htxtDivLeftBody
        Private m_strhtxtDivTopBody As String                 'htxtDivTopBody
        Private m_strhtxtDivLeftMain As String                'htxtDivLeftMain
        Private m_strhtxtDivTopMain As String                 'htxtDivTopMain
        Private m_strhtxtDivLeftWYXX As String                'htxtDivLeftWYXX
        Private m_strhtxtDivTopWYXX As String                 'htxtDivTopWYXX
        Private m_strhtxtDivLeftYWRY As String                'htxtDivLeftYWRY
        Private m_strhtxtDivTopYWRY As String                 'htxtDivTopYWRY

        Private m_strhtxtHTWYBS As String                     'htxtHTWYBS
        Private m_strhtxtHTZT As String                       'htxtHTZT
        Private m_strtxtHTBH As String                        'txtHTBH
        Private m_strtxtHTRQ As String                        'txtHTRQ
        'zengxianglin 2008-11-22
        Private m_strtxtTJRQ As String                        'txtTJRQ
        'zengxianglin 2008-11-22
        'zengxianglin 2008-11-25
        Private m_strtxtAJFH As String                        'txtAJFH
        'zengxianglin 2008-11-25
        Private m_strtxtBZXX As String                        'txtBZXX
        Private m_intSelectedIndex_rblHTLX As Integer         'rblHTLX_SelectedIndex
        Private m_intSelectedIndex_ddlFKFS As Integer         'ddlFKFS_SelectedIndex

        Private m_strhtxtWYBS As String                       'htxtWYBS
        Private m_strhtxtQRSH As String                       'htxtQRSH
        Private m_strhtxtDGRQ As String                       'htxtDGRQ
        Private m_strtxtJFMC As String                        'txtJFMC
        Private m_strtxtYFMC As String                        'txtYFMC
        Private m_strtxtJFLXDZ As String                      'txtJFLXDZ
        Private m_strtxtYFLXDZ As String                      'txtYFLXDZ
        Private m_strtxtJFZZHM As String                      'txtJFZZHM
        Private m_strtxtYFZZHM As String                      'txtYFZZHM
        Private m_strtxtJFLXDH As String                      'txtJFLXDH
        Private m_strtxtYFLXDH As String                      'txtYFLXDH
        Private m_strtxtJFDLR As String                       'txtJFDLR
        Private m_strtxtYFDLR As String                       'txtYFDLR
        Private m_strtxtJYZMJ As String                       'txtJYZMJ
        Private m_strtxtFWDZ As String                        'txtFWDZ
        Private m_strtxtJYZJG As String                       'txtJYZJG
        Private m_strtxtJFDLF As String                       'txtJFDLF
        Private m_strtxtYFDLF As String                       'txtYFDLF
        Private m_strtxtDLFZK As String                       'txtDLFZK
        Private m_strtxtJLRQ As String                        'txtJLRQ

        Private m_intSelectedIndex_rblJLRQYD As Integer       'rblJLRQYD_SelectedIndex
        Private m_intSelectedIndex_rblJLZKYD As Integer       'rblJLZKYD_SelectedIndex
        Private m_intSelectedIndex_rblSFZFYD As Integer       'rblSFZFYD_SelectedIndex
        Private m_intSelectedIndex_rblTGFKYD As Integer       'rblTGFKYD_SelectedIndex

        Private m_intSelectedIndex_ddlJFZJLB As Integer       'ddlJFZJLB_SelectedIndex
        Private m_intSelectedIndex_ddlYFZJLB As Integer       'ddlYFZJLB_SelectedIndex

        Private m_strhtxtSessionId_WYXX As String             'htxtSessionId_WYXX
        Private m_intCurrentPageIndex_grdWYXX As Integer      'grdWYXX_CurrentPageIndex
        Private m_intSelectedIndex_grdWYXX As Integer         'grdWYXX_SelectedIndex
        Private m_intPageSize_grdWYXX As Integer              'grdWYXX_PageSize

        Private m_strhtxtSessionId_YWRY As String             'htxtSessionId_YWRY
        Private m_intCurrentPageIndex_grdYWRY As Integer      'grdYWRY_CurrentPageIndex
        Private m_intSelectedIndex_grdYWRY As Integer         'grdYWRY_SelectedIndex
        Private m_intPageSize_grdYWRY As Integer              'grdYWRY_PageSize

        'zengxianglin 2010-12-27
        Private m_strtxtKYBH As String                        'txtKYBH
        Private m_strtxtCCDZ As String                        'txtCCDZ
        Private m_strtxtCCF As String                         'txtCCF
        Private m_strtxtSSYJ As String                        'txtSSYJ
        Private m_strtxtHZYJ As String                        'txtHZYJ
        Private m_strtxtAJJG As String                        'txtAJJG
        Private m_strtxtAJYH As String                        'txtAJYH
        Private m_strtxtAJCS As String                        'txtAJCS
        Private m_strtxtAJNX As String                        'txtAJNX
        Private m_intSelectedIndex_rblYZQC As Integer         'rblYZQC_SelectedIndex
        Private m_strtxtYZQN As String                        'txtYZQN
        Private m_intSelectedIndex_rblYZLY As Integer         'rblYZLY_SelectedIndex
        Private m_strtxtYYQT As String                        'txtYYQT
        Private m_strtxtYZDY As String                        'txtYZDY
        Private m_intSelectedIndex_rblSHYX As Integer         'rblSHYX_SelectedIndex
        Private m_intSelectedIndex_rblSYWY As Integer         'rblSYWY_SelectedIndex
        Private m_intSelectedIndex_rblMJQC As Integer         'rblMJQC_SelectedIndex
        Private m_strtxtMJQN As String                        'txtMJQN
        Private m_intSelectedIndex_rblKHLY As Integer         'rblKHLY_SelectedIndex
        Private m_strtxtKYQT As String                        'txtKYQT
        Private m_strtxtKHDY As String                        'txtKHDY
        Private m_intSelectedIndex_rblGMMD As Integer         'rblGMMD_SelectedIndex
        Private m_intSelectedIndex_rblFKFSYD As Integer       'rblFKFSYD_SelectedIndex
        Private m_strhtxtHTBZ As String                       'htxtHTBZ
        Private m_strtxtJCRQ As String                        'txtJCRQ
        Private m_strtxtHZRQ As String                        'txtHZRQ
        Private m_strtxtHZJE As String                        'txtHZJE
        Private m_blnchkHTJC As Boolean                       'chkHTJC_Checked
        Private m_blnchkHTHZ As Boolean                       'chkHTHZ_Checked
        'zengxianglin 2010-12-27












        '----------------------------------------------------------------
        ' ���캯��
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()

            m_strhtxtDivLeftBody = ""
            m_strhtxtDivTopBody = ""
            m_strhtxtDivLeftMain = ""
            m_strhtxtDivTopMain = ""
            m_strhtxtDivLeftWYXX = ""
            m_strhtxtDivTopWYXX = ""
            m_strhtxtDivLeftYWRY = ""
            m_strhtxtDivTopYWRY = ""

            m_strhtxtHTWYBS = ""
            m_strhtxtHTZT = ""
            m_strtxtHTBH = ""
            m_strtxtHTRQ = ""
            'zengxianglin 2008-11-22
            m_strtxtTJRQ = ""
            'zengxianglin 2008-11-22
            'zengxianglin 2008-11-25
            m_strtxtAJFH = ""
            'zengxianglin 2008-11-25
            m_strtxtBZXX = ""

            m_intSelectedIndex_rblHTLX = -1
            m_intSelectedIndex_ddlFKFS = -1

            m_strhtxtWYBS = ""
            m_strhtxtQRSH = ""
            m_strhtxtDGRQ = ""
            m_strtxtJFMC = ""
            m_strtxtYFMC = ""
            m_strtxtJFLXDZ = ""
            m_strtxtYFLXDZ = ""
            m_strtxtJFZZHM = ""
            m_strtxtYFZZHM = ""
            m_strtxtJFLXDH = ""
            m_strtxtYFLXDH = ""
            m_strtxtJFDLR = ""
            m_strtxtYFDLR = ""
            m_strtxtJYZMJ = ""
            m_strtxtFWDZ = ""
            m_strtxtJYZJG = ""
            m_strtxtJFDLF = ""
            m_strtxtYFDLF = ""
            m_strtxtDLFZK = ""
            m_strtxtJLRQ = ""

            m_intSelectedIndex_rblJLRQYD = -1
            m_intSelectedIndex_rblJLZKYD = -1
            m_intSelectedIndex_rblSFZFYD = -1
            m_intSelectedIndex_rblTGFKYD = -1

            m_intSelectedIndex_ddlJFZJLB = -1
            m_intSelectedIndex_ddlYFZJLB = -1

            m_strhtxtSessionId_WYXX = ""
            m_intCurrentPageIndex_grdWYXX = 0
            m_intSelectedIndex_grdWYXX = -1
            m_intPageSize_grdWYXX = 30

            m_strhtxtSessionId_YWRY = ""
            m_intCurrentPageIndex_grdYWRY = 0
            m_intSelectedIndex_grdYWRY = -1
            m_intPageSize_grdYWRY = 30

            'zengxianglin 2010-12-27
            Me.m_strtxtKYBH = ""
            Me.m_strtxtCCDZ = ""
            Me.m_strtxtCCF = ""
            Me.m_strtxtSSYJ = ""
            Me.m_strtxtHZYJ = ""
            Me.m_strtxtAJJG = ""
            Me.m_strtxtAJYH = ""
            Me.m_strtxtAJCS = ""
            Me.m_strtxtAJNX = ""
            Me.m_intSelectedIndex_rblYZQC = -1
            Me.m_strtxtYZQN = ""
            Me.m_intSelectedIndex_rblYZLY = -1
            Me.m_strtxtYYQT = ""
            Me.m_strtxtYZDY = ""
            Me.m_intSelectedIndex_rblSHYX = -1
            Me.m_intSelectedIndex_rblSYWY = -1
            Me.m_intSelectedIndex_rblMJQC = -1
            Me.m_strtxtMJQN = ""
            Me.m_intSelectedIndex_rblKHLY = -1
            Me.m_strtxtKYQT = ""
            Me.m_strtxtKHDY = ""
            Me.m_intSelectedIndex_rblGMMD = -1
            Me.m_intSelectedIndex_rblFKFSYD = -1
            Me.m_strhtxtHTBZ = ""
            Me.m_strtxtJCRQ = ""
            Me.m_strtxtHZRQ = ""
            Me.m_strtxtHZJE = ""
            Me.m_blnchkHTJC = False
            Me.m_blnchkHTHZ = False
            'zengxianglin 2010-12-27
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
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IMEstateEsHetongMmInfo)
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
        ' htxtDivLeftWYXX����
        '----------------------------------------------------------------
        Public Property htxtDivLeftWYXX() As String
            Get
                htxtDivLeftWYXX = m_strhtxtDivLeftWYXX
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivLeftWYXX = Value
                Catch ex As Exception
                    m_strhtxtDivLeftWYXX = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopWYXX����
        '----------------------------------------------------------------
        Public Property htxtDivTopWYXX() As String
            Get
                htxtDivTopWYXX = m_strhtxtDivTopWYXX
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivTopWYXX = Value
                Catch ex As Exception
                    m_strhtxtDivTopWYXX = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivLeftYWRY����
        '----------------------------------------------------------------
        Public Property htxtDivLeftYWRY() As String
            Get
                htxtDivLeftYWRY = m_strhtxtDivLeftYWRY
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivLeftYWRY = Value
                Catch ex As Exception
                    m_strhtxtDivLeftYWRY = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopYWRY����
        '----------------------------------------------------------------
        Public Property htxtDivTopYWRY() As String
            Get
                htxtDivTopYWRY = m_strhtxtDivTopYWRY
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivTopYWRY = Value
                Catch ex As Exception
                    m_strhtxtDivTopYWRY = ""
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
        ' htxtQRSH����
        '----------------------------------------------------------------
        Public Property htxtQRSH() As String
            Get
                htxtQRSH = m_strhtxtQRSH
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtQRSH = Value
                Catch ex As Exception
                    m_strhtxtQRSH = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDGRQ����
        '----------------------------------------------------------------
        Public Property htxtDGRQ() As String
            Get
                htxtDGRQ = m_strhtxtDGRQ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDGRQ = Value
                Catch ex As Exception
                    m_strhtxtDGRQ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtJFMC����
        '----------------------------------------------------------------
        Public Property txtJFMC() As String
            Get
                txtJFMC = m_strtxtJFMC
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJFMC = Value
                Catch ex As Exception
                    m_strtxtJFMC = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtYFMC����
        '----------------------------------------------------------------
        Public Property txtYFMC() As String
            Get
                txtYFMC = m_strtxtYFMC
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtYFMC = Value
                Catch ex As Exception
                    m_strtxtYFMC = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtJFLXDZ����
        '----------------------------------------------------------------
        Public Property txtJFLXDZ() As String
            Get
                txtJFLXDZ = m_strtxtJFLXDZ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJFLXDZ = Value
                Catch ex As Exception
                    m_strtxtJFLXDZ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtYFLXDZ����
        '----------------------------------------------------------------
        Public Property txtYFLXDZ() As String
            Get
                txtYFLXDZ = m_strtxtYFLXDZ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtYFLXDZ = Value
                Catch ex As Exception
                    m_strtxtYFLXDZ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtJFZZHM����
        '----------------------------------------------------------------
        Public Property txtJFZZHM() As String
            Get
                txtJFZZHM = m_strtxtJFZZHM
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJFZZHM = Value
                Catch ex As Exception
                    m_strtxtJFZZHM = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtYFZZHM����
        '----------------------------------------------------------------
        Public Property txtYFZZHM() As String
            Get
                txtYFZZHM = m_strtxtYFZZHM
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtYFZZHM = Value
                Catch ex As Exception
                    m_strtxtYFZZHM = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtJFLXDH����
        '----------------------------------------------------------------
        Public Property txtJFLXDH() As String
            Get
                txtJFLXDH = m_strtxtJFLXDH
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJFLXDH = Value
                Catch ex As Exception
                    m_strtxtJFLXDH = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtYFLXDH����
        '----------------------------------------------------------------
        Public Property txtYFLXDH() As String
            Get
                txtYFLXDH = m_strtxtYFLXDH
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtYFLXDH = Value
                Catch ex As Exception
                    m_strtxtYFLXDH = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtJFDLR����
        '----------------------------------------------------------------
        Public Property txtJFDLR() As String
            Get
                txtJFDLR = m_strtxtJFDLR
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJFDLR = Value
                Catch ex As Exception
                    m_strtxtJFDLR = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtYFDLR����
        '----------------------------------------------------------------
        Public Property txtYFDLR() As String
            Get
                txtYFDLR = m_strtxtYFDLR
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtYFDLR = Value
                Catch ex As Exception
                    m_strtxtYFDLR = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtJYZMJ����
        '----------------------------------------------------------------
        Public Property txtJYZMJ() As String
            Get
                txtJYZMJ = m_strtxtJYZMJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJYZMJ = Value
                Catch ex As Exception
                    m_strtxtJYZMJ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtFWDZ����
        '----------------------------------------------------------------
        Public Property txtFWDZ() As String
            Get
                txtFWDZ = m_strtxtFWDZ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtFWDZ = Value
                Catch ex As Exception
                    m_strtxtFWDZ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtJYZJG����
        '----------------------------------------------------------------
        Public Property txtJYZJG() As String
            Get
                txtJYZJG = m_strtxtJYZJG
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJYZJG = Value
                Catch ex As Exception
                    m_strtxtJYZJG = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtJFDLF����
        '----------------------------------------------------------------
        Public Property txtJFDLF() As String
            Get
                txtJFDLF = m_strtxtJFDLF
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJFDLF = Value
                Catch ex As Exception
                    m_strtxtJFDLF = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtYFDLF����
        '----------------------------------------------------------------
        Public Property txtYFDLF() As String
            Get
                txtYFDLF = m_strtxtYFDLF
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtYFDLF = Value
                Catch ex As Exception
                    m_strtxtYFDLF = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtDLFZK����
        '----------------------------------------------------------------
        Public Property txtDLFZK() As String
            Get
                txtDLFZK = m_strtxtDLFZK
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtDLFZK = Value
                Catch ex As Exception
                    m_strtxtDLFZK = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtJLRQ����
        '----------------------------------------------------------------
        Public Property txtJLRQ() As String
            Get
                txtJLRQ = m_strtxtJLRQ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJLRQ = Value
                Catch ex As Exception
                    m_strtxtJLRQ = ""
                End Try
            End Set
        End Property















        '----------------------------------------------------------------
        ' htxtHTWYBS����
        '----------------------------------------------------------------
        Public Property htxtHTWYBS() As String
            Get
                htxtHTWYBS = m_strhtxtHTWYBS
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtHTWYBS = Value
                Catch ex As Exception
                    m_strhtxtHTWYBS = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtHTZT����
        '----------------------------------------------------------------
        Public Property htxtHTZT() As String
            Get
                htxtHTZT = m_strhtxtHTZT
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtHTZT = Value
                Catch ex As Exception
                    m_strhtxtHTZT = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtHTBH����
        '----------------------------------------------------------------
        Public Property txtHTBH() As String
            Get
                txtHTBH = m_strtxtHTBH
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtHTBH = Value
                Catch ex As Exception
                    m_strtxtHTBH = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtHTRQ����
        '----------------------------------------------------------------
        Public Property txtHTRQ() As String
            Get
                txtHTRQ = m_strtxtHTRQ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtHTRQ = Value
                Catch ex As Exception
                    m_strtxtHTRQ = ""
                End Try
            End Set
        End Property

        'zengxianglin 2008-11-22
        '----------------------------------------------------------------
        ' txtTJRQ����
        '----------------------------------------------------------------
        Public Property txtTJRQ() As String
            Get
                txtTJRQ = m_strtxtTJRQ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtTJRQ = Value
                Catch ex As Exception
                    m_strtxtTJRQ = ""
                End Try
            End Set
        End Property
        'zengxianglin 2008-11-22

        'zengxianglin 2008-11-25
        '----------------------------------------------------------------
        ' txtAJFH����
        '----------------------------------------------------------------
        Public Property txtAJFH() As String
            Get
                txtAJFH = m_strtxtAJFH
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtAJFH = Value
                Catch ex As Exception
                    m_strtxtAJFH = ""
                End Try
            End Set
        End Property
        'zengxianglin 2008-11-25

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
        ' rblHTLX_SelectedIndex����
        '----------------------------------------------------------------
        Public Property rblHTLX_SelectedIndex() As Integer
            Get
                rblHTLX_SelectedIndex = m_intSelectedIndex_rblHTLX
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_rblHTLX = Value
                Catch ex As Exception
                    m_intSelectedIndex_rblHTLX = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' ddlFKFS_SelectedIndex����
        '----------------------------------------------------------------
        Public Property ddlFKFS_SelectedIndex() As Integer
            Get
                ddlFKFS_SelectedIndex = m_intSelectedIndex_ddlFKFS
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlFKFS = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlFKFS = -1
                End Try
            End Set
        End Property











        '----------------------------------------------------------------
        ' rblJLRQYD_SelectedIndex����
        '----------------------------------------------------------------
        Public Property rblJLRQYD_SelectedIndex() As Integer
            Get
                rblJLRQYD_SelectedIndex = m_intSelectedIndex_rblJLRQYD
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_rblJLRQYD = Value
                Catch ex As Exception
                    m_intSelectedIndex_rblJLRQYD = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' rblJLZKYD_SelectedIndex����
        '----------------------------------------------------------------
        Public Property rblJLZKYD_SelectedIndex() As Integer
            Get
                rblJLZKYD_SelectedIndex = m_intSelectedIndex_rblJLZKYD
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_rblJLZKYD = Value
                Catch ex As Exception
                    m_intSelectedIndex_rblJLZKYD = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' rblTGFKYD_SelectedIndex����
        '----------------------------------------------------------------
        Public Property rblTGFKYD_SelectedIndex() As Integer
            Get
                rblTGFKYD_SelectedIndex = m_intSelectedIndex_rblTGFKYD
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_rblTGFKYD = Value
                Catch ex As Exception
                    m_intSelectedIndex_rblTGFKYD = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' rblSFZFYD_SelectedIndex����
        '----------------------------------------------------------------
        Public Property rblSFZFYD_SelectedIndex() As Integer
            Get
                rblSFZFYD_SelectedIndex = m_intSelectedIndex_rblSFZFYD
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_rblSFZFYD = Value
                Catch ex As Exception
                    m_intSelectedIndex_rblSFZFYD = -1
                End Try
            End Set
        End Property












        '----------------------------------------------------------------
        ' ddlJFZJLB_SelectedIndex����
        '----------------------------------------------------------------
        Public Property ddlJFZJLB_SelectedIndex() As Integer
            Get
                ddlJFZJLB_SelectedIndex = m_intSelectedIndex_ddlJFZJLB
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlJFZJLB = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlJFZJLB = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' ddlYFZJLB_SelectedIndex����
        '----------------------------------------------------------------
        Public Property ddlYFZJLB_SelectedIndex() As Integer
            Get
                ddlYFZJLB_SelectedIndex = m_intSelectedIndex_ddlYFZJLB
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlYFZJLB = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlYFZJLB = -1
                End Try
            End Set
        End Property












        '----------------------------------------------------------------
        ' htxtSessionId_WYXX����
        '----------------------------------------------------------------
        Public Property htxtSessionId_WYXX() As String
            Get
                htxtSessionId_WYXX = m_strhtxtSessionId_WYXX
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSessionId_WYXX = Value
                Catch ex As Exception
                    m_strhtxtSessionId_WYXX = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdWYXX_CurrentPageIndex����
        '----------------------------------------------------------------
        Public Property grdWYXX_CurrentPageIndex() As Integer
            Get
                grdWYXX_CurrentPageIndex = m_intCurrentPageIndex_grdWYXX
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdWYXX = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdWYXX = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdWYXX_SelectedIndex����
        '----------------------------------------------------------------
        Public Property grdWYXX_SelectedIndex() As Integer
            Get
                grdWYXX_SelectedIndex = m_intSelectedIndex_grdWYXX
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdWYXX = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdWYXX = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdWYXX_PageSize����
        '----------------------------------------------------------------
        Public Property grdWYXX_PageSize() As Integer
            Get
                grdWYXX_PageSize = m_intPageSize_grdWYXX
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdWYXX = Value
                Catch ex As Exception
                    m_intPageSize_grdWYXX = 0
                End Try
            End Set
        End Property











        '----------------------------------------------------------------
        ' htxtSessionId_YWRY����
        '----------------------------------------------------------------
        Public Property htxtSessionId_YWRY() As String
            Get
                htxtSessionId_YWRY = m_strhtxtSessionId_YWRY
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSessionId_YWRY = Value
                Catch ex As Exception
                    m_strhtxtSessionId_YWRY = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdYWRY_CurrentPageIndex����
        '----------------------------------------------------------------
        Public Property grdYWRY_CurrentPageIndex() As Integer
            Get
                grdYWRY_CurrentPageIndex = m_intCurrentPageIndex_grdYWRY
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdYWRY = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdYWRY = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdYWRY_SelectedIndex����
        '----------------------------------------------------------------
        Public Property grdYWRY_SelectedIndex() As Integer
            Get
                grdYWRY_SelectedIndex = m_intSelectedIndex_grdYWRY
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdYWRY = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdYWRY = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdYWRY_PageSize����
        '----------------------------------------------------------------
        Public Property grdYWRY_PageSize() As Integer
            Get
                grdYWRY_PageSize = m_intPageSize_grdYWRY
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdYWRY = Value
                Catch ex As Exception
                    m_intPageSize_grdYWRY = 0
                End Try
            End Set
        End Property








        '----------------------------------------------------------------
        ' txtKYBH����
        '----------------------------------------------------------------
        Public Property txtKYBH() As String
            Get
                txtKYBH = Me.m_strtxtKYBH
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtKYBH = Value
                Catch ex As Exception
                    Me.m_strtxtKYBH = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtCCDZ����
        '----------------------------------------------------------------
        Public Property txtCCDZ() As String
            Get
                txtCCDZ = Me.m_strtxtCCDZ
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtCCDZ = Value
                Catch ex As Exception
                    Me.m_strtxtCCDZ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtCCF����
        '----------------------------------------------------------------
        Public Property txtCCF() As String
            Get
                txtCCF = Me.m_strtxtCCF
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtCCF = Value
                Catch ex As Exception
                    Me.m_strtxtCCF = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtSSYJ����
        '----------------------------------------------------------------
        Public Property txtSSYJ() As String
            Get
                txtSSYJ = Me.m_strtxtSSYJ
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtSSYJ = Value
                Catch ex As Exception
                    Me.m_strtxtSSYJ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtHZYJ����
        '----------------------------------------------------------------
        Public Property txtHZYJ() As String
            Get
                txtHZYJ = Me.m_strtxtHZYJ
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtHZYJ = Value
                Catch ex As Exception
                    Me.m_strtxtHZYJ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtAJJG����
        '----------------------------------------------------------------
        Public Property txtAJJG() As String
            Get
                txtAJJG = Me.m_strtxtAJJG
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtAJJG = Value
                Catch ex As Exception
                    Me.m_strtxtAJJG = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtAJYH����
        '----------------------------------------------------------------
        Public Property txtAJYH() As String
            Get
                txtAJYH = Me.m_strtxtAJYH
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtAJYH = Value
                Catch ex As Exception
                    Me.m_strtxtAJYH = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtAJCS����
        '----------------------------------------------------------------
        Public Property txtAJCS() As String
            Get
                txtAJCS = Me.m_strtxtAJCS
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtAJCS = Value
                Catch ex As Exception
                    Me.m_strtxtAJCS = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtAJNX����
        '----------------------------------------------------------------
        Public Property txtAJNX() As String
            Get
                txtAJNX = Me.m_strtxtAJNX
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtAJNX = Value
                Catch ex As Exception
                    Me.m_strtxtAJNX = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtYZQN����
        '----------------------------------------------------------------
        Public Property txtYZQN() As String
            Get
                txtYZQN = Me.m_strtxtYZQN
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtYZQN = Value
                Catch ex As Exception
                    Me.m_strtxtYZQN = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtYYQT����
        '----------------------------------------------------------------
        Public Property txtYYQT() As String
            Get
                txtYYQT = Me.m_strtxtYYQT
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtYYQT = Value
                Catch ex As Exception
                    Me.m_strtxtYYQT = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtYZDY����
        '----------------------------------------------------------------
        Public Property txtYZDY() As String
            Get
                txtYZDY = Me.m_strtxtYZDY
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtYZDY = Value
                Catch ex As Exception
                    Me.m_strtxtYZDY = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtMJQN����
        '----------------------------------------------------------------
        Public Property txtMJQN() As String
            Get
                txtMJQN = Me.m_strtxtMJQN
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtMJQN = Value
                Catch ex As Exception
                    Me.m_strtxtMJQN = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtKYQT����
        '----------------------------------------------------------------
        Public Property txtKYQT() As String
            Get
                txtKYQT = Me.m_strtxtKYQT
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtKYQT = Value
                Catch ex As Exception
                    Me.m_strtxtKYQT = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtKHDY����
        '----------------------------------------------------------------
        Public Property txtKHDY() As String
            Get
                txtKHDY = Me.m_strtxtKHDY
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtKHDY = Value
                Catch ex As Exception
                    Me.m_strtxtKHDY = ""
                End Try
            End Set
        End Property








        '----------------------------------------------------------------
        ' rblYZQC_SelectedIndex����
        '----------------------------------------------------------------
        Public Property rblYZQC_SelectedIndex() As Integer
            Get
                rblYZQC_SelectedIndex = Me.m_intSelectedIndex_rblYZQC
            End Get
            Set(ByVal Value As Integer)
                Try
                    Me.m_intSelectedIndex_rblYZQC = Value
                Catch ex As Exception
                    Me.m_intSelectedIndex_rblYZQC = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' rblYZLY_SelectedIndex����
        '----------------------------------------------------------------
        Public Property rblYZLY_SelectedIndex() As Integer
            Get
                rblYZLY_SelectedIndex = Me.m_intSelectedIndex_rblYZLY
            End Get
            Set(ByVal Value As Integer)
                Try
                    Me.m_intSelectedIndex_rblYZLY = Value
                Catch ex As Exception
                    Me.m_intSelectedIndex_rblYZLY = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' rblSHYX_SelectedIndex����
        '----------------------------------------------------------------
        Public Property rblSHYX_SelectedIndex() As Integer
            Get
                rblSHYX_SelectedIndex = Me.m_intSelectedIndex_rblSHYX
            End Get
            Set(ByVal Value As Integer)
                Try
                    Me.m_intSelectedIndex_rblSHYX = Value
                Catch ex As Exception
                    Me.m_intSelectedIndex_rblSHYX = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' rblSYWY_SelectedIndex����
        '----------------------------------------------------------------
        Public Property rblSYWY_SelectedIndex() As Integer
            Get
                rblSYWY_SelectedIndex = Me.m_intSelectedIndex_rblSYWY
            End Get
            Set(ByVal Value As Integer)
                Try
                    Me.m_intSelectedIndex_rblSYWY = Value
                Catch ex As Exception
                    Me.m_intSelectedIndex_rblSYWY = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' rblMJQC_SelectedIndex����
        '----------------------------------------------------------------
        Public Property rblMJQC_SelectedIndex() As Integer
            Get
                rblMJQC_SelectedIndex = Me.m_intSelectedIndex_rblMJQC
            End Get
            Set(ByVal Value As Integer)
                Try
                    Me.m_intSelectedIndex_rblMJQC = Value
                Catch ex As Exception
                    Me.m_intSelectedIndex_rblMJQC = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' rblKHLY_SelectedIndex����
        '----------------------------------------------------------------
        Public Property rblKHLY_SelectedIndex() As Integer
            Get
                rblKHLY_SelectedIndex = Me.m_intSelectedIndex_rblKHLY
            End Get
            Set(ByVal Value As Integer)
                Try
                    Me.m_intSelectedIndex_rblKHLY = Value
                Catch ex As Exception
                    Me.m_intSelectedIndex_rblKHLY = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' rblGMMD_SelectedIndex����
        '----------------------------------------------------------------
        Public Property rblGMMD_SelectedIndex() As Integer
            Get
                rblGMMD_SelectedIndex = Me.m_intSelectedIndex_rblGMMD
            End Get
            Set(ByVal Value As Integer)
                Try
                    Me.m_intSelectedIndex_rblGMMD = Value
                Catch ex As Exception
                    Me.m_intSelectedIndex_rblGMMD = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' rblFKFSYD_SelectedIndex����
        '----------------------------------------------------------------
        Public Property rblFKFSYD_SelectedIndex() As Integer
            Get
                rblFKFSYD_SelectedIndex = m_intSelectedIndex_rblFKFSYD
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_rblFKFSYD = Value
                Catch ex As Exception
                    m_intSelectedIndex_rblFKFSYD = -1
                End Try
            End Set
        End Property











        '----------------------------------------------------------------
        ' txtJCRQ����
        '----------------------------------------------------------------
        Public Property txtJCRQ() As String
            Get
                txtJCRQ = Me.m_strtxtJCRQ
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtJCRQ = Value
                Catch ex As Exception
                    Me.m_strtxtJCRQ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtHZRQ����
        '----------------------------------------------------------------
        Public Property txtHZRQ() As String
            Get
                txtHZRQ = Me.m_strtxtHZRQ
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtHZRQ = Value
                Catch ex As Exception
                    Me.m_strtxtHZRQ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtHZJE����
        '----------------------------------------------------------------
        Public Property txtHZJE() As String
            Get
                txtHZJE = Me.m_strtxtHZJE
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtHZJE = Value
                Catch ex As Exception
                    Me.m_strtxtHZJE = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtHTBZ����
        '----------------------------------------------------------------
        Public Property htxtHTBZ() As String
            Get
                htxtHTBZ = Me.m_strhtxtHTBZ
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strhtxtHTBZ = Value
                Catch ex As Exception
                    Me.m_strhtxtHTBZ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' chkHTJC_Checked����
        '----------------------------------------------------------------
        Public Property chkHTJC_Checked() As Boolean
            Get
                chkHTJC_Checked = Me.m_blnchkHTJC
            End Get
            Set(ByVal Value As Boolean)
                Try
                    Me.m_blnchkHTJC = Value
                Catch ex As Exception
                    Me.m_blnchkHTJC = False
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' chkHTHZ_Checked����
        '----------------------------------------------------------------
        Public Property chkHTHZ_Checked() As Boolean
            Get
                chkHTHZ_Checked = Me.m_blnchkHTHZ
            End Get
            Set(ByVal Value As Boolean)
                Try
                    Me.m_blnchkHTHZ = Value
                Catch ex As Exception
                    Me.m_blnchkHTHZ = False
                End Try
            End Set
        End Property

    End Class

End Namespace
