Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.BusinessFacade
    ' ����    ��IEstateCwYsyf
    '
    ' ���������� 
    '     estate_cw_ysyf.aspxģ����ýӿڵĶ����봦��
    '----------------------------------------------------------------
    <Serializable()> Public Class IEstateCwYsyf
        Inherits Josco.JsKernal.BusinessFacade.ICallInterface

        '----------------------------------------------------------------
        'QueryString Parameters
        '----------------------------------------------------------------

        '----------------------------------------------------------------
        '�������
        '----------------------------------------------------------------
        Private m_strQRSH_I As String
        Private m_blnCanModify_I As Boolean

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
            m_blnCanModify_I = False

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
        Public Overloads Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IEstateCwYsyf)
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

        '----------------------------------------------------------------
        ' iCanModify����
        '----------------------------------------------------------------
        Public Property iCanModify() As Boolean
            Get
                iCanModify = Me.m_blnCanModify_I
            End Get
            Set(ByVal Value As Boolean)
                Try
                    Me.m_blnCanModify_I = Value
                Catch ex As Exception
                    Me.m_blnCanModify_I = False
                End Try
            End Set
        End Property











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