Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.BusinessFacade
    ' ����    ��IMEstateRsLuyongInfo
    '
    ' ���������� 
    '     estate_rs_luyong_info.aspxģ�鱾��ָ��ֳ���Ҫ����Ϣ
    '----------------------------------------------------------------
    <Serializable()> Public Class IMEstateRsLuyongInfo
        Implements IDisposable

        '----------------------------------------------------------------
        '
        '----------------------------------------------------------------
        Private m_strhtxtEditMode As String               'htxtEditMode
        Private m_strhtxtEditType As String               'htxtEditType
        Private m_strhtxtEnforeEdit As String             'htxtEnforeEdit
        Private m_strhtxtZWNRFileName As String           'htxtZWNRFileName

        Private m_objDataSet_FJ As Josco.JsKernal.Common.Data.FlowData
        Private m_strhtxtSessionIDFJ As String            'htxtSessionIDFJ
        Private m_strhtxtFJSort As String                 'htxtFJSort
        Private m_strhtxtFJSortColumnIndex As String      'htxtFJSortColumnIndex
        Private m_strhtxtFJSortType As String             'htxtFJSortType
        Private m_intPageSize_grdFJ As Integer            'grdFJ_PageSize
        Private m_intSelectedIndex_grdFJ As Integer       'grdFJ_SelectedIndex
        Private m_intCurrentPageIndex_grdFJ As Integer    'grdFJ_CurrentPageIndex

        Private m_objDataSet_XGWJ As Josco.JsKernal.Common.Data.FlowData
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
        'asp:textbox(�����渺�����������)
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








        '----------------------------------------------------------------
        ' ���캯��
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
            m_strtxtLSH = ""
            m_strhtxtWJBS = ""
            m_blnChecked_chkDDSZ = False

            m_objDataSet_RYXX = Nothing
            m_objDataSet_XGWJ = Nothing
            m_objDataSet_FJ = Nothing

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
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IMEstateRsLuyongInfo)
            Try
                If Not (obj Is Nothing) Then
                    obj.Dispose()
                End If
            Catch ex As Exception
            End Try
            obj = Nothing
        End Sub











        '----------------------------------------------------------------
        ' htxtEditMode����
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
        ' htxtEditType����
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
        ' htxtEnforeEdit����
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
        ' htxtZWNRFileName����
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
        ' htxtSessionIDFJ����
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
        ' htxtSessionIDXGWJ����
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
        ' htxtSessionIDRYXX����
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
        ' htxtFJSort����
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
        ' htxtFJSortColumnIndex����
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
        ' htxtFJSortType����
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
        ' grdFJ_SelectedIndex����
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
        ' grdFJ_PageSize����
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
        ' grdFJ_CurrentPageIndex����
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
        ' htxtXGWJSort����
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
        ' htxtXGWJSortColumnIndex����
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
        ' htxtXGWJSortType����
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
        ' grdXGWJ_SelectedIndex����
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
        ' grdXGWJ_PageSize����
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
        ' grdXGWJ_CurrentPageIndex����
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
        ' htxtRYXXSort����
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
        ' htxtRYXXSortColumnIndex����
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
        ' htxtRYXXSortType����
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
        ' grdRYXX_SelectedIndex����
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
        ' grdRYXX_PageSize����
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
        ' grdRYXX_CurrentPageIndex����
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
        ' htxtDivLeftRYXX����
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
        ' htxtDivTopRYXX����
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
        ' htxtDivLeftXGWJ����
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
        ' htxtDivTopXGWJ����
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
        ' htxtDivLeftFJ����
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
        ' htxtDivTopFJ����
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
        ' htxtDivLeftFHYJ����
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
        ' htxtDivTopFHYJ����
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
        ' htxtDivLeftSHYJ����
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
        ' htxtDivTopSHYJ����
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
        ' htxtDivLeftHQYJ����
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
        ' htxtDivTopHQYJ����
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
        ' htxtDivLeftQFYJ����
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
        ' htxtDivTopQFYJ����
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
        ' htxtDivLeftContent����
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
        ' htxtDivTopContent����
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
        ' htxtSelectMenuID����
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
        ' ddlJJCD_SelectedIndex����
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
        ' ddlMMDJ_SelectedIndex����
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
        ' txtJGDZ����
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
        ' txtWJNF����
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
        ' txtWJXH����
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
        ' txtWJBT����
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
        ' txtDBRS����
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
        ' txtJBDW����
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
        ' txtJBRY����
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
        ' txtJBRQ����
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
        ' txtLSH����
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
        ' htxtWJBS����
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
        ' chkDDSZ_Checked����
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
        ' objDataSet_FJ����
        '----------------------------------------------------------------
        Public Property objDataSet_FJ() As Josco.JsKernal.Common.Data.FlowData
            Get
                objDataSet_FJ = m_objDataSet_FJ
            End Get
            Set(ByVal Value As Josco.JsKernal.Common.Data.FlowData)
                Try
                    m_objDataSet_FJ = Value
                Catch ex As Exception
                    m_objDataSet_FJ = Nothing
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' objDataSet_XGWJ����
        '----------------------------------------------------------------
        Public Property objDataSet_XGWJ() As Josco.JsKernal.Common.Data.FlowData
            Get
                objDataSet_XGWJ = m_objDataSet_XGWJ
            End Get
            Set(ByVal Value As Josco.JsKernal.Common.Data.FlowData)
                Try
                    m_objDataSet_XGWJ = Value
                Catch ex As Exception
                    m_objDataSet_XGWJ = Nothing
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' objDataSet_RYXX����
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
        ' txtJLBH����
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
        ' txtRYDM����
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
        ' txtRYXM����
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
        ' txtRYNN����
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
        ' txtNFPBM����
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
        ' txtNDRZW����
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
        ' txtNBDRQ����
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
        ' txtZPSM����
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
        ' txtXYRYS����
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
        ' txtDBRYS����
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
        ' rblRYXB_SelectedIndex����
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
        ' ddlXL_SelectedIndex����
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

    End Class

End Namespace
