Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.web
    ' 类名    ：estate_es_hetong_sh
    ' 
    ' 调用性质：
    '     I/O
    '
    ' 功能描述： 
    '   　“合同审核”处理模块
    '----------------------------------------------------------------

    Partial Class estate_es_hetong_sh
        Inherits Josco.JsKernal.web.PageBase

#Region " Web 窗体设计器生成的代码 "

        '该调用是 Web 窗体设计器所必需的。
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub






        'zengxianglin 2009-02-24
        'zengxianglin 2009-02-24




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
        Private m_cstrPrevilegeParamPrefix As String = "estate_es_hetong_previlege_param"
        Private m_blnPrevilegeParams(15) As Boolean

        '----------------------------------------------------------------
        '模块现场保留参数，恢复完成后立即释放session资源
        '----------------------------------------------------------------
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMEstateEsHetongSh
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        '模块接口参数
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IEstateEsHetongSh
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '与数据网格grdHT相关的参数
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_HT As String = "chkHT"
        Private Const m_cstrDataGridInDIV_HT As String = "divHT"
        Private m_intFixedColumns_HT As Integer

        '----------------------------------------------------------------
        '与数据网格grdSHQK相关的参数
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_SHQK As String = "chkSHQK"
        Private Const m_cstrDataGridInDIV_SHQK As String = "divSHQK"
        Private m_intFixedColumns_SHQK As Integer

        '----------------------------------------------------------------
        '当前处理的数据集
        '----------------------------------------------------------------
        Private m_objDataSet_SHQK As Josco.JSOA.Common.Data.estateErshouData
        Private m_objDataSet_HT As Josco.JSOA.Common.Data.estateErshouData
        Private m_strQuery_HT As String
        Private m_intRows_HT As Integer

        '----------------------------------------------------------------
        '模块接口参数
        '----------------------------------------------------------------
        Private m_strQRSH As String

        '----------------------------------------------------------------
        '其他模块私用参数
        '----------------------------------------------------------------
        Private m_blnQxControl As Boolean

        Public ReadOnly Property propQRSH() As String
            Get
                propQRSH = Me.m_strQRSH
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
                        Me.m_objInterface = CType(Session(strSessionId), Josco.JSOA.BusinessFacade.IEstateEsHetongSh)
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
                Dim strFirstParamValue As String = ""
                Dim strParamValue As String = ""
                Dim strParamName As String = ""
                Dim strFilter As String = ""
                Dim strMKMC As String = ""
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
                    Me.htxtDivLeftHT.Value = .htxtDivLeftHT
                    Me.htxtDivTopHT.Value = .htxtDivTopHT
                    Me.htxtDivLeftSHQK.Value = .htxtDivLeftSHQK
                    Me.htxtDivTopSHQK.Value = .htxtDivTopSHQK

                    Me.htxtHTQuery.Value = .htxtHTQuery
                    Me.htxtHTRows.Value = .htxtHTRows
                    Me.htxtHTSort.Value = .htxtHTSort
                    Me.htxtHTSortColumnIndex.Value = .htxtHTSortColumnIndex
                    Me.htxtHTSortType.Value = .htxtHTSortType

                    Me.txtHTSearch_HTBH.Text = .txtHTSearch_HTBH
                    Me.txtHTSearch_QRSH.Text = .txtHTSearch_QRSH
                    Me.txtHTSearch_JFMC.Text = .txtHTSearch_JFMC
                    Me.txtHTSearch_YFMC.Text = .txtHTSearch_YFMC
                    Me.txtHTSearch_FWDZ.Text = .txtHTSearch_FWDZ
                    Me.txtHTSearch_HTRQMax.Text = .txtHTSearch_HTRQMax
                    Me.txtHTSearch_HTRQMin.Text = .txtHTSearch_HTRQMin
                    Me.ddlHTSearch_HTZT.SelectedIndex = .ddlHTSearch_HTZT_SelectedIndex

                    Me.txtHTPageIndex.Text = .txtHTPageIndex
                    Me.txtHTPageSize.Text = .txtHTPageSize

                    Try
                        Me.grdHT.PageSize = .grdHTPageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdHT.CurrentPageIndex = .grdHTCurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdHT.SelectedIndex = .grdHTSelectedIndex
                    Catch ex As Exception
                    End Try
                    Me.htxtSessionIdQueryHT.Value = .htxtSessionIdQueryHT

                    Try
                        Me.grdSHQK.PageSize = .grdSHQKPageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdSHQK.CurrentPageIndex = .grdSHQKCurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdSHQK.SelectedIndex = .grdSHQKSelectedIndex
                    Catch ex As Exception
                    End Try
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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMEstateEsHetongSh

                '保存现场信息
                With Me.m_objSaveScence
                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftHT = Me.htxtDivLeftHT.Value
                    .htxtDivTopHT = Me.htxtDivTopHT.Value
                    .htxtDivLeftSHQK = Me.htxtDivLeftSHQK.Value
                    .htxtDivTopSHQK = Me.htxtDivTopSHQK.Value

                    .htxtHTQuery = Me.htxtHTQuery.Value
                    .htxtHTRows = Me.htxtHTRows.Value
                    .htxtHTSort = Me.htxtHTSort.Value
                    .htxtHTSortColumnIndex = Me.htxtHTSortColumnIndex.Value
                    .htxtHTSortType = Me.htxtHTSortType.Value

                    .txtHTSearch_HTBH = Me.txtHTSearch_HTBH.Text
                    .txtHTSearch_QRSH = Me.txtHTSearch_QRSH.Text
                    .txtHTSearch_JFMC = Me.txtHTSearch_JFMC.Text
                    .txtHTSearch_YFMC = Me.txtHTSearch_YFMC.Text
                    .txtHTSearch_FWDZ = Me.txtHTSearch_FWDZ.Text
                    .txtHTSearch_HTRQMax = Me.txtHTSearch_HTRQMax.Text
                    .txtHTSearch_HTRQMin = Me.txtHTSearch_HTRQMin.Text
                    .ddlHTSearch_HTZT_SelectedIndex = Me.ddlHTSearch_HTZT.SelectedIndex

                    .txtHTPageIndex = Me.txtHTPageIndex.Text
                    .txtHTPageSize = Me.txtHTPageSize.Text

                    .grdHTPageSize = Me.grdHT.PageSize
                    .grdHTCurrentPageIndex = Me.grdHT.CurrentPageIndex
                    .grdHTSelectedIndex = Me.grdHT.SelectedIndex
                    .htxtSessionIdQueryHT = Me.htxtSessionIdQueryHT.Value

                    .grdSHQKPageSize = Me.grdSHQK.PageSize
                    .grdSHQKCurrentPageIndex = Me.grdSHQK.CurrentPageIndex
                    .grdSHQKSelectedIndex = Me.grdSHQK.SelectedIndex
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

                'zengxianglin 2008-11-18
                '==========================================================================================================================================================
                Dim objIEstateEsHetongQtInfo As Josco.JSOA.BusinessFacade.IEstateEsHetongQtInfo = Nothing
                Try
                    objIEstateEsHetongQtInfo = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IEstateEsHetongQtInfo)
                Catch ex As Exception
                    objIEstateEsHetongQtInfo = Nothing
                End Try
                If Not (objIEstateEsHetongQtInfo Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IEstateEsHetongQtInfo.SafeRelease(objIEstateEsHetongQtInfo)
                    Exit Try
                End If
                'zengxianglin 2008-11-18

                '==========================================================================================================================================================
                Dim objIEstateEsHetongZlInfo As Josco.JSOA.BusinessFacade.IEstateEsHetongZlInfo = Nothing
                Try
                    objIEstateEsHetongZlInfo = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IEstateEsHetongZlInfo)
                Catch ex As Exception
                    objIEstateEsHetongZlInfo = Nothing
                End Try
                If Not (objIEstateEsHetongZlInfo Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IEstateEsHetongZlInfo.SafeRelease(objIEstateEsHetongZlInfo)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIEstateEsHetongMmInfo As Josco.JSOA.BusinessFacade.IEstateEsHetongMmInfo = Nothing
                Try
                    objIEstateEsHetongMmInfo = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IEstateEsHetongMmInfo)
                Catch ex As Exception
                    objIEstateEsHetongMmInfo = Nothing
                End Try
                If Not (objIEstateEsHetongMmInfo Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IEstateEsHetongMmInfo.SafeRelease(objIEstateEsHetongMmInfo)
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
                        Me.htxtHTQuery.Value = objISjcxCxtj.oQueryString
                        If Me.htxtSessionIdQueryHT.Value.Trim = "" Then
                            Me.htxtSessionIdQueryHT.Value = objPulicParameters.getNewGuid()
                        Else
                            Try
                                objQueryData = CType(Session(Me.htxtSessionIdQueryHT.Value), Josco.JsKernal.Common.Data.QueryData)
                            Catch ex As Exception
                                objQueryData = Nothing
                            End Try
                            Josco.JsKernal.Common.Data.QueryData.SafeRelease(objQueryData)
                        End If
                        Session.Add(Me.htxtSessionIdQueryHT.Value, objISjcxCxtj.oDataSetTJ)
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
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IEstateEsHetongSh)
                Catch ex As Exception
                    m_objInterface = Nothing
                End Try
                If m_objInterface Is Nothing Then
                    Me.m_blnInterface = False
                    '没有有接口参数
                    Me.m_strQRSH = ""
                Else
                    Me.m_blnInterface = True
                    '有接口参数
                    Me.m_strQRSH = Me.m_objInterface.iQRSH
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
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMEstateEsHetongSh)
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

                Me.m_strQuery_HT = Me.htxtHTQuery.Value
                Me.m_intRows_HT = objPulicParameters.getObjectValue(Me.htxtHTRows.Value, 0)
                Me.m_intFixedColumns_HT = objPulicParameters.getObjectValue(Me.htxtHTFixed.Value, 0)

                Me.m_intFixedColumns_SHQK = objPulicParameters.getObjectValue(Me.htxtSHQKFixed.Value, 0)
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
                If Me.htxtSessionIdQueryHT.Value.Trim <> "" Then
                    Dim objQueryData As Josco.JsKernal.Common.Data.QueryData
                    Try
                        objQueryData = CType(Session(Me.htxtSessionIdQueryHT.Value), Josco.JsKernal.Common.Data.QueryData)
                    Catch ex As Exception
                        objQueryData = Nothing
                    End Try
                    Josco.JsKernal.Common.Data.QueryData.SafeRelease(objQueryData)
                    Session.Remove(Me.htxtSessionIdQueryHT.Value)
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
        Private Function getQueryString_HT( _
            ByRef strErrMsg As String, _
            ByRef strQuery As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getQueryString_HT = False
            strQuery = ""

            Try
                '按“确认书号”搜索
                Dim strQRSH As String = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_JYBH
                If Me.txtHTSearch_QRSH.Text.Length > 0 Then Me.txtHTSearch_QRSH.Text = Me.txtHTSearch_QRSH.Text.Trim()
                If Me.txtHTSearch_QRSH.Text <> "" Then
                    Me.txtHTSearch_QRSH.Text = objPulicParameters.getNewSearchString(Me.txtHTSearch_QRSH.Text)
                    If strQuery = "" Then
                        strQuery = strQRSH + " like '" + Me.txtHTSearch_QRSH.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strQRSH + " like '" + Me.txtHTSearch_QRSH.Text + "%'"
                    End If
                End If

                '按“合同编号”搜索
                Dim strHTBH As String = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_HTBH
                If Me.txtHTSearch_HTBH.Text.Length > 0 Then Me.txtHTSearch_HTBH.Text = Me.txtHTSearch_HTBH.Text.Trim()
                If Me.txtHTSearch_HTBH.Text <> "" Then
                    Me.txtHTSearch_HTBH.Text = objPulicParameters.getNewSearchString(Me.txtHTSearch_HTBH.Text)
                    If strQuery = "" Then
                        strQuery = strHTBH + " like '" + Me.txtHTSearch_HTBH.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strHTBH + " like '" + Me.txtHTSearch_HTBH.Text + "%'"
                    End If
                End If

                '按“甲方名称”搜索
                Dim strJFMC As String = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_YZMC
                If Me.txtHTSearch_JFMC.Text.Length > 0 Then Me.txtHTSearch_JFMC.Text = Me.txtHTSearch_JFMC.Text.Trim()
                If Me.txtHTSearch_JFMC.Text <> "" Then
                    Me.txtHTSearch_JFMC.Text = objPulicParameters.getNewSearchString(Me.txtHTSearch_JFMC.Text)
                    If strQuery = "" Then
                        strQuery = strJFMC + " like '" + Me.txtHTSearch_JFMC.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strJFMC + " like '" + Me.txtHTSearch_JFMC.Text + "%'"
                    End If
                End If

                '按“乙方名称”搜索
                Dim strYFMC As String = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_KHMC
                If Me.txtHTSearch_YFMC.Text.Length > 0 Then Me.txtHTSearch_YFMC.Text = Me.txtHTSearch_YFMC.Text.Trim()
                If Me.txtHTSearch_YFMC.Text <> "" Then
                    Me.txtHTSearch_YFMC.Text = objPulicParameters.getNewSearchString(Me.txtHTSearch_YFMC.Text)
                    If strQuery = "" Then
                        strQuery = strYFMC + " like '" + Me.txtHTSearch_YFMC.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strYFMC + " like '" + Me.txtHTSearch_YFMC.Text + "%'"
                    End If
                End If

                '按“房屋地址”搜索
                Dim strFWDZ As String = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_WYDZ
                If Me.txtHTSearch_FWDZ.Text.Length > 0 Then Me.txtHTSearch_FWDZ.Text = Me.txtHTSearch_FWDZ.Text.Trim()
                If Me.txtHTSearch_FWDZ.Text <> "" Then
                    Me.txtHTSearch_FWDZ.Text = objPulicParameters.getNewSearchString(Me.txtHTSearch_FWDZ.Text)
                    If strQuery = "" Then
                        strQuery = strFWDZ + " like '" + Me.txtHTSearch_FWDZ.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strFWDZ + " like '" + Me.txtHTSearch_FWDZ.Text + "%'"
                    End If
                End If

                '按“合同状态”搜索
                Dim strHTZT As String = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_HTZT
                Select Case Me.ddlHTSearch_HTZT.SelectedIndex
                    Case Is > 0
                        If strQuery = "" Then
                            strQuery = strHTZT + Me.ddlHTSearch_HTZT.SelectedValue
                        Else
                            strQuery = strQuery + " and " + strHTZT + Me.ddlHTSearch_HTZT.SelectedValue
                        End If
                    Case Else
                End Select

                Dim dateMin As System.DateTime
                Dim dateMax As System.DateTime

                '按“合同日期”搜索
                Dim strHTRQ As String
                strHTRQ = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_HTRQ
                If Me.txtHTSearch_HTRQMin.Text.Length > 0 Then Me.txtHTSearch_HTRQMin.Text = Me.txtHTSearch_HTRQMin.Text.Trim()
                If Me.txtHTSearch_HTRQMax.Text.Length > 0 Then Me.txtHTSearch_HTRQMax.Text = Me.txtHTSearch_HTRQMax.Text.Trim()
                If Me.txtHTSearch_HTRQMin.Text <> "" And Me.txtHTSearch_HTRQMax.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtHTSearch_HTRQMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的时间！"
                        GoTo errProc
                    End Try
                    Try
                        dateMax = CType(Me.txtHTSearch_HTRQMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的时间！"
                        GoTo errProc
                    End Try
                    If dateMin > dateMax Then
                        Me.txtHTSearch_HTRQMin.Text = dateMax.ToString("yyyy-MM-dd")
                        Me.txtHTSearch_HTRQMax.Text = dateMin.ToString("yyyy-MM-dd")
                    Else
                        Me.txtHTSearch_HTRQMin.Text = dateMin.ToString("yyyy-MM-dd")
                        Me.txtHTSearch_HTRQMax.Text = dateMax.ToString("yyyy-MM-dd")
                    End If
                    If strQuery = "" Then
                        strQuery = strHTRQ + " between '" + Me.txtHTSearch_HTRQMin.Text + "' and '" + Me.txtHTSearch_HTRQMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strHTRQ + " between '" + Me.txtHTSearch_HTRQMin.Text + "' and '" + Me.txtHTSearch_HTRQMax.Text + "'"
                    End If
                ElseIf Me.txtHTSearch_HTRQMin.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtHTSearch_HTRQMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的时间！"
                        GoTo errProc
                    End Try
                    Me.txtHTSearch_HTRQMin.Text = dateMin.ToString("yyyy-MM-dd")
                    If strQuery = "" Then
                        strQuery = strHTRQ + " >= '" + Me.txtHTSearch_HTRQMin.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strHTRQ + " >= '" + Me.txtHTSearch_HTRQMin.Text + "'"
                    End If
                ElseIf Me.txtHTSearch_HTRQMax.Text <> "" Then
                    Try
                        dateMax = CType(Me.txtHTSearch_HTRQMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的时间！"
                        GoTo errProc
                    End Try
                    Me.txtHTSearch_HTRQMax.Text = dateMax.ToString("yyyy-MM-dd")
                    If strQuery = "" Then
                        strQuery = strHTRQ + " <= '" + Me.txtHTSearch_HTRQMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strHTRQ + " <= '" + Me.txtHTSearch_HTRQMax.Text + "'"
                    End If
                Else
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getQueryString_HT = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取grdHT要显示的数据信息
        '     strErrMsg      ：返回错误信息
        '     strQRSH        ：确认书号
        '     strWhere       ：搜索字符串
        '     blnControl     ：特殊权限控制
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_HT( _
            ByRef strErrMsg As String, _
            ByVal strQRSH As String, _
            ByVal strWhere As String, _
            ByVal blnControl As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_V_QUANBUJIAOYI
            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou

            getModuleData_HT = False

            Try
                '备份Sort字符串
                Dim strSort As String = ""
                strSort = Me.htxtHTSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '释放资源
                Josco.JSOA.Common.Data.estateErshouData.SafeRelease(Me.m_objDataSet_HT)

                '重新检索数据
                If objsystemEstateErshou.getDataSet_ES_JYXX(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, strWhere, blnControl, Me.m_objDataSet_HT) = False Then
                    GoTo errProc
                End If

                '恢复Sort字符串
                With Me.m_objDataSet_HT.Tables(strTable)
                    .DefaultView.Sort = strSort
                End With

                '缓存参数
                With Me.m_objDataSet_HT.Tables(strTable)
                    Me.htxtHTRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_HT = .DefaultView.Count
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)

            getModuleData_HT = True
            Exit Function

errProc:
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 根据grdHT的当前行获取QRSH
        '     strErrMsg      ：返回错误信息
        '     strQRSH        ：确认书号
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getQRSH( _
            ByRef strErrMsg As String, _
            ByRef strQRSH As String) As Boolean

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            getQRSH = False
            strErrMsg = ""
            strQRSH = ""

            Try
                If Me.grdHT.SelectedIndex >= 0 Then
                    Dim i As Integer = Me.grdHT.SelectedIndex
                    Dim intColIndex As Integer = 0
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdHT, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_JYBH)
                    strQRSH = objDataGridProcess.getDataGridCellValue(Me.grdHT.Items(i), intColIndex)
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            getQRSH = True
            Exit Function

errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取grdSHQK要显示的数据信息(根据合同列表的当前合同获取)
        '     strErrMsg      ：返回错误信息
        '     strWhere       ：搜索条件
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_SHQK( _
            ByRef strErrMsg As String, _
            ByVal strWhere As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_SHENHE
            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou

            getModuleData_SHQK = False

            Try
                '计算当前合同
                Dim strQRSH As String = ""
                If Me.getQRSH(strErrMsg, strQRSH) = False Then
                    GoTo errProc
                End If

                '释放资源
                Josco.JSOA.Common.Data.estateErshouData.SafeRelease(Me.m_objDataSet_SHQK)

                '重新检索数据
                If objsystemEstateErshou.getDataSet_ES_HETONG_SHQK(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, strWhere, Me.m_objDataSet_SHQK) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)

            getModuleData_SHQK = True
            Exit Function

errProc:
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 根据屏幕搜索条件搜索grdHT数据
        '     strErrMsg      ：返回错误信息
        '     strQRSH        ：确认书号
        '     blnControl     ：特殊权限控制
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function searchModuleData_HT( _
            ByRef strErrMsg As String, _
            ByVal strQRSH As String, _
            ByVal blnControl As Boolean) As Boolean

            searchModuleData_HT = False

            Try
                '获取搜索字符串
                Dim strQuery As String
                If Me.getQueryString_HT(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '搜索数据
                If Me.getModuleData_HT(strErrMsg, strQRSH, strQuery, blnControl) = False Then
                    GoTo errProc
                End If

                '记录搜索字符串
                Me.m_strQuery_HT = strQuery
                Me.htxtHTQuery.Value = Me.m_strQuery_HT
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            searchModuleData_HT = True
            Exit Function
errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdHT的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo_HT( _
            ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_V_QUANBUJIAOYI
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_HT = False

            '获取系统保存的网格排序数据
            Dim intSortColumnIndex As Integer = -1
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtHTSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtHTSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '网格显示处理
            Try
                '在获取数据时已经恢复了RowFilter、Sort的现场
                '设置数据源
                If Me.m_objDataSet_HT Is Nothing Then
                    Me.grdHT.DataSource = Nothing
                Else
                    With Me.m_objDataSet_HT.Tables(strTable)
                        Me.grdHT.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objDataSet_HT.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdHT, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '恢复列标题中的排序信息
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdHT)
                    With Me.grdHT.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '绑定数据
                Me.grdHT.DataBind()

                '----------------------------------------------------------------
                '因为这些信息是非绑定的，所以下面的操作必须等绑定完成后执行！！！
                '一旦在后续处理中执行了DataBind，则信息会丢失！！！
                '----------------------------------------------------------------
                ''恢复网格中的CheckBox状态
                'If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdHT, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_HT) = False Then
                '    GoTo errProc
                'End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_HT = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdSHQK的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo_SHQK( _
            ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_SHENHE
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_SHQK = False

            '网格显示处理
            Try
                '在获取数据时已经恢复了RowFilter、Sort的现场
                '设置数据源
                If Me.m_objDataSet_SHQK Is Nothing Then
                    Me.grdSHQK.DataSource = Nothing
                Else
                    With Me.m_objDataSet_SHQK.Tables(strTable)
                        Me.grdSHQK.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objDataSet_SHQK.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdSHQK, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '绑定数据
                Me.grdSHQK.DataBind()

                '----------------------------------------------------------------
                '因为这些信息是非绑定的，所以下面的操作必须等绑定完成后执行！！！
                '一旦在后续处理中执行了DataBind，则信息会丢失！！！
                '----------------------------------------------------------------
                ''恢复网格中的CheckBox状态
                'If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdSHQK, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_SHQK) = False Then
                '    GoTo errProc
                'End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_SHQK = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdHT及相关信息
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleData_HT( _
            ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_V_QUANBUJIAOYI
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showModuleData_HT = False

            Try
                '显示网格信息
                If Me.showDataGridInfo_HT(strErrMsg) = False Then
                    GoTo errProc
                End If

                '显示与网格紧密相关的操作或信息提示
                With Me.m_objDataSet_HT.Tables(strTable).DefaultView
                    '显示网格位置信息
                    Me.lblHTGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdHT, .Count)

                    '显示页面浏览功能
                    Me.lnkCZHTMoveFirst.Enabled = objDataGridProcess.canDoMoveFirstPage(Me.grdHT, .Count)
                    Me.lnkCZHTMoveLast.Enabled = objDataGridProcess.canDoMoveLastPage(Me.grdHT, .Count)
                    Me.lnkCZHTMovePrev.Enabled = objDataGridProcess.canDoMovePreviousPage(Me.grdHT, .Count)
                    Me.lnkCZHTMoveNext.Enabled = objDataGridProcess.canDoMoveNextPage(Me.grdHT, .Count)

                    '显示相关操作
                    Dim blnEnabled As Boolean
                    If .Count < 1 Then
                        blnEnabled = False
                    Else
                        blnEnabled = True
                    End If
                    Me.lnkCZHTDeSelectAll.Enabled = blnEnabled
                    Me.lnkCZHTSelectAll.Enabled = blnEnabled
                    Me.lnkCZHTGotoPage.Enabled = blnEnabled
                    Me.lnkCZHTSetPageSize.Enabled = blnEnabled
                End With

                '同步显示
                Dim strQRSH As String = ""
                If Me.getQRSH(strErrMsg, strQRSH) = False Then
                    GoTo errProc
                End If
                If Me.getModuleData_SHQK(strErrMsg, "") = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_SHQK(strErrMsg) = False Then
                    GoTo errProc
                End If
                If Me.showJiaoyiInfo(strErrMsg, strQRSH) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_Main(strErrMsg) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showModuleData_HT = True
            Exit Function

errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdSHQK及相关信息
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleData_SHQK( _
            ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_SHENHE
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showModuleData_SHQK = False

            Try
                '显示网格信息
                If Me.showDataGridInfo_SHQK(strErrMsg) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showModuleData_SHQK = True
            Exit Function

errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示合同信息
        '     strErrMsg      ：返回错误信息
        '     strQRSH        ：确认书号
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showJiaoyiInfo( _
            ByRef strErrMsg As String, _
            ByVal strQRSH As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_V_QUANBUJIAOYI
            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDropDownListProcess As New Josco.JsKernal.web.DropDownListProcess
            Dim objestateErshouData As Josco.JSOA.Common.Data.estateErshouData

            showJiaoyiInfo = False
            strErrMsg = ""

            Try
                '获取信息
                If objsystemEstateErshou.getDataSet_ES_JYXX(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, "", objestateErshouData) = False Then
                    GoTo errProc
                End If

                '初始化信息
                Me.lblJYBH.Text = ""
                Me.lblJYRQ.Text = ""
                Me.lblJFMC.Text = ""
                Me.lblJYJG.Text = ""
                Me.lblHTBH.Text = ""
                Me.lblHTRQ.Text = ""
                Me.lblYFMC.Text = ""
                Me.lblJYMJ.Text = ""
                Me.lblWYDZ.Text = ""
                Me.lblJFDLF.Text = ""
                Me.lblYFDLF.Text = ""

                '显示信息
                With objestateErshouData.Tables(strTable)
                    If .Rows.Count < 1 Then
                        Exit Try
                    End If
                    Me.lblJYBH.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_JYBH), "")
                    Me.lblJYRQ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_JYRQ), "", "yyyy-MM-dd")
                    Me.lblJFMC.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_YZMC), "")
                    Me.lblJYJG.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_JYJG), 0.0).ToString("#,###.00")
                    Me.lblHTBH.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_HTBH), "")
                    Me.lblHTRQ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_HTRQ), "", "yyyy-MM-dd")
                    Me.lblYFMC.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_KHMC), "")
                    Me.lblJYMJ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_JYMJ), 0.0).ToString("#,###.00")
                    Me.lblWYDZ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_WYDZ), "")
                    Me.lblJFDLF.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_JFDLF), 0.0).ToString("#,###.00")
                    Me.lblYFDLF.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_YFDLF), 0.0).ToString("#,###.00")
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateErshouData.SafeRelease(objestateErshouData)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)

            showJiaoyiInfo = True
            Exit Function

