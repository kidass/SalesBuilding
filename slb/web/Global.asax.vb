Imports System.IO
Imports System.Web
Imports System.Web.SessionState
Imports System.Runtime.Remoting

Imports Josco.JsKernal.SystemFramework
Imports Josco.JsKernal.Common
Imports Josco.JsKernal.BusinessFacade

Public Class [Global]
    Inherits System.Web.HttpApplication

#Region " �����������ɵĴ��� "

    Public Sub New()
        MyBase.New()

        '�õ�������������������ġ�
        InitializeComponent()

        '�� InitializeComponent() ����֮������κγ�ʼ��

    End Sub

    '���������������
    Private components As System.ComponentModel.IContainer

    'ע��: ���¹��������������������
    '����ʹ�����������޸Ĵ˹��̡�
    '��Ҫʹ�ô���༭���޸�����
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
    End Sub

#End Region

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' ��Ӧ�ó�������ʱ����
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)

        ' �ڻỰ����ʱ����
        ApplicationConfiguration.OnApplicationStart(Context.Server.MapPath(Context.Request.ApplicationPath))

        'ע����ʵ�ֵĹ�����
        Try
            Dim objsystemFlowObject As Josco.JsKernal.BusinessFacade.systemFlowObject = Nothing
            Dim objsystemFlowObject_l As Josco.JSOA.BusinessFacade.systemFlowObject = Nothing
            Dim strType As String = ""
            Dim strName As String = ""

            '*******************************************************************************************
            ''ע������¼������������
            strType = Josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong.FLOWCODE
            strName = Josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong.FLOWNAME
            objsystemFlowObject = Josco.JsKernal.BusinessFacade.systemFlowObject.Create(strType, strName)
            Josco.JsKernal.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)

            ''ע��������ְ����������
            strType = Josco.JSOA.Common.Workflow.BaseFlowRenshiRuZhi.FLOWCODE
            strName = Josco.JSOA.Common.Workflow.BaseFlowRenshiRuZhi.FLOWNAME
            objsystemFlowObject_l = Josco.JSOA.BusinessFacade.systemFlowObject.Create(strType, strName)
            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject_l)


            ''ע�����µ�������������
            strType = Josco.JSOA.Common.Workflow.BaseFlowRenshiTiaozheng.FLOWCODE
            strName = Josco.JSOA.Common.Workflow.BaseFlowRenshiTiaozheng.FLOWNAME
            objsystemFlowObject_l = Josco.JSOA.BusinessFacade.systemFlowObject.Create(strType, strName)
            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject_l)

            ''ע��������ְ����������
            strType = Josco.JSOA.Common.Workflow.BaseFlowRenshiLiZhi.FLOWCODE
            strName = Josco.JSOA.Common.Workflow.BaseFlowRenshiLiZhi.FLOWNAME
            objsystemFlowObject_l = Josco.JSOA.BusinessFacade.systemFlowObject.Create(strType, strName)
            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject_l)

            ''ע������ʵϰ������������
            strType = Josco.JSOA.Common.Workflow.BaseFlowRenshiShiXiSheng.FLOWCODE
            strName = Josco.JSOA.Common.Workflow.BaseFlowRenshiShiXiSheng.FLOWNAME
            objsystemFlowObject_l = Josco.JSOA.BusinessFacade.systemFlowObject.Create(strType, strName)
            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject_l)

        Catch ex As Exception
        End Try

    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' ��ÿ������ʼʱ����
    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' ���Զ�ʹ�ý��������֤ʱ����
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' �ڷ�������ʱ����
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' �ڻỰ����ʱ����
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' ��Ӧ�ó������ʱ����
    End Sub

End Class
