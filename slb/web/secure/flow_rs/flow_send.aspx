<%@ Page Language="vb" AutoEventWireup="false" Codebehind="flow_send.aspx.vb" Inherits="Josco.JSOA.web.flow_send"%>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>�ļ����ʹ�����</title>    
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../stylesGrsw.css" type="text/css" rel="stylesheet">
		<style>
			TD.grdJSRXXLocked { ; LEFT: expression(divJSRXX.scrollLeft); POSITION: relative }
			TH.grdJSRXXLocked { ; LEFT: expression(divJSRXX.scrollLeft); POSITION: relative }
			TH.grdJSRXXLocked { Z-INDEX: 99 }
			TD.grdWTXXLocked { ; LEFT: expression(divWTXX.scrollLeft); POSITION: relative }
			TH.grdWTXXLocked { ; LEFT: expression(divWTXX.scrollLeft); POSITION: relative }
			TH.grdWTXXLocked { Z-INDEX: 99 }
			TH { Z-INDEX: 10; POSITION: relative }
		</style>
		<script src="../../scripts/transkey.js"></script>
		<script language="javascript">
		<!--
			function window_onresize() 
			{
				var dblHeight = 0;
				var dblWidth  = 0;
				var strHeight = "";
				var strWidth  = "";
				var dblDeltaY = 20;
				var dblDeltaX = 0;
				
				if (document.all("divJSRXX") == null)
					return;
				
				dblHeight = 280 + (dblDeltaY + document.body.clientHeight - 590) / 2; //default state : 280px
				strHeight = parseInt(dblHeight.toString(), 10).toString() + "px";
				dblWidth  = 800 + (dblDeltaX + document.body.clientWidth  - 850);     //default state : 800px
				strWidth = parseInt(dblWidth.toString(), 10).toString() + "px";
				divJSRXX.style.width  = strWidth;
				divJSRXX.style.height = strHeight;
				divJSRXX.style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";

				dblHeight = 120 + (dblDeltaY + document.body.clientHeight - 570) / 2; //default state : 120px
				strHeight = parseInt(dblHeight.toString(), 10).toString() + "px";
				dblWidth  = 800 + (dblDeltaX + document.body.clientWidth  - 850);     //default state : 800px
				strWidth = parseInt(dblWidth.toString(), 10).toString() + "px";
				divWTXX.style.width  = strWidth;
				divWTXX.style.height = strHeight;
				divWTXX.style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";
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
		<form id="frmFLOW_SEND" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="5"></TD>
						<TD vAlign="top" align="center">
							<TABLE cellSpacing="0" cellPadding="0" border="0">
								<tr>
									<TD height="3"></TD>
								</tr>
								<TR>
									<TD class="tips" align="left" colSpan="3" height="26"><B>&nbsp;&nbsp;�ļ�׼�����͸�������Ա����</B><asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton><asp:Label ID="lblJSRXXGridLocInfo" Runat="server" CssClass="label-text"></asp:Label></TD>
								</TR>
								<TR>
									<TD width="5"></TD>
									<TD vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" border="0">
											<TR>
												<TD>
													<DIV id="divJSRXX" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 800px; CLIP: rect(0px 800px 280px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 280px">
														<asp:datagrid id="grdJSRXX" runat="server"  CssClass="labelGrid" 
                                                            AllowPaging="True" AutoGenerateColumns="False" GridLines="Vertical" BackColor="White"
                                                            PageSize="250" BorderColor="#dfdfdf" BorderWidth="0px" AllowSorting="True" CellPadding="4"  UseAccessibleHeader="True" BorderStyle="Solid">
															 <SelectedItemStyle  Font-Bold="False" VerticalAlign="top" ForeColor="blue" ></SelectedItemStyle>
                                                            <EditItemStyle   BackColor="#FFCC00" VerticalAlign="top"></EditItemStyle>
                                                            <AlternatingItemStyle  BorderWidth="1px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="top" BackColor="White"></AlternatingItemStyle>
                                                            <ItemStyle  BorderWidth="1px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="top" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
                                                            <HeaderStyle   Font-Bold="True" ForeColor="White" VerticalAlign="top" BackColor="#6699cc" HorizontalAlign="Left"></HeaderStyle>
                                                            <FooterStyle BackColor="#CCCC99"></FooterStyle>
															<Columns>
																<asp:TemplateColumn HeaderText="ѡ" >
																	<HeaderStyle HorizontalAlign="Center" Width="20px" ForeColor="White" Font-Size="14px"></HeaderStyle>
																	<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Bottom"></ItemStyle>
																	<ItemTemplate>
																		<asp:CheckBox id="chkJSRXX" runat="server" AutoPostBack="False"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:ButtonColumn DataTextField="������" SortExpression="������" HeaderText="������" CommandName="Select" ItemStyle-VerticalAlign="Bottom">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:TemplateColumn HeaderText="��������" >
																	<HeaderStyle HorizontalAlign="left" Width="240px" ForeColor="White" Font-Size="14px"></HeaderStyle>
																	<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																	<ItemTemplate>
																		<asp:DropDownList ID="ddlBLSY" Runat="server" CssClass="textbox-text" Width="100%"></asp:DropDownList>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:TemplateColumn HeaderText="��������" HeaderStyle-ForeColor="White">
																	<HeaderStyle HorizontalAlign="left" Width="200px" ForeColor="White" Font-Size="14px"></HeaderStyle>
																	<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																	<ItemTemplate>
																		<asp:TextBox ID="txtBLQX" Runat="server" CssClass="textbox-text" Width="100%"></asp:TextBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:ButtonColumn Visible="False" DataTextField="������" SortExpression="������" HeaderText="������" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="��������" SortExpression="��������" HeaderText="��������" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:TemplateColumn HeaderText="�ļ�����" Visible="False">
																	<HeaderStyle HorizontalAlign="Center" Width="0px" ForeColor="White" Font-Size="14px"></HeaderStyle>
																	<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																	<ItemTemplate>
																		<asp:DropDownList ID="ddlWJZT" Runat="server" CssClass="textbox-text">
																			<asp:ListItem Value="01">ֽ</asp:ListItem>
																			<asp:ListItem Value="10">����</asp:ListItem>
																			<asp:ListItem Value="11">ֽ+����</asp:ListItem>
																		</asp:DropDownList>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:TemplateColumn HeaderText="ֽ���ļ�����">
																	<HeaderStyle HorizontalAlign="Center" Width="60px" ForeColor="White" Font-Size="14px"></HeaderStyle>
																	<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																	<ItemTemplate>
																		<asp:TextBox ID="txtWJZZFS" Runat="server" CssClass="textbox-text" Width="100%"></asp:TextBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:TemplateColumn HeaderText="�����ļ�����">
																	<HeaderStyle HorizontalAlign="Center" Width="60px" ForeColor="White" Font-Size="14px"></HeaderStyle>
																	<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																	<ItemTemplate>
																		<asp:TextBox ID="txtWJDZFS" Runat="server" CssClass="textbox-text" Width="100%"></asp:TextBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:TemplateColumn HeaderText="��������" Visible="False">
																	<HeaderStyle HorizontalAlign="Center" Width="0px" ForeColor="White" Font-Size="14px"></HeaderStyle>
																	<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																	<ItemTemplate>
																		<asp:DropDownList ID="ddlFJZT" Runat="server" CssClass="textbox-text">
																			<asp:ListItem Value="01">ֽ</asp:ListItem>
																			<asp:ListItem Value="10">����</asp:ListItem>
																			<asp:ListItem Value="11">ֽ+����</asp:ListItem>
																		</asp:DropDownList>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:TemplateColumn HeaderText="ֽ�ʸ�������">
																	<HeaderStyle HorizontalAlign="Center" Width="60px" ForeColor="White" Font-Size="14px"></HeaderStyle>
																	<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																	<ItemTemplate>
																		<asp:TextBox ID="txtFJZZFS" Runat="server" CssClass="textbox-text" Width="100%"></asp:TextBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:TemplateColumn HeaderText="���Ӹ�������">
																	<HeaderStyle HorizontalAlign="Center" Width="60px" ForeColor="White" Font-Size="14px"></HeaderStyle>
																	<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																	<ItemTemplate>
																		<asp:TextBox ID="txtFJDZFS" Runat="server" CssClass="textbox-text" Width="100%"></asp:TextBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:ButtonColumn Visible="False" DataTextField="���˼���" SortExpression="���˼���" HeaderText="���˼���" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="ί����" SortExpression="ί����" HeaderText="ί����" CommandName="Select">
																	<HeaderStyle Width="90px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:TemplateColumn HeaderText="Э��">
																	<HeaderStyle HorizontalAlign="Center" Width="50px" ForeColor="White" Font-Size="14px"></HeaderStyle>
																	<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																	<ItemTemplate>
																		<asp:DropDownList ID="ddlXBBZ" Runat="server" CssClass="textbox-text" Width="100%">
																			<asp:ListItem Value="��">��</asp:ListItem>
																			<asp:ListItem Value="��">��</asp:ListItem>
																		</asp:DropDownList>
																	</ItemTemplate>
																</asp:TemplateColumn>
															</Columns>
															<PagerStyle Visible="False" NextPageText="��ҳ" Font-Size="12px" Font-Names="����" PrevPageText="��ҳ" HorizontalAlign="Right" ForeColor="Black" Position="Bottom" BackColor="SkyBlue"></PagerStyle>
														</asp:datagrid><INPUT id="htxtJSRXXFixed" type="hidden" value="0" runat="server">
													</DIV>
												</TD>
											</TR>
											<TR align="left">
												<TD class="label">
													<TABLE cellSpacing="0" cellPadding="0" border="0">
														<TR align="center">
															<TD class="label" vAlign="bottom"><asp:linkbutton id="lnkSelectAll" runat="server" CssClass="labelBlack">ȫѡ</asp:linkbutton>&nbsp;&nbsp;&nbsp;&nbsp;</TD>
															<TD class="label" vAlign="bottom"><asp:linkbutton id="lnkDeSelectAll" runat="server" CssClass="labelBlack">��ѡ</asp:linkbutton>&nbsp;&nbsp;&nbsp;&nbsp;</TD>
															<TD class="labelBlack" vAlign="bottom"><asp:linkbutton id="lnkMovePrev" runat="server" CssClass="labelBlack">ǰҳ</asp:linkbutton>&nbsp;&nbsp;&nbsp;&nbsp;</TD>
															<TD class="labelBlack" vAlign="bottom" ><asp:linkbutton id="lnkMoveNext" runat="server" CssClass="labelBlack">��ҳ</asp:linkbutton></TD>															
														</TR>
													</TABLE>
												</TD>
											</TR>		
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD class="tips" align="left" colSpan="3" height="26"><B>&nbsp;&nbsp;ί����Ϣһ����</B><asp:Label ID="lblWTXXGridLocInfo" Runat="server" CssClass="label-text"></asp:Label></TD>
								</TR>
								<TR>
									<TD width="5"></TD>
									<TD vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" border="0">
											<TR>
												<TD>
													<DIV id="divWTXX" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 800px; CLIP: rect(0px 800px 120px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 120px">
														<asp:datagrid id="grdWTXX" runat="server"  Font-Size="12px" Font-Names="����" AllowPaging="False"
                                                            AutoGenerateColumns="False" GridLines="Vertical" BackColor="White" BorderStyle="None" PageSize="30"
                                                            BorderColor="#DEDFDE" BorderWidth="0px" AllowSorting="True" CellPadding="4" UseAccessibleHeader="True">
                                                           <SelectedItemStyle Font-Size="12px" Font-Names="����" Font-Bold="False" VerticalAlign="top" ForeColor="RED" ></SelectedItemStyle>
                                                            <EditItemStyle Font-Size="12px" Font-Names="����"  BackColor="#FFCC00" VerticalAlign="top"></EditItemStyle>
                                                            <AlternatingItemStyle Font-Size="12px" Font-Names="����" BorderWidth="1px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="top" BackColor="White"></AlternatingItemStyle>
                                                            <ItemStyle Font-Size="12px" Font-Names="����" BorderWidth="1px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="top" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
                                                            <HeaderStyle Font-Size="12px" Font-Names="����" Font-Bold="True" ForeColor="White" VerticalAlign="top" BackColor="#6699cc" HorizontalAlign="Left"></HeaderStyle>
                                                            <FooterStyle BackColor="#CCCC99"></FooterStyle>
															<Columns>
																<asp:TemplateColumn HeaderText="ѡ">
																	<HeaderStyle HorizontalAlign="Center" Width="30px" ForeColor="White" Font-Size="14px"></HeaderStyle>
																	<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																	<ItemTemplate>
																		<asp:CheckBox id="chkWTXX" runat="server" AutoPostBack="False"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:ButtonColumn Visible="False" DataTextField="��ʶ" SortExpression="��ʶ" HeaderText="��ʶ" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="������" SortExpression="������" HeaderText="ί����" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="��������" SortExpression="��������" HeaderText="��������" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd HH:mm:ss}">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="��Ч����" SortExpression="��Ч����" HeaderText="��Ч����" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd HH:mm:ss}">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="ʧЧ����" SortExpression="ʧЧ����" HeaderText="ʧЧ����" CommandName="Select"
																	DataTextFormatString="{0:yyyy-MM-dd HH:mm:ss}">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="ί�д�����" SortExpression="ί�д�����" HeaderText="������" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="��������" SortExpression="��������" HeaderText="��������" CommandName="Select">
																	<HeaderStyle Width="500px"></HeaderStyle>
																</asp:ButtonColumn>
															</Columns>
															<PagerStyle Visible="False" NextPageText="��ҳ" Font-Size="12px" Font-Names="����" PrevPageText="��ҳ" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
														</asp:datagrid><INPUT id="htxtWTXXFixed" type="hidden" value="0" runat="server">
													</DIV>
												</TD>
											</TR>
											<TR>
												<TD align="left">
													<asp:RadioButtonList id="rblWTXX" Runat="server" CssClass="textbox-text"  RepeatLayout="Flow"
														RepeatDirection="Horizontal" RepeatColumns="3"  CellSpacing="6" AutoPostBack="True">
														<asp:ListItem Value="0">������ί����&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:ListItem>
														<asp:ListItem Value="1">����������ͬʱ����ί����&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:ListItem>
														<asp:ListItem Value="2">���������˵�������ί����</asp:ListItem>
													</asp:RadioButtonList>
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
						<TD align="left" colSpan="3">&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:CheckBoxList id="cblFSXX" Runat="server" CssClass="textbox-text"  RepeatLayout="Flow"
								RepeatDirection="Horizontal" RepeatColumns="3"  CellSpacing="6">
								<asp:ListItem Value="0">����֪ͨ��ԭ������&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:ListItem>
								<asp:ListItem Value="1">���ߺ���Ҫ��������</asp:ListItem>
							</asp:CheckBoxList>
							&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:DropDownList id="ddlPLBLSY" Runat="server" Width="160px" CssClass="textbox-text">
								<asp:ListItem></asp:ListItem>																	
							</asp:DropDownList><asp:button id="btnPLTJSY" Runat="server" CssClass="button" Text="�������"></asp:button>
						</td>
					</TR>
					<TR>
						<TD colSpan="3" height="5"></TD>
					</TR>
					<TR>
						<TD align="center" colSpan="3">
							<asp:Button id="btnSend" Runat="server" CssClass="button"  Height="30px" Text=" ��  �� "></asp:Button>
							<asp:Button id="btnSelectRY" Runat="server" CssClass="button"  Height="30px" Text=" ѡ  �� "></asp:Button>
							<asp:Button id="btnAddFSR" Runat="server" CssClass="button"  Height="30px" Text=" ��  �� "></asp:Button>							
							<asp:Button id="btnDeleteRY" Runat="server" CssClass="button"  Height="30px" Text=" ɾ  �� "></asp:Button>
							<asp:Button id="btnCancel" Runat="server" CssClass="button"  Height="30px" Text=" ȡ  �� "></asp:Button>
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
									<TD id="tdErrInfo" style="FONT-SIZE: 32pt; COLOR: black; LINE-HEIGHT: 40pt; FONT-FAMILY: ����; LETTER-SPACING: 2pt" align="center"><asp:Label id="lblMessage" Runat="server"></asp:Label><p>&nbsp;&nbsp;</p><p><input type="button" id="btnGoBack" value=" ���� " style="FONT-SIZE: 24pt; FONT-FAMILY: ����" onclick="javascript:history.back();"></p></TD>
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
						<input id="htxtSessionIdJSRXX" type="hidden" runat="server">
						<input id="htxtXRMode" type="hidden" runat="server">
						<input id="htxtEditMode" type="hidden" runat="server">
						<input id="htxtJSRXXQuery" type="hidden" runat="server">
						<input id="htxtJSRXXRows" type="hidden" runat="server">
						<input id="htxtJSRXXSort" type="hidden" runat="server">
						<input id="htxtJSRXXSortColumnIndex" type="hidden" runat="server">
						<input id="htxtJSRXXSortType" type="hidden" runat="server">
						<input id="htxtWTXXQuery" type="hidden" runat="server">
						<input id="htxtWTXXRows" type="hidden" runat="server">
						<input id="htxtWTXXSort" type="hidden" runat="server">
						<input id="htxtWTXXSortColumnIndex" type="hidden" runat="server">
						<input id="htxtWTXXSortType" type="hidden" runat="server">
						<input id="htxtDivLeftJSRXX" type="hidden" runat="server">
						<input id="htxtDivTopJSRXX" type="hidden" runat="server">
						<input id="htxtDivLeftWTXX" type="hidden" runat="server">
						<input id="htxtDivTopWTXX" type="hidden" runat="server">
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
							function ScrollProc_divJSRXX() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopJSRXX");
								if (oText != null) oText.value = divJSRXX.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftJSRXX");
								if (oText != null) oText.value = divJSRXX.scrollLeft;
								return;
							}
							function ScrollProc_divWTXX() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopWTXX");
								if (oText != null) oText.value = divWTXX.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftWTXX");
								if (oText != null) oText.value = divWTXX.scrollLeft;
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
								oText=document.getElementById("htxtDivTopJSRXX");
								if (oText != null) divJSRXX.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftJSRXX");
								if (oText != null) divJSRXX.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtDivTopWTXX");
								if (oText != null) divWTXX.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftWTXX");
								if (oText != null) divWTXX.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divJSRXX.onscroll = ScrollProc_divJSRXX;
								divWTXX.onscroll = ScrollProc_divWTXX;
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
