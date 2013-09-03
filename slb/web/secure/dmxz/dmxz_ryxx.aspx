<%@ Page Language="vb" AutoEventWireup="false" Codebehind="dmxz_ryxx.aspx.vb" Inherits="Josco.JsKernal.web.dmxz_ryxx" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>��Աѡ����</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles01.css" type="text/css" rel="stylesheet">
		<style>
		    TD.grdRYXXLocked { ; LEFT: expression(divRYXX.scrollLeft); POSITION: relative }
		    TH.grdRYXXLocked { ; LEFT: expression(divRYXX.scrollLeft); POSITION: relative }
		    TH.grdRYXXLocked { Z-INDEX: 99 }
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
				
				if (document.all("divRYXX") == null)
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
                
				divRYXX.style.width  = strWidth;
				divRYXX.style.height = strHeight;
				divRYXX.style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";
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
		<form id="frmdmxz_ryxx" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="5"></TD>
						<TD vAlign="top" align="center">
							<TABLE cellSpacing="0" cellPadding="0" border="0">
								<TR id="trRow1">
									<TD class="title" align="center" colSpan="3" height="30">��Աѡ����<asp:Label ID="lblSelectMode" Runat="server" CssClass="label"></asp:Label><asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton></TD>
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
															<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;��Ա����&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtRYXXSearch_RYDM" runat="server" CssClass="textbox" Columns="8"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;��Ա����&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtRYXXSearch_RYMC" runat="server" CssClass="textbox" Columns="16"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;��λ����&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtRYXXSearch_ZZMC" runat="server" CssClass="textbox" Columns="16"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;����ְ��&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtRYXXSearch_DRZW" runat="server" CssClass="textbox" Columns="16"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;����&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtRYXXSearch_XZJB" runat="server" CssClass="textbox" Columns="12"></asp:textbox></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;��Ч&nbsp;</TD>
															<TD class="label" align="left"><asp:DropDownList id="ddlRYXXSearch_SFYX" runat="server" CssClass="textbox"><asp:ListItem Value=""></asp:ListItem><asp:ListItem Value="0">��Ч</asp:ListItem><asp:ListItem Value="1">��Ч</asp:ListItem></asp:DropDownList></TD>
															<TD class="label">&nbsp;&nbsp;<asp:button id="btnRYXXSearch" Runat="server" CssClass="button" Text="����"></asp:button><asp:button id="btnRYXXSearch_Full" Runat="server" CssClass="button" Text="ȫ��"></asp:button></td>
														</Tr>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD>
													<DIV id="divRYXX" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 964px; CLIP: rect(0px 964px 384px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 384px">
														<asp:datagrid id="grdRYXX" runat="server" Font-Size="12px" CssClass="label" Font-Names="����"
															CellPadding="4" AllowSorting="True" BorderWidth="0px" BorderColor="#DEDFDE" PageSize="30"
															BorderStyle="None" GridLines="Vertical" AutoGenerateColumns="False" AllowPaging="True"
															UseAccessibleHeader="True" Width="1620px">
															<SelectedItemStyle Font-Size="12px" Font-Names="����" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
															<EditItemStyle Font-Size="12px" Font-Names="����" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
															<AlternatingItemStyle Font-Size="12px" Font-Names="����" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
															<ItemStyle Font-Size="12px" Font-Names="����" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
															<HeaderStyle Font-Size="12px" Font-Names="����" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#6699cc" HorizontalAlign="Left"></HeaderStyle>
															<FooterStyle BackColor="#CCCC99"></FooterStyle>
															<Columns>
																<asp:TemplateColumn HeaderText="ѡ">
																	<HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
																	<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																	<ItemTemplate>
																		<asp:CheckBox id="chkRYXX" runat="server" AutoPostBack="False"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:ButtonColumn DataTextField="��Ա����" SortExpression="��Ա����" HeaderText="��ʶ" CommandName="Select">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="��Ա����" SortExpression="��Ա����" HeaderText="����" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="��Ա����" SortExpression="��Ա����" HeaderText="����" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="�Ƿ���Ч" SortExpression="�Ƿ���Ч" HeaderText="��Ч" CommandName="Select">
																	<HeaderStyle Width="60px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="��֯����" SortExpression="��֯����" HeaderText="����" CommandName="Select">
																	<HeaderStyle Width="240px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="��Ա���" SortExpression="��Ա���" HeaderText="���" CommandName="Select">
																	<HeaderStyle Width="60px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="��λ�б�" SortExpression="��λ�б�" HeaderText="ְ��" CommandName="Select">
																	<HeaderStyle Width="180px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn DataTextField="��������" SortExpression="��������" HeaderText="����" CommandName="Select">
																	<HeaderStyle Width="80px"></HeaderStyle>
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
																<asp:ButtonColumn Visible="False" DataTextField="��Ա����" SortExpression="��Ա����" HeaderText="��ʶ" CommandName="Select">
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
															<PagerStyle Visible="False" NextPageText="��ҳ" Font-Size="12px" Font-Names="����" PrevPageText="��ҳ" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
														</asp:datagrid><INPUT id="htxtRYXXFixed" type="hidden" value="0" runat="server">
													</DIV>
												</TD>
											</TR>
											<TR id="trRow3">
												<TD class="label">
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZRYXXDeSelectAll" runat="server" Font-Size="12px" Font-Name="����">��ѡ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZRYXXSelectAll" runat="server" Font-Size="12px" Font-Name="����">ȫѡ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZRYXXMoveFirst" runat="server" Font-Size="12px" Font-Name="����">��ǰ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZRYXXMovePrev" runat="server" Font-Size="12px" Font-Name="����">ǰҳ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZRYXXMoveNext" runat="server" Font-Size="12px" Font-Name="����">��ҳ</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZRYXXMoveLast" runat="server" Font-Size="12px" Font-Name="����">���</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZRYXXGotoPage" runat="server" Font-Size="12px" Font-Name="����">ǰ��</asp:linkbutton><asp:textbox id="txtRYXXPageIndex" runat="server" Font-Size="12px" Font-Name="����" CssClass="textbox" Columns="3">1</asp:textbox>ҳ</TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZRYXXSetPageSize" runat="server" Font-Size="12px" Font-Name="����">ÿҳ</asp:linkbutton><asp:textbox id="txtRYXXPageSize" runat="server" Font-Size="12px" Font-Name="����" CssClass="textbox" Columns="3">30</asp:textbox>��</TD>
															<TD class="label" vAlign="middle" noWrap align="right"><asp:label id="lblRYXXGridLocInfo" runat="server" Font-Size="12px" Font-Name="����" CssClass="label">1/10 N/15</asp:label></TD>
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
							            <asp:Button id="btnOK" Runat="server" Font-Size="12px" Font-Name="����" CssClass="button" Text=" ѡ��ȷ�� " Height="36px"></asp:Button>&nbsp;&nbsp;
							            <asp:Button id="btnNull" Runat="server" Font-Size="12px" Font-Name="����" CssClass="button" Text=" ��ֵȷ�� " Height="36px"></asp:Button>&nbsp;&nbsp;
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
						<input id="htxtSessionIdQuery" type="hidden" runat="server">
						<input id="htxtRYXXQuery" type="hidden" runat="server">
						<input id="htxtRYXXRows" type="hidden" runat="server">
						<input id="htxtRYXXSort" type="hidden" runat="server">
						<input id="htxtRYXXSortColumnIndex" type="hidden" runat="server">
						<input id="htxtRYXXSortType" type="hidden" runat="server">
						<input id="htxtDivLeftRYXX" type="hidden" runat="server">
						<input id="htxtDivTopRYXX" type="hidden" runat="server">
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
							function ScrollProc_divRYXX() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopRYXX");
								if (oText != null) oText.value = divRYXX.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftRYXX");
								if (oText != null) oText.value = divRYXX.scrollLeft;
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
								oText=document.getElementById("htxtDivTopRYXX");
								if (oText != null) divRYXX.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftRYXX");
								if (oText != null) divRYXX.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divRYXX.onscroll = ScrollProc_divRYXX;
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
