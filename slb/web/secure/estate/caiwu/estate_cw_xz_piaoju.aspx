<%@ Page Language="vb" AutoEventWireup="false" Codebehind="estate_cw_xz_piaoju.aspx.vb" Inherits="Josco.JSOA.web.estate_cw_xz_piaoju" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>ѡ��Ʊ��</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../styles01.css" type="text/css" rel="stylesheet">
		<style>
		    TD.grdPIAOJULocked { ; LEFT: expression(divPIAOJU.scrollLeft); POSITION: relative }
		    TH.grdPIAOJULocked { ; LEFT: expression(divPIAOJU.scrollLeft); POSITION: relative }
		    TH.grdPIAOJULocked { Z-INDEX: 99 }
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
				
				if (document.all("divPIAOJU") == null)
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
                
				divPIAOJU.style.width  = strWidth;
				divPIAOJU.style.height = strHeight;
				divPIAOJU.style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";
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
		<form id="frmestate_cw_xz_piaoju" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="5"></TD>
						<TD vAlign="top" align="center">
							<TABLE cellSpacing="0" cellPadding="0" border="0">
								<TR id="trRow1">
									<TD class="title" align="center" colSpan="3" height="30">ѡ��Ʊ��<asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton></TD>
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
															<TD class="label" vAlign="middle" align="right">&nbsp;��Ʊ����&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtPIAOJUSearch_KPRQMin" runat="server" Font-Size="12px" CssClass="textbox" Columns="9" Font-Names="����"></asp:textbox>~<asp:textbox id="txtPIAOJUSearch_KPRQMax" runat="server" Font-Size="12px" CssClass="textbox" Columns="9" Font-Names="����"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;Ʊ��״̬&nbsp;</TD>
															<TD class="label" align="left">
																<asp:DropDownList id="ddlPIAOJUSearch_ZTBZ" runat="server" Font-Size="12px" CssClass="textbox" Font-Names="����" Enabled="False">
																	<asp:ListItem Value=""></asp:ListItem>
																	<asp:ListItem Value="0">δʹ��</asp:ListItem>
																	<asp:ListItem Value="1" Selected="True">��ʹ��</asp:ListItem>
																	<asp:ListItem Value="2">������</asp:ListItem>
																	<asp:ListItem Value="4">���ջ�</asp:ListItem>
																</asp:DropDownList>
															</TD>
															<!-- zengxianglin 2008-11-22-->
															<TD class="label" vAlign="middle" align="right">&nbsp;�ѿ�ƾ֤&nbsp;</TD>
															<TD class="label" align="left">
																<asp:DropDownList id="ddlPIAOJUSearch_YKPZ" runat="server" Font-Size="12px" CssClass="textbox" Font-Names="����">
																	<asp:ListItem Value=""></asp:ListItem>
																	<asp:ListItem Value="0" Selected="True">δ��ƾ֤</asp:ListItem>
																	<asp:ListItem Value="1">�ѿ�ƾ֤</asp:ListItem>
																</asp:DropDownList>
															</TD>
															<!-- zengxianglin 2008-11-22-->
															<TD class="label" vAlign="middle" align="right">&nbsp;ҵ����&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtPIAOJUSearch_YWBH" runat="server" Font-Size="12px" CssClass="textbox" Font-Names="����" Columns="16"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;��Ʊ��Ա&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtPIAOJUSearch_JBRY" runat="server" Font-Size="12px" CssClass="textbox" Font-Names="����" Columns="6"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;Ʊ�ݺ���&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtPIAOJUSearch_PJHM" runat="server" Font-Size="12px" CssClass="textbox" Font-Names="����" Columns="12"></asp:textbox></TD>
															<TD class="label">&nbsp;<asp:button id="btnPIAOJUSearch" Runat="server" Font-Size="12px" Font-Name="����" CssClass="button" Text="����"></asp:button><asp:button id="btnPIAOJUSearch_Full" Runat="server" Font-Size="12px" Font-Name="����" CssClass="button" Text="ȫ��"></asp:button></td>
														</Tr>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD>
													<DIV id="divPIAOJU" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 964px; CLIP: rect(0px 964px 364px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 364px">
														<asp:datagrid id="grdPIAOJU" runat="server" Font-Size="12px" CssClass="label" Font-Names="����"
															CellPadding="4" AllowSorting="True" BorderWidth="0px" BorderColor="#DEDFDE" PageSize="30"
															BorderStyle="None" BackColor="White" GridLines="Vertical" AutoGenerateColumns="False" AllowPaging="True"
															UseAccessibleHeader="True" Width="1960px">
															<SelectedItemStyle Font-Size="12px" Font-Names="����" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
															<EditItemStyle Font-Size="12px" Font-Names="����" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
															<AlternatingItemStyle Font-Size="12px" Font-Names="����" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
															<ItemStyle Font-Size="12px" Font-Names="����" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
															<HeaderStyle Font-Size="12px" Font-Names="����" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#6699cc" HorizontalAlign="Left"></HeaderStyle>
															<FooterStyle BackColor="#CCCC99"></FooterStyle>
															
															<Columns>
																<asp:TemplateColumn HeaderText="ѡ" Visible="False" ItemStyle-Width="20px">
																	<HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
																	<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																	<ItemTemplate>
																		<asp:CheckBox id="chkPIAOJU" runat="server" AutoPostBack="False" Visible="False"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="Ψһ��ʶ" SortExpression="Ψһ��ʶ" HeaderText="Ψһ��ʶ" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="��������" SortExpression="��������" HeaderText="����������" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn  ItemStyle-Width="180px" DataTextField="������������" SortExpression="������������" HeaderText="����" CommandName="Select">
																	<HeaderStyle Width="180px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn  ItemStyle-Width="60px" DataTextField="Ʊ������" SortExpression="Ʊ������" HeaderText="����" CommandName="Select">
																	<HeaderStyle Width="60px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn  ItemStyle-Width="100px" DataTextField="Ʊ�ݺ���" SortExpression="Ʊ�ݺ���" HeaderText="Ʊ�ݺ�" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn  ItemStyle-Width="80px" DataTextField="Ʊ������" SortExpression="Ʊ������" HeaderText="����" CommandName="Select">
																	<HeaderStyle Width="80px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="������Ա" SortExpression="������Ա" HeaderText="������Ա��" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="������Ա����" SortExpression="������Ա����" HeaderText="������Ա" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="��������" SortExpression="��������" HeaderText="��������" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="״̬��־" SortExpression="״̬��־" HeaderText="״̬��־" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn  ItemStyle-Width="80px" DataTextField="״̬��־����" SortExpression="״̬��־����" HeaderText="״̬" CommandName="Select">
																	<HeaderStyle Width="80px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn  ItemStyle-Width="120px" DataTextField="��Ʊ���" SortExpression="��Ʊ���" HeaderText="��Ʊ���" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="120px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn  ItemStyle-Width="140px" DataTextField="��Ʊ����" SortExpression="��Ʊ����" HeaderText="��Ʊ����" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn  ItemStyle-Width="140px" DataTextField="���ױ��" SortExpression="���ױ��" HeaderText="ҵ����" CommandName="Select">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="˰�Ѵ���" SortExpression="˰�Ѵ���" HeaderText="˰�Ѵ���" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="˰������" SortExpression="˰������" HeaderText="˰������" CommandName="Select">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="�ո���־" SortExpression="�ո���־" HeaderText="�ո���־" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="�ո�����" SortExpression="�ո�����" HeaderText="�ո�����" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" DataTextField="������Ա" SortExpression="������Ա" HeaderText="������Ա��" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn  ItemStyle-Width="100px" DataTextField="������Ա����" SortExpression="������Ա����" HeaderText="��Ʊ��Ա" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn  ItemStyle-Width="160px" DataTextField="ժҪ˵��" SortExpression="ժҪ˵��" HeaderText="ժҪ" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�����Ա" SortExpression="�����Ա" HeaderText="�����Ա��" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="�����Ա����" SortExpression="�����Ա����" HeaderText="�����Ա" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="�������" SortExpression="�������" HeaderText="�������" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																																
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="������Ա" SortExpression="������Ա" HeaderText="������Ա��" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn  ItemStyle-Width="100px" DataTextField="������Ա����" SortExpression="������Ա����" HeaderText="������Ա" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn  ItemStyle-Width="140px" DataTextField="��������" SortExpression="��������" HeaderText="��������" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="ΨһƱ�ݺ���" SortExpression="ΨһƱ�ݺ���" HeaderText="ΨһƱ�ݺ���" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="ҵ���ʶ" SortExpression="ҵ���ʶ" HeaderText="ҵ���ʶ" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
															</Columns>
															
															<PagerStyle Visible="False" NextPageText="��ҳ" Font-Size="12px" Font-Names="����" PrevPageText="��ҳ" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
														</asp:datagrid><INPUT id="htxtPIAOJUFixed" type="hidden" value="0" runat="server" NAME="htxtPIAOJUFixed">
													</DIV>
												</TD>
											</TR>
											<TR id="trRow3">
												<TD class="label">
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZPIAOJUDeSelectAll" runat="server" Font-Size="12px" Font-Name="����">��ѡ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZPIAOJUSelectAll" runat="server" Font-Size="12px" Font-Name="����">ȫѡ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZPIAOJUMoveFirst" runat="server" Font-Size="12px" Font-Name="����">��ǰ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZPIAOJUMovePrev" runat="server" Font-Size="12px" Font-Name="����">ǰҳ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZPIAOJUMoveNext" runat="server" Font-Size="12px" Font-Name="����">��ҳ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZPIAOJUMoveLast" runat="server" Font-Size="12px" Font-Name="����">���</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZPIAOJUGotoPage" runat="server" Font-Size="12px" Font-Name="����">ǰ��</asp:linkbutton><asp:textbox id="txtPIAOJUPageIndex" runat="server" Font-Size="12px" Font-Name="����" CssClass="textbox" Columns="3">1</asp:textbox>ҳ</TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZPIAOJUSetPageSize" runat="server" Font-Size="12px" Font-Name="����">ÿҳ</asp:linkbutton><asp:textbox id="txtPIAOJUPageSize" runat="server" Font-Size="12px" Font-Name="����" CssClass="textbox" Columns="3">30</asp:textbox>��</TD>
															<TD class="label" vAlign="middle" noWrap align="right"><asp:label id="lblPIAOJUGridLocInfo" runat="server" Font-Size="12px" Font-Name="����" CssClass="label">1/10 N/15</asp:label></TD>
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
							            <asp:Button id="btnNull" Runat="server" Font-Size="12px" Font-Name="����" CssClass="button" Text=" ��ֵѡ�� " Height="36px"></asp:Button>
							            <asp:Button id="btnOK" Runat="server" Font-Size="12px" Font-Name="����" CssClass="button" Text=" ѡ��ȷ�� " Height="36px"></asp:Button>
							            <asp:Button id="btnClose" Runat="server" Font-Size="12px" Font-Name="����" CssClass="button" Text=" ֱ�ӷ��� " Height="36px"></asp:Button>
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
						<input id="htxtSessionIdQuery" type="hidden" runat="server" NAME="htxtSessionIdQuery">
						<input id="htxtPIAOJUQuery" type="hidden" runat="server" NAME="htxtPIAOJUQuery">
						<input id="htxtPIAOJURows" type="hidden" runat="server" NAME="htxtPIAOJURows">
						<input id="htxtPIAOJUSort" type="hidden" runat="server" NAME="htxtPIAOJUSort">
						<input id="htxtPIAOJUSortColumnIndex" type="hidden" runat="server" NAME="htxtPIAOJUSortColumnIndex">
						<input id="htxtPIAOJUSortType" type="hidden" runat="server" NAME="htxtPIAOJUSortType">
						<input id="htxtDivLeftPIAOJU" type="hidden" runat="server" NAME="htxtDivLeftPIAOJU">
						<input id="htxtDivTopPIAOJU" type="hidden" runat="server" NAME="htxtDivTopPIAOJU">
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
							function ScrollProc_divPIAOJU() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopPIAOJU");
								if (oText != null) oText.value = divPIAOJU.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftPIAOJU");
								if (oText != null) oText.value = divPIAOJU.scrollLeft;
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
								oText=document.getElementById("htxtDivTopPIAOJU");
								if (oText != null) divPIAOJU.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftPIAOJU");
								if (oText != null) divPIAOJU.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divPIAOJU.onscroll = ScrollProc_divPIAOJU;
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
