Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.BusinessFacade
    ' 类名    ：IMEstateEsHetongZlInfo
    '
    ' 功能描述： 
    '     estate_es_hetongzl_info.aspx模块本身恢复现场需要的信息
    '----------------------------------------------------------------
    <Serializable()> Public Class IMEstateEsHetongZlInfo
        Implements IDisposable

        '----------------------------------------------------------------
        ' 模块属性
        '----------------------------------------------------------------
        Private m_strhtxtDivLeftBody As String                'htxtDivLeftBody
        Private m_strhtxtDivTopBody As String                 'htxtDivTopBody
        Private m_strhtxtDivLeftMain As String                'htxtDivLeftMain
        Private m_strhtxtDivTopMain As String                 'htxtDivTopMain
        Private m_strhtxtDivLeftWYXX As String                'htxtDivLeftWYXX
        Private m_strhtxtDivTopWYXX As String                 'htxtDivTopWYXX
        Private m_strhtxtDivLeftYWRY As String                'htxtDivLeftYWRY
        Private m_strhtxtDivTopYWRY As String                 'htxtDivTopYWRY
        Private m_strhtxtDivLeftZLQX As String                'htxtDivLeftZLQX
        Private m_strhtxtDivTopZLQX As String                 'htxtDivTopZLQX

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
        Private m_strtxtJYZZJ As String                       'txtJYZZJ
        Private m_strtxtJYYZJ As String                       'txtJYYZJ
        Private m_strtxtZLBZJ As String                       'txtZLBZJ
        Private m_strtxtJFDLF As String                       'txtJFDLF
        Private m_strtxtYFDLF As String                       'txtYFDLF
        Private m_strtxtDLFZK As String                       'txtDLFZK
        Private m_strtxtJLRQ As String                        'txtJLRQ
        Private m_strtxtZQYS As String                        'txtZQYS
        Private m_strtxtJZR As String                         'txtJZR
        Private m_strtxtZNJBL As String                       'txtZNJBL
        Private m_strtxtNDZBL As String                       'txtNDZBL
        Private m_strtxtJLZKSM As String                      'txtJLZKSM
        Private m_intSelectedIndex_rblFZFSYD As Integer       'rblFZFSYD_SelectedIndex
        Private m_intSelectedIndex_rblSFZFYD As Integer       'rblSFZFYD_SelectedIndex
        Private m_intSelectedIndex_rblZJTGYD As Integer       'rblZJTGYD_SelectedIndex
        Private m_intSelectedIndex_ddlJFZJLB As Integer       'ddlJFZJLB_SelectedIndex
        Private m_intSelectedIndex_ddlYFZJLB As Integer       'ddlYFZJLB_SelectedIndex

        Private m_strtxtQX_KSRQ As String                      'txtQX_KSRQ
        Private m_strtxtQX_ZZRQ As String                      'txtQX_ZZRQ
        Private m_strtxtQX_YZJE As String                      'txtQX_YZJE
        Private m_strtxtQX_YZZE As String                      'txtQX_YZZE
        Private m_strtxtQX_ZQYS As String                      'txtQX_ZQYS
        Private m_strtxtQX_JZR As String                       'txtQX_JZR
        Private m_intSelectedIndex_rblQX_JZFS As Integer       'rblQX_JZFS_SelectedIndex

        Private m_strhtxtSessionId_WYXX As String             'htxtSessionId_WYXX
        Private m_intCurrentPageIndex_grdWYXX As Integer      'grdWYXX_CurrentPageIndex
        Private m_intSelectedIndex_grdWYXX As Integer         'grdWYXX_SelectedIndex
        Private m_intPageSize_grdWYXX As Integer              'grdWYXX_PageSize

        Private m_strhtxtSessionId_YWRY As String             'htxtSessionId_YWRY
        Private m_intCurrentPageIndex_grdYWRY As Integer      'grdYWRY_CurrentPageIndex
        Private m_intSelectedIndex_grdYWRY As Integer         'grdYWRY_SelectedIndex
        Private m_intPageSize_grdYWRY As Integer              'grdYWRY_PageSize

        Private m_strhtxtSessionId_ZLQX As String             'htxtSessionId_ZLQX
        Private m_intCurrentPageIndex_grdZLQX As Integer      'grdZLQX_CurrentPageIndex
        Private m_intSelectedIndex_grdZLQX As Integer         'grdZLQX_SelectedIndex
        Private m_intPageSize_grdZLQX As Integer              'grdZLQX_PageSize

        'zengxianglin 2010-12-27
        Private m_strtxtKYBH As String                        'txtKYBH
        Private m_strtxtCCDZ As String                        'txtCCDZ
        Private m_strtxtCCF As String                         'txtCCF
        Private m_strtxtSSYJ As String                        'txtSSYJ
        Private m_strtxtHZYJ As String                        'txtHZYJ
        Private m_intSelectedIndex_rblYZQC As Integer         'rblYZQC_SelectedIndex
        Private m_strtxtYZQN As String                        'txtYZQN
        Private m_intSelectedIndex_rblYZLY As Integer         'rblYZLY_SelectedIndex
        Private m_strtxtYYQT As String                        'txtYYQT
        Private m_strtxtYZDY As String                        'txtYZDY
        Private m_intSelectedIndex_rblSYWY As Integer         'rblSYWY_SelectedIndex
        Private m_intSelectedIndex_rblMJQC As Integer         'rblMJQC_SelectedIndex
        Private m_strtxtMJQN As String                        'txtMJQN
        Private m_intSelectedIndex_rblKHLY As Integer         'rblKHLY_SelectedIndex
        Private m_strtxtKYQT As String                        'txtKYQT
        Private m_strtxtKHDY As String                        'txtKHDY
        Private m_strtxtZLKS As String                        'txtZLKS
        Private m_strtxtZLJS As String                        'txtZLJS
        Private m_intSelectedIndex_rblSDMQ As Integer         'rblSDMQ_SelectedIndex
        Private m_intSelectedIndex_rblDHF As Integer          'rblDHF_SelectedIndex
        Private m_intSelectedIndex_rblGLF As Integer          'rblGLF_SelectedIndex
        Private m_intSelectedIndex_rblZLFP As Integer         'rblZLFP_SelectedIndex
        Private m_strhtxtHTBZ As String                       'htxtHTBZ
        Private m_strtxtJCRQ As String                        'txtJCRQ
        Private m_strtxtHZRQ As String                        'txtHZRQ
        Private m_strtxtHZJE As String                        'txtHZJE
        Private m_blnchkHTJC As Boolean                       'chkHTJC_Checked
        Private m_blnchkHTHZ As Boolean                       'chkHTHZ_Checked
        'zengxianglin 2010-12-27











        '----------------------------------------------------------------
        ' 构造函数
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
            m_strtxtJYZZJ = ""
            m_strtxtJYYZJ = ""
            m_strtxtZLBZJ = ""
            m_strtxtJFDLF = ""
            m_strtxtYFDLF = ""
            m_strtxtDLFZK = ""
            m_strtxtZQYS = ""
            m_strtxtJZR = ""
            m_strtxtJLRQ = ""
            m_strtxtZNJBL = ""
            m_strtxtNDZBL = ""
            m_strtxtJLZKSM = ""
            m_intSelectedIndex_rblFZFSYD = -1
            m_intSelectedIndex_rblSFZFYD = -1
            m_intSelectedIndex_rblZJTGYD = -1
            m_intSelectedIndex_ddlJFZJLB = -1
            m_intSelectedIndex_ddlYFZJLB = -1

            m_strtxtQX_KSRQ = ""
            m_strtxtQX_ZZRQ = ""
            m_strtxtQX_YZJE = ""
            m_strtxtQX_YZZE = ""
            m_strtxtQX_ZQYS = ""
            m_strtxtQX_JZR = ""
            m_intSelectedIndex_rblQX_JZFS = -1

            m_strhtxtSessionId_WYXX = ""
            m_intCurrentPageIndex_grdWYXX = 0
            m_intSelectedIndex_grdWYXX = -1
            m_intPageSize_grdWYXX = 30

            m_strhtxtSessionId_YWRY = ""
            m_intCurrentPageIndex_grdYWRY = 0
            m_intSelectedIndex_grdYWRY = -1
            m_intPageSize_grdYWRY = 30

            m_strhtxtSessionId_ZLQX = ""
            m_intCurrentPageIndex_grdZLQX = 0
            m_intSelectedIndex_grdZLQX = -1
            m_intPageSize_grdZLQX = 30

            'zengxianglin 2010-12-27
            Me.m_strtxtKYBH = ""
            Me.m_strtxtCCDZ = ""
            Me.m_strtxtCCF = ""
            Me.m_strtxtSSYJ = ""
            Me.m_strtxtHZYJ = ""
            Me.m_intSelectedIndex_rblYZQC = -1
            Me.m_strtxtYZQN = ""
            Me.m_intSelectedIndex_rblYZLY = -1
            Me.m_strtxtYYQT = ""
            Me.m_strtxtYZDY = ""
            Me.m_intSelectedIndex_rblSYWY = -1
            Me.m_intSelectedIndex_rblMJQC = -1
            Me.m_strtxtMJQN = ""
            Me.m_intSelectedIndex_rblKHLY = -1
            Me.m_strtxtKYQT = ""
            Me.m_strtxtKHDY = ""
            Me.m_strtxtZLKS = ""
            Me.m_strtxtZLJS = ""
            Me.m_intSelectedIndex_rblSDMQ = -1
            Me.m_intSelectedIndex_rblDHF = -1
            Me.m_intSelectedIndex_rblGLF = -1
            Me.m_intSelectedIndex_rblZLFP = -1
            Me.m_strhtxtHTBZ = ""
            Me.m_strtxtJCRQ = ""
            Me.m_strtxtHZRQ = ""
            Me.m_strtxtHZJE = ""
            Me.m_blnchkHTJC = False
            Me.m_blnchkHTHZ = False
            'zengxianglin 2010-12-27
        End Sub

        '----------------------------------------------------------------
        ' 虚拟析构函数
        '----------------------------------------------------------------
        Public Sub Dispose() Implements System.IDisposable.Dispose
            Dispose(True)
        End Sub

        '----------------------------------------------------------------
        ' 释放本身资源
        '----------------------------------------------------------------
        Protected Sub Dispose(ByVal disposing As Boolean)
            If (Not disposing) Then
                Exit Sub
            End If
        End Sub

        '----------------------------------------------------------------
        ' 安全释放本身资源
        '----------------------------------------------------------------
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IMEstateEsHetongZlInfo)
            Try
                If Not (obj Is Nothing) Then
                    obj.Dispose()
                End If
            Catch ex As Exception
            End Try
            obj = Nothing
        End Sub













        '----------------------------------------------------------------
        ' htxtDivLeftBody属性
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
        ' htxtDivTopBody属性
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
        ' htxtDivLeftMain属性
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
        ' htxtDivTopMain属性
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
        ' htxtDivLeftWYXX属性
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
        ' htxtDivTopWYXX属性
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
        ' htxtDivLeftYWRY属性
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
        ' htxtDivTopYWRY属性
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
        ' htxtDivLeftZLQX属性
        '----------------------------------------------------------------
        Public Property htxtDivLeftZLQX() As String
            Get
                htxtDivLeftZLQX = m_strhtxtDivLeftZLQX
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivLeftZLQX = Value
                Catch ex As Exception
                    m_strhtxtDivLeftZLQX = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopZLQX属性
        '----------------------------------------------------------------
        Public Property htxtDivTopZLQX() As String
            Get
                htxtDivTopZLQX = m_strhtxtDivTopZLQX
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivTopZLQX = Value
                Catch ex As Exception
                    m_strhtxtDivTopZLQX = ""
                End Try
            End Set
        End Property












        '----------------------------------------------------------------
        ' htxtWYBS属性
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
        ' htxtQRSH属性
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
        ' htxtDGRQ属性
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
        ' txtJFMC属性
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
        ' txtYFMC属性
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
        ' txtJFLXDZ属性
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
        ' txtYFLXDZ属性
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
        ' txtJFZZHM属性
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
        ' txtYFZZHM属性
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
        ' txtJFLXDH属性
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
        ' txtYFLXDH属性
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
        ' txtJFDLR属性
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
        ' txtYFDLR属性
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
        ' txtJYZMJ属性
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
        ' txtFWDZ属性
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
        ' txtJYZZJ属性
        '----------------------------------------------------------------
        Public Property txtJYZZJ() As String
            Get
                txtJYZZJ = m_strtxtJYZZJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJYZZJ = Value
                Catch ex As Exception
                    m_strtxtJYZZJ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtJYYZJ属性
        '----------------------------------------------------------------
        Public Property txtJYYZJ() As String
            Get
                txtJYYZJ = m_strtxtJYYZJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJYYZJ = Value
                Catch ex As Exception
                    m_strtxtJYYZJ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtZLBZJ属性
        '----------------------------------------------------------------
        Public Property txtZLBZJ() As String
            Get
                txtZLBZJ = m_strtxtZLBZJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtZLBZJ = Value
                Catch ex As Exception
                    m_strtxtZLBZJ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtJFDLF属性
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
        ' txtYFDLF属性
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
        ' txtDLFZK属性
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
        ' txtJLRQ属性
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
        ' txtZQYS属性
        '----------------------------------------------------------------
        Public Property txtZQYS() As String
            Get
                txtZQYS = m_strtxtZQYS
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtZQYS = Value
                Catch ex As Exception
                    m_strtxtZQYS = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtJZR属性
        '----------------------------------------------------------------
        Public Property txtJZR() As String
            Get
                txtJZR = m_strtxtJZR
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJZR = Value
                Catch ex As Exception
                    m_strtxtJZR = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtZNJBL属性
        '----------------------------------------------------------------
        Public Property txtZNJBL() As String
            Get
                txtZNJBL = m_strtxtZNJBL
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtZNJBL = Value
                Catch ex As Exception
                    m_strtxtZNJBL = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtNDZBL属性
        '----------------------------------------------------------------
        Public Property txtNDZBL() As String
            Get
                txtNDZBL = m_strtxtNDZBL
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtNDZBL = Value
                Catch ex As Exception
                    m_strtxtNDZBL = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtJLZKSM属性
        '----------------------------------------------------------------
        Public Property txtJLZKSM() As String
            Get
                txtJLZKSM = m_strtxtJLZKSM
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJLZKSM = Value
                Catch ex As Exception
                    m_strtxtJLZKSM = ""
                End Try
            End Set
        End Property















        '----------------------------------------------------------------
        ' htxtHTWYBS属性
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
        ' htxtHTZT属性
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
        ' txtHTBH属性
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
        ' txtHTRQ属性
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
        ' txtTJRQ属性
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
        ' txtAJFH属性
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
        ' txtBZXX属性
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
        ' ddlFKFS_SelectedIndex属性
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
        ' rblFZFSYD_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property rblFZFSYD_SelectedIndex() As Integer
            Get
                rblFZFSYD_SelectedIndex = m_intSelectedIndex_rblFZFSYD
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_rblFZFSYD = Value
                Catch ex As Exception
                    m_intSelectedIndex_rblFZFSYD = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' rblZJTGYD_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property rblZJTGYD_SelectedIndex() As Integer
            Get
                rblZJTGYD_SelectedIndex = m_intSelectedIndex_rblZJTGYD
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_rblZJTGYD = Value
                Catch ex As Exception
                    m_intSelectedIndex_rblZJTGYD = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' rblSFZFYD_SelectedIndex属性
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
        ' ddlJFZJLB_SelectedIndex属性
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
        ' ddlYFZJLB_SelectedIndex属性
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
        ' txtQX_KSRQ属性
        '----------------------------------------------------------------
        Public Property txtQX_KSRQ() As String
            Get
                txtQX_KSRQ = m_strtxtQX_KSRQ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtQX_KSRQ = Value
                Catch ex As Exception
                    m_strtxtQX_KSRQ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtQX_ZZRQ属性
        '----------------------------------------------------------------
        Public Property txtQX_ZZRQ() As String
            Get
                txtQX_ZZRQ = m_strtxtQX_ZZRQ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtQX_ZZRQ = Value
                Catch ex As Exception
                    m_strtxtQX_ZZRQ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtQX_YZJE属性
        '----------------------------------------------------------------
        Public Property txtQX_YZJE() As String
            Get
                txtQX_YZJE = m_strtxtQX_YZJE
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtQX_YZJE = Value
                Catch ex As Exception
                    m_strtxtQX_YZJE = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtQX_YZZE属性
        '----------------------------------------------------------------
        Public Property txtQX_YZZE() As String
            Get
                txtQX_YZZE = m_strtxtQX_YZZE
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtQX_YZZE = Value
                Catch ex As Exception
                    m_strtxtQX_YZZE = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtQX_ZQYS属性
        '----------------------------------------------------------------
        Public Property txtQX_ZQYS() As String
            Get
                txtQX_ZQYS = m_strtxtQX_ZQYS
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtQX_ZQYS = Value
                Catch ex As Exception
                    m_strtxtQX_ZQYS = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtQX_JZR属性
        '----------------------------------------------------------------
        Public Property txtQX_JZR() As String
            Get
                txtQX_JZR = m_strtxtQX_JZR
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtQX_JZR = Value
                Catch ex As Exception
                    m_strtxtQX_JZR = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' rblQX_JZFS_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property rblQX_JZFS_SelectedIndex() As Integer
            Get
                rblQX_JZFS_SelectedIndex = m_intSelectedIndex_rblQX_JZFS
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_rblQX_JZFS = Value
                Catch ex As Exception
                    m_intSelectedIndex_rblQX_JZFS = -1
                End Try
            End Set
        End Property












        '----------------------------------------------------------------
        ' htxtSessionId_WYXX属性
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
        ' grdWYXX_CurrentPageIndex属性
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
        ' grdWYXX_SelectedIndex属性
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
        ' grdWYXX_PageSize属性
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
        ' htxtSessionId_YWRY属性
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
        ' grdYWRY_CurrentPageIndex属性
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
        ' grdYWRY_SelectedIndex属性
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
        ' grdYWRY_PageSize属性
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
        ' htxtSessionId_ZLQX属性
        '----------------------------------------------------------------
        Public Property htxtSessionId_ZLQX() As String
            Get
                htxtSessionId_ZLQX = m_strhtxtSessionId_ZLQX
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSessionId_ZLQX = Value
                Catch ex As Exception
                    m_strhtxtSessionId_ZLQX = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdZLQX_CurrentPageIndex属性
        '----------------------------------------------------------------
        Public Property grdZLQX_CurrentPageIndex() As Integer
            Get
                grdZLQX_CurrentPageIndex = m_intCurrentPageIndex_grdZLQX
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdZLQX = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdZLQX = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdZLQX_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property grdZLQX_SelectedIndex() As Integer
            Get
                grdZLQX_SelectedIndex = m_intSelectedIndex_grdZLQX
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdZLQX = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdZLQX = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdZLQX_PageSize属性
        '----------------------------------------------------------------
        Public Property grdZLQX_PageSize() As Integer
            Get
                grdZLQX_PageSize = m_intPageSize_grdZLQX
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdZLQX = Value
                Catch ex As Exception
                    m_intPageSize_grdZLQX = 0
                End Try
            End Set
        End Property








        '----------------------------------------------------------------
        ' txtKYBH属性
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
        ' txtCCDZ属性
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
        ' txtCCF属性
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
        ' txtSSYJ属性
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
        ' txtHZYJ属性
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
        ' txtYZQN属性
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
        ' txtYYQT属性
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
        ' txtYZDY属性
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
        ' txtMJQN属性
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
        ' txtKYQT属性
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
        ' txtKHDY属性
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
        ' txtZLKS属性
        '----------------------------------------------------------------
        Public Property txtZLKS() As String
            Get
                txtZLKS = Me.m_strtxtZLKS
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtZLKS = Value
                Catch ex As Exception
                    Me.m_strtxtZLKS = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtZLJS属性
        '----------------------------------------------------------------
        Public Property txtZLJS() As String
            Get
                txtZLJS = Me.m_strtxtZLJS
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtZLJS = Value
                Catch ex As Exception
                    Me.m_strtxtZLJS = ""
                End Try
            End Set
        End Property








        '----------------------------------------------------------------
        ' rblYZQC_SelectedIndex属性
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
        ' rblYZLY_SelectedIndex属性
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
        ' rblSYWY_SelectedIndex属性
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
        ' rblMJQC_SelectedIndex属性
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
        ' rblKHLY_SelectedIndex属性
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
        ' rblSDMQ_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property rblSDMQ_SelectedIndex() As Integer
            Get
                rblSDMQ_SelectedIndex = Me.m_intSelectedIndex_rblSDMQ
            End Get
            Set(ByVal Value As Integer)
                Try
                    Me.m_intSelectedIndex_rblSDMQ = Value
                Catch ex As Exception
                    Me.m_intSelectedIndex_rblSDMQ = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' rblDHF_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property rblDHF_SelectedIndex() As Integer
            Get
                rblDHF_SelectedIndex = Me.m_intSelectedIndex_rblDHF
            End Get
            Set(ByVal Value As Integer)
                Try
                    Me.m_intSelectedIndex_rblDHF = Value
                Catch ex As Exception
                    Me.m_intSelectedIndex_rblDHF = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' rblGLF_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property rblGLF_SelectedIndex() As Integer
            Get
                rblGLF_SelectedIndex = Me.m_intSelectedIndex_rblGLF
            End Get
            Set(ByVal Value As Integer)
                Try
                    Me.m_intSelectedIndex_rblGLF = Value
                Catch ex As Exception
                    Me.m_intSelectedIndex_rblGLF = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' rblZLFP_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property rblZLFP_SelectedIndex() As Integer
            Get
                rblZLFP_SelectedIndex = Me.m_intSelectedIndex_rblZLFP
            End Get
            Set(ByVal Value As Integer)
                Try
                    Me.m_intSelectedIndex_rblZLFP = Value
                Catch ex As Exception
                    Me.m_intSelectedIndex_rblZLFP = -1
                End Try
            End Set
        End Property










        '----------------------------------------------------------------
        ' txtJCRQ属性
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
        ' txtHZRQ属性
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
        ' txtHZJE属性
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
        ' htxtHTBZ属性
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
        ' chkHTJC_Checked属性
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
        ' chkHTHZ_Checked属性
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
