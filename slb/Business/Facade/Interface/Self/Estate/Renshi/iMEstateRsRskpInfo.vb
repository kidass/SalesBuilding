Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.BusinessFacade
    ' 类名    ：IMEstateRsRskpInfo
    '
    ' 功能描述： 
    '     estate_rs_rskp_info.aspx模块本身恢复现场需要的信息
    '----------------------------------------------------------------
    <Serializable()> Public Class IMEstateRsRskpInfo
        Implements IDisposable

        '----------------------------------------------------------------
        ' 模块属性
        '----------------------------------------------------------------
        Private m_strhtxtDivLeftBody As String              'htxtDivLeftBody
        Private m_strhtxtDivTopBody As String               'htxtDivTopBody
        Private m_strhtxtDivLeftMain As String              'htxtDivLeftMain
        Private m_strhtxtDivTopMain As String               'htxtDivTopMain
        Private m_strhtxtDivLeftJTCY As String              'htxtDivLeftJTCY
        Private m_strhtxtDivTopJTCY As String               'htxtDivTopJTCY
        Private m_strhtxtDivLeftXXJL As String              'htxtDivLeftXXJL
        Private m_strhtxtDivTopXXJL As String               'htxtDivTopXXJL
        Private m_strhtxtDivLeftGZJL As String              'htxtDivLeftGZJL
        Private m_strhtxtDivTopGZJL As String               'htxtDivTopGZJL

        Private m_strhtxtUploadFile As String               'htxtUploadFile
        Private m_strhtxtRYXPWZ As String                   'htxtRYXPWZ
        '********************************************************************
        Private m_strhtxtBM As String                       'htxtBM
        Private m_strhtxtWYBS As String                     'htxtWYBS

        Private m_strtxtRYDM As String                      'txtRYDM
        Private m_strtxtRYXM As String                      'txtRYXM
        Private m_strtxtCSNY As String                      'txtCSNY
        Private m_strtxtMZ As String                        'txtMZ
        Private m_strtxtJG As String                        'txtJG
        Private m_strtxtHJDZ As String                      'txtHJDZ
        Private m_strtxtRDSJ As String                      'txtRDSJ
        Private m_strtxtZJZG As String                      'txtZJZG
        Private m_strtxtBYYX As String                      'txtBYYX
        Private m_strtxtBYZY As String                      'txtBYZY
        Private m_strtxtBYSJ As String                      'txtBYSJ
        Private m_strtxtXZDZ As String                      'txtXZDZ
        Private m_strtxtYJDZ As String                      'txtYJDZ
        Private m_strtxtGRFYKS As String                    'txtGRFYKS
        Private m_strtxtGRFYJS As String                    'txtGRFYJS
        Private m_strtxtGRFYSM As String                    'txtGRFYSM
        Private m_strtxtCYFYSM As String                    'txtCYFYSM
        '********************************************************************
        Private m_strtxtRBDWSJ As String                    'txtRBDWSJ
        Private m_strtxtCJGZSJ As String                    'txtCJGZSJ
        'zengxianglin 2009-01-12
        Private m_strtxtTXSJ As String                      'txtTXSJ
        'zengxianglin 2009-01-12
        Private m_strtxtZCQDSJ As String                    'txtZCQDSJ
        'zengxianglin 2009-01-07
        Private m_strtxtZGQDSJ As String                    'txtZCQDSJ
        'zengxianglin 2009-01-07
        Private m_strtxtYWM As String                       'txtYWM
        Private m_strtxtSJHM As String                      'txtSJHM
        Private m_strtxtZZDH As String                      'txtZZDH
        Private m_strtxtSFZH As String                      'txtSFZH
        Private m_strtxtZZGX As String                      'txtZZGX
        Private m_strtxtBM As String                        'txtBM

        Private m_intSelectedIndex_rblRYXB As Integer       'rblRYXB_SelectedIndex
        Private m_intSelectedIndex_rblHYZK As Integer       'rblHYZK_SelectedIndex
        Private m_intSelectedIndex_rblSYZK As Integer       'rblSYZK_SelectedIndex
        Private m_intSelectedIndex_rblZZQK1 As Integer      'rblZZQK1_SelectedIndex
        Private m_intSelectedIndex_rblZZQK2 As Integer      'rblZZQK2_SelectedIndex
        Private m_intSelectedIndex_rblCYFYZT As Integer     'rblCYFYZT_SelectedIndex
        Private m_intSelectedIndex_rblGRFYZT As Integer     'rblGRFYZT_SelectedIndex
        '********************************************************************
        Private m_intSelectedIndex_rblHKZT As Integer       'rblHKZT_SelectedIndex
        Private m_intSelectedIndex_rblRYQYTX As Integer     'rblRYQYTX_SelectedIndex

        Private m_intSelectedIndex_ddlXL As Integer         'ddlXL_SelectedIndex
        Private m_intSelectedIndex_ddlXW As Integer         'ddlXW_SelectedIndex
        Private m_intSelectedIndex_ddlZZMM As Integer       'ddlZZMM_SelectedIndex
        Private m_intSelectedIndex_ddlZYZG As Integer       'ddlZYZG_SelectedIndex
        Private m_intSelectedIndex_ddlXXLX As Integer       'ddlXXLX_SelectedIndex
        Private m_intSelectedIndex_ddlJSZC As Integer       'ddlJSZC_SelectedIndex

        Private m_blnChecked_chkHYZK As Boolean             'chkHYZK_Checked
        Private m_blnChecked_chkBRSDSZ As Boolean           'chkBRSDSZ_Checked
        Private m_blnChecked_chkSFLDSZ As Boolean           'chkSFLDSZ_Checked
        Private m_blnChecked_chkSFJZGB As Boolean           'chkSFJZGB_Checked
        '********************************************************************
        Private m_blnChecked_chkSFSGGB As Boolean           'chkSFSGGB_Checked
        Private m_blnChecked_chkSFGHCY As Boolean           'chkSFGHCY_Checked

        Private m_strhtxtSessionId_JTCY As String             'htxtSessionId_JTCY
        Private m_intCurrentPageIndex_grdJTCY As Integer      'grdJTCY_CurrentPageIndex
        Private m_intSelectedIndex_grdJTCY As Integer         'grdJTCY_SelectedIndex
        Private m_intPageSize_grdJTCY As Integer              'grdJTCY_PageSize

        Private m_strhtxtSessionId_XXJL As String             'htxtSessionId_XXJL
        Private m_intCurrentPageIndex_grdXXJL As Integer      'grdXXJL_CurrentPageIndex
        Private m_intSelectedIndex_grdXXJL As Integer         'grdXXJL_SelectedIndex
        Private m_intPageSize_grdXXJL As Integer              'grdXXJL_PageSize

        Private m_strhtxtSessionId_GZJL As String             'htxtSessionId_GZJL
        Private m_intCurrentPageIndex_grdGZJL As Integer      'grdGZJL_CurrentPageIndex
        Private m_intSelectedIndex_grdGZJL As Integer         'grdGZJL_SelectedIndex
        Private m_intPageSize_grdGZJL As Integer              'grdGZJL_PageSize











        '----------------------------------------------------------------
        ' 构造函数
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()

            m_strhtxtDivLeftBody = ""
            m_strhtxtDivTopBody = ""
            m_strhtxtDivLeftMain = ""
            m_strhtxtDivTopMain = ""
            m_strhtxtDivLeftJTCY = ""
            m_strhtxtDivTopJTCY = ""
            m_strhtxtDivLeftXXJL = ""
            m_strhtxtDivTopXXJL = ""
            m_strhtxtDivLeftGZJL = ""
            m_strhtxtDivTopGZJL = ""

            m_strhtxtUploadFile = ""
            m_strhtxtRYXPWZ = ""
            '****************************
            m_strhtxtBM = ""
            m_strhtxtWYBS = ""

            m_strtxtRYDM = ""
            m_strtxtRYXM = ""
            m_strtxtCSNY = ""
            m_strtxtMZ = ""
            m_strtxtJG = ""
            m_strtxtHJDZ = ""
            m_strtxtRDSJ = ""
            m_strtxtZJZG = ""
            m_strtxtBYYX = ""
            m_strtxtBYZY = ""
            m_strtxtBYSJ = ""
            m_strtxtXZDZ = ""
            m_strtxtYJDZ = ""
            m_strtxtGRFYKS = ""
            m_strtxtGRFYJS = ""
            m_strtxtGRFYSM = ""
            m_strtxtCYFYSM = ""
            '****************************
            m_strtxtRBDWSJ = ""
            m_strtxtCJGZSJ = ""
            'zengxianglin 2009-01-12
            m_strtxtTXSJ = ""
            'zengxianglin 2009-01-12
            m_strtxtZCQDSJ = ""
            'zengxianglin 2009-01-07
            m_strtxtZGQDSJ = ""
            'zengxianglin 2009-01-07
            m_strtxtYWM = ""
            m_strtxtSJHM = ""
            m_strtxtZZDH = ""
            m_strtxtSFZH = ""
            m_strtxtZZGX = ""
            m_strtxtBM = ""

            m_intSelectedIndex_rblRYXB = -1
            m_intSelectedIndex_rblHYZK = -1
            m_intSelectedIndex_rblSYZK = -1
            m_intSelectedIndex_rblZZQK1 = -1
            m_intSelectedIndex_rblZZQK2 = -1
            m_intSelectedIndex_rblCYFYZT = -1
            m_intSelectedIndex_rblGRFYZT = -1
            '****************************
            m_intSelectedIndex_rblHKZT = -1
            m_intSelectedIndex_rblRYQYTX = -1

            m_intSelectedIndex_ddlXL = -1
            m_intSelectedIndex_ddlXW = -1
            m_intSelectedIndex_ddlZZMM = -1
            m_intSelectedIndex_ddlZYZG = -1
            m_intSelectedIndex_ddlXXLX = -1
            m_intSelectedIndex_ddlJSZC = -1

            m_blnChecked_chkHYZK = False
            m_blnChecked_chkBRSDSZ = False
            m_blnChecked_chkSFLDSZ = False
            m_blnChecked_chkSFJZGB = False
            '****************************
            m_blnChecked_chkSFSGGB = False
            m_blnChecked_chkSFGHCY = False

            m_strhtxtSessionId_JTCY = ""
            m_intCurrentPageIndex_grdJTCY = 0
            m_intSelectedIndex_grdJTCY = -1
            m_intPageSize_grdJTCY = 30

            m_strhtxtSessionId_XXJL = ""
            m_intCurrentPageIndex_grdXXJL = 0
            m_intSelectedIndex_grdXXJL = -1
            m_intPageSize_grdXXJL = 30

            m_strhtxtSessionId_GZJL = ""
            m_intCurrentPageIndex_grdGZJL = 0
            m_intSelectedIndex_grdGZJL = -1
            m_intPageSize_grdGZJL = 30

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
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IMEstateRsRskpInfo)
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
        ' htxtDivLeftJTCY属性
        '----------------------------------------------------------------
        Public Property htxtDivLeftJTCY() As String
            Get
                htxtDivLeftJTCY = m_strhtxtDivLeftJTCY
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivLeftJTCY = Value
                Catch ex As Exception
                    m_strhtxtDivLeftJTCY = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopJTCY属性
        '----------------------------------------------------------------
        Public Property htxtDivTopJTCY() As String
            Get
                htxtDivTopJTCY = m_strhtxtDivTopJTCY
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivTopJTCY = Value
                Catch ex As Exception
                    m_strhtxtDivTopJTCY = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivLeftXXJL属性
        '----------------------------------------------------------------
        Public Property htxtDivLeftXXJL() As String
            Get
                htxtDivLeftXXJL = m_strhtxtDivLeftXXJL
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivLeftXXJL = Value
                Catch ex As Exception
                    m_strhtxtDivLeftXXJL = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopXXJL属性
        '----------------------------------------------------------------
        Public Property htxtDivTopXXJL() As String
            Get
                htxtDivTopXXJL = m_strhtxtDivTopXXJL
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivTopXXJL = Value
                Catch ex As Exception
                    m_strhtxtDivTopXXJL = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivLeftGZJL属性
        '----------------------------------------------------------------
        Public Property htxtDivLeftGZJL() As String
            Get
                htxtDivLeftGZJL = m_strhtxtDivLeftGZJL
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivLeftGZJL = Value
                Catch ex As Exception
                    m_strhtxtDivLeftGZJL = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopGZJL属性
        '----------------------------------------------------------------
        Public Property htxtDivTopGZJL() As String
            Get
                htxtDivTopGZJL = m_strhtxtDivTopGZJL
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivTopGZJL = Value
                Catch ex As Exception
                    m_strhtxtDivTopGZJL = ""
                End Try
            End Set
        End Property











        '----------------------------------------------------------------
        ' htxtUploadFile属性
        '----------------------------------------------------------------
        Public Property htxtUploadFile() As String
            Get
                htxtUploadFile = m_strhtxtUploadFile
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtUploadFile = Value
                Catch ex As Exception
                    m_strhtxtUploadFile = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtRYXPWZ属性
        '----------------------------------------------------------------
        Public Property htxtRYXPWZ() As String
            Get
                htxtRYXPWZ = m_strhtxtRYXPWZ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtRYXPWZ = Value
                Catch ex As Exception
                    m_strhtxtRYXPWZ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtBM属性
        '----------------------------------------------------------------
        Public Property htxtBM() As String
            Get
                htxtBM = m_strhtxtBM
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtBM = Value
                Catch ex As Exception
                    m_strhtxtBM = ""
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
        ' txtRYDM属性
        '----------------------------------------------------------------
        Public Property txtRYDM() As String
            Get
                txtRYDM = m_strtxtRYDM
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtRYDM = Value
                Catch ex As Exception
                    m_strtxtRYDM = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtRYXM属性
        '----------------------------------------------------------------
        Public Property txtRYXM() As String
            Get
                txtRYXM = m_strtxtRYXM
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtRYXM = Value
                Catch ex As Exception
                    m_strtxtRYXM = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtCSNY属性
        '----------------------------------------------------------------
        Public Property txtCSNY() As String
            Get
                txtCSNY = m_strtxtCSNY
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtCSNY = Value
                Catch ex As Exception
                    m_strtxtCSNY = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtMZ属性
        '----------------------------------------------------------------
        Public Property txtMZ() As String
            Get
                txtMZ = m_strtxtMZ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtMZ = Value
                Catch ex As Exception
                    m_strtxtMZ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtJG属性
        '----------------------------------------------------------------
        Public Property txtJG() As String
            Get
                txtJG = m_strtxtJG
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJG = Value
                Catch ex As Exception
                    m_strtxtJG = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtHJDZ属性
        '----------------------------------------------------------------
        Public Property txtHJDZ() As String
            Get
                txtHJDZ = m_strtxtHJDZ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtHJDZ = Value
                Catch ex As Exception
                    m_strtxtHJDZ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtRDSJ属性
        '----------------------------------------------------------------
        Public Property txtRDSJ() As String
            Get
                txtRDSJ = m_strtxtRDSJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtRDSJ = Value
                Catch ex As Exception
                    m_strtxtRDSJ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtZJZG属性
        '----------------------------------------------------------------
        Public Property txtZJZG() As String
            Get
                txtZJZG = m_strtxtZJZG
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtZJZG = Value
                Catch ex As Exception
                    m_strtxtZJZG = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtBYYX属性
        '----------------------------------------------------------------
        Public Property txtBYYX() As String
            Get
                txtBYYX = m_strtxtBYYX
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtBYYX = Value
                Catch ex As Exception
                    m_strtxtBYYX = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtBYZY属性
        '----------------------------------------------------------------
        Public Property txtBYZY() As String
            Get
                txtBYZY = m_strtxtBYZY
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtBYZY = Value
                Catch ex As Exception
                    m_strtxtBYZY = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtBYSJ属性
        '----------------------------------------------------------------
        Public Property txtBYSJ() As String
            Get
                txtBYSJ = m_strtxtBYSJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtBYSJ = Value
                Catch ex As Exception
                    m_strtxtBYSJ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtXZDZ属性
        '----------------------------------------------------------------
        Public Property txtXZDZ() As String
            Get
                txtXZDZ = m_strtxtXZDZ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtXZDZ = Value
                Catch ex As Exception
                    m_strtxtXZDZ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtYJDZ属性
        '----------------------------------------------------------------
        Public Property txtYJDZ() As String
            Get
                txtYJDZ = m_strtxtYJDZ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtYJDZ = Value
                Catch ex As Exception
                    m_strtxtYJDZ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtGRFYKS属性
        '----------------------------------------------------------------
        Public Property txtGRFYKS() As String
            Get
                txtGRFYKS = m_strtxtGRFYKS
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtGRFYKS = Value
                Catch ex As Exception
                    m_strtxtGRFYKS = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtGRFYJS属性
        '----------------------------------------------------------------
        Public Property txtGRFYJS() As String
            Get
                txtGRFYJS = m_strtxtGRFYJS
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtGRFYJS = Value
                Catch ex As Exception
                    m_strtxtGRFYJS = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtGRFYSM属性
        '----------------------------------------------------------------
        Public Property txtGRFYSM() As String
            Get
                txtGRFYSM = m_strtxtGRFYSM
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtGRFYSM = Value
                Catch ex As Exception
                    m_strtxtGRFYSM = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtCYFYSM属性
        '----------------------------------------------------------------
        Public Property txtCYFYSM() As String
            Get
                txtCYFYSM = m_strtxtCYFYSM
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtCYFYSM = Value
                Catch ex As Exception
                    m_strtxtCYFYSM = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtRBDWSJ属性
        '----------------------------------------------------------------
        Public Property txtRBDWSJ() As String
            Get
                txtRBDWSJ = m_strtxtRBDWSJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtRBDWSJ = Value
                Catch ex As Exception
                    m_strtxtRBDWSJ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtCJGZSJ属性
        '----------------------------------------------------------------
        Public Property txtCJGZSJ() As String
            Get
                txtCJGZSJ = m_strtxtCJGZSJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtCJGZSJ = Value
                Catch ex As Exception
                    m_strtxtCJGZSJ = ""
                End Try
            End Set
        End Property

        'zengxianglin 2009-01-12
        '----------------------------------------------------------------
        ' txtTXSJ属性
        '----------------------------------------------------------------
        Public Property txtTXSJ() As String
            Get
                txtTXSJ = m_strtxtTXSJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtTXSJ = Value
                Catch ex As Exception
                    m_strtxtTXSJ = ""
                End Try
            End Set
        End Property
        'zengxianglin 2009-01-12

        '----------------------------------------------------------------
        ' txtZCQDSJ属性
        '----------------------------------------------------------------
        Public Property txtZCQDSJ() As String
            Get
                txtZCQDSJ = m_strtxtZCQDSJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtZCQDSJ = Value
                Catch ex As Exception
                    m_strtxtZCQDSJ = ""
                End Try
            End Set
        End Property

        'zengxianglin 2009-01-07
        '----------------------------------------------------------------
        ' txtZGQDSJ属性
        '----------------------------------------------------------------
        Public Property txtZGQDSJ() As String
            Get
                txtZGQDSJ = m_strtxtZGQDSJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtZGQDSJ = Value
                Catch ex As Exception
                    m_strtxtZGQDSJ = ""
                End Try
            End Set
        End Property
        'zengxianglin 2009-01-07

        '----------------------------------------------------------------
        ' txtYWM属性
        '----------------------------------------------------------------
        Public Property txtYWM() As String
            Get
                txtYWM = m_strtxtYWM
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtYWM = Value
                Catch ex As Exception
                    m_strtxtYWM = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtSJHM属性
        '----------------------------------------------------------------
        Public Property txtSJHM() As String
            Get
                txtSJHM = m_strtxtSJHM
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtSJHM = Value
                Catch ex As Exception
                    m_strtxtSJHM = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtZZDH属性
        '----------------------------------------------------------------
        Public Property txtZZDH() As String
            Get
                txtZZDH = m_strtxtZZDH
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtZZDH = Value
                Catch ex As Exception
                    m_strtxtZZDH = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtSFZH属性
        '----------------------------------------------------------------
        Public Property txtSFZH() As String
            Get
                txtSFZH = m_strtxtSFZH
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtSFZH = Value
                Catch ex As Exception
                    m_strtxtSFZH = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtZZGX属性
        '----------------------------------------------------------------
        Public Property txtZZGX() As String
            Get
                txtZZGX = m_strtxtZZGX
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtZZGX = Value
                Catch ex As Exception
                    m_strtxtZZGX = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtBM属性
        '----------------------------------------------------------------
        Public Property txtBM() As String
            Get
                txtBM = m_strtxtBM
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtBM = Value
                Catch ex As Exception
                    m_strtxtBM = ""
                End Try
            End Set
        End Property












        '----------------------------------------------------------------
        ' rblRYXB_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property rblRYXB_SelectedIndex() As Integer
            Get
                rblRYXB_SelectedIndex = m_intSelectedIndex_rblRYXB
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_rblRYXB = Value
                Catch ex As Exception
                    m_intSelectedIndex_rblRYXB = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' rblHYZK_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property rblHYZK_SelectedIndex() As Integer
            Get
                rblHYZK_SelectedIndex = m_intSelectedIndex_rblHYZK
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_rblHYZK = Value
                Catch ex As Exception
                    m_intSelectedIndex_rblHYZK = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' rblSYZK_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property rblSYZK_SelectedIndex() As Integer
            Get
                rblSYZK_SelectedIndex = m_intSelectedIndex_rblSYZK
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_rblSYZK = Value
                Catch ex As Exception
                    m_intSelectedIndex_rblSYZK = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' rblZZQK1_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property rblZZQK1_SelectedIndex() As Integer
            Get
                rblZZQK1_SelectedIndex = m_intSelectedIndex_rblZZQK1
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_rblZZQK1 = Value
                Catch ex As Exception
                    m_intSelectedIndex_rblZZQK1 = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' rblZZQK2_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property rblZZQK2_SelectedIndex() As Integer
            Get
                rblZZQK2_SelectedIndex = m_intSelectedIndex_rblZZQK2
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_rblZZQK2 = Value
                Catch ex As Exception
                    m_intSelectedIndex_rblZZQK2 = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' rblCYFYZT_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property rblCYFYZT_SelectedIndex() As Integer
            Get
                rblCYFYZT_SelectedIndex = m_intSelectedIndex_rblCYFYZT
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_rblCYFYZT = Value
                Catch ex As Exception
                    m_intSelectedIndex_rblCYFYZT = -1
                End Try
            End Set
        End Property



        '----------------------------------------------------------------
        ' rblGRFYZT_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property rblGRFYZT_SelectedIndex() As Integer
            Get
                rblGRFYZT_SelectedIndex = m_intSelectedIndex_rblGRFYZT
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_rblGRFYZT = Value
                Catch ex As Exception
                    m_intSelectedIndex_rblGRFYZT = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' rblHKZT_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property rblHKZT_SelectedIndex() As Integer
            Get
                rblHKZT_SelectedIndex = m_intSelectedIndex_rblHKZT
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_rblHKZT = Value
                Catch ex As Exception
                    m_intSelectedIndex_rblHKZT = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' rblRYQYTX_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property rblRYQYTX_SelectedIndex() As Integer
            Get
                rblRYQYTX_SelectedIndex = m_intSelectedIndex_rblRYQYTX
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_rblRYQYTX = Value
                Catch ex As Exception
                    m_intSelectedIndex_rblRYQYTX = -1
                End Try
            End Set
        End Property












        '----------------------------------------------------------------
        ' ddlXL_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property ddlXL_SelectedIndex() As Integer
            Get
                ddlXL_SelectedIndex = m_intSelectedIndex_ddlXL
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlXL = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlXL = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' ddlXW_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property ddlXW_SelectedIndex() As Integer
            Get
                ddlXW_SelectedIndex = m_intSelectedIndex_ddlXW
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlXW = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlXW = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' ddlZZMM_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property ddlZZMM_SelectedIndex() As Integer
            Get
                ddlZZMM_SelectedIndex = m_intSelectedIndex_ddlZZMM
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlZZMM = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlZZMM = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' ddlZYZG_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property ddlZYZG_SelectedIndex() As Integer
            Get
                ddlZYZG_SelectedIndex = m_intSelectedIndex_ddlZYZG
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlZYZG = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlZYZG = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' ddlXXLX_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property ddlXXLX_SelectedIndex() As Integer
            Get
                ddlXXLX_SelectedIndex = m_intSelectedIndex_ddlXXLX
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlXXLX = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlXXLX = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' ddlJSZC_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property ddlJSZC_SelectedIndex() As Integer
            Get
                ddlJSZC_SelectedIndex = m_intSelectedIndex_ddlJSZC
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlJSZC = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlJSZC = -1
                End Try
            End Set
        End Property












        '----------------------------------------------------------------
        ' chkHYZK_Checked属性
        '----------------------------------------------------------------
        Public Property chkHYZK_Checked() As Boolean
            Get
                chkHYZK_Checked = m_blnChecked_chkHYZK
            End Get
            Set(ByVal Value As Boolean)
                Try
                    m_blnChecked_chkHYZK = Value
                Catch ex As Exception
                    m_blnChecked_chkHYZK = False
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' chkBRSDSZ_Checked属性
        '----------------------------------------------------------------
        Public Property chkBRSDSZ_Checked() As Boolean
            Get
                chkBRSDSZ_Checked = m_blnChecked_chkBRSDSZ
            End Get
            Set(ByVal Value As Boolean)
                Try
                    m_blnChecked_chkBRSDSZ = Value
                Catch ex As Exception
                    m_blnChecked_chkBRSDSZ = False
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' chkSFLDSZ_Checked属性
        '----------------------------------------------------------------
        Public Property chkSFLDSZ_Checked() As Boolean
            Get
                chkSFLDSZ_Checked = m_blnChecked_chkSFLDSZ
            End Get
            Set(ByVal Value As Boolean)
                Try
                    m_blnChecked_chkSFLDSZ = Value
                Catch ex As Exception
                    m_blnChecked_chkSFLDSZ = False
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' chkSFJZGB_Checked属性
        '----------------------------------------------------------------
        Public Property chkSFJZGB_Checked() As Boolean
            Get
                chkSFJZGB_Checked = m_blnChecked_chkSFJZGB
            End Get
            Set(ByVal Value As Boolean)
                Try
                    m_blnChecked_chkSFJZGB = Value
                Catch ex As Exception
                    m_blnChecked_chkSFJZGB = False
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' chkSFSGGB_Checked属性
        '----------------------------------------------------------------
        Public Property chkSFSGGB_Checked() As Boolean
            Get
                chkSFSGGB_Checked = m_blnChecked_chkSFSGGB
            End Get
            Set(ByVal Value As Boolean)
                Try
                    m_blnChecked_chkSFSGGB = Value
                Catch ex As Exception
                    m_blnChecked_chkSFSGGB = False
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' chkSFGHCY_Checked属性
        '----------------------------------------------------------------
        Public Property chkSFGHCY_Checked() As Boolean
            Get
                chkSFGHCY_Checked = m_blnChecked_chkSFGHCY
            End Get
            Set(ByVal Value As Boolean)
                Try
                    m_blnChecked_chkSFGHCY = Value
                Catch ex As Exception
                    m_blnChecked_chkSFGHCY = False
                End Try
            End Set
        End Property













        '----------------------------------------------------------------
        ' htxtSessionId_JTCY属性
        '----------------------------------------------------------------
        Public Property htxtSessionId_JTCY() As String
            Get
                htxtSessionId_JTCY = m_strhtxtSessionId_JTCY
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSessionId_JTCY = Value
                Catch ex As Exception
                    m_strhtxtSessionId_JTCY = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdJTCY_CurrentPageIndex属性
        '----------------------------------------------------------------
        Public Property grdJTCY_CurrentPageIndex() As Integer
            Get
                grdJTCY_CurrentPageIndex = m_intCurrentPageIndex_grdJTCY
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdJTCY = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdJTCY = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdJTCY_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property grdJTCY_SelectedIndex() As Integer
            Get
                grdJTCY_SelectedIndex = m_intSelectedIndex_grdJTCY
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdJTCY = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdJTCY = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdJTCY_PageSize属性
        '----------------------------------------------------------------
        Public Property grdJTCY_PageSize() As Integer
            Get
                grdJTCY_PageSize = m_intPageSize_grdJTCY
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdJTCY = Value
                Catch ex As Exception
                    m_intPageSize_grdJTCY = 0
                End Try
            End Set
        End Property











        '----------------------------------------------------------------
        ' htxtSessionId_XXJL属性
        '----------------------------------------------------------------
        Public Property htxtSessionId_XXJL() As String
            Get
                htxtSessionId_XXJL = m_strhtxtSessionId_XXJL
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSessionId_XXJL = Value
                Catch ex As Exception
                    m_strhtxtSessionId_XXJL = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdXXJL_CurrentPageIndex属性
        '----------------------------------------------------------------
        Public Property grdXXJL_CurrentPageIndex() As Integer
            Get
                grdXXJL_CurrentPageIndex = m_intCurrentPageIndex_grdXXJL
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdXXJL = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdXXJL = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdXXJL_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property grdXXJL_SelectedIndex() As Integer
            Get
                grdXXJL_SelectedIndex = m_intSelectedIndex_grdXXJL
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdXXJL = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdXXJL = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdXXJL_PageSize属性
        '----------------------------------------------------------------
        Public Property grdXXJL_PageSize() As Integer
            Get
                grdXXJL_PageSize = m_intPageSize_grdXXJL
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdXXJL = Value
                Catch ex As Exception
                    m_intPageSize_grdXXJL = 0
                End Try
            End Set
        End Property










        '----------------------------------------------------------------
        ' htxtSessionId_GZJL属性
        '----------------------------------------------------------------
        Public Property htxtSessionId_GZJL() As String
            Get
                htxtSessionId_GZJL = m_strhtxtSessionId_GZJL
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSessionId_GZJL = Value
                Catch ex As Exception
                    m_strhtxtSessionId_GZJL = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdGZJL_CurrentPageIndex属性
        '----------------------------------------------------------------
        Public Property grdGZJL_CurrentPageIndex() As Integer
            Get
                grdGZJL_CurrentPageIndex = m_intCurrentPageIndex_grdGZJL
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdGZJL = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdGZJL = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdGZJL_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property grdGZJL_SelectedIndex() As Integer
            Get
                grdGZJL_SelectedIndex = m_intSelectedIndex_grdGZJL
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdGZJL = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdGZJL = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdGZJL_PageSize属性
        '----------------------------------------------------------------
        Public Property grdGZJL_PageSize() As Integer
            Get
                grdGZJL_PageSize = m_intPageSize_grdGZJL
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdGZJL = Value
                Catch ex As Exception
                    m_intPageSize_grdGZJL = 0
                End Try
            End Set
        End Property

    End Class

End Namespace
