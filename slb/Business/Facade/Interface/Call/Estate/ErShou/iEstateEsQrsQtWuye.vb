Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.BusinessFacade
    ' 类名    ：IEstateEsQrsQtWuye
    '
    ' 功能描述： 
    '     estate_es_qrsqt_wuye.aspx模块调用接口的定义与处理
    '----------------------------------------------------------------
    <Serializable()> Public Class IEstateEsQrsQtWuye
        Inherits Josco.JsKernal.BusinessFacade.ICallInterface

        '----------------------------------------------------------------
        'QueryString Parameters
        '----------------------------------------------------------------

        '----------------------------------------------------------------
        '输入参数
        '----------------------------------------------------------------
        Private m_objenumEditType_I As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType
        Private m_objValues_I As System.Collections.Specialized.NameValueCollection
        Private m_intSelectedIndex_I As Integer
        Private m_strQRSH_I As String

        '----------------------------------------------------------------
        '输出参数
        '----------------------------------------------------------------
        Private m_objValues_O As System.Collections.Specialized.NameValueCollection
        Private m_blnExitMode_O As Boolean












        '----------------------------------------------------------------
        ' 构造函数
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()

            '初始化父类参数
            MyBase.iInterfaceType = Josco.JsKernal.BusinessFacade.ICallInterface.enumInterfaceType.InputAndOutput

            '初始化输入参数
            Me.m_objenumEditType_I = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect
            Me.m_intSelectedIndex_I = -1
            Me.m_strQRSH_I = ""
            Me.m_objValues_I = Nothing

            '初始化输出参数
            Me.m_blnExitMode_O = False
            Me.m_objValues_O = Nothing
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
        Public Overloads Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IEstateEsQrsQtWuye)
            Try
                If Not (obj Is Nothing) Then
                    Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(obj.m_objValues_I)
                    Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(obj.m_objValues_O)
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
                iMode = Me.m_objenumEditType_I
            End Get
            Set(ByVal Value As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType)
                Try
                    Me.m_objenumEditType_I = Value
                Catch ex As Exception
                    Me.m_objenumEditType_I = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' iRowNo属性
        '----------------------------------------------------------------
        Public Property iRowNo() As Integer
            Get
                iRowNo = Me.m_intSelectedIndex_I
            End Get
            Set(ByVal Value As Integer)
                Try
                    Me.m_intSelectedIndex_I = Value
                Catch ex As Exception
                    Me.m_intSelectedIndex_I = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' iQRSH属性
        '----------------------------------------------------------------
        Public Property iQRSH() As String
            Get
                iQRSH = Me.m_strQRSH_I
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strQRSH_I = Value
                Catch ex As Exception
                    Me.m_strQRSH_I = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' iValues属性
        '----------------------------------------------------------------
        Public Property iValues() As System.Collections.Specialized.NameValueCollection
            Get
                iValues = Me.m_objValues_I
            End Get
            Set(ByVal Value As System.Collections.Specialized.NameValueCollection)
                Try
                    Me.m_objValues_I = Value
                Catch ex As Exception
                    Me.m_objValues_I = Nothing
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

        '----------------------------------------------------------------
        ' oValues属性
        '----------------------------------------------------------------
        Public Property oValues() As System.Collections.Specialized.NameValueCollection
            Get
                oValues = Me.m_objValues_O
            End Get
            Set(ByVal Value As System.Collections.Specialized.NameValueCollection)
                Try
                    Me.m_objValues_O = Value
                Catch ex As Exception
                    Me.m_objValues_O = Nothing
                End Try
            End Set
        End Property

    End Class

End Namespace
