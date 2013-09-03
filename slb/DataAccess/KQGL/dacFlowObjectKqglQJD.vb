
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

Imports Microsoft.VisualBasic

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient

Imports Josco.JSOA.Common
Imports Josco.JSOA.Common.Data
Imports Josco.JsKernal.SystemFramework
Imports Josco.JSOA.DataAccess.FlowObject
Imports Josco.JsKernal.Common
Imports Josco.JsKernal.Common.Data
Imports Josco.JsKernal.DataAccess.FlowObject

Namespace Josco.JSOA.DataAccess

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.DataAccess
    ' 类名    ：FlowObjectKqglQJD
    '
    ' 功能描述： 
    '     人事入职审批工作流
    '----------------------------------------------------------------
    Public Class FlowObjectKqglQJD
        Inherits Josco.JSOA.DataAccess.FlowObject

        '流水号发放表/视图名称
        Private TABLE_FOR_NEWLSH As String = "考勤_B_休假申请单"











        '----------------------------------------------------------------
        ' 构造函数
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New(Josco.JSOA.Common.Workflow.BaseFlowKqglQJD.FLOWCODE, Josco.JSOA.Common.Workflow.BaseFlowKqglQJD.FLOWNAME)
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
        Public Overloads Shared Sub SafeRelease(ByRef obj As Josco.JSOA.DataAccess.FlowObjectKqglQJD)
            Try
                If Not (obj Is Nothing) Then
                    obj.Dispose()
                End If

            Catch ex As Exception
            End Try
            obj = Nothing
        End Sub













        '----------------------------------------------------------------
        ' 获取缺省意见内容
        '     strYjlx              ：审批事宜
        ' 返回
        '                          ：办理标志
        '----------------------------------------------------------------
        Public Overrides Function getDefaultYJNR(ByVal strYJLX As String) As String
            getDefaultYJNR = "同意。"
        End Function

        '----------------------------------------------------------------
        ' 判断strUserXM是否可以填写承办的办理结果?
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserXM            ：人员名称
        '     blnCanWrite          ：返回：是否可以?
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Overrides Function canWriteChengbanResult( _
            ByRef strErrMsg As String, _
            ByVal strUserXM As String, _
            ByRef blnCanWrite As Boolean) As Boolean
            strErrMsg = "错误：[" + MyBase.FlowTypeName + "]不支持[canWriteChengbanResult]操作！"
            canWriteChengbanResult = False
        End Function

        '----------------------------------------------------------------
        ' 判断strUserXM是否可以加印文件?
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserXM            ：人员名称
        '     blnCanJiayin         ：返回：是否可以?
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Overrides Function canJiayinFile( _
            ByRef strErrMsg As String, _
            ByVal strUserXM As String, _
            ByRef blnCanJiayin As Boolean) As Boolean
            strErrMsg = "错误：[" + MyBase.FlowTypeName + "]不支持[canJiayinFile]操作！"
            canJiayinFile = False
        End Function

        '----------------------------------------------------------------
        ' 判断strUserXM是否登记办理结果?
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserXM            ：人员名称
        '     blnCan               ：返回：是否可以?
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Overrides Function canDengjiBLJG( _
            ByRef strErrMsg As String, _
            ByVal strUserXM As String, _
            ByRef blnCan As Boolean) As Boolean
            canDengjiBLJG = Me.canWriteChengbanResult(strErrMsg, strUserXM, blnCan)
        End Function

        '----------------------------------------------------------------
        ' 判断strUserXM是否承办过文件?
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserXM            ：用户名称
        '     strXBBZ              ：如果承办过，则返回协办标志
        '     blnHasChengban       ：返回是否承办过文件?
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Overrides Function isRenyuanHasChengban( _
            ByRef strErrMsg As String, _
            ByVal strUserXM As String, _
            ByRef strXBBZ As String, _
            ByRef blnHasChengban As Boolean) As Boolean
            strErrMsg = "错误：[" + MyBase.FlowTypeName + "]不支持[isRenyuanHasChengban]操作！"
            isRenyuanHasChengban = False
        End Function













        '----------------------------------------------------------------
        ' 判断文件是否正常办理完毕?
        '     strErrMsg            ：如果错误，则返回错误信息
        '     blnComplete          ：返回是否办理完毕?
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Overrides Function isFileComplete( _
            ByRef strErrMsg As String, _
            ByRef blnComplete As Boolean) As Boolean

            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objDataSet As System.Data.DataSet = Nothing
            Dim strSQL As String = ""

            isFileComplete = False
            blnComplete = False
            strErrMsg = ""

            Try
                '检查
                If Me.IsInitialized = False Then
                    strErrMsg = "错误：[isFileComplete]对象还没有初始化，不能使用！"
                    GoTo errProc
                End If

                '获取文件已完成列表
                Dim strFileYWCStatus As String = Me.FlowData.FILESTATUS_YWC

                '获取文件标识
                Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Me.SqlConnection
                Dim strWJBS As String = Me.WJBS

                '计算
                If Me.IsFillData = False Then
                    '获取数据
                    strSQL = ""
                    strSQL = strSQL + " select * from 考勤_B_休假申请单 " + vbCr
                    strSQL = strSQL + " where 文件标识 = '" + strWJBS + "' " + vbCr
                    strSQL = strSQL + " and   办理状态 = '" + strFileYWCStatus + "' " + vbCr
                    If objdacCommon.getDataSetBySQL(strErrMsg, objSqlConnection, strSQL, objDataSet) = False Then
                        GoTo errProc
                    End If
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        blnComplete = True
                    End If
                Else
                    Dim objBaseFlowKqglQJD As Josco.JSOA.Common.Workflow.BaseFlowKqglQJD
                    objBaseFlowKqglQJD = CType(Me.FlowData, Josco.JSOA.Common.Workflow.BaseFlowKqglQJD)
                    Select Case objBaseFlowKqglQJD.BLZT
                        Case strFileYWCStatus
                            blnComplete = True
                        Case Else
                    End Select
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            isFileComplete = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 判断文件是否已经定稿?
        '     strErrMsg            ：如果错误，则返回错误信息
        '     blnDinggao           ：返回是否已经定稿?
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Overrides Function isFileDinggao( _
            ByRef strErrMsg As String, _
            ByRef blnDinggao As Boolean) As Boolean

            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objDataSet As System.Data.DataSet
            Dim strSQL As String

            isFileDinggao = False
            blnDinggao = False
            strErrMsg = ""

            Try
                '检查
                If Me.IsInitialized = False Then
                    strErrMsg = "错误：[isFileDinggao]对象还没有初始化，不能使用！"
                    GoTo errProc
                End If

                '获取文件已定稿列表
                Dim strFileYDGList As String = Me.FlowData.FileStatusYDGList

                '获取文件标识
                Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Me.SqlConnection
                Dim strWJBS As String = Me.WJBS

                '计算
                If Me.IsFillData = False Then
                    '获取数据
                    strSQL = ""
                    strSQL = strSQL + " select * from 考勤_B_休假申请单 " + vbCr
                    strSQL = strSQL + " where 文件标识 = '" + strWJBS + "' " + vbCr
                    strSQL = strSQL + " and   办理状态 in (" + strFileYDGList + ") " + vbCr
                    If objdacCommon.getDataSetBySQL(strErrMsg, objSqlConnection, strSQL, objDataSet) = False Then
                        GoTo errProc
                    End If
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        blnDinggao = True
                    End If
                Else
                    Dim objBaseFlowKqglQJD As Josco.JSOA.Common.Workflow.BaseFlowKqglQJD
                    objBaseFlowKqglQJD = CType(Me.FlowData, Josco.JSOA.Common.Workflow.BaseFlowKqglQJD)
                    Dim strBLZT As String
                    strBLZT = "'" + objBaseFlowKqglQJD.BLZT + "'"
                    If strFileYDGList.IndexOf(strBLZT) >= 0 Then
                        blnDinggao = True
                    End If
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            isFileDinggao = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 判断文件是否已经作废?
        '     strErrMsg            ：如果错误，则返回错误信息
        '     blnZuofei            ：返回是否已经作废?
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Overrides Function isFileZuofei( _
            ByRef strErrMsg As String, _
            ByRef blnZuofei As Boolean) As Boolean

            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objDataSet As System.Data.DataSet
            Dim strSQL As String

            isFileZuofei = False
            blnZuofei = False
            strErrMsg = ""

            Try
                '检查
                If Me.IsInitialized = False Then
                    strErrMsg = "错误：[isFileZuofei]对象还没有初始化，不能使用！"
                    GoTo errProc
                End If

                '获取文件已作废列表
                Dim strFileYZFStatus As String = Me.FlowData.FILESTATUS_YZF

                '获取文件标识
                Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Me.SqlConnection
                Dim strWJBS As String = Me.WJBS

                '计算
                If Me.IsFillData = False Then
                    '获取数据
                    strSQL = ""
                    strSQL = strSQL + " select * from 考勤_B_休假申请单 " + vbCr
                    strSQL = strSQL + " where 文件标识 = '" + strWJBS + "' " + vbCr
                    strSQL = strSQL + " and   办理状态 = '" + strFileYZFStatus + "' " + vbCr
                    If objdacCommon.getDataSetBySQL(strErrMsg, objSqlConnection, strSQL, objDataSet) = False Then
                        GoTo errProc
                    End If
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        blnZuofei = True
                    End If
                Else
                    Dim objBaseFlowKqglQJD As Josco.JSOA.Common.Workflow.BaseFlowKqglQJD
                    objBaseFlowKqglQJD = CType(Me.FlowData, Josco.JSOA.Common.Workflow.BaseFlowKqglQJD)
                    Select Case objBaseFlowKqglQJD.BLZT
                        Case strFileYZFStatus
                            blnZuofei = True
                        Case Else
                    End Select
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            isFileZuofei = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 判断文件是否已经停办?
        '     strErrMsg            ：如果错误，则返回错误信息
        '     blnTingban           ：返回是否已经停办?
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Overrides Function isFileTingban( _
            ByRef strErrMsg As String, _
            ByRef blnTingban As Boolean) As Boolean

            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objDataSet As System.Data.DataSet
            Dim strSQL As String

            isFileTingban = False
            blnTingban = False
            strErrMsg = ""

            Try
                '检查
                If Me.IsInitialized = False Then
                    strErrMsg = "错误：[isFileTingban]对象还没有初始化，不能使用！"
                    GoTo errProc
                End If

                '获取文件已缓办列表
                Dim strFileYTBStatus As String = Me.FlowData.FILESTATUS_YTB

                '获取文件标识
                Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Me.SqlConnection
                Dim strWJBS As String = Me.WJBS

                '计算
                If Me.IsFillData = False Then
                    '获取数据
                    strSQL = ""
                    strSQL = strSQL + " select * from 考勤_B_休假申请单 " + vbCr
                    strSQL = strSQL + " where 文件标识 = '" + strWJBS + "' " + vbCr
                    strSQL = strSQL + " and   办理状态 = '" + strFileYTBStatus + "' " + vbCr
                    If objdacCommon.getDataSetBySQL(strErrMsg, objSqlConnection, strSQL, objDataSet) = False Then
                        GoTo errProc
                    End If
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        blnTingban = True
                    End If
                Else
                    Dim objBaseFlowKqglQJD As Josco.JSOA.Common.Workflow.BaseFlowKqglQJD
                    objBaseFlowKqglQJD = CType(Me.FlowData, Josco.JSOA.Common.Workflow.BaseFlowKqglQJD)
                    Select Case objBaseFlowKqglQJD.BLZT
                        Case strFileYTBStatus
                            blnTingban = True
                        Case Else
                    End Select
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            isFileTingban = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 判断strUserXM是否是文件的原始作者?
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserXM            ：人员名称
        '     blnIs                ：返回是否?
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Overrides Function isOriginalPeople( _
            ByRef strErrMsg As String, _
            ByVal strUserXM As String, _
            ByRef blnIs As Boolean) As Boolean

            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objDataSet As System.Data.DataSet
            Dim strSQL As String

            isOriginalPeople = False
            blnIs = False
            strErrMsg = ""

            Try
                '检查
                If Me.IsInitialized = False Then
                    strErrMsg = "错误：[isOriginalPeople]对象还没有初始化，不能使用！"
                    GoTo errProc
                End If

                '获取文件标识
                Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Me.SqlConnection
                Dim strWJBS As String = Me.WJBS

                '计算
                If Me.IsFillData = False Then
                    '获取数据
                    strSQL = ""
                    strSQL = strSQL + " select * from 考勤_B_休假申请单 " + vbCr
                    strSQL = strSQL + " where 文件标识 = '" + strWJBS + "' " + vbCr
                    strSQL = strSQL + " and   经办人员 = '" + strUserXM + "' " + vbCr
                    If objdacCommon.getDataSetBySQL(strErrMsg, objSqlConnection, strSQL, objDataSet) = False Then
                        GoTo errProc
                    End If
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        blnIs = True
                    End If
                Else
                    Dim objBaseFlowKqglQJD As Josco.JSOA.Common.Workflow.BaseFlowKqglQJD
                    objBaseFlowKqglQJD = CType(Me.FlowData, Josco.JSOA.Common.Workflow.BaseFlowKqglQJD)
                    Select Case objBaseFlowKqglQJD.NGR
                        Case strUserXM
                            blnIs = True
                        Case Else
                    End Select
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            isOriginalPeople = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 判断strBLSY是否已经批准?
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strBLSY              ：事宜名称
        '     blnApproved          ：返回是否?
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Overrides Function isTaskApproved( _
            ByRef strErrMsg As String, _
            ByVal strBLSY As String, _
            ByRef blnApproved As Boolean) As Boolean

            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objDataSet As System.Data.DataSet
            Dim strSQL As String

            isTaskApproved = False
            blnApproved = False
            strErrMsg = ""

            Try
                '检查
                If Me.IsInitialized = False Then
                    strErrMsg = "错误：[isTaskApproved]对象还没有初始化，不能使用！"
                    GoTo errProc
                End If
                If strBLSY Is Nothing Then strBLSY = ""
                strBLSY = strBLSY.Trim()

                '获取文件标识
                Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Me.SqlConnection
                Dim strWJBS As String = Me.WJBS
                Dim strBLLX As String = Me.FlowTypeName

                '获取数据
                Select Case strBLSY
                    Case Josco.JSOA.Common.Workflow.BaseFlowKqglQJD.TASK_QFWJ
                        If Me.IsFillData = False Then
                            strSQL = ""
                            strSQL = strSQL + " select * from 考勤_B_休假申请单 " + vbCr
                            strSQL = strSQL + " where 文件标识 = '" + strWJBS + "' " + vbCr
                            strSQL = strSQL + " and len(rtrim(isnull(签发人,' '))) > 0 " + vbCr
                        Else
                            Dim objBaseFlowKqglQJD As Josco.JSOA.Common.Workflow.BaseFlowKqglQJD
                            objBaseFlowKqglQJD = CType(Me.FlowData, Josco.JSOA.Common.Workflow.BaseFlowKqglQJD)
                            Select Case objBaseFlowKqglQJD.QFR
                                Case ""
                                Case Else
                                    blnApproved = True
                            End Select
                            Exit Try
                        End If

                    Case Else
                        strSQL = ""
                        strSQL = strSQL + " select * from 公文_B_办理 " + vbCr
                        strSQL = strSQL + " where 文件标识 = '" + strWJBS + "' " + vbCr
                        strSQL = strSQL + " and   办理类型 = '" + strBLLX + "' " + vbCr
                        strSQL = strSQL + " and   办理子类 = '" + strBLSY + "' " + vbCr
                        strSQL = strSQL + " and   是否批准 like '11%' " + vbCr
                End Select
                If objdacCommon.getDataSetBySQL(strErrMsg, objSqlConnection, strSQL, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    blnApproved = True
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            isTaskApproved = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 判断strBLSY是否为审批事宜？
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strBLSY              ：事宜名称
        '     intLevel             ：事宜级别
        '     blnIsShenpi          ：返回：是否？
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Overloads Overrides Function isShenpiTask( _
            ByRef strErrMsg As String, _
            ByVal strBLSY As String, _
            ByVal intLevel As Integer, _
            ByRef blnIsShenpi As Boolean) As Boolean

            isShenpiTask = False
            blnIsShenpi = False

            Try
                '检查
                If Me.IsInitialized = False Then
                    strErrMsg = "错误：[isShenpiTask]对象还没有初始化，不能使用！"
                    GoTo errProc
                End If
                If strBLSY Is Nothing Then strBLSY = ""
                strBLSY = strBLSY.Trim()

                '计算
                If intLevel <= 10 Then
                    blnIsShenpi = False
                Else
                    blnIsShenpi = True
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            isShenpiTask = True
            Exit Function
errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 判断strBLSY是否为审批事宜？
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strBLSY              ：事宜名称
        '     blnIsShenpi          ：返回：是否？
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Overloads Overrides Function isShenpiTask( _
            ByRef strErrMsg As String, _
            ByVal strBLSY As String, _
            ByRef blnIsShenpi As Boolean) As Boolean

            Dim intLevel As Integer

            isShenpiTask = False
            blnIsShenpi = False

            Try
                '检查
                If Me.IsInitialized = False Then
                    strErrMsg = "错误：[isShenpiTask]对象还没有初始化，不能使用！"
                    GoTo errProc
                End If
                If strBLSY Is Nothing Then strBLSY = ""
                strBLSY = strBLSY.Trim()

                '计算级别
                If Me.getTaskLevel(strErrMsg, strBLSY, intLevel) = False Then
                    GoTo errProc
                End If

                '计算
                If intLevel <= 10 Then
                    blnIsShenpi = False
                Else
                    blnIsShenpi = True
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            isShenpiTask = True
            Exit Function
errProc:
            Exit Function

        End Function












        '----------------------------------------------------------------
        ' 获取工作流相关文件附件的基本目录
        '----------------------------------------------------------------
        Public Overrides Function getBasePath_XGWJFJ() As String
            getBasePath_XGWJFJ = Josco.JSOA.Common.Workflow.BaseFlowKqglQJD.FILEDIR_XG
        End Function

        '----------------------------------------------------------------
        ' 获取工作流稿件的基本目录
        '----------------------------------------------------------------
        Public Overrides Function getBasePath_GJ() As String
            getBasePath_GJ = Josco.JSOA.Common.Workflow.BaseFlowKqglQJD.FILEDIR_GJ
        End Function

        '----------------------------------------------------------------
        ' 获取工作流附件的基本目录
        '----------------------------------------------------------------
        Public Overrides Function getBasePath_FJ() As String
            getBasePath_FJ = Josco.JSOA.Common.Workflow.BaseFlowKqglQJD.FILEDIR_FJ
        End Function

        '----------------------------------------------------------------
        ' 获取工作流开始的任务名称
        '----------------------------------------------------------------
        Public Overrides Function getInitTask() As String
            getInitTask = Josco.JSOA.Common.Workflow.BaseFlowKqglQJD.TASK_CYCG
        End Function












        '----------------------------------------------------------------
        ' 根据“文件标识”获取工作流主表数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     objDataSet           ：返回对象的主表数据集
        '     strTableName         ：返回主表在数据集中的表名
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Overrides Function getMainFlowData( _
            ByRef strErrMsg As String, _
            ByRef objDataSet As System.Data.DataSet, _
            ByRef strTableName As String) As Boolean

            Dim objTempDataSet As Josco.JSOA.Common.Data.kaoqinguanliData
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand
            Dim strWJBS As String
            Dim strSQL As String

            getMainFlowData = False
            objDataSet = Nothing
            strTableName = ""
            strErrMsg = ""

            Try
                '获取文件标识
                objSqlConnection = Me.SqlConnection
                strWJBS = Me.WJBS
                If objSqlConnection Is Nothing Then
                    strErrMsg = "错误：[getMainFlowData]对象还没有初始化，不能使用！"
                    GoTo errProc
                End If

                '创建数据集
                objTempDataSet = New Josco.JSOA.Common.Data.kaoqinguanliData(Josco.JSOA.Common.Data.kaoqinguanliData.enumTableType.KQ_B_XIUJIASHENQINGDAN)
                If strWJBS = "" Then
                    Exit Try
                End If

                '创建SqlCommand
                objSqlCommand = New System.Data.SqlClient.SqlCommand
                objSqlCommand.Connection = objSqlConnection
                objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                '执行检索
                With Me.SqlDataAdapter
                    strSQL = ""
                    strSQL = strSQL + " select * from 考勤_B_休假申请单 " + vbCr
                    strSQL = strSQL + " where 文件标识 = '" + strWJBS + "'" + vbCr

                    '设置参数
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    .SelectCommand = objSqlCommand

                    '执行操作
                    .Fill(objTempDataSet.Tables(Josco.JSOA.Common.Data.kaoqinguanliData.TABLE_KQ_B_XIUJIASHENQINGDAN))
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)

            strTableName = Josco.JSOA.Common.Data.kaoqinguanliData.TABLE_KQ_B_XIUJIASHENQINGDAN
            objDataSet = objTempDataSet
            getMainFlowData = True
            Exit Function

errProc:
            Josco.JSOA.Common.Data.kaoqinguanliData.SafeRelease(objTempDataSet)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 计算strBLSY的级别
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strBLSY              ：事宜名称
        '     intLevel             ：返回级别
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Overrides Function getTaskLevel( _
            ByRef strErrMsg As String, _
            ByVal strBLSY As String, _
            ByRef intLevel As Integer) As Boolean

            getTaskLevel = False
            intLevel = 1

            Try
                '检查
                If Me.IsInitialized = False Then
                    strErrMsg = "错误：[getTaskLevel]对象还没有初始化，不能使用！"
                    GoTo errProc
                End If
                If strBLSY Is Nothing Then strBLSY = ""
                strBLSY = strBLSY.Trim()

                '计算
                Select Case strBLSY
                    Case Josco.JSOA.Common.Workflow.BaseFlowKqglQJD.TASK_CYCG, _
                        Josco.JSOA.Common.Workflow.BaseFlowKqglQJD.TASK_GJBJ
                        '草拟初稿、稿件编辑
                        intLevel = 1

                    Case Josco.JSOA.Common.Workflow.BaseFlowKqglQJD.TASK_SMCL
                        '司秘处理
                        intLevel = 15
                    Case Josco.JSOA.Common.Workflow.BaseFlowKqglQJD.TASK_SHWJ
                        '审核文件
                        intLevel = 20
                    Case Josco.JSOA.Common.Workflow.BaseFlowKqglQJD.TASK_HQWJ
                        '会签文件
                        intLevel = 22
                    Case Josco.JSOA.Common.Workflow.BaseFlowKqglQJD.TASK_XGCL
                        '相关处理
                        intLevel = 25
                    Case Josco.JSOA.Common.Workflow.BaseFlowKqglQJD.TASK_MSCL
                        '秘书处理
                        intLevel = 30
                    Case Josco.JSOA.Common.Workflow.BaseFlowKqglQJD.TASK_QFWJ, _
                        Josco.JSOA.Common.Workflow.BaseFlowKqglQJD.TASK_LDCL
                        '签发文件,审批文件
                        intLevel = 40

                    Case Josco.JSOA.Common.Workflow.BaseFlowKqglQJD.TASK_WJGD
                        '文件归档
                        intLevel = 5
                End Select

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            getTaskLevel = True
            Exit Function
errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取strUserXM能阅读的审批意见
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserXM            ：用户名称
        '     strWhere             ：搜索条件
        '     objOpinionData       ：返回：意见数据
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        ' 变更说明：
        '     曾祥林 2008-04-01 
        '       (1) 更改审批意见的显示顺序为显示序号、行政级别、组织代码、人员序号
        '       (2) 审批意见信息中增加显示序号字段
        '----------------------------------------------------------------
        Public Overrides Function getCanReadOpinion( _
            ByRef strErrMsg As String, _
            ByVal strUserXM As String, _
            ByVal strWhere As String, _
            ByRef objOpinionData As Josco.JSOA.Common.Data.FlowData) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objTempOpinionData As Josco.JSOA.Common.Data.FlowData
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand
            Dim objDataSet As System.Data.DataSet
            Dim strSQL As String

            getCanReadOpinion = False
            objOpinionData = Nothing
            strErrMsg = ""

            Try
                '检查
                If Me.IsInitialized = False Then
                    strErrMsg = "错误：[getCanReadOpinion]对象还没有初始化，不能使用！"
                    GoTo errProc
                End If
                If strUserXM Is Nothing Then strUserXM = ""
                strUserXM = strUserXM.Trim()
                If strWhere Is Nothing Then strWhere = ""
                strWhere = strWhere.Trim

                '获取文件标识
                Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Me.SqlConnection
                Dim strSep As String = Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate
                Dim strTaskYWCStatusList As String = Me.FlowData.TaskStatusYWCList
                Dim strTaskSPSYList As String = Me.FlowData.TaskBlzlSPSYList
                Dim strTaskBSHStatus As String = Me.FlowData.TASKSTATUS_BSH
                Dim strBYQQ As String = Me.FlowData.TASK_BYQQ
                Dim strBYTZ As String = Me.FlowData.TASK_BYTZ
                Dim strBLLX As String = Me.FlowTypeName
                Dim strWJBS As String = Me.WJBS

                '计算所有的主动补阅人和请求补阅人并得到批准
                Dim strSearchList As String = ""
                Dim strUserList As String = ""
                Dim strBuffer As String = ""
                Dim strTemp As String = ""
                Dim blnFound As Boolean
                Dim intCount As Integer
                Dim i As Integer
                strSearchList = "'" + strUserXM + "'"
                strBuffer = strSearchList
                Do While True
                    blnFound = False

                    '计算批准补阅人列表
                    strSQL = ""
                    strSQL = strSQL + " select a.接收人 " + vbCr
                    strSQL = strSQL + " from " + vbCr
                    strSQL = strSQL + " (" + vbCr
                    strSQL = strSQL + "   select a.* " + vbCr
                    strSQL = strSQL + "   from 公文_B_交接 a " + vbCr
                    strSQL = strSQL + "   where a.文件标识 = '" + strWJBS + "' " + vbCr           '当前文件
                    strSQL = strSQL + "   and   a.办理子类 = '" + strBYQQ + "' " + vbCr           '补阅请求
                    strSQL = strSQL + "   and   a.发送人 in (" + strSearchList + ") " + vbCr      '发送的补阅请求
                    strSQL = strSQL + "   and   a.交接标识 like '_____1%' " + vbCr                '通知类
                    strSQL = strSQL + "   and   a.办理状态 <> '" + strTaskBSHStatus + "' " + vbCr '没有被收回
                    strSQL = strSQL + " ) a " + vbCr
                    strSQL = strSQL + " left join " + vbCr
                    strSQL = strSQL + " (" + vbCr
                    strSQL = strSQL + "   select * from 公文_B_办理 " + vbCr
                    strSQL = strSQL + "   where 文件标识 = '" + strWJBS + "' " + vbCr
                    strSQL = strSQL + "   and   办理子类 = '" + strBYQQ + "' " + vbCr
                    strSQL = strSQL + "   and   是否批准 = '1100' " + vbCr
                    strSQL = strSQL + " ) b on a.文件标识 = b.文件标识 and a.交接序号 = b.交接序号 " + vbCr
                    strSQL = strSQL + " where b.文件标识 is not null " + vbCr                     '已经批准的补阅请求
                    strSQL = strSQL + " group by a.接收人" + vbCr
                    If objdacCommon.getDataSetBySQL(strErrMsg, objSqlConnection, strSQL, objDataSet) = False Then
                        GoTo errProc
                    End If
                    intCount = objDataSet.Tables(0).Rows.Count
                    For i = 0 To intCount - 1 Step 1
                        strTemp = objPulicParameters.getObjectValue(objDataSet.Tables(0).Rows(i).Item("接收人"), "")
                        strTemp = "'" + strTemp + "'"
                        If strUserList = "" Then
                            strUserList = strTemp
                            strBuffer = strBuffer + "," + strTemp
                            blnFound = True
                        Else
                            If InStr(1, strUserList, strTemp) < 1 Then
                                strUserList = strUserList + "," + strTemp
                                strBuffer = strBuffer + "," + strTemp
                                blnFound = True
                            End If
                        End If
                    Next
                    Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                    objDataSet = Nothing

                    '计算主动补阅人列表
                    strSQL = ""
                    strSQL = strSQL + " select a.发送人 " + vbCr
                    strSQL = strSQL + " from " + vbCr
                    strSQL = strSQL + " (" + vbCr
                    strSQL = strSQL + "   select a.* " + vbCr
                    strSQL = strSQL + "   from 公文_B_交接 a " + vbCr
                    strSQL = strSQL + "   where a.文件标识 = '" + strWJBS + "' " + vbCr             '当前文件
                    strSQL = strSQL + "   and   a.办理子类 = '" + strBYTZ + "' " + vbCr             '主动补阅
                    strSQL = strSQL + "   and   a.接收人 in (" + strSearchList + ") " + vbCr        '接收人
                    strSQL = strSQL + "   and   a.交接标识 like '_____1%' " + vbCr                  '通知类
                    strSQL = strSQL + "   and   a.办理状态 <> '" + strTaskBSHStatus + "' " + vbCr   '没有被收回
                    strSQL = strSQL + "   and   a.原交接号 = -2 " + vbCr                            '主动补阅
                    strSQL = strSQL + " ) a " + vbCr
                    strSQL = strSQL + " group by a.发送人" + vbCr
                    If objdacCommon.getDataSetBySQL(strErrMsg, objSqlConnection, strSQL, objDataSet) = False Then
                        GoTo errProc
                    End If
                    intCount = objDataSet.Tables(0).Rows.Count
                    For i = 0 To intCount - 1 Step 1
                        strTemp = objPulicParameters.getObjectValue(objDataSet.Tables(0).Rows(i).Item("发送人"), "")
                        strTemp = "'" + strTemp + "'"
                        If strUserList = "" Then
                            strUserList = strTemp
                            strBuffer = strBuffer + "," + strTemp
                            blnFound = True
                        Else
                            If InStr(1, strUserList, strTemp) < 1 Then
                                strUserList = strUserList + "," + strTemp
                                strBuffer = strBuffer + "," + strTemp
                                blnFound = True
                            End If
                        End If
                    Next
                    Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                    objDataSet = Nothing

                    If blnFound = False Then
                        Exit Do
                    End If
                    strSearchList = strBuffer
                Loop

                '创建数据集
                objTempOpinionData = New Josco.JSOA.Common.Data.FlowData(Josco.JSOA.Common.Data.FlowData.enumTableType.GW_B_SHENPIYIJIAN)
                If strWJBS = "" Then Exit Try

                '创建SqlCommand
                objSqlCommand = New System.Data.SqlClient.SqlCommand
                objSqlCommand.Connection = objSqlConnection
                objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                '执行检索
                With Me.SqlDataAdapter
                    strSQL = ""
                    strSQL = strSQL + " select a.*" + vbCr
                    strSQL = strSQL + " from" + vbCr
                    strSQL = strSQL + " (" + vbCr
                    strSQL = strSQL + "   select a.*, " + vbCr
                    strSQL = strSQL + "     是否同意 = case " + vbCr
                    strSQL = strSQL + "        when b.是否批准 = '1100' then '" + Josco.JSOA.Common.Workflow.BaseFlowKqglQJD.SPYJ_TY + "' " + vbCr
                    strSQL = strSQL + "        when b.是否批准 = '1110' then '" + Josco.JSOA.Common.Workflow.BaseFlowKqglQJD.SPYJ_BLYJ + "' " + vbCr
                    strSQL = strSQL + "        when b.是否批准 = '1000' then '" + Josco.JSOA.Common.Workflow.BaseFlowKqglQJD.SPYJ_BTY + "' " + vbCr
                    strSQL = strSQL + "        else ' ' end," + vbCr
                    strSQL = strSQL + "     b.办理日期, " + vbCr
                    strSQL = strSQL + "     b.办理意见, " + vbCr
                    strSQL = strSQL + "     b.便笺内容, " + vbCr
                    strSQL = strSQL + "     b.代理人, " + vbCr
                    strSQL = strSQL + "     b.代理日期, " + vbCr
                    strSQL = strSQL + "     b.办理结果, " + vbCr
                    strSQL = strSQL + "     b.填写日期, " + vbCr
                    strSQL = strSQL + "     c.人员序号, " + vbCr
                    strSQL = strSQL + "     c.行政级别, " + vbCr
                    strSQL = strSQL + "     c.组织代码, " + vbCr
                    '曾祥林 2008-04-01
                    strSQL = strSQL + "     b.显示序号  " + vbCr
                    '曾祥林 2008-04-01
                    strSQL = strSQL + "   from " + vbCr
                    strSQL = strSQL + "   (" + vbCr
                    strSQL = strSQL + "     select a.文件标识, a.交接序号, a.办理类型, a.接收人, c.办理子类 as 办理子类, a.协办 " + vbCr
                    strSQL = strSQL + "     from " + vbCr
                    strSQL = strSQL + "     (" + vbCr
                    strSQL = strSQL + "       select a.* " + vbCr
                    strSQL = strSQL + "       from 公文_B_交接 a " + vbCr
                    strSQL = strSQL + "       where a.文件标识 = '" + strWJBS + "' " + vbCr                 '当前文件
                    strSQL = strSQL + "       and   a.办理子类 in (" + strTaskSPSYList + ") " + vbCr        '审批类事宜
                    strSQL = strSQL + "       and   a.交接标识 like '1_1__0%' " + vbCr                      '已发送+接收人能看+非通知类
                    strSQL = strSQL + "     ) a " + vbCr
                    strSQL = strSQL + "     left join " + vbCr
                    strSQL = strSQL + "     (" + vbCr
                    strSQL = strSQL + "       select a.文件标识, a.接收人, a.发送序号, isnull(max(a.交接序号),0) as 交接序号 " + vbCr
                    strSQL = strSQL + "       from 公文_B_交接 a " + vbCr
                    strSQL = strSQL + "       where a.文件标识 = '" + strWJBS + "' " + vbCr                 '当前文件
                    strSQL = strSQL + "       and   a.交接标识 like '1_1__0%' " + vbCr                      '已发送+接收人能看+非通知类
                    If strUserList = "" Then
                        strSQL = strSQL + "       and   a.接收人   = '" + strUserXM + "' " + vbCr           '只有自己
                    Else
                        strSQL = strSQL + "       and ((a.接收人   = '" + strUserXM + "') " + vbCr
                        strSQL = strSQL + "       or   (a.接收人   in (" + strUserList + "))) " + vbCr      '自己+主动补阅人能看+自己补阅请求批准后能看
                    End If
                    strSQL = strSQL + "       group by a.文件标识, a.接收人, a.发送序号 " + vbCr
                    strSQL = strSQL + "     ) b on a.文件标识 = b.文件标识 " + vbCr
                    strSQL = strSQL + "     left join " + vbCr
                    strSQL = strSQL + "     (" + vbCr
                    strSQL = strSQL + "       select * from 公文_B_办理 " + vbCr
                    strSQL = strSQL + "       where 文件标识 = '" + strWJBS + "' " + vbCr
                    strSQL = strSQL + "     ) c on a.文件标识 = c.文件标识 and a.交接序号 = c.交接序号 " + vbCr
                    strSQL = strSQL + "     where ((a.接收人 = b.接收人) " + vbCr
                    strSQL = strSQL + "     or a.办理状态 in (" + strTaskYWCStatusList + ")) " + vbCr       '已完成或本人
                    strSQL = strSQL + "     group by a.文件标识, a.交接序号, a.办理类型, a.接收人, c.办理子类, a.协办 " + vbCr
                    strSQL = strSQL + "   ) a " + vbCr
                    strSQL = strSQL + "   left join " + vbCr
                    strSQL = strSQL + "   (" + vbCr
                    strSQL = strSQL + "     select * from 公文_B_办理 " + vbCr
                    strSQL = strSQL + "     where 文件标识 = '" + strWJBS + "' " + vbCr                    '当前文件
                    strSQL = strSQL + "     and   CHARINDEX('" + strUserXM + strSep + "',rtrim(isnull(限制阅读人员,' '))+'" + strSep + "',1) < 1 " + vbCr
                    strSQL = strSQL + "   ) b on a.文件标识 = b.文件标识 and a.交接序号 = b.交接序号 " + vbCr
                    strSQL = strSQL + "   left join " + vbCr
                    strSQL = strSQL + "   (" + vbCr
                    strSQL = strSQL + "     select a.人员名称, a.组织代码, 人员序号=convert(integer,a.人员序号), b.行政级别 " + vbCr
                    strSQL = strSQL + "     from 公共_B_人员 a " + vbCr
                    strSQL = strSQL + "     left join 公共_B_行政级别 b on a.级别代码 = b.级别代码 " + vbCr
                    strSQL = strSQL + "   ) c on a.接收人 = c.人员名称 " + vbCr
                    strSQL = strSQL + "   where b.文件标识 is not null " + vbCr                            '非限制阅读
                    strSQL = strSQL + " ) a" + vbCr
                    If strWhere <> "" Then
                        strSQL = strSQL + " where " + strWhere + vbCr
                    End If
                    '曾祥林 2008-04-01
                    'strSQL = strSQL + " order by a.组织代码, a.人员序号, a.办理日期 desc" + vbCr
                    strSQL = strSQL + " order by a.显示序号, a.行政级别, a.组织代码, a.人员序号, a.办理日期 desc" + vbCr
                    '曾祥林 2008-04-01

                    '设置参数
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    .SelectCommand = objSqlCommand

                    '执行操作
                    .Fill(objTempOpinionData.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_SHENPIYIJIAN))
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            objOpinionData = objTempOpinionData
            getCanReadOpinion = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JSOA.Common.Data.FlowData.SafeRelease(objTempOpinionData)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取新的文件流水号
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strLSH               ：返回文件流水号
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Overrides Function getNewLSH( _
            ByRef strErrMsg As String, _
            ByRef strLSH As String) As Boolean

            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String

            getNewLSH = False
            strLSH = ""
            strErrMsg = ""

            Try
                '检查
                If Me.IsInitialized = False Then
                    strErrMsg = "错误：[getNewLSH]对象还没有初始化，不能使用！"
                    GoTo errProc
                End If

                '获取文件标识
                Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Me.SqlConnection
                Dim strWJBS As String = Me.WJBS

                '检索数据
                Dim strWJLX As String = Josco.JSOA.Common.Workflow.BaseFlowKqglQJD.FLOWNAME
                Dim strPrefix As String
                strPrefix = Format(Now, "yyyyMMdd") + "-"
                If objdacCommon.getNewCode(strErrMsg, objSqlConnection, "流水号", Me.TABLE_FOR_NEWLSH, 14, strPrefix, True, strLSH) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            getNewLSH = True
            Exit Function

errProc:
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function















        '----------------------------------------------------------------
        ' 删除文件
        '     strErrMsg            ：如果错误，则返回错误信息
        '     objFTPProperty       ：FTP服务器连接参数
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Overrides Function doDeleteFile( _
            ByRef strErrMsg As String, _
            ByVal objFTPProperty As Josco.JsKernal.Common.Utilities.FTPProperty) As Boolean

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand
            Dim strSQL As String

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objBaseFTP As New Josco.JsKernal.Common.Utilities.BaseFTP
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objDataSet_XGFJ As System.Data.DataSet
            Dim objDataSet_MAIN As System.Data.DataSet
            Dim objDataSet_FJ As System.Data.DataSet

            doDeleteFile = False
            strErrMsg = ""

            Try
                '检查
                If Me.IsInitialized = False Then
                    strErrMsg = "错误：[doDeleteFile]对象还没有初始化，不能使用！"
                    GoTo errProc
                End If

                '获取文件标识
                Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Me.SqlConnection
                Dim strWJBS As String = Me.WJBS
                If strWJBS = "" Then Exit Try

                '获取附件列表
                strSQL = "select * from 公文_B_附件 where 文件标识 = '" + strWJBS + "'"
                If objdacCommon.getDataSetBySQL(strErrMsg, objSqlConnection, strSQL, objDataSet_FJ) = False Then
                    GoTo errProc
                End If

                '获取相关文件附件列表
                strSQL = "select * from 公文_B_相关文件附件 where 文件标识 = '" + strWJBS + "'"
                If objdacCommon.getDataSetBySQL(strErrMsg, objSqlConnection, strSQL, objDataSet_XGFJ) = False Then
                    objSqlTransaction.Rollback()
                    GoTo errProc
                End If

                '获取主记录内容
                strSQL = "select * from 考勤_B_休假申请单 where 文件标识 = '" + strWJBS + "'"
                If objdacCommon.getDataSetBySQL(strErrMsg, objSqlConnection, strSQL, objDataSet_MAIN) = False Then
                    objSqlTransaction.Rollback()
                    GoTo errProc
                End If

                '创建SqlCommand
                objSqlCommand = New System.Data.SqlClient.SqlCommand
                objSqlCommand.Connection = objSqlConnection
                objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                '开始事务
                objSqlTransaction = objSqlConnection.BeginTransaction
                objSqlCommand.Transaction = objSqlTransaction

                '事务处理
                Dim strFilePath As String
                Dim strUrl As String
                Dim intCount As Integer
                Dim i As Integer
                Try
                    '删除文件锁定记录
                    strSQL = "delete from 管理_B_文件封锁 where 文件标识 = '" + strWJBS + "'"
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    '删除文件日志记录
                    strSQL = "delete from 公文_B_操作日志 where 文件标识 = '" + strWJBS + "'"
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    '删除督办信息
                    strSQL = "delete from 公文_B_督办 where 文件标识 = '" + strWJBS + "'"
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    '删除催办信息
                    strSQL = "delete from 公文_B_催办 where 文件标识 = '" + strWJBS + "'"
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    '删除公文办理信息
                    strSQL = "delete from 公文_B_办理 where 文件标识 = '" + strWJBS + "'"
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    '删除公文承办信息
                    strSQL = "delete from 公文_B_承办 where 文件标识 = '" + strWJBS + "'"
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    '删除附件记录
                    strSQL = "delete from 公文_B_附件 where 文件标识 = '" + strWJBS + "'"
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    '删除相关文件信息
                    strSQL = "delete from 公文_B_相关文件 where 当前文件标识 = '" + strWJBS + "'"
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    '删除相关文件附件记录
                    strSQL = "delete from 公文_B_相关文件附件 where 文件标识 = '" + strWJBS + "'"
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    '删除公文交接信息
                    strSQL = "delete from 公文_B_交接 where 文件标识 = '" + strWJBS + "'"
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    '删除“考勤_B_休假申请单_假期”
                    strSQL = "delete from 考勤_B_休假申请单_假期 where 文件标识 = '" + strWJBS + "'"
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    '删除主记录
                    strSQL = "delete from 考勤_B_休假申请单 where 文件标识 = '" + strWJBS + "'"
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    '删除附件信息
                    '删除对应的FTP文件
                    With objDataSet_FJ.Tables(0)
                        intCount = .Rows.Count
                        For i = 0 To intCount - 1 Step 1
                            strFilePath = objPulicParameters.getObjectValue(.Rows(i).Item("位置"), "")
                            If strFilePath <> "" Then
                                With objFTPProperty
                                    strUrl = .getUrl(strFilePath)
                                    If objBaseFTP.doDeleteFile(strErrMsg, strUrl, .UserID, .Password, .ProxyUrl, .ProxyUserID, .ProxyPassword) = False Then
                                        '可以不成功，形成垃圾文件！
                                    End If
                                End With
                            End If
                        Next
                    End With
                    objDataSet_FJ.Dispose()
                    objDataSet_FJ = Nothing

                    '删除相关文件附件信息
                    '删除对应的FTP文件
                    With objDataSet_XGFJ.Tables(0)
                        intCount = .Rows.Count
                        For i = 0 To intCount - 1 Step 1
                            strFilePath = objPulicParameters.getObjectValue(.Rows(i).Item("位置"), "")
                            If strFilePath <> "" Then
                                With objFTPProperty
                                    strUrl = .getUrl(strFilePath)
                                    If objBaseFTP.doDeleteFile(strErrMsg, strUrl, .UserID, .Password, .ProxyUrl, .ProxyUserID, .ProxyPassword) = False Then
                                        '可以不成功，形成垃圾文件！
                                    End If
                                End With
                            End If
                        Next
                    End With
                    objDataSet_XGFJ.Dispose()
                    objDataSet_XGFJ = Nothing

                    '删除主记录中的FTP文件
                    With objDataSet_MAIN.Tables(0)
                        If .Rows.Count > 0 Then
                            '删除正文内容对应的文件
                            strFilePath = objPulicParameters.getObjectValue(.Rows(0).Item("正文内容"), "")
                            If strFilePath <> "" Then
                                With objFTPProperty
                                    strUrl = .getUrl(strFilePath)
                                    If objBaseFTP.doDeleteFile(strErrMsg, strUrl, .UserID, .Password, .ProxyUrl, .ProxyUserID, .ProxyPassword) = False Then
                                        '可以不成功，形成垃圾文件！
                                    End If
                                End With
                            End If
                            '删除痕迹文件对应的文件
                            strFilePath = objPulicParameters.getObjectValue(.Rows(0).Item("痕迹文件"), "")
                            If strFilePath <> "" Then
                                With objFTPProperty
                                    strUrl = .getUrl(strFilePath)
                                    If objBaseFTP.doDeleteFile(strErrMsg, strUrl, .UserID, .Password, .ProxyUrl, .ProxyUserID, .ProxyPassword) = False Then
                                        '可以不成功，形成垃圾文件！
                                    End If
                                End With
                            End If
                            '删除批件原件对应的文件
                            strFilePath = objPulicParameters.getObjectValue(.Rows(0).Item("批件原件"), "")
                            If strFilePath <> "" Then
                                With objFTPProperty
                                    strUrl = .getUrl(strFilePath)
                                    If objBaseFTP.doDeleteFile(strErrMsg, strUrl, .UserID, .Password, .ProxyUrl, .ProxyUserID, .ProxyPassword) = False Then
                                        '可以不成功，形成垃圾文件！
                                    End If
                                End With
                            End If
                        End If
                    End With
                    objDataSet_MAIN.Dispose()
                    objDataSet_MAIN = Nothing

                Catch ex As Exception
                    objSqlTransaction.Rollback()
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '提交事务
                objSqlTransaction.Commit()

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet_MAIN)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet_FJ)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet_XGFJ)
            Josco.JsKernal.Common.Utilities.BaseFTP.SafeRelease(objBaseFTP)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            doDeleteFile = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet_MAIN)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet_FJ)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet_XGFJ)
            Josco.JsKernal.Common.Utilities.BaseFTP.SafeRelease(objBaseFTP)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 根据“文件标识”填充工作流对象数据(须在子类中实现)
        '     strErrMsg            ：如果错误，则返回错误信息
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Overrides Function doFillFlowData( _
            ByRef strErrMsg As String) As Boolean

            Dim objkaoqinguanliData As Josco.JSOA.Common.Data.kaoqinguanliData
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataSet As System.Data.DataSet

            doFillFlowData = False
            strErrMsg = ""

            Try
                '获取当前记录
                Dim strTableName As String
                If Me.getMainFlowData(strErrMsg, objDataSet, strTableName) = False Then
                    GoTo errProc
                End If
                objkaoqinguanliData = CType(objDataSet, Josco.JSOA.Common.Data.kaoqinguanliData)
                If objkaoqinguanliData.Tables(strTableName).Rows.Count < 1 Then
                    Exit Try
                End If

                '获取对象数据
                Dim objBaseFlowKqglQJD As Josco.JSOA.Common.Workflow.BaseFlowKqglQJD
                objBaseFlowKqglQJD = CType(Me.FlowData, Josco.JSOA.Common.Workflow.BaseFlowKqglQJD)

                '填充数据
                Dim objDate As System.DateTime = Nothing
                With objkaoqinguanliData.Tables(strTableName).Rows(0)
                    '*****************************************************************************************************************************
                    objBaseFlowKqglQJD.WJBS = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_WJBS), "")
                    objBaseFlowKqglQJD.LSH = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_LSH), "")
                    objBaseFlowKqglQJD.Status = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_BLZT), "")
                    objBaseFlowKqglQJD.PZR = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_QFR), "")
                    objBaseFlowKqglQJD.PZRQ = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_QFRQ), objDate)
                    objBaseFlowKqglQJD.DDSZ = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_DDSZ), 0)
                    '*****************************************************************************************************************************
                    objBaseFlowKqglQJD.WJBT = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_WJBT), "")
                    objBaseFlowKqglQJD.JJCD = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_JJCD), "")
                    objBaseFlowKqglQJD.MMDJ = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_MMDJ), "")
                    objBaseFlowKqglQJD.JGDZ = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_JGDZ), "")
                    objBaseFlowKqglQJD.WJNF = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_WJNF), "")
                    objBaseFlowKqglQJD.WJXH = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_WJXH), "")
                    '*****************************************************************************************************************************
                    objBaseFlowKqglQJD.ZBDW = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_JBDW), "")
                    objBaseFlowKqglQJD.NGR = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_JBRY), "")
                    objBaseFlowKqglQJD.NGRQ = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_JBRQ), objDate)
                    '*****************************************************************************************************************************
                    objBaseFlowKqglQJD.QFR = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_QFR), "")
                    objBaseFlowKqglQJD.QFRQ = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_QFRQ), objDate)
                    '*****************************************************************************************************************************
                    objBaseFlowKqglQJD.ZWNR = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_ZWNR), "")
                    objBaseFlowKqglQJD.HJWJ = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_HJWJ), "")
                    objBaseFlowKqglQJD.PJYJ = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_PJYJ), "")
                    '*****************************************************************************************************************************
                    objBaseFlowKqglQJD.BLZT = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_BLZT), "")
                    '*****************************************************************************************************************************
                    objBaseFlowKqglQJD.BEIZ = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_BZXX), "")
                    '*****************************************************************************************************************************
                    objBaseFlowKqglQJD.SQR = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_SQR), "")
                    objBaseFlowKqglQJD.SQRDM = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_SQRDM), "")
                    objBaseFlowKqglQJD.SQRQ = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_SQRQ), objDate)
                    objBaseFlowKqglQJD.YY = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_YY), "")
                    objBaseFlowKqglQJD.ZZDM = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_ZZDM), "")
                    objBaseFlowKqglQJD.ZZMC = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_ZZMC), "")
                    objBaseFlowKqglQJD.ZW = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_ZW), "")
                    objBaseFlowKqglQJD.DD = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_DD), "")
                    objBaseFlowKqglQJD.LXDH = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_LXDH), "")
                    objBaseFlowKqglQJD.KSRQ = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_KSRQ), objDate)
                    objBaseFlowKqglQJD.JSRQ = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_JSRQ), objDate)
                    objBaseFlowKqglQJD.TS = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_TS), 0)
                    objBaseFlowKqglQJD.WTGZ = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_WTGZ), "")
                   
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.Common.Data.kaoqinguanliData.SafeRelease(objkaoqinguanliData)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            doFillFlowData = True
            Exit Function
