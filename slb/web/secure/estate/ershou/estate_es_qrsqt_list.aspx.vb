Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.web
    ' 类名    ：estate_es_qrsqt_list
    ' 
    ' 调用性质：
    '     I/O
    '
    ' 功能描述： 
    '   　“其他确认书列表”处理模块
    ' 更改记录：
    '     zengxianglin 2008-11-17 创建
    '     zengxianglin 2009-05-17 更改
    '----------------------------------------------------------------

    Partial Class estate_es_qrsqt_list
        Inherits Josco.JsKernal.web.PageBase

#Region " Web 窗体设计器生成的代码 "

        '该调用是 Web 窗体设计器所必需的。
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub




        'zengxianglin 2008-11-18
        'zengxianglin 2008-11-18



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
        '打印模版相对于应用根的路径
        Private m_cstrExcelMBRelativePathToAppRoot As String = "/template/excel/"
        '打印文件缓存目录相对于应用根的路径
        Private m_cstrPrintCacheRelativePathToAppRoot As String = "/temp/printcache/"

        '----------------------------------------------------------------
        '模块授权参数
        '----------------------------------------------------------------
        Private m_cstrPrevilegeParamPrefix As String = "estate_es_qrsqt_previlege_param"
        Private m_blnPrevilegeParams(5) As Boolean

        '----------------------------------------------------------------
        '模块现场保留参数，恢复完成后立即释放session资源
        '----------------------------------------------------------------
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMEstateEsQrsQtList
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        '模块接口参数
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IEstateEsQrsQtList
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '与数据网格grdQRS相关的参数
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_QRS As String = "chkQRS"
        Private Const m_cstrDataGridInDIV_QRS As String = "divQRS"
        Private m_intFixedColumns_QRS As Integer

        '----------------------------------------------------------------
        '当前处理的数据集
        '----------------------------------------------------------------
        Private m_objDataSet_QRS As Josco.JSOA.Common.Data.estateErshouData
        Private m_strQuery_QRS As String
        Private m_intRows_QRS As Integer

        '----------------------------------------------------------------
        '其他模块私用参数
        '----------------------------------------------------------------
        Private m_blnQxControl As Boolean

        Public ReadOnly Property propRYMC() As String
            Get
                propRYMC = MyBase.UserZM
            End Get
        End Property











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
                        Me.m_objInterface = CType(Session(strSessionId), Josco.JSOA.BusinessFacade.IEstateEsQrsQtList)
                    Catch ex As Exception
                        Me.m_objInterface = Nothing
                    End Try
                Else
                    Me.m_objInterface = Nothing
                End If
                If Not (Me.m_objInterface Is Nothing) Then
                    '设置返回参数
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
        ' 获取权限参数
        '     strErrMsg          ：返回错误信息
        '     blnContinueExecute ：是否继续执行后续程序？
        ' 返回
        '     True               ：成功
        '     False              ：失败
        '----------------------------------------------------------------
        Private Function getPrevilegeParams( _
            ByRef strErrMsg As String, _
            ByRef blnContinueExecute As Boolean) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objsystemAppManager As New Josco.JsKernal.BusinessFacade.systemAppManager
            Dim objMokuaiQXData As Josco.JsKernal.Common.Data.AppManagerData

            getPrevilegeParams = False
            blnContinueExecute = False

            Try
                Dim intCount As Integer
                Dim i As Integer

                '根据登录用户获取模块权限数据
                If MyBase.UserId.ToUpper() = "SA" Then
                    '管理员权限
                    intCount = Me.m_blnPrevilegeParams.Length
                    For i = 0 To intCount - 1 Step 1
                        Me.m_blnPrevilegeParams(i) = True
                    Next
                    blnContinueExecute = True
                    Exit Try
                Else
                    '普通用户权限
                    If objsystemAppManager.getDBUserMokuaiQXData(strErrMsg, MyBase.UserId, MyBase.UserPassword, MyBase.UserId, objMokuaiQXData) = False Then
                        GoTo errProc
                    End If
                End If

                '检查权限
                Dim strFirstParamValue As String
                Dim strParamValue As String
                Dim strParamName As String
                Dim strMKMC As String
                Dim strFilter As String
                strMKMC = Josco.JsKernal.Common.Data.AppManagerData.FIELD_GL_B_YINGYONGXITONG_MOKUAIQX_MKMC
                With objMokuaiQXData.Tables(Josco.JsKernal.Common.Data.AppManagerData.TABLE_GL_B_YINGYONGXITONG_MOKUAIQX)
                    intCount = Me.m_blnPrevilegeParams.Length
                    For i = 0 To intCount - 1 Step 1
                        '计算参数名
                        strParamName = i.ToString()
                        If strParamName.Length < 2 Then strParamName = "0" + strParamName
                        strParamName = Me.m_cstrPrevilegeParamPrefix + strParamName

                        '获取参数值
                        With objPulicParameters
                            strParamValue = .getObjectValue(Josco.JsKernal.Common.jsoaSecureConfiguration.ReadSetting(strParamName, ""), "")
                        End With
                        If i = 0 Then strFirstParamValue = strParamValue

                        '获取参数对应的权限
                        strFilter = strMKMC + " = '" + strParamValue + "'"
                        .DefaultView.RowFilter = strFilter
                        If .DefaultView.Count > 0 Then
                            Me.m_blnPrevilegeParams(i) = True
                        Else
                            Me.m_blnPrevilegeParams(i) = False
                        End If
                    Next

                End With

                '是否继续执行
                If Me.m_blnPrevilegeParams(0) = True Then
                    blnContinueExecute = True
                Else
                    Me.panelError.Visible = True
                    Me.lblMessage.Text = "错误：您没有[" + strFirstParamValue + "]的执行权限，请与系统管理员联系，谢谢！"
                    Me.panelMain.Visible = Not Me.panelError.Visible
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.BusinessFacade.systemAppManager.SafeRelease(objsystemAppManager)
            Josco.JsKernal.Common.Data.AppManagerData.SafeRelease(objMokuaiQXData)

            getPrevilegeParams = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.BusinessFacade.systemAppManager.SafeRelease(objsystemAppManager)
            Josco.JsKernal.Common.Data.AppManagerData.SafeRelease(objMokuaiQXData)
            Exit Function

        End Function














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
                    Me.htxtDivLeftQRS.Value = .htxtDivLeftQRS
                    Me.htxtDivTopQRS.Value = .htxtDivTopQRS

                    Me.htxtQRSQuery.Value = .htxtQRSQuery
                    Me.htxtQRSRows.Value = .htxtQRSRows
                    Me.htxtQRSSort.Value = .htxtQRSSort
                    Me.htxtQRSSortColumnIndex.Value = .htxtQRSSortColumnIndex
                    Me.htxtQRSSortType.Value = .htxtQRSSortType

                    Me.txtQRSSearch_QRSH.Text = .txtQRSSearch_QRSH
                    Me.txtQRSSearch_JFMC.Text = .txtQRSSearch_JFMC
                    Me.txtQRSSearch_YFMC.Text = .txtQRSSearch_YFMC
                    Me.txtQRSSearch_FWDZ.Text = .txtQRSSearch_FWDZ
                    Me.txtQRSSearch_DGRQMax.Text = .txtQRSSearch_DGRQMax
                    Me.txtQRSSearch_DGRQMin.Text = .txtQRSSearch_DGRQMin
                    Me.ddlQRSSearch_DGZT.SelectedIndex = .ddlQRSSearch_DGZT_SelectedIndex

                    Me.txtQRSPageIndex.Text = .txtQRSPageIndex
                    Me.txtQRSPageSize.Text = .txtQRSPageSize

                    Try
                        Me.grdQRS.PageSize = .grdQRSPageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdQRS.CurrentPageIndex = .grdQRSCurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdQRS.SelectedIndex = .grdQRSSelectedIndex
                    Catch ex As Exception
                    End Try
                    Me.htxtSessionIdQuery.Value = .htxtSessionIdQuery
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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            Dim strSessionId As String = ""

            saveModuleInformation = ""

            Try
                '创建SessionId
                strSessionId = objPulicParameters.getNewGuid()
                If strSessionId = "" Then
                    Exit Try
                End If

                '创建对象
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMEstateEsQrsQtList

                '保存现场信息
                With Me.m_objSaveScence
                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftQRS = Me.htxtDivLeftQRS.Value
                    .htxtDivTopQRS = Me.htxtDivTopQRS.Value

                    .htxtQRSQuery = Me.htxtQRSQuery.Value
                    .htxtQRSRows = Me.htxtQRSRows.Value
                    .htxtQRSSort = Me.htxtQRSSort.Value
                    .htxtQRSSortColumnIndex = Me.htxtQRSSortColumnIndex.Value
                    .htxtQRSSortType = Me.htxtQRSSortType.Value

                    .txtQRSSearch_QRSH = Me.txtQRSSearch_QRSH.Text
                    .txtQRSSearch_JFMC = Me.txtQRSSearch_JFMC.Text
                    .txtQRSSearch_YFMC = Me.txtQRSSearch_YFMC.Text
                    .txtQRSSearch_FWDZ = Me.txtQRSSearch_FWDZ.Text
                    .txtQRSSearch_DGRQMax = Me.txtQRSSearch_DGRQMax.Text
                    .txtQRSSearch_DGRQMin = Me.txtQRSSearch_DGRQMin.Text
                    .ddlQRSSearch_DGZT_SelectedIndex = Me.ddlQRSSearch_DGZT.SelectedIndex

                    .txtQRSPageIndex = Me.txtQRSPageIndex.Text
                    .txtQRSPageSize = Me.txtQRSPageSize.Text

                    .grdQRSPageSize = Me.grdQRS.PageSize
                    .grdQRSCurrentPageIndex = Me.grdQRS.CurrentPageIndex
                    .grdQRSSelectedIndex = Me.grdQRS.SelectedIndex
                    .htxtSessionIdQuery = Me.htxtSessionIdQuery.Value
                End With

                '缓存对象
                Session.Add(strSessionId, Me.m_objSaveScence)

            Catch ex As Exception
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            saveModuleInformation = strSessionId
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 从调用模块中获取数据
        '----------------------------------------------------------------
        Private Function getDataFromCallModule(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objsystemCustomer As New Josco.JsKernal.BusinessFacade.systemCustomer

            getDataFromCallModule = False

            Try
                If Me.IsPostBack = True Then
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIEstateCwSssf As Josco.JSOA.BusinessFacade.IEstateCwSssf = Nothing
                Try
                    objIEstateCwSssf = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IEstateCwSssf)
                Catch ex As Exception
                    objIEstateCwSssf = Nothing
                End Try
                If Not (objIEstateCwSssf Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IEstateCwSssf.SafeRelease(objIEstateCwSssf)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIEstateEsQrsQtInfo As Josco.JSOA.BusinessFacade.IEstateEsQrsQtInfo = Nothing
                Try
                    objIEstateEsQrsQtInfo = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IEstateEsQrsQtInfo)
                Catch ex As Exception
                    objIEstateEsQrsQtInfo = Nothing
                End Try
                If Not (objIEstateEsQrsQtInfo Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IEstateEsQrsQtInfo.SafeRelease(objIEstateEsQrsQtInfo)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objISjcxCxtj As Josco.JsKernal.BusinessFacade.ISjcxCxtj
                Try
                    objISjcxCxtj = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JsKernal.BusinessFacade.ISjcxCxtj)
                Catch ex As Exception
                    objISjcxCxtj = Nothing
                End Try
                If Not (objISjcxCxtj Is Nothing) Then
                    If objISjcxCxtj.oExitMode = True Then
                        Dim objQueryData As Josco.JsKernal.Common.Data.QueryData
                        Me.htxtQRSQuery.Value = objISjcxCxtj.oQueryString
                        If Me.htxtSessionIdQuery.Value.Trim = "" Then
                            Me.htxtSessionIdQuery.Value = objPulicParameters.getNewGuid()
                        Else
                            Try
                                objQueryData = CType(Session(Me.htxtSessionIdQuery.Value), Josco.JsKernal.Common.Data.QueryData)
                            Catch ex As Exception
                                objQueryData = Nothing
                            End Try
                            Josco.JsKernal.Common.Data.QueryData.SafeRelease(objQueryData)
                        End If
                        Session.Add(Me.htxtSessionIdQuery.Value, objISjcxCxtj.oDataSetTJ)
                    End If
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JsKernal.BusinessFacade.ISjcxCxtj.SafeRelease(objISjcxCxtj)
                    Exit Try
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)

            getDataFromCallModule = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)
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
        Private Function getInterfaceParameters(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objsystemCustomer As New Josco.JsKernal.BusinessFacade.systemCustomer

            getInterfaceParameters = False

            Try
                '从QueryString中解析接口参数(不论是否回发)
                Dim objTemp As Object = Nothing
                Try
                    objTemp = Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId))
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IEstateEsQrsQtList)
                Catch ex As Exception
                    m_objInterface = Nothing
                End Try
                If m_objInterface Is Nothing Then
                    Me.m_blnInterface = False
                    '没有有接口参数
                Else
                    Me.m_blnInterface = True
                    '有接口参数
                End If

                '判断当前人员是否为分行人员
                Dim blnIS As Boolean = True
                If objsystemCustomer.isFenghangRenyuan(strErrMsg, MyBase.UserId, MyBase.UserPassword, MyBase.UserId, blnIS) = False Then
                    GoTo errProc
                End If
                If blnIS = True Then
                    Me.m_blnQxControl = True '进行特殊权限控制
                Else
                    Me.m_blnQxControl = False
                End If

                '获取恢复现场参数
                If Me.IsPostBack = False Then
                    Dim strSessionId As String
                    strSessionId = objPulicParameters.getObjectValue(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId), "")
                    Try
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMEstateEsQrsQtList)
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

                Me.m_strQuery_QRS = Me.htxtQRSQuery.Value
                Me.m_intRows_QRS = objPulicParameters.getObjectValue(Me.htxtQRSRows.Value, 0)
                Me.m_intFixedColumns_QRS = objPulicParameters.getObjectValue(Me.htxtQRSFixed.Value, 0)
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)

            getInterfaceParameters = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 释放本模块缓存的参数
        '----------------------------------------------------------------
        Private Sub releaseModuleParameters()

            Try
                If Me.htxtSessionIdQuery.Value.Trim <> "" Then
                    Dim objQueryData As Josco.JsKernal.Common.Data.QueryData
                    Try
                        objQueryData = CType(Session(Me.htxtSessionIdQuery.Value), Josco.JsKernal.Common.Data.QueryData)
                    Catch ex As Exception
                        objQueryData = Nothing
                    End Try
                    Josco.JsKernal.Common.Data.QueryData.SafeRelease(objQueryData)
                    Session.Remove(Me.htxtSessionIdQuery.Value)
                End If
            Catch ex As Exception
            End Try

            Exit Sub

        End Sub














        '----------------------------------------------------------------
        ' 获取模块搜索条件(默认表前缀a.)
        '     strErrMsg      ：返回错误信息
        '     strQuery       ：返回的搜索条件
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getQueryString_QRS( _
            ByRef strErrMsg As String, _
            ByRef strQuery As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getQueryString_QRS = False
            strQuery = ""

            Try
                '按“确认书号”搜索
                Dim strQRSH As String = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_QRSH
                If Me.txtQRSSearch_QRSH.Text.Length > 0 Then Me.txtQRSSearch_QRSH.Text = Me.txtQRSSearch_QRSH.Text.Trim()
                If Me.txtQRSSearch_QRSH.Text <> "" Then
                    Me.txtQRSSearch_QRSH.Text = objPulicParameters.getNewSearchString(Me.txtQRSSearch_QRSH.Text)
                    If strQuery = "" Then
                        strQuery = strQRSH + " like '" + Me.txtQRSSearch_QRSH.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strQRSH + " like '" + Me.txtQRSSearch_QRSH.Text + "%'"
                    End If
                End If

                '按“甲方名称”搜索
                Dim strJFMC As String = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_JFMC
                If Me.txtQRSSearch_JFMC.Text.Length > 0 Then Me.txtQRSSearch_JFMC.Text = Me.txtQRSSearch_JFMC.Text.Trim()
                If Me.txtQRSSearch_JFMC.Text <> "" Then
                    Me.txtQRSSearch_JFMC.Text = objPulicParameters.getNewSearchString(Me.txtQRSSearch_JFMC.Text)
                    If strQuery = "" Then
                        strQuery = strJFMC + " like '" + Me.txtQRSSearch_JFMC.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strJFMC + " like '" + Me.txtQRSSearch_JFMC.Text + "%'"
                    End If
                End If

                '按“乙方名称”搜索
                Dim strYFMC As String = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_YFMC
                If Me.txtQRSSearch_YFMC.Text.Length > 0 Then Me.txtQRSSearch_YFMC.Text = Me.txtQRSSearch_YFMC.Text.Trim()
                If Me.txtQRSSearch_YFMC.Text <> "" Then
                    Me.txtQRSSearch_YFMC.Text = objPulicParameters.getNewSearchString(Me.txtQRSSearch_YFMC.Text)
                    If strQuery = "" Then
                        strQuery = strYFMC + " like '" + Me.txtQRSSearch_YFMC.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strYFMC + " like '" + Me.txtQRSSearch_YFMC.Text + "%'"
                    End If
                End If

                '按“房屋地址”搜索
                Dim strFWDZ As String = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_FWDZ
                If Me.txtQRSSearch_FWDZ.Text.Length > 0 Then Me.txtQRSSearch_FWDZ.Text = Me.txtQRSSearch_FWDZ.Text.Trim()
                If Me.txtQRSSearch_FWDZ.Text <> "" Then
                    Me.txtQRSSearch_FWDZ.Text = objPulicParameters.getNewSearchString(Me.txtQRSSearch_FWDZ.Text)
                    If strQuery = "" Then
                        strQuery = strFWDZ + " like '" + Me.txtQRSSearch_FWDZ.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strFWDZ + " like '" + Me.txtQRSSearch_FWDZ.Text + "%'"
                    End If
                End If

                '按“订购状态”搜索
                Dim strDGZT As String = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_DGZT
                Select Case Me.ddlQRSSearch_DGZT.SelectedIndex
                    Case Is > 0
                        If strQuery = "" Then
                            strQuery = strDGZT + Me.ddlQRSSearch_DGZT.SelectedValue
                        Else
                            strQuery = strQuery + " and " + strDGZT + Me.ddlQRSSearch_DGZT.SelectedValue
                        End If
                    Case Else
                End Select

                '按“订购日期”搜索
                Dim strDGRQ As String
                Dim dateMin As System.DateTime
                Dim dateMax As System.DateTime
                strDGRQ = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_DGRQ
                If Me.txtQRSSearch_DGRQMin.Text.Length > 0 Then Me.txtQRSSearch_DGRQMin.Text = Me.txtQRSSearch_DGRQMin.Text.Trim()
                If Me.txtQRSSearch_DGRQMax.Text.Length > 0 Then Me.txtQRSSearch_DGRQMax.Text = Me.txtQRSSearch_DGRQMax.Text.Trim()
                If Me.txtQRSSearch_DGRQMin.Text <> "" And Me.txtQRSSearch_DGRQMax.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtQRSSearch_DGRQMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的时间！"
                        GoTo errProc
                    End Try
                    Try
                        dateMax = CType(Me.txtQRSSearch_DGRQMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的时间！"
                        GoTo errProc
                    End Try
                    If dateMin > dateMax Then
                        Me.txtQRSSearch_DGRQMin.Text = dateMax.ToString("yyyy-MM-dd")
                        Me.txtQRSSearch_DGRQMax.Text = dateMin.ToString("yyyy-MM-dd")
                    Else
                        Me.txtQRSSearch_DGRQMin.Text = dateMin.ToString("yyyy-MM-dd")
                        Me.txtQRSSearch_DGRQMax.Text = dateMax.ToString("yyyy-MM-dd")
                    End If
                    If strQuery = "" Then
                        strQuery = strDGRQ + " between '" + Me.txtQRSSearch_DGRQMin.Text + "' and '" + Me.txtQRSSearch_DGRQMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strDGRQ + " between '" + Me.txtQRSSearch_DGRQMin.Text + "' and '" + Me.txtQRSSearch_DGRQMax.Text + "'"
                    End If
                ElseIf Me.txtQRSSearch_DGRQMin.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtQRSSearch_DGRQMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的时间！"
                        GoTo errProc
                    End Try
                    Me.txtQRSSearch_DGRQMin.Text = dateMin.ToString("yyyy-MM-dd")
                    If strQuery = "" Then
                        strQuery = strDGRQ + " >= '" + Me.txtQRSSearch_DGRQMin.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strDGRQ + " >= '" + Me.txtQRSSearch_DGRQMin.Text + "'"
                    End If
                ElseIf Me.txtQRSSearch_DGRQMax.Text <> "" Then
                    Try
                        dateMax = CType(Me.txtQRSSearch_DGRQMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的时间！"
                        GoTo errProc
                    End Try
                    Me.txtQRSSearch_DGRQMax.Text = dateMax.ToString("yyyy-MM-dd")
                    If strQuery = "" Then
                        strQuery = strDGRQ + " <= '" + Me.txtQRSSearch_DGRQMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strDGRQ + " <= '" + Me.txtQRSSearch_DGRQMax.Text + "'"
                    End If
                Else
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getQueryString_QRS = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取grdQRS要显示的数据信息
        '     strErrMsg      ：返回错误信息
        '     strWhere       ：搜索字符串
        '     blnControl     ：特殊权限控制
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_QRS( _
            ByRef strErrMsg As String, _
            ByVal strWhere As String, _
            ByVal blnControl As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_QUERENSHU_QT
            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou

            getModuleData_QRS = False

            Try
                '备份Sort字符串
                Dim strSort As String = ""
                strSort = Me.htxtQRSSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '释放资源
                Josco.JSOA.Common.Data.estateErshouData.SafeRelease(Me.m_objDataSet_QRS)

                '重新检索数据
                If objsystemEstateErshou.getDataSet_ES_QRS_QT(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWhere, blnControl, Me.m_objDataSet_QRS) = False Then
                    GoTo errProc
                End If

                '恢复Sort字符串
                With Me.m_objDataSet_QRS.Tables(strTable)
                    .DefaultView.Sort = strSort
                End With

                '缓存参数
                With Me.m_objDataSet_QRS.Tables(strTable)
                    Me.htxtQRSRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_QRS = .DefaultView.Count
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)

            getModuleData_QRS = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取grdQRS要显示的数据信息
        '     strErrMsg      ：返回错误信息
        '     strWhere       ：搜索字符串
        '     blnControl     ：特殊权限控制
        ' 返回
        '     True           ：成功
        '     False          ：失败
        ' 更改记录
        '     zengxianglin 2009-05-17 创建
        '----------------------------------------------------------------
        Private Function getModuleData_QRS_PRN( _
            ByRef strErrMsg As String, _
            ByVal strWhere As String, _
            ByVal blnControl As Boolean, _
            ByRef objDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_QUERENSHU_QT_PRN
            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou

            getModuleData_QRS_PRN = False

            Try
                '备份Sort字符串
                Dim strSort As String = ""
                strSort = Me.htxtQRSSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '重新检索数据
                If objsystemEstateErshou.getDataSet_ES_QRS_QT_PRN(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWhere, blnControl, objDataSet) = False Then
                    GoTo errProc
                End If

                '恢复Sort字符串
                With objDataSet.Tables(strTable)
                    .DefaultView.Sort = strSort
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)

            getModuleData_QRS_PRN = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 根据屏幕搜索条件搜索grdQRS数据
        '     strErrMsg      ：返回错误信息
        '     blnControl     ：特殊权限控制
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function searchModuleData_QRS( _
            ByRef strErrMsg As String, _
            ByVal blnControl As Boolean) As Boolean

            searchModuleData_QRS = False

            Try
                '获取搜索字符串
                Dim strQuery As String
                If Me.getQueryString_QRS(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '搜索数据
                If Me.getModuleData_QRS(strErrMsg, strQuery, blnControl) = False Then
                    GoTo errProc
                End If

                '记录搜索字符串
                Me.m_strQuery_QRS = strQuery
                Me.htxtQRSQuery.Value = Me.m_strQuery_QRS
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            searchModuleData_QRS = True
            Exit Function
errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdQRS的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo_QRS( _
            ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_QUERENSHU_QT
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_QRS = False

            '获取系统保存的网格排序数据
            Dim intSortColumnIndex As Integer = -1
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtQRSSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtQRSSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '网格显示处理
            Try
                '在获取数据时已经恢复了RowFilter、Sort的现场
                '设置数据源
                If Me.m_objDataSet_QRS Is Nothing Then
                    Me.grdQRS.DataSource = Nothing
                Else
                    With Me.m_objDataSet_QRS.Tables(strTable)
                        Me.grdQRS.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objDataSet_QRS.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdQRS, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '恢复列标题中的排序信息
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdQRS)
                    With Me.grdQRS.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '绑定数据
                Me.grdQRS.DataBind()

                '----------------------------------------------------------------
                '因为这些信息是非绑定的，所以下面的操作必须等绑定完成后执行！！！
                '一旦在后续处理中执行了DataBind，则信息会丢失！！！
                '----------------------------------------------------------------
                ''恢复网格中的CheckBox状态
                'If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdQRS, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_QRS) = False Then
                '    GoTo errProc
                'End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_QRS = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示整个模块的信息
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleData( _
            ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_QUERENSHU_QT
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showModuleData = False

            Try
                '显示网格信息
                If Me.showDataGridInfo_QRS(strErrMsg) = False Then
                    GoTo errProc
                End If

                '显示与网格紧密相关的操作或信息提示
                With Me.m_objDataSet_QRS.Tables(strTable).DefaultView
                    '显示网格位置信息
                    Me.lblQRSGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdQRS, .Count)

                    '显示页面浏览功能
                    Me.lnkCZQRSMoveFirst.Enabled = objDataGridProcess.canDoMoveFirstPage(Me.grdQRS, .Count)
                    Me.lnkCZQRSMoveLast.Enabled = objDataGridProcess.canDoMoveLastPage(Me.grdQRS, .Count)
                    Me.lnkCZQRSMovePrev.Enabled = objDataGridProcess.canDoMovePreviousPage(Me.grdQRS, .Count)
                    Me.lnkCZQRSMoveNext.Enabled = objDataGridProcess.canDoMoveNextPage(Me.grdQRS, .Count)

                    '显示相关操作
                    Dim blnEnabled As Boolean
                    If .Count < 1 Then
                        blnEnabled = False
                    Else
                        blnEnabled = True
                    End If
                    Me.lnkCZQRSDeSelectAll.Enabled = blnEnabled
                    Me.lnkCZQRSSelectAll.Enabled = blnEnabled
                    Me.lnkCZQRSGotoPage.Enabled = blnEnabled
                    Me.lnkCZQRSSetPageSize.Enabled = blnEnabled
                End With

                '显示操作命令
                Me.btnAddNew.Visible = Me.m_blnPrevilegeParams(1)
                Me.btnUpdate.Visible = Me.m_blnPrevilegeParams(2)
                Me.btnDelete.Visible = Me.m_blnPrevilegeParams(3)
                Me.btnTading.Visible = Me.m_blnPrevilegeParams(4)
                'zengxianglin 2008-11-18
                Me.btnDelWtj.Visible = Me.m_blnPrevilegeParams(5)
                'zengxianglin 2008-11-18
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showModuleData = True
            Exit Function
errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 初始化控件
        '----------------------------------------------------------------
        Private Function initializeControls(ByRef strErrMsg As String) As Boolean

            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            initializeControls = False

            '仅在第一次调用页面时执行
            If Me.IsPostBack = False Then
                Try
                    '显示Pannel(不论是否回调，始终显示panelMain)
                    Me.panelMain.Visible = True
                    Me.panelError.Visible = Not Me.panelMain.Visible

                    '执行键转译(不论是否是“回发”)
                    objControlProcess.doTranslateKey(Me.txtQRSPageIndex)
                    objControlProcess.doTranslateKey(Me.txtQRSPageSize)
                    objControlProcess.doTranslateKey(Me.txtQRSSearch_QRSH)
                    objControlProcess.doTranslateKey(Me.txtQRSSearch_JFMC)
                    objControlProcess.doTranslateKey(Me.txtQRSSearch_YFMC)
                    objControlProcess.doTranslateKey(Me.txtQRSSearch_FWDZ)
                    objControlProcess.doTranslateKey(Me.txtQRSSearch_DGRQMin)
                    objControlProcess.doTranslateKey(Me.txtQRSSearch_DGRQMax)
                    objControlProcess.doTranslateKey(Me.ddlQRSSearch_DGZT)

                    If Me.m_blnSaveScence = False Then
                        Me.txtQRSSearch_DGRQMin.Text = Now.Year.ToString + "-01-01"
                        If Me.searchModuleData_QRS(strErrMsg, Me.m_blnQxControl) = False Then
                            GoTo errProc
                        End If
                    Else
                        '获取数据
                        If Me.getModuleData_QRS(strErrMsg, Me.m_strQuery_QRS, Me.m_blnQxControl) = False Then
                            GoTo errProc
                        End If
                    End If
                    '显示数据
                    If Me.showModuleData(strErrMsg) = False Then
                        GoTo errProc
                    End If
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
            End If

            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            initializeControls = True
            Exit Function
errProc:
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String
            Dim strUrl As String

            '预处理
            If MyBase.doPagePreprocess(True, Me.IsPostBack And Me.m_blnSaveScence) = True Then
                Exit Sub
            End If

            '检查权限(不论是否回发！)
            Dim blnDo As Boolean
            If Me.getPrevilegeParams(strErrMsg, blnDo) = False Then
                GoTo errProc
            End If
            If blnDo = False Then
                GoTo normExit
            End If

            '获取接口参数
            If Me.getInterfaceParameters(strErrMsg) = False Then
                GoTo errProc
            End If

            '控件初始化
            If Me.initializeControls(strErrMsg) = False Then
                GoTo errProc
            End If
normExit:
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub












        '----------------------------------------------------------------
        '网格事件处理器
        '----------------------------------------------------------------
        '实现对网格行、列的固定
        Sub grdQRS_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdQRS.ItemDataBound

            Dim intCells As Integer = -1
            Dim i As Integer = 0

            Try
                If e.Item.ItemIndex < 0 Then
                    '标题行,输出标题锁定一般属性
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_QRS + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_QRS > 0 Then
                    '锁定列
                    For i = 0 To Me.m_intFixedColumns_QRS - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdQRS.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

            Exit Sub

        End Sub

        Private Sub grdQRS_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdQRS.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '显示记录位置
                Me.lblQRSGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdQRS, Me.m_intRows_QRS)
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub grdQRS_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdQRS.SortCommand

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_QUERENSHU_QT
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                Dim objenumSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
                Dim objDataGridItem As System.Web.UI.WebControls.DataGridItem
                Dim strFinalCommand As String
                Dim strOldCommand As String
                Dim strUniqueId As String
                Dim intColumnIndex As Integer

                '获取数据
                If Me.getModuleData_QRS(strErrMsg, Me.m_strQuery_QRS, Me.m_blnQxControl) = False Then
                    GoTo errProc
                End If

                '获取原排序命令
                With Me.m_objDataSet_QRS.Tables(strTable)
                    strOldCommand = .DefaultView.Sort
                End With

                '获取要执行的排序命令
                objDataGridProcess.getColumnSortCommand(strErrMsg, strOldCommand, e.SortExpression, strFinalCommand, objenumSortType)
                If strErrMsg <> "" Then
                    GoTo errProc
                End If

                '执行排序
                With Me.m_objDataSet_QRS.Tables(strTable)
                    .DefaultView.Sort = strFinalCommand
                End With

                '获取排序列的列索引
                objDataGridItem = CType(e.CommandSource, System.Web.UI.WebControls.DataGridItem)
                strUniqueId = Request.Form("__EVENTTARGET")
                intColumnIndex = objDataGridProcess.getColumnIndexByUniqueIdInRow(objDataGridItem, strUniqueId)

                '保存排序信息
                Me.htxtQRSSortColumnIndex.Value = intColumnIndex.ToString()
                Me.htxtQRSSortType.Value = CType(objenumSortType, Integer).ToString()
                Me.htxtQRSSort.Value = strFinalCommand

                '重新显示数据
                If Me.showModuleData(strErrMsg) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub grdQRS_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdQRS.ItemCommand

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                Dim strControlId As String
                Dim intColIndex As Integer

                '定位
                Me.grdQRS.SelectedIndex = e.Item.ItemIndex

                '处理
                Select Case e.CommandName.ToUpper
                    Case "OpenDocument".ToUpper
                        strControlId = objDataGridProcess.getPostbackControlId(e.CommandSource)
                        Me.doOpen(strControlId)
                    Case Else
                End Select
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub














        Private Sub doMoveFirst(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_QRS(strErrMsg, Me.m_strQuery_QRS, Me.m_blnQxControl) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(0, Me.grdQRS.PageCount)
                Me.grdQRS.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData(strErrMsg) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doMoveLast(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_QRS(strErrMsg, Me.m_strQuery_QRS, Me.m_blnQxControl) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdQRS.PageCount - 1, Me.grdQRS.PageCount)
                Me.grdQRS.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData(strErrMsg) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doMoveNext(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_QRS(strErrMsg, Me.m_strQuery_QRS, Me.m_blnQxControl) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdQRS.CurrentPageIndex + 1, Me.grdQRS.PageCount)
                Me.grdQRS.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData(strErrMsg) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doMovePrevious(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_QRS(strErrMsg, Me.m_strQuery_QRS, Me.m_blnQxControl) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdQRS.CurrentPageIndex - 1, Me.grdQRS.PageCount)
                Me.grdQRS.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData(strErrMsg) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doGotoPage(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '获取新的页大小
            Dim intPageIndex As Integer
            intPageIndex = objPulicParameters.getObjectValue(Me.txtQRSPageIndex.Text, 0)
            If intPageIndex <= 0 Then
                intPageIndex = 0
            Else
                intPageIndex -= 1
            End If

            Try
                '获取数据
                If Me.getModuleData_QRS(strErrMsg, Me.m_strQuery_QRS, Me.m_blnQxControl) = False Then
                    GoTo errProc
                End If

                '设置新的页
                Me.grdQRS.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData(strErrMsg) = False Then
                    GoTo errProc
                End If

                '信息同步
                Me.txtQRSPageIndex.Text = (Me.grdQRS.CurrentPageIndex + 1).ToString()

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doSetPageSize(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '获取新的页大小
            Dim intPageSize As Integer
            intPageSize = objPulicParameters.getObjectValue(Me.txtQRSPageSize.Text, 100)
            If intPageSize <= 0 Then intPageSize = 100

            Try
                '获取数据
                If Me.getModuleData_QRS(strErrMsg, Me.m_strQuery_QRS, Me.m_blnQxControl) = False Then
                    GoTo errProc
                End If

                '设置新的页大小
                Me.grdQRS.PageSize = intPageSize

                '刷新网格显示
                If Me.showModuleData(strErrMsg) = False Then
                    GoTo errProc
                End If

                '信息同步
                Me.txtQRSPageSize.Text = (Me.grdQRS.PageSize).ToString()
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doSelectAll(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdQRS, 0, Me.m_cstrCheckBoxIdInDataGrid_QRS, True) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doDeSelectAll(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdQRS, 0, Me.m_cstrCheckBoxIdInDataGrid_QRS, False) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doSearch(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '搜索数据
                If Me.searchModuleData_QRS(strErrMsg, Me.m_blnQxControl) = False Then
                    GoTo errProc
                End If

                '刷新网格显示
                If Me.showModuleData(strErrMsg) = False Then
                    GoTo errProc
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

        Private Sub lnkCZQRSMoveFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZQRSMoveFirst.Click
            Me.doMoveFirst("lnkCZQRSMoveFirst")
        End Sub

        Private Sub lnkCZQRSMoveLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZQRSMoveLast.Click
            Me.doMoveLast("lnkCZQRSMoveLast")
        End Sub

        Private Sub lnkCZQRSMoveNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZQRSMoveNext.Click
            Me.doMoveNext("lnkCZQRSMoveNext")
        End Sub

        Private Sub lnkCZQRSMovePrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZQRSMovePrev.Click
            Me.doMovePrevious("lnkCZQRSMovePrev")
        End Sub

        Private Sub lnkCZQRSGotoPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZQRSGotoPage.Click
            Me.doGotoPage("lnkCZQRSGotoPage")
        End Sub

        Private Sub lnkCZQRSSetPageSize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZQRSSetPageSize.Click
            Me.doSetPageSize("lnkCZQRSSetPageSize")
        End Sub

        Private Sub lnkCZQRSSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZQRSSelectAll.Click
            Me.doSelectAll("lnkCZQRSSelectAll")
        End Sub

        Private Sub lnkCZQRSDeSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZQRSDeSelectAll.Click
            Me.doDeSelectAll("lnkCZQRSDeSelectAll")
        End Sub

        Private Sub btnQRSSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnQRSSearch.Click
            Me.doSearch("btnQRSSearch")
        End Sub











        '----------------------------------------------------------------
        '模块特殊操作处理器
        '----------------------------------------------------------------
        Private Sub doAddNew(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '备份现场参数
                Dim strSessionId As String = ""
                strSessionId = Me.saveModuleInformation()
                If strSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim objIEstateEsQrsQtInfo As Josco.JSOA.BusinessFacade.IEstateEsQrsQtInfo = Nothing
                Dim strUrl As String = ""
                objIEstateEsQrsQtInfo = New Josco.JSOA.BusinessFacade.IEstateEsQrsQtInfo
                With objIEstateEsQrsQtInfo
                    .iMode = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                    .iQRSH = ""
                    .iSourceControlId = strControlId
                    If Me.m_blnInterface = True Then
                        strUrl = ""
                        strUrl += Request.Url.AbsolutePath
                        strUrl += "?"
                        strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                        strUrl += "="
                        strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                        strUrl += "&"
                        strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                        strUrl += "="
                        strUrl += strSessionId
                    Else
                        strUrl = ""
                        strUrl += Request.Url.AbsolutePath
                        strUrl += "?"
                        strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                        strUrl += "="
                        strUrl += strSessionId
                    End If
                    .iReturnUrl = strUrl
                End With

                '调用模块
                Dim strNewSessionId As String = ""
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIEstateEsQrsQtInfo)

                strUrl = ""
                strUrl += "estate_es_qrsqt_info.aspx"
                strUrl += "?"
                strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                strUrl += "="
                strUrl += strNewSessionId
                Response.Redirect(strUrl)
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doUpdate(ByVal strControlId As String)

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '检查
                If Me.grdQRS.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有选定[确认书]！"
                    GoTo errProc
                End If
                Dim intColIndex As Integer = -1
                Dim strQRSH As String = ""
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdQRS, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_QRSH)
                strQRSH = objDataGridProcess.getDataGridCellValue(Me.grdQRS.Items(Me.grdQRS.SelectedIndex), intColIndex)
                strQRSH = strQRSH.Trim
                If strQRSH = "" Then
                    strErrMsg = "错误：没有[确认书]！"
                    GoTo errProc
                End If
                '已签合同？
                Dim blnIS As Boolean
                If objsystemEstateErshou.isQianHetong(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, blnIS) = False Then
                    GoTo errProc
                End If
                If blnIS = True Then
                    strErrMsg = "错误：已经签订合同，不能更改！"
                    GoTo errProc
                End If

                '备份现场参数
                Dim strSessionId As String = ""
                strSessionId = Me.saveModuleInformation()
                If strSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim objIEstateEsQrsQtInfo As Josco.JSOA.BusinessFacade.IEstateEsQrsQtInfo = Nothing
                Dim strUrl As String = ""
                objIEstateEsQrsQtInfo = New Josco.JSOA.BusinessFacade.IEstateEsQrsQtInfo
                With objIEstateEsQrsQtInfo
                    .iMode = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate
                    .iQRSH = strQRSH
                    .iSourceControlId = strControlId
                    If Me.m_blnInterface = True Then
                        strUrl = ""
                        strUrl += Request.Url.AbsolutePath
                        strUrl += "?"
                        strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                        strUrl += "="
                        strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                        strUrl += "&"
                        strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                        strUrl += "="
                        strUrl += strSessionId
                    Else
                        strUrl = ""
                        strUrl += Request.Url.AbsolutePath
                        strUrl += "?"
                        strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                        strUrl += "="
                        strUrl += strSessionId
                    End If
                    .iReturnUrl = strUrl
                End With

                '调用模块
                Dim strNewSessionId As String = ""
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIEstateEsQrsQtInfo)

                strUrl = ""
                strUrl += "estate_es_qrsqt_info.aspx"
                strUrl += "?"
                strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                strUrl += "="
                strUrl += strNewSessionId
                Response.Redirect(strUrl)

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doOpen(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '检查
                If Me.grdQRS.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有选定[确认书]！"
                    GoTo errProc
                End If
                Dim intColIndex As Integer = -1
                Dim strQRSH As String = ""
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdQRS, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_QRSH)
                strQRSH = objDataGridProcess.getDataGridCellValue(Me.grdQRS.Items(Me.grdQRS.SelectedIndex), intColIndex)
                strQRSH = strQRSH.Trim
                If strQRSH = "" Then
                    strErrMsg = "错误：没有选定[确认书]！"
                    GoTo errProc
                End If

                '备份现场参数
                Dim strSessionId As String = ""
                strSessionId = Me.saveModuleInformation()
                If strSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim objIEstateEsQrsQtInfo As Josco.JSOA.BusinessFacade.IEstateEsQrsQtInfo = Nothing
                Dim strUrl As String = ""
                objIEstateEsQrsQtInfo = New Josco.JSOA.BusinessFacade.IEstateEsQrsQtInfo
                With objIEstateEsQrsQtInfo
                    .iMode = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect
                    .iQRSH = strQRSH
                    .iSourceControlId = strControlId
                    If Me.m_blnInterface = True Then
                        strUrl = ""
                        strUrl += Request.Url.AbsolutePath
                        strUrl += "?"
                        strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                        strUrl += "="
                        strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                        strUrl += "&"
                        strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                        strUrl += "="
                        strUrl += strSessionId
                    Else
                        strUrl = ""
                        strUrl += Request.Url.AbsolutePath
                        strUrl += "?"
                        strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                        strUrl += "="
                        strUrl += strSessionId
                    End If
                    .iReturnUrl = strUrl
                End With

                '调用模块
                Dim strNewSessionId As String = ""
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIEstateEsQrsQtInfo)

                strUrl = ""
                strUrl += "estate_es_qrsqt_info.aspx"
                strUrl += "?"
                strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                strUrl += "="
                strUrl += strNewSessionId
                Response.Redirect(strUrl)
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doDelete(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_QUERENSHU_QT
            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String
            Dim intStep As Integer

            Try
                intStep = 1
                '检查选择
                If Me.grdQRS.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有当前[确认书]！"
                    GoTo errProc
                End If
                Dim i As Integer = Me.grdQRS.SelectedIndex
                Dim intColIndex As Integer = 0
                Dim strWYBS As String = ""
                Dim strQRSH As String = ""
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdQRS, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_WYBS)
                strWYBS = objDataGridProcess.getDataGridCellValue(Me.grdQRS.Items(i), intColIndex)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdQRS, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_QRSH)
                strQRSH = objDataGridProcess.getDataGridCellValue(Me.grdQRS.Items(i), intColIndex)
                '已签合同？
                Dim blnIS As Boolean
                If objsystemEstateErshou.isQianHetong(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, blnIS) = False Then
                    GoTo errProc
                End If
                If blnIS = True Then
                    strErrMsg = "错误：已经签订合同，不能删除！"
                    GoTo errProc
                End If

                '询问
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "提示：您确实准备删除当前[" + strQRSH + "]吗（是/否）？", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '提示后回答“是”接着处理
                intStep = 3
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '删除处理
                    If objsystemEstateErshou.doDeleteData_ES_QRS_QT(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWYBS) = False Then
                        GoTo errProc
                    End If

                    '记录审计日志
                    Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]在[二手_其他确认书]中[删除]了[" + strQRSH + "]！")

                    '重新获取数据
                    If Me.getModuleData_QRS(strErrMsg, Me.m_strQuery_QRS, Me.m_blnQxControl) = False Then
                        GoTo errProc
                    End If

                    '刷新网格显示
                    If Me.showModuleData(strErrMsg) = False Then
                        GoTo errProc
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        'zengxianglin 2008-11-18
        Private Sub doDelWtj(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_QUERENSHU_QT
            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String
            Dim intStep As Integer

            Try
                intStep = 1
                '检查选择
                If Me.grdQRS.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有当前[确认书]！"
                    GoTo errProc
                End If
                Dim i As Integer = Me.grdQRS.SelectedIndex
                Dim intColIndex As Integer = 0
                Dim strWYBS As String = ""
                Dim strQRSH As String = ""
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdQRS, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_WYBS)
                strWYBS = objDataGridProcess.getDataGridCellValue(Me.grdQRS.Items(i), intColIndex)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdQRS, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_QRSH)
                strQRSH = objDataGridProcess.getDataGridCellValue(Me.grdQRS.Items(i), intColIndex)

                '询问
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "提示：您确实准备删除当前[" + strQRSH + "]吗（是/否）？", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '提示后回答“是”接着处理
                intStep = 3
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '删除处理
                    If objsystemEstateErshou.doDeleteData_ES_QRS_QT(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWYBS) = False Then
                        GoTo errProc
                    End If

                    '记录审计日志
                    Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]在[二手_其他确认书]中[删除]了[" + strQRSH + "]！")

                    '重新获取数据
                    If Me.getModuleData_QRS(strErrMsg, Me.m_strQuery_QRS, Me.m_blnQxControl) = False Then
                        GoTo errProc
                    End If

                    '刷新网格显示
                    If Me.showModuleData(strErrMsg) = False Then
                        GoTo errProc
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub
        'zengxianglin 2008-11-18

        Private Sub doClose(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                Dim strSessionId As String
                Dim strUrl As String
                If Me.m_blnInterface = True Then
                    '设置返回参数
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

        Private Sub doSearchFull(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_QUERENSHU_QT
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objISjcxCxtj As Josco.JsKernal.BusinessFacade.ISjcxCxtj = Nothing
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strNewSessionId As String = ""
            Dim strSessionId As String = ""
            Dim strErrMsg As String = ""

            Try
                '获取数据
                If Me.getModuleData_QRS(strErrMsg, Me.m_strQuery_QRS, Me.m_blnQxControl) = False Then
                    GoTo errProc
                End If

                '备份现场参数
                strSessionId = Me.saveModuleInformation()
                If strSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim strUrl As String
                objISjcxCxtj = New Josco.JsKernal.BusinessFacade.ISjcxCxtj
                With objISjcxCxtj
                    If Me.htxtSessionIdQuery.Value.Trim <> "" Then
                        .iDataSetTJ = CType(Session(Me.htxtSessionIdQuery.Value), Josco.JsKernal.Common.Data.QueryData)
                    Else
                        .iDataSetTJ = Nothing
                    End If
                    .iQueryTable = Me.m_objDataSet_QRS.Tables(strTable)
                    .iFixQuery = ""

                    .iSourceControlId = strControlId
                    If Me.m_blnInterface = True Then
                        strUrl = ""
                        strUrl += Request.Url.AbsolutePath
                        strUrl += "?"
                        strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                        strUrl += "="
                        strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                        strUrl += "&"
                        strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                        strUrl += "="
                        strUrl += strSessionId
                    Else
                        strUrl = ""
                        strUrl += Request.Url.AbsolutePath
                        strUrl += "?"
                        strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                        strUrl += "="
                        strUrl += strSessionId
                    End If
                    .iReturnUrl = strUrl
                End With

                '调用模块
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objISjcxCxtj)
                strUrl = ""
                strUrl += "../../sjcx/sjcx_cxtj.aspx"
                strUrl += "?"
                strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                strUrl += "="
                strUrl += strNewSessionId
                Response.Redirect(strUrl)
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doTading(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_QUERENSHU_QT
            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String
            Dim intStep As Integer

            Try
                intStep = 1
                '检查选择
                If Me.grdQRS.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有当前[确认书]！"
                    GoTo errProc
                End If
                Dim i As Integer = Me.grdQRS.SelectedIndex
                Dim intColIndex As Integer = 0
                Dim intStatus As Integer = 0
                Dim strWYBS As String = ""
                Dim strQRSH As String = ""
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdQRS, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_WYBS)
                strWYBS = objDataGridProcess.getDataGridCellValue(Me.grdQRS.Items(i), intColIndex)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdQRS, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_QRSH)
                strQRSH = objDataGridProcess.getDataGridCellValue(Me.grdQRS.Items(i), intColIndex)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdQRS, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_DGZT)
                intStatus = CType(objDataGridProcess.getDataGridCellValue(Me.grdQRS.Items(i), intColIndex), Integer)
                '已签合同？
                Dim blnIS As Boolean
                If objsystemEstateErshou.isQianHetong(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, blnIS) = False Then
                    GoTo errProc
                End If
                If blnIS = True Then
                    strErrMsg = "错误：已经签订合同，不能挞定！"
                    GoTo errProc
                End If
                If Josco.JSOA.Common.Data.estateErshouData.getQuerenshuStatus(intStatus) = Josco.JSOA.Common.Data.estateErshouData.enumQuerenshuStatus.Tading Then
                    strErrMsg = "错误：已经挞定！"
                    GoTo errProc
                End If

                '询问
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "提示：您确实准备挞定当前[" + strQRSH + "]吗（是/否）？", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '提示后回答“是”接着处理
                intStep = 3
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '处理
                    If objsystemEstateErshou.doTading_ES_QRS_QT(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWYBS) = False Then
                        GoTo errProc
                    End If

                    '记录审计日志
                    Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]在[二手_其他确认书]中[挞定]了[" + strQRSH + "]！")

                    '重新获取数据
                    If Me.getModuleData_QRS(strErrMsg, Me.m_strQuery_QRS, Me.m_blnQxControl) = False Then
                        GoTo errProc
                    End If

                    '刷新网格显示
                    If Me.showModuleData(strErrMsg) = False Then
                        GoTo errProc
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doOpen_SSSF(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '检查
                If Me.grdQRS.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有[确认书]！"
                    GoTo errProc
                End If
                Dim i As Integer = Me.grdQRS.SelectedIndex
                Dim intColIndex As Integer = 0
                Dim strQRSH As String = ""
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdQRS, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_QRSH)
                strQRSH = objDataGridProcess.getDataGridCellValue(Me.grdQRS.Items(i), intColIndex)
                If strQRSH = "" Then
                    strErrMsg = "错误：没有选定[确认书]！"
                    GoTo errProc
                End If

                '备份现场参数
                Dim strSessionId As String = ""
                strSessionId = Me.saveModuleInformation()
                If strSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim objIEstateCwSssf As Josco.JSOA.BusinessFacade.IEstateCwSssf = Nothing
                Dim strUrl As String = ""
                objIEstateCwSssf = New Josco.JSOA.BusinessFacade.IEstateCwSssf
                With objIEstateCwSssf
                    .iQRSH = strQRSH
                    .iSourceControlId = strControlId
                    If Me.m_blnInterface = True Then
                        strUrl = ""
                        strUrl += Request.Url.AbsolutePath
                        strUrl += "?"
                        strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                        strUrl += "="
                        strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                        strUrl += "&"
                        strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                        strUrl += "="
                        strUrl += strSessionId
                    Else
                        strUrl = ""
                        strUrl += Request.Url.AbsolutePath
                        strUrl += "?"
                        strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                        strUrl += "="
                        strUrl += strSessionId
                    End If
                    .iReturnUrl = strUrl
                End With

                '调用模块
                Dim strNewSessionId As String = ""
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIEstateCwSssf)

                strUrl = ""
                strUrl += "../caiwu/estate_cw_sssf.aspx"
                strUrl += "?"
                strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                strUrl += "="
                strUrl += strNewSessionId
                Response.Redirect(strUrl)
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        'zengxianglin 2009-05-17 更改
        Private Sub doPrint(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_QUERENSHU_QT_PRN
            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objDataSet As Josco.JSOA.Common.Data.estateErshouData = Nothing
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                'zengxianglin 2009-05-17
                '获取打印专用数据集
                'zengxianglin 2009-05-17
                '获取打印数据
                If Me.getModuleData_QRS_PRN(strErrMsg, Me.m_strQuery_QRS, Me.m_blnQxControl, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(strTable) Is Nothing Then
                    strErrMsg = "错误：还未获取数据！"
                    GoTo errProc
                End If
                With objDataSet.Tables(strTable)
                    If .Rows.Count < 1 Then
                        strErrMsg = "错误：没有数据！"
                        GoTo errProc
                    End If
                End With

                '准备Excel文件
                Dim strDesExcelPath As String = Request.ApplicationPath + Me.m_cstrPrintCacheRelativePathToAppRoot
                Dim strSrcExcelSpec As String = Request.ApplicationPath + Me.m_cstrExcelMBRelativePathToAppRoot + "广州兴业_合同管理_其他确认书.xls"
                Dim strDesExcelFile As String = ""
                Dim strDesExcelSpec As String = ""
                strDesExcelPath = Server.MapPath(strDesExcelPath)
                strSrcExcelSpec = Server.MapPath(strSrcExcelSpec)
                If objBaseLocalFile.doCopyToTempFile(strErrMsg, strSrcExcelSpec, strDesExcelPath, strDesExcelFile) = False Then
                    GoTo errProc
                End If
                strDesExcelSpec = objBaseLocalFile.doMakePath(strDesExcelPath, strDesExcelFile)

                '导出文件
                Dim strMacroValue As String = ""
                Dim strMacroName As String = ""
                strMacroName = "$Macro$QCRQ$,$Macro$QMRQ$,$Macro$GSMC$"
                strMacroValue = Me.txtQRSSearch_DGRQMin.Text + "," + Me.txtQRSSearch_DGRQMax.Text + "," + "兴业公司"
                If objsystemEstateErshou.doExportToExcel(strErrMsg, objDataSet, strDesExcelSpec, strMacroName, strMacroValue, "yyyy-MM-dd") = False Then
                    GoTo errProc
                End If

                '打开临时Excel文件
                Dim strUrl As String = Request.ApplicationPath + Me.m_cstrPrintCacheRelativePathToAppRoot + strDesExcelFile
                objMessageProcess.doOpenUrl(Me.popMessageObject, strUrl, "_blank", "titlebar=yes,menubar=yes,resizable=yes,scrollbars=yes,status=yes")
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
        End Sub

        Private Sub btnQRSSearch_Full_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnQRSSearch_Full.Click
            Me.doSearchFull("btnQRSSearch_Full")
        End Sub

        Private Sub btnScyj_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnScyj.Click
            Me.doOpen_SSSF("btnScyj")
        End Sub

        Private Sub btnAddNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNew.Click
            Me.doAddNew("btnAddNew")
        End Sub

        Private Sub btnOpen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOpen.Click
            Me.doOpen("btnOpen")
        End Sub

        Private Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            Me.doUpdate("btnUpdate")
        End Sub

        Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
            Me.doDelete("btnDelete")
        End Sub

        'zengxianglin 2008-11-18
        Private Sub btnDelWtj_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelWtj.Click
            Me.doDelWtj("btnDelWtj")
        End Sub
        'zengxianglin 2008-11-18

        Private Sub btnTading_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTading.Click
            Me.doTading("btnTading")
        End Sub

        Private Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
            Me.doPrint("btnPrint")
        End Sub

        Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
            Me.doClose("btnClose")
        End Sub

    End Class

End Namespace
