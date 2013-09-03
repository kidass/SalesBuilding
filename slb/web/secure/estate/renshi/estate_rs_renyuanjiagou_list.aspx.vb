Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.web
    ' 类名    ：estate_rs_renyuanjiagou_list
    ' 
    ' 调用性质：
    '     I/O
    '
    ' 功能描述： 
    '   　“人员变动情况一览表”处理模块
    '
    ' 更改记录：
    '     zengxianglin 2009-05-14 更改
    '     zengxianglin 2010-01-02 更改
    '     zengxianglin 2010-03-18 更改
    '----------------------------------------------------------------

    Partial Class estate_rs_renyuanjiagou_list
        Inherits Josco.JsKernal.web.PageBase

#Region " Web 窗体设计器生成的代码 "

        '该调用是 Web 窗体设计器所必需的。
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub





        'zengxianglin 2008-11-18
        'zengxianglin 2008-11-18




        'zengxianglin 2010-01-02
        'zengxianglin 2010-01-02

        'zengxianglin 2010-03-18
        'zengxianglin 2010-03-18

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
        Private m_cstrPrevilegeParamPrefix As String = "estate_rs_renyuanjiagou_previlege_param"
        Private m_blnPrevilegeParams(4) As Boolean

        '----------------------------------------------------------------
        '模块现场保留参数，恢复完成后立即释放session资源
        '----------------------------------------------------------------
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMEstateRsRenyuanJiagou_List
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        '模块接口参数
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IEstateRsRenyuanJiagou_List
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '与数据网格grdRY相关的参数
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_grdRY As String = "chkRY"
        Private Const m_cstrDataGridInDIV_grdRY As String = "divRY"
        Private m_intFixedColumns_grdRY As Integer
        Private m_intRows_grdRY As Integer

        '----------------------------------------------------------------
        '当前处理的数据集
        '----------------------------------------------------------------
        Private m_objDataSet_TDZH As Josco.JSOA.Common.Data.estateRenshiXingyeData
        Private m_objDataSet_RY As Josco.JSOA.Common.Data.estateRenshiXingyeData

        '----------------------------------------------------------------
        '其他参数
        '----------------------------------------------------------------
        Public ReadOnly Property propEditMode() As Boolean
            Get
                propEditMode = Me.btnMidify.Visible
            End Get
        End Property












        Private Sub doGoBack(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                Dim strSessionId As String = ""
                Dim strUrl As String = ""
                strSessionId = Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                If strSessionId Is Nothing Then strSessionId = ""
                If strSessionId <> "" Then
                    Try
                        Me.m_objInterface = CType(Session(strSessionId), Josco.JSOA.BusinessFacade.IEstateRsRenyuanJiagou_List)
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

            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objTempDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData
            Dim strErrMsg As String

            Try
                If Me.m_objSaveScence Is Nothing Then
                    Exit Try
                End If

                With Me.m_objSaveScence
                    Me.htxtDivLeftBody.Value = .htxtDivLeftBody
                    Me.htxtDivTopBody.Value = .htxtDivTopBody
                    Me.htxtDivLeftMain.Value = .htxtDivLeftMain
                    Me.htxtDivTopMain.Value = .htxtDivTopMain
                    Me.htxtDivLeftRY.Value = .htxtDivLeftRY
                    Me.htxtDivTopRY.Value = .htxtDivTopRY

                    Me.htxtRYSessionIdQuery.Value = .htxtRYSessionIdQuery
                    Me.htxtRYQuery.Value = .htxtRYQuery
                    Me.htxtRYRows.Value = .htxtRYRows
                    Me.htxtRYSort.Value = .htxtRYSort
                    Me.htxtRYSortColumnIndex.Value = .htxtRYSortColumnIndex
                    Me.htxtRYSortType.Value = .htxtRYSortType

                    Try
                        Me.grdRY.PageSize = .grdRY_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdRY.CurrentPageIndex = .grdRY_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdRY.SelectedIndex = .grdRY_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Me.txtSearch_RY_RYDM.Text = .txtSearch_RY_RYDM
                    Me.txtSearch_RY_RYMC.Text = .txtSearch_RY_RYMC
                    Me.txtSearch_RY_DWMC.Text = .txtSearch_RY_DWMC
                    Me.txtSearch_RY_BDSJ.Text = .txtSearch_RY_BDSJ
                    Me.txtSearch_RY_KSSJMin.Text = .txtSearch_RY_KSSJMin
                    Me.txtSearch_RY_KSSJMax.Text = .txtSearch_RY_KSSJMax
                    Me.txtSearch_RY_JSSJMin.Text = .txtSearch_RY_JSSJMin
                    Me.txtSearch_RY_JSSJMax.Text = .txtSearch_RY_JSSJMax

                    Me.txtRYPageIndex.Text = .txtRYPageIndex
                    Me.txtRYPageSize.Text = .txtRYPageSize

                    Me.txtKSSJ.Text = .txtKSSJ
                    Me.txtJSSJ.Text = .txtJSSJ
                    Me.txtSJLD.Text = .txtSJLD
                    Me.htxtSJLD.Value = .htxtSJLD
                    Me.txtZZDM.Text = .txtZZDM
                    Me.htxtZZDM.Value = .htxtZZDM
                    'zengxianglin 2008-11-18
                    Me.txtZGDW.Text = .txtZGDW
                    Me.htxtZGDW.Value = .htxtZGDW
                    'zengxianglin 2008-11-18

                    Me.doFillSsfzList(strErrMsg, Me.ddlSSFZ, Me.txtZZDM.Text)
                    Try
                        Me.ddlSSFZ.SelectedIndex = .ddlSSFZ_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.ddlZJDM.SelectedIndex = .ddlZJDM_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.rblRYZT.SelectedIndex = .rblRYZT_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.rblSFZB.SelectedIndex = .rblSFZB_SelectedIndex
                    Catch ex As Exception
                    End Try

                    'zengxianglin 2010-01-02
                    Me.htxtSessionId_TDZH.Value = .htxtSessionId_TDZH
                    Me.htxtBZXL.Value = .htxtBZXL
                    Me.htxtZGTD.Value = .htxtZGTD
                    Me.htxtXGTD.Value = .htxtXGTD
                    Me.txtTDBH.Text = .txtTDBH
                    If Me.getModuleData_TDZH(strErrMsg) = True Then
                        If objsystemEstateRenshiXingye.getDataSet_TDZH(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.htxtZGTD.Value, Me.m_objDataSet_TDZH, objTempDataSet) = True Then
                            Me.doDisplayBuffer_TDZH(strErrMsg, Me.htxtZGTD.Value, objTempDataSet, Me.lstZGTD)
                        End If
                        Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objTempDataSet)
                        If objsystemEstateRenshiXingye.getDataSet_TDZH(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.htxtXGTD.Value, Me.m_objDataSet_TDZH, objTempDataSet) = True Then
                            Me.doDisplayBuffer_TDZH(strErrMsg, Me.htxtXGTD.Value, objTempDataSet, Me.lstXGTD)
                        End If
                        Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objTempDataSet)
                    End If
                    Try
                        Me.lstXGTD.SelectedIndex = .lstXGTD_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.lstZGTD.SelectedIndex = .lstZGTD_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.ddlYDYY.SelectedIndex = .ddlYDYY_SelectedIndex
                    Catch ex As Exception
                    End Try
                    'zengxianglin 2010-01-02
                End With

                '释放资源
                Session.Remove(strSessionId)
                Me.m_objSaveScence.Dispose()
                Me.m_objSaveScence = Nothing
            Catch ex As Exception
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objTempDataSet)
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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMEstateRsRenyuanJiagou_List

                '保存现场信息
                With Me.m_objSaveScence
                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftMain = Me.htxtDivLeftMain.Value
                    .htxtDivTopMain = Me.htxtDivTopMain.Value
                    .htxtDivLeftRY = Me.htxtDivLeftRY.Value
                    .htxtDivTopRY = Me.htxtDivTopRY.Value

                    .htxtRYSessionIdQuery = Me.htxtRYSessionIdQuery.Value
                    .htxtRYQuery = Me.htxtRYQuery.Value
                    .htxtRYRows = Me.htxtRYRows.Value
                    .htxtRYSort = Me.htxtRYSort.Value
                    .htxtRYSortColumnIndex = Me.htxtRYSortColumnIndex.Value
                    .htxtRYSortType = Me.htxtRYSortType.Value

                    .grdRY_PageSize = Me.grdRY.PageSize
                    .grdRY_CurrentPageIndex = Me.grdRY.CurrentPageIndex
                    .grdRY_SelectedIndex = Me.grdRY.SelectedIndex

                    .txtSearch_RY_RYDM = Me.txtSearch_RY_RYDM.Text
                    .txtSearch_RY_BDSJ = Me.txtSearch_RY_BDSJ.Text
                    .txtSearch_RY_RYMC = Me.txtSearch_RY_RYMC.Text
                    .txtSearch_RY_DWMC = Me.txtSearch_RY_DWMC.Text
                    .txtSearch_RY_KSSJMin = Me.txtSearch_RY_KSSJMin.Text
                    .txtSearch_RY_KSSJMax = Me.txtSearch_RY_KSSJMax.Text
                    .txtSearch_RY_JSSJMin = Me.txtSearch_RY_JSSJMin.Text
                    .txtSearch_RY_JSSJMax = Me.txtSearch_RY_JSSJMax.Text

                    .txtRYPageIndex = Me.txtRYPageIndex.Text
                    .txtRYPageSize = Me.txtRYPageSize.Text

                    .txtKSSJ = Me.txtKSSJ.Text
                    .txtJSSJ = Me.txtJSSJ.Text
                    .txtSJLD = Me.txtSJLD.Text
                    .htxtSJLD = Me.htxtSJLD.Value
                    .txtZZDM = Me.txtZZDM.Text
                    .htxtZZDM = Me.htxtZZDM.Value
                    'zengxianglin 2008-11-18
                    .txtZGDW = Me.txtZGDW.Text
                    .htxtZGDW = Me.htxtZGDW.Value
                    'zengxianglin 2008-11-18
                    .ddlSSFZ_SelectedIndex = Me.ddlSSFZ.SelectedIndex
                    .ddlZJDM_SelectedIndex = Me.ddlZJDM.SelectedIndex
                    .rblRYZT_SelectedIndex = Me.rblRYZT.SelectedIndex
                    .rblSFZB_SelectedIndex = Me.rblSFZB.SelectedIndex

                    'zengxianglin 2010-01-02
                    .htxtSessionId_TDZH = Me.htxtSessionId_TDZH.Value
                    .htxtBZXL = Me.htxtBZXL.Value
                    .htxtZGTD = Me.htxtZGTD.Value
                    .htxtXGTD = Me.htxtXGTD.Value
                    .txtTDBH = Me.txtTDBH.Text
                    .lstXGTD_SelectedIndex = Me.lstXGTD.SelectedIndex
                    .lstZGTD_SelectedIndex = Me.lstZGTD.SelectedIndex
                    .ddlYDYY_SelectedIndex = Me.ddlYDYY.SelectedIndex
                    'zengxianglin 2010-01-02
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
            Dim objsystemCustomer As New Josco.JsKernal.BusinessFacade.systemCustomer

            getDataFromCallModule = False

            Try
                If Me.IsPostBack = True Then
                    Exit Try
                End If

                'zengxianglin 2010-01-02
                '==========================================================================================================================================================
                Dim objIEstateRsXzTeam As Josco.JSOA.BusinessFacade.IEstateRsXzTeam = Nothing
                Try
                    objIEstateRsXzTeam = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IEstateRsXzTeam)
                Catch ex As Exception
                    objIEstateRsXzTeam = Nothing
                End Try
                If Not (objIEstateRsXzTeam Is Nothing) Then
                    If objIEstateRsXzTeam.oExitMode = True Then
                        Dim strZBBS As String = ""
                        Select Case objIEstateRsXzTeam.iSourceControlId.ToUpper()
                            Case "btnSelectTDBH".ToUpper()
                                If objIEstateRsXzTeam.oDataSet Is Nothing Then
                                    Me.txtTDBH.Text = ""
                                Else
                                    With objIEstateRsXzTeam.oDataSet.Tables(Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_TDZH)
                                        If .Rows.Count < 1 Then
                                            Me.txtTDBH.Text = ""
                                        Else
                                            Me.txtTDBH.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_TDBH), "")
                                        End If
                                    End With
                                End If
                            Case "btnSelectZGTD".ToUpper()
                                If Me.getModuleData_TDZH(strErrMsg) = True Then
                                    '加入新团队组
                                    If Me.doAddInBuffer_TDZH(strErrMsg, objIEstateRsXzTeam.oDataSet, Me.m_objDataSet_TDZH, strZBBS) = True Then
                                        '清除上次缓存
                                        If Me.htxtZGTD.Value.Trim <> "" Then
                                            Me.doDeleteBuffer_TDZH(strErrMsg, Me.htxtZGTD.Value, Me.m_objDataSet_TDZH)
                                        End If
                                        '显示本次列表
                                        Me.doDisplayBuffer_TDZH(strErrMsg, strZBBS, Me.m_objDataSet_TDZH, Me.lstZGTD)
                                        '更新数值
                                        Me.htxtZGTD.Value = strZBBS
                                    End If
                                End If
                            Case "btnSelectXGTD".ToUpper()
                                If Me.getModuleData_TDZH(strErrMsg) = True Then
                                    '加入新团队组
                                    If Me.doAddInBuffer_TDZH(strErrMsg, objIEstateRsXzTeam.oDataSet, Me.m_objDataSet_TDZH, strZBBS) = True Then
                                        '清除上次缓存
                                        If Me.htxtXGTD.Value.Trim <> "" Then
                                            Me.doDeleteBuffer_TDZH(strErrMsg, Me.htxtXGTD.Value, Me.m_objDataSet_TDZH)
                                        End If
                                        '显示本次列表
                                        Me.doDisplayBuffer_TDZH(strErrMsg, strZBBS, Me.m_objDataSet_TDZH, Me.lstXGTD)
                                        '更新数值
                                        Me.htxtXGTD.Value = strZBBS
                                    End If
                                End If

                                'zengxianglin 2010-03-18
                            Case "btnAddnewZGTD".ToUpper()
                                If Me.getModuleData_TDZH(strErrMsg) = True Then
                                    '加入新团队组(新选定+原来存在)
                                    If Me.doAddInBuffer_TDZH(strErrMsg, objIEstateRsXzTeam.oDataSet, Me.htxtZGTD.Value.Trim, Me.m_objDataSet_TDZH, strZBBS) = True Then
                                        '清除上次缓存
                                        If Me.htxtZGTD.Value.Trim <> "" Then
                                            Me.doDeleteBuffer_TDZH(strErrMsg, Me.htxtZGTD.Value, Me.m_objDataSet_TDZH)
                                        End If
                                        '显示本次列表
                                        Me.doDisplayBuffer_TDZH(strErrMsg, strZBBS, Me.m_objDataSet_TDZH, Me.lstZGTD)
                                        '更新数值
                                        Me.htxtZGTD.Value = strZBBS
                                    End If
                                End If
                            Case "btnAddnewXGTD".ToUpper()
                                If Me.getModuleData_TDZH(strErrMsg) = True Then
                                    '加入新团队组(新选定+原来存在)
                                    If Me.doAddInBuffer_TDZH(strErrMsg, objIEstateRsXzTeam.oDataSet, Me.htxtXGTD.Value.Trim, Me.m_objDataSet_TDZH, strZBBS) = True Then
                                        '清除上次缓存
                                        If Me.htxtXGTD.Value.Trim <> "" Then
                                            Me.doDeleteBuffer_TDZH(strErrMsg, Me.htxtXGTD.Value, Me.m_objDataSet_TDZH)
                                        End If
                                        '显示本次列表
                                        Me.doDisplayBuffer_TDZH(strErrMsg, strZBBS, Me.m_objDataSet_TDZH, Me.lstXGTD)
                                        '更新数值
                                        Me.htxtXGTD.Value = strZBBS
                                    End If
                                End If
                                'zengxianglin 2010-03-18
                        End Select
                    End If
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IEstateRsXzTeam.SafeRelease(objIEstateRsXzTeam)
                    Exit Try
                End If
                'zengxianglin 2010-01-02

                '==========================================================================================================================================================
                Dim objIDmxzZzjg As Josco.JsKernal.BusinessFacade.IDmxzZzjg = Nothing
                Try
                    objIDmxzZzjg = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JsKernal.BusinessFacade.IDmxzZzjg)
                Catch ex As Exception
                    objIDmxzZzjg = Nothing
                End Try
                If Not (objIDmxzZzjg Is Nothing) Then
                    If objIDmxzZzjg.oExitMode = True Then
                        Select Case objIDmxzZzjg.iSourceControlId.ToUpper()
                            Case "btnSelectZZDM".ToUpper()
                                Dim strZZMC As String = objIDmxzZzjg.oBumenList
                                Dim strZZDM As String = ""
                                If objsystemCustomer.getZzdmByZzmc(strErrMsg, MyBase.UserId, MyBase.UserPassword, strZZMC, strZZDM) = True Then
                                    Me.htxtZZDM.Value = strZZDM
                                    Me.txtZZDM.Text = strZZMC
                                    Me.doFillSsfzList(strErrMsg, Me.ddlSSFZ, strZZMC)
                                End If
                                'zengxianglin 2008-11-18
                            Case "btnSelectZGDW".ToUpper()
                                Dim strZZMC As String = objIDmxzZzjg.oBumenList
                                Dim strZGDW As String = ""
                                If objsystemCustomer.getZzdmByZzmc(strErrMsg, MyBase.UserId, MyBase.UserPassword, strZZMC, strZGDW) = True Then
                                    Me.htxtZGDW.Value = strZGDW
                                    Me.txtZGDW.Text = strZZMC
                                End If
                                'zengxianglin 2008-11-18
                        End Select
                    End If
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JsKernal.BusinessFacade.IDmxzZzjg.SafeRelease(objIDmxzZzjg)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIEstateRsRenyuanJiagou_Rela As Josco.JSOA.BusinessFacade.IEstateRsRenyuanJiagou_Rela = Nothing
                Try
                    objIEstateRsRenyuanJiagou_Rela = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IEstateRsRenyuanJiagou_Rela)
                Catch ex As Exception
                    objIEstateRsRenyuanJiagou_Rela = Nothing
                End Try
                If Not (objIEstateRsRenyuanJiagou_Rela Is Nothing) Then
                    If objIEstateRsRenyuanJiagou_Rela.oExitMode = True Then
                        Select Case objIEstateRsRenyuanJiagou_Rela.iSourceControlId.ToUpper()
                            Case "btnSelectSJLD".ToUpper()
                                Me.htxtSJLD.Value = objIEstateRsRenyuanJiagou_Rela.oRYDM
                                Me.txtSJLD.Text = objIEstateRsRenyuanJiagou_Rela.oRYZM
                        End Select
                    End If
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IEstateRsRenyuanJiagou_Rela.SafeRelease(objIEstateRsRenyuanJiagou_Rela)
                    Exit Try
                End If

                '=================================================================
                Dim objISjcxCxtj As Josco.JsKernal.BusinessFacade.ISjcxCxtj
                Try
                    objISjcxCxtj = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JsKernal.BusinessFacade.ISjcxCxtj)
                Catch ex As Exception
                    objISjcxCxtj = Nothing
                End Try
                If Not (objISjcxCxtj Is Nothing) Then
                    If objISjcxCxtj.oExitMode = True Then
                        Dim objQueryData As Josco.JsKernal.Common.Data.QueryData = Nothing
                        Select Case objISjcxCxtj.iSourceControlId.ToUpper
                            Case "btnSearchFull_RY".ToUpper
                                Me.htxtRYQuery.Value = objISjcxCxtj.oQueryString
                                If Me.htxtRYSessionIdQuery.Value.Trim = "" Then
                                    Me.htxtRYSessionIdQuery.Value = objPulicParameters.getNewGuid()
                                Else
                                    Try
                                        objQueryData = CType(Session(Me.htxtRYSessionIdQuery.Value), Josco.JsKernal.Common.Data.QueryData)
                                    Catch ex As Exception
                                        objQueryData = Nothing
                                    End Try
                                    Josco.JsKernal.Common.Data.QueryData.SafeRelease(objQueryData)
                                End If
                                Session.Add(Me.htxtRYSessionIdQuery.Value, objISjcxCxtj.oDataSetTJ)
                            Case Else
                        End Select
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

            getInterfaceParameters = False

            Try
                '从QueryString中解析接口参数(不论是否回发)
                Dim objTemp As Object = Nothing
                Try
                    objTemp = Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId))
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IEstateRsRenyuanJiagou_List)
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

                '获取恢复现场参数
                If Me.IsPostBack = False Then
                    Dim strSessionId As String
                    strSessionId = objPulicParameters.getObjectValue(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId), "")
                    Try
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMEstateRsRenyuanJiagou_List)
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

                Me.m_intFixedColumns_grdRY = objPulicParameters.getObjectValue(Me.htxtRYFixed.Value, 0)
                Me.m_intRows_grdRY = objPulicParameters.getObjectValue(Me.htxtRYRows.Value, 0)
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

            Try
                Dim objQueryData As Josco.JsKernal.Common.Data.QueryData = Nothing
                If Me.htxtRYSessionIdQuery.Value.Trim <> "" Then
                    Try
                        objQueryData = CType(Session(Me.htxtRYSessionIdQuery.Value), Josco.JsKernal.Common.Data.QueryData)
                    Catch ex As Exception
                        objQueryData = Nothing
                    End Try
                    Josco.JsKernal.Common.Data.QueryData.SafeRelease(objQueryData)
                    Session.Remove(Me.htxtRYSessionIdQuery.Value)
                End If

                Dim objDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData = Nothing
                If Me.htxtSessionId_TDZH.Value.Trim <> "" Then
                    Try
                        objDataSet = CType(Session(Me.htxtSessionId_TDZH.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                    Catch ex As Exception
                        objDataSet = Nothing
                    End Try
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objDataSet)
                    Session.Remove(Me.htxtSessionId_TDZH.Value)
                End If
            Catch ex As Exception
            End Try

            Exit Sub

        End Sub










        '----------------------------------------------------------------
        ' 将lstTDZH中选定的团队从strZBBS对应的数据中删除，
        ' 返回删除后的数据集objDataSet_Des及新团队组别
        '     strErrMsg      ：返回错误信息
        '     lstTDZH        ：要加入的数据
        '     strZBBS_Old    ：原组别标识
        '     objDataSet_Des ：加入到的数据
        '     strZBBS        ：新组别标识
        ' 返回
        '     True           ：成功
        '     False          ：失败
        ' 更改记录
        '     zengxianglin 2010-03-18 创建
        '----------------------------------------------------------------
        Private Function doDelInBuffer_TDZH( _
            ByRef strErrMsg As String, _
            ByVal lstTDZH As System.Web.UI.WebControls.ListBox, _
            ByVal strZBBS_Old As String, _
            ByRef objDataSet_Des As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByRef strZBBS As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_TDZH
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objDataSet_Old As Josco.JSOA.Common.Data.estateRenshiXingyeData = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataRow As System.Data.DataRow = Nothing
            Dim i, j, intRows, intCols As Integer
            Dim strZHBS As String = ""

            doDelInBuffer_TDZH = False
            strErrMsg = ""
            strZBBS = ""

            Try
                '检查
                '=====================================================================================================================
                If objDataSet_Des Is Nothing Then
                    Exit Try
                End If
                If objDataSet_Des.Tables(strTable) Is Nothing Then
                    Exit Try
                End If
                If lstTDZH Is Nothing Then
                    Exit Try
                End If
                '=====================================================================================================================

                '计算strZBBS_Old对应的团队数据[objDataSet_Old]
                If strZBBS_Old <> "" Then
                    If objsystemEstateRenshiXingye.getDataSet_TDZH(strErrMsg, MyBase.UserId, MyBase.UserPassword, strZBBS_Old, objDataSet_Des, objDataSet_Old) = False Then
                        GoTo errProc
                    End If
                End If
                If objDataSet_Old Is Nothing Then
                    Exit Try
                End If
                If objDataSet_Old.Tables(strTable) Is Nothing Then
                    Exit Try
                End If

                '从objDataSet_Old中删除lstTDZH选定的团队
                Dim intCount As Integer = 0
                intCount = lstTDZH.Items.Count
                For i = 0 To intCount - 1 Step 1
                    If lstTDZH.Items(i).Selected = True Then
                        strZHBS = lstTDZH.Items(i).Value
                        With objDataSet_Old.Tables(strTable)
                            .DefaultView.RowFilter = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_ZHBS + " = '" + strZHBS + "'"
                            objDataRow = Nothing
                            If .DefaultView.Count > 0 Then
                                objDataRow = .DefaultView.Item(0).Row
                            End If
                            If Not (objDataRow Is Nothing) Then
                                .Rows.Remove(objDataRow)
                            End If
                            .DefaultView.RowFilter = ""
                        End With
                    End If
                Next

                '新[组别标识]
                strZBBS = objPulicParameters.getNewGuid()

                '加入objDataSet_Old到objDataSet_Des
                If Not (objDataSet_Old Is Nothing) Then
                    If Not (objDataSet_Old.Tables(strTable) Is Nothing) Then
                        With objDataSet_Old.Tables(strTable)
                            intCols = .Columns.Count
                            intRows = .Rows.Count
                            For i = 0 To intRows - 1 Step 1
                                '新[组合标识]
                                strZHBS = objPulicParameters.getNewGuid()
                                '加入数据
                                With objDataSet_Des.Tables(strTable)
                                    objDataRow = .NewRow
                                End With
                                For j = 0 To intCols - 1 Step 1
                                    objDataRow.Item(j) = .Rows(i).Item(j)
                                Next
                                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_ZHBS) = strZHBS
                                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_ZBBS) = strZBBS
                                With objDataSet_Des.Tables(strTable)
                                    .Rows.Add(objDataRow)
                                End With
                            Next
                        End With
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objDataSet_Old)

            doDelInBuffer_TDZH = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objDataSet_Old)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 将objDataSet_Src写入objDataSet_Des中，只加入objDataSet_Src在
        ' strZBBS_Old中不存在的团队
        '     strErrMsg      ：返回错误信息
        '     objDataSet_Src ：要加入的数据
        '     strZBBS_Old    ：原组别标识
        '     objDataSet_Des ：加入到的数据
        '     strZBBS        ：新组别标识
        ' 返回
        '     True           ：成功
        '     False          ：失败
        ' 更改记录
        '     zengxianglin 2010-03-18 创建
        '----------------------------------------------------------------
        Private Function doAddInBuffer_TDZH( _
            ByRef strErrMsg As String, _
            ByVal objDataSet_Src As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByVal strZBBS_Old As String, _
            ByRef objDataSet_Des As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByRef strZBBS As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_TDZH
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objDataSet_Old As Josco.JSOA.Common.Data.estateRenshiXingyeData = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataRow As System.Data.DataRow = Nothing
            Dim i, j, intRows, intCols As Integer
            Dim strZHBS As String = ""

            doAddInBuffer_TDZH = False
            strErrMsg = ""
            strZBBS = ""

            Try
                '检查
                '=====================================================================================================================
                If objDataSet_Src Is Nothing Then
                    Exit Try
                End If
                If objDataSet_Src.Tables(strTable) Is Nothing Then
                    Exit Try
                End If
                If objDataSet_Src.Tables(strTable).Rows.Count < 1 Then
                    Exit Try
                End If
                '=====================================================================================================================
                If objDataSet_Des Is Nothing Then
                    Exit Try
                End If
                If objDataSet_Des.Tables(strTable) Is Nothing Then
                    Exit Try
                End If
                '=====================================================================================================================

                '计算strZBBS_Old对应的团队数据[objDataSet_Old]
                If strZBBS_Old <> "" Then
                    If objsystemEstateRenshiXingye.getDataSet_TDZH(strErrMsg, MyBase.UserId, MyBase.UserPassword, strZBBS_Old, objDataSet_Des, objDataSet_Old) = False Then
                        GoTo errProc
                    End If
                End If

                '新[组别标识]
                strZBBS = objPulicParameters.getNewGuid()

                '加入objDataSet_Old到objDataSet_Des
                If Not (objDataSet_Old Is Nothing) Then
                    If Not (objDataSet_Old.Tables(strTable) Is Nothing) Then
                        With objDataSet_Old.Tables(strTable)
                            intCols = .Columns.Count
                            intRows = .Rows.Count
                            For i = 0 To intRows - 1 Step 1
                                '新[组合标识]
                                strZHBS = objPulicParameters.getNewGuid()
                                '加入数据
                                With objDataSet_Des.Tables(strTable)
                                    objDataRow = .NewRow
                                End With
                                For j = 0 To intCols - 1 Step 1
                                    objDataRow.Item(j) = .Rows(i).Item(j)
                                Next
                                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_ZHBS) = strZHBS
                                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_ZBBS) = strZBBS
                                With objDataSet_Des.Tables(strTable)
                                    .Rows.Add(objDataRow)
                                End With
                            Next
                        End With
                    End If
                End If

                '加入objDataSet_Src到objDataSet_Des
                Dim blnExisted As Boolean = False
                Dim strFilterOld As String = ""
                Dim strFilter As String = ""
                Dim strSSDW As String = ""
                Dim intTDBH As Integer = 0
                With objDataSet_Src.Tables(strTable)
                    intCols = .Columns.Count
                    intRows = .Rows.Count
                    For i = 0 To intRows - 1 Step 1
                        '新[组合标识]
                        strZHBS = objPulicParameters.getNewGuid()
                        '计算新选数据
                        strSSDW = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_SSDW), "")
                        intTDBH = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_TDBH), 0)
                        '检查是否存在？
                        blnExisted = False
                        With objDataSet_Des.Tables(strTable)
                            strFilter = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_ZBBS + " = '" + strZBBS + "'"
                            strFilter = strFilter + " and " + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_SSDW + " = '" + strSSDW + "'"
                            strFilter = strFilter + " and " + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_TDBH + " = " + intTDBH.ToString + ""
                            strFilterOld = .DefaultView.RowFilter
                            .DefaultView.RowFilter = strFilter
                            If .DefaultView.Count > 0 Then
                                blnExisted = True
                            End If
                            .DefaultView.RowFilter = strFilterOld
                        End With
                        '不存在，则加入！
                        If blnExisted = False Then
                            With objDataSet_Des.Tables(strTable)
                                objDataRow = .NewRow
                            End With
                            For j = 0 To intCols - 1 Step 1
                                objDataRow.Item(j) = .Rows(i).Item(j)
                            Next
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_ZHBS) = strZHBS
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_ZBBS) = strZBBS
                            With objDataSet_Des.Tables(strTable)
                                .Rows.Add(objDataRow)
                            End With
                        End If
                    Next
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objDataSet_Old)

            doAddInBuffer_TDZH = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objDataSet_Old)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 将objDataSet_Src写入objDataSet_Des中
        '     strErrMsg      ：返回错误信息
        '     objDataSet_Src ：要加入的数据
        '     objDataSet_Des ：加入到的数据
        '     strZBBS        ：新组别标识
        ' 返回
        '     True           ：成功
        '     False          ：失败
        ' 更改记录
        '     zengxianglin 2010-01-02 创建
        '----------------------------------------------------------------
        Private Function doAddInBuffer_TDZH( _
            ByRef strErrMsg As String, _
            ByVal objDataSet_Src As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByRef objDataSet_Des As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByRef strZBBS As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_TDZH
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataRow As System.Data.DataRow = Nothing
            Dim i, j, intRows, intCols As Integer
            Dim strZHBS As String = ""

            doAddInBuffer_TDZH = False
            strErrMsg = ""
            strZBBS = ""

            Try
                '检查
                '=====================================================================================================================
                If objDataSet_Src Is Nothing Then
                    Exit Try
                End If
                If objDataSet_Src.Tables(strTable) Is Nothing Then
                    Exit Try
                End If
                If objDataSet_Src.Tables(strTable).Rows.Count < 1 Then
                    Exit Try
                End If
                '=====================================================================================================================
                If objDataSet_Des Is Nothing Then
                    Exit Try
                End If
                If objDataSet_Des.Tables(strTable) Is Nothing Then
                    Exit Try
                End If
                '=====================================================================================================================

                '主处理
                strZBBS = objPulicParameters.getNewGuid()
                With objDataSet_Src.Tables(strTable)
                    intCols = .Columns.Count
                    intRows = .Rows.Count
                    For i = 0 To intRows - 1 Step 1
                        strZHBS = objPulicParameters.getNewGuid()

                        With objDataSet_Des.Tables(strTable)
                            objDataRow = .NewRow
                        End With

                        For j = 0 To intCols - 1 Step 1
                            objDataRow.Item(j) = .Rows(i).Item(j)
                        Next
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_ZHBS) = strZHBS
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_ZBBS) = strZBBS

                        With objDataSet_Des.Tables(strTable)
                            .Rows.Add(objDataRow)
                        End With
                    Next
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            doAddInBuffer_TDZH = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 从objDataSet_Des删除strZBBS对应的数据
        '     strErrMsg      ：返回错误信息
        '     strZBBS        ：组别标识
        '     objDataSet_Des ：操作数据
        ' 返回
        '     True           ：成功
        '     False          ：失败
        ' 更改记录
        '     zengxianglin 2010-01-02 创建
        '----------------------------------------------------------------
        Private Function doDeleteBuffer_TDZH( _
            ByRef strErrMsg As String, _
            ByVal strZBBS As String, _
            ByRef objDataSet_Des As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_TDZH
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strOldRowFilter As String = ""
            Dim i, intRows As Integer

            doDeleteBuffer_TDZH = False
            strErrMsg = ""

            Try
                '检查
                '=====================================================================================================================
                If objDataSet_Des Is Nothing Then
                    Exit Try
                End If
                If objDataSet_Des.Tables(strTable) Is Nothing Then
                    Exit Try
                End If
                If objDataSet_Des.Tables(strTable).Rows.Count < 1 Then
                    Exit Try
                End If
                '=====================================================================================================================

                '备份
                With objDataSet_Des.Tables(strTable)
                    strOldRowFilter = .DefaultView.RowFilter
                End With

                '搜索
                With objDataSet_Des.Tables(strTable)
                    .DefaultView.RowFilter = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_ZBBS + " = '" + strZBBS + "'"
                End With

                '主处理
                With objDataSet_Des.Tables(strTable)
                    intRows = .DefaultView.Count
                    For i = intRows - 1 To 0 Step -1
                        .Rows.Remove(.DefaultView.Item(i).Row)
                    Next
                End With

                '恢复
                With objDataSet_Des.Tables(strTable)
                    .DefaultView.RowFilter = strOldRowFilter
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            doDeleteBuffer_TDZH = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示strZBBS的objDataSet_Des数据到objListBox
        '     strErrMsg      ：返回错误信息
        '     strZBBS        ：组别标识
        '     objDataSet_Des ：显示数据
        '     objListBox     ：显示控件
        ' 返回
        '     True           ：成功
        '     False          ：失败
        ' 更改记录
        '     zengxianglin 2010-01-02 创建
        '----------------------------------------------------------------
        Private Function doDisplayBuffer_TDZH( _
            ByRef strErrMsg As String, _
            ByVal strZBBS As String, _
            ByVal objDataSet_Des As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByVal objListBox As System.Web.UI.WebControls.ListBox) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_TDZH
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objListItem As System.Web.UI.WebControls.ListItem = Nothing
            Dim strOldRowFilter As String = ""
            Dim strZHBS As String = ""
            Dim strDWMC As String = ""
            Dim strTDBH As String = ""
            Dim i, intRows As Integer

            doDisplayBuffer_TDZH = False
            strErrMsg = ""

            Try
                '检查
                '=====================================================================================================================
                If objDataSet_Des Is Nothing Then
                    Exit Try
                End If
                If objDataSet_Des.Tables(strTable) Is Nothing Then
                    Exit Try
                End If
                '=====================================================================================================================

                '清空
                objListBox.Items.Clear()

                '备份
                With objDataSet_Des.Tables(strTable)
                    strOldRowFilter = .DefaultView.RowFilter
                End With

                '搜索
                With objDataSet_Des.Tables(strTable)
                    .DefaultView.RowFilter = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_ZBBS + " = '" + strZBBS + "'"
                End With

                '主处理
                With objDataSet_Des.Tables(strTable)
                    intRows = .DefaultView.Count
                    For i = 0 To intRows - 1 Step 1
                        strZHBS = objPulicParameters.getObjectValue(.DefaultView.Item(i).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_ZHBS), "")
                        strDWMC = objPulicParameters.getObjectValue(.DefaultView.Item(i).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_DWMC), "")
                        strTDBH = objPulicParameters.getObjectValue(.DefaultView.Item(i).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_TDBH), "")

                        objListItem = New System.Web.UI.WebControls.ListItem
                        objListItem.Value = strZHBS
                        objListItem.Text = strDWMC + "_" + strTDBH

                        objListBox.Items.Add(objListItem)
                    Next
                End With

                '恢复
                With objDataSet_Des.Tables(strTable)
                    .DefaultView.RowFilter = strOldRowFilter
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            doDisplayBuffer_TDZH = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取grdRY搜索条件(默认表前缀a.)
        '     strErrMsg      ：返回错误信息
        '     strQuery       ：返回的搜索条件
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getQueryString_RY( _
            ByRef strErrMsg As String, _
            ByRef strQuery As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getQueryString_RY = False
            strQuery = ""

            Try
                '按人员代码搜索
                Dim strRYDM As String = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYDM
                If Me.txtSearch_RY_RYDM.Text.Length > 0 Then Me.txtSearch_RY_RYDM.Text = Me.txtSearch_RY_RYDM.Text.Trim()
                If Me.txtSearch_RY_RYDM.Text <> "" Then
                    If strQuery = "" Then
                        strQuery = strRYDM + " like '" + Me.txtSearch_RY_RYDM.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strRYDM + " like '" + Me.txtSearch_RY_RYDM.Text + "%'"
                    End If
                End If

                '按变动时间搜索
                Dim strKSSJ As String = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_KSSJ
                Dim strJSSJ As String = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_JSSJ
                Dim strNewT As String = ""
                If Me.txtSearch_RY_BDSJ.Text.Length > 0 Then Me.txtSearch_RY_BDSJ.Text = Me.txtSearch_RY_BDSJ.Text.Trim()
                If Me.txtSearch_RY_BDSJ.Text <> "" Then
                    If objPulicParameters.isDatetimeString(Me.txtSearch_RY_BDSJ.Text) = False Then
                        strErrMsg = "错误：[" + Me.txtSearch_RY_BDSJ.Text + "]是无效的时间！"
                        GoTo errProc
                    End If
                    Me.txtSearch_RY_BDSJ.Text = CType(Me.txtSearch_RY_BDSJ.Text, System.DateTime).ToString("yyyy-MM-dd HH:mm:ss")
                    strNewT = CType(Me.txtSearch_RY_BDSJ.Text, System.DateTime).AddSeconds(-1).ToString("yyyy-MM-dd HH:mm:ss")
                    If strQuery = "" Then
                        strQuery = ""
                        strQuery = strQuery + "(" + strKSSJ + " = '" + Me.txtSearch_RY_BDSJ.Text + "'"
                        strQuery = strQuery + " or "
                        strQuery = strQuery + " " + strJSSJ + " = '" + strNewT + "'" + ")"
                    Else
                        strQuery = strQuery + " and "
                        strQuery = strQuery + "(" + strKSSJ + " = '" + Me.txtSearch_RY_BDSJ.Text + "'"
                        strQuery = strQuery + " or "
                        strQuery = strQuery + " " + strJSSJ + " = '" + strNewT + "'" + ")"
                    End If
                End If

                '按人员名称搜索
                Dim strRYMC As String = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYMC
                If Me.txtSearch_RY_RYMC.Text.Length > 0 Then Me.txtSearch_RY_RYMC.Text = Me.txtSearch_RY_RYMC.Text.Trim()
                If Me.txtSearch_RY_RYMC.Text <> "" Then
                    If strQuery = "" Then
                        strQuery = strRYMC + " like '" + Me.txtSearch_RY_RYMC.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strRYMC + " like '" + Me.txtSearch_RY_RYMC.Text + "%'"
                    End If
                End If

                '按人员名称搜索
                Dim strSSDWMC As String = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SSDWMC
                If Me.txtSearch_RY_DWMC.Text.Length > 0 Then Me.txtSearch_RY_DWMC.Text = Me.txtSearch_RY_DWMC.Text.Trim()
                If Me.txtSearch_RY_DWMC.Text <> "" Then
                    If strQuery = "" Then
                        strQuery = strSSDWMC + " like '" + Me.txtSearch_RY_DWMC.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strSSDWMC + " like '" + Me.txtSearch_RY_DWMC.Text + "%'"
                    End If
                End If

                Dim dateMin As System.DateTime
                Dim dateMax As System.DateTime

                '按[生效时间]搜索
                strKSSJ = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_KSSJ
                If Me.txtSearch_RY_KSSJMin.Text.Length > 0 Then Me.txtSearch_RY_KSSJMin.Text = Me.txtSearch_RY_KSSJMin.Text.Trim()
                If Me.txtSearch_RY_KSSJMax.Text.Length > 0 Then Me.txtSearch_RY_KSSJMax.Text = Me.txtSearch_RY_KSSJMax.Text.Trim()
                If Me.txtSearch_RY_KSSJMin.Text <> "" And Me.txtSearch_RY_KSSJMax.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtSearch_RY_KSSJMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的时间！"
                        GoTo errProc
                    End Try
                    Try
                        dateMax = CType(Me.txtSearch_RY_KSSJMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的时间！"
                        GoTo errProc
                    End Try
                    If dateMin > dateMax Then
                        Me.txtSearch_RY_KSSJMin.Text = dateMax.ToString("yyyy-MM-dd HH:mm:ss")
                        Me.txtSearch_RY_KSSJMax.Text = dateMin.ToString("yyyy-MM-dd HH:mm:ss")
                    Else
                        Me.txtSearch_RY_KSSJMin.Text = dateMin.ToString("yyyy-MM-dd HH:mm:ss")
                        Me.txtSearch_RY_KSSJMax.Text = dateMax.ToString("yyyy-MM-dd HH:mm:ss")
                    End If
                    If strQuery = "" Then
                        strQuery = strKSSJ + " between '" + Me.txtSearch_RY_KSSJMin.Text + "' and '" + Me.txtSearch_RY_KSSJMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strKSSJ + " between '" + Me.txtSearch_RY_KSSJMin.Text + "' and '" + Me.txtSearch_RY_KSSJMax.Text + "'"
                    End If
                ElseIf Me.txtSearch_RY_KSSJMin.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtSearch_RY_KSSJMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的时间！"
                        GoTo errProc
                    End Try
                    Me.txtSearch_RY_KSSJMin.Text = dateMin.ToString("yyyy-MM-dd HH:mm:ss")
                    If strQuery = "" Then
                        strQuery = strKSSJ + " >= '" + Me.txtSearch_RY_KSSJMin.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strKSSJ + " >= '" + Me.txtSearch_RY_KSSJMin.Text + "'"
                    End If
                ElseIf Me.txtSearch_RY_KSSJMax.Text <> "" Then
                    Try
                        dateMax = CType(Me.txtSearch_RY_KSSJMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的时间！"
                        GoTo errProc
                    End Try
                    Me.txtSearch_RY_KSSJMax.Text = dateMax.ToString("yyyy-MM-dd HH:mm:ss")
                    If strQuery = "" Then
                        strQuery = strKSSJ + " <= '" + Me.txtSearch_RY_KSSJMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strKSSJ + " <= '" + Me.txtSearch_RY_KSSJMax.Text + "'"
                    End If
                Else
                End If

                '按[失效时间]搜索
                strJSSJ = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_JSSJ
                If Me.txtSearch_RY_JSSJMin.Text.Length > 0 Then Me.txtSearch_RY_JSSJMin.Text = Me.txtSearch_RY_JSSJMin.Text.Trim()
                If Me.txtSearch_RY_JSSJMax.Text.Length > 0 Then Me.txtSearch_RY_JSSJMax.Text = Me.txtSearch_RY_JSSJMax.Text.Trim()
                If Me.txtSearch_RY_JSSJMin.Text <> "" And Me.txtSearch_RY_JSSJMax.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtSearch_RY_JSSJMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的时间！"
                        GoTo errProc
                    End Try
                    Try
                        dateMax = CType(Me.txtSearch_RY_JSSJMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的时间！"
                        GoTo errProc
                    End Try
                    If dateMin > dateMax Then
                        Me.txtSearch_RY_JSSJMin.Text = dateMax.ToString("yyyy-MM-dd HH:mm:ss")
                        Me.txtSearch_RY_JSSJMax.Text = dateMin.ToString("yyyy-MM-dd HH:mm:ss")
                    Else
                        Me.txtSearch_RY_JSSJMin.Text = dateMin.ToString("yyyy-MM-dd HH:mm:ss")
                        Me.txtSearch_RY_JSSJMax.Text = dateMax.ToString("yyyy-MM-dd HH:mm:ss")
                    End If
                    If strQuery = "" Then
                        strQuery = strJSSJ + " between '" + Me.txtSearch_RY_JSSJMin.Text + "' and '" + Me.txtSearch_RY_JSSJMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strJSSJ + " between '" + Me.txtSearch_RY_JSSJMin.Text + "' and '" + Me.txtSearch_RY_JSSJMax.Text + "'"
                    End If
                ElseIf Me.txtSearch_RY_JSSJMin.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtSearch_RY_JSSJMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的时间！"
                        GoTo errProc
                    End Try
                    Me.txtSearch_RY_JSSJMin.Text = dateMin.ToString("yyyy-MM-dd HH:mm:ss")
                    If strQuery = "" Then
                        strQuery = strJSSJ + " >= '" + Me.txtSearch_RY_JSSJMin.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strJSSJ + " >= '" + Me.txtSearch_RY_JSSJMin.Text + "'"
                    End If
                ElseIf Me.txtSearch_RY_JSSJMax.Text <> "" Then
                    Try
                        dateMax = CType(Me.txtSearch_RY_JSSJMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：无效的时间！"
                        GoTo errProc
                    End Try
                    Me.txtSearch_RY_JSSJMax.Text = dateMax.ToString("yyyy-MM-dd HH:mm:ss")
                    If strQuery = "" Then
                        strQuery = strJSSJ + " <= '" + Me.txtSearch_RY_JSSJMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strJSSJ + " <= '" + Me.txtSearch_RY_JSSJMax.Text + "'"
                    End If
                Else
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getQueryString_RY = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取grdRY要显示的数据信息
        '     strErrMsg      ：返回错误信息
        '     strWhere       ：搜索字符串
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_RY( _
            ByRef strErrMsg As String, _
            ByVal strWhere As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_V_RS_RENYUANJIAGOU
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye

            getModuleData_RY = False

            Try
                '备份Sort字符串
                Dim strSort As String = ""
                strSort = Me.htxtRYSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '释放资源
                Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(Me.m_objDataSet_RY)

                '重新检索数据
                If objsystemEstateRenshiXingye.getDataSet_RYJG(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWhere, Me.m_objDataSet_RY) = False Then
                    GoTo errProc
                End If

                '恢复Sort字符串
                With Me.m_objDataSet_RY.Tables(strTable)
                    .DefaultView.Sort = strSort
                End With

                '缓存参数
                With Me.m_objDataSet_RY.Tables(strTable)
                    Me.htxtRYRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_grdRY = .DefaultView.Count
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)

            getModuleData_RY = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取团队组合临时数据集
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        ' 更改记录
        '     zengxianglin 2010-01-02 创建
        '----------------------------------------------------------------
        Private Function getModuleData_TDZH(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_TDZH
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getModuleData_TDZH = False

            Try
                '根据需要获取
                If Me.htxtSessionId_TDZH.Value.Trim <> "" Then
                    '从缓存中获取数据
                    Me.m_objDataSet_TDZH = CType(Session.Item(Me.htxtSessionId_TDZH.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                Else
                    '释放资源
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(Me.m_objDataSet_TDZH)
                    '空数据
                    Me.m_objDataSet_TDZH = New Josco.JSOA.Common.Data.estateRenshiXingyeData(Josco.JSOA.Common.Data.estateRenshiXingyeData.enumTableType.DC_B_RS_TDZH)
                    '缓存数据
                    Me.htxtSessionId_TDZH.Value = objPulicParameters.getNewGuid()
                    Session.Add(Me.htxtSessionId_TDZH.Value, Me.m_objDataSet_TDZH)
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getModuleData_TDZH = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 根据屏幕搜索条件搜索数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function searchModuleData_RY(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_V_RS_RENYUANJIAGOU

            searchModuleData_RY = False

            Try
                '获取搜索字符串
                Dim strQuery As String
                If Me.getQueryString_RY(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '搜索数据
                If Me.getModuleData_RY(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '记录搜索字符串
                Me.htxtRYQuery.Value = strQuery
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            searchModuleData_RY = True
            Exit Function
errProc:
            Exit Function

        End Function











        '----------------------------------------------------------------
        ' 将grdRY当前行信息显示到参数表中
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        ' 更改记录
        '     zengxianglin 2010-01-02 更改
        '     zengxianglin 2010-03-18 更改
        '----------------------------------------------------------------
        Private Function showEditPanel_RY(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_V_RS_RENYUANJIAGOU
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objTempDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData = Nothing
            Dim objRadioButtonListProcess As New Josco.JsKernal.web.RadioButtonListProcess
            Dim objDropDownListProcess As New Josco.JsKernal.web.DropDownListProcess
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showEditPanel_RY = False

            Try
                '清空
                Me.txtKSSJ.Text = ""
                Me.txtJSSJ.Text = ""
                Me.htxtZZDM.Value = ""
                Me.txtZZDM.Text = ""
                'zengxianglin 2008-11-18
                Me.htxtZGDW.Value = ""
                Me.txtZGDW.Text = ""
                'zengxianglin 2008-11-18
                Me.ddlSSFZ.SelectedIndex = -1
                Me.ddlZJDM.SelectedIndex = -1
                Me.rblRYZT.SelectedIndex = -1
                Me.rblSFZB.SelectedIndex = -1
                'zengxianglin 2010-01-02
                Me.chkSFJZ.Checked = False
                Me.htxtBZXL.Value = ""
                Me.txtTDBH.Text = ""
                Me.htxtZGTD.Value = ""
                Me.lstZGTD.Items.Clear()
                Me.htxtXGTD.Value = ""
                Me.lstXGTD.Items.Clear()
                Me.ddlYDYY.SelectedIndex = -1
                'zengxianglin 2010-01-02

                '检查
                If Me.grdRY.SelectedIndex < 0 Then
                    Exit Try
                End If
                Dim intIndex As Integer = Me.grdRY.SelectedIndex

                '显示
                Dim intColIndex As Integer
                Dim strValue As String = ""
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SSDW)
                Me.htxtZZDM.Value = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(intIndex), intColIndex)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SSDWMC)
                Me.txtZZDM.Text = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(intIndex), intColIndex)
                Me.doFillSsfzList(strErrMsg, Me.ddlSSFZ, Me.txtZZDM.Text)

                'zengxianglin 2008-11-18
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZGDW)
                Me.htxtZGDW.Value = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(intIndex), intColIndex)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZGDWMC)
                Me.txtZGDW.Text = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(intIndex), intColIndex)
                'zengxianglin 2008-11-18

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SJLD)
                Me.htxtSJLD.Value = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(intIndex), intColIndex)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SJLDMC)
                Me.txtSJLD.Text = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(intIndex), intColIndex)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZJDM)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(intIndex), intColIndex)
                Me.ddlZJDM.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlZJDM, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYZT)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(intIndex), intColIndex)
                Me.rblRYZT.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblRYZT, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SFZB)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(intIndex), intColIndex)
                Me.rblSFZB.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblSFZB, strValue)

                Me.doFillSsfzList(strErrMsg, Me.ddlSSFZ, Me.txtZZDM.Text)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SSFZ)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(intIndex), intColIndex)
                Me.ddlSSFZ.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlSSFZ, strValue, True)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_KSSJ)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(intIndex), intColIndex)
                Me.txtKSSJ.Text = strValue

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_JSSJ)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(intIndex), intColIndex)
                Me.txtJSSJ.Text = strValue

                'zengxianglin 2010-01-02
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_BZXL)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(intIndex), intColIndex)
                Me.htxtBZXL.Value = strValue
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_TDBH)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(intIndex), intColIndex)
                Me.txtTDBH.Text = strValue
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZGTD)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(intIndex), intColIndex)
                Me.htxtZGTD.Value = strValue
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_XGTD)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(intIndex), intColIndex)
                Me.htxtXGTD.Value = strValue
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_YDYY)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(intIndex), intColIndex)
                Me.ddlYDYY.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlYDYY, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SFJZ)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(intIndex), intColIndex)
                If strValue = "1" Then
                    Me.chkSFJZ.Checked = True
                Else
                    Me.chkSFJZ.Checked = False
                End If
                If Me.getModuleData_TDZH(strErrMsg) = True Then
                    If objsystemEstateRenshiXingye.getDataSet_TDZH(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.htxtZGTD.Value, Me.m_objDataSet_TDZH, objTempDataSet) = True Then
                        Me.doDisplayBuffer_TDZH(strErrMsg, Me.htxtZGTD.Value, objTempDataSet, Me.lstZGTD)
                    End If
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objTempDataSet)
                    If objsystemEstateRenshiXingye.getDataSet_TDZH(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.htxtXGTD.Value, Me.m_objDataSet_TDZH, objTempDataSet) = True Then
                        Me.doDisplayBuffer_TDZH(strErrMsg, Me.htxtXGTD.Value, objTempDataSet, Me.lstXGTD)
                    End If
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objTempDataSet)
                End If
                'zengxianglin 2010-01-02

                'zengxianglin 2010-01-02
                '控制输入
                Dim intBZXL As Integer
                Dim blnVal As Boolean
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYLX)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(intIndex), intColIndex)
                If strValue = "1" Then
                    Me.chkSFJZ.Enabled = False
                Else
                    Me.chkSFJZ.Enabled = True
                End If
                If objsystemEstateRenshiXingye.getBZXL_RSJG(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.txtKSSJ.Text, intBZXL) = True Then
                    Select Case intBZXL
                        Case 1 '管理模式一
                            blnVal = True

                            Me.txtSJLD.Enabled = blnVal
                            Me.btnSelectSJLD.Visible = blnVal
                            Me.ddlSSFZ.Enabled = blnVal
                            Me.btnJSFZLB.Visible = blnVal
                            Me.txtZGDW.Enabled = blnVal
                            Me.btnSelectZGDW.Visible = blnVal

                            Me.txtTDBH.Enabled = Not blnVal
                            Me.btnSelectTDBH.Visible = Not blnVal
                            Me.btnSelectZGTD.Visible = Not blnVal
                            Me.btnSelectXGTD.Visible = Not blnVal
                            'zengxianglin 2010-03-18
                            Me.btnAddnewZGTD.Visible = Not blnVal
                            Me.btnDeleteZGTD.Visible = Not blnVal
                            Me.btnAddnewXGTD.Visible = Not blnVal
                            Me.btnDeleteXGTD.Visible = Not blnVal
                            'zengxianglin 2010-03-18
                        Case 2 '管理模式二
                            blnVal = False

                            Me.txtSJLD.Enabled = blnVal
                            Me.btnSelectSJLD.Visible = blnVal
                            Me.ddlSSFZ.Enabled = blnVal
                            Me.btnJSFZLB.Visible = blnVal
                            Me.txtZGDW.Enabled = blnVal
                            Me.btnSelectZGDW.Visible = blnVal

                            Me.txtTDBH.Enabled = Not blnVal
                            Me.btnSelectTDBH.Visible = Not blnVal
                            Me.btnSelectZGTD.Visible = Not blnVal
                            Me.btnSelectXGTD.Visible = Not blnVal
                            'zengxianglin 2010-03-18
                            Me.btnAddnewZGTD.Visible = Not blnVal
                            Me.btnDeleteZGTD.Visible = Not blnVal
                            Me.btnAddnewXGTD.Visible = Not blnVal
                            Me.btnDeleteXGTD.Visible = Not blnVal
                            'zengxianglin 2010-03-18
                        Case Else
                            blnVal = False

                            Me.txtSJLD.Enabled = blnVal
                            Me.btnSelectSJLD.Visible = blnVal
                            Me.ddlSSFZ.Enabled = blnVal
                            Me.btnJSFZLB.Visible = blnVal
                            Me.txtZGDW.Enabled = blnVal
                            Me.btnSelectZGDW.Visible = blnVal

                            Me.txtTDBH.Enabled = blnVal
                            Me.btnSelectTDBH.Visible = blnVal
                            Me.btnSelectZGTD.Visible = blnVal
                            Me.btnSelectXGTD.Visible = blnVal
                            'zengxianglin 2010-03-18
                            Me.btnAddnewZGTD.Visible = blnVal
                            Me.btnDeleteZGTD.Visible = blnVal
                            Me.btnAddnewXGTD.Visible = blnVal
                            Me.btnDeleteXGTD.Visible = blnVal
                            'zengxianglin 2010-03-18
                    End Select
                End If
                'zengxianglin 2010-01-02
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objTempDataSet)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showEditPanel_RY = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objTempDataSet)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdRY的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo_RY(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_V_RS_RENYUANJIAGOU
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_RY = False

            '获取系统保存的网格排序数据
            Dim intSortColumnIndex As Integer = -1
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtRYSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtRYSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '网格显示处理
            Try
                '设置数据源
                If Me.m_objDataSet_RY Is Nothing Then
                    Me.grdRY.DataSource = Nothing
                Else
                    With Me.m_objDataSet_RY.Tables(strTable)
                        Me.grdRY.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objDataSet_RY.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdRY, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '恢复列标题中的排序信息
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdRY)
                    With Me.grdRY.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '绑定数据
                Me.grdRY.DataBind()

                '----------------------------------------------------------------
                '因为这些信息是非绑定的，所以下面的操作必须等绑定完成后执行！！！
                '一旦在后续处理中执行了DataBind，则信息会丢失！！！
                '----------------------------------------------------------------
                '恢复网格中的CheckBox状态
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdRY, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_grdRY) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_RY = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdRY相关信息
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        ' 更改说明
        '     zengxianglin 2008-11-06 增加
        '       Optional ByVal blnTongbu As Boolean = True
        '----------------------------------------------------------------
        Private Function showModuleData_RY( _
            ByRef strErrMsg As String, _
            Optional ByVal blnTongbu As Boolean = True) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_V_RS_RENYUANJIAGOU
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showModuleData_RY = False

            Try
                '显示网格信息
                If Me.showDataGridInfo_RY(strErrMsg) = False Then
                    GoTo errProc
                End If

                '显示与网格紧密相关的操作或信息提示
                With Me.m_objDataSet_RY.Tables(strTable).DefaultView
                    '显示网格位置信息
                    Me.lblRYGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdRY, .Count)

                    '显示页面浏览功能
                    Me.lnkCZRYMoveFirst.Enabled = objDataGridProcess.canDoMoveFirstPage(Me.grdRY, .Count)
                    Me.lnkCZRYMoveLast.Enabled = objDataGridProcess.canDoMoveLastPage(Me.grdRY, .Count)
                    Me.lnkCZRYMovePrev.Enabled = objDataGridProcess.canDoMovePreviousPage(Me.grdRY, .Count)
                    Me.lnkCZRYMoveNext.Enabled = objDataGridProcess.canDoMoveNextPage(Me.grdRY, .Count)

                    '显示相关操作
                    Dim blnEnabled As Boolean
                    If .Count < 1 Then
                        blnEnabled = False
                    Else
                        blnEnabled = True
                    End If
                    Me.lnkCZRYDeSelectAll.Enabled = blnEnabled
                    Me.lnkCZRYSelectAll.Enabled = blnEnabled
                    Me.lnkCZRYGotoPage.Enabled = blnEnabled
                    Me.lnkCZRYSetPageSize.Enabled = blnEnabled
                End With

                '显示当前行信息
                'zengxianglin 2008-11-06
                If blnTongbu = True Then
                    If Me.showEditPanel_RY(strErrMsg) = False Then
                        GoTo errProc
                    End If
                End If
                'zengxianglin 2008-11-06
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showModuleData_RY = True
            Exit Function
errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示整个模块信息
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleData_Main(ByRef strErrMsg As String) As Boolean

            showModuleData_Main = False

            Try
                Me.btnMidify.Visible = Me.m_blnPrevilegeParams(1)
                Me.btnDelete.Visible = Me.m_blnPrevilegeParams(1)
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            showModuleData_Main = True
            Exit Function
errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 填充职级下拉列表框
        '     strErrMsg      ：返回错误信息
        '     objDropDownList：要填充的列表框
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function doFillZjdmList( _
            ByRef strErrMsg As String, _
            ByVal objDropDownList As System.Web.UI.WebControls.DropDownList) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_ZHIJIDINGYI
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            doFillZjdmList = False
            strErrMsg = ""

            Try
                '检查
                If objDropDownList Is Nothing Then
                    strErrMsg = "错误：[doFillZjdmList]接口参数不正确！"
                    GoTo errProc
                End If

                '获取数据
                'zengxianglin 2010-01-02
                'If objsystemEstateRenshiXingye.getDataSet_ZhijiDingyi(strErrMsg, MyBase.UserId, MyBase.UserPassword, "", objestateRenshiXingyeData) = False Then
                '    GoTo errProc
                'End If
                Dim strWhere As String = ""
                strWhere = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_ZHIJIDINGYI_JBSZ + " > 0"
                If objsystemEstateRenshiXingye.getDataSet_ZhijiDingyi(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWhere, objestateRenshiXingyeData) = False Then
                    GoTo errProc
                End If
                'zengxianglin 2010-01-02

                '清空现有列表
                objDropDownList.Items.Clear()

                '填充数据
                Dim objListItem As System.Web.UI.WebControls.ListItem = Nothing
                Dim strCode As String = ""
                Dim strName As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                With objestateRenshiXingyeData.Tables(strTable)
                    intCount = .Rows.Count
                    For i = 0 To intCount - 1 Step 1
                        strCode = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_ZHIJIDINGYI_ZJDM), "")
                        strName = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_ZHIJIDINGYI_ZJMC), "")

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

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objestateRenshiXingyeData)

            doFillZjdmList = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objestateRenshiXingyeData)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 填充分组下拉列表框
        '     strErrMsg      ：返回错误信息
        '     objDropDownList：要填充的列表框
        '     strZZMC        ：组织名称
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function doFillSsfzList( _
            ByRef strErrMsg As String, _
            ByVal objDropDownList As System.Web.UI.WebControls.DropDownList, _
            ByVal strZZMC As String) As Boolean

            Dim strTable As String = Josco.JsKernal.Common.Data.CustomerData.TABLE_GG_B_ZUZHIFENZU
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objsystemCustomer As New Josco.JsKernal.BusinessFacade.systemCustomer
            Dim objCustomerData As Josco.JsKernal.Common.Data.CustomerData = Nothing

            doFillSsfzList = False
            strErrMsg = ""

            Try
                '检查
                If objDropDownList Is Nothing Then
                    strErrMsg = "错误：[doFillYdyyList]接口参数不正确！"
                    GoTo errProc
                End If
                If strZZMC Is Nothing Then strZZMC = ""
                strZZMC = strZZMC.Trim

                '清空现有列表
                objDropDownList.Items.Clear()
                objDropDownList.Items.Add("")
                If strZZMC = "" Then
                    Exit Try
                End If

                '获取数据
                If objsystemCustomer.getFenzuDataByFhmc(strErrMsg, MyBase.UserId, MyBase.UserPassword, strZZMC, objCustomerData) = False Then
                    GoTo errProc
                End If

                '填充数据
                Dim objListItem As System.Web.UI.WebControls.ListItem = Nothing
                Dim strCode As String = ""
                Dim strName As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                With objCustomerData.Tables(strTable)
                    intCount = .Rows.Count
                    For i = 0 To intCount - 1 Step 1
                        strCode = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_ZUZHIFENZU_FZMC), "")
                        strName = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_ZUZHIFENZU_FZMC), "")

                        objListItem = New System.Web.UI.WebControls.ListItem
                        objListItem.Text = strName
                        objListItem.Value = strName
                        objDropDownList.Items.Add(objListItem)
                    Next
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Data.CustomerData.SafeRelease(objCustomerData)

            doFillSsfzList = True
            Exit Function