errProc:
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateErshouData.SafeRelease(objestateErshouData)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示模块其他信息
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleData_Main( _
            ByRef strErrMsg As String) As Boolean

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou

            showModuleData_Main = False

            Try
                '合同已审？
                Dim blnComplete As Boolean = True
                Dim strQRSH As String = ""
                If Me.getQRSH(strErrMsg, strQRSH) = False Then
                    GoTo errProc
                End If
                If strQRSH <> "" Then
                    If objsystemEstateErshou.isHetongYiShen(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, blnComplete) = False Then
                        GoTo errProc
                    End If
                End If

                'zengxianglin 2009-02-24
                Me.btnTJRQ.Visible = Me.m_blnPrevilegeParams(4) And strQRSH <> ""
                'zengxianglin 2009-02-24
                Me.btnSHQM.Visible = Me.m_blnPrevilegeParams(4) And blnComplete = False And strQRSH <> ""
                Me.btnSDQM.Visible = Me.m_blnPrevilegeParams(4) And blnComplete = False And strQRSH <> ""
                Me.btnQXQM.Visible = Me.m_blnPrevilegeParams(4) And blnComplete = False And strQRSH <> ""
                Me.btnUpdate.Visible = Me.m_blnPrevilegeParams(4) And blnComplete = False And strQRSH <> ""
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)

            showModuleData_Main = True
            Exit Function

