Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.BusinessFacade
    ' ����    ��IEstateCwXzPiaoju
    '
    ' ���������� 
    '     estate_cw_xz_piaoju.aspxģ����ýӿڵĶ����봦��
    '----------------------------------------------------------------
    <Serializable()> Public Class IEstateCwXzPiaoju
        Inherits Josco.JsKernal.BusinessFacade.ICallInterface

        'zengxianglin 2008-11-22
        Public Enum enumYKPZ
            None = 0
            Ykpz = 1
            Wkpz = 2
        End Enum
        'zengxianglin 2008-11-22

        '----------------------------------------------------------------
        'QueryString Parameters
        '----------------------------------------------------------------

        '----------------------------------------------------------------
        '�������
        '----------------------------------------------------------------
        Private m_blnAllowNull_I As Boolean            '���������?false-����,true-��(ȱʡ)
        Private m_strYWBH_I As String                  'ҵ����
        'zengxianglin 2008-11-22
        Private m_objenumYKPZ As enumYKPZ              '�ѿ�ƾ֤
        'zengxianglin 2008-11-22


        '----------------------------------------------------------------
        '�������
        '----------------------------------------------------------------
        Private m_blnExitMode_O As Boolean             '�˳���ʽ��True-ȷ����False-ȡ��
        Private m_strWYBS_O As String                  '��ѡʱ����














        '----------------------------------------------------------------
        ' ���캯��
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()

            '��ʼ���������
            MyBase.iInterfaceType = Josco.JsKernal.BusinessFacade.ICallInterface.enumInterfaceType.InputAndOutput

            '��ʼ���������
            m_blnAllowNull_I = True
            m_strYWBH_I = ""
            'zengxianglin 2008-11-22
            m_objenumYKPZ = enumYKPZ.None
            'zengxianglin 2008-11-22

            '��ʼ���������
            m_blnExitMode_O = False
            m_strWYBS_O = ""

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
        Public Overloads Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IEstateCwXzPiaoju)
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
        ' iYWBH����
        '----------------------------------------------------------------
        Public Property iYWBH() As String
            Get
                iYWBH = m_strYWBH_I
            End Get
            Set(ByVal Value As String)
                Try
                    m_strYWBH_I = Value
                Catch ex As Exception
                    m_strYWBH_I = ""
                End Try
            End Set
        End Property

        'zengxianglin 2008-11-22
        '----------------------------------------------------------------
        ' iYkpz����
        '----------------------------------------------------------------
        Public Property iYkpz() As enumYKPZ
            Get
                iYkpz = m_objenumYKPZ
            End Get
            Set(ByVal Value As enumYKPZ)
                Try
                    m_objenumYKPZ = Value
                Catch ex As Exception
                    m_objenumYKPZ = enumYKPZ.None
                End Try
            End Set
        End Property
        'zengxianglin 2008-11-22










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

    End Class

End Namespace
