<%@ Page Language="vb" AutoEventWireup="false" Codebehind="estate_rs_rskp_main.aspx.vb" Inherits="Josco.JSOA.web.estate_rs_rskp_main" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>��Ա����һ����</title>
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
				intWidth  -= 2 * 4;                       //���ҿհ�
				intWidth  -= 24;                          //�ҹ�����
				strWidth   = intWidth.toString() + "px";
				
				intHeight  = document.body.clientHeight;  //�ܸ߶�
				intHeight -= 24;                          //������
				intHeight -= trRow1.clientHeight;
				intHeight -= trRow2.clientHeight;
				intHeight -= trRow3.clientHeight;
				intHeight -= trRow4.clientHeight;
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
		<form id="frmestate_rs_rskp_main" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="5"></TD>
						<TD vAlign="top" align="center">
							<TABLE cellSpacing="0" cellPadding="0" border="0">
								<TR id="trRow1">
									<TD class="title" align="left" colSpan="3" height="30">��ǰλ�ã����¹���&nbsp;&gt;&gt;&gt;&gt;&nbsp;��ְԱ������<asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton></TD>
								</TR>
								<tr>
								    <td height="4"></td>
								</tr>
								<TR>
									<TD width="5"></TD>
									<TD vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" border="0">
											<TR id="trRow3">
												<TD class="label" align="left" style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid">
													<TABLE cellSpacing="0" cellPadding="0" border="0">
														<TR>
															<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;Ա����&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtRYLISTSearch_RYDM" runat="server" Font-Size="12px" CssClass="textbox" Font-Names="����" Width="60px"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right">����&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtRYLISTSearch_NNMin" runat="server" Font-Size="12px" CssClass="textbox" Columns="4" Font-Names="����"></asp:textbox>~<asp:textbox id="txtRYLISTSearch_NNMax" runat="server" Font-Size="12px" CssClass="textbox" Columns="4" Font-Names="����"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;ְ��&nbsp;</TD>
															<TD class="label" align="left"><asp:DropDownList id="ddlRYLISTSearch_ZC" runat="server" Font-Size="12px" CssClass="textbox" Font-Names="����"></asp:DropDownList></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;ְҵ�ʸ�&nbsp;</TD>
															<TD class="label" align="left"><asp:DropDownList id="ddlRYLISTSearch_ZYZG" runat="server" Font-Size="12px" CssClass="textbox" Font-Names="����" Width="180px"></asp:DropDownList></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;������ò&nbsp;</TD>
															<TD class="label" align="left"><asp:DropDownList id="ddlRYLISTSearch_ZZMM" runat="server" Font-Size="12px" CssClass="textbox" Font-Names="����"></asp:DropDownList></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;�Ա�&nbsp;</TD>
															<TD class="label" align="left"><asp:DropDownList id="ddlRYLISTSearch_XB" runat="server" Font-Size="12px" CssClass="textbox" Font-Names="����"><asp:ListItem Value=""> </asp:ListItem><asp:ListItem Value="��">��</asp:ListItem><asp:ListItem Value="Ů">Ů</asp:ListItem></asp:DropDownList></TD>
															<TD class="label">&nbsp;&nbsp;<asp:button id="btnRYLISTSearch" Runat="server" Font-Size="12px" Font-Name="����" CssClass="button" Text=" �������� "></asp:button></td>
															
														</Tr>
														<tr>
															<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;����&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtRYLISTSearch_RYXM" runat="server" Font-Size="12px" CssClass="textbox" Font-Names="����" Width="60px"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;��λ&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtRYLISTSearch_DRZW" runat="server" Font-Size="12px" CssClass="textbox" Width="100%" Font-Names="����"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;ѧ��&nbsp;</TD>
															<TD class="label" align="left"><asp:DropDownList id="ddlRYLISTSearch_XL" runat="server" Font-Size="12px" CssClass="textbox" Font-Names="����" Width="100%"></asp:DropDownList></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;ְ��&nbsp;</TD>
															<TD class="label" align="left"><asp:DropDownList id="ddlRYLISTSearch_ZJMC" runat="server" Font-Size="12px" CssClass="textbox" Font-Names="����" Width="180px"></asp:DropDownList></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;����/����&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtRYLISTSearch_JGHJ" runat="server" Font-Size="12px" CssClass="textbox" Font-Names="����" Width="100%"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;����&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtRYLISTSearch_MZ" runat="server" Font-Size="12px" CssClass="textbox" Width="100%" Font-Names="����"></asp:textbox></TD>
															<TD class="label">&nbsp;&nbsp;<asp:button id="btnRYLISTSearch_Full" Runat="server" Font-Size="12px" Font-Name="����" CssClass="button" Text=" ȫ�ļ��� "></asp:button></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD>
													<DIV id="divRYLIST" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 980px; CLIP: rect(0px 980px 389px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 389px">
														<asp:datagrid id="grdRYLIST" runat="server" Width="6100px" Font-Size="12px" CssClass="label" Font-Names="����"
															CellPadding="4" AllowSorting="True" BorderWidth="0px" BorderColor="#DEDFDE" PageSize="30"
															BorderStyle="None" BackColor="White" GridLines="Vertical" AutoGenerateColumns="False" AllowPaging="True"
															UseAccessibleHeader="True">
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
																
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="Ψһ��ʶ" SortExpression="Ψһ��ʶ" HeaderText="Ψһ��ʶ" CommandName="OpenDocument">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="��Ա����" SortExpression="��Ա����" HeaderText="Ա����" CommandName="OpenDocument">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="�Ƿ���ְ" SortExpression="�Ƿ���ְ" HeaderText="�Ƿ���ְ" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="����" SortExpression="����" HeaderText="����" CommandName="OpenDocument">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="60px" DataTextField="�Ա�" SortExpression="�Ա�" HeaderText="�Ա�" CommandName="Select">
																	<HeaderStyle Width="60px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="��������" SortExpression="��������" HeaderText="��������" CommandName="Select"  DataTextFormatString="{0:yyyy-MM}">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="80px" DataTextField="����" SortExpression="����" HeaderText="����" CommandName="Select">
																	<HeaderStyle Width="80px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="������ò" SortExpression="������ò" HeaderText="������ò����" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="80px" DataTextField="������ò����" SortExpression="������ò����" HeaderText="������ò" CommandName="Select">
																	<HeaderStyle Width="80px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="���ѧ��" SortExpression="���ѧ��" HeaderText="���ѧ������" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="���ѧ������" SortExpression="���ѧ������" HeaderText="ѧ��" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="ѧϰ����" SortExpression="ѧϰ����" HeaderText="�������" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="���ѧλ" SortExpression="���ѧλ" HeaderText="���ѧλ����" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="���ѧλ����" SortExpression="���ѧλ����" HeaderText="ѧλ" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="200px" DataTextField="��ҵԺУ" SortExpression="��ҵԺУ" HeaderText="��ҵԺУ" CommandName="Select">
																	<HeaderStyle Width="200px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="��ҵרҵ" SortExpression="��ҵרҵ" HeaderText="רҵ" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="����ְ��" SortExpression="����ְ��" HeaderText="����ְ�ƴ���" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="����ְ������" SortExpression="����ְ������" HeaderText="ְ��" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="ִҵ�ʸ�" SortExpression="ִҵ�ʸ�" HeaderText="ִҵ�ʸ����" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="ִҵ�ʸ�����" SortExpression="ִҵ�ʸ�����" HeaderText="ִҵ�ʸ�" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="80px" DataTextField="����" SortExpression="����" HeaderText="����" CommandName="Select">
																	<HeaderStyle Width="80px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="80px" DataTextField="����" SortExpression="����" HeaderText="����" CommandName="Select">
																	<HeaderStyle Width="80px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="180px" DataTextField="�μӹ���ʱ��" SortExpression="�μӹ���ʱ��" HeaderText="�μӹ���ʱ��" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="180px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="180px" DataTextField="�뱾��λʱ��" SortExpression="�뱾��λʱ��" HeaderText="�뱾��λʱ��" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="180px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="180px" DataTextField="ת��ʱ��" SortExpression="ת��ʱ��" HeaderText="ת��ʱ��" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="180px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="180px" DataTextField="ת��ְλ" SortExpression="ת��ְλ" HeaderText="ת��ְλ" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="180px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="ְ������" SortExpression="ְ������" HeaderText="ְ������" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="200px" DataTextField="ְ������" SortExpression="ְ������" HeaderText="����ְ��" CommandName="Select">
																	<HeaderStyle Width="200px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="300px" DataTextField="����ְ��" SortExpression="����ְ��" HeaderText="����ְ��" CommandName="Select">
																	<HeaderStyle Width="300px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="180px" DataTextField="��ҵʱ��" SortExpression="��ҵʱ��" HeaderText="��ҵʱ��" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="180px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="180px" DataTextField="ְ��ȡ��ʱ��" SortExpression="ְ��ȡ��ʱ��" HeaderText="ְ��ȡ��ʱ��" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="180px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="180px" DataTextField="�뵳ʱ��" SortExpression="�뵳ʱ��" HeaderText="�뵳/��ʱ��" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="180px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="��֯��ϵ" SortExpression="��֯��ϵ" HeaderText="��֯��ϵ" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�Ƿ񹤻��Ա" SortExpression="�Ƿ񹤻��Ա" HeaderText="�Ƿ񹤻��Ա����" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="�Ƿ񹤻��Ա����" SortExpression="�Ƿ񹤻��Ա����" HeaderText="�Ƿ񹤻��Ա" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="300px" DataTextField="������ַ" SortExpression="������ַ" HeaderText="����" CommandName="Select">
																	<HeaderStyle Width="300px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="����״̬" SortExpression="����״̬" HeaderText="����״̬����" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="����״̬����" SortExpression="����״̬����" HeaderText="����״̬" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="����״��" SortExpression="����״��" HeaderText="����״������" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="����״������" SortExpression="����״������" HeaderText="����״��" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�������" SortExpression="�������" HeaderText="�����������" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="�����������" SortExpression="�����������" HeaderText="�������" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="80px" DataTextField="��Ů����" SortExpression="��Ů����" HeaderText="��Ů����" CommandName="Select">
																	<HeaderStyle Width="80px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="�н��ʸ�" SortExpression="�н��ʸ�" HeaderText="�н��ʸ�֤" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="200px" DataTextField="���֤��" SortExpression="���֤��" HeaderText="���֤��" CommandName="Select">
																	<HeaderStyle Width="200px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="300px" DataTextField="��ס��ַ" SortExpression="��ס��ַ" HeaderText="��ס��ַ" CommandName="Select">
																	<HeaderStyle Width="300px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="300px" DataTextField="�ʼĵ�ַ" SortExpression="�ʼĵ�ַ" HeaderText="�ʼĵ�ַ" CommandName="Select">
																	<HeaderStyle Width="300px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="300px" DataTextField="���˷���˵��" SortExpression="���˷���˵��" HeaderText="���˷������" CommandName="Select">
																	<HeaderStyle Width="300px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="300px" DataTextField="��Ա����˵��" SortExpression="��Ա����˵��" HeaderText="��ͥ�������" CommandName="Select">
																	<HeaderStyle Width="300px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="��ְԭ��" SortExpression="��ְԭ��" HeaderText="��ְԭ��" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
															</Columns>
															
															<PagerStyle Visible="False" NextPageText="��ҳ" Font-Size="12px" Font-Names="����" PrevPageText="��ҳ" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
														</asp:datagrid><INPUT id="htxtRYLISTFixed" type="hidden" value="0" runat="server"></DIV>
												</TD>
											</TR>
											<TR id="trRow2">
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
					<TR id="trRow4">
						<TD align="center" colSpan="3">
						    <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
						        <tr>
						            <td height="3"></td>
						        </tr>
						        <tr>
						            <td align="center">
							            <asp:Button id="btnOpen"   Runat="server" Font-Size="12px" Font-Name="����" CssClass="button" Text=" �� " Height="36px"></asp:Button>
							            <asp:Button id="btnAddNew" Runat="server" Font-Size="12px" Font-Name="����" CssClass="button" Text=" ���� " Height="36px"></asp:Button>
							            <asp:Button id="btnUpdate" Runat="server" Font-Size="12px" Font-Name="����" CssClass="button" Text=" �޸� " Height="36px"></asp:Button>
							            <asp:Button id="btnDelete" Runat="server" Font-Size="12px" Font-Name="����" CssClass="button" Text=" ɾ�� " Height="36px"></asp:Button>
							            <asp:Button id="btnPrint"  Runat="server" Font-Size="12px" Font-Name="����" CssClass="button" Text=" ��ӡ��Ա������ϸ�� " Height="36px"></asp:Button>
							            <asp:Button id="btnPXJL"   Runat="server" Font-Size="12px" Font-Name="����" CssClass="button" Text=" ��ѵ��� " Height="36px"></asp:Button>
							            <asp:Button id="btnYDJL"   Runat="server" Font-Size="12px" Font-Name="����" CssClass="button" Text=" �䶯��� " Height="36px"></asp:Button>
							            <asp:Button id="btnLDHT"   Runat="server" Font-Size="12px" Font-Name="����" CssClass="button" Text=" �Ͷ���ͬ " Height="36px"></asp:Button>
							            <asp:Button id="btnClose"  Runat="server" Font-Size="12px" Font-Name="����" CssClass="button" Text=" ���� " Height="36px"></asp:Button>
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