errProc:
            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Data.CustomerData.SafeRelease(objCustomerData)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 填充变动原因下拉列表框
        '     strErrMsg      ：返回错误信息
        '     objDropDownList：要填充的列表框
        ' 返回
        '     True           ：成功
        '     False          ：失败
        ' 更改
        '     zengxianglin 2010-01-05 创建
        '----------------------------------------------------------------
        Private Function doFillYdyyList( _
            ByRef strErrMsg As String, _
            ByVal objDropDownList As System.Web.UI.WebControls.DropDownList, _
            Optional ByVal strWhere As String = "") As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_BIANDONGYUANYIN
            Dim objsystemEstateRenshiGeneral As New Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral
            Dim objestateRenshiGeneralData As Josco.JSOA.Common.Data.estateRenshiGeneralData = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            doFillYdyyList = False
            strErrMsg = ""

            Try
                '检查
                If objDropDownList Is Nothing Then
                    strErrMsg = "错误：[doFillYdyyList]接口参数不正确！"
                    GoTo errProc
                End If

                '获取数据
                If objsystemEstateRenshiGeneral.getDataSet_BiandongYuanyin(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWhere, objestateRenshiGeneralData) = False Then
                    GoTo errProc
                End If

                '清空现有列表
                objDropDownList.Items.Clear()

                '填充数据
                Dim objListItem As System.Web.UI.WebControls.ListItem = Nothing
                Dim strCode As String = ""
                Dim strName As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                With objestateRenshiGeneralData.Tables(strTable)
                    intCount = .Rows.Count
                    For i = 0 To intCount - 1 Step 1
                        strCode = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_BIANDONGYUANYIN_YYDM), "")
                        strName = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_BIANDONGYUANYIN_YYMC), "")

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

            Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral.SafeRelease(objsystemEstateRenshiGeneral)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objestateRenshiGeneralData)

            doFillYdyyList = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral.SafeRelease(objsystemEstateRenshiGeneral)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objestateRenshiGeneralData)
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
                    With objControlProcess
                        .doTranslateKey(Me.txtSearch_RY_DWMC)
                        .doTranslateKey(Me.txtSearch_RY_RYDM)
                        .doTranslateKey(Me.txtSearch_RY_BDSJ)
                        .doTranslateKey(Me.txtSearch_RY_RYMC)
                        .doTranslateKey(Me.txtSearch_RY_KSSJMin)
                        .doTranslateKey(Me.txtSearch_RY_KSSJMax)
                        .doTranslateKey(Me.txtSearch_RY_JSSJMin)
                        .doTranslateKey(Me.txtSearch_RY_JSSJMax)
                        '**************************************************
                        .doTranslateKey(Me.txtRYPageIndex)
                        .doTranslateKey(Me.txtRYPageSize)
                        '**************************************************
                        .doTranslateKey(Me.txtKSSJ)
                        .doTranslateKey(Me.txtJSSJ)
                        .doTranslateKey(Me.txtSJLD)
                        .doTranslateKey(Me.txtZZDM)
                        .doTranslateKey(Me.ddlSSFZ)
                        .doTranslateKey(Me.ddlZJDM)
                        '**************************************************
                        'zengxianglin 2010-01-02
                        .doTranslateKey(Me.txtTDBH)
                        'zengxianglin 2010-01-02
                        '**************************************************
                    End With

                    '设初始值
                    If Me.m_blnSaveScence = False Then
                        Me.txtSearch_RY_KSSJMin.Text = Now.Year.ToString + "-01-01"
                        Me.txtSearch_RY_KSSJMax.Text = Now.Year.ToString + "-12-31"
                        If Me.searchModuleData_RY(strErrMsg) = False Then
                            GoTo errProc
                        End If
                    Else
                        If Me.getModuleData_RY(strErrMsg, Me.htxtRYQuery.Value) = False Then
                            GoTo errProc
                        End If
                    End If
                    'zengxianglin 2008-11-06
                    If Me.m_blnSaveScence = True Then
                        If Me.showModuleData_RY(strErrMsg, False) = False Then
                            GoTo errProc
                        End If
                    Else
                        If Me.showModuleData_RY(strErrMsg) = False Then
                            GoTo errProc
                        End If
                    End If
                    'zengxianglin 2008-11-06

                    '显示Main
                    If Me.showModuleData_Main(strErrMsg) = False Then
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
            Dim strErrMsg As String
            Dim strUrl As String

            Try
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

                '填充列表
                If Me.IsPostBack = False Then
                    If Me.doFillZjdmList(strErrMsg, Me.ddlZJDM) = False Then
                        GoTo errProc
                    End If
                    'zengxianglin 2010-01-05
                    If Me.doFillYdyyList(strErrMsg, Me.ddlYDYY, "") = False Then
                        GoTo errProc
                    End If
                    'zengxianglin 2010-01-05
                End If

                '获取接口参数
                If Me.getInterfaceParameters(strErrMsg) = False Then
                    GoTo errProc
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










        '---------------------------------------------------------------------------------------------------------------------------
        '网格事件处理器
        '---------------------------------------------------------------------------------------------------------------------------
        Sub grdRY_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdRY.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '标题行,输出标题锁定一般属性
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_grdRY + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_grdRY > 0 Then
                    '锁定列
                    For i = 0 To Me.m_intFixedColumns_grdRY - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdRY.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Private Sub grdRY_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdRY.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '显示记录位置
                Me.lblRYGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdRY, Me.m_intRows_grdRY)

                '同步显示信息
                If Me.showEditPanel_RY(strErrMsg) = False Then
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

        Private Sub grdRY_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdRY.SortCommand

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_V_RS_RENYUANJIAGOU
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                Dim objenumSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
                Dim objDataGridItem As System.Web.UI.WebControls.DataGridItem
                Dim strFinalCommand As String = ""
                Dim strOldCommand As String = ""
                Dim strUniqueId As String = ""
                Dim intColumnIndex As Integer

                '获取数据
                If Me.getModuleData_RY(strErrMsg, Me.htxtRYQuery.Value) = False Then
                    GoTo errProc
                End If

                '获取原排序命令
                With Me.m_objDataSet_RY.Tables(strTable)
                    strOldCommand = .DefaultView.Sort
                End With

                '获取要执行的排序命令
                objDataGridProcess.getColumnSortCommand(strErrMsg, strOldCommand, e.SortExpression, strFinalCommand, objenumSortType)
                If strErrMsg <> "" Then
                    GoTo errProc
                End If

                '执行排序
                With Me.m_objDataSet_RY.Tables(strTable)
                    .DefaultView.Sort = strFinalCommand
                End With

                '获取排序列的列索引
                objDataGridItem = CType(e.CommandSource, System.Web.UI.WebControls.DataGridItem)
                strUniqueId = Request.Form("__EVENTTARGET")
                intColumnIndex = objDataGridProcess.getColumnIndexByUniqueIdInRow(objDataGridItem, strUniqueId)

                '保存排序信息
                Me.htxtRYSortColumnIndex.Value = intColumnIndex.ToString()
                Me.htxtRYSortType.Value = CType(objenumSortType, Integer).ToString()
                Me.htxtRYSort.Value = strFinalCommand

                '重新显示数据
                If Me.showModuleData_RY(strErrMsg) = False Then
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











        Private Sub doMoveFirst_RY(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_RY(strErrMsg, Me.htxtRYQuery.Value) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(0, Me.grdRY.PageCount)
                Me.grdRY.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_RY(strErrMsg) = False Then
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

        Private Sub doMoveLast_RY(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_RY(strErrMsg, Me.htxtRYQuery.Value) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdRY.PageCount - 1, Me.grdRY.PageCount)
                Me.grdRY.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_RY(strErrMsg) = False Then
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

        Private Sub doMoveNext_RY(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_RY(strErrMsg, Me.htxtRYQuery.Value) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdRY.CurrentPageIndex + 1, Me.grdRY.PageCount)
                Me.grdRY.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_RY(strErrMsg) = False Then
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

        Private Sub doMovePrevious_RY(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_RY(strErrMsg, Me.htxtRYQuery.Value) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdRY.CurrentPageIndex - 1, Me.grdRY.PageCount)
                Me.grdRY.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_RY(strErrMsg) = False Then
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

        Private Sub doGotoPage_RY(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '获取新的页大小
            Dim intPageIndex As Integer
            intPageIndex = objPulicParameters.getObjectValue(Me.txtRYPageIndex.Text, 0)
            If intPageIndex <= 0 Then
                intPageIndex = 0
            Else
                intPageIndex -= 1
            End If

            Try
                '获取数据
                If Me.getModuleData_RY(strErrMsg, Me.htxtRYQuery.Value) = False Then
                    GoTo errProc
                End If

                '设置新的页
                Me.grdRY.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_RY(strErrMsg) = False Then
                    GoTo errProc
                End If

                '信息同步
                Me.txtRYPageIndex.Text = (Me.grdRY.CurrentPageIndex + 1).ToString()
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

        Private Sub doSetPageSize_RY(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '获取新的页大小
            Dim intPageSize As Integer
            intPageSize = objPulicParameters.getObjectValue(Me.txtRYPageSize.Text, 100)
            If intPageSize <= 0 Then intPageSize = 100

            Try
                '获取数据
                If Me.getModuleData_RY(strErrMsg, Me.htxtRYQuery.Value) = False Then
                    GoTo errProc
                End If

                '设置新的页大小
                Me.grdRY.PageSize = intPageSize

                '刷新网格显示
                If Me.showModuleData_RY(strErrMsg) = False Then
                    GoTo errProc
                End If

                '信息同步
                Me.txtRYPageSize.Text = (Me.grdRY.PageSize).ToString()
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

        Private Sub doSelectAll_RY(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdRY, 0, Me.m_cstrCheckBoxIdInDataGrid_grdRY, True) = False Then
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

        Private Sub doDeSelectAll_RY(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdRY, 0, Me.m_cstrCheckBoxIdInDataGrid_grdRY, False) = False Then
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

        Private Sub lnkCZRYMoveFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRYMoveFirst.Click
            Me.doMoveFirst_RY("lnkCZRYMoveFirst")
        End Sub

        Private Sub lnkCZRYMoveLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRYMoveLast.Click
            Me.doMoveLast_RY("lnkCZRYMoveLast")
        End Sub

        Private Sub lnkCZRYMoveNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRYMoveNext.Click
            Me.doMoveNext_RY("lnkCZRYMoveNext")
        End Sub

        Private Sub lnkCZRYMovePrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRYMovePrev.Click
            Me.doMovePrevious_RY("lnkCZRYMovePrev")
        End Sub

        Private Sub lnkCZRYGotoPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRYGotoPage.Click
            Me.doGotoPage_RY("lnkCZRYGotoPage")
        End Sub

        Private Sub lnkCZRYSetPageSize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRYSetPageSize.Click
            Me.doSetPageSize_RY("lnkCZRYSetPageSize")
        End Sub

        Private Sub lnkCZRYSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRYSelectAll.Click
            Me.doSelectAll_RY("lnkCZRYSelectAll")
        End Sub

        Private Sub lnkCZRYDeSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRYDeSelectAll.Click
            Me.doDeSelectAll_RY("lnkCZRYDeSelectAll")
        End Sub











        Private Sub doSelectSJLD(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                'zengxianglin 2008-11-22
                '检查
                If Me.txtKSSJ.Text.Trim = "" Then
                    strErrMsg = "错误：没有指定[生效时间]！"
                    GoTo errProc
                End If
                If objPulicParameters.isDatetimeString(Me.txtKSSJ.Text) = False Then
                    strErrMsg = "错误：无效的[生效时间]！"
                    GoTo errProc
                End If
                'zengxianglin 2008-11-22

                '备份现场参数
                Dim strSessionId As String = ""
                strSessionId = Me.saveModuleInformation()
                If strSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim objIEstateRsRenyuanJiagou_Rela As Josco.JSOA.BusinessFacade.IEstateRsRenyuanJiagou_Rela = Nothing
                Dim strUrl As String = ""
                objIEstateRsRenyuanJiagou_Rela = New Josco.JSOA.BusinessFacade.IEstateRsRenyuanJiagou_Rela
                With objIEstateRsRenyuanJiagou_Rela
                    'zengxianglin 2008-11-22
                    '.iTime = Now.ToString("yyyy-MM-dd")
                    .iTime = Me.txtKSSJ.Text
                    'zengxianglin 2008-11-22
                    .iAllowNull = True
                    .iMode = 1

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
                Session.Add(strNewSessionId, objIEstateRsRenyuanJiagou_Rela)
                strUrl = ""
                strUrl += "estate_rs_renyuanjiagou_rela.aspx"
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

        Private Sub doSelectZZDM(ByVal strControlId As String)

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
                Dim objIDmxzZzjg As Josco.JsKernal.BusinessFacade.IDmxzZzjg = Nothing
                Dim strUrl As String = ""
                objIDmxzZzjg = New Josco.JsKernal.BusinessFacade.IDmxzZzjg
                With objIDmxzZzjg
                    .iAllowInput = False
                    .iMultiSelect = False
                    .iAllowNull = False
                    .iSelectFFFW = False
                    .iBumenList = ""

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
                Session.Add(strNewSessionId, objIDmxzZzjg)
                strUrl = ""
                strUrl += "../../dmxz/dmxz_zzjg.aspx"
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

        'zengxianglin 2008-11-18
        Private Sub doSelectZGDW(ByVal strControlId As String)

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
                Dim objIDmxzZzjg As Josco.JsKernal.BusinessFacade.IDmxzZzjg = Nothing
                Dim strUrl As String = ""
                objIDmxzZzjg = New Josco.JsKernal.BusinessFacade.IDmxzZzjg
                With objIDmxzZzjg
                    .iAllowInput = False
                    .iMultiSelect = False
                    .iAllowNull = True
                    .iSelectFFFW = False
                    .iBumenList = ""

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
                Session.Add(strNewSessionId, objIDmxzZzjg)
                strUrl = ""
                strUrl += "../../dmxz/dmxz_zzjg.aspx"
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
        'zengxianglin 2008-11-18

        Private Sub doJSFZLB(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                If Me.doFillSsfzList(strErrMsg, Me.ddlSSFZ, Me.txtZZDM.Text) = False Then
                    GoTo errProc
                End If
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

        'zengxianglin 2010-01-02
        Private Sub doSelectTDBH(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '检查
                If Me.txtZZDM.Text.Trim = "" Then
                    strErrMsg = "错误：没有指定[新的部门]！"
                    GoTo errProc
                End If
                If Me.txtKSSJ.Text.Trim = "" Then
                    strErrMsg = "错误：没有指定[生效时间]！"
                    GoTo errProc
                End If
                If objPulicParameters.isDatetimeString(Me.txtKSSJ.Text) = False Then
                    strErrMsg = "错误：无效的[生效时间][" + Me.txtKSSJ.Text + "]！"
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
                Dim objIEstateRsXzTeam As Josco.JSOA.BusinessFacade.IEstateRsXzTeam = Nothing
                Dim strUrl As String = ""
                objIEstateRsXzTeam = New Josco.JSOA.BusinessFacade.IEstateRsXzTeam
                With objIEstateRsXzTeam
                    .iMultiSelect = False
                    .iAllowNull = True
                    .iJCSJ = Me.txtKSSJ.Text
                    .iFixQuery = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_SSDW + " = '" + Me.htxtZZDM.Value + "'"

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
                Session.Add(strNewSessionId, objIEstateRsXzTeam)
                strUrl = ""
                strUrl += "estate_rs_xz_team.aspx"
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
        'zengxianglin 2010-01-02

        'zengxianglin 2010-01-02
        Private Sub doSelectZGTD(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '检查
                If Me.txtKSSJ.Text.Trim = "" Then
                    strErrMsg = "错误：没有指定[生效时间]！"
                    GoTo errProc
                End If
                If objPulicParameters.isDatetimeString(Me.txtKSSJ.Text) = False Then
                    strErrMsg = "错误：无效的[生效时间][" + Me.txtKSSJ.Text + "]！"
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
                Dim objIEstateRsXzTeam As Josco.JSOA.BusinessFacade.IEstateRsXzTeam = Nothing
                Dim strUrl As String = ""
                objIEstateRsXzTeam = New Josco.JSOA.BusinessFacade.IEstateRsXzTeam
                With objIEstateRsXzTeam
                    .iMultiSelect = True
                    .iAllowNull = True
                    .iJCSJ = Me.txtKSSJ.Text
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
                Dim strNewSessionId As String = ""
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIEstateRsXzTeam)
                strUrl = ""
                strUrl += "estate_rs_xz_team.aspx"
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
        'zengxianglin 2010-01-02

        'zengxianglin 2010-01-02
        Private Sub doSelectXGTD(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '检查
                If Me.txtKSSJ.Text.Trim = "" Then
                    strErrMsg = "错误：没有指定[生效时间]！"
                    GoTo errProc
                End If
                If objPulicParameters.isDatetimeString(Me.txtKSSJ.Text) = False Then
                    strErrMsg = "错误：无效的[生效时间][" + Me.txtKSSJ.Text + "]！"
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
                Dim objIEstateRsXzTeam As Josco.JSOA.BusinessFacade.IEstateRsXzTeam = Nothing
                Dim strUrl As String = ""
                objIEstateRsXzTeam = New Josco.JSOA.BusinessFacade.IEstateRsXzTeam
                With objIEstateRsXzTeam
                    .iMultiSelect = True
                    .iAllowNull = True
                    .iJCSJ = Me.txtKSSJ.Text
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
                Dim strNewSessionId As String = ""
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIEstateRsXzTeam)
                strUrl = ""
                strUrl += "estate_rs_xz_team.aspx"
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
        'zengxianglin 2010-01-02

        'zengxianglin 2010-03-08
        Private Sub doAddnewZGTD(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '检查
                If Me.txtKSSJ.Text.Trim = "" Then
                    strErrMsg = "错误：没有指定[生效时间]！"
                    GoTo errProc
                End If
                If objPulicParameters.isDatetimeString(Me.txtKSSJ.Text) = False Then
                    strErrMsg = "错误：无效的[生效时间][" + Me.txtKSSJ.Text + "]！"
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
                Dim objIEstateRsXzTeam As Josco.JSOA.BusinessFacade.IEstateRsXzTeam = Nothing
                Dim strUrl As String = ""
                objIEstateRsXzTeam = New Josco.JSOA.BusinessFacade.IEstateRsXzTeam
                With objIEstateRsXzTeam
                    .iMultiSelect = True
                    .iAllowNull = False
                    .iJCSJ = Me.txtKSSJ.Text
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
                Dim strNewSessionId As String = ""
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIEstateRsXzTeam)
                strUrl = ""
                strUrl += "estate_rs_xz_team.aspx"
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
        'zengxianglin 2010-03-08

        'zengxianglin 2010-03-18
        Private Sub doAddnewXGTD(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '检查
                If Me.txtKSSJ.Text.Trim = "" Then
                    strErrMsg = "错误：没有指定[生效时间]！"
                    GoTo errProc
                End If
                If objPulicParameters.isDatetimeString(Me.txtKSSJ.Text) = False Then
                    strErrMsg = "错误：无效的[生效时间][" + Me.txtKSSJ.Text + "]！"
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
                Dim objIEstateRsXzTeam As Josco.JSOA.BusinessFacade.IEstateRsXzTeam = Nothing
                Dim strUrl As String = ""
                objIEstateRsXzTeam = New Josco.JSOA.BusinessFacade.IEstateRsXzTeam
                With objIEstateRsXzTeam
                    .iMultiSelect = True
                    .iAllowNull = False
                    .iJCSJ = Me.txtKSSJ.Text
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
                Dim strNewSessionId As String = ""
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIEstateRsXzTeam)
                strUrl = ""
                strUrl += "estate_rs_xz_team.aspx"
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
        'zengxianglin 2010-03-18

        'zengxianglin 2010-03-08
        Private Sub doDeleteZGTD(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '检查选择
                Dim i, intCount, intSelected As Integer
                intCount = Me.lstZGTD.Items.Count
                intSelected = 0
                For i = 0 To intCount - 1 Step 1
                    If Me.lstZGTD.Items(i).Selected = True Then
                        intSelected += 1
                    End If
                Next
                If intSelected < 1 Then
                    strErrMsg = "错误：没有选定任何团队！"
                    GoTo errProc
                End If

                '移除操作
                Dim strZBBS As String = ""
                If Me.getModuleData_TDZH(strErrMsg) = False Then
                    GoTo errProc
                End If
                If Me.doDelInBuffer_TDZH(strErrMsg, Me.lstZGTD, Me.htxtZGTD.Value, Me.m_objDataSet_TDZH, strZBBS) = False Then
                    GoTo errProc
                End If
                If Me.htxtZGTD.Value.Trim <> "" Then
                    If Me.doDeleteBuffer_TDZH(strErrMsg, Me.htxtZGTD.Value, Me.m_objDataSet_TDZH) = False Then
                        GoTo errProc
                    End If
                End If
                If strZBBS <> "" Then
                    Me.htxtZGTD.Value = strZBBS
                End If
                If Me.doDisplayBuffer_TDZH(strErrMsg, strZBBS, Me.m_objDataSet_TDZH, Me.lstZGTD) = False Then
                    GoTo errProc
                End If
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
        'zengxianglin 2010-03-08

        'zengxianglin 2010-03-08
        Private Sub doDeleteXGTD(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '检查选择
                Dim i, intCount, intSelected As Integer
                intCount = Me.lstXGTD.Items.Count
                intSelected = 0
                For i = 0 To intCount - 1 Step 1
                    If Me.lstXGTD.Items(i).Selected = True Then
                        intSelected += 1
                    End If
                Next
                If intSelected < 1 Then
                    strErrMsg = "错误：没有选定任何团队！"
                    GoTo errProc
                End If

                '移除操作
                Dim strZBBS As String = ""
                If Me.getModuleData_TDZH(strErrMsg) = False Then
                    GoTo errProc
                End If
                If Me.doDelInBuffer_TDZH(strErrMsg, Me.lstXGTD, Me.htxtXGTD.Value, Me.m_objDataSet_TDZH, strZBBS) = False Then
                    GoTo errProc
                End If
                If Me.htxtXGTD.Value.Trim <> "" Then
                    If Me.doDeleteBuffer_TDZH(strErrMsg, Me.htxtXGTD.Value, Me.m_objDataSet_TDZH) = False Then
                        GoTo errProc
                    End If
                End If
                If strZBBS <> "" Then
                    Me.htxtXGTD.Value = strZBBS
                End If
                If Me.doDisplayBuffer_TDZH(strErrMsg, strZBBS, Me.m_objDataSet_TDZH, Me.lstXGTD) = False Then
                    GoTo errProc
                End If
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
        'zengxianglin 2010-03-08

        Private Sub btnSelectSJLD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelectSJLD.Click
            Me.doSelectSJLD("btnSelectSJLD")
        End Sub

        Private Sub btnSelectZZDM_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelectZZDM.Click
            Me.doSelectZZDM("btnSelectZZDM")
        End Sub

        'zengxianglin 2008-11-18
        Private Sub btnSelectZGDW_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelectZGDW.Click
            Me.doSelectZGDW("btnSelectZGDW")
        End Sub
        'zengxianglin 2008-11-18

        Private Sub btnJSFZLB_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnJSFZLB.Click
            Me.doJSFZLB("btnJSFZLB")
        End Sub

        'zengxianglin 2010-01-02
        Private Sub btnSelectTDBH_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelectTDBH.Click
            Me.doSelectTDBH("btnSelectTDBH")
        End Sub
        'zengxianglin 2010-01-02

        'zengxianglin 2010-01-02
        Private Sub btnSelectZGTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelectZGTD.Click
            Me.doSelectZGTD("btnSelectZGTD")
        End Sub
        'zengxianglin 2010-01-02

        'zengxianglin 2010-01-02
        Private Sub btnSelectXGTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelectXGTD.Click
            Me.doSelectXGTD("btnSelectXGTD")
        End Sub
        'zengxianglin 2010-01-02

        'zengxianglin 2010-03-18
        Private Sub btnAddnewZGTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddnewZGTD.Click
            Me.doAddnewZGTD("btnAddnewZGTD")
        End Sub
        'zengxianglin 2010-03-18

        'zengxianglin 2010-03-18
        Private Sub btnAddnewXGTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddnewXGTD.Click
            Me.doAddnewXGTD("btnAddnewXGTD")
        End Sub
        'zengxianglin 2010-03-18

        'zengxianglin 2010-03-18
        Private Sub btnDeleteZGTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeleteZGTD.Click
            Me.doDeleteZGTD("btnDeleteZGTD")
        End Sub
        'zengxianglin 2010-03-18

        'zengxianglin 2010-03-18
        Private Sub btnDeleteXGTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeleteXGTD.Click
            Me.doDeleteXGTD("btnDeleteXGTD")
        End Sub
        'zengxianglin 2010-03-18










        Private Sub doSearch_RY(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If Me.searchModuleData_RY(strErrMsg) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_RY(strErrMsg) = False Then
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

        Private Sub doSearchFull_RY(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_V_RS_RENYUANJIAGOU
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '获取数据
                If Me.getModuleData_RY(strErrMsg, Me.htxtRYQuery.Value) = False Then
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
                Dim objISjcxCxtj As Josco.JsKernal.BusinessFacade.ISjcxCxtj = Nothing
                Dim strUrl As String = ""
                objISjcxCxtj = New Josco.JsKernal.BusinessFacade.ISjcxCxtj
                With objISjcxCxtj
                    .iQueryTable = Me.m_objDataSet_RY.Tables(strTable)
                    Try
                        If Me.htxtRYSessionIdQuery.Value.Trim <> "" Then
                            .iDataSetTJ = CType(Session(Me.htxtRYSessionIdQuery.Value), Josco.JsKernal.Common.Data.QueryData)
                        Else
                            .iDataSetTJ = Nothing
                        End If
                    Catch ex As Exception
                        .iDataSetTJ = Nothing
                    End Try
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
                Dim strNewSessionId As String = ""
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

        Private Sub btnSearch_RY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch_RY.Click
            Me.doSearch_RY("btnSearch_RY")
        End Sub

        Private Sub btnSearchFull_RY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchFull_RY.Click
            Me.doSearchFull_RY("btnSearchFull_RY")
        End Sub















        Private Sub doClose(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                Dim strSessionId As String = ""
                Dim strUrl As String = ""
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

        Private Sub doModify(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_V_RS_RENYUANJIAGOU
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objNewDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim intStep As Integer

            Try
                Dim intIndex As Integer = Me.grdRY.SelectedIndex
                Dim intColIndex As Integer
                Dim strWYBS As String = ""
                Dim strRYMC As String = ""
                Dim intRYLX As Integer

                intStep = 1
                '检查
                '======================================================================================================================================================
                If Me.grdRY.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有要更改的信息！"
                    GoTo errProc
                End If
                '======================================================================================================================================================
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYLX)
                intRYLX = objPulicParameters.getObjectValue(objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(intIndex), intColIndex), 0)
                '======================================================================================================================================================
                If Me.ddlZJDM.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有指定[职级]！"
                    GoTo errProc
                End If
                '======================================================================================================================================================
                If Me.rblRYZT.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有指定[正式职工]或[试用人员]！"
                    GoTo errProc
                End If
                '======================================================================================================================================================
                If Me.rblSFZB.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有指定[编内人员]或[编外人员]！"
                    GoTo errProc
                End If
                '======================================================================================================================================================
                If Me.htxtZZDM.Value.Trim = "" Then
                    strErrMsg = "错误：没有指定[所属单位]！"
                    GoTo errProc
                End If
                '======================================================================================================================================================
                If Me.txtKSSJ.Text.Trim = "" Then
                    strErrMsg = "错误：没有指定[生效时间]！"
                    GoTo errProc
                End If
                If objPulicParameters.isDatetimeString(Me.txtKSSJ.Text) = False Then
                    strErrMsg = "错误：[" + Me.txtKSSJ.Text + "]是无效的时间！"
                    GoTo errProc
                End If
                Me.txtKSSJ.Text = CType(Me.txtKSSJ.Text, System.DateTime).ToString("yyyy-MM-dd HH:mm:ss")
                If Me.txtJSSJ.Text.Trim <> "" Then
                    If objPulicParameters.isDatetimeString(Me.txtJSSJ.Text) = False Then
                        strErrMsg = "错误：[" + Me.txtJSSJ.Text + "]是无效的时间！"
                        GoTo errProc
                    End If
                    Me.txtJSSJ.Text = CType(Me.txtJSSJ.Text, System.DateTime).ToString("yyyy-MM-dd HH:mm:ss")
                    If CType(Me.txtKSSJ.Text, System.DateTime) >= CType(Me.txtJSSJ.Text, System.DateTime) Then
                        strErrMsg = "错误：[失效时间]必须大于[生效时间]！"
                        GoTo errProc
                    End If
                End If
                '======================================================================================================================================================
                'zengxianglin 2010-01-05
                If Me.ddlYDYY.SelectedIndex < 0 Then
                    strErrMsg = "错误：必须指定[变动原因]！"
                    GoTo errProc
                End If
                'zengxianglin 2010-01-05
                '======================================================================================================================================================
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_WYBS)
                strWYBS = objPulicParameters.getObjectValue(objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(intIndex), intColIndex), "")
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYMC)
                strRYMC = objPulicParameters.getObjectValue(objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(intIndex), intColIndex), "")
                '======================================================================================================================================================

                'zengxianglin 2010-01-02
                '检查日期与标准是否匹配？
                Dim strKSSJ_Old As String = ""
                Dim intBZXL(3) As Integer
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_KSSJ)
                strKSSJ_Old = objPulicParameters.getObjectValue(objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(intIndex), intColIndex), "")
                If objsystemEstateRenshiXingye.getBZXL_RSJG(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.txtKSSJ.Text, intBZXL(0)) = False Then
                    GoTo errProc
                End If
                If objsystemEstateRenshiXingye.getBZXL_RSJG(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.txtJSSJ.Text, intBZXL(1)) = False Then
                    GoTo errProc
                End If
                If objsystemEstateRenshiXingye.getBZXL_RSJG(strErrMsg, MyBase.UserId, MyBase.UserPassword, strKSSJ_Old, intBZXL(2)) = False Then
                    GoTo errProc
                End If
                If intBZXL(0) <> intBZXL(1) Or intBZXL(0) <> intBZXL(2) Or intBZXL(1) <> intBZXL(2) Then
                    strErrMsg = "错误：[生效时间]、[失效时间]与当时管理模式执行时间不匹配！"
                    GoTo errProc
                End If
                Select Case intBZXL(0)
                    Case 1 '管理模式一
                    Case 2 '管理模式二
                    Case Else
                        strErrMsg = "错误：不支持的管理模式！"
                        GoTo errProc
                End Select
                'zengxianglin 2010-01-02

                intStep = 2
                '确认
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "警告：您确信输入的数据是正确吗（确定/取消）？", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                intStep = 3
                '处理
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '获取数据集
                    If Me.getModuleData_RY(strErrMsg, Me.htxtRYQuery.Value) = False Then
                        GoTo errProc
                    End If
                    'zengxianglin 2010-01-02
                    If Me.getModuleData_TDZH(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    'zengxianglin 2010-01-02

                    '获取当前记录行
                    Dim objOldData As System.Data.DataRow = Nothing
                    Dim intRecPos As Integer
                    With Me.grdRY
                        intRecPos = objDataGridProcess.getRecordPosition(.SelectedIndex, .CurrentPageIndex, .PageSize)
                    End With
                    With Me.m_objDataSet_RY.Tables(strTable)
                        objOldData = .DefaultView.Item(intRecPos).Row
                    End With

                    '获取要提交的行数据
                    Dim objNewData As System.Data.DataRow = Nothing
                    Dim intCols As Integer
                    Dim i As Integer
                    objNewDataSet = New Josco.JSOA.Common.Data.estateRenshiXingyeData(Josco.JSOA.Common.Data.estateRenshiXingyeData.enumTableType.DC_V_RS_RENYUANJIAGOU)
                    With objNewDataSet.Tables(strTable)
                        objNewData = .NewRow()
                        '****************************************************************************
                        intCols = .Columns.Count
                        For i = 0 To intCols - 1 Step 1
                            objNewData.Item(i) = objOldData.Item(i)
                        Next
                        '****************************************************************************
                        objNewData.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_KSSJ) = CType(Me.txtKSSJ.Text, System.DateTime)
                        If Me.txtJSSJ.Text.Trim = "" Then
                            objNewData.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_JSSJ) = System.DBNull.Value
                        Else
                            objNewData.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_JSSJ) = CType(Me.txtJSSJ.Text, System.DateTime)
                        End If
                        objNewData.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SSDW) = Me.htxtZZDM.Value
                        objNewData.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SSDWMC) = Me.txtZZDM.Text
                        If Me.ddlZJDM.SelectedIndex < 0 Then
                            objNewData.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZJDM) = ""
                            objNewData.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZJMC) = ""
                        Else
                            objNewData.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZJDM) = Me.ddlZJDM.SelectedItem.Value
                            objNewData.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZJMC) = Me.ddlZJDM.SelectedItem.Text.Split("|".ToCharArray)(1)
                        End If
                        If Me.rblRYZT.SelectedIndex < 0 Then
                            objNewData.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYZT) = 2
                            objNewData.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYZTMC) = "正式"
                        Else
                            objNewData.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYZT) = CType(Me.rblRYZT.SelectedItem.Value, Integer)
                            objNewData.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYZTMC) = Me.rblRYZT.SelectedItem.Text
                        End If
                        If Me.rblSFZB.SelectedIndex < 0 Then
                            objNewData.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SFZB) = 1
                        Else
                            objNewData.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SFZB) = CType(Me.rblSFZB.SelectedItem.Value, Integer)
                        End If
                        '****************************************************************************
                        objNewData.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SJLD) = Me.htxtSJLD.Value
                        'zengxianglin 2008-11-18
                        objNewData.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZGDW) = Me.htxtZGDW.Value
                        'zengxianglin 2008-11-18
                        If Me.ddlSSFZ.SelectedIndex < 0 Then
                            objNewData.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SSFZ) = ""
                        Else
                            objNewData.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SSFZ) = Me.ddlSSFZ.SelectedItem.Text
                        End If
                        '****************************************************************************
                        'zengxianglin 2010-01-02
                        objNewData.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_BZXL) = Me.htxtBZXL.Value
                        objNewData.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZGTD) = Me.htxtZGTD.Value
                        objNewData.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_XGTD) = Me.htxtXGTD.Value
                        objNewData.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_TDBH) = Me.txtTDBH.Text
                        objNewData.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_YDYY) = Me.ddlYDYY.SelectedItem.Value
                        If Me.chkSFJZ.Enabled = False Then
                            objNewData.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SFJZ) = "0"
                        ElseIf Me.chkSFJZ.Checked = True Then
                            objNewData.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SFJZ) = "1"
                        Else
                            objNewData.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SFJZ) = "0"
                        End If
                        'zengxianglin 2010-01-02
                        '****************************************************************************
                        .Rows.Add(objNewData)
                    End With
                    objNewData = objNewDataSet.Tables(strTable).Rows(0)

                    '保存信息
                    'zengxianglin 2010-01-02
                    'If objsystemEstateRenshiXingye.doSaveData_RYJG(strErrMsg, MyBase.UserId, MyBase.UserPassword, objNewData, objOldData, Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate) = False Then
                    '    GoTo errProc
                    'End If
                    If objsystemEstateRenshiXingye.doSaveData_RYJG(strErrMsg, MyBase.UserId, MyBase.UserPassword, objNewData, objOldData, Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate, Me.m_objDataSet_TDZH) = False Then
                        GoTo errProc
                    End If
                    'zengxianglin 2010-01-02

                    'zengxianglin 2010-01-02
                    '清除缓存
                    With Me.m_objDataSet_TDZH.Tables(Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_TDZH)
                        .Rows.Clear()
                    End With
                    'zengxianglin 2010-01-02

                    '记录审计日志
                    Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]更改了[" + strRYMC + "]的[人员架构]数据，对应的[唯一标识]=" + strWYBS + "！")

                    '重新显示信息
                    If Me.getModuleData_RY(strErrMsg, Me.htxtRYQuery.Value) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_RY(strErrMsg) = False Then
                        GoTo errProc
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objNewDataSet)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objNewDataSet)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doDelete(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_V_RS_RENYUANJIAGOU
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim intStep As Integer

            Try
                Dim intSelect As Integer = 0
                Dim intRows As Integer
                Dim i As Integer

                intStep = 1
                '检查选择
                intRows = Me.grdRY.Items.Count
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    For i = 0 To intRows - 1 Step 1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdRY.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_grdRY) = True Then
                            intSelect += 1
                        End If
                    Next
                    If intSelect < 1 Then
                        strErrMsg = "错误：未选择要删除的内容！"
                        GoTo errProc
                    End If
                End If

                '询问
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "提示：您确实准备删除选定的[" + intSelect.ToString() + "]条内容吗（是/否）？", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '提示后回答“是”接着处理
                intStep = 3
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '获取数据
                    If Me.getModuleData_RY(strErrMsg, Me.htxtRYQuery.Value) = False Then
                        GoTo errProc
                    End If

                    '逐个删除
                    Dim objOldData As System.Data.DataRow = Nothing
                    Dim intColIndex(2) As Integer
                    Dim strWYBS As String = ""
                    Dim strRYMC As String = ""
                    Dim intPos As Integer
                    intColIndex(0) = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_WYBS)
                    intColIndex(1) = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYMC)
                    For i = intRows - 1 To 0 Step -1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdRY.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_grdRY) = True Then
                            strWYBS = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(i), intColIndex(0))
                            strRYMC = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(i), intColIndex(1))

                            '获取要删除的数据行
                            With Me.grdRY
                                intPos = objDataGridProcess.getRecordPosition(i, .CurrentPageIndex, .PageSize)
                            End With
                            objOldData = Nothing
                            With Me.m_objDataSet_RY.Tables(strTable)
                                objOldData = .DefaultView.Item(intPos).Row
                            End With

                            '删除处理
                            If objsystemEstateRenshiXingye.doDeleteData_RYJG(strErrMsg, MyBase.UserId, MyBase.UserPassword, objOldData) = False Then
                                GoTo errProc
                            End If

                            '记录审计日志
                            Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]删除了[" + strRYMC + "]的[人员架构]数据，对应的[唯一标识]=" + strWYBS + "！")
                        End If
                    Next

                    '重新显示数据
                    If Me.getModuleData_RY(strErrMsg, Me.htxtRYQuery.Value) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_RY(strErrMsg) = False Then
                        GoTo errProc
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
            Me.doClose("btnClose")
        End Sub

        Private Sub btnMidify_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMidify.Click
            Me.doModify("btnMidify")
        End Sub

        Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
            Me.doDelete("btnDelete")
        End Sub

    End Class

End Namespace
