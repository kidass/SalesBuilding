Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.web
    ' 类名    ：estate_es_qrsqt_wuye
    ' 
    ' 调用性质：
    '     I/O
    '
    ' 功能描述： 
    '   　“其他确认书物业信息”处理模块
    '
    ' 更改描述：
    '      zengxianglin 2008-11-17 创建
    '      zengxianglin 2010-12-26 更改
    '----------------------------------------------------------------

    Partial Class estate_es_qrsqt_wuye
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

        '----------------------------------------------------------------
        '模块私用参数
        '----------------------------------------------------------------
        '本模块相对image的相对路径
        Private m_cstrRelativePathToImage As String = "../../../"

        '----------------------------------------------------------------
        '模块授权参数
        '----------------------------------------------------------------

        '----------------------------------------------------------------
        '模块现场保留参数，恢复完成后立即释放session资源
        '----------------------------------------------------------------
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMEstateEsQrsQtWuye
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        '模块接口参数
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IEstateEsQrsQtWuye
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '当前处理的数据集
        '----------------------------------------------------------------

        '----------------------------------------------------------------
        '模块接口参数
        '----------------------------------------------------------------
        Private m_objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType
        Private m_objValues As System.Collections.Specialized.NameValueCollection
        Private m_blnEditMode As Boolean











        Private Sub doGoBack(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                Dim strSessionId As String
                Dim strUrl As String
                strSessionId = Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                If strSessionId Is Nothing Then strSessionId = ""
                If strSessionId <> "" Then
                    Try
                        Me.m_objInterface = CType(Session(strSessionId), Josco.JSOA.BusinessFacade.IEstateEsQrsQtWuye)
                    Catch ex As Exception
                        Me.m_objInterface = Nothing
                    End Try
                Else
                    Me.m_objInterface = Nothing
                End If
                If Not (Me.m_objInterface Is Nothing) Then
                    '设置返回参数
                    Me.m_objInterface.oExitMode = False
                    '返回到调用模块，并附加返回参数
                    '要返回的SessionId
                    strSessionId = Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    'SessionId附加到返回的Url
                    strUrl = Me.m_objInterface.getReturnUrl(Server, Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId, strSessionId)
                Else
                    strUrl = Josco.JsKernal.Common.jsoaConfiguration.GeneralReturnUrl
                End If
                '释放模块资源
                Me.releaseModuleParameters()
                Me.releaseInterfaceParameters()
                '返回
                If strUrl <> "" Then
                    Response.Redirect(strUrl)
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub btnGoBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGoBack.Click
            Me.doGoBack("btnGoBack")
        End Sub










        '----------------------------------------------------------------
        ' 复原模块现场信息并释放相应的资源
        '----------------------------------------------------------------
        Private Sub restoreModuleInformation(ByVal strSessionId As String)

            Try
                If Me.m_objSaveScence Is Nothing Then
                    Exit Try
                End If

                With Me.m_objSaveScence
                    Me.htxtDivLeftBody.Value = .htxtDivLeftBody
                    Me.htxtDivTopBody.Value = .htxtDivTopBody
                    Me.htxtDivLeftMain.Value = .htxtDivLeftMain
                    Me.htxtDivTopMain.Value = .htxtDivTopMain

                    Try
                        Me.ddlZX.SelectedIndex = .ddlZX_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.ddlJG.SelectedIndex = .ddlJG_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.ddlWYXZ.SelectedIndex = .ddlWYXZ_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.ddlSZQY.SelectedIndex = .ddlSZQY_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Me.htxtWYBS.Value = .htxtWYBS
                    Me.htxtWYBM.Value = .htxtWYBM
                    Me.txtQRSH.Text = .txtQRSH

                    Me.txtFWDZ.Text = .txtFWDZ
                    Me.txtFCZH.Text = .txtFCZH
                    Me.txtFCZDZ.Text = .txtFCZDZ
                    Me.txtLC.Text = .txtLC
                    Me.txtLL.Text = .txtLL
                    Me.txtBZXX.Text = .txtBZXX
                    Me.txtMJ.Text = .txtMJ
                    Me.txtJYJE.Text = .txtJYJE

                    'zengxianglin 2010-12-26
                    Me.txtFYBH.Text = .txtFYBH
                    Me.txtLP.Text = .txtLP
                    Me.txtLD.Text = .txtLD
                    Me.txtDY.Text = .txtDY
                    Me.txtJCSJ.Text = .txtJCSJ
                    Me.txtLG.Text = .txtLG
                    Me.txtDTSL.Text = .txtDTSL
                    Me.txtLCHS.Text = .txtLCHS
                    Me.txtLPQS.Text = .txtLPQS
                    Me.txtJGFS.Text = .txtJGFS
                    Me.txtWSSL.Text = .txtWSSL
                    Me.txtYTSL.Text = .txtYTSL
                    Me.rblKJLX.SelectedIndex = .rblKJLX_SelectedIndex
                    Me.rblFWXZ.SelectedIndex = .rblFWXZ_SelectedIndex
                    Me.rblCX.SelectedIndex = .rblCX_SelectedIndex
                    Me.rblWYSX.SelectedIndex = .rblWYSX_SelectedIndex
                    Me.rblZXDC.SelectedIndex = .rblZXDC_SelectedIndex
                    Me.rblZXNX.SelectedIndex = .rblZXNX_SelectedIndex
                    Me.rblZYYX.SelectedIndex = .rblZYYX_SelectedIndex
                    Me.rblJJSB.SelectedIndex = .rblJJSB_SelectedIndex
                    Me.rblLYJT.SelectedIndex = .rblLYJT_SelectedIndex
                    Me.rblFWJG.SelectedIndex = .rblFWJG_SelectedIndex
                    Me.rblJGLX.SelectedIndex = .rblJGLX_SelectedIndex
                    'zengxianglin 2010-12-26
                End With

                '释放资源
                Session.Remove(strSessionId)
                Me.m_objSaveScence.Dispose()
                Me.m_objSaveScence = Nothing
            Catch ex As Exception
            End Try

            Exit Sub

        End Sub

        '----------------------------------------------------------------
        ' 保存模块现场信息并返回相应的SessionId
        '----------------------------------------------------------------
        Private Function saveModuleInformation() As String

            Dim strSessionId As String = ""

            saveModuleInformation = ""

            Try
                '创建SessionId
                With New Josco.JsKernal.Common.Utilities.PulicParameters
                    strSessionId = .getNewGuid()
                End With
                If strSessionId = "" Then
                    Exit Try
                End If

                '创建对象
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMEstateEsQrsQtWuye

                '保存现场信息
                With Me.m_objSaveScence
                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftMain = Me.htxtDivLeftMain.Value
                    .htxtDivTopMain = Me.htxtDivTopMain.Value

                    .ddlZX_SelectedIndex = Me.ddlZX.SelectedIndex
                    .ddlJG_SelectedIndex = Me.ddlJG.SelectedIndex
                    .ddlWYXZ_SelectedIndex = Me.ddlWYXZ.SelectedIndex
                    .ddlSZQY_SelectedIndex = Me.ddlSZQY.SelectedIndex

                    .htxtWYBS = Me.htxtWYBS.Value
                    .htxtWYBM = Me.htxtWYBM.Value
                    .txtQRSH = Me.txtQRSH.Text

                    .txtFCZH = Me.txtFCZH.Text
                    .txtFWDZ = Me.txtFWDZ.Text
                    .txtFCZDZ = Me.txtFCZDZ.Text
                    .txtLC = Me.txtLC.Text
                    .txtLL = Me.txtLL.Text
                    .txtBZXX = Me.txtBZXX.Text
                    .txtMJ = Me.txtMJ.Text
                    .txtJYJE = Me.txtJYJE.Text

                    'zengxianglin 2010-12-26
                    .txtFYBH = Me.txtFYBH.Text
                    .txtLP = Me.txtLP.Text
                    .txtLD = Me.txtLD.Text
                    .txtDY = Me.txtDY.Text
                    .txtJCSJ = Me.txtJCSJ.Text
                    .txtLG = Me.txtLG.Text
                    .txtDTSL = Me.txtDTSL.Text
                    .txtLCHS = Me.txtLCHS.Text
                    .txtLPQS = Me.txtLPQS.Text
                    .txtJGFS = Me.txtJGFS.Text
                    .txtWSSL = Me.txtWSSL.Text
                    .txtYTSL = Me.txtYTSL.Text
                    .rblKJLX_SelectedIndex = Me.rblKJLX.SelectedIndex
                    .rblFWXZ_SelectedIndex = Me.rblFWXZ.SelectedIndex
                    .rblCX_SelectedIndex = Me.rblCX.SelectedIndex
                    .rblWYSX_SelectedIndex = Me.rblWYSX.SelectedIndex
                    .rblZXDC_SelectedIndex = Me.rblZXDC.SelectedIndex
                    .rblZXNX_SelectedIndex = Me.rblZXNX.SelectedIndex
                    .rblZYYX_SelectedIndex = Me.rblZYYX.SelectedIndex
                    .rblJJSB_SelectedIndex = Me.rblJJSB.SelectedIndex
                    .rblLYJT_SelectedIndex = Me.rblLYJT.SelectedIndex
                    .rblFWJG_SelectedIndex = Me.rblFWJG.SelectedIndex
                    .rblJGLX_SelectedIndex = Me.rblJGLX.SelectedIndex
                    'zengxianglin 2010-12-26
                End With

                '缓存对象
                Session.Add(strSessionId, Me.m_objSaveScence)
            Catch ex As Exception
            End Try

            saveModuleInformation = strSessionId
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 从调用模块中获取数据
        '----------------------------------------------------------------
        Private Function getDataFromCallModule(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getDataFromCallModule = False

            Try
                If Me.IsPostBack = True Then
                    Exit Try
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getDataFromCallModule = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 释放接口参数
        '----------------------------------------------------------------
        Private Sub releaseInterfaceParameters()

            Try
                If Not (Me.m_objInterface Is Nothing) Then
                    If Me.m_objInterface.iInterfaceType = Josco.JsKernal.BusinessFacade.ICallInterface.enumInterfaceType.InputOnly Then
                        Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId))
                        Me.m_objInterface.Dispose()
                        Me.m_objInterface = Nothing
                    End If
                End If
            Catch ex As Exception
            End Try

            Exit Sub

        End Sub

        '----------------------------------------------------------------
        ' 获取接口参数
        '----------------------------------------------------------------
        Private Function getInterfaceParameters( _
            ByRef strErrMsg As String, _
            ByRef blnContinue As Boolean) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getInterfaceParameters = False
            blnContinue = True

            Try
                '从QueryString中解析接口参数(不论是否回发)
                Dim objTemp As Object = Nothing
                Try
                    objTemp = Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId))
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IEstateEsQrsQtWuye)
                Catch ex As Exception
                    m_objInterface = Nothing
                End Try
                If m_objInterface Is Nothing Then
                    Me.m_blnInterface = False
                    '没有有接口参数
                    Me.m_objenumEditType = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect
                    Me.m_objValues = Nothing
                Else
                    Me.m_blnInterface = True
                    '有接口参数
                    Me.m_objenumEditType = Me.m_objInterface.iMode
                    Me.m_objValues = Me.m_objInterface.iValues
                End If
                Select Case Me.m_objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                        Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew, _
                        Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate
                        Me.m_blnEditMode = True
                    Case Else
                        Me.m_blnEditMode = False
                End Select
                If Me.m_blnInterface = False Then
                    blnContinue = False
                    Me.panelError.Visible = False
                    Me.panelMain.Visible = Not Me.panelError.Visible
                    Me.lblMessage.Text = "错误：没有提供本模块需要的接口！"
                    Exit Try
                End If

                '获取恢复现场参数
                If Me.IsPostBack = False Then
                    Dim strSessionId As String
                    strSessionId = objPulicParameters.getObjectValue(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId), "")
                    Try
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMEstateEsQrsQtWuye)
                    Catch ex As Exception
                        Me.m_objSaveScence = Nothing
                    End Try
                    If Me.m_objSaveScence Is Nothing Then
                        Me.m_blnSaveScence = False
                    Else
                        Me.m_blnSaveScence = True
                    End If

                    '恢复现场参数后释放该资源
                    Me.restoreModuleInformation(strSessionId)

                    '处理调用模块返回后的信息并同时释放相应资源
                    If Me.getDataFromCallModule(strErrMsg) = False Then
                        GoTo errProc
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getInterfaceParameters = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 释放本模块缓存的参数
        '----------------------------------------------------------------
        Private Sub releaseModuleParameters()

            Dim strErrMsg As String = ""

            Try

            Catch ex As Exception
            End Try

            Exit Sub

        End Sub













        '----------------------------------------------------------------
        ' 显示模块主信息
        '     strErrMsg      ：返回错误信息
        '     blnEditMode    ：编辑模式
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showEditPanel_MAIN( _
            ByRef strErrMsg As String, _
            ByVal blnEditMode As Boolean) As Boolean

            Dim objRadioButtonListProcess As New Josco.JsKernal.web.RadioButtonListProcess
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDropDownListProcess As New Josco.JsKernal.web.DropDownListProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showEditPanel_MAIN = False
            strErrMsg = ""

            Try
                '显示值
                Dim strValue As String = ""
                Dim intValue As Integer = 0
                If Me.IsPostBack = False And Me.m_blnSaveScence = False Then
                    If Me.m_objValues Is Nothing Then
                        '设置空值
                        Me.ddlZX.SelectedIndex = -1
                        Me.ddlJG.SelectedIndex = -1
                        Me.ddlWYXZ.SelectedIndex = -1
                        Me.ddlSZQY.SelectedIndex = -1

                        Me.htxtWYBS.Value = ""
                        Me.htxtWYBM.Value = ""
                        Me.txtQRSH.Text = ""

                        Me.txtFCZH.Text = ""
                        Me.txtFWDZ.Text = ""
                        Me.txtFCZDZ.Text = ""
                        Me.txtLC.Text = ""
                        Me.txtLL.Text = ""
                        Me.txtBZXX.Text = ""
                        Me.txtMJ.Text = ""
                        Me.txtJYJE.Text = ""

                        'zengxianglin 2010-12-26
                        Me.txtFYBH.Text = ""
                        Me.txtLP.Text = ""
                        Me.txtLD.Text = ""
                        Me.txtDY.Text = ""
                        Me.txtJCSJ.Text = ""
                        Me.txtLG.Text = ""
                        Me.txtDTSL.Text = ""
                        Me.txtLCHS.Text = ""
                        Me.txtLPQS.Text = ""
                        Me.txtJGFS.Text = ""
                        Me.txtWSSL.Text = ""
                        Me.txtYTSL.Text = ""
                        Me.rblKJLX.SelectedIndex = -1
                        Me.rblFWXZ.SelectedIndex = -1
                        Me.rblCX.SelectedIndex = -1
                        Me.rblWYSX.SelectedIndex = -1
                        Me.rblZXDC.SelectedIndex = -1
                        Me.rblZXNX.SelectedIndex = -1
                        Me.rblZYYX.SelectedIndex = -1
                        Me.rblJJSB.SelectedIndex = -1
                        Me.rblLYJT.SelectedIndex = -1
                        Me.rblFWJG.SelectedIndex = -1
                        Me.rblJGLX.SelectedIndex = -1
                        'zengxianglin 2010-12-26
                    Else
                        'zengxianglin 2010-12-26
                        'strValue = objPulicParameters.getObjectValue(Me.m_objValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_ZX), "")
                        'Me.ddlZX.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlZX, strValue)
                        'zengxianglin 2010-12-26
                        strValue = objPulicParameters.getObjectValue(Me.m_objValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_JG), "")
                        Me.ddlJG.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlJG, strValue)
                        'zengxianglin 2010-12-26
                        'strValue = objPulicParameters.getObjectValue(Me.m_objValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_WYXZ), "")
                        'Me.ddlWYXZ.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlWYXZ, strValue)
                        'zengxianglin 2010-12-26
                        strValue = objPulicParameters.getObjectValue(Me.m_objValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_SZQY), "")
                        Me.ddlSZQY.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlSZQY, strValue)

                        Me.htxtWYBS.Value = objPulicParameters.getObjectValue(Me.m_objValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_WYBS), "")
                        Me.htxtWYBM.Value = objPulicParameters.getObjectValue(Me.m_objValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_WYBM), "")
                        Me.txtQRSH.Text = objPulicParameters.getObjectValue(Me.m_objValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_QRSH), "")

                        Me.txtFWDZ.Text = objPulicParameters.getObjectValue(Me.m_objValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_FWDZ), "")
                        Me.txtFCZH.Text = objPulicParameters.getObjectValue(Me.m_objValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_FCZH), "")
                        Me.txtFCZDZ.Text = objPulicParameters.getObjectValue(Me.m_objValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_FCZDZ), "")
                        Me.txtLC.Text = objPulicParameters.getObjectValue(Me.m_objValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_LC), "")
                        Me.txtLL.Text = objPulicParameters.getObjectValue(Me.m_objValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_LL), "")
                        Me.txtBZXX.Text = objPulicParameters.getObjectValue(Me.m_objValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_BZXX), "")
                        Me.txtMJ.Text = objPulicParameters.getObjectValue(Me.m_objValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_MJ), 0.0).ToString("#,###.00")
                        Me.txtJYJE.Text = objPulicParameters.getObjectValue(Me.m_objValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_JYJE), 0.0).ToString("#,###.00")

                        'zengxianglin 2010-12-26
                        Me.txtFYBH.Text = objPulicParameters.getObjectValue(Me.m_objValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_FYBH), "")
                        Me.txtLP.Text = objPulicParameters.getObjectValue(Me.m_objValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_LP), "")
                        Me.txtLD.Text = objPulicParameters.getObjectValue(Me.m_objValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_LD), "")
                        Me.txtDY.Text = objPulicParameters.getObjectValue(Me.m_objValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_DY), "")
                        Me.txtJCSJ.Text = objPulicParameters.getObjectValue(Me.m_objValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_JCSJ), "", "yyyy-MM-dd")
                        Me.txtLG.Text = objPulicParameters.getObjectValue(Me.m_objValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_LG), "")
                        Me.txtDTSL.Text = objPulicParameters.getObjectValue(Me.m_objValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_DTSL), "")
                        Me.txtLCHS.Text = objPulicParameters.getObjectValue(Me.m_objValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_LCHS), "")
                        Me.txtLPQS.Text = objPulicParameters.getObjectValue(Me.m_objValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_LPQS), "")
                        Me.txtJGFS.Text = objPulicParameters.getObjectValue(Me.m_objValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_JGFS), "")
                        Me.txtWSSL.Text = objPulicParameters.getObjectValue(Me.m_objValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_WSSL), "")
                        Me.txtYTSL.Text = objPulicParameters.getObjectValue(Me.m_objValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_YTSL), "")
                        strValue = objPulicParameters.getObjectValue(Me.m_objValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_KJLX), "")
                        Me.rblKJLX.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblKJLX, strValue)
                        strValue = objPulicParameters.getObjectValue(Me.m_objValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_FWXZ), "")
                        Me.rblFWXZ.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblFWXZ, strValue)
                        strValue = objPulicParameters.getObjectValue(Me.m_objValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_ZX), "")
                        Me.rblCX.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblCX, strValue)
                        strValue = objPulicParameters.getObjectValue(Me.m_objValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_WYXZ), "")
                        Me.rblWYSX.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblWYSX, strValue)
                        strValue = objPulicParameters.getObjectValue(Me.m_objValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_ZXDC), "")
                        Me.rblZXDC.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblZXDC, strValue)
                        strValue = objPulicParameters.getObjectValue(Me.m_objValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_ZXNX), "")
                        Me.rblZXNX.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblZXNX, strValue)
                        strValue = objPulicParameters.getObjectValue(Me.m_objValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_ZYYX), "")
                        Me.rblZYYX.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblZYYX, strValue)
                        strValue = objPulicParameters.getObjectValue(Me.m_objValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_JJSB), "")
                        Me.rblJJSB.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblJJSB, strValue)
                        strValue = objPulicParameters.getObjectValue(Me.m_objValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_LYJT), "")
                        Me.rblLYJT.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblLYJT, strValue)
                        strValue = objPulicParameters.getObjectValue(Me.m_objValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_FWJG), "")
                        Me.rblFWJG.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblFWJG, strValue)
                        strValue = objPulicParameters.getObjectValue(Me.m_objValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_JGLX), "")
                        Me.rblJGLX.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblJGLX, strValue)
                        'zengxianglin 2010-12-26
                    End If
                End If

                '操作控制
                objControlProcess.doEnabledControl(Me.ddlZX, blnEditMode)
                objControlProcess.doEnabledControl(Me.ddlJG, blnEditMode)
                objControlProcess.doEnabledControl(Me.ddlWYXZ, blnEditMode)
                objControlProcess.doEnabledControl(Me.ddlSZQY, blnEditMode)

                objControlProcess.doEnabledControl(Me.txtQRSH, False)
                objControlProcess.doEnabledControl(Me.txtFCZH, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtFWDZ, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtFCZDZ, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtLC, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtLL, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtBZXX, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtMJ, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtJYJE, blnEditMode)

                'zengxianglin 2010-12-26
                objControlProcess.doEnabledControl(Me.txtFYBH, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtLP, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtLD, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtDY, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtJCSJ, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtLG, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtDTSL, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtLCHS, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtLPQS, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtJGFS, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtWSSL, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtYTSL, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblKJLX, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblFWXZ, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblCX, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblWYSX, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblZXDC, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblZXNX, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblZYYX, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblJJSB, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblLYJT, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblFWJG, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblJGLX, blnEditMode)
                'zengxianglin 2010-12-26
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showEditPanel_MAIN = True
            Exit Function
