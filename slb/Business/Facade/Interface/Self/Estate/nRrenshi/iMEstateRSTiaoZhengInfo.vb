Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.BusinessFacade
    ' 类名    ：IMEstateRSTiaoZhengInfo
    '
    ' 功能描述： 
    '     estate_rs_ruzhi_info.aspx模块本身恢复现场需要的信息
    '----------------------------------------------------------------
    <Serializable()> Public Class IMEstateRSTiaoZhengInfo
        Implements IDisposable

        '----------------------------------------------------------------
        '
        '----------------------------------------------------------------
        Private m_strhtxtEditMode As String               'htxtEditMode
        Private m_strhtxtEditType As String               'htxtEditType
        Private m_strhtxtEnforeEdit As String             'htxtEnforeEdit
        Private m_strhtxtZWNRFileName As String           'htxtZWNRFileName

        Private m_objDataSet_FJ As Josco.JSOA.Common.Data.FlowData
        Private m_strhtxtSessionIDFJ As String            'htxtSessionIDFJ
        Private m_strhtxtFJSort As String                 'htxtFJSort
        Private m_strhtxtFJSortColumnIndex As String      'htxtFJSortColumnIndex
        Private m_strhtxtFJSortType As String             'htxtFJSortType
        Private m_intPageSize_grdFJ As Integer            'grdFJ_PageSize
        Private m_intSelectedIndex_grdFJ As Integer       'grdFJ_SelectedIndex
        Private m_intCurrentPageIndex_grdFJ As Integer    'grdFJ_CurrentPageIndex

        Private m_objDataSet_XGWJ As Josco.JSOA.Common.Data.FlowData
        Private m_strhtxtSessionIDXGWJ As String          'htxtSessionIDXGWJ
        Private m_strhtxtXGWJSort As String               'htxtXGWJSort
        Private m_strhtxtXGWJSortColumnIndex As String    'htxtXGWJSortColumnIndex
        Private m_strhtxtXGWJSortType As String           'htxtXGWJSortType
        Private m_intPageSize_grdXGWJ As Integer          'grdXGWJ_PageSize
        Private m_intSelectedIndex_grdXGWJ As Integer     'grdXGWJ_SelectedIndex
        Private m_intCurrentPageIndex_grdXGWJ As Integer  'grdXGWJ_CurrentPageIndex

        Private m_objDataSet_RYXX As Josco.JSOA.Common.Data.estateRenshiXingyeData
        Private m_strhtxtSessionIDRYXX As String          'htxtSessionIDRYXX
        Private m_strhtxtRYXXSort As String               'htxtRYXXSort
        Private m_strhtxtRYXXSortColumnIndex As String    'htxtRYXXSortColumnIndex
        Private m_strhtxtRYXXSortType As String           'htxtRYXXSortType
        Private m_intPageSize_grdRYXX As Integer          'grdRYXX_PageSize
        Private m_intSelectedIndex_grdRYXX As Integer     'grdRYXX_SelectedIndex
        Private m_intCurrentPageIndex_grdRYXX As Integer  'grdRYXX_CurrentPageIndex

        Private m_strhtxtDivLeftRYXX As String            'htxtDivLeftRYXX
        Private m_strhtxtDivTopRYXX As String             'htxtDivTopRYXX
        Private m_strhtxtDivLeftXGWJ As String            'htxtDivLeftXGWJ
        Private m_strhtxtDivTopXGWJ As String             'htxtDivTopXGWJ
        Private m_strhtxtDivLeftFJ As String              'htxtDivLeftFJ
        Private m_strhtxtDivTopFJ As String               'htxtDivTopFJ
        Private m_strhtxtDivLeftQFYJ As String            'htxtDivLeftQFYJ
        Private m_strhtxtDivTopQFYJ As String             'htxtDivTopQFYJ
        Private m_strhtxtDivLeftFHYJ As String            'htxtDivLeftFHYJ
        Private m_strhtxtDivTopFHYJ As String             'htxtDivTopFHYJ
        Private m_strhtxtDivLeftSHYJ As String            'htxtDivLeftSHYJ
        Private m_strhtxtDivTopSHYJ As String             'htxtDivTopSHYJ
        Private m_strhtxtDivLeftHQYJ As String            'htxtDivLeftHQYJ
        Private m_strhtxtDivTopHQYJ As String             'htxtDivTopHQYJ
        Private m_strhtxtDivLeftContent As String         'htxtDivLeftContent
        Private m_strhtxtDivTopContent As String          'htxtDivTopContent
        Private m_strhtxtDivLeftBody As String            'htxtDivLeftBody
        Private m_strhtxtDivTopBody As String             'htxtDivTopBody

        Private m_strhtxtSelectMenuID As String           'htxtSelectMenuID

        '----------------------------------------------------------------
        'asp:textbox(本界面负责输入的内容)
        '----------------------------------------------------------------
        Private m_intSelectedIndex_ddlJJCD As Integer    'ddlJJCD
        Private m_intSelectedIndex_ddlMMDJ As Integer    'ddlMMDJ
        Private m_strtxtJGDZ As String                   'txtJGDZ
        Private m_strtxtWJNF As String                   'txtWJNF
        Private m_strtxtWJXH As String                   'txtWJXH
        Private m_strtxtWJBT As String                   'txtWJBT
        Private m_strtxtDBRS As String                   'txtDBRS
        Private m_strtxtBZXX As String                   'txtBZXX
        Private m_blnChecked_chkDDSZ As Boolean          'chkDDSZ
        Private m_strtxtJBDW As String                   'txtJBDW
        Private m_strtxtJBRY As String                   'txtJBRY
        Private m_strtxtJBRQ As String                   'txtJBRQ
        Private m_strtxtLSH As String                    'txtLSH
        Private m_strhtxtWJBS As String                  'htxtWJBS
        Private m_strhtxtRYXM As String                  'htxtRYXM

        Private m_strtxtJLBH As String                   'txtJLBH
        Private m_strtxtRYDM As String                   'txtRYDM
        Private m_strtxtRYXM As String                   'txtRYXM
        Private m_strtxtRYNN As String                   'txtRYNN
        Private m_strtxtNFPBM As String                  'txtNFPBM
        Private m_strtxtNDRZW As String                  'txtNDRZW
        Private m_strtxtNBDRQ As String                  'txtNBDRQ
        Private m_strtxtZPSM As String                   'txtZPSM
        Private m_strtxtXYRYS As String                  'txtXYRYS
        Private m_strtxtDBRYS As String                  'txtDBRYS
        Private m_intSelectedIndex_rblRYXB As Integer    'rblRYXB
        Private m_intSelectedIndex_ddlXL As Integer      'ddlXL
        Private m_intSelectedIndex_rblSXRQ As Integer    'rblSXRQ

        Private m_strtxtRQ As String                   'txtRQ
        Private m_strtxtSFZHM As String                   'txtSFZHM
        Private m_strtxtBMJL As String                   'txtBMJL
        Private m_strtxtWLJNFS As String                   'txtWLJNFS
        Private m_strtxtSPSM As String                   'txtSPSM
        Private m_intSelectedIndex_ddlZPQD As Integer      'ddlZPQD
        Private m_intSelectedIndex_ddlZJDM As Integer      'ddlZJDM
        Private m_intSelectedIndex_ddlYDYY As Integer      'ddlYDYY

        Private m_intSelectedIndex_rblRYLX As Integer      'rblRYLX
        Private m_strtxtTDBH As String                   'txtTDBH
        Private m_strtxtLXDH As String                   'txtLXDH
        Private m_strhtxtBZXL As String                   'htxtBZXL
        Private m_strhhtxtSSDW As String                   'htxtSSDW


        Private m_strtxtYZJMC As String   'txtYZJMC
        Private m_strtxtYBMMC As String   'txtYBMMC
        'txtNDRZW As String   .txtNDRZW
        Private m_strtxtYTD As String   'txtYTD
        Private m_strtxtYRYZT As String   'txtYRYZT
        Private m_strtxtYZBQK As String   'txtYZBQK
        Private m_strhtxtYZJDM As String   'htxtYZJDM.Value
        Private m_strhtxtYBMDM As String   'htxtYBMDM.Value
        Private m_strhtxtYZGTD As String   'htxtYZGTD.Value
        Private m_strhtxtYXGTD As String   'htxtYXGTD.Value

        Private m_strtxtSSDW As String   'txtSSDW
        Private m_strhtxtSSDW As String   'htxtSSDW
        Private m_strhtxtZGTD As String   'htxtZGTD
        Private m_strhtxtXGTD As String   'htxtXGTD

        Private m_intSelectedIndex_rblRYZT As Integer   'rblRYZT
        Private m_intSelectedIndex_rblSFZB As Integer   'rblSFZB
        Private m_intSelectedIndex_lstZGTD As Integer       'lstZGTD_SelectedIndex
        Private m_intSelectedIndex_lstXGTD As Integer       'lstXGTD_SelectedIndex

        Private m_strtxtYWYBS As String   'txtYWYBS
        Private m_strtxtSFJZ As String   'txtSFJZ
        Private m_strtxtRTLX As String   'txtRTLX
        Private m_strtxtBZXL As String   'txtBZXL
        Private m_strtxtRTLXMC As String   'txtRTLXMC
        Private m_strtxtZGDWDM As String   'txtZGDWDM
        Private m_strtxtZGDWMC As String   'txtZGDWMC
        Private m_strtxtSJLD As String   'txtSJLD
        Private m_strtxtSJLDMC As String   'txtSJLDMC
        Private m_strhtxtSessionId_TDZH As String   'htxtSessionId_TDZH
        Private m_strhtxtSessionId_YTDZH As String   'htxtSessionId_YTDZH



        '----------------------------------------------------------------
        ' 构造函数
        '----------------------------------------------------------------
        Public Sub New()

            MyBase.New()

            m_strhtxtEditMode = ""
            m_strhtxtEditType = ""
            m_strhtxtEnforeEdit = ""
            m_strhtxtZWNRFileName = ""
            m_strhtxtSessionIDFJ = ""
            m_strhtxtSessionIDXGWJ = ""

            m_strhtxtFJSort = ""
            m_strhtxtFJSortColumnIndex = ""
            m_strhtxtFJSortType = ""
            m_intSelectedIndex_grdFJ = -1
            m_intPageSize_grdFJ = 30
            m_intCurrentPageIndex_grdFJ = 0

            m_strhtxtXGWJSort = ""
            m_strhtxtXGWJSortColumnIndex = ""
            m_strhtxtXGWJSortType = ""
            m_intSelectedIndex_grdXGWJ = -1
            m_intPageSize_grdXGWJ = 30
            m_intCurrentPageIndex_grdXGWJ = 0

            m_strhtxtRYXXSort = ""
            m_strhtxtRYXXSortColumnIndex = ""
            m_strhtxtRYXXSortType = ""
            m_intSelectedIndex_grdRYXX = -1
            m_intPageSize_grdRYXX = 30
            m_intCurrentPageIndex_grdRYXX = 0

            m_strhtxtDivLeftRYXX = ""
            m_strhtxtDivTopRYXX = ""
            m_strhtxtDivLeftXGWJ = ""
            m_strhtxtDivTopXGWJ = ""
            m_strhtxtDivLeftFJ = ""
            m_strhtxtDivTopFJ = ""
            m_strhtxtDivLeftSHYJ = ""
            m_strhtxtDivTopSHYJ = ""
            m_strhtxtDivLeftHQYJ = ""
            m_strhtxtDivTopHQYJ = ""
            m_strhtxtDivLeftFHYJ = ""
            m_strhtxtDivTopFHYJ = ""
            m_strhtxtDivLeftQFYJ = ""
            m_strhtxtDivTopQFYJ = ""
            m_strhtxtDivLeftContent = ""
            m_strhtxtDivTopContent = ""
            m_strhtxtDivLeftBody = ""
            m_strhtxtDivTopBody = ""

            m_strhtxtSelectMenuID = ""

            m_intSelectedIndex_ddlJJCD = -1
            m_intSelectedIndex_ddlMMDJ = -1
            m_strtxtJGDZ = ""
            m_strtxtWJNF = ""
            m_strtxtWJBT = ""
            m_strtxtDBRS = ""
            m_strtxtBZXX = ""
            m_strtxtJBDW = ""
            m_strtxtJBRY = ""
            m_strtxtJBRQ = ""
            m_strtxtRQ = ""
            m_strtxtLSH = ""
            m_strhtxtWJBS = ""
            m_strhtxtRYXM = ""
            m_blnChecked_chkDDSZ = False

            m_objDataSet_RYXX = Nothing
            m_objDataSet_XGWJ = Nothing
            m_objDataSet_FJ = Nothing

            m_strtxtYWYBS = ""
            m_strtxtJLBH = ""
            m_strtxtRYDM = ""
            m_strtxtRYXM = ""
            m_strtxtRYNN = ""
            m_strtxtNFPBM = ""
            m_strtxtNDRZW = ""
            m_strtxtNBDRQ = ""
            m_strtxtZPSM = ""
            m_strtxtXYRYS = ""
            m_strtxtDBRYS = ""
            m_intSelectedIndex_rblRYXB = -1
            m_intSelectedIndex_ddlXL = -1
            m_intSelectedIndex_rblSXRQ = -1

            m_strtxtSFZHM = ""
            m_strtxtBMJL = ""
            m_strtxtWLJNFS = ""
            m_strtxtSPSM = ""
            m_intSelectedIndex_ddlZPQD = -1
            m_intSelectedIndex_ddlZJDM = -1
            m_intSelectedIndex_ddlYDYY = -1

            m_intSelectedIndex_rblRYLX = -1
            m_strtxtTDBH = ""
            m_strtxtLXDH = ""
            m_strhtxtBZXL = ""
            m_strhhtxtSSDW = ""



            m_strtxtYZJMC = ""
            m_strtxtYBMMC = ""
            m_strtxtYTD = ""
            m_strtxtYRYZT = ""
            m_strtxtYZBQK = ""
            m_strhtxtYZJDM = ""
            m_strhtxtYBMDM = ""
            m_strhtxtYZGTD = ""
            m_strhtxtYXGTD = ""
            m_strtxtSSDW = ""
            m_strhtxtSSDW = ""
            m_strhtxtZGTD = ""
            m_strhtxtXGTD = ""

            m_strtxtSFJZ = ""
            m_strtxtRTLX = ""
            m_strtxtBZXL = ""
            m_strtxtRTLXMC = ""
            m_strtxtZGDWDM = ""
            m_strtxtZGDWMC = ""
            m_strtxtSJLD = ""
            m_strtxtSJLDMC = ""
            m_strhtxtSessionId_TDZH = ""
            m_strhtxtSessionId_YTDZH = ""

            m_intSelectedIndex_rblRYZT = -1
            m_intSelectedIndex_rblRYZT = -1
            m_intSelectedIndex_lstZGTD = -1
            m_intSelectedIndex_lstXGTD = -1


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
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IMEstateRSTiaoZhengInfo)
            Try
                If Not (obj Is Nothing) Then
                    obj.Dispose()
                End If
            Catch ex As Exception
            End Try
            obj = Nothing
        End Sub










        '----------------------------------------------------------------
        ' lstZGTD_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property lstZGTD_SelectedIndex() As Integer
            Get
                lstZGTD_SelectedIndex = m_intSelectedIndex_lstZGTD
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_lstZGTD = Value
                Catch ex As Exception
                    m_intSelectedIndex_lstZGTD = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' lstXGTD_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property lstXGTD_SelectedIndex() As Integer
            Get
                lstXGTD_SelectedIndex = m_intSelectedIndex_lstXGTD
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_lstXGTD = Value
                Catch ex As Exception
                    m_intSelectedIndex_lstXGTD = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtEditMode属性
        '----------------------------------------------------------------
        Public Property htxtEditMode() As String
            Get
                htxtEditMode = m_strhtxtEditMode
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtEditMode = Value
                Catch ex As Exception
                    m_strhtxtEditMode = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtEditType属性
        '----------------------------------------------------------------
        Public Property htxtEditType() As String
            Get
                htxtEditType = m_strhtxtEditType
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtEditType = Value
                Catch ex As Exception
                    m_strhtxtEditType = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtEnforeEdit属性
        '----------------------------------------------------------------
        Public Property htxtEnforeEdit() As String
            Get
                htxtEnforeEdit = m_strhtxtEnforeEdit
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtEnforeEdit = Value
                Catch ex As Exception
                    m_strhtxtEnforeEdit = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtZWNRFileName属性
        '----------------------------------------------------------------
        Public Property htxtZWNRFileName() As String
            Get
                htxtZWNRFileName = m_strhtxtZWNRFileName
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtZWNRFileName = Value
                Catch ex As Exception
                    m_strhtxtZWNRFileName = ""
                End Try
            End Set
        End Property











        '----------------------------------------------------------------
        ' htxtSessionIDFJ属性
        '----------------------------------------------------------------
        Public Property htxtSessionIDFJ() As String
            Get
                htxtSessionIDFJ = m_strhtxtSessionIDFJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSessionIDFJ = Value
                Catch ex As Exception
                    m_strhtxtSessionIDFJ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtSessionIDXGWJ属性
        '----------------------------------------------------------------
        Public Property htxtSessionIDXGWJ() As String
            Get
                htxtSessionIDXGWJ = m_strhtxtSessionIDXGWJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSessionIDXGWJ = Value
                Catch ex As Exception
                    m_strhtxtSessionIDXGWJ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtSessionIDRYXX属性
        '----------------------------------------------------------------
        Public Property htxtSessionIDRYXX() As String
            Get
                htxtSessionIDRYXX = m_strhtxtSessionIDRYXX
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSessionIDRYXX = Value
                Catch ex As Exception
                    m_strhtxtSessionIDRYXX = ""
                End Try
            End Set
        End Property











        '----------------------------------------------------------------
        ' htxtFJSort属性
        '----------------------------------------------------------------
        Public Property htxtFJSort() As String
            Get
                htxtFJSort = m_strhtxtFJSort
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtFJSort = Value
                Catch ex As Exception
                    m_strhtxtFJSort = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtFJSortColumnIndex属性
        '----------------------------------------------------------------
        Public Property htxtFJSortColumnIndex() As String
            Get
                htxtFJSortColumnIndex = m_strhtxtFJSortColumnIndex
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtFJSortColumnIndex = Value
                Catch ex As Exception
                    m_strhtxtFJSortColumnIndex = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtFJSortType属性
        '----------------------------------------------------------------
        Public Property htxtFJSortType() As String
            Get
                htxtFJSortType = m_strhtxtFJSortType
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtFJSortType = Value
                Catch ex As Exception
                    m_strhtxtFJSortType = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdFJ_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property grdFJ_SelectedIndex() As Integer
            Get
                grdFJ_SelectedIndex = m_intSelectedIndex_grdFJ
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdFJ = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdFJ = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdFJ_PageSize属性
        '----------------------------------------------------------------
        Public Property grdFJ_PageSize() As Integer
            Get
                grdFJ_PageSize = m_intPageSize_grdFJ
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdFJ = Value
                Catch ex As Exception
                    m_intPageSize_grdFJ = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdFJ_CurrentPageIndex属性
        '----------------------------------------------------------------
        Public Property grdFJ_CurrentPageIndex() As Integer
            Get
                grdFJ_CurrentPageIndex = m_intCurrentPageIndex_grdFJ
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdFJ = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdFJ = -1
                End Try
            End Set
        End Property












        '----------------------------------------------------------------
        ' htxtXGWJSort属性
        '----------------------------------------------------------------
        Public Property htxtXGWJSort() As String
            Get
                htxtXGWJSort = m_strhtxtXGWJSort
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtXGWJSort = Value
                Catch ex As Exception
                    m_strhtxtXGWJSort = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtXGWJSortColumnIndex属性
        '----------------------------------------------------------------
        Public Property htxtXGWJSortColumnIndex() As String
            Get
                htxtXGWJSortColumnIndex = m_strhtxtXGWJSortColumnIndex
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtXGWJSortColumnIndex = Value
                Catch ex As Exception
                    m_strhtxtXGWJSortColumnIndex = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtXGWJSortType属性
        '----------------------------------------------------------------
        Public Property htxtXGWJSortType() As String
            Get
                htxtXGWJSortType = m_strhtxtXGWJSortType
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtXGWJSortType = Value
                Catch ex As Exception
                    m_strhtxtXGWJSortType = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdXGWJ_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property grdXGWJ_SelectedIndex() As Integer
            Get
                grdXGWJ_SelectedIndex = m_intSelectedIndex_grdXGWJ
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdXGWJ = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdXGWJ = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdXGWJ_PageSize属性
        '----------------------------------------------------------------
        Public Property grdXGWJ_PageSize() As Integer
            Get
                grdXGWJ_PageSize = m_intPageSize_grdXGWJ
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdXGWJ = Value
                Catch ex As Exception
                    m_intPageSize_grdXGWJ = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdXGWJ_CurrentPageIndex属性
        '----------------------------------------------------------------
        Public Property grdXGWJ_CurrentPageIndex() As Integer
            Get
                grdXGWJ_CurrentPageIndex = m_intCurrentPageIndex_grdXGWJ
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdXGWJ = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdXGWJ = -1
                End Try
            End Set
        End Property














        '----------------------------------------------------------------
        ' htxtRYXXSort属性
        '----------------------------------------------------------------
        Public Property htxtRYXXSort() As String
            Get
                htxtRYXXSort = m_strhtxtRYXXSort
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtRYXXSort = Value
                Catch ex As Exception
                    m_strhtxtRYXXSort = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtRYXXSortColumnIndex属性
        '----------------------------------------------------------------
        Public Property htxtRYXXSortColumnIndex() As String
            Get
                htxtRYXXSortColumnIndex = m_strhtxtRYXXSortColumnIndex
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtRYXXSortColumnIndex = Value
                Catch ex As Exception
                    m_strhtxtRYXXSortColumnIndex = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtRYXXSortType属性
        '----------------------------------------------------------------
        Public Property htxtRYXXSortType() As String
            Get
                htxtRYXXSortType = m_strhtxtRYXXSortType
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtRYXXSortType = Value
                Catch ex As Exception
                    m_strhtxtRYXXSortType = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdRYXX_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property grdRYXX_SelectedIndex() As Integer
            Get
                grdRYXX_SelectedIndex = m_intSelectedIndex_grdRYXX
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdRYXX = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdRYXX = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdRYXX_PageSize属性
        '----------------------------------------------------------------
        Public Property grdRYXX_PageSize() As Integer
            Get
                grdRYXX_PageSize = m_intPageSize_grdRYXX
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdRYXX = Value
                Catch ex As Exception
                    m_intPageSize_grdRYXX = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdRYXX_CurrentPageIndex属性
        '----------------------------------------------------------------
        Public Property grdRYXX_CurrentPageIndex() As Integer
            Get
                grdRYXX_CurrentPageIndex = m_intCurrentPageIndex_grdRYXX
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdRYXX = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdRYXX = -1
                End Try
            End Set
        End Property














        '----------------------------------------------------------------
        ' htxtDivLeftRYXX属性
        '----------------------------------------------------------------
        Public Property htxtDivLeftRYXX() As String
            Get
                htxtDivLeftRYXX = m_strhtxtDivLeftRYXX
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivLeftRYXX = Value
                Catch ex As Exception
                    m_strhtxtDivLeftRYXX = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopRYXX属性
        '----------------------------------------------------------------
        Public Property htxtDivTopRYXX() As String
            Get
                htxtDivTopRYXX = m_strhtxtDivTopRYXX
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivTopRYXX = Value
                Catch ex As Exception
                    m_strhtxtDivTopRYXX = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivLeftXGWJ属性
        '----------------------------------------------------------------
        Public Property htxtDivLeftXGWJ() As String
            Get
                htxtDivLeftXGWJ = m_strhtxtDivLeftXGWJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivLeftXGWJ = Value
                Catch ex As Exception
                    m_strhtxtDivLeftXGWJ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopXGWJ属性
        '----------------------------------------------------------------
        Public Property htxtDivTopXGWJ() As String
            Get
                htxtDivTopXGWJ = m_strhtxtDivTopXGWJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivTopXGWJ = Value
                Catch ex As Exception
                    m_strhtxtDivTopXGWJ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivLeftFJ属性
        '----------------------------------------------------------------
        Public Property htxtDivLeftFJ() As String
            Get
                htxtDivLeftFJ = m_strhtxtDivLeftFJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivLeftFJ = Value
                Catch ex As Exception
                    m_strhtxtDivLeftFJ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopFJ属性
        '----------------------------------------------------------------
        Public Property htxtDivTopFJ() As String
            Get
                htxtDivTopFJ = m_strhtxtDivTopFJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivTopFJ = Value
                Catch ex As Exception
                    m_strhtxtDivTopFJ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivLeftFHYJ属性
        '----------------------------------------------------------------
        Public Property htxtDivLeftFHYJ() As String
            Get
                htxtDivLeftFHYJ = m_strhtxtDivLeftFHYJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivLeftFHYJ = Value
                Catch ex As Exception
                    m_strhtxtDivLeftFHYJ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopFHYJ属性
        '----------------------------------------------------------------
        Public Property htxtDivTopFHYJ() As String
            Get
                htxtDivTopFHYJ = m_strhtxtDivTopFHYJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivTopFHYJ = Value
                Catch ex As Exception
                    m_strhtxtDivTopFHYJ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivLeftSHYJ属性
        '----------------------------------------------------------------
        Public Property htxtDivLeftSHYJ() As String
            Get
                htxtDivLeftSHYJ = m_strhtxtDivLeftSHYJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivLeftSHYJ = Value
                Catch ex As Exception
                    m_strhtxtDivLeftSHYJ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopSHYJ属性
        '----------------------------------------------------------------
        Public Property htxtDivTopSHYJ() As String
            Get
                htxtDivTopSHYJ = m_strhtxtDivTopSHYJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivTopSHYJ = Value
                Catch ex As Exception
                    m_strhtxtDivTopSHYJ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivLeftHQYJ属性
        '----------------------------------------------------------------
        Public Property htxtDivLeftHQYJ() As String
            Get
                htxtDivLeftHQYJ = m_strhtxtDivLeftHQYJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivLeftHQYJ = Value
                Catch ex As Exception
                    m_strhtxtDivLeftHQYJ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopHQYJ属性
        '----------------------------------------------------------------
        Public Property htxtDivTopHQYJ() As String
            Get
                htxtDivTopHQYJ = m_strhtxtDivTopHQYJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivTopHQYJ = Value
                Catch ex As Exception
                    m_strhtxtDivTopHQYJ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivLeftQFYJ属性
        '----------------------------------------------------------------
        Public Property htxtDivLeftQFYJ() As String
            Get
                htxtDivLeftQFYJ = m_strhtxtDivLeftQFYJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivLeftQFYJ = Value
                Catch ex As Exception
                    m_strhtxtDivLeftQFYJ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopQFYJ属性
        '----------------------------------------------------------------
        Public Property htxtDivTopQFYJ() As String
            Get
                htxtDivTopQFYJ = m_strhtxtDivTopQFYJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivTopQFYJ = Value
                Catch ex As Exception
                    m_strhtxtDivTopQFYJ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivLeftContent属性
        '----------------------------------------------------------------
        Public Property htxtDivLeftContent() As String
            Get
                htxtDivLeftContent = m_strhtxtDivLeftContent
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivLeftContent = Value
                Catch ex As Exception
                    m_strhtxtDivLeftContent = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopContent属性
        '----------------------------------------------------------------
        Public Property htxtDivTopContent() As String
            Get
                htxtDivTopContent = m_strhtxtDivTopContent
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivTopContent = Value
                Catch ex As Exception
                    m_strhtxtDivTopContent = ""
                End Try
            End Set
        End Property

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
        ' htxtSelectMenuID属性
        '----------------------------------------------------------------
        Public Property htxtSelectMenuID() As String
            Get
                htxtSelectMenuID = m_strhtxtSelectMenuID
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSelectMenuID = Value
                Catch ex As Exception
                    m_strhtxtSelectMenuID = ""
                End Try
            End Set
        End Property













        '----------------------------------------------------------------
        ' ddlJJCD_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property ddlJJCD_SelectedIndex() As Integer
            Get
                ddlJJCD_SelectedIndex = m_intSelectedIndex_ddlJJCD
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlJJCD = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlJJCD = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' ddlMMDJ_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property ddlMMDJ_SelectedIndex() As Integer
            Get
                ddlMMDJ_SelectedIndex = m_intSelectedIndex_ddlMMDJ
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlMMDJ = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlMMDJ = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtJGDZ属性
        '----------------------------------------------------------------
        Public Property txtJGDZ() As String
            Get
                txtJGDZ = m_strtxtJGDZ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJGDZ = Value
                Catch ex As Exception
                    m_strtxtJGDZ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtWJNF属性
        '----------------------------------------------------------------
        Public Property txtWJNF() As String
            Get
                txtWJNF = m_strtxtWJNF
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtWJNF = Value
                Catch ex As Exception
                    m_strtxtWJNF = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtWJXH属性
        '----------------------------------------------------------------
        Public Property txtWJXH() As String
            Get
                txtWJXH = m_strtxtWJXH
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtWJXH = Value
                Catch ex As Exception
                    m_strtxtWJXH = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtWJBT属性
        '----------------------------------------------------------------
        Public Property txtWJBT() As String
            Get
                txtWJBT = m_strtxtWJBT
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtWJBT = Value
                Catch ex As Exception
                    m_strtxtWJBT = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtDBRS属性
        '----------------------------------------------------------------
        Public Property txtDBRS() As String
            Get
                txtDBRS = m_strtxtDBRS
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtDBRS = Value
                Catch ex As Exception
                    m_strtxtDBRS = ""
                End Try
            End Set
        End Property

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
        ' txtJBDW属性
        '----------------------------------------------------------------
        Public Property txtJBDW() As String
            Get
                txtJBDW = m_strtxtJBDW
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJBDW = Value
                Catch ex As Exception
                    m_strtxtJBDW = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtJBRY属性
        '----------------------------------------------------------------
        Public Property txtJBRY() As String
            Get
                txtJBRY = m_strtxtJBRY
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJBRY = Value
                Catch ex As Exception
                    m_strtxtJBRY = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtJBRQ属性
        '----------------------------------------------------------------
        Public Property txtJBRQ() As String
            Get
                txtJBRQ = m_strtxtJBRQ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJBRQ = Value
                Catch ex As Exception
                    m_strtxtJBRQ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtRQ属性
        '----------------------------------------------------------------
        Public Property txtRQ() As String
            Get
                txtRQ = m_strtxtRQ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtRQ = Value
                Catch ex As Exception
                    m_strtxtRQ = ""
                End Try
            End Set
        End Property


        '----------------------------------------------------------------
        ' txtLSH属性
        '----------------------------------------------------------------
        Public Property txtLSH() As String
            Get
                txtLSH = m_strtxtLSH
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtLSH = Value
                Catch ex As Exception
                    m_strtxtLSH = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtWJBS属性
        '----------------------------------------------------------------
        Public Property htxtWJBS() As String
            Get
                htxtWJBS = m_strhtxtWJBS
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtWJBS = Value
                Catch ex As Exception
                    m_strhtxtWJBS = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtRYXM属性
        '----------------------------------------------------------------
        Public Property htxtRYXM() As String
            Get
                htxtRYXM = m_strhtxtRYXM
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtRYXM = Value
                Catch ex As Exception
                    m_strhtxtRYXM = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' chkDDSZ_Checked属性
        '----------------------------------------------------------------
        Public Property chkDDSZ_Checked() As Boolean
            Get
                chkDDSZ_Checked = m_blnChecked_chkDDSZ
            End Get
            Set(ByVal Value As Boolean)
                Try
                    m_blnChecked_chkDDSZ = Value
                Catch ex As Exception
                    m_blnChecked_chkDDSZ = False
                End Try
            End Set
        End Property












        '----------------------------------------------------------------
        ' objDataSet_FJ属性
        '----------------------------------------------------------------
        Public Property objDataSet_FJ() As Josco.JSOA.Common.Data.FlowData
            Get
                objDataSet_FJ = m_objDataSet_FJ
            End Get
            Set(ByVal Value As Josco.JSOA.Common.Data.FlowData)
                Try
                    m_objDataSet_FJ = Value
                Catch ex As Exception
                    m_objDataSet_FJ = Nothing
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' objDataSet_XGWJ属性
        '----------------------------------------------------------------
        Public Property objDataSet_XGWJ() As Josco.JSOA.Common.Data.FlowData
            Get
                objDataSet_XGWJ = m_objDataSet_XGWJ
            End Get
            Set(ByVal Value As Josco.JSOA.Common.Data.FlowData)
                Try
                    m_objDataSet_XGWJ = Value
                Catch ex As Exception
                    m_objDataSet_XGWJ = Nothing
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' objDataSet_RYXX属性
        '----------------------------------------------------------------
        Public Property objDataSet_RYXX() As Josco.JSOA.Common.Data.estateRenshiXingyeData
            Get
                objDataSet_RYXX = m_objDataSet_RYXX
            End Get
            Set(ByVal Value As Josco.JSOA.Common.Data.estateRenshiXingyeData)
                Try
                    m_objDataSet_RYXX = Value
                Catch ex As Exception
                    m_objDataSet_RYXX = Nothing
                End Try
            End Set
        End Property













        '----------------------------------------------------------------
        ' txtYWYBS属性
        '----------------------------------------------------------------
        Public Property txtYWYBS() As String
            Get
                txtYWYBS = m_strtxtYWYBS
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtYWYBS = Value
                Catch ex As Exception
                    m_strtxtYWYBS = ""
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
        ' txtRYNN属性
        '----------------------------------------------------------------
        Public Property txtRYNN() As String
            Get
                txtRYNN = m_strtxtRYNN
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtRYNN = Value
                Catch ex As Exception
                    m_strtxtRYNN = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtNFPBM属性
        '----------------------------------------------------------------
        Public Property txtNFPBM() As String
            Get
                txtNFPBM = m_strtxtNFPBM
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtNFPBM = Value
                Catch ex As Exception
                    m_strtxtNFPBM = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtNDRZW属性
        '----------------------------------------------------------------
        Public Property txtNDRZW() As String
            Get
                txtNDRZW = m_strtxtNDRZW
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtNDRZW = Value
                Catch ex As Exception
                    m_strtxtNDRZW = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtNBDRQ属性
        '----------------------------------------------------------------
        Public Property txtNBDRQ() As String
            Get
                txtNBDRQ = m_strtxtNBDRQ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtNBDRQ = Value
                Catch ex As Exception
                    m_strtxtNBDRQ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtZPSM属性
        '----------------------------------------------------------------
        Public Property txtZPSM() As String
            Get
                txtZPSM = m_strtxtZPSM
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtZPSM = Value
                Catch ex As Exception
                    m_strtxtZPSM = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtXYRYS属性
        '----------------------------------------------------------------
        Public Property txtXYRYS() As String
            Get
                txtXYRYS = m_strtxtXYRYS
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtXYRYS = Value
                Catch ex As Exception
                    m_strtxtXYRYS = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtDBRYS属性
        '----------------------------------------------------------------
        Public Property txtDBRYS() As String
            Get
                txtDBRYS = m_strtxtDBRYS
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtDBRYS = Value
                Catch ex As Exception
                    m_strtxtDBRYS = ""
                End Try
            End Set
        End Property








        '----------------------------------------------------------------
        ' rblSXRQ_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property rblSXRQ_SelectedIndex() As Integer
            Get
                rblSXRQ_SelectedIndex = m_intSelectedIndex_rblSXRQ
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_rblSXRQ = Value
                Catch ex As Exception
                    m_intSelectedIndex_rblSXRQ = -1
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
        ' txtSFZHM属性
        '----------------------------------------------------------------
        Public Property txtSFZHM() As String
            Get
                txtSFZHM = m_strtxtSFZHM
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtSFZHM = Value
                Catch ex As Exception
                    m_strtxtSFZHM = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtBMJL属性
        '----------------------------------------------------------------
        Public Property txtBMJL() As String
            Get
                txtBMJL = m_strtxtBMJL
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtBMJL = Value
                Catch ex As Exception
                    m_strtxtBMJL = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtWLJNFS属性
        '----------------------------------------------------------------
        Public Property txtWLJNFS() As String
            Get
                txtWLJNFS = m_strtxtWLJNFS
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtWLJNFS = Value
                Catch ex As Exception
                    m_strtxtWLJNFS = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtSPSM属性
        '----------------------------------------------------------------
        Public Property txtSPSM() As String
            Get
                txtSPSM = m_strtxtSPSM
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtSPSM = Value
                Catch ex As Exception
                    m_strtxtSPSM = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' ddlZPQD_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property ddlZPQD_SelectedIndex() As Integer
            Get
                ddlZPQD_SelectedIndex = m_intSelectedIndex_ddlZPQD
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlZPQD = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlZPQD = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' ddlZJDM_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property ddlZJDM_SelectedIndex() As Integer
            Get
                ddlZJDM_SelectedIndex = m_intSelectedIndex_ddlZJDM
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlZJDM = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlZJDM = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' ddlYDYY_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property ddlYDYY_SelectedIndex() As Integer
            Get
                ddlYDYY_SelectedIndex = m_intSelectedIndex_ddlYDYY
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlYDYY = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlYDYY = -1
                End Try
            End Set
        End Property


        '----------------------------------------------------------------
        ' rblRYLX_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property rblRYLX_SelectedIndex() As Integer
            Get
                rblRYLX_SelectedIndex = m_intSelectedIndex_rblRYLX
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_rblRYLX = Value
                Catch ex As Exception
                    m_intSelectedIndex_rblRYLX = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtTDBH
        '----------------------------------------------------------------
        Public Property txtTDBH() As String
            Get
                txtTDBH = m_strtxtTDBH
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtTDBH = Value
                Catch ex As Exception
                    m_strtxtTDBH = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtLXDH
        '----------------------------------------------------------------
        Public Property txtLXDH() As String
            Get
                txtLXDH = m_strtxtLXDH
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtLXDH = Value
                Catch ex As Exception
                    m_strtxtLXDH = ""
                End Try
            End Set
        End Property


        '----------------------------------------------------------------
        ' htxtBZXL
        '----------------------------------------------------------------
        Public Property htxtBZXL() As String
            Get
                htxtBZXL = m_strhtxtBZXL
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtBZXL = Value
                Catch ex As Exception
                    m_strhtxtBZXL = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtSSDW
        '----------------------------------------------------------------
        Public Property htxtSSDW() As String
            Get
                htxtSSDW = m_strhhtxtSSDW
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhhtxtSSDW = Value
                Catch ex As Exception
                    m_strhhtxtSSDW = ""
                End Try
            End Set
        End Property


        '----------------------------------------------------------------
        ' txtYZJMC
        '----------------------------------------------------------------
        Public Property txtYZJMC() As String
            Get
                txtYZJMC = m_strtxtYZJMC
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtYZJMC = Value
                Catch ex As Exception
                    m_strtxtYZJMC = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtYBMMC
        '----------------------------------------------------------------
        Public Property txtYBMMC() As String
            Get
                txtYBMMC = m_strtxtYBMMC
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtYBMMC = Value
                Catch ex As Exception
                    m_strtxtYBMMC = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtYTD
        '----------------------------------------------------------------
        Public Property txtYTD() As String
            Get
                txtYTD = m_strtxtYTD
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtYTD = Value
                Catch ex As Exception
                    m_strtxtYTD = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtYRYZT
        '----------------------------------------------------------------
        Public Property txtYRYZT() As String
            Get
                txtYRYZT = m_strtxtYRYZT
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtYRYZT = Value
                Catch ex As Exception
                    m_strtxtYRYZT = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtYZBQK
        '----------------------------------------------------------------
        Public Property txtYZBQK() As String
            Get
                txtYZBQK = m_strtxtYZBQK
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtYZBQK = Value
                Catch ex As Exception
                    m_strtxtYZBQK = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtYZJDM
        '----------------------------------------------------------------
        Public Property htxtYZJDM() As String
            Get
                htxtYZJDM = m_strhtxtYZJDM
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtYZJDM = Value
                Catch ex As Exception
                    m_strhtxtYZJDM = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtYBMDM
        '----------------------------------------------------------------
        Public Property htxtYBMDM() As String
            Get
                htxtYBMDM = m_strhtxtYBMDM
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtYBMDM = Value
                Catch ex As Exception
                    m_strhtxtYBMDM = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtYZGTD
        '----------------------------------------------------------------
        Public Property htxtYZGTD() As String
            Get
                htxtYZGTD = m_strhtxtYZGTD
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtYZGTD = Value
                Catch ex As Exception
                    m_strhtxtYZGTD = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtYXGTD
        '----------------------------------------------------------------
        Public Property htxtYXGTD() As String
            Get
                htxtYXGTD = m_strhtxtYXGTD
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtYXGTD = Value
                Catch ex As Exception
                    m_strhtxtYXGTD = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtSSDW
        '----------------------------------------------------------------
        Public Property txtSSDW() As String
            Get
                txtSSDW = m_strtxtSSDW
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtSSDW = Value
                Catch ex As Exception
                    m_strtxtSSDW = ""
                End Try
            End Set
        End Property

       

        '----------------------------------------------------------------
        ' htxtZGTD
        '----------------------------------------------------------------
        Public Property htxtZGTD() As String
            Get
                htxtZGTD = m_strhtxtZGTD
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtZGTD = Value
                Catch ex As Exception
                    m_strhtxtZGTD = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtXGTD
        '----------------------------------------------------------------
        Public Property htxtXGTD() As String
            Get
                htxtXGTD = m_strhtxtXGTD
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtXGTD = Value
                Catch ex As Exception
                    m_strhtxtXGTD = ""
                End Try
            End Set
        End Property


        '----------------------------------------------------------------
        ' rblRYZT_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property rblRYZT_SelectedIndex() As Integer
            Get
                rblRYZT_SelectedIndex = m_intSelectedIndex_rblRYZT
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_rblRYZT = Value
                Catch ex As Exception
                    m_intSelectedIndex_rblRYZT = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' rblSFZB_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property rblSFZB_SelectedIndex() As Integer
            Get
                rblSFZB_SelectedIndex = m_intSelectedIndex_rblSFZB
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_rblSFZB = Value
                Catch ex As Exception
                    m_intSelectedIndex_rblSFZB = -1
                End Try
            End Set
        End Property


        '----------------------------------------------------------------
        ' txtSFJZ
        '----------------------------------------------------------------
        Public Property txtSFJZ() As String
            Get
                txtSFJZ = m_strtxtSFJZ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtSFJZ = Value
                Catch ex As Exception
                    m_strtxtSFJZ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtRTLX
        '----------------------------------------------------------------
        Public Property txtRTLX() As String
            Get
                txtRTLX = m_strtxtRTLX
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtRTLX = Value
                Catch ex As Exception
                    m_strtxtRTLX = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtBZXL
        '----------------------------------------------------------------
        Public Property txtBZXL() As String
            Get
                txtBZXL = m_strtxtBZXL
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtBZXL = Value
                Catch ex As Exception
                    m_strtxtBZXL = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtRTLXMC
        '----------------------------------------------------------------
        Public Property txtRTLXMC() As String
            Get
                txtRTLXMC = m_strtxtRTLXMC
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtRTLXMC = Value
                Catch ex As Exception
                    m_strtxtRTLXMC = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtZGDWDM
        '----------------------------------------------------------------
        Public Property txtZGDWDM() As String
            Get
                txtZGDWDM = m_strtxtZGDWDM
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtZGDWDM = Value
                Catch ex As Exception
                    m_strtxtZGDWDM = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtZGDWMC
        '----------------------------------------------------------------
        Public Property txtZGDWMC() As String
            Get
                txtZGDWMC = m_strtxtZGDWMC
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtZGDWMC = Value
                Catch ex As Exception
                    m_strtxtZGDWMC = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtSJLD
        '----------------------------------------------------------------
        Public Property txtSJLD() As String
            Get
                txtSJLD = m_strtxtSJLD
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtSJLD = Value
                Catch ex As Exception
                    m_strtxtSJLD = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtSJLDMC
        '----------------------------------------------------------------
        Public Property txtSJLDMC() As String
            Get
                txtSJLDMC = m_strtxtSJLDMC
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtSJLDMC = Value
                Catch ex As Exception
                    m_strtxtSJLDMC = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtSessionId_TDZH
        '----------------------------------------------------------------
        Public Property htxtSessionId_TDZH() As String
            Get
                htxtSessionId_TDZH = m_strhtxtSessionId_TDZH
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSessionId_TDZH = Value
                Catch ex As Exception
                    m_strhtxtSessionId_TDZH = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtSessionId_YTDZH
        '----------------------------------------------------------------
        Public Property htxtSessionId_YTDZH() As String
            Get
                htxtSessionId_YTDZH = m_strhtxtSessionId_YTDZH
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSessionId_YTDZH = Value
                Catch ex As Exception
                    m_strhtxtSessionId_YTDZH = ""
                End Try
            End Set
        End Property

    End Class

End Namespace