errProc:
            Josco.JSOA.Common.Data.kaoqinguanliData.SafeRelease(objkaoqinguanliData)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 判断记录数据是否有效？
        '     strErrMsg            ：如果错误，则返回错误信息
        '     objNewData           ：记录新值(返回推荐值)
        '     objOldData           ：记录旧值
        '     objenumEditType      ：编辑类型
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Overrides Function doVerifyFile( _
            ByRef strErrMsg As String, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objOldData As Josco.JSOA.Common.Workflow.BaseFlowObject, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objDataSet As System.Data.DataSet

            Dim objListDictionary As System.Collections.Specialized.ListDictionary
            Dim strSQL As String

            doVerifyFile = False

            Try
                '检查
                If Me.IsInitialized = False Then
                    strErrMsg = "错误：[doVerifyFile]对象还没有初始化，不能使用！"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    strErrMsg = "错误：[doVerifyFile]未传入新的数据！"
                    GoTo errProc
                End If
                objOldData = CType(objOldData, Josco.JSOA.Common.Workflow.BaseFlowKqglQJD)
                Dim strOldWJBS As String
                Dim strOldLSH As String
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, Utilities.PulicParameters.enumEditType.eCpyNew
                    Case Else
                        If objOldData Is Nothing Then
                            strErrMsg = "错误：[doVerifyFile]未传入旧的数据！"
                            GoTo errProc
                        End If
                        strOldWJBS = objOldData.WJBS
                        strOldLSH = objOldData.LSH
                End Select

                '获取现有信息
                Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Me.SqlConnection

                '获取表结构定义
                strSQL = "select top 0 * from 考勤_B_休假申请单"
                If objdacCommon.getDataSetWithSchemaBySQL(strErrMsg, objSqlConnection, strSQL, "考勤_B_休假申请单", objDataSet) = False Then
                    GoTo errProc
                End If

                '检查数据长度
                Dim intCount As Integer = objNewData.Count
                Dim strField As String
                Dim strValue As String
                Dim intLen As Integer
                Dim i As Integer
                For i = 0 To intCount - 1 Step 1
                    strField = objNewData.GetKey(i).Trim()
                    strValue = objNewData.Item(i).Trim()
                    Select Case strField
                        Case Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_WJBS
                            Select Case objenumEditType
                                Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                                    Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                                    '设置缺省值
                                    If Me.getNewWJBS(strErrMsg, strValue) = False Then
                                        GoTo errProc
                                    End If
                                Case Else
                            End Select
                        Case Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_LSH
                            Select Case objenumEditType
                                Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                                    Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                                    '设置缺省值
                                    If Me.getNewLSH(strErrMsg, strValue) = False Then
                                        GoTo errProc
                                    End If
                                Case Else
                            End Select
                        Case Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_BLZT
                            If strValue = "" Then
                                '设置缺省值
                                strValue = Me.FlowData.FILESTATUS_ZJB
                            End If

                        Case Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_WJBT, _
                            Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_JGDZ, _
                            Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_WJNF
                            If strValue = "" Then
                                strErrMsg = "错误：[" + strField + "]不能为空！"
                                GoTo errProc
                            End If
                            With objDataSet.Tables(0).Columns(strField)
                                intLen = objPulicParameters.getStringLength(strValue)
                                If intLen > .MaxLength Then
                                    strErrMsg = "错误：[" + strField + "]长度不能超过[" + .MaxLength.ToString() + "]，实际有[" + intLen.ToString() + "]！"
                                    GoTo errProc
                                End If
                            End With

                        Case Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_DDSZ
                            If strValue = "" Then strValue = "0"
                            If objPulicParameters.isIntegerString(strValue) = False Then
                                strErrMsg = "错误：[" + strField + "]必须是数字！"
                                GoTo errProc
                            End If
                            intLen = CType(strValue, Integer)
                            Select Case intLen
                                Case 0, 1
                                Case Else
                                    strErrMsg = "错误：[" + strField + "]必须是0或1！"
                                    GoTo errProc
                            End Select
                            strValue = intLen.ToString()
                        Case Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_TS
                            If strValue = "" Then strValue = "0"
                            If objPulicParameters.isIntegerString(strValue) = False Then
                                strErrMsg = "错误：[" + strField + "]必须是数字！"
                                GoTo errProc
                            End If
                            intLen = CType(strValue, Integer)
                            If intLen < 0 Then
                                strErrMsg = "错误：[" + strField + "]必须>0！"
                                GoTo errProc
                            End If
                            strValue = intLen.ToString()

                        Case Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_JBRQ
                            If strValue = "" Then
                                strErrMsg = "错误：[" + strField + "]不能为空！"
                                GoTo errProc
                            End If
                            Dim objDate As System.DateTime
                            Try
                                objDate = CType(strValue, System.DateTime)
                            Catch ex As Exception
                                strErrMsg = "错误：[" + strField + "]值[" + strValue + "]无效！"
                                GoTo errProc
                            End Try
                            strValue = Format(objDate, "yyyy-MM-dd HH:mm")
                        Case Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_QFRQ, _
                            Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_KSRQ, _
                            Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_JSRQ, _
                            Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_SQRQ

                            If strValue <> "" Then
                                Dim objDate As System.DateTime
                                Try
                                    objDate = CType(strValue, System.DateTime)
                                Catch ex As Exception
                                    strErrMsg = "错误：[" + strField + "]值[" + strValue + "]无效！"
                                    GoTo errProc
                                End Try
                                strValue = Format(objDate, "yyyy-MM-dd HH:mm")
                            End If

                        Case Else
                            If strValue <> "" Then
                                With objDataSet.Tables(0).Columns(strField)
                                    intLen = objPulicParameters.getStringLength(strValue)
                                    If intLen > .MaxLength Then
                                        strErrMsg = "错误：[" + strField + "]长度不能超过[" + .MaxLength.ToString() + "]，实际有[" + intLen.ToString() + "]！"
                                        GoTo errProc
                                    End If
                                End With
                            End If
                    End Select

                    objNewData(strField) = strValue
                Next
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                objDataSet = Nothing

                '生成“文件序号”
                Dim strJGDZ As String = objNewData(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_JGDZ)
                Dim strWJNF As String = objNewData(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_WJNF)
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                        Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                        '设置缺省值
                        If Me.getNewWjxh(strErrMsg, strJGDZ, strWJNF, strValue) = False Then
                            GoTo errProc
                        End If
                        objNewData(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_WJXH) = strValue
                    Case Else
                End Select

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objListDictionary)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            doVerifyFile = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objListDictionary)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 保存记录
        '     strErrMsg              ：如果错误，则返回错误信息
        '     objSqlTransaction      ：现有事务
        '     objNewData             ：记录新值(返回保存后的新值)
        '     objOldData             ：记录旧值
        '     objenumEditType        ：编辑类型
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
        '----------------------------------------------------------------
        Public Overrides Function doSaveFile( _
            ByRef strErrMsg As String, _
            ByVal objSqlTransaction As System.Data.SqlClient.SqlTransaction, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objOldData As Josco.JSOA.Common.Workflow.BaseFlowObject, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean

            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand
            Dim blnNewTrans As Boolean = False
            Dim strSQL As String

            '初始化
            doSaveFile = False
            strErrMsg = ""

            Try
                '检查
                If Me.IsInitialized = False Then
                    strErrMsg = "错误：[doSaveFile]对象还没有初始化，不能使用！"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    strErrMsg = "错误：[doSaveFile]未传入新的数据！"
                    GoTo errProc
                End If
                objOldData = CType(objOldData, Josco.JSOA.Common.Workflow.BaseFlowKqglQJD)
                Dim strOldWJBS As String
                Dim strOldLSH As String
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                        Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                    Case Else
                        If objOldData Is Nothing Then
                            strErrMsg = "错误：[doSaveFile]未传入旧的数据！"
                            GoTo errProc
                        End If
                        strOldWJBS = objOldData.WJBS
                        strOldLSH = objOldData.LSH
                End Select

                '获取现有信息
                If objSqlTransaction Is Nothing Then
                    objSqlConnection = Me.SqlConnection
                Else
                    objSqlConnection = objSqlTransaction.Connection
                End If

                '开始事务
                If objSqlTransaction Is Nothing Then
                    blnNewTrans = True
                    objSqlTransaction = objSqlConnection.BeginTransaction()
                Else
                    blnNewTrans = False
                End If

                '保存数据
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '计算SQL
                    Dim strFileds As String = ""
                    Dim strValues As String = ""
                    Dim strField As String
                    Dim intCount As Integer
                    Dim i As Integer = 0
                    Select Case objenumEditType
                        Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                            Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                            intCount = objNewData.Count
                            For i = 0 To intCount - 1 Step 1
                                If strFileds = "" Then
                                    strFileds = objNewData.GetKey(i)
                                Else
                                    strFileds = strFileds + "," + objNewData.GetKey(i)
                                End If
                                If strValues = "" Then
                                    strValues = "@A" + i.ToString()
                                Else
                                    strValues = strValues + "," + "@A" + i.ToString()
                                End If
                            Next

                            strSQL = ""
                            strSQL = strSQL + " insert into 考勤_B_休假申请单 (" + strFileds + ")"
                            strSQL = strSQL + " values (" + strValues + ")"

                            objSqlCommand.Parameters.Clear()
                            intCount = objNewData.Count
                            For i = 0 To intCount - 1 Step 1
                                Select Case objNewData.GetKey(i)
                                    Case Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_DDSZ, _
                                        Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_TS
                                        If objNewData.Item(i) = "" Then
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), 0)
                                        Else
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), CType(objNewData.Item(i), Integer))
                                        End If

                                    Case Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_JBRQ, _
                                        Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_QFRQ, _
                                        Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_SQRQ, _
                                        Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_KSRQ, _
                                        Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_JSRQ

                                        If objNewData.Item(i) = "" Then
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), System.DBNull.Value)
                                        Else
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), CType(objNewData.Item(i), System.DateTime))
                                        End If

                                    Case Else
                                        If objNewData.Item(i) = "" Then
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), " ")
                                        Else
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), objNewData.Item(i))
                                        End If
                                End Select
                            Next

                            objSqlCommand.CommandText = strSQL
                            objSqlCommand.ExecuteNonQuery()

                        Case Else
                            intCount = objNewData.Count
                            For i = 0 To intCount - 1 Step 1
                                If strFileds = "" Then
                                    strFileds = objNewData.GetKey(i) + " = @A" + i.ToString()
                                Else
                                    strFileds = strFileds + "," + objNewData.GetKey(i) + " = @A" + i.ToString()
                                End If
                            Next

                            strSQL = ""
                            strSQL = strSQL + " update 考勤_B_休假申请单 set "
                            strSQL = strSQL + "   " + strFileds
                            strSQL = strSQL + " where 文件标识 = @oldwjbs"

                            objSqlCommand.Parameters.Clear()
                            intCount = objNewData.Count
                            For i = 0 To intCount - 1 Step 1
                                Select Case objNewData.GetKey(i)
                                    Case Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_DDSZ, _
                                        Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_TS
                                        If objNewData.Item(i) = "" Then
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), 0)
                                        Else
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), CType(objNewData.Item(i), Integer))
                                        End If

                                    Case Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_JBRQ, _
                                        Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_QFRQ, _
                                        Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_SQRQ, _
                                        Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_KSRQ, _
                                        Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_JSRQ
                                        If objNewData.Item(i) = "" Then
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), System.DBNull.Value)
                                        Else
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), CType(objNewData.Item(i), System.DateTime))
                                        End If

                                    Case Else
                                        If objNewData.Item(i) = "" Then
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), " ")
                                        Else
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), objNewData.Item(i))
                                        End If
                                End Select
                            Next
                            objSqlCommand.Parameters.AddWithValue("@oldwjbs", strOldWJBS)

                            objSqlCommand.CommandText = strSQL
                            objSqlCommand.ExecuteNonQuery()
                    End Select

                Catch ex As Exception
                    If blnNewTrans = True Then
                        objSqlTransaction.Rollback()
                    End If
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '提交事务
                If blnNewTrans = True Then
                    objSqlTransaction.Commit()
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)

            '返回
            doSaveFile = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 保存稿件文件
        '     strErrMsg              ：如果错误，则返回错误信息
        '     intWJND                ：要保存到的年度
        '     objSqlTransaction      ：现有事务
        '     objConnectionProperty  ：FTP连接参数
        '     strGJFile              ：要保存的稿件文件的本地缓存文件完整路径
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
        '----------------------------------------------------------------
        Public Overrides Function doSaveGJFile( _
            ByRef strErrMsg As String, _
            ByVal intWJND As Integer, _
            ByVal objSqlTransaction As System.Data.SqlClient.SqlTransaction, _
            ByVal objFTPProperty As Josco.JsKernal.Common.Utilities.FTPProperty, _
            ByVal strGJFile As String) As Boolean

            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objBaseFTP As New Josco.JsKernal.Common.Utilities.BaseFTP

            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand
            Dim blnNewTrans As Boolean = False
            Dim strZWNR As String
            Dim strWJBS As String
            Dim strSQL As String

            doSaveGJFile = False
            strErrMsg = ""

            Try
                '检查输入参数
                If Me.IsInitialized = False Then
                    strErrMsg = "错误：[doSaveGJFile]对象还没有初始化，不能使用！"
                    GoTo errProc
                End If
                If Me.IsFillData = False Then
                    strErrMsg = "错误：[doSaveGJFile]对象还没有填充数据，不能使用！"
                    GoTo errProc
                End If
                If objFTPProperty Is Nothing Then
                    strErrMsg = "错误：[doSaveGJFile]没有指定FTP的连接参数！"
                    GoTo errProc
                End If
                If strGJFile Is Nothing Then strGJFile = ""
                strGJFile = strGJFile.Trim()
                If strGJFile = "" Then
                    '不用保存
                    Exit Try
                End If

                '检查文件是否存在?
                Dim blnExisted As Boolean
                If objBaseLocalFile.doFileExisted(strErrMsg, strGJFile, blnExisted) = False Then
                    GoTo errProc
                End If
                If blnExisted = False Then
                    strErrMsg = "错误：稿件文件[" + strGJFile + "]不存在！"
                    GoTo errProc
                End If

                '获取文件信息
                Dim objBaseFlowKqglQJD As Josco.JSOA.Common.Workflow.BaseFlowKqglQJD
                objBaseFlowKqglQJD = CType(Me.FlowData, Josco.JSOA.Common.Workflow.BaseFlowKqglQJD)
                strZWNR = objBaseFlowKqglQJD.ZWNR
                strWJBS = objBaseFlowKqglQJD.WJBS

                '获取服务器文件
                Dim strBasePath As String = Me.getBasePath_GJ
                Dim strDesFile As String
                If Me.getFTPFileName_GJ(strErrMsg, strGJFile, intWJND, strWJBS, strBasePath, strDesFile) = False Then
                    GoTo errProc
                End If

                '备份原文件
                If Me.doBackupFiles_GJ(strErrMsg, strZWNR, objFTPProperty) = False Then
                    GoTo errProc
                End If

                '更新文件路径
                '获取事务连接
                If objSqlTransaction Is Nothing Then
                    objSqlConnection = Me.SqlConnection
                Else
                    objSqlConnection = objSqlTransaction.Connection
                End If
                '开始事务
                If objSqlTransaction Is Nothing Then
                    blnNewTrans = True
                    objSqlTransaction = objSqlConnection.BeginTransaction
                Else
                    blnNewTrans = False
                End If

                '上传文件
                Dim strDesUrl As String
                With objFTPProperty
                    strDesUrl = .getUrl(strDesFile)
                    If objBaseFTP.doPutFile(strErrMsg, strGJFile, strDesUrl, .UserID, .Password, .ProxyUrl, .ProxyUserID, .ProxyPassword) = False Then
                        GoTo rollDatabaseAndFile
                    End If
                End With

                Try
                    '准备命令参数
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout
                    '准备SQL
                    strSQL = ""
                    strSQL = strSQL + " update 考勤_B_休假申请单 set "
                    strSQL = strSQL + "   正文内容 = @zwnr "
                    strSQL = strSQL + " where 文件标识  = @wjbs "
                    strSQL = strSQL + " and   正文内容 <> @zwnr "
                    '执行命令
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@zwnr", strDesFile)
                    objSqlCommand.Parameters.AddWithValue("@wjbs", strWJBS)
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo rollDatabaseAndFile
                End Try
                '提交事务
                If blnNewTrans = True Then
                    objSqlTransaction.Commit()
                End If

                '删除备份文件
                If blnNewTrans = True Then
                    If Me.doDeleteBackupFiles_GJ(strErrMsg, strZWNR, objFTPProperty) = False Then
                        '可以不成功，形成垃圾文件！
                    End If
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.BaseFTP.SafeRelease(objBaseFTP)

            doSaveGJFile = True
            Exit Function

rollDatabaseAndFile:
            If blnNewTrans = True Then
                objSqlTransaction.Rollback()
                If Me.doRestoreFiles_GJ(strSQL, strZWNR, objFTPProperty) = False Then
                    '可以不成功，形成垃圾数据
                End If
            End If
            GoTo errProc

