Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.web
    ' 类名    ：estate_es_hetongqt_qry
    ' 
    ' 调用性质：
    '     I/O
    '
    ' 功能描述： 
    '   　“其他代办合同信息全屏查询”处理模块
    '
    ' 更改记录：
    '     zengxianglin 2011-01-04 创建
    '----------------------------------------------------------------
    Partial Public Class estate_es_hetongqt_qry
        Inherits Josco.JsKernal.web.PageBase

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
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMEstateEsHetongQtQry
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        '模块接口参数
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IEstateEsHetongQtQry
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '当前处理的数据集
        '----------------------------------------------------------------

        '----------------------------------------------------------------
        '其他参数
        '----------------------------------------------------------------










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
                        Me.m_objInterface = CType(Session(strSessionId), Josco.JSOA.BusinessFacade.IEstateEsHetongQtQry)
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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMEstateEsHetongQtQry

                '保存现场信息
                With Me.m_objSaveScence
                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftMain = Me.htxtDivLeftMain.Value
                    .htxtDivTopMain = Me.htxtDivTopMain.Value
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
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IEstateEsHetongQtQry)
                Catch ex As Exception
                    m_objInterface = Nothing
                End Try
                If m_objInterface Is Nothing Then
                    Me.m_blnInterface = False
                    '没有有接口参数
                    blnContinue = False
                    Me.panelError.Visible = True
                    Me.panelMain.Visible = Not Me.panelError.Visible
                    Me.lblMessage.Text = "错误：没有提供本模块必须的接口！"
                    Exit Try
                Else
                End If
                Me.m_blnInterface = True

                '获取恢复现场参数
                If Me.IsPostBack = False Then
                    Dim strSessionId As String = ""
                    strSessionId = objPulicParameters.getObjectValue(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId), "")
                    Try
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMEstateEsHetongQtQry)
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
        ' 填充所在区域下拉列表框
        '     strErrMsg      ：返回错误信息
        '     objDropDownList：要填充的列表框
        '     blnAddBlank    ：添加空白条目
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function doFillSZQYList( _
            ByRef strErrMsg As String, _
            ByVal objDropDownList As System.Web.UI.WebControls.DropDownList, _
            ByVal blnAddBlank As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateCommonData.TABLE_DC_B_GG_QUYUHUAFEN
            Dim objsystemEstateCommon As New Josco.JSOA.BusinessFacade.systemEstateCommon
            Dim objestateCommonData As Josco.JSOA.Common.Data.estateCommonData = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            doFillSZQYList = False
            strErrMsg = ""

            Try
                '检查
                If objDropDownList Is Nothing Then
                    strErrMsg = "错误：[doFillSZQYList]接口参数不正确！"
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

            doFillSZQYList = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateCommon.SafeRelease(objsystemEstateCommon)
            Josco.JSOA.Common.Data.estateCommonData.SafeRelease(objestateCommonData)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
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
        Private Function doFillWYJGList( _
            ByRef strErrMsg As String, _
            ByVal objDropDownList As System.Web.UI.WebControls.DropDownList, _
            ByVal blnAddBlank As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateCommonData.TABLE_DC_B_GG_WUYEJIANGE
            Dim objsystemEstateCommon As New Josco.JSOA.BusinessFacade.systemEstateCommon
            Dim objestateCommonData As Josco.JSOA.Common.Data.estateCommonData = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            doFillWYJGList = False
            strErrMsg = ""

            Try
                '检查
                If objDropDownList Is Nothing Then
                    strErrMsg = "错误：[doFillWYJGList]接口参数不正确！"
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

            doFillWYJGList = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateCommon.SafeRelease(objsystemEstateCommon)
            Josco.JSOA.Common.Data.estateCommonData.SafeRelease(objestateCommonData)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 填充付款方式下拉列表框
        '     strErrMsg      ：返回错误信息
        '     objDropDownList：要填充的列表框
        '     blnAddBlank    ：添加空白条目
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function doFillFKFSList( _
            ByRef strErrMsg As String, _
            ByVal objDropDownList As System.Web.UI.WebControls.DropDownList, _
            ByVal blnAddBlank As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateCommonData.TABLE_DC_B_GG_YINGSHOUYINGFUMOBAN
            Dim objsystemEstateCommon As New Josco.JSOA.BusinessFacade.systemEstateCommon
            Dim objestateCommonData As Josco.JSOA.Common.Data.estateCommonData = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            doFillFKFSList = False
            strErrMsg = ""

            Try
                '检查
                If objDropDownList Is Nothing Then
                    strErrMsg = "错误：[doFillFKFSList]接口参数不正确！"
                    GoTo errProc
                End If

                '获取数据
                Dim strWhere As String = ""
                If objsystemEstateCommon.getDataSet_YingshouYingfuMoban(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWhere, objestateCommonData) = False Then
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
                        strCode = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_MBDM), "")
                        strName = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_MBMC), "")

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

            doFillFKFSList = True
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
        '     objCheckBoxList   ：要填充的列表框
        '     blnAddBlank       ：添加空白条目
        ' 返回
        '     True              ：成功
        '     False             ：失败
        '----------------------------------------------------------------
        Private Function doFillWYXZList( _
            ByRef strErrMsg As String, _
            ByVal objCheckBoxList As System.Web.UI.WebControls.CheckBoxList, _
            ByVal blnAddBlank As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateCommonData.TABLE_DC_B_GG_WUYEXINGZHI
            Dim objsystemEstateCommon As New Josco.JSOA.BusinessFacade.systemEstateCommon
            Dim objestateCommonData As Josco.JSOA.Common.Data.estateCommonData = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            doFillWYXZList = False
            strErrMsg = ""

            Try
                '检查
                If objCheckBoxList Is Nothing Then
                    strErrMsg = "错误：[doFillWYXZList]接口参数不正确！"
                    GoTo errProc
                End If

                '获取数据
                Dim strWhere As String = ""
                If objsystemEstateCommon.getDataSet_WuyeXingzhi_List(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWhere, objestateCommonData) = False Then
                    GoTo errProc
                End If

                '清空现有列表
                objCheckBoxList.Items.Clear()
                If blnAddBlank = True Then
                    objCheckBoxList.Items.Add("")
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
                        objCheckBoxList.Items.Add(objListItem)
                    Next
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateCommon.SafeRelease(objsystemEstateCommon)
            Josco.JSOA.Common.Data.estateCommonData.SafeRelease(objestateCommonData)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            doFillWYXZList = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateCommon.SafeRelease(objsystemEstateCommon)
            Josco.JSOA.Common.Data.estateCommonData.SafeRelease(objestateCommonData)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 填充职级下拉列表框
        '     strErrMsg      ：返回错误信息
        '     objCheckBoxList：要填充的列表框
        '     blnAddBlank    ：True-加空项
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Private Function doFillZJDMList( _
            ByRef strErrMsg As String, _
            ByVal objCheckBoxList As System.Web.UI.WebControls.CheckBoxList, _
            ByVal blnAddBlank As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_ZHIJIDINGYI
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            doFillZJDMList = False
            strErrMsg = ""

            Try
                '检查
                If objCheckBoxList Is Nothing Then
                    strErrMsg = "错误：[doFillZJDMList]接口参数不正确！"
                    GoTo errProc
                End If

                '获取数据
                Dim strWhere As String = ""
                strWhere = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_ZHIJIDINGYI_JBSZ + " > 0"
                If objsystemEstateRenshiXingye.getDataSet_ZhijiDingyi(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWhere, objestateRenshiXingyeData) = False Then
                    GoTo errProc
                End If

                '清空现有列表
                objCheckBoxList.Items.Clear()
                If blnAddBlank = True Then
                    objCheckBoxList.Items.Add("")
                End If

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
                        objListItem.Text = strName
                        objListItem.Value = strCode
                        objCheckBoxList.Items.Add(objListItem)
                    Next
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objestateRenshiXingyeData)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            doFillZJDMList = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objestateRenshiXingyeData)
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
                    objControlProcess.doTranslateKey(Me.txtQRSH)
                    objControlProcess.doTranslateKey(Me.txtHTBH)
                    objControlProcess.doTranslateKey(Me.txtKYBH)
                    objControlProcess.doTranslateKey(Me.txtDGRQMin)
                    objControlProcess.doTranslateKey(Me.txtDGRQMax)
                    objControlProcess.doTranslateKey(Me.txtHTRQMin)
                    objControlProcess.doTranslateKey(Me.txtHTRQMax)
                    objControlProcess.doTranslateKey(Me.txtTJRQMin)
                    objControlProcess.doTranslateKey(Me.txtTJRQMax)
                    objControlProcess.doTranslateKey(Me.txtJARQMin)
                    objControlProcess.doTranslateKey(Me.txtJARQMax)

                    objControlProcess.doTranslateKey(Me.txtCCDZ)
                    objControlProcess.doTranslateKey(Me.txtCCFMin)
                    objControlProcess.doTranslateKey(Me.txtCCFMax)

                    objControlProcess.doTranslateKey(Me.txtJYZJGMin)
                    objControlProcess.doTranslateKey(Me.txtJYZJGMax)
                    objControlProcess.doTranslateKey(Me.txtJFDLFMin)
                    objControlProcess.doTranslateKey(Me.txtJFDLFMax)
                    objControlProcess.doTranslateKey(Me.txtYFDLFMin)
                    objControlProcess.doTranslateKey(Me.txtYFDLFMax)
                    objControlProcess.doTranslateKey(Me.txtSSYJMin)
                    objControlProcess.doTranslateKey(Me.txtSSYJMax)
                    objControlProcess.doTranslateKey(Me.txtHZYJMin)
                    objControlProcess.doTranslateKey(Me.txtHZYJMax)
                    objControlProcess.doTranslateKey(Me.txtAJFHMin)
                    objControlProcess.doTranslateKey(Me.txtAJFHMax)
                    objControlProcess.doTranslateKey(Me.txtDLFZKMin)
                    objControlProcess.doTranslateKey(Me.txtDLFZKMax)
                    objControlProcess.doTranslateKey(Me.txtAJJG)
                    objControlProcess.doTranslateKey(Me.txtJCRQMin)
                    objControlProcess.doTranslateKey(Me.txtJCRQMax)
                    objControlProcess.doTranslateKey(Me.txtHZJEMin)
                    objControlProcess.doTranslateKey(Me.txtHZJEMax)
                    objControlProcess.doTranslateKey(Me.txtHZRQMin)
                    objControlProcess.doTranslateKey(Me.txtHZRQMax)

                    objControlProcess.doTranslateKey(Me.txtFYBH)
                    objControlProcess.doTranslateKey(Me.txtFCZH)
                    objControlProcess.doTranslateKey(Me.txtFWDZ)
                    objControlProcess.doTranslateKey(Me.txtFCZDZ)
                    objControlProcess.doTranslateKey(Me.txtLP)
                    objControlProcess.doTranslateKey(Me.txtLD)
                    objControlProcess.doTranslateKey(Me.txtDY)
                    objControlProcess.doTranslateKey(Me.ddlSZQY)
                    objControlProcess.doTranslateKey(Me.txtSZQYList)
                    objControlProcess.doTranslateKey(Me.txtMJMin)
                    objControlProcess.doTranslateKey(Me.txtMJMax)
                    objControlProcess.doTranslateKey(Me.txtJCSJMin)
                    objControlProcess.doTranslateKey(Me.txtJCSJMax)
                    objControlProcess.doTranslateKey(Me.txtLLMin)
                    objControlProcess.doTranslateKey(Me.txtLLMax)
                    objControlProcess.doTranslateKey(Me.txtLGMin)
                    objControlProcess.doTranslateKey(Me.txtLGMax)
                    objControlProcess.doTranslateKey(Me.txtDTSLMin)
                    objControlProcess.doTranslateKey(Me.txtDTSLMax)
                    objControlProcess.doTranslateKey(Me.txtLCHSMin)
                    objControlProcess.doTranslateKey(Me.txtLCHSMax)
                    objControlProcess.doTranslateKey(Me.txtLPQSMin)
                    objControlProcess.doTranslateKey(Me.txtLPQSMax)
                    objControlProcess.doTranslateKey(Me.txtJGFSMin)
                    objControlProcess.doTranslateKey(Me.txtJGFSMax)
                    objControlProcess.doTranslateKey(Me.txtLCMin)
                    objControlProcess.doTranslateKey(Me.txtLCMax)
                    objControlProcess.doTranslateKey(Me.txtWSSLMin)
                    objControlProcess.doTranslateKey(Me.txtWSSLMax)
                    objControlProcess.doTranslateKey(Me.txtYTSLMin)
                    objControlProcess.doTranslateKey(Me.txtYTSLMax)
                    objControlProcess.doTranslateKey(Me.txtJYJEMin)
                    objControlProcess.doTranslateKey(Me.txtJYJEMax)
                    objControlProcess.doTranslateKey(Me.ddlJG)
                    objControlProcess.doTranslateKey(Me.txtJGList)

                    objControlProcess.doTranslateKey(Me.txtAJYH)
                    objControlProcess.doTranslateKey(Me.txtAJCSMin)
                    objControlProcess.doTranslateKey(Me.txtAJCSMax)
                    objControlProcess.doTranslateKey(Me.txtAJNXMin)
                    objControlProcess.doTranslateKey(Me.txtAJNXMax)
                    objControlProcess.doTranslateKey(Me.txtJFMC)
                    objControlProcess.doTranslateKey(Me.txtJFDLR)
                    objControlProcess.doTranslateKey(Me.txtJFZZHM)
                    objControlProcess.doTranslateKey(Me.txtJFLXDH)
                    objControlProcess.doTranslateKey(Me.txtYZQN)
                    objControlProcess.doTranslateKey(Me.txtYYQT)
                    objControlProcess.doTranslateKey(Me.txtJFLXDZ)
                    objControlProcess.doTranslateKey(Me.txtYZDY)
                    objControlProcess.doTranslateKey(Me.txtYFMC)
                    objControlProcess.doTranslateKey(Me.txtYFDLR)
                    objControlProcess.doTranslateKey(Me.txtYFZZHM)
                    objControlProcess.doTranslateKey(Me.txtYFLXDH)
                    objControlProcess.doTranslateKey(Me.txtMJQN)
                    objControlProcess.doTranslateKey(Me.txtKYQT)
                    objControlProcess.doTranslateKey(Me.txtYFLXDZ)
                    objControlProcess.doTranslateKey(Me.txtKHDY)

                    objControlProcess.doTranslateKey(Me.txtJYZMJMin)
                    objControlProcess.doTranslateKey(Me.txtJYZMJMax)
                    objControlProcess.doTranslateKey(Me.txtHTFWDZ)
                    objControlProcess.doTranslateKey(Me.ddlFKFS)
                    objControlProcess.doTranslateKey(Me.txtFKFSList)
                    objControlProcess.doTranslateKey(Me.txtJLRQMin)
                    objControlProcess.doTranslateKey(Me.txtJLRQMax)

                    objControlProcess.doTranslateKey(Me.txtBZXX)

                    objControlProcess.doTranslateKey(Me.txtYWRYMC)
                    objControlProcess.doTranslateKey(Me.txtYWBMMC)
                    objControlProcess.doTranslateKey(Me.txtTDBHMin)
                    objControlProcess.doTranslateKey(Me.txtTDBHMax)
                    objControlProcess.doTranslateKey(Me.txtFPBLMin)
                    objControlProcess.doTranslateKey(Me.txtFPBLMax)
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

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim strUrl As String = ""
            Dim blnDo As Boolean = False

            Try
                '预处理
                If MyBase.doPagePreprocess(True, Me.IsPostBack And Me.m_blnSaveScence) = True Then
                    Exit Sub
                End If

                '填充列表
                If Me.IsPostBack = False Then
                    If Me.doFillFKFSList(strErrMsg, Me.ddlFKFS, True) = False Then
                        GoTo errProc
                    End If
                    If Me.doFillWYJGList(strErrMsg, Me.ddlJG, True) = False Then
                        GoTo errProc
                    End If
                    If Me.doFillSZQYList(strErrMsg, Me.ddlSZQY, True) = False Then
                        GoTo errProc
                    End If
                    If Me.doFillWYXZList(strErrMsg, Me.cblWYSX, False) = False Then
                        GoTo errProc
                    End If
                    If Me.doFillZJDMList(strErrMsg, Me.cblYWRYZJ, False) = False Then
                        GoTo errProc
                    End If
                End If

                '获取接口参数
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













        Private Sub ddlSZQY_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSZQY.SelectedIndexChanged
            Try
                If Me.ddlSZQY.SelectedIndex <= 0 Then
                    Me.txtSZQYList.Text = ""
                Else
                    If Me.txtSZQYList.Text.Trim <> "" Then
                        If Me.txtSZQYList.Text.Contains("'" + Me.ddlSZQY.SelectedValue + "'") = False Then
                            Me.txtSZQYList.Text = Me.txtSZQYList.Text.Trim + ",'" + Me.ddlSZQY.SelectedValue + "'"
                        End If
                    Else
                        Me.txtSZQYList.Text = "'" + Me.ddlSZQY.SelectedValue + "'"
                    End If
                End If
            Catch ex As Exception
            End Try
        End Sub

        Private Sub ddlJG_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlJG.SelectedIndexChanged
            Try
                If Me.ddlJG.SelectedIndex <= 0 Then
                    Me.txtJGList.Text = ""
                Else
                    If Me.txtJGList.Text.Trim <> "" Then
                        If Me.txtJGList.Text.Contains("'" + Me.ddlJG.SelectedValue + "'") = False Then
                            Me.txtJGList.Text = Me.txtJGList.Text.Trim + ",'" + Me.ddlJG.SelectedValue + "'"
                        End If
                    Else
                        Me.txtJGList.Text = "'" + Me.ddlJG.SelectedValue + "'"
                    End If
                End If
            Catch ex As Exception
            End Try
        End Sub

        Private Sub ddlFKFS_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlFKFS.SelectedIndexChanged
            Try
                If Me.ddlFKFS.SelectedIndex <= 0 Then
                    Me.txtFKFSList.Text = ""
                Else
                    If Me.txtFKFSList.Text.Trim <> "" Then
                        If Me.txtFKFSList.Text.Contains("'" + Me.ddlFKFS.SelectedValue + "'") = False Then
                            Me.txtFKFSList.Text = Me.txtFKFSList.Text.Trim + ",'" + Me.ddlFKFS.SelectedValue + "'"
                        End If
                    Else
                        Me.txtFKFSList.Text = "'" + Me.ddlFKFS.SelectedValue + "'"
                    End If
                End If
            Catch ex As Exception
            End Try
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

        Private Sub doReset(ByVal strControlId As String)

            Dim objCheckBoxListProcess As New Josco.JsKernal.web.CheckBoxListProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                Me.txtQRSH.Text = ""
                Me.txtHTBH.Text = ""
                Me.txtKYBH.Text = ""
                Me.txtDGRQMin.Text = ""
                Me.txtDGRQMax.Text = ""
                Me.txtHTRQMin.Text = ""
                Me.txtHTRQMax.Text = ""
                Me.txtTJRQMin.Text = ""
                Me.txtTJRQMax.Text = ""
                Me.txtJARQMin.Text = ""
                Me.txtJARQMax.Text = ""
                objCheckBoxListProcess.doNoneSelection(Me.cblHTJA)
                objCheckBoxListProcess.doNoneSelection(Me.cblHTSH)
                objCheckBoxListProcess.doNoneSelection(Me.cblHTLX)
                objCheckBoxListProcess.doNoneSelection(Me.cblHTJC)
                objCheckBoxListProcess.doNoneSelection(Me.cblHTHZ)

                Me.txtCCDZ.Text = ""
                Me.txtCCFMin.Text = ""
                Me.txtCCFMax.Text = ""

                Me.txtJYZJGMin.Text = ""
                Me.txtJYZJGMax.Text = ""
                Me.txtJFDLFMin.Text = ""
                Me.txtJFDLFMax.Text = ""
                Me.txtYFDLFMin.Text = ""
                Me.txtYFDLFMax.Text = ""
                Me.txtSSYJMin.Text = ""
                Me.txtSSYJMax.Text = ""
                Me.txtHZYJMin.Text = ""
                Me.txtHZYJMax.Text = ""
                Me.txtAJFHMin.Text = ""
                Me.txtAJFHMax.Text = ""
                Me.txtDLFZKMin.Text = ""
                Me.txtDLFZKMax.Text = ""
                Me.txtAJJG.Text = ""
                Me.txtJCRQMin.Text = ""
                Me.txtJCRQMax.Text = ""
                Me.txtHZJEMin.Text = ""
                Me.txtHZJEMax.Text = ""
                Me.txtHZRQMin.Text = ""
                Me.txtHZRQMax.Text = ""

                Me.txtFYBH.Text = ""
                Me.txtFCZH.Text = ""
                Me.txtFWDZ.Text = ""
                Me.txtFCZDZ.Text = ""
                Me.txtLP.Text = ""
                Me.txtLD.Text = ""
                Me.txtDY.Text = ""
                Me.ddlSZQY.SelectedIndex = -1
                Me.txtSZQYList.Text = ""
                Me.txtMJMin.Text = ""
                Me.txtMJMax.Text = ""
                Me.txtJCSJMin.Text = ""
                Me.txtJCSJMax.Text = ""
                Me.txtLLMin.Text = ""
                Me.txtLLMax.Text = ""
                objCheckBoxListProcess.doNoneSelection(Me.cblKJLX)
                objCheckBoxListProcess.doNoneSelection(Me.cblFWXZ)
                Me.txtLGMin.Text = ""
                Me.txtLGMax.Text = ""
                Me.txtDTSLMin.Text = ""
                Me.txtDTSLMax.Text = ""
                Me.txtLCHSMin.Text = ""
                Me.txtLCHSMax.Text = ""
                Me.txtLPQSMin.Text = ""
                Me.txtLPQSMax.Text = ""
                objCheckBoxListProcess.doNoneSelection(Me.cblCX)
                objCheckBoxListProcess.doNoneSelection(Me.cblWYSX)
                objCheckBoxListProcess.doNoneSelection(Me.cblZXDC)
                objCheckBoxListProcess.doNoneSelection(Me.cblZXNX)
                objCheckBoxListProcess.doNoneSelection(Me.cblZYYX)
                objCheckBoxListProcess.doNoneSelection(Me.cblJJSB)
                objCheckBoxListProcess.doNoneSelection(Me.cblLYJT)
                objCheckBoxListProcess.doNoneSelection(Me.cblFWJG)
                objCheckBoxListProcess.doNoneSelection(Me.cblJGLX)
                Me.txtJGFSMin.Text = ""
                Me.txtJGFSMax.Text = ""
                Me.txtLCMin.Text = ""
                Me.txtLCMax.Text = ""
                Me.txtWSSLMin.Text = ""
                Me.txtWSSLMax.Text = ""
                Me.txtYTSLMin.Text = ""
                Me.txtYTSLMax.Text = ""
                Me.txtJYJEMin.Text = ""
                Me.txtJYJEMax.Text = ""
                Me.ddlJG.SelectedIndex = -1
                Me.txtJGList.Text = ""

                objCheckBoxListProcess.doNoneSelection(Me.cblFKFSYD)
                Me.txtAJYH.Text = ""
                Me.txtAJCSMin.Text = ""
                Me.txtAJCSMax.Text = ""
                Me.txtAJNXMin.Text = ""
                Me.txtAJNXMax.Text = ""
                Me.txtJFMC.Text = ""
                Me.txtJFDLR.Text = ""
                objCheckBoxListProcess.doNoneSelection(Me.cblJFZJLB)
                Me.txtJFZZHM.Text = ""
                Me.txtJFLXDH.Text = ""
                objCheckBoxListProcess.doNoneSelection(Me.cblYZQC)
                Me.txtYZQN.Text = ""
                objCheckBoxListProcess.doNoneSelection(Me.cblYZLY)
                Me.txtYYQT.Text = ""
                Me.txtJFLXDZ.Text = ""
                Me.txtYZDY.Text = ""
                objCheckBoxListProcess.doNoneSelection(Me.cblSHYX)
                objCheckBoxListProcess.doNoneSelection(Me.cblSYWY)
                Me.txtYFMC.Text = ""
                Me.txtYFDLR.Text = ""
                objCheckBoxListProcess.doNoneSelection(Me.cblYFZJLB)
                Me.txtYFZZHM.Text = ""
                Me.txtYFLXDH.Text = ""
                objCheckBoxListProcess.doNoneSelection(Me.cblMJQC)
                Me.txtMJQN.Text = ""
                objCheckBoxListProcess.doNoneSelection(Me.cblKHLY)
                Me.txtKYQT.Text = ""
                Me.txtYFLXDZ.Text = ""
                Me.txtKHDY.Text = ""
                objCheckBoxListProcess.doNoneSelection(Me.cblGMMD)

                Me.txtJYZMJMin.Text = ""
                Me.txtJYZMJMax.Text = ""
                Me.txtHTFWDZ.Text = ""
                Me.ddlFKFS.SelectedIndex = -1
                Me.txtFKFSList.Text = ""
                objCheckBoxListProcess.doNoneSelection(Me.cblJLRQYD)
                Me.txtJLRQMin.Text = ""
                Me.txtJLRQMax.Text = ""
                objCheckBoxListProcess.doNoneSelection(Me.cblJLZKYD)
                objCheckBoxListProcess.doNoneSelection(Me.cblSFZFYD)
                objCheckBoxListProcess.doNoneSelection(Me.cblTGFKYD)

                Me.txtBZXX.Text = ""

                Me.txtYWRYMC.Text = ""
                Me.txtYWBMMC.Text = ""
                Me.txtTDBHMin.Text = ""
                Me.txtTDBHMax.Text = ""
                objCheckBoxListProcess.doNoneSelection(Me.cblYWRYZJ)
                Me.txtFPBLMin.Text = ""
                Me.txtFPBLMax.Text = ""
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.CheckBoxListProcess.SafeRelease(objCheckBoxListProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.web.CheckBoxListProcess.SafeRelease(objCheckBoxListProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doOK(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strQueryDG As String = ""
            Dim strQueryHT As String = ""
            Dim strQueryDY As String = ""
            Dim strQueryRY As String = ""
            Dim strErrMsg As String = ""

            Try
                Dim strValue As String = ""

                '确认书条件
                '********************************************************************************************************************************************************************************
                If Me.txtQRSH.Text.Trim <> "" Then
                    strValue = objPulicParameters.getNewSearchString(Me.txtQRSH.Text)
                    If strQueryDG = "" Then
                        strQueryDG = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_QRSH + " like '" + strValue + "'"
                    Else
                        strQueryDG = strQueryDG + vbCr + " and " + "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_QRSH + " like '" + strValue + "'"
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If Me.txtKYBH.Text.Trim <> "" Then
                    strValue = objPulicParameters.getNewSearchString(Me.txtKYBH.Text)
                    If strQueryDG = "" Then
                        strQueryDG = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_KYBH + " like '" + strValue + "'"
                    Else
                        strQueryDG = strQueryDG + vbCr + " and " + "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_KYBH + " like '" + strValue + "'"
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringDatetime(strErrMsg, Me.txtDGRQMin, Me.txtDGRQMax, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_DGRQ, strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryDG = "" Then
                        strQueryDG = strValue
                    Else
                        strQueryDG = strQueryDG + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If Me.txtCCDZ.Text.Trim <> "" Then
                    strValue = objPulicParameters.getNewSearchString(Me.txtCCDZ.Text)
                    If strQueryDG = "" Then
                        strQueryDG = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_CCDZ + " like '" + strValue + "'"
                    Else
                        strQueryDG = strQueryDG + vbCr + " and " + "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_CCDZ + " like '" + strValue + "'"
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringFloat(strErrMsg, Me.txtCCFMin, Me.txtCCFMax, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_CCF, strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryDG = "" Then
                        strQueryDG = strValue
                    Else
                        strQueryDG = strQueryDG + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringFloat(strErrMsg, Me.txtJYZJGMin, Me.txtJYZJGMax, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_JYZJG, strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryDG = "" Then
                        strQueryDG = strValue
                    Else
                        strQueryDG = strQueryDG + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringFloat(strErrMsg, Me.txtJFDLFMin, Me.txtJFDLFMax, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_JFDLF, strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryDG = "" Then
                        strQueryDG = strValue
                    Else
                        strQueryDG = strQueryDG + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringFloat(strErrMsg, Me.txtYFDLFMin, Me.txtYFDLFMax, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_YFDLF, strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryDG = "" Then
                        strQueryDG = strValue
                    Else
                        strQueryDG = strQueryDG + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringFloat(strErrMsg, Me.txtSSYJMin, Me.txtSSYJMax, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_SSYJ, strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryDG = "" Then
                        strQueryDG = strValue
                    Else
                        strQueryDG = strQueryDG + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringFloat(strErrMsg, Me.txtHZYJMin, Me.txtHZYJMax, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_HZYJ, strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryDG = "" Then
                        strQueryDG = strValue
                    Else
                        strQueryDG = strQueryDG + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringFloat(strErrMsg, Me.txtDLFZKMin, Me.txtDLFZKMax, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_DLFZK + " * 100.0", strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryDG = "" Then
                        strQueryDG = strValue
                    Else
                        strQueryDG = strQueryDG + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If Me.txtAJJG.Text.Trim <> "" Then
                    strValue = objPulicParameters.getNewSearchString(Me.txtAJJG.Text)
                    If strQueryDG = "" Then
                        strQueryDG = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_AJJG + " like '" + strValue + "'"
                    Else
                        strQueryDG = strQueryDG + vbCr + " and " + "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_AJJG + " like '" + strValue + "'"
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If Me.txtAJYH.Text.Trim <> "" Then
                    strValue = objPulicParameters.getNewSearchString(Me.txtAJYH.Text)
                    If strQueryDG = "" Then
                        strQueryDG = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_AJYH + " like '" + strValue + "'"
                    Else
                        strQueryDG = strQueryDG + vbCr + " and " + "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_AJYH + " like '" + strValue + "'"
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If Me.txtJFMC.Text.Trim <> "" Then
                    strValue = objPulicParameters.getNewSearchString(Me.txtJFMC.Text)
                    If strQueryDG = "" Then
                        strQueryDG = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_JFMC + " like '" + strValue + "'"
                    Else
                        strQueryDG = strQueryDG + vbCr + " and " + "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_JFMC + " like '" + strValue + "'"
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If Me.txtJFDLR.Text.Trim <> "" Then
                    strValue = objPulicParameters.getNewSearchString(Me.txtJFDLR.Text)
                    If strQueryDG = "" Then
                        strQueryDG = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_JFDLR + " like '" + strValue + "'"
                    Else
                        strQueryDG = strQueryDG + vbCr + " and " + "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_JFDLR + " like '" + strValue + "'"
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If Me.txtJFZZHM.Text.Trim <> "" Then
                    strValue = objPulicParameters.getNewSearchString(Me.txtJFZZHM.Text)
                    If strQueryDG = "" Then
                        strQueryDG = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_JFZZHM + " like '" + strValue + "'"
                    Else
                        strQueryDG = strQueryDG + vbCr + " and " + "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_JFZZHM + " like '" + strValue + "'"
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If Me.txtJFLXDH.Text.Trim <> "" Then
                    strValue = objPulicParameters.getNewSearchString(Me.txtJFLXDH.Text)
                    If strQueryDG = "" Then
                        strQueryDG = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_JFLXDH + " like '" + strValue + "'"
                    Else
                        strQueryDG = strQueryDG + vbCr + " and " + "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_JFLXDH + " like '" + strValue + "'"
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If Me.txtYZQN.Text.Trim <> "" Then
                    strValue = objPulicParameters.getNewSearchString(Me.txtYZQN.Text)
                    If strQueryDG = "" Then
                        strQueryDG = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_YZQN + " like '" + strValue + "'"
                    Else
                        strQueryDG = strQueryDG + vbCr + " and " + "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_YZQN + " like '" + strValue + "'"
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If Me.txtYYQT.Text.Trim <> "" Then
                    strValue = objPulicParameters.getNewSearchString(Me.txtYYQT.Text)
                    If strQueryDG = "" Then
                        strQueryDG = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_YYQT + " like '" + strValue + "'"
                    Else
                        strQueryDG = strQueryDG + vbCr + " and " + "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_YYQT + " like '" + strValue + "'"
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If Me.txtJFLXDZ.Text.Trim <> "" Then
                    strValue = objPulicParameters.getNewSearchString(Me.txtJFLXDZ.Text)
                    If strQueryDG = "" Then
                        strQueryDG = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_JFLXDZ + " like '" + strValue + "'"
                    Else
                        strQueryDG = strQueryDG + vbCr + " and " + "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_JFLXDZ + " like '" + strValue + "'"
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If Me.txtYZDY.Text.Trim <> "" Then
                    strValue = objPulicParameters.getNewSearchString(Me.txtYZDY.Text)
                    If strQueryDG = "" Then
                        strQueryDG = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_YZDY + " like '" + strValue + "'"
                    Else
                        strQueryDG = strQueryDG + vbCr + " and " + "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_YZDY + " like '" + strValue + "'"
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If Me.txtYFMC.Text.Trim <> "" Then
                    strValue = objPulicParameters.getNewSearchString(Me.txtYFMC.Text)
                    If strQueryDG = "" Then
                        strQueryDG = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_YFMC + " like '" + strValue + "'"
                    Else
                        strQueryDG = strQueryDG + vbCr + " and " + "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_YFMC + " like '" + strValue + "'"
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If Me.txtYFDLR.Text.Trim <> "" Then
                    strValue = objPulicParameters.getNewSearchString(Me.txtYFDLR.Text)
                    If strQueryDG = "" Then
                        strQueryDG = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_YFDLR + " like '" + strValue + "'"
                    Else
                        strQueryDG = strQueryDG + vbCr + " and " + "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_YFDLR + " like '" + strValue + "'"
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If Me.txtYFZZHM.Text.Trim <> "" Then
                    strValue = objPulicParameters.getNewSearchString(Me.txtYFZZHM.Text)
                    If strQueryDG = "" Then
                        strQueryDG = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_YFZZHM + " like '" + strValue + "'"
                    Else
                        strQueryDG = strQueryDG + vbCr + " and " + "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_YFZZHM + " like '" + strValue + "'"
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If Me.txtYFLXDH.Text.Trim <> "" Then
                    strValue = objPulicParameters.getNewSearchString(Me.txtYFLXDH.Text)
                    If strQueryDG = "" Then
                        strQueryDG = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_YFLXDH + " like '" + strValue + "'"
                    Else
                        strQueryDG = strQueryDG + vbCr + " and " + "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_YFLXDH + " like '" + strValue + "'"
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If Me.txtMJQN.Text.Trim <> "" Then
                    strValue = objPulicParameters.getNewSearchString(Me.txtMJQN.Text)
                    If strQueryDG = "" Then
                        strQueryDG = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_MJQN + " like '" + strValue + "'"
                    Else
                        strQueryDG = strQueryDG + vbCr + " and " + "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_MJQN + " like '" + strValue + "'"
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If Me.txtKYQT.Text.Trim <> "" Then
                    strValue = objPulicParameters.getNewSearchString(Me.txtKYQT.Text)
                    If strQueryDG = "" Then
                        strQueryDG = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_KYQT + " like '" + strValue + "'"
                    Else
                        strQueryDG = strQueryDG + vbCr + " and " + "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_KYQT + " like '" + strValue + "'"
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If Me.txtYFLXDZ.Text.Trim <> "" Then
                    strValue = objPulicParameters.getNewSearchString(Me.txtYFLXDZ.Text)
                    If strQueryDG = "" Then
                        strQueryDG = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_YFLXDZ + " like '" + strValue + "'"
                    Else
                        strQueryDG = strQueryDG + vbCr + " and " + "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_YFLXDZ + " like '" + strValue + "'"
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If Me.txtKHDY.Text.Trim <> "" Then
                    strValue = objPulicParameters.getNewSearchString(Me.txtKHDY.Text)
                    If strQueryDG = "" Then
                        strQueryDG = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_KHDY + " like '" + strValue + "'"
                    Else
                        strQueryDG = strQueryDG + vbCr + " and " + "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_KHDY + " like '" + strValue + "'"
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringFloat(strErrMsg, Me.txtAJCSMin, Me.txtAJCSMax, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_AJCS, strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryDG = "" Then
                        strQueryDG = strValue
                    Else
                        strQueryDG = strQueryDG + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringFloat(strErrMsg, Me.txtAJNXMin, Me.txtAJNXMax, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_AJNX, strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryDG = "" Then
                        strQueryDG = strValue
                    Else
                        strQueryDG = strQueryDG + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringFloat(strErrMsg, Me.txtJYZMJMin, Me.txtJYZMJMax, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_JYZMJ, strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryDG = "" Then
                        strQueryDG = strValue
                    Else
                        strQueryDG = strQueryDG + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If Me.txtHTFWDZ.Text.Trim <> "" Then
                    strValue = objPulicParameters.getNewSearchString(Me.txtHTFWDZ.Text)
                    If strQueryDG = "" Then
                        strQueryDG = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_FWDZ + " like '" + strValue + "'"
                    Else
                        strQueryDG = strQueryDG + vbCr + " and " + "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_FWDZ + " like '" + strValue + "'"
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringDatetime(strErrMsg, Me.txtJLRQMin, Me.txtJLRQMax, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_JHJLRQ, strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryDG = "" Then
                        strQueryDG = strValue
                    Else
                        strQueryDG = strQueryDG + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringList(strErrMsg, Me.cblTGFKYD, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_FKTGYD, 0, strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryDG = "" Then
                        strQueryDG = strValue
                    Else
                        strQueryDG = strQueryDG + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringList(strErrMsg, Me.cblSFZFYD, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_SFZFYD, 0, strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryDG = "" Then
                        strQueryDG = strValue
                    Else
                        strQueryDG = strQueryDG + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringList(strErrMsg, Me.cblJLZKYD, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_JLZKYD, 0, strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryDG = "" Then
                        strQueryDG = strValue
                    Else
                        strQueryDG = strQueryDG + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringList(strErrMsg, Me.cblJLRQYD, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_JLRQYD, 0, strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryDG = "" Then
                        strQueryDG = strValue
                    Else
                        strQueryDG = strQueryDG + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringList(strErrMsg, Me.cblGMMD, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_GMMD, "", strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryDG = "" Then
                        strQueryDG = strValue
                    Else
                        strQueryDG = strQueryDG + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringList(strErrMsg, Me.cblKHLY, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_KHLY, "", strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryDG = "" Then
                        strQueryDG = strValue
                    Else
                        strQueryDG = strQueryDG + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringList(strErrMsg, Me.cblMJQC, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_MJQC, "", strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryDG = "" Then
                        strQueryDG = strValue
                    Else
                        strQueryDG = strQueryDG + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringList(strErrMsg, Me.cblYFZJLB, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_YFZJLX, 0, strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryDG = "" Then
                        strQueryDG = strValue
                    Else
                        strQueryDG = strQueryDG + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringList(strErrMsg, Me.cblJFZJLB, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_JFZJLX, 0, strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryDG = "" Then
                        strQueryDG = strValue
                    Else
                        strQueryDG = strQueryDG + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringList(strErrMsg, Me.cblSYWY, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_SYWY, "", strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryDG = "" Then
                        strQueryDG = strValue
                    Else
                        strQueryDG = strQueryDG + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringList(strErrMsg, Me.cblSHYX, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_SHYX, "", strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryDG = "" Then
                        strQueryDG = strValue
                    Else
                        strQueryDG = strQueryDG + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringList(strErrMsg, Me.cblYZLY, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_YZLY, "", strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryDG = "" Then
                        strQueryDG = strValue
                    Else
                        strQueryDG = strQueryDG + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringList(strErrMsg, Me.cblYZQC, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_YZQC, "", strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryDG = "" Then
                        strQueryDG = strValue
                    Else
                        strQueryDG = strQueryDG + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringList(strErrMsg, Me.cblFKFSYD, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_FKFSYD, 0, strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryDG = "" Then
                        strQueryDG = strValue
                    Else
                        strQueryDG = strQueryDG + vbCr + " and " + strValue
                    End If
                End If


                '合同条件
                '********************************************************************************************************************************************************************************
                If Me.txtHTBH.Text.Trim <> "" Then
                    strValue = objPulicParameters.getNewSearchString(Me.txtHTBH.Text)
                    If strQueryHT = "" Then
                        strQueryHT = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_HTBH + " like '" + strValue + "'"
                    Else
                        strQueryHT = strQueryHT + vbCr + " and " + "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_HTBH + " like '" + strValue + "'"
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringDatetime(strErrMsg, Me.txtHTRQMin, Me.txtHTRQMax, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_HTRQ, strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryHT = "" Then
                        strQueryHT = strValue
                    Else
                        strQueryHT = strQueryHT + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringDatetime(strErrMsg, Me.txtTJRQMin, Me.txtTJRQMax, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_TJRQ, strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryHT = "" Then
                        strQueryHT = strValue
                    Else
                        strQueryHT = strQueryHT + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringDatetime(strErrMsg, Me.txtJARQMin, Me.txtJARQMax, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JARQ, strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryHT = "" Then
                        strQueryHT = strValue
                    Else
                        strQueryHT = strQueryHT + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringFloat(strErrMsg, Me.txtAJFHMin, Me.txtAJFHMax, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_AJFH, strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryHT = "" Then
                        strQueryHT = strValue
                    Else
                        strQueryHT = strQueryHT + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringDatetime(strErrMsg, Me.txtJCRQMin, Me.txtJCRQMax, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JCRQ, strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryHT = "" Then
                        strQueryHT = strValue
                    Else
                        strQueryHT = strQueryHT + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringDatetime(strErrMsg, Me.txtHZRQMin, Me.txtHZRQMax, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_HZRQ, strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryHT = "" Then
                        strQueryHT = strValue
                    Else
                        strQueryHT = strQueryHT + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringFloat(strErrMsg, Me.txtHZJEMin, Me.txtHZJEMax, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_HZJE, strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryHT = "" Then
                        strQueryHT = strValue
                    Else
                        strQueryHT = strQueryHT + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If Me.txtBZXX.Text.Trim <> "" Then
                    strValue = objPulicParameters.getNewSearchString(Me.txtBZXX.Text)
                    If strQueryHT = "" Then
                        strQueryHT = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BZXX + " like '" + strValue + "'"
                    Else
                        strQueryHT = strQueryHT + vbCr + " and " + "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BZXX + " like '" + strValue + "'"
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringList(strErrMsg, Me.cblHTLX, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_HTLX, 0, strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryHT = "" Then
                        strQueryHT = strValue
                    Else
                        strQueryHT = strQueryHT + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If Me.txtFKFSList.Text.Trim <> "" Then
                    strValue = Me.txtFKFSList.Text.Trim
                    If strQueryHT = "" Then
                        strQueryHT = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FKFS + " in (" + strValue + ")"
                    Else
                        strQueryHT = strQueryHT + vbCr + " and " + "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FKFS + " in (" + strValue + ")"
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringList(strErrMsg, Me.cblHTJA, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_HTZT + " & 0x2", 0, strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryHT = "" Then
                        strQueryHT = strValue
                    Else
                        strQueryHT = strQueryHT + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringList(strErrMsg, Me.cblHTSH, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_HTZT + " & 0x1", 0, strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryHT = "" Then
                        strQueryHT = strValue
                    Else
                        strQueryHT = strQueryHT + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringList(strErrMsg, Me.cblHTJC, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_HTBZ + " & 0x1", 0, strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryHT = "" Then
                        strQueryHT = strValue
                    Else
                        strQueryHT = strQueryHT + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringList(strErrMsg, Me.cblHTHZ, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_HTBZ + " & 0x2", 0, strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryHT = "" Then
                        strQueryHT = strValue
                    Else
                        strQueryHT = strQueryHT + vbCr + " and " + strValue
                    End If
                End If

                '物业条件
                '********************************************************************************************************************************************************************************
                If Me.txtFYBH.Text.Trim <> "" Then
                    strValue = objPulicParameters.getNewSearchString(Me.txtFYBH.Text)
                    If strQueryDY = "" Then
                        strQueryDY = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_FYBH + " like '" + strValue + "'"
                    Else
                        strQueryDY = strQueryDY + vbCr + " and " + "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_FYBH + " like '" + strValue + "'"
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If Me.txtFCZH.Text.Trim <> "" Then
                    strValue = objPulicParameters.getNewSearchString(Me.txtFCZH.Text)
                    If strQueryDY = "" Then
                        strQueryDY = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_FCZH + " like '" + strValue + "'"
                    Else
                        strQueryDY = strQueryDY + vbCr + " and " + "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_FCZH + " like '" + strValue + "'"
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If Me.txtFWDZ.Text.Trim <> "" Then
                    strValue = objPulicParameters.getNewSearchString(Me.txtFWDZ.Text)
                    If strQueryDY = "" Then
                        strQueryDY = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_FWDZ + " like '" + strValue + "'"
                    Else
                        strQueryDY = strQueryDY + vbCr + " and " + "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_FWDZ + " like '" + strValue + "'"
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If Me.txtFCZDZ.Text.Trim <> "" Then
                    strValue = objPulicParameters.getNewSearchString(Me.txtFCZDZ.Text)
                    If strQueryDY = "" Then
                        strQueryDY = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_FCZDZ + " like '" + strValue + "'"
                    Else
                        strQueryDY = strQueryDY + vbCr + " and " + "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_FCZDZ + " like '" + strValue + "'"
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If Me.txtLP.Text.Trim <> "" Then
                    strValue = objPulicParameters.getNewSearchString(Me.txtLP.Text)
                    If strQueryDY = "" Then
                        strQueryDY = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_LP + " like '" + strValue + "'"
                    Else
                        strQueryDY = strQueryDY + vbCr + " and " + "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_LP + " like '" + strValue + "'"
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If Me.txtLD.Text.Trim <> "" Then
                    strValue = objPulicParameters.getNewSearchString(Me.txtLD.Text)
                    If strQueryDY = "" Then
                        strQueryDY = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_LD + " like '" + strValue + "'"
                    Else
                        strQueryDY = strQueryDY + vbCr + " and " + "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_LD + " like '" + strValue + "'"
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If Me.txtDY.Text.Trim <> "" Then
                    strValue = objPulicParameters.getNewSearchString(Me.txtDY.Text)
                    If strQueryDY = "" Then
                        strQueryDY = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_DY + " like '" + strValue + "'"
                    Else
                        strQueryDY = strQueryDY + vbCr + " and " + "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_DY + " like '" + strValue + "'"
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringFloat(strErrMsg, Me.txtMJMin, Me.txtMJMax, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_MJ, strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryDY = "" Then
                        strQueryDY = strValue
                    Else
                        strQueryDY = strQueryDY + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringDatetime(strErrMsg, Me.txtJCSJMin, Me.txtJCSJMax, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_JCSJ, strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryDY = "" Then
                        strQueryDY = strValue
                    Else
                        strQueryDY = strQueryDY + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringInteger(strErrMsg, Me.txtLLMin, Me.txtLLMax, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_LL, strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryDY = "" Then
                        strQueryDY = strValue
                    Else
                        strQueryDY = strQueryDY + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringInteger(strErrMsg, Me.txtLGMin, Me.txtLGMax, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_LG, strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryDY = "" Then
                        strQueryDY = strValue
                    Else
                        strQueryDY = strQueryDY + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringInteger(strErrMsg, Me.txtDTSLMin, Me.txtDTSLMax, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_DTSL, strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryDY = "" Then
                        strQueryDY = strValue
                    Else
                        strQueryDY = strQueryDY + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringInteger(strErrMsg, Me.txtLCHSMin, Me.txtLCHSMax, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_LCHS, strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryDY = "" Then
                        strQueryDY = strValue
                    Else
                        strQueryDY = strQueryDY + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringInteger(strErrMsg, Me.txtLPQSMin, Me.txtLPQSMax, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_LPQS, strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryDY = "" Then
                        strQueryDY = strValue
                    Else
                        strQueryDY = strQueryDY + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringInteger(strErrMsg, Me.txtJGFSMin, Me.txtJGFSMax, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_JGFS, strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryDY = "" Then
                        strQueryDY = strValue
                    Else
                        strQueryDY = strQueryDY + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringInteger(strErrMsg, Me.txtLCMin, Me.txtLCMax, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_LC, strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryDY = "" Then
                        strQueryDY = strValue
                    Else
                        strQueryDY = strQueryDY + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringInteger(strErrMsg, Me.txtWSSLMin, Me.txtWSSLMax, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_WSSL, strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryDY = "" Then
                        strQueryDY = strValue
                    Else
                        strQueryDY = strQueryDY + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringInteger(strErrMsg, Me.txtYTSLMin, Me.txtYTSLMax, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_YTSL, strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryDY = "" Then
                        strQueryDY = strValue
                    Else
                        strQueryDY = strQueryDY + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringFloat(strErrMsg, Me.txtJYJEMin, Me.txtJYJEMax, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_JYJE, strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryDY = "" Then
                        strQueryDY = strValue
                    Else
                        strQueryDY = strQueryDY + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringList(strErrMsg, Me.cblJGLX, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_JGLX, "", strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryDY = "" Then
                        strQueryDY = strValue
                    Else
                        strQueryDY = strQueryDY + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringList(strErrMsg, Me.cblFWJG, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_FWJG, "", strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryDY = "" Then
                        strQueryDY = strValue
                    Else
                        strQueryDY = strQueryDY + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringList(strErrMsg, Me.cblLYJT, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_LYJT, "", strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryDY = "" Then
                        strQueryDY = strValue
                    Else
                        strQueryDY = strQueryDY + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringList(strErrMsg, Me.cblJJSB, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_JJSB, "", strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryDY = "" Then
                        strQueryDY = strValue
                    Else
                        strQueryDY = strQueryDY + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringList(strErrMsg, Me.cblZYYX, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_ZYYX, "", strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryDY = "" Then
                        strQueryDY = strValue
                    Else
                        strQueryDY = strQueryDY + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringList(strErrMsg, Me.cblZXNX, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_ZXNX, "", strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryDY = "" Then
                        strQueryDY = strValue
                    Else
                        strQueryDY = strQueryDY + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringList(strErrMsg, Me.cblZXDC, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_ZXDC, "", strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryDY = "" Then
                        strQueryDY = strValue
                    Else
                        strQueryDY = strQueryDY + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringList(strErrMsg, Me.cblWYSX, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_WYXZ, "", strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryDY = "" Then
                        strQueryDY = strValue
                    Else
                        strQueryDY = strQueryDY + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringList(strErrMsg, Me.cblCX, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_ZX, "", strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryDY = "" Then
                        strQueryDY = strValue
                    Else
                        strQueryDY = strQueryDY + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringList(strErrMsg, Me.cblFWXZ, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_FWXZ, "", strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryDY = "" Then
                        strQueryDY = strValue
                    Else
                        strQueryDY = strQueryDY + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringList(strErrMsg, Me.cblKJLX, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_KJLX, "", strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryDY = "" Then
                        strQueryDY = strValue
                    Else
                        strQueryDY = strQueryDY + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If Me.txtSZQYList.Text.Trim <> "" Then
                    strValue = Me.txtSZQYList.Text.Trim
                    If strQueryDY = "" Then
                        strQueryDY = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_SZQY + " in (" + strValue + ")"
                    Else
                        strQueryDY = strQueryDY + vbCr + " and " + "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_SZQY + " in (" + strValue + ")"
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If Me.txtJGList.Text.Trim <> "" Then
                    strValue = Me.txtJGList.Text.Trim
                    If strQueryDY = "" Then
                        strQueryDY = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_JG + " in (" + strValue + ")"
                    Else
                        strQueryDY = strQueryDY + vbCr + " and " + "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_QT_JG + " in (" + strValue + ")"
                    End If
                End If

                '业务员条件
                '********************************************************************************************************************************************************************************
                If Me.txtYWRYMC.Text.Trim <> "" Then
                    strValue = objPulicParameters.getNewSearchString(Me.txtYWRYMC.Text)
                    If strQueryRY = "" Then
                        strQueryRY = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYMC + " like '" + strValue + "'"
                    Else
                        strQueryRY = strQueryRY + vbCr + " and " + "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYMC + " like '" + strValue + "'"
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If Me.txtYWBMMC.Text.Trim <> "" Then
                    strValue = objPulicParameters.getNewSearchString(Me.txtYWBMMC.Text)
                    If strQueryRY = "" Then
                        strQueryRY = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_DWMC + " like '" + strValue + "'"
                    Else
                        strQueryRY = strQueryRY + vbCr + " and " + "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_DWMC + " like '" + strValue + "'"
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringInteger(strErrMsg, Me.txtTDBHMin, Me.txtTDBHMax, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_TDBH, strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryRY = "" Then
                        strQueryRY = strValue
                    Else
                        strQueryRY = strQueryRY + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringFloat(strErrMsg, Me.txtFPBLMin, Me.txtFPBLMax, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_FPBL + " * 100.0", strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryRY = "" Then
                        strQueryRY = strValue
                    Else
                        strQueryRY = strQueryRY + vbCr + " and " + strValue
                    End If
                End If
                '********************************************************************************************************************************************************************************
                If objControlProcess.getQueryStringList(strErrMsg, Me.cblYWRYZJ, "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYZJ, "", strValue) = False Then
                    GoTo errProc
                End If
                If strValue <> "" Then
                    If strQueryRY = "" Then
                        strQueryRY = strValue
                    Else
                        strQueryRY = strQueryRY + vbCr + " and " + strValue
                    End If
                End If

                '返回条件
                Dim strSessionId As String = ""
                Dim strUrl As String = ""
                If Me.m_blnInterface = True Then
                    '设置返回参数
                    With Me.m_objInterface
                        .oExitMode = True
                        .oQuery_DG = strQueryDG
                        .oQuery_HT = strQueryHT
                        .oQuery_DY = strQueryDY
                        .oQuery_RY = strQueryRY
                    End With
                    '返回到调用模块，并附加返回参数
                    strSessionId = Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
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

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
            Me.doClose("btnClose")
        End Sub

        Private Sub btnReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReset.Click
            Me.doReset("btnReset")
        End Sub

        Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
            Me.doOK("btnOK")
        End Sub

    End Class

End Namespace
