<%@ Page Language="vb" AutoEventWireup="false" Codebehind="estate_rs_luyong_main.aspx.vb" Inherits="Josco.JSOA.web.estate_rs_luyong_main" %>
<%@ Register TagPrefix="ComponentArt" Namespace="ComponentArt.Web.UI" Assembly="ComponentArt.Web.UI" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>����¼����������</title>            
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../styles01.css" type="text/css" rel="stylesheet">
		<link href="../../../mnuStyle01.css" type="text/css" rel="stylesheet">
		<style>
			TD.grdRSLYGLLocked { ; LEFT: expression(divRSLYGL.scrollLeft); POSITION: relative }
			TH.grdRSLYGLLocked { ; LEFT: expression(divRSLYGL.scrollLeft); POSITION: relative }
			TH.grdRSLYGLLocked { Z-INDEX: 99 }
			TH { Z-INDEX: 10; POSITION: relative }
		</style>
		<script src="../../../scripts/transkey.js"></script>
		<script language="javascript">  
		<!--
			function doMenuItemClick(menuItemId, param00) 
			{
				try {
					document.all("htxtSelectMenuID").value = menuItemId;
					document.all("htxtMenuParam00").value = param00;
					window.setTimeout("__doPostBack('lnkMenu', '');", 500);
				} catch (e) {}
			}
			function window_onresize() 
			{
				var dblHeight = 0;
				var dblWidth  = 0;
				var strHeight = "";
				var strWidth  = "";
				
				if (document.all("divRSLYGL") == null)
					return;

				intWidth   = document.body.clientWidth;   //�ܿ��
				intWidth  -= 24;                          //������
				intWidth  -= 2 * 4;                       //���ҿհ�
				intWidth  -= 16;                          //������
				strWidth   = intWidth.toString() + "px";
				
				intHeight  = document.body.clientHeight;  //�ܸ߶�
				intHeight -= 24;                          //������
				intHeight -= trRow0.clientHeight;
				intHeight -= trRow1.clientHeight;
				intHeight -= trRow2.clientHeight;
				intHeight -= trRow3.clientHeight;
				strHeight  = intHeight.toString() + "px";

				document.all("divRSLYGL").style.width  = strWidth;
				document.all("divRSLYGL").style.height = strHeight;
				document.all("divRSLYGL").style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";
			}
			function document_onreadystatechange() 
			{
				return window_onresize();
			}
		//-->
		</script>
		<script language="javascript" event="onreadystatechange" for="document">
		<!--
			return document_onreadystatechange()
		//-->
		</script>
	</HEAD>
	<body onresize="return window_onresize()" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" background="../../images/oabk.gif">
		<form id="frmestate_rs_luyong_main" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="4">
                        <TD id="trRow0" height="30" class="title" vAlign="middle" align="left">��ǰλ�ã����¹���&nbsp;&gt;&gt;&gt;&gt;&nbsp;��Ա¼������</TD>
                        <TD width="4">
                    </TR>					
                    <TR id="trRow1">
						<TD width="4"><asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton><asp:LinkButton id="lnkMenu" Runat="server" Width="0px"></asp:LinkButton><INPUT id="htxtSelectMenuID" type="hidden" size="1" runat="server"><INPUT id="htxtMenuParam00" type="hidden" size="1" runat="server"></TD>
						<TD align="center">
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD>
						                <ComponentArt:Menu id="mnuMain" runat="server" width="100%" Orientation="Horizontal" CssClass="TopGroup"
								            DefaultGroupCssClass="MenuGroup" DefaultSubGroupExpandOffsetX="-10" DefaultSubGroupExpandOffsetY="-5"
								            DefaultItemLookID="DefaultItemLook" TopGroupItemSpacing="1" DefaultGroupItemSpacing="2" ImagesBaseUrl="../images/"
								            EnableViewState="false" ExpandDelay="100" DefaultTarget="mainFrame">
											<ITEMS>
												<COMPONENTART:MENUITEM id="mnuNew" DisabledLookId="MenuItemDisabledLook" Target="mainFrame" Text="�µ��ļ�" ClientSideCommand="doMenuItemClick('mnuNew','');"></COMPONENTART:MENUITEM>
												<COMPONENTART:MENUITEM id="mnuOpen" DisabledLookId="MenuItemDisabledLook" Target="mainFrame" Text="���ļ�" ClientSideCommand="doMenuItemClick('mnuOpen','');"></COMPONENTART:MENUITEM>
												<COMPONENTART:MENUITEM id="mnuDelete" DisabledLookId="MenuItemDisabledLook" Target="mainFrame" Text="ɾ���ļ�" ClientSideCommand="doMenuItemClick('mnuDelete','');"></COMPONENTART:MENUITEM>
												<COMPONENTART:MENUITEM id="mnuXXCY" DisabledLookId="MenuItemDisabledLook" Target="mainFrame" Text="������Ϣ">
													<COMPONENTART:MENUITEM id="mnuXXCY_CYYJ" DisabledLookId="MenuItemDisabledLook" Target="mainFrame" Text="�鿴�쵼��ʾ" ClientSideCommand="doMenuItemClick('mnuXXCY_CYYJ','');"></COMPONENTART:MENUITEM>
													<COMPONENTART:MENUITEM id="mnuXXCY_CKLZ" DisabledLookId="MenuItemDisabledLook" Target="mainFrame" Text="�鿴��ת���" ClientSideCommand="doMenuItemClick('mnuXXCY_CKLZ','');"></COMPONENTART:MENUITEM>
													<COMPONENTART:MENUITEM id="mnuXXCY_CKBY" DisabledLookId="MenuItemDisabledLook" Target="mainFrame" Text="�鿴�������" ClientSideCommand="doMenuItemClick('mnuXXCY_CKBY','');"></COMPONENTART:MENUITEM>
													<COMPONENTART:MENUITEM id="mnuXXCY_CKRZ" DisabledLookId="MenuItemDisabledLook" Target="mainFrame" Text="�鿴������־" ClientSideCommand="doMenuItemClick('mnuXXCY_CKRZ','');"></COMPONENTART:MENUITEM>
													<COMPONENTART:MENUITEM id="mnuXXCY_CKCB" DisabledLookId="MenuItemDisabledLook" Target="mainFrame" Text="�鿴�߰����" ClientSideCommand="doMenuItemClick('mnuXXCY_CKCB','');"></COMPONENTART:MENUITEM>
													<COMPONENTART:MENUITEM id="mnuXXCY_CKDB" DisabledLookId="MenuItemDisabledLook" Target="mainFrame" Text="�鿴�������" ClientSideCommand="doMenuItemClick('mnuXXCY_CKDB','');"></COMPONENTART:MENUITEM>
												</COMPONENTART:MENUITEM>
												<COMPONENTART:MENUITEM id="mnuBWTX" DisabledLookId="MenuItemDisabledLook" Target="mainFrame" Text="��������">
													<COMPONENTART:MENUITEM id="mnuBWTX_SZTX" DisabledLookId="MenuItemDisabledLook" Target="mainFrame" Text="���ñ�������" ClientSideCommand="doMenuItemClick('mnuBWTX_SZTX','');"></COMPONENTART:MENUITEM>
													<COMPONENTART:MENUITEM id="mnuBWTX_QCTX" DisabledLookId="MenuItemDisabledLook" Target="mainFrame" Text="�����������" ClientSideCommand="doMenuItemClick('mnuBWTX_QCTX','');"></COMPONENTART:MENUITEM>
												</COMPONENTART:MENUITEM>
												<COMPONENTART:MENUITEM id="mnuPrint" DisabledLookId="MenuItemDisabledLook" Target="mainFrame" Text="������ӡ">
													<COMPONENTART:MENUITEM id="mnuPrint_QWJS" DisabledLookId="MenuItemDisabledLook" Target="mainFrame" Text="ȫ�ļ���" ClientSideCommand="doMenuItemClick('mnuPrint_QWJS','');"></COMPONENTART:MENUITEM>
													<COMPONENTART:MENUITEM id="mnuPrint_DYQD" DisabledLookId="MenuItemDisabledLook" Target="mainFrame" Text="�����ļ��嵥" ClientSideCommand="doMenuItemClick('mnuPrint_DYQD','');"></COMPONENTART:MENUITEM>
												</COMPONENTART:MENUITEM>
												<COMPONENTART:MENUITEM id="mnuUnlock" DisabledLookId="MenuItemDisabledLook" Target="mainFrame" Text="�������" ClientSideCommand="doMenuItemClick('mnuUnlock','');"></COMPONENTART:MENUITEM>
												<COMPONENTART:MENUITEM id="mnuRefresh" DisabledLookId="MenuItemDisabledLook" Target="mainFrame" Text="ˢ����ʾ" ClientSideCommand="doMenuItemClick('mnuRefresh','');"></COMPONENTART:MENUITEM>
												<COMPONENTART:MENUITEM id="mnuClose" DisabledLookId="MenuItemDisabledLook" Target="mainFrame" Text="�����ϼ�" ClientSideCommand="doMenuItemClick('mnuClose','');"></COMPONENTART:MENUITEM>
											</ITEMS>
											<ITEMLOOKS>
	        								  	<COMPONENTART:ItemLook LookID="TopItemLook" CssClass="TopMenuItem" HoverCssClass="TopMenuItemHover" LabelPaddingLeft="15" LabelPaddingRight="15" LabelPaddingTop="4" LabelPaddingBottom="4" />
									            <COMPONENTART:ItemLook LookID="DefaultItemLook" CssClass="MenuItem" HoverCssClass="MenuItemHover" ExpandedCssClass="MenuItemHover" LabelPaddingLeft="18" LabelPaddingRight="12" LabelPaddingTop="4" LabelPaddingBottom="4" />
									            <COMPONENTART:ItemLook LookID="MenuItemDisabledLook" CssClass="MenuItemDisabled" HoverCssClass="" ExpandedCssClass="" LabelPaddingLeft="18" LabelPaddingRight="12" LabelPaddingTop="4" LabelPaddingBottom="4" />
									            <COMPONENTART:ItemLook LookID="BreakItem" CssClass="MenuBreak" ImageHeight="2" ImageWidth="100%" ImageUrl="../images/menu01/break.gif" />
											</ITEMLOOKS>
										</ComponentArt:Menu>
									</TD>
								</TR>
							</TABLE>
						</TD>
						<TD width="4"></TD>
					</TR>
					<TR>
						<TD width="4"></TD>
						<TD style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid" vAlign="top" align="center">
							<TABLE cellSpacing="0" cellPadding="0" border="0">
								<TR>
									<TD colSpan="3" height="4"></TD>
								</TR>
								<TR>
									<TD width="5"></TD>
									<TD vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" border="0">
											<TR>
												<TD class="label" align="left">
													<TABLE cellSpacing="0" cellPadding="0" border="0">
														<TR id="trRow3">
															<TD class="label" vAlign="middle">����&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtRSLYGLSearch_WJBT" runat="server" CssClass="textbox" Font-Size="12px" Columns="48" Font-Names="����"></asp:textbox></TD>
															<TD class="label" vAlign="middle">&nbsp;&nbsp;��������&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtRSLYGLSearch_JBRQMin" runat="server" CssClass="textbox" Font-Size="12px" Columns="10" Font-Names="����"></asp:textbox>~<asp:textbox id="txtRSLYGLSearch_JBRQMax" runat="server" CssClass="textbox" Font-Size="12px" Columns="10" Font-Names="����"></asp:textbox></TD>
															<TD class="label" vAlign="middle">&nbsp;&nbsp;ǩ������&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtRSLYGLSearch_QFRQMin" runat="server" CssClass="textbox" Font-Size="12px" Columns="10" Font-Names="����"></asp:textbox>~<asp:textbox id="txtRSLYGLSearch_QFRQMax" runat="server" CssClass="textbox" Font-Size="12px" Columns="10" Font-Names="����"></asp:textbox></TD>
															<TD class="label" vAlign="middle">&nbsp;&nbsp;����״̬&nbsp;</TD>
															<TD class="label" align="left"><asp:DropDownList ID="ddlRSLYGLSearch_BLZT" Runat="server" CssClass="textbox">
															        <asp:ListItem Value=""></asp:ListItem>
															        <asp:ListItem Value="���ڰ���">���ڰ���</asp:ListItem>
															        <asp:ListItem Value="�Ѿ�ǩ��">�Ѿ�ǩ��</asp:ListItem>
															        <asp:ListItem Value="�������">�������</asp:ListItem>
															        <asp:ListItem Value="�ݻ�����">�ݻ�����</asp:ListItem>
															        <asp:ListItem Value="�ļ�����">�ļ�����</asp:ListItem>
															    </asp:DropDownList>
															</td>
															<TD class="label">&nbsp;&nbsp;<asp:button id="btnRSLYGLSearch" Runat="server" CssClass="button" Font-Name="����" Font-Size="12px" Text="����"></asp:button></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD>
													<DIV id="divRSLYGL" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 800px; CLIP: rect(0px 800px 420px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 420px">
														<asp:datagrid id="grdRSLYGL" runat="server" Width="1700px" CssClass="label" Font-Size="12px" Font-Names="����"
															UseAccessibleHeader="True" AllowPaging="True" AutoGenerateColumns="False" GridLines="Vertical"
															BackColor="White" BorderStyle="None" PageSize="30" BorderColor="#DEDFDE" BorderWidth="0px"
															AllowSorting="True" CellPadding="4">
															<SelectedItemStyle Font-Size="12px" Font-Names="����" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
															<EditItemStyle Font-Size="12px" Font-Names="����" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
															<AlternatingItemStyle Font-Size="12px" Font-Names="����" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
															<ItemStyle Font-Size="12px" Font-Names="����" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
															<HeaderStyle Font-Size="12px" Font-Names="����" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#006699" HorizontalAlign="Left"></HeaderStyle>
															<FooterStyle BackColor="#CCCC99"></FooterStyle>
															
															<Columns>
																<asp:TemplateColumn HeaderText="ѡ" ItemStyle-Width="20px">
																	<HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
																	<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																	<ItemTemplate>
																		<asp:CheckBox id="chkRSLYGL" runat="server" AutoPostBack="False" Width="30px"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�ļ���ʶ" SortExpression="�ļ���ʶ" HeaderText="�ļ���ʶ" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="��ˮ��" SortExpression="��ˮ��" HeaderText="��ˮ��" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="��������" SortExpression="��������" HeaderText="��������" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="60px" DataTextField="��������" SortExpression="��������" HeaderText="����" CommandName="Select">
																	<HeaderStyle Width="60px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="300px" DataTextField="�ļ�����" SortExpression="�ļ�����" HeaderText="����" CommandName="OpenDocument">
																	<HeaderStyle Width="300px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="60px" DataTextField="�����̶�" SortExpression="�����̶�" HeaderText="����" CommandName="OpenDocument">
																	<HeaderStyle Width="60px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="60px" DataTextField="���ܵȼ�" SortExpression="���ܵȼ�" HeaderText="�ܼ�" CommandName="OpenDocument">
																	<HeaderStyle Width="60px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="200px" DataTextField="ǩ������" SortExpression="ǩ������" HeaderText="ǩ������" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="200px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="80px" DataTextField="ǩ����" SortExpression="ǩ����" HeaderText="ǩ����" CommandName="Select">
																	<HeaderStyle Width="80px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="��������" SortExpression="��������" HeaderText="��������" CommandName="Select">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="������Ա" SortExpression="������Ա" HeaderText="������Ա" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="200px" DataTextField="��������" SortExpression="��������" HeaderText="��������" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="200px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="200px" DataTextField="���쵥λ" SortExpression="���쵥λ" HeaderText="���쵥λ" CommandName="Select">
																	<HeaderStyle Width="200px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="����״̬" SortExpression="����״̬" HeaderText="����״̬" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="200px" DataTextField="��ע��Ϣ" SortExpression="��ע��Ϣ" HeaderText="��ע��Ϣ" CommandName="Select">
																	<HeaderStyle Width="200px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="���ش���" SortExpression="���ش���" HeaderText="���ش���" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�ļ����" SortExpression="�ļ����" HeaderText="�ļ����" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�ļ����" SortExpression="�ļ����" HeaderText="�ļ����" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
															</Columns>
															
															<PagerStyle Visible="False" NextPageText="��ҳ" Font-Size="12px" Font-Names="����" PrevPageText="��ҳ" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
														</asp:datagrid><INPUT id="htxtRSLYGLFixed" type="hidden" size="1" value="0" runat="server">
													</DIV>
												</TD>
											</TR>
											<TR>
												<TD class="label">
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR id="trRow2">
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZRSLYGLDeSelectAll" runat="server" Font-Name="����" Font-Size="12px">��ѡ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZRSLYGLSelectAll" runat="server" Font-Name="����" Font-Size="12px">ȫѡ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZRSLYGLMoveFirst" runat="server" Font-Name="����" Font-Size="12px">��ǰ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZRSLYGLMovePrev" runat="server" Font-Name="����" Font-Size="12px">ǰҳ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZRSLYGLMoveNext" runat="server" Font-Name="����" Font-Size="12px">��ҳ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZRSLYGLMoveLast" runat="server" Font-Name="����" Font-Size="12px">���</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZRSLYGLGotoPage" runat="server" Font-Name="����" Font-Size="12px">ǰ��</asp:linkbutton><asp:textbox id="txtRSLYGLPageIndex" runat="server" CssClass="textbox" Font-Name="����" Font-Size="12px" Columns="3">1</asp:textbox>ҳ</TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZRSLYGLSetPageSize" runat="server" Font-Name="����" Font-Size="12px">ÿҳ</asp:linkbutton><asp:textbox id="txtRSLYGLPageSize" runat="server" CssClass="textbox" Font-Name="����" Font-Size="12px" Columns="3">30</asp:textbox>��</TD>
															<TD class="label" vAlign="middle" noWrap align="right"><asp:label id="lblRSLYGLGridLocInfo" runat="server" CssClass="label" Font-Name="����" Font-Size="12px">1/10 N/15</asp:label></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
									</TD>
									<TD width="5"></TD>
								</TR>
								<TR>
									<TD colSpan="3" height="4"></TD>
								</TR>
							</TABLE>
						</TD>
						<TD width="4"></TD>
					</TR>
				</TABLE>
			</asp:panel>
			<asp:panel id="panelError" Runat="server">
				<TABLE id="tabErrMain" height="98%" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="5%"></TD>
						<TD>
							<TABLE id="tabErrInfo" height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD>&nbsp;&nbsp;&nbsp;&nbsp;</TD>
									<TD id="tdErrInfo" style="FONT-SIZE: 32pt; COLOR: black; LINE-HEIGHT: 40pt; FONT-FAMILY: ����; LETTER-SPACING: 2pt" align="center"><asp:Label id="lblMessage" Runat="server"></asp:Label><P>&nbsp;&nbsp;</P><P><asp:Button ID="btnGoBack" Runat="server" Font-Size="24pt" Text=" ���� "></asp:Button></P></TD>
									<TD>&nbsp;&nbsp;&nbsp;&nbsp;</TD>
								</TR>
							</TABLE>
						</TD>
						<TD width="5%"></TD>
					</TR>
				</TABLE>
			</asp:panel>
			<table cellSpacing="0" cellPadding="0" align="center" border="0">
				<tr>
					<td>
						<input id="htxtSessionIdQuery" type="hidden" runat="server">
						<input id="htxtRSLYGLQuery" type="hidden" runat="server">
						<input id="htxtRSLYGLRows" type="hidden" runat="server">
						<input id="htxtRSLYGLSort" type="hidden" runat="server">
						<input id="htxtRSLYGLSortColumnIndex" type="hidden" runat="server">
						<input id="htxtRSLYGLSortType" type="hidden" runat="server">
						<input id="htxtDivLeftRSLYGL" type="hidden" runat="server">
						<input id="htxtDivTopRSLYGL" type="hidden" runat="server">
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
							function ScrollProc_divRSLYGL() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopRSLYGL");
								if (oText != null) oText.value = divRSLYGL.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftRSLYGL");
								if (oText != null) oText.value = divRSLYGL.scrollLeft;
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
								oText=document.getElementById("htxtDivTopRSLYGL");
								if (oText != null) divRSLYGL.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftRSLYGL");
								if (oText != null) divRSLYGL.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divRSLYGL.onscroll = ScrollProc_divRSLYGL;
							}
							catch (e) {}
						</script>
					</td>
				</tr>
				<tr>
					<td>
						<script language="javascript">window_onresize();</script>
						<uwin:popmessage id="popMessageObject" runat="server" EnableViewState="False" PopupWindowType="Normal" ActionType="OpenWindow" Visible="False" width="96px" height="48px"></uwin:popmessage>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
