<%@ Page Language="vb" AutoEventWireup="false" Codebehind="estate_rs_rskp_ydjl.aspx.vb" Inherits="Josco.JSOA.web.estate_rs_rskp_ydjl" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>��Ա���±䶯����鿴��༭��</title>
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
	<body background="../../images/oabk.gif" bottomMargin="0" leftMargin="0" topMargin="0"
		rightMargin="0" onresize="return window_onresize()">
		<form id="frmestate_rs_rskp_ydjl" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="5"></TD>
						<TD vAlign="top" align="center">
							<TABLE cellSpacing="0" cellPadding="0" border="0">
								<TR id="trRow1">
									<TD class="title" align="left" colSpan="3" height="30">��ǰλ�ã����¹���&nbsp;&gt;&gt;&gt;&gt;&nbsp;���±䶯����<%=propRYMC%>��<asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton></TD>
								</TR>
								<TR>
									<TD height="4"></TD>
								</TR>
								<TR>
									<TD width="5"></TD>
									<TD vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" border="0">
											<TR id="trRow2">
												<TD class="label" style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid"
													align="left">
													<TABLE cellSpacing="0" cellPadding="0" border="0">
														<TR>
															<TD class="label" vAlign="middle" align="right">��Ա&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtRYLISTSearch_RYDM" runat="server" Columns="4" Font-Names="����" CssClass="textbox" Font-Size="12px"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;ʱ��&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtRYLISTSearch_YDSJMin" runat="server" Columns="8" Font-Names="����" CssClass="textbox" Font-Size="12px"></asp:textbox>~<asp:textbox id="txtRYLISTSearch_YDSJMax" runat="server" Columns="8" Font-Names="����" CssClass="textbox" Font-Size="12px"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;�ֵ�λ&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtRYLISTSearch_RZDW" runat="server" Columns="6" Font-Names="����" CssClass="textbox" Font-Size="12px"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;ԭ��λ&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtRYLISTSearch_YRDW" runat="server" Columns="6" Font-Names="����" CssClass="textbox" Font-Size="12px"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;�ڸ�&nbsp;</TD>
															<TD class="label" align="left">
																<asp:DropDownList id="ddlRYLISTSearch_GWSX" runat="server" Font-Names="����" CssClass="textbox" Font-Size="12px">
																	<asp:ListItem Value=""></asp:ListItem>
																	<asp:ListItem Value="0">���</asp:ListItem>
																	<asp:ListItem Value="1">�ڸ�</asp:ListItem>
																</asp:DropDownList>
															</TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;����&nbsp;</TD>
															<TD class="label" align="left"><asp:DropDownList id="ddlRYLISTSearch_YDYY" runat="server" Font-Names="����" CssClass="textbox" Font-Size="12px"></asp:DropDownList></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;ְ�����&nbsp;</TD>
															<TD class="label" align="left"><asp:DropDownList id="ddlRYLISTSearch_ZGSX" runat="server" Font-Names="����" CssClass="textbox" Font-Size="12px"></asp:DropDownList></TD>
															<TD class="label">&nbsp;<asp:button id="btnRYLISTSearch" Runat="server" CssClass="button" Text="����"></asp:button><asp:button id="btnRYLISTSearch_Full" Runat="server" CssClass="button" Text="ȫ��"></asp:button></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD>
													<DIV id="divRYLIST" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 964px; CLIP: rect(0px 964px 326px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 326px">
														<asp:datagrid id="grdRYLIST" runat="server" Width="2960px" Font-Names="����" CssClass="label" Font-Size="12px"
															UseAccessibleHeader="True" AllowPaging="True" AutoGenerateColumns="False" GridLines="Vertical"
															BackColor="White" BorderStyle="None" PageSize="12" BorderColor="#DEDFDE" BorderWidth="0px"
															AllowSorting="True" CellPadding="2">
															<SelectedItemStyle Font-Names="����" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
															<EditItemStyle Font-Names="����" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
															<AlternatingItemStyle Font-Names="����" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
															<ItemStyle Font-Names="����" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
															<HeaderStyle Font-Names="����" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#6699cc" HorizontalAlign="Left"></HeaderStyle>
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
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="��Ա����" SortExpression="��Ա����" HeaderText="Ա����" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="80px" DataTextField="��Ա����" SortExpression="��Ա����" HeaderText="����" CommandName="Select">
																	<HeaderStyle Width="80px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="��ʼʱ��" SortExpression="��ʼʱ��" HeaderText="��ʼʱ��" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd HH:mm:ss}">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="��ֹʱ��" SortExpression="��ֹʱ��" HeaderText="��ֹʱ��" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd HH:mm:ss}">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�䶯ԭ��" SortExpression="�䶯ԭ��" HeaderText="�䶯ԭ����" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="�䶯ԭ������" SortExpression="�䶯ԭ������" HeaderText="�䶯����" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="��ְ��λ" SortExpression="��ְ��λ" HeaderText="��ְ��λ��" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="180px" DataTextField="��ְ��λ����" SortExpression="��ְ��λ����" HeaderText="���ε�λ" CommandName="Select">
																	<HeaderStyle Width="180px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="ԭ�ε�λ" SortExpression="ԭ�ε�λ" HeaderText="ԭ�ε�λ��" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="180px" DataTextField="ԭ�ε�λ����" SortExpression="ԭ�ε�λ����" HeaderText="ԭ�ε�λ" CommandName="Select">
																	<HeaderStyle Width="180px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="��ְ����" SortExpression="��ְ����" HeaderText="���μ���" CommandName="Select">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="ԭ�μ���" SortExpression="ԭ�μ���" HeaderText="ԭ�μ���" CommandName="Select">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="��λ����" SortExpression="��λ����" HeaderText="��λ������" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="��λ��������" SortExpression="��λ��������" HeaderText="����/���" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="ԭ������" SortExpression="ԭ������" HeaderText="ԭ��������" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="ԭ����������" SortExpression="ԭ����������" HeaderText="ԭ��/���" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="ְ������" SortExpression="ְ������" HeaderText="ְ��������" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="ְ����������" SortExpression="ְ����������" HeaderText="��ְ�����" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="ԭְ����" SortExpression="ԭְ����" HeaderText="ԭְ������" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="ԭְ��������" SortExpression="ԭְ��������" HeaderText="ԭְ�����" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="����ռ��" SortExpression="����ռ��" HeaderText="����ռ��" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="�ϴ�ռ��" SortExpression="�ϴ�ռ��" HeaderText="�ϴ�ռ��" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="�����Ŷ�" SortExpression="�����Ŷ�" HeaderText="�����Ŷ�" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="ԭ���Ŷ�" SortExpression="ԭ���Ŷ�" HeaderText="ԭ���Ŷ�" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="��������" SortExpression="��������" HeaderText="��������" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="ԭ������" SortExpression="ԭ������" HeaderText="ԭ������" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�����־" SortExpression="�����־" HeaderText="�����־��" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="80px" DataTextField="�����־����" SortExpression="�����־����" HeaderText="����˵��" CommandName="Select">
																	<HeaderStyle Width="80px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="180px" DataTextField="�ֹܹ���" SortExpression="�ֹܹ���" HeaderText="�ֹܹ���" CommandName="Select">
																	<HeaderStyle Width="180px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="200px" DataTextField="��ע��Ϣ" SortExpression="��ע��Ϣ" HeaderText="��ע" CommandName="Select">
																	<HeaderStyle Width="200px"></HeaderStyle>
																</asp:ButtonColumn>

																<asp:ButtonColumn ItemStyle-Width="360px" DataTextField="������ʶ" SortExpression="������ʶ" HeaderText="������ʶ" CommandName="Select">
																	<HeaderStyle Width="360px"></HeaderStyle>
																</asp:ButtonColumn>
															</Columns>
															
															<PagerStyle Visible="False" NextPageText="��ҳ" Font-Names="����" PrevPageText="��ҳ" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
														</asp:datagrid><INPUT id="htxtRYLISTFixed" type="hidden" value="0" runat="server">
													</DIV>
												</TD>
											</TR>
											<TR id="trRow3">
												<TD class="label">
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD class="label" vAlign="baseline" align="left"><asp:linkbutton id="lnkCZRYLISTDeSelectAll" runat="server">��ѡ</asp:linkbutton></TD>
															<TD class="label" vAlign="baseline" align="left"><asp:linkbutton id="lnkCZRYLISTSelectAll" runat="server">ȫѡ</asp:linkbutton></TD>
															<TD class="label" vAlign="baseline" align="left"><asp:linkbutton id="lnkCZRYLISTMoveFirst" runat="server">��ǰ</asp:linkbutton></TD>
															<TD class="label" vAlign="baseline" align="left"><asp:linkbutton id="lnkCZRYLISTMovePrev" runat="server">ǰҳ</asp:linkbutton></TD>
															<TD class="label" vAlign="baseline" align="left"><asp:linkbutton id="lnkCZRYLISTMoveNext" runat="server">��ҳ</asp:linkbutton></TD>
															<TD class="label" vAlign="baseline" align="left"><asp:linkbutton id="lnkCZRYLISTMoveLast" runat="server">���</asp:linkbutton></TD>
															<TD class="label" vAlign="baseline" align="left"><asp:linkbutton id="lnkCZRYLISTGotoPage" runat="server">ǰ��</asp:linkbutton><asp:textbox id="txtRYLISTPageIndex" runat="server" Columns="3" CssClass="textbox">1</asp:textbox>ҳ</TD>
															<TD class="label" vAlign="baseline" align="left"><asp:linkbutton id="lnkCZRYLISTSetPageSize" runat="server">ÿҳ</asp:linkbutton><asp:textbox id="txtRYLISTPageSize" runat="server" Columns="3" CssClass="textbox">12</asp:textbox>��</TD>
															<TD class="label" vAlign="baseline" noWrap align="right"><asp:label id="lblRYLISTGridLocInfo" runat="server" CssClass="label">1/10 N/15</asp:label></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR id="trRow4">
												<TD class="label" style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid" width="100%">
													<TABLE cellSpacing="0" cellPadding="0" border="0" width="100%">
														<TR>
															<TD class="label" width="100%">
																<TABLE cellSpacing="0" cellPadding="0" border="0" width="100%">
																	<TR>
																		<TD class="labelNotNull" align="right" nowrap>&nbsp;&nbsp;Ա������</TD>
																		<TD class="label" align="left" nowrap><asp:textbox id="txtRYMC" Runat="server" Width="264px" CssClass="textbox"></asp:textbox><asp:Button id="btnSelect_RYDM" Runat="server" CssClass="button" Text="��"></asp:Button><INPUT id="htxtWYBS" type="hidden" size="1" runat="server"><INPUT id="htxtRYDM" type="hidden" size="1" runat="server"><INPUT id="htxtGLBS" type="hidden" size="1" runat="server"></TD>
																		<TD class="label" align="right" nowrap>&nbsp;&nbsp;���ε�λ</TD>
																		<TD class="label" align="left" nowrap><asp:textbox id="txtRZDW" Runat="server" Width="190px" CssClass="textbox"></asp:textbox><asp:Button id="btnSelect_RZDW" Runat="server" CssClass="button" Text="��"></asp:Button><INPUT id="htxtRZDW" type="hidden" size="1" runat="server"></TD>
																		<TD class="label" align="right" nowrap>&nbsp;&nbsp;ԭ�ε�λ</TD>
																		<TD class="label" align="left" nowrap><asp:textbox id="txtYRDW" Runat="server" Width="190px" CssClass="textbox"></asp:textbox><asp:Button id="btnSelect_YRDW" Runat="server" CssClass="button" Text="��"></asp:Button><INPUT id="htxtYRDW" type="hidden" size="1" runat="server" NAME="htxtYRDW"></TD>
																		<TD><asp:button id="btnSave" Runat="server" Width="48px" CssClass="button" Text="����" Height="24px"></asp:button></TD>
																	</TR>
																	<TR>
																		<TD class="labelNotNull" align="right" nowrap>&nbsp;&nbsp;�䶯��ʼ</TD>
																		<TD class="label" align="left" nowrap><asp:textbox id="txtKSSJ" Runat="server" Width="264px" CssClass="textbox"></asp:textbox></TD>
																		<TD class="label" align="right" nowrap>&nbsp;&nbsp;���μ���</TD>
																		<TD class="label" align="left" nowrap><asp:textbox id="txtRZJB" Runat="server" Width="190px" CssClass="textbox"></asp:textbox></TD>
																		<TD class="label" align="right" nowrap>&nbsp;&nbsp;ԭ�μ���</TD>
																		<TD class="label" align="left" nowrap><asp:textbox id="txtYRJB" Runat="server" Width="190px" CssClass="textbox"></asp:textbox></TD>
																		<TD></TD>
																	</TR>
																	<TR>
																		<TD class="label" align="right" nowrap>&nbsp;&nbsp;�䶯����</TD>
																		<TD class="label" align="left" nowrap><asp:textbox id="txtJSSJ" Runat="server" Width="264px" CssClass="textbox"></asp:textbox></td>
																		<TD class="label" align="right" nowrap>&nbsp;&nbsp;��ְ���</TD>
																		<TD class="label" align="left" nowrap><asp:DropDownList id="ddlZGSX" Runat="server" Width="190px" CssClass="textbox"></asp:DropDownList></TD>
																		<TD class="label" align="right" nowrap>&nbsp;&nbsp;ԭְ���</TD>
																		<TD class="label" align="left" nowrap><asp:DropDownList id="ddlYZSX" Runat="server" Width="190px" CssClass="textbox"></asp:DropDownList></TD>
																		<TD></TD>
																	</TR>
																	<tr>
																		<TD class="labelNotNull" align="right" nowrap>&nbsp;&nbsp;�䶯����</TD>
																		<TD class="label" align="left" nowrap><asp:DropDownList id="ddlYDYY" Runat="server" Width="264px" CssClass="textbox"></asp:DropDownList></TD>
																		<TD class="label" align="right" nowrap>&nbsp;&nbsp;��������</TD>
																		<TD class="label" align="left" nowrap><asp:textbox id="txtSSFZ" Runat="server" Width="190px" CssClass="textbox"></asp:textbox></TD>
																		<TD class="label" align="right" nowrap>&nbsp;&nbsp;ԭ������</TD>
																		<TD class="label" align="left" nowrap><asp:textbox id="txtYSFZ" Runat="server" Width="190px" CssClass="textbox"></asp:textbox></TD>
																		<td></td>
																		<td></td>
																		<td></td>
																	</tr>
																	<TR>
																		<TD class="label" align="right" nowrap>&nbsp;&nbsp;��������</TD>
																		<TD class="label" align="left" nowrap>
																			<asp:RadioButtonList id="rblJBBZ" Runat="server" CssClass="textbox" RepeatLayout="Flow" RepeatDirection="Vertical" RepeatColumns="3">
																				<asp:ListItem Value="0">�ǹ�����Ա</asp:ListItem>
																				<asp:ListItem Value="1">�в������Ա</asp:ListItem>
																				<asp:ListItem Value="2">�߲������Ա</asp:ListItem>
																			</asp:RadioButtonList>
																		</TD>
																		<TD class="label" align="right" nowrap>&nbsp;&nbsp;�������</TD>
																		<TD class="label" align="left" nowrap>
																			<asp:RadioButtonList id="rblGWSX" Runat="server" CssClass="textbox" RepeatLayout="Flow" RepeatDirection="Vertical" RepeatColumns="2">
																				<asp:ListItem Value="0">���</asp:ListItem>
																				<asp:ListItem Value="1">�ڸ�</asp:ListItem>
																			</asp:RadioButtonList>
																		</TD>
																		<TD class="label" align="right" nowrap>&nbsp;&nbsp;ԭ�����</TD>
																		<TD class="label" align="left" nowrap>
																			<asp:RadioButtonList id="rblYGSX" Runat="server" CssClass="textbox" RepeatLayout="Flow" RepeatDirection="Vertical" RepeatColumns="2">
																				<asp:ListItem Value="0">���</asp:ListItem>
																				<asp:ListItem Value="1">�ڸ�</asp:ListItem>
																			</asp:RadioButtonList>
																		</TD>
																		<TD></TD>
																	</TR>
																	<tr>
																		<TD class="label" align="right" nowrap>&nbsp;&nbsp;�ֹܹ���</TD>
																		<TD class="label" align="left" nowrap><asp:textbox id="txtFGGZ" Runat="server" Width="264px" CssClass="textbox"></asp:textbox></TD>
																		<TD class="label" align="right" nowrap>&nbsp;&nbsp;����ռ��</TD>
																		<TD class="label" align="left" nowrap>
																			<asp:RadioButtonList id="rblBCZB" Runat="server" CssClass="textbox" RepeatLayout="Flow" RepeatDirection="Vertical" RepeatColumns="2">
																				<asp:ListItem Value="0">��ռ</asp:ListItem>
																				<asp:ListItem Value="1">ռ��</asp:ListItem>
																			</asp:RadioButtonList>
																		</TD>
																		<TD class="label" align="right" nowrap>&nbsp;&nbsp;ԭ��ռ��</TD>
																		<TD class="label" align="left" nowrap>
																			<asp:RadioButtonList id="rblSCZB" Runat="server" CssClass="textbox" RepeatLayout="Flow" RepeatDirection="Vertical" RepeatColumns="2">
																				<asp:ListItem Value="0">��ռ</asp:ListItem>
																				<asp:ListItem Value="1">ռ��</asp:ListItem>
																			</asp:RadioButtonList>
																		</TD>
																	</tr>
																	<tr>
																		<TD class="label" align="right" nowrap>&nbsp;&nbsp;��ע��Ϣ</TD>
																		<TD class="label" align="left" nowrap><asp:textbox id="txtBZXX" Runat="server" Width="264px" CssClass="textbox"></asp:textbox></TD>
																		<TD class="label" align="right" nowrap>&nbsp;&nbsp;�����Ŷ�</TD>
																		<TD class="label" align="left" nowrap><asp:textbox id="txtXSTD" Runat="server" Width="190px" CssClass="textbox"></asp:textbox></TD>
																		<TD class="label" align="right" nowrap>&nbsp;&nbsp;ԭ���Ŷ�</TD>
																		<TD class="label" align="left" nowrap><asp:textbox id="txtYSTD" Runat="server" Width="190px" CssClass="textbox"></asp:textbox></TD>
																		<td><asp:button id="btnCancel" Runat="server" Width="48px" CssClass="button" Text="ȡ��" Height="24px"></asp:button></td>
																	</tr>
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
								<TR>
									<TD height="3"></TD>
								</TR>
								<TR>
									<TD align="center">
										<asp:Button id="btnAddNew" Runat="server" CssClass="button" Text=" ��    �� " Height="36px"></asp:Button>&nbsp;&nbsp;
										<asp:Button id="btnUpdate" Runat="server" CssClass="button" Text=" ��    �� " Height="36px"></asp:Button>&nbsp;&nbsp;
										<asp:Button id="btnDelete" Runat="server" CssClass="button" Text=" ɾ    �� " Height="36px"></asp:Button>&nbsp;&nbsp;
										<asp:Button id="btnPrint"  Runat="server" CssClass="button" Text=" ��    ӡ " Height="36px"></asp:Button>&nbsp;&nbsp;
										<asp:Button id="btnClose"  Runat="server" CssClass="button" Text=" ��    �� " Height="36px"></asp:Button>
									</TD>
								</TR>
							</TABLE>
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
									<TD id="tdErrInfo" style="FONT-SIZE: 32pt; COLOR: black; LINE-HEIGHT: 40pt; FONT-FAMILY: ����; LETTER-SPACING: 2pt" align="center"><asp:Label id="lblMessage" Runat="server"></asp:Label><P>&nbsp;&nbsp;</P><P><asp:Button id="btnGoBack" Runat="server" Font-Size="24pt" Text=" ���� "></asp:Button></P></TD>
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
