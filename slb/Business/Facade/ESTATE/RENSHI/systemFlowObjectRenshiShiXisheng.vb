
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
Imports System.Security.Cryptography
Imports Microsoft.VisualBasic

Imports Josco.JsKernal.SystemFramework
Imports Josco.JsKernal.Common.Data
Imports Josco.JSOA.Common.Data
Imports Josco.JSOA.BusinessRules

Namespace Josco.JSOA.BusinessFacade
    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.BusinessFacade
    ' 类名    ：systemFlowObjectRenshiShiXisheng
    '
    ' 功能描述： 
    '   　人事实习生审批工作流的表现层对象
    '----------------------------------------------------------------
    Public Class systemFlowObjectRenshiShiXisheng
        Inherits Josco.JSOA.BusinessFacade.systemFlowObject

        '模块命令
        Private m_blnDRQP As Boolean        '导入签批电子件
        Private m_blnDRZS As Boolean        '导入签批扫描件
        'zengxianglin 2009-05-16
        Private m_blnRYLY As Boolean        '人员录用处理
        'zengxianglin 2009-05-16

        '模块附加信息
        Private m_blnQSYJ_SH As Boolean     '审核意见
        Private m_blnQSYJ_HQ As Boolean     '会签意见
        Private m_blnQSYJ_FH As Boolean     '复核意见
        Private m_blnQSYJ_QF As Boolean     '签发意见









        '----------------------------------------------------------------
        ' 构造函数
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New(Josco.JSOA.Common.Workflow.BaseFlowRenshiShiXiSheng.FLOWCODE, Josco.JSOA.Common.Workflow.BaseFlowRenshiShiXiSheng.FLOWNAME)

            m_blnDRQP = False
            m_blnDRZS = False
            'zengxianglin 2009-05-16
            m_blnRYLY = False
            'zengxianglin 2009-05-16

            m_blnQSYJ_SH = False
            m_blnQSYJ_HQ = False
            m_blnQSYJ_FH = False
            m_blnQSYJ_QF = False

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
        Public Overloads Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.systemFlowObjectRenshiShiXisheng)
            Try
                If Not (obj Is Nothing) Then
                    obj.Dispose()
                End If
            Catch ex As Exception
            End Try
            obj = Nothing
        End Sub












        'zengxianglin 2009-05-16
        '----------------------------------------------------------------
        ' mlRYLY属性
        '----------------------------------------------------------------
        Public ReadOnly Property mlRYLY() As Boolean
            Get
                mlRYLY = m_blnRYLY
            End Get
        End Property
        'zengxianglin 2009-05-16

        '----------------------------------------------------------------
        ' mlDRQP属性
        '----------------------------------------------------------------
        Public ReadOnly Property mlDRQP() As Boolean
            Get
                mlDRQP = m_blnDRQP
            End Get
        End Property

        '----------------------------------------------------------------
        ' mlDRZS属性
        '----------------------------------------------------------------
        Public ReadOnly Property mlDRZS() As Boolean
            Get
                mlDRZS = m_blnDRZS
            End Get
        End Property

        '----------------------------------------------------------------
        ' pmQSYJ_QF属性
        '----------------------------------------------------------------
        Public ReadOnly Property pmQSYJ_QF() As Boolean
            Get
                pmQSYJ_QF = m_blnQSYJ_QF
            End Get
        End Property

        '----------------------------------------------------------------
        ' pmQSYJ_FH属性
        '----------------------------------------------------------------
        Public ReadOnly Property pmQSYJ_FH() As Boolean
            Get
                pmQSYJ_FH = m_blnQSYJ_FH
            End Get
        End Property

        '----------------------------------------------------------------
        ' pmQSYJ_HQ属性
        '----------------------------------------------------------------
        Public ReadOnly Property pmQSYJ_HQ() As Boolean
            Get
                pmQSYJ_HQ = m_blnQSYJ_HQ
            End Get
        End Property

        '----------------------------------------------------------------
        ' pmQSYJ_SH属性
        '----------------------------------------------------------------
        Public ReadOnly Property pmQSYJ_SH() As Boolean
            Get
                pmQSYJ_SH = m_blnQSYJ_SH
            End Get
        End Property













        '----------------------------------------------------------------
        ' 获取工作流文件目前能进行的任务
        '     strErrMsg      ：返回错误信息
        '     objTask        ：返回能进行的任务
        ' 返回 
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Public Overrides Function getCanDoTaskList( _
            ByRef strErrMsg As String, _
            ByRef objTask As System.Collections.Specialized.NameValueCollection) As Boolean

            getCanDoTaskList = False
            strErrMsg = ""
            objTask = Nothing

            Try
                '检查
                If Me.IsInitialized = False Then
                    strErrMsg = "错误：[getCanDoTaskList]工作流对象未初始化，不能使用！"
                    GoTo errProc
                End If
                If Me.IsFillData = False Then
                    strErrMsg = "错误：[getCanDoTaskList]工作流对象未填充数据，不能使用！"
                    GoTo errProc
                End If

                '创建对象
                objTask = New System.Collections.Specialized.NameValueCollection

                '根据文件状态设置
                Dim objBaseFlowRenshiShiXiSheng As Josco.JSOA.Common.Workflow.BaseFlowRenshiShiXiSheng
                objBaseFlowRenshiShiXiSheng = CType(Me.FlowData, Josco.JSOA.Common.Workflow.BaseFlowRenshiShiXiSheng)
                Select Case objBaseFlowRenshiShiXiSheng.BLZT
                    Case objBaseFlowRenshiShiXiSheng.FILESTATUS_YQP
                        objTask.Add(objBaseFlowRenshiShiXiSheng.TASK_LDCL, objBaseFlowRenshiShiXiSheng.TASK_LDCL)
                        objTask.Add(objBaseFlowRenshiShiXiSheng.TASK_WJGD, objBaseFlowRenshiShiXiSheng.TASK_WJGD)
                    Case Else
                        objTask.Add(objBaseFlowRenshiShiXiSheng.TASK_LDCL, objBaseFlowRenshiShiXiSheng.TASK_LDCL)
                        objTask.Add(objBaseFlowRenshiShiXiSheng.TASK_XGCL, objBaseFlowRenshiShiXiSheng.TASK_XGCL)
                End Select

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            getCanDoTaskList = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 打开指定文件的工作流模块
        ' 准备工作流调用接口并返回要访问工作流的Url
        '     strErrMsg      ：返回错误信息
        '     strControlId   ：当前操作组件ID
        '     strWJBS        ：文件标识
        '     strMSessionId  ：调用本工作流模块的父模块的MSessionId
        '     strISessionId  ：调用本工作流模块的父模块的ISessionId
        '     objEditType    ：工作流编辑类型
        '     Request        ：当前HttpRequest
        '     Session        ：当前HttpSessionState
        '     strUrl         ：返回要打开工作流文件的Url
        ' 返回 
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Public Overrides Function doFileOpen( _
            ByRef strErrMsg As String, _
            ByVal strControlId As String, _
            ByVal strWJBS As String, _
            ByVal strMSessionId As String, _
            ByVal strISessionId As String, _
            ByVal objEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType, _
            ByVal Request As System.Web.HttpRequest, _
            ByVal Session As System.Web.SessionState.HttpSessionState, _
            ByRef strUrl As String) As Boolean

            Dim objIEstateRsLuyongInfo As Josco.JSOA.BusinessFacade.IEstateRsLuyongInfo = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strNewSessionId As String = ""

            doFileOpen = False
            strErrMsg = ""
            strUrl = ""

            Try
                '检查参数
                If Request Is Nothing Then
                    strErrMsg = "错误：[doFileOpen]未传入HTTP请求对象！"
                    GoTo errProc
                End If
                If Session Is Nothing Then
                    strErrMsg = "错误：[doFileOpen]未传入HTTP会话对象！"
                    GoTo errProc
                End If
                If strWJBS Is Nothing Then strWJBS = ""
                strWJBS = strWJBS.Trim
                If strWJBS = "" Then
                    strErrMsg = "错误：[doFileOpen]未指定要打开的文件！"
                    GoTo errProc
                End If
                If strControlId Is Nothing Then strControlId = ""
                strControlId = strControlId.Trim
                If strMSessionId Is Nothing Then strMSessionId = ""
                strMSessionId = strMSessionId.Trim
                If strISessionId Is Nothing Then strISessionId = ""
                strISessionId = strISessionId.Trim

                '准备调用接口
                objIEstateRsLuyongInfo = New Josco.JSOA.BusinessFacade.IEstateRsLuyongInfo
                With objIEstateRsLuyongInfo
                    .iEditMode = objEditType
                    .iWJBS = strWJBS

                    .iSourceControlId = strControlId
                    strUrl = ""
                    strUrl += Request.Url.AbsolutePath
                    strUrl += "?"
                    If strISessionId = "" Then
                        strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                        strUrl += "="
                        strUrl += strMSessionId
                    Else
                        strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                        strUrl += "="
                        strUrl += strISessionId
                        strUrl += "&"
                        strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                        strUrl += "="
                        strUrl += strMSessionId
                    End If
                    .iReturnUrl = strUrl
                End With

                '缓存接口
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIEstateRsLuyongInfo)

                '计算Url
                strUrl = ""
                strUrl += Request.ApplicationPath + Me.getPageUrl()
                strUrl += "?"
                strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                strUrl += "="
                strUrl += strNewSessionId

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            doFileOpen = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.BusinessFacade.IEstateRsLuyongInfo.SafeRelease(objIEstateRsLuyongInfo)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 打开新建文件的工作流模块
        ' 准备工作流调用接口并返回要访问工作流的Url
        '     strErrMsg      ：返回错误信息
        '     strControlId   ：当前操作组件ID
        '     strWJBS        ：文件标识=""
        '     strMSessionId  ：调用本工作流模块的父模块的MSessionId
        '     strISessionId  ：调用本工作流模块的父模块的ISessionId
        '     objEditType    ：工作流编辑类型
        '     Request        ：当前HttpRequest
        '     Session        ：当前HttpSessionState
        '     strUrl         ：返回要打开工作流文件的Url
        '     strRSessionId  ：返回新创建的会话ID
        ' 返回 
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Public Overrides Function doFileNew( _
            ByRef strErrMsg As String, _
            ByVal strControlId As String, _
            ByVal strWJBS As String, _
            ByVal strMSessionId As String, _
            ByVal strISessionId As String, _
            ByVal objEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType, _
            ByVal Request As System.Web.HttpRequest, _
            ByVal Session As System.Web.SessionState.HttpSessionState, _
            ByRef strUrl As String, _
            ByRef strRSessionId As String) As Boolean

            Dim objIEstateRsLuyongInfo As Josco.JSOA.BusinessFacade.IEstateRsLuyongInfo = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strNewSessionId As String

            doFileNew = False
            strRSessionId = ""
            strErrMsg = ""
            strUrl = ""

            Try
                '检查参数
                If Request Is Nothing Then
                    strErrMsg = "错误：未传入HTTP请求对象！"
                    GoTo errProc
                End If
                If Session Is Nothing Then
                    strErrMsg = "错误：未传入HTTP会话对象！"
                    GoTo errProc
                End If
                If strControlId Is Nothing Then strControlId = ""
                strControlId = strControlId.Trim
                If strWJBS Is Nothing Then strWJBS = ""
                strWJBS = strWJBS.Trim
                If strMSessionId Is Nothing Then strMSessionId = ""
                strMSessionId = strMSessionId.Trim
                If strISessionId Is Nothing Then strISessionId = ""
                strISessionId = strISessionId.Trim

                '准备调用接口
                objIEstateRsLuyongInfo = New Josco.JSOA.BusinessFacade.IEstateRsLuyongInfo
                With objIEstateRsLuyongInfo
                    .iEditMode = objEditType
                    .iWJBS = strWJBS

                    .iSourceControlId = strControlId
                    strUrl = ""
                    strUrl += Request.Url.AbsolutePath
                    strUrl += "?"
                    If strISessionId = "" Then
                        strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                        strUrl += "="
                        strUrl += strMSessionId
                    Else
                        strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                        strUrl += "="
                        strUrl += strISessionId
                        strUrl += "&"
                        strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                        strUrl += "="
                        strUrl += strMSessionId
                    End If
                    .iReturnUrl = strUrl
                End With

                '缓存接口
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIEstateRsLuyongInfo)

                '计算Url
                strUrl = ""
                strUrl += Request.ApplicationPath + Me.getPageUrl()
                strUrl += "?"
                strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                strUrl += "="
                strUrl += strNewSessionId

                strRSessionId = strNewSessionId

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            doFileNew = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.BusinessFacade.IEstateRsLuyongInfo.SafeRelease(objIEstateRsLuyongInfo)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取当前工作流的web页的Url(相对应用的根路径)
        ' 返回
        '                    ：当前工作流的web页的Url
        '----------------------------------------------------------------
        Public Overrides Function getPageUrl() As String
            getPageUrl = "/secure/estate/nrenshi/estate_rs_shixisheng_info.aspx"
        End Function

        '----------------------------------------------------------------
        ' 计算可对当前文件进行的操作
        '     strErrMsg      ：返回错误信息
        '     strCzyId       ：当前用户代码
        '     strUserXM      ：当前用户名称
        '     strUserBMDM    ：当前用户单位代码
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Public Overrides Function getCanExecuteCommand( _
            ByRef strErrMsg As String, _
            ByVal strCzyId As String, _
            ByVal strUserXM As String, _
            ByVal strUserBMDM As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objJiaojieDataWWC As Josco.JSOA.Common.Data.FlowData

            Dim strSep As String = Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate
            Dim objBaseFlowRenshiShiXiSheng As Josco.JSOA.Common.Workflow.BaseFlowRenshiShiXiSheng
            Dim blnEditMode As Boolean = False
            Dim blnDo As Boolean

            getCanExecuteCommand = False

            Try
                '工作流初始化
                objBaseFlowRenshiShiXiSheng = CType(Me.FlowData, Josco.JSOA.Common.Workflow.BaseFlowRenshiShiXiSheng)
                Dim strWJBS As String = objBaseFlowRenshiShiXiSheng.WJBS
                If strUserXM Is Nothing Then strUserXM = ""
                strUserXM = strUserXM.Trim()
                If strCzyId Is Nothing Then strCzyId = ""
                strCzyId = strCzyId.Trim()
                If strUserBMDM Is Nothing Then strUserBMDM = ""
                strUserBMDM = strUserBMDM.Trim()
                Dim objrulesFlowObjectRenshiShiXiSheng As Josco.JSOA.BusinessRules.rulesFlowObjectRenshiShiXiSheng = Nothing
                objrulesFlowObjectRenshiShiXiSheng = CType(Me.m_objrulesFlowObject, Josco.JSOA.BusinessRules.rulesFlowObjectRenshiShiXiSheng)

                '
                '不受文件影响的操作
                '
                '刷新文件
                Me.m_blnSXWJ = Not blnEditMode
                '返回上级
                Me.m_blnFHSJ = Not blnEditMode

                '
                '没有文件
                '
                If strWJBS = "" Then
                    Exit Try
                End If

                '
                '文件已作废？
                '
                If Me.isFileZuofei(strErrMsg, blnDo) = False Then
                    GoTo errProc
                End If
                If blnDo = True Then
                    '可打印
                    Me.m_blnDYGZ = Not blnEditMode
                    Me.m_blnDYBJ = Not blnEditMode
                    '可查看文件监控信息
                    Me.m_blnCYYJ = Not blnEditMode
                    Me.m_blnCKLZ = Not blnEditMode
                    Me.m_blnCKRZ = Not blnEditMode
                    Me.m_blnCKBY = Not blnEditMode
                    Me.m_blnCKCB = Not blnEditMode
                    Me.m_blnCKDB = Not blnEditMode
                    '起草人可重新启用
                    If Me.isOriginalPeople(strErrMsg, strUserXM, blnDo) = False Then
                        GoTo errProc
                    End If
                    Me.m_blnQYWJ = Not blnEditMode And blnDo
                    Exit Try
                End If

                '
                '文件已正常办完？
                '
                If Me.isFileComplete(strErrMsg, blnDo) = False Then
                    GoTo errProc
                End If
                If blnDo = True Then
                    '可打印
                    Me.m_blnDYGZ = Not blnEditMode
                    Me.m_blnDYBJ = Not blnEditMode
                    '可查看文件监控信息
                    Me.m_blnCYYJ = Not blnEditMode
                    Me.m_blnCKLZ = Not blnEditMode
                    Me.m_blnCKRZ = Not blnEditMode
                    Me.m_blnCKBY = Not blnEditMode
                    Me.m_blnCKCB = Not blnEditMode
                    Me.m_blnCKDB = Not blnEditMode
                    '可以补阅
                    Me.m_blnWJBY = Not blnEditMode
                    '可以处理未办的通知类消息
                    If Me.isHasNotCompleteTongzhi(strErrMsg, strUserXM, blnDo) = False Then
                        GoTo errProc
                    End If
                    Me.m_blnWYYZ = Not blnEditMode And blnDo
                    Exit Try
                End If

                '
                '当前文件是否发送过？
                '
                If Me.isFileSendOnce(strErrMsg, blnDo) = False Then
                    GoTo errProc
                End If
                If blnDo = False Then
                    '可打印
                    Me.m_blnDYGZ = Not blnEditMode
                    Me.m_blnDYBJ = Not blnEditMode
                    '可以补阅
                    Me.m_blnWJBY = Not blnEditMode
                    '可以发送
                    Me.m_blnFSWJ = Not blnEditMode
                    '可以修改
                    Me.m_blnXGWJ = Not blnEditMode
                    '可以处理未办的通知类消息
                    If Me.isHasNotCompleteTongzhi(strErrMsg, strUserXM, blnDo) = False Then
                        GoTo errProc
                    End If
                    Me.m_blnWYYZ = Not blnEditMode And blnDo
                    Exit Try
                End If

                '
                '正常流转文件
                '
                '
                '是否自动接收文件？
                '
                If Me.isAutoReceive(strErrMsg, strUserXM, blnDo) = False Then
                    GoTo errProc
                End If
                If blnDo = True Then
                    '自动接收文件
                    If Me.doAutoReceive(strErrMsg, strUserXM) = False Then
                        GoTo errProc
                    End If
                End If

                '可以处理未办的通知类消息
                If Me.isHasNotCompleteTongzhi(strErrMsg, strUserXM, blnDo) = False Then
                    GoTo errProc
                End If
                Me.m_blnWYYZ = Not blnEditMode And blnDo

                '
                '是否有未办完的事宜？(非通知类事宜)
                '
                If Me.getNotCompletedTaskData(strErrMsg, strUserXM, objJiaojieDataWWC) = False Then
                    GoTo errProc
                End If

                '
                '是否有未接收的事宜？
                '
                Dim strTaskStatusWJS As String = objBaseFlowRenshiShiXiSheng.TASKSTATUS_WJS
                With objJiaojieDataWWC.Tables(Josco.JsKernal.Common.Data.FlowData.TABLE_GW_B_JIAOJIE)
                    .DefaultView.RowFilter = Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_BLZT + " = '" + strTaskStatusWJS + "'"
                    If .DefaultView.Count > 0 Then
                        '存在未接收的事宜，必须先接收文件才能继续处理
                        Me.m_blnJSWJ = Not blnEditMode
                        Me.m_blnMustJieshou = Not blnEditMode
                    End If
                    '复原过滤
                    .DefaultView.RowFilter = ""
                End With

                '
                '正常流转文件：一般可执行的操作
                '
                '可打印
                Me.m_blnDYGZ = Not blnEditMode
                Me.m_blnDYBJ = Not blnEditMode
                '可查看文件监控信息
                Me.m_blnCYYJ = Not blnEditMode
                Me.m_blnCKLZ = Not blnEditMode
                Me.m_blnCKRZ = Not blnEditMode
                Me.m_blnCKBY = Not blnEditMode
                Me.m_blnCKCB = Not blnEditMode
                Me.m_blnCKDB = Not blnEditMode
                '可以补阅
                Me.m_blnWJBY = Not blnEditMode

                '文件是否停办？
                If Me.isFileTingban(strErrMsg, blnDo) = False Then
                    GoTo errProc
                End If
                If blnDo = True Then
                    '文件停办
                    With objJiaojieDataWWC.Tables(Josco.JsKernal.Common.Data.FlowData.TABLE_GW_B_JIAOJIE)
                        .DefaultView.RowFilter = Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_BLZT + " = '" + Me.FlowData.TASKSTATUS_YTB + "'"
                        If .Rows.Count > 0 Then
                            '可以“继续办理”
                            Me.m_blnJXBL = True
                            Exit Try
                        Else
                            '不用继续判断！
                            Exit Try
                        End If
                    End With
                End If

                '
                '可以填写督办结果？
                '
                If Me.canWriteDubanResult(strErrMsg, strUserXM, blnDo) = False Then
                    GoTo errProc
                End If
                Me.m_blnDBJG = Not blnEditMode And blnDo

                '
                '可以补登领导意见？(也可修改文件)
                '
                If Me.canBuDengFile(strErrMsg, strCzyId, strUserBMDM, blnDo) = False Then
                    GoTo errProc
                End If
                Me.m_blnBDPS = Not blnEditMode And blnDo
                If Me.m_blnBDPS = True Then
                    Me.m_blnXGWJ = Me.m_blnBDPS
                End If

                '
                '可以督办？
                '
                If Me.canDubanFile(strErrMsg, strCzyId, strUserBMDM, blnDo) = False Then
                    GoTo errProc
                End If
                Me.m_blnDBWJ = Not blnEditMode And blnDo

                '
                '可以催办文件？(也可收回文件)
                '
                If Me.canCuibanFile(strErrMsg, strUserXM, blnDo) = False Then
                    GoTo errProc
                End If
                Me.m_blnCBWJ = Not blnEditMode And blnDo
                Me.m_blnSHWJ = Me.m_blnCBWJ

                '全部办完？
                With objJiaojieDataWWC.Tables(Josco.JsKernal.Common.Data.FlowData.TABLE_GW_B_JIAOJIE)
                    If .Rows.Count < 1 Then
                        '全部办完！
                        Exit Try
                    End If
                End With

                '是否接收过文件？
                With objJiaojieDataWWC.Tables(Josco.JsKernal.Common.Data.FlowData.TABLE_GW_B_JIAOJIE)
                    .DefaultView.RowFilter = Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_BLZT + " = '" + strTaskStatusWJS + "'"
                    If .DefaultView.Count < 1 Then
                        '没有未接收，不能接收文件
                        Me.m_blnJSWJ = blnEditMode
                    Else
                        '有未接收！
                        .DefaultView.RowFilter = Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_BLZT + " <> '" + strTaskStatusWJS + "'"
                        If .DefaultView.Count < 1 Then
                            '全部未接收，必须先接收文件！
                            Me.m_blnJSWJ = Not blnEditMode
                            Me.m_blnMustJieshou = Not blnEditMode
                            Exit Try
                        Else
                            '可以接收文件
                            Me.m_blnJSWJ = Not blnEditMode
                        End If
                    End If
                    '获取已接收的事宜！
                    .DefaultView.RowFilter = Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_BLZT + " <> '" + strTaskStatusWJS + "'"
                End With
                '通用操作：我已办完
                Me.m_blnBLWB = Not blnEditMode

                '根据未办事宜判断可执行的操作
                Dim strBLZL As String
                Dim strJJBS As String
                Dim intCount As Integer
                Dim i As Integer
                With objJiaojieDataWWC.Tables(Josco.JsKernal.Common.Data.FlowData.TABLE_GW_B_JIAOJIE).DefaultView
                    intCount = .Count
                    For i = 0 To intCount - 1 Step 1
                        strJJBS = objPulicParameters.getObjectValue(.Item(i).Item(Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_JJBS), "")
                        strBLZL = objPulicParameters.getObjectValue(.Item(i).Item(Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_BLZL), "")

                        If Me.isTaskTuihui(strJJBS) = True Then
                            '退回的：不用办理、作废文件
                            Me.m_blnBYBL = Not blnEditMode
                            Me.m_blnZFWJ = Not blnEditMode
                        End If
                        If Me.isTaskShouhui(strJJBS) = True Then
                            '收回的：不用办理、作废文件
                            Me.m_blnBYBL = Not blnEditMode
                            Me.m_blnZFWJ = Not blnEditMode
                        End If
                        If Me.isTaskTongzhi(strJJBS) = True Then
                            '通知类事宜：我已阅知
                            Me.m_blnWYYZ = Not blnEditMode
                        End If

                        '继续办理？停止办理？
                        Select Case objBaseFlowRenshiShiXiSheng.BLZT
                            Case objBaseFlowRenshiShiXiSheng.FILESTATUS_YTB
                                '可执行：继续办理
                                Me.m_blnJXBL = Not blnEditMode
                            Case objBaseFlowRenshiShiXiSheng.FILESTATUS_YQP
                                '不能：停止办理
                            Case Else
                                Dim strTaskBYSYList As String = objBaseFlowRenshiShiXiSheng.TaskBlzlBYSYList
                                Dim strTask As String = "'" + strBLZL + "'"
                                If strTaskBYSYList.IndexOf(strTask) >= 0 Then
                                Else
                                    '可执行：停止办理
                                    Me.m_blnZHBL = Not blnEditMode
                                End If
                        End Select

                        '根据事宜判断
                        Select Case strBLZL
                            Case objBaseFlowRenshiShiXiSheng.TASK_CYCG, objBaseFlowRenshiShiXiSheng.TASK_GJBJ
                                '发送文件
                                Me.m_blnFSWJ = Not blnEditMode
                                '修改文件
                                Me.m_blnXGWJ = Not blnEditMode
                                '已签发？
                                If objBaseFlowRenshiShiXiSheng.QFR <> "" Then
                                    '拟稿人？
                                    If Me.isOriginalPeople(strErrMsg, strUserXM, blnDo) = False Then
                                        GoTo errProc
                                    End If
                                    If blnDo = True Then
                                        '文件办结
                                        Me.m_blnWJBJ = Not blnEditMode
                                    End If
                                End If

                            Case objBaseFlowRenshiShiXiSheng.TASK_SHWJ
                                '发送文件
                                Me.m_blnFSWJ = Not blnEditMode
                                '修改文件
                                Me.m_blnXGWJ = Not blnEditMode
                                '填写意见
                                Me.m_blnTXYJ = Not blnEditMode
                                Me.m_blnQSYJ_SH = Not blnEditMode
                                '退回文件
                                Me.m_blnTHWJ = Not blnEditMode

                            Case objBaseFlowRenshiShiXiSheng.TASK_HQWJ
                                '发送文件
                                Me.m_blnFSWJ = Not blnEditMode
                                '修改文件
                                Me.m_blnXGWJ = Not blnEditMode
                                '填写意见
                                Me.m_blnTXYJ = Not blnEditMode
                                Me.m_blnQSYJ_HQ = Not blnEditMode
                                '退回文件
                                Me.m_blnTHWJ = Not blnEditMode

                            Case objBaseFlowRenshiShiXiSheng.TASK_FHWJ
                                '发送文件
                                Me.m_blnFSWJ = Not blnEditMode
                                '修改文件
                                Me.m_blnXGWJ = Not blnEditMode
                                '填写意见
                                Me.m_blnTXYJ = Not blnEditMode
                                Me.m_blnQSYJ_FH = Not blnEditMode
                                '退回文件
                                Me.m_blnTHWJ = Not blnEditMode

                            Case objBaseFlowRenshiShiXiSheng.TASK_QFWJ
                                '发送文件
                                Me.m_blnFSWJ = Not blnEditMode
                                '修改文件
                                Me.m_blnXGWJ = Not blnEditMode
                                '填写意见
                                Me.m_blnTXYJ = Not blnEditMode
                                Me.m_blnQSYJ_QF = Not blnEditMode
                                Me.m_blnQSYJ_FH = Not blnEditMode
                                Me.m_blnQSYJ_HQ = Not blnEditMode
                                Me.m_blnQSYJ_SH = Not blnEditMode
                                '退回文件
                                Me.m_blnTHWJ = Not blnEditMode

                            Case objBaseFlowRenshiShiXiSheng.TASK_XGCL
                                '发送文件
                                Me.m_blnFSWJ = Not blnEditMode
                                '修改文件
                                Me.m_blnXGWJ = Not blnEditMode
                                '填写意见
                                Me.m_blnTXYJ = Not blnEditMode
                                Me.m_blnQSYJ_QF = Not blnEditMode
                                Me.m_blnQSYJ_FH = Not blnEditMode
                                Me.m_blnQSYJ_HQ = Not blnEditMode
                                Me.m_blnQSYJ_SH = Not blnEditMode
                                '退回文件
                                Me.m_blnTHWJ = Not blnEditMode
                                '已签发？
                                If objBaseFlowRenshiShiXiSheng.QFR <> "" Then
                                    '拟稿人？
                                    If Me.isOriginalPeople(strErrMsg, strUserXM, blnDo) = False Then
                                        GoTo errProc
                                    End If
                                    If blnDo = True Then
                                        '文件办结
                                        Me.m_blnWJBJ = Not blnEditMode
                                    End If
                                End If

                            Case objBaseFlowRenshiShiXiSheng.TASK_LDCL
                                '发送文件
                                Me.m_blnFSWJ = Not blnEditMode
                                '修改文件
                                Me.m_blnXGWJ = Not blnEditMode
                                '填写意见
                                Me.m_blnTXYJ = Not blnEditMode
                                Me.m_blnQSYJ_QF = Not blnEditMode
                                Me.m_blnQSYJ_FH = Not blnEditMode
                                Me.m_blnQSYJ_HQ = Not blnEditMode
                                Me.m_blnQSYJ_SH = Not blnEditMode
                                '退回文件
                                Me.m_blnTHWJ = Not blnEditMode

                                Me.m_blnWJBJ = Not blnEditMode

                            Case objBaseFlowRenshiShiXiSheng.TASK_CSWJ
                                '发送文件
                                Me.m_blnFSWJ = Not blnEditMode
                                '退回文件
                                Me.m_blnTHWJ = Not blnEditMode

                                'LJ
                                If Me.doICompleteTask(strErrMsg, strUserXM) = False Then
                                    GoTo errProc
                                End If

                            Case objBaseFlowRenshiShiXiSheng.TASK_MSCL, objBaseFlowRenshiShiXiSheng.TASK_SMCL
                                '发送文件
                                Me.m_blnFSWJ = Not blnEditMode
                                '退回文件
                                Me.m_blnTHWJ = Not blnEditMode

                            Case objBaseFlowRenshiShiXiSheng.TASK_WJGD
                                '发送文件
                                Me.m_blnFSWJ = Not blnEditMode
                                '退回文件
                                Me.m_blnTHWJ = Not blnEditMode
                                '文件办结
                                Me.m_blnWJBJ = Not blnEditMode

                            Case Else
                        End Select
                    Next
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            '后续处理
            Dim strQFRList As String
            Dim strTemp As String
            Try
                '文件办完，不允许改动
                Select Case objBaseFlowRenshiShiXiSheng.BLZT
                    Case objBaseFlowRenshiShiXiSheng.FILESTATUS_YWC
                        Me.m_blnXGWJ = False
                        Me.m_blnEnforeEdit = False
                    Case Else
                End Select
                If Me.m_blnXGWJ = True Then
                    If objBaseFlowRenshiShiXiSheng.QFR <> "" Then
                        strQFRList = objBaseFlowRenshiShiXiSheng.QFR + strSep
                        strTemp = strUserXM + strSep
                        If strQFRList.IndexOf(strTemp) < 0 Then
                            '他人标记强制修改
                            Me.m_blnEnforeEdit = True
                        End If
                    End If
                End If

                '设置其他功能
                Select Case objBaseFlowRenshiShiXiSheng.BLZT
                    Case objBaseFlowRenshiShiXiSheng.FILESTATUS_YWC
                        'zengxianglin 2009-05-16
                        If objBaseFlowRenshiShiXiSheng.QFR <> "" Then
                            Me.m_blnRYLY = Not blnEditMode
                        End If
                        'zengxianglin 2009-05-16
                        Me.m_blnDRQP = False
                        Me.m_blnDRZS = False
                    Case objBaseFlowRenshiShiXiSheng.FILESTATUS_YQP
                        Me.m_blnDRQP = Not blnEditMode
                        Me.m_blnDRZS = Not blnEditMode
                    Case Else
                        Me.m_blnDRQP = False
                        Me.m_blnDRZS = False
                End Select
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.FlowData.SafeRelease(objJiaojieDataWWC)

            getCanExecuteCommand = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.FlowData.SafeRelease(objJiaojieDataWWC)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 根据strWJBS获取“地产_B_人事_实习生审批”的数据集
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
            Try
                Dim objrulesFlowObjectRenshiShiXiSheng As Josco.JSOA.BusinessRules.rulesFlowObjectRenshiShiXiSheng
                objrulesFlowObjectRenshiShiXiSheng = CType(Me.m_objrulesFlowObject, Josco.JSOA.BusinessRules.rulesFlowObjectRenshiShiXiSheng)
                getMainData = objrulesFlowObjectRenshiShiXiSheng.getMainData(strErrMsg, strUserId, strPassword, strWJBS, objestateRenshiXingyeData)
            Catch ex As Exception
                getMainData = False
                strErrMsg = ex.Message
            End Try
        End Function

        '----------------------------------------------------------------
        ' 根据strWJBS获取“地产_B_人事_实习生审批”的数据集
        '     strErrMsg                         ：如果错误，则返回错误信息
        '     objestateRenshiXingyeData         ：信息数据集
        ' 返回
        '     True                              ：成功
        '     False                             ：失败
        '----------------------------------------------------------------
        Public Function getMainData( _
            ByRef strErrMsg As String, _
            ByRef objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            Try
                Dim objrulesFlowObjectRenshiShiXiSheng As Josco.JSOA.BusinessRules.rulesFlowObjectRenshiShiXiSheng
                objrulesFlowObjectRenshiShiXiSheng = CType(Me.m_objrulesFlowObject, Josco.JSOA.BusinessRules.rulesFlowObjectRenshiShiXiSheng)
                getMainData = objrulesFlowObjectRenshiShiXiSheng.getMainData(strErrMsg, objestateRenshiXingyeData)
            Catch ex As Exception
                getMainData = False
                strErrMsg = ex.Message
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
            Try
                Dim objrulesFlowObjectRenshiShiXiSheng As Josco.JSOA.BusinessRules.rulesFlowObjectRenshiShiXiSheng
                objrulesFlowObjectRenshiShiXiSheng = CType(Me.m_objrulesFlowObject, Josco.JSOA.BusinessRules.rulesFlowObjectRenshiShiXiSheng)
                getNewWjxh = objrulesFlowObjectRenshiShiXiSheng.getNewWjxh(strErrMsg, strJGDZ, strWJNF, strWJXH)
            Catch ex As Exception
                strErrMsg = ex.Message
                getNewWjxh = False
            End Try
        End Function

        '----------------------------------------------------------------
        ' 获取“地产_B_人事_实习生审批_人员信息”数据集(以“人员序号”升序排列)
        '     strErrMsg                        ：如果错误，则返回错误信息
        '     strUserXM                        : 人员姓名
        '     objestateRenshiXingyeData        ：返回数据
        ' 返回
        '     True                             ：成功
        '     False                            ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_RYXX( _
            ByRef strErrMsg As String, _
            ByVal strUserXM As String, _
            ByRef objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            Try
                Dim objrulesFlowObjectRenshiShiXiSheng As Josco.JSOA.BusinessRules.rulesFlowObjectRenshiShiXiSheng
                objrulesFlowObjectRenshiShiXiSheng = CType(Me.m_objrulesFlowObject, Josco.JSOA.BusinessRules.rulesFlowObjectRenshiShiXiSheng)
                getDataSet_RYXX = objrulesFlowObjectRenshiShiXiSheng.getDataSet_RYXX(strErrMsg, strUserXM, objestateRenshiXingyeData)
            Catch ex As Exception
                strErrMsg = ex.Message
                getDataSet_RYXX = False
            End Try
        End Function

        '----------------------------------------------------------------
        ' 获取“地产_B_人事_实习生审批_人员信息”数据集(以“人员序号”升序排列)
        '     strErrMsg                        ：如果错误，则返回错误信息
        '     objestateRenshiXingyeData        ：返回数据
        '     blnOption                        ：重载
        ' 返回
        '     True                             ：成功
        '     False                            ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_RYXX( _
            ByRef strErrMsg As String, _
            ByRef objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByVal blnOption As Boolean) As Boolean

            Try
                Dim objrulesFlowObjectRenshiShiXiSheng As Josco.JSOA.BusinessRules.rulesFlowObjectRenshiShiXiSheng
                objrulesFlowObjectRenshiShiXiSheng = CType(Me.m_objrulesFlowObject, Josco.JSOA.BusinessRules.rulesFlowObjectRenshiShiXiSheng)
                getDataSet_RYXX = objrulesFlowObjectRenshiShiXiSheng.getDataSet_RYXX(strErrMsg, objestateRenshiXingyeData, blnOption)
            Catch ex As Exception
                strErrMsg = ex.Message
                getDataSet_RYXX = False
            End Try
        End Function

        '----------------------------------------------------------------
        ' 获取strUserXM能够查看的“地产_B_人事_实习生审批”完全数据的数据集(以“经办日期”降序排序)
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
            Try
                Dim objrulesFlowObjectRenshiShiXiSheng As Josco.JSOA.BusinessRules.rulesFlowObjectRenshiShiXiSheng
                objrulesFlowObjectRenshiShiXiSheng = CType(Me.m_objrulesFlowObject, Josco.JSOA.BusinessRules.rulesFlowObjectRenshiShiXiSheng)
                getDataSet_Main = objrulesFlowObjectRenshiShiXiSheng.getDataSet_Main(strErrMsg, strUserXM, strWhere, objestateRenshiXingyeData)
            Catch ex As Exception
                strErrMsg = ex.Message
                getDataSet_Main = False
            End Try
        End Function




        '----------------------------------------------------------------
        ' 获取strUserXM能够查看的“地产_B_人事_实习生审批_人员信息”完全数据的数据集(以“经办日期”降序排序)
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户ID
        '     strUserXM                  ：用户名称
        '     strWhere                   ：搜索字符串
        '     objestateRenshiXingyeData  ：信息数据集
        '     blnCXY                     : 是否是查询员
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_ListMain( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strUserXM As String, _
            ByVal strWhere As String, _
            ByRef objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByVal blnCXY As Boolean) As Boolean
            Try
                Dim objrulesFlowObjectRenshiShiXiSheng As Josco.JSOA.BusinessRules.rulesFlowObjectRenshiShiXiSheng
                objrulesFlowObjectRenshiShiXiSheng = CType(Me.m_objrulesFlowObject, Josco.JSOA.BusinessRules.rulesFlowObjectRenshiShiXiSheng)
                getDataSet_ListMain = objrulesFlowObjectRenshiShiXiSheng.getDataSet_ListMain(strErrMsg, strUserId, strUserXM, strWhere, objestateRenshiXingyeData, blnCXY)
            Catch ex As Exception
                strErrMsg = ex.Message
                getDataSet_ListMain = False
            End Try
        End Function





    End Class










    '----------------------------------------------------------------
    ' 命名空间：Josco.JsKernal.DataAccess
    ' 类名    ：systemFlowObjectRenshiShiXishengCreator
    '
    ' 功能描述： 
    '     systemFlowObjectRenshiShiXishengCreator的创建接口实现
    '----------------------------------------------------------------
    Public Class systemFlowObjectRenshiShiXishengCreator
        Implements Josco.JSOA.BusinessFacade.ISystemFlowObjectCreate

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
            ByVal strFlowTypeName As String) As Josco.JSOA.BusinessFacade.systemFlowObject _
            Implements Josco.JSOA.BusinessFacade.ISystemFlowObjectCreate.Create

            Try
                Create = New Josco.JSOA.BusinessFacade.systemFlowObjectRenshiShiXisheng
            Catch ex As Exception
                Throw ex
            End Try

        End Function

    End Class

End Namespace


