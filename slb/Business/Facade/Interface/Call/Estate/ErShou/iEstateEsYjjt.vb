Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.BusinessFacade
    ' 类名    ：IEstateEsYjjt
    '
    ' 功能描述： 
    '     estate_es_yjjt.aspx模块调用接口的定义与处理
    '----------------------------------------------------------------
    <Serializable()> Public Class IEstateEsYjjt
        Inherits Josco.JsKernal.BusinessFacade.ICallInterface

        '----------------------------------------------------------------
        'QueryString Parameters
        '----------------------------------------------------------------

        '----------------------------------------------------------------
        '输入参数
        '----------------------------------------------------------------
        Private m_strRYDM_I As String  '查询人员
        Private m_intYJBZ_I As Integer '业绩标志

        '----------------------------------------------------------------
        '输出参数
        '----------------------------------------------------------------
        Private m_blnExitMode_O As Boolean 'True-确定 False-取消











        '----------------------------------------------------------------
        ' 构造函数
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()

            '初始化父类参数
            MyBase.iInterfaceType = Josco.JsKernal.BusinessFacade.ICallInterface.enumInterfaceType.InputAndOutput

            '初始化输入参数
            Me.m_strRYDM_I = ""
            Me.m_intYJBZ_I = 0

            '初始化输出参数
            Me.m_blnExitMode_O = False

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
        Public Overloads Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IEstateEsYjjt)
            Try
                If Not (obj Is Nothing) Then
                    obj.Dispose()
                End If
            Catch ex As Exception
            End Try
            obj = Nothing
        End Sub









        '----------------------------------------------------------------
        ' iRYDM属性
        '----------------------------------------------------------------
        Public Property iRYDM() As String
            Get
                iRYDM = Me.m_strRYDM_I
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strRYDM_I = Value
                Catch ex As Exception
                    Me.m_strRYDM_I = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' iYJBZ属性
        '----------------------------------------------------------------
        Public Property iYJBZ() As Integer
            Get
                iYJBZ = Me.m_intYJBZ_I
            End Get
            Set(ByVal Value As Integer)
                Try
                    Me.m_intYJBZ_I = Value
                Catch ex As Exception
                    Me.m_intYJBZ_I = 0
                End Try
            End Set
        End Property










        '----------------------------------------------------------------
        ' oExitMode属性
        '----------------------------------------------------------------
        Public Property oExitMode() As Boolean
            Get
                oExitMode = Me.m_blnExitMode_O
            End Get
            Set(ByVal Value As Boolean)
                Try
                    Me.m_blnExitMode_O = Value
                Catch ex As Exception
                    Me.m_blnExitMode_O = False
                End Try
            End Set
        End Property

    End Class

End Namespace
