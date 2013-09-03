Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.web
    ' 类名    ：estate_rs_renyuanjiagou_rela
    ' 
    ' 调用性质：
    '     独立运行
    '
    ' 功能描述： 
    '   　“人员管理关系”显示处理模块
    '----------------------------------------------------------------

    Partial Class estate_rs_renyuanjiagou_rela
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

        '----------------------------------------------------------------
        '模块授权参数
        '----------------------------------------------------------------
        Private m_cstrPrevilegeParamPrefix As String = "estate_rs_renyuanjiagou_previlege_param"
        Private m_blnPrevilegeParams(4) As Boolean

        '----------------------------------------------------------------
        '模块现场保留参数，恢复完成后立即释放session资源
        '----------------------------------------------------------------
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMEstateRsRenyuanJiagou_Rela
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        '模块接口参数
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IEstateRsRenyuanJiagou_Rela
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '模块接口参数
        '----------------------------------------------------------------
        Private m_objDataSet_Main As Josco.JSOA.Common.Data.estateRenshiXingyeData

        '----------------------------------------------------------------
        '接口参数
        '----------------------------------------------------------------
        Private m_strSelectedNodeIndex As String
        Private m_intMode As Integer
        Private m_strTime As String
        'zengxianglin 2008-10-14
        Private m_blnAllowNull As Boolean
        'zengxianglin 2008-10-14










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
                        Me.m_objInterface = CType(Session(strSessionId), Josco.JSOA.BusinessFacade.IEstateRsRenyuanJiagou_Rela)
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
                If (Me.m_blnPrevilegeParams(0) = True) And (Me.m_blnPrevilegeParams(4) = True) Then
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
                    Me.htxtDivLeftMain.Value = .htxtDivLeftMain
                    Me.htxtDivTopMain.Value = .htxtDivTopMain

                    Try
                        ''zengxianglin 2008-11-18
                        'Dim objNode As Microsoft.Web.UI.WebControls.TreeNode = Nothing
                        'Dim strArray() As String = {}
                        'Dim strIndex As String = ""
                        'Dim i As Integer
                        'strArray = .tvwMain_SelectedNodeIndex.Split(Josco.JsKernal.web.TreeviewProcess.CharTreeNodeIndexFGF.ToCharArray)
                        'For i = 0 To strArray.Length - 1 Step 1
                        '    If strIndex <> "" Then
                        '        strIndex = strIndex + Josco.JsKernal.web.TreeviewProcess.CharTreeNodeIndexFGF + strArray(i)
                        '    Else
                        '        strIndex = strArray(i)
                        '    End If
                        '    objNode = Me.tvwMain.GetNodeFromIndex(strIndex)
                        '    If Not (objNode Is Nothing) Then
                        '        If objNode.Nodes.Count > 0 Then
                        '            objNode.Expanded = True
                        '        End If
                        '    End If
                        'Next
                        ''zengxianglin 2008-11-18
                        Me.m_strSelectedNodeIndex = .tvwMain_SelectedNodeIndex
                    Catch ex As Exception
                    End Try

                    'zengxianglin 2008-11-18
                    Me.txtRYMC.Text = .txtRYMC
                    'zengxianglin 2008-11-18
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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMEstateRsRenyuanJiagou_Rela

                '保存现场信息
                With Me.m_objSaveScence
                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftMain = Me.htxtDivLeftMain.Value
                    .htxtDivTopMain = Me.htxtDivTopMain.Value

                    .tvwMain_SelectedNodeIndex = Me.tvwMain.SelectedNodeIndex

                    'zengxianglin 2008-11-18
                    .txtRYMC = Me.txtRYMC.Text
                    'zengxianglin 2008-11-18
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

            getDataFromCallModule = False

            Try
                If Me.IsPostBack = True Then
                    Exit Try
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            getDataFromCallModule = True
            Exit Function
