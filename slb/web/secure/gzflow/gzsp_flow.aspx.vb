Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.web
    ' 类名    ：grsw_wdsy
    ' 
    ' 调用性质：
    '     不被其他模块调用，本身调用其他模块
    '
    ' QueryString参数：
    '     TYPE：事宜类别(值：DBSY、GQSY、BWTX)
    '     WJBS：文件标识
    '
    ' 功能描述： 
    '   　我的事宜处理
    '----------------------------------------------------------------

    Public Class gzsp_flow
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
        '文件下载后的缓存路径
        Private m_cstrUrlBaseToFileCache As String = "/temp/filecache/"
        '打印模版相对于应用根的路径
        Private m_cstrExcelMBRelativePathToAppRoot As String = "/template/excel/"
        '打印文件缓存目录相对于应用根的路径
        Private m_cstrPrintCacheRelativePathToAppRoot As String = "/temp/printcache/"
        '----------------------------------------------------------------
        '模块授权参数
        '----------------------------------------------------------------

        '----------------------------------------------------------------
        '模块现场保留参数，恢复完成后立即释放session资源
        '----------------------------------------------------------------
        Private m_objSaveScence As Josco.JsKernal.BusinessFacade.IMGrswWdsy
        Private m_blnSaveScence As Boolean


        '----------------------------------------------------------------
        '模块接口参数
        '----------------------------------------------------------------
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '与数据网格grdFILE相关的参数
        '----------------------------------------------------------------
        '网格中模板列中的控件ID
        Private Const m_cstrCheckBoxIdInDataGrid_FILE As String = "chkFILE"
        '包含网格的DIV对象ID
        Private Const m_cstrDataGridInDIV_FILE As String = "divFILE"
        '网格要锁定的列数
        Private m_intFixedColumns_FILE As Integer

        '----------------------------------------------------------------
        '与数据网格grdTASK相关的参数
        '----------------------------------------------------------------
        '网格中模板列中的控件ID
        Private Const m_cstrCheckBoxIdInDataGrid_TASK As String = "chkTASK"
        '包含网格的DIV对象ID
        Private Const m_cstrDataGridInDIV_TASK As String = "divTASK"
        '网格要锁定的列数
        Private m_intFixedColumns_TASK As Integer

        '----------------------------------------------------------------
        '要访问的数据
        '----------------------------------------------------------------
        Private m_objDataSet_NODE As Josco.JsKernal.Common.Data.grswMyTaskData
        Private m_objDataSet_FILE As Josco.JsKernal.Common.Data.grswMyTaskData
        Private m_objDataSet_TASK As Josco.JsKernal.Common.Data.grswMyTaskData
        Private m_strQuery_FILE As String '记录m_objDataSet_FILE搜索串
        Private m_intRows_FILE As Integer '记录m_objDataSet_FILE的DefaultView记录数
        Private m_strQuery_TASK As String '记录m_objDataSet_TASK搜索串
        Private m_intRows_TASK As Integer '记录m_objDataSet_TASK的DefaultView记录数
        Private m_objDataSet_JSRXX As Josco.JSOA.Common.Data.FlowData

        '----------------------------------------------------------------
        '接口参数
        '----------------------------------------------------------------
        Private m_strTYPE As String
        Private m_strWJBS As String

        '全局人员
        Private m_strSearchAdmin As String







        '----------------------------------------------------------------
        ' 复原模块现场信息并释放相应的资源
        '----------------------------------------------------------------
        Private Sub restoreModuleInformation(ByVal strSessionId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            Try
                If Me.m_objSaveScence Is Nothing Then Exit Try

                With Me.m_objSaveScence
                    Me.htxtSessionIdQueryFILE.Value = .htxtSessionIdQueryFILE

                    Me.htxtFILEQuery.Value = .htxtFILEQuery
                    Me.htxtFILERows.Value = .htxtFILERows
                    Me.htxtFILESort.Value = .htxtFILESort
                    Me.htxtFILESortColumnIndex.Value = .htxtFILESortColumnIndex
                    Me.htxtFILESortType.Value = .htxtFILESortType

                    Me.htxtTASKQuery.Value = .htxtTASKQuery
                    Me.htxtTASKRows.Value = .htxtTASKRows
                    Me.htxtTASKSort.Value = .htxtTASKSort
                    Me.htxtTASKSortColumnIndex.Value = .htxtTASKSortColumnIndex
                    Me.htxtTASKSortType.Value = .htxtTASKSortType

                    Me.htxtDivLeftFILE.Value = .htxtDivLeftFILE
                    Me.htxtDivTopFILE.Value = .htxtDivTopFILE
                    Me.htxtDivLeftTASK.Value = .htxtDivLeftTASK
                    Me.htxtDivTopTASK.Value = .htxtDivTopTASK
                    Me.htxtDivLeftBody.Value = .htxtDivLeftBody
                    Me.htxtDivTopBody.Value = .htxtDivTopBody

                    Me.txtFILEPageIndex.Text = .txtFILEPageIndex
                    Me.txtFILEPageSize.Text = .txtFILEPageSize

                    'Me.txtFILESearch_WJLX.Text = .txtFILESearch_WJLX
                    Me.txtFILESearch_WJBT.Text = .txtFILESearch_WJBT
                    Me.txtFILESearch_WJZH.Text = .txtFILESearch_WJZH
                    Me.txtFILESearch_WJRQMin.Text = .txtFILESearch_WJRQMin
                    Me.txtFILESearch_WJRQMax.Text = .txtFILESearch_WJRQMax

                    'Me.htxtPageCloseWindow.Value = .htxtPageCloseWindow

                    'Try
                    '    Me.ddlGWJKSearch_WJLX.SelectedIndex = .ddlGWJKSearch_WJLX_SelectedIndex
                    'Catch ex As Exception
                    'End Try

                    Try
                        Me.grdFILE.PageSize = .grdFILE_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdFILE.CurrentPageIndex = .grdFILE_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdFILE.SelectedIndex = .grdFILE_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Try
                        Me.grdTASK.PageSize = .grdTASK_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdTASK.CurrentPageIndex = .grdTASK_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdTASK.SelectedIndex = .grdTASK_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Try
                        Dim objTreeNode As Microsoft.Web.UI.WebControls.TreeNode
                        objTreeNode = Me.tvwTASK.GetNodeFromIndex(.tvwTASK_SelectedNodeIndex)
                        If Not (objTreeNode Is Nothing) Then
                            Me.tvwTASK.SelectedNodeIndex = .tvwTASK_SelectedNodeIndex
                        End If
                        Dim intCount As Integer
                        Dim i As Integer
                        intCount = Me.tvwTASK.Nodes.Count
                        For i = 0 To intCount - 1 Step 1
                            Me.tvwTASK.Nodes(i).Expanded = .tvwTASK_Expanded(i)
                        Next
                    Catch ex As Exception
                    End Try

                End With

                '释放资源
                Session.Remove(strSessionId)
                Me.m_objSaveScence.Dispose()
                Me.m_objSaveScence = Nothing

            Catch ex As Exception
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

        End Sub

        '----------------------------------------------------------------
        ' 保存模块现场信息并返回相应的SessionId
        '----------------------------------------------------------------
        Private Function saveModuleInformation() As String

            Dim strSessionId As String = ""
            Dim strErrMsg As String

            saveModuleInformation = ""

            Try
                '创建SessionId
                With New Josco.JsKernal.Common.Utilities.PulicParameters
                    strSessionId = .getNewGuid()
                End With
                If strSessionId = "" Then Exit Try

                '创建对象
                Me.m_objSaveScence = New Josco.JsKernal.BusinessFacade.IMGrswWdsy

                '保存现场信息
                With Me.m_objSaveScence
                    .htxtSessionIdQueryFILE = Me.htxtSessionIdQueryFILE.Value

                    .htxtFILEQuery = Me.htxtFILEQuery.Value
                    .htxtFILERows = Me.htxtFILERows.Value
                    .htxtFILESort = Me.htxtFILESort.Value
                    .htxtFILESortColumnIndex = Me.htxtFILESortColumnIndex.Value
                    .htxtFILESortType = Me.htxtFILESortType.Value

                    .htxtTASKQuery = Me.htxtTASKQuery.Value
                    .htxtTASKRows = Me.htxtTASKRows.Value
                    .htxtTASKSort = Me.htxtTASKSort.Value
                    .htxtTASKSortColumnIndex = Me.htxtTASKSortColumnIndex.Value
                    .htxtTASKSortType = Me.htxtTASKSortType.Value

                    .htxtDivLeftFILE = Me.htxtDivLeftFILE.Value
                    .htxtDivTopFILE = Me.htxtDivTopFILE.Value
                    '.htxtPageCloseWindow = Me.htxtPageCloseWindow.Value

                    .htxtDivLeftTASK = Me.htxtDivLeftTASK.Value
                    .htxtDivTopTASK = Me.htxtDivTopTASK.Value

                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value

                    .txtFILEPageIndex = Me.txtFILEPageIndex.Text
                    .txtFILEPageSize = Me.txtFILEPageSize.Text

                    '.ddlGWJKSearch_WJLX_SelectedIndex = Me.ddlGWJKSearch_WJLX.SelectedIndex
                    .txtFILESearch_WJBT = Me.txtFILESearch_WJBT.Text
                    '.txtFILESearch_WJLX = Me.txtFILESearch_WJLX.Text
                    .txtFILESearch_WJZH = Me.txtFILESearch_WJZH.Text
                    .txtFILESearch_WJRQMin = Me.txtFILESearch_WJRQMin.Text
                    .txtFILESearch_WJRQMax = Me.txtFILESearch_WJRQMax.Text

                    .grdFILE_PageSize = Me.grdFILE.PageSize
                    .grdFILE_CurrentPageIndex = Me.grdFILE.CurrentPageIndex
                    .grdFILE_SelectedIndex = Me.grdFILE.SelectedIndex

                    .grdTASK_PageSize = Me.grdTASK.PageSize
                    .grdTASK_CurrentPageIndex = Me.grdTASK.CurrentPageIndex
                    .grdTASK_SelectedIndex = Me.grdTASK.SelectedIndex

                    .tvwTASK_SelectedNodeIndex = Me.tvwTASK.SelectedNodeIndex
                    Dim blnExpanded(Me.tvwTASK.Nodes.Count) As Boolean
                    Dim intCount As Integer
                    Dim i As Integer
                    intCount = Me.tvwTASK.Nodes.Count
                    For i = 0 To intCount - 1 Step 1
                        blnExpanded(i) = Me.tvwTASK.Nodes(i).Expanded
                    Next
                    .tvwTASK_Expanded = blnExpanded
                End With

                '缓存对象
                Session.Add(strSessionId, Me.m_objSaveScence)

            Catch ex As Exception
                strErrMsg = ex.Message

            End Try

            saveModuleInformation = strSessionId

        End Function

        '----------------------------------------------------------------
        ' 从调用模块中获取数据
        '----------------------------------------------------------------
        Private Function getDataFromCallModule(ByRef strErrMsg As String) As Boolean

            Dim strSep As String = Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            Try
                If Me.IsPostBack = True Then Exit Try


                '==================================================================================================================================
                Dim objIEstateRsLuyongMain As Josco.JSOA.BusinessFacade.IEstateRsLuyongMain = Nothing
                Try
                    objIEstateRsLuyongMain = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IEstateRsLuyongMain)
                Catch ex As Exception
                    objIEstateRsLuyongMain = Nothing
                End Try
                If Not (objIEstateRsLuyongMain Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IEstateRsLuyongMain.SafeRelease(objIEstateRsLuyongMain)
                    Exit Try
                End If

                Dim objIEstateRsLuyongInfo As Josco.JSOA.BusinessFacade.IEstateRsLuyongInfo = Nothing
                Try
                    objIEstateRsLuyongInfo = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IEstateRsLuyongInfo)
                Catch ex As Exception
                    objIEstateRsLuyongInfo = Nothing
                End Try
                If Not (objIEstateRsLuyongInfo Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IEstateRsLuyongInfo.SafeRelease(objIEstateRsLuyongInfo)
                    Exit Try
                End If

                '==================================================================================================================================
                Dim objISjcxCxtj As Josco.JsKernal.BusinessFacade.ISjcxCxtj
                Try
                    objISjcxCxtj = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JsKernal.BusinessFacade.ISjcxCxtj)
                Catch ex As Exception
                    objISjcxCxtj = Nothing
                End Try
                If Not (objISjcxCxtj Is Nothing) Then
                    If objISjcxCxtj.oExitMode = True Then
                        Dim objQueryData As Josco.JsKernal.Common.Data.QueryData
                        Me.htxtFILEQuery.Value = objISjcxCxtj.oQueryString
                        If Me.htxtSessionIdQueryFILE.Value.Trim = "" Then
                            Me.htxtSessionIdQueryFILE.Value = objPulicParameters.getNewGuid()
                        Else
                            Try
                                objQueryData = CType(Session(Me.htxtSessionIdQueryFILE.Value), Josco.JsKernal.Common.Data.QueryData)
                            Catch ex As Exception
                                objQueryData = Nothing
                            End Try
                            If Not (objQueryData Is Nothing) Then
                                objQueryData.Dispose()
                                objQueryData = Nothing
                            End If
                        End If
                        Session.Add(Me.htxtSessionIdQueryFILE.Value, objISjcxCxtj.oDataSetTJ)
                    End If
                    '释放资源
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    objISjcxCxtj.Dispose()
                    objISjcxCxtj = Nothing
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
        ' 释放接口参数(模块无返回数据时用)
        '----------------------------------------------------------------
        Private Sub releaseInterfaceParameters()

            Try
            Catch ex As Exception
            End Try

        End Sub

        '----------------------------------------------------------------
        ' 获取接口参数(没有接口参数则显示错误信息页面)
        '----------------------------------------------------------------
        Private Function getInterfaceParameters( _
            ByRef strErrMsg As String, _
            ByRef blnContinue As Boolean) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getInterfaceParameters = False
            blnContinue = True

            Try
                '获取接口参数
                m_blnInterface = False
                Me.m_strTYPE = Request.QueryString("TYPE")
                If Me.m_strTYPE Is Nothing Then
                    Me.m_strTYPE = ""
                End If
                Me.m_strWJBS = Request.QueryString("WJBS")
                If Me.m_strWJBS Is Nothing Then
                    Me.m_strWJBS = ""
                End If

                '获取恢复现场参数
                If Me.IsPostBack = False Then
                    Dim strSessionId As String
                    strSessionId = objPulicParameters.getObjectValue(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId), "")
                    Try
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JsKernal.BusinessFacade.IMGrswWdsy)
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
                If Me.htxtPageCloseWindow.Value = "1" Then
                    Me.doClose(strErrMsg, "")
                    blnContinue = False
                    Exit Try
                End If

                '获取局部接口参数
                '记录m_objDataSet_FILE的DefaultView记录数
                Me.m_intRows_FILE = objPulicParameters.getObjectValue(Me.htxtFILERows.Value, 0)
                Me.m_strQuery_FILE = Me.htxtFILEQuery.Value
                Me.m_intFixedColumns_FILE = objPulicParameters.getObjectValue(Me.htxtFILEFixed.Value, 0)

                '记录m_objDataSet_TASK的DefaultView记录数
                Me.m_intRows_TASK = objPulicParameters.getObjectValue(Me.htxtTASKRows.Value, 0)
                Me.m_strQuery_TASK = Me.htxtTASKQuery.Value
                Me.m_intFixedColumns_TASK = objPulicParameters.getObjectValue(Me.htxtTASKFixed.Value, 0)

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
        ' 释放本模块缓存的参数(模块返回时用)
        '----------------------------------------------------------------
        Private Sub releaseModuleParameters()

            Try
                If Me.htxtSessionIdQueryFILE.Value.Trim <> "" Then
                    Dim objQueryData As Josco.JsKernal.Common.Data.QueryData
                    Try
                        objQueryData = CType(Session(Me.htxtSessionIdQueryFILE.Value), Josco.JsKernal.Common.Data.QueryData)
                    Catch ex As Exception
                        objQueryData = Nothing
                    End Try
                    If Not (objQueryData Is Nothing) Then
                        objQueryData.Dispose()
                        objQueryData = Nothing
                    End If
                    Session.Remove(Me.htxtSessionIdQueryFILE.Value)
                    Me.htxtSessionIdQueryFILE.Value = ""
                End If
            Catch ex As Exception
            End Try

        End Sub

        '----------------------------------------------------------------
        ' 获取grdFILE的搜索条件(默认表前缀a.)
        '     strErrMsg      ：返回错误信息
        '     strQuery       ：返回的搜索条件
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getQueryString_FILE( _
            ByRef strErrMsg As String, _
            ByRef strQuery As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getQueryString_FILE = False
            strQuery = ""

            Try
                '根据选项设置界面信息
                Dim strSearchTitle As String
                Dim strSearchField As String
                If Me.getTaskTypeInfo(strErrMsg, strSearchTitle, strSearchField) = False Then
                    GoTo errProc
                End If

                '按文件标题搜索
                Dim strWJBT As String
                strWJBT = "a." + Josco.JsKernal.Common.Data.grswMyTaskData.FIELD_GR_B_MYTASK_FILE_WJBT
                If Me.txtFILESearch_WJBT.Text.Length > 0 Then Me.txtFILESearch_WJBT.Text = Me.txtFILESearch_WJBT.Text.Trim()
                If Me.txtFILESearch_WJBT.Text <> "" Then
                    Me.txtFILESearch_WJBT.Text = objPulicParameters.getNewSearchString(Me.txtFILESearch_WJBT.Text)
                    If strQuery = "" Then
                        strQuery = strWJBT + " like '" + Me.txtFILESearch_WJBT.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strWJBT + " like '" + Me.txtFILESearch_WJBT.Text + "%'"
                    End If
                End If

                '按文件日期搜索
                Dim strWJRQ As String
                Dim dateMin As System.DateTime
                Dim dateMax As System.DateTime
                strWJRQ = "a." + strSearchField
                If Me.txtFILESearch_WJRQMin.Text.Length > 0 Then Me.txtFILESearch_WJRQMin.Text = Me.txtFILESearch_WJRQMin.Text.Trim()
                If Me.txtFILESearch_WJRQMax.Text.Length > 0 Then Me.txtFILESearch_WJRQMax.Text = Me.txtFILESearch_WJRQMax.Text.Trim()
                If Me.txtFILESearch_WJRQMin.Text <> "" And Me.txtFILESearch_WJRQMax.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtFILESearch_WJRQMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：[" + Me.txtFILESearch_WJRQMin.Text + "]不是有效的日期！"
                        GoTo errProc
                    End Try
                    Try
                        dateMax = CType(Me.txtFILESearch_WJRQMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：[" + Me.txtFILESearch_WJRQMax.Text + "]不是有效的日期！"
                        GoTo errProc
                    End Try

                    If dateMin > dateMax Then
                        Me.txtFILESearch_WJRQMin.Text = Format(dateMax, "yyyy-MM-dd")
                        Me.txtFILESearch_WJRQMax.Text = Format(dateMin, "yyyy-MM-dd")
                    Else
                        Me.txtFILESearch_WJRQMin.Text = Format(dateMin, "yyyy-MM-dd")
                        Me.txtFILESearch_WJRQMax.Text = Format(dateMax, "yyyy-MM-dd")
                    End If
                    If strQuery = "" Then
                        strQuery = strWJRQ + " between '" + Me.txtFILESearch_WJRQMin.Text + "' and '" + Me.txtFILESearch_WJRQMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strWJRQ + " between '" + Me.txtFILESearch_WJRQMin.Text + "' and '" + Me.txtFILESearch_WJRQMax.Text + "'"
                    End If
                ElseIf Me.txtFILESearch_WJRQMin.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtFILESearch_WJRQMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：[" + Me.txtFILESearch_WJRQMin.Text + "]不是有效的日期！"
                        GoTo errProc
                    End Try

                    Me.txtFILESearch_WJRQMin.Text = Format(dateMin, "yyyy-MM-dd")
                    If strQuery = "" Then
                        strQuery = strWJRQ + " >= '" + Me.txtFILESearch_WJRQMin.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strWJRQ + " >= '" + Me.txtFILESearch_WJRQMin.Text + "'"
                    End If
                ElseIf Me.txtFILESearch_WJRQMax.Text <> "" Then
                    Try
                        dateMax = CType(Me.txtFILESearch_WJRQMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "错误：[" + Me.txtFILESearch_WJRQMax.Text + "]不是有效的日期！"
                        GoTo errProc
                    End Try

                    Me.txtFILESearch_WJRQMax.Text = Format(dateMax, "yyyy-MM-dd")
                    If strQuery = "" Then
                        strQuery = strWJRQ + " <= '" + Me.txtFILESearch_WJRQMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strWJRQ + " <= '" + Me.txtFILESearch_WJRQMax.Text + "'"
                    End If
                Else
                End If

                '按文件类型搜索
                '按“文件类型”搜索
                Dim strWJLX As String
                strWJLX = "a." + Josco.JsKernal.Common.Data.grswMyTaskData.FIELD_GR_B_MYTASK_FILE_WJLX
                Select Case Me.ddlGWJKSearch_WJLX.SelectedIndex
                    Case -1, 0
                    Case Else
                        If strQuery = "" Then
                            strQuery = strWJLX + " = '" + Me.ddlGWJKSearch_WJLX.SelectedItem.Text + "'"
                        Else
                            strQuery = strQuery + " and " + strWJLX + " = '" + Me.ddlGWJKSearch_WJLX.SelectedItem.Text + "'"
                        End If
                End Select

                '按文件字号搜索
                Dim strWJZH As String
                strWJZH = "a." + Josco.JsKernal.Common.Data.grswMyTaskData.FIELD_GR_B_MYTASK_FILE_WJZH
                If Me.txtFILESearch_WJZH.Text.Length > 0 Then Me.txtFILESearch_WJZH.Text = Me.txtFILESearch_WJZH.Text.Trim()
                If Me.txtFILESearch_WJZH.Text <> "" Then
                    'Me.txtFILESearch_WJZH.Text = objPulicParameters.getNewSearchString(Me.txtFILESearch_WJZH.Text)
                    If strQuery = "" Then
                        strQuery = strWJZH + " like '" + Me.txtFILESearch_WJZH.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strWJZH + " like '" + Me.txtFILESearch_WJZH.Text + "%'"
                    End If
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getQueryString_FILE = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取树节点信息
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_NODE( _
            ByRef strErrMsg As String) As Boolean

            Dim objsystemMyTask As New Josco.JSOA.BusinessFacade.systemGzsp

            getModuleData_NODE = False

            Try
                ''释放资源
                'If Not (Me.m_objDataSet_NODE Is Nothing) Then
                '    Me.m_objDataSet_NODE.Dispose()
                '    Me.m_objDataSet_NODE = Nothing
                'End If

                '释放资源
                Josco.JsKernal.Common.Data.grswMyTaskData.SafeRelease(Me.m_objDataSet_NODE)

                '重新获取数据
                If objsystemMyTask.getMyTaskNodeData(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_objDataSet_NODE) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemGzsp.SafeRelease(objsystemMyTask)

            getModuleData_NODE = True
            Exit Function

errProc:
            Josco.JSOA.BusinessFacade.systemGzsp.SafeRelease(objsystemMyTask)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取文件信息
        '     strErrMsg      ：返回错误信息
        '     strWhere       ：搜索条件
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_FILE( _
            ByRef strErrMsg As String, _
            ByVal strWhere As String) As Boolean

            Dim objsystemMyTask As New Josco.JSOA.BusinessFacade.systemGzsp

            Dim objTreeviewProcess As New Josco.JsKernal.web.TreeviewProcess
            Dim objNodeData As System.Data.DataRow

            getModuleData_FILE = False

            Try
                '从tvwTASK中获取任务
                Dim objTreeNode As Microsoft.Web.UI.WebControls.TreeNode
                Dim strCode As String
                If Me.tvwTASK.SelectedNodeIndex = "" Then
                    strErrMsg = "错误：没有选择事宜！"
                    GoTo errProc
                End If
                objTreeNode = Me.tvwTASK.GetNodeFromIndex(Me.tvwTASK.SelectedNodeIndex)
                If objTreeNode Is Nothing Then
                    strErrMsg = "错误：没有选择事宜！"
                    GoTo errProc
                End If
                strCode = objTreeviewProcess.getCodeValueFromNodeId(objTreeNode.ID)

                '根据strCode获取任务数据
                If objsystemMyTask.getMyTaskNodeData(strErrMsg, strCode, Me.m_objDataSet_NODE, objNodeData) = False Then
                    GoTo errProc
                End If

                '备份Sort字符串
                Dim strSort As String
                strSort = Me.htxtFILESort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '释放资源
                If Not (Me.m_objDataSet_FILE Is Nothing) Then
                    Me.m_objDataSet_FILE.Dispose()
                    Me.m_objDataSet_FILE = Nothing
                End If

                '重新检索数据
                If objsystemMyTask.getMyTaskFileData(strErrMsg, MyBase.UserId, MyBase.UserPassword, MyBase.UserXM, objNodeData, strWhere, Me.m_objDataSet_FILE) = False Then
                    GoTo errProc
                End If

                '恢复Sort字符串
                With Me.m_objDataSet_FILE.Tables(Josco.JsKernal.Common.Data.grswMyTaskData.TABLE_GR_B_MYTASK_FILE)
                    .DefaultView.Sort = strSort
                End With

                '缓存参数
                With Me.m_objDataSet_FILE.Tables(Josco.JsKernal.Common.Data.grswMyTaskData.TABLE_GR_B_MYTASK_FILE)
                    Me.htxtFILERows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_FILE = .DefaultView.Count
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemGzsp.SafeRelease(objsystemMyTask)
            Josco.JsKernal.web.TreeviewProcess.SafeRelease(objTreeviewProcess)

            getModuleData_FILE = True
            Exit Function

errProc:
            Josco.JSOA.BusinessFacade.systemGzsp.SafeRelease(objsystemMyTask)
            Josco.JsKernal.web.TreeviewProcess.SafeRelease(objTreeviewProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 根据屏幕搜索条件搜索grdFILE数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function searchModuleData_FILE(ByRef strErrMsg As String) As Boolean

            searchModuleData_FILE = False

            Try
                '获取搜索字符串
                Dim strQuery As String
                If Me.getQueryString_FILE(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '搜索数据
                If Me.getModuleData_FILE(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '记录搜索字符串
                Me.m_strQuery_FILE = strQuery
                Me.htxtFILEQuery.Value = Me.m_strQuery_FILE

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            searchModuleData_FILE = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取文件对应的事宜信息
        '     strErrMsg      ：返回错误信息
        '     strWhere       ：搜索条件
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getModuleData_TASK( _
            ByRef strErrMsg As String, _
            ByVal strWhere As String) As Boolean

            Dim objsystemMyTask As New Josco.JSOA.BusinessFacade.systemGzsp
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objTreeviewProcess As New Josco.JsKernal.web.TreeviewProcess
            Dim objNodeData As System.Data.DataRow

            getModuleData_TASK = False

            Try
                '从tvwTASK中获取任务
                Dim objTreeNode As Microsoft.Web.UI.WebControls.TreeNode
                Dim strCode As String
                If Me.tvwTASK.SelectedNodeIndex = "" Then
                    strErrMsg = "错误：没有选择事宜！"
                    GoTo errProc
                End If
                objTreeNode = Me.tvwTASK.GetNodeFromIndex(Me.tvwTASK.SelectedNodeIndex)
                If objTreeNode Is Nothing Then
                    strErrMsg = "错误：没有选择事宜！"
                    GoTo errProc
                End If
                strCode = objTreeviewProcess.getCodeValueFromNodeId(objTreeNode.ID)
                '根据strCode获取任务数据
                If objsystemMyTask.getMyTaskNodeData(strErrMsg, strCode, Me.m_objDataSet_NODE, objNodeData) = False Then
                    GoTo errProc
                End If

                '从grdFILE中获取文件标识
                Dim intColIndex As Integer
                Dim strWJBS As String
                If Me.grdFILE.SelectedIndex < 0 Then
                    strWJBS = ""
                Else
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdFILE, Josco.JsKernal.Common.Data.grswMyTaskData.FIELD_GR_B_MYTASK_FILE_WJBS)
                    strWJBS = objDataGridProcess.getDataGridCellValue(Me.grdFILE.Items(Me.grdFILE.SelectedIndex), intColIndex)
                End If

                '备份Sort字符串
                Dim strSort As String
                strSort = Me.htxtTASKSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '释放资源
                If Not (Me.m_objDataSet_TASK Is Nothing) Then
                    Me.m_objDataSet_TASK.Dispose()
                    Me.m_objDataSet_TASK = Nothing
                End If

                '重新检索数据
                If objsystemMyTask.getMyTaskTaskData(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWJBS, MyBase.UserXM, objNodeData, strWhere, Me.m_objDataSet_TASK) = False Then
                    GoTo errProc
                End If

                '恢复Sort字符串
                With Me.m_objDataSet_TASK.Tables(Josco.JsKernal.Common.Data.grswMyTaskData.TABLE_GR_B_MYTASK_TASK)
                    .DefaultView.Sort = strSort
                End With

                '缓存参数
                With Me.m_objDataSet_TASK.Tables(Josco.JsKernal.Common.Data.grswMyTaskData.TABLE_GR_B_MYTASK_TASK)
                    Me.htxtTASKRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_TASK = .DefaultView.Count
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemGzsp.SafeRelease(objsystemMyTask)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.TreeviewProcess.SafeRelease(objTreeviewProcess)

            getModuleData_TASK = True
            Exit Function

errProc:
            Josco.JSOA.BusinessFacade.systemGzsp.SafeRelease(objsystemMyTask)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.TreeviewProcess.SafeRelease(objTreeviewProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示tvwTASK的数据
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleData_NODE( _
            ByRef strErrMsg As String) As Boolean

            Dim objTreeviewProcess As New Josco.JsKernal.web.TreeviewProcess

            showModuleData_NODE = False

            'TreeView显示处理
            Try
                '初始化tvwTask
                If objTreeviewProcess.doDisplayTreeViewAll(strErrMsg, Me.tvwTASK, _
                    Me.m_objDataSet_NODE.Tables(Josco.JsKernal.Common.Data.grswMyTaskData.TABLE_GR_B_MYTASK_NODE), _
                    Josco.JsKernal.Common.Data.grswMyTaskData.FIELD_GR_B_MYTASK_NODE_CODE, _
                    Josco.JsKernal.Common.Data.grswMyTaskData.FIELD_GR_B_MYTASK_NODE_NAME, _
                    False, True, Josco.JsKernal.Common.Data.grswMyTaskData.intJDDM_FJCDSM) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.TreeviewProcess.SafeRelease(objTreeviewProcess)

            showModuleData_NODE = True
            Exit Function

errProc:
            Josco.JsKernal.web.TreeviewProcess.SafeRelease(objTreeviewProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdFILE的信息
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo_FILE(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_FILE = False

            '获取系统保存的网格排序数据
            Dim intSortColumnIndex As Integer
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtFILESortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtFILESortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '网格显示处理
            Try
                '根据选项设置界面信息
                Dim strSearchTitle As String
                Dim strSearchField As String
                If Me.getTaskTypeInfo(strErrMsg, strSearchTitle, strSearchField) = False Then
                    GoTo errProc
                End If

                '在获取数据时已经恢复了RowFilter、Sort的现场
                '设置数据源
                If Me.m_objDataSet_FILE Is Nothing Then
                    Me.grdFILE.DataSource = Nothing
                Else
                    With Me.m_objDataSet_FILE.Tables(Josco.JsKernal.Common.Data.grswMyTaskData.TABLE_GR_B_MYTASK_FILE)
                        Me.grdFILE.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objDataSet_FILE.Tables(Josco.JsKernal.Common.Data.grswMyTaskData.TABLE_GR_B_MYTASK_FILE)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdFILE, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '=============================================================================================
                '列标题动态设定
                Dim intColIndex As Integer
                If strSearchField = Josco.JsKernal.Common.Data.grswMyTaskData.FIELD_GR_B_MYTASK_FILE_FSRQ Then
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdFILE, Josco.JsKernal.Common.Data.grswMyTaskData.FIELD_GR_B_MYTASK_FILE_FSRQ)
                    Me.grdFILE.Columns(intColIndex).HeaderText = strSearchTitle
                End If
                '=============================================================================================

                '恢复列标题中的排序信息
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdFILE)
                    With Me.grdFILE.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '绑定数据
                Me.grdFILE.DataBind()

                '----------------------------------------------------------------
                '因为这些信息是非绑定的，所以下面的操作必须等绑定完成后执行！！！
                '一旦在后续处理中执行了DataBind，则信息会丢失！！！
                '----------------------------------------------------------------
                '恢复网格中的CheckBox状态
                'If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdFILE, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_FILE) = False Then
                '    GoTo errProc
                'End If

                Dim intColI(3) As Integer
                Dim strWJBS As String
                Dim intRows As Integer
                Dim strFlowTypeName As String
                Dim strWJBT As String
                Dim i As Integer

                Dim strRYDM As String = ""
                strRYDM = MyBase.UserId
                'If strRYDM = "linjunli" Or strRYDM = "wenluxi" Then

                intRows = Me.grdFILE.Items.Count
                For i = intRows - 1 To 0 Step -1
                    intColI(0) = objDataGridProcess.getDataGridColumnIndex(Me.grdFILE, Josco.JsKernal.Common.Data.grswMyTaskData.FIELD_GR_B_MYTASK_FILE_WJBS)
                    intColI(1) = objDataGridProcess.getDataGridColumnIndex(Me.grdFILE, Josco.JsKernal.Common.Data.grswMyTaskData.FIELD_GR_B_MYTASK_FILE_WJBT)
                    intColI(2) = objDataGridProcess.getDataGridColumnIndex(Me.grdFILE, Josco.JsKernal.Common.Data.grswMyTaskData.FIELD_GR_B_MYTASK_FILE_WJLX)
                    strWJBS = objDataGridProcess.getDataGridCellValue(Me.grdFILE.Items(i), intColI(0))
                    strWJBT = objDataGridProcess.getDataGridCellValue(Me.grdFILE.Items(i), intColI(1))
                    strFlowTypeName = objDataGridProcess.getDataGridCellValue(Me.grdFILE.Items(i), intColI(2))

                    If doAutoReceiveFILE(strErrMsg, strWJBS, strWJBT, strFlowTypeName) = False Then
                        GoTo errProc
                    End If
                Next
                'End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_FILE = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdTASK的信息
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showDataGridInfo_TASK(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_TASK = False

            '获取系统保存的网格排序数据
            Dim intSortColumnIndex As Integer
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtTASKSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtTASKSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '网格显示处理
            Try
                '在获取数据时已经恢复了RowFilter、Sort的现场
                '设置数据源
                If Me.m_objDataSet_TASK Is Nothing Then
                    Me.grdTASK.DataSource = Nothing
                Else
                    With Me.m_objDataSet_TASK.Tables(Josco.JsKernal.Common.Data.grswMyTaskData.TABLE_GR_B_MYTASK_TASK)
                        Me.grdTASK.DataSource = .DefaultView
                    End With
                End If

                '调整网格参数
                With Me.m_objDataSet_TASK.Tables(Josco.JsKernal.Common.Data.grswMyTaskData.TABLE_GR_B_MYTASK_TASK)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdTASK, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '恢复列标题中的排序信息
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdTASK)
                    With Me.grdTASK.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '绑定数据
                Me.grdTASK.DataBind()

                '----------------------------------------------------------------
                '因为这些信息是非绑定的，所以下面的操作必须等绑定完成后执行！！！
                '一旦在后续处理中执行了DataBind，则信息会丢失！！！
                '----------------------------------------------------------------

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_TASK = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdFILE及相关信息
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleData_FILE( _
            ByRef strErrMsg As String) As Boolean

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showModuleData_FILE = False

            Try
                '显示网格信息
                If Me.showDataGridInfo_FILE(strErrMsg) = False Then
                    GoTo errProc
                End If

                '显示与网格紧密相关的操作或信息提示
                With Me.m_objDataSet_FILE.Tables(Josco.JsKernal.Common.Data.grswMyTaskData.TABLE_GR_B_MYTASK_FILE).DefaultView
                    '显示网格位置信息
                    Me.lblFILEGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdFILE, .Count)
                    '显示页面浏览功能
                    Me.lnkCZFILEMoveFirst.Enabled = objDataGridProcess.canDoMoveFirstPage(Me.grdFILE, .Count)
                    Me.lnkCZFILEMoveLast.Enabled = objDataGridProcess.canDoMoveLastPage(Me.grdFILE, .Count)
                    Me.lnkCZFILEMovePrev.Enabled = objDataGridProcess.canDoMovePreviousPage(Me.grdFILE, .Count)
                    Me.lnkCZFILEMoveNext.Enabled = objDataGridProcess.canDoMoveNextPage(Me.grdFILE, .Count)
                    '显示相关操作
                    Dim blnEnabled As Boolean
                    If .Count < 1 Then
                        blnEnabled = False
                    Else
                        blnEnabled = True
                    End If
                    Me.lnkCZFILEDeSelectAll.Enabled = blnEnabled
                    Me.lnkCZFILESelectAll.Enabled = blnEnabled
                    Me.lnkCZFILEGotoPage.Enabled = blnEnabled
                    Me.lnkCZFILESetPageSize.Enabled = blnEnabled
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showModuleData_FILE = True
            Exit Function

errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 显示grdTASK及相关信息
        '     strErrMsg      ：返回错误信息
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function showModuleData_TASK( _
            ByRef strErrMsg As String) As Boolean

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showModuleData_TASK = False

            Try
                '显示网格信息
                If Me.showDataGridInfo_TASK(strErrMsg) = False Then
                    GoTo errProc
                End If

                '显示与网格紧密相关的操作或信息提示

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showModuleData_TASK = True
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

            Try
                '仅在第一次调用页面时执行
                If Me.IsPostBack = False Then
                    '显示Pannel(不论是否回调，始终显示panelMain)
                    Me.panelMain.Visible = True
                    Me.panelError.Visible = Not Me.panelMain.Visible
                    Me.htxtPageCloseWindow.Value = "0"

                    '接口参数处理
                    If Me.m_blnSaveScence = False Then
                        Select Case Me.m_strTYPE.ToUpper
                            Case "DBSY".ToUpper
                                Me.tvwTASK.SelectedNodeIndex = Me.tvwTASK.Nodes(0).GetNodeIndex
                            Case "BWTX".ToUpper
                                Me.tvwTASK.SelectedNodeIndex = Me.tvwTASK.Nodes(1).GetNodeIndex
                            Case "GQSY".ToUpper
                                Me.tvwTASK.SelectedNodeIndex = Me.tvwTASK.Nodes(5).GetNodeIndex
                            Case Else
                        End Select
                    End If

                    '打开指定文件
                    If Me.m_blnSaveScence = False Then
                        If Me.m_strWJBS <> "" Then
                            Me.m_strQuery_FILE = "a." + Josco.JsKernal.Common.Data.grswMyTaskData.FIELD_GR_B_MYTASK_FILE_WJBS + " = '" + Me.m_strWJBS + "'"
                        End If
                    End If

                    '显示文件数据
                    If Me.getModuleData_FILE(strErrMsg, Me.m_strQuery_FILE) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_FILE(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '同步显示事宜数据
                    If Me.getModuleData_TASK(strErrMsg, Me.m_strQuery_TASK) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_TASK(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '打开指定文件
                    If Me.m_blnSaveScence = False Then
                        If Me.m_strWJBS <> "" Then
                            Me.htxtPageCloseWindow.Value = "1"
                            If Me.doOpenFile(strErrMsg, "lnkMenu") = False Then
                                GoTo errProc
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            initializeControls = True
            Exit Function

errProc:
            Exit Function

        End Function

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim strUrl As String

            Dim strUserID As String = ""
            Dim strPassword As String = ""
            Dim strNewPassword As String
            Dim intStep As Integer

            Dim objsystemCustomer As Josco.JsKernal.BusinessFacade.systemCustomer = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objCustomerData As Josco.JsKernal.Common.Data.CustomerData = Nothing

            Try
                strUserID = CStr(Request.QueryString("ID"))
                strPassword = CStr(Request.QueryString("password"))

                If strUserID <> "" Then
                    strPassword = CStr(Request.QueryString("password"))

                    '验证
                    objsystemCustomer = New Josco.JsKernal.BusinessFacade.systemCustomer
                    If objsystemCustomer.doVerifyUserPassword(strErrMsg, strUserID, strPassword, strNewPassword) = False Then
                        GoTo errProc
                    End If

                    '获取用户信息`
                    If objsystemCustomer.getRenyuanData(strErrMsg, strUserID, strPassword, "0011", objCustomerData) = False Then
                        GoTo errProc
                    End If

                    '记录凭证
                    System.Web.Security.FormsAuthentication.SetAuthCookie("*", False)

                    '缓存用户信息
                    MyBase.Customer = objCustomerData
                    MyBase.UserId = strUserID
                    MyBase.UserOrgPassword = strPassword
                    MyBase.UserPassword = strNewPassword
                    MyBase.UserEnterTime = Format(Now, "yyyy-MM-dd HH:mm:ss")
                    MyBase.LastScanTime_Chat = ""
                    MyBase.LastScanTime_Notice = ""

                    '检查密码长度
                    If MyBase.doCheckPassword() = True Then
                        Exit Sub
                    End If
                End If

                '预处理
                If MyBase.doPagePreprocess(True, Me.IsPostBack And Me.m_blnSaveScence) = True Then
                    Exit Sub
                End If

                '初始化列表
                If Me.IsPostBack = False Then
                    Me.ddlGWJKSearch_WJLX.Items.Add("")
                    Me.ddlGWJKSearch_WJLX.Items.Add(Josco.JSOA.Common.Workflow.BaseFlowRenshiLiZhi.FLOWNAME)
                    Me.ddlGWJKSearch_WJLX.Items.Add(Josco.JSOA.Common.Workflow.BaseFlowRenshiRuZhi.FLOWNAME)
                    Me.ddlGWJKSearch_WJLX.Items.Add(Josco.JSOA.Common.Workflow.BaseFlowRenshiShiXiSheng.FLOWNAME)
                    Me.ddlGWJKSearch_WJLX.Items.Add(Josco.JSOA.Common.Workflow.BaseFlowRenshiTiaozheng.FLOWNAME)

                End If

                '初始化工作流
                Dim m_objsystemFlowObjectRenshiRuZhi As Josco.JSOA.BusinessFacade.systemFlowObjectRenshiRuZhi
                If Me.doInitializeWorkflow(strErrMsg, "", False, m_objsystemFlowObjectRenshiRuZhi) = False Then
                    GoTo errProc
                End If

                '必须先获取任务列表数据
                '获取任务数据
                If Me.getModuleData_NODE(strErrMsg) = False Then
                    GoTo errProc
                End If


                If Me.IsPostBack = False Then
                    '显示任务数据
                    If Me.showModuleData_NODE(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    '折叠
                    If Me.m_blnSaveScence = False Then
                        Dim intCount As Integer
                        Dim i As Integer
                        intCount = Me.tvwTASK.Nodes.Count
                        For i = 0 To intCount - 1 Step 1
                            Me.tvwTASK.Nodes(i).Expanded = False
                        Next
                    End If
                End If

                '获取接口参数
                Dim blnDo As Boolean = False
                If Me.getInterfaceParameters(strErrMsg, blnDo) = False Then
                    GoTo errProc
                End If
                If blnDo = False Then
                    Exit Try
                End If

                '控件初始化
                If Me.initializeControls(strErrMsg) = False Then
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




        '----------------------------------------------------------------
        '网格事件处理器
        '----------------------------------------------------------------
        '实现对grdFILE网格行、列的固定
        Sub grdFILE_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdFILE.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                'If e.Item.ItemIndex < 0 Then
                '    '标题行,输出标题锁定一般属性
                '    intCells = e.Item.Cells.Count
                '    For i = 0 To intCells - 1 Step 1
                '        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_FILE + ".scrollTop)")
                '    Next
                'End If
                'If Me.m_intFixedColumns_FILE > 0 Then
                '    '锁定列
                '    For i = 0 To Me.m_intFixedColumns_FILE - 1 Step 1
                '        e.Item.Cells(i).CssClass = Me.grdFILE. + "Locked"
                '    Next
                'End If
            Catch ex As Exception
            End Try

        End Sub

        Private Sub grdFILE_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdFILE.ItemCommand

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                Dim strControlId As String
                Dim intColIndex As Integer

                '定位
                Me.grdFILE.SelectedIndex = e.Item.ItemIndex

                '处理
                Select Case e.CommandName.ToUpper
                    Case "OpenDocument".ToUpper
                        strControlId = objDataGridProcess.getPostbackControlId(e.CommandSource)
                        If Me.doOpenFile(strErrMsg, strControlId) = False Then
                            GoTo errProc
                        End If
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

        '实现对grdTASK网格行、列的固定
        Sub grdTASK_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdTASK.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '标题行,输出标题锁定一般属性
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_TASK + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_TASK > 0 Then
                    '锁定列
                    For i = 0 To Me.m_intFixedColumns_TASK - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdTASK.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub




        '----------------------------------------------------------------
        ' 根据tvwTASK当前节点获取搜索条件的标题及字段名
        '     strErrMsg      ：返回错误信息
        '     strSearchTitle ：返回的搜索条件的标题
        '     strSearchField ：返回的搜索条件的字段名
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function getTaskTypeInfo( _
            ByRef strErrMsg As String, _
            ByRef strSearchTitle As String, _
            ByRef strSearchField As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objTreeviewProcess As New Josco.JsKernal.web.TreeviewProcess

            getTaskTypeInfo = False
            strSearchTitle = ""
            strSearchField = ""
            strErrMsg = ""

            Try
                Dim objTreeNode As Microsoft.Web.UI.WebControls.TreeNode
                objTreeNode = Me.tvwTASK.GetNodeFromIndex(Me.tvwTASK.SelectedNodeIndex)
                If objTreeNode Is Nothing Then
                    Exit Try
                End If
                Dim strCode As String
                strCode = objTreeviewProcess.getCodeValueFromNodeId(objTreeNode.ID)
                Dim intLevel1Len As Integer = Josco.JsKernal.Common.Data.grswMyTaskData.intJDDM_FJCDSM(0)
                Dim intCode As Integer
                intCode = objPulicParameters.getObjectValue(strCode.Substring(0, intLevel1Len), 1)
                Select Case intCode
                    Case Josco.JsKernal.Common.Data.grswMyTaskData.enumTaskTypeLevel1.DBSY  '待办事宜
                        strSearchField = Josco.JsKernal.Common.Data.grswMyTaskData.FIELD_GR_B_MYTASK_FILE_FSRQ
                        strSearchTitle = "发送日期"

                    Case Josco.JsKernal.Common.Data.grswMyTaskData.enumTaskTypeLevel1.DPWJ  '待批文件
                        strSearchField = Josco.JsKernal.Common.Data.grswMyTaskData.FIELD_GR_B_MYTASK_FILE_FSRQ
                        strSearchTitle = "发送日期"

                    Case Josco.JsKernal.Common.Data.grswMyTaskData.enumTaskTypeLevel1.HBWJ  '缓办文件
                        strSearchField = Josco.JsKernal.Common.Data.grswMyTaskData.FIELD_GR_B_MYTASK_FILE_WCRQ
                        strSearchTitle = "完成日期"

                    Case Josco.JsKernal.Common.Data.grswMyTaskData.enumTaskTypeLevel1.YBSY  '已办事宜
                        strSearchField = Josco.JsKernal.Common.Data.grswMyTaskData.FIELD_GR_B_MYTASK_FILE_WCRQ
                        strSearchTitle = "完成日期"

                    Case Josco.JsKernal.Common.Data.grswMyTaskData.enumTaskTypeLevel1.GQSY  '过期事宜
                        strSearchField = Josco.JsKernal.Common.Data.grswMyTaskData.FIELD_GR_B_MYTASK_FILE_BLQX
                        strSearchTitle = "办理期限"

                    Case Josco.JsKernal.Common.Data.grswMyTaskData.enumTaskTypeLevel1.CBSY  '催办事宜
                        strSearchField = Josco.JsKernal.Common.Data.grswMyTaskData.FIELD_GR_B_MYTASK_FILE_FSRQ
                        strSearchTitle = "催办日期"

                    Case Josco.JsKernal.Common.Data.grswMyTaskData.enumTaskTypeLevel1.BCSY  '被催事宜
                        strSearchField = Josco.JsKernal.Common.Data.grswMyTaskData.FIELD_GR_B_MYTASK_FILE_FSRQ
                        strSearchTitle = "催办日期"

                    Case Josco.JsKernal.Common.Data.grswMyTaskData.enumTaskTypeLevel1.DBWJ  '督办文件
                        strSearchField = Josco.JsKernal.Common.Data.grswMyTaskData.FIELD_GR_B_MYTASK_FILE_FSRQ
                        strSearchTitle = "督办日期"

                    Case Josco.JsKernal.Common.Data.grswMyTaskData.enumTaskTypeLevel1.BDWJ  '被督文件
                        strSearchField = Josco.JsKernal.Common.Data.grswMyTaskData.FIELD_GR_B_MYTASK_FILE_FSRQ
                        strSearchTitle = "督办日期"

                    Case Josco.JsKernal.Common.Data.grswMyTaskData.enumTaskTypeLevel1.QBSY  '全部事宜
                        strSearchField = Josco.JsKernal.Common.Data.grswMyTaskData.FIELD_GR_B_MYTASK_FILE_FSRQ
                        strSearchTitle = "发送日期"
                End Select

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.TreeviewProcess.SafeRelease(objTreeviewProcess)

            getTaskTypeInfo = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.TreeviewProcess.SafeRelease(objTreeviewProcess)
            Exit Function

        End Function

        Private Sub tvwTASK_SelectedIndexChange(ByVal sender As Object, ByVal e As Microsoft.Web.UI.WebControls.TreeViewSelectEventArgs) Handles tvwTASK.SelectedIndexChange

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '设置新索引
                Me.tvwTASK.SelectedNodeIndex = e.NewNode

                '根据选项设置界面信息
                Dim strSearchTitle As String
                Dim strSearchField As String
                If Me.getTaskTypeInfo(strErrMsg, strSearchTitle, strSearchField) = False Then
                    GoTo errProc
                End If
                Me.lblFILESearch_WJRQ.Text = strSearchTitle

                '显示文件数据
                If Me.getModuleData_FILE(strErrMsg, Me.m_strQuery_FILE) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_FILE(strErrMsg) = False Then
                    GoTo errProc
                End If

                '同步显示事宜数据
                If Me.getModuleData_TASK(strErrMsg, Me.m_strQuery_TASK) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_TASK(strErrMsg) = False Then
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

        Private Sub grdFILE_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdFILE.SelectedIndexChanged

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '显示记录位置
                With New Josco.JsKernal.web.DataGridProcess
                    Me.lblFILEGridLocInfo.Text = .getDataGridLocation(Me.grdFILE, Me.m_intRows_FILE)
                End With

                '同步显示事宜数据
                If Me.getModuleData_TASK(strErrMsg, Me.m_strQuery_TASK) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_TASK(strErrMsg) = False Then
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



        Private Sub grdFILE_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdFILE.SortCommand

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
                If Me.getModuleData_FILE(strErrMsg, Me.m_strQuery_FILE) = False Then
                    GoTo errProc
                End If

                '获取原排序命令
                strOldCommand = Me.m_objDataSet_FILE.Tables(Josco.JsKernal.Common.Data.grswMyTaskData.TABLE_GR_B_MYTASK_FILE).DefaultView.Sort

                '获取要执行的排序命令
                objDataGridProcess.getColumnSortCommand(strErrMsg, strOldCommand, e.SortExpression, strFinalCommand, objenumSortType)
                If strErrMsg <> "" Then
                    GoTo errProc
                End If

                '执行排序
                Me.m_objDataSet_FILE.Tables(Josco.JsKernal.Common.Data.grswMyTaskData.TABLE_GR_B_MYTASK_FILE).DefaultView.Sort = strFinalCommand

                '获取排序列的列索引
                objDataGridItem = CType(e.CommandSource, System.Web.UI.WebControls.DataGridItem)
                strUniqueId = Request.Form("__EVENTTARGET")
                intColumnIndex = objDataGridProcess.getColumnIndexByUniqueIdInRow(objDataGridItem, strUniqueId)

                '保存排序信息
                Me.htxtFILESortColumnIndex.Value = intColumnIndex.ToString()
                Me.htxtFILESortType.Value = CType(objenumSortType, Integer).ToString()
                Me.htxtFILESort.Value = strFinalCommand

                '重新显示数据
                If Me.showModuleData_FILE(strErrMsg) = False Then
                    GoTo errProc
                End If

                '同步显示事宜数据
                If Me.getModuleData_TASK(strErrMsg, Me.m_strQuery_TASK) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_TASK(strErrMsg) = False Then
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

        Private Sub grdTASK_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdTASK.SortCommand

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
                If Me.getModuleData_TASK(strErrMsg, Me.m_strQuery_TASK) = False Then
                    GoTo errProc
                End If

                '获取原排序命令
                strOldCommand = Me.m_objDataSet_TASK.Tables(Josco.JsKernal.Common.Data.grswMyTaskData.TABLE_GR_B_MYTASK_TASK).DefaultView.Sort

                '获取要执行的排序命令
                objDataGridProcess.getColumnSortCommand(strErrMsg, strOldCommand, e.SortExpression, strFinalCommand, objenumSortType)
                If strErrMsg <> "" Then
                    GoTo errProc
                End If

                '执行排序
                Me.m_objDataSet_TASK.Tables(Josco.JsKernal.Common.Data.grswMyTaskData.TABLE_GR_B_MYTASK_TASK).DefaultView.Sort = strFinalCommand

                '获取排序列的列索引
                objDataGridItem = CType(e.CommandSource, System.Web.UI.WebControls.DataGridItem)
                strUniqueId = Request.Form("__EVENTTARGET")
                intColumnIndex = objDataGridProcess.getColumnIndexByUniqueIdInRow(objDataGridItem, strUniqueId)

                '保存排序信息
                Me.htxtTASKSortColumnIndex.Value = intColumnIndex.ToString()
                Me.htxtTASKSortType.Value = CType(objenumSortType, Integer).ToString()
                Me.htxtTASKSort.Value = strFinalCommand

                '重新显示数据
                If Me.showModuleData_TASK(strErrMsg) = False Then
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



        Private Sub doMoveFirst_FILE(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_FILE(strErrMsg, Me.m_strQuery_FILE) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(0, Me.grdFILE.PageCount)
                Me.grdFILE.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_FILE(strErrMsg) = False Then
                    GoTo errProc
                End If

                '同步显示事宜数据
                If Me.getModuleData_TASK(strErrMsg, Me.m_strQuery_TASK) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_TASK(strErrMsg) = False Then
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

        Private Sub doMoveLast_FILE(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_FILE(strErrMsg, Me.m_strQuery_FILE) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdFILE.PageCount - 1, Me.grdFILE.PageCount)
                Me.grdFILE.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_FILE(strErrMsg) = False Then
                    GoTo errProc
                End If

                '同步显示事宜数据
                If Me.getModuleData_TASK(strErrMsg, Me.m_strQuery_TASK) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_TASK(strErrMsg) = False Then
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

        Private Sub doMoveNext_FILE(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_FILE(strErrMsg, Me.m_strQuery_FILE) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdFILE.CurrentPageIndex + 1, Me.grdFILE.PageCount)
                Me.grdFILE.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_FILE(strErrMsg) = False Then
                    GoTo errProc
                End If

                '同步显示事宜数据
                If Me.getModuleData_TASK(strErrMsg, Me.m_strQuery_TASK) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_TASK(strErrMsg) = False Then
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

        Private Sub doMovePrevious_FILE(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '获取数据
                If Me.getModuleData_FILE(strErrMsg, Me.m_strQuery_FILE) = False Then
                    GoTo errProc
                End If

                '设置新的页
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdFILE.CurrentPageIndex - 1, Me.grdFILE.PageCount)
                Me.grdFILE.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_FILE(strErrMsg) = False Then
                    GoTo errProc
                End If

                '同步显示事宜数据
                If Me.getModuleData_TASK(strErrMsg, Me.m_strQuery_TASK) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_TASK(strErrMsg) = False Then
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

        Private Sub doGotoPage_FILE(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '获取新的页大小
            Dim intPageIndex As Integer
            intPageIndex = objPulicParameters.getObjectValue(Me.txtFILEPageIndex.Text, 0)
            If intPageIndex <= 0 Then
                intPageIndex = 0
            Else
                intPageIndex -= 1
            End If

            Try
                '获取数据
                If Me.getModuleData_FILE(strErrMsg, Me.m_strQuery_FILE) = False Then
                    GoTo errProc
                End If

                '设置新的页
                Me.grdFILE.CurrentPageIndex = intPageIndex

                '刷新网格显示
                If Me.showModuleData_FILE(strErrMsg) = False Then
                    GoTo errProc
                End If

                '同步显示事宜数据
                If Me.getModuleData_TASK(strErrMsg, Me.m_strQuery_TASK) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_TASK(strErrMsg) = False Then
                    GoTo errProc
                End If

                '信息同步
                Me.txtFILEPageIndex.Text = (Me.grdFILE.CurrentPageIndex + 1).ToString()

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

        Private Sub doSetPageSize_FILE(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '获取新的页大小
            Dim intPageSize As Integer
            intPageSize = objPulicParameters.getObjectValue(Me.txtFILEPageSize.Text, 100)
            If intPageSize <= 0 Then intPageSize = 100

            Try
                '获取数据
                If Me.getModuleData_FILE(strErrMsg, Me.m_strQuery_FILE) = False Then
                    GoTo errProc
                End If

                '设置新的页大小
                Me.grdFILE.PageSize = intPageSize

                '刷新网格显示
                If Me.showModuleData_FILE(strErrMsg) = False Then
                    GoTo errProc
                End If

                '同步显示事宜数据
                If Me.getModuleData_TASK(strErrMsg, Me.m_strQuery_TASK) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_TASK(strErrMsg) = False Then
                    GoTo errProc
                End If

                '信息同步
                Me.txtFILEPageSize.Text = (Me.grdFILE.PageSize).ToString()

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

        Private Sub doSelectAll_FILE(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdFILE, 0, Me.m_cstrCheckBoxIdInDataGrid_FILE, True) = False Then
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

        Private Sub doDeSelectAll_FILE(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdFILE, 0, Me.m_cstrCheckBoxIdInDataGrid_FILE, False) = False Then
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

        Private Sub doSearch_FILE(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '搜索数据
                If Me.searchModuleData_FILE(strErrMsg) = False Then
                    GoTo errProc
                End If

                '刷新网格显示
                If Me.showModuleData_FILE(strErrMsg) = False Then
                    GoTo errProc
                End If

                '同步显示事宜数据
                If Me.getModuleData_TASK(strErrMsg, Me.m_strQuery_TASK) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_TASK(strErrMsg) = False Then
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

        Private Sub lnkCZFILEMoveFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZFILEMoveFirst.Click
            Me.doMoveFirst_FILE("lnkCZFILEMoveFirst")
        End Sub

        Private Sub lnkCZFILEMoveLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZFILEMoveLast.Click
            Me.doMoveLast_FILE("lnkCZFILEMoveLast")
        End Sub

        Private Sub lnkCZFILEMovePrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZFILEMovePrev.Click
            Me.doMovePrevious_FILE("lnkCZFILEMovePrev")
        End Sub

        Private Sub lnkCZFILEMoveNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZFILEMoveNext.Click
            Me.doMoveNext_FILE("lnkCZFILEMoveNext")
        End Sub

        Private Sub lnkCZFILESetPageSize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZFILESetPageSize.Click
            Me.doSetPageSize_FILE("lnkCZFILESetPageSize")
        End Sub

        Private Sub lnkCZFILEGotoPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZFILEGotoPage.Click
            Me.doGotoPage_FILE("lnkCZFILEGotoPage")
        End Sub

        Private Sub lnkCZFILESelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZFILESelectAll.Click
            Me.doSelectAll_FILE("lnkCZFILESelectAll")
        End Sub

        Private Sub lnkCZFILEDeSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZFILEDeSelectAll.Click
            Me.doDeSelectAll_FILE("lnkCZFILEDeSelectAll")
        End Sub

        Private Sub btnFILESearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFILESearch.Click
            Me.doSearch_FILE("btnFILESearch")
        End Sub

        Private Sub ddlGWJKSearch_WJLX_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlGWJKSearch_WJLX.SelectedIndexChanged
            Me.doSearch_FILE("btnFILESearch")
        End Sub







        Private Sub doSearchFull_FILE(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objISjcxCxtj As Josco.JsKernal.BusinessFacade.ISjcxCxtj
            Dim strNewSessionId As String
            Dim strMSessionId As String

            Dim strTable As String = Josco.JsKernal.Common.Data.grswMyTaskData.TABLE_GR_B_MYTASK_FILE

            Try
                '获取数据
                If Me.getModuleData_FILE(strErrMsg, Me.m_strQuery_FILE) = False Then
                    GoTo errProc
                End If

                '备份现场参数
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                Dim strUrl As String
                objISjcxCxtj = New Josco.JsKernal.BusinessFacade.ISjcxCxtj
                With objISjcxCxtj
                    If Me.htxtSessionIdQueryFILE.Value.Trim <> "" Then
                        .iDataSetTJ = CType(Session(Me.htxtSessionIdQueryFILE.Value), Josco.JsKernal.Common.Data.QueryData)
                    Else
                        .iDataSetTJ = Nothing
                    End If
                    .iQueryTable = Me.m_objDataSet_FILE.Tables(strTable)
                    .iFixQuery = ""

                    .iSourceControlId = strControlId
                    strUrl = ""
                    strUrl += Request.Url.AbsolutePath
                    strUrl += "?"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                    strUrl += "="
                    strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    strUrl += "&"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                    strUrl += "="
                    strUrl += strMSessionId
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
                strUrl += "../sjcx/sjcx_cxtj.aspx"
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

        Private Sub btnFileSearchFull_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFileSearchFull.Click
            Me.doSearchFull_FILE("btnFILESearchFull")
        End Sub





        '----------------------------------------------------------------
        ' 新建文件
        '     strErrMsg      ：返回错误信息
        '     strControlId   ：当前操作控件ID
        '     strFlowTypeName：要创建工作流类型名称
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function doNewFile( _
            ByRef strErrMsg As String, _
            ByVal strControlId As String, _
            ByVal strFlowTypeName As String) As Boolean

            Dim objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject
            Dim strWJBS As String = ""

            Dim strRSessionId As String = ""
            Dim strISessionId As String = ""
            Dim strMSessionId As String = ""
            Dim strUrl As String

            doNewFile = False

            Try
                '创建指定工作流对象
                Dim strType As String
                Dim strName As String
                strType = Josco.JSOA.BusinessFacade.systemFlowObject.getFlowType(strFlowTypeName)
                strName = strFlowTypeName
                objsystemFlowObject = Josco.JSOA.BusinessFacade.systemFlowObject.Create(strType, strName)
                If objsystemFlowObject.doInitialize(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWJBS, False) = False Then
                    GoTo errProc
                End If

                '备份现场参数
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '获取Url
                If Me.m_blnInterface = False Then
                    If objsystemFlowObject.doFileNew( _
                        strErrMsg, _
                        strControlId, _
                        "", _
                        strMSessionId, _
                        "", _
                        Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                        Request, Session, _
                        strUrl, _
                        strRSessionId) = False Then
                        GoTo errProc
                    End If
                Else
                    strISessionId = Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    If objsystemFlowObject.doFileNew( _
                        strErrMsg, _
                        strControlId, _
                        "", _
                        strMSessionId, _
                        strISessionId, _
                        Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                        Request, Session, _
                        strUrl, _
                        strRSessionId) = False Then
                        GoTo errProc
                    End If
                End If
                If strUrl <> "" Then
                    Response.Redirect(strUrl)
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)

            doNewFile = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 打开文件
        '     strErrMsg      ：返回错误信息
        '     strControlId   ：当前操作控件ID
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function doOpenFile( _
            ByRef strErrMsg As String, _
            ByVal strControlId As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            Dim objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject
            Dim strISessionId As String = ""
            Dim strMSessionId As String = ""
            Dim strUrl As String

            doOpenFile = False

            Try
                '检查当前选择
                If Me.grdFILE.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有当前文件！"
                    GoTo errProc
                End If

                '获取文件标识和文件类型
                Dim strFlowTypeName As String
                Dim strWJBS As String
                Dim intColIndex(2) As Integer
                intColIndex(0) = objDataGridProcess.getDataGridColumnIndex(Me.grdFILE, Josco.JsKernal.Common.Data.grswMyTaskData.FIELD_GR_B_MYTASK_FILE_WJBS)
                intColIndex(1) = objDataGridProcess.getDataGridColumnIndex(Me.grdFILE, Josco.JsKernal.Common.Data.grswMyTaskData.FIELD_GR_B_MYTASK_FILE_WJLX)
                strWJBS = objDataGridProcess.getDataGridCellValue(Me.grdFILE.Items(Me.grdFILE.SelectedIndex), intColIndex(0))
                strFlowTypeName = objDataGridProcess.getDataGridCellValue(Me.grdFILE.Items(Me.grdFILE.SelectedIndex), intColIndex(1))
                If strWJBS = "" Then
                    strErrMsg = "错误：没有当前文件！"
                    GoTo errProc
                End If
                If strFlowTypeName = "" Then
                    strErrMsg = "错误：当前文件类型不明确！"
                    GoTo errProc
                End If

                '创建指定工作流对象
                Dim strType As String
                Dim strName As String
                strType = Josco.JSOA.BusinessFacade.systemFlowObject.getFlowType(strFlowTypeName)
                strName = strFlowTypeName
                objsystemFlowObject = Josco.JSOA.BusinessFacade.systemFlowObject.Create(strType, strName)
                If objsystemFlowObject.doInitialize(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWJBS, False) = False Then
                    GoTo errProc
                End If

                '备份现场参数
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '计算Url
                If Me.m_blnInterface = False Then
                    If objsystemFlowObject.doFileOpen( _
                        strErrMsg, _
                        strControlId, _
                        strWJBS, _
                        strMSessionId, _
                        "", _
                        Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect, _
                        Request, Session, _
                        strUrl) = False Then
                        GoTo errProc
                    End If
                Else
                    strISessionId = Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    If objsystemFlowObject.doFileOpen( _
                        strErrMsg, _
                        strControlId, _
                        strWJBS, _
                        strMSessionId, _
                        strISessionId, _
                        Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect, _
                        Request, Session, _
                        strUrl) = False Then
                        GoTo errProc
                    End If
                End If
                If strUrl <> "" Then
                    Response.Redirect(strUrl)
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            doOpenFile = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function


        '----------------------------------------------------------------
        ' 删除文件
        '     strErrMsg      ：返回错误信息
        '     strControlId   ：当前操作控件ID
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function doDeleteFile( _
            ByRef strErrMsg As String, _
            ByVal strControlId As String) As Boolean

            Dim objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim intStep As Integer

            doDeleteFile = False

            Try
                '检查当前选择
                If Me.grdFILE.SelectedIndex < 0 Then
                    strErrMsg = "错误：没有当前文件！"
                    GoTo errProc
                End If

                '获取文件标识和文件类型
                Dim strFlowTypeName As String
                Dim strWJBS As String
                Dim intColIndex(2) As Integer
                intColIndex(0) = objDataGridProcess.getDataGridColumnIndex(Me.grdFILE, Josco.JsKernal.Common.Data.grswMyTaskData.FIELD_GR_B_MYTASK_FILE_WJBS)
                intColIndex(1) = objDataGridProcess.getDataGridColumnIndex(Me.grdFILE, Josco.JsKernal.Common.Data.grswMyTaskData.FIELD_GR_B_MYTASK_FILE_WJLX)
                strWJBS = objDataGridProcess.getDataGridCellValue(Me.grdFILE.Items(Me.grdFILE.SelectedIndex), intColIndex(0))
                strFlowTypeName = objDataGridProcess.getDataGridCellValue(Me.grdFILE.Items(Me.grdFILE.SelectedIndex), intColIndex(1))
                If strWJBS = "" Then
                    strErrMsg = "错误：没有当前文件！"
                    GoTo errProc
                End If
                If strFlowTypeName = "" Then
                    strErrMsg = "错误：当前文件类型不明确！"
                    GoTo errProc
                End If

                '创建指定工作流对象
                Dim strType As String
                Dim strName As String
                Dim blnDo As Boolean
                strType = Josco.JSOA.BusinessFacade.systemFlowObject.getFlowType(strFlowTypeName)
                strName = strFlowTypeName
                objsystemFlowObject = Josco.JSOA.BusinessFacade.systemFlowObject.Create(strType, strName)
                If objsystemFlowObject.doInitialize(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWJBS, True) = False Then
                    GoTo errProc
                End If

                '便笺特殊处理
                Select Case strType.ToUpper
                    Case Else
                        '是否发送?
                        If objsystemFlowObject.isFileSendOnce(strErrMsg, blnDo) = False Then
                            GoTo errProc
                        End If
                        If blnDo = True Then
                            If objsystemFlowObject.isFileZuofei(strErrMsg, blnDo) = False Then
                                GoTo errProc
                            End If
                            If blnDo = False Then
                                strErrMsg = "错误：文件已经发送，不能删除！"
                                GoTo errProc
                            End If

                            '是否初始人
                            If objsystemFlowObject.isOriginalPeople(strErrMsg, MyBase.UserXM, blnDo) = False Then
                                GoTo errProc
                            End If
                            If blnDo = False Then
                                strErrMsg = "错误：只有初始创建人能删除！"
                                GoTo errProc
                            End If
                        End If
                End Select

                '询问
                intStep = 1
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "警告：一旦删除将无法撤销，确定要删除吗（是/否）？", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '执行删除操作
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '执行操作
                    If objsystemFlowObject.doDeleteFile(strErrMsg, MyBase.UserId, MyBase.UserPassword) = False Then
                        GoTo errProc
                    End If

                    '记录操作审计日志
                    With New Josco.JsKernal.BusinessFacade.systemCustomer
                        .doWriteYonghuCaozuoRizhi(strErrMsg, MyBase.UserId, MyBase.UserPassword, Request.UserHostAddress, Request.UserHostName, "删除了[" + strWJBS + "]的[全部数据]！")
                    End With

                    '显示文件数据
                    If Me.getModuleData_FILE(strErrMsg, Me.m_strQuery_FILE) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_FILE(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '同步显示事宜数据
                    If Me.getModuleData_TASK(strErrMsg, Me.m_strQuery_TASK) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_TASK(strErrMsg) = False Then
                        GoTo errProc
                    End If
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)

            doDeleteFile = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 返回上级
        '     strErrMsg      ：返回错误信息
        '     strControlId   ：当前操作控件ID
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function doClose( _
            ByRef strErrMsg As String, _
            ByVal strControlId As String) As Boolean

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess

            doClose = False

            Try
                '释放模块资源
                Me.releaseModuleParameters()
                Me.releaseInterfaceParameters()

                '返回到欢迎页面
                Dim strUrl As String = Josco.JsKernal.Common.jsoaConfiguration.GeneralReturnUrl
                If strUrl <> "" Then
                    Response.Redirect(strUrl)
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)

            doClose = True
            Exit Function

errProc:
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Function

        End Function


        '----------------------------------------------------------------
        ' 刷新数据
        '     strErrMsg      ：返回错误信息
        '     strControlId   ：当前操作控件ID
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function doRefresh( _
            ByRef strErrMsg As String, _
            ByVal strControlId As String) As Boolean

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess

            doRefresh = False

            Try
                '显示文件数据
                If Me.getModuleData_FILE(strErrMsg, Me.m_strQuery_FILE) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_FILE(strErrMsg) = False Then
                    GoTo errProc
                End If

                '同步显示事宜数据
                If Me.getModuleData_TASK(strErrMsg, Me.m_strQuery_TASK) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_TASK(strErrMsg) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)

            doRefresh = True
            Exit Function
errProc:
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 返回上级
        '     strErrMsg      ：返回错误信息
        '     strControlId   ：当前操作控件ID
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function doZhuanFa(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_RUZHISHENPI_RENYUANXINXI
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objNewData As System.Collections.Specialized.NameValueCollection
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim intStep As Integer = 0
            Dim strWJBS As String = ""
            Dim strWJBT As String = ""

            doZhuanFa = False
            Try
                intStep = 1
                strWJBS = ""

                '检查选择
                Dim intSelect As Integer = 0
                Dim intRows As Integer
                Dim i As Integer
                intRows = Me.grdFILE.Items.Count
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    For i = 0 To intRows - 1 Step 1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdFILE.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_FILE) = True Then
                            intSelect += 1
                        End If
                    Next
                    If intSelect < 1 Then
                        strErrMsg = "错误：未选择要转发的文件！"
                        GoTo errProc
                    End If
                End If

                '提示后回答“是”接着处理
                intStep = 3
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    Dim objDataRow As System.Data.DataRow = Nothing
                    Dim intPos As Integer = 0
                    Dim intColIndex(3) As Integer
                    Dim strFlowTypeName As String

                    '创建缺省数据
                    If Me.m_objDataSet_JSRXX Is Nothing Then
                        Me.m_objDataSet_JSRXX = New Josco.JSOA.Common.Data.FlowData(Josco.JSOA.Common.Data.FlowData.enumTableType.GW_B_VT_WENJIANFASONG)
                    End If

                    '准备数据
                    With Me.m_objDataSet_JSRXX.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_VT_WENJIANFASONG)
                        objDataRow = .NewRow()
                    End With

                    'objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_BLSY) = Josco.JSOA.Common.Workflow.BaseFlowObject.TASK_XGCL

                    Select Case MyBase.UserId
                        '调整-李振；入职-谭颖仪；离职-吴欣霞
                        Case "wenluxi"
                            objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_JSR) = "李振"

                        Case "tanyingyi", _
                                "linjunli"
                            If MyBase.UserId = "tanyingyi" Then
                                objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_JSR) = "吴欣霞"
                            Else
                                objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_JSR) = "谭颖仪"
                            End If
                        Case Else
                            objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_JSR) = "李振"
                    End Select

                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_BLSY) = Josco.JSOA.Common.Workflow.BaseFlowRenshiLiZhi.TASK_LDCL
                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_BLQX) = Now.AddDays(3)
                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_FSR) = MyBase.UserXM
                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_FSRQ) = Now
                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_WJZT) = Josco.JSOA.Common.Workflow.BaseFlowObject.FILEZTLX_DZ
                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_WJZZFS) = 0
                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_WJDZFS) = 1
                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_FJZT) = Josco.JSOA.Common.Workflow.BaseFlowObject.FILEZTLX_DZ
                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_FJZZFS) = 0
                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_FJDZFS) = 1
                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_SYJB) = 0
                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_XB) = Josco.JsKernal.Common.Utilities.PulicParameters.CharFalse
                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_WTR) = ""

                    With Me.m_objDataSet_JSRXX.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_VT_WENJIANFASONG)
                        .Rows.Add(objDataRow)
                    End With
                    'intColIndex(0) = objDataGridProcess.getDataGridColumnIndex(Me.grdFILE, Josco.JsKernal.Common.Data.grswMyTaskData.FIELD_GR_B_MYTASK_FILE_WJBS)
                    'strWJBS = objDataGridProcess.getDataGridCellValue(Me.grdFILE.Items(Me.grdFILE.SelectedIndex), intColIndex(0))

                    intRows = Me.grdFILE.Items.Count

                    For i = intRows - 1 To 0 Step -1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdFILE.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_FILE) = True Then
                            intColIndex(0) = objDataGridProcess.getDataGridColumnIndex(Me.grdFILE, Josco.JsKernal.Common.Data.grswMyTaskData.FIELD_GR_B_MYTASK_FILE_WJBS)
                            intColIndex(1) = objDataGridProcess.getDataGridColumnIndex(Me.grdFILE, Josco.JsKernal.Common.Data.grswMyTaskData.FIELD_GR_B_MYTASK_FILE_WJBT)
                            intColIndex(2) = objDataGridProcess.getDataGridColumnIndex(Me.grdFILE, Josco.JsKernal.Common.Data.grswMyTaskData.FIELD_GR_B_MYTASK_FILE_WJLX)
                            strWJBS = objDataGridProcess.getDataGridCellValue(Me.grdFILE.Items(i), intColIndex(0))
                            strWJBT = objDataGridProcess.getDataGridCellValue(Me.grdFILE.Items(i), intColIndex(1))
                            strFlowTypeName = objDataGridProcess.getDataGridCellValue(Me.grdFILE.Items(i), intColIndex(2))

                            '如果是林俊丽就不能用批量转发人员调整单
                            If MyBase.UserId = "linjunli" Then
                                If strFlowTypeName <> Josco.JSOA.Common.Workflow.BaseFlowRenshiTiaozheng.FLOWNAME Then
                                    If dosend(strErrMsg, strWJBS, strWJBT, strFlowTypeName) = False Then
                                        GoTo errProc
                                    End If
                                End If
                            Else
                                If dosend(strErrMsg, strWJBS, strWJBT, strFlowTypeName) = False Then
                                    GoTo errProc
                                End If
                            End If
                        End If
                    Next
                End If


                '刷新显示
                If Me.doRefresh(strErrMsg, "") = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            doZhuanFa = True

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objNewData)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Exit Function

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objNewData)
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Exit Function

        End Function

        Private Function doAutoReceiveFILE(ByRef strErrMsg As String, ByVal strWJBS As String, ByVal strWJBT As String, ByVal strFlowTypeName As String) As Boolean

            Dim objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject
            Dim blnHasRecevice As Boolean
            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_VT_WENJIANFASONG
            Dim objDataRow As System.Data.DataRow
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strTaskName As String
            Dim intLevel As Integer
            Dim objLastZJBJiaojieDataSet As Josco.JSOA.Common.Data.FlowData
            Dim strAddedJJXHList As String = ""

            doAutoReceiveFILE = False

            Try
                '创建工作流
                If Me.doCreateWorkflow(strErrMsg, strWJBS, strFlowTypeName, objsystemFlowObject) = False Then
                    GoTo errProc
                End If

                ''文件自动接收
                'If objsystemFlowObject.doAutoReceive(strErrMsg, MyBase.UserXM) = False Then
                '    GoTo errProc
                'End If
                If objsystemFlowObject.getCanExecuteCommand(strErrMsg, MyBase.UserId, MyBase.UserXM, MyBase.UserBmdm) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.FlowData.SafeRelease(objLastZJBJiaojieDataSet)
            doAutoReceiveFILE = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.FlowData.SafeRelease(objLastZJBJiaojieDataSet)
            Exit Function

        End Function

        Private Function dosend(ByRef strErrMsg As String, ByVal strWJBS As String, ByVal strWJBT As String, ByVal strFlowTypeName As String) As Boolean

            Dim objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject
            Dim blnHasRecevice As Boolean
            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_VT_WENJIANFASONG
            Dim objDataRow As System.Data.DataRow
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strTaskName As String
            Dim intLevel As Integer
            Dim objLastZJBJiaojieDataSet As Josco.JSOA.Common.Data.FlowData
            Dim strAddedJJXHList As String = ""

            dosend = False

            Try
                '创建工作流
                If Me.doCreateWorkflow(strErrMsg, strWJBS, strFlowTypeName, objsystemFlowObject) = False Then
                    GoTo errProc
                End If

                '文件是否被审批或者被查阅
                If objsystemFlowObject.isHasRecevice(strErrMsg, MyBase.UserXM, blnHasRecevice) = False Then
                    GoTo errProc
                End If
                If blnHasRecevice = False Then
                    strErrMsg = "提示：" + strWJBT + " 还没有被审批或者被查阅，不能转发!!"
                    GoTo errProc
                End If

                With Me.m_objDataSet_JSRXX.Tables(strTable)
                    '获取“办理事宜”
                    strTaskName = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_BLSY), "")
                    strTaskName = strTaskName.ToUpper

                    '计算级别
                    If objsystemFlowObject.getTaskLevel(strErrMsg, strTaskName, intLevel) = False Then
                        GoTo errProc
                    End If

                    '保存信息
                    .Rows(0).Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANFASONG_SYJB) = intLevel
                End With

                Dim intYJJH As Integer = 0
                Dim strBLSY As String = ""
                Dim intDQSYJB As Integer = 0
                '获取当前办理人的最近未办的交接数据
                If objsystemFlowObject.getLastZJBJiaojieData(strErrMsg, MyBase.UserXM, objLastZJBJiaojieDataSet) = False Then
                    GoTo errProc
                End If
                With objLastZJBJiaojieDataSet.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_JIAOJIE)
                    If .Rows.Count > 0 Then
                        intYJJH = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_JJXH), 0)
                        strBLSY = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_BLZL), "")
                    End If
                End With
                If Not (objLastZJBJiaojieDataSet Is Nothing) Then
                    objLastZJBJiaojieDataSet.Dispose()
                    objLastZJBJiaojieDataSet = Nothing
                End If
                If strBLSY <> "" Then
                    If objsystemFlowObject.getTaskLevel(strErrMsg, strBLSY, intDQSYJB) = False Then
                        GoTo errProc
                    End If
                End If

                '获取发送前最大的交接序号
                Dim intMaxJJXH As Integer = 0
                If objsystemFlowObject.getMaxJJXH(strErrMsg, intMaxJJXH) = False Then
                    GoTo errProc
                End If

                '计算发送序号：本批次发送的交接的发送序号一致！
                Dim strFSXH As String = ""
                If objsystemFlowObject.getNewFSXH(strErrMsg, strFSXH, False) = False Then
                    GoTo errProc
                End If

                '发送“交接单”
                If objsystemFlowObject.doSend(strErrMsg, Me.m_objDataSet_JSRXX, strFSXH, intYJJH.ToString, intDQSYJB, strAddedJJXHList) = False Then
                    GoTo errProc
                End If
              
                '设置自己的未办事宜已办完
                If objsystemFlowObject.doSetTaskComplete(strErrMsg, MyBase.UserXM, strAddedJJXHList) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.FlowData.SafeRelease(objLastZJBJiaojieDataSet)
            dosend = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.FlowData.SafeRelease(objLastZJBJiaojieDataSet)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 创建工作流
        '     strErrMsg      ：返回错误信息
        '     strControlId   ：当前操作控件ID
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function doCreateWorkflow( _
            ByRef strErrMsg As String, _
            ByVal strWJBS As String, _
            ByVal strFlowTypeName As String, _
            ByRef objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            Dim strISessionId As String = ""
            Dim strMSessionId As String = ""
            Dim strUrl As String

            doCreateWorkflow = False

            Try
                '获取文件标识和文件类型
                If strWJBS = "" Then
                    strErrMsg = "错误：没有当前文件！"
                    GoTo errProc
                End If
                If strFlowTypeName = "" Then
                    strErrMsg = "错误：当前文件类型不明确！"
                    GoTo errProc
                End If

                '创建指定工作流对象
                Dim strType As String
                Dim strName As String
                strType = Josco.JSOA.BusinessFacade.systemFlowObject.getFlowType(strFlowTypeName)
                strName = strFlowTypeName
                objsystemFlowObject = Josco.JSOA.BusinessFacade.systemFlowObject.Create(strType, strName)
                If objsystemFlowObject.doInitialize(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWJBS, False) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            doCreateWorkflow = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        Private Function getPrintWjbsTZ(ByRef strErrMsg As String, ByRef strWJBS As String, ByVal strFlowTypeName As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_RUZHISHENPI_RENYUANXINXI
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objNewData As System.Collections.Specialized.NameValueCollection
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim intStep As Integer = 0

            getPrintWjbsTZ = False
            Try
                intStep = 1
                strWJBS = ""

                '检查选择
                Dim intSelect As Integer = 0
                Dim intRows As Integer
                Dim i As Integer
                intRows = Me.grdFILE.Items.Count
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    For i = 0 To intRows - 1 Step 1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdFILE.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_FILE) = True Then
                            intSelect += 1
                        End If
                    Next
                    If intSelect < 1 Then
                        strErrMsg = "错误：未选择要打印的数据！"
                        GoTo errProc
                    End If
                End If

                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '提示信息
                    objMessageProcess.doAlertMessage(Me.popMessageObject, "提示：每次只输出6条审批信息！")
                End If

                '提示后回答“是”接着处理
                intStep = 3
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    Dim objDataRow As System.Data.DataRow = Nothing
                    Dim intPos As Integer = 0
                    Dim intColIndex(2) As Integer
                    Dim strWJBS_2 As String
                    Dim strFlowType As String
                    Dim intRow As Integer = 0

                    intRows = Me.grdFILE.Items.Count
                    For i = 0 To intRows - 1 Step 1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdFILE.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_FILE) = True Then
                            intColIndex(0) = objDataGridProcess.getDataGridColumnIndex(Me.grdFILE, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_WJBS)
                            intColIndex(1) = objDataGridProcess.getDataGridColumnIndex(Me.grdFILE, Josco.JsKernal.Common.Data.grswMyTaskData.FIELD_GR_B_MYTASK_FILE_WJLX)
                            strFlowType = objDataGridProcess.getDataGridCellValue(Me.grdFILE.Items(i), intColIndex(1))
                            If intRow < 6 Then
                                intRow = intRow + 1

                                If strFlowType = strFlowTypeName Then
                                    If strWJBS = "" Then
                                        strWJBS = "'" + objDataGridProcess.getDataGridCellValue(Me.grdFILE.Items(i), intColIndex(0)) + "'"
                                    Else
                                        strWJBS = strWJBS + "," + "'" + objDataGridProcess.getDataGridCellValue(Me.grdFILE.Items(i), intColIndex(0)) + "'"
                                    End If
                                End If
                            End If
                        End If
                    Next
                    'While checkPrintWjbsTZ(strErrMsg, strWJBS, intRow, strFlowTypeName) > 6
                    '    If strErrMsg <> "" Then
                    '        GoTo errProc
                    '    End If
                    '    'checkPrintWjbsTZ(strErrMsg, strWJBS, intRow, strFlowTypeName)
                    'End While

                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            getPrintWjbsTZ = True

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objNewData)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Exit Function

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objNewData)
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Exit Function
        End Function

        '        Private Function checkPrintWjbsTZ(ByRef strErrMsg As String, ByRef strWJBS As String, ByRef intRows As Integer, ByVal strFlowTypeName As String) As Integer

        '            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_RUZHISHENPI_RENYUANXINXI
        '            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
        '            Dim objNewData As System.Collections.Specialized.NameValueCollection
        '            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
        '            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
        '            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
        '            Dim intStep As Integer = 0

        '            checkPrintWjbsTZ = 0
        '            Try
        '                Dim intPos As Integer = 0
        '                Dim intColIndex(2) As Integer
        '                Dim strWJBS_2 As String
        '                Dim strFlowType As String
        '                Dim intRow As Integer
        '                Dim intSelect As Integer = 0
        '                Dim i As Integer
        '                Dim strWhere As String = ""

        '                For i = 0 To intRows - 1 Step 1
        '                    If objDataGridProcess.isDataGridItemChecked(Me.grdFILE.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_FILE) = True Then
        '                        intColIndex(0) = objDataGridProcess.getDataGridColumnIndex(Me.grdFILE, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_WJBS)
        '                        intColIndex(1) = objDataGridProcess.getDataGridColumnIndex(Me.grdFILE, Josco.JsKernal.Common.Data.grswMyTaskData.FIELD_GR_B_MYTASK_FILE_WJLX)
        '                        strFlowType = objDataGridProcess.getDataGridCellValue(Me.grdFILE.Items(i), intColIndex(1))
        '                        If strFlowType = strFlowTypeName Then
        '                            If strWJBS = "" Then
        '                                strWJBS = "'" + objDataGridProcess.getDataGridCellValue(Me.grdFILE.Items(i), intColIndex(0)) + "'"
        '                            Else
        '                                strWJBS = strWJBS + "," + "'" + objDataGridProcess.getDataGridCellValue(Me.grdFILE.Items(i), intColIndex(0)) + "'"
        '                            End If
        '                        End If

        '                    End If
        '                Next

        '                strWhere = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_WJBS + " in (" + strWJBS + ")"
        '                If objsystemEstateRenshiXingye.getPrintRyxxData(strErrMsg, MyBase.UserId, MyBase.UserPassword, MyBase.UserXM, strWhere, intRow) = False Then
        '                    GoTo errProc
        '                End If

        '            Catch ex As Exception
        '                strErrMsg = ex.Message
        '                GoTo errProc
        '            End Try

        '            checkPrintWjbsTZ = intRow

        '            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objNewData)
        '            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
        '            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
        '            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
        '            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
        '            Exit Function

        'errProc:
        '            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
        '            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
        '            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
        '            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objNewData)
        '            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
        '            Exit Function
        '        End Function

        Private Function getPrintWjbs(ByRef strErrMsg As String, ByRef strWJBS As String, ByVal strFlowTypeName As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_RUZHISHENPI_RENYUANXINXI
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objNewData As System.Collections.Specialized.NameValueCollection
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim intStep As Integer = 0

            getPrintWjbs = False
            Try
                intStep = 1
                strWJBS = ""

                '检查选择
                Dim intSelect As Integer = 0
                Dim intRows As Integer
                Dim i As Integer
                intRows = Me.grdFILE.Items.Count
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    For i = 0 To intRows - 1 Step 1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdFILE.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_FILE) = True Then
                            intSelect += 1
                        End If
                    Next
                    If intSelect < 1 Then
                        strErrMsg = "错误：未选择要打印的数据！"
                        GoTo errProc
                    End If
                End If

                '提示后回答“是”接着处理
                intStep = 3
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    Dim objDataRow As System.Data.DataRow = Nothing
                    Dim intPos As Integer = 0
                    Dim intColIndex(2) As Integer
                    Dim strWJBS_2 As String
                    Dim strFlowType As String
                    Dim intRow As Integer = 0

                    intRows = Me.grdFILE.Items.Count

                    For i = 0 To intRows - 1 Step 1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdFILE.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_FILE) = True Then
                            intColIndex(0) = objDataGridProcess.getDataGridColumnIndex(Me.grdFILE, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_WJBS)
                            intColIndex(1) = objDataGridProcess.getDataGridColumnIndex(Me.grdFILE, Josco.JsKernal.Common.Data.grswMyTaskData.FIELD_GR_B_MYTASK_FILE_WJLX)
                            strFlowType = objDataGridProcess.getDataGridCellValue(Me.grdFILE.Items(i), intColIndex(1))
                            intRow = intRow + 1
                            If strFlowType = strFlowTypeName Then
                                If strWJBS = "" Then
                                    strWJBS = "'" + objDataGridProcess.getDataGridCellValue(Me.grdFILE.Items(i), intColIndex(0)) + "'"
                                Else
                                    strWJBS = strWJBS + "," + "'" + objDataGridProcess.getDataGridCellValue(Me.grdFILE.Items(i), intColIndex(0)) + "'"
                                End If
                            Else
                                strErrMsg = "提示：选择打印的数据和选择的打印表不匹配，请查证！"
                                GoTo errProc
                            End If
                        End If
                    Next
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            getPrintWjbs = True

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objNewData)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Exit Function

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objNewData)
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Exit Function
        End Function



        Private Function doPrintRUZHI(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_RUZHISHENPI_RENYUANXINXI
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objDateSet As Josco.JSOA.Common.Data.estateRenshiXingyeData
            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject
            Dim strWYBS As String = ""
            Dim strWhere As String

            doPrintRUZHI = False

            Try

                '创建指定工作流对象
                Dim strWJBS As String = ""
                Dim strType As String
                Dim strName As String
                strType = Josco.JSOA.Common.Workflow.BaseFlowRenshiRuZhi.FLOWCODE
                strName = Josco.JSOA.Common.Workflow.BaseFlowRenshiRuZhi.FLOWNAME

                If getPrintWjbs(strErrMsg, strWYBS, strName) = False Then
                    GoTo errProc
                End If

                '获取数据集
                strWhere = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_WJBS + " in (" + strWYBS + ")"
                If objsystemEstateRenshiXingye.getPrintRyxxData(strErrMsg, MyBase.UserId, MyBase.UserPassword, MyBase.UserXM, strWhere, objDateSet) = False Then
                    GoTo errProc
                End If

                If objDateSet.Tables(strTable) Is Nothing Then
                    strErrMsg = "错误：获取数据时出错！"
                    GoTo errProc
                End If
                With objDateSet.Tables(strTable)
                    If .Rows.Count < 1 Then
                        strErrMsg = "错误：没有要输出的数据！"
                        GoTo errProc
                    End If
                End With

                objsystemFlowObject = Josco.JSOA.BusinessFacade.systemFlowObject.Create(strType, strName)
                If objsystemFlowObject.doInitialize(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWJBS, False) = False Then
                    GoTo errProc
                End If

                '检查模版文件
                Dim strMBURL As String = Request.ApplicationPath + Me.m_cstrExcelMBRelativePathToAppRoot + "人事_入职_人员_审批一览表.xls"
                Dim strMBLOC As String = Server.MapPath(strMBURL)
                Dim blnFound As Boolean
                If objBaseLocalFile.doFileExisted(strErrMsg, strMBLOC, blnFound) = False Then
                    GoTo errProc
                End If
                If blnFound = False Then
                    strErrMsg = "错误：[" + strMBLOC + "]不存在！"
                    GoTo errProc
                End If

                '备份模版文件到缓存目录
                Dim strTempPath As String = Request.ApplicationPath + Me.m_cstrPrintCacheRelativePathToAppRoot
                Dim strTempFile As String
                strTempPath = Server.MapPath(strTempPath)
                If objBaseLocalFile.doCopyToTempFile(strErrMsg, strMBLOC, strTempPath, strTempFile) = False Then
                    GoTo errProc
                End If
                Dim strTempSpec As String
                strTempSpec = objBaseLocalFile.doMakePath(strTempPath, strTempFile)

                '输出数据
                Dim strMacroName As String = ""
                Dim strMacroValue As String = ""
                strMacroName = "$Macro$ZZRQ$"
                strMacroValue = Format(Now, "yyyy-MM-dd")

                If objsystemFlowObject.doExportToExcel(strErrMsg, objDateSet, strTempSpec, strMacroName, strMacroValue, "yyyy-MM-dd") = False Then
                    GoTo errProc
                End If

                '显示Excel
               
                Dim strTempUrl As String = Request.ApplicationPath + Me.m_cstrPrintCacheRelativePathToAppRoot + strTempFile
                objMessageProcess.doOpenUrl(Me.popMessageObject, strTempUrl, "_blank", "titlebar=yes,menubar=yes,resizable=yes,scrollbars=yes,status=yes")

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            doPrintRUZHI = True
            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)

            Exit Function

