Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' 命名空间：Josco.JsKernal.web
    ' 类名    ：estate_rs_ruzhi_info
    ' 
    ' 调用性质：
    '     可被其他模块调用，本身也调用其他模块
    '
    ' 功能描述： 
    '   　人事录用审批单信息处理
    '     新建时，保存完成后自动更改输入接口的iWJBS和iEditMode并等待用户后续操作
    '         如果取消，则直接返回上级。
    '     编辑时，无论保存或取消均等待用户后续操作
    '
    ' 接口参数：
    '     参见接口类IEstateRsLuyongInfo描述
    ' 更改记录：
    '     zengxianglin 2009-05-21 更改
    '----------------------------------------------------------------

    Partial Public Class dwxz_bmmc
        Inherits Josco.JsKernal.web.PageBase


        '----------------------------------------------------------------
        '模块私用参数
        '----------------------------------------------------------------
        '本模块相对image的相对路径
        Private m_cstrRelativePathToImage As String = "../../"

        '----------------------------------------------------------------
        '与数据网格grdSELBM相关的参数
        '----------------------------------------------------------------
        '网格中模板列中的控件ID
        Private Const m_cstrCheckBoxIdInDataGrid_SELBM As String = "chkSELBM"
        '包含网格的DIV对象ID
        Private Const m_cstrDataGridInDIV_SELBM As String = "divSELBM"
        '网格要锁定的列数
        Private m_intFixedColumns_SELBM As Integer

        '----------------------------------------------------------------
        '模块接口参数
        '----------------------------------------------------------------
        'Private m_objIDmxzBmmc As Josco.JSOA.BusinessFacade.IDmxzBmmc

        '----------------------------------------------------------------
        '要访问的数据
        '----------------------------------------------------------------
        Private m_objDataSet_BMXX As Josco.JsKernal.Common.Data.CustomerData
        Private m_objDataSet_SELBM As Josco.JsKernal.Common.Data.CustomerData
        Private m_strSessionId_SELBM As String '缓存m_objDataSet_SELBM的SessionId




        '----------------------------------------------------------------
        ' 释放接口参数
        '----------------------------------------------------------------
        Private Sub releaseInterfaceParameters()

            Try
                'If Not (Me.m_objIDmxzBmmc Is Nothing) Then
                '    If Me.m_objIDmxzBmmc.iInterfaceType = Josco.JSOA.BusinessFacade.ICallInterface.enumInterfaceType.InputOnly Then
                '        '释放Session
                '        Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId))
                '        '释放对象
                '        Me.m_objIDmxzBmmc.Dispose()
                '        Me.m_objIDmxzBmmc = Nothing
                '    End If
                'End If
            Catch ex As Exception
            End Try

        End Sub

        '----------------------------------------------------------------
        ' 获取接口参数(没有接口参数则显示错误信息页面)
        '----------------------------------------------------------------
        Private Function getInterfaceParameters(ByRef strErrMsg As String) As Boolean

            getInterfaceParameters = False

            '从QueryString中解析接口参数(不论是否回发)
            Dim objTemp As Object
            'Try
            '    objTemp = Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId))
            '    m_objIDmxzBmmc = CType(objTemp, Josco.JSOA.BusinessFacade.IDmxzBmmc)
            'Catch ex As Exception
            '    m_objIDmxzBmmc = Nothing
            'End Try

            ''必须有接口参数
            'If m_objIDmxzBmmc Is Nothing Then
            '    '显示错误信息
            '    Me.panelError.Visible = True
            '    Me.panelMain.Visible = Not Me.panelError.Visible
            '    strErrMsg = "本模块必须提供输入接口参数！"
            '    GoTo errProc
            'End If

            '获取局部接口参数
            Me.m_strSessionId_SELBM = Me.htxtSessionIdSELBM.Value
            With New Josco.JsKernal.Common.Utilities.PulicParameters
                Me.m_intFixedColumns_SELBM = .getObjectValue(Me.htxtSELBMFixed.Value, 0)
            End With

            getInterfaceParameters = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 释放本模块缓存的参数
        '----------------------------------------------------------------
        Private Sub releaseModuleParameters()
            Try
                If Me.m_strSessionId_SELBM.Trim <> "" Then
                    Dim objTempDataSet As Josco.JsKernal.Common.Data.CustomerData = Nothing
                    Try
                        objTempDataSet = CType(Session(Me.m_strSessionId_SELBM), Josco.JsKernal.Common.Data.CustomerData)
                    Catch ex As Exception
                        objTempDataSet = Nothing
                    End Try
                    Josco.JsKernal.Common.Data.CustomerData.SafeRelease(objTempDataSet)
                    Session.Remove(Me.m_strSessionId_SELBM)
                End If
            Catch ex As Exception
            End Try

        End Sub




        '----------------------------------------------------------------
        ' 获取tvwBMLIST要显示的数据信息
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_BMXX( _
            ByRef strErrMsg As String) As Boolean

            Dim objsystemCustomer As New Josco.JsKernal.BusinessFacade.systemCustomer

            getModuleData_BMXX = False

            Try
                '释放资源
                If Not (Me.m_objDataSet_BMXX Is Nothing) Then
                    Me.m_objDataSet_BMXX.Dispose()
                    Me.m_objDataSet_BMXX = Nothing
                End If

                '重新检索数据
                If objsystemCustomer.getBumenData(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_objDataSet_BMXX) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)

            getModuleData_BMXX = True
            Exit Function

