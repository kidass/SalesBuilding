<%@ Page Language="vb" AutoEventWireup="false" Codebehind="dmxz_zzjg.aspx.vb" Inherits="Josco.JsKernal.web.dmxz_zzjg" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>��λѡ��</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../stylesw.css" type="text/css" rel="stylesheet">
		<style>
		    TD.grdFWLISTLocked { ; LEFT: expression(divFWLIST.scrollLeft); POSITION: relative }
		    TH.grdFWLISTLocked { ; LEFT: expression(divFWLIST.scrollLeft); POSITION: relative }
		    TH.grdFWLISTLocked { Z-INDEX: 99 }
		    TD.grdSELBMLocked { ; LEFT: expression(divSELBM.scrollLeft); POSITION: relative }
		    TH.grdSELBMLocked { ; LEFT: expression(divSELBM.scrollLeft); POSITION: relative }
		    TH.grdSELBMLocked { Z-INDEX: 99 }
		    TH { Z-INDEX: 10; POSITION: relative }
		</style>
		<script src="../../scripts/transkey.js"></script>
		<script language="javascript">
			function window_onresize() 
			{
				var dblHeight = 0;
				var dblWidth  = 0;
				var strHeight = "";
				var strWidth  = "";
				var dblDeltaY = 20;
				
				if (document.all("divMAIN") == null)
					return;
				
				dblHeight = 470 + dblDeltaY + document.body.clientHeight - 570; //default state : 470px
				strHeight = parseInt(dblHeight.toString(), 10).toString() + "px";
				strWidth  = "100%";
				divMAIN.style.width  = strWidth;
				divMAIN.style.height = strHeight;
				divMAIN.style.clip = "rect(0px " + strWidth + " " + strHeight + " 0px)";
			}
			function document_onreadystatechange() 
			{
				window_onresize();
			}
		</script>
		<script language="javascript" for="document" event="onreadystatechange">
		<!--
			return document_onreadystatechange()
		//-->
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onresize="return window_onresize()">
		<form id="frmDMXZ_ZZJG" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="3"></TD>
						<TD align="center" style="BORDER-BOTTOM: #99cccc 1px solid">
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR vAlign="middle" align="left">
									<TD class="label" vAlign="middle" align="center" height="24"><B>��λѡ��<asp:Label id="lblTitle" Runat="server" CssClass="label"></asp:Label></B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD width="3"></TD>
					</TR>
					<TR>
						<TD width="3"></TD>
						<TD vAlign="top" align="center">
							<div id="divMAIN" style="OVERFLOW: auto; WIDTH: 820px; CLIP: rect(0px 820px 470px 0px); HEIGHT: 470px">
								<TABLE cellSpacing="0" cellPadding="0" border="0">
									<TR>
										<TD class="tips" align="left" colSpan="5" height="30">&nbsp;&nbsp;����������ͷ�ɽ������򣬵���1��Ϊ�������У��ٵ���1��Ϊ�������У��ٵ���1�λָ���ԭʼ����<asp:LinkButton id="lnkBlank" Runat="server" Width="0px" Height="5px"></asp:LinkButton></TD>
									</TR>
									<TR>
										<TD width="3"></TD>
										<TD vAlign="top" align="left" style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid">
											<iewc:treeview id="tvwBMLIST" runat="server" CssClass="label" Width="240px" Height="516px" Font-Size="11pt" Font-Name="����" AutoPostBack="true"></iewc:treeview></TD>
										<TD width="3"></TD>
										<TD vAlign="top" style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid">
											<TABLE cellSpacing="0" cellPadding="0" border="0">
												<TR>
													<TD class="label" align="left">
														<TABLE cellSpacing="0" cellPadding="0" border="0">
															<TR>
																<TD class="label" vAlign="middle" align="left">����</TD>
																<TD class="label" align="left"><asp:textbox id="txtFWLISTSearch_FWMC" runat="server" CssClass="textbox" Font-Size="11pt" Columns="36" Font-Names="����"></asp:textbox></TD>
																<TD class="label"><asp:button id="btnFWLISTSearch" Runat="server" CssClass="button" Height="22px" Font-Size="11pt" Font-Name="����" Text="����"></asp:button><asp:button id="btnFWLISTAdd" Runat="server" CssClass="button" Height="22px" Font-Size="11pt" Font-Name="����" Text="ѡ������"></asp:button></TD>
															</TR>
														</TABLE>
													</TD>
												</TR>
												<TR>
													<TD>
														<DIV id="divFWLIST" style="TABLE-LAYOUT: fixed; OVERFLOW: auto; WIDTH: 550px; CLIP: rect(0px 550px 200px 0px); HEIGHT: 200px">
															<asp:datagrid id="grdFWLIST" runat="server" CssClass="label" Font-Size="11pt" Font-Names="����"
																UseAccessibleHeader="True" CellPadding="4" AllowSorting="True" BorderWidth="0px" BorderColor="#DEDFDE"
																PageSize="30" BorderStyle="None" BackColor="White" GridLines="Vertical" AutoGenerateColumns="False"
																AllowPaging="True">
																<FooterStyle BackColor="#CCCC99"></FooterStyle>
																<SelectedItemStyle Font-Size="11pt" Font-Names="����" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
																<EditItemStyle Font-Size="11pt" Font-Names="����" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
																<AlternatingItemStyle Font-Size="11pt" Font-Names="����" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
																<ItemStyle Font-Size="11pt" Font-Names="����" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
																<HeaderStyle Font-Size="11pt" Font-Names="����" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#87cefa" HorizontalAlign="Left"></HeaderStyle>
																<Columns>
																	<asp:TemplateColumn HeaderText="��">
																		<HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
																		<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																		<ItemTemplate>
																			<asp:CheckBox id="chkFWLIST" runat="server" AutoPostBack="False"></asp:CheckBox>
																		</ItemTemplate>
																	</asp:TemplateColumn>
																	<asp:ButtonColumn Text="��" ButtonType="PushButton" CommandName="AddOneRow" HeaderText="��"></asp:ButtonColumn>
																	<asp:ButtonColumn DataTextField="��Χ����" SortExpression="��Χ����" HeaderText="��Χ����" CommandName="Select">
																		<HeaderStyle Width="100%"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn Visible="False" DataTextField="��ˮ��" SortExpression="��ˮ��" HeaderText="��ˮ��" CommandName="Select">
																		<HeaderStyle Width="0px"></HeaderStyle>
																		<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn Visible="False" DataTextField="��Χ��־" SortExpression="��Χ��־" HeaderText="��Χ��־" CommandName="Select">
																		<HeaderStyle Width="0px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn Visible="False" DataTextField="��Ա����" SortExpression="��Ա����" HeaderText="��Ա����" CommandName="Select">
																		<HeaderStyle Width="0px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn Visible="False" DataTextField="��Ա����" SortExpression="��Ա����" HeaderText="��Ա����" CommandName="Select">
																		<HeaderStyle Width="0px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn Visible="False" DataTextField="��Աλ��" SortExpression="��Աλ��" HeaderText="���" CommandName="Select">
																		<HeaderStyle Width="0px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn Visible="False" DataTextField="��ϵ�绰" SortExpression="��ϵ�绰" HeaderText="��ϵ�绰" CommandName="Select">
																		<HeaderStyle Width="0px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn Visible="False" DataTextField="�ֻ�����" SortExpression="�ֻ�����" HeaderText="�ƶ��绰" CommandName="Select">
																		<HeaderStyle Width="0px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn Visible="False" DataTextField="FTP��ַ" SortExpression="FTP��ַ" HeaderText="�ڲ�����" CommandName="Select">
																		<HeaderStyle Width="0px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn Visible="False" DataTextField="�����ַ" SortExpression="�����ַ" HeaderText="����������" CommandName="Select">
																		<HeaderStyle Width="0px"></HeaderStyle>
																	</asp:ButtonColumn>
																</Columns>
																<PagerStyle Visible="False" NextPageText="��ҳ" Font-Size="11pt" Font-Names="����" PrevPageText="��ҳ" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
															</asp:datagrid><INPUT id="htxtFWLISTFixed" type="hidden" value="0" runat="server"></DIV>
													</TD>
												</TR>
												<TR>
													<TD>
														<TABLE cellSpacing="0" cellPadding="0" border="0" width="100%">
															<TR align="center">
																<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZFWLISTDeSelectAll" runat="server" Font-Size="11pt" Font-Name="����">��ѡ</asp:linkbutton></TD>
																<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZFWLISTSelectAll" runat="server" Font-Size="11pt" Font-Name="����">ȫѡ</asp:linkbutton></TD>
																<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZFWLISTMoveFirst" runat="server" Font-Size="11pt" Font-Name="����">��ǰ</asp:linkbutton></TD>
																<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZFWLISTMovePrev" runat="server" Font-Size="11pt" Font-Name="����">ǰҳ</asp:linkbutton></TD>
																<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZFWLISTMoveNext" runat="server" Font-Size="11pt" Font-Name="����">��ҳ</asp:linkbutton></TD>
																<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZFWLISTMoveLast" runat="server" Font-Size="11pt" Font-Name="����">���</asp:linkbutton></TD>
																<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZFWLISTGotoPage" runat="server" Font-Size="11pt" Font-Name="����">ǰ��</asp:linkbutton><asp:textbox id="txtFWLISTPageIndex" runat="server" CssClass="textbox" Font-Size="11pt" Font-Name="����" Columns="3">1</asp:textbox>ҳ</TD>
																<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZFWLISTSetPageSize" runat="server" Font-Size="11pt" Font-Name="����">ÿҳ</asp:linkbutton><asp:textbox id="txtFWLISTPageSize" runat="server" CssClass="textbox" Font-Size="11pt" Font-Name="����" Columns="3">30</asp:textbox>��</TD>
																<TD class="label" vAlign="middle" align="right" width="140"><asp:label id="lblFWLISTGridLocInfo" runat="server" CssClass="label" Font-Size="11pt" Font-Name="����">1/10 N/15</asp:label></TD>
															</TR>
														</TABLE>
													</TD>
												</TR>
												<TR align="center">
													<TD class="label" align="left" style="BORDER-TOP: #99cccc 1px solid">
														<TABLE cellSpacing="0" cellPadding="0" border="0">
															<TR>
																<TD class="label" vAlign="middle" align="left">����</TD>
																<TD class="label" align="left"><asp:textbox id="txtSELBMSearch_BMMC" runat="server" CssClass="textbox" Font-Size="11pt" Columns="36" Font-Names="����"></asp:textbox></TD>
																<TD class="label"><asp:button id="btnSELBMSearch" Runat="server" CssClass="button" Height="22px" Font-Size="11pt" Font-Name="����" Text="����"></asp:button><asp:button id="btnSELBMDelete" Runat="server" CssClass="button" Height="22px" Font-Size="11pt" Font-Name="����" Text="ѡ���Ƴ�"></asp:button></TD>
															</TR>
														</TABLE>
													</TD>
												</TR>
												<TR>
													<TD>
														<DIV id="divSELBM" style="TABLE-LAYOUT: fixed; OVERFLOW: auto; WIDTH: 550px; CLIP: rect(0px 550px 200px 0px); HEIGHT: 200px">
															<asp:datagrid id="grdSELBM" runat="server" CssClass="label" Width="1440px" Font-Size="11pt" Font-Names="����"
																UseAccessibleHeader="True" CellPadding="4" AllowSorting="True" BorderWidth="0px" BorderColor="#DEDFDE"
																PageSize="30" BorderStyle="None" BackColor="White" GridLines="Vertical" AutoGenerateColumns="False"
																AllowPaging="True">
																<FooterStyle BackColor="#CCCC99"></FooterStyle>
																<SelectedItemStyle Font-Size="11pt" Font-Names="����" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
																<EditItemStyle Font-Size="11pt" Font-Names="����" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
																<AlternatingItemStyle Font-Size="11pt" Font-Names="����" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
																<ItemStyle Font-Size="11pt" Font-Names="����" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
																<HeaderStyle Font-Size="11pt" Font-Names="����" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#87cefa" HorizontalAlign="Left"></HeaderStyle>
																<Columns>
																	<asp:TemplateColumn HeaderText="��">
																		<HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
																		<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																		<ItemTemplate>
																			<asp:CheckBox id="chkSELBM" runat="server" AutoPostBack="False"></asp:CheckBox>
																		</ItemTemplate>
																	</asp:TemplateColumn>
																	<asp:ButtonColumn Text="��" ButtonType="PushButton" CommandName="DeleteOneRow" HeaderText="��"></asp:ButtonColumn>
																	<asp:ButtonColumn DataTextField="��λ����" SortExpression="��λ����" HeaderText="��λ��Χ����" CommandName="Select">
																		<HeaderStyle Width="240px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn DataTextField="ѡ������" SortExpression="ѡ������" HeaderText="����" CommandName="Select">
																		<HeaderStyle Width="40px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn DataTextField="��λȫ��" SortExpression="��λȫ��" HeaderText="��λ��Χȫ��" CommandName="Select">
																		<HeaderStyle Width="300px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn DataTextField="��ϵ�绰" SortExpression="��ϵ�绰" HeaderText="��ϵ�绰" CommandName="Select">
																		<HeaderStyle Width="200px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn DataTextField="�ֻ�����" SortExpression="�ֻ�����" HeaderText="�ƶ��绰" CommandName="Select">
																		<HeaderStyle Width="200px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn DataTextField="FTP��ַ" SortExpression="FTP��ַ" HeaderText="�ڲ�����" CommandName="Select">
																		<HeaderStyle Width="200px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn DataTextField="�����ַ" SortExpression="�����ַ" HeaderText="����������" CommandName="Select">
																		<HeaderStyle Width="200px"></HeaderStyle>
																	</asp:ButtonColumn>
																</Columns>
																<PagerStyle Visible="False" NextPageText="��ҳ" Font-Size="11pt" Font-Names="����" PrevPageText="��ҳ"
																	HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
															</asp:datagrid><INPUT id="htxtSELBMFixed" type="hidden" value="0" runat="server"></DIV>
													</TD>
												</TR>
												<TR>
													<TD class="label">
														<TABLE cellSpacing="0" cellPadding="0" border="0" width="100%">
															<TR>
																<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZSELBMDeSelectAll" runat="server" Font-Size="11pt" Font-Name="����">��ѡ</asp:linkbutton></TD>
																<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZSELBMSelectAll" runat="server" Font-Size="11pt" Font-Name="����">ȫѡ</asp:linkbutton></TD>
																<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZSELBMMoveFirst" runat="server" Font-Size="11pt" Font-Name="����">��ǰ</asp:linkbutton></TD>
																<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZSELBMMovePrev" runat="server" Font-Size="11pt" Font-Name="����">ǰҳ</asp:linkbutton></TD>
																<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZSELBMMoveNext" runat="server" Font-Size="11pt" Font-Name="����">��ҳ</asp:linkbutton></TD>
																<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZSELBMMoveLast" runat="server" Font-Size="11pt" Font-Name="����">���</asp:linkbutton></TD>
																<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZSELBMGotoPage" runat="server" Font-Size="11pt" Font-Name="����">ǰ��</asp:linkbutton><asp:textbox id="txtSELBMPageIndex" runat="server" CssClass="textbox" Font-Size="11pt" Font-Name="����" Columns="3">1</asp:textbox>ҳ</TD>
																<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZSELBMSetPageSize" runat="server" Font-Size="11pt" Font-Name="����">ÿҳ</asp:linkbutton><asp:textbox id="txtSELBMPageSize" runat="server" CssClass="textbox" Font-Size="11pt" Font-Name="����" Columns="3">30</asp:textbox>��</TD>
																<TD class="label" vAlign="middle" align="right" width="140"><asp:label id="lblSELBMGridLocInfo" runat="server" CssClass="label" Font-Size="11pt" Font-Name="����">1/10 N/15</asp:label></TD>
															</TR>
														</TABLE>
													</TD>
												</TR>
												<TR>
													<TD class="label" style="BORDER-TOP: #99cccc 1px solid">&nbsp;�����µ�
														<asp:RadioButtonList id="rblXZLX" Runat="server" Font-Size="11pt" Font-Name="����" RepeatColumns="3" RepeatDirection="Horizontal" RepeatLayout="Flow">
															<asp:ListItem>��Χ</asp:ListItem>
															<asp:ListItem Selected="True">��λ</asp:ListItem>
														</asp:RadioButtonList>
														<asp:TextBox id="txtNewDWMC" Runat="server" Height="22px" Font-Size="11pt" Font-Name="����" Columns="36"></asp:TextBox>
														<asp:Button id="btnAddNew" Runat="server" Width="60px" Height="22px" Font-Size="11pt" Font-Name="����" Text="����"></asp:Button>
													</TD>
												</TR>
											</TABLE>
										</TD>
										<TD width="3"></TD>
									</TR>
									<TR>
										<TD colSpan="5" height="3"></TD>
									</TR>
								</TABLE>
							</div>
						</TD>
						<TD width="3"></TD>
					</TR>
					<TR>
						<TD colSpan="3" height="3"></TD>
					</TR>
					<TR>
						<TD align="center" colspan="3" style="BORDER-TOP: #99cccc 1px solid">
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							    <tr>
							        <td height="3"></td>
							    </tr>
								<TR vAlign="middle" align="left">
									<TD class="label" vAlign="middle" align="center" height="30">
										<asp:Button id="btnOK" Runat="server" Height="30px" Font-Size="11pt" Font-Name="����" Text=" ȷ  �� "></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:Button id="btnCancel" Runat="server" Height="30px" Font-Size="11pt" Font-Name="����" Text=" ȡ  �� "></asp:Button>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE>
			</asp:panel>
			<asp:Panel id="panelError" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0" height="98%">
					<TR>
						<TD width="5%"></TD>
						<TD>
							<TABLE height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD>&nbsp;&nbsp;&nbsp;&nbsp;</TD>
									<TD style="FONT-SIZE: 32pt; COLOR: black; LINE-HEIGHT: 40pt; FONT-FAMILY: ����; LETTER-SPACING: 2pt" align="center"><asp:Label id="lblMessage" Runat="server"></asp:Label><p>&nbsp;&nbsp;</p><p><input type="button" id="btnGoBack" value=" ���� " style="FONT-SIZE: 24pt; FONT-FAMILY: ����" onclick="javascript:history.back();"></p></TD>
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
						<input id="htxtSessionIdSELBM" type="hidden" runat="server">
						<input id="htxtSELBMSort" type="hidden" runat="server">
						<input id="htxtSELBMSortColumnIndex" type="hidden" runat="server">
						<input id="htxtSELBMSortType" type="hidden" runat="server">
						<input id="htxtFWLISTQuery" type="hidden" runat="server">
						<input id="htxtFWLISTRows" type="hidden" runat="server">
						<input id="htxtFWLISTSort" type="hidden" runat="server">
						<input id="htxtFWLISTSortColumnIndex" type="hidden" runat="server">
						<input id="htxtFWLISTSortType" type="hidden" runat="server">
						<input id="htxtDivLeftSELBM" type="hidden" runat="server">
						<input id="htxtDivTopSELBM" type="hidden" runat="server">
						<input id="htxtDivLeftFWLIST" type="hidden" runat="server">
						<input id="htxtDivTopFWLIST" type="hidden" runat="server">
						<input id="htxtDivLeftMAIN" type="hidden" runat="server">
						<input id="htxtDivTopMAIN" type="hidden" runat="server">
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
							function ScrollProc_divMAIN() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopMAIN");
								if (oText != null) oText.value = divMAIN.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftMAIN");
								if (oText != null) oText.value = divMAIN.scrollLeft;
								return;
							}
							function ScrollProc_divFWLIST() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopFWLIST");
								if (oText != null) oText.value = divFWLIST.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftFWLIST");
								if (oText != null) oText.value = divFWLIST.scrollLeft;
								return;
							}
							function ScrollProc_divSELBM() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopSELBM");
								if (oText != null) oText.value = divSELBM.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftSELBM");
								if (oText != null) oText.value = divSELBM.scrollLeft;
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
								oText=document.getElementById("htxtDivTopMAIN");
								if (oText != null) divMAIN.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftMAIN");
								if (oText != null) divMAIN.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtDivTopFWLIST");
								if (oText != null) divFWLIST.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftFWLIST");
								if (oText != null) divFWLIST.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtDivTopSELBM");
								if (oText != null) divSELBM.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftSELBM");
								if (oText != null) divSELBM.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divMAIN.onscroll = ScrollProc_divMAIN;
								divFWLIST.onscroll = ScrollProc_divFWLIST;
								divSELBM.onscroll = ScrollProc_divSELBM;
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
