Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.BusinessFacade
    ' 类名    ：IMEstateEsQrsQtWuye
    '
    ' 功能描述： 
    '     estate_es_qrsqt_wuye.aspx模块本身恢复现场需要的信息
    '----------------------------------------------------------------
    <Serializable()> Public Class IMEstateEsQrsQtWuye
        Implements IDisposable

        '----------------------------------------------------------------
        ' 模块属性
        '----------------------------------------------------------------
        Private m_strhtxtDivLeftBody As String                'htxtDivLeftBody
        Private m_strhtxtDivTopBody As String                 'htxtDivTopBody
        Private m_strhtxtDivLeftMain As String                'htxtDivLeftMain
        Private m_strhtxtDivTopMain As String                 'htxtDivTopMain

        Private m_strhtxtWYBS As String                       'htxtWYBS
        Private m_strhtxtWYBM As String                       'htxtWYBM
        Private m_strtxtQRSH As String                        'txtQRSH

        Private m_strtxtFWDZ As String                        'txtFWDZ
        Private m_strtxtMJ As String                          'txtMJ
        Private m_strtxtJYJE As String                        'txtJYJE
        Private m_strtxtFCZH As String                        'txtFCZH
        Private m_strtxtFCZDZ As String                       'txtFCZDZ
        Private m_strtxtLC As String                          'txtLC
        Private m_strtxtLL As String                          'txtLL
        Private m_strtxtBZXX As String                        'txtBZXX

        Private m_intSelectedIndex_ddlZX As Integer           'ddlZX_SelectedIndex
        Private m_intSelectedIndex_ddlJG As Integer           'ddlJG_SelectedIndex
        Private m_intSelectedIndex_ddlSZQY As Integer         'ddlSZQY_SelectedIndex
        Private m_intSelectedIndex_ddlWYXZ As Integer         'ddlWYXZ_SelectedIndex

        'zengxianglin 2010-12-26
        Private m_strtxtFYBH As String                        'txtFYBH
        Private m_strtxtLP As String                          'txtLP
        Private m_strtxtLD As String                          'txtLD
        Private m_strtxtDY As String                          'txtDY
        Private m_strtxtJCSJ As String                        'txtJCSJ
        Private m_intSelectedIndex_rblKJLX As Integer         'rblKJLX_SelectedIndex
        Private m_intSelectedIndex_rblFWXZ As Integer         'rblFWXZ_SelectedIndex
        Private m_strtxtLG As String                          'txtLG
        Private m_strtxtDTSL As String                        'txtDTSL
        Private m_strtxtLCHS As String                        'txtLCHS
        Private m_strtxtLPQS As String                        'txtLPQS
        Private m_intSelectedIndex_rblCX As Integer           'rblCX_SelectedIndex
        Private m_intSelectedIndex_rblWYSX As Integer         'rblWYSX_SelectedIndex
        Private m_intSelectedIndex_rblZXDC As Integer         'rblZXDC_SelectedIndex
        Private m_intSelectedIndex_rblZXNX As Integer         'rblZXNX_SelectedIndex
        Private m_intSelectedIndex_rblZYYX As Integer         'rblZYYX_SelectedIndex
        Private m_intSelectedIndex_rblJJSB As Integer         'rblJJSB_SelectedIndex
        Private m_intSelectedIndex_rblLYJT As Integer         'rblLYJT_SelectedIndex
        Private m_intSelectedIndex_rblFWJG As Integer         'rblFWJG_SelectedIndex
        Private m_intSelectedIndex_rblJGLX As Integer         'rblJGLX_SelectedIndex
        Private m_strtxtJGFS As String                        'txtJGFS
        Private m_strtxtWSSL As String                        'txtWSSL
        Private m_strtxtYTSL As String                        'txtYTSL
        'zengxianglin 2010-12-26













        '----------------------------------------------------------------
        ' 构造函数
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()

            Me.m_strhtxtDivLeftBody = ""
            Me.m_strhtxtDivTopBody = ""
            Me.m_strhtxtDivLeftMain = ""
            Me.m_strhtxtDivTopMain = ""

            Me.m_strhtxtWYBS = ""
            Me.m_strhtxtWYBM = ""
            Me.m_strtxtQRSH = ""

            Me.m_strtxtMJ = ""
            Me.m_strtxtJYJE = ""
            Me.m_strtxtFWDZ = ""
            Me.m_strtxtFCZH = ""
            Me.m_strtxtFCZDZ = ""
            Me.m_strtxtLC = ""
            Me.m_strtxtLL = ""
            Me.m_strtxtBZXX = ""

            Me.m_intSelectedIndex_ddlZX = -1
            Me.m_intSelectedIndex_ddlJG = -1
            Me.m_intSelectedIndex_ddlSZQY = -1
            Me.m_intSelectedIndex_ddlWYXZ = -1

            'zengxianglin 2010-12-26
            Me.m_strtxtFYBH = ""
            Me.m_strtxtLP = ""
            Me.m_strtxtLD = ""
            Me.m_strtxtDY = ""
            Me.m_strtxtJCSJ = ""
            Me.m_intSelectedIndex_rblKJLX = -1
            Me.m_intSelectedIndex_rblFWXZ = -1
            Me.m_strtxtLG = ""
            Me.m_strtxtDTSL = ""
            Me.m_strtxtLCHS = ""
            Me.m_strtxtLPQS = ""
            Me.m_intSelectedIndex_rblCX = -1
            Me.m_intSelectedIndex_rblWYSX = -1
            Me.m_intSelectedIndex_rblZXDC = -1
            Me.m_intSelectedIndex_rblZXNX = -1
            Me.m_intSelectedIndex_rblZYYX = -1
            Me.m_intSelectedIndex_rblJJSB = -1
            Me.m_intSelectedIndex_rblLYJT = -1
            Me.m_intSelectedIndex_rblFWJG = -1
            Me.m_intSelectedIndex_rblJGLX = -1
            Me.m_strtxtJGFS = ""
            Me.m_strtxtWSSL = ""
            Me.m_strtxtYTSL = ""
            'zengxianglin 2010-12-26
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
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IMEstateEsQrsQtWuye)
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
                htxtDivLeftBody = Me.m_strhtxtDivLeftBody
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strhtxtDivLeftBody = Value
                Catch ex As Exception
                    Me.m_strhtxtDivLeftBody = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopBody属性
        '----------------------------------------------------------------
        Public Property htxtDivTopBody() As String
            Get
                htxtDivTopBody = Me.m_strhtxtDivTopBody
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strhtxtDivTopBody = Value
                Catch ex As Exception
                    Me.m_strhtxtDivTopBody = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivLeftMain属性
        '----------------------------------------------------------------
        Public Property htxtDivLeftMain() As String
            Get
                htxtDivLeftMain = Me.m_strhtxtDivLeftMain
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strhtxtDivLeftMain = Value
                Catch ex As Exception
                    Me.m_strhtxtDivLeftMain = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopMain属性
        '----------------------------------------------------------------
        Public Property htxtDivTopMain() As String
            Get
                htxtDivTopMain = Me.m_strhtxtDivTopMain
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strhtxtDivTopMain = Value
                Catch ex As Exception
                    Me.m_strhtxtDivTopMain = ""
                End Try
            End Set
        End Property













        '----------------------------------------------------------------
        ' htxtWYBS属性
        '----------------------------------------------------------------
        Public Property htxtWYBS() As String
            Get
                htxtWYBS = Me.m_strhtxtWYBS
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strhtxtWYBS = Value
                Catch ex As Exception
                    Me.m_strhtxtWYBS = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtWYBM属性
        '----------------------------------------------------------------
        Public Property htxtWYBM() As String
            Get
                htxtWYBM = Me.m_strhtxtWYBM
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strhtxtWYBM = Value
                Catch ex As Exception
                    Me.m_strhtxtWYBM = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtQRSH属性
        '----------------------------------------------------------------
        Public Property txtQRSH() As String
            Get
                txtQRSH = Me.m_strtxtQRSH
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtQRSH = Value
                Catch ex As Exception
                    Me.m_strtxtQRSH = ""
                End Try
            End Set
        End Property














        '----------------------------------------------------------------
        ' txtFCZH属性
        '----------------------------------------------------------------
        Public Property txtFCZH() As String
            Get
                txtFCZH = Me.m_strtxtFCZH
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtFCZH = Value
                Catch ex As Exception
                    Me.m_strtxtFCZH = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtFCZDZ属性
        '----------------------------------------------------------------
        Public Property txtFCZDZ() As String
            Get
                txtFCZDZ = Me.m_strtxtFCZDZ
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtFCZDZ = Value
                Catch ex As Exception
                    Me.m_strtxtFCZDZ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtLC属性
        '----------------------------------------------------------------
        Public Property txtLC() As String
            Get
                txtLC = Me.m_strtxtLC
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtLC = Value
                Catch ex As Exception
                    Me.m_strtxtLC = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtLL属性
        '----------------------------------------------------------------
        Public Property txtLL() As String
            Get
                txtLL = Me.m_strtxtLL
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtLL = Value
                Catch ex As Exception
                    Me.m_strtxtLL = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtMJ属性
        '----------------------------------------------------------------
        Public Property txtMJ() As String
            Get
                txtMJ = Me.m_strtxtMJ
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtMJ = Value
                Catch ex As Exception
                    Me.m_strtxtMJ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtFWDZ属性
        '----------------------------------------------------------------
        Public Property txtFWDZ() As String
            Get
                txtFWDZ = Me.m_strtxtFWDZ
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtFWDZ = Value
                Catch ex As Exception
                    Me.m_strtxtFWDZ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtJYJE属性
        '----------------------------------------------------------------
        Public Property txtJYJE() As String
            Get
                txtJYJE = Me.m_strtxtJYJE
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtJYJE = Value
                Catch ex As Exception
                    Me.m_strtxtJYJE = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtBZXX属性
        '----------------------------------------------------------------
        Public Property txtBZXX() As String
            Get
                txtBZXX = Me.m_strtxtBZXX
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtBZXX = Value
                Catch ex As Exception
                    Me.m_strtxtBZXX = ""
                End Try
            End Set
        End Property












        '----------------------------------------------------------------
        ' ddlSZQY_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property ddlSZQY_SelectedIndex() As Integer
            Get
                ddlSZQY_SelectedIndex = Me.m_intSelectedIndex_ddlSZQY
            End Get
            Set(ByVal Value As Integer)
                Try
                    Me.m_intSelectedIndex_ddlSZQY = Value
                Catch ex As Exception
                    Me.m_intSelectedIndex_ddlSZQY = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' ddlWYXZ_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property ddlWYXZ_SelectedIndex() As Integer
            Get
                ddlWYXZ_SelectedIndex = Me.m_intSelectedIndex_ddlWYXZ
            End Get
            Set(ByVal Value As Integer)
                Try
                    Me.m_intSelectedIndex_ddlWYXZ = Value
                Catch ex As Exception
                    Me.m_intSelectedIndex_ddlWYXZ = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' ddlZX_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property ddlZX_SelectedIndex() As Integer
            Get
                ddlZX_SelectedIndex = Me.m_intSelectedIndex_ddlZX
            End Get
            Set(ByVal Value As Integer)
                Try
                    Me.m_intSelectedIndex_ddlZX = Value
                Catch ex As Exception
                    Me.m_intSelectedIndex_ddlZX = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' ddlJG_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property ddlJG_SelectedIndex() As Integer
            Get
                ddlJG_SelectedIndex = Me.m_intSelectedIndex_ddlJG
            End Get
            Set(ByVal Value As Integer)
                Try
                    Me.m_intSelectedIndex_ddlJG = Value
                Catch ex As Exception
                    Me.m_intSelectedIndex_ddlJG = -1
                End Try
            End Set
        End Property










        '----------------------------------------------------------------
        ' txtFYBH属性
        '----------------------------------------------------------------
        Public Property txtFYBH() As String
            Get
                txtFYBH = Me.m_strtxtFYBH
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtFYBH = Value
                Catch ex As Exception
                    Me.m_strtxtFYBH = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtLP属性
        '----------------------------------------------------------------
        Public Property txtLP() As String
            Get
                txtLP = Me.m_strtxtLP
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtLP = Value
                Catch ex As Exception
                    Me.m_strtxtLP = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtLD属性
        '----------------------------------------------------------------
        Public Property txtLD() As String
            Get
                txtLD = Me.m_strtxtLD
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtLD = Value
                Catch ex As Exception
                    Me.m_strtxtLD = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtDY属性
        '----------------------------------------------------------------
        Public Property txtDY() As String
            Get
                txtDY = Me.m_strtxtDY
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtDY = Value
                Catch ex As Exception
                    Me.m_strtxtDY = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtJCSJ属性
        '----------------------------------------------------------------
        Public Property txtJCSJ() As String
            Get
                txtJCSJ = Me.m_strtxtJCSJ
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtJCSJ = Value
                Catch ex As Exception
                    Me.m_strtxtJCSJ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtLG属性
        '----------------------------------------------------------------
        Public Property txtLG() As String
            Get
                txtLG = Me.m_strtxtLG
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtLG = Value
                Catch ex As Exception
                    Me.m_strtxtLG = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtDTSL属性
        '----------------------------------------------------------------
        Public Property txtDTSL() As String
            Get
                txtDTSL = Me.m_strtxtDTSL
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtDTSL = Value
                Catch ex As Exception
                    Me.m_strtxtDTSL = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtLCHS属性
        '----------------------------------------------------------------
        Public Property txtLCHS() As String
            Get
                txtLCHS = Me.m_strtxtLCHS
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtLCHS = Value
                Catch ex As Exception
                    Me.m_strtxtLCHS = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtLPQS属性
        '----------------------------------------------------------------
        Public Property txtLPQS() As String
            Get
                txtLPQS = Me.m_strtxtLPQS
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtLPQS = Value
                Catch ex As Exception
                    Me.m_strtxtLPQS = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtJGFS属性
        '----------------------------------------------------------------
        Public Property txtJGFS() As String
            Get
                txtJGFS = Me.m_strtxtJGFS
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtJGFS = Value
                Catch ex As Exception
                    Me.m_strtxtJGFS = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtWSSL属性
        '----------------------------------------------------------------
        Public Property txtWSSL() As String
            Get
                txtWSSL = Me.m_strtxtWSSL
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtWSSL = Value
                Catch ex As Exception
                    Me.m_strtxtWSSL = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtYTSL属性
        '----------------------------------------------------------------
        Public Property txtYTSL() As String
            Get
                txtYTSL = Me.m_strtxtYTSL
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtYTSL = Value
                Catch ex As Exception
                    Me.m_strtxtYTSL = ""
                End Try
            End Set
        End Property








        '----------------------------------------------------------------
        ' rblKJLX_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property rblKJLX_SelectedIndex() As Integer
            Get
                rblKJLX_SelectedIndex = Me.m_intSelectedIndex_rblKJLX
            End Get
            Set(ByVal Value As Integer)
                Try
                    Me.m_intSelectedIndex_rblKJLX = Value
                Catch ex As Exception
                    Me.m_intSelectedIndex_rblKJLX = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' rblFWXZ_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property rblFWXZ_SelectedIndex() As Integer
            Get
                rblFWXZ_SelectedIndex = Me.m_intSelectedIndex_rblFWXZ
            End Get
            Set(ByVal Value As Integer)
                Try
                    Me.m_intSelectedIndex_rblFWXZ = Value
                Catch ex As Exception
                    Me.m_intSelectedIndex_rblFWXZ = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' rblCX_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property rblCX_SelectedIndex() As Integer
            Get
                rblCX_SelectedIndex = Me.m_intSelectedIndex_rblCX
            End Get
            Set(ByVal Value As Integer)
                Try
                    Me.m_intSelectedIndex_rblCX = Value
                Catch ex As Exception
                    Me.m_intSelectedIndex_rblCX = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' rblWYSX_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property rblWYSX_SelectedIndex() As Integer
            Get
                rblWYSX_SelectedIndex = Me.m_intSelectedIndex_rblWYSX
            End Get
            Set(ByVal Value As Integer)
                Try
                    Me.m_intSelectedIndex_rblWYSX = Value
                Catch ex As Exception
                    Me.m_intSelectedIndex_rblWYSX = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' rblZXDC_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property rblZXDC_SelectedIndex() As Integer
            Get
                rblZXDC_SelectedIndex = Me.m_intSelectedIndex_rblZXDC
            End Get
            Set(ByVal Value As Integer)
                Try
                    Me.m_intSelectedIndex_rblZXDC = Value
                Catch ex As Exception
                    Me.m_intSelectedIndex_rblZXDC = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' rblZXNX_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property rblZXNX_SelectedIndex() As Integer
            Get
                rblZXNX_SelectedIndex = Me.m_intSelectedIndex_rblZXNX
            End Get
            Set(ByVal Value As Integer)
                Try
                    Me.m_intSelectedIndex_rblZXNX = Value
                Catch ex As Exception
                    Me.m_intSelectedIndex_rblZXNX = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' rblZYYX_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property rblZYYX_SelectedIndex() As Integer
            Get
                rblZYYX_SelectedIndex = Me.m_intSelectedIndex_rblZYYX
            End Get
            Set(ByVal Value As Integer)
                Try
                    Me.m_intSelectedIndex_rblZYYX = Value
                Catch ex As Exception
                    Me.m_intSelectedIndex_rblZYYX = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' rblJJSB_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property rblJJSB_SelectedIndex() As Integer
            Get
                rblJJSB_SelectedIndex = Me.m_intSelectedIndex_rblJJSB
            End Get
            Set(ByVal Value As Integer)
                Try
                    Me.m_intSelectedIndex_rblJJSB = Value
                Catch ex As Exception
                    Me.m_intSelectedIndex_rblJJSB = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' rblLYJT_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property rblLYJT_SelectedIndex() As Integer
            Get
                rblLYJT_SelectedIndex = Me.m_intSelectedIndex_rblLYJT
            End Get
            Set(ByVal Value As Integer)
                Try
                    Me.m_intSelectedIndex_rblLYJT = Value
                Catch ex As Exception
                    Me.m_intSelectedIndex_rblLYJT = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' rblFWJG_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property rblFWJG_SelectedIndex() As Integer
            Get
                rblFWJG_SelectedIndex = Me.m_intSelectedIndex_rblFWJG
            End Get
            Set(ByVal Value As Integer)
                Try
                    Me.m_intSelectedIndex_rblFWJG = Value
                Catch ex As Exception
                    Me.m_intSelectedIndex_rblFWJG = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' rblJGLX_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property rblJGLX_SelectedIndex() As Integer
            Get
                rblJGLX_SelectedIndex = Me.m_intSelectedIndex_rblJGLX
            End Get
            Set(ByVal Value As Integer)
                Try
                    Me.m_intSelectedIndex_rblJGLX = Value
                Catch ex As Exception
                    Me.m_intSelectedIndex_rblJGLX = -1
                End Try
            End Set
        End Property

    End Class

End Namespace