errProc:
            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取grdSELBM要显示的数据信息，并进行session缓存
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_SELBM( _
            ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getModuleData_SELBM = False

            Dim strGuid As String
            Try
                If Me.IsPostBack = False Then
                    '获取Session的Id
                    strGuid = objPulicParameters.getNewGuid()
                    If strGuid = "" Then
                        strErrMsg = "无法产生GUID！"
                        GoTo errProc
                    End If

                    '初次调用空数据
                    Me.m_objDataSet_SELBM = New Josco.JsKernal.Common.Data.CustomerData(Josco.JsKernal.Common.Data.CustomerData.enumTableType.GG_B_ZUZHIJIGOU_SELECT)

                    '根据初始值设置信息
                    'If Me.m_objIDmxzBmmc.iLeibieList <> "" Then
                    '    Dim strValue() As String
                    '    strValue = Me.m_objIDmxzBmmc.iLeibieList.Split(Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate.ToCharArray())
                    '    Dim objDataRow As System.Data.DataRow
                    '    Dim intCount As Integer
                    '    Dim i As Integer
                    '    intCount = strValue.Length
                    '    For i = 0 To intCount - 1 Step 1
                    '        With Me.m_objDataSet_SELBM.Tables(Josco.JsKernal.Common.Data.CustomerData.TABLE_GG_B_ZUZHIJIGOU_SELECT)
                    '            objDataRow = .NewRow()
                    '            objDataRow.Item(Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_ZUZHIJIGOU_SELECT_DWMC) = strValue(i)
                    '            .Rows.Add(objDataRow)
                    '        End With
                    '    Next
                    'End If

                    '缓存信息
                    Me.m_strSessionId_SELBM = strGuid
                    Session.Add(Me.m_strSessionId_SELBM, Me.m_objDataSet_SELBM)
                    Me.htxtSessionIdSELBM.Value = Me.m_strSessionId_SELBM
                Else
                    '直接引用数据
                    Me.m_objDataSet_SELBM = CType(Session.Item(Me.m_strSessionId_SELBM), Josco.JsKernal.Common.Data.CustomerData)
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getModuleData_SELBM = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 根据屏幕搜索条件搜索grdSELBM数据(RowFilter)
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function searchModuleData_SELBM(ByRef strErrMsg As String) As Boolean

            searchModuleData_SELBM = False

            Try
                '获取搜索字符串
                Dim strQuery As String = ""


                '搜索数据
                If Me.getModuleData_SELBM(strErrMsg) = False Then
                    GoTo errProc
                End If

                '设置新的搜索字符串
                Me.m_objDataSet_SELBM.Tables(Josco.JsKernal.Common.Data.CustomerData.TABLE_GG_B_ZUZHIJIGOU_SELECT).DefaultView.RowFilter = strQuery
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            searchModuleData_SELBM = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示tvwBMLIST的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showTreeViewInfo_BMXX(ByRef strErrMsg As String) As Boolean

            Dim objTreeviewProcess As New Josco.JsKernal.web.TreeviewProcess

            showTreeViewInfo_BMXX = False

            'TreeView显示处理
            Try
                '初始化tvwBMLIST

                If objTreeviewProcess.doDisplayTreeViewAll(strErrMsg, Me.tvwBMLIST, _
                   Me.m_objDataSet_BMXX.Tables(Josco.JsKernal.Common.Data.CustomerData.TABLE_GG_B_ZUZHIJIGOU), _
                   Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_ZUZHIJIGOU_ZZDM, _
                   Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_ZUZHIJIGOU_ZZMC, _
                   True, True, Josco.JsKernal.Common.Data.CustomerData.intZZDM_FJCDSM) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.TreeviewProcess.SafeRelease(objTreeviewProcess)

            showTreeViewInfo_BMXX = True
            Exit Function

errProc:
            Josco.JsKernal.web.TreeviewProcess.SafeRelease(objTreeviewProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdSELBM的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo_SELBM( _
            ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_SELBM = False

            '获取系统保存的网格排序数据
            Dim intSortColumnIndex As Integer
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtSELBMSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtSELBMSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '网格显示处理
            Try
                '在获取数据时已经恢复了RowFilter、Sort的现场
                '设置数据源
                If Me.m_objDataSet_SELBM Is Nothing Then
                    Me.grdSELBM.DataSource = Nothing
                Else
                    With Me.m_objDataSet_SELBM.Tables(Josco.JsKernal.Common.Data.CustomerData.TABLE_GG_B_ZUZHIJIGOU_SELECT)
                        Me.grdSELBM.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objDataSet_SELBM.Tables(Josco.JsKernal.Common.Data.CustomerData.TABLE_GG_B_ZUZHIJIGOU_SELECT)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdSELBM, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '恢复列标题中的排序信息
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdSELBM)
                    With Me.grdSELBM.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '绑定数据
                Me.grdSELBM.DataBind()

                '----------------------------------------------------------------
                '因为这些信息是非绑定的，所以下面的操作必须等绑定完成后执行！！！
                '一旦在后续处理中执行了DataBind，则信息会丢失！！！
                '----------------------------------------------------------------
                '恢复网格中的CheckBox状态
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdSELBM, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_SELBM) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_SELBM = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function


        '----------------------------------------------------------------
        ' 显示grdSELBM及相关信息
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleData_SELBM( _
            ByRef strErrMsg As String) As Boolean

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showModuleData_SELBM = False

            Try
                '显示网格信息
                If Me.showDataGridInfo_SELBM(strErrMsg) = False Then
                    GoTo errProc
                End If

                '显示与网格紧密相关的操作或信息提示
                With Me.m_objDataSet_SELBM.Tables(Josco.JsKernal.Common.Data.CustomerData.TABLE_GG_B_ZUZHIJIGOU_SELECT).DefaultView
                    '显示网格位置信息
                    Me.BMlSELBMGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdSELBM, .Count)
                    '显示页面浏览功能
                    Me.lnkCZSELBMMoveFirst.Enabled = objDataGridProcess.canDoMoveFirstPage(Me.grdSELBM, .Count)
                    Me.lnkCZSELBMMoveLast.Enabled = objDataGridProcess.canDoMoveLastPage(Me.grdSELBM, .Count)
                    Me.lnkCZSELBMMovePrev.Enabled = objDataGridProcess.canDoMovePreviousPage(Me.grdSELBM, .Count)
                    Me.lnkCZSELBMMoveNext.Enabled = objDataGridProcess.canDoMoveNextPage(Me.grdSELBM, .Count)
                    '显示相关操作
                    Dim blnEnabled As Boolean
                    If .Count < 1 Then
                        blnEnabled = False
                    Else
                        blnEnabled = True
                    End If
                    Me.lnkCZSELBMDeSelectAll.Enabled = blnEnabled
                    Me.lnkCZSELBMSelectAll.Enabled = blnEnabled
                    Me.lnkCZSELBMGotoPage.Enabled = blnEnabled
                    Me.lnkCZSELBMSetPageSize.Enabled = blnEnabled
                    'Me.btnSELBMDelete.Enabled = blnEnabled
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showModuleData_SELBM = True
            Exit Function

errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 初始化控件
        '----------------------------------------------------------------
        Private Function initializeControls(ByRef strErrMsg As String) As Boolean

            initializeControls = False

            '仅在第一次调用页面时执行
            If Me.IsPostBack = False Then
                Try
                    '根据接口参数设置

                Catch ex As Exception
                End Try

                '显示Pannel
                Me.panelMain.Visible = True
                Me.panelError.Visible = Not Me.panelMain.Visible

                '执行键转译(不论是否是“回发”)
                Try
                    With New Josco.JsKernal.web.ControlProcess
                        .doTranslateKey(Me.txtSELBMPageIndex)
                        .doTranslateKey(Me.txtSELBMPageSize)
                    End With
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
            End If

            If Me.IsPostBack = False Then
                '获取数据
                If Me.getModuleData_BMXX(strErrMsg) = False Then
                    GoTo errProc
                End If
                '显示数据
                If Me.showTreeViewInfo_BMXX(strErrMsg) = False Then
                    GoTo errProc
                End If

                '获取数据
                If Me.getModuleData_SELBM(strErrMsg) = False Then
                    GoTo errProc
                End If
                '显示数据
                If Me.showModuleData_SELBM(strErrMsg) = False Then
                    GoTo errProc
                End If
            End If

            initializeControls = True
            Exit Function

