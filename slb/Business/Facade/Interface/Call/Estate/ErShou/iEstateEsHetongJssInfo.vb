Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.BusinessFacade
    ' 类名    ：IEstateEsHetongJssInfo
    '
    ' 功能描述： 
    '     estate_es_hetong_jss_info.aspx模块调用接口的定义与处理
    '----------------------------------------------------------------
    <Serializable()> Public Class IEstateEsHetongJssInfo
        Inherits Josco.JsKernal.BusinessFacade.ICallInterface

        '----------------------------------------------------------------
        'QueryString Parameters
        '----------------------------------------------------------------

        '----------------------------------------------------------------
        '输入参数
        '----------------------------------------------------------------
        Private m_objEditMode_I As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType
        Private m_strQRSH_I As String
        Private m_strJSSH_I As String

        '----------------------------------------------------------------
        '输出参数
        '----------------------------------------------------------------
        Private m_blnExitMode_O As Boolean











        '----------------------------------------------------------------
        ' 构造函数
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()

            '初始化父类参数
            MyBase.iInterfaceType = Josco.JsKernal.BusinessFacade.ICallInterface.enumInterfaceType.InputAndOutput

            '初始化输入参数
            m_objEditMode_I = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect
            m_strQRSH_I = ""
            m_strJSSH_I = ""

            '初始化输出参数
            m_blnExitMode_O = False

        End Sub

        '----------------------------------------------------------------
        ' 重载父类的析构函数
        '----------------------------------------------------------------
        Public Overloads Sub Dispose()
            MyBase.Dispose()
            Dispose(True)
        End Sub

        '----------------------------------------------------------------
        ' 释放本身资源
        '----------------------------------------------------------------
        Protected Overloads Sub Dispose(ByVal disposing As Boolean)
            If (Not disposing) Then
                Exit Sub
            End If
        End Sub

        '----------------------------------------------------------------
        ' 安全释放本身资源
        '----------------------------------------------------------------
        Public Overloads Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IEstateEsHetongJssInfo)
            Try
                If Not (obj Is Nothing) Then
                    obj.Dispose()
                End If
            Catch ex As Exception
            End Try
            obj = Nothing
        End Sub









        '----------------------------------------------------------------
        ' iMode属性
        '----------------------------------------------------------------
        Public Property iMode() As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType
            Get
                iMode = Me.m_objEditMode_I
            End Get
            Set(ByVal Value As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType)
                Try
                    Me.m_objEditMode_I = Value
                Catch ex As Exception
                    Me.m_objEditMode_I = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' iQRSH属性
        '----------------------------------------------------------------
        Public Property iQRSH() As String
            Get
                iQRSH = m_strQRSH_I
            End Get
            Set(ByVal Value As String)
                Try
                    m_strQRSH_I = Value
                Catch ex As Exception
                    m_strQRSH_I = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' iJSSH属性
        '----------------------------------------------------------------
        Public Property iJSSH() As String
            Get
                iJSSH = m_strJSSH_I
            End Get
            Set(ByVal Value As String)
                Try
                    m_strJSSH_I = Value
                Catch ex As Exception
                    m_strJSSH_I = ""
                End Try
            End Set
        End Property










        '----------------------------------------------------------------
        ' oExitMode属性
        '----------------------------------------------------------------
        Public Property oExitMode() As Boolean
            Get
                oExitMode = m_blnExitMode_O
            End Get
            Set(ByVal Value As Boolean)
                Try
                    m_blnExitMode_O = Value
                Catch ex As Exception
                    m_blnExitMode_O = False
                End Try
            End Set
        End Property

    End Class

End Namespace
