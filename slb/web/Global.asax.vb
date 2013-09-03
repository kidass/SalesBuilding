Imports System.IO
Imports System.Web
Imports System.Web.SessionState
Imports System.Runtime.Remoting

Imports Josco.JsKernal.SystemFramework
Imports Josco.JsKernal.Common
Imports Josco.JsKernal.BusinessFacade

Public Class [Global]
    Inherits System.Web.HttpApplication

#Region " 组件设计器生成的代码 "

    Public Sub New()
        MyBase.New()

        '该调用是组件设计器所必需的。
        InitializeComponent()

        '在 InitializeComponent() 调用之后添加任何初始化

    End Sub

    '组件设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是组件设计器所必需的
    '可以使用组件设计器修改此过程。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
    End Sub

#End Region

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' 在应用程序启动时激发
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)

        ' 在会话启动时激发
        ApplicationConfiguration.OnApplicationStart(Context.Server.MapPath(Context.Request.ApplicationPath))

        '注册已实现的工作流
        Try
            Dim objsystemFlowObject As Josco.JsKernal.BusinessFacade.systemFlowObject = Nothing
            Dim objsystemFlowObject_l As Josco.JSOA.BusinessFacade.systemFlowObject = Nothing
            Dim strType As String = ""
            Dim strName As String = ""

            '*******************************************************************************************
            ''注册人事录用审批工作流
            strType = Josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong.FLOWCODE
            strName = Josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong.FLOWNAME
            objsystemFlowObject = Josco.JsKernal.BusinessFacade.systemFlowObject.Create(strType, strName)
            Josco.JsKernal.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)

            ''注册人事入职审批工作流
            strType = Josco.JSOA.Common.Workflow.BaseFlowRenshiRuZhi.FLOWCODE
            strName = Josco.JSOA.Common.Workflow.BaseFlowRenshiRuZhi.FLOWNAME
            objsystemFlowObject_l = Josco.JSOA.BusinessFacade.systemFlowObject.Create(strType, strName)
            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject_l)


            ''注册人事调整审批工作流
            strType = Josco.JSOA.Common.Workflow.BaseFlowRenshiTiaozheng.FLOWCODE
            strName = Josco.JSOA.Common.Workflow.BaseFlowRenshiTiaozheng.FLOWNAME
            objsystemFlowObject_l = Josco.JSOA.BusinessFacade.systemFlowObject.Create(strType, strName)
            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject_l)

            ''注册人事离职审批工作流
            strType = Josco.JSOA.Common.Workflow.BaseFlowRenshiLiZhi.FLOWCODE
            strName = Josco.JSOA.Common.Workflow.BaseFlowRenshiLiZhi.FLOWNAME
            objsystemFlowObject_l = Josco.JSOA.BusinessFacade.systemFlowObject.Create(strType, strName)
            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject_l)

            ''注册人事实习生审批工作流
            strType = Josco.JSOA.Common.Workflow.BaseFlowRenshiShiXiSheng.FLOWCODE
            strName = Josco.JSOA.Common.Workflow.BaseFlowRenshiShiXiSheng.FLOWNAME
            objsystemFlowObject_l = Josco.JSOA.BusinessFacade.systemFlowObject.Create(strType, strName)
            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject_l)

        Catch ex As Exception
        End Try

    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' 在每个请求开始时激发
    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' 尝试对使用进行身份验证时激发
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' 在发生错误时激发
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' 在会话结束时激发
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' 在应用程序结束时激发
    End Sub

End Class
