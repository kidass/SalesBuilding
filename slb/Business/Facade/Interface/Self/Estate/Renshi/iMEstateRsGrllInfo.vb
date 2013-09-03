Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.BusinessFacade
    ' 类名    ：IMEstateRsGrllInfo
    '
    ' 功能描述： 
    '     estate_rs_grll_info.aspx模块本身恢复现场需要的信息
    '----------------------------------------------------------------
    <Serializable()> Public Class IMEstateRsGrllInfo
        Implements IDisposable

        '----------------------------------------------------------------
        ' 模块属性
        '----------------------------------------------------------------
        Private m_strhtxtDivLeftBody As String              'htxtDivLeftBody
        Private m_strhtxtDivTopBody As String               'htxtDivTopBody
        Private m_strhtxtDivLeftMain As String              'htxtDivLeftMain
        Private m_strhtxtDivTopMain As String               'htxtDivTopMain
        Private m_strhtxtDivLeftXXJL As String              'htxtDivLeftXXJL
        Private m_strhtxtDivTopXXJL As String               'htxtDivTopXXJL
        Private m_strhtxtDivLeftGZJL As String              'htxtDivLeftGZJL
        Private m_strhtxtDivTopGZJL As String               'htxtDivTopGZJL

        Private m_strhtxtUploadFile As String               'htxtUploadFile
        Private m_strhtxtRYXP As String                     'htxtRYXP
        '********************************************************************
        Private m_strhtxtWYBS As String                     'htxtWYBS

        Private m_strtxtRYDM As String                      'txtRYDM
        Private m_strtxtRYXM As String                      'txtRYXM
        Private m_strtxtCSNY As String                      'txtCSNY
        Private m_strtxtMZ As String                        'txtMZ
        Private m_strtxtJG As String                        'txtJG
        Private m_strtxtHJDZ As String                      'txtHJDZ
        Private m_strtxtRDSJ As String                      'txtRDSJ
        Private m_strtxtBYYX As String                      'txtBYYX
        Private m_strtxtBYZY As String                      'txtBYZY
        Private m_strtxtBYSJ As String                      'txtBYSJ
        Private m_strtxtXZDZ As String                      'txtXZDZ
        '********************************************************************
        Private m_strtxtZCQDSJ As String                    'txtZCQDSJ
        Private m_strtxtYWM As String                       'txtYWM
        Private m_strtxtSJHM As String                      'txtSJHM
        Private m_strtxtZZDH As String                      'txtZZDH
        Private m_strtxtSFZH As String                      'txtSFZH
        '********************************************************************
        Private m_strtxtGRJJ As String                      'txtGRJJ
        Private m_strtxtSG As String                        'txtSG
        Private m_strtxtTZ As String                        'txtTZ
        Private m_strtxtXJYQ As String                      'txtXJYQ
        Private m_strtxtYPZW As String                      'txtYPZW
        Private m_strtxtJLBH As String                      'txtJLBH
        Private m_strtxtTBRQ As String                      'txtTBRQ

        'zengxianglin 2009-05-14
        Private m_strhtxtDJRY As String                     'htxtDJRY
        Private m_strtxtDJRY As String                      'txtDJRY
        Private m_strhtxtDJBM As String                     'htxtDJBM
        Private m_strtxtDJBM As String                      'txtDJBM
        Private m_strtxtDJSJ As String                      'txtDJSJ
        Private m_strhtxtNYBM As String                     'htxtNYBM
        Private m_strtxtNYBM As String                      'txtNYBM
        Private m_strtxtXCYJ As String                      'txtXCYJ
        'zengxianglin 2009-05-14

        Private m_intSelectedIndex_rblRYXB As Integer       'rblRYXB_SelectedIndex
        Private m_intSelectedIndex_rblHYZK As Integer       'rblHYZK_SelectedIndex
        Private m_intSelectedIndex_rblSYZK As Integer       'rblSYZK_SelectedIndex
        '********************************************************************
        Private m_intSelectedIndex_rblXZZDS As Integer      'rblXZZDS_SelectedIndex

        Private m_intSelectedIndex_ddlXL As Integer         'ddlXL_SelectedIndex
        Private m_intSelectedIndex_ddlXW As Integer         'ddlXW_SelectedIndex
        Private m_intSelectedIndex_ddlZZMM As Integer       'ddlZZMM_SelectedIndex
        Private m_intSelectedIndex_ddlZYZG As Integer       'ddlZYZG_SelectedIndex
        Private m_intSelectedIndex_ddlJSZC As Integer       'ddlJSZC_SelectedIndex

        Private m_blnChecked_chkHYZK As Boolean             'chkHYZK_Checked
        '********************************************************************
        Private m_blnChecked_chkYZGZ As Boolean             'chkYZGZ_Checked

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
            m_strhtxtDivLeftXXJL = ""
            m_strhtxtDivTopXXJL = ""
            m_strhtxtDivLeftGZJL = ""
            m_strhtxtDivTopGZJL = ""

            m_strhtxtUploadFile = ""
            m_strhtxtRYXP = ""
            '****************************
            m_strhtxtWYBS = ""

            m_strtxtRYDM = ""
            m_strtxtRYXM = ""
            m_strtxtCSNY = ""
            m_strtxtMZ = ""
            m_strtxtJG = ""
            m_strtxtHJDZ = ""
            m_strtxtRDSJ = ""
            m_strtxtBYYX = ""
            m_strtxtBYZY = ""
            m_strtxtBYSJ = ""
            m_strtxtXZDZ = ""
            '****************************
            m_strtxtZCQDSJ = ""
            m_strtxtYWM = ""
            m_strtxtSJHM = ""
            m_strtxtZZDH = ""
            m_strtxtSFZH = ""
            '****************************
            m_strtxtGRJJ = ""
            m_strtxtSG = ""
            m_strtxtTZ = ""
            m_strtxtXJYQ = ""
            m_strtxtYPZW = ""
            m_strtxtJLBH = ""
            m_strtxtTBRQ = ""

            m_intSelectedIndex_rblRYXB = -1
            m_intSelectedIndex_rblHYZK = -1
            m_intSelectedIndex_rblSYZK = -1
            '****************************
            m_intSelectedIndex_rblXZZDS = -1

            m_intSelectedIndex_ddlXL = -1
            m_intSelectedIndex_ddlXW = -1
            m_intSelectedIndex_ddlZZMM = -1
            m_intSelectedIndex_ddlZYZG = -1
            m_intSelectedIndex_ddlJSZC = -1

            m_blnChecked_chkHYZK = False
            '****************************
            m_blnChecked_chkYZGZ = False

            m_strhtxtSessionId_XXJL = ""
            m_intCurrentPageIndex_grdXXJL = 0
            m_intSelectedIndex_grdXXJL = -1
            m_intPageSize_grdXXJL = 30

            m_strhtxtSessionId_GZJL = ""
            m_intCurrentPageIndex_grdGZJL = 0
            m_intSelectedIndex_grdGZJL = -1
            m_intPageSize_grdGZJL = 30

            'zengxianglin 2009-05-14
            m_strhtxtDJRY = ""
            m_strtxtDJRY = ""
            m_strhtxtDJBM = ""
            m_strtxtDJBM = ""
            m_strtxtDJSJ = ""
            m_strhtxtNYBM = ""
            m_strtxtNYBM = ""
            m_strtxtXCYJ = ""
            'zengxianglin 2009-05-14
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
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IMEstateRsGrllInfo)
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
        ' htxtRYXP属性
        '----------------------------------------------------------------
        Public Property htxtRYXP() As String
            Get
                htxtRYXP = m_strhtxtRYXP
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtRYXP = Value
                Catch ex As Exception
                    m_strhtxtRYXP = ""
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
        ' txtGRJJ属性
        '----------------------------------------------------------------
        Public Property txtGRJJ() As String
            Get
                txtGRJJ = m_strtxtGRJJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtGRJJ = Value
                Catch ex As Exception
                    m_strtxtGRJJ = ""
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
        ' txtSG属性
        '----------------------------------------------------------------
        Public Property txtSG() As String
            Get
                txtSG = m_strtxtSG
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtSG = Value
                Catch ex As Exception
                    m_strtxtSG = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtTZ属性
        '----------------------------------------------------------------
        Public Property txtTZ() As String
            Get
                txtTZ = m_strtxtTZ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtTZ = Value
                Catch ex As Exception
                    m_strtxtTZ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtXJYQ属性
        '----------------------------------------------------------------
        Public Property txtXJYQ() As String
            Get
                txtXJYQ = m_strtxtXJYQ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtXJYQ = Value
                Catch ex As Exception
                    m_strtxtXJYQ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtYPZW属性
        '----------------------------------------------------------------
        Public Property txtYPZW() As String
            Get
                txtYPZW = m_strtxtYPZW
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtYPZW = Value
                Catch ex As Exception
                    m_strtxtYPZW = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtJLBH属性
        '----------------------------------------------------------------
        Public Property txtJLBH() As String
            Get
                txtJLBH = m_strtxtJLBH
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJLBH = Value
                Catch ex As Exception
                    m_strtxtJLBH = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtTBRQ属性
        '----------------------------------------------------------------
        Public Property txtTBRQ() As String
            Get
                txtTBRQ = m_strtxtTBRQ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtTBRQ = Value
                Catch ex As Exception
                    m_strtxtTBRQ = ""
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
        ' rblXZZDS_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property rblXZZDS_SelectedIndex() As Integer
            Get
                rblXZZDS_SelectedIndex = m_intSelectedIndex_rblXZZDS
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_rblXZZDS = Value
                Catch ex As Exception
                    m_intSelectedIndex_rblXZZDS = -1
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
        ' chkYZGZ_Checked属性
        '----------------------------------------------------------------
        Public Property chkYZGZ_Checked() As Boolean
            Get
                chkYZGZ_Checked = m_blnChecked_chkYZGZ
            End Get
            Set(ByVal Value As Boolean)
                Try
                    m_blnChecked_chkYZGZ = Value
                Catch ex As Exception
                    m_blnChecked_chkYZGZ = False
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








        'zengxianglin 2009-05-14
        '----------------------------------------------------------------
        ' htxtDJRY属性
        '----------------------------------------------------------------
        Public Property htxtDJRY() As String
            Get
                htxtDJRY = m_strhtxtDJRY
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDJRY = Value
                Catch ex As Exception
                    m_strhtxtDJRY = ""
                End Try
            End Set
        End Property
        'zengxianglin 2009-05-14

        'zengxianglin 2009-05-14
        '----------------------------------------------------------------
        ' txtDJRY属性
        '----------------------------------------------------------------
        Public Property txtDJRY() As String
            Get
                txtDJRY = m_strtxtDJRY
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtDJRY = Value
                Catch ex As Exception
                    m_strtxtDJRY = ""
                End Try
            End Set
        End Property
        'zengxianglin 2009-05-14

        'zengxianglin 2009-05-14
        '----------------------------------------------------------------
        ' htxtDJBM属性
        '----------------------------------------------------------------
        Public Property htxtDJBM() As String
            Get
                htxtDJBM = m_strhtxtDJBM
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDJBM = Value
                Catch ex As Exception
                    m_strhtxtDJBM = ""
                End Try
            End Set
        End Property
        'zengxianglin 2009-05-14

        'zengxianglin 2009-05-14
        '----------------------------------------------------------------
        ' txtDJBM属性
        '----------------------------------------------------------------
        Public Property txtDJBM() As String
            Get
                txtDJBM = m_strtxtDJBM
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtDJBM = Value
                Catch ex As Exception
                    m_strtxtDJBM = ""
                End Try
            End Set
        End Property
        'zengxianglin 2009-05-14

        'zengxianglin 2009-05-14
        '----------------------------------------------------------------
        ' txtDJSJ属性
        '----------------------------------------------------------------
        Public Property txtDJSJ() As String
            Get
                txtDJSJ = m_strtxtDJSJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtDJSJ = Value
                Catch ex As Exception
                    m_strtxtDJSJ = ""
                End Try
            End Set
        End Property
        'zengxianglin 2009-05-14

        'zengxianglin 2009-05-14
        '----------------------------------------------------------------
        ' htxtNYBM属性
        '----------------------------------------------------------------
        Public Property htxtNYBM() As String
            Get
                htxtNYBM = m_strhtxtNYBM
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtNYBM = Value
                Catch ex As Exception
                    m_strhtxtNYBM = ""
                End Try
            End Set
        End Property
        'zengxianglin 2009-05-14

        'zengxianglin 2009-05-14
        '----------------------------------------------------------------
        ' txtNYBM属性
        '----------------------------------------------------------------
        Public Property txtNYBM() As String
            Get
                txtNYBM = m_strtxtNYBM
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtNYBM = Value
                Catch ex As Exception
                    m_strtxtNYBM = ""
                End Try
            End Set
        End Property
        'zengxianglin 2009-05-14

        'zengxianglin 2009-05-14
        '----------------------------------------------------------------
        ' txtXCYJ属性
        '----------------------------------------------------------------
        Public Property txtXCYJ() As String
            Get
                txtXCYJ = m_strtxtXCYJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtXCYJ = Value
                Catch ex As Exception
                    m_strtxtXCYJ = ""
                End Try
            End Set
        End Property
        'zengxianglin 2009-05-14

    End Class

End Namespace
