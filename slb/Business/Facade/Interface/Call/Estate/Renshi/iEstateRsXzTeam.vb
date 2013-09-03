Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.BusinessFacade
    ' 类名    ：IEstateRsXzTeam
    '
    ' 功能描述： 
    '     estate_rs_xz_team.aspx模块调用接口的定义与处理
    '----------------------------------------------------------------
    <Serializable()> Public Class IEstateRsXzTeam
        Inherits Josco.JsKernal.BusinessFacade.ICallInterface

        '----------------------------------------------------------------
        '输入参数
        '----------------------------------------------------------------
        Private m_blnMultiSelect_I As Boolean                                   '多重选择?false-不能,true-能(缺省)
        Private m_blnAllowNull_I As Boolean                                     '允许空值?false-不能,true-能(缺省)
        Private m_strFixQuery_I As String                                       '限制条件
        Private m_strJCSJ_I As String                                           '检测时间

        '----------------------------------------------------------------
        '输出参数
        '----------------------------------------------------------------
        Private m_blnExitMode_O As Boolean                                      '退出方式：True-确定，False-取消
        Private m_objDataSet_O As Josco.JSOA.Common.Data.estateRenshiXingyeData '选定数据集







        '----------------------------------------------------------------
        ' 构造函数
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()

            '初始化父类参数
            MyBase.iInterfaceType = Josco.JsKernal.BusinessFacade.ICallInterface.enumInterfaceType.InputAndOutput

            '初始化输入参数
            m_blnMultiSelect_I = True
            m_blnAllowNull_I = True
            m_strFixQuery_I = ""
            m_strJCSJ_I = ""

            '初始化输出参数
            m_blnExitMode_O = False
            m_objDataSet_O = Nothing
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
            Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(m_objDataSet_O)
        End Sub

        '----------------------------------------------------------------
        ' 安全释放本身资源
        '----------------------------------------------------------------
        Public Overloads Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IEstateRsXzTeam)
            Try
                If Not (obj Is Nothing) Then
                    obj.Dispose()
                End If
            Catch ex As Exception
            End Try
            obj = Nothing
        End Sub












        '----------------------------------------------------------------
        ' iMultiSelect属性
        '----------------------------------------------------------------
        Public Property iMultiSelect() As Boolean
            Get
                iMultiSelect = m_blnMultiSelect_I
            End Get
            Set(ByVal Value As Boolean)
                Try
                    m_blnMultiSelect_I = Value
                Catch ex As Exception
                    m_blnMultiSelect_I = False
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' iAllowNull属性
        '----------------------------------------------------------------
        Public Property iAllowNull() As Boolean
            Get
                iAllowNull = m_blnAllowNull_I
            End Get
            Set(ByVal Value As Boolean)
                Try
                    m_blnAllowNull_I = Value
                Catch ex As Exception
                    m_blnAllowNull_I = False
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' iFixQuery属性
        '----------------------------------------------------------------
        Public Property iFixQuery() As String
            Get
                iFixQuery = m_strFixQuery_I
            End Get
            Set(ByVal Value As String)
                Try
                    m_strFixQuery_I = Value
                Catch ex As Exception
                    m_strFixQuery_I = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' iJCSJ属性
        '----------------------------------------------------------------
        Public Property iJCSJ() As String
            Get
                iJCSJ = m_strJCSJ_I
            End Get
            Set(ByVal Value As String)
                Try
                    m_strJCSJ_I = Value
                Catch ex As Exception
                    m_strJCSJ_I = ""
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

        '----------------------------------------------------------------
        ' oDataSet属性
        '----------------------------------------------------------------
        Public Property oDataSet() As Josco.JSOA.Common.Data.estateRenshiXingyeData
            Get
                oDataSet = m_objDataSet_O
            End Get
            Set(ByVal Value As Josco.JSOA.Common.Data.estateRenshiXingyeData)
                Try
                    m_objDataSet_O = Value
                Catch ex As Exception
                    m_objDataSet_O = Nothing
                End Try
            End Set
        End Property

    End Class

End Namespace
