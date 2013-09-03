<%@ Page Language="vb" AutoEventWireup="false" Codebehind="estate_rs_renyuanjiagou_bdls.aspx.vb" Inherits="Josco.JSOA.web.estate_rs_renyuanjiagou_bdls" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
    <HEAD>
        <title>人员管理架构变动历史查看窗(模式一)</title>
        <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
        <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
        <meta content="JavaScript" name="vs_defaultClientScript">
        <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <LINK href="../../../stylesw.css" type="text/css" rel="stylesheet">
        <script src="../../../scripts/transkey.js"></script>
        <script language="vb" runat="server">
			'zengxianglin 2009-05-13
			'职级代码调整以及增加职级[中级区域经理][初级区域行政助理]
			'zengxianglin 2009-05-13
			'zengxainglin 2008-11-18
			'重新编写
			'定义序列信息
			Public Const m_cintSeries As Integer = 5 '0-总监,1-区经,2-营经,3-业经,4-顾问,5-文员
			Public Const m_cintTabNo_BBCS As Integer = 0
			Public Const m_cintTabNo_SYSJ As Integer = 1
			Public Const m_cintTabNo_YWJL As Integer = 2
			Public Const m_cintTabNo_YYJL As Integer = 3
			Public Const m_cintTabNo_QYJL As Integer = 4
			Public Const m_cintTabNo_QYZJ As Integer = 5
			Public Const m_cintTabNo_GLJG As Integer = 6
			Public Const m_cintTabNo_ZLJG As Integer = 7
			Public Const m_cintTabNo_DWXX As Integer = 8
			Public m_intSeriesMaxColumns(m_cintSeries) As Integer
			Public m_intMaxRows As Integer
			Public m_intMaxCols As Integer
			'报表用的数据
			Public m_objDataSetBB As System.Data.DataSet = Nothing
			'初始化标志
			Public m_blnInitialized As Boolean = False
			'定义检查时间
			Public m_objTime As System.DateTime
			'准备报表数据
			Public Function doPrepareData() As Boolean
				Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
				Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
				Dim strErrMsg As String = ""
				Try
					'按新时间计算
					Me.m_objTime = propJCSJ
					'不用重新计算
					If Me.m_blnInitialized = True Then
						Exit Try
					End If
					'计算数据
					Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(Me.m_objDataSetBB)
					If objsystemEstateRenshiXingye.getDataSet_RYJG(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_objTime.ToString("yyyy-MM-dd"), Me.m_objDataSetBB) = False Then
						Exit Try
					End If
					'填充序列的最大列数
					If Not (Me.m_objDataSetBB.Tables(Me.m_cintTabNo_BBCS) Is Nothing) Then
						With Me.m_objDataSetBB.Tables(Me.m_cintTabNo_BBCS)
							m_intSeriesMaxColumns(0) = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_VT_RS_RYJG_BBCS_QYZJLS), 1)
							m_intSeriesMaxColumns(1) = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_VT_RS_RYJG_BBCS_QYJLLS), 1)
							m_intSeriesMaxColumns(2) = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_VT_RS_RYJG_BBCS_YYJLLS), 1)
							m_intSeriesMaxColumns(3) = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_VT_RS_RYJG_BBCS_YWJLLS), 1)
							m_intSeriesMaxColumns(4) = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_VT_RS_RYJG_BBCS_WYGWLS), 1)
							m_intSeriesMaxColumns(5) = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_VT_RS_RYJG_BBCS_XZZLLS), 1)
							m_intMaxRows = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_VT_RS_RYJG_BBCS_BBHS), 1)
							m_intMaxCols = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_VT_RS_RYJG_BBCS_BBLS), 1)
						End With
					End If
					'标记已初始化
					Me.m_blnInitialized = True
					doPrepareData = True
				Catch ex As Exception
					doPrepareData = False
				End Try
				Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
				Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
			End Function
			'计算单元格的style信息
			Public Function getCellStyle(ByVal strZJDM As String, ByVal intXGRY As Integer, ByVal intRYZT As Integer, ByVal intSFZB As Integer) As String
				Try
					Dim strUnderLine As String = ""
					Dim strColor As String = ""
					Select Case strZJDM
						'*********************
						'区域总监级
						Case "010.010.010"
							strColor = "Red"
						Case "010.010.020"
							strColor = "Fuchsia"
						Case "010.010.030"
							strColor = "Pink"

						'*********************
						'区域经理级
						Case "010.020.010"
							strColor = "Teal"
						Case "010.020.020"
							strColor = "Lime"
						Case "010.020.025"
							strColor = "Chartreuse"
						Case "010.020.030"
							strColor = "LightGreen"

						'*********************
						'营业经理级
						Case "010.030.010"
							strColor = "Silver"
						Case "010.030.020"
							strColor = "Blue"
						Case "010.030.030"
							strColor = "DeepSkyBlue"
						Case "010.030.040"
							strColor = "LightBlue"
						Case "010.030.050"
							strColor = "LightCyan"
							
						'*********************
						'物业顾问级
						Case "020.010.010"
							strColor = "DarkKhaki"
						Case "020.010.020"
							strColor = "YellowGreen"
						Case "020.010.030"
							strColor = "Orange"
						Case "020.010.040"
							strColor = "white"
							
						'*********************
						'行政助理级
						Case "030.010.010"
							strColor = "PowderBlue"
						Case "030.010.015"
							strColor = "CornflowerBlue"
						Case "030.010.020"
							strColor = "LightSkyBlue"
						Case "030.010.030"
							strColor = "LightSteelBlue"
						Case "030.010.040"
							strColor = "Plum"

						'*********************
						Case Else
							strColor = "white"
					End Select
					If intXGRY = 1 Then
						strColor = "white"
					End If
					If intXGRY = 0 And intSFZB = 0 Then
						strColor = "white"
					End If
					If (intRYZT And 3) = 1 Then
						strUnderLine = "underline"
					End If
					getCellStyle = "BACKGROUND-COLOR: " + strColor + ";"
					If strUnderLine <> "" Then
						getCellStyle = getCellStyle + "TEXT-DECORATION: " + strUnderLine + ";"
					End If
				Catch ex As Exception
					getCellStyle = "BACKGROUND-COLOR: white;"
				End Try
			End Function
			'计算人员所属序列(1,2,3,4,5,6)
			Public Function getSeriesNo(ByVal strZJDM As String) As Integer
				Try
					Select Case strZJDM
						'*********************
						'区域总监级
						Case "010.010.010"
							getSeriesNo = 1
						Case "010.010.020"
							getSeriesNo = 1
						Case "010.010.030"
							getSeriesNo = 1
							
						'*********************
						'区域经理级
						Case "010.020.010"
							getSeriesNo = 2
						Case "010.020.020"
							getSeriesNo = 2
						Case "010.020.025"
							getSeriesNo = 2
						Case "010.020.030"
							getSeriesNo = 2

						'*********************
						'营业经理级
						Case "010.030.010"
							getSeriesNo = 3
						Case "010.030.020"
							getSeriesNo = 3
						Case "010.030.030"
							getSeriesNo = 3
						Case "010.030.040"
							getSeriesNo = 3
						Case "010.030.050"
							getSeriesNo = 4

						'*********************
						'物业顾问级
						Case "020.010.010"
							getSeriesNo = 5
						Case "020.010.020"
							getSeriesNo = 5
						Case "020.010.030"
							getSeriesNo = 5
						Case "020.010.040"
							getSeriesNo = 5

						'*********************
						'行政助理级
						Case "030.010.010"
							getSeriesNo = 6
						Case "030.010.015"
							getSeriesNo = 6
						Case "030.010.020"
							getSeriesNo = 6
						Case "030.010.030"
							getSeriesNo = 6
						Case "030.010.040"
							getSeriesNo = 6
							
						'*********************
						Case Else
							getSeriesNo = 5
					End Select
				Catch ex As Exception
					getSeriesNo = 5
				End Try
			End Function
			'计算单元格的style信息
			Public Function getNewCellValue(ByVal strValue As String, ByVal intXGRY As Integer, ByVal intSFZB As Integer, ByVal strDQDW As String, ByVal strZGDW As String) As String
				Try
					If (intXGRY = 1) Or (intXGRY = 0 And intSFZB = 0) Then
						getNewCellValue = strValue + "*"
					Else
						getNewCellValue = strValue
					End If
					If strZGDW <> "" Then
						If strZGDW = strDQDW Then
							getNewCellValue = "@" + getNewCellValue
						End If
					End If
				Catch ex As Exception
					getNewCellValue = strValue
				End Try
			End Function
			'显示输出处理
			Public Sub doDisplayData()
				Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
				Dim strErrMsg As String = ""
				Try
					'初始化
					If doPrepareData() = False Then
						Exit Try
					End If
					If Me.m_objDataSetBB Is Nothing Then
						Exit Try
					End If
					If Me.m_objDataSetBB.Tables.Count < 9 Then
						Exit Try
					End If
					Dim intDataCols As Integer = Me.m_intMaxCols
					Dim strBorderStyle As String = "BORDER-RIGHT: black 1px solid; BORDER-TOP: black 1px solid; BORDER-LEFT: black 1px solid; BORDER-BOTTOM: black 1px solid;"
					Response.Write("<TABLE cellSpacing='0' cellPadding='0' border='0' style='" + strBorderStyle + "'>" + vbCr)
					'输出表头
					Response.Write("  <tr height='36' bgcolor='#99cccc'>" + vbCr)
					Response.Write("    <td style='" + strBorderStyle + "' align='center'><b>序号</b></td>" + vbCr)
					Response.Write("    <td style='" + strBorderStyle + "' align='center' width='160'><b>分行</b></td>" + vbCr)
					If m_intSeriesMaxColumns(0) > 1 Then
						Response.Write("    <td style='" + strBorderStyle + "' align='center' colspan='" + Me.m_intSeriesMaxColumns(0).ToString + "'><b>总监</b></td>" + vbCr)
					Else
						Response.Write("    <td style='" + strBorderStyle + "' align='center'><b>总监</b></td>" + vbCr)
					End If
					If m_intSeriesMaxColumns(1) > 1 Then
						Response.Write("    <td style='" + strBorderStyle + "' align='center' colspan='" + Me.m_intSeriesMaxColumns(1).ToString + "'><b>区经</b></td>" + vbCr)
					Else
						Response.Write("    <td style='" + strBorderStyle + "' align='center'><b>区经</b></td>" + vbCr)
					End If
					If m_intSeriesMaxColumns(2) > 1 Then
						Response.Write("    <td style='" + strBorderStyle + "' align='center' colspan='" + Me.m_intSeriesMaxColumns(2).ToString + "'><b>营经</b></td>" + vbCr)
					Else
						Response.Write("    <td style='" + strBorderStyle + "' align='center'><b>营经</b></td>" + vbCr)
					End If
					If m_intSeriesMaxColumns(3) > 1 Then
						Response.Write("    <td style='" + strBorderStyle + "' align='center' colspan='" + Me.m_intSeriesMaxColumns(3).ToString + "'><b>业经</b></td>" + vbCr)
					Else
						Response.Write("    <td style='" + strBorderStyle + "' align='center'><b>业经</b></td>" + vbCr)
					End If
					If m_intSeriesMaxColumns(4) > 1 Then
						Response.Write("    <td style='" + strBorderStyle + "' align='center' colspan='" + Me.m_intSeriesMaxColumns(4).ToString + "'><b>物业顾问</b></td>" + vbCr)
					Else
						Response.Write("    <td style='" + strBorderStyle + "' align='center'><b>物业顾问</b></td>" + vbCr)
					End If
					If m_intSeriesMaxColumns(5) > 1 Then
						Response.Write("    <td style='" + strBorderStyle + "' align='center' colspan='" + Me.m_intSeriesMaxColumns(5).ToString + "'><b>文员</b></td>" + vbCr)
					Else
						Response.Write("    <td style='" + strBorderStyle + "' align='center'><b>文员</b></td>" + vbCr)
					End If
					Response.Write("    <td style='" + strBorderStyle + "' align='center'><b>计划<br>编制</b></td>" + vbCr)
					Response.Write("    <td style='" + strBorderStyle + "' align='center'><b>实际<br>编制</b></td>" + vbCr)
					Response.Write("  </tr>" + vbCr)
					'输出数据
					Dim strSep As String = Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate
					Dim strStyles(intDataCols + 4 - 1) As String '0开始
					Dim strValues(intDataCols + 4 - 1) As String '0开始
					Dim strSeriesTotal(m_cintSeries) As String   '序列计数人(逗号分隔)
					Dim intSeriesTotal(m_cintSeries) As Integer  '序列汇总数
					Dim intSeriesPtr(m_cintSeries) As Integer    '序列指针
					Dim intTotalJHBZ As Integer = 0
					Dim intTotalSJBZ As Integer = 0
					Dim intCountA As Integer = 0
					Dim intCountB As Integer = 0
					Dim intXGRY As Integer = 0
					Dim intRYZT As Integer = 0
					Dim intSFZB As Integer = 0
					Dim strDQDWOld As String = ""
					Dim strDQDW As String = ""
					Dim strDQRY As String = ""
					Dim intRows As Integer
					Dim strZGDW As String = ""
					Dim strZJDM As String = ""
					Dim strRYZM As String = ""
					Dim strSSDW As String = ""
					Dim strRYDM As String = ""
					Dim strTEMP As String = ""
					Dim intNo As Integer = 0
					Dim intTNo As Integer
					Dim i As Integer = 0
					Dim j As Integer = 0
					Dim k As Integer = 0
					With Me.m_objDataSetBB.Tables(Me.m_cintTabNo_SYSJ)
						For i = 0 To intSeriesTotal.Length - 1 Step 1
							intSeriesTotal(i) = 0
						Next
						For i = 0 To strSeriesTotal.Length - 1 Step 1
							strSeriesTotal(i) = ""
						Next
						intCountA = .Rows.Count
						For i = 0 To intCountA - 1 Step 1
							'初始化序列指针
							intSeriesPtr(0) = 2
							intSeriesPtr(1) = intSeriesPtr(0) + m_intSeriesMaxColumns(0)
							intSeriesPtr(2) = intSeriesPtr(1) + m_intSeriesMaxColumns(1)
							intSeriesPtr(3) = intSeriesPtr(2) + m_intSeriesMaxColumns(2)
							intSeriesPtr(4) = intSeriesPtr(3) + m_intSeriesMaxColumns(3)
							intSeriesPtr(5) = intSeriesPtr(4) + m_intSeriesMaxColumns(4)
							'初始化所有序列值
							For j = 0 To strValues.Length - 1 Step 1
								strValues(j) = ""
							Next
							For j = 0 To strStyles.Length - 1 Step 1
								strStyles(j) = ""
							Next
							'获取当前行的索引数据
							strDQDW = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_VT_RS_RYJG_SYSJ_SSDW), "")
							strDQRY = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_VT_RS_RYJG_SYSJ_RYDM), "")
							intRows = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_VT_RS_RYJG_SYSJ_DWHS), 1)
							'计算当前行的单位数据
							With Me.m_objDataSetBB.Tables(Me.m_cintTabNo_DWXX)
								.DefaultView.RowFilter = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RENYUANJIAGOU_DW_SSDW + " = '" + strDQDW + "'"
								If .DefaultView.Count > 0 Then
									strValues(0) = objPulicParameters.getObjectValue(.DefaultView.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RENYUANJIAGOU_DW_DWXH), "")
									strValues(1) = objPulicParameters.getObjectValue(.DefaultView.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RENYUANJIAGOU_DW_DWMC), "")
									If strDQDWOld <> strDQDW Then
										j = objPulicParameters.getObjectValue(.DefaultView.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RENYUANJIAGOU_DW_BZRS), 0)
										strValues(strValues.Length - 2) = j.ToString()
										intTotalJHBZ += j
									End If
									If strDQDWOld <> strDQDW Then
										j = objPulicParameters.getObjectValue(.DefaultView.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RENYUANJIAGOU_DW_SJBZ), 0)
										strValues(strValues.Length - 1) = j.ToString()
										intTotalSJBZ += j
									End If
								End If
							End With
							'计算当前行的总监、区经、营经、业经的数据
							For k = 0 To 3 Step 1
								Select Case k
									Case 0
										'计算当前行的总监数据
										intTNo = Me.m_cintTabNo_QYZJ
									Case 1
										'计算当前行的区经数据
										intTNo = Me.m_cintTabNo_QYJL
									Case 2
										'计算当前行的营经数据
										intTNo = Me.m_cintTabNo_YYJL
									Case 3
										'计算当前行的业经数据
										intTNo = Me.m_cintTabNo_YWJL
								End Select
								With Me.m_objDataSetBB.Tables(intTNo)
									.DefaultView.RowFilter = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_VT_RS_RYJG_XLSJ_SSDW + " = '" + strDQDW + "' and " + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_VT_RS_RYJG_XLSJ_RYDM + " = '" + strDQRY + "'"
									intCountB = .DefaultView.Count
									For j = 0 To intCountB - 1 Step 1
										strRYDM = objPulicParameters.getObjectValue(.DefaultView.Item(j).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_VT_RS_RYJG_XLSJ_SJLD), "")
										With Me.m_objDataSetBB.Tables(Me.m_cintTabNo_GLJG)
											.DefaultView.RowFilter = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_RYDM + " = '" + strRYDM + "'"
											If (.DefaultView.Count > 0) Then
												strSSDW = ""
												strSSDW = objPulicParameters.getObjectValue(.DefaultView.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_SSDW), "")
												strZGDW = ""
												strZGDW = objPulicParameters.getObjectValue(.DefaultView.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_ZGDW), "")
												strZJDM = ""
												strZJDM = objPulicParameters.getObjectValue(.DefaultView.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_ZJDM), "")
												strRYZM = ""
												strRYZM = objPulicParameters.getObjectValue(.DefaultView.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_RYMC), "")
												intRYZT = 0
												intRYZT = objPulicParameters.getObjectValue(.DefaultView.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_RYZT), 0)
												intSFZB = 0
												intSFZB = objPulicParameters.getObjectValue(.DefaultView.Item(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_SFZB), 0)
												If strSSDW = strDQDW Then
													intXGRY = 0
												Else
													intXGRY = 1
												End If
												'计算所属序列
												intNo = Me.getSeriesNo(strZJDM)
												'设置序列项值
												strValues(intSeriesPtr(intNo - 1)) = getNewCellValue(strRYZM, intXGRY, intSFZB, strDQDW, strZGDW)
												strStyles(intSeriesPtr(intNo - 1)) = getCellStyle(strZJDM, intXGRY, intRYZT, intSFZB)
												'指针移动
												intSeriesPtr(intNo - 1) += 1
												'序列项汇总
												If (intXGRY = 0) Then
													If (intSFZB = 1) Then
														If strSeriesTotal(intNo - 1) = "" Then
															intSeriesTotal(intNo - 1) = intSeriesTotal(intNo - 1) + 1
															strSeriesTotal(intNo - 1) = strRYDM
														Else
															strTEMP = strSep + strSeriesTotal(intNo - 1) + strSep
															If strTEMP.IndexOf(strSep + strRYDM + strSep) < 0 Then
																intSeriesTotal(intNo - 1) = intSeriesTotal(intNo - 1) + 1
																strSeriesTotal(intNo - 1) = strSeriesTotal(intNo - 1) + strSep + strRYDM
															End If
														End If
													End If
												End If
											End If
										End With
									Next
								End With
							Next
							'计算当前行的物业顾问数据
							With Me.m_objDataSetBB.Tables(Me.m_cintTabNo_GLJG)
								.DefaultView.RowFilter = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_SSDW + " = '" + strDQDW + "' and " + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_SJLD + " = '" + strDQRY + "' and " + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_ZJDM + " like '020.%'"
								intCountB = .DefaultView.Count
								For j = 0 To intCountB - 1 Step 1
									strRYDM = objPulicParameters.getObjectValue(.DefaultView.Item(j).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_RYDM), "")
									strSSDW = ""
									strSSDW = objPulicParameters.getObjectValue(.DefaultView.Item(j).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_SSDW), "")
									strZGDW = ""
									strZGDW = objPulicParameters.getObjectValue(.DefaultView.Item(j).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_ZGDW), "")
									strZJDM = ""
									strZJDM = objPulicParameters.getObjectValue(.DefaultView.Item(j).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_ZJDM), "")
									strRYZM = ""
									strRYZM = objPulicParameters.getObjectValue(.DefaultView.Item(j).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_RYMC), "")
									intRYZT = 0
									intRYZT = objPulicParameters.getObjectValue(.DefaultView.Item(j).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_RYZT), 0)
									intSFZB = 0
									intSFZB = objPulicParameters.getObjectValue(.DefaultView.Item(j).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GUANLIJIAGOU_SFZB), 0)
									If strSSDW = strDQDW Then
										intXGRY = 0
									Else
										intXGRY = 1
									End If
									'计算所属序列
									intNo = Me.getSeriesNo(strZJDM)
									'设置序列项值
									strValues(intSeriesPtr(intNo - 1)) = getNewCellValue(strRYZM, intXGRY, intSFZB, strDQDW, strZGDW)
									strStyles(intSeriesPtr(intNo - 1)) = getCellStyle(strZJDM, intXGRY, intRYZT, intSFZB)
									'指针移动
									intSeriesPtr(intNo - 1) += 1
									'序列项汇总
									If (intXGRY = 0) Then
										If (intSFZB = 1) Then
											If strSeriesTotal(intNo - 1) = "" Then
												intSeriesTotal(intNo - 1) = intSeriesTotal(intNo - 1) + 1
												strSeriesTotal(intNo - 1) = strRYDM
											Else
												strTEMP = strSep + strSeriesTotal(intNo - 1) + strSep
												If strTEMP.IndexOf(strSep + strRYDM + strSep) < 0 Then
													intSeriesTotal(intNo - 1) = intSeriesTotal(intNo - 1) + 1
													strSeriesTotal(intNo - 1) = strSeriesTotal(intNo - 1) + strSep + strRYDM
												End If
											End If
										End If
									End If
								Next
							End With
							'计算当前行的行政助理数据
							With Me.m_objDataSetBB.Tables(Me.m_cintTabNo_ZLJG)
								.DefaultView.RowFilter = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_ZHULIJIAGOU_SSDW + " = '" + strDQDW + "'"
								intCountB = .DefaultView.Count
								For j = 0 To intCountB - 1 Step 1
									strRYDM = objPulicParameters.getObjectValue(.DefaultView.Item(j).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_ZHULIJIAGOU_RYDM), "")
									strSSDW = ""
									strSSDW = objPulicParameters.getObjectValue(.DefaultView.Item(j).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_ZHULIJIAGOU_SSDW), "")
									strZGDW = ""
									strZJDM = ""
									strZJDM = objPulicParameters.getObjectValue(.DefaultView.Item(j).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_ZHULIJIAGOU_ZJDM), "")
									strRYZM = ""
									strRYZM = objPulicParameters.getObjectValue(.DefaultView.Item(j).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_ZHULIJIAGOU_RYMC), "")
									intRYZT = 0
									intRYZT = objPulicParameters.getObjectValue(.DefaultView.Item(j).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_ZHULIJIAGOU_RYZT), 0)
									intSFZB = 0
									intSFZB = objPulicParameters.getObjectValue(.DefaultView.Item(j).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_ZHULIJIAGOU_SFZB), 0)
									If strSSDW = strDQDW Then
										intXGRY = 0
									Else
										intXGRY = 1
									End If
									'计算所属序列
									intNo = Me.getSeriesNo(strZJDM)
									'设置序列项值
									strValues(intSeriesPtr(intNo - 1)) = getNewCellValue(strRYZM, intXGRY, intSFZB, strDQDW, strZGDW)
									strStyles(intSeriesPtr(intNo - 1)) = getCellStyle(strZJDM, intXGRY, intRYZT, intSFZB)
									'指针移动
									intSeriesPtr(intNo - 1) += 1
									'序列项汇总
									If (intXGRY = 0) Then
										If (intSFZB = 1) Then
											If strSeriesTotal(intNo - 1) = "" Then
												intSeriesTotal(intNo - 1) = intSeriesTotal(intNo - 1) + 1
												strSeriesTotal(intNo - 1) = strRYDM
											Else
												strTEMP = strSep + strSeriesTotal(intNo - 1) + strSep
												If strTEMP.IndexOf(strSep + strRYDM + strSep) < 0 Then
													intSeriesTotal(intNo - 1) = intSeriesTotal(intNo - 1) + 1
													strSeriesTotal(intNo - 1) = strSeriesTotal(intNo - 1) + strSep + strRYDM
												End If
											End If
										End If
									End If
								Next
							End With
							'输入本行数据
							For j = 0 To strValues.Length - 1 Step 1
								If strStyles(j) Is Nothing Then strStyles(j) = ""
								strStyles(j) = strStyles(j) + strBorderStyle + "FONT-SIZE: 12px; FONT-FAMILY: 宋体;"
								If strValues(j) Is Nothing Then strValues(j) = ""
								If strValues(j) = "" Then strValues(j) = "&nbsp;"
							Next
							Response.Write("  <tr height='24' valign='middle'>" + vbCr)
							For j = 0 To strValues.Length - 1 Step 1
								Select Case j
									Case 0, 1
										'[单位序号][单位名称]
										If intRows > 1 Then
											If strDQDW <> strDQDWOld Then
												If strStyles(j) = "" Then
													Response.Write("    <td align='center' rowspan='" + intRows.ToString + "'>" + strValues(j) + "</td>" + vbCr)
												Else
													Response.Write("    <td align='center' rowspan='" + intRows.ToString + "' style='" + strStyles(j) + "'>" + strValues(j) + "</td>" + vbCr)
												End If
											End If
										Else
											If strStyles(j) = "" Then
												Response.Write("    <td align='center'>" + strValues(j) + "</td>" + vbCr)
											Else
												Response.Write("    <td align='center' style='" + strStyles(j) + "'>" + strValues(j) + "</td>" + vbCr)
											End If
										End If
									Case strValues.Length - 2, strValues.Length - 1
										'[计划编制][实际编制]
										If intRows > 1 Then
											If strDQDW <> strDQDWOld Then
												If strStyles(j) = "" Then
													Response.Write("    <td align='right' rowspan='" + intRows.ToString + "'>" + strValues(j) + "</td>" + vbCr)
												Else
													Response.Write("    <td align='right' rowspan='" + intRows.ToString + "' style='" + strStyles(j) + "'>" + strValues(j) + "</td>" + vbCr)
												End If
											End If
										Else
											If strStyles(j) = "" Then
												Response.Write("    <td align='right'>" + strValues(j) + "</td>" + vbCr)
											Else
												Response.Write("    <td align='right' style='" + strStyles(j) + "'>" + strValues(j) + "</td>" + vbCr)
											End If
										End If
									Case Else
										If (j >= strValues.Length - 2 - m_intSeriesMaxColumns(5)) and (j < strValues.Length - 2)
											'zengxianglin 2009-05-14
											'行政助理特殊处理
											If intRows > 1 Then
												If strDQDW <> strDQDWOld Then
													If strStyles(j) = "" Then
														Response.Write("    <td align='center' width='80' rowspan='" + intRows.ToString + "'>" + strValues(j) + "</td>" + vbCr)
													Else
														Response.Write("    <td align='center' width='80' rowspan='" + intRows.ToString + "' style='" + strStyles(j) + "'>" + strValues(j) + "</td>" + vbCr)
													End If
												End If
											Else
												If strStyles(j) = "" Then
													Response.Write("    <td align='center' width='80'>" + strValues(j) + "</td>" + vbCr)
												Else
													Response.Write("    <td align='center' width='80' style='" + strStyles(j) + "'>" + strValues(j) + "</td>" + vbCr)
												End If
											End If
											'zengxianglin 2009-05-14
										Else
											If strStyles(j) = "" Then
												Response.Write("    <td align='center' width='80'>" + strValues(j) + "</td>" + vbCr)
											Else
												Response.Write("    <td align='center' width='80' style='" + strStyles(j) + "'>" + strValues(j) + "</td>" + vbCr)
											End If
										End If
								End Select
							Next
							Response.Write("  </tr>" + vbCr)
							'更换当前单位
							strDQDWOld = strDQDW
						Next
					End With
					'输出汇总
					Response.Write("  <tr height='36' bgcolor='#99cccc'>" + vbCr)
					Response.Write("    <td style='" + strBorderStyle + "' align='center' width='60'><b>总计</b></td>" + vbCr)
					Response.Write("    <td style='" + strBorderStyle + "' align='center' width='160'>&nbsp;</td>" + vbCr)
					If m_intSeriesMaxColumns(0) > 1 Then
						Response.Write("    <td style='" + strBorderStyle + "' align='right' colspan='" + m_intSeriesMaxColumns(0).ToString + "'><b>" + intSeriesTotal(0).ToString + "</b></td>" + vbCr)
					Else
						Response.Write("    <td style='" + strBorderStyle + "' align='right'><b>" + intSeriesTotal(0).ToString + "</b></td>" + vbCr)
					End If
					If m_intSeriesMaxColumns(1) > 1 Then
						Response.Write("    <td style='" + strBorderStyle + "' align='right' colspan='" + m_intSeriesMaxColumns(1).ToString + "'><b>" + intSeriesTotal(1).ToString + "</b></td>" + vbCr)
					Else
						Response.Write("    <td style='" + strBorderStyle + "' align='right'><b>" + intSeriesTotal(1).ToString + "</b></td>" + vbCr)
					End If
					If m_intSeriesMaxColumns(2) > 1 Then
						Response.Write("    <td style='" + strBorderStyle + "' align='right' colspan='" + m_intSeriesMaxColumns(2).ToString + "'><b>" + intSeriesTotal(2).ToString + "</b></td>" + vbCr)
					Else
						Response.Write("    <td style='" + strBorderStyle + "' align='right'><b>" + intSeriesTotal(2).ToString + "</b></td>" + vbCr)
					End If
					If m_intSeriesMaxColumns(3) > 1 Then
						Response.Write("    <td style='" + strBorderStyle + "' align='right' colspan='" + m_intSeriesMaxColumns(3).ToString + "'><b>" + intSeriesTotal(3).ToString + "</b></td>" + vbCr)
					Else
						Response.Write("    <td style='" + strBorderStyle + "' align='right'><b>" + intSeriesTotal(3).ToString + "</b></td>" + vbCr)
					End If
					If m_intSeriesMaxColumns(4) > 1 Then
						Response.Write("    <td style='" + strBorderStyle + "' align='right' colspan='" + m_intSeriesMaxColumns(4).ToString + "'><b>" + intSeriesTotal(4).ToString + "</b></td>" + vbCr)
					Else
						Response.Write("    <td style='" + strBorderStyle + "' align='right'><b>" + intSeriesTotal(4).ToString + "</b></td>" + vbCr)
					End If
					If m_intSeriesMaxColumns(5) > 1 Then
						Response.Write("    <td style='" + strBorderStyle + "' align='right' colspan='" + m_intSeriesMaxColumns(5).ToString + "'><b>" + intSeriesTotal(5).ToString + "</b></td>" + vbCr)
					Else
						Response.Write("    <td style='" + strBorderStyle + "' align='right'><b>" + intSeriesTotal(5).ToString + "</b></td>" + vbCr)
					End If
					Response.Write("    <td style='" + strBorderStyle + "' align='right' width='80'><b>" + intTotalJHBZ.ToString + "</b></td>" + vbCr)
					Response.Write("    <td style='" + strBorderStyle + "' align='right' width='80'><b>" + intTotalSJBZ.ToString + "</b></td>" + vbCr)
					Response.Write("  </tr>" + vbCr)
					Response.Write("</TABLE>")
				Catch ex As Exception
				End Try
				Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
			End Sub
			'zengxainglin 2008-11-18
        </script>
		<script language="javascript">
		<!--
			//zengxianglin 2008-10-14
			function btnCloseWin_onClick()
			{
		        if (document.getElementById("spanCloseWin") == null)
		            return;
		        window.close();
			}
			//zengxianglin 2008-10-14
		    function btnPrint_onClick()
		    {
		        if (document.getElementById("divMain") == null)
		            return;
		        if (document.getElementById("txtJCSJ") == null)
		            return;
		        var objwindow = null;
		        var strHeight = (window.screen.availHeight - 8).toString();
		        var strWidth  = (window.screen.availWidth  - 8).toString();
		        objwindow = window.open("/人员架构一览表.doc","_blank","height=" + strHeight + ",width=" + strWidth + ",status=yes,toolbar=yes,menubar=yes,location=yes,resizable=yes,scrollbars=yes");
		        objwindow.document.clear()
		        objwindow.document.write("<META HTTP-EQUIV='Content-Type' CONTENT='application/msword'>");
		        objwindow.document.writeln("<TABLE cellSpacing='0' cellPadding='0' border='0' width='100%'>");
		        objwindow.document.writeln("  <TR height='32' valign='middle'>");
		        objwindow.document.writeln("    <TD align='center' style='FONT-SIZE: 32px; FONT-FAMILY: 黑体'>");
		        objwindow.document.writeln("      人员架构表");
		        objwindow.document.writeln("    </TD>");
		        objwindow.document.writeln("  </TR>");
		        objwindow.document.writeln("  <TR height='24' valign='middle'>");
		        objwindow.document.writeln("    <TD align='center' style='FONT-SIZE: 11pt; FONT-FAMILY: 宋体; BORDER-BOTTOM: black 2px solid;'>");
		        objwindow.document.writeln("      " + document.getElementById("txtJCSJ").value);
		        objwindow.document.writeln("    </TD>");
		        objwindow.document.writeln("  </TR>");
		        objwindow.document.writeln("  <TR valign='middle'>");
		        objwindow.document.writeln("    <TD align='center' height='6'></td>");
		        objwindow.document.writeln("  </TR>");
		        objwindow.document.writeln("</TABLE>");
		        objwindow.document.writeln("");
		        objwindow.document.write(document.getElementById("divMain").innerHTML);
		        return;
		    }
			function window_onresize() 
			{
				var dblHeight = 0;
				var dblWidth  = 0;
				var strHeight = "";
				var strWidth  = "";
				
				if (document.all("divMain") == null)
					return;
				
				intWidth   = document.body.clientWidth;   //总宽度
				intWidth  -= 16;                          //滚动条
				strWidth   = intWidth.toString() + "px";
				
				intHeight  = document.body.clientHeight;  //总高度
				intHeight -= 16;                          //滚动条
				intHeight -= trRow01.clientHeight;
				intHeight -= trRow02.clientHeight;
				strHeight  = intHeight.toString() + "px";

				document.all("divMain").style.width  = strWidth;
				document.all("divMain").style.height = strHeight;
				document.all("divMain").style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";
			}
			function document_onreadystatechange() 
			{
			    //控制打印
			    if (document.getElementById("htxtCanPrint") != null)
			    {
			        if (document.getElementById("btnPrint") != null)
			        {
			            if (document.getElementById("htxtCanPrint").value == "1")
			                document.getElementById("btnPrint").style.display = "";
			            else
			                document.getElementById("btnPrint").style.display = "none";
			        }
			    }
			    //zengxianglin 2008-10-14
		        if (document.getElementById("spanCloseWin") != null)
		        {
					if (window.top == window)
					{
						spanCloseWin.style.display = "";
						spanClose.style.display = "none";
					}
					else
					{
						spanCloseWin.style.display = "none";
						spanClose.style.display = "";
					}
		        }
			    //zengxianglin 2008-10-14
			    //其他处理
				return window_onresize();
			}
		//-->
		</script>
		<script language="javascript" for="document" event="onreadystatechange">
		<!--
			return document_onreadystatechange()
		//-->
		</script>
    </HEAD>
    <body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onresize="javascript:window_onresize()">
        <form id="frmestate_rs_renyuanjiagou_bdls" method="post" runat="server">
            <asp:panel id="panelMain" Runat="server">
                <TABLE cellSpacing="0" cellPadding="0" border="0">
                    <TR id="trRow01">
                        <TD height="30" vAlign="middle" align="left" class="title" style="BORDER-BOTTOM: #99cccc 2px solid">当前位置：人事管理&nbsp;&gt;&gt;&gt;&gt;&nbsp;二手业务人员架构变动查询<asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton></TD>
                        <td height="30" vAlign="middle" align="right"class="title" style="BORDER-BOTTOM: #99cccc 2px solid">查询时间：<asp:TextBox ID="txtJCSJ" Runat="server" CssClass="textbox" Columns="10"></asp:TextBox><asp:Button ID="btnDisplay" Runat="server" CssClass="button" Text="显示架构"></asp:Button></td>
                    </TR>
                    <TR>
                        <TD vAlign="top" align="center" colspan="2">
                            <DIV id="divMain" style="OVERFLOW: auto; WIDTH: 996px; CLIP: rect(0px 444px 996px 0px); HEIGHT: 444px">
                                <TABLE cellSpacing="0" cellPadding="0" border="0" width="100%">
                                    <tr>
                                        <td height="4"></td>
                                    </tr>
                                    <TR>
                                        <td align="center">
                                            <TABLE cellSpacing="0" cellPadding="0" border="0" style="BORDER-RIGHT: black 2px solid; BORDER-TOP: black 2px solid; BORDER-LEFT: black 2px solid; BORDER-BOTTOM: black 2px solid">
                                                <tr height="24" valign="middle">
                                                    <td colspan="3" align="center" style="BORDER-RIGHT: black 2px solid; BORDER-BOTTOM: black 1px solid">区域总监</td>
                                                    <td colspan="4" align="center" style="BORDER-RIGHT: black 2px solid; BORDER-BOTTOM: black 1px solid">区域经理</td>
                                                    <td colspan="5" align="center" style="BORDER-RIGHT: black 2px solid; BORDER-BOTTOM: black 1px solid">营业经理</td>
                                                    <td colspan="4" align="center" style="BORDER-RIGHT: black 2px solid; BORDER-BOTTOM: black 1px solid">物业顾问</td>
                                                    <td colspan="5" align="center" style="BORDER-BOTTOM: black 1px solid">文员</td>
                                                </tr>
                                                <tr height="48" valign="middle">
                                                    <td style="BORDER-RIGHT: black 1px solid;" align="center" width="40" bgcolor="Red">资深</td>
                                                    <td style="BORDER-RIGHT: black 1px solid;" align="center" width="40" bgcolor="Fuchsia">高级</td>
                                                    <td style="BORDER-RIGHT: black 2px solid;" align="center" width="40" bgcolor="Pink">总监</td>
                                                    
                                                    <td style="BORDER-RIGHT: black 1px solid;" align="center" width="40" bgcolor="Teal">资深</td>
                                                    <td style="BORDER-RIGHT: black 1px solid;" align="center" width="40" bgcolor="Lime">高级</td>
                                                    <td style="BORDER-RIGHT: black 1px solid;" align="center" width="40" bgcolor="Chartreuse">中级</td>
                                                    <td style="BORDER-RIGHT: black 2px solid;" align="center" width="40" bgcolor="LightGreen">区域<br>经理</td>
                                                    
                                                    <td style="BORDER-RIGHT: black 1px solid;" align="center" width="40" bgcolor="Silver">资深</td>
                                                    <td style="BORDER-RIGHT: black 1px solid;" align="center" width="40" bgcolor="Blue">高级</td>
                                                    <td style="BORDER-RIGHT: black 1px solid;" align="center" width="40" bgcolor="DeepSkyBlue">中级</td>
                                                    <td style="BORDER-RIGHT: black 1px solid;" align="center" width="40" bgcolor="LightBlue">营业<br>经理</td>
                                                    <td style="BORDER-RIGHT: black 2px solid;" align="center" width="40" bgcolor="LightCyan">业务<br>经理</td>

                                                    <td style="BORDER-RIGHT: black 1px solid;" align="center" width="40" bgcolor="DarkKhaki">资深</td>
                                                    <td style="BORDER-RIGHT: black 1px solid;" align="center" width="40" bgcolor="YellowGreen">高级</td>
                                                    <td style="BORDER-RIGHT: black 1px solid;" align="center" width="40" bgcolor="Orange">中级</td>
                                                    <td style="BORDER-RIGHT: black 2px solid;" align="center" width="40" bgcolor="white">初级</td>

                                                    <td style="BORDER-RIGHT: black 1px solid;" align="center" width="40" bgcolor="PowderBlue">区域</td>
                                                    <td style="BORDER-RIGHT: black 1px solid;" align="center" width="40" bgcolor="CornflowerBlue">初区</td>
                                                    <td style="BORDER-RIGHT: black 1px solid;" align="center" width="40" bgcolor="LightSkyBlue">高级</td>
                                                    <td style="BORDER-RIGHT: black 1px solid;" align="center" width="40" bgcolor="LightSteelBlue">中级</td>
                                                    <td align="center" width="40" bgcolor="Plum">初级</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </TR>
                                    <tr>
                                        <td height="10"></td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                        <% 
											'zengxianglin 2008-10-14
											if propAutoDisplay = true then
												doDisplayData()
												propAutoDisplay = false
											else
												response.write("&nbsp;")
											end if
											'zengxianglin 2008-10-14
										%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="10"></td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <TABLE cellSpacing="0" cellPadding="0" border="0" width="100%">
                                                <tr>
                                                    <td bgcolor="LightGreen">表格说明：</td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;&nbsp;(1) 带下划线表示试用期员工</td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;&nbsp;(2) 名字后面带*号的不占该分行的编制</td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;&nbsp;(3) 不属于该分行的员工用白色底色显示</td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;&nbsp;(4) 名字前面带@号的是该分行的直管</td>
                                                </tr>
                                            </TABLE>
                                        </td>
                                    </tr>
                                </table>
                            </DIV>
                        </TD>
                    </TR>
                    <TR id="trRow02">
                        <TD style="BORDER-TOP: #99cccc 2px solid" vAlign="middle" align="center" height="36" colspan="2">
                            <input      id="btnPrint"    type="button"  value=" 打印架构 " class   ="button" style="HEIGHT: 32px" onclick="btnPrint_onClick();">
                            <asp:Button id="btnViewGX"   Runat="server" Text =" 查看关系 " CssClass="button" Height="32px"></asp:Button>
                            <asp:Button id="btnTongbu"   Runat="server" Text =" 信息同步 " CssClass="button" Height="32px"></asp:Button>
                            <!-- zengxianglin 2008-10-14 -->
                            <span       id="spanClose" style="display:">
                            <asp:Button id="btnClose"    Runat="server" Text =" 返    回 " CssClass="button" Height="32px"></asp:Button>
                            </span>
                            <!-- zengxianglin 2008-10-14 -->
                            <!-- zengxianglin 2008-10-14 -->
                            <span       id="spanCloseWin" style="display:none">
                            <input      id="btnCloseWin" type="button"  value=" 关    闭 " class="button" style="HEIGHT: 32px" onclick="btnCloseWin_onClick()">
                            </span>
                            <!-- zengxianglin 2008-10-14 -->
                        </TD>
                    </TR>
                </TABLE>
            </asp:panel>
            <asp:Panel id="panelError" Runat="server">
                <TABLE height="98%" cellSpacing="0" cellPadding="0" width="100%" border="0">
                    <TR>
                        <TD width="5%"></TD>
                        <TD>
                            <TABLE height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
                                <TR>
                                    <TD>&nbsp;&nbsp;&nbsp;&nbsp;</TD>
                                    <TD style="FONT-SIZE: 32pt; COLOR: black; LINE-HEIGHT: 40pt; FONT-FAMILY: 宋体; LETTER-SPACING: 2pt" align="center"><asp:Label id="lblMessage" Runat="server"></asp:Label><P>&nbsp;&nbsp;</P><P><asp:Button ID="btnGoBack" Runat="server" Font-Size="24pt" Text=" 返回 "></asp:Button></P></TD>
                                    <TD>&nbsp;&nbsp;&nbsp;&nbsp;</TD>
                                </TR>
                            </TABLE>
                        </TD>
                        <TD width="5%"></TD>
                    </TR>
                </TABLE>
            </asp:Panel>
            <table cellSpacing="0" cellPadding="0" align="center" border="0">
                <tr>
                    <td>
                        <input id="htxtCanPrint" type="hidden" runat="server" value="0">
                        <input id="htxtDivLeftMain" type="hidden" runat="server">
                        <input id="htxtDivTopMain" type="hidden" runat="server">
                        <input id="htxtDivLeftBody" type="hidden" runat="server">
                        <input id="htxtDivTopBody" type="hidden" runat="server">
                    </td>
                </tr>
                <tr>
                    <td>
                        <script language="javascript">
							function ScrollProc_Body() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopBody");
								if (oText != null) oText.value = document.body.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftBody");
								if (oText != null) oText.value = document.body.scrollLeft;
								return;
							}
							function ScrollProc_divMain() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopMain");
								if (oText != null) oText.value = divMain.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftMain");
								if (oText != null) oText.value = divMain.scrollLeft;
								return;
							}
							try {
								var Text;

								oText=null;
								oText=document.getElementById("htxtDivTopBody");
								if (oText != null) document.body.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftBody");
								if (oText != null) document.body.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtDivTopMain");
								if (oText != null) divMain.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftMain");
								if (oText != null) divMain.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divMain.onscroll = ScrollProc_divMain;
							}
							catch (e) {}
                        </script>
                    </td>
                </tr>
                <tr>
                    <td>
                        <script language="javascript">window_onresize();</script>
                        <uwin:popmessage id="popMessageObject" runat="server" height="48px" width="96px" Visible="False" ActionType="OpenWindow" PopupWindowType="Normal" EnableViewState="False"></uwin:popmessage>
                    </td>
                </tr>
            </table>
        </form>
    </body>
</HTML>