errProc:
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.BaseFTP.SafeRelease(objBaseFTP)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 保存工作流记录(整个事务完成)
        '     strErrMsg              ：如果错误，则返回错误信息
        '     objNewData             ：记录新值(返回保存后的新值)
        '     objOldData             ：记录旧值
        '     objenumEditType        ：编辑类型
        '     strGJFile              ：要保存的稿件文件的本地缓存文件完整路径
        '     objDataSet_FJ          ：要保存的附件数据
        '     objDataSet_XGWJ        ：要保存的相关文件数据
        '     strUserXM              ：当前操作人员
        '     blnEnforeEdit          ：强制编辑文件数据
        '     objConnectionProperty  ：FTP连接参数
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
        '----------------------------------------------------------------
        Public Overrides Function doSaveFileTransaction( _
            ByRef strErrMsg As String, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objOldData As Josco.JSOA.Common.Workflow.BaseFlowObject, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType, _
            ByVal strGJFile As String, _
            ByVal objDataSet_FJ As Josco.JSOA.Common.Data.FlowData, _
            ByVal objDataSet_XGWJ As Josco.JSOA.Common.Data.FlowData, _
            ByVal strUserXM As String, _
            ByVal blnEnforeEdit As Boolean, _
            ByVal objFTPProperty As Josco.JsKernal.Common.Utilities.FTPProperty) As Boolean

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection

            Dim objOldFJData As Josco.JSOA.Common.Data.FlowData
            Dim objOldXGWJData As Josco.JSOA.Common.Data.FlowData
            Dim objNewXGWJFJData As Josco.JSOA.Common.Data.FlowData
            Dim objOldXGWJFJData As Josco.JSOA.Common.Data.FlowData

            Dim strCZSM As String = Josco.JSOA.Common.Workflow.BaseFlowObject.LOGO_QXBJ
            Dim intWJND As Integer = Year(Now)
            Dim strOldZWNR As String
            Dim strWJBS As String
            Dim strSQL As String

            doSaveFileTransaction = False

            Try
                If Me.IsInitialized = False Then
                    strErrMsg = "错误：[doSaveFileTransaction]对象还没有初始化，不能使用！"
                    GoTo errProc
                End If
                If Me.IsFillData = False Then
                    strErrMsg = "错误：[doSaveFileTransaction]对象还没有填充数据，不能使用！"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    strErrMsg = "错误：[doSaveFileTransaction]没有指定要保存的数据！"
                    GoTo errProc
                End If
                If objFTPProperty Is Nothing Then
                    strErrMsg = "错误：[doSaveFileTransaction]没有指定FTP连接参数！"
                    GoTo errProc
                End If
                If strGJFile Is Nothing Then strGJFile = ""
                strGJFile = strGJFile.Trim
                If strUserXM Is Nothing Then strUserXM = ""
                strUserXM = strUserXM.Trim

                '检查主记录
                If Me.doVerifyFile(strErrMsg, objNewData, objOldData, objenumEditType) = False Then
                    GoTo errProc
                End If

                '获取连接事务
                objSqlConnection = Me.SqlConnection

                '获取原附件数据
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                        Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                        strOldZWNR = ""
                        objOldFJData = Nothing
                        objOldXGWJData = Nothing
                        objOldXGWJFJData = Nothing

                    Case Else
                        strOldZWNR = CType(Me.FlowData, Josco.JSOA.Common.Workflow.BaseFlowKqglQJD).ZWNR
                        If Me.getFujianData(strErrMsg, objOldFJData) = False Then
                            GoTo errProc
                        End If
                        If Me.getXgwjData(strErrMsg, objOldXGWJData) = False Then
                            GoTo errProc
                        End If
                        If Me.doSplitXGWJDataSet(strErrMsg, objOldXGWJData, objOldXGWJFJData) = False Then
                            GoTo errProc
                        End If
                End Select
                If Me.doSplitXGWJDataSet(strErrMsg, objDataSet_XGWJ, objNewXGWJFJData) = False Then
                    GoTo errProc
                End If

                '开始事务
                objSqlTransaction = objSqlConnection.BeginTransaction

                '执行事务
                Try
                    '保存主记录
                    If Me.doSaveFile(strErrMsg, objSqlTransaction, objNewData, objOldData, objenumEditType) = False Then
                        GoTo rollDatabase
                    End If

                    '设置新文件标识
                    strWJBS = objNewData(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_WJBS)
                    Me.FlowData.WJBS = strWJBS

                    '如果是新增
                    Select Case objenumEditType
                        Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                            Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                            '保存初始交接数据
                            If Me.doSaveInitJJD(strErrMsg, objSqlTransaction, strUserXM, strUserXM) = False Then
                                GoTo rollDatabase
                            End If
                        Case Else
                    End Select

                    '保存稿件文件
                    If Me.doSaveGJFile(strErrMsg, intWJND, objSqlTransaction, objFTPProperty, strGJFile) = False Then
                        GoTo rollGJFile
                    End If

                    '保存附件文件
                    If Me.doSaveFujian(strErrMsg, strWJBS, intWJND, objSqlTransaction, objFTPProperty, objDataSet_FJ, objOldFJData) = False Then
                        GoTo rollGJAndFJFile
                    End If

                    '保存相关文件数据
                    If Me.doSaveXgwj(strErrMsg, strWJBS, intWJND, objSqlTransaction, objFTPProperty, objDataSet_XGWJ, objOldXGWJData, objNewXGWJFJData, objOldXGWJFJData) = False Then
                        GoTo rollGJAndFJAndXGWJFile
                    End If

                    '如果是强制编辑
                    If blnEnforeEdit = True Then
                        If Me.doWriteFileLogo(strErrMsg, objSqlTransaction, strUserXM, strCZSM) = False Then
                            GoTo rollGJAndFJAndXGWJFile
                        End If
                    End If

                    '解除文件编辑封锁
                    If Me.doLockFile(strErrMsg, objSqlTransaction, "", False) = False Then
                        GoTo rollGJAndFJAndXGWJFile
                    End If

                    '清除备份文件
                    If Me.doDeleteBackupFiles_GJ(strErrMsg, strOldZWNR, objFTPProperty) = False Then
                        '可以不成功，形成垃圾文件
                    End If
                    If Me.doDeleteBackupFiles_FJ(strErrMsg, objFTPProperty, objOldFJData) = False Then
                        '可以不成功，形成垃圾文件
                    End If
                    If Me.doDeleteBackupFiles_XGWJFJ(strErrMsg, objFTPProperty, objOldXGWJFJData) = False Then
                        '可以不成功，形成垃圾文件
                    End If

                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo rollDatabase
                End Try

                '提交事务
                objSqlTransaction.Commit()

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.Common.Data.FlowData.SafeRelease(objOldFJData)
            Josco.JSOA.Common.Data.FlowData.SafeRelease(objOldXGWJData)
            Josco.JSOA.Common.Data.FlowData.SafeRelease(objOldXGWJFJData)
            Josco.JSOA.Common.Data.FlowData.SafeRelease(objNewXGWJFJData)

            doSaveFileTransaction = True
            Exit Function

rollGJAndFJAndXGWJFile:
            objSqlTransaction.Rollback()
            If Me.doRestoreFiles_GJ(strSQL, strOldZWNR, objFTPProperty) = False Then
                '已经尽力了！
            End If
            If Me.doRestoreFiles_FJ(strSQL, strWJBS, intWJND, objFTPProperty, objDataSet_FJ, objOldFJData) = False Then
                '已经尽力了！
            End If
            If Me.doRestoreFiles_XGWJFJ(strSQL, strWJBS, intWJND, objFTPProperty, objNewXGWJFJData, objOldXGWJFJData) = False Then
                '已经尽力了！
            End If
            GoTo errProc

rollGJAndFJFile:
            objSqlTransaction.Rollback()
            If Me.doRestoreFiles_GJ(strSQL, strOldZWNR, objFTPProperty) = False Then
                '已经尽力了！
            End If
            If Me.doRestoreFiles_FJ(strSQL, strWJBS, intWJND, objFTPProperty, objDataSet_FJ, objOldFJData) = False Then
                '已经尽力了！
            End If
            GoTo errProc

rollGJFile:
            objSqlTransaction.Rollback()
            If Me.doRestoreFiles_GJ(strSQL, strOldZWNR, objFTPProperty) = False Then
                '已经尽力了！
            End If
            GoTo errProc

rollDatabase:
            objSqlTransaction.Rollback()
            GoTo errProc

errProc:
            Josco.JSOA.Common.Data.FlowData.SafeRelease(objOldFJData)
            Josco.JSOA.Common.Data.FlowData.SafeRelease(objOldXGWJData)
            Josco.JSOA.Common.Data.FlowData.SafeRelease(objOldXGWJFJData)
            Josco.JSOA.Common.Data.FlowData.SafeRelease(objNewXGWJFJData)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 保存“考勤_B_休假申请单_假期”数据
        '     strErrMsg              ：如果错误，则返回错误信息
        '     strWJBS                ：文件标识
        '     objSqlTransaction      ：现有事务
        '     objNewData             ：记录新值(返回保存后的新值)
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
        '----------------------------------------------------------------
        Private Function doSaveJqxx( _
            ByRef strErrMsg As String, _
            ByVal strWJBS As String, _
            ByVal objSqlTransaction As System.Data.SqlClient.SqlTransaction, _
            ByRef objNewData As Josco.JSOA.Common.Data.kaoqinguanliData) As Boolean

            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand

            Dim strTable As String = Josco.JSOA.Common.Data.kaoqinguanliData.TABLE_KQ_B_XIUJIASHENQINGDAN_JIAQI
            Dim blnNewTrans As Boolean = False
            Dim strSQL As String

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            '初始化
            doSaveJqxx = False
            strErrMsg = ""

            Try
                '检查
                If Me.IsInitialized = False Then
                    strErrMsg = "错误：对象还没有初始化，不能使用！"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    strErrMsg = "错误：未传入新的数据！"
                    GoTo errProc
                End If
                If strWJBS Is Nothing Then strWJBS = ""
                strWJBS = strWJBS.Trim
                If strWJBS = "" Then
                    Exit Try
                End If

                '获取现有信息
                If objSqlTransaction Is Nothing Then
                    objSqlConnection = Me.SqlConnection
                Else
                    objSqlConnection = objSqlTransaction.Connection
                End If

                '开始事务
                If objSqlTransaction Is Nothing Then
                    blnNewTrans = True
                    objSqlTransaction = objSqlConnection.BeginTransaction()
                Else
                    blnNewTrans = False
                End If

                '保存数据
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '删除“考勤_B_休假申请单_假期”数据
                    strSQL = ""
                    strSQL = strSQL + " delete from 考勤_B_休假申请单_假期 " + vbCr
                    strSQL = strSQL + " where 文件标识 = @wjbs" + vbCr
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@wjbs", strWJBS)
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()

                    Try
                        '保存新数据
                        Dim strValue As String = ""
                        Dim intCount As Integer
                        Dim i As Integer
                        With objNewData.Tables(strTable)
                            intCount = .DefaultView.Count
                            For i = 0 To intCount - 1 Step 1
                                '写数据
                                strSQL = ""
                                strSQL = strSQL + " insert into 考勤_B_休假申请单_假期 (" + vbCr
                                strSQL = strSQL + "   唯一标识,文件标识,记录代码,天数,记录名称,序号 " + vbCr
                                strSQL = strSQL + " ) values (" + vbCr
                                strSQL = strSQL + "   newid(),@wjbs,@jldm,@ts,@jlmc,@xh " + vbCr
                                strSQL = strSQL + " )" + vbCr

                                objSqlCommand.Parameters.Clear()
                                objSqlCommand.Parameters.AddWithValue("@wjbs", strWJBS)
                                objSqlCommand.Parameters.AddWithValue("@jldm", objPulicParameters.getObjectValue(.DefaultView.Item(i).Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_JIAQI_JQDM), ""))
                                strValue = objPulicParameters.getObjectValue(.DefaultView.Item(i).Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_JIAQI_TS), "")
                                If strValue = "" Then
                                    objSqlCommand.Parameters.AddWithValue("@ts", 0)
                                Else
                                    objSqlCommand.Parameters.AddWithValue("@ts", CType(strValue, Integer))
                                End If

                                objSqlCommand.Parameters.AddWithValue("@jlmc", objPulicParameters.getObjectValue(.DefaultView.Item(i).Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_JIAQI_JQMC), ""))
                                strValue = objPulicParameters.getObjectValue(.DefaultView.Item(i).Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_JIAQI_XH), "")
                                If strValue = "" Then
                                    objSqlCommand.Parameters.AddWithValue("@xh", 0)
                                Else
                                    objSqlCommand.Parameters.AddWithValue("@xh", CType(strValue, Integer))
                                End If
                                
                                objSqlCommand.CommandText = strSQL
                                objSqlCommand.ExecuteNonQuery()
                            Next
                        End With
                    Catch ex As Exception
                        strErrMsg = ex.Message
                        GoTo rollDatabase
                    End Try
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo rollDatabase
                End Try

                '提交事务
                If blnNewTrans = True Then
                    objSqlTransaction.Commit()
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)

            '返回
            doSaveJqxx = True
            Exit Function

rollDatabase:
            If blnNewTrans = True Then
                objSqlTransaction.Rollback()
            End If
            GoTo errProc

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Exit Function

        End Function


       

        '----------------------------------------------------------------
        ' 保存工作流记录(整个事务完成)
        '     strErrMsg              ：如果错误，则返回错误信息
        '     objNewData             ：记录新值(返回保存后的新值)
        '     objOldData             ：记录旧值
        '     objenumEditType        ：编辑类型
        '     strGJFile              ：要保存的稿件文件的本地缓存文件完整路径
        '     objDataSet_FJ          ：要保存的附件数据
        '     objDataSet_XGWJ        ：要保存的相关文件数据
        '     strUserXM              ：当前操作人员
        '     blnEnforeEdit          ：强制编辑文件数据
        '     objConnectionProperty  ：FTP连接参数
        '     objParams              ：其他要随事务提交的数据
        '                              0 - “考勤_B_休假申请单_假期”数据集
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
        '----------------------------------------------------------------
        Public Overrides Function doSaveFileTransactionVariantParam( _
            ByRef strErrMsg As String, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objOldData As Josco.JSOA.Common.Workflow.BaseFlowObject, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType, _
            ByVal strGJFile As String, _
            ByVal objDataSet_FJ As Josco.JSOA.Common.Data.FlowData, _
            ByVal objDataSet_XGWJ As Josco.JSOA.Common.Data.FlowData, _
            ByVal strUserXM As String, _
            ByVal blnEnforeEdit As Boolean, _
            ByVal objFTPProperty As Josco.JsKernal.Common.Utilities.FTPProperty, _
            ByVal objParams As System.Collections.Specialized.ListDictionary) As Boolean

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection

            Dim objOldFJData As Josco.JSOA.Common.Data.FlowData
            Dim objOldXGWJData As Josco.JSOA.Common.Data.FlowData
            Dim objNewXGWJFJData As Josco.JSOA.Common.Data.FlowData
            Dim objOldXGWJFJData As Josco.JSOA.Common.Data.FlowData

            Dim strCZSM As String = Josco.JSOA.Common.Workflow.BaseFlowObject.LOGO_QXBJ
            Dim intWJND As Integer = Year(Now)
            Dim strOldZWNR As String
            Dim strWJBS As String
            Dim strSQL As String

            doSaveFileTransactionVariantParam = False

            Try
                If Me.IsInitialized = False Then
                    strErrMsg = "错误：[doSaveFileTransactionVariantParam]对象还没有初始化，不能使用！"
                    GoTo errProc
                End If
                If Me.IsFillData = False Then
                    strErrMsg = "错误：[doSaveFileTransactionVariantParam]对象还没有填充数据，不能使用！"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    strErrMsg = "错误：[doSaveFileTransactionVariantParam]没有指定要保存的数据！"
                    GoTo errProc
                End If
                If objFTPProperty Is Nothing Then
                    strErrMsg = "错误：[doSaveFileTransactionVariantParam]没有指定FTP连接参数！"
                    GoTo errProc
                End If
                If strGJFile Is Nothing Then strGJFile = ""
                strGJFile = strGJFile.Trim
                If strUserXM Is Nothing Then strUserXM = ""
                strUserXM = strUserXM.Trim

                '检查主记录
                If Me.doVerifyFile(strErrMsg, objNewData, objOldData, objenumEditType) = False Then
                    GoTo errProc
                End If

                '获取连接事务
                objSqlConnection = Me.SqlConnection

                '获取原附件数据
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                        Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                        strOldZWNR = ""
                        objOldFJData = Nothing
                        objOldXGWJData = Nothing
                        objOldXGWJFJData = Nothing

                    Case Else
                        strOldZWNR = CType(Me.FlowData, Josco.JSOA.Common.Workflow.BaseFlowKqglQJD).ZWNR
                        If Me.getFujianData(strErrMsg, objOldFJData) = False Then
                            GoTo errProc
                        End If
                        If Me.getXgwjData(strErrMsg, objOldXGWJData) = False Then
                            GoTo errProc
                        End If
                        If Me.doSplitXGWJDataSet(strErrMsg, objOldXGWJData, objOldXGWJFJData) = False Then
                            GoTo errProc
                        End If
                End Select
                If Me.doSplitXGWJDataSet(strErrMsg, objDataSet_XGWJ, objNewXGWJFJData) = False Then
                    GoTo errProc
                End If

                '开始事务
                objSqlTransaction = objSqlConnection.BeginTransaction

                '执行事务
                Try
                    '保存主记录
                    If Me.doSaveFile(strErrMsg, objSqlTransaction, objNewData, objOldData, objenumEditType) = False Then
                        GoTo rollDatabase
                    End If

                    '设置新文件标识
                    strWJBS = objNewData(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIASHENQINGDAN_WJBS)
                    Me.FlowData.WJBS = strWJBS

                    '如果是新增
                    Select Case objenumEditType
                        Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                            Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                            '保存初始交接数据
                            If Me.doSaveInitJJD(strErrMsg, objSqlTransaction, strUserXM, strUserXM) = False Then
                                GoTo rollDatabase
                            End If
                        Case Else
                    End Select

                    '保存其他内容
                    If Not (objParams Is Nothing) Then
                        If objParams.Count > 0 Then
                            Dim objDataSet_RYXX As Josco.JSOA.Common.Data.kaoqinguanliData = Nothing
                            Try
                                objDataSet_RYXX = CType(objParams.Item(0), Josco.JSOA.Common.Data.kaoqinguanliData)
                            Catch ex As Exception
                                objDataSet_RYXX = Nothing
                            End Try
                            If Not (objDataSet_RYXX Is Nothing) Then
                                If Me.doSaveJqxx(strErrMsg, strWJBS, objSqlTransaction, objDataSet_RYXX) = False Then
                                    GoTo rollDatabase
                                End If
                            End If
                        End If
                    End If

                    '保存稿件文件
                    If Me.doSaveGJFile(strErrMsg, intWJND, objSqlTransaction, objFTPProperty, strGJFile) = False Then
                        GoTo rollGJFile
                    End If

                    '保存附件文件
                    If Me.doSaveFujian(strErrMsg, strWJBS, intWJND, objSqlTransaction, objFTPProperty, objDataSet_FJ, objOldFJData) = False Then
                        GoTo rollGJAndFJFile
                    End If

                    '保存相关文件数据
                    If Me.doSaveXgwj(strErrMsg, strWJBS, intWJND, objSqlTransaction, objFTPProperty, objDataSet_XGWJ, objOldXGWJData, objNewXGWJFJData, objOldXGWJFJData) = False Then
                        GoTo rollGJAndFJAndXGWJFile
                    End If

                    '如果是强制编辑
                    If blnEnforeEdit = True Then
                        If Me.doWriteFileLogo(strErrMsg, objSqlTransaction, strUserXM, strCZSM) = False Then
                            GoTo rollGJAndFJAndXGWJFile
                        End If
                    End If

                    '解除文件编辑封锁
                    If Me.doLockFile(strErrMsg, objSqlTransaction, "", False) = False Then
                        GoTo rollGJAndFJAndXGWJFile
                    End If

                    '清除备份文件
                    If Me.doDeleteBackupFiles_GJ(strErrMsg, strOldZWNR, objFTPProperty) = False Then
                        '可以不成功，形成垃圾文件
                    End If
                    If Me.doDeleteBackupFiles_FJ(strErrMsg, objFTPProperty, objOldFJData) = False Then
                        '可以不成功，形成垃圾文件
                    End If
                    If Me.doDeleteBackupFiles_XGWJFJ(strErrMsg, objFTPProperty, objOldXGWJFJData) = False Then
                        '可以不成功，形成垃圾文件
                    End If

                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo rollDatabase
                End Try

                '提交事务
                objSqlTransaction.Commit()

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.Common.Data.FlowData.SafeRelease(objOldFJData)
            Josco.JSOA.Common.Data.FlowData.SafeRelease(objOldXGWJData)
            Josco.JSOA.Common.Data.FlowData.SafeRelease(objOldXGWJFJData)
            Josco.JSOA.Common.Data.FlowData.SafeRelease(objNewXGWJFJData)

            doSaveFileTransactionVariantParam = True
            Exit Function

rollGJAndFJAndXGWJFile:
            objSqlTransaction.Rollback()
            If Me.doRestoreFiles_GJ(strSQL, strOldZWNR, objFTPProperty) = False Then
                '已经尽力了！
            End If
            If Me.doRestoreFiles_FJ(strSQL, strWJBS, intWJND, objFTPProperty, objDataSet_FJ, objOldFJData) = False Then
                '已经尽力了！
            End If
            If Me.doRestoreFiles_XGWJFJ(strSQL, strWJBS, intWJND, objFTPProperty, objNewXGWJFJData, objOldXGWJFJData) = False Then
                '已经尽力了！
            End If
            GoTo errProc

rollGJAndFJFile:
            objSqlTransaction.Rollback()
            If Me.doRestoreFiles_GJ(strSQL, strOldZWNR, objFTPProperty) = False Then
                '已经尽力了！
            End If
            If Me.doRestoreFiles_FJ(strSQL, strWJBS, intWJND, objFTPProperty, objDataSet_FJ, objOldFJData) = False Then
                '已经尽力了！
            End If
            GoTo errProc

rollGJFile:
            objSqlTransaction.Rollback()
            If Me.doRestoreFiles_GJ(strSQL, strOldZWNR, objFTPProperty) = False Then
                '已经尽力了！
            End If
            GoTo errProc

rollDatabase:
            objSqlTransaction.Rollback()
            GoTo errProc

errProc:
            Josco.JSOA.Common.Data.FlowData.SafeRelease(objOldFJData)
            Josco.JSOA.Common.Data.FlowData.SafeRelease(objOldXGWJData)
            Josco.JSOA.Common.Data.FlowData.SafeRelease(objOldXGWJFJData)
            Josco.JSOA.Common.Data.FlowData.SafeRelease(objNewXGWJFJData)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 保存工作流稿件、附件、相关文件记录(完整事务操作)
        '     strErrMsg              ：如果错误，则返回错误信息
        '     strGJFile              ：要保存的稿件文件的本地缓存文件完整路径
        '     objDataSet_FJ          ：要保存的附件数据
        '     objDataSet_XGWJ        ：要保存的相关文件数据
        '     strUserXM              ：当前操作人员
        '     blnEnforeEdit          ：强制编辑文件数据
        '     objFTPProperty         ：FTP连接参数
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
        '----------------------------------------------------------------
        Public Overrides Function doSaveFileTransactionZDBC( _
            ByRef strErrMsg As String, _
            ByVal strGJFile As String, _
            ByVal objDataSet_FJ As Josco.JSOA.Common.Data.FlowData, _
            ByVal objDataSet_XGWJ As Josco.JSOA.Common.Data.FlowData, _
            ByVal strUserXM As String, _
            ByVal blnEnforeEdit As Boolean, _
            ByVal objFTPProperty As Josco.JsKernal.Common.Utilities.FTPProperty) As Boolean

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection

            Dim objOldFJData As Josco.JSOA.Common.Data.FlowData
            Dim objOldXGWJData As Josco.JSOA.Common.Data.FlowData
            Dim objOldXGWJFJData As Josco.JSOA.Common.Data.FlowData
            Dim objNewXGWJFJData As Josco.JSOA.Common.Data.FlowData

            Dim strCZSM As String = Josco.JSOA.Common.Workflow.BaseFlowObject.LOGO_QXBJ
            Dim intWJND As Integer = Year(Now)
            Dim strOldZWNR As String
            Dim strWJBS As String
            Dim strSQL As String

            doSaveFileTransactionZDBC = False

            Try
                If Me.IsInitialized = False Then
                    strErrMsg = "错误：[doSaveFileTransactionZDBC]对象还没有初始化，不能使用！"
                    GoTo errProc
                End If
                If Me.IsFillData = False Then
                    strErrMsg = "错误：[doSaveFileTransactionZDBC]对象还没有获取数据，不能使用！"
                    GoTo errProc
                End If
                If objFTPProperty Is Nothing Then
                    strErrMsg = "错误：[doSaveFileTransactionZDBC]没有指定FTP连接参数！"
                    GoTo errProc
                End If
                If strGJFile Is Nothing Then strGJFile = ""
                strGJFile = strGJFile.Trim
                If strUserXM Is Nothing Then strUserXM = ""
                strUserXM = strUserXM.Trim

                '获取参数
                strOldZWNR = CType(Me.FlowData, Josco.JSOA.Common.Workflow.BaseFlowKqglQJD).ZWNR
                objSqlConnection = Me.SqlConnection
                strWJBS = Me.WJBS

                '获取原附件数据
                If Me.getFujianData(strErrMsg, objOldFJData) = False Then
                    GoTo errProc
                End If

                '获取原相关文件数据
                If Me.getXgwjData(strErrMsg, objOldXGWJData) = False Then
                    GoTo errProc
                End If
                '分离出原相关附件
                If Me.doSplitXGWJDataSet(strErrMsg, objOldXGWJData, objOldXGWJFJData) = False Then
                    GoTo errProc
                End If
                '分离出新相关附件
                If Me.doSplitXGWJDataSet(strErrMsg, objDataSet_XGWJ, objNewXGWJFJData) = False Then
                    GoTo errProc
                End If

                '开始事务
                objSqlTransaction = objSqlConnection.BeginTransaction

                '执行事务
                Try
                    '保存稿件文件
                    If Me.doSaveGJFile(strErrMsg, intWJND, objSqlTransaction, objFTPProperty, strGJFile) = False Then
                        GoTo rollGJFile
                    End If

                    '保存附件文件
                    If Me.doSaveFujian(strErrMsg, strWJBS, intWJND, objSqlTransaction, objFTPProperty, objDataSet_FJ, objOldFJData) = False Then
                        GoTo rollGJAndFJFile
                    End If

                    '保存相关文件数据
                    If Me.doSaveXgwj(strErrMsg, strWJBS, intWJND, objSqlTransaction, objFTPProperty, objDataSet_XGWJ, objOldXGWJData, objNewXGWJFJData, objOldXGWJFJData) = False Then
                        GoTo rollGJAndFJAndXGWJFile
                    End If

                    '如果是强制编辑
                    If blnEnforeEdit = True Then
                        If Me.doWriteFileLogo(strErrMsg, objSqlTransaction, strUserXM, strCZSM) = False Then
                            GoTo rollGJAndFJAndXGWJFile
                        End If
                    End If

                    '解除文件编辑封锁
                    If Me.doLockFile(strErrMsg, objSqlTransaction, "", False) = False Then
                        GoTo rollGJAndFJAndXGWJFile
                    End If

                    '清除备份文件
                    If Me.doDeleteBackupFiles_GJ(strErrMsg, strOldZWNR, objFTPProperty) = False Then
                        '可以不成功，形成垃圾文件
                    End If
                    If Me.doDeleteBackupFiles_FJ(strErrMsg, objFTPProperty, objOldFJData) = False Then
                        '可以不成功，形成垃圾文件
                    End If
                    If Me.doDeleteBackupFiles_XGWJFJ(strErrMsg, objFTPProperty, objOldXGWJFJData) = False Then
                        '可以不成功，形成垃圾文件
                    End If

                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo rollDatabase
                End Try

                '提交事务
                objSqlTransaction.Commit()

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.Common.Data.FlowData.SafeRelease(objOldFJData)
            Josco.JSOA.Common.Data.FlowData.SafeRelease(objOldXGWJData)
            Josco.JSOA.Common.Data.FlowData.SafeRelease(objOldXGWJFJData)
            Josco.JSOA.Common.Data.FlowData.SafeRelease(objNewXGWJFJData)

            doSaveFileTransactionZDBC = True
            Exit Function