errProc:
            Exit Function

        End Function

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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





        '实现对grdSELBM网格行、列的固定
        Sub grdSELBM_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdSELBM.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '标题行,输出标题锁定一般属性
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_SELBM + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_SELBM > 0 Then
                    '锁定列
                    For i = 0 To Me.m_intFixedColumns_SELBM - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdSELBM.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Private Sub tvwBMLIST_Check(ByVal sender As Object, ByVal e As Microsoft.Web.UI.WebControls.TreeViewClickEventArgs) Handles tvwBMLIST.Check

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objsystemCustomer As New Josco.JsKernal.BusinessFacade.systemCustomer
            Dim objsystemCommon As New Josco.JsKernal.BusinessFacade.systemCommon
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim objTreeviewProcess As New Josco.JsKernal.web.TreeviewProcess
            Dim objBumenData As Josco.JsKernal.Common.Data.CustomerData
            Dim strErrMsg As String

            Try
                Dim objDataRow As System.Data.DataRow

                '获取选定节点
                Dim objTreeNode As Microsoft.Web.UI.WebControls.TreeNode
                objTreeNode = Me.tvwBMLIST.GetNodeFromIndex(e.Node)
                If objTreeNode Is Nothing Then
                    strErrMsg = "错误：未给资产类别打勾！"
                    GoTo errProc
                End If
                If objTreeNode.Checked = False Then
                    GoTo normExit
                End If

                '从节点ID中获取资产类别代码
                Dim strBMDM As String
                strBMDM = objTreeviewProcess.getCodeValueFromNodeId(objTreeNode.ID)
                If strBMDM = "" Then
                    GoTo normExit
                End If

                '获取资产类别信息
                If objsystemCustomer.getBumenData(strErrMsg, MyBase.UserId, MyBase.UserPassword, strBMDM, objBumenData) = False Then
                    GoTo errProc
                End If
                With objBumenData.Tables(Josco.JsKernal.Common.Data.CustomerData.TABLE_GG_B_ZUZHIJIGOU_FULLJOIN)
                    '没有数据
                    If .Rows.Count < 1 Then
                        GoTo normExit
                    End If
                End With

                '获取SELBM的数据
                If Me.getModuleData_SELBM(strErrMsg) = False Then
                    GoTo errProc
                End If

                '根据接口参数处理
                Dim blnFound As Boolean
                Dim strMC As String
                '检查是否存在
                With objBumenData.Tables(Josco.JsKernal.Common.Data.CustomerData.TABLE_GG_B_ZUZHIJIGOU_FULLJOIN)
                    strMC = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_ZUZHIJIGOU_ZZMC), "")
                End With
                If objsystemCommon.doFindInDataTable(strErrMsg, _
                    Me.m_objDataSet_SELBM.Tables(Josco.JsKernal.Common.Data.CustomerData.TABLE_GG_B_ZUZHIJIGOU_SELECT), _
                    Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_ZUZHIJIGOU_SELECT_DWMC, _
                    strMC, blnFound) = False Then
                    GoTo errProc
                End If
                If blnFound = True Then '存在
                    GoTo normExit
                End If

                '复制到m_objDataSet_SELBM
                objDataRow = Me.m_objDataSet_SELBM.Tables(Josco.JsKernal.Common.Data.CustomerData.TABLE_GG_B_ZUZHIJIGOU_SELECT).NewRow()
                With objBumenData.Tables(Josco.JsKernal.Common.Data.CustomerData.TABLE_GG_B_ZUZHIJIGOU_FULLJOIN)
                    '设置数据
                    objDataRow.Item(Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_ZUZHIJIGOU_SELECT_DWMC) = .Rows(0).Item(Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_ZUZHIJIGOU_ZZMC)
                    objDataRow.Item(Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_ZUZHIJIGOU_SELECT_XZLX) = Josco.JsKernal.Common.Data.FenfafanweiData.CYLX_DANWEI
                    objDataRow.Item(Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_ZUZHIJIGOU_SELECT_DWQC) = .Rows(0).Item(Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_ZUZHIJIGOU_ZZBM)
                    objDataRow.Item(Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_ZUZHIJIGOU_SELECT_DWJB) = .Rows(0).Item(Josco.JsKernal.Common.Data.XingzhengjibieData.FIELD_GG_B_XINGZHENGJIBIE_JBMC)
                    objDataRow.Item(Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_ZUZHIJIGOU_SELECT_DWMS) = .Rows(0).Item(Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_RENYUAN_FULLJOIN_MSMC)
                    objDataRow.Item(Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_ZUZHIJIGOU_SELECT_SJHM) = .Rows(0).Item(Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_ZUZHIJIGOU_SJHM)
                    objDataRow.Item(Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_ZUZHIJIGOU_SELECT_LXDH) = .Rows(0).Item(Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_ZUZHIJIGOU_LXDH)
                    objDataRow.Item(Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_ZUZHIJIGOU_SELECT_FTPDZ) = .Rows(0).Item(Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_ZUZHIJIGOU_FTPDZ)
                    objDataRow.Item(Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_ZUZHIJIGOU_SELECT_YXDZ) = .Rows(0).Item(Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_ZUZHIJIGOU_YXDZ)
                End With

                '加入表
                With Me.m_objDataSet_SELBM.Tables(Josco.JsKernal.Common.Data.CustomerData.TABLE_GG_B_ZUZHIJIGOU_SELECT)
                    .Rows.Add(objDataRow)
                End With

                '重新显示网格
                If Me.showModuleData_SELBM(strErrMsg) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

