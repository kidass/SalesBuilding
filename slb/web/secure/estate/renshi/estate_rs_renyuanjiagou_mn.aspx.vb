Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.web
    ' ����    ��estate_rs_renyuanjiagou_mn
    ' 
    ' �������ʣ�
    '     ��������
    '
    ' ���������� 
    '   ����Ա�ܹ���ʾ����ģ��(����ҳ��)
    '
    ' ���ļ�¼��
    '     zengxianglin 2010-01-02 ����
    '----------------------------------------------------------------

    Partial Class estate_rs_renyuanjiagou_mn
        Inherits Josco.JsKernal.web.PageBase

#Region " Web ������������ɵĴ��� "

        '�õ����� Web ���������������ġ�
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        'ע��: ����ռλ�������� Web ���������������ġ�
        '��Ҫɾ�����ƶ�����
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: �˷��������� Web ����������������
            '��Ҫʹ�ô���༭���޸�����
            InitializeComponent()
        End Sub

#End Region

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim strErrMsg As String = ""
            Dim intBZXL As Integer
            If objsystemEstateRenshiXingye.getBZXL_RSJG(strErrMsg, MyBase.UserId, MyBase.UserPassword, Now.ToString("yyyy-MM-dd HH:mm:ss"), intBZXL) = False Then
                '����
            Else
                Select Case intBZXL
                    Case 1    'ģʽһ
                        Response.Redirect("estate_rs_renyuanjiagou.aspx" + Request.Url.Query)
                    Case 2    'ģʽ��
                        Response.Redirect("estate_rs_renyuanjiagou_x2.aspx" + Request.Url.Query)
                    Case Else '����
                        Response.Redirect("estate_rs_renyuanjiagou_x2.aspx" + Request.Url.Query)
                End Select
            End If
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
        End Sub


    End Class

End Namespace