rollGJAndFJAndXGWJFile:
            objSqlTransaction.Rollback()
            If Me.doRestoreFiles_GJ(strSQL, strOldZWNR, objFTPProperty) = False Then
                '已经尽力了！
            End If
            If Me.doRestoreFiles_FJ(strSQL, strWJBS, intWJND, objFTPProperty, objDataSet_FJ, objOldFJData) = False Then
                '已经尽力了！
            End If
            If Me.doRestoreFiles_XGWJFJ(strSQL, strWJBS, intWJND, objFTPProperty, objNewXGWJFJData, objOldXGWJFJData) = False Then
                '已经尽力了！
            End If
            GoTo errProc

rollGJAndFJFile:
            objSqlTransaction.Rollback()
            If Me.doRestoreFiles_GJ(strSQL, strOldZWNR, objFTPProperty) = False Then
                '已经尽力了！
            End If
            If Me.doRestoreFiles_FJ(strSQL, strWJBS, intWJND, objFTPProperty, objDataSet_FJ, objOldFJData) = False Then
                '已经尽力了！
            End If
            GoTo errProc

rollGJFile:
            objSqlTransaction.Rollback()
            If Me.doRestoreFiles_GJ(strSQL, strOldZWNR, objFTPProperty) = False Then
                '已经尽力了！
            End If
            GoTo errProc

rollDatabase:
            objSqlTransaction.Rollback()
            GoTo errProc

errProc:
            Josco.JSOA.Common.Data.FlowData.SafeRelease(objOldFJData)
            Josco.JSOA.Common.Data.FlowData.SafeRelease(objOldXGWJData)
            Josco.JSOA.Common.Data.FlowData.SafeRelease(objOldXGWJFJData)
            Josco.JSOA.Common.Data.FlowData.SafeRelease(objNewXGWJFJData)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 保存工作流稿件、附件、相关文件记录(完整事务操作)
        '     strErrMsg              ：如果错误，则返回错误信息
        '     strGJFile              ：要保存的稿件文件的本地缓存文件完整路径
        '     objDataSet_FJ          ：要保存的附件数据
        '     objDataSet_XGWJ        ：要保存的相关文件数据
        '     strUserXM              ：当前操作人员
        '     blnEnforeEdit          ：强制编辑文件数据
        '     objFTPProperty         ：FTP连接参数
        '     objParams              ：其他要随事务提交的数据
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
        '----------------------------------------------------------------
        Public Overrides Function doSaveFileTransactionZDBCVariantParam( _
            ByRef strErrMsg As String, _
            ByVal strGJFile As String, _
            ByVal objDataSet_FJ As Josco.JSOA.Common.Data.FlowData, _
            ByVal objDataSet_XGWJ As Josco.JSOA.Common.Data.FlowData, _
            ByVal strUserXM As String, _
            ByVal blnEnforeEdit As Boolean, _
            ByVal objFTPProperty As Josco.JsKernal.Common.Utilities.FTPProperty, _
            ByVal objParams As System.Collections.Specialized.ListDictionary) As Boolean

            doSaveFileTransactionZDBCVariantParam = False

            Try
                doSaveFileTransactionZDBCVariantParam = Me.doSaveFileTransactionZDBC(strErrMsg, strGJFile, objDataSet_FJ, objDataSet_XGWJ, strUserXM, blnEnforeEdit, objFTPProperty)
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            doSaveFileTransactionZDBCVariantParam = True
            Exit Function
errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 翻译办理事宜
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strOldBlsy           ：翻译前的办理事宜
        '     strNewBlsy           ：翻译后的办理事宜
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Overrides Function doTranslateTask( _
            ByRef strErrMsg As String, _
            ByVal strOldBlsy As String, _
            ByRef strNewBlsy As String) As Boolean

            doTranslateTask = False
            strErrMsg = ""
            strNewBlsy = strOldBlsy

            Try
                '检查
                If Me.IsInitialized = False Then
                    strErrMsg = "错误：[doTranslateTask]工作流没有初始化！"
                    GoTo errProc
                End If
                If Me.IsFillData = False Then
                    strErrMsg = "错误：[doTranslateTask]工作流没有填充数据！"
                    GoTo errProc
                End If
                If strOldBlsy Is Nothing Then
                    Exit Try
                End If
                strOldBlsy = strOldBlsy.Trim

                '翻译
                Dim objBaseFlowKqglQJD As Josco.JSOA.Common.Workflow.BaseFlowKqglQJD
                objBaseFlowKqglQJD = CType(Me.FlowData, Josco.JSOA.Common.Workflow.BaseFlowKqglQJD)
                Select Case strOldBlsy
                    Case objBaseFlowKqglQJD.TASK_CYCG
                        strNewBlsy = objBaseFlowKqglQJD.TASK_GJBJ
                    Case Else
                        strNewBlsy = strOldBlsy
                End Select

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            doTranslateTask = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 处理“暂缓处理”业务
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserXM            ：用户名称
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Overrides Function doIStopFile( _
            ByRef strErrMsg As String, _
            ByVal strUserXM As String) As Boolean

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand
            Dim strSQL As String

            Dim objdacCustomer As New Josco.JsKernal.DataAccess.dacCustomer

            doIStopFile = False
            strErrMsg = ""

            Try
                '检查
                If Me.IsInitialized = False Then
                    strErrMsg = "错误：[doIStopFile]对象还没有初始化，不能使用！"
                    GoTo errProc
                End If
                If strUserXM Is Nothing Then strUserXM = ""
                strUserXM = strUserXM.Trim

                '获取文件信息
                Dim strTaskStatusYWCList As String = Me.FlowData.TaskStatusYWCList
                Dim strWJBS As String = Me.WJBS
                If strWJBS = "" Then
                    Exit Try
                End If

                '获取事务连接
                objSqlConnection = Me.SqlConnection

                '获取人员代码
                Dim strUserId As String
                If objdacCustomer.getRydmByRymc(strErrMsg, objSqlConnection, strUserXM, strUserId) = False Then
                    GoTo errProc
                End If
                If strUserId <> "" Then
                    '解除自己的文件封锁
                    If Me.doLockFile(strErrMsg, strUserId, False) = False Then
                        GoTo errProc
                    End If
                End If

                '检查是否有人在编辑本文件！
                Dim blnLocked As Boolean
                Dim strBMMC As String
                Dim strRYMC As String
                If Me.getFileLocked(strErrMsg, blnLocked, strBMMC, strRYMC) = False Then
                    GoTo errProc
                End If
                If blnLocked = True Then
                    strErrMsg = "错误：[" + strBMMC + "]的[" + strRYMC + "]正在修改本文件[" + strWJBS + "]，请稍后再进行处理！"
                    GoTo errProc
                End If

                '创建SqlCommand
                objSqlCommand = New System.Data.SqlClient.SqlCommand
                objSqlCommand.Connection = objSqlConnection
                objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                '开始事务
                objSqlTransaction = objSqlConnection.BeginTransaction
                objSqlCommand.Transaction = objSqlTransaction

                '事务处理
                Try
                    strSQL = ""
                    strSQL = strSQL + " update 公文_B_交接 set" + vbCr
                    strSQL = strSQL + "   办理状态 = '" + Me.FlowData.TASKSTATUS_YTB + "'," + vbCr
                    strSQL = strSQL + "   完成日期 = '" + Format(Now, "yyyy-MM-dd HH:mm:ss") + "'" + vbCr
                    strSQL = strSQL + " where 文件标识 = '" + strWJBS + "'" + vbCr                       '当前文件
                    strSQL = strSQL + " and   接收人   = '" + strUserXM + "'" + vbCr                     '接收人
                    strSQL = strSQL + " and   交接标识 like '_____0%'" + vbCr                            '非通知类
                    strSQL = strSQL + " and   办理状态 not in (" + strTaskStatusYWCList + ")" + vbCr     '未完成
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    strSQL = ""
                    strSQL = strSQL + " update 考勤_B_休假申请单 set" + vbCr
                    strSQL = strSQL + "   办理状态 = '" + Me.FlowData.FILESTATUS_YTB + "'" + vbCr
                    strSQL = strSQL + " where 文件标识 = '" + strWJBS + "'" + vbCr                       '当前文件
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                Catch ex As Exception
                    objSqlTransaction.Rollback()
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '提交事务
                objSqlTransaction.Commit()

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCustomer.SafeRelease(objdacCustomer)

            doIStopFile = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCustomer.SafeRelease(objdacCustomer)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 处理“继续办理”业务
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserXM            ：用户名称
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Overrides Function doIContinueFile( _
            ByRef strErrMsg As String, _
            ByVal strUserXM As String) As Boolean

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand
            Dim strSQL As String

            Dim objdacCustomer As New Josco.JsKernal.DataAccess.dacCustomer

            doIContinueFile = False
            strErrMsg = ""

            Try
                '检查
                If Me.IsInitialized = False Then
                    strErrMsg = "错误：[doIContinueFile]对象还没有初始化，不能使用！"
                    GoTo errProc
                End If
                If strUserXM Is Nothing Then strUserXM = ""
                strUserXM = strUserXM.Trim

                '获取文件信息
                Dim strTaskStatusYWCList As String = Me.FlowData.TaskStatusYWCList
                Dim strWJBS As String = Me.WJBS
                If strWJBS = "" Then
                    Exit Try
                End If

                '获取事务连接
                objSqlConnection = Me.SqlConnection

                '获取人员代码
                Dim strUserId As String
                If objdacCustomer.getRydmByRymc(strErrMsg, objSqlConnection, strUserXM, strUserId) = False Then
                    GoTo errProc
                End If
                If strUserId <> "" Then
                    '解除自己的文件封锁
                    If Me.doLockFile(strErrMsg, strUserId, False) = False Then
                        GoTo errProc
                    End If
                End If

                '检查是否有人在编辑本文件！
                Dim blnLocked As Boolean
                Dim strBMMC As String
                Dim strRYMC As String
                If Me.getFileLocked(strErrMsg, blnLocked, strBMMC, strRYMC) = False Then
                    GoTo errProc
                End If
                If blnLocked = True Then
                    strErrMsg = "错误：[" + strBMMC + "]的[" + strRYMC + "]正在修改本文件[" + strWJBS + "]，请稍后再进行处理！"
                    GoTo errProc
                End If

                '创建SqlCommand
                objSqlCommand = New System.Data.SqlClient.SqlCommand
                objSqlCommand.Connection = objSqlConnection
                objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                '开始事务
                objSqlTransaction = objSqlConnection.BeginTransaction
                objSqlCommand.Transaction = objSqlTransaction

                '事务处理
                Try
                    strSQL = ""
                    strSQL = strSQL + " update 公文_B_交接 set" + vbCr
                    strSQL = strSQL + "   办理状态 = '" + Me.FlowData.TASKSTATUS_ZJB + "'" + vbCr
                    strSQL = strSQL + " where 文件标识 = '" + strWJBS + "'" + vbCr                       '当前文件
                    strSQL = strSQL + " and   接收人   = '" + strUserXM + "'" + vbCr                     '接收人
                    strSQL = strSQL + " and   办理状态 = '" + Me.FlowData.TASKSTATUS_YTB + "'" + vbCr    '已停办
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    strSQL = ""
                    strSQL = strSQL + " update 考勤_B_休假申请单 set" + vbCr
                    strSQL = strSQL + "   办理状态 = '" + Me.FlowData.FILESTATUS_ZJB + "'" + vbCr
                    strSQL = strSQL + " where 文件标识 = '" + strWJBS + "'" + vbCr                       '当前文件
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                Catch ex As Exception
                    objSqlTransaction.Rollback()
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '提交事务
                objSqlTransaction.Commit()

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCustomer.SafeRelease(objdacCustomer)

            doIContinueFile = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCustomer.SafeRelease(objdacCustomer)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 处理“作废文件”业务
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserXM            ：用户名称
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Overrides Function doIZuofeiFile( _
            ByRef strErrMsg As String, _
            ByVal strUserXM As String) As Boolean

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand
            Dim strSQL As String

            Dim objdacCustomer As New Josco.JsKernal.DataAccess.dacCustomer

            doIZuofeiFile = False
            strErrMsg = ""

            Try
                '检查
                If Me.IsInitialized = False Then
                    strErrMsg = "错误：[doIZuofeiFile]对象还没有初始化，不能使用！"
                    GoTo errProc
                End If
                If strUserXM Is Nothing Then strUserXM = ""
                strUserXM = strUserXM.Trim

                '获取文件信息
                Dim strTaskStatusYWCList As String = Me.FlowData.TaskStatusYWCList
                Dim strWJBS As String = Me.WJBS
                If strWJBS = "" Then
                    Exit Try
                End If

                '获取事务连接
                objSqlConnection = Me.SqlConnection

                '获取人员代码
                Dim strUserId As String
                If objdacCustomer.getRydmByRymc(strErrMsg, objSqlConnection, strUserXM, strUserId) = False Then
                    GoTo errProc
                End If
                If strUserId <> "" Then
                    '解除自己的文件封锁
                    If Me.doLockFile(strErrMsg, strUserId, False) = False Then
                        GoTo errProc
                    End If
                End If

                '检查是否有人在编辑本文件！
                Dim blnLocked As Boolean
                Dim strBMMC As String
                Dim strRYMC As String
                If Me.getFileLocked(strErrMsg, blnLocked, strBMMC, strRYMC) = False Then
                    GoTo errProc
                End If
                If blnLocked = True Then
                    strErrMsg = "错误：[" + strBMMC + "]的[" + strRYMC + "]正在修改本文件[" + strWJBS + "]，请稍后再进行处理！"
                    GoTo errProc
                End If

                '创建SqlCommand
                objSqlCommand = New System.Data.SqlClient.SqlCommand
                objSqlCommand.Connection = objSqlConnection
                objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                '开始事务
                objSqlTransaction = objSqlConnection.BeginTransaction
                objSqlCommand.Transaction = objSqlTransaction

                '事务处理
                Try
                    strSQL = ""
                    strSQL = strSQL + " update 考勤_B_休假申请单 set" + vbCr
                    strSQL = strSQL + "   办理状态 = '" + Me.FlowData.FILESTATUS_YZF + "'" + vbCr
                    strSQL = strSQL + " where 文件标识 = '" + strWJBS + "'" + vbCr                       '当前文件
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                Catch ex As Exception
                    objSqlTransaction.Rollback()
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '提交事务
                objSqlTransaction.Commit()

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCustomer.SafeRelease(objdacCustomer)

            doIZuofeiFile = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCustomer.SafeRelease(objdacCustomer)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 处理“启用文件”业务
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserXM            ：用户名称
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Overrides Function doIQiyongFile( _
            ByRef strErrMsg As String, _
            ByVal strUserXM As String) As Boolean

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand
            Dim strSQL As String

            Dim objdacCustomer As New Josco.JsKernal.DataAccess.dacCustomer

            doIQiyongFile = False
            strErrMsg = ""

            Try
                '检查
                If Me.IsInitialized = False Then
                    strErrMsg = "错误：[doIQiyongFile]对象还没有初始化，不能使用！"
                    GoTo errProc
                End If
                If strUserXM Is Nothing Then strUserXM = ""
                strUserXM = strUserXM.Trim

                '获取文件信息
                Dim strTaskStatusYWCList As String = Me.FlowData.TaskStatusYWCList
                Dim strWJBS As String = Me.WJBS
                If strWJBS = "" Then
                    Exit Try
                End If

                '获取事务连接
                objSqlConnection = Me.SqlConnection

                '获取人员代码
                Dim strUserId As String
                If objdacCustomer.getRydmByRymc(strErrMsg, objSqlConnection, strUserXM, strUserId) = False Then
                    GoTo errProc
                End If
                If strUserId <> "" Then
                    '解除自己的文件封锁
                    If Me.doLockFile(strErrMsg, strUserId, False) = False Then
                        GoTo errProc
                    End If
                End If

                '检查是否有人在编辑本文件！
                Dim blnLocked As Boolean
                Dim strBMMC As String
                Dim strRYMC As String
                If Me.getFileLocked(strErrMsg, blnLocked, strBMMC, strRYMC) = False Then
                    GoTo errProc
                End If
                If blnLocked = True Then
                    strErrMsg = "错误：[" + strBMMC + "]的[" + strRYMC + "]正在修改本文件[" + strWJBS + "]，请稍后再进行处理！"
                    GoTo errProc
                End If

                '只有初始人能启用
                If Me.isOriginalPeople(strErrMsg, strUserXM, blnLocked) = False Then
                    GoTo errProc
                End If
                If blnLocked = False Then
                    strErrMsg = "错误：只有拟稿人才能启用稿件！"
                    GoTo errProc
                End If

                '创建SqlCommand
                objSqlCommand = New System.Data.SqlClient.SqlCommand
                objSqlCommand.Connection = objSqlConnection
                objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                '开始事务
                objSqlTransaction = objSqlConnection.BeginTransaction
                objSqlCommand.Transaction = objSqlTransaction

                '事务处理
                Try
                    '删除文件封锁信息
                    strSQL = "delete from 管理_B_文件封锁 where 文件标识 = '" + strWJBS + "'"
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    '删除督办信息
                    strSQL = "delete from 公文_B_督办 where 文件标识 = '" + strWJBS + "'"
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    '删除催办信息
                    strSQL = "delete from 公文_B_催办 where 文件标识 = '" + strWJBS + "'"
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    '删除公文办理信息
                    strSQL = "delete from 公文_B_办理 where 文件标识 = '" + strWJBS + "'"
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    '删除公文承办信息
                    strSQL = "delete from 公文_B_承办 where 文件标识 = '" + strWJBS + "'"
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    '删除公文交接信息
                    strSQL = ""
                    strSQL = strSQL + " delete from 公文_B_交接" + vbCr
                    strSQL = strSQL + " where 文件标识 = '" + strWJBS + "'" + vbCr  '当前文件
                    strSQL = strSQL + " and   交接标识 like '1%' " + vbCr           '非初始交接
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    '更新初始交接信息
                    strSQL = ""
                    strSQL = strSQL + " update 公文_B_交接 set" + vbCr
                    strSQL = strSQL + "   完成日期 = NULL," + vbCr
                    strSQL = strSQL + "   办理状态 = '" + Me.FlowData.TASKSTATUS_ZJB + "'" + vbCr
                    strSQL = strSQL + " where 文件标识 = '" + strWJBS + "'" + vbCr  '当前文件
                    strSQL = strSQL + " and   交接标识 like '0%'" + vbCr            '初始交接
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    '更新拟稿日期
                    strSQL = ""
                    strSQL = strSQL + " update 考勤_B_休假申请单 set" + vbCr
                    strSQL = strSQL + "   经办日期 = '" + Format(Now, "yyyy-MM-dd HH:mm:ss") + "'," + vbCr
                    strSQL = strSQL + "   签发人 = ' '," + vbCr
                    strSQL = strSQL + "   签发日期 = NULL," + vbCr
                    strSQL = strSQL + "   办理状态 = '" + Me.FlowData.FILESTATUS_ZJB + "'" + vbCr
                    strSQL = strSQL + " where 文件标识 = '" + strWJBS + "'" + vbCr
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                Catch ex As Exception
                    objSqlTransaction.Rollback()
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '提交事务
                objSqlTransaction.Commit()

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCustomer.SafeRelease(objdacCustomer)

            doIQiyongFile = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCustomer.SafeRelease(objdacCustomer)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 处理“文件办结”业务
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserXM            ：用户名称
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        ' 更改记录
        '     曾祥林 2008-04-01 
        '       (1) 写入“显示序号”的内容
        '     zengxianglin 2009-05-15 更改
        '----------------------------------------------------------------
        Public Overrides Function doCompleteFile( _
            ByRef strErrMsg As String, _
            ByVal strUserXM As String) As Boolean

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand
            Dim strSQL As String

            Dim objdacCustomer As New Josco.JsKernal.DataAccess.dacCustomer

            doCompleteFile = False
            strErrMsg = ""

            Try
                '检查
                If Me.IsInitialized = False Then
                    strErrMsg = "错误：[doCompleteFile]对象还没有初始化，不能使用！"
                    GoTo errProc
                End If
                If Me.IsFillData = False Then
                    strErrMsg = "错误：[doCompleteFile]对象还没有填充数据，不能使用！"
                    GoTo errProc
                End If
                If strUserXM Is Nothing Then strUserXM = ""
                strUserXM = strUserXM.Trim

                '获取文件信息
                Dim strTaskStatusYWCList As String = Me.FlowData.TaskStatusYWCList
                Dim strWJBS As String = Me.WJBS
                If strWJBS = "" Then
                    Exit Try
                End If

                '获取事务连接
                objSqlConnection = Me.SqlConnection

                '获取人员代码
                Dim strUserId As String
                If objdacCustomer.getRydmByRymc(strErrMsg, objSqlConnection, strUserXM, strUserId) = False Then
                    GoTo errProc
                End If
                If strUserId <> "" Then
                    '解除自己的文件封锁
                    If Me.doLockFile(strErrMsg, strUserId, False) = False Then
                        GoTo errProc
                    End If
                End If

                '检查是否有人在编辑本文件！
                Dim blnLocked As Boolean
                Dim strBMMC As String
                Dim strRYMC As String
                If Me.getFileLocked(strErrMsg, blnLocked, strBMMC, strRYMC) = False Then
                    GoTo errProc
                End If
                If blnLocked = True Then
                    strErrMsg = "错误：[" + strBMMC + "]的[" + strRYMC + "]正在修改本文件[" + strWJBS + "]，请稍后再进行处理！"
                    GoTo errProc
                End If

                ''检查批件电子件和批件扫描件
                'Dim objBaseFlowKqglQJD As Josco.JSOA.Common.Workflow.BaseFlowKqglQJD
                'objBaseFlowKqglQJD = CType(Me.FlowData, Josco.JSOA.Common.Workflow.BaseFlowKqglQJD)
                'If objBaseFlowKqglQJD.QFR <> "" Then      '已签发！
                '    If objBaseFlowKqglQJD.HJWJ = "" Then  '批件电子件
                '        strErrMsg = "错误：签批文件电子件没有导入，您不能办结！"
                '        GoTo errProc
                '    End If
                '    If objBaseFlowKqglQJD.PJYJ = "" Then  '批件扫描件
                '        strErrMsg = "错误：签批文件扫描件没有导入，您不能办结！"
                '        GoTo errProc
                '    End If
                'End If

                '创建SqlCommand
                objSqlCommand = New System.Data.SqlClient.SqlCommand
                objSqlCommand.Connection = objSqlConnection
                objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                '开始事务
                objSqlTransaction = objSqlConnection.BeginTransaction
                objSqlCommand.Transaction = objSqlTransaction

                '事务处理
                Try
                    '设置自己的全部事宜办理完毕
                    strSQL = ""
                    strSQL = strSQL + " update 公文_B_交接 set " + vbCr
                    strSQL = strSQL + "   办理状态 = '" + Me.FlowData.TASKSTATUS_YWC + "'," + vbCr
                    strSQL = strSQL + "   完成日期 = '" + Format(Now, "yyyy-MM-dd HH:mm:ss") + "'" + vbCr
                    strSQL = strSQL + " where 文件标识 = '" + strWJBS + "'" + vbCr                      '当前文件
                    strSQL = strSQL + " and   接收人   = '" + strUserXM + "'" + vbCr                    '接收人
                    strSQL = strSQL + " and   办理状态 not in (" + strTaskStatusYWCList + ")" + vbCr    '未办完
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    'zengxianglin 2009-05-15
                    '[考勤_B_休假申请单_假期][拟分配部门]写入[地产_B_人事_个人履历][拟用部门]
                    strSQL = ""
                    strSQL = strSQL + " update 地产_B_人事_个人履历 set" + vbCr
                    strSQL = strSQL + "   拟用部门 = b.组织代码" + vbCr
                    strSQL = strSQL + " from 地产_B_人事_个人履历 a" + vbCr
                    strSQL = strSQL + " left join" + vbCr
                    strSQL = strSQL + " (" + vbCr
                    strSQL = strSQL + "   select a.*,b.组织代码" + vbCr
                    strSQL = strSQL + "   from" + vbCr
                    strSQL = strSQL + "   (" + vbCr
                    strSQL = strSQL + "     select *" + vbCr
                    strSQL = strSQL + "     from 考勤_B_休假申请单_假期" + vbCr
                    strSQL = strSQL + "     where 文件标识 = @wjbs" + vbCr
                    strSQL = strSQL + "     and   拟分配部门 <> ''" + vbCr
                    strSQL = strSQL + "   ) a" + vbCr
                    strSQL = strSQL + "   left join 公共_B_组织机构 b on a.拟分配部门=b.组织名称" + vbCr
                    strSQL = strSQL + "   where b.组织名称 is not null" + vbCr
                    strSQL = strSQL + " ) b on a.简历编号=b.简历编号" + vbCr
                    strSQL = strSQL + " where b.简历编号 is not null" + vbCr
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@wjbs", strWJBS)
                    objSqlCommand.ExecuteNonQuery()
                    'zengxianglin 2009-05-15

                    '写文件完成标识
                    strSQL = ""
                    strSQL = strSQL + " update 考勤_B_休假申请单 set " + vbCr
                    strSQL = strSQL + "   办理状态 = '" + Me.FlowData.FILESTATUS_YWC + "'" + vbCr
                    strSQL = strSQL + " where 文件标识 = '" + strWJBS + "'" + vbCr
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()
                Catch ex As Exception
                    objSqlTransaction.Rollback()
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '提交事务
                objSqlTransaction.Commit()

                '曾祥林 2008-04-01
                '写入“显示序号”内容
                If Me.doWriteXSXH(strErrMsg) = False Then
                    '允许不成功
                    '忽略错误！
                End If
                '曾祥林 2008-04-01
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCustomer.SafeRelease(objdacCustomer)

            doCompleteFile = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCustomer.SafeRelease(objdacCustomer)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取“痕迹文件”字段值
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strPJYJ              ：(返回)批件原件字段值
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Overrides Function getPJYJ( _
            ByRef strErrMsg As String, _
            ByRef strPJYJ As String) As Boolean

            getPJYJ = False
            strErrMsg = ""
            strPJYJ = ""

            Try
                '检查
                If Me.IsInitialized = False Then
                    strErrMsg = "错误：[getPJYJ]对象还没有初始化，不能使用！"
                    GoTo errProc
                End If
                If Me.IsFillData = False Then
                    strErrMsg = "错误：[getPJYJ]对象还没有填充数据，不能使用！"
                    GoTo errProc
                End If

                '返回
                Dim objBaseFlowKqglQJD As Josco.JSOA.Common.Workflow.BaseFlowKqglQJD
                objBaseFlowKqglQJD = CType(Me.FlowData, Josco.JSOA.Common.Workflow.BaseFlowKqglQJD)
                strPJYJ = objBaseFlowKqglQJD.HJWJ

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            getPJYJ = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 处理“导入签批电子件”业务
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strFileSpec          ：要导入的文件路径(WEB服务器本地完全路径)
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Overrides Function doImportQP( _
            ByRef strErrMsg As String, _
            ByVal strFileSpec As String) As Boolean

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand
            Dim strSQL As String

            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objdacCustomer As New Josco.JsKernal.DataAccess.dacCustomer

            Dim objdacXitongpeizhi As New Josco.JsKernal.DataAccess.dacXitongpeizhi
            Dim objFTPProperty As Josco.JsKernal.Common.Utilities.FTPProperty
            Dim objBaseFTP As New Josco.JsKernal.Common.Utilities.BaseFTP

            Dim strBakExt As String = Josco.JsKernal.Common.Utilities.PulicParameters.BACKUPFILEEXT
            Dim strFromUrl As String = ""
            Dim strToUrl As String = ""
            Dim strHJWJ As String = ""

            doImportQP = False
            strErrMsg = ""

            Try
                '检查
                If Me.IsInitialized = False Then
                    strErrMsg = "错误：[doImportQP]对象还没有初始化，不能使用！"
                    GoTo errProc
                End If
                If Me.IsFillData = False Then
                    strErrMsg = "错误：[doImportQP]对象还没有填充数据，不能使用！"
                    GoTo errProc
                End If
                If strFileSpec Is Nothing Then strFileSpec = ""
                strFileSpec = strFileSpec.Trim
                If strFileSpec = "" Then
                    strErrMsg = "错误：[doImportQP]未指定要导入的文件！"
                    GoTo errProc
                End If

                '获取文件信息
                Dim strWJBS As String = Me.WJBS
                If strWJBS = "" Then
                    Exit Try
                End If

                '获取事务连接
                objSqlConnection = Me.SqlConnection

                '获取FTP参数
                If objdacXitongpeizhi.getFtpServerParam(strErrMsg, objSqlConnection, objFTPProperty) = False Then
                    GoTo errProc
                End If

                '获取人员代码
                Dim strUserId As String
                If objdacCustomer.getRydmByRymc(strErrMsg, objSqlConnection, strFileSpec, strUserId) = False Then
                    GoTo errProc
                End If
                If strUserId <> "" Then
                    '解除自己的文件封锁
                    If Me.doLockFile(strErrMsg, strUserId, False) = False Then
                        GoTo errProc
                    End If
                End If

                '检查是否有人在编辑本文件！
                Dim blnLocked As Boolean
                Dim strBMMC As String
                Dim strRYMC As String
                If Me.getFileLocked(strErrMsg, blnLocked, strBMMC, strRYMC) = False Then
                    GoTo errProc
                End If
                If blnLocked = True Then
                    strErrMsg = "错误：[" + strBMMC + "]的[" + strRYMC + "]正在修改本文件[" + strWJBS + "]，请稍后再进行处理！"
                    GoTo errProc
                End If

                '获取文件数据对象
                Dim objBaseFlowKqglQJD As Josco.JSOA.Common.Workflow.BaseFlowKqglQJD
                objBaseFlowKqglQJD = CType(Me.FlowData, Josco.JSOA.Common.Workflow.BaseFlowKqglQJD)
                strHJWJ = objBaseFlowKqglQJD.HJWJ
                '计算上传文件
                Dim strFileType As String
                strFileType = objBaseLocalFile.getExtension(strFileSpec)
                Dim strDesSpec As String
                If strFileType <> "" Then
                    strDesSpec = objBaseFlowKqglQJD.FILEDIR_PJ + "\" + Year(Now).ToString + "\" + strWJBS + strFileType
                Else
                    strDesSpec = objBaseFlowKqglQJD.FILEDIR_PJ + "\" + Year(Now).ToString + "\" + strWJBS
                End If
                '备份文件
                If strHJWJ <> "" Then
                    With objFTPProperty
                        strFromUrl = .getUrl(strHJWJ)
                        strToUrl = .getUrl(strHJWJ + strBakExt)
                        If objBaseFTP.doRenameFile(strErrMsg, strFromUrl, strToUrl, .UserID, .Password, .ProxyUrl, .ProxyUserID, .ProxyPassword) = False Then
                            GoTo errProc
                        End If
                    End With
                End If
                '上传文件
                Dim strUrl As String = ""
                With objFTPProperty
                    strUrl = .getUrl(strDesSpec)
                    If objBaseFTP.doPutFile(strErrMsg, strFileSpec, strUrl, .UserID, .Password, .ProxyUrl, .ProxyUserID, .ProxyPassword) = False Then
                        GoTo rollWJ
                    End If
                End With

                '创建SqlCommand
                objSqlCommand = New System.Data.SqlClient.SqlCommand
                objSqlCommand.Connection = objSqlConnection
                objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                '开始事务
                objSqlTransaction = objSqlConnection.BeginTransaction
                objSqlCommand.Transaction = objSqlTransaction

                '事务处理
                Try
                    '写数据
                    strSQL = ""
                    strSQL = strSQL + " update 考勤_B_休假申请单 set " + vbCr
                    strSQL = strSQL + "   痕迹文件 = '" + strDesSpec + "'" + vbCr
                    strSQL = strSQL + " where 文件标识 = '" + strWJBS + "'" + vbCr
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    '清除临时文件
                    If strHJWJ <> "" Then
                        With objFTPProperty
                            If objBaseFTP.doDeleteFile(strErrMsg, strToUrl, .UserID, .Password, .ProxyUrl, .ProxyUserID, .ProxyPassword) = False Then
                                '可以不成功,形成垃圾文件
                            End If
                        End With
                    End If

                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo rollDatabaseAndWJ
                End Try

                '提交事务
                objSqlTransaction.Commit()

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacXitongpeizhi.SafeRelease(objdacXitongpeizhi)
            Josco.JsKernal.Common.Utilities.FTPProperty.SafeRelease(objFTPProperty)
            Josco.JsKernal.DataAccess.dacCustomer.SafeRelease(objdacCustomer)
            Josco.JsKernal.Common.Utilities.BaseFTP.SafeRelease(objBaseFTP)

            doImportQP = True
            Exit Function

