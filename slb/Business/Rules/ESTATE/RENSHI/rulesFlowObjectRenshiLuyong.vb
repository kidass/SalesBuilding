'----------------------------------------------------------------
' Copyright (C) 2006-2016 Josco Software Corporation
' All rights reserved.
'
' This source code is intended only as a supplement to Microsoft
' Development Tools and/or on-line documentation. See these other
' materials for detailed information regarding Microsoft code samples.
'
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY 
' OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT 
' LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR 
' FITNESS FOR A PARTICULAR PURPOSE.
'----------------------------------------------------------------
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

Namespace Josco.JSOA.BusinessRules

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.BusinessRules
    ' 类名    ：rulesFlowObjectRenshiLuyong
    '
    ' 功能描述： 
    '   　人事录用审批工作流的业务规则层对象
    '----------------------------------------------------------------
    Public Class rulesFlowObjectRenshiLuyong
        Inherits Josco.JsKernal.BusinessRules.rulesFlowObject

        '----------------------------------------------------------------
        ' 构造函数
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New(Josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong.FLOWCODE, Josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong.FLOWNAME)
        End Sub

        '----------------------------------------------------------------
        ' 析构函数
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
        Public Overloads Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessRules.rulesFlowObjectRenshiLuyong)
            Try
                If Not (obj Is Nothing) Then
                    obj.Dispose()
                End If
            Catch ex As Exception
            End Try
            obj = Nothing
        End Sub











        '----------------------------------------------------------------
        ' 根据strWJBS获取“地产_B_人事_录用审批”的数据集
        '     strErrMsg                     ：如果错误，则返回错误信息
        '     strUserId                     ：用户标识
        '     strPassword                   ：用户密码
        '     strWJBS                       ：文件标识
        '     objestateRenshiXingyeData     ：信息数据集
        ' 返回
        '     True                          ：成功
        '     False                         ：失败
        '----------------------------------------------------------------
        Public Function getMainData( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWJBS As String, _
            ByRef objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean

            getMainData = False
            objestateRenshiXingyeData = Nothing

            Try
                '初始化工作流对象
                If Me.m_objFlowObject.doInitialize(strErrMsg, strUserId, strPassword, strWJBS, False) = False Then
                    GoTo errProc
                End If

                '获取数据
                Dim objDataSet As System.Data.DataSet = Nothing
                Dim strTableName As String = ""
                If Me.m_objFlowObject.getMainFlowData(strErrMsg, objDataSet, strTableName) = False Then
                    GoTo errProc
                End If

                '返回
                objestateRenshiXingyeData = CType(objDataSet, Josco.JSOA.Common.Data.estateRenshiXingyeData)
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            getMainData = True
            Exit Function
errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 根据strWJBS获取“地产_B_人事_录用审批”的数据集
        '     strErrMsg                     ：如果错误，则返回错误信息
        '     objestateRenshiXingyeData     ：信息数据集
        ' 返回
        '     True                          ：成功
        '     False                         ：失败
        '----------------------------------------------------------------
        Public Function getMainData( _
            ByRef strErrMsg As String, _
            ByRef objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean

            getMainData = False
            objestateRenshiXingyeData = Nothing

            Try
                '获取数据
                Dim objDataSet As System.Data.DataSet = Nothing
                Dim strTableName As String = ""
                If Me.m_objFlowObject.getMainFlowData(strErrMsg, objDataSet, strTableName) = False Then
                    GoTo errProc
                End If

                '返回
                objestateRenshiXingyeData = CType(objDataSet, Josco.JSOA.Common.Data.estateRenshiXingyeData)
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            getMainData = True
            Exit Function
errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取稿件模板文件名
        ' 返回
        '                    ：稿件模板文件名
        '----------------------------------------------------------------
        Public Overrides Function getGJMBFile() As String

            Try
                getGJMBFile = Josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong.FILEMBDIR_GJ
            Catch ex As Exception
                getGJMBFile = ""
            End Try

        End Function

        '----------------------------------------------------------------
        ' 获取稿件文件的FTP路径名
        ' 返回
        '                    ：稿件文件的FTP路径名
        '----------------------------------------------------------------
        Public Overrides Function getGJFTPFile() As String

            Try
                Dim objBaseFlowRenshiLuyong As Josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong
                objBaseFlowRenshiLuyong = CType(Me.FlowData, Josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong)
                getGJFTPFile = objBaseFlowRenshiLuyong.ZWNR
            Catch ex As Exception
                getGJFTPFile = ""
            End Try

        End Function

        '----------------------------------------------------------------
        ' 获取指定机关代字+文件年份新的文件序号
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strJGDZ              ：机关代字
        '     strWJNF              ：文件年份
        '     strWJXH              ：(返回)文件序号
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function getNewWjxh( _
            ByRef strErrMsg As String, _
            ByVal strJGDZ As String, _
            ByVal strWJNF As String, _
            ByRef strWJXH As String) As Boolean

            getNewWjxh = False
            Try
                Dim objBaseFlowRenshiLuyong As Josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong
                objBaseFlowRenshiLuyong = CType(Me.FlowData, Josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong)
                Dim objFlowObjectRenshiLuyong As Josco.JSOA.DataAccess.FlowObjectRenshiLuyong
                objFlowObjectRenshiLuyong = CType(Me.m_objFlowObject, Josco.JSOA.DataAccess.FlowObjectRenshiLuyong)
                getNewWjxh = objFlowObjectRenshiLuyong.getNewWjxh(strErrMsg, strJGDZ, strWJNF, strWJXH)
            Catch ex As Exception
                strErrMsg = ex.Message
                getNewWjxh = False
            End Try

        End Function

        '----------------------------------------------------------------
        ' 获取“地产_B_人事_录用审批_人员信息”数据集(以“人员序号”升序排列)
        '     strErrMsg                        ：如果错误，则返回错误信息
        '     objestateRenshiXingyeData        ：返回数据
        ' 返回
        '     True                             ：成功
        '     False                            ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_RYXX( _
            ByRef strErrMsg As String, _
            ByRef objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            getDataSet_RYXX = False
            Try
                Dim objFlowObjectRenshiLuyong As Josco.JSOA.DataAccess.FlowObjectRenshiLuyong
                objFlowObjectRenshiLuyong = CType(Me.m_objFlowObject, Josco.JSOA.DataAccess.FlowObjectRenshiLuyong)
                getDataSet_RYXX = objFlowObjectRenshiLuyong.getDataSet_RYXX(strErrMsg, objestateRenshiXingyeData)
            Catch ex As Exception
                strErrMsg = ex.Message
                getDataSet_RYXX = False
            End Try
        End Function

        '----------------------------------------------------------------
        ' 获取strUserXM能够查看的“地产_B_人事_录用审批”完全数据的数据集(以“经办日期”降序排序)
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserXM                  ：用户名称
        '     strWhere                   ：搜索字符串
        '     objestateRenshiXingyeData  ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_Main( _
            ByRef strErrMsg As String, _
            ByVal strUserXM As String, _
            ByVal strWhere As String, _
            ByRef objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            getDataSet_Main = False
            Try
                Dim objFlowObjectRenshiLuyong As Josco.JSOA.DataAccess.FlowObjectRenshiLuyong
                objFlowObjectRenshiLuyong = CType(Me.m_objFlowObject, Josco.JSOA.DataAccess.FlowObjectRenshiLuyong)
                getDataSet_Main = objFlowObjectRenshiLuyong.getDataSet_Main(strErrMsg, strUserXM, strWhere, objestateRenshiXingyeData)
            Catch ex As Exception
                strErrMsg = ex.Message
                getDataSet_Main = False
            End Try
        End Function

    End Class 'rulesFlowObjectRenshiLuyong



    '----------------------------------------------------------------
    ' 命名空间：Josco.JsKernal.DataAccess
    ' 类名    ：FlowObjectRenshiLuyongCreator
    '
    ' 功能描述： 
    '     FlowObjectRenshiLuyong的创建接口实现
    '----------------------------------------------------------------
    Public Class rulesFlowObjectRenshiLuyongCreator
        Implements Josco.JsKernal.BusinessRules.IRulesFlowObjectCreate

        '----------------------------------------------------------------
        ' 构造函数
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()
        End Sub

        '----------------------------------------------------------------
        ' 实现接口
        '----------------------------------------------------------------
        Public Function Create( _
            ByVal strFlowType As String, _
            ByVal strFlowTypeName As String) As Josco.JsKernal.BusinessRules.rulesFlowObject _
            Implements Josco.JsKernal.BusinessRules.IRulesFlowObjectCreate.Create

            Try
                Create = New Josco.JSOA.BusinessRules.rulesFlowObjectRenshiLuyong
            Catch ex As Exception
                Throw ex
            End Try

        End Function

    End Class

End Namespace 'Josco.JsKernal.BusinessRules
