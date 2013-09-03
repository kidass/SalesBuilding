Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.BusinessFacade
    ' ����    ��IEstateCwSssfSh
    '
    ' ���������� 
    '     estate_cw_sssf_sh.aspxģ����ýӿڵĶ����봦��
    '----------------------------------------------------------------
    <Serializable()> Public Class IEstateCwSssfSh
        Inherits Josco.JsKernal.BusinessFacade.ICallInterface

        '----------------------------------------------------------------
        'QueryString Parameters
        '----------------------------------------------------------------

        '----------------------------------------------------------------
        '�������
        '----------------------------------------------------------------
        Private m_strQRSH_I As String
        'zengxianglin 2010-12-30
        Private m_strSFDM_I As String '��ʽΪ:^sfdm1^,^sfdm2^,^sfdm3^...
        'zengxianglin 2010-12-30

        '----------------------------------------------------------------
        '�������
        '----------------------------------------------------------------
        Private m_blnExitMode_O As Boolean













        '----------------------------------------------------------------
        ' ���캯��
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()

            '��ʼ���������
            MyBase.iInterfaceType = Josco.JsKernal.BusinessFacade.ICallInterface.enumInterfaceType.InputAndOutput

            '��ʼ���������
            m_strQRSH_I = ""
            'zengxianglin 2010-12-30
            Me.m_strSFDM_I = ""
            'zengxianglin 2010-12-30

            '��ʼ���������
            m_blnExitMode_O = False
        End Sub

        '----------------------------------------------------------------
        ' ���ظ������������
        '----------------------------------------------------------------
        Public Overloads Sub Dispose()
            MyBase.Dispose()
            Dispose(True)
        End Sub

        '----------------------------------------------------------------
        ' �ͷű�����Դ
        '----------------------------------------------------------------
        Protected Overloads Sub Dispose(ByVal disposing As Boolean)
            If (Not disposing) Then
                Exit Sub
            End If
        End Sub

        '----------------------------------------------------------------
        ' ��ȫ�ͷű�����Դ
        '----------------------------------------------------------------
        Public Overloads Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IEstateCwSssfSh)
            Try
                If Not (obj Is Nothing) Then
                    obj.Dispose()
                End If
            Catch ex As Exception
            End Try
            obj = Nothing
        End Sub











        '----------------------------------------------------------------
        ' iQRSH����
        '----------------------------------------------------------------
        Public Property iQRSH() As String
            Get
                iQRSH = m_strQRSH_I
            End Get
            Set(ByVal Value As String)
                Try
                    m_strQRSH_I = Value
                Catch ex As Exception
                    m_strQRSH_I = ""
                End Try
            End Set
        End Property

        'zengxianglin 2010-12-30
        '----------------------------------------------------------------
        ' iSFDM����
        '----------------------------------------------------------------
        Public Property iSFDM() As String
            Get
                iSFDM = m_strSFDM_I
            End Get
            Set(ByVal Value As String)
                Try
                    m_strSFDM_I = Value
                Catch ex As Exception
                    m_strSFDM_I = ""
                End Try
            End Set
        End Property
        'zengxianglin 2010-12-30












        '----------------------------------------------------------------
        ' oExitMode����
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

    End Class

End Namespace