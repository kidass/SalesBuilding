<%@ Page Language="vb" AutoEventWireup="false" Codebehind="estate_rs_rskp_ldht.aspx.vb" Inherits="Josco.JSOA.web.estate_rs_rskp_ldht" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>��Ա�Ͷ���ͬǩ������鿴��༭��</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../styles01.css" type="text/css" rel="stylesheet">
		<style>
		    TD.grdRYLISTLocked { ; LEFT: expression(divRYLIST.scrollLeft); POSITION: relative }
		    TH.grdRYLISTLocked { ; LEFT: expression(divRYLIST.scrollLeft); POSITION: relative }
		    TH.grdRYLISTLocked { Z-INDEX: 99 }
		    TH { Z-INDEX: 10; POSITION: relative }
		</style>
		<script src="../../../scripts/transkey.js"></script>
		<script language="javascript">
		<!--
			function window_onresize() 
			{
				var dblHeight = 0;
				var dblWidth  = 0;
				var strHeight = "";
				var strWidth  = "";
				
				if (document.all("divRYLIST") == null)
					return;
				
				intWidth   = document.body.clientWidth;   //�ܿ��
				intWidth  -= 24;                          //������
				intWidth  -= 2 * 4;                       //���ҿհ�
				intWidth  -= 16;                          //������
				strWidth   = intWidth.toString() + "px";
				
				intHeight  = document.body.clientHeight;  //�ܸ߶�
				intHeight -= 24;                          //������
				intHeight -= trRow1.clientHeight;
				intHeight -= trRow2.clientHeight;
				intHeight -= trRow3.clientHeight;
				intHeight -= trRow4.clientHeight;
				intHeight -= trRow5.clientHeight;
				strHeight  = intHeight.toString() + "px";
				//if (document.readyState.toLowerCase() == "complete")
                //    alert(strWidth + " " + strHeight);
                
				divRYLIST.style.width  = strWidth;
				divRYLIST.style.height = strHeight;
				divRYLIST.style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";
			}
			function document_onreadystatechange() 
			{
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
	<body background="../../images/oabk.gif" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onresize="return window_onresize()">
		<form id="frmestate_rs_rskp_ldht" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="5"></TD>
						<TD vAlign="top" align="center">
							<TABLE cellSpacing="0" cellPadding="0" border="0">
								<TR id="trRow1">
									<TD class="title" align="left" colSpan="3" height="30">��ǰλ�ã����¹���&nbsp;&gt;&gt;&gt;&gt;&nbsp;�Ͷ���ͬ����<%=propRYMC%>��<asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton></TD>
								</TR>
								<tr>
								    <td height="4"></td>
								</tr>
								<TR>
									<TD width="5"></TD>
									<TD vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" border="0">
											<TR id="trRow2">
												<TD class="label" align="left" style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid">
													<TABLE cellSpacing="0" cellPadding="0" border="0">
														<TR>
															<TD class="label" vAlign="middle" align="right">��Ա&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtRYLISTSearch_RYDM" runat="server" Font-Size="12px" CssClass="textbox" Font-Names="����" Columns="6"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;ǩ��ʱ��&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtRYLISTSearch_HTSJMin" runat="server" Font-Size="12px" CssClass="textbox" Columns="10" Font-Names="����"></asp:textbox>~<asp:textbox id="txtRYLISTSearch_HTSJMax" runat="server" Font-Size="12px" CssClass="textbox" Columns="10" Font-Names="����"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;��ͬ����&nbsp;</TD>
															<TD class="label" align="left">
																<asp:DropDownList id="ddlRYLISTSearch_HTLX" runat="server" Font-Size="12px" CssClass="textbox" Font-Names="����">
																	<asp:ListItem Value=""></asp:ListItem>
																	<asp:ListItem Value="0">�̶����޺�ͬ</asp:ListItem>
																	<asp:ListItem Value="1">�޹̶��ں�ͬ</asp:ListItem>
																	<asp:ListItem Value="2">��ʱ��ͬ</asp:ListItem>
																</asp:DropDownList>
															</TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;��Լ���&nbsp;</TD>
															<TD class="label" align="left">
																<asp:DropDownList id="ddlRYLISTSearch_SFXY" runat="server" Font-Size="12px" CssClass="textbox" Font-Names="����">
																	<asp:ListItem Value=""></asp:ListItem>
																	<asp:ListItem Value="0">��ǩ��ͬ</asp:ListItem>
																	<asp:ListItem Value="1">��ͬ��Լ</asp:ListItem>
																</asp:DropDownList>
															</TD>
															<TD class="label">&nbsp;&nbsp;<asp:button id="btnRYLISTSearch" Runat="server" Font-Size="12px" Font-Name="����" CssClass="button" Text="����"></asp:button><asp:button id="btnRYLISTSearch_Full" Runat="server" Font-Size="12px" Font-Name="����" CssClass="button" Text="ȫ��"></asp:button></td>
														</Tr>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD>
													<DIV id="divRYLIST" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 964px; CLIP: rect(0px 964px 367px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 367px">
														<asp:datagrid id="grdRYLIST" runat="server" Font-Size="12px" CssClass="label" Font-Names="����"
															CellPadding="4" AllowSorting="True" BorderWidth="0px" BorderColor="#DEDFDE" PageSize="30"
															BorderStyle="None" BackColor="White" GridLines="Vertical" AutoGenerateColumns="False" AllowPaging="True"
															UseAccessibleHeader="True" Width="100%">
															<SelectedItemStyle Font-Size="12px" Font-Names="����" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
															<EditItemStyle Font-Size="12px" Font-Names="����" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
															<AlternatingItemStyle Font-Size="12px" Font-Names="����" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
															<ItemStyle Font-Size="12px" Font-Names="����" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
															<HeaderStyle Font-Size="12px" Font-Names="����" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#6699cc" HorizontalAlign="Left"></HeaderStyle>
															<FooterStyle BackColor="#CCCC99"></FooterStyle>
															
															<Columns>
																<asp:TemplateColumn HeaderText="ѡ" ItemStyle-Width="20px">
																	<HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
																	<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																	<ItemTemplate>
																		<asp:CheckBox id="chkRYLIST" runat="server" AutoPostBack="False"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="Ψһ��ʶ" SortExpression="Ψһ��ʶ" HeaderText="Ψһ��ʶ" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="��Ա����" SortExpression="��Ա����" HeaderText="Ա����" CommandName="Select">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="��Ա����" SortExpression="��Ա����" HeaderText="����" CommandName="Select">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="��ʼʱ��" SortExpression="��ʼʱ��" HeaderText="��ͬ��ʼ" CommandName="Select"  DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="����ʱ��" SortExpression="����ʱ��" HeaderText="��ͬ����" CommandName="Select"  DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="���ÿ�ʼ" SortExpression="���ÿ�ʼ" HeaderText="���ÿ�ʼ" CommandName="Select"  DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="���ý���" SortExpression="���ý���" HeaderText="���ý���" CommandName="Select"  DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="��ͬ����" SortExpression="��ͬ����" HeaderText="��ͬ������" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="��ͬ��������" SortExpression="��ͬ��������" HeaderText="��ͬ����" CommandName="Select">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�Ƿ���Լ" SortExpression="�Ƿ���Լ" HeaderText="�Ƿ���Լ��" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="�Ƿ���Լ����" SortExpression="�Ƿ���Լ����" HeaderText="��Լ���" CommandName="Select">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="��ͬ�ļ�" SortExpression="��ͬ�ļ�" HeaderText="��ͬ�ļ���" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="��ͬ�ļ�����" SortExpression="��ͬ�ļ�����" HeaderText="�е����ļ�" CommandName="Select">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
															</Columns>
															
															<PagerStyle Visible="False" NextPageText="��ҳ" Font-Size="12px" Font-Names="����" PrevPageText="��ҳ" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
														</asp:datagrid><INPUT id="htxtRYLISTFixed" type="hidden" value="0" runat="server">
													</DIV>
												</TD>
											</TR>
											<TR id="trRow3">
												<TD class="label">
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZRYLISTDeSelectAll" runat="server" Font-Size="12px" Font-Name="����">��ѡ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZRYLISTSelectAll" runat="server" Font-Size="12px" Font-Name="����">ȫѡ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZRYLISTMoveFirst" runat="server" Font-Size="12px" Font-Name="����">��ǰ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZRYLISTMovePrev" runat="server" Font-Size="12px" Font-Name="����">ǰҳ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZRYLISTMoveNext" runat="server" Font-Size="12px" Font-Name="����">��ҳ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZRYLISTMoveLast" runat="server" Font-Size="12px" Font-Name="����">���</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZRYLISTGotoPage" runat="server" Font-Size="12px" Font-Name="����">ǰ��</asp:linkbutton><asp:textbox id="txtRYLISTPageIndex" runat="server" Font-Size="12px" Font-Name="����" CssClass="textbox" Columns="3">1</asp:textbox>ҳ</TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZRYLISTSetPageSize" runat="server" Font-Size="12px" Font-Name="����">ÿҳ</asp:linkbutton><asp:textbox id="txtRYLISTPageSize" runat="server" Font-Size="12px" Font-Name="����" CssClass="textbox" Columns="3">30</asp:textbox>��</TD>
															<TD class="label" vAlign="middle" noWrap align="right"><asp:label id="lblRYLISTGridLocInfo" runat="server" Font-Size="12px" Font-Name="����" CssClass="label">1/10 N/15</asp:label></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
					                        <TR id="trRow4">
						                        <TD class="label" align="center" style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid">
							                        <TABLE cellSpacing="0" cellPadding="0" border="0">
								                        <TR>
									                        <TD class="label" align="center">
										                        <TABLE cellSpacing="0" cellPadding="0" border="0">
											                        <TR>
											                            <td class="labelNotNull" align="right" nowrap>&nbsp;&nbsp;&nbsp;&nbsp;Ա������</td>
												                        <TD class="label" align="left"><asp:textbox id="txtRYMC" Runat="server" Font-Size="12px" Font-Name="����" Columns="22" CssClass="textbox"></asp:textbox><asp:Button ID="btnSelect_RYDM" Runat="server" CssClass="button" Text="��"></asp:Button><input type="hidden" id="htxtWYBS" runat="server" size="1"><input type="hidden" id="htxtRYDM" runat="server" size="1"></TD>
											                            <td class="labelNotNull" align="right" nowrap>&nbsp;&nbsp;&nbsp;&nbsp;��ͬ����</td>
												                        <TD class="label" align="left"><asp:textbox id="txtKSSJ" Runat="server" Font-Size="12px" Font-Name="����" Columns="10" CssClass="textbox"></asp:textbox>~<asp:textbox id="txtJSSJ" Runat="server" Font-Size="12px" Font-Name="����" Columns="10" CssClass="textbox"></asp:textbox></td>
											                            <td class="labelNotNull" align="right" nowrap>&nbsp;&nbsp;&nbsp;&nbsp;��ͬ����</td>
												                        <TD class="label" align="left">
																			<asp:RadioButtonList id="rblHTLX" Runat="server" Font-Size="12px" Font-Name="����" CssClass="textbox" RepeatColumns="3" RepeatDirection="Vertical" RepeatLayout="Flow" AutoPostBack="True">
																				<asp:ListItem Value="0">�̶����޺�ͬ</asp:ListItem>
																				<asp:ListItem Value="1">�޹̶��ں�ͬ</asp:ListItem>
																				<asp:ListItem Value="2">��ʱ��ͬ</asp:ListItem>
																			</asp:RadioButtonList>
																		</td>
												                        <td><asp:button id="btnSave" Runat="server" Font-Size="12px" Font-Name="����" Height="24px" Width="96px" CssClass="button" Text="����"></asp:button></td>
											                        </TR>
											                        <tr>
																		<td class="label" align="right" nowrap>&nbsp;&nbsp;&nbsp;&nbsp;��������</td>
																		<td class="label" align="left">
																			<asp:DropDownList ID="ddlSYLX" Runat="server" CssClass="textbox" AutoPostBack="True" Width="100%">
																				<asp:ListItem Value="">��������</asp:ListItem>
																				<asp:ListItem Value="3">������������</asp:ListItem>
																				<asp:ListItem Value="6">������������</asp:ListItem>
																			</asp:DropDownList>
																		</td>
																		<td class="label" align="right">&nbsp;&nbsp;&nbsp;&nbsp;��������</td>
																		<TD class="label" align="left"><asp:textbox id="txtSYKS" Runat="server" Font-Size="12px" Font-Name="����" Columns="10" CssClass="textbox"></asp:textbox>~<asp:textbox id="txtSYJS" Runat="server" Font-Size="12px" Font-Name="����" Columns="10" CssClass="textbox"></asp:textbox></td>
											                            <td class="labelNotNull" align="right" nowrap>&nbsp;&nbsp;&nbsp;&nbsp;�Ƿ���Լ</td>
												                        <TD class="label" align="left">
																			<asp:RadioButtonList id="rblSFXY" Runat="server" Font-Size="12px" Font-Name="����" CssClass="textbox" RepeatColumns="2" RepeatDirection="Vertical" RepeatLayout="Flow">
																				<asp:ListItem Value="0">��ǩ��ͬ&nbsp;&nbsp;&nbsp;&nbsp;</asp:ListItem>
																				<asp:ListItem Value="1">��ͬ��Լ&nbsp;&nbsp;&nbsp;&nbsp;</asp:ListItem>
																			</asp:RadioButtonList>
																		</td>
												                        <td>&nbsp;</td>
											                        </tr>
											                        <TR>
											                            <td class="label" align="right">&nbsp;&nbsp;&nbsp;&nbsp;��ͬ�ļ�</td>
											                            <td class="label" align="left" colspan="3"><input type="file" id="fileUpload" runat="server" style="FONT-SIZE: 12px; WIDTH: 100%"></td>
											                            <td class="label" align="left" colspan="2"><input type="hidden" id="htxtUploadFile" runat="server" size="1" NAME="htxtUploadFile"><input type="hidden" id="htxtHTWJ" runat="server" size="1" NAME="htxtHTWJ"><asp:LinkButton ID="lnkUpload" Runat="server" CssClass="button" Font-Size="12px">�ϴ��ļ�</asp:LinkButton></td>
												                        <TD><asp:button id="btnCancel" Runat="server" Font-Size="12px" Font-Name="����" Height="24px" Width="96px" CssClass="button" Text="ȡ��"></asp:button></TD>
											                        </TR>
										                        </TABLE>
									                        </TD>
								                        </TR>
							                        </TABLE>
						                        </TD>
					                        </TR>
										</TABLE>
									</TD>
									<TD width="5"></TD>
								</TR>
								<TR>
									<TD colSpan="5" height="3"></TD>
								</TR>
							</TABLE>
						</TD>
						<TD width="5"></TD>
					</TR>
					<TR>
						<TD colSpan="3" height="3"></TD>
					</TR>
					<TR id="trRow5">
						<TD align="center" colSpan="3">
						    <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
						        <tr>
						            <td height="3"></td>
						        </tr>
						        <tr>
						            <td align="center">
							            <asp:Button id="btnAddNew" Runat="server" Font-Size="12px" Font-Name="����" CssClass="button" Text=" ��    �� " Height="36px"></asp:Button>&nbsp;&nbsp;
							            <asp:Button id="btnUpdate" Runat="server" Font-Size="12px" Font-Name="����" CssClass="button" Text=" ��    �� " Height="36px"></asp:Button>&nbsp;&nbsp;
							            <asp:Button id="btnDelete" Runat="server" Font-Size="12px" Font-Name="����" CssClass="button" Text=" ɾ    �� " Height="36px"></asp:Button>&nbsp;&nbsp;
							            <asp:Button id="btnPrint" Runat="server" Font-Size="12px" Font-Name="����" CssClass="button" Text=" ��    ӡ " Height="36px"></asp:Button>&nbsp;&nbsp;
							            <asp:Button id="btnHTWJ" Runat="server" Font-Size="12px" Font-Name="����" CssClass="button" Text=" �鿴�ļ� " Height="36px"></asp:Button>&nbsp;&nbsp;
							            <asp:Button id="btnClose" Runat="server" Font-Size="12px" Font-Name="����" CssClass="button" Text=" ��    �� " Height="36px"></asp:Button>
						            </td>
						        </tr>
						    </table>
						</TD>
					</TR>
				</TABLE>
			</asp:panel>
			<asp:Panel id="panelError" Runat="server">
				<TABLE id="tabErrMain" height="98%" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="5%"></TD>
						<TD>
							<TABLE id="tabErrInfo" height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD>&nbsp;&nbsp;&nbsp;&nbsp;</TD>
									<TD id="tdErrInfo" style="FONT-SIZE: 32pt; COLOR: black; LINE-HEIGHT: 40pt; FONT-FAMILY: ����; LETTER-SPACING: 2pt" align="center"><asp:Label id="lblMessage" Runat="server"></asp:Label><p>&nbsp;&nbsp;</p><p><asp:Button ID="btnGoBack" Runat="server" Font-Size="24pt" Text=" ���� "></asp:Button></p></TD>
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
						<input id="htxtCurrentPage" type="hidden" runat="server">
						<input id="htxtCurrentRow" type="hidden" runat="server">
						<input id="htxtEditMode" type="hidden" runat="server">
						<input id="htxtEditType" type="hidden" runat="server">
						<input id="htxtSessionIdQuery" type="hidden" runat="server">
						<input id="htxtRYLISTQuery" type="hidden" runat="server">
						<input id="htxtRYLISTRows" type="hidden" runat="server">
						<input id="htxtRYLISTSort" type="hidden" runat="server">
						<input id="htxtRYLISTSortColumnIndex" type="hidden" runat="server">
						<input id="htxtRYLISTSortType" type="hidden" runat="server">
						<input id="htxtDivLeftRYLIST" type="hidden" runat="server">
						<input id="htxtDivTopRYLIST" type="hidden" runat="server">
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
							function ScrollProc_divRYLIST() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopRYLIST");
								if (oText != null) oText.value = divRYLIST.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftRYLIST");
								if (oText != null) oText.value = divRYLIST.scrollLeft;
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
								oText=document.getElementById("htxtDivTopRYLIST");
								if (oText != null) divRYLIST.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftRYLIST");
								if (oText != null) divRYLIST.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divRYLIST.onscroll = ScrollProc_divRYLIST;
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