errProc:
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
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
                    '********************************************************
                    objControlProcess.doTranslateKey(Me.txtHTPageIndex)
                    objControlProcess.doTranslateKey(Me.txtHTPageSize)
                    '********************************************************
                    objControlProcess.doTranslateKey(Me.txtHTSearch_HTBH)
                    objControlProcess.doTranslateKey(Me.txtHTSearch_QRSH)
                    objControlProcess.doTranslateKey(Me.txtHTSearch_JFMC)
                    objControlProcess.doTranslateKey(Me.txtHTSearch_YFMC)
                    objControlProcess.doTranslateKey(Me.txtHTSearch_FWDZ)
                    objControlProcess.doTranslateKey(Me.txtHTSearch_HTRQMin)
                    objControlProcess.doTranslateKey(Me.txtHTSearch_HTRQMax)
                    objControlProcess.doTranslateKey(Me.ddlHTSearch_HTZT)
                    '********************************************************

                    If Me.m_blnSaveScence = False Then
                        If Me.m_strQRSH = "" Then
                            Me.txtHTSearch_HTRQMin.Text = Now.Year.ToString + "-01-01"
                            Me.ddlHTSearch_HTZT.SelectedIndex = 1
                            If Me.searchModuleData_HT(strErrMsg, Me.m_strQRSH, Me.m_blnQxControl) = False Then
                                GoTo errProc
                            End If
                        Else
                            If Me.getModuleData_HT(strErrMsg, Me.m_strQRSH, Me.m_strQuery_HT, Me.m_blnQxControl) = False Then
                                GoTo errProc
                            End If
                        End If
                    Else
                        If Me.getModuleData_HT(strErrMsg, Me.m_strQRSH, Me.m_strQuery_HT, Me.m_blnQxControl) = False Then
                            GoTo errProc
                        End If
                    End If
                    If Me.showModuleData_HT(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    'zengxianglin 2008-11-06
                    If Me.showModuleData_Main(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    'zengxianglin 2008-11-06
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
        Sub grdHT_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdHT.ItemDataBound

            Dim intCells As Integer = -1
            Dim i As Integer = 0

            Try
                If e.Item.ItemIndex < 0 Then
                    '标题行,输出标题锁定一般属性
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_HT + ".scrollTop)")
                    Next
                End If

                If Me.m_intFixedColumns_HT > 0 Then
                    '锁定列
                    For i = 0 To Me.m_intFixedColumns_HT - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdHT.ID + "Locked"
                    Next
                End If

            Catch ex As Exception
            End Try

            Exit Sub

        End Sub

        Sub grdSHQK_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdSHQK.ItemDataBound

            Dim intCells As Integer = -1
            Dim i As Integer = 0

            Try
                If e.Item.ItemIndex < 0 Then
                    '标题行,输出标题锁定一般属性
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_SHQK + ".scrollTop)")
                    Next
                End If

                If Me.m_intFixedColumns_SHQK > 0 Then
                    '锁定列
                    For i = 0 To Me.m_intFixedColumns_SHQK - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdSHQK.ID + "Locked"
                    Next
                End If

            Catch ex As Exception
            End Try

            Exit Sub

        End Sub

        Private Sub grdHT_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdHT.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '显示记录位置
                Me.lblHTGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdHT, Me.m_intRows_HT)

                '同步显示
                Dim strQRSH As String = ""
                If Me.getQRSH(strErrMsg, strQRSH) = False Then
                    GoTo errProc
                End If
                If Me.getModuleData_SHQK(strErrMsg, "") = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_SHQK(strErrMsg) = False Then
                    GoTo errProc
                End If
                If Me.showJiaoyiInfo(strErrMsg, strQRSH) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_Main(strErrMsg) = False Then
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

        Private Sub grdHT_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdHT.SortCommand

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_V_QUANBUJIAOYI
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
                If Me.getModuleData_HT(strErrMsg, Me.m_strQRSH, Me.m_strQuery_HT, Me.m_blnQxControl) = False Then
                    GoTo errProc
                End If

                '获取原排序命令
                With Me.m_objDataSet_HT.Tables(strTable)
                    strOldCommand = .DefaultView.Sort
                End With

                '获取要执行的排序命令
                objDataGridProcess.getColumnSortCommand(strErrMsg, strOldCommand, e.SortExpression, strFinalCommand, objenumSortType)
                If strErrMsg <> "" Then
                    GoTo errProc
                End If

                '执行排序
                With Me.m_objDataSet_HT.Tables(strTable)
                    .DefaultView.Sort = strFinalCommand
                End With

                '获取排序列的列索引
                objDataGridItem = CType(e.CommandSource, System.Web.UI.WebControls.DataGridItem)
                strUniqueId = Request.Form("__EVENTTARGET")
                intColumnIndex = objDataGridProcess.getColumnIndexByUniqueIdInRow(objDataGridItem, strUniqueId)

                '保存排序信息
                Me.htxtHTSortColumnIndex.Value = intColumnIndex.ToString()
                Me.htxtHTSortType.Value = CType(objenumSortType, Integer).ToString()
                Me.htxtHTSort.Value = strFinalCommand

                '重新显示数据
                If Me.showModuleData_HT(strErrMsg) = False Then
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

        Private Sub grdHT_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdHT.ItemCommand

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                Dim strControlId As String
                Dim intColIndex As Integer

                '定位
                Me.grdHT.SelectedIndex = e.Item.ItemIndex

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
                If Me.getModuleData_HT(strErrMsg, Me.m_strQRSH, Me.m_strQuery_HT, Me.m_blnQxControl) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(0, Me.grdHT.PageCount)
                Me.grdHT.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_HT(strErrMsg) = False Then
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
                If Me.getModuleData_HT(strErrMsg, Me.m_strQRSH, Me.m_strQuery_HT, Me.m_blnQxControl) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdHT.PageCount - 1, Me.grdHT.PageCount)
                Me.grdHT.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_HT(strErrMsg) = False Then
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
                If Me.getModuleData_HT(strErrMsg, Me.m_strQRSH, Me.m_strQuery_HT, Me.m_blnQxControl) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdHT.CurrentPageIndex + 1, Me.grdHT.PageCount)
                Me.grdHT.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_HT(strErrMsg) = False Then
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
                If Me.getModuleData_HT(strErrMsg, Me.m_strQRSH, Me.m_strQuery_HT, Me.m_blnQxControl) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdHT.CurrentPageIndex - 1, Me.grdHT.PageCount)
                Me.grdHT.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_HT(strErrMsg) = False Then
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
            intPageIndex = objPulicParameters.getObjectValue(Me.txtHTPageIndex.Text, 0)
            If intPageIndex <= 0 Then
                intPageIndex = 0
            Else
                intPageIndex -= 1
            End If

            Try
                '获取数据
                If Me.getModuleData_HT(strErrMsg, Me.m_strQRSH, Me.m_strQuery_HT, Me.m_blnQxControl) = False Then
                    GoTo errProc
                End If

                '设置新的页
                Me.grdHT.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_HT(strErrMsg) = False Then
                    GoTo errProc
                End If

                '信息同步
                Me.txtHTPageIndex.Text = (Me.grdHT.CurrentPageIndex + 1).ToString()

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
            intPageSize = objPulicParameters.getObjectValue(Me.txtHTPageSize.Text, 100)
            If intPageSize <= 0 Then intPageSize = 100

            Try
                '获取数据
                If Me.getModuleData_HT(strErrMsg, Me.m_strQRSH, Me.m_strQuery_HT, Me.m_blnQxControl) = False Then
                    GoTo errProc
                End If

                '设置新的页大小
                Me.grdHT.PageSize = intPageSize

                '刷新网格显示
                If Me.showModuleData_HT(strErrMsg) = False Then
                    GoTo errProc
                End If

                '信息同步
                Me.txtHTPageSize.Text = (Me.grdHT.PageSize).ToString()

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
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdHT, 0, Me.m_cstrCheckBoxIdInDataGrid_HT, True) = False Then
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
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdHT, 0, Me.m_cstrCheckBoxIdInDataGrid_HT, False) = False Then
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
                If Me.searchModuleData_HT(strErrMsg, Me.m_strQRSH, Me.m_blnQxControl) = False Then
                    GoTo errProc
                End If

                '刷新网格显示
                If Me.showModuleData_HT(strErrMsg) = False Then
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

        Private Sub lnkCZHTMoveFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZHTMoveFirst.Click
            Me.doMoveFirst("lnkCZHTMoveFirst")
        End Sub

        Private Sub lnkCZHTMoveLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZHTMoveLast.Click
            Me.doMoveLast("lnkCZHTMoveLast")
        End Sub

        Private Sub lnkCZHTMoveNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZHTMoveNext.Click
            Me.doMoveNext("lnkCZHTMoveNext")
        End Sub

        Private Sub lnkCZHTMovePrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZHTMovePrev.Click
            Me.doMovePrevious("lnkCZHTMovePrev")
        End Sub

        Private Sub lnkCZHTGotoPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZHTGotoPage.Click
            Me.doGotoPage("lnkCZHTGotoPage")
        End Sub

        Private Sub lnkCZHTSetPageSize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZHTSetPageSize.Click
            Me.doSetPageSize("lnkCZHTSetPageSize")
        End Sub

        Private Sub lnkCZHTSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZHTSelectAll.Click
            Me.doSelectAll("lnkCZHTSelectAll")
        End Sub

        Private Sub lnkCZHTDeSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZHTDeSelectAll.Click
            Me.doDeSelectAll("lnkCZHTDeSelectAll")
        End Sub

        Private Sub btnHTSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHTSearch.Click
            Me.doSearch("btnHTSearch")
        End Sub











        Private Sub doSearchFull(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_V_QUANBUJIAOYI
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objISjcxCxtj As Josco.JsKernal.BusinessFacade.ISjcxCxtj = Nothing
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strNewSessionId As String = ""
            Dim strSessionId As String = ""
            Dim strErrMsg As String = ""

            Try
                '获取数据
                If Me.getModuleData_HT(strErrMsg, Me.m_strQRSH, Me.m_strQuery_HT, Me.m_blnQxControl) = False Then
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
                    If Me.htxtSessionIdQueryHT.Value.Trim <> "" Then
                        .iDataSetTJ = CType(Session(Me.htxtSessionIdQueryHT.Value), Josco.JsKernal.Common.Data.QueryData)
                    Else
                        .iDataSetTJ = Nothing
                    End If
                    .iQueryTable = Me.m_objDataSet_HT.Tables(strTable)
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

        Private Sub btnHTSearch_Full_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHTSearch_Full.Click
            Me.doSearchFull("btnHTSearch_Full")
        End Sub













        '----------------------------------------------------------------
        '模块特殊操作处理器
        '----------------------------------------------------------------
        Private Sub doUpdate(ByVal strControlId As String)

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '检查
                If Me.grdHT.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有选定[合同]！"
                    GoTo errProc
                End If
                Dim i As Integer = Me.grdHT.SelectedIndex
                Dim intColIndex As Integer = 0
                Dim strYWLX As String = ""
                Dim intHTZT As Integer = 0
                Dim strHTBH As String = ""
                Dim strQRSH As String = ""
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdHT, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_JYLX)
                strYWLX = objDataGridProcess.getDataGridCellValue(Me.grdHT.Items(i), intColIndex)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdHT, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_HTZT)
                intHTZT = objPulicParameters.getObjectValue(objDataGridProcess.getDataGridCellValue(Me.grdHT.Items(i), intColIndex), 0)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdHT, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_HTBH)
                strHTBH = objDataGridProcess.getDataGridCellValue(Me.grdHT.Items(i), intColIndex)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdHT, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_JYBH)
                strQRSH = objDataGridProcess.getDataGridCellValue(Me.grdHT.Items(i), intColIndex)
                If strHTBH = "" Then
                    strErrMsg = "错误：[" + strQRSH + "]还没签合同！"
                    GoTo errProc
                End If
                Select Case Josco.JSOA.Common.Data.estateErshouData.getHetongStatus(intHTZT)
                    Case Josco.JSOA.Common.Data.estateErshouData.enumHetongStatus.Weishen
                    Case Else
                        strErrMsg = "错误：[" + strQRSH + "]已经审核或完成，不能更改！"
                        GoTo errProc
                End Select

                '备份现场参数
                Dim strSessionId As String = ""
                strSessionId = Me.saveModuleInformation()
                If strSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Select Case strYWLX
                    Case Josco.JSOA.Common.Data.estateErshouData.YWLX_ES_MM
                        Dim strUrl As String = ""
                        Dim objIEstateEsHetongMmInfo As Josco.JSOA.BusinessFacade.IEstateEsHetongMmInfo = Nothing
                        objIEstateEsHetongMmInfo = New Josco.JSOA.BusinessFacade.IEstateEsHetongMmInfo
                        With objIEstateEsHetongMmInfo
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
                        Session.Add(strNewSessionId, objIEstateEsHetongMmInfo)
                        strUrl = ""
                        strUrl += "estate_es_hetongmm_info.aspx"
                        strUrl += "?"
                        strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                        strUrl += "="
                        strUrl += strNewSessionId
                        Response.Redirect(strUrl)
                    Case Josco.JSOA.Common.Data.estateErshouData.YWLX_ES_ZL
                        Dim strUrl As String = ""
                        Dim objIEstateEsHetongZlInfo As Josco.JSOA.BusinessFacade.IEstateEsHetongZlInfo = Nothing
                        objIEstateEsHetongZlInfo = New Josco.JSOA.BusinessFacade.IEstateEsHetongZlInfo
                        With objIEstateEsHetongZlInfo
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
                        Session.Add(strNewSessionId, objIEstateEsHetongZlInfo)
                        strUrl = ""
                        strUrl += "estate_es_hetongzl_info.aspx"
                        strUrl += "?"
                        strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                        strUrl += "="
                        strUrl += strNewSessionId
                        Response.Redirect(strUrl)

                        'zengxianglin 2008-11-18
                    Case Josco.JSOA.Common.Data.estateErshouData.YWLX_ES_QT
                        Dim strUrl As String = ""
                        Dim objIEstateEsHetongQtInfo As Josco.JSOA.BusinessFacade.IEstateEsHetongQtInfo = Nothing
                        objIEstateEsHetongQtInfo = New Josco.JSOA.BusinessFacade.IEstateEsHetongQtInfo
                        With objIEstateEsHetongQtInfo
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
                        Session.Add(strNewSessionId, objIEstateEsHetongQtInfo)
                        strUrl = ""
                        strUrl += "estate_es_hetongqt_info.aspx"
                        strUrl += "?"
                        strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                        strUrl += "="
                        strUrl += strNewSessionId
                        Response.Redirect(strUrl)
                        'zengxianglin 2008-11-18

                End Select
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
                If Me.grdHT.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有选定[合同]！"
                    GoTo errProc
                End If
                Dim i As Integer = Me.grdHT.SelectedIndex
                Dim intColIndex As Integer = 0
                Dim strYWLX As String = ""
                Dim intHTZT As Integer = 0
                Dim strHTBH As String = ""
                Dim strQRSH As String = ""
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdHT, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_JYLX)
                strYWLX = objDataGridProcess.getDataGridCellValue(Me.grdHT.Items(i), intColIndex)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdHT, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_HTZT)
                intHTZT = objPulicParameters.getObjectValue(objDataGridProcess.getDataGridCellValue(Me.grdHT.Items(i), intColIndex), 0)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdHT, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_HTBH)
                strHTBH = objDataGridProcess.getDataGridCellValue(Me.grdHT.Items(i), intColIndex)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdHT, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_JYBH)
                strQRSH = objDataGridProcess.getDataGridCellValue(Me.grdHT.Items(i), intColIndex)
                If strHTBH = "" Then
                    strErrMsg = "错误：[" + strQRSH + "]还没签合同！"
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
                Select Case strYWLX
                    Case Josco.JSOA.Common.Data.estateErshouData.YWLX_ES_MM
                        Dim strUrl As String = ""
                        Dim objIEstateEsHetongMmInfo As Josco.JSOA.BusinessFacade.IEstateEsHetongMmInfo = Nothing
                        objIEstateEsHetongMmInfo = New Josco.JSOA.BusinessFacade.IEstateEsHetongMmInfo
                        With objIEstateEsHetongMmInfo
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
                        Session.Add(strNewSessionId, objIEstateEsHetongMmInfo)
                        strUrl = ""
                        strUrl += "estate_es_hetongmm_info.aspx"
                        strUrl += "?"
                        strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                        strUrl += "="
                        strUrl += strNewSessionId
                        Response.Redirect(strUrl)
                    Case Josco.JSOA.Common.Data.estateErshouData.YWLX_ES_ZL
                        Dim strUrl As String = ""
                        Dim objIEstateEsHetongZlInfo As Josco.JSOA.BusinessFacade.IEstateEsHetongZlInfo = Nothing
                        objIEstateEsHetongZlInfo = New Josco.JSOA.BusinessFacade.IEstateEsHetongZlInfo
                        With objIEstateEsHetongZlInfo
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
                        Session.Add(strNewSessionId, objIEstateEsHetongZlInfo)
                        strUrl = ""
                        strUrl += "estate_es_hetongzl_info.aspx"
                        strUrl += "?"
                        strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                        strUrl += "="
                        strUrl += strNewSessionId
                        Response.Redirect(strUrl)

                        'zengxianglin 2008-11-18
                    Case Josco.JSOA.Common.Data.estateErshouData.YWLX_ES_QT
                        Dim strUrl As String = ""
                        Dim objIEstateEsHetongQtInfo As Josco.JSOA.BusinessFacade.IEstateEsHetongQtInfo = Nothing
                        objIEstateEsHetongQtInfo = New Josco.JSOA.BusinessFacade.IEstateEsHetongQtInfo
                        With objIEstateEsHetongQtInfo
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
                        Session.Add(strNewSessionId, objIEstateEsHetongQtInfo)
                        strUrl = ""
                        strUrl += "estate_es_hetongqt_info.aspx"
                        strUrl += "?"
                        strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                        strUrl += "="
                        strUrl += strNewSessionId
                        Response.Redirect(strUrl)
                        'zengxianglin 2008-11-18

                End Select
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

        Private Sub doClose(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                Dim strSessionId As String
                Dim strUrl As String
                If Me.m_blnInterface = True Then
                    '设置返回参数
                    '返回到调用模块，并附加返回参数
                    Me.m_objInterface.oExitMode = False
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

        Private Sub doSHQM(ByVal strControlId As String)

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim intStep As Integer = 0
            Dim strErrMsg As String

            Try
                intStep = 1
                '检查
                If Me.grdHT.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有合同！"
                    GoTo errProc
                End If
                Dim strQRSH As String = ""
                If Me.getQRSH(strErrMsg, strQRSH) = False Then
                    GoTo errProc
                End If
                'zengxianglin 2008-11-22
                Dim strYWLX As String = ""
                Dim blnIS_GY As Boolean
                Dim blnIS As Boolean
                If objsystemEstateErshou.getYWLX(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, strYWLX) = False Then
                    GoTo errProc
                End If
                Select Case strYWLX
                    Case Josco.JSOA.Common.Data.estateErshouData.YWLX_ES_MM, _
                        Josco.JSOA.Common.Data.estateErshouData.YWLX_ES_QT
                        If objsystemEstateErshou.isHetongDoneBAJH(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, blnIS) = False Then
                            GoTo errProc
                        End If
                        If blnIS = False Then
                            strErrMsg = "错误：本合同还没有制订[办案计划]！"
                            GoTo errProc
                        End If
                    Case Else
                End Select
                If objsystemEstateErshou.isHetongDoneFPBL(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, blnIS, blnIS_GY) = False Then
                    GoTo errProc
                End If
                If blnIS = False Then
                    strErrMsg = "错误：本合同还没有指定[私人业绩分配方案]！"
                    GoTo errProc
                End If
                'zengxianglin 2008-11-22

                intStep = 2
                '询问
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "警告：您确定要进行[审核]签名吗（是/否）？", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                intStep = 3
                '回答“是”
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '签名
                    If objsystemEstateErshou.doShenHe_ES_HETONG( _
                        strErrMsg, MyBase.UserId, MyBase.UserPassword, _
                        strQRSH, _
                        MyBase.UserId, _
                        Josco.JSOA.Common.Data.estateErshouData.enumShenheStatus.Shenhe) = False Then
                        GoTo errProc
                    End If

                    '刷新显示
                    If Me.getModuleData_SHQK(strErrMsg, "") = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_SHQK(strErrMsg) = False Then
                        GoTo errProc
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doSDQM(ByVal strControlId As String)

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim intStep As Integer = 0
            Dim strErrMsg As String

            Try
                intStep = 1
                '检查
                If Me.grdHT.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有合同！"
                    GoTo errProc
                End If
                Dim strQRSH As String = ""
                If Me.getQRSH(strErrMsg, strQRSH) = False Then
                    GoTo errProc
                End If
                'zengxianglin 2008-11-22
                '检查是否做过审核？
                Dim blnIS As Boolean
                If objsystemEstateErshou.isHetongDoneShenhe(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, blnIS) = False Then
                    GoTo errProc
                End If
                If blnIS = False Then
                    strErrMsg = "错误：合同还没有人审核！"
                    GoTo errProc
                End If
                'zengxianglin 2008-11-22

                intStep = 2
                '询问
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "警告：您确定要进行[审定]签名吗（是/否）？", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                intStep = 3
                '回答“是”
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '签名
                    If objsystemEstateErshou.doShenHe_ES_HETONG( _
                        strErrMsg, MyBase.UserId, MyBase.UserPassword, _
                        strQRSH, _
                        MyBase.UserId, _
                        Josco.JSOA.Common.Data.estateErshouData.enumShenheStatus.Shending) = False Then
                        GoTo errProc
                    End If

                    '刷新显示
                    'zengxianglin 2008-11-18
                    If Me.getModuleData_HT(strErrMsg, Me.m_strQRSH, Me.m_strQuery_HT, Me.m_blnQxControl) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_HT(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    'If Me.getModuleData_SHQK(strErrMsg, "") = False Then
                    '    GoTo errProc
                    'End If
                    'If Me.showModuleData_SHQK(strErrMsg) = False Then
                    '    GoTo errProc
                    'End If
                    'zengxianglin 2008-11-18
                    If Me.showModuleData_Main(strErrMsg) = False Then
                        GoTo errProc
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doQXQM(ByVal strControlId As String)

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim intStep As Integer = 0
            Dim strErrMsg As String

            Try
                intStep = 1
                '检查
                If Me.grdHT.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有合同！"
                    GoTo errProc
                End If
                Dim strQRSH As String = ""
                If Me.getQRSH(strErrMsg, strQRSH) = False Then
                    GoTo errProc
                End If

                intStep = 2
                '询问
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "警告：您确定要进行[取消]自己的签名吗（是/否）？", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                intStep = 3
                '回答“是”
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '签名
                    If objsystemEstateErshou.doShenHe_ES_HETONG( _
                        strErrMsg, MyBase.UserId, MyBase.UserPassword, _
                        strQRSH, _
                        MyBase.UserId, _
                        Josco.JSOA.Common.Data.estateErshouData.enumShenheStatus.Quxiao) = False Then
                        GoTo errProc
                    End If

                    '刷新显示
                    'zengxianglin 2008-11-18
                    If Me.getModuleData_HT(strErrMsg, Me.m_strQRSH, Me.m_strQuery_HT, Me.m_blnQxControl) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_HT(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    'If Me.getModuleData_SHQK(strErrMsg, "") = False Then
                    '    GoTo errProc
                    'End If
                    'If Me.showModuleData_SHQK(strErrMsg) = False Then
                    '    GoTo errProc
                    'End If
                    'zengxianglin 2008-11-18
                    If Me.showModuleData_Main(strErrMsg) = False Then
                        GoTo errProc
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        'zengxianglin 2009-02-24
        Private Sub doTJRQ(ByVal strControlId As String)

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim intStep As Integer = 0
            Dim strErrMsg As String

            Try
                intStep = 1
                '检查
                If Me.grdHT.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有合同！"
                    GoTo errProc
                End If
                Dim strQRSH As String = ""
                If Me.getQRSH(strErrMsg, strQRSH) = False Then
                    GoTo errProc
                End If
                If strQRSH = "" Then
                    strErrMsg = "错误：没有合同！"
                    GoTo errProc
                End If

                intStep = 2
                '输入新日期
                Dim strTJRQ As String = ""
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '获取原统计日期
                    If objsystemEstateErshou.getES_HETONG_TJRQ(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, strTJRQ) = False Then
                        GoTo errProc
                    End If
                    '提示输入
                    objMessageProcess.doInputBox(Me.popMessageObject, "请输入新的[统计日期]：", strControlId, intStep, strTJRQ)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                intStep = 3
                '询问
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '获取输入日期
                    strTJRQ = objMessageProcess.getInputBoxValue(Request, Me.popMessageObject.UniqueID)
                    If strTJRQ = "" Then
                        strErrMsg = "错误：没有输入[统计日期]！"
                        GoTo errProc
                    End If
                    If objPulicParameters.isDatetimeString(strTJRQ) = False Then
                        strErrMsg = "错误：无效的[统计日期]！"
                        GoTo errProc
                    End If
                    Me.htxtParam01.Value = strTJRQ
                    '提示
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "警告：您确定要更改合同的[统计日期]吗（是/否）？", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                intStep = 4
                '回答“是”
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '获取数据
                    strTJRQ = Me.htxtParam01.Value
                    '签名
                    If objsystemEstateErshou.doUpdateData_ES_HETONG_TJRQ( _
                        strErrMsg, MyBase.UserId, MyBase.UserPassword, _
                        strQRSH, strTJRQ) = False Then
                        GoTo errProc
                    End If

                    '刷新显示
                    If Me.getModuleData_SHQK(strErrMsg, "") = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_SHQK(strErrMsg) = False Then
                        GoTo errProc
                    End If
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
        Private Sub btnTJRQ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTJRQ.Click
            Me.doTJRQ("btnTJRQ")
        End Sub
        'zengxianglin 2009-02-24

        Private Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            Me.doUpdate("btnUpdate")
        End Sub

        Private Sub btnSHQM_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSHQM.Click
            Me.doSHQM("btnSHQM")
        End Sub

        Private Sub btnSDQM_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSDQM.Click
            Me.doSDQM("btnSDQM")
        End Sub

        Private Sub btnQXQM_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnQXQM.Click
            Me.doQXQM("btnQXQM")
        End Sub

        Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
            Me.doClose("btnClose")
        End Sub

    End Class

End Namespace
