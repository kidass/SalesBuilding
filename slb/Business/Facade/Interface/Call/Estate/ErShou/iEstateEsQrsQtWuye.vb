Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.BusinessFacade
    ' ����    ��IEstateEsQrsQtWuye
    '
    ' ���������� 
    '     estate_es_qrsqt_wuye.aspxģ����ýӿڵĶ����봦��
    '----------------------------------------------------------------
    <Serializable()> Public Class IEstateEsQrsQtWuye
        Inherits Josco.JsKernal.BusinessFacade.ICallInterface

        '----------------------------------------------------------------
        'QueryString Parameters
        '----------------------------------------------------------------

        '----------------------------------------------------------------
        '�������
        '----------------------------------------------------------------
        Private m_objenumEditType_I As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType
        Private m_objValues_I As System.Collections.Specialized.NameValueCollection
        Private m_intSelectedIndex_I As Integer
        Private m_strQRSH_I As String

        '----------------------------------------------------------------
        '�������
        '----------------------------------------------------------------
        Private m_objValues_O As System.Collections.Specialized.NameValueCollection
        Private m_blnExitMode_O As Boolean












        '----------------------------------------------------------------
        ' ���캯��
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()

            '��ʼ���������
            MyBase.iInterfaceType = Josco.JsKernal.BusinessFacade.ICallInterface.enumInterfaceType.InputAndOutput

            '��ʼ���������
            Me.m_objenumEditType_I = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect
            Me.m_intSelectedIndex_I = -1
            Me.m_strQRSH_I = ""
            Me.m_objValues_I = Nothing

            '��ʼ���������
            Me.m_blnExitMode_O = False
            Me.m_objValues_O = Nothing
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
        Public Overloads Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IEstateEsQrsQtWuye)
            Try
                If Not (obj Is Nothing) Then
                    Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(obj.m_objValues_I)
                    Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(obj.m_objValues_O)
                    obj.Dispose()
                End If
            Catch ex As Exception
            End Try
            obj = Nothing
        End Sub









        '----------------------------------------------------------------
        ' iMode����
        '----------------------------------------------------------------
        Public Property iMode() As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType
            Get
                iMode = Me.m_objenumEditType_I
            End Get
            Set(ByVal Value As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType)
                Try
                    Me.m_objenumEditType_I = Value
                Catch ex As Exception
                    Me.m_objenumEditType_I = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' iRowNo����
        '----------------------------------------------------------------
        Public Property iRowNo() As Integer
            Get
                iRowNo = Me.m_intSelectedIndex_I
            End Get
            Set(ByVal Value As Integer)
                Try
                    Me.m_intSelectedIndex_I = Value
                Catch ex As Exception
                    Me.m_intSelectedIndex_I = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' iQRSH����
        '----------------------------------------------------------------
        Public Property iQRSH() As String
            Get
                iQRSH = Me.m_strQRSH_I
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strQRSH_I = Value
                Catch ex As Exception
                    Me.m_strQRSH_I = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' iValues����
        '----------------------------------------------------------------
        Public Property iValues() As System.Collections.Specialized.NameValueCollection
            Get
                iValues = Me.m_objValues_I
            End Get
            Set(ByVal Value As System.Collections.Specialized.NameValueCollection)
                Try
                    Me.m_objValues_I = Value
                Catch ex As Exception
                    Me.m_objValues_I = Nothing
                End Try
            End Set
        End Property









        '----------------------------------------------------------------
        ' oExitMode����
        '----------------------------------------------------------------
        Public Property oExitMode() As Boolean
            Get
                oExitMode = Me.m_blnExitMode_O
            End Get
            Set(ByVal Value As Boolean)
                Try
                    Me.m_blnExitMode_O = Value
                Catch ex As Exception
                    Me.m_blnExitMode_O = False
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' oValues����
        '----------------------------------------------------------------
        Public Property oValues() As System.Collections.Specialized.NameValueCollection
            Get
                oValues = Me.m_objValues_O
            End Get
            Set(ByVal Value As System.Collections.Specialized.NameValueCollection)
                Try
                    Me.m_objValues_O = Value
                Catch ex As Exception
                    Me.m_objValues_O = Nothing
                End Try
            End Set
        End Property

    End Class

End Namespace
