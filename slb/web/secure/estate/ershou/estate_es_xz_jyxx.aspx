<%@ Page Language="vb" AutoEventWireup="false" Codebehind="estate_es_xz_jyxx.aspx.vb" Inherits="Josco.JSOA.web.estate_es_xz_jyxx" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>ҵ����ѡ����</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../styles01.css" type="text/css" rel="stylesheet">
		<style>
		    TD.grdJYXXLocked { ; LEFT: expression(divJYXX.scrollLeft); POSITION: relative }
		    TH.grdJYXXLocked { ; LEFT: expression(divJYXX.scrollLeft); POSITION: relative }
		    TH.grdJYXXLocked { Z-INDEX: 99 }
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
				
				if (document.all("divJYXX") == null)
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
				strHeight  = intHeight.toString() + "px";
                //if (document.readyState.toLowerCase() == "complete")
                //    alert(strWidth + " " + strHeight);
                
				divJYXX.style.width  = strWidth;
				divJYXX.style.height = strHeight;
				divJYXX.style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";
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
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onresize="return window_onresize()">
		<form id="frmestate_es_xz_jyxx" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="5"></TD>
						<TD vAlign="top" align="center">
							<TABLE cellSpacing="0" cellPadding="0" border="0">
								<TR id="trRow1">
									<TD class="title" align="center" colSpan="3" height="30">ҵ����ѡ����<asp:Label ID="lblSelectMode" Runat="server" CssClass="label"></asp:Label><asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton></TD>
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
															<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;ȷ�����&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtJYXXSearch_JYBH" runat="server" CssClass="textbox" Columns="8"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;�׷�&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtJYXXSearch_YZMC" runat="server" CssClass="textbox" Columns="6"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;�ҷ�&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtJYXXSearch_KHMC" runat="server" CssClass="textbox" Columns="6"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;��ַ&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtJYXXSearch_WYDZ" runat="server" CssClass="textbox" Columns="12"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;ȷ������&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtJYXXSearch_JYRQMin" runat="server" CssClass="textbox" Columns="8"></asp:textbox>~<asp:textbox id="txtJYXXSearch_JYRQMax" runat="server" CssClass="textbox" Columns="8"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;��ͬ����&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtJYXXSearch_HTRQMin" runat="server" CssClass="textbox" Columns="8"></asp:textbox>~<asp:textbox id="txtJYXXSearch_HTRQMax" runat="server" CssClass="textbox" Columns="8"></asp:textbox></TD>
															<TD class="label">&nbsp;&nbsp;<asp:button id="btnJYXXSearch" Runat="server" CssClass="button" Text="����"></asp:button><asp:button id="btnJYXXSearch_Full" Runat="server" CssClass="button" Text="ȫ��"></asp:button></td>
														</Tr>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD>
													<DIV id="divJYXX" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 964px; CLIP: rect(0px 964px 384px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 384px">
														<asp:datagrid id="grdJYXX" runat="server" Font-Size="12px" CssClass="label" Font-Names="����"
															CellPadding="4" AllowSorting="True" BorderWidth="0px" BorderColor="#DEDFDE" PageSize="30"
															BorderStyle="None" GridLines="Vertical" AutoGenerateColumns="False" AllowPaging="True"
															UseAccessibleHeader="True" Width="7040px">
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
																		<asp:CheckBox id="chkJYXX" runat="server" AutoPostBack="False"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="Ψһ��ʶ" SortExpression="Ψһ��ʶ" HeaderText="Ψһ��ʶ" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="��������" SortExpression="��������" HeaderText="����" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="���ױ��" SortExpression="���ױ��" HeaderText="ȷ�����" CommandName="Select">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="��ͬ���" SortExpression="��ͬ���" HeaderText="��ͬ���" CommandName="Select">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="��������" SortExpression="��������" HeaderText="ȷ������" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="��ͬ����" SortExpression="��ͬ����" HeaderText="��ͬ����" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="����״̬" SortExpression="����״̬" HeaderText="����״̬" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="��ͬ״̬" SortExpression="��ͬ״̬" HeaderText="��ͬ״̬" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="ҵ������" SortExpression="ҵ������" HeaderText="ҵ��" CommandName="Select">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="�ͻ�����" SortExpression="�ͻ�����" HeaderText="�ͻ�" CommandName="Select">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="700px" DataTextField="��ҵ��ַ" SortExpression="��ҵ��ַ" HeaderText="��ҵ��ַ" CommandName="Select">
																	<HeaderStyle Width="700px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="���׼۸�" SortExpression="���׼۸�" HeaderText="���" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="�������" SortExpression="�������" HeaderText="���" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="�׷������" SortExpression="�׷������" HeaderText="�׷������" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="�ҷ������" SortExpression="�ҷ������" HeaderText="�ҷ������" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="������ۿ�" SortExpression="������ۿ�" HeaderText="������ۿ�" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="���ʽ" SortExpression="���ʽ" HeaderText="���ʽ" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>

																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="��Դ���" SortExpression="��Դ���" HeaderText="��Դ���" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="����ַ" SortExpression="����ַ" HeaderText="����ַ" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="����" SortExpression="����" HeaderText="����" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="ʵ��Ӷ��" SortExpression="ʵ��Ӷ��" HeaderText="ʵ��Ӷ��" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="����Ӷ��" SortExpression="����Ӷ��" HeaderText="����Ӷ��" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="���һ���" SortExpression="���һ���" HeaderText="���һ���" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="��������" SortExpression="��������" HeaderText="��������" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="���ҳ���" SortExpression="���ҳ���" HeaderText="���ҳ���" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="��������" SortExpression="��������" HeaderText="��������" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="ҵ������" SortExpression="ҵ������" HeaderText="ҵ������" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="ҵ������" SortExpression="ҵ������" HeaderText="ҵ����������" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="ҵ����Դ" SortExpression="ҵ����Դ" HeaderText="ҵ����Դ" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="ҵԴ����" SortExpression="ҵԴ����" HeaderText="ҵ����Դ����" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="ҵ������" SortExpression="ҵ������" HeaderText="ҵ������" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="�ۺ�����" SortExpression="�ۺ�����" HeaderText="�ۺ�����" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="ʣ����ҵ" SortExpression="ʣ����ҵ" HeaderText="ʣ����ҵ" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="�������" SortExpression="�������" HeaderText="��ҵ���" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="�������" SortExpression="�������" HeaderText="��ҵ�������" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="�ͻ���Դ" SortExpression="�ͻ���Դ" HeaderText="�ͻ���Դ" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="��Դ����" SortExpression="��Դ����" HeaderText="�ͻ���Դ����" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="�ͻ�����" SortExpression="�ͻ�����" HeaderText="�ͻ�����" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="����Ŀ��" SortExpression="����Ŀ��" HeaderText="����Ŀ��" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>

													            <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="��ͬ��־" SortExpression="��ͬ��־" HeaderText="��ͬ��־" CommandName="Select">
														            <HeaderStyle Width="100px"></HeaderStyle>
													            </asp:ButtonColumn>
													            <asp:ButtonColumn ItemStyle-Width="140px" DataTextField="�������" SortExpression="�������" HeaderText="�������" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
														            <HeaderStyle Width="140px"></HeaderStyle>
													            </asp:ButtonColumn>
													            <asp:ButtonColumn ItemStyle-Width="140px" DataTextField="��������" SortExpression="��������" HeaderText="��������" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
														            <HeaderStyle Width="140px"></HeaderStyle>
													            </asp:ButtonColumn>
													            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="���˽��" SortExpression="���˽��" HeaderText="���˽��" CommandName="Select" DataTextFormatString="{0:#,##0.00}">
														            <HeaderStyle Width="160px"></HeaderStyle>
													            </asp:ButtonColumn>
													            <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="��ͬ���" SortExpression="��ͬ���" HeaderText="��ͬ���" CommandName="Select">
														            <HeaderStyle Width="100px"></HeaderStyle>
													            </asp:ButtonColumn>
													            <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="���˺�ͬ" SortExpression="���˺�ͬ" HeaderText="���˺�ͬ" CommandName="Select">
														            <HeaderStyle Width="100px"></HeaderStyle>
													            </asp:ButtonColumn>

																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="���޿�ʼ" SortExpression="���޿�ʼ" HeaderText="���޿�ʼ" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="���޽���" SortExpression="���޽���" HeaderText="���޽���" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="ˮ��ú��" SortExpression="ˮ��ú��" HeaderText="ˮ��ú��" CommandName="Select">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="�绰��" SortExpression="�绰��" HeaderText="�绰��" CommandName="Select">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="�����" SortExpression="�����" HeaderText="�����" CommandName="Select">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="���޷�Ʊ" SortExpression="���޷�Ʊ" HeaderText="���޷�Ʊ" CommandName="Select">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
															</Columns>
															
															<PagerStyle Visible="False" NextPageText="��ҳ" Font-Size="12px" Font-Names="����" PrevPageText="��ҳ" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
														</asp:datagrid><INPUT id="htxtJYXXFixed" type="hidden" value="0" runat="server">
													</DIV>
												</TD>
											</TR>
											<TR id="trRow3">
												<TD class="label">
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZJYXXDeSelectAll" runat="server" Font-Size="12px" Font-Name="����">��ѡ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZJYXXSelectAll" runat="server" Font-Size="12px" Font-Name="����">ȫѡ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZJYXXMoveFirst" runat="server" Font-Size="12px" Font-Name="����">��ǰ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZJYXXMovePrev" runat="server" Font-Size="12px" Font-Name="����">ǰҳ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZJYXXMoveNext" runat="server" Font-Size="12px" Font-Name="����">��ҳ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZJYXXMoveLast" runat="server" Font-Size="12px" Font-Name="����">���</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZJYXXGotoPage" runat="server" Font-Size="12px" Font-Name="����">ǰ��</asp:linkbutton><asp:textbox id="txtJYXXPageIndex" runat="server" Font-Size="12px" Font-Name="����" CssClass="textbox" Columns="3">1</asp:textbox>ҳ</TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZJYXXSetPageSize" runat="server" Font-Size="12px" Font-Name="����">ÿҳ</asp:linkbutton><asp:textbox id="txtJYXXPageSize" runat="server" Font-Size="12px" Font-Name="����" CssClass="textbox" Columns="3">30</asp:textbox>��</TD>
															<TD class="label" vAlign="middle" noWrap align="right"><asp:label id="lblJYXXGridLocInfo" runat="server" Font-Size="12px" Font-Name="����" CssClass="label">1/10 N/15</asp:label></TD>
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
						            <td height="4"></td>
						        </tr>
						        <tr>
						            <td align="center">
							            <asp:Button id="btnOK" Runat="server" Font-Size="12px" Font-Name="����" CssClass="button" Text=" ѡ��ȷ�� " Height="36px"></asp:Button>
							            <asp:Button id="btnNull" Runat="server" Font-Size="12px" Font-Name="����" CssClass="button" Text=" ��ֵȷ�� " Height="36px"></asp:Button>
							            <asp:Button id="btnClose" Runat="server" Font-Size="12px" Font-Name="����" CssClass="button" Text=" ȡ    �� " Height="36px"></asp:Button>
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
						<input id="htxtJYXXQuery" type="hidden" runat="server">
						<input id="htxtJYXXRows" type="hidden" runat="server">
						<input id="htxtJYXXSort" type="hidden" runat="server">
						<input id="htxtJYXXSortColumnIndex" type="hidden" runat="server">
						<input id="htxtJYXXSortType" type="hidden" runat="server">
						<input id="htxtDivLeftJYXX" type="hidden" runat="server">
						<input id="htxtDivTopJYXX" type="hidden" runat="server">
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
							function ScrollProc_divJYXX() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopJYXX");
								if (oText != null) oText.value = divJYXX.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftJYXX");
								if (oText != null) oText.value = divJYXX.scrollLeft;
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
								oText=document.getElementById("htxtDivTopJYXX");
								if (oText != null) divJYXX.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftJYXX");
								if (oText != null) divJYXX.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divJYXX.onscroll = ScrollProc_divJYXX;
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
