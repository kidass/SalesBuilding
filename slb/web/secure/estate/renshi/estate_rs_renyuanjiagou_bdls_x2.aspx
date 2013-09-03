<%@ Page Language="vb" AutoEventWireup="false" Codebehind="estate_rs_renyuanjiagou_bdls_x2.aspx.vb" Inherits="Josco.JSOA.web.estate_rs_renyuanjiagou_bdls_x2" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
    <HEAD>
        <title>��Ա����ܹ��䶯��ʷ�鿴��(ģʽ��)</title>
        <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
        <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
        <meta content="JavaScript" name="vs_defaultClientScript">
        <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <LINK href="../../../stylesw.css" type="text/css" rel="stylesheet">
        <script src="../../../scripts/transkey.js"></script>
        <script language="vb" runat="server">
			'����������Ϣ
			Public Const m_cintSeries As Integer = 7 '0-�ܼ�,1-����,2-Ӫ��ֱ��,3-Ӫ��Э��,4-ҵ��,5-�ͻ�����,6-����,7-��Ա
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

			'�����õ�����
			Public m_objDataSetBB As System.Data.DataSet = Nothing

			'��ʼ����־
			Public m_blnInitialized As Boolean = False

			'������ʱ��
			Public m_objTime As System.DateTime

			'׼����������
			Public Function doPrepareData() As Boolean
				Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
				Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
				Dim strErrMsg As String = ""
				Try
					'����ʱ�����
					Me.m_objTime = propJCSJ
					'�������¼���
					If Me.m_blnInitialized = True Then
						Exit Try
					End If
					'��������
					Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(Me.m_objDataSetBB)
					If objsystemEstateRenshiXingye.getDataSet_RYJG_X2(strErrMsg, "sa","20080701xiugai", Me.m_objTime.ToString("yyyy-MM-dd"), Me.m_objDataSetBB) = False Then
						Exit Try
					End If
					'������е��������
					If Not (Me.m_objDataSetBB.Tables(Me.m_cintTabNo_BBCS) Is Nothing) Then
						With Me.m_objDataSetBB.Tables(Me.m_cintTabNo_BBCS)
							m_intSeriesMaxColumns(0) = objPulicParameters.getObjectValue(.Rows(0).Item("�ܼ�����"), 1)
							m_intSeriesMaxColumns(1) = objPulicParameters.getObjectValue(.Rows(0).Item("��������"), 1)
							m_intSeriesMaxColumns(2) = objPulicParameters.getObjectValue(.Rows(0).Item("Ӫֱ����"), 1)
							m_intSeriesMaxColumns(3) = objPulicParameters.getObjectValue(.Rows(0).Item("ӪЭ����"), 1)
							m_intSeriesMaxColumns(4) = objPulicParameters.getObjectValue(.Rows(0).Item("ҵ������"), 1)
							m_intSeriesMaxColumns(5) = objPulicParameters.getObjectValue(.Rows(0).Item("�;�����"), 1)
							m_intSeriesMaxColumns(6) = objPulicParameters.getObjectValue(.Rows(0).Item("��������"), 1)
							m_intSeriesMaxColumns(7) = objPulicParameters.getObjectValue(.Rows(0).Item("��Ա����"), 1)
							m_intMaxRows = objPulicParameters.getObjectValue(.Rows(0).Item("��������"), 1)
							m_intMaxCols = objPulicParameters.getObjectValue(.Rows(0).Item("��������"), 1)
						End With
					End If
					'����ѳ�ʼ��
					Me.m_blnInitialized = True
					doPrepareData = True
				Catch ex As Exception
					doPrepareData = False
				End Try
				Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
				Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
			End Function
			
			'������Ա��������(1,2,3,4,5,6,7,8)
			Public Function getSeriesNo(ByVal strZJDM As String, ByVal intXGRY As Integer) As Integer
				Try
					Select Case strZJDM
						'*********************
						'�����ܼ༶
						Case "010.010.010"
							getSeriesNo = 1
						Case "010.010.020"
							getSeriesNo = 1
						Case "010.010.030"
							getSeriesNo = 1

						'*********************
						'������
						Case "010.020.010"
							getSeriesNo = 2
						Case "010.020.020"
							getSeriesNo = 2
						Case "010.020.025"
							getSeriesNo = 2
						Case "010.020.030"
							getSeriesNo = 2

						'*********************
						'Ӫҵ����
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
						'ҵ����
						Case "010.030.050"
							getSeriesNo = 5

						'*********************
						'�ͻ�����
						Case "020.010.005"
							getSeriesNo = 6

						'*********************
						'��ҵ���ʼ�
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
						'��������
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
						'Ĭ��Ϊ��ҵ����
						Case Else
							getSeriesNo = 7
					End Select
				Catch ex As Exception
					getSeriesNo = 7
				End Try
			End Function

			'���㵥Ԫ���style��Ϣ
			Public Function getCellStyle(ByVal strZJDM As String, ByVal intRYZT As Integer, ByVal intSFZB As Integer) As String
				Try
					Dim strTextDecoration As String = ""
					Dim strBkColor As String = ""
					Select Case strZJDM
						'*********************
						'�����ܼ༶
						Case "010.010.010"
							strBkColor = "Red"
						Case "010.010.020"
							strBkColor = "Fuchsia"
						Case "010.010.030"
							strBkColor = "Pink"

						'*********************
						'������
						Case "010.020.010"
							strBkColor = "Teal"
						Case "010.020.020"
							strBkColor = "Lime"
						Case "010.020.025"
							strBkColor = "MediumSpringGreen"
						Case "010.020.030"
							strBkColor = "LightGreen"

						'*********************
						'Ӫҵ����
						Case "010.030.010"
							strBkColor = "Silver"
						Case "010.030.020"
							strBkColor = "Blue"
						Case "010.030.030"
							strBkColor = "DeepSkyBlue"
						Case "010.030.040"
							strBkColor = "LightBlue"

						'*********************
						'ҵ����
						Case "010.030.050"
							strBkColor = "LightCyan"

						'*********************
						'�ͻ�����
						Case "020.010.005"
							strBkColor = "DodgerBlue"

						'*********************
						'��ҵ���ʼ�
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
						'��������
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
						'Ĭ�ϴ���
						Case Else
							strBkColor = "white"
					End Select

					'��ռ��
					If intSFZB = 0 Then
						strBkColor = "white"
					End If

					'������Ա
					If (intRYZT And 1) = 1 Then
						strTextDecoration = "underline"
					End If
					'ʵϰ��
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

			'���㵥Ԫ���style��Ϣ
			Public Function getNewCellValue(ByVal strValue As String, ByVal intXGRY As Integer, ByVal intSFZB As Integer) As String
				Try
					'��ռ��(*)
					If intSFZB = 0 Then
						getNewCellValue = strValue + "*"
					Else
						getNewCellValue = strValue
					End If
					'ֱ��(@)
					If intXGRY = 0 Then
						getNewCellValue = "@" + getNewCellValue
					End If
				Catch ex As Exception
					getNewCellValue = strValue
				End Try
			End Function

			'��ʾ�������
			Public Sub doDisplayData()
				Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
				Dim strErrMsg As String = ""
				Try
					'��ʼ��
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

					'�����ͷ
					Response.Write("  <tr height='36' bgcolor='#99cccc'>" + vbCr)
					Response.Write("    <td style='" + strBorderStyle + "' align='center'><b>���</b></td>" + vbCr)
					Response.Write("    <td style='" + strBorderStyle + "' align='center' width='160'><b>����</b></td>" + vbCr)
					Response.Write("    <td style='" + strBorderStyle + "' align='center' width='80'><b>�Ŷ�</b></td>" + vbCr)
					If m_intSeriesMaxColumns(0) > 1 Then
						Response.Write("    <td style='" + strBorderStyle + "' align='center' colspan='" + Me.m_intSeriesMaxColumns(0).ToString + "'><b>����<br>�ܼ�</b></td>" + vbCr)
					Else
						Response.Write("    <td style='" + strBorderStyle + "' align='center'><b>����<br>�ܼ�</b></td>" + vbCr)
					End If
					If m_intSeriesMaxColumns(1) > 1 Then
						Response.Write("    <td style='" + strBorderStyle + "' align='center' colspan='" + Me.m_intSeriesMaxColumns(1).ToString + "'><b>����<br>����</b></td>" + vbCr)
					Else
						Response.Write("    <td style='" + strBorderStyle + "' align='center'><b>����<br>����</b></td>" + vbCr)
					End If
					If m_intSeriesMaxColumns(2) > 1 Then
						Response.Write("    <td style='" + strBorderStyle + "' align='center' colspan='" + Me.m_intSeriesMaxColumns(2).ToString + "'><b>Ӫ��<br>ֱ��</b></td>" + vbCr)
					Else
						Response.Write("    <td style='" + strBorderStyle + "' align='center'><b>Ӫ��<br>ֱ��</b></td>" + vbCr)
					End If
					If m_intSeriesMaxColumns(3) > 1 Then
						Response.Write("    <td style='" + strBorderStyle + "' align='center' colspan='" + Me.m_intSeriesMaxColumns(3).ToString + "'><b>Ӫ��<br>Э��</b></td>" + vbCr)
					Else
						Response.Write("    <td style='" + strBorderStyle + "' align='center'><b>Ӫ��<br>Э��</b></td>" + vbCr)
					End If
					If m_intSeriesMaxColumns(4) > 1 Then
						Response.Write("    <td style='" + strBorderStyle + "' align='center' colspan='" + Me.m_intSeriesMaxColumns(4).ToString + "'><b>ҵ��<br>����</b></td>" + vbCr)
					Else
						Response.Write("    <td style='" + strBorderStyle + "' align='center'><b>ҵ��<br>����</b></td>" + vbCr)
					End If
					If m_intSeriesMaxColumns(5) > 1 Then
						Response.Write("    <td style='" + strBorderStyle + "' align='center' colspan='" + Me.m_intSeriesMaxColumns(5).ToString + "'><b>�ͻ�<br>����</b></td>" + vbCr)
					Else
						Response.Write("    <td style='" + strBorderStyle + "' align='center'><b>�ͻ�<br>����</b></td>" + vbCr)
					End If
					If m_intSeriesMaxColumns(6) > 1 Then
						Response.Write("    <td style='" + strBorderStyle + "' align='center' colspan='" + Me.m_intSeriesMaxColumns(6).ToString + "'><b>��ҵ����</b></td>" + vbCr)
					Else
						Response.Write("    <td style='" + strBorderStyle + "' align='center'><b>��ҵ����</b></td>" + vbCr)
					End If
					If m_intSeriesMaxColumns(7) > 1 Then
						Response.Write("    <td style='" + strBorderStyle + "' align='center' colspan='" + Me.m_intSeriesMaxColumns(7).ToString + "'><b>��Ա</b></td>" + vbCr)
					Else
						Response.Write("    <td style='" + strBorderStyle + "' align='center'><b>��Ա</b></td>" + vbCr)
					End If
					'zengxianglin 2010-03-17
					Response.Write("    <td style='" + strBorderStyle + "' align='center'><b>�Ŷ�<br>����</b></td>" + vbCr)
					'zengxianglin 2010-03-17
					Response.Write("    <td style='" + strBorderStyle + "' align='center'><b>�ƻ�<br>����</b></td>" + vbCr)
					Response.Write("    <td style='" + strBorderStyle + "' align='center'><b>ʵ��<br>����</b></td>" + vbCr)
					Response.Write("  </tr>" + vbCr)

					'�������
					Dim strSep As String = Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate
					'zengxianglin 2010-03-17
					'Dim strStyles(intDataCols + 5 - 1) As String '0��ʼ
					'Dim strValues(intDataCols + 5 - 1) As String '0��ʼ
					Dim strStyles(intDataCols + 6 - 1) As String '0��ʼ
					Dim strValues(intDataCols + 6 - 1) As String '0��ʼ
					'zengxianglin 2010-03-17
					Dim strSeriesTotal(m_cintSeries) As String   '���м�����(���ŷָ�)
					Dim intSeriesTotal(m_cintSeries) As Integer  '���л�����
					Dim intSeriesPtr(m_cintSeries) As Integer    '���п�ʼ��
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

					'��Ա�ܹ����ݿ�ʼ���
					With Me.m_objDataSetBB.Tables(Me.m_cintTabNo_SYSJ)
						'��ʼ�������еĻ������������б�
						For i = 0 To intSeriesTotal.Length - 1 Step 1
							intSeriesTotal(i) = 0
						Next
						For i = 0 To strSeriesTotal.Length - 1 Step 1
							strSeriesTotal(i) = ""
						Next

						'����ŶӴ���
						intCountA = .Rows.Count
						For i = 0 To intCountA - 1 Step 1
							'��ʼ�����еĿ�ʼ��ָ��
							intSeriesPtr(0) = 3 '�ܼ࿪ʼ
							intSeriesPtr(1) = intSeriesPtr(0) + m_intSeriesMaxColumns(0)
							intSeriesPtr(2) = intSeriesPtr(1) + m_intSeriesMaxColumns(1)
							intSeriesPtr(3) = intSeriesPtr(2) + m_intSeriesMaxColumns(2)
							intSeriesPtr(4) = intSeriesPtr(3) + m_intSeriesMaxColumns(3)
							intSeriesPtr(5) = intSeriesPtr(4) + m_intSeriesMaxColumns(4)
							intSeriesPtr(6) = intSeriesPtr(5) + m_intSeriesMaxColumns(5)
							intSeriesPtr(7) = intSeriesPtr(6) + m_intSeriesMaxColumns(6)

							'��ʼ���������е���ֵ����ʾ��ʽ
							For j = 0 To strValues.Length - 1 Step 1
								strValues(j) = ""
							Next
							For j = 0 To strStyles.Length - 1 Step 1
								strStyles(j) = ""
							Next

							'��ȡ��ǰ��(�Ŷ�)����������
							strDQDW = objPulicParameters.getObjectValue(.Rows(i).Item("������λ"), "")
							intDQTD = objPulicParameters.getObjectValue(.Rows(i).Item("�Ŷӱ��"), 0)
							intDWHS = objPulicParameters.getObjectValue(.Rows(i).Item("��λ����"), 1)
							'zengxianglin 2010-03-17
							intTDRS = objPulicParameters.getObjectValue(.Rows(i).Item("�Ŷ�����"), 0)
							intTotalTDRS += intTDRS
							'zengxianglin 2010-03-17

							'���㵱ǰ��(�Ŷ�)�ĵ�λ����
							'zengxianglin 2010-03-17
							strValues(strValues.Length - 3) = intTDRS.ToString()
							'zengxianglin 2010-03-17
							With Me.m_objDataSetBB.Tables(Me.m_cintTabNo_DWXX)
								.DefaultView.RowFilter = "������λ = '" + strDQDW + "'"
								If .DefaultView.Count > 0 Then
									strValues(0) = objPulicParameters.getObjectValue(.DefaultView.Item(0).Item("��λ���"), "")
									strValues(1) = objPulicParameters.getObjectValue(.DefaultView.Item(0).Item("��λ����"), "")
									strValues(2) = intDQTD.ToString
									If strDQDWOld <> strDQDW Then
										j = objPulicParameters.getObjectValue(.DefaultView.Item(0).Item("��������"), 0)
										strValues(strValues.Length - 2) = j.ToString()
										intTotalJHBZ += j
									End If
									If strDQDWOld <> strDQDW Then
										j = objPulicParameters.getObjectValue(.DefaultView.Item(0).Item("ʵ�ʱ���"), 0)
										strValues(strValues.Length - 1) = j.ToString()
										intTotalSJBZ += j
									End If
								End If
							End With

							'���㵱ǰ��(�Ŷ�)���ܼࡢ������Ӫ��ֱ�ܡ�Ӫ��Э�ܡ�ҵ��������
							For k = 0 To 4 Step 1
								Select Case k
									Case 0
										'���㵱ǰ�е��ܼ�����
										intTNo = Me.m_cintTabNo_QYZJ
									Case 1
										'���㵱ǰ�е���������
										intTNo = Me.m_cintTabNo_QYJL
									Case 2
										'���㵱ǰ�е�Ӫ��ֱ������
										intTNo = Me.m_cintTabNo_YYJL_ZG
									Case 3
										'���㵱ǰ�е�Ӫ��Э������
										intTNo = Me.m_cintTabNo_YYJL_XG
									Case 4
										'���㵱ǰ�е�ҵ������
										intTNo = Me.m_cintTabNo_YWJL
								End Select

								'����Ŷӹ�������Ա����
								With Me.m_objDataSetBB.Tables(intTNo)
									.DefaultView.RowFilter = "������λ = '" + strDQDW + "' and �Ŷӱ�� = " + intDQTD.ToString
									intCountB = .DefaultView.Count
									For j = 0 To intCountB - 1 Step 1
										strRYDM = objPulicParameters.getObjectValue(.DefaultView.Item(j).Item("��Ա����"), "")
										intXGRY = objPulicParameters.getObjectValue(.DefaultView.Item(j).Item("�Ƿ�ֱ��"), 0)
										intXGRY = 1 - intXGRY
										With Me.m_objDataSetBB.Tables(Me.m_cintTabNo_GLJG)
											.DefaultView.RowFilter = "��Ա���� = '" + strRYDM + "'"
											If .DefaultView.Count > 0 Then
												strSSDW = objPulicParameters.getObjectValue(.DefaultView.Item(0).Item("������λ"), "")
												strZJDM = objPulicParameters.getObjectValue(.DefaultView.Item(0).Item("ְ������"), "")
												strRYZM = objPulicParameters.getObjectValue(.DefaultView.Item(0).Item("��Ա����"), "")
												intRYZT = objPulicParameters.getObjectValue(.DefaultView.Item(0).Item("��Ա״̬"), 0)
												intSFZB = objPulicParameters.getObjectValue(.DefaultView.Item(0).Item("�Ƿ�ռ��"), 0)
												intTDBH = objPulicParameters.getObjectValue(.DefaultView.Item(0).Item("�Ŷӱ��"), 0)
												'ռ�ࣿ
												If Not (strDQDW = strSSDW And intDQTD = intTDBH) Then
													intSFZB = 0
												End If
												'������������
												intSNo = Me.getSeriesNo(strZJDM, intXGRY)
												'����������ֵ
												strValues(intSeriesPtr(intSNo - 1)) = getNewCellValue(strRYZM, intXGRY, intSFZB)
												strStyles(intSeriesPtr(intSNo - 1)) = getCellStyle(strZJDM, intRYZT, intSFZB)
												'��ָ���ƶ�
												intSeriesPtr(intSNo - 1) += 1
												'���������
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

							'���㵱ǰ��(�Ŷ�)�Ŀͻ���������
							With Me.m_objDataSetBB.Tables(Me.m_cintTabNo_GLJG)
								.DefaultView.RowFilter = "������λ = '" + strDQDW + "' and �Ŷӱ�� = " + intDQTD.ToString + " and ְ������ = '020.010.005'"
								intCountB = .DefaultView.Count
								For j = 0 To intCountB - 1 Step 1
									strRYDM = objPulicParameters.getObjectValue(.DefaultView.Item(j).Item("��Ա����"), "")
									strSSDW = objPulicParameters.getObjectValue(.DefaultView.Item(j).Item("������λ"), "")
									strZJDM = objPulicParameters.getObjectValue(.DefaultView.Item(j).Item("ְ������"), "")
									strRYZM = objPulicParameters.getObjectValue(.DefaultView.Item(j).Item("��Ա����"), "")
									intRYZT = objPulicParameters.getObjectValue(.DefaultView.Item(j).Item("��Ա״̬"), 0)
									intSFZB = objPulicParameters.getObjectValue(.DefaultView.Item(j).Item("�Ƿ�ռ��"), 0)
									intXGRY = -1 '��Ч
									'������������
									intSNo = Me.getSeriesNo(strZJDM, intXGRY)
									'����������ֵ
									strValues(intSeriesPtr(intSNo - 1)) = getNewCellValue(strRYZM, intXGRY, intSFZB)
									strStyles(intSeriesPtr(intSNo - 1)) = getCellStyle(strZJDM, intRYZT, intSFZB)
									'��ָ���ƶ�
									intSeriesPtr(intSNo - 1) += 1
									'���������
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

							'���㵱ǰ��(�Ŷ�)����ҵ��������
							With Me.m_objDataSetBB.Tables(Me.m_cintTabNo_GLJG)
								.DefaultView.RowFilter = "������λ = '" + strDQDW + "' and �Ŷӱ�� = " + intDQTD.ToString + " and ְ������ like '020.%' and ְ������ <> '020.010.005'"
								intCountB = .DefaultView.Count
								For j = 0 To intCountB - 1 Step 1
									strRYDM = objPulicParameters.getObjectValue(.DefaultView.Item(j).Item("��Ա����"), "")
									strSSDW = objPulicParameters.getObjectValue(.DefaultView.Item(j).Item("������λ"), "")
									strZJDM = objPulicParameters.getObjectValue(.DefaultView.Item(j).Item("ְ������"), "")
									strRYZM = objPulicParameters.getObjectValue(.DefaultView.Item(j).Item("��Ա����"), "")
									intRYZT = objPulicParameters.getObjectValue(.DefaultView.Item(j).Item("��Ա״̬"), 0)
									intSFZB = objPulicParameters.getObjectValue(.DefaultView.Item(j).Item("�Ƿ�ռ��"), 0)
									intXGRY = -1 '��Ч
									'������������
									intSNo = Me.getSeriesNo(strZJDM, intXGRY)
									'����������ֵ
									strValues(intSeriesPtr(intSNo - 1)) = getNewCellValue(strRYZM, intXGRY, intSFZB)
									strStyles(intSeriesPtr(intSNo - 1)) = getCellStyle(strZJDM, intRYZT, intSFZB)
									'��ָ���ƶ�
									intSeriesPtr(intSNo - 1) += 1
									'���������
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

							'���㵱ǰ��(�Ŷ�)��������������
							With Me.m_objDataSetBB.Tables(Me.m_cintTabNo_ZLJG)
								.DefaultView.RowFilter = "������λ = '" + strDQDW + "'"
								intCountB = .DefaultView.Count
								For j = 0 To intCountB - 1 Step 1
									strRYDM = objPulicParameters.getObjectValue(.DefaultView.Item(j).Item("��Ա����"), "")
									strSSDW = objPulicParameters.getObjectValue(.DefaultView.Item(j).Item("������λ"), "")
									strZJDM = objPulicParameters.getObjectValue(.DefaultView.Item(j).Item("ְ������"), "")
									strRYZM = objPulicParameters.getObjectValue(.DefaultView.Item(j).Item("��Ա����"), "")
									intRYZT = objPulicParameters.getObjectValue(.DefaultView.Item(j).Item("��Ա״̬"), 0)
									intSFZB = objPulicParameters.getObjectValue(.DefaultView.Item(j).Item("�Ƿ�ռ��"), 0)
									intXGRY = -1 '��Ч
									'������������
									intSNo = Me.getSeriesNo(strZJDM, intXGRY)
									'����������ֵ
									strValues(intSeriesPtr(intSNo - 1)) = getNewCellValue(strRYZM, intXGRY, intSFZB)
									strStyles(intSeriesPtr(intSNo - 1)) = getCellStyle(strZJDM, intRYZT, intSFZB)
									'��ָ���ƶ�
									intSeriesPtr(intSNo - 1) += 1
									'���������
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

							'���뱾������
							For j = 0 To strValues.Length - 1 Step 1
								If strStyles(j) Is Nothing Then strStyles(j) = ""
								strStyles(j) = strStyles(j) + strBorderStyle + "FONT-SIZE: 12px; FONT-FAMILY: ����;"
								If strValues(j) Is Nothing Then strValues(j) = ""
								If strValues(j) = "" Then strValues(j) = "&nbsp;"
							Next
							Response.Write("  <tr height='24' valign='middle'>" + vbCr)
							For j = 0 To strValues.Length - 1 Step 1
								Select Case j
									Case 0, 1
										'[��λ���][��λ����]
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
										'�Ŷ�
										If strStyles(j) = "" Then
											Response.Write("    <td align='center' width='80'>" + strValues(j) + "</td>" + vbCr)
										Else
											Response.Write("    <td align='center' width='80' style='" + strStyles(j) + "'>" + strValues(j) + "</td>" + vbCr)
										End If
									'zengxianglin 2010-03-17
									Case strValues.Length - 3
										'�Ŷ�����
										If strStyles(j) = "" Then
											Response.Write("    <td align='center' width='80'>" + strValues(j) + "</td>" + vbCr)
										Else
											Response.Write("    <td align='center' width='80' style='" + strStyles(j) + "'>" + strValues(j) + "</td>" + vbCr)
										End If
									'zengxianglin 2010-03-17
									Case strValues.Length - 2, strValues.Length - 1
										'[�ƻ�����][ʵ�ʱ���]
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
											'�����������⴦��
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
											'������������
											If strStyles(j) = "" Then
												Response.Write("    <td align='center' width='80'>" + strValues(j) + "</td>" + vbCr)
											Else
												Response.Write("    <td align='center' width='80' style='" + strStyles(j) + "'>" + strValues(j) + "</td>" + vbCr)
											End If
										End If
								End Select
							Next
							Response.Write("  </tr>" + vbCr)

							'�����Ŷ�
							strDQDWOld = strDQDW
						Next
					End With

					'�������
					Response.Write("  <tr height='36' bgcolor='#99cccc'>" + vbCr)
					Response.Write("    <td style='" + strBorderStyle + "' align='center' width='60'><b>�ܼ�</b></td>" + vbCr)
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
		        objwindow = window.open("/��Ա�ܹ�һ����.doc","_blank","height=" + strHeight + ",width=" + strWidth + ",status=yes,toolbar=yes,menubar=yes,location=yes,resizable=yes,scrollbars=yes");
		        objwindow.document.clear()
		        objwindow.document.write("<META HTTP-EQUIV='Content-Type' CONTENT='application/msword'>");
		        objwindow.document.writeln("<TABLE cellSpacing='0' cellPadding='0' border='0' width='100%'>");
		        objwindow.document.writeln("  <TR height='32' valign='middle'>");
		        objwindow.document.writeln("    <TD align='center' style='FONT-SIZE: 32px; FONT-FAMILY: ����'>");
		        objwindow.document.writeln("      ��Ա�ܹ���");
		        objwindow.document.writeln("    </TD>");
		        objwindow.document.writeln("  </TR>");
		        objwindow.document.writeln("  <TR height='24' valign='middle'>");
		        objwindow.document.writeln("    <TD align='center' style='FONT-SIZE: 11pt; FONT-FAMILY: ����; BORDER-BOTTOM: black 2px solid;'>");
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
				
				intWidth   = document.body.clientWidth;   //�ܿ��
				intWidth  -= 16;                          //������
				strWidth   = intWidth.toString() + "px";
				
				intHeight  = document.body.clientHeight;  //�ܸ߶�
				intHeight -= 16;                          //������
				intHeight -= trRow01.clientHeight;
				intHeight -= trRow02.clientHeight;
				strHeight  = intHeight.toString() + "px";

				document.all("divMain").style.width  = strWidth;
				document.all("divMain").style.height = strHeight;
				document.all("divMain").style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";
			}
			function document_onreadystatechange() 
			{
			    //���ƴ�ӡ
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
			    //��������
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
                        <TD height="30" vAlign="middle" align="left" class="title" style="BORDER-BOTTOM: #99cccc 2px solid">��ǰλ�ã����¹���&nbsp;&gt;&gt;&gt;&gt;&nbsp;��Ա�ܹ��䶯��ѯ<asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton></TD>
                        <td height="30" vAlign="middle" align="right"class="title" style="BORDER-BOTTOM: #99cccc 2px solid">��ѯʱ�䣺<asp:TextBox ID="txtJCSJ" Runat="server" CssClass="textbox" Columns="10"></asp:TextBox><asp:Button ID="btnDisplay" Runat="server" CssClass="button" Text="��ʾ�ܹ�"></asp:Button></td>
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
                                                    <td colspan="3" align="center" style="BORDER-RIGHT: black 2px solid; BORDER-BOTTOM: black 1px solid">�����ܼ�</td>
                                                    <td colspan="4" align="center" style="BORDER-RIGHT: black 2px solid; BORDER-BOTTOM: black 1px solid">������</td>
                                                    <td colspan="5" align="center" style="BORDER-RIGHT: black 2px solid; BORDER-BOTTOM: black 1px solid">Ӫҵ����</td>
                                                    <td colspan="6" align="center" style="BORDER-RIGHT: black 2px solid; BORDER-BOTTOM: black 1px solid">��ҵ����</td>
                                                    <td colspan="5" align="center" style="BORDER-BOTTOM: black 1px solid">��Ա</td>
                                                </tr>
                                                <tr height="48" valign="middle">
                                                    <td style="BORDER-RIGHT: black 1px solid;" align="center" width="40" bgcolor="Red">����</td>
                                                    <td style="BORDER-RIGHT: black 1px solid;" align="center" width="40" bgcolor="Fuchsia">�߼�</td>
                                                    <td style="BORDER-RIGHT: black 2px solid;" align="center" width="40" bgcolor="Pink">�ܼ�</td>
                                                    
                                                    <td style="BORDER-RIGHT: black 1px solid;" align="center" width="40" bgcolor="Teal">����</td>
                                                    <td style="BORDER-RIGHT: black 1px solid;" align="center" width="40" bgcolor="Lime">�߼�</td>
                                                    <td style="BORDER-RIGHT: black 1px solid;" align="center" width="40" bgcolor="MediumSpringGreen">�м�</td>
                                                    <td style="BORDER-RIGHT: black 2px solid;" align="center" width="40" bgcolor="LightGreen">����<br>����</td>
                                                    
                                                    <td style="BORDER-RIGHT: black 1px solid;" align="center" width="40" bgcolor="Silver">����</td>
                                                    <td style="BORDER-RIGHT: black 1px solid;" align="center" width="40" bgcolor="Blue">�߼�</td>
                                                    <td style="BORDER-RIGHT: black 1px solid;" align="center" width="40" bgcolor="DeepSkyBlue">�м�</td>
                                                    <td style="BORDER-RIGHT: black 1px solid;" align="center" width="40" bgcolor="LightBlue">Ӫҵ<br>����</td>
                                                    <td style="BORDER-RIGHT: black 2px solid;" align="center" width="40" bgcolor="LightCyan">ҵ��<br>����</td>

                                                    <td style="BORDER-RIGHT: black 1px solid;" align="center" width="40" bgcolor="DodgerBlue">�ͻ�<br>����</td>
                                                    <td style="BORDER-RIGHT: black 1px solid;" align="center" width="40" bgcolor="RoyalBlue">Ӫҵ<br>����</td>
                                                    <td style="BORDER-RIGHT: black 1px solid;" align="center" width="40" bgcolor="DarkKhaki">����</td>
                                                    <td style="BORDER-RIGHT: black 1px solid;" align="center" width="40" bgcolor="YellowGreen">�߼�</td>
                                                    <td style="BORDER-RIGHT: black 1px solid;" align="center" width="40" bgcolor="Orange">�м�</td>
                                                    <td style="BORDER-RIGHT: black 2px solid;" align="center" width="40" bgcolor="white">����</td>

                                                    <td style="BORDER-RIGHT: black 1px solid;" align="center" width="40" bgcolor="PowderBlue">����</td>
                                                    <td style="BORDER-RIGHT: black 1px solid;" align="center" width="40" bgcolor="CornflowerBlue">����</td>
                                                    <td style="BORDER-RIGHT: black 1px solid;" align="center" width="40" bgcolor="LightSkyBlue">�߼�</td>
                                                    <td style="BORDER-RIGHT: black 1px solid;" align="center" width="40" bgcolor="LightSteelBlue">�м�</td>
                                                    <td align="center" width="40" bgcolor="Plum">����</td>
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
                                                    <td bgcolor="LightGreen">���˵����</td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;&nbsp;(1) ���»��߱�ʾ������Ա������ɾ���߱�ʾʵϰ��</td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;&nbsp;(2) ���ֺ����*�ŵĲ�ռ�Ŷӱ���</td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;&nbsp;(3) ��ռ�Ŷӱ��ƵĹ�����Ա��ɫ��ɫ��ʾ</td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;&nbsp;(4) ����ǰ���@�ŵ����Ŷ�ֱ��</td>
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
                            <input      id="btnPrint"  type="button"  class="button"    value=" ��ӡ�ܹ� " style="HEIGHT: 32px" onclick="btnPrint_onClick();">
                            <asp:Button id="btnTongbu" Runat="server" CssClass="button" Text =" ��Ϣͬ�� " Height="32px"></asp:Button>
                            <span id="spanClose" style="display:">
                            <asp:Button id="btnClose"  Runat="server" CssClass="button" Text =" ��    �� " Height="32px"></asp:Button>
                            </span>
                            <span id="spanCloseWin" style="display:none">
                            <input id="btnCloseWin"    type="button"  class="button"    value=" ��    �� " style="HEIGHT: 32px" onclick="btnCloseWin_onClick()">
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
                                    <TD style="FONT-SIZE: 32pt; COLOR: black; LINE-HEIGHT: 40pt; FONT-FAMILY: ����; LETTER-SPACING: 2pt" align="center"><asp:Label id="lblMessage" Runat="server"></asp:Label><P>&nbsp;&nbsp;</P><P><asp:Button ID="btnGoBack" Runat="server" Font-Size="24pt" Text=" ���� "></asp:Button></P></TD>
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