errProc:
            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示模块其他信息
        '     strErrMsg      ：返回错误信息
        '     blnEditMode    ：编辑模式
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleData_MAIN( _
            ByRef strErrMsg As String, _
            ByVal blnEditMode As Boolean) As Boolean

            showModuleData_MAIN = False

            Try
                Me.btnOK.Visible = blnEditMode
                Me.btnCancel.Visible = blnEditMode

                Me.btnClose.Visible = Not blnEditMode
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            showModuleData_MAIN = True
            Exit Function
errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 填充物业间隔下拉列表框
        '     strErrMsg      ：返回错误信息
        '     objDropDownList：要填充的列表框
        '     blnAddBlank    ：添加空白条目
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function doFillWyjgList( _
            ByRef strErrMsg As String, _
            ByVal objDropDownList As System.Web.UI.WebControls.DropDownList, _
            ByVal blnAddBlank As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateCommonData.TABLE_DC_B_GG_WUYEJIANGE
            Dim objsystemEstateCommon As New Josco.JSOA.BusinessFacade.systemEstateCommon
            Dim objestateCommonData As Josco.JSOA.Common.Data.estateCommonData = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            doFillWyjgList = False
            strErrMsg = ""

            Try
                '检查
                If objDropDownList Is Nothing Then
                    strErrMsg = "错误：[doFillWyjgList]接口参数不正确！"
                    GoTo errProc
                End If

                '获取数据
                Dim strWhere As String = ""
                If objsystemEstateCommon.getDataSet_WuyeJiange(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWhere, objestateCommonData) = False Then
                    GoTo errProc
                End If

                '清空现有列表
                objDropDownList.Items.Clear()
                If blnAddBlank = True Then
                    objDropDownList.Items.Add("")
                End If

                '填充数据
                Dim objListItem As System.Web.UI.WebControls.ListItem = Nothing
                Dim strCode As String = ""
                Dim strName As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                With objestateCommonData.Tables(strTable)
                    intCount = .Rows.Count
                    For i = 0 To intCount - 1 Step 1
                        strCode = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_WUYEJIANGE_WYJGDM), "")
                        strName = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_WUYEJIANGE_WYJGMC), "")

                        objListItem = New System.Web.UI.WebControls.ListItem
                        objListItem.Text = strCode + "|" + strName
                        objListItem.Value = strCode
                        objDropDownList.Items.Add(objListItem)
                    Next
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateCommon.SafeRelease(objsystemEstateCommon)
            Josco.JSOA.Common.Data.estateCommonData.SafeRelease(objestateCommonData)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            doFillWyjgList = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateCommon.SafeRelease(objsystemEstateCommon)
            Josco.JSOA.Common.Data.estateCommonData.SafeRelease(objestateCommonData)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 填充物业性质下拉列表框
        '     strErrMsg      ：返回错误信息
        '     objDropDownList：要填充的列表框
        '     blnAddBlank    ：添加空白条目
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function doFillWyxzList( _
            ByRef strErrMsg As String, _
            ByVal objDropDownList As System.Web.UI.WebControls.DropDownList, _
            ByVal blnAddBlank As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateCommonData.TABLE_DC_B_GG_WUYEXINGZHI
            Dim objsystemEstateCommon As New Josco.JSOA.BusinessFacade.systemEstateCommon
            Dim objestateCommonData As Josco.JSOA.Common.Data.estateCommonData = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            doFillWyxzList = False
            strErrMsg = ""

            Try
                '检查
                If objDropDownList Is Nothing Then
                    strErrMsg = "错误：[doFillWyxzList]接口参数不正确！"
                    GoTo errProc
                End If

                '获取数据
                Dim strWhere As String = ""
                If objsystemEstateCommon.getDataSet_WuyeXingzhi_List(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWhere, objestateCommonData) = False Then
                    GoTo errProc
                End If

                '清空现有列表
                objDropDownList.Items.Clear()
                If blnAddBlank = True Then
                    objDropDownList.Items.Add("")
                End If

                '填充数据
                Dim objListItem As System.Web.UI.WebControls.ListItem = Nothing
                Dim strCode As String = ""
                Dim strName As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                With objestateCommonData.Tables(strTable)
                    intCount = .Rows.Count
                    For i = 0 To intCount - 1 Step 1
                        strCode = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_WUYEXINGZHI_WYXZDM), "")
                        strName = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_WUYEXINGZHI_WYXZMC), "")

                        objListItem = New System.Web.UI.WebControls.ListItem
                        objListItem.Text = strCode + "|" + strName
                        objListItem.Value = strCode
                        objDropDownList.Items.Add(objListItem)
                    Next
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateCommon.SafeRelease(objsystemEstateCommon)
            Josco.JSOA.Common.Data.estateCommonData.SafeRelease(objestateCommonData)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            doFillWyxzList = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateCommon.SafeRelease(objsystemEstateCommon)
            Josco.JSOA.Common.Data.estateCommonData.SafeRelease(objestateCommonData)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 填充物业性质列表框
        '     strErrMsg         ：返回错误信息
        '     objRadioButtonList：要填充的列表框
        '     blnAddBlank       ：添加空白条目
        ' 返回
        '     True              ：成功
        '     False             ：失败
        ' 更改
        '     zengxianglin 2010-12-26 创建
        '----------------------------------------------------------------
        Private Function doFillWyxzList( _
            ByRef strErrMsg As String, _
            ByVal objRadioButtonList As System.Web.UI.WebControls.RadioButtonList, _
            ByVal blnAddBlank As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateCommonData.TABLE_DC_B_GG_WUYEXINGZHI
            Dim objsystemEstateCommon As New Josco.JSOA.BusinessFacade.systemEstateCommon
            Dim objestateCommonData As Josco.JSOA.Common.Data.estateCommonData = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            doFillWyxzList = False
            strErrMsg = ""

            Try
                '检查
                If objRadioButtonList Is Nothing Then
                    strErrMsg = "错误：[doFillWyxzList]接口参数不正确！"
                    GoTo errProc
                End If

                '获取数据
                Dim strWhere As String = ""
                If objsystemEstateCommon.getDataSet_WuyeXingzhi_List(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWhere, objestateCommonData) = False Then
                    GoTo errProc
                End If

                '清空现有列表
                objRadioButtonList.Items.Clear()
                If blnAddBlank = True Then
                    objRadioButtonList.Items.Add("")
                End If

                '填充数据
                Dim objListItem As System.Web.UI.WebControls.ListItem = Nothing
                Dim strCode As String = ""
                Dim strName As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                With objestateCommonData.Tables(strTable)
                    intCount = .Rows.Count
                    For i = 0 To intCount - 1 Step 1
                        strCode = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_WUYEXINGZHI_WYXZDM), "")
                        strName = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_WUYEXINGZHI_WYXZMC), "")

                        objListItem = New System.Web.UI.WebControls.ListItem
                        objListItem.Text = strName
                        objListItem.Value = strCode
                        objRadioButtonList.Items.Add(objListItem)
                    Next
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateCommon.SafeRelease(objsystemEstateCommon)
            Josco.JSOA.Common.Data.estateCommonData.SafeRelease(objestateCommonData)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            doFillWyxzList = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateCommon.SafeRelease(objsystemEstateCommon)
            Josco.JSOA.Common.Data.estateCommonData.SafeRelease(objestateCommonData)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 填充所在区域下拉列表框
        '     strErrMsg      ：返回错误信息
        '     objDropDownList：要填充的列表框
        '     blnAddBlank    ：添加空白条目
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function doFillSzqyList( _
            ByRef strErrMsg As String, _
            ByVal objDropDownList As System.Web.UI.WebControls.DropDownList, _
            ByVal blnAddBlank As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateCommonData.TABLE_DC_B_GG_QUYUHUAFEN
            Dim objsystemEstateCommon As New Josco.JSOA.BusinessFacade.systemEstateCommon
            Dim objestateCommonData As Josco.JSOA.Common.Data.estateCommonData = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            doFillSzqyList = False
            strErrMsg = ""

            Try
                '检查
                If objDropDownList Is Nothing Then
                    strErrMsg = "错误：[doFillSzqyList]接口参数不正确！"
                    GoTo errProc
                End If

                '获取数据
                Dim strWhere As String = ""
                If objsystemEstateCommon.getDataSet_QuyuHuafen(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWhere, objestateCommonData) = False Then
                    GoTo errProc
                End If

                '清空现有列表
                objDropDownList.Items.Clear()
                If blnAddBlank = True Then
                    objDropDownList.Items.Add("")
                End If

                '填充数据
                Dim objListItem As System.Web.UI.WebControls.ListItem = Nothing
                Dim strCode As String = ""
                Dim strName As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                With objestateCommonData.Tables(strTable)
                    intCount = .Rows.Count
                    For i = 0 To intCount - 1 Step 1
                        strCode = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_QUYUHUAFEN_QYDM), "")
                        strName = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_QUYUHUAFEN_QYMC), "")

                        objListItem = New System.Web.UI.WebControls.ListItem
                        objListItem.Text = strCode + "|" + strName
                        objListItem.Value = strCode
                        objDropDownList.Items.Add(objListItem)
                    Next
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateCommon.SafeRelease(objsystemEstateCommon)
            Josco.JSOA.Common.Data.estateCommonData.SafeRelease(objestateCommonData)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            doFillSzqyList = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateCommon.SafeRelease(objsystemEstateCommon)
            Josco.JSOA.Common.Data.estateCommonData.SafeRelease(objestateCommonData)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 初始化控件
        '----------------------------------------------------------------
        Private Function initializeControls(ByRef strErrMsg As String) As Boolean

            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            initializeControls = False

            Try
                '仅在第一次调用页面时执行
                If Me.IsPostBack = False Then
                    '显示Pannel(不论是否回调，始终显示panelMain)
                    Me.panelMain.Visible = True
                    Me.panelError.Visible = Not Me.panelMain.Visible

                    '执行键转译(不论是否是“回发”)
                    objControlProcess.doTranslateKey(Me.ddlZX)
                    objControlProcess.doTranslateKey(Me.ddlJG)
                    objControlProcess.doTranslateKey(Me.ddlWYXZ)
                    objControlProcess.doTranslateKey(Me.ddlSZQY)

                    objControlProcess.doTranslateKey(Me.txtQRSH)
                    objControlProcess.doTranslateKey(Me.txtFCZH)
                    objControlProcess.doTranslateKey(Me.txtFWDZ)
                    objControlProcess.doTranslateKey(Me.txtLC)
                    objControlProcess.doTranslateKey(Me.txtLL)
                    objControlProcess.doTranslateKey(Me.txtFCZDZ)
                    objControlProcess.doTranslateKey(Me.txtBZXX)
                    objControlProcess.doTranslateKey(Me.txtMJ)
                    objControlProcess.doTranslateKey(Me.txtJYJE)

                    'zengxianglin 2010-12-26
                    objControlProcess.doTranslateKey(Me.txtFYBH)
                    objControlProcess.doTranslateKey(Me.txtLP)
                    objControlProcess.doTranslateKey(Me.txtLD)
                    objControlProcess.doTranslateKey(Me.txtDY)
                    objControlProcess.doTranslateKey(Me.txtJCSJ)
                    objControlProcess.doTranslateKey(Me.txtLG)
                    objControlProcess.doTranslateKey(Me.txtDTSL)
                    objControlProcess.doTranslateKey(Me.txtLCHS)
                    objControlProcess.doTranslateKey(Me.txtLPQS)
                    objControlProcess.doTranslateKey(Me.txtJGFS)
                    objControlProcess.doTranslateKey(Me.txtWSSL)
                    objControlProcess.doTranslateKey(Me.txtYTSL)
                    'zengxianglin 2010-12-26

                    '显示Main
                    If Me.showModuleData_MAIN(strErrMsg, Me.m_blnEditMode) = False Then
                        GoTo errProc
                    End If
                    If Me.showEditPanel_MAIN(strErrMsg, Me.m_blnEditMode) = False Then
                        GoTo errProc
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            initializeControls = True
            Exit Function
