Option Strict On
Option Explicit On 

Imports System
Imports System.Data
Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic

Imports Josco.JsKernal.SystemFramework
Imports Josco.JsKernal.Common
Imports Josco.JsKernal.Common.Data
Imports Josco.JsKernal.DataAccess

Imports Josco.JSOA.Common
Imports Josco.JSOA.Common.Data
Imports Josco.JSOA.DataAccess

Namespace Josco.JSOA.BusinessRules

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.BusinessRules
    ' 类名    ：rulesGzsp
    '
    ' 功能描述： 
    '     提供对“我的事宜”模块涉及的业务逻辑层操作
    '----------------------------------------------------------------
    Public Class rulesGzsp

        '----------------------------------------------------------------
        ' 构造函数
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()
        End Sub

        '----------------------------------------------------------------
        ' 安全释放本身资源
        '----------------------------------------------------------------
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessRules.rulesGzsp)
            Try
                If Not (obj Is Nothing) Then
                    'obj.Dispose()
                End If
            Catch ex As Exception
            End Try
            obj = Nothing
        End Sub









        '----------------------------------------------------------------
        ' 获取“个人_B_我的事宜_节点”的数据集
        '     strErrMsg              ：如果错误，则返回错误信息
        '     strUserId              ：用户标识
        '     strPassword            ：用户密码
        '     objgrswMyTaskData      ：信息数据集
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
        '----------------------------------------------------------------
        Public Function getMyTaskNodeData( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef objgrswMyTaskData As Josco.JsKernal.Common.Data.grswMyTaskData) As Boolean

            Try
                With New Josco.JSOA.DataAccess.dacGzsp
                    getMyTaskNodeData = .getMyTaskNodeData(strErrMsg, strUserId, strPassword, objgrswMyTaskData)
                End With
            Catch ex As Exception
                getMyTaskNodeData = False
                strErrMsg = ex.Message
            End Try

        End Function

        '----------------------------------------------------------------
        ' 根据给定代码获取对应的数据行数据
        '     strErrMsg              ：如果错误，则返回错误信息
        '     strCode                ：给定节点代码(唯一性保证)
        '     objgrswMyTaskData      ：节点信息数据集
        '     objNodeData            ：(返回)指定节点的数据行数据
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
        '----------------------------------------------------------------
        Public Function getMyTaskNodeData( _
            ByRef strErrMsg As String, _
            ByVal strCode As String, _
            ByVal objgrswMyTaskData As Josco.JsKernal.Common.Data.grswMyTaskData, _
            ByRef objNodeData As System.Data.DataRow) As Boolean

            Try
                With New Josco.JSOA.DataAccess.dacGzsp
                    getMyTaskNodeData = .getMyTaskNodeData(strErrMsg, strCode, objgrswMyTaskData, objNodeData)
                End With
            Catch ex As Exception
                getMyTaskNodeData = False
                strErrMsg = ex.Message
            End Try

        End Function

        '----------------------------------------------------------------
        ' 根据当前选定的任务、搜索条件获取当前用户的要查看的文件数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strUserXM            ：用户名称
        '     objNodeData          ：当前任务节点数据行
        '     strWhere             ：当前搜索条件(a.)
        '     objFileData          ：返回要查看的文件数据
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function getMyTaskFileData( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strUserXM As String, _
            ByVal objNodeData As System.Data.DataRow, _
            ByVal strWhere As String, _
            ByRef objFileData As Josco.JsKernal.Common.Data.grswMyTaskData) As Boolean

            Try
                With New Josco.JSOA.DataAccess.dacGzsp
                    getMyTaskFileData = .getMyTaskFileData(strErrMsg, strUserId, strPassword, strUserXM, objNodeData, strWhere, objFileData)
                End With
            Catch ex As Exception
                getMyTaskFileData = False
                strErrMsg = ex.Message
            End Try

        End Function

        '----------------------------------------------------------------
        ' 根据当前选定的任务、搜索条件获取当前用户的要查看的任务数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strWJBS              ：要查看的文件标识
        '     strUserXM            ：用户名称
        '     objNodeData          ：当前任务节点数据行
        '     strWhere             ：当前搜索条件(a.)
        '     objTaskData          ：返回要查看的任务数据
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function getMyTaskTaskData( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWJBS As String, _
            ByVal strUserXM As String, _
            ByVal objNodeData As System.Data.DataRow, _
            ByVal strWhere As String, _
            ByRef objTaskData As Josco.JsKernal.Common.Data.grswMyTaskData) As Boolean

            Try
                With New Josco.JSOA.DataAccess.dacGzsp
                    getMyTaskTaskData = .getMyTaskTaskData(strErrMsg, strUserId, strPassword, strWJBS, strUserXM, objNodeData, strWhere, objTaskData)
                End With
            Catch ex As Exception
                getMyTaskTaskData = False
                strErrMsg = ex.Message
            End Try

        End Function

        '----------------------------------------------------------------
        ' 获取我的未办事宜数据集
        '     strErrMsg              ：如果错误，则返回错误信息
        '     strUserId              ：用户标识
        '     strPassword            ：用户密码
        '     strUserXM              ：用户名称
        '     objDataSetDBSY         ：未办事宜数据集
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
        '----------------------------------------------------------------
        Public Function getDataSetDBSY( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strUserXM As String, _
            ByRef objDataSetDBSY As Josco.JsKernal.Common.Data.grswMyTaskData) As Boolean

            Try
                With New Josco.JSOA.DataAccess.dacGzsp
                    getDataSetDBSY = .getDataSetDBSY(strErrMsg, strUserId, strPassword, strUserXM, objDataSetDBSY)
                End With
            Catch ex As Exception
                getDataSetDBSY = False
                strErrMsg = ex.Message
            End Try

        End Function

        '----------------------------------------------------------------
        ' 获取我的已经过期文件+今天要过期数据集
        '     strErrMsg              ：如果错误，则返回错误信息
        '     strUserId              ：用户标识
        '     strPassword            ：用户密码
        '     strUserXM              ：用户名称
        '     objDataSetGQSY         ：已经过期文件+今天要过期数据集
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
        '----------------------------------------------------------------
        Public Function getDataSetGQSY( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strUserXM As String, _
            ByRef objDataSetGQSY As Josco.JsKernal.Common.Data.grswMyTaskData) As Boolean

            Try
                With New Josco.JSOA.DataAccess.dacGzsp
                    getDataSetGQSY = .getDataSetGQSY(strErrMsg, strUserId, strPassword, strUserXM, objDataSetGQSY)
                End With
            Catch ex As Exception
                getDataSetGQSY = False
                strErrMsg = ex.Message
            End Try

        End Function

        '----------------------------------------------------------------
        ' 获取我的备忘提醒数据集
        '     strErrMsg              ：如果错误，则返回错误信息
        '     strUserId              ：用户标识
        '     strPassword            ：用户密码
        '     strUserXM              ：用户名称
        '     objDataSetBWTX         ：备忘提醒数据集
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
        '----------------------------------------------------------------
        Public Function getDataSetBWTX( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strUserXM As String, _
            ByRef objDataSetBWTX As Josco.JsKernal.Common.Data.grswMyTaskData) As Boolean

            Try
                With New Josco.JSOA.DataAccess.dacGzsp
                    getDataSetBWTX = .getDataSetBWTX(strErrMsg, strUserId, strPassword, strUserXM, objDataSetBWTX)
                End With
            Catch ex As Exception
                getDataSetBWTX = False
                strErrMsg = ex.Message
            End Try

        End Function

        '----------------------------------------------------------------
        ' 获取我的未办事宜数目
        '     strErrMsg              ：如果错误，则返回错误信息
        '     strUserId              ：用户标识
        '     strPassword            ：用户密码
        '     strUserXM              ：用户名称
        '     intCountDBSY           ：未办事宜数目
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
        '----------------------------------------------------------------
        Public Function getCountDBSY( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strUserXM As String, _
            ByRef intCountDBSY As Integer) As Boolean

            Try
                With New Josco.JSOA.DataAccess.dacGzsp
                    getCountDBSY = .getCountDBSY(strErrMsg, strUserId, strPassword, strUserXM, intCountDBSY)
                End With
            Catch ex As Exception
                getCountDBSY = False
                strErrMsg = ex.Message
            End Try

        End Function

        '----------------------------------------------------------------
        ' 获取我的已经过期文件+今天要过期文件数目
        '     strErrMsg              ：如果错误，则返回错误信息
        '     strUserId              ：用户标识
        '     strPassword            ：用户密码
        '     strUserXM              ：用户名称
        '     intCountGQSY           ：已经过期文件+今天要过期文件数目
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
        '----------------------------------------------------------------
        Public Function getCountGQSY( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strUserXM As String, _
            ByRef intCountGQSY As Integer) As Boolean

            Try
                With New Josco.JSOA.DataAccess.dacGzsp
                    getCountGQSY = .getCountGQSY(strErrMsg, strUserId, strPassword, strUserXM, intCountGQSY)
                End With
            Catch ex As Exception
                getCountGQSY = False
                strErrMsg = ex.Message
            End Try

        End Function

        '----------------------------------------------------------------
        ' 获取我的备忘提醒文件数目
        '     strErrMsg              ：如果错误，则返回错误信息
        '     strUserId              ：用户标识
        '     strPassword            ：用户密码
        '     strUserXM              ：用户名称
        '     intCountBWTX           ：备忘提醒文件数目
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
        '----------------------------------------------------------------
        Public Function getCountBWTX( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strUserXM As String, _
            ByRef intCountBWTX As Integer) As Boolean

            Try
                With New Josco.JSOA.DataAccess.dacGzsp
                    getCountBWTX = .getCountBWTX(strErrMsg, strUserId, strPassword, strUserXM, intCountBWTX)
                End With
            Catch ex As Exception
                getCountBWTX = False
                strErrMsg = ex.Message
            End Try

        End Function

        '----------------------------------------------------------------
        ' 获取指定时间后收到的文件数目
        '     strErrMsg              ：如果错误，则返回错误信息
        '     strUserId              ：用户标识
        '     strPassword            ：用户密码
        '     strUserXM              ：用户名称
        '     strZDSJ                ：指定时间(日期+时间格式)
        '     intCountRecv           ：文件数目
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
        '----------------------------------------------------------------
        Public Function getCountRecv( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strUserXM As String, _
            ByVal strZDSJ As String, _
            ByRef intCountRecv As Integer) As Boolean

            Try
                With New Josco.JSOA.DataAccess.dacGzsp
                    getCountRecv = .getCountRecv(strErrMsg, strUserId, strPassword, strUserXM, strZDSJ, intCountRecv)
                End With
            Catch ex As Exception
                getCountRecv = False
                strErrMsg = ex.Message
            End Try

        End Function

    End Class 'rulesGzsp

End Namespace 'Josco.JSOA.BusinessRules
