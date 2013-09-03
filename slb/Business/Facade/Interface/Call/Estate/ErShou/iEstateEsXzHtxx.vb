Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.BusinessFacade
    ' ����    ��IEstateEsXzHtxx
    '
    ' ���������� 
    '     estate_es_xz_htxx.aspxģ����ýӿڵĶ����봦��
    '----------------------------------------------------------------
    <Serializable()> Public Class IEstateEsXzHtxx
        Inherits Josco.JsKernal.BusinessFacade.ICallInterface

        '----------------------------------------------------------------
        '�������
        '----------------------------------------------------------------
        Private m_blnAllowNull_I As Boolean            '���������?false-����,true-��(ȱʡ)

        '----------------------------------------------------------------
        '�������
        '----------------------------------------------------------------
        Private m_blnExitMode_O As Boolean             '�˳���ʽ��True-ȷ����False-ȡ��
        Private m_strJYBH_O As String                  '��ѡʱ����
        Private m_strHTBH_O As String                  '��ѡʱ����
        Private m_strWYBS_O As String                  '��ѡʱ����
        Private m_strHTWYBS_O As String                '��ѡʱ����








        '----------------------------------------------------------------
        ' ���캯��
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()

            '��ʼ���������
            MyBase.iInterfaceType = Josco.JsKernal.BusinessFacade.ICallInterface.enumInterfaceType.InputAndOutput

            '��ʼ���������
            m_blnAllowNull_I = True

            '��ʼ���������
            m_blnExitMode_O = False
            m_strJYBH_O = ""
            m_strHTBH_O = ""
            m_strWYBS_O = ""
            m_strHTWYBS_O = ""
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
        Public Overloads Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IEstateEsXzHtxx)
            Try
                If Not (obj Is Nothing) Then
                    obj.Dispose()
                End If
            Catch ex As Exception
            End Try
            obj = Nothing
        End Sub












        '----------------------------------------------------------------
        ' iAllowNull����
        '----------------------------------------------------------------
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

        '----------------------------------------------------------------
        ' oJYBH����
        '----------------------------------------------------------------
        Public Property oJYBH() As String
            Get
                oJYBH = m_strJYBH_O
            End Get
            Set(ByVal Value As String)
                Try
                    m_strJYBH_O = Value
                Catch ex As Exception
                    m_strJYBH_O = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' oHTBH����
        '----------------------------------------------------------------
        Public Property oHTBH() As String
            Get
                oHTBH = m_strHTBH_O
            End Get
            Set(ByVal Value As String)
                Try
                    m_strHTBH_O = Value
                Catch ex As Exception
                    m_strHTBH_O = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' oWYBS����
        '----------------------------------------------------------------
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

        '----------------------------------------------------------------
        ' oHTWYBS����
        '----------------------------------------------------------------
        Public Property oHTWYBS() As String
            Get
                oHTWYBS = m_strHTWYBS_O
            End Get
            Set(ByVal Value As String)
                Try
                    m_strHTWYBS_O = Value
                Catch ex As Exception
                    m_strHTWYBS_O = ""
                End Try
            End Set
        End Property

    End Class

End Namespace
