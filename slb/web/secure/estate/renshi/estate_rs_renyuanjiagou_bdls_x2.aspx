<%@ Page Language="vb" AutoEventWireup="false" Codebehind="estate_rs_renyuanjiagou_bdls_x2.aspx.vb" Inherits="Josco.JSOA.web.estate_rs_renyuanjiagou_bdls_x2" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
    <HEAD>
        <title>人员管理架构变动历史查看窗(模式二)</title>
        <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
        <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
        <meta content="JavaScript" name="vs_defaultClientScript">
        <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <LINK href="../../../stylesw.css" type="text/css" rel="stylesheet">
        <script src="../../../scripts/transkey.js"></script>
        <script language="vb" runat="server">
			'定义序列信息
			Public Const m_cintSeries As Integer = 7 '0-总监,1-区经,2-营经直管,3-营经协管,4-业经,5-客户经理,6-顾问,7-文员
			Public Const m_cintTabNo_BBCS As Integer = 0
			Public Const m_cintTabNo_SYSJ As Integer = 1
			Public Const m_cintTabNo_YWJL As Integer = 2
			Public Const m_cintTabNo_YYJL_XG As Integer = 3
			Public Const m_cintTabNo_YYJL_ZG As Integer = 4
			Public Const m_cintTabNo_QYJL As Integer = 5
			Public Const m_cintTabNo_QYZJ As Integer = 6
			Public Const m_cintTabNo_GLJG As Integer = 7
			Public Const m_cintTabNo_ZLJG As Integer = 8
			Public Const m_cintTabNo_DWXX As Integer = 9
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
					If objsystemEstateRenshiXingye.getDataSet_RYJG_X2(strErrMsg, "sa","20080701xiugai", Me.m_objTime.ToString("yyyy-MM-dd"), Me.m_objDataSetBB) = False Then
						Exit Try
					End If
					'填充序列的最大列数
					If Not (Me.m_objDataSetBB.Tables(Me.m_cintTabNo_BBCS) Is Nothing) Then
						With Me.m_objDataSetBB.Tables(Me.m_cintTabNo_BBCS)
							m_intSeriesMaxColumns(0) = objPulicParameters.getObjectValue(.Rows(0).Item("总监列数"), 1)
							m_intSeriesMaxColumns(1) = objPulicParameters.getObjectValue(.Rows(0).Item("区经列数"), 1)
							m_intSeriesMaxColumns(2) = objPulicParameters.getObjectValue(.Rows(0).Item("营直列数"), 1)
							m_intSeriesMaxColumns(3) = objPulicParameters.getObjectValue(.Rows(0).Item("营协列数"), 1)
							m_intSeriesMaxColumns(4) = objPulicParameters.getObjectValue(.Rows(0).Item("业经列数"), 1)
							m_intSeriesMaxColumns(5) = objPulicParameters.getObjectValue(.Rows(0).Item("客经列数"), 1)
							m_intSeriesMaxColumns(6) = objPulicParameters.getObjectValue(.Rows(0).Item("顾问列数"), 1)
							m_intSeriesMaxColumns(7) = objPulicParameters.getObjectValue(.Rows(0).Item("文员列数"), 1)
							m_intMaxRows = objPulicParameters.getObjectValue(.Rows(0).Item("报表行数"), 1)
							m_intMaxCols = objPulicParameters.getObjectValue(.Rows(0).Item("报表列数"), 1)
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
			
			'计算人员所属序列(1,2,3,4,5,6,7,8)
			Public Function getSeriesNo(ByVal strZJDM As String, ByVal intXGRY As Integer) As Integer
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
							If intXGRY = 0 Then
								getSeriesNo = 3
							Else
								getSeriesNo = 4
							End If
						Case "010.030.020"
							If intXGRY = 0 Then
								getSeriesNo = 3
							Else
								getSeriesNo = 4
							End If
						Case "010.030.030"
							If intXGRY = 0 Then
								getSeriesNo = 3
							Else
								getSeriesNo = 4
							End If
						Case "010.030.040"
							If intXGRY = 0 Then
								getSeriesNo = 3
							Else
								getSeriesNo = 4
							End If

						'*********************
						'业务经理级
						Case "010.030.050"
							getSeriesNo = 5

						'*********************
						'客户经理级
						Case "020.010.005"
							getSeriesNo = 6

						'*********************
						'物业顾问级
						Case "020.010.010"
							getSeriesNo = 7
						Case "020.010.015"
							getSeriesNo = 7
						Case "020.010.020"
							getSeriesNo = 7
						Case "020.010.030"
							getSeriesNo = 7
						Case "020.010.040"
							getSeriesNo = 7

						'*********************
						'行政助理级
						Case "030.010.010"
							getSeriesNo = 8
						Case "030.010.015"
							getSeriesNo = 8
						Case "030.010.020"
							getSeriesNo = 8
						Case "030.010.030"
							getSeriesNo = 8
						Case "030.010.040"
							getSeriesNo = 8

						'*********************
						'默认为物业顾问
						Case Else
							getSeriesNo = 7
					End Select
				Catch ex As Exception
					getSeriesNo = 7
				End Try
			End Function

			'计算单元格的style信息
			Public Function getCellStyle(ByVal strZJDM As String, ByVal intRYZT As Integer, ByVal intSFZB As Integer) As String
				Try
					Dim strTextDecoration As String = ""
					Dim strBkColor As String = ""
					Select Case strZJDM
						'*********************
						'区域总监级
						Case "010.010.010"
							strBkColor = "Red"
						Case "010.010.020"
							strBkColor = "Fuchsia"
						Case "010.010.030"
							strBkColor = "Pink"

						'*********************
						'区域经理级
						Case "010.020.010"
							strBkColor = "Teal"
						Case "010.020.020"
							strBkColor = "Lime"
						Case "010.020.025"
							strBkColor = "MediumSpringGreen"
						Case "010.020.030"
							strBkColor = "LightGreen"

						'*********************
						'营业经理级
						Case "010.030.010"
							strBkColor = "Silver"
						Case "010.030.020"
							strBkColor = "Blue"
						Case "010.030.030"
							strBkColor = "DeepSkyBlue"
						Case "010.030.040"
							strBkColor = "LightBlue"

						'*********************
						'业务经理级
						Case "010.030.050"
							strBkColor = "LightCyan"

						'*********************
						'客户经理级
						Case "020.010.005"
							strBkColor = "DodgerBlue"

						'*********************
						'物业顾问级
						Case "020.010.010"
							strBkColor = "DarkKhaki"
						Case "020.010.015"
							strBkColor = "RoyalBlue"
						Case "020.010.020"
							strBkColor = "YellowGreen"
						Case "020.010.030"
							strBkColor = "Orange"
						Case "020.010.040"
							strBkColor = "white"

						'*********************
						'行政助理级
						Case "030.010.010"
							strBkColor = "PowderBlue"
						Case "030.010.015"
							strBkColor = "CornflowerBlue"
						Case "030.010.020"
							strBkColor = "LightSkyBlue"
						Case "030.010.030"
							strBkColor = "LightSteelBlue"
						Case "030.010.040"
							strBkColor = "Plum"

						'*********************
						'默认处理
						Case Else
							strBkColor = "white"
					End Select

					'不占编
					If intSFZB = 0 Then
						strBkColor = "white"
					End If

					'试用人员
					If (intRYZT And 1) = 1 Then
						strTextDecoration = "underline"
					End If
					'实习生
					If (intRYZT And 4) = 4 Then
						strTextDecoration = "line-through"
					End If

					getCellStyle = "BACKGROUND-COLOR: " + strBkColor + ";"
					If strTextDecoration <> "" Then
						getCellStyle = getCellStyle + "TEXT-DECORATION: " + strTextDecoration + ";"
					End If
				Catch ex As Exception
					getCellStyle = "BACKGROUND-COLOR: white;"
				End Try
			End Function

			'计算单元格的style信息
			Public Function getNewCellValue(ByVal strValue As String, ByVal intXGRY As Integer, ByVal intSFZB As Integer) As String
				Try
					'不占编(*)
					If intSFZB = 0 Then
						getNewCellValue = strValue + "*"
					Else
						getNewCellValue = strValue
					End If
					'直管(@)
					If intXGRY = 0 Then
						getNewCellValue = "@" + getNewCellValue
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
					If Me.m_objDataSetBB.Tables.Count < 10 Then
						Exit Try
					End If
					Dim intDataCols As Integer = Me.m_intMaxCols
					Dim strBorderStyle As String = "BORDER-RIGHT: black 1px solid; BORDER-TOP: black 1px solid; BORDER-LEFT: black 1px solid; BORDER-BOTTOM: black 1px solid;"
					Response.Write("<TABLE cellSpacing='0' cellPadding='0' border='0' style='" + strBorderStyle + "'>" + vbCr)

					'输出表头
					Response.Write("  <tr height='36' bgcolor='#99cccc'>" + vbCr)
					Response.Write("    <td style='" + strBorderStyle + "' align='center'><b>序号</b></td>" + vbCr)
					Response.Write("    <td style='" + strBorderStyle + "' align='center' width='160'><b>分行</b></td>" + vbCr)
					Response.Write("    <td style='" + strBorderStyle + "' align='center' width='80'><b>团队</b></td>" + vbCr)
					If m_intSeriesMaxColumns(0) > 1 Then
						Response.Write("    <td style='" + strBorderStyle + "' align='center' colspan='" + Me.m_intSeriesMaxColumns(0).ToString + "'><b>区域<br>总监</b></td>" + vbCr)
					Else
						Response.Write("    <td style='" + strBorderStyle + "' align='center'><b>区域<br>总监</b></td>" + vbCr)
					End If
					If m_intSeriesMaxColumns(1) > 1 Then
						Response.Write("    <td style='" + strBorderStyle + "' align='center' colspan='" + Me.m_intSeriesMaxColumns(1).ToString + "'><b>区域<br>经理</b></td>" + vbCr)
					Else
						Response.Write("    <td style='" + strBorderStyle + "' align='center'><b>区域<br>经理</b></td>" + vbCr)
					End If
					If m_intSeriesMaxColumns(2) > 1 Then
						Response.Write("    <td style='" + strBorderStyle + "' align='center' colspan='" + Me.m_intSeriesMaxColumns(2).ToString + "'><b>营经<br>直管</b></td>" + vbCr)
					Else
						Response.Write("    <td style='" + strBorderStyle + "' align='center'><b>营经<br>直管</b></td>" + vbCr)
					End If
					If m_intSeriesMaxColumns(3) > 1 Then
						Response.Write("    <td style='" + strBorderStyle + "' align='center' colspan='" + Me.m_intSeriesMaxColumns(3).ToString + "'><b>营经<br>协管</b></td>" + vbCr)
					Else
						Response.Write("    <td style='" + strBorderStyle + "' align='center'><b>营经<br>协管</b></td>" + vbCr)
					End If
					If m_intSeriesMaxColumns(4) > 1 Then
						Response.Write("    <td style='" + strBorderStyle + "' align='center' colspan='" + Me.m_intSeriesMaxColumns(4).ToString + "'><b>业务<br>经理</b></td>" + vbCr)
					Else
						Response.Write("    <td style='" + strBorderStyle + "' align='center'><b>业务<br>经理</b></td>" + vbCr)
					End If
					If m_intSeriesMaxColumns(5) > 1 Then
						Response.Write("    <td style='" + strBorderStyle + "' align='center' colspan='" + Me.m_intSeriesMaxColumns(5).ToString + "'><b>客户<br>经理</b></td>" + vbCr)
					Else
						Response.Write("    <td style='" + strBorderStyle + "' align='center'><b>客户<br>经理</b></td>" + vbCr)
					End If
					If m_intSeriesMaxColumns(6) > 1 Then
						Response.Write("    <td style='" + strBorderStyle + "' align='center' colspan='" + Me.m_intSeriesMaxColumns(6).ToString + "'><b>物业顾问</b></td>" + vbCr)
					Else
						Response.Write("    <td style='" + strBorderStyle + "' align='center'><b>物业顾问</b></td>" + vbCr)
					End If
					If m_intSeriesMaxColumns(7) > 1 Then
						Response.Write("    <td style='" + strBorderStyle + "' align='center' colspan='" + Me.m_intSeriesMaxColumns(7).ToString + "'><b>文员</b></td>" + vbCr)
					Else
						Response.Write("    <td style='" + strBorderStyle + "' align='center'><b>文员</b></td>" + vbCr)
					End If
					'zengxianglin 2010-03-17
					Response.Write("    <td style='" + strBorderStyle + "' align='center'><b>团队<br>编制</b></td>" + vbCr)
					'zengxianglin 2010-03-17
					Response.Write("    <td style='" + strBorderStyle + "' align='center'><b>计划<br>编制</b></td>" + vbCr)
					Response.Write("    <td style='" + strBorderStyle + "' align='center'><b>实际<br>编制</b></td>" + vbCr)
					Response.Write("  </tr>" + vbCr)

					'输出数据
					Dim strSep As String = Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate
					'zengxianglin 2010-03-17
					'Dim strStyles(intDataCols + 5 - 1) As String '0开始
					'Dim strValues(intDataCols + 5 - 1) As String '0开始
					Dim strStyles(intDataCols + 6 - 1) As String '0开始
					Dim strValues(intDataCols + 6 - 1) As String '0开始
					'zengxianglin 2010-03-17
					Dim strSeriesTotal(m_cintSeries) As String   '序列计数人(逗号分隔)
					Dim intSeriesTotal(m_cintSeries) As Integer  '序列汇总数
					Dim intSeriesPtr(m_cintSeries) As Integer    '序列开始列
					Dim intTotalJHBZ As Integer = 0
					Dim intTotalSJBZ As Integer = 0
					Dim intTotalTDRS As Integer = 0
					Dim intCountA As Integer = 0
					Dim intCountB As Integer = 0
					Dim intXGRY As Integer = 0
					Dim intRYZT As Integer = 0
					Dim intSFZB As Integer = 0
					Dim strDQDWOld As String = ""
					Dim strDQDW As String = ""
					Dim intDQTD As Integer
					Dim intDWHS As Integer
					dim intTDRS As Integer
					Dim strSSDW As String = ""
					Dim strZJDM As String = ""
					Dim strRYZM As String = ""
					Dim strRYDM As String = ""
					Dim intTDBH As Integer
					Dim strTEMP As String = ""
					Dim intSNo As Integer = 0
					Dim intTNo As Integer
					Dim i As Integer = 0
					Dim j As Integer = 0
					Dim k As Integer = 0

					'人员架构数据开始输出
					With Me.m_objDataSetBB.Tables(Me.m_cintTabNo_SYSJ)
						'初始化各序列的汇总数、人名列表
						For i = 0 To intSeriesTotal.Length - 1 Step 1
							intSeriesTotal(i) = 0
						Next
						For i = 0 To strSeriesTotal.Length - 1 Step 1
							strSeriesTotal(i) = ""
						Next

						'逐个团队处理
						intCountA = .Rows.Count
						For i = 0 To intCountA - 1 Step 1
							'初始化序列的开始列指针
							intSeriesPtr(0) = 3 '总监开始
							intSeriesPtr(1) = intSeriesPtr(0) + m_intSeriesMaxColumns(0)
							intSeriesPtr(2) = intSeriesPtr(1) + m_intSeriesMaxColumns(1)
							intSeriesPtr(3) = intSeriesPtr(2) + m_intSeriesMaxColumns(2)
							intSeriesPtr(4) = intSeriesPtr(3) + m_intSeriesMaxColumns(3)
							intSeriesPtr(5) = intSeriesPtr(4) + m_intSeriesMaxColumns(4)
							intSeriesPtr(6) = intSeriesPtr(5) + m_intSeriesMaxColumns(5)
							intSeriesPtr(7) = intSeriesPtr(6) + m_intSeriesMaxColumns(6)

							'初始化所有序列的列值与显示样式
							For j = 0 To strValues.Length - 1 Step 1
								strValues(j) = ""
							Next
							For j = 0 To strStyles.Length - 1 Step 1
								strStyles(j) = ""
							Next

							'获取当前行(团队)的索引数据
							strDQDW = objPulicParameters.getObjectValue(.Rows(i).Item("所属单位"), "")
							intDQTD = objPulicParameters.getObjectValue(.Rows(i).Item("团队编号"), 0)
							intDWHS = objPulicParameters.getObjectValue(.Rows(i).Item("单位行数"), 1)
							'zengxianglin 2010-03-17
							intTDRS = objPulicParameters.getObjectValue(.Rows(i).Item("团队人数"), 0)
							intTotalTDRS += intTDRS
							'zengxianglin 2010-03-17

							'计算当前行(团队)的单位数据
							'zengxianglin 2010-03-17
							strValues(strValues.Length - 3) = intTDRS.ToString()
							'zengxianglin 2010-03-17
							With Me.m_objDataSetBB.Tables(Me.m_cintTabNo_DWXX)
								.DefaultView.RowFilter = "所属单位 = '" + strDQDW + "'"
								If .DefaultView.Count > 0 Then
									strValues(0) = objPulicParameters.getObjectValue(.DefaultView.Item(0).Item("单位序号"), "")
									strValues(1) = objPulicParameters.getObjectValue(.DefaultView.Item(0).Item("单位名称"), "")
									strValues(2) = intDQTD.ToString
									If strDQDWOld <> strDQDW Then
										j = objPulicParameters.getObjectValue(.DefaultView.Item(0).Item("编制人数"), 0)
										strValues(strValues.Length - 2) = j.ToString()
										intTotalJHBZ += j
									End If
									If strDQDWOld <> strDQDW Then
										j = objPulicParameters.getObjectValue(.DefaultView.Item(0).Item("实际编制"), 0)
										strValues(strValues.Length - 1) = j.ToString()
										intTotalSJBZ += j
									End If
								End If
							End With

							'计算当前行(团队)的总监、区经、营经直管、营经协管、业经的数据
							For k = 0 To 4 Step 1
								Select Case k
									Case 0
										'计算当前行的总监数据
										intTNo = Me.m_cintTabNo_QYZJ
									Case 1
										'计算当前行的区经数据
										intTNo = Me.m_cintTabNo_QYJL
									Case 2
										'计算当前行的营经直管数据
										intTNo = Me.m_cintTabNo_YYJL_ZG
									Case 3
										'计算当前行的营经协管数据
										intTNo = Me.m_cintTabNo_YYJL_XG
									Case 4
										'计算当前行的业经数据
										intTNo = Me.m_cintTabNo_YWJL
								End Select

								'输出团队管理层的人员数据
								With Me.m_objDataSetBB.Tables(intTNo)
									.DefaultView.RowFilter = "所属单位 = '" + strDQDW + "' and 团队编号 = " + intDQTD.ToString
									intCountB = .DefaultView.Count
									For j = 0 To intCountB - 1 Step 1
										strRYDM = objPulicParameters.getObjectValue(.DefaultView.Item(j).Item("人员代码"), "")
										intXGRY = objPulicParameters.getObjectValue(.DefaultView.Item(j).Item("是否直管"), 0)
										intXGRY = 1 - intXGRY
										With Me.m_objDataSetBB.Tables(Me.m_cintTabNo_GLJG)
											.DefaultView.RowFilter = "人员代码 = '" + strRYDM + "'"
											If .DefaultView.Count > 0 Then
												strSSDW = objPulicParameters.getObjectValue(.DefaultView.Item(0).Item("所属单位"), "")
												strZJDM = objPulicParameters.getObjectValue(.DefaultView.Item(0).Item("职级代码"), "")
												strRYZM = objPulicParameters.getObjectValue(.DefaultView.Item(0).Item("人员名称"), "")
												intRYZT = objPulicParameters.getObjectValue(.DefaultView.Item(0).Item("人员状态"), 0)
												intSFZB = objPulicParameters.getObjectValue(.DefaultView.Item(0).Item("是否占编"), 0)
												intTDBH = objPulicParameters.getObjectValue(.DefaultView.Item(0).Item("团队编号"), 0)
												'占编？
												If Not (strDQDW = strSSDW And intDQTD = intTDBH) Then
													intSFZB = 0
												End If
												'计算所属序列
												intSNo = Me.getSeriesNo(strZJDM, intXGRY)
												'设置序列项值
												strValues(intSeriesPtr(intSNo - 1)) = getNewCellValue(strRYZM, intXGRY, intSFZB)
												strStyles(intSeriesPtr(intSNo - 1)) = getCellStyle(strZJDM, intRYZT, intSFZB)
												'列指针移动
												intSeriesPtr(intSNo - 1) += 1
												'序列项汇总
												If intSFZB = 1 Then
													If strSeriesTotal(intSNo - 1) = "" Then
														intSeriesTotal(intSNo - 1) = intSeriesTotal(intSNo - 1) + 1
														strSeriesTotal(intSNo - 1) = strRYDM
													Else
														strTEMP = strSep + strSeriesTotal(intSNo - 1) + strSep
														If strTEMP.IndexOf(strSep + strRYDM + strSep) < 0 Then
															intSeriesTotal(intSNo - 1) = intSeriesTotal(intSNo - 1) + 1
															strSeriesTotal(intSNo - 1) = strSeriesTotal(intSNo - 1) + strSep + strRYDM
														End If
													End If
												End If
											End If
										End With
									Next
								End With
							Next

							'计算当前行(团队)的客户经理数据
							With Me.m_objDataSetBB.Tables(Me.m_cintTabNo_GLJG)
								.DefaultView.RowFilter = "所属单位 = '" + strDQDW + "' and 团队编号 = " + intDQTD.ToString + " and 职级代码 = '020.010.005'"
								intCountB = .DefaultView.Count
								For j = 0 To intCountB - 1 Step 1
									strRYDM = objPulicParameters.getObjectValue(.DefaultView.Item(j).Item("人员代码"), "")
									strSSDW = objPulicParameters.getObjectValue(.DefaultView.Item(j).Item("所属单位"), "")
									strZJDM = objPulicParameters.getObjectValue(.DefaultView.Item(j).Item("职级代码"), "")
									strRYZM = objPulicParameters.getObjectValue(.DefaultView.Item(j).Item("人员名称"), "")
									intRYZT = objPulicParameters.getObjectValue(.DefaultView.Item(j).Item("人员状态"), 0)
									intSFZB = objPulicParameters.getObjectValue(.DefaultView.Item(j).Item("是否占编"), 0)
									intXGRY = -1 '无效
									'计算所属序列
									intSNo = Me.getSeriesNo(strZJDM, intXGRY)
									'设置序列项值
									strValues(intSeriesPtr(intSNo - 1)) = getNewCellValue(strRYZM, intXGRY, intSFZB)
									strStyles(intSeriesPtr(intSNo - 1)) = getCellStyle(strZJDM, intRYZT, intSFZB)
									'列指针移动
									intSeriesPtr(intSNo - 1) += 1
									'序列项汇总
									If intSFZB = 1 Then
										If strSeriesTotal(intSNo - 1) = "" Then
											intSeriesTotal(intSNo - 1) = intSeriesTotal(intSNo - 1) + 1
											strSeriesTotal(intSNo - 1) = strRYDM
										Else
											strTEMP = strSep + strSeriesTotal(intSNo - 1) + strSep
											If strTEMP.IndexOf(strSep + strRYDM + strSep) < 0 Then
												intSeriesTotal(intSNo - 1) = intSeriesTotal(intSNo - 1) + 1
												strSeriesTotal(intSNo - 1) = strSeriesTotal(intSNo - 1) + strSep + strRYDM
											End If
										End If
									End If
								Next
							End With

							'计算当前行(团队)的物业顾问数据
							With Me.m_objDataSetBB.Tables(Me.m_cintTabNo_GLJG)
								.DefaultView.RowFilter = "所属单位 = '" + strDQDW + "' and 团队编号 = " + intDQTD.ToString + " and 职级代码 like '020.%' and 职级代码 <> '020.010.005'"
								intCountB = .DefaultView.Count
								For j = 0 To intCountB - 1 Step 1
									strRYDM = objPulicParameters.getObjectValue(.DefaultView.Item(j).Item("人员代码"), "")
									strSSDW = objPulicParameters.getObjectValue(.DefaultView.Item(j).Item("所属单位"), "")
									strZJDM = objPulicParameters.getObjectValue(.DefaultView.Item(j).Item("职级代码"), "")
									strRYZM = objPulicParameters.getObjectValue(.DefaultView.Item(j).Item("人员名称"), "")
									intRYZT = objPulicParameters.getObjectValue(.DefaultView.Item(j).Item("人员状态"), 0)
									intSFZB = objPulicParameters.getObjectValue(.DefaultView.Item(j).Item("是否占编"), 0)
									intXGRY = -1 '无效
									'计算所属序列
									intSNo = Me.getSeriesNo(strZJDM, intXGRY)
									'设置序列项值
									strValues(intSeriesPtr(intSNo - 1)) = getNewCellValue(strRYZM, intXGRY, intSFZB)
									strStyles(intSeriesPtr(intSNo - 1)) = getCellStyle(strZJDM, intRYZT, intSFZB)
									'列指针移动
									intSeriesPtr(intSNo - 1) += 1
									'序列项汇总
									If intSFZB = 1 Then
										If strSeriesTotal(intSNo - 1) = "" Then
											intSeriesTotal(intSNo - 1) = intSeriesTotal(intSNo - 1) + 1
											strSeriesTotal(intSNo - 1) = strRYDM
										Else
											strTEMP = strSep + strSeriesTotal(intSNo - 1) + strSep
											If strTEMP.IndexOf(strSep + strRYDM + strSep) < 0 Then
												intSeriesTotal(intSNo - 1) = intSeriesTotal(intSNo - 1) + 1
												strSeriesTotal(intSNo - 1) = strSeriesTotal(intSNo - 1) + strSep + strRYDM
											End If
										End If
									End If
								Next
							End With

							'计算当前行(团队)的行政助理数据
							With Me.m_objDataSetBB.Tables(Me.m_cintTabNo_ZLJG)
								.DefaultView.RowFilter = "所属单位 = '" + strDQDW + "'"
								intCountB = .DefaultView.Count
								For j = 0 To intCountB - 1 Step 1
									strRYDM = objPulicParameters.getObjectValue(.DefaultView.Item(j).Item("人员代码"), "")
									strSSDW = objPulicParameters.getObjectValue(.DefaultView.Item(j).Item("所属单位"), "")
									strZJDM = objPulicParameters.getObjectValue(.DefaultView.Item(j).Item("职级代码"), "")
									strRYZM = objPulicParameters.getObjectValue(.DefaultView.Item(j).Item("人员名称"), "")
									intRYZT = objPulicParameters.getObjectValue(.DefaultView.Item(j).Item("人员状态"), 0)
									intSFZB = objPulicParameters.getObjectValue(.DefaultView.Item(j).Item("是否占编"), 0)
									intXGRY = -1 '无效
									'计算所属序列
									intSNo = Me.getSeriesNo(strZJDM, intXGRY)
									'设置序列项值
									strValues(intSeriesPtr(intSNo - 1)) = getNewCellValue(strRYZM, intXGRY, intSFZB)
									strStyles(intSeriesPtr(intSNo - 1)) = getCellStyle(strZJDM, intRYZT, intSFZB)
									'列指针移动
									intSeriesPtr(intSNo - 1) += 1
									'序列项汇总
									If intSFZB = 1 Then
										If strSeriesTotal(intSNo - 1) = "" Then
											intSeriesTotal(intSNo - 1) = intSeriesTotal(intSNo - 1) + 1
											strSeriesTotal(intSNo - 1) = strRYDM
										Else
											strTEMP = strSep + strSeriesTotal(intSNo - 1) + strSep
											If strTEMP.IndexOf(strSep + strRYDM + strSep) < 0 Then
												intSeriesTotal(intSNo - 1) = intSeriesTotal(intSNo - 1) + 1
												strSeriesTotal(intSNo - 1) = strSeriesTotal(intSNo - 1) + strSep + strRYDM
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
										If intDWHS > 1 Then
											If strDQDW <> strDQDWOld Then
												If strStyles(j) = "" Then
													Response.Write("    <td align='center' rowspan='" + intDWHS.ToString + "'>" + strValues(j) + "</td>" + vbCr)
												Else
													Response.Write("    <td align='center' rowspan='" + intDWHS.ToString + "' style='" + strStyles(j) + "'>" + strValues(j) + "</td>" + vbCr)
												End If
											End If
										Else
											If strStyles(j) = "" Then
												Response.Write("    <td align='center'>" + strValues(j) + "</td>" + vbCr)
											Else
												Response.Write("    <td align='center' style='" + strStyles(j) + "'>" + strValues(j) + "</td>" + vbCr)
											End If
										End If
									Case 2
										'团队
										If strStyles(j) = "" Then
											Response.Write("    <td align='center' width='80'>" + strValues(j) + "</td>" + vbCr)
										Else
											Response.Write("    <td align='center' width='80' style='" + strStyles(j) + "'>" + strValues(j) + "</td>" + vbCr)
										End If
									'zengxianglin 2010-03-17
									Case strValues.Length - 3
										'团队人数
										If strStyles(j) = "" Then
											Response.Write("    <td align='center' width='80'>" + strValues(j) + "</td>" + vbCr)
										Else
											Response.Write("    <td align='center' width='80' style='" + strStyles(j) + "'>" + strValues(j) + "</td>" + vbCr)
										End If
									'zengxianglin 2010-03-17
									Case strValues.Length - 2, strValues.Length - 1
										'[计划编制][实际编制]
										If intDWHS > 1 Then
											If strDQDW <> strDQDWOld Then
												If strStyles(j) = "" Then
													Response.Write("    <td align='right' rowspan='" + intDWHS.ToString + "'>" + strValues(j) + "</td>" + vbCr)
												Else
													Response.Write("    <td align='right' rowspan='" + intDWHS.ToString + "' style='" + strStyles(j) + "'>" + strValues(j) + "</td>" + vbCr)
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
										'zengxianglin 2010-03-17
										'If (j >= strValues.Length - 2 - m_intSeriesMaxColumns(7)) And (j < strValues.Length - 2) Then
										'zengxianglin 2010-03-17
										If (j >= strValues.Length - 3 - m_intSeriesMaxColumns(7)) And (j < strValues.Length - 3) Then
											'行政助理特殊处理
											If intDWHS > 1 Then
												If strDQDW <> strDQDWOld Then
													If strStyles(j) = "" Then
														Response.Write("    <td align='center' width='80' rowspan='" + intDWHS.ToString + "'>" + strValues(j) + "</td>" + vbCr)
													Else
														Response.Write("    <td align='center' width='80' rowspan='" + intDWHS.ToString + "' style='" + strStyles(j) + "'>" + strValues(j) + "</td>" + vbCr)
													End If
												End If
											Else
												If strStyles(j) = "" Then
													Response.Write("    <td align='center' width='80'>" + strValues(j) + "</td>" + vbCr)
												Else
													Response.Write("    <td align='center' width='80' style='" + strStyles(j) + "'>" + strValues(j) + "</td>" + vbCr)
												End If
											End If
										Else
											'其他正常序列
											If strStyles(j) = "" Then
												Response.Write("    <td align='center' width='80'>" + strValues(j) + "</td>" + vbCr)
											Else
												Response.Write("    <td align='center' width='80' style='" + strStyles(j) + "'>" + strValues(j) + "</td>" + vbCr)
											End If
										End If
								End Select
							Next
							Response.Write("  </tr>" + vbCr)

							'更换团队
							strDQDWOld = strDQDW
						Next
					End With

					'输出汇总
					Response.Write("  <tr height='36' bgcolor='#99cccc'>" + vbCr)
					Response.Write("    <td style='" + strBorderStyle + "' align='center' width='60'><b>总计</b></td>" + vbCr)
					Response.Write("    <td style='" + strBorderStyle + "' align='center' width='160'>&nbsp;</td>" + vbCr)
					Response.Write("    <td style='" + strBorderStyle + "' align='center' width='80'>&nbsp;</td>" + vbCr)
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
					If m_intSeriesMaxColumns(6) > 1 Then
						Response.Write("    <td style='" + strBorderStyle + "' align='right' colspan='" + m_intSeriesMaxColumns(6).ToString + "'><b>" + intSeriesTotal(6).ToString + "</b></td>" + vbCr)
					Else
						Response.Write("    <td style='" + strBorderStyle + "' align='right'><b>" + intSeriesTotal(6).ToString + "</b></td>" + vbCr)
					End If
					If m_intSeriesMaxColumns(7) > 1 Then
						Response.Write("    <td style='" + strBorderStyle + "' align='right' colspan='" + m_intSeriesMaxColumns(7).ToString + "'><b>" + intSeriesTotal(7).ToString + "</b></td>" + vbCr)
					Else
						Response.Write("    <td style='" + strBorderStyle + "' align='right'><b>" + intSeriesTotal(7).ToString + "</b></td>" + vbCr)
					End If
					'zengxianglin 2010-03-17
					Response.Write("    <td style='" + strBorderStyle + "' align='right' width='80'><b>" + intTotalTDRS.ToString + "</b></td>" + vbCr)
					'zengxianglin 2010-03-17
					Response.Write("    <td style='" + strBorderStyle + "' align='right' width='80'><b>" + intTotalJHBZ.ToString + "</b></td>" + vbCr)
					Response.Write("    <td style='" + strBorderStyle + "' align='right' width='80'><b>" + intTotalSJBZ.ToString + "</b></td>" + vbCr)
					Response.Write("  </tr>" + vbCr)
					Response.Write("</TABLE>")
				Catch ex As Exception
				End Try
				Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
			End Sub
        </script>
		<script language="javascript">
		<!--
			function btnCloseWin_onClick()
			{
		        if (document.getElementById("spanCloseWin") == null)
		            return;
		        window.close();
			}
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
        <form id="frmestate_rs_renyuanjiagou_bdls_x2" method="post" runat="server">
            <asp:panel id="panelMain" Runat="server">
                <TABLE cellSpacing="0" cellPadding="0" border="0">
                    <TR id="trRow01">
                        <TD height="30" vAlign="middle" align="left" class="title" style="BORDER-BOTTOM: #99cccc 2px solid">当前位置：人事管理&nbsp;&gt;&gt;&gt;&gt;&nbsp;人员架构变动查询<asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton></TD>
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
                                                    <td colspan="6" align="center" style="BORDER-RIGHT: black 2px solid; BORDER-BOTTOM: black 1px solid">物业顾问</td>
                                                    <td colspan="5" align="center" style="BORDER-BOTTOM: black 1px solid">文员</td>
                                                </tr>
                                                <tr height="48" valign="middle">
                                                    <td style="BORDER-RIGHT: black 1px solid;" align="center" width="40" bgcolor="Red">资深</td>
                                                    <td style="BORDER-RIGHT: black 1px solid;" align="center" width="40" bgcolor="Fuchsia">高级</td>
                                                    <td style="BORDER-RIGHT: black 2px solid;" align="center" width="40" bgcolor="Pink">总监</td>
                                                    
                                                    <td style="BORDER-RIGHT: black 1px solid;" align="center" width="40" bgcolor="Teal">资深</td>
                                                    <td style="BORDER-RIGHT: black 1px solid;" align="center" width="40" bgcolor="Lime">高级</td>
                                                    <td style="BORDER-RIGHT: black 1px solid;" align="center" width="40" bgcolor="MediumSpringGreen">中级</td>
                                                    <td style="BORDER-RIGHT: black 2px solid;" align="center" width="40" bgcolor="LightGreen">区域<br>经理</td>
                                                    
                                                    <td style="BORDER-RIGHT: black 1px solid;" align="center" width="40" bgcolor="Silver">资深</td>
                                                    <td style="BORDER-RIGHT: black 1px solid;" align="center" width="40" bgcolor="Blue">高级</td>
                                                    <td style="BORDER-RIGHT: black 1px solid;" align="center" width="40" bgcolor="DeepSkyBlue">中级</td>
                                                    <td style="BORDER-RIGHT: black 1px solid;" align="center" width="40" bgcolor="LightBlue">营业<br>经理</td>
                                                    <td style="BORDER-RIGHT: black 2px solid;" align="center" width="40" bgcolor="LightCyan">业务<br>经理</td>

                                                    <td style="BORDER-RIGHT: black 1px solid;" align="center" width="40" bgcolor="DodgerBlue">客户<br>经理</td>
                                                    <td style="BORDER-RIGHT: black 1px solid;" align="center" width="40" bgcolor="RoyalBlue">营业<br>主任</td>
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
											if propAutoDisplay = true then
												doDisplayData()
												propAutoDisplay = false
											else
												response.write("&nbsp;")
											end if
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
                                                    <td>&nbsp;&nbsp;(1) 带下划线表示试用期员工，带删除线表示实习生</td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;&nbsp;(2) 名字后面带*号的不占团队编制</td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;&nbsp;(3) 不占团队编制的管理人员白色底色表示</td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;&nbsp;(4) 名字前面带@号的是团队直管</td>
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
                            <input      id="btnPrint"  type="button"  class="button"    value=" 打印架构 " style="HEIGHT: 32px" onclick="btnPrint_onClick();">
                            <asp:Button id="btnTongbu" Runat="server" CssClass="button" Text =" 信息同步 " Height="32px"></asp:Button>
                            <span id="spanClose" style="display:">
                            <asp:Button id="btnClose"  Runat="server" CssClass="button" Text =" 返    回 " Height="32px"></asp:Button>
                            </span>
                            <span id="spanCloseWin" style="display:none">
                            <input id="btnCloseWin"    type="button"  class="button"    value=" 关    闭 " style="HEIGHT: 32px" onclick="btnCloseWin_onClick()">
                            </span>
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
                        <input id="htxtCanPrint" type="hidden" runat="server" value="0" NAME="htxtCanPrint">
                        <input id="htxtDivLeftMain" type="hidden" runat="server" NAME="htxtDivLeftMain">
                        <input id="htxtDivTopMain" type="hidden" runat="server" NAME="htxtDivTopMain">
                        <input id="htxtDivLeftBody" type="hidden" runat="server" NAME="htxtDivLeftBody">
                        <input id="htxtDivTopBody" type="hidden" runat="server" NAME="htxtDivTopBody">
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