errProc:
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Exit Function

        End Function

        Private Function doPrintNBTZ(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_TIAOZHENG_RENYUANXINXI
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objDateSet As Josco.JSOA.Common.Data.estateRenshiXingyeData
            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject
            Dim strWYBS As String = ""
            Dim strWhere As String
            Dim strTZ As String

            doPrintNBTZ = False

            Try
                Dim strWJBS As String = ""
                Dim strType As String
                Dim strName As String
                strType = Josco.JSOA.Common.Workflow.BaseFlowRenshiTiaozheng.FLOWCODE
                strName = Josco.JSOA.Common.Workflow.BaseFlowRenshiTiaozheng.FLOWNAME

                If getPrintWjbsTZ(strErrMsg, strWYBS, strName) = False Then
                    GoTo errProc
                End If

                '获取数据集
                strWhere = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_WJBS + " in (" + strWYBS + ")"
                If objsystemEstateRenshiXingye.getPrintRyxxData(strErrMsg, MyBase.UserId, MyBase.UserPassword, MyBase.UserXM, strWhere, objDateSet, strTZ) = False Then
                    GoTo errProc
                End If

                If objDateSet.Tables(strTable) Is Nothing Then
                    strErrMsg = "错误：获取数据时出错！"
                    GoTo errProc
                End If
                With objDateSet.Tables(strTable)
                    If .Rows.Count < 1 Then
                        strErrMsg = "错误：没有要输出的数据！"
                        GoTo errProc
                    End If
                End With

                '创建指定工作流对象
                objsystemFlowObject = Josco.JSOA.BusinessFacade.systemFlowObject.Create(strType, strName)
                If objsystemFlowObject.doInitialize(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWJBS, False) = False Then
                    GoTo errProc
                End If

                '检查模版文件
                Dim strMBURL As String = Request.ApplicationPath + Me.m_cstrExcelMBRelativePathToAppRoot + "人事调整人员审批一览表.xls"
                Dim strMBLOC As String = Server.MapPath(strMBURL)
                Dim blnFound As Boolean
                If objBaseLocalFile.doFileExisted(strErrMsg, strMBLOC, blnFound) = False Then
                    GoTo errProc
                End If
                If blnFound = False Then
                    strErrMsg = "错误：[" + strMBLOC + "]不存在！"
                    GoTo errProc
                End If

                '备份模版文件到缓存目录
                Dim strTempPath As String = Request.ApplicationPath + Me.m_cstrPrintCacheRelativePathToAppRoot
                Dim strTempFile As String
                strTempPath = Server.MapPath(strTempPath)
                If objBaseLocalFile.doCopyToTempFile(strErrMsg, strMBLOC, strTempPath, strTempFile) = False Then
                    GoTo errProc
                End If
                Dim strTempSpec As String
                strTempSpec = objBaseLocalFile.doMakePath(strTempPath, strTempFile)

                '输出数据
                If objsystemFlowObject.doExportToExcel(strErrMsg, objDateSet, strTempSpec) = False Then
                    GoTo errProc
                End If

                '显示Excel
                Dim strTempUrl As String = Request.ApplicationPath + Me.m_cstrPrintCacheRelativePathToAppRoot + strTempFile
                objMessageProcess.doOpenUrl(Me.popMessageObject, strTempUrl, "_blank", "titlebar=yes,toolbar=yes,menubar=yes,resizable=yes,scrollbars=yes,status=yes")

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            doPrintNBTZ = True
            Exit Function

errProc:
            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Function

        End Function

        Private Function doPrintSXS(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objDateSet As Josco.JSOA.Common.Data.estateRenshiXingyeData
            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject
            Dim strWYBS As String = ""
            Dim strWhere As String
            Dim intSXS As Integer = 0

            doPrintSXS = False
            Try
                Dim strWJBS As String = ""
                Dim strType As String
                Dim strName As String
                strType = Josco.JSOA.Common.Workflow.BaseFlowRenshiShiXiSheng.FLOWCODE
                strName = Josco.JSOA.Common.Workflow.BaseFlowRenshiShiXiSheng.FLOWNAME

                If getPrintWjbs(strErrMsg, strWYBS, strName) = False Then
                    GoTo errProc
                End If

                '获取数据集
                strWhere = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_WJBS + " in (" + strWYBS + ")"
                If objsystemEstateRenshiXingye.getPrintRyxxData(strErrMsg, MyBase.UserId, MyBase.UserPassword, MyBase.UserXM, strWhere, objDateSet, intSXS) = False Then
                    GoTo errProc
                End If

                If objDateSet.Tables(strTable) Is Nothing Then
                    strErrMsg = "错误：获取数据时出错！"
                    GoTo errProc
                End If
                With objDateSet.Tables(strTable)
                    If .Rows.Count < 1 Then
                        strErrMsg = "错误：没有要输出的数据！"
                        GoTo errProc
                    End If
                End With

                '创建指定工作流对象              
                objsystemFlowObject = Josco.JSOA.BusinessFacade.systemFlowObject.Create(strType, strName)
                If objsystemFlowObject.doInitialize(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWJBS, False) = False Then
                    GoTo errProc
                End If

                '检查模版文件
                Dim strMBURL As String = Request.ApplicationPath + Me.m_cstrExcelMBRelativePathToAppRoot + "人事_实习生_人员_审批一览表.xls"
                Dim strMBLOC As String = Server.MapPath(strMBURL)
                Dim blnFound As Boolean
                If objBaseLocalFile.doFileExisted(strErrMsg, strMBLOC, blnFound) = False Then
                    GoTo errProc
                End If
                If blnFound = False Then
                    strErrMsg = "错误：[" + strMBLOC + "]不存在！"
                    GoTo errProc
                End If

                '备份模版文件到缓存目录
                Dim strTempPath As String = Request.ApplicationPath + Me.m_cstrPrintCacheRelativePathToAppRoot
                Dim strTempFile As String
                strTempPath = Server.MapPath(strTempPath)
                If objBaseLocalFile.doCopyToTempFile(strErrMsg, strMBLOC, strTempPath, strTempFile) = False Then
                    GoTo errProc
                End If
                Dim strTempSpec As String
                strTempSpec = objBaseLocalFile.doMakePath(strTempPath, strTempFile)

                ''输出数据
                'If objsystemFlowObject.doExportToExcel(strErrMsg, objDateSet, strTempSpec) = False Then
                '    GoTo errProc
                'End If

                '输出数据
                Dim strMacroName As String = ""
                Dim strMacroValue As String = ""
                strMacroName = "$Macro$ZZRQ$"
                strMacroValue = Format(Now, "yyyy-MM-dd")

                If objsystemFlowObject.doExportToExcel(strErrMsg, objDateSet, strTempSpec, strMacroName, strMacroValue, "yyyy-MM-dd") = False Then
                    GoTo errProc
                End If

                '显示Excel
                Dim strTempUrl As String = Request.ApplicationPath + Me.m_cstrPrintCacheRelativePathToAppRoot + strTempFile
                objMessageProcess.doOpenUrl(Me.popMessageObject, strTempUrl, "_blank", "titlebar=yes,menubar=yes,resizable=yes,scrollbars=yes,status=yes")

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            doPrintSXS = True
            Exit Function

errProc:
            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Function

        End Function


        Private Function doOpenRUZHI(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
           
            Dim strNewSessionId As String
            Dim strMSessionId As String
            Dim objIEstateRsLuyongMain As Josco.JSOA.BusinessFacade.IEstateRsLuyongMain
            Dim strTable As String = Josco.JsKernal.Common.Data.grswMyTaskData.TABLE_GR_B_MYTASK_FILE

            doOpenRUZHI = False
            Try
                '备份现场参数
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                '准备调用接口
                Dim strUrl As String
                objIEstateRsLuyongMain = New Josco.JSOA.BusinessFacade.IEstateRsLuyongMain
                With objIEstateRsLuyongMain

                    .iSourceControlId = strControlId
                    strUrl = ""
                    strUrl += Request.Url.AbsolutePath
                    strUrl += "?"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                    strUrl += "="
                    strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    strUrl += "&"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                    strUrl += "="
                    strUrl += strMSessionId
                    .iReturnUrl = strUrl
                End With

                '调用模块
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIEstateRsLuyongMain)
                strUrl = ""
                strUrl += "gzsp_rzryList.aspx"
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

            doOpenRUZHI = True
            Exit Function

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Function

        End Function

        Private Function doOpenLIZHI(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess

            Dim strNewSessionId As String
            Dim strMSessionId As String
            Dim objIEstateRsLuyongMain As Josco.JSOA.BusinessFacade.IEstateRsLuyongMain
            Dim strTable As String = Josco.JsKernal.Common.Data.grswMyTaskData.TABLE_GR_B_MYTASK_FILE

            doOpenLIZHI = False
            Try
                '备份现场参数
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                '准备调用接口
                Dim strUrl As String
                objIEstateRsLuyongMain = New Josco.JSOA.BusinessFacade.IEstateRsLuyongMain
                With objIEstateRsLuyongMain

                    .iSourceControlId = strControlId
                    strUrl = ""
                    strUrl += Request.Url.AbsolutePath
                    strUrl += "?"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                    strUrl += "="
                    strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    strUrl += "&"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                    strUrl += "="
                    strUrl += strMSessionId
                    .iReturnUrl = strUrl
                End With

                '调用模块
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIEstateRsLuyongMain)
                strUrl = ""
                strUrl += "gzsp_lzList.aspx"
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

            doOpenLIZHI = True
            Exit Function

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Function

        End Function

        Private Function doOpenNBTZ(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess

            Dim strNewSessionId As String
            Dim strMSessionId As String
            Dim objIEstateRsLuyongMain As Josco.JSOA.BusinessFacade.IEstateRsLuyongMain
            Dim strTable As String = Josco.JsKernal.Common.Data.grswMyTaskData.TABLE_GR_B_MYTASK_FILE

            doOpenNBTZ = False
            Try
                '备份现场参数
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                '准备调用接口
                Dim strUrl As String
                objIEstateRsLuyongMain = New Josco.JSOA.BusinessFacade.IEstateRsLuyongMain
                With objIEstateRsLuyongMain

                    .iSourceControlId = strControlId
                    strUrl = ""
                    strUrl += Request.Url.AbsolutePath
                    strUrl += "?"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                    strUrl += "="
                    strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    strUrl += "&"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                    strUrl += "="
                    strUrl += strMSessionId
                    .iReturnUrl = strUrl
                End With

                '调用模块
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIEstateRsLuyongMain)
                strUrl = ""
                strUrl += "gzsp_nbtzList.aspx"
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

            doOpenNBTZ = True
            Exit Function

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Function

        End Function


        Private Function doOpenSXS(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess

            Dim strNewSessionId As String
            Dim strMSessionId As String
            Dim objIEstateRsLuyongMain As Josco.JSOA.BusinessFacade.IEstateRsLuyongMain
            Dim strTable As String = Josco.JsKernal.Common.Data.grswMyTaskData.TABLE_GR_B_MYTASK_FILE

            doOpenSXS = False
            Try
                '备份现场参数
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "错误：不能保存现场信息！"
                    GoTo errProc
                End If

                '准备调用接口
                '准备调用接口
                Dim strUrl As String
                objIEstateRsLuyongMain = New Josco.JSOA.BusinessFacade.IEstateRsLuyongMain
                With objIEstateRsLuyongMain

                    .iSourceControlId = strControlId
                    strUrl = ""
                    strUrl += Request.Url.AbsolutePath
                    strUrl += "?"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                    strUrl += "="
                    strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    strUrl += "&"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                    strUrl += "="
                    strUrl += strMSessionId
                    .iReturnUrl = strUrl
                End With

                '调用模块
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "错误：不能初始化调用接口！"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIEstateRsLuyongMain)
                strUrl = ""
                strUrl += "gzsp_sxsList.aspx"
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

            doOpenSXS = True
            Exit Function

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Function

        End Function


        Private Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '获取点击菜单
                Dim strMenuId As String = Me.htxtSelectMenuID.Value
                '处理菜单命令
                Select Case strMenuId.ToUpper()
                    Case "mnuNew_RZ".ToUpper()
                        If Me.doNewFile(strErrMsg, "lnkMenu", Josco.JSOA.Common.Workflow.BaseFlowRenshiRuZhi.FLOWNAME) = False Then
                            GoTo errProc
                        End If
                    Case "mnuNew_TZ".ToUpper()
                        If Me.doNewFile(strErrMsg, "lnkMenu", Josco.JSOA.Common.Workflow.BaseFlowRenshiTiaozheng.FLOWNAME) = False Then
                            GoTo errProc
                        End If
                    Case "mnuNew_LZ".ToUpper()
                        If Me.doNewFile(strErrMsg, "lnkMenu", Josco.JSOA.Common.Workflow.BaseFlowRenshiLiZhi.FLOWNAME) = False Then
                            GoTo errProc
                        End If
                    Case "mnuNew_SXS".ToUpper()
                        If Me.doNewFile(strErrMsg, "lnkMenu", Josco.JSOA.Common.Workflow.BaseFlowRenshiShiXiSheng.FLOWNAME) = False Then
                            GoTo errProc
                        End If

                    Case "mnuOpen".ToUpper()
                        If Me.doOpenFile(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If

                    Case "mnuDelete".ToUpper()
                        If Me.doDeleteFile(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If

                    Case "mnuRefresh".ToUpper()
                        If Me.doRefresh(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If

                    Case "mnuClose".ToUpper()
                        If Me.doClose(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If

                    Case "mnuZF".ToUpper()
                        If Me.doZhuanFa(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If

                    Case "mnuPrint_RUZHI".ToUpper()
                        If Me.doPrintRUZHI(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If
                    Case "mnuPrint_NBTZ".ToUpper()
                        If Me.doPrintNBTZ(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If
                    Case "mnuPrint_SXS".ToUpper()
                        If Me.doPrintSXS(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If

                    Case "mnuList_RUZHI".ToUpper()
                        If Me.doOpenRUZHI(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If
                    Case "mnuList_NBTZ".ToUpper()
                        If Me.doOpenNBTZ(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If
                    Case "mnuList_SXS".ToUpper()
                        If Me.doOpenSXS(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If
                    Case "mnuList_LIZHI".ToUpper()
                        If Me.doOpenLIZHI(strErrMsg, "lnkMenu") = False Then
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

        '----------------------------------------------------------------
        ' 初始化工作流对象
        '     strErrMsg                       ：返回错误信息
        '     strWJBS                         ：文件标识
        '     blnFill                         ：填充数据
        '     objsystemFlowObjectRenshiRuZhi ：工作流对象
        ' 返回
        '     True                            ：成功
        '     False                           ：失败
        '----------------------------------------------------------------
        Private Function doInitializeWorkflow( _
            ByRef strErrMsg As String, _
            ByVal strWJBS As String, _
            ByVal blnFill As Boolean, _
            ByRef objsystemFlowObjectRenshiRuZhi As Josco.JSOA.BusinessFacade.systemFlowObjectRenshiRuZhi) As Boolean

            Dim objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject = Nothing

            doInitializeWorkflow = False
            strErrMsg = ""

            Try
                '释放现有资源
                Josco.JSOA.BusinessFacade.systemFlowObjectRenshiRuZhi.SafeRelease(objsystemFlowObjectRenshiRuZhi)

                '创建工作流对象
                Dim strType As String = Josco.JSOA.Common.Workflow.BaseFlowRenshiRuZhi.FLOWCODE
                Dim strName As String = Josco.JSOA.Common.Workflow.BaseFlowRenshiRuZhi.FLOWNAME
                objsystemFlowObject = Josco.JSOA.BusinessFacade.systemFlowObjectRenshiRuZhi.Create(strType, strName)

                '初始化工作流
                If objsystemFlowObject.doInitialize(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWJBS, blnFill) = False Then
                    GoTo errProc
                End If

                '返回
                objsystemFlowObjectRenshiRuZhi = CType(objsystemFlowObject, Josco.JSOA.BusinessFacade.systemFlowObjectRenshiRuZhi)
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            doInitializeWorkflow = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Exit Function

        End Function
    End Class
End Namespace
