<%@ Page Language="vb" AutoEventWireup="false" Codebehind="xtgl_yhgl_js.aspx.vb" Inherits="Josco.JsKernal.web.xtgl_yhgl_js" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Ӧ��ϵͳ�û�����(��ɫ����)</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../stylesw.css" type="text/css" rel="stylesheet">
		<style>
			TD.grdYRLocked { ; LEFT: expression(divYR.scrollLeft); POSITION: relative }
			TH.grdYRLocked { ; LEFT: expression(divYR.scrollLeft); POSITION: relative }
			TH.grdYRLocked { Z-INDEX: 99 }
			TD.grdWRLocked { ; LEFT: expression(divWR.scrollLeft); POSITION: relative }
			TH.grdWRLocked { ; LEFT: expression(divWR.scrollLeft); POSITION: relative }
			TH.grdWRLocked { Z-INDEX: 99 }
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
				var dblDeltaX = 20;
				
				if (document.all("divYR") == null)
					return;
				
				strHeight = divYR.style.height;
				dblWidth  = 570 + dblDeltaX + document.body.clientWidth  - 850; //default state : 570px
				strWidth = parseInt(dblWidth.toString(), 10).toString() + "px";
				divYR.style.width  = strWidth;
				divYR.style.height = strHeight;
				divYR.style.clip = "rect(0px " + strWidth + " " + strHeight + " 0px)";

				strHeight = divWR.style.height;
				dblWidth  = 570 + dblDeltaX + document.body.clientWidth  - 850; //default state : 570px
				strWidth = parseInt(dblWidth.toString(), 10).toString() + "px";
				divWR.style.width  = strWidth;
				divWR.style.height = strHeight;
				divWR.style.clip = "rect(0px " + strWidth + " " + strHeight + " 0px)";
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
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onresize="return window_onresize()" background="../../images/bgmain.gif">
		<form id="frmYHGLJS" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD colSpan="3" height="5"></TD>
					</TR>
					<TR>
						<TD width="5"></TD>
						<TD align="center" style="BORDER-BOTTOM: #99cccc 2px solid">
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR vAlign="middle" align="left" height="24">
									<TD vAlign="middle" align="center" width="100"><asp:linkbutton id="lnkMLRoleGL" runat="server" Font-Name="����" Font-Size="11pt" Enabled="False"><img src="../../images/users.ico" alt="role" border="0" width="16" height="16">��ɫ����</asp:linkbutton></TD>
									<TD vAlign="middle" align="center" width="100"><asp:linkbutton id="lnkMLUserGL" runat="server" Font-Name="����" Font-Size="11pt"><img src="../../images/user.ico" alt="user" border="0" width="16" height="16">�û�����</asp:linkbutton></TD>
									<TD vAlign="middle" align="center" width="100"><asp:linkbutton id="lnkMLAddRole" runat="server" Font-Name="����" Font-Size="11pt"><img src="../../images/new.gif" alt="addnew" border="0" width="16" height="16">�����ɫ</asp:linkbutton></TD>
									<TD vAlign="middle" align="center" width="100"><asp:linkbutton id="lnkMLDeleteRole" runat="server" Font-Name="����" Font-Size="11pt"><img src="../../images/delete.gif" alt="delete" border="0" width="16" height="16">ɾ����ɫ</asp:linkbutton></TD>
									<TD vAlign="middle" align="center" width="100"><asp:linkbutton id="lnkMLMoveIn" runat="server" Font-Name="����" Font-Size="11pt"><img src="../../images/movein.ico" alt="movein" border="0" width="16" height="16">�����û�</asp:linkbutton></TD>
									<TD vAlign="middle" align="center" width="100"><asp:linkbutton id="lnkMLMoveOut" runat="server" Font-Name="����" Font-Size="11pt"><img src="../../images/moveout.ico" alt="moveout" border="0" width="16" height="16">�Ƴ��û�</asp:linkbutton></TD>
									<TD vAlign="middle" align="center" width="100"><asp:linkbutton id="lnkMLClose" runat="server" Font-Size="11pt" Font-Name="����"><img src="../../images/CLOSE.GIF" alt="�����ϼ�" border="0" width="16" height="16">�����ϼ�</asp:linkbutton></TD>
									<TD vAlign="middle" align="center" width="100"></TD>
								</TR>
							</TABLE>
						</TD>
						<TD width="5"></TD>
					</TR>
					<TR>
						<TD width="5"></TD>
						<TD vAlign="top" align="center">
							<TABLE cellSpacing="0" cellPadding="0" border="0">
								<TR>
									<TD class="tips" align="left" colSpan="5" height="30">&nbsp;&nbsp;����������ͷ�ɽ������򣬵���1��Ϊ�������У��ٵ���1��Ϊ�������У��ٵ���1�λָ���ԭʼ����<asp:LinkButton id="lnkBlank" Runat="server" Height="5px" Width="0px"></asp:LinkButton></TD>
								</TR>
								<TR>
									<TD width="5"></TD>
									<TD vAlign="top" align="left" width="220" style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid">
										<TABLE cellSpacing="0" cellPadding="0" border="0">
											<TR>
												<TD><IEWC:TREEVIEW id="tvwServers" runat="server" Font-Name="����" Font-Size="11pt" Height="700px" Width="220px" AutoPostBack="True" CssClass="label"></IEWC:TREEVIEW></TD>
											</TR>
										</TABLE>
									</TD>
									<TD width="5"></TD>
									<TD style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid" vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" border="0">
											<TR align="center">
												<TD class="label" align="left">
													<TABLE cellSpacing="0" cellPadding="0" border="0">
														<TR>
															<TD class="label" vAlign="middle" align="right">��ʶ</TD>
															<TD class="label" align="left"><asp:textbox id="txtYRSearchRYDM" runat="server" Font-Size="11pt" CssClass="textbox" Columns="6" height="22px" Font-Names="����"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right">����</TD>
															<TD class="label" align="left"><asp:textbox id="txtYRSearchRYMC" runat="server" Font-Size="11pt" CssClass="textbox" Columns="6" height="22px" Font-Names="����"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right">��λ</TD>
															<TD class="label" align="left"><asp:textbox id="txtYRSearchZZMC" runat="server" Font-Size="11pt" CssClass="textbox" Columns="6" height="22px" Font-Names="����"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right">ְ��</TD>
															<TD class="label" align="left"><asp:textbox id="txtYRSearchGWLB" runat="server" Font-Size="11pt" CssClass="textbox" Columns="6" height="22px" Font-Names="����"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right">����</TD>
															<TD class="label" align="left"><asp:textbox id="txtYRSearchJBMC" runat="server" Font-Size="11pt" CssClass="textbox" Columns="6" height="22px" Font-Names="����"></asp:textbox></TD>
															<TD class="label"><asp:button id="btnYRSearch" Runat="server" Font-Name="����" Font-Size="11pt" CssClass="button" Text="����"></asp:button></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD>
													<DIV id="divYR" style="TABLE-LAYOUT: fixed; OVERFLOW: auto; WIDTH: 570px; CLIP: rect(0px 570px 300px 0px); HEIGHT: 300px">
														<asp:datagrid id="grdYR" runat="server" Font-Size="11pt" Width="1450px" CssClass="label" Font-Names="����"
															AutoGenerateColumns="False" GridLines="Vertical" BackColor="White" BorderStyle="None" CellPadding="4"
															AllowPaging="True" PageSize="30" BorderColor="#DEDFDE" BorderWidth="0px" AllowSorting="True"
															UseAccessibleHeader="True">
															<SelectedItemStyle Font-Size="11pt" Font-Names="����" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
															<EditItemStyle Font-Size="11pt" Font-Names="����" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
															<AlternatingItemStyle Font-Size="11pt" Font-Names="����" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
															<ItemStyle Font-Size="11pt" Font-Names="����" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
															<HeaderStyle Font-Size="11pt" Font-Names="����" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#87cefa" HorizontalAlign="Left"></HeaderStyle>
															<FooterStyle BackColor="#CCCC99"></FooterStyle>
															<Columns>
																<asp:TemplateColumn HeaderText="ѡ">
																	<HeaderStyle HorizontalAlign="Center" Width="30px"></HeaderStyle>
																	<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																	<ItemTemplate>
																		<asp:CheckBox id="chkYR" runat="server" AutoPostBack="False"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:ButtonColumn DataTextField="��Ա����" SortExpression="��Ա����" HeaderText="��ʶ" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="��Ա����" SortExpression="��Ա����" HeaderText="����" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="��֯����" SortExpression="��֯����" HeaderText="����" CommandName="Select">
																	<HeaderStyle Width="200px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="��Ա���" SortExpression="��Ա���" HeaderText="���" CommandName="Select">
																	<HeaderStyle Width="80px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="��λ�б�" SortExpression="��λ�б�" HeaderText="ְ��" CommandName="Select">
																	<HeaderStyle Width="180px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="��������" SortExpression="��������" HeaderText="����" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="��������" SortExpression="��������" HeaderText="����" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="��ϵ�绰" SortExpression="��ϵ�绰" HeaderText="��ϵ�绰" CommandName="Select">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="�ֻ�����" SortExpression="�ֻ�����" HeaderText="�ƶ��绰" CommandName="Select">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="FTP��ַ" SortExpression="FTP��ַ" HeaderText="�ڲ�����" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="�����ַ" SortExpression="�����ַ" HeaderText="����������" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="�Ƿ�����" SortExpression="�Ƿ�����" HeaderText="����?" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="��֯����" SortExpression="��֯����" HeaderText="��֯����" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="�������" SortExpression="�������" HeaderText="�������" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="��������" SortExpression="��������" HeaderText="��������" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="�������" SortExpression="�������" HeaderText="�������" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="�Զ�ǩ��" SortExpression="�Զ�ǩ��" HeaderText="�Զ�ǩ��" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="������ʾ����" SortExpression="������ʾ����" HeaderText="������ʾ����" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="�ɲ鿴����" SortExpression="�ɲ鿴����" HeaderText="�ɲ鿴����" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="��ֱ����Ա" SortExpression="��ֱ����Ա" HeaderText="��ֱ����Ա" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="������ת��" SortExpression="������ת��" HeaderText="������ת��" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="�Ƿ����" SortExpression="�Ƿ����" HeaderText="�Ƿ����" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
															</Columns>
															<PagerStyle Visible="False" NextPageText="��ҳ" Font-Size="11pt" Font-Names="����" PrevPageText="��ҳ" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
														</asp:datagrid><INPUT id="htxtYRFixed" type="hidden" value="0" runat="server"></DIV>
												</TD>
											</TR>
											<TR align="center">
												<TD class="label">
													<TABLE cellSpacing="0" cellPadding="0" border="0" width="100%">
														<TR>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZYRDeSelectAll" runat="server" Font-Name="����" Font-Size="11pt">��ѡ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZYRSelectAll" runat="server" Font-Name="����" Font-Size="11pt">ȫѡ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZYRMoveFirst" runat="server" Font-Name="����" Font-Size="11pt">��ǰ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZYRMovePrev" runat="server" Font-Name="����" Font-Size="11pt">ǰҳ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZYRMoveNext" runat="server" Font-Name="����" Font-Size="11pt">��ҳ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZYRMoveLast" runat="server" Font-Name="����" Font-Size="11pt">���</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZYRGotoPage" runat="server" Font-Name="����" Font-Size="11pt">ǰ��</asp:linkbutton><asp:textbox id="txtYRPageIndex" runat="server" Font-Name="����" Font-Size="11pt" Width="40px" CssClass="textbox" Columns="2" height="22px">1</asp:textbox>ҳ</TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZYRSetPageSize" runat="server" Font-Name="����" Font-Size="11pt">ÿҳ</asp:linkbutton><asp:textbox id="txtYRPageSize" runat="server" Font-Name="����" Font-Size="11pt" Width="40px" CssClass="textbox" Columns="3" height="22px">30</asp:textbox>��</TD>
															<TD class="label" vAlign="middle" align="right" width="140"><asp:label id="lblYRGridLocInfo" runat="server" Font-Name="����" Font-Size="11pt" CssClass="label">1/10 N/15</asp:label></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR align="center">
												<TD class="label" align="left">
													<TABLE cellSpacing="0" cellPadding="0" border="0">
														<TR>
															<TD class="label" vAlign="middle" align="right">��ʶ</TD>
															<TD class="label" align="left"><asp:textbox id="txtWRSearchRYDM" runat="server" Font-Size="11pt" CssClass="textbox" Columns="6" height="22px" Font-Names="����"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right">����</TD>
															<TD class="label" align="left"><asp:textbox id="txtWRSearchRYMC" runat="server" Font-Size="11pt" CssClass="textbox" Columns="6" height="22px" Font-Names="����"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right">��λ</TD>
															<TD class="label" align="left"><asp:textbox id="txtWRSearchZZMC" runat="server" Font-Size="11pt" CssClass="textbox" Columns="6" height="22px" Font-Names="����"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right">ְ��</TD>
															<TD class="label" align="left"><asp:textbox id="txtWRSearchGWLB" runat="server" Font-Size="11pt" CssClass="textbox" Columns="6" height="22px" Font-Names="����"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right">����</TD>
															<TD class="label" align="left"><asp:textbox id="txtWRSearchJBMC" runat="server" Font-Size="11pt" CssClass="textbox" Columns="6" height="22px" Font-Names="����"></asp:textbox></TD>
															<TD class="label"><asp:button id="btnWRSearch" Runat="server" Font-Name="����" Font-Size="11pt" CssClass="button" Text="����"></asp:button></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD>
													<DIV id="divWR" style="TABLE-LAYOUT: fixed; OVERFLOW: auto; WIDTH: 570px; CLIP: rect(0px 570px 300px 0px); HEIGHT: 300px">
														<asp:datagrid id="grdWR" runat="server" Font-Size="11pt" Width="1450px" CssClass="label" Font-Names="����"
															AutoGenerateColumns="False" GridLines="Vertical" BackColor="White" BorderStyle="None" CellPadding="4"
															AllowPaging="True" PageSize="30" BorderColor="#DEDFDE" BorderWidth="0px" AllowSorting="True"
															UseAccessibleHeader="True">
															<SelectedItemStyle Font-Size="11pt" Font-Names="����" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
															<EditItemStyle Font-Size="11pt" Font-Names="����" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
															<AlternatingItemStyle Font-Size="11pt" Font-Names="����" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
															<ItemStyle Font-Size="11pt" Font-Names="����" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
															<HeaderStyle Font-Size="11pt" Font-Names="����" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#87cefa" HorizontalAlign="Left"></HeaderStyle>
															<FooterStyle BackColor="#CCCC99"></FooterStyle>
															<Columns>
																<asp:TemplateColumn HeaderText="ѡ">
																	<HeaderStyle HorizontalAlign="Center" Width="30px"></HeaderStyle>
																	<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																	<ItemTemplate>
																		<asp:CheckBox id="chkWR" runat="server" AutoPostBack="False"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:ButtonColumn DataTextField="��Ա����" SortExpression="��Ա����" HeaderText="��ʶ" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="��Ա����" SortExpression="��Ա����" HeaderText="����" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="��֯����" SortExpression="��֯����" HeaderText="����" CommandName="Select">
																	<HeaderStyle Width="200px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="��Ա���" SortExpression="��Ա���" HeaderText="���" CommandName="Select">
																	<HeaderStyle Width="80px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="��λ�б�" SortExpression="��λ�б�" HeaderText="ְ��" CommandName="Select">
																	<HeaderStyle Width="180px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="��������" SortExpression="��������" HeaderText="����" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="��������" SortExpression="��������" HeaderText="����" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="��ϵ�绰" SortExpression="��ϵ�绰" HeaderText="��ϵ�绰" CommandName="Select">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="�ֻ�����" SortExpression="�ֻ�����" HeaderText="�ƶ��绰" CommandName="Select">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="FTP��ַ" SortExpression="FTP��ַ" HeaderText="�ڲ�����" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="�����ַ" SortExpression="�����ַ" HeaderText="����������" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="�Ƿ�����" SortExpression="�Ƿ�����" HeaderText="����?" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="��֯����" SortExpression="��֯����" HeaderText="��֯����" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="�������" SortExpression="�������" HeaderText="�������" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="��������" SortExpression="��������" HeaderText="��������" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="�������" SortExpression="�������" HeaderText="�������" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="�Զ�ǩ��" SortExpression="�Զ�ǩ��" HeaderText="�Զ�ǩ��" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="������ʾ����" SortExpression="������ʾ����" HeaderText="������ʾ����" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="�ɲ鿴����" SortExpression="�ɲ鿴����" HeaderText="�ɲ鿴����" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="��ֱ����Ա" SortExpression="��ֱ����Ա" HeaderText="��ֱ����Ա" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="������ת��" SortExpression="������ת��" HeaderText="������ת��" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="�Ƿ����" SortExpression="�Ƿ����" HeaderText="�Ƿ����" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
															</Columns>
															<PagerStyle Visible="False" NextPageText="��ҳ" Font-Size="11pt" Font-Names="����" PrevPageText="��ҳ" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
														</asp:datagrid><INPUT id="htxtWRFixed" type="hidden" value="0" runat="server"></DIV>
												</TD>
											</TR>
											<TR align="center">
												<TD class="label" style="">
													<TABLE cellSpacing="0" cellPadding="0" border="0" width="100%">
														<TR>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZWRDeSelectAll" runat="server" Font-Name="����" Font-Size="11pt">��ѡ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZWRSelectAll" runat="server" Font-Name="����" Font-Size="11pt">ȫѡ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZWRMoveFirst" runat="server" Font-Name="����" Font-Size="11pt">��ǰ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZWRMovePrev" runat="server" Font-Name="����" Font-Size="11pt">ǰҳ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZWRMoveNext" runat="server" Font-Name="����" Font-Size="11pt">��ҳ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZWRMoveLast" runat="server" Font-Name="����" Font-Size="11pt">���</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZWRGotoPage" runat="server" Font-Name="����" Font-Size="11pt">ǰ��</asp:linkbutton><asp:textbox id="txtWRPageIndex" runat="server" Font-Name="����" Font-Size="11pt" Width="40px" CssClass="textbox" Columns="2" height="22px">1</asp:textbox>ҳ</TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZWRSetPageSize" runat="server" Font-Name="����" Font-Size="11pt">ÿҳ</asp:linkbutton><asp:textbox id="txtWRPageSize" runat="server" Font-Name="����" Font-Size="11pt" Width="40px" CssClass="textbox" Columns="3" height="22px">30</asp:textbox>��</TD>
															<TD class="label" vAlign="middle" align="right" width="140"><asp:label id="lblWRGridLocInfo" runat="server" Font-Name="����" Font-Size="11pt" CssClass="label">1/10 N/15</asp:label></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
									</TD>
									<TD width="5"></TD>
								</TR>
								<TR>
									<TD colSpan="5" height="5"></TD>
								</TR>
							</TABLE>
						</TD>
						<TD width="5"></TD>
					</TR>
					<TR>
						<TD width="5"></TD>
						<TD align="center" style="BORDER-TOP: #99cccc 2px solid">
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR vAlign="middle" align="left" height="24">
									<TD vAlign="middle" align="center" width="100"><asp:linkbutton id="lnkMLRoleGLB" runat="server" Font-Name="����" Font-Size="11pt" Enabled="False"><img src="../../images/users.ico" alt="role" border="0" width="16" height="16">��ɫ����</asp:linkbutton></TD>
									<TD vAlign="middle" align="center" width="100"><asp:linkbutton id="lnkMLUserGLB" runat="server" Font-Name="����" Font-Size="11pt"><img src="../../images/user.ico" alt="user" border="0" width="16" height="16">�û�����</asp:linkbutton></TD>
									<TD vAlign="middle" align="center" width="100"><asp:linkbutton id="lnkMLAddRoleB" runat="server" Font-Name="����" Font-Size="11pt"><img src="../../images/new.gif" alt="addnew" border="0" width="16" height="16">�����ɫ</asp:linkbutton></TD>
									<TD vAlign="middle" align="center" width="100"><asp:linkbutton id="lnkMLDeleteRoleB" runat="server" Font-Name="����" Font-Size="11pt"><img src="../../images/delete.gif" alt="delete" border="0" width="16" height="16">ɾ����ɫ</asp:linkbutton></TD>
									<TD vAlign="middle" align="center" width="100"><asp:linkbutton id="lnkMLMoveInB" runat="server" Font-Name="����" Font-Size="11pt"><img src="../../images/movein.ico" alt="movein" border="0" width="16" height="16">�����û�</asp:linkbutton></TD>
									<TD vAlign="middle" align="center" width="100"><asp:linkbutton id="lnkMLMoveOutB" runat="server" Font-Name="����" Font-Size="11pt"><img src="../../images/moveout.ico" alt="moveout" border="0" width="16" height="16">�Ƴ��û�</asp:linkbutton></TD>
									<TD vAlign="middle" align="center" width="100"><asp:linkbutton id="lnkMLCloseB" runat="server" Font-Size="11pt" Font-Name="����"><img src="../../images/CLOSE.GIF" alt="�����ϼ�" border="0" width="16" height="16">�����ϼ�</asp:linkbutton></TD>
									<TD vAlign="middle" align="center" width="100"></TD>
								</TR>
							</TABLE>
						</TD>
						<TD width="5"></TD>
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
						<input id="htxtYRQuery" type="hidden" runat="server">
						<input id="htxtYRRows" type="hidden" runat="server">
						<input id="htxtYRSort" type="hidden" runat="server">
						<input id="htxtYRSortColumnIndex" type="hidden" runat="server">
						<input id="htxtYRSortType" type="hidden" runat="server">
						<input id="htxtWRQuery" type="hidden" runat="server">
						<input id="htxtWRRows" type="hidden" runat="server">
						<input id="htxtWRSort" type="hidden" runat="server">
						<input id="htxtWRSortColumnIndex" type="hidden" runat="server">
						<input id="htxtWRSortType" type="hidden" runat="server">
						<input id="htxtDivLeftYR" type="hidden" runat="server">
						<input id="htxtDivTopYR" type="hidden" runat="server">
						<input id="htxtDivLeftWR" type="hidden" runat="server">
						<input id="htxtDivTopWR" type="hidden" runat="server">
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
							function ScrollProc_DivYRObject() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopYR");
								if (oText != null) oText.value = divYR.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftYR");
								if (oText != null) oText.value = divYR.scrollLeft;
								return;
							}
							function ScrollProc_DivWRObject() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopWR");
								if (oText != null) oText.value = divWR.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftWR");
								if (oText != null) oText.value = divWR.scrollLeft;
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
								oText=document.getElementById("htxtDivTopYR");
								if (oText != null) divYR.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftYR");
								if (oText != null) divYR.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtDivTopWR");
								if (oText != null) divWR.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftWR");
								if (oText != null) divWR.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divYR.onscroll = ScrollProc_DivYRObject;
								divWR.onscroll = ScrollProc_DivWRObject;
							}
							catch (e) {}
						</script>
					</td>
				</tr>
				<tr>
					<td>
						<script language="javascript">window_onresize();</script>
						<uwin:popmessage id="popMessageObject" runat="server" EnableViewState="False" PopupWindowType="Normal" ActionType="OpenWindow" Visible="False" height="48px" width="96px"></uwin:popmessage>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
