Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.BusinessFacade
    ' 类名    ：IEstateEsHetongFpbl
    '
    ' 功能描述： 
    '     estate_es_hetong_fpbl.aspx模块调用接口的定义与处理
    '----------------------------------------------------------------
    <Serializable()> Public Class IEstateEsHetongFpbl
        Inherits Josco.JsKernal.BusinessFacade.ICallInterface

        '----------------------------------------------------------------
        'QueryString Parameters
        '----------------------------------------------------------------

        '----------------------------------------------------------------
        '输入参数
        '----------------------------------------------------------------
        'zengxianglin 2009-02-24
        Private m_blnEnforcedEdit_I As Boolean
        'zengxianglin 2009-02-24
        Private m_strQRSH_I As String

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
            'zengxianglin 2009-02-24
            m_blnEnforcedEdit_I = False
            'zengxianglin 2009-02-24
            m_strQRSH_I = ""

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
        Public Overloads Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IEstateEsHetongFpbl)
            Try
                If Not (obj Is Nothing) Then
                    obj.Dispose()
                End If
            Catch ex As Exception
            End Try
            obj = Nothing
        End Sub









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

        'zengxianglin 2009-02-24
        '----------------------------------------------------------------
        ' iEnforcedEdit属性
        '----------------------------------------------------------------
        Public Property iEnforcedEdit() As Boolean
            Get
                iEnforcedEdit = m_blnEnforcedEdit_I
            End Get
            Set(ByVal Value As Boolean)
                Try
                    m_blnEnforcedEdit_I = Value
                Catch ex As Exception
                    m_blnEnforcedEdit_I = False
                End Try
            End Set
        End Property
        'zengxianglin 2009-02-24










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
