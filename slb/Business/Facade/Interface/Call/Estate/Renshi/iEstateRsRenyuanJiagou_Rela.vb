Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.BusinessFacade
    ' ����    ��IEstateRsRenyuanJiagou_Rela
    '
    ' ���������� 
    '     estate_rs_renyuanjiagou_rela.aspxģ����ýӿڵĶ����봦��
    '----------------------------------------------------------------
    <Serializable()> Public Class IEstateRsRenyuanJiagou_Rela
        Inherits Josco.JsKernal.BusinessFacade.ICallInterface

        '----------------------------------------------------------------
        'QueryString Parameters
        '----------------------------------------------------------------

        '----------------------------------------------------------------
        '�������
        '----------------------------------------------------------------
        Private m_intMode_I As Integer       '0-һ����ʾ��1-ѡ��ڵ�
        Private m_strTime_I As String        '���ʱ��
        'zengxianglin 2008-10-14
        Private m_blnAllowNull_I As Boolean  'true-����False-������
        'zengxianglin 2008-10-14
        '----------------------------------------------------------------
        '�������
        '----------------------------------------------------------------
        Private m_blnExitMode_O As Boolean 'True-ѡ�����أ�false-ȡ��/�ر�
        Private m_strRYDM_O As String      '���ص���Ա����
        Private m_strWYBS_O As String      '���ص���֯�ܹ�Ψһ��ʶ
        Private m_strRYZM_O As String      '���ص���Ա����












        '----------------------------------------------------------------
        ' ���캯��
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()

            '��ʼ���������
            MyBase.iInterfaceType = Josco.JsKernal.BusinessFacade.ICallInterface.enumInterfaceType.InputAndOutput

            '��ʼ���������
            m_intMode_I = 0
            'zengxianglin 2008-10-14
            m_blnAllowNull_I = False
            'zengxianglin 2008-10-14

            '��ʼ���������
            m_blnExitMode_O = False
            m_strRYDM_O = ""
            m_strWYBS_O = ""
            m_strRYZM_O = ""

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
        Public Overloads Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IEstateRsRenyuanJiagou_Rela)
            Try
                If Not (obj Is Nothing) Then
                    obj.Dispose()
                End If
            Catch ex As Exception
            End Try
            obj = Nothing
        End Sub









        'zengxianglin 2008-10-14
        Public Property iAllowNull() As Boolean
            Get
                iAllowNull = m_blnAllowNull_I
            End Get
            Set(ByVal Value As Boolean)
                Try
                    m_blnAllowNull_I = Value
                Catch ex As Exception
                    m_blnAllowNull_I = False
                End Try
            End Set
        End Property
        'zengxianglin 2008-10-14

        Public Property iMode() As Integer
            Get
                iMode = m_intMode_I
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intMode_I = Value
                Catch ex As Exception
                    m_intMode_I = 0
                End Try
            End Set
        End Property

        Public Property iTime() As String
            Get
                iTime = m_strTime_I
            End Get
            Set(ByVal Value As String)
                Try
                    m_strTime_I = Value
                Catch ex As Exception
                    m_strTime_I = ""
                End Try
            End Set
        End Property









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

        Public Property oRYDM() As String
            Get
                oRYDM = m_strRYDM_O
            End Get
            Set(ByVal Value As String)
                Try
                    m_strRYDM_O = Value
                Catch ex As Exception
                    m_strRYDM_O = ""
                End Try
            End Set
        End Property

        Public Property oRYZM() As String
            Get
                oRYZM = m_strRYZM_O
            End Get
            Set(ByVal Value As String)
                Try
                    m_strRYZM_O = Value
                Catch ex As Exception
                    m_strRYZM_O = ""
                End Try
            End Set
        End Property

        Public Property oWYBS() As String
            Get
                oWYBS = m_strWYBS_O
            End Get
            Set(ByVal Value As String)
                Try
                    m_strWYBS_O = Value
                Catch ex As Exception
                    m_strWYBS_O = ""
                End Try
            End Set
        End Property

    End Class

End Namespace
