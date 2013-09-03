Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.BusinessFacade
    ' 类名    ：IMEstateEsHetongJssInfo
    '
    ' 功能描述： 
    '     estate_es_hetong_jss_info.aspx模块本身恢复现场需要的信息
    '----------------------------------------------------------------
    <Serializable()> Public Class IMEstateEsHetongJssInfo
        Implements IDisposable

        '----------------------------------------------------------------
        ' 模块属性
        '----------------------------------------------------------------
        Private m_strhtxtDivLeftBody As String                'htxtDivLeftBody
        Private m_strhtxtDivTopBody As String                 'htxtDivTopBody
        Private m_strhtxtDivLeftMain As String                'htxtDivLeftMain
        Private m_strhtxtDivTopMain As String                 'htxtDivTopMain
        Private m_strhtxtDivLeftJSMX As String                'htxtDivLeftJSMX
        Private m_strhtxtDivTopJSMX As String                 'htxtDivTopJSMX
        Private m_strhtxtDivLeftYEJI As String                'htxtDivLeftYEJI
        Private m_strhtxtDivTopYEJI As String                 'htxtDivTopYEJI

        Private m_strtxtHTZK As String                        'txtHTZK
        Private m_strtxtWYDZ As String                        'txtWYDZ
        Private m_strtxtJFMC As String                        'txtJFMC
        Private m_strtxtYFMC As String                        'txtYFMC
        Private m_strtxtHTBH As String                        'txtHTBH
        Private m_intSelectedIndex_rblHTLX As Integer         'rblHTLX_SelectedIndex

        Private m_strhtxtWYBS As String                       'htxtWYBS
        Private m_strhtxtQRSH As String                       'htxtQRSH
        Private m_strhtxtZTBZ As String                       'htxtZTBZ
        Private m_strtxtJSSH As String                        'txtJSSH
        Private m_strtxtJSRQ As String                        'txtJSRQ
        'zengxianglin 2009-12-26
        Private m_strtxtJYRQ As String                        'txtJYRQ
        'zengxianglin 2009-12-26

        Private m_strtxtJSDW As String                        'txtJSDW
        Private m_strhtxtJSDW As String                       'htxtJSDW
        Private m_strtxtJBRY As String                        'txtJBRY
        Private m_strhtxtJBRY As String                       'htxtJBRY
        Private m_strtxtZJFE As String                        'txtZJFE
        Private m_strtxtJSEJ As String                        'txtJSEJ
        Private m_strtxtJSEY As String                        'txtJSEY
        Private m_strtxtSSEJ As String                        'txtSSEJ
        Private m_strtxtSSEY As String                        'txtSSEY
        Private m_strtxtBZXX As String                        'txtBZXX
        Private m_intSelectedIndex_rblJSLX As Integer         'rblJSLX_SelectedIndex

        Private m_strhtxtSessionId_JSMX As String             'htxtSessionId_JSMX
        Private m_intCurrentPageIndex_grdJSMX As Integer      'grdJSMX_CurrentPageIndex
        Private m_intSelectedIndex_grdJSMX As Integer         'grdJSMX_SelectedIndex
        Private m_intPageSize_grdJSMX As Integer              'grdJSMX_PageSize

        Private m_strhtxtSessionId_YEJI As String             'htxtSessionId_YEJI
        Private m_intCurrentPageIndex_grdYEJI As Integer      'grdYEJI_CurrentPageIndex
        Private m_intSelectedIndex_grdYEJI As Integer         'grdYEJI_SelectedIndex
        Private m_intPageSize_grdYEJI As Integer              'grdYEJI_PageSize












        '----------------------------------------------------------------
        ' 构造函数
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()

            m_strhtxtDivLeftBody = ""
            m_strhtxtDivTopBody = ""
            m_strhtxtDivLeftMain = ""
            m_strhtxtDivTopMain = ""
            m_strhtxtDivLeftJSMX = ""
            m_strhtxtDivTopJSMX = ""
            m_strhtxtDivLeftYEJI = ""
            m_strhtxtDivTopYEJI = ""

            m_strtxtHTZK = ""
            m_strtxtWYDZ = ""
            m_strtxtJFMC = ""
            m_strtxtYFMC = ""
            m_strtxtHTBH = ""
            m_intSelectedIndex_rblHTLX = -1

            m_strhtxtWYBS = ""
            m_strhtxtQRSH = ""
            m_strtxtJSSH = ""
            m_strtxtJSRQ = ""
            'zengxianglin 2009-12-26
            m_strtxtJYRQ = ""
            'zengxianglin 2009-12-26

            m_strtxtJSDW = ""
            m_strhtxtJSDW = ""
            m_strtxtJBRY = ""
            m_strhtxtJBRY = ""
            m_strtxtZJFE = ""
            m_strtxtJSEJ = ""
            m_strtxtJSEY = ""
            m_strtxtSSEJ = ""
            m_strtxtSSEY = ""
            m_strhtxtZTBZ = ""
            m_strtxtBZXX = ""

            m_intSelectedIndex_rblJSLX = -1

            m_strhtxtSessionId_JSMX = ""
            m_intCurrentPageIndex_grdJSMX = 0
            m_intSelectedIndex_grdJSMX = -1
            m_intPageSize_grdJSMX = 30

            m_strhtxtSessionId_YEJI = ""
            m_intCurrentPageIndex_grdYEJI = 0
            m_intSelectedIndex_grdYEJI = -1
            m_intPageSize_grdYEJI = 30
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
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IMEstateEsHetongJssInfo)
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
        ' htxtDivLeftJSMX属性
        '----------------------------------------------------------------
        Public Property htxtDivLeftJSMX() As String
            Get
                htxtDivLeftJSMX = m_strhtxtDivLeftJSMX
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivLeftJSMX = Value
                Catch ex As Exception
                    m_strhtxtDivLeftJSMX = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopJSMX属性
        '----------------------------------------------------------------
        Public Property htxtDivTopJSMX() As String
            Get
                htxtDivTopJSMX = m_strhtxtDivTopJSMX
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivTopJSMX = Value
                Catch ex As Exception
                    m_strhtxtDivTopJSMX = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivLeftYEJI属性
        '----------------------------------------------------------------
        Public Property htxtDivLeftYEJI() As String
            Get
                htxtDivLeftYEJI = m_strhtxtDivLeftYEJI
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivLeftYEJI = Value
                Catch ex As Exception
                    m_strhtxtDivLeftYEJI = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopYEJI属性
        '----------------------------------------------------------------
        Public Property htxtDivTopYEJI() As String
            Get
                htxtDivTopYEJI = m_strhtxtDivTopYEJI
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivTopYEJI = Value
                Catch ex As Exception
                    m_strhtxtDivTopYEJI = ""
                End Try
            End Set
        End Property











        '----------------------------------------------------------------
        ' txtHTZK属性
        '----------------------------------------------------------------
        Public Property txtHTZK() As String
            Get
                txtHTZK = m_strtxtHTZK
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtHTZK = Value
                Catch ex As Exception
                    m_strtxtHTZK = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtWYDZ属性
        '----------------------------------------------------------------
        Public Property txtWYDZ() As String
            Get
                txtWYDZ = m_strtxtWYDZ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtWYDZ = Value
                Catch ex As Exception
                    m_strtxtWYDZ = ""
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
        ' rblHTLX_SelectedIndex属性
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
        ' txtJSSH属性
        '----------------------------------------------------------------
        Public Property txtJSSH() As String
            Get
                txtJSSH = m_strtxtJSSH
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJSSH = Value
                Catch ex As Exception
                    m_strtxtJSSH = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtJSRQ属性
        '----------------------------------------------------------------
        Public Property txtJSRQ() As String
            Get
                txtJSRQ = m_strtxtJSRQ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJSRQ = Value
                Catch ex As Exception
                    m_strtxtJSRQ = ""
                End Try
            End Set
        End Property

        'zengxianglin 2009-12-26
        '----------------------------------------------------------------
        ' txtJYRQ属性
        '----------------------------------------------------------------
        Public Property txtJYRQ() As String
            Get
                txtJYRQ = m_strtxtJYRQ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJYRQ = Value
                Catch ex As Exception
                    m_strtxtJYRQ = ""
                End Try
            End Set
        End Property
        'zengxianglin 2009-12-26

        '----------------------------------------------------------------
        ' txtJSDW属性
        '----------------------------------------------------------------
        Public Property txtJSDW() As String
            Get
                txtJSDW = m_strtxtJSDW
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJSDW = Value
                Catch ex As Exception
                    m_strtxtJSDW = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtJSDW属性
        '----------------------------------------------------------------
        Public Property htxtJSDW() As String
            Get
                htxtJSDW = m_strhtxtJSDW
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtJSDW = Value
                Catch ex As Exception
                    m_strhtxtJSDW = ""
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
        ' htxtJBRY属性
        '----------------------------------------------------------------
        Public Property htxtJBRY() As String
            Get
                htxtJBRY = m_strhtxtJBRY
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtJBRY = Value
                Catch ex As Exception
                    m_strhtxtJBRY = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtZJFE属性
        '----------------------------------------------------------------
        Public Property txtZJFE() As String
            Get
                txtZJFE = m_strtxtZJFE
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtZJFE = Value
                Catch ex As Exception
                    m_strtxtZJFE = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtJSEJ属性
        '----------------------------------------------------------------
        Public Property txtJSEJ() As String
            Get
                txtJSEJ = m_strtxtJSEJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJSEJ = Value
                Catch ex As Exception
                    m_strtxtJSEJ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtJSEY属性
        '----------------------------------------------------------------
        Public Property txtJSEY() As String
            Get
                txtJSEY = m_strtxtJSEY
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJSEY = Value
                Catch ex As Exception
                    m_strtxtJSEY = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtSSEJ属性
        '----------------------------------------------------------------
        Public Property txtSSEJ() As String
            Get
                txtSSEJ = m_strtxtSSEJ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtSSEJ = Value
                Catch ex As Exception
                    m_strtxtSSEJ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtSSEY属性
        '----------------------------------------------------------------
        Public Property txtSSEY() As String
            Get
                txtSSEY = m_strtxtSSEY
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtSSEY = Value
                Catch ex As Exception
                    m_strtxtSSEY = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtZTBZ属性
        '----------------------------------------------------------------
        Public Property htxtZTBZ() As String
            Get
                htxtZTBZ = m_strhtxtZTBZ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtZTBZ = Value
                Catch ex As Exception
                    m_strhtxtZTBZ = ""
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
        ' rblJSLX_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property rblJSLX_SelectedIndex() As Integer
            Get
                rblJSLX_SelectedIndex = m_intSelectedIndex_rblJSLX
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_rblJSLX = Value
                Catch ex As Exception
                    m_intSelectedIndex_rblJSLX = -1
                End Try
            End Set
        End Property












        '----------------------------------------------------------------
        ' htxtSessionId_JSMX属性
        '----------------------------------------------------------------
        Public Property htxtSessionId_JSMX() As String
            Get
                htxtSessionId_JSMX = m_strhtxtSessionId_JSMX
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSessionId_JSMX = Value
                Catch ex As Exception
                    m_strhtxtSessionId_JSMX = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdJSMX_CurrentPageIndex属性
        '----------------------------------------------------------------
        Public Property grdJSMX_CurrentPageIndex() As Integer
            Get
                grdJSMX_CurrentPageIndex = m_intCurrentPageIndex_grdJSMX
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdJSMX = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdJSMX = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdJSMX_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property grdJSMX_SelectedIndex() As Integer
            Get
                grdJSMX_SelectedIndex = m_intSelectedIndex_grdJSMX
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdJSMX = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdJSMX = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdJSMX_PageSize属性
        '----------------------------------------------------------------
        Public Property grdJSMX_PageSize() As Integer
            Get
                grdJSMX_PageSize = m_intPageSize_grdJSMX
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdJSMX = Value
                Catch ex As Exception
                    m_intPageSize_grdJSMX = 0
                End Try
            End Set
        End Property











        '----------------------------------------------------------------
        ' htxtSessionId_YEJI属性
        '----------------------------------------------------------------
        Public Property htxtSessionId_YEJI() As String
            Get
                htxtSessionId_YEJI = m_strhtxtSessionId_YEJI
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSessionId_YEJI = Value
                Catch ex As Exception
                    m_strhtxtSessionId_YEJI = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdYEJI_CurrentPageIndex属性
        '----------------------------------------------------------------
        Public Property grdYEJI_CurrentPageIndex() As Integer
            Get
                grdYEJI_CurrentPageIndex = m_intCurrentPageIndex_grdYEJI
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdYEJI = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdYEJI = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdYEJI_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property grdYEJI_SelectedIndex() As Integer
            Get
                grdYEJI_SelectedIndex = m_intSelectedIndex_grdYEJI
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdYEJI = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdYEJI = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdYEJI_PageSize属性
        '----------------------------------------------------------------
        Public Property grdYEJI_PageSize() As Integer
            Get
                grdYEJI_PageSize = m_intPageSize_grdYEJI
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdYEJI = Value
                Catch ex As Exception
                    m_intPageSize_grdYEJI = 0
                End Try
            End Set
        End Property

    End Class

End Namespace
