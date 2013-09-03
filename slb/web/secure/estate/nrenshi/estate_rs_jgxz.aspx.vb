Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.web
    ' 类名    ：estate_rs_jgxz

    '----------------------------------------------------------------
    Partial Public Class estate_rs_jgxz
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
        Private m_cstrRelativePathToImage As String = "../../"

        '----------------------------------------------------------------
        '与数据网格grdZWLIST相关的参数
        '----------------------------------------------------------------
        '网格中模板列中的控件ID
        Private Const m_cstrCheckBoxIdInDataGrid_ZWLIST As String = "chkZWLIST"
        '包含网格的DIV对象ID
        Private Const m_cstrDataGridInDIV_ZWLIST As String = "divZWLIST"
        '网格要锁定的列数
        Private m_intFixedColumns_ZWLIST As Integer

        '----------------------------------------------------------------
        '模块接口参数
        '----------------------------------------------------------------
        Private m_objIDmxzRyjg As Josco.JSOA.BusinessFacade.IDmxzRyjg

        '----------------------------------------------------------------
        '要访问的数据
        '----------------------------------------------------------------
        Private m_objDataSet_JGRY As Josco.JSOA.Common.Data.estateRenshiXingyeData
        Private m_strQuery_JGRY As String '记录m_objDataSet_JGRY搜索串
        Private m_strSessionId_ZWSEL As String '缓存m_objDataSet_ZWSEL的SessionId
        Private m_intRows_ZWLIST As Integer '记录m_objDataSet_ZWLIST的DefaultView记录数

        '进入编辑模式前记录的行位置
        Private m_intCurrentSelectIndex As Integer








        '----------------------------------------------------------------
        ' 释放接口参数
        '----------------------------------------------------------------
        Private Sub releaseInterfaceParameters()

            Try
                If Not (Me.m_objIDmxzRyjg Is Nothing) Then
                    If Me.m_objIDmxzRyjg.iInterfaceType = Josco.JsKernal.BusinessFacade.ICallInterface.enumInterfaceType.InputOnly Then
                        '释放Session
                        Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId))
                        '释放对象
                        Me.m_objIDmxzRyjg.Dispose()
                        Me.m_objIDmxzRyjg = Nothing
                    End If
                End If
            Catch ex As Exception
            End Try

        End Sub

        '----------------------------------------------------------------
        ' 获取接口参数(没有接口参数则显示错误信息页面)
        '----------------------------------------------------------------
        Private Function getInterfaceParameters(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getInterfaceParameters = False

            '从QueryString中解析接口参数(不论是否回发)
            Dim objTemp As Object
            Try
                objTemp = Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId))
                m_objIDmxzRyjg = CType(objTemp, Josco.JSOA.BusinessFacade.IDmxzRyjg)
            Catch ex As Exception
                m_objIDmxzRyjg = Nothing
            End Try

            '必须有接口参数
            If m_objIDmxzRyjg Is Nothing Then
                '显示错误信息
                strErrMsg = "本模块必须提供输入接口参数！"
                Me.lblMessage.Text = strErrMsg
                Me.panelError.Visible = True
                Me.panelMain.Visible = Not Me.panelError.Visible
                GoTo errProc
            End If

            '获取局部接口参数
            Me.m_strSessionId_ZWSEL = Me.htxtSessionIdZWSEL.Value
            Me.m_intFixedColumns_ZWLIST = objPulicParameters.getObjectValue(Me.htxtZWLISTFixed.Value, 0)
            Me.m_intRows_ZWLIST = objPulicParameters.getObjectValue(Me.htxtZWLISTRows.Value, 0)

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

          
        End Sub

        '----------------------------------------------------------------
        ' 获取grdZWLIST的搜索条件(默认表前缀a.)
        '     strErrMsg      ：返回错误信息
        '     strQuery       ：返回的搜索条件
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getQueryString_ZWLIST( _
            ByRef strErrMsg As String, _
            ByRef strQuery As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getQueryString_ZWLIST = False
            strQuery = ""

            Try
                '按搜索
                Dim strZWMC As String = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYMC
                Dim strTemp As String = ""
                If Me.txtSearchZWMC.Text.Length > 0 Then Me.txtSearchZWMC.Text = Me.txtSearchZWMC.Text.Trim()
                strTemp = objPulicParameters.getNewSearchString(Me.txtSearchZWMC.Text)
                If strTemp <> "" Then
                    strTemp = strTemp
                    If strQuery = "" Then
                        strQuery = strZWMC + " like '" + strTemp + "%'"
                    Else
                        strQuery = strQuery + " and " + strZWMC + " like '" + strTemp + "%'"
                    End If
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getQueryString_ZWLIST = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取grdZWLIST要显示的数据信息
        '     strErrMsg      ：返回错误信息
        '     strWhere       ：搜索条件
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_ZWLIST( _
            ByRef strErrMsg As String, _
            ByVal strWhere As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_V_RS_RENYUANJIAGOU

            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye

            getModuleData_ZWLIST = False

            Try
                '备份Sort字符串
                Dim strSort As String
                strSort = Me.htxtZWLISTSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '释放资源
                If Not (Me.m_objDataSet_JGRY Is Nothing) Then
                    Me.m_objDataSet_JGRY.Dispose()
                    Me.m_objDataSet_JGRY = Nothing
                End If

                '重新检索数据
                Dim blnOptiong As Boolean = True
                If objsystemEstateRenshiXingye.getDataSet_RYJG_RY_In(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWhere, Me.m_objDataSet_JGRY, blnOptiong) = False Then
                    GoTo errProc
                End If

                '恢复Sort字符串
                With Me.m_objDataSet_JGRY.Tables(strTable)
                    .DefaultView.Sort = strSort
                End With

                '缓存参数
                With Me.m_objDataSet_JGRY.Tables(strTable)
                    Me.htxtZWLISTRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_ZWLIST = .DefaultView.Count
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)

            getModuleData_ZWLIST = True
            Exit Function

errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Exit Function

        End Function

      

        '----------------------------------------------------------------
        ' 根据屏幕搜索条件搜索grdZWLIST数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function searchModuleData_ZWLIST(ByRef strErrMsg As String) As Boolean

            searchModuleData_ZWLIST = False

            Try
                '获取搜索字符串
                Dim strQuery As String
                If Me.getQueryString_ZWLIST(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '搜索数据
                If Me.getModuleData_ZWLIST(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '记录搜索字符串
                Me.m_strQuery_JGRY = strQuery
                Me.htxtZWLISTQuery.Value = Me.m_strQuery_JGRY

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            searchModuleData_ZWLIST = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdZWLIST的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo_ZWLIST(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_V_RS_RENYUANJIAGOU

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_ZWLIST = False

            '获取系统保存的网格排序数据
            Dim intSortColumnIndex As Integer
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtZWLISTSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtZWLISTSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '网格显示处理
            Try
                '在获取数据时已经恢复了RowFilter、Sort的现场
                '设置数据源
                If Me.m_objDataSet_JGRY Is Nothing Then
                    Me.grdZWLIST.DataSource = Nothing
                Else
                    With Me.m_objDataSet_JGRY.Tables(strTable)
                        Me.grdZWLIST.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objDataSet_JGRY.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdZWLIST, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '恢复列标题中的排序信息
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdZWLIST)
                    With Me.grdZWLIST.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '绑定数据
                Me.grdZWLIST.DataBind()

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_ZWLIST = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdZWLIST及相关信息
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleData_ZWLIST(ByRef strErrMsg As String) As Boolean


            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_V_RS_RENYUANJIAGOU
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showModuleData_ZWLIST = False

            Try
                '显示网格信息
                If Me.showDataGridInfo_ZWLIST(strErrMsg) = False Then
                    GoTo errProc
                End If


                '显示与网格紧密相关的操作或信息提示
                With Me.m_objDataSet_JGRY.Tables(strTable).DefaultView
                    '显示网格位置信息
                    Me.lblZWLISTGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdZWLIST, .Count)


                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showModuleData_ZWLIST = True
            Exit Function

errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

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
                    '根据接口参数设置
                    If Me.m_objIDmxzRyjg.iMultiSelect = True Then
                        Me.lblTitle.Text += "[多选]"
                    Else
                        Me.lblTitle.Text += "[单选]"
                    End If
                Catch ex As Exception
                End Try

                '显示Pannel
                Me.panelMain.Visible = True
                Me.panelError.Visible = Not Me.panelMain.Visible

                '执行键转译(不论是否是“回发”)
                Try
                    objControlProcess.doTranslateKey(Me.txtSearchZWMC)
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
            End If

            If Me.IsPostBack = False Then
                '获取数据
                If Me.getModuleData_ZWLIST(strErrMsg, "") = False Then
                    GoTo errProc
                End If
                '显示数据
                If Me.showModuleData_ZWLIST(strErrMsg) = False Then
                    GoTo errProc
                End If

            End If

            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            initializeControls = True
            Exit Function

errProc:
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String
            Dim strUrl As String

            '预处理
            If MyBase.doPagePreprocess(True, False) = True Then
                Exit Sub
            End If

            '获取接口参数
            If Me.getInterfaceParameters(strErrMsg) = False Then
                GoTo errProc
            End If

            '控件初始化
            If Me.initializeControls(strErrMsg) = False Then
                GoTo errProc
            End If

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
        '实现对grdZWLIST网格行、列的固定
        Sub grdZWLIST_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdZWLIST.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '标题行,输出标题锁定一般属性
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_ZWLIST + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_ZWLIST > 0 Then
                    '锁定列
                    For i = 0 To Me.m_intFixedColumns_ZWLIST - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdZWLIST.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Private Sub grdZWLIST_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdZWLIST.PreRender

        End Sub

        Private Sub grdZWLIST_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdZWLIST.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '显示记录位置
                Me.lblZWLISTGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdZWLIST, Me.m_intRows_ZWLIST)
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

        '        Private Sub grdZWLIST_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdZWLIST.SortCommand

        '            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_V_RS_RENYUANJIAGOU

        '            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
        '            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
        '            Dim strErrMsg As String

        '            Try
        '                Dim objenumSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
        '                Dim objDataGridItem As System.Web.UI.WebControls.DataGridItem
        '                Dim strFinalCommand As String
        '                Dim strOldCommand As String
        '                Dim strUniqueId As String
        '                Dim intColumnIndex As Integer

        '                '获取数据
        '                If Me.getModuleData_ZWLIST(strErrMsg, "") = False Then
        '                    GoTo errProc
        '                End If

        '                '获取原排序命令
        '                strOldCommand = Me.m_objDataSet_JGRY.Tables(strTable).DefaultView.Sort

        '                '获取要执行的排序命令
        '                objDataGridProcess.getColumnSortCommand(strErrMsg, strOldCommand, e.SortExpression, strFinalCommand, objenumSortType)
        '                If strErrMsg <> "" Then
        '                    GoTo errProc
        '                End If

        '                '执行排序
        '                Me.m_objDataSet_JGRY.Tables(strTable).DefaultView.Sort = strFinalCommand

        '                '获取排序列的列索引
        '                objDataGridItem = CType(e.CommandSource, System.Web.UI.WebControls.DataGridItem)
        '                strUniqueId = Request.Form("__EVENTTARGET")
        '                intColumnIndex = objDataGridProcess.getColumnIndexByUniqueIdInRow(objDataGridItem, strUniqueId)

        '                '保存排序信息
        '                Me.htxtZWLISTSortColumnIndex.Value = intColumnIndex.ToString()
        '                Me.htxtZWLISTSortType.Value = CType(objenumSortType, Integer).ToString()
        '                Me.htxtZWLISTSort.Value = strFinalCommand

        '                '重新显示数据
        '                If Me.showModuleData_ZWLIST(strErrMsg) = False Then
        '                    GoTo errProc
        '                End If

        '            Catch ex As Exception
        '                strErrMsg = ex.Message
        '                GoTo errProc
        '            End Try

        '            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
        '            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
        '            Exit Sub

        'errProc:
        '            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
        '            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
        '            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
        '            Exit Sub

        '        End Sub


        Private Sub doSearch(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '搜索数据
                If Me.searchModuleData_ZWLIST(strErrMsg) = False Then
                    GoTo errProc
                End If

                '刷新网格显示
                If Me.showModuleData_ZWLIST(strErrMsg) = False Then
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

        Private Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
            Me.doSearch("btnSearch")
        End Sub


        '----------------------------------------------------------------
        '模块特殊操作处理器
        '----------------------------------------------------------------
        Private Sub doCancel(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '设置返回参数
                Me.m_objIDmxzRyjg.oExitMode = False

                '释放模块资源
                Me.releaseModuleParameters()
                Me.releaseInterfaceParameters()

                '返回到调用模块，并附加返回参数
                '要返回的SessionId
                Dim strSessionId As String
                strSessionId = Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                'SessionId附加到返回的Url
                Dim strUrl As String
                strUrl = Me.m_objIDmxzRyjg.getReturnUrl(Server, Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId, strSessionId)
                '返回
                Response.Redirect(strUrl)

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

        Private Sub doConfirm(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_V_RS_RENYUANJIAGOU
            Dim strSep As String = Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String
            Dim m_objDataSet_SEL As Josco.JSOA.Common.Data.estateRenshiXingyeData

            Try
                Dim intColIndex As Integer
                Dim strZW As String
                If Me.grdZWLIST.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有选择[人员]！"
                    GoTo errProc
                End If
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdZWLIST, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_WYBS)
                strZW = objDataGridProcess.getDataGridCellValue(Me.grdZWLIST.Items(Me.grdZWLIST.SelectedIndex), intColIndex)

                If Me.getModuleData_ZWLIST(strErrMsg, "") = False Then
                    GoTo errProc
                End If

                '加入选择
                With m_objDataSet_JGRY.Tables(strTable)
                    .DefaultView.RowFilter = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_WYBS + "='" + strZW + "'"
                End With

                

                '设置返回值
                Me.m_objIDmxzRyjg.oDataSet = Me.m_objDataSet_JGRY

                '设置返回参数
                Me.m_objIDmxzRyjg.oExitMode = True

                '释放模块资源
                Me.releaseModuleParameters()
                Me.releaseInterfaceParameters()

                '返回到调用模块，并附加返回参数
                '要返回的SessionId
                Dim strSessionId As String
                strSessionId = Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                'SessionId附加到返回的Url
                Dim strUrl As String
                strUrl = Me.m_objIDmxzRyjg.getReturnUrl(Server, Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId, strSessionId)
                '返回
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

        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Me.doCancel("btnCancel")
        End Sub

        Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
            Me.doConfirm("btnOK")
        End Sub
    End Class
End Namespace