errProc:
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
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IEstateRsRenyuanJiagou_Rela)
                Catch ex As Exception
                    m_objInterface = Nothing
                End Try
                If m_objInterface Is Nothing Then
                    Me.m_blnInterface = False
                    '没有有接口参数
                    Me.m_intMode = 0
                    Me.m_strTime = Now.ToString("yyyy-MM-dd")
                    'zengxianglin 2008-10-14
                    Me.m_blnAllowNull = False
                    'zengxianglin 2008-10-14
                Else
                    Me.m_blnInterface = True
                    '有接口参数
                    Me.m_intMode = Me.m_objInterface.iMode
                    Me.m_strTime = Me.m_objInterface.iTime
                    'zengxianglin 2008-10-14
                    Me.m_blnAllowNull = Me.m_objInterface.iAllowNull
                    'zengxianglin 2008-10-14
                End If
                If objPulicParameters.isDatetimeString(Me.m_strTime) = False Then
                    strErrMsg = "错误：[检测时间]接口参数是无效的日期！"
                    GoTo errProc
                End If

                '获取恢复现场参数
                If Me.IsPostBack = False Then
                    Dim strSessionId As String
                    strSessionId = objPulicParameters.getObjectValue(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId), "")
                    Try
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMEstateRsRenyuanJiagou_Rela)
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

            Try
            Catch ex As Exception
            End Try

            Exit Sub

        End Sub











        '----------------------------------------------------------------
        ' 获取tvwMain要显示的数据信息
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_MAIN(ByRef strErrMsg As String) As Boolean

            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye

            getModuleData_MAIN = False

            Try
                '释放资源
                Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(Me.m_objDataSet_Main)

                '重新检索数据
                Dim objTime As System.DateTime = CType(Me.m_strTime, System.DateTime)
                If objsystemEstateRenshiXingye.getDataSet_GuanliJiagou(strErrMsg, MyBase.UserId, MyBase.UserPassword, objTime, "", Me.m_objDataSet_Main) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)

            getModuleData_MAIN = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示指定节点的下级节点数据
        '     strErrMsg      ：返回错误信息
        '     objParentNode  ：父节点
        '     objDataTable   ：本级节点要显示的数据
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showTreeViewInfo_MAIN_Child( _
            ByRef strErrMsg As String, _
            ByVal objParentNode As Microsoft.Web.UI.WebControls.TreeNode, _
            ByVal objDataTable As System.Data.DataTable) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objTreeNode As Microsoft.Web.UI.WebControls.TreeNode = Nothing
            Dim objDataTableChild As System.Data.DataTable = Nothing

            showTreeViewInfo_MAIN_Child = False

            Try
                Dim strRYDM As String = ""
                Dim strRYMC As String = ""
                Dim strZJMC As String = ""
                Dim strDWMC As String = ""
                Dim strWYBS As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                With objDataTable
                    '逐个显示
                    intCount = .DefaultView.Count
                    For i = 0 To intCount - 1 Step 1
                        '获取数据
                        strRYDM = objPulicParameters.getObjectValue(.DefaultView.Item(i).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_RYDM), "")
                        strRYMC = objPulicParameters.getObjectValue(.DefaultView.Item(i).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_RYMC), "")
                        strZJMC = objPulicParameters.getObjectValue(.DefaultView.Item(i).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_ZJMC), "")
                        strDWMC = objPulicParameters.getObjectValue(.DefaultView.Item(i).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_SSDWMC), "")
                        strWYBS = objPulicParameters.getObjectValue(.DefaultView.Item(i).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_WYBS), "")
                        '设置信息
                        objTreeNode = New Microsoft.Web.UI.WebControls.TreeNode
                        objTreeNode.Expandable = Microsoft.Web.UI.WebControls.ExpandableValue.Auto
                        objTreeNode.Expanded = True
                        objTreeNode.Text = strRYMC + " | " + strZJMC + " | " + strDWMC
                        '加节点
                        objParentNode.Nodes.Add(objTreeNode)
                        '设置ID
                        objTreeNode.ID = objTreeNode.GetNodeIndex + Josco.JsKernal.web.TreeviewProcess.CharTreeNodeIdFGF + strWYBS + Josco.JsKernal.web.TreeviewProcess.CharTreeNodeIdFGF + strRYDM
                        '显示下级
                        objDataTableChild = .Copy()
                        objDataTableChild.DefaultView.RowFilter = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_SJLD + " = '" + strRYDM + "'"
                        If Me.showTreeViewInfo_MAIN_Child(strErrMsg, objTreeNode, objDataTableChild) = False Then
                            GoTo errProc
                        End If
                        Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataTableChild)
                    Next
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataTableChild)

            showTreeViewInfo_MAIN_Child = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataTableChild)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示tvwMain的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showTreeViewInfo_MAIN(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_GUANLIJIAGOU
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objTreeNode As Microsoft.Web.UI.WebControls.TreeNode = Nothing
            Dim objDataTable As System.Data.DataTable = Nothing

            showTreeViewInfo_MAIN = False

            Try
                Dim strRYDM As String = ""
                Dim strRYMC As String = ""
                Dim strZJMC As String = ""
                Dim strDWMC As String = ""
                Dim strWYBS As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                With Me.m_objDataSet_Main.Tables(strTable)
                    '获取顶级人员
                    .DefaultView.RowFilter = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_SJLD + " = ''"
                    '逐个显示
                    intCount = .DefaultView.Count
                    For i = 0 To intCount - 1 Step 1
                        '获取数据
                        strRYDM = objPulicParameters.getObjectValue(.DefaultView.Item(i).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_RYDM), "")
                        strRYMC = objPulicParameters.getObjectValue(.DefaultView.Item(i).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_RYMC), "")
                        strZJMC = objPulicParameters.getObjectValue(.DefaultView.Item(i).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_ZJMC), "")
                        strDWMC = objPulicParameters.getObjectValue(.DefaultView.Item(i).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_SSDWMC), "")
                        strWYBS = objPulicParameters.getObjectValue(.DefaultView.Item(i).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_WYBS), "")
                        '设置信息
                        objTreeNode = New Microsoft.Web.UI.WebControls.TreeNode
                        objTreeNode.Expandable = Microsoft.Web.UI.WebControls.ExpandableValue.Auto
                        objTreeNode.Expanded = True
                        objTreeNode.Text = strRYMC + " | " + strZJMC + " | " + strDWMC
                        '加节点
                        Me.tvwMain.Nodes.Add(objTreeNode)
                        '设置ID
                        objTreeNode.ID = objTreeNode.GetNodeIndex + Josco.JsKernal.web.TreeviewProcess.CharTreeNodeIdFGF + strWYBS + Josco.JsKernal.web.TreeviewProcess.CharTreeNodeIdFGF + strRYDM
                        '显示下级
                        objDataTable = .Copy()
                        objDataTable.DefaultView.RowFilter = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_SJLD + " = '" + strRYDM + "'"
                        If Me.showTreeViewInfo_MAIN_Child(strErrMsg, objTreeNode, objDataTable) = False Then
                            GoTo errProc
                        End If
                        Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataTable)
                    Next
                End With

                ''zengxianglin 2008-11-18
                'intCount = Me.tvwMain.Nodes.Count
                'For i = 0 To intCount - 1 Step 1
                '    Me.tvwMain.Nodes(i).Expanded = False
                'Next
                ''zengxianglin 2008-11-18
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataTable)

            showTreeViewInfo_MAIN = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataTable)
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
                Me.btnClose.Visible = True
                Select Case Me.m_intMode
                    Case 1
                        Me.btnOK.Visible = True
                        'zengxianglin 2008-10-14
                        Me.btnNull.Visible = Me.m_blnAllowNull
                        'zengxianglin 2008-10-14
                    Case Else
                        Me.btnOK.Visible = False
                        'zengxianglin 2008-10-14
                        Me.btnNull.Visible = False
                        'zengxianglin 2008-10-14
                End Select
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

                    'zengxianglin 2008-11-18
                    With objControlProcess
                        .doTranslateKey(Me.txtRYMC)
                    End With
                    'zengxianglin 2008-11-18

                    '设初始值
                    Me.lblJCSJ.Text = Me.m_strTime

                    '显示Main
                    If Me.showModuleData_Main(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '显示tvwMain
                    If Me.getModuleData_MAIN(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    If Me.showTreeViewInfo_MAIN(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    If Me.m_blnSaveScence = True Then
                        Me.tvwMain.SelectedNodeIndex = Me.m_strSelectedNodeIndex
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









        Private Sub doOK(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '检查
                If Me.tvwMain.SelectedNodeIndex = "" Then
                    strErrMsg = "错误：没有选择人员！"
                    GoTo errProc
                End If

                '返回处理
                Dim strSessionId As String = ""
                Dim strUrl As String = ""
                If Me.m_blnInterface = True Then
                    '设置返回参数
                    Dim strArray() As String
                    With Me.m_objInterface
                        .oExitMode = True
                        strArray = Me.tvwMain.GetNodeFromIndex(Me.tvwMain.SelectedNodeIndex).ID.Split(Josco.JsKernal.web.TreeviewProcess.CharTreeNodeIdFGF.ToCharArray)
                        .oWYBS = strArray(1)
                        .oRYDM = strArray(2)
                        strArray = Me.tvwMain.GetNodeFromIndex(Me.tvwMain.SelectedNodeIndex).Text.Split("|".ToCharArray)
                        .oRYZM = strArray(0)
                    End With
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

        'zengxianglin 2008-10-14
        Private Sub doNull(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '返回处理
                Dim strSessionId As String = ""
                Dim strUrl As String = ""
                If Me.m_blnInterface = True Then
                    '设置返回参数
                    Dim strArray() As String
                    With Me.m_objInterface
                        .oExitMode = True
                        .oWYBS = ""
                        .oRYDM = ""
                        .oRYZM = ""
                    End With
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
        'zengxianglin 2008-10-14

        Private Sub doClose(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                Dim strSessionId As String = ""
                Dim strUrl As String = ""
                If Me.m_blnInterface = True Then
                    '设置返回参数
                    With Me.m_objInterface
                        .oExitMode = False
                        .oRYDM = ""
                    End With
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

        'zengxianglin 2008-11-18
        Private Sub doSearch(ByVal strControlId As String)

            Dim objTreeviewProcess As New Josco.JsKernal.web.TreeviewProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '检查
                If Me.txtRYMC.Text.Trim = "" Then
                    Exit Try
                End If

                '搜索
                Dim strNodeIndex As String = ""
                If objTreeviewProcess.doSearch(strErrMsg, Me.tvwMain, Me.txtRYMC.Text, strNodeIndex) = False Then
                    GoTo errProc
                End If

                '定位
                If strNodeIndex <> "" Then
                    Me.tvwMain.SelectedNodeIndex = strNodeIndex
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.TreeviewProcess.SafeRelease(objTreeviewProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.web.TreeviewProcess.SafeRelease(objTreeviewProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub
        Private Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
            Me.doSearch("btnSearch")
        End Sub
        'zengxianglin 2008-11-18

        Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
            Me.doOK("btnOK")
        End Sub

        'zengxianglin 2008-10-14
        Private Sub btnNull_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNull.Click
            Me.doNull("btnNull")
        End Sub
        'zengxianglin 2008-10-14

        Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
            Me.doClose("btnClose")
        End Sub

    End Class

End Namespace