rollWJ:
            '尽量复原文件
            Dim strTempMsgA As String = ""
            If strHJWJ <> "" Then
                With objFTPProperty
                    If objBaseFTP.doRenameFile(strTempMsgA, strToUrl, strFromUrl, .UserID, .Password, .ProxyUrl, .ProxyUserID, .ProxyPassword) = False Then
                        '已经尽力了！
                    End If
                End With
            End If
            GoTo errProc

rollDatabaseAndWJ:
            '尽量复原文件
            Dim strTempMsgB As String = ""
            If strHJWJ <> "" Then
                With objFTPProperty
                    If objBaseFTP.doRenameFile(strTempMsgB, strToUrl, strFromUrl, .UserID, .Password, .ProxyUrl, .ProxyUserID, .ProxyPassword) = False Then
                        '已经尽力了！
                    End If
                End With
            End If
            GoTo rollDataBase

rollDataBase:
            objSqlTransaction.Rollback()
            GoTo errProc

errProc:
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacXitongpeizhi.SafeRelease(objdacXitongpeizhi)
            Josco.JsKernal.Common.Utilities.FTPProperty.SafeRelease(objFTPProperty)
            Josco.JsKernal.DataAccess.dacCustomer.SafeRelease(objdacCustomer)
            Josco.JsKernal.Common.Utilities.BaseFTP.SafeRelease(objBaseFTP)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取“批件原件”字段值
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strZSWJ              ：(返回)正式文件字段值
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Overrides Function getZSWJ( _
            ByRef strErrMsg As String, _
            ByRef strZSWJ As String) As Boolean

            getZSWJ = False
            strErrMsg = ""
            strZSWJ = ""

            Try
                '检查
                If Me.IsInitialized = False Then
                    strErrMsg = "错误：[getZSWJ]对象还没有初始化，不能使用！"
                    GoTo errProc
                End If
                If Me.IsFillData = False Then
                    strErrMsg = "错误：[getZSWJ]对象还没有填充数据，不能使用！"
                    GoTo errProc
                End If

                '返回
                Dim objBaseFlowKqglQJD As Josco.JSOA.Common.Workflow.BaseFlowKqglQJD
                objBaseFlowKqglQJD = CType(Me.FlowData, Josco.JSOA.Common.Workflow.BaseFlowKqglQJD)
                strZSWJ = objBaseFlowKqglQJD.PJYJ

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            getZSWJ = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 处理“导入签批扫描件”业务
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strFileSpec          ：要导入的文件路径(WEB服务器本地完全路径)
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Overrides Function doImportZS( _
            ByRef strErrMsg As String, _
            ByVal strFileSpec As String) As Boolean

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand
            Dim strSQL As String

            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objdacCustomer As New Josco.JsKernal.DataAccess.dacCustomer

            Dim objdacXitongpeizhi As New Josco.JsKernal.DataAccess.dacXitongpeizhi
            Dim objFTPProperty As Josco.JsKernal.Common.Utilities.FTPProperty
            Dim objBaseFTP As New Josco.JsKernal.Common.Utilities.BaseFTP

            Dim strBakExt As String = Josco.JsKernal.Common.Utilities.PulicParameters.BACKUPFILEEXT
            Dim strFromUrl As String = ""
            Dim strToUrl As String = ""
            Dim strPJYJ As String = ""

            doImportZS = False
            strErrMsg = ""

            Try
                '检查
                If Me.IsInitialized = False Then
                    strErrMsg = "错误：[doImportZS]对象还没有初始化，不能使用！"
                    GoTo errProc
                End If
                If Me.IsFillData = False Then
                    strErrMsg = "错误：[doImportZS]对象还没有填充数据，不能使用！"
                    GoTo errProc
                End If
                If strFileSpec Is Nothing Then strFileSpec = ""
                strFileSpec = strFileSpec.Trim
                If strFileSpec = "" Then
                    strErrMsg = "错误：[doImportZS]未指定要导入的文件！"
                    GoTo errProc
                End If

                '获取文件信息
                Dim strWJBS As String = Me.WJBS
                If strWJBS = "" Then
                    Exit Try
                End If

                '获取事务连接
                objSqlConnection = Me.SqlConnection

                '获取FTP参数
                If objdacXitongpeizhi.getFtpServerParam(strErrMsg, objSqlConnection, objFTPProperty) = False Then
                    GoTo errProc
                End If

                '获取人员代码
                Dim strUserId As String
                If objdacCustomer.getRydmByRymc(strErrMsg, objSqlConnection, strFileSpec, strUserId) = False Then
                    GoTo errProc
                End If
                If strUserId <> "" Then
                    '解除自己的文件封锁
                    If Me.doLockFile(strErrMsg, strUserId, False) = False Then
                        GoTo errProc
                    End If
                End If

                '检查是否有人在编辑本文件！
                Dim blnLocked As Boolean
                Dim strBMMC As String
                Dim strRYMC As String
                If Me.getFileLocked(strErrMsg, blnLocked, strBMMC, strRYMC) = False Then
                    GoTo errProc
                End If
                If blnLocked = True Then
                    strErrMsg = "错误：[" + strBMMC + "]的[" + strRYMC + "]正在修改本文件[" + strWJBS + "]，请稍后再进行处理！"
                    GoTo errProc
                End If

                '获取文件数据对象
                Dim objBaseFlowKqglQJD As Josco.JSOA.Common.Workflow.BaseFlowKqglQJD
                objBaseFlowKqglQJD = CType(Me.FlowData, Josco.JSOA.Common.Workflow.BaseFlowKqglQJD)
                strPJYJ = objBaseFlowKqglQJD.PJYJ
                '计算上传文件
                Dim strFileType As String
                strFileType = objBaseLocalFile.getExtension(strFileSpec)
                Dim strDesSpec As String
                If strFileType <> "" Then
                    strDesSpec = objBaseFlowKqglQJD.FILEDIR_RO + "\" + Year(Now).ToString + "\" + strWJBS + strFileType
                Else
                    strDesSpec = objBaseFlowKqglQJD.FILEDIR_RO + "\" + Year(Now).ToString + "\" + strWJBS
                End If
                '备份文件
                If strPJYJ <> "" Then
                    With objFTPProperty
                        strFromUrl = .getUrl(strPJYJ)
                        strToUrl = .getUrl(strPJYJ + strBakExt)
                        If objBaseFTP.doRenameFile(strErrMsg, strFromUrl, strToUrl, .UserID, .Password, .ProxyUrl, .ProxyUserID, .ProxyPassword) = False Then
                            GoTo errProc
                        End If
                    End With
                End If
                '上传文件
                Dim strUrl As String = ""
                With objFTPProperty
                    strUrl = .getUrl(strDesSpec)
                    If objBaseFTP.doPutFile(strErrMsg, strFileSpec, strUrl, .UserID, .Password, .ProxyUrl, .ProxyUserID, .ProxyPassword) = False Then
                        GoTo rollWJ
                    End If
                End With

                '创建SqlCommand
                objSqlCommand = New System.Data.SqlClient.SqlCommand
                objSqlCommand.Connection = objSqlConnection
                objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                '开始事务
                objSqlTransaction = objSqlConnection.BeginTransaction
                objSqlCommand.Transaction = objSqlTransaction

                '事务处理
                Try
                    '写数据
                    strSQL = ""
                    strSQL = strSQL + " update 考勤_B_休假申请单 set " + vbCr
                    strSQL = strSQL + "   批件原件 = '" + strDesSpec + "'" + vbCr
                    strSQL = strSQL + " where 文件标识 = '" + strWJBS + "'" + vbCr
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    '清除临时文件
                    If strPJYJ <> "" Then
                        With objFTPProperty
                            If objBaseFTP.doDeleteFile(strErrMsg, strToUrl, .UserID, .Password, .ProxyUrl, .ProxyUserID, .ProxyPassword) = False Then
                                '可以不成功,形成垃圾文件
                            End If
                        End With
                    End If

                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo rollDatabaseAndWJ
                End Try

                '提交事务
                objSqlTransaction.Commit()

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacXitongpeizhi.SafeRelease(objdacXitongpeizhi)
            Josco.JsKernal.Common.Utilities.FTPProperty.SafeRelease(objFTPProperty)
            Josco.JsKernal.DataAccess.dacCustomer.SafeRelease(objdacCustomer)
            Josco.JsKernal.Common.Utilities.BaseFTP.SafeRelease(objBaseFTP)

            doImportZS = True
            Exit Function

rollWJ:
            '尽量复原文件
            Dim strTempMsgA As String = ""
            If strPJYJ <> "" Then
                With objFTPProperty
                    If objBaseFTP.doRenameFile(strTempMsgA, strToUrl, strFromUrl, .UserID, .Password, .ProxyUrl, .ProxyUserID, .ProxyPassword) = False Then
                        '已经尽力了！
                    End If
                End With
            End If
            GoTo errProc

rollDatabaseAndWJ:
            '尽量复原文件
            Dim strTempMsgB As String = ""
            If strPJYJ <> "" Then
                With objFTPProperty
                    If objBaseFTP.doRenameFile(strTempMsgB, strToUrl, strFromUrl, .UserID, .Password, .ProxyUrl, .ProxyUserID, .ProxyPassword) = False Then
                        '已经尽力了！
                    End If
                End With
            End If
            GoTo rollDataBase

rollDataBase:
            objSqlTransaction.Rollback()
            GoTo errProc

