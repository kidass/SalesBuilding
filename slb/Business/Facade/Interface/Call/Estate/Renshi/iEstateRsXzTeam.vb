Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.BusinessFacade
    ' ����    ��IEstateRsXzTeam
    '
    ' ���������� 
    '     estate_rs_xz_team.aspxģ����ýӿڵĶ����봦��
    '----------------------------------------------------------------
    <Serializable()> Public Class IEstateRsXzTeam
        Inherits Josco.JsKernal.BusinessFacade.ICallInterface

        '----------------------------------------------------------------
        '�������
        '----------------------------------------------------------------
        Private m_blnMultiSelect_I As Boolean                                   '����ѡ��?false-����,true-��(ȱʡ)
        Private m_blnAllowNull_I As Boolean                                     '�����ֵ?false-����,true-��(ȱʡ)
        Private m_strFixQuery_I As String                                       '��������
        Private m_strJCSJ_I As String                                           '���ʱ��

        '----------------------------------------------------------------
        '�������
        '----------------------------------------------------------------
        Private m_blnExitMode_O As Boolean                                      '�˳���ʽ��True-ȷ����False-ȡ��
        Private m_objDataSet_O As Josco.JSOA.Common.Data.estateRenshiXingyeData 'ѡ�����ݼ�







        '----------------------------------------------------------------
        ' ���캯��
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()

            '��ʼ���������
            MyBase.iInterfaceType = Josco.JsKernal.BusinessFacade.ICallInterface.enumInterfaceType.InputAndOutput

            '��ʼ���������
            m_blnMultiSelect_I = True
            m_blnAllowNull_I = True
            m_strFixQuery_I = ""
            m_strJCSJ_I = ""

            '��ʼ���������
            m_blnExitMode_O = False
            m_objDataSet_O = Nothing
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
            Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(m_objDataSet_O)
        End Sub

        '----------------------------------------------------------------
        ' ��ȫ�ͷű�����Դ
        '----------------------------------------------------------------
        Public Overloads Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IEstateRsXzTeam)
            Try
                If Not (obj Is Nothing) Then
                    obj.Dispose()
                End If
            Catch ex As Exception
            End Try
            obj = Nothing
        End Sub












        '----------------------------------------------------------------
        ' iMultiSelect����
        '----------------------------------------------------------------
        Public Property iMultiSelect() As Boolean
            Get
                iMultiSelect = m_blnMultiSelect_I
            End Get
            Set(ByVal Value As Boolean)
                Try
                    m_blnMultiSelect_I = Value
                Catch ex As Exception
                    m_blnMultiSelect_I = False
                End Try
            End Set
        End Property

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
        ' iFixQuery����
        '----------------------------------------------------------------
        Public Property iFixQuery() As String
            Get
                iFixQuery = m_strFixQuery_I
            End Get
            Set(ByVal Value As String)
                Try
                    m_strFixQuery_I = Value
                Catch ex As Exception
                    m_strFixQuery_I = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' iJCSJ����
        '----------------------------------------------------------------
        Public Property iJCSJ() As String
            Get
                iJCSJ = m_strJCSJ_I
            End Get
            Set(ByVal Value As String)
                Try
                    m_strJCSJ_I = Value
                Catch ex As Exception
                    m_strJCSJ_I = ""
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
        ' oDataSet����
        '----------------------------------------------------------------
        Public Property oDataSet() As Josco.JSOA.Common.Data.estateRenshiXingyeData
            Get
                oDataSet = m_objDataSet_O
            End Get
            Set(ByVal Value As Josco.JSOA.Common.Data.estateRenshiXingyeData)
                Try
                    m_objDataSet_O = Value
                Catch ex As Exception
                    m_objDataSet_O = Nothing
                End Try
            End Set
        End Property

    End Class

End Namespace
