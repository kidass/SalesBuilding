Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.web
    ' 类名    ：estate_rs_renyuanjiagou_mn
    ' 
    ' 调用性质：
    '     独立运行
    '
    ' 功能描述： 
    '   　人员架构显示处理模块(引导页面)
    '
    ' 更改记录：
    '     zengxianglin 2010-01-02 创建
    '----------------------------------------------------------------

    Partial Class estate_rs_renyuanjiagou_mn
        Inherits Josco.JsKernal.web.PageBase

#Region " Web 窗体设计器生成的代码 "

        '该调用是 Web 窗体设计器所必需的。
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        '注意: 以下占位符声明是 Web 窗体设计器所必需的。
        '不要删除或移动它。
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: 此方法调用是 Web 窗体设计器所必需的
            '不要使用代码编辑器修改它。
            InitializeComponent()
        End Sub

#End Region

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim strErrMsg As String = ""
            Dim intBZXL As Integer
            If objsystemEstateRenshiXingye.getBZXL_RSJG(strErrMsg, MyBase.UserId, MyBase.UserPassword, Now.ToString("yyyy-MM-dd HH:mm:ss"), intBZXL) = False Then
                '忽略
            Else
                Select Case intBZXL
                    Case 1    '模式一
                        Response.Redirect("estate_rs_renyuanjiagou.aspx" + Request.Url.Query)
                    Case 2    '模式二
                        Response.Redirect("estate_rs_renyuanjiagou_x2.aspx" + Request.Url.Query)
                    Case Else '其他
                        Response.Redirect("estate_rs_renyuanjiagou_x2.aspx" + Request.Url.Query)
                End Select
            End If
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
        End Sub


    End Class

End Namespace