normExit:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)
            Josco.JsKernal.BusinessFacade.systemCommon.SafeRelease(objsystemCommon)
            Josco.JsKernal.Common.Data.CustomerData.SafeRelease(objBumenData)
            Josco.JsKernal.web.TreeviewProcess.SafeRelease(objTreeviewProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)
            Josco.JsKernal.BusinessFacade.systemCommon.SafeRelease(objsystemCommon)
            Josco.JsKernal.Common.Data.CustomerData.SafeRelease(objBumenData)
            Josco.JsKernal.web.TreeviewProcess.SafeRelease(objTreeviewProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub


        Private Sub grdSELBM_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdSELBM.SelectedIndexChanged

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '获取数据
                If Me.getModuleData_SELBM(strErrMsg) = False Then
                    GoTo errProc
                End If
                '显示数据
                If Me.showModuleData_SELBM(strErrMsg) = False Then
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



        Private Sub grdSELBM_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdSELBM.SortCommand

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
                If Me.getModuleData_SELBM(strErrMsg) = False Then
                    GoTo errProc
                End If

                '获取原排序命令
                strOldCommand = Me.m_objDataSet_SELBM.Tables(Josco.JsKernal.Common.Data.CustomerData.TABLE_GG_B_ZUZHIJIGOU_SELECT).DefaultView.Sort

                '获取要执行的排序命令
                objDataGridProcess.getColumnSortCommand(strErrMsg, strOldCommand, e.SortExpression, strFinalCommand, objenumSortType)
                If strErrMsg <> "" Then
                    GoTo errProc
                End If

                '执行排序
                Me.m_objDataSet_SELBM.Tables(Josco.JsKernal.Common.Data.CustomerData.TABLE_GG_B_ZUZHIJIGOU_SELECT).DefaultView.Sort = strFinalCommand

                '获取排序列的列索引
                objDataGridItem = CType(e.CommandSource, System.Web.UI.WebControls.DataGridItem)
                strUniqueId = Request.Form("__EVENTTARGET")
                intColumnIndex = objDataGridProcess.getColumnIndexByUniqueIdInRow(objDataGridItem, strUniqueId)

                '保存排序信息
                Me.htxtSELBMSortColumnIndex.Value = intColumnIndex.ToString()
                Me.htxtSELBMSortType.Value = CType(objenumSortType, Integer).ToString()

                '重新显示数据
                If Me.showModuleData_SELBM(strErrMsg) = False Then
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

        Private Sub doMoveFirst_SELBM(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_SELBM(strErrMsg) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(0, Me.grdSELBM.PageCount)
                Me.grdSELBM.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_SELBM(strErrMsg) = False Then
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

        Private Sub doMoveLast_SELBM(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_SELBM(strErrMsg) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdSELBM.PageCount - 1, Me.grdSELBM.PageCount)
                Me.grdSELBM.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_SELBM(strErrMsg) = False Then
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

        Private Sub doMoveNext_SELBM(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_SELBM(strErrMsg) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdSELBM.CurrentPageIndex + 1, Me.grdSELBM.PageCount)
                Me.grdSELBM.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_SELBM(strErrMsg) = False Then
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

        Private Sub doMovePrevious_SELBM(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_SELBM(strErrMsg) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdSELBM.CurrentPageIndex - 1, Me.grdSELBM.PageCount)
                Me.grdSELBM.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_SELBM(strErrMsg) = False Then
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

        Private Sub doGotoPage_SELBM(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '获取新的页大小
            Dim intPageIndex As Integer
            intPageIndex = objPulicParameters.getObjectValue(Me.txtSELBMPageIndex.Text, 0)
            If intPageIndex <= 0 Then
                intPageIndex = 0
            Else
                intPageIndex -= 1
            End If

            Try
                '获取数据
                If Me.getModuleData_SELBM(strErrMsg) = False Then
                    GoTo errProc
                End If

                '设置新的页
                Me.grdSELBM.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_SELBM(strErrMsg) = False Then
                    GoTo errProc
                End If

                '信息同步
                Me.txtSELBMPageIndex.Text = (Me.grdSELBM.CurrentPageIndex + 1).ToString()

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

        Private Sub doSetPageSize_SELBM(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '获取新的页大小
            Dim intPageSize As Integer
            intPageSize = objPulicParameters.getObjectValue(Me.txtSELBMPageSize.Text, 100)
            If intPageSize <= 0 Then intPageSize = 100

            Try
                '获取数据
                If Me.getModuleData_SELBM(strErrMsg) = False Then
                    GoTo errProc
                End If

                '设置新的页大小
                Me.grdSELBM.PageSize = intPageSize

                '刷新网格显示
                If Me.showModuleData_SELBM(strErrMsg) = False Then
                    GoTo errProc
                End If

                '信息同步
                Me.txtSELBMPageSize.Text = (Me.grdSELBM.PageSize).ToString()

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

        Private Sub doSelectAll_SELBM(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdSELBM, 0, Me.m_cstrCheckBoxIdInDataGrid_SELBM, True) = False Then
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

        Private Sub doDeSelectAll_SELBM(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdSELBM, 0, Me.m_cstrCheckBoxIdInDataGrid_SELBM, False) = False Then
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

        Private Sub doSearch_SELBM(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '搜索数据
                If Me.searchModuleData_SELBM(strErrMsg) = False Then
                    GoTo errProc
                End If

                '刷新网格显示
                If Me.showModuleData_SELBM(strErrMsg) = False Then
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

        Private Sub lnkCZSELBMMoveFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZSELBMMoveFirst.Click
            Me.doMoveFirst_SELBM("lnkCZSELBMMoveFirst")
        End Sub

        Private Sub lnkCZSELBMMoveLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZSELBMMoveLast.Click
            Me.doMoveLast_SELBM("lnkCZSELBMMoveLast")
        End Sub

        Private Sub lnkCZSELBMMoveNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZSELBMMoveNext.Click
            Me.doMoveNext_SELBM("lnkCZSELBMMoveNext")
        End Sub

        Private Sub lnkCZSELBMMovePrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZSELBMMovePrev.Click
            Me.doMovePrevious_SELBM("lnkCZSELBMMovePrev")
        End Sub

        Private Sub lnkCZSELBMGotoPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZSELBMGotoPage.Click
            Me.doGotoPage_SELBM("lnkCZSELBMGotoPage")
        End Sub

        Private Sub lnkCZSELBMSetPageSize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZSELBMSetPageSize.Click
            Me.doSetPageSize_SELBM("lnkCZSELBMSetPageSize")
        End Sub

        Private Sub lnkCZSELBMSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZSELBMSelectAll.Click
            Me.doSelectAll_SELBM("lnkCZSELBMSelectAll")
        End Sub

        Private Sub lnkCZSELBMDeSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZSELBMDeSelectAll.Click
            Me.doDeSelectAll_SELBM("lnkCZSELBMDeSelectAll")
        End Sub




        '----------------------------------------------------------------
        '模块特殊操作处理器
        '----------------------------------------------------------------
        '处理“取消”按钮
        Private Sub doCancel(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '设置返回参数
            'Me.m_objIDmxzBmmc.oExitMode = False

            '释放模块资源
            Me.releaseModuleParameters()
            Me.releaseInterfaceParameters()

            '返回到调用模块，并附加返回参数
            '要返回的SessionId
            Dim strSessionId As String
            strSessionId = Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
            'SessionId附加到返回的Url
            Dim strUrl As String
            'strUrl = Me.m_objIDmxzBmmc.getReturnUrl(Server, Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId, strSessionId)
            '返回
            Page.ClientScript.RegisterStartupScript(ClientScript.GetType(), "", "<script> window.returnValue='';window.close();</script>")



            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        '处理选择单位“移出”按钮
        Private Sub doDelete_SELBM(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '获取数据
                If Me.getModuleData_SELBM(strErrMsg) = False Then
                    GoTo errProc
                End If

                '检查选择
                Dim blnChecked As Boolean
                Dim intRecPos As Integer
                Dim blnDo As Boolean
                Dim intCount As Integer
                Dim i As Integer
                intCount = Me.grdSELBM.Items.Count
                blnDo = False
                For i = intCount - 1 To 0 Step -1
                    blnChecked = objDataGridProcess.isDataGridItemChecked(Me.grdSELBM.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_SELBM)
                    If blnChecked = True Then
                        '获取记录位置
                        intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdSELBM.CurrentPageIndex, Me.grdSELBM.PageSize)

                        '删除
                        With Me.m_objDataSet_SELBM.Tables(Josco.JsKernal.Common.Data.CustomerData.TABLE_GG_B_ZUZHIJIGOU_SELECT)
                            .Rows.Remove(.DefaultView.Item(intRecPos).Row)
                        End With

                        '标志发生修改
                        blnDo = True
                    End If
                Next

                '刷新显示
                If blnDo = True Then
                    If Me.showModuleData_SELBM(strErrMsg) = False Then
                        GoTo errProc
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

normExit:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub



        '处理“确定”按钮
        Private Sub doConfirm(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '获取选择数据
            If Me.getModuleData_SELBM(strErrMsg) = False Then
                GoTo errProc
            End If

            Dim strReturnValue As String = ""
            Try
                '检查选择数据
                With Me.m_objDataSet_SELBM.Tables(Josco.JsKernal.Common.Data.CustomerData.TABLE_GG_B_ZUZHIJIGOU_SELECT)
                    If .Rows.Count < 1 Then
                        strErrMsg = "错误：没有选择任何内容！"
                        GoTo errProc
                    End If

                    If .Rows.Count > 1 Then
                        strErrMsg = "错误：只允许选择1条！"
                        GoTo errProc
                    End If

                End With

                With Me.m_objDataSet_SELBM.Tables(Josco.JsKernal.Common.Data.CustomerData.TABLE_GG_B_ZUZHIJIGOU_SELECT)
                    If .Rows.Count < 1 Then
                        '设置返回值

                    Else
                        '获取返回参数
                        Dim strSep As String = Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate
                        Dim strValue As String
                        Dim intCount As Integer
                        Dim i As Integer
                        With Me.m_objDataSet_SELBM.Tables(Josco.JsKernal.Common.Data.CustomerData.TABLE_GG_B_ZUZHIJIGOU_SELECT)
                            intCount = .Rows.Count
                            For i = 0 To intCount - 1 Step 1
                                strValue = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_ZUZHIJIGOU_SELECT_DWMC), "")
                                If strValue <> "" Then
                                    If strReturnValue <> "" Then
                                        strReturnValue = strReturnValue + strSep + strValue
                                    Else
                                        strReturnValue = strValue
                                    End If
                                End If
                            Next
                        End With

                        '清除所有的RowFilter
                        With Me.m_objDataSet_SELBM.Tables(Josco.JsKernal.Common.Data.CustomerData.TABLE_GG_B_ZUZHIJIGOU_SELECT)
                            .DefaultView.RowFilter = ""
                        End With

                        '设置返回值
                        'Me.m_objIDmxzBmmc.oLeibieList = strReturnValue
                        'Me.m_objIDmxzBmmc.oDataSet = Me.m_objDataSet_SELBM
                        Me.htxtReturnValue.Value = strReturnValue
                        If Me.m_strSessionId_SELBM.Trim <> "" Then
                            Try
                                Session.Remove(Me.m_strSessionId_SELBM)
                            Catch ex As Exception
                            End Try
                            Me.m_strSessionId_SELBM = ""
                        End If
                    End If
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            '设置返回参数
            'Me.m_objIDmxzBmmc.oExitMode = True

            '释放模块资源
            Me.releaseModuleParameters()
            Me.releaseInterfaceParameters()

            '返回到调用模块，并附加返回参数
            '要返回的SessionId
            Dim strSessionId As String
            strSessionId = Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
            'SessionId附加到返回的Url
            Dim strUrl As String

            'strUrl = Me.m_objIDmxzBmmc.getReturnUrl(Server, Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId, strSessionId)
            '返回
            'Response.Redirect(strUrl)
            'RegisterStartupScript("return", "<srcipt> window.returnvalue='" + strReturnValue + "';window.close();</srcipt>")
            '
            Page.ClientScript.RegisterStartupScript(ClientScript.GetType(), "", "<script> window.returnValue='" + strReturnValue + "';window.close();</script>")

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

        '处理单个选择单位“移出”按钮
        Private Function doDelete_SELBM_One(ByRef strErrMsg As String) As Boolean

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess

            doDelete_SELBM_One = False

            Try
                '检查当前行
                If Me.grdSELBM.Items.Count < 1 Then
                    strErrMsg = "错误：没有数据！"
                    GoTo errProc
                End If
                If Me.grdSELBM.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有选定数据！"
                    GoTo errProc
                End If

                '获取数据
                If Me.getModuleData_SELBM(strErrMsg) = False Then
                    GoTo errProc
                End If

                '检查选择
                Dim blnChecked As Boolean
                Dim intRecPos As Integer
                Dim blnDo As Boolean
                Dim i As Integer
                i = Me.grdSELBM.SelectedIndex
                blnDo = False

                '获取记录位置
                intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdSELBM.CurrentPageIndex, Me.grdSELBM.PageSize)

                '删除
                With Me.m_objDataSet_SELBM.Tables(Josco.JsKernal.Common.Data.CustomerData.TABLE_GG_B_ZUZHIJIGOU_SELECT)
                    .Rows.Remove(.DefaultView.Item(intRecPos).Row)
                End With

                '标志发生修改
                blnDo = True

                '刷新显示
                If blnDo = True Then
                    If Me.showModuleData_SELBM(strErrMsg) = False Then
                        GoTo errProc
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

normExit:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)

            doDelete_SELBM_One = True
            Exit Function

errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Function

        End Function

        Private Sub grdSELBM_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdSELBM.ItemCommand

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '修改当前行
                Me.grdSELBM.SelectedIndex = e.Item.ItemIndex

                '处理
                Select Case e.CommandName.ToUpper()
                    Case "DeleteOneRow".ToUpper()
                        If Me.doDelete_SELBM_One(strErrMsg) = False Then
                            GoTo errProc
                        End If
                    Case Else
                End Select

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
    End Class
End Namespace