errProc:
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacXitongpeizhi.SafeRelease(objdacXitongpeizhi)
            Josco.JsKernal.Common.Utilities.FTPProperty.SafeRelease(objFTPProperty)
            Josco.JsKernal.DataAccess.dacCustomer.SafeRelease(objdacCustomer)
            Josco.JsKernal.Common.Utilities.BaseFTP.SafeRelease(objBaseFTP)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取工作流能进行的签批意见列表
        '     strErrMsg            ：如果错误，则返回错误信息
        '     objYjlx              ：签批意见类型+显示名称集合
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Overrides Function getAllYjlx( _
            ByRef strErrMsg As String, _
            ByRef objYjlx As System.Collections.Specialized.NameValueCollection) As Boolean

            getAllYjlx = False
            strErrMsg = ""
            objYjlx = Nothing

            Try
                '获取工作流明细对象
                Dim objBaseFlowKqglQJD As Josco.JSOA.Common.Workflow.BaseFlowKqglQJD
                objBaseFlowKqglQJD = CType(Me.FlowData, Josco.JSOA.Common.Workflow.BaseFlowKqglQJD)

                '对象初始化
                objYjlx = New System.Collections.Specialized.NameValueCollection

                objYjlx.Add(objBaseFlowKqglQJD.TASK_ZJL, "总经理审批")
                objYjlx.Add(objBaseFlowKqglQJD.TASK_FGLD, "分管领导意见")
                objYjlx.Add(objBaseFlowKqglQJD.TASK_HQWJ, "办公室意见")
                objYjlx.Add(objBaseFlowKqglQJD.TASK_SHWJ, "部门经理意见")
                objYjlx.Add(objBaseFlowKqglQJD.TASK_QFWJ, "项目经理/区域经理/总监意见")
                objYjlx.Add(objBaseFlowKqglQJD.TASK_FHWJ, "售楼部/分行经理意见")

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            getAllYjlx = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 取消签名
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strYjlx              ：要取消的意见类型
        '     strSPR               ：审批人
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Overrides Function doQianminCancel( _
            ByRef strErrMsg As String, _
            ByVal strYjlx As String, _
            ByVal strSPR As String) As Boolean

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand

            Dim strWJBS As String
            Dim strSQL As String

            '初始化
            doQianminCancel = False
            strErrMsg = ""

            Try
                '检查
                If Me.IsInitialized = False Then
                    strErrMsg = "错误：[doQianminCancel]对象还没有初始化，不能使用！"
                    GoTo errProc
                End If
                If Me.IsFillData = False Then
                    strErrMsg = "错误：[doQianminCancel]对象还没有填充数据，不能使用！"
                    GoTo errProc
                End If
                If strYjlx Is Nothing Then strYjlx = ""
                strYjlx = strYjlx.Trim
                If strYjlx = "" Then
                    Exit Try
                End If
                If strSPR Is Nothing Then strSPR = ""
                strSPR = strSPR.Trim
                If strSPR = "" Then
                    Exit Try
                End If

                '获取现有信息
                objSqlConnection = Me.SqlConnection
                strWJBS = Me.FlowData.WJBS
                If strWJBS = "" Then
                    Exit Try
                End If

                '检查编辑封锁
                Dim blnLocked As Boolean
                Dim strBmmc As String
                Dim strRymc As String
                If Me.getFileLocked(strErrMsg, blnLocked, strBmmc, strRymc) = False Then
                    GoTo errProc
                End If

                '保存数据
                Dim objBaseFlowKqglQJD As Josco.JSOA.Common.Workflow.BaseFlowKqglQJD
                objBaseFlowKqglQJD = CType(Me.FlowData, Josco.JSOA.Common.Workflow.BaseFlowKqglQJD)

                '计算取消签名的SQL
                strSQL = ""
                Select Case strYjlx
                    Case Josco.JSOA.Common.Workflow.BaseFlowKqglQJD.TASK_QFWJ
                        Dim strQFR As String = objBaseFlowKqglQJD.QFR
                        Dim strTmp As String = strSPR

                        '取消签名
                        If strQFR <> "" Then
                            strQFR += Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate
                            strTmp += Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate

                            strQFR = strQFR.Replace(strTmp, "")
                            If strQFR.Length > 0 Then
                                strQFR = strQFR.Substring(0, strQFR.Length - 1)
                            End If

                            '更新
                            strSQL = ""
                            strSQL = strSQL + " update 考勤_B_休假申请单 set" + vbCr
                            strSQL = strSQL + "   签发人 = '" + strQFR + "'" + vbCr
                            If strQFR = "" Then
                                strSQL = strSQL + ",办理状态 = '" + Me.FlowData.FILESTATUS_ZJB + "'" + vbCr
                                strSQL = strSQL + ",签发日期 = NULL " + vbCr
                            End If
                            strSQL = strSQL + " where 文件标识 = '" + strWJBS + "'" + vbCr
                        End If

                    Case Else
                End Select

                If strSQL <> "" Then
                    If blnLocked = True Then
                        strErrMsg = "错误：[" + strBmmc + "]单位的[" + strRymc + "]人正在编辑本文件，请稍后再处理！"
                        GoTo errProc
                    End If

                    '开始事务
                    objSqlTransaction = objSqlConnection.BeginTransaction()
                    Try
                        objSqlCommand = objSqlConnection.CreateCommand()
                        objSqlCommand.Connection = objSqlConnection
                        objSqlCommand.Transaction = objSqlTransaction
                        objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                        objSqlCommand.Parameters.Clear()
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.ExecuteNonQuery()
                    Catch ex As Exception
                        GoTo rollDatabase
                    End Try
                    '提交事务
                    objSqlTransaction.Commit()
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)

            '返回
            doQianminCancel = True
            Exit Function

rollDatabase:
            objSqlTransaction.Rollback()
            GoTo errProc

errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 签名确认
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strYjlx              ：要确认的意见类型
        '     strSPR               ：审批人
        '     intMode              ：签批模式：0-单独签，1-共同签
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Overrides Function doQianminQueren( _
            ByRef strErrMsg As String, _
            ByVal strYjlx As String, _
            ByVal strSPR As String, _
            ByVal intMode As Integer) As Boolean

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand

            Dim objdacCustomer As New Josco.JsKernal.DataAccess.dacCustomer

            Dim strWJBS As String
            Dim strSQL As String

            '初始化
            doQianminQueren = False
            strErrMsg = ""

            Try
                '检查
                If Me.IsInitialized = False Then
                    strErrMsg = "错误：[doQianminQueren]对象还没有初始化，不能使用！"
                    GoTo errProc
                End If
                If Me.IsFillData = False Then
                    strErrMsg = "错误：[doQianminQueren]对象还没有填充数据，不能使用！"
                    GoTo errProc
                End If
                If strYjlx Is Nothing Then strYjlx = ""
                strYjlx = strYjlx.Trim
                If strYjlx = "" Then
                    Exit Try
                End If
                If strSPR Is Nothing Then strSPR = ""
                strSPR = strSPR.Trim
                If strSPR = "" Then
                    Exit Try
                End If

                '获取现有信息
                objSqlConnection = Me.SqlConnection
                strWJBS = Me.FlowData.WJBS
                If strWJBS = "" Then
                    Exit Try
                End If

                '检查编辑封锁
                Dim blnLocked As Boolean
                Dim strBmmc As String
                Dim strRymc As String
                If Me.getFileLocked(strErrMsg, blnLocked, strBmmc, strRymc) = False Then
                    GoTo errProc
                End If

                '保存数据
                Dim strSep As String = Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate
                Dim objBaseFlowKqglQJD As Josco.JSOA.Common.Workflow.BaseFlowKqglQJD
                objBaseFlowKqglQJD = CType(Me.FlowData, Josco.JSOA.Common.Workflow.BaseFlowKqglQJD)

                '计算签名SQL
                strSQL = ""
                Select Case strYjlx
                    Case Josco.JSOA.Common.Workflow.BaseFlowKqglQJD.TASK_QFWJ
                        Dim strQFR As String = objBaseFlowKqglQJD.QFR
                        Dim strTmp As String = strSPR
                        Dim strNewQFR As String = ""

                        '确认签名
                        If strQFR <> "" Then
                            strQFR += strSep
                            strTmp += strSep

                            If strQFR.IndexOf(strTmp) >= 0 Then
                                '已签名
                            Else
                                '没有签名
                                strQFR += strTmp
                            End If
                            strQFR = strQFR.Substring(0, strQFR.Length - 1)
                        Else
                            strQFR = strSPR
                        End If

                        '排序
                        If objdacCustomer.doSortRenyuanList(strErrMsg, objSqlConnection, strQFR, strSep, strNewQFR) = False Then
                            GoTo errProc
                        End If
                        strQFR = strNewQFR

                        intMode = 2
                        '更新
                        Select Case intMode
                            Case 0 '单独
                                strSQL = ""
                                strSQL = strSQL + " update 考勤_B_休假申请单 set" + vbCr
                                strSQL = strSQL + "   办理状态 = '" + Me.FlowData.FILESTATUS_YQP + "'," + vbCr
                                strSQL = strSQL + "   签发人   = '" + strSPR + "'," + vbCr
                                strSQL = strSQL + "   签发日期 = '" + Format(Now, "yyyy-MM-dd HH:mm:ss") + "'" + vbCr
                                strSQL = strSQL + " where 文件标识 = '" + strWJBS + "'" + vbCr

                            Case 1 '共同
                                strSQL = ""
                                strSQL = strSQL + " update 考勤_B_休假申请单 set" + vbCr
                                strSQL = strSQL + "   办理状态 = '" + Me.FlowData.FILESTATUS_YQP + "'," + vbCr
                                strSQL = strSQL + "   签发人   = '" + strQFR + "'," + vbCr
                                strSQL = strSQL + "   签发日期 = '" + Format(Now, "yyyy-MM-dd HH:mm:ss") + "'" + vbCr
                                strSQL = strSQL + " where 文件标识 = '" + strWJBS + "'" + vbCr

                            Case Else
                                '不签名
                        End Select

                    Case Else
                End Select

                If strSQL <> "" Then
                    If blnLocked = True Then
                        strErrMsg = "错误：[" + strBmmc + "]单位的[" + strRymc + "]人正在编辑本文件，请稍后再处理！"
                        GoTo errProc
                    End If

                    '开始事务
                    objSqlTransaction = objSqlConnection.BeginTransaction()
                    Try
                        objSqlCommand = objSqlConnection.CreateCommand()
                        objSqlCommand.Connection = objSqlConnection
                        objSqlCommand.Transaction = objSqlTransaction
                        objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                        objSqlCommand.Parameters.Clear()
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.ExecuteNonQuery()
                    Catch ex As Exception
                        GoTo rollDatabase
                    End Try
                    '提交事务
                    objSqlTransaction.Commit()
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCustomer.SafeRelease(objdacCustomer)

            '返回
            doQianminQueren = True
            Exit Function

rollDatabase:
            objSqlTransaction.Rollback()
            GoTo errProc

errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCustomer.SafeRelease(objdacCustomer)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 翻译“是否批准”标志
        ' 返回
        '                          ：翻译后的字符串
        '----------------------------------------------------------------
        Public Overrides Function doTranslateSFPZ(ByVal strSFPZ As String) As String

            doTranslateSFPZ = ""

            Try
                If strSFPZ Is Nothing Then
                    Exit Try
                End If
                strSFPZ = strSFPZ.Trim

                Select Case strSFPZ
                    Case "1000"
                        doTranslateSFPZ = "不同意"
                    Case "1100"
                        doTranslateSFPZ = "同意"
                    Case "1110"
                        doTranslateSFPZ = "一般意见"
                    Case Else
                End Select

            Catch ex As Exception
                doTranslateSFPZ = ""
            End Try

        End Function

        '----------------------------------------------------------------
        ' 需要签名确认提示?
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strYjlx              ：要确认的意见类型
        '     strSPR               ：审批人
        '     blnNeed              ：(返回)是否需要提示
        '     strXyrList           ：(返回)已有签名人列表
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Overrides Function isNeedQianminQuerenPrompt( _
            ByRef strErrMsg As String, _
            ByVal strYjlx As String, _
            ByVal strSPR As String, _
            ByRef blnNeed As Boolean, _
            ByRef strXyrList As String) As Boolean

            isNeedQianminQuerenPrompt = False
            strErrMsg = ""
            blnNeed = False
            strXyrList = ""

            Try
                '检查
                If Me.IsInitialized = False Then
                    Exit Try
                End If
                If Me.IsFillData = False Then
                    Exit Try
                End If
                If strYjlx Is Nothing Then strYjlx = ""
                strYjlx = strYjlx.Trim
                If strYjlx = "" Then
                    Exit Try
                End If
                If strSPR Is Nothing Then strSPR = ""
                strSPR = strSPR.Trim
                If strSPR = "" Then
                    Exit Try
                End If

                '判断
                Dim strSep As String = Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate
                Dim objBaseFlowKqglQJD As Josco.JSOA.Common.Workflow.BaseFlowKqglQJD
                objBaseFlowKqglQJD = CType(Me.FlowData, Josco.JSOA.Common.Workflow.BaseFlowKqglQJD)
                Select Case strYjlx
                    Case Josco.JSOA.Common.Workflow.BaseFlowKqglQJD.TASK_LDCL
                        Dim strQFR As String = objBaseFlowKqglQJD.QFR
                        Dim strTmp As String = strSPR

                        If strQFR <> "" Then
                            strQFR += strSep
                            strTmp += strSep
                            If strQFR.IndexOf(strTmp) >= 0 Then
                                blnNeed = False
                            Else
                                blnNeed = True
                            End If
                        Else
                            blnNeed = True
                        End If
                        strXyrList = objBaseFlowKqglQJD.QFR

                End Select

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            isNeedQianminQuerenPrompt = True
            Exit Function
errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 是需要签名确认的审批事宜?
        '     strYjlx              ：审批事宜
        ' 返回
        '     True                 ：需要签名
        '     False                ：不需要签名
        '----------------------------------------------------------------
        Public Overrides Function isQianminTask(ByVal strYjlx As String) As Boolean

            Try
                Select Case strYjlx
                    Case Josco.JSOA.Common.Workflow.BaseFlowKqglQJD.TASK_QFWJ
                        isQianminTask = True

                    Case Else
                        isQianminTask = False
                End Select
            Catch ex As Exception
                isQianminTask = False
            End Try

        End Function

        '----------------------------------------------------------------
        ' 是对整个文件签名的审批意见?如果是，返回提醒字符串
        '     strYjlx              ：审批事宜
        ' 返回
        '     True                 ：需要签名
        '     False                ：不需要签名
        '----------------------------------------------------------------
        Public Overrides Function isFileQianminTask( _
            ByVal strYjlx As String, _
            ByRef strPrompt As String) As Boolean

            Try
                Select Case strYjlx
                    Case Josco.JSOA.Common.Workflow.BaseFlowKqglQJD.TASK_LDCL
                        strPrompt = "特别提醒：您确认本文件在您的职责范围内就可以[批]了吗（确定/取消）？可以[批]请按[确定]，否则请按[取消]。"
                        isFileQianminTask = True

                    Case Else
                        isFileQianminTask = False
                        strPrompt = ""
                End Select
            Catch ex As Exception
                isFileQianminTask = False
                strPrompt = ""
            End Try

        End Function

        '----------------------------------------------------------------
        ' 获取“批准”办理标志
        ' 返回
        '                          ：办理标志
        '----------------------------------------------------------------
        Public Overrides Function getPizhunBLBZ() As String
            getPizhunBLBZ = "1100"
        End Function

        '----------------------------------------------------------------
        ' 获取“保存意见”办理标志
        ' 返回
        '                          ：办理标志
        '----------------------------------------------------------------
        Public Overrides Function getBaocunYijianBLBZ() As String
            getBaocunYijianBLBZ = "1110"
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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strWJBS As String

            getNewWjxh = False
            strErrMsg = ""
            strWJXH = "0"

            Try
                '检查
                If Me.IsInitialized = False Then
                    strErrMsg = "错误：[getNewWjxh]工作流没有初始化！"
                    GoTo errProc
                End If
                If strJGDZ Is Nothing Then strJGDZ = ""
                strJGDZ = strJGDZ.Trim
                If strJGDZ = "" Then
                    strErrMsg = "错误：[getNewWjxh]没有输入[机关代字]！"
                    GoTo errProc
                End If
                If strWJNF Is Nothing Then strWJNF = ""
                strWJNF = strWJNF.Trim
                If strWJNF = "" Then
                    strErrMsg = "错误：[getNewWjxh]没有输入[文件年份]！"
                    GoTo errProc
                End If

                '获取信息
                objSqlConnection = Me.SqlConnection
                strWJBS = Me.WJBS

                '获取序号
                Dim strSep As String = Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate
                If objdacCommon.getNewCode(strErrMsg, objSqlConnection, "文件序号", "机关代字,文件年份", strJGDZ + strSep + strWJNF, "考勤_B_休假申请单", True, strWJXH) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            getNewWjxh = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取“考勤_B_休假申请单_假期”数据集(以“人员序号”升序排列)
        '     strErrMsg                        ：如果错误，则返回错误信息
        '     objkaoqinguanliData        ：返回数据
        ' 返回
        '     True                             ：成功
        '     False                            ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_JQXX( _
            ByRef strErrMsg As String, _
            ByRef objkaoqinguanliData As Josco.JSOA.Common.Data.kaoqinguanliData) As Boolean

            Dim objTempobjkaoqinguanliData As Josco.JSOA.Common.Data.kaoqinguanliData
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand
            Dim strSQL As String

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getDataSet_JQXX = False
            objkaoqinguanliData = Nothing
            strErrMsg = ""

            Try
                '检查
                If Me.IsInitialized = False Then
                    strErrMsg = "错误：对象还没有初始化，不能使用！"
                    GoTo errProc
                End If

                '获取文件标识
                Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Me.SqlConnection
                Dim strWJBS As String = Me.WJBS

                '创建数据集
                objTempobjkaoqinguanliData = New Josco.JSOA.Common.Data.kaoqinguanliData(Josco.JSOA.Common.Data.kaoqinguanliData.enumTableType.KQ_B_XIUJIASHENQINGDAN_JIAQI)
                If strWJBS = "" Then
                    Exit Try
                End If

                '创建SqlCommand
                objSqlCommand = New System.Data.SqlClient.SqlCommand
                objSqlCommand.Connection = objSqlConnection
                objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                '执行检索
                With Me.SqlDataAdapter
                    '获取
                    strSQL = ""
                    strSQL = strSQL + " select *,convert(varchar(3),天数) + '天' as '显示天数' " + vbCr
                    strSQL = strSQL + " from 考勤_B_休假申请单_假期" + vbCr
                    strSQL = strSQL + " where 文件标识 = @wjbs " + vbCr
                    strSQL = strSQL + " order by 记录代码" + vbCr

                    '设置参数
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@wjbs", strWJBS)
                    .SelectCommand = objSqlCommand

                    '执行操作
                    .Fill(objTempobjkaoqinguanliData.Tables(Josco.JSOA.Common.Data.kaoqinguanliData.TABLE_KQ_B_XIUJIASHENQINGDAN_JIAQI))
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)

            objkaoqinguanliData = objTempobjkaoqinguanliData
            getDataSet_JQXX = True
            Exit Function

errProc:
            Josco.JSOA.Common.Data.kaoqinguanliData.SafeRelease(objTempobjkaoqinguanliData)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取“考勤_B_休假申请单_假期”数据集(以“人员序号”升序排列)
        '     strErrMsg                        ：如果错误，则返回错误信息
        '     objkaoqinguanliData        ：返回数据
        '     blnOption                        ：重载
        ' 返回
        '     True                             ：成功
        '     False                            ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_JQXX( _
            ByRef strErrMsg As String, _
            ByRef objkaoqinguanliData As Josco.JSOA.Common.Data.kaoqinguanliData, _
            ByVal blnOption As Boolean) As Boolean

            Dim objTempobjkaoqinguanliData As Josco.JSOA.Common.Data.kaoqinguanliData
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand
            Dim strSQL As String

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getDataSet_JQXX = False
            objkaoqinguanliData = Nothing
            strErrMsg = ""

            Try
                '检查
                If Me.IsInitialized = False Then
                    strErrMsg = "错误：对象还没有初始化，不能使用！"
                    GoTo errProc
                End If

                '获取文件标识
                Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Me.SqlConnection
                Dim strWJBS As String = Me.WJBS

                '创建数据集
                objTempobjkaoqinguanliData = New Josco.JSOA.Common.Data.kaoqinguanliData(Josco.JSOA.Common.Data.kaoqinguanliData.enumTableType.KQ_B_XIUJIASHENQINGDAN_JIAQI)
                If strWJBS = "" Then
                    Exit Try
                End If

                '创建SqlCommand
                objSqlCommand = New System.Data.SqlClient.SqlCommand
                objSqlCommand.Connection = objSqlConnection
                objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                '执行检索
                With Me.SqlDataAdapter
                    '获取
                    strSQL = ""
                    strSQL = strSQL + " select *,convert(varchar(3),天数) + '天' as '显示天数'  " + vbCr
                    strSQL = strSQL + " from 考勤_B_休假申请单_假期 " + vbCr
                    strSQL = strSQL + " where 文件标识 = @wjbs " + vbCr
                    strSQL = strSQL + " order by 记录代码 " + vbCr

                    '设置参数
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@wjbs", strWJBS)
                    .SelectCommand = objSqlCommand

                    '执行操作
                    .Fill(objTempobjkaoqinguanliData.Tables(Josco.JSOA.Common.Data.kaoqinguanliData.TABLE_KQ_B_XIUJIASHENQINGDAN_JIAQI))
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)

            objkaoqinguanliData = objTempobjkaoqinguanliData
            getDataSet_JQXX = True
            Exit Function

errProc:
            Josco.JSOA.Common.Data.kaoqinguanliData.SafeRelease(objTempobjkaoqinguanliData)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取strUserXM能够查看的“考勤_B_休假申请单”完全数据的数据集(以“经办日期”降序排序)
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserXM                  ：用户名称
        '     strWhere                   ：搜索字符串
        '     objkaoqinguanliData  ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_Main( _
            ByRef strErrMsg As String, _
            ByVal strUserXM As String, _
            ByVal strWhere As String, _
            ByRef objkaoqinguanliData As Josco.JSOA.Common.Data.kaoqinguanliData) As Boolean

            Dim objTempkaoqinguanliData As Josco.JSOA.Common.Data.kaoqinguanliData = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim strSQL As String = ""

            '初始化
            getDataSet_Main = False
            objkaoqinguanliData = Nothing
            strErrMsg = ""

            Try
                '检查
                If Me.IsInitialized = False Then
                    strErrMsg = "错误：对象还没有初始化，不能使用！"
                    GoTo errProc
                End If
                If strUserXM Is Nothing Then strUserXM = ""
                strUserXM = strUserXM.Trim

                '获取连接
                objSqlConnection = Me.SqlConnection

                '获取数据
                Try
                    '创建数据集
                    objTempkaoqinguanliData = New Josco.JSOA.Common.Data.kaoqinguanliData(Josco.JSOA.Common.Data.kaoqinguanliData.enumTableType.KQ_B_XIUJIASHENQINGDAN)

                    '创建SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '执行检索
                    With Me.SqlDataAdapter
                        '准备SQL
                        strSQL = ""
                        strSQL = strSQL + " select a.*" + vbCr
                        strSQL = strSQL + " from" + vbCr
                        strSQL = strSQL + " (" + vbCr
                        strSQL = strSQL + "   select a.*," + vbCr
                        strSQL = strSQL + "     备忘提醒 = dbo.GetFileBWTX(a.文件标识,@userxm)" + vbCr
                        strSQL = strSQL + "   from 考勤_B_休假申请单 a" + vbCr
                        strSQL = strSQL + "   where dbo.Flow_CanReadFile(a.文件标识,@userxm) = 1" + vbCr
                        strSQL = strSQL + " ) a" + vbCr
                        If strWhere <> "" Then
                            strSQL = strSQL + " where " + strWhere + vbCr
                        End If
                        strSQL = strSQL + " order by a.经办日期 desc " + vbCr

                        '设置参数
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        objSqlCommand.Parameters.AddWithValue("@userxm", strUserXM)
                        .SelectCommand = objSqlCommand

                        '执行操作
                        .Fill(objTempkaoqinguanliData.Tables(Josco.JSOA.Common.Data.kaoqinguanliData.TABLE_KQ_B_XIUJIASHENQINGDAN))
                    End With
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
                If objTempkaoqinguanliData.Tables.Count < 1 Then
                    Josco.JSOA.Common.Data.kaoqinguanliData.SafeRelease(objTempkaoqinguanliData)
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)

            '返回
            objkaoqinguanliData = objTempkaoqinguanliData
            getDataSet_Main = True
            Exit Function