errProc:
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim strUrl As String = ""

            Try
                '预处理
                If MyBase.doPagePreprocess(True, Me.IsPostBack And Me.m_blnSaveScence) = True Then
                    Exit Sub
                End If

                '填充列表
                If Me.IsPostBack = False Then
                    If Me.doFillSzqyList(strErrMsg, Me.ddlSZQY, True) = False Then
                        GoTo errProc
                    End If
                    If Me.doFillWyjgList(strErrMsg, Me.ddlJG, True) = False Then
                        GoTo errProc
                    End If
                    If Me.doFillWyxzList(strErrMsg, Me.ddlWYXZ, True) = False Then
                        GoTo errProc
                    End If
                    'zengxianglin 2010-12-26
                    If Me.doFillWyxzList(strErrMsg, Me.rblWYSX, False) = False Then
                        GoTo errProc
                    End If
                    'zengxianglin 2010-12-26
                End If

                '获取接口参数
                Dim blnDo As Boolean
                If Me.getInterfaceParameters(strErrMsg, blnDo) = False Then
                    GoTo errProc
                End If
                If blnDo = False Then
                    GoTo normExit
                End If

                '控件初始化
                If Me.initializeControls(strErrMsg) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try
normExit:
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub











        Private Sub doCancel(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim intStep As Integer = 1

            Try
                '提示信息
                intStep = 1
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "提示：您确实准备取消吗（是/否）？", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '提示后回答“是”接着处理
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    Dim strSessionId As String = ""
                    Dim strUrl As String = ""
                    If Me.m_blnInterface = True Then
                        '设置返回参数
                        Me.m_objInterface.oExitMode = False
                        '返回到调用模块，并附加返回参数
                        '要返回的SessionId
                        strSessionId = Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                        'SessionId附加到返回的Url
                        strUrl = Me.m_objInterface.getReturnUrl(Server, Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId, strSessionId)
                    Else
                        strUrl = Josco.JsKernal.Common.jsoaConfiguration.GeneralReturnUrl
                    End If
                    '释放模块资源
                    Me.releaseModuleParameters()
                    Me.releaseInterfaceParameters()
                    '返回
                    If strUrl <> "" Then
                        Response.Redirect(strUrl)
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doClose(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                Dim strSessionId As String = ""
                Dim strUrl As String = ""
                If Me.m_blnInterface = True Then
                    '设置返回参数
                    Me.m_objInterface.oExitMode = False
                    '返回到调用模块，并附加返回参数
                    '要返回的SessionId
                    strSessionId = Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    'SessionId附加到返回的Url
                    strUrl = Me.m_objInterface.getReturnUrl(Server, Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId, strSessionId)
                Else
                    strUrl = Josco.JsKernal.Common.jsoaConfiguration.GeneralReturnUrl
                End If
                '释放模块资源
                Me.releaseModuleParameters()
                Me.releaseInterfaceParameters()
                '返回
                If strUrl <> "" Then
                    Response.Redirect(strUrl)
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doOK(ByVal strControlId As String)

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objNewData As System.Collections.Specialized.NameValueCollection
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '检查接口
                If Me.m_objValues Is Nothing Then
                    objNewData = New System.Collections.Specialized.NameValueCollection
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_WYBS, "")
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_WYBM, "")
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_QRSH, "")

                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_FCZH, "")
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_FCZDZ, "")
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_FWDZ, "")

                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_MJ, "")
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_JYJE, "")
                    'zengxianglin 2010-12-26
                    'objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_ZX, "")
                    'zengxianglin 2010-12-26
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_LC, "")
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_LL, "")
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_JG, "")
                    'zengxianglin 2010-12-26
                    'objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_WYXZ, "")
                    'zengxianglin 2010-12-26
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_SZQY, "")
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_BZXX, "")

                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_JGMC, "")
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_WYXZMC, "")
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_SZQYMC, "")

                    'zengxianglin 2010-12-26
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_FYBH, "")
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_LP, "")
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_LD, "")
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_DY, "")
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_JCSJ, "")
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_LG, "")
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_DTSL, "")
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_LCHS, "")
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_LPQS, "")
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_JGFS, "")
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_WSSL, "")
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_YTSL, "")
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_HYMJ, "")
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_KJLX, "")
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_FWXZ, "")
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_ZX, "")
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_WYXZ, "")
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_ZXDC, "")
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_ZXNX, "")
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_ZYYX, "")
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_JJSB, "")
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_LYJT, "")
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_FWJG, "")
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_JGLX, "")
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_WYXX, "")
                    'zengxianglin 2010-12-26
                Else
                    objNewData = Me.m_objValues
                End If

                '设置返回值
                objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_WYBS) = Me.htxtWYBS.Value
                objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_WYBM) = Me.htxtWYBM.Value
                objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_QRSH) = Me.txtQRSH.Text

                objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_FCZH) = Me.txtFCZH.Text
                objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_FCZDZ) = Me.txtFCZDZ.Text
                objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_FWDZ) = Me.txtFWDZ.Text

                objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_MJ) = Me.txtMJ.Text
                objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_JYJE) = Me.txtJYJE.Text
                objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_LC) = Me.txtLC.Text
                objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_LL) = Me.txtLL.Text
                objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_BZXX) = Me.txtBZXX.Text

                'zengxianglin 2010-12-26
                'If Me.ddlZX.SelectedIndex <= 0 Then
                '    objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_ZX) = ""
                'Else
                '    objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_ZX) = Me.ddlZX.SelectedValue
                'End If
                'zengxianglin 2010-12-26

                If Me.ddlJG.SelectedIndex <= 0 Then
                    objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_JG) = ""
                    objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_JGMC) = ""
                Else
                    objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_JG) = Me.ddlJG.SelectedValue
                    objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_JGMC) = Me.ddlJG.SelectedItem.Text.Split("|".ToCharArray)(1)
                End If

                'zengxianglin 2010-12-26
                'If Me.ddlWYXZ.SelectedIndex <= 0 Then
                '    objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_WYXZ) = ""
                '    objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_WYXZMC) = ""
                'Else
                '    objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_WYXZ) = Me.ddlWYXZ.SelectedValue
                '    objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_WYXZMC) = Me.ddlWYXZ.SelectedItem.Text.Split("|".ToCharArray)(1)
                'End If
                'zengxianglin 2010-12-26

                If Me.ddlSZQY.SelectedIndex <= 0 Then
                    objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_SZQY) = ""
                    objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_SZQYMC) = ""
                Else
                    objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_SZQY) = Me.ddlSZQY.SelectedValue
                    objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_SZQYMC) = Me.ddlSZQY.SelectedItem.Text.Split("|".ToCharArray)(1)
                End If

                '如果输入了“房产证地址”，则
                If Me.txtFCZDZ.Text.Trim <> "" Then
                    Me.txtFWDZ.Text = Me.txtFCZDZ.Text
                    objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_FWDZ) = objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_FCZDZ)
                End If

                'zengxianglin 2010-12-26
                '如果输入了[楼盘][栋别][单元]
                If Me.txtFWDZ.Text.Trim = "" Then
                    If Me.txtLP.Text.Trim <> "" Or Me.txtLD.Text.Trim <> "" Or Me.txtDY.Text.Trim <> "" Then
                        Me.txtFWDZ.Text = Me.txtLP.Text.Trim + Me.txtLD.Text.Trim + Me.txtDY.Text.Trim
                        objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_FWDZ) = objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_FCZDZ)
                    End If
                End If
                '如果输入了[建成时间]
                If Me.txtLL.Text.Trim = "" Then
                    If Me.txtJCSJ.Text.Trim <> "" Then
                        If objPulicParameters.isDatetimeString(Me.txtJCSJ.Text.Trim) = True Then
                            Me.txtLL.Text = (System.Math.Abs(Microsoft.VisualBasic.DateDiff(Microsoft.VisualBasic.DateInterval.Year, Now, CType(Me.txtJCSJ.Text, System.DateTime))) + 1).ToString
                            objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_LL) = Me.txtLL.Text
                        End If
                    End If
                End If
                objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_FYBH) = Me.txtFYBH.Text
                objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_LP) = Me.txtLP.Text
                objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_LD) = Me.txtLD.Text
                objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_DY) = Me.txtDY.Text
                objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_JCSJ) = Me.txtJCSJ.Text
                objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_LG) = Me.txtLG.Text
                objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_DTSL) = Me.txtDTSL.Text
                objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_LCHS) = Me.txtLCHS.Text
                objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_LPQS) = Me.txtLPQS.Text
                objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_JGFS) = Me.txtJGFS.Text
                objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_WSSL) = Me.txtWSSL.Text
                objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_YTSL) = Me.txtYTSL.Text
                If Me.rblKJLX.SelectedIndex < 0 Then
                    objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_KJLX) = ""
                Else
                    objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_KJLX) = Me.rblKJLX.SelectedValue
                End If
                If Me.rblFWXZ.SelectedIndex < 0 Then
                    objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_FWXZ) = ""
                Else
                    objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_FWXZ) = Me.rblFWXZ.SelectedValue
                End If
                If Me.rblCX.SelectedIndex < 0 Then
                    objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_ZX) = ""
                Else
                    objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_ZX) = Me.rblCX.SelectedValue
                End If
                If Me.rblWYSX.SelectedIndex < 0 Then
                    objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_WYXZ) = ""
                    objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_WYXZMC) = ""
                Else
                    objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_WYXZ) = Me.rblWYSX.SelectedValue
                    objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_WYXZMC) = Me.rblWYSX.SelectedItem.Text
                End If
                If Me.rblZXDC.SelectedIndex < 0 Then
                    objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_ZXDC) = ""
                Else
                    objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_ZXDC) = Me.rblZXDC.SelectedValue
                End If
                If Me.rblZXNX.SelectedIndex < 0 Then
                    objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_ZXNX) = ""
                Else
                    objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_ZXNX) = Me.rblZXNX.SelectedValue
                End If
                If Me.rblZYYX.SelectedIndex < 0 Then
                    objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_ZYYX) = ""
                Else
                    objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_ZYYX) = Me.rblZYYX.SelectedValue
                End If
                If Me.rblJJSB.SelectedIndex < 0 Then
                    objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_JJSB) = ""
                Else
                    objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_JJSB) = Me.rblJJSB.SelectedValue
                End If
                If Me.rblLYJT.SelectedIndex < 0 Then
                    objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_LYJT) = ""
                Else
                    objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_LYJT) = Me.rblLYJT.SelectedValue
                End If
                If Me.rblFWJG.SelectedIndex < 0 Then
                    objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_FWJG) = ""
                Else
                    objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_FWJG) = Me.rblFWJG.SelectedValue
                End If
                If Me.rblJGLX.SelectedIndex < 0 Then
                    objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_JGLX) = ""
                Else
                    objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_JGLX) = Me.rblJGLX.SelectedValue
                End If
                objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_WYXX) = objsystemEstateErshou.getWYXX_QT(objNewData)
                'zengxianglin 2010-12-26

                '检查数据
                If objsystemEstateErshou.doVerifyData_ES_WUYE_QT(strErrMsg, MyBase.UserId, MyBase.UserPassword, objNewData) = False Then
                    GoTo errProc
                End If

                '返回处理
                Dim strSessionId As String = ""
                Dim strUrl As String = ""
                If Me.m_blnInterface = True Then
                    '设置返回参数
                    Me.m_objInterface.oExitMode = True
                    Me.m_objInterface.oValues = objNewData
                    '返回到调用模块，并附加返回参数
                    '要返回的SessionId
                    strSessionId = Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    'SessionId附加到返回的Url
                    strUrl = Me.m_objInterface.getReturnUrl(Server, Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId, strSessionId)
                Else
                    strUrl = Josco.JsKernal.Common.jsoaConfiguration.GeneralReturnUrl
                End If
                '释放模块资源
                Me.releaseModuleParameters()
                Me.releaseInterfaceParameters()
                '返回
                If strUrl <> "" Then
                    Response.Redirect(strUrl)
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Me.doCancel("btnCancel")
        End Sub

        Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
            Me.doClose("btnClose")
        End Sub

        Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
            Me.doOK("btnOK")
        End Sub

    End Class

End Namespace
