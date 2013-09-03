Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.BusinessFacade
    ' ����    ��IEstateRsLuyongInfo
    '
    ' ���������� 
    '     estate_rs_luyong_info.aspxģ����ýӿڵĶ����봦��
    '----------------------------------------------------------------
    <Serializable()> Public Class IEstateRsLuyongInfo
        Inherits Josco.JsKernal.BusinessFacade.ICallInterface

        '----------------------------------------------------------------
        '�������
        '----------------------------------------------------------------
        Private m_objMode_I As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType '�༭ģʽ
        Private m_strWJBS_I As String                                                   '�ļ���ʶ

        '----------------------------------------------------------------
        '�������
        '----------------------------------------------------------------
        Private m_blnExitMode_O As Boolean '���ط�ʽ��True-ȷ����False-ȡ��












        '----------------------------------------------------------------
        ' ���캯��
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()

            '��ʼ���������
            MyBase.iInterfaceType = Josco.JsKernal.BusinessFacade.ICallInterface.enumInterfaceType.InputAndOutput

            '��ʼ���������
            m_strWJBS_I = ""
            m_objMode_I = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect

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
        Public Overloads Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IEstateRsLuyongInfo)
            Try
                If Not (obj Is Nothing) Then
                    obj.Dispose()
                End If
            Catch ex As Exception
            End Try
            obj = Nothing
        End Sub












        '----------------------------------------------------------------
        ' iWJBS����
        '----------------------------------------------------------------
        Public Property iWJBS() As String
            Get
                iWJBS = m_strWJBS_I
            End Get
            Set(ByVal Value As String)
                Try
                    m_strWJBS_I = Value
                Catch ex As Exception
                    m_strWJBS_I = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' iEditMode����
        '----------------------------------------------------------------
        Public Property iEditMode() As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType
            Get
                iEditMode = m_objMode_I
            End Get
            Set(ByVal Value As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType)
                Try
                    m_objMode_I = Value
                Catch ex As Exception
                    m_objMode_I = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect
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