errProc:
            Josco.JSOA.Common.Data.kaoqinguanliData.SafeRelease(objTempkaoqinguanliData)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Exit Function

        End Function












        '----------------------------------------------------------------
        ' 将本工作流文件加入到指定的案卷中
        '     strErrMsg            ：返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strAJBS              ：指定案卷标识
        '     strTempPath          ：下载文件临时存放路径
        ' 返回
        '     True                 ：成功
        '     False                ：不成功
        ' 备注
        '     载体                 ：电子
        '     保管期限             ：长期
        '     档案分类             ：文书档案
        '----------------------------------------------------------------
        Public Overrides Function doAddToAnjuan( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strAJBS As String, _
            ByVal strTempPath As String) As Boolean
            strErrMsg = "错误：[doAddToAnjuan]没有实现！"
            doAddToAnjuan = False
        End Function
        '        Public Overrides Function doAddToAnjuan( _
        '            ByRef strErrMsg As String, _
        '            ByVal strUserId As String, _
        '            ByVal strPassword As String, _
        '            ByVal strAJBS As String, _
        '            ByVal strTempPath As String) As Boolean

        '            Dim objAnjuanDataSet As Josco.JSOA.Common.Data.daglDanganData
        '            Dim objFujianDataSet As Josco.JSOA.Common.Data.FlowData

        '            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction
        '            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
        '            Dim objSqlCommand As System.Data.SqlClient.SqlCommand
        '            Dim strSQL As String

        '            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
        '            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
        '            Dim objdacCustomer As New Josco.JsKernal.DataAccess.dacCustomer
        '            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
        '            Dim objdacDangan As New Josco.JSOA.DataAccess.dacDangan

        '            doAddToAnjuan = False
        '            strErrMsg = ""

        '            Try
        '                '检查
        '                If strAJBS Is Nothing Then strAJBS = ""
        '                strAJBS = strAJBS.Trim
        '                If strAJBS = "" Then
        '                    strErrMsg = "错误：没有指定目标[案卷]！"
        '                    GoTo errProc
        '                End If
        '                If Me.IsInitialized = False Then
        '                    strErrMsg = "错误：工作流未初始化！"
        '                    GoTo errProc
        '                End If
        '                If Me.IsFillData = False Then
        '                    strErrMsg = "错误：工作流未获取数据！"
        '                    GoTo errProc
        '                End If
        '                If strUserId Is Nothing Then strUserId = ""
        '                strUserId = strUserId.Trim
        '                If strUserId = "" Then
        '                    strErrMsg = "错误：未指定[连接用户]！"
        '                    GoTo errProc
        '                End If
        '                If strPassword Is Nothing Then strPassword = ""
        '                strPassword = strPassword.Trim
        '                If strTempPath Is Nothing Then strTempPath = ""
        '                strTempPath = strTempPath.Trim
        '                If strTempPath = "" Then
        '                    strErrMsg = "错误：未指定下载文件临时存放路径！"
        '                    GoTo errProc
        '                End If
        '                objSqlConnection = Me.SqlConnection

        '                '获取目标案卷信息
        '                If objdacDangan.getDataSet_Anjuan(strErrMsg, strUserId, strPassword, strAJBS, objAnjuanDataSet) = False Then
        '                    GoTo errProc
        '                End If
        '                Dim strMLBS As String
        '                Dim strDALX As String
        '                Dim strWJND As String
        '                Dim strSSDW As String
        '                With objAnjuanDataSet.Tables(Josco.JSOA.Common.Data.daglDanganData.TABLE_DA_B_ANJUANMULU)
        '                    If .Rows.Count < 1 Then
        '                        strErrMsg = "错误：[案卷]不存在！"
        '                        GoTo errProc
        '                    End If
        '                    strMLBS = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.daglDanganData.FIELD_DA_B_ANJUANMULU_ZABS), "")
        '                    strDALX = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.daglDanganData.FIELD_DA_B_ANJUANMULU_DALX), "")
        '                    strWJND = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.daglDanganData.FIELD_DA_B_ANJUANMULU_WJND), "")
        '                    strSSDW = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.daglDanganData.FIELD_DA_B_ANJUANMULU_SSDW), "")
        '                End With
        '                Josco.JSOA.Common.Data.daglDanganData.SafeRelease(objAnjuanDataSet)

        '                '检查权限(作者以上权限)
        '                Dim blnIS As Boolean
        '                If objdacDangan.isRole(strErrMsg, strUserId, strPassword, strUserId, strSSDW, strDALX, 6, blnIS) = False Then
        '                    GoTo errProc
        '                End If
        '                If blnIS = False Then
        '                    strErrMsg = "错误：不具备[" + strSSDW + "]作者以上权限！"
        '                    GoTo errProc
        '                End If

        '                '获取工作流记录
        '                Dim objBaseFlowKqglQJD As Josco.JSOA.Common.Workflow.BaseFlowKqglQJD
        '                Try
        '                    objBaseFlowKqglQJD = CType(Me.FlowData, Josco.JSOA.Common.Workflow.BaseFlowKqglQJD)
        '                Catch ex As Exception
        '                    strErrMsg = ex.Message
        '                    GoTo errProc
        '                End Try
        '                If objBaseFlowKqglQJD Is Nothing Then
        '                    strErrMsg = "错误：无法正确获取文件数据！"
        '                    GoTo errProc
        '                End If

        '                '获取用户所在单位
        '                Dim strBMDM As String
        '                Dim strBMMC As String
        '                If objdacCustomer.getBmdmAndBmmcByRydm(strErrMsg, objSqlConnection, strUserId, strBMDM, strBMMC) = False Then
        '                    GoTo errProc
        '                End If

        '                '获取附件数据
        '                If Me.getFujianData(strErrMsg, objFujianDataSet) = False Then
        '                    GoTo errProc
        '                End If

        '                '下载“批件原件”
        '                Dim strPJYJ As String = objBaseFlowKqglQJD.PJYJ
        '                Dim strDesPath As String = strTempPath
        '                Dim strDesSpec As String = ""
        '                Dim strDesFile As String = ""
        '                If strPJYJ <> "" Then
        '                    If objdacCommon.doFTPDownLoadFile(strErrMsg, strUserId, strPassword, strPJYJ, strDesSpec, strDesPath, strDesFile) = False Then
        '                        GoTo errProc
        '                    End If
        '                    strPJYJ = strDesSpec
        '                End If

        '                '下载“正文内容”
        '                Dim strZWNR As String = objBaseFlowKqglQJD.ZWNR
        '                strDesPath = strTempPath
        '                strDesSpec = ""
        '                strDesFile = ""
        '                If strZWNR <> "" Then
        '                    If objdacCommon.doFTPDownLoadFile(strErrMsg, strUserId, strPassword, strZWNR, strDesSpec, strDesPath, strDesFile) = False Then
        '                        GoTo errProc
        '                    End If
        '                    strZWNR = strDesSpec
        '                End If

        '                '下载“定稿文件”
        '                Dim strHJWJ As String = objBaseFlowKqglQJD.HJWJ
        '                strDesPath = strTempPath
        '                strDesSpec = ""
        '                strDesFile = ""
        '                If strHJWJ <> "" Then
        '                    If objdacCommon.doFTPDownLoadFile(strErrMsg, strUserId, strPassword, strHJWJ, strDesSpec, strDesPath, strDesFile) = False Then
        '                        GoTo errProc
        '                    End If
        '                    strHJWJ = strDesSpec
        '                End If

        '                '获取新的卷内序号
        '                Dim intJNXH As Integer
        '                If objdacDangan.getNewJNXH(strErrMsg, strUserId, strPassword, strMLBS, strAJBS, intJNXH) = False Then
        '                    GoTo errProc
        '                End If

        '                '获取新的卷内文件标识
        '                Dim strJNBS As String
        '                If objdacCommon.getNewGUID(strErrMsg, objSqlConnection, strJNBS) = False Then
        '                    GoTo errProc
        '                End If

        '                '计算文号
        '                Dim strWJZH As String = ""

        '                '开始事务
        '                Try
        '                    objSqlCommand = New System.Data.SqlClient.SqlCommand
        '                    objSqlCommand.Connection = objSqlConnection
        '                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout
        '                    objSqlTransaction = objSqlConnection.BeginTransaction
        '                    objSqlCommand.Transaction = objSqlTransaction
        '                Catch ex As Exception
        '                    strErrMsg = ex.Message
        '                    GoTo errProc
        '                End Try

        '                '执行事务
        '                Dim strBasePath As String = Josco.JSOA.Common.Data.daglDanganData.FILEDIR_WJ
        '                Dim intWJND As Integer = objPulicParameters.getObjectValue(strWJND, 0)
        '                Dim strFileUrl As String
        '                Dim intXH As Integer = 1
        '                Try
        '                    '写入指定案卷
        '                    strSQL = ""
        '                    strSQL = strSQL + " insert into 档案_B_卷内目录 (" + vbCr
        '                    strSQL = strSQL + "   文件标识,主案标识,案卷标识," + vbCr
        '                    strSQL = strSQL + "   档案类型,文件年度,所属单位,所有者,归档单位," + vbCr
        '                    strSQL = strSQL + "   卷内序号,文件标题,文件字号,文件日期,档案分类," + vbCr
        '                    strSQL = strSQL + "   文件类型,收发代码,主题词,作者,发文单位,密级,紧急程度," + vbCr
        '                    strSQL = strSQL + "   载体,保管期限,归档日期,对应文件" + vbCr
        '                    strSQL = strSQL + " ) values (" + vbCr
        '                    '---------------------------------------------------------------
        '                    strSQL = strSQL + "   '" + strJNBS + "'," + vbCr
        '                    strSQL = strSQL + "   '" + strMLBS + "'," + vbCr
        '                    strSQL = strSQL + "   '" + strAJBS + "'," + vbCr
        '                    '---------------------------------------------------------------
        '                    strSQL = strSQL + "   '" + strDALX + "'," + vbCr
        '                    strSQL = strSQL + "   '" + strWJND + "'," + vbCr
        '                    strSQL = strSQL + "   '" + strSSDW + "'," + vbCr
        '                    strSQL = strSQL + "   '" + strSSDW + "'," + vbCr
        '                    strSQL = strSQL + "   '" + strBMMC + "'," + vbCr
        '                    '---------------------------------------------------------------
        '                    strSQL = strSQL + "    " + intJNXH.ToString + "," + vbCr
        '                    strSQL = strSQL + "   '" + objBaseFlowKqglQJD.WJBT + "'," + vbCr
        '                    strSQL = strSQL + "   '" + strWJZH + "'," + vbCr
        '                    strSQL = strSQL + "   '" + objBaseFlowKqglQJD.QFRQ.ToString("yyyy-MM-dd HH:mm:ss") + "'," + vbCr
        '                    strSQL = strSQL + "   '" + "文书档案" + "'," + vbCr
        '                    '---------------------------------------------------------------
        '                    strSQL = strSQL + "   '" + " " + "'," + vbCr
        '                    strSQL = strSQL + "   '" + objBaseFlowKqglQJD.FLOWNAME + "'," + vbCr
        '                    strSQL = strSQL + "   '" + " " + "'," + vbCr
        '                    strSQL = strSQL + "   '" + objBaseFlowKqglQJD.ZBDW + "'," + vbCr
        '                    strSQL = strSQL + "   '" + objBaseFlowKqglQJD.ZBDW + "'," + vbCr
        '                    strSQL = strSQL + "   '" + objBaseFlowKqglQJD.MMDJ + "'," + vbCr
        '                    strSQL = strSQL + "   '" + objBaseFlowKqglQJD.JJCD + "'," + vbCr
        '                    '---------------------------------------------------------------
        '                    strSQL = strSQL + "   '" + "电子" + "'," + vbCr
        '                    strSQL = strSQL + "   '" + "长期" + "'," + vbCr
        '                    strSQL = strSQL + "   '" + Now.ToString("yyyy-MM-dd HH:mm:ss") + "'," + vbCr
        '                    strSQL = strSQL + "   '" + objBaseFlowKqglQJD.WJBS + "'" + vbCr
        '                    strSQL = strSQL + " ) " + vbCr
        '                    objSqlCommand.CommandText = strSQL
        '                    objSqlCommand.Parameters.Clear()
        '                    objSqlCommand.ExecuteNonQuery()

        '                    '写参与人
        '                    strSQL = ""
        '                    strSQL = strSQL + " insert into 档案_B_参与人员 (文件标识,参与人员) " + vbCr
        '                    strSQL = strSQL + " select 文件标识 = '" + strJNBS + "',人员名称 " + vbCr
        '                    strSQL = strSQL + " from " + vbCr
        '                    strSQL = strSQL + " (" + vbCr
        '                    strSQL = strSQL + "   select 接收人 as 人员名称 from 公文_B_交接 " + vbCr
        '                    strSQL = strSQL + "   where 文件标识 = '" + objBaseFlowKqglQJD.WJBS + "' " + vbCr
        '                    strSQL = strSQL + "   and 交接标识 like '__1%' " + vbCr
        '                    strSQL = strSQL + "   group by 接收人 " + vbCr
        '                    strSQL = strSQL + "   union " + vbCr
        '                    strSQL = strSQL + "   select 发送人 as 人员名称 from 公文_B_交接 " + vbCr
        '                    strSQL = strSQL + "   where 文件标识 = '" + objBaseFlowKqglQJD.WJBS + "' " + vbCr
        '                    strSQL = strSQL + "   and 交接标识 like '_1%' " + vbCr
        '                    strSQL = strSQL + "   group by 发送人 " + vbCr
        '                    strSQL = strSQL + " ) a " + vbCr
        '                    strSQL = strSQL + " group by a.人员名称" + vbCr
        '                    objSqlCommand.CommandText = strSQL
        '                    objSqlCommand.Parameters.Clear()
        '                    objSqlCommand.ExecuteNonQuery()

        '                    '写定稿文件
        '                    If strHJWJ <> "" Then
        '                        '上载文件
        '                        If objdacDangan.getFTPFileName_JNML_FILE(strErrMsg, strHJWJ, intWJND, strJNBS, intXH, strBasePath, strFileUrl) = False Then
        '                            GoTo rollDatabase
        '                        End If
        '                        If objdacCommon.doFTPUploadFile(strErrMsg, strUserId, strPassword, strHJWJ, strFileUrl) = False Then
        '                            GoTo rollDatabase
        '                        End If
        '                        '保存数据
        '                        strSQL = ""
        '                        strSQL = strSQL + " insert into 档案_B_卷内文件 (" + vbCr
        '                        strSQL = strSQL + "   文件标识,序号,类型,样式,名称,页数,位置" + vbCr
        '                        strSQL = strSQL + " ) values (" + vbCr
        '                        strSQL = strSQL + "   '" + strJNBS + "'," + vbCr
        '                        strSQL = strSQL + "    " + intXH.ToString + " ," + vbCr
        '                        strSQL = strSQL + "   '" + Josco.JSOA.Common.Data.daglDanganData.TYPE_ZSWJ + "'," + vbCr
        '                        strSQL = strSQL + "   '" + Josco.JSOA.Common.Data.daglDanganData.STYLE_FYJ + "'," + vbCr
        '                        strSQL = strSQL + "   '" + "定稿文件" + "'," + vbCr
        '                        strSQL = strSQL + "    " + "1" + " ," + vbCr
        '                        strSQL = strSQL + "   '" + strFileUrl + "' " + vbCr
        '                        strSQL = strSQL + " )" + vbCr
        '                        objSqlCommand.CommandText = strSQL
        '                        objSqlCommand.Parameters.Clear()
        '                        objSqlCommand.ExecuteNonQuery()
        '                        '************************************************
        '                        intXH += 1
        '                    End If

        '                    '写签批文件
        '                    If strPJYJ <> "" Then
        '                        '上载文件
        '                        If objdacDangan.getFTPFileName_JNML_FILE(strErrMsg, strPJYJ, intWJND, strJNBS, intXH, strBasePath, strFileUrl) = False Then
        '                            GoTo rollDatabase
        '                        End If
        '                        If objdacCommon.doFTPUploadFile(strErrMsg, strUserId, strPassword, strPJYJ, strFileUrl) = False Then
        '                            GoTo rollDatabase
        '                        End If
        '                        '保存数据
        '                        strSQL = ""
        '                        strSQL = strSQL + " insert into 档案_B_卷内文件 (" + vbCr
        '                        strSQL = strSQL + "   文件标识,序号,类型,样式,名称,页数,位置" + vbCr
        '                        strSQL = strSQL + " ) values (" + vbCr
        '                        strSQL = strSQL + "   '" + strJNBS + "'," + vbCr
        '                        strSQL = strSQL + "    " + intXH.ToString + " ," + vbCr
        '                        strSQL = strSQL + "   '" + Josco.JSOA.Common.Data.daglDanganData.TYPE_ZSWJ + "'," + vbCr
        '                        strSQL = strSQL + "   '" + Josco.JSOA.Common.Data.daglDanganData.STYLE_YJ + "'," + vbCr
        '                        strSQL = strSQL + "   '" + "正式文件" + "'," + vbCr
        '                        strSQL = strSQL + "    " + "1" + " ," + vbCr
        '                        strSQL = strSQL + "   '" + strFileUrl + "' " + vbCr
        '                        strSQL = strSQL + " )" + vbCr
        '                        objSqlCommand.CommandText = strSQL
        '                        objSqlCommand.Parameters.Clear()
        '                        objSqlCommand.ExecuteNonQuery()
        '                        '************************************************
        '                        intXH += 1
        '                    End If

        '                    '写稿件文件
        '                    If strZWNR <> "" Then
        '                        '上载文件
        '                        If objdacDangan.getFTPFileName_JNML_FILE(strErrMsg, strZWNR, intWJND, strJNBS, intXH, strBasePath, strFileUrl) = False Then
        '                            GoTo rollDatabase
        '                        End If
        '                        If objdacCommon.doFTPUploadFile(strErrMsg, strUserId, strPassword, strZWNR, strFileUrl) = False Then
        '                            GoTo rollDatabase
        '                        End If
        '                        '保存数据
        '                        strSQL = ""
        '                        strSQL = strSQL + " insert into 档案_B_卷内文件 (" + vbCr
        '                        strSQL = strSQL + "   文件标识,序号,类型,样式,名称,页数,位置" + vbCr
        '                        strSQL = strSQL + " ) values (" + vbCr
        '                        strSQL = strSQL + "   '" + strJNBS + "'," + vbCr
        '                        strSQL = strSQL + "    " + intXH.ToString + " ," + vbCr
        '                        strSQL = strSQL + "   '" + Josco.JSOA.Common.Data.daglDanganData.TYPE_PIJIAN + "'," + vbCr
        '                        strSQL = strSQL + "   '" + Josco.JSOA.Common.Data.daglDanganData.STYLE_FYJ + "'," + vbCr
        '                        strSQL = strSQL + "   '" + "原稿内容" + "'," + vbCr
        '                        strSQL = strSQL + "    " + "1" + " ," + vbCr
        '                        strSQL = strSQL + "   '" + strFileUrl + "' " + vbCr
        '                        strSQL = strSQL + " )" + vbCr
        '                        objSqlCommand.CommandText = strSQL
        '                        objSqlCommand.Parameters.Clear()
        '                        objSqlCommand.ExecuteNonQuery()
        '                        '************************************************
        '                        intXH += 1
        '                    End If

        '                    '写附件数据
        '                    Dim strFJSM As String
        '                    Dim strWJWZ As String
        '                    Dim intFJXH As Integer
        '                    Dim intFJYS As Integer
        '                    Dim intCount As Integer
        '                    Dim i As Integer
        '                    With objFujianDataSet.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_FUJIAN)
        '                        intCount = .Rows.Count
        '                        For i = 0 To intCount - 1 Step 1
        '                            '计算附件数据
        '                            strFJSM = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJSM), "")
        '                            strWJWZ = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJWZ), "")
        '                            intFJXH = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJXH), 0)
        '                            intFJYS = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJYS), 0)
        '                            '下载文件
        '                            strDesPath = strTempPath
        '                            strDesSpec = ""
        '                            strDesFile = ""
        '                            If objdacCommon.doFTPDownLoadFile(strErrMsg, strUserId, strPassword, strWJWZ, strDesSpec, strDesPath, strDesFile) = False Then
        '                                GoTo rollDatabase
        '                            End If
        '                            '上载文件
        '                            If objdacDangan.getFTPFileName_JNML_FILE(strErrMsg, strDesSpec, intWJND, strJNBS, intXH, strBasePath, strFileUrl) = False Then
        '                                GoTo rollDatabase
        '                            End If
        '                            If objdacCommon.doFTPUploadFile(strErrMsg, strUserId, strPassword, strDesSpec, strFileUrl) = False Then
        '                                GoTo rollDatabase
        '                            End If
        '                            '保存数据
        '                            strSQL = ""
        '                            strSQL = strSQL + " insert into 档案_B_卷内文件 (" + vbCr
        '                            strSQL = strSQL + "   文件标识,序号,类型,样式,名称,页数,位置" + vbCr
        '                            strSQL = strSQL + " ) values (" + vbCr
        '                            strSQL = strSQL + "   '" + strJNBS + "'," + vbCr
        '                            strSQL = strSQL + "    " + intXH.ToString + " ," + vbCr
        '                            strSQL = strSQL + "   '" + Josco.JSOA.Common.Data.daglDanganData.TYPE_PIJIAN + "'," + vbCr
        '                            strSQL = strSQL + "   '" + Josco.JSOA.Common.Data.daglDanganData.STYLE_FYJ + "'," + vbCr
        '                            strSQL = strSQL + "   '" + "附件" + intFJXH.ToString + "：" + strFJSM + "'," + vbCr
        '                            strSQL = strSQL + "    " + intFJYS.ToString + " ," + vbCr
        '                            strSQL = strSQL + "   '" + strFileUrl + "' " + vbCr
        '                            strSQL = strSQL + " )" + vbCr
        '                            objSqlCommand.CommandText = strSQL
        '                            objSqlCommand.Parameters.Clear()
        '                            objSqlCommand.ExecuteNonQuery()
        '                            '************************************************
        '                            intXH += 1
        '                        Next
        '                    End With

        '                Catch ex As Exception
        '                    strErrMsg = ex.Message
        '                    GoTo rollDatabase
        '                End Try

        '                '提交事务
        '                objSqlTransaction.Commit()

        '            Catch ex As Exception
        '                strErrMsg = ex.Message
        '                GoTo errProc
        '            End Try

        '            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
        '            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
        '            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
        '            Josco.JSOA.Common.Data.daglDanganData.SafeRelease(objAnjuanDataSet)
        '            Josco.JSOA.Common.Data.FlowData.SafeRelease(objFujianDataSet)
        '            Josco.JsKernal.DataAccess.dacCustomer.SafeRelease(objdacCustomer)
        '            Josco.JSOA.DataAccess.dacDangan.SafeRelease(objdacDangan)
        '            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

        '            doAddToAnjuan = True
        '            Exit Function

        'rollDatabase:
        '            objSqlTransaction.Rollback()
        '            GoTo errProc

        'errProc:
        '            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
        '            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
        '            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
        '            Josco.JSOA.Common.Data.daglDanganData.SafeRelease(objAnjuanDataSet)
        '            Josco.JSOA.Common.Data.FlowData.SafeRelease(objFujianDataSet)
        '            Josco.JsKernal.DataAccess.dacCustomer.SafeRelease(objdacCustomer)
        '            Josco.JSOA.DataAccess.dacDangan.SafeRelease(objdacDangan)
        '            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
        '            Exit Function

        '        End Function







    End Class

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.DataAccess
    ' 类名    ：FlowObjectKqglQJDCreator
    '
    ' 功能描述： 
    '     FlowObjectKqglQJD的创建接口实现
    '----------------------------------------------------------------
    Public Class FlowObjectKqglQJDCreator
        Implements Josco.JSOA.DataAccess.IFlowObjectCreate

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
            ByVal strFlowTypeName As String) As Josco.JSOA.DataAccess.FlowObject _
            Implements Josco.JSOA.DataAccess.IFlowObjectCreate.Create

            Try
                Create = New Josco.JSOA.DataAccess.FlowObjectKqglQJD
            Catch ex As Exception
                Throw ex
            End Try

        End Function

    End Class

End Namespace

