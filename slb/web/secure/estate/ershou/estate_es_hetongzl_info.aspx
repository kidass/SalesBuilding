<%@ Page Language="vb" AutoEventWireup="false" Codebehind="estate_es_hetongzl_info.aspx.vb" Inherits="Josco.JSOA.web.estate_es_hetongzl_info" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>���޺�ͬ�鿴��༭</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../styles01.css" type="text/css" rel="stylesheet">
		<style>
			TD.grdWYXXLocked { ; LEFT: expression(divWYXX.scrollLeft); POSITION: relative }
			TH.grdWYXXLocked { ; LEFT: expression(divWYXX.scrollLeft); POSITION: relative }
			TH.grdWYXXLocked { Z-INDEX: 99 }
			TD.grdYWRYLocked { ; LEFT: expression(divYWRY.scrollLeft); POSITION: relative }
			TH.grdYWRYLocked { ; LEFT: expression(divYWRY.scrollLeft); POSITION: relative }
			TH.grdYWRYLocked { Z-INDEX: 99 }
			TD.grdZLQXLocked { ; LEFT: expression(divZLQX.scrollLeft); POSITION: relative }
			TH.grdZLQXLocked { ; LEFT: expression(divZLQX.scrollLeft); POSITION: relative }
			TH.grdZLQXLocked { Z-INDEX: 99 }
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
				
				if (document.all("divMain") == null)
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
				strHeight  = intHeight.toString() + "px";

				divMain.style.width  = strWidth;
				divMain.style.height = strHeight;
				divMain.style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";
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
		<form id="frmestate_es_hetongzl_info" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
					<TR id="trRow1">
						<TD align="center">
							<TABLE cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
								<TR>
									<TD class="title" align="center">���ز����޺�ͬ<asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton></TD>
									<TD width="20">&nbsp;</TD>
								</TR>
								<TR>
									<TD vAlign="middle" align="right"><span class="labelAuto">��ͬ��ţ�</span><asp:TextBox id="txtHTBH" runat="server" CssClass="textbox" Columns="14"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;��Դ��ţ�<asp:TextBox id="txtKYBH" runat="server" Columns="24" CssClass="textbox"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<span class="labelNotNull">ǩ�����ڣ�</span><asp:TextBox id="txtHTRQ" runat="server" CssClass="textbox" Columns="8"></asp:TextBox>&nbsp;&nbsp;<span class="labelAuto">ǩԼͳ�����ڣ�</span><asp:TextBox id="txtTJRQ" runat="server" CssClass="textbox" Columns="8"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="chkHTJC" runat="server"  CssClass="labelAuto" Text="��ͬ���"/><asp:CheckBox ID="chkHTHZ" runat="server"  CssClass="labelAuto" Text="���ڻ���"/><INPUT id="htxtHTWYBS" type="hidden" size="1" runat="server"><INPUT id="htxtHTZT" type="hidden" size="1" runat="server"><INPUT id="htxtWYBS" type="hidden" size="1" runat="server"><INPUT id="htxtQRSH" type="hidden" size="1" runat="server"><INPUT id="htxtDGRQ" type="hidden" size="1" runat="server"><INPUT id="htxtHTBZ" type="hidden" size="1" runat="server"></TD>
									<TD width="20">&nbsp;</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD align="center">
							<DIV id="divMain" style="BORDER-TOP: #99cccc 2px solid; OVERFLOW: auto; WIDTH: 964px; CLIP: rect(0px 964px 447px 0px); BORDER-BOTTOM: #99cccc 2px solid; HEIGHT: 447px">
								<TABLE>
                                    <TR>
                                        <TD class="label" align="left" bgColor="#ccff99"><B>&gt;&gt;&gt;&gt;��������</B></TD>
                                    </TR>
                                    <tr>
                                        <td>
                                            <table cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                 <tr>
                                                    <td align="left"><span class="labelNotNull">����ַ��</span><asp:TextBox id="txtCCDZ" runat="server" Columns="60" CssClass="textbox"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<span class="labelNotNull">���ѣ�</span><asp:TextBox id="txtCCF" runat="server" Columns="14" CssClass="textbox"></asp:TextBox></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <TR>
                                        <TD class="label" align="left" bgColor="#ccff99"><B>&gt;&gt;&gt;&gt;Ӷ������(RMB)</B></TD>
                                    </TR>
                                    <tr>
                                        <td>
                                            <table cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                <tr>
                                                    <td align="left"><span class="labelAuto">�����</span><asp:TextBox id="txtJYYZJ" runat="server" Columns="16" CssClass="textbox"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<span class="labelNotNull">ҵ��Ӷ��</span><asp:TextBox id="txtJFDLF" runat="server" Columns="16" CssClass="textbox"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<span class="labelNotNull">�ͻ�Ӷ��</span><asp:TextBox id="txtYFDLF" runat="server" Columns="16" CssClass="textbox"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="left"><span class="labelAuto">����ܶ</span><asp:TextBox id="txtJYZZJ" runat="server" Columns="16" CssClass="textbox"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<span class="labelNotNull">��ҵʵ�գ�</span><asp:TextBox id="txtSSYJ" runat="server" Columns="16" CssClass="textbox"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<span class="labelNotNull">����Ӷ��</span><asp:TextBox id="txtHZYJ" runat="server" Columns="16" CssClass="textbox"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="left"><span class="labelAuto">���ҷ�����</span><asp:TextBox id="txtAJFH" runat="server" CssClass="textbox" Columns="16"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;�����ۿۣ�<asp:TextBox id="txtDLFZK" runat="server" CssClass="textbox" Columns="16"></asp:TextBox>% (100%��ʾû���ۿ�)</td>
                                                </tr>
                                                <tr>
                                                    <td align="left"><span class="labelAuto">���˽�</span><asp:TextBox id="txtHZJE" runat="server" Columns="16" CssClass="textbox"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<span class="labelAuto">������ڣ�</span><asp:TextBox id="txtJCRQ" runat="server" Columns="16" CssClass="textbox"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<span class="labelAuto">�������ڣ�</span><asp:TextBox id="txtHZRQ" runat="server" Columns="16" CssClass="textbox"></asp:TextBox></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <TR>
                                        <TD class="label" align="left" bgColor="#ccff99"><B>&gt;&gt;&gt;&gt;��ҵ¥��</B></TD>
                                    </TR>
									<TR>
										<TD>
											<TABLE cellSpacing="0" cellPadding="0" border="0">
												<TR>
													<TD>
														<DIV id="divWYXX" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 900px; CLIP: rect(0px 900px 260px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 260px">
															<asp:datagrid id="grdWYXX" runat="server" Width="4160px" CssClass="label" CellPadding="4" AllowSorting="False"
																BorderWidth="0px" BorderColor="#DEDFDE" PageSize="30" BorderStyle="None" BackColor="White"
																GridLines="Vertical" AutoGenerateColumns="False" AllowPaging="False" UseAccessibleHeader="True">
																<FooterStyle BackColor="#CCCC99"></FooterStyle>
																<SelectedItemStyle ForeColor="#CC0000" VerticalAlign="Middle" BackColor="#FFFFDD"></SelectedItemStyle>
																<EditItemStyle VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
																<AlternatingItemStyle BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
																<ItemStyle BorderWidth="0px" ForeColor="Black" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7"></ItemStyle>
																<HeaderStyle Font-Bold="True" HorizontalAlign="Left" ForeColor="White" VerticalAlign="Middle" BackColor="#6699cc"></HeaderStyle>
																
																<Columns>
																	<asp:TemplateColumn HeaderText="ѡ" ItemStyle-Width="20px">
																		<HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
																		<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																		<ItemTemplate>
																			<asp:CheckBox id="chkWYXX" runat="server" AutoPostBack="False"></asp:CheckBox>
																		</ItemTemplate>
																	</asp:TemplateColumn>
																	
                                                                    <asp:ButtonColumn ItemStyle-Width="700px" DataTextField="��ҵ��Ϣ" SortExpression="��ҵ��Ϣ" HeaderText="��ҵ��Ϣ" CommandName="OpenDocument">
                                                                        <HeaderStyle Width="700px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
																	
																	<asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="Ψһ��ʶ" SortExpression="Ψһ��ʶ" HeaderText="Ψһ��ʶ" CommandName="Select">
																		<HeaderStyle Width="0px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="ȷ�����" SortExpression="ȷ�����" HeaderText="ȷ�����" CommandName="Select">
																		<HeaderStyle Width="0px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="��ҵ����" SortExpression="��ҵ����" HeaderText="��ҵ����" CommandName="Select">
																		<HeaderStyle Width="0px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn ItemStyle-Width="240px" DataTextField="���ݵ�ַ" SortExpression="���ݵ�ַ" HeaderText="���ݵ�ַ" CommandName="OpenDocument">
																		<HeaderStyle Width="240px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="����֤��" SortExpression="����֤��" HeaderText="����֤��" CommandName="OpenDocument">
																		<HeaderStyle Width="160px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="����֤��ַ" SortExpression="����֤��ַ" HeaderText="����֤��ַ" CommandName="Select">
																		<HeaderStyle Width="0px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="�����" SortExpression="�����" HeaderText="�����" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																		<HeaderStyle Width="120px" HorizontalAlign="Right"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="���" SortExpression="���" HeaderText="���" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																		<HeaderStyle Width="120px" HorizontalAlign="Right"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="����" SortExpression="����" HeaderText="����" CommandName="Select">
																		<HeaderStyle Width="100px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="¥��" SortExpression="¥��" HeaderText="¥��" CommandName="Select">
																		<HeaderStyle Width="100px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="¥��" SortExpression="¥��" HeaderText="¥��" CommandName="Select">
																		<HeaderStyle Width="100px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="���" SortExpression="���" HeaderText="�����" CommandName="Select">
																		<HeaderStyle Width="0px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="�������" SortExpression="�������" HeaderText="����" CommandName="Select">
																		<HeaderStyle Width="100px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="��ҵ����" SortExpression="��ҵ����" HeaderText="��ҵ������" CommandName="Select">
																		<HeaderStyle Width="0px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="��ҵ��������" SortExpression="��ҵ��������" HeaderText="��ҵ����" CommandName="Select">
																		<HeaderStyle Width="140px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="��������" SortExpression="��������" HeaderText="����������" CommandName="Select">
																		<HeaderStyle Width="0px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="������������" SortExpression="������������" HeaderText="��������" CommandName="Select">
																		<HeaderStyle Width="100px"></HeaderStyle>
																	</asp:ButtonColumn>
																	
                                                                    <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="��Դ���" SortExpression="��Դ���" HeaderText="��Դ���" CommandName="Select">
                                                                        <HeaderStyle Width="160px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="¥��" SortExpression="¥��" HeaderText="¥��" CommandName="Select">
                                                                        <HeaderStyle Width="160px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="¥��" SortExpression="¥��" HeaderText="¥��" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="��Ԫ" SortExpression="��Ԫ" HeaderText="��Ԫ" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="140px" DataTextField="����ʱ��" SortExpression="����ʱ��" HeaderText="����ʱ��" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
                                                                        <HeaderStyle Width="140px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="�ռ�����" SortExpression="�ռ�����" HeaderText="�ռ�����" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="��������" SortExpression="��������" HeaderText="��������" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="װ�޵���" SortExpression="װ�޵���" HeaderText="װ�޵���" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="װ������" SortExpression="װ������" HeaderText="װ������" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="����Ӱ��" SortExpression="����Ӱ��" HeaderText="����Ӱ��" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="�Ҿ��豸" SortExpression="�Ҿ��豸" HeaderText="�Ҿ��豸" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="¥�ͨ" SortExpression="¥�ͨ" HeaderText="¥�ͨ" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="���ݼ��" SortExpression="���ݼ��" HeaderText="���ݼ��" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="��������" SortExpression="��������" HeaderText="���ݾ���" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="���۷���" SortExpression="���۷���" HeaderText="���۷���" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="¥��" SortExpression="¥��" HeaderText="¥��" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="��������" SortExpression="��������" HeaderText="��������" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="��̨����" SortExpression="��̨����" HeaderText="��̨����" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="0px" Visible="false" DataTextField="��԰���" SortExpression="��԰���" HeaderText="��԰���" CommandName="Select" DataTextFormatString="{0:0.00}">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="��������" SortExpression="��������" HeaderText="��������" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="¥�㻧��" SortExpression="¥�㻧��" HeaderText="¥�㻧��" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="¥������" SortExpression="¥������" HeaderText="¥������" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
																	
																	<asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="��ע��Ϣ" SortExpression="��ע��Ϣ" HeaderText="��ע��Ϣ" CommandName="Select">
																		<HeaderStyle Width="0px"></HeaderStyle>
																	</asp:ButtonColumn>
																</Columns>
																
																<PagerStyle Visible="False" NextPageText="��ҳ" PrevPageText="��ҳ" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
															</asp:datagrid><INPUT id="htxtWYXXFixed" type="hidden" value="0" runat="server">
														</DIV>
													</TD>
												</TR>
												<TR>
													<TD align="right"><asp:Button id="btnAddNew_WYXX" Runat="server" CssClass="button" Text=" �����µ���ҵ "></asp:Button><asp:Button id="btnUpdate_WYXX" Runat="server" CssClass="button" Text=" ������ҵ���� "></asp:Button><asp:Button id="btnDelete_WYXX" Runat="server" CssClass="button" Text=" ɾ��������ҵ "></asp:Button></TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
                                    <TR>
                                        <TD class="label" align="left" bgColor="#ccff99"><B>&gt;&gt;&gt;&gt;��������</B></TD>
                                    </TR>
									<TR>
										<TD>
                                            <TABLE cellSpacing="0" cellPadding="2" width="100%" border="0">
                                                <tr>
                                                    <td align="left" class="labelNotNull">���ڣ���<asp:TextBox id="txtZLKS" runat="server" Columns="12" CssClass="textbox"></asp:TextBox>��<asp:TextBox id="txtZLJS" runat="server" Columns="12" CssClass="textbox"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="left"><span style="width:96px">ˮ���硢ú����</span>
                                                        <asp:RadioButtonList id="rblSDMQ" Runat="server" CssClass="textbox" RepeatLayout="Flow" RepeatDirection="Vertical" RepeatColumns="2">
                                                            <asp:ListItem Value="����">����</asp:ListItem>
                                                            <asp:ListItem Value="������">������</asp:ListItem>
                                                        </asp:RadioButtonList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="width:84px">�绰�ѣ�</span>
                                                        <asp:RadioButtonList id="rblDHF" Runat="server" CssClass="textbox" RepeatLayout="Flow" RepeatDirection="Vertical" RepeatColumns="2">
                                                            <asp:ListItem Value="����">����</asp:ListItem>
                                                            <asp:ListItem Value="������">������</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left"><span style="width:96px">����ѣ�</span>
                                                        <asp:RadioButtonList id="rblGLF" Runat="server" CssClass="textbox" RepeatLayout="Flow" RepeatDirection="Vertical" RepeatColumns="2">
                                                            <asp:ListItem Value="����">����</asp:ListItem>
                                                            <asp:ListItem Value="������">������</asp:ListItem>
                                                        </asp:RadioButtonList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="width:84px">���޷�Ʊ��</span>
                                                        <asp:RadioButtonList id="rblZLFP" Runat="server" CssClass="textbox" RepeatLayout="Flow" RepeatDirection="Vertical" RepeatColumns="2">
                                                            <asp:ListItem Value="����">����</asp:ListItem>
                                                            <asp:ListItem Value="������">������</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left"><span class="labelNotNull">ҵ�����ƣ�</span><asp:TextBox id="txtJFMC" runat="server" CssClass="textbox" Columns="40"></asp:TextBox>&nbsp;&nbsp;�����ˣ�<asp:TextBox id="txtJFDLR" runat="server" Columns="24" CssClass="textbox"></asp:TextBox><span class="labelNotNull">&nbsp;&nbsp;֤�����룺</span><asp:DropDownList id="ddlJFZJLB" runat="server" CssClass="textbox" Width="100px">
                                                            <asp:ListItem Value="0">���֤</asp:ListItem>
                                                            <asp:ListItem Value="1">����</asp:ListItem>
                                                            <asp:ListItem Value="2">Ӫҵִ��</asp:ListItem>
                                                        </asp:DropDownList>&nbsp;&nbsp;<asp:TextBox id="txtJFZZHM" Runat="server" CssClass="textbox" Columns="36"></asp:TextBox>
                                                    </td>
                                                </TR>
                                                <tr>
                                                    <td align="left"><span class="label">ʣ����ҵ��</span>
                                                        <asp:RadioButtonList id="rblSYWY" Runat="server" CssClass="textbox" RepeatLayout="Flow" RepeatDirection="Vertical" RepeatColumns="3">
                                                            <asp:ListItem Value="1��">1��</asp:ListItem>
                                                            <asp:ListItem Value="2-3��">2-3��</asp:ListItem>
                                                            <asp:ListItem Value="4������">4������</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </TR>
                                                <tr>
                                                    <td align="left"><span class="labelNotNull">ҵ���绰��</span><asp:TextBox id="txtJFLXDH" Runat="server" CssClass="textbox" Columns="48"></asp:TextBox><span class="labelNotNull">&nbsp;&nbsp;������</span><asp:RadioButtonList ID="rblYZQC" runat="server" CssClass="textbox" RepeatColumns="2" RepeatLayout="Flow" RepeatDirection="Vertical">
                                                            <asp:ListItem Value="��½">��½</asp:ListItem>
                                                            <asp:ListItem Value="�������������">�������������</asp:ListItem>
                                                        </asp:RadioButtonList>&nbsp;&nbsp;<asp:TextBox id="txtYZQN" runat="server" CssClass="textbox" Columns="40"></asp:TextBox>
                                                    </td>
                                                </TR>
                                                <tr>
                                                    <td align="left"><span class="labelNotNull">ҵ����Դ��</span>
                                                        <asp:RadioButtonList id="rblYZLY" Runat="server" CssClass="textbox" RepeatLayout="Flow" RepeatDirection="Vertical" RepeatColumns="11">
                                                            <asp:ListItem Value="Call in">Call in</asp:ListItem>
                                                            <asp:ListItem Value="Walk in">Walk in</asp:ListItem>
                                                            <asp:ListItem Value="Cold Call">Cold Call</asp:ListItem>
                                                            <asp:ListItem Value="ת��">ת��</asp:ListItem>
                                                            <asp:ListItem Value="�ɿ�">�ɿ�</asp:ListItem>
                                                            <asp:ListItem Value="�����ձ�">�����ձ�</asp:ListItem>
                                                            <asp:ListItem Value="�ѷ�">�ѷ�</asp:ListItem>
                                                            <asp:ListItem Value="���ӿ�">���ӿ�</asp:ListItem>
                                                            <asp:ListItem Value="����">����</asp:ListItem>
                                                            <asp:ListItem Value="����">����</asp:ListItem>
                                                            <asp:ListItem Value="����">����</asp:ListItem>
                                                        </asp:RadioButtonList>&nbsp;&nbsp;<asp:TextBox id="txtYYQT" runat="server" CssClass="textbox" Columns="20"></asp:TextBox>
                                                    </td>
                                                </TR>
                                                <tr>
                                                    <td align="left">ҵ����ַ��<asp:TextBox id="txtJFLXDZ" Runat="server" CssClass="textbox" Columns="70"></asp:TextBox></td>
                                                </TR>
                                                <tr>
                                                    <td align="left">ҵ�����ʣ�<asp:TextBox id="txtYZDY" Runat="server" CssClass="textbox" Columns="70"></asp:TextBox></td>
                                                </TR>
                                                <tr>
                                                    <td align="left"><span class="labelNotNull">������ƣ�</span><asp:TextBox id="txtYFMC" runat="server" CssClass="textbox" Columns="40"></asp:TextBox>&nbsp;&nbsp;�����ˣ�<asp:TextBox id="txtYFDLR" runat="server" CssClass="textbox" Columns="24"></asp:TextBox><span class="labelNotNull">&nbsp;&nbsp;֤�����룺</span><asp:DropDownList id="ddlYFZJLB" runat="server" CssClass="textbox" Width="100px">
                                                            <asp:ListItem Value="0">���֤</asp:ListItem>
                                                            <asp:ListItem Value="1">����</asp:ListItem>
                                                            <asp:ListItem Value="2">Ӫҵִ��</asp:ListItem>
                                                        </asp:DropDownList>&nbsp;&nbsp;<asp:TextBox id="txtYFZZHM" Runat="server" CssClass="textbox" Columns="36"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left"><span class="labelNotNull">��͵绰��</span><asp:TextBox id="txtYFLXDH" Runat="server" CssClass="textbox" Columns="48"></asp:TextBox><span class="labelNotNull">&nbsp;&nbsp;������</span><asp:RadioButtonList ID="rblMJQC" runat="server" CssClass="textbox" RepeatColumns="2" RepeatLayout="Flow" RepeatDirection="Vertical">
                                                            <asp:ListItem Value="��½">��½</asp:ListItem>
                                                            <asp:ListItem Value="�������������">�������������</asp:ListItem>
                                                        </asp:RadioButtonList>&nbsp;&nbsp;<asp:TextBox id="txtMJQN" runat="server" CssClass="textbox" Columns="40"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left"><span class="labelNotNull">�����Դ��</span>
                                                        <asp:RadioButtonList id="rblKHLY" Runat="server" CssClass="textbox" RepeatLayout="Flow" RepeatDirection="Vertical" RepeatColumns="11">
                                                            <asp:ListItem Value="Call in">Call in</asp:ListItem>
                                                            <asp:ListItem Value="Walk in">Walk in</asp:ListItem>
                                                            <asp:ListItem Value="Cold Call">Cold Call</asp:ListItem>
                                                            <asp:ListItem Value="ת��">ת��</asp:ListItem>
                                                            <asp:ListItem Value="�ɿ�">�ɿ�</asp:ListItem>
                                                            <asp:ListItem Value="�����ձ�">�����ձ�</asp:ListItem>
                                                            <asp:ListItem Value="�ѷ�">�ѷ�</asp:ListItem>
                                                            <asp:ListItem Value="���ӿ�">���ӿ�</asp:ListItem>
                                                            <asp:ListItem Value="����">����</asp:ListItem>
                                                            <asp:ListItem Value="����">����</asp:ListItem>
                                                            <asp:ListItem Value="����">����</asp:ListItem>
                                                        </asp:RadioButtonList>&nbsp;&nbsp;<asp:TextBox id="txtKYQT" runat="server" CssClass="textbox" Columns="20"></asp:TextBox>
                                                    </td>
                                                </TR>
                                                <tr>
                                                    <td align="left">��͵�ַ��<asp:TextBox id="txtYFLXDZ" Runat="server" CssClass="textbox" Columns="70"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="left">��͵��ʣ�<asp:TextBox id="txtKHDY" Runat="server" CssClass="textbox" Columns="70"></asp:TextBox></td>
                                                </tr>
                                            </TABLE>
										</TD>
									</TR>
									<TR>
										<TD class="label" align="left" bgColor="#ccff99"><B>&gt;&gt;&gt;&gt;��������</B></TD>
									</TR>
									<TR>
										<TD>
											<TABLE cellSpacing="0" cellPadding="0" border="0">
												<TR>
													<TD>
														<DIV id="divZLQX" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 900px; CLIP: rect(0px 900px 140px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 140px">
															<asp:datagrid id="grdZLQX" runat="server" CssClass="label" CellPadding="4" AllowSorting="False"
																BorderWidth="0px" BorderColor="#DEDFDE" PageSize="30" BorderStyle="None" BackColor="White"
																GridLines="Vertical" AutoGenerateColumns="False" AllowPaging="False" UseAccessibleHeader="True">
																<FooterStyle BackColor="#CCCC99"></FooterStyle>
																<SelectedItemStyle ForeColor="#CC0000" VerticalAlign="Middle" BackColor="#FFFFDD"></SelectedItemStyle>
																<EditItemStyle VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
																<AlternatingItemStyle BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
																<ItemStyle BorderWidth="0px" ForeColor="Black" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7"></ItemStyle>
																<HeaderStyle Font-Bold="True" HorizontalAlign="Left" ForeColor="White" VerticalAlign="Middle" BackColor="#6699cc"></HeaderStyle>
																
																<Columns>
																	<asp:TemplateColumn HeaderText="ѡ" ItemStyle-Width="20px">
																		<HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
																		<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																		<ItemTemplate>
																			<asp:CheckBox id="chkZLQX" runat="server" AutoPostBack="False"></asp:CheckBox>
																		</ItemTemplate>
																	</asp:TemplateColumn>
																	<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="Ψһ��ʶ" SortExpression="Ψһ��ʶ" HeaderText="Ψһ��ʶ" CommandName="Select">
																		<HeaderStyle Width="0px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="ȷ�����" SortExpression="ȷ�����" HeaderText="ȷ�����" CommandName="Select">
																		<HeaderStyle Width="0px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn ItemStyle-Width="180px" DataTextField="��ʼ����" SortExpression="��ʼ����" HeaderText="��ʼ����" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																		<HeaderStyle Width="180px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn ItemStyle-Width="180px" DataTextField="��ֹ����" SortExpression="��ֹ����" HeaderText="��ֹ����" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																		<HeaderStyle Width="180px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn ItemStyle-Width="180px" DataTextField="������" SortExpression="������" HeaderText="�����(Ԫ)" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																		<HeaderStyle Width="180px" HorizontalAlign="Right"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn ItemStyle-Width="180px" DataTextField="�����ܶ�" SortExpression="�����ܶ�" HeaderText="�ܶ�(Ԫ)" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																		<HeaderStyle Width="180px" HorizontalAlign="Right"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn ItemStyle-Width="180px" DataTextField="��������" SortExpression="��������" HeaderText="����(��)" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																		<HeaderStyle Width="180px" HorizontalAlign="Right"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="������" SortExpression="������" HeaderText="������" CommandName="Select">
																		<HeaderStyle Width="120px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="���ⷽʽ" SortExpression="���ⷽʽ" HeaderText="���ⷽʽ" CommandName="Select">
																		<HeaderStyle Width="0px"></HeaderStyle>
																	</asp:ButtonColumn>
																	<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="���ⷽʽ����" SortExpression="���ⷽʽ����" HeaderText="���ⷽ��" CommandName="Select">
																		<HeaderStyle Width="160px"></HeaderStyle>
																	</asp:ButtonColumn>
																</Columns>
																
																<PagerStyle Visible="False" NextPageText="��ҳ" PrevPageText="��ҳ" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
															</asp:datagrid><INPUT id="htxtZLQXFixed" type="hidden" value="0" runat="server">
														</DIV>
													</TD>
												</TR>
												<TR>
													<TD style="BORDER-RIGHT: #6699cc 1px solid; BORDER-LEFT: #6699cc 1px solid; BORDER-BOTTOM: #6699cc 1px solid"><% if propEditMode()=false then response.write("<div style='display:none'>") %>
														<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
															<TR>
																<TD class="labelNotNull" noWrap align="right">��ʼ����</TD>
																<TD align="left"><asp:TextBox id="txtQX_KSRQ" Runat="server" CssClass="textbox" Columns="8"></asp:TextBox></TD>
																<TD class="labelNotNull" noWrap align="right">��ֹ����</TD>
																<TD align="left"><asp:TextBox id="txtQX_ZZRQ" Runat="server" CssClass="textbox" Columns="8"></asp:TextBox></TD>
																<TD class="label" noWrap align="right">�����</TD>
																<TD align="left"><asp:TextBox id="txtQX_YZJE" Runat="server" CssClass="textbox" Columns="10"></asp:TextBox></TD>
																<TD class="label" noWrap align="right">������</TD>
																<TD align="left"><asp:TextBox id="txtQX_JZR" Runat="server" CssClass="textbox" Columns="2"></asp:TextBox></TD>
																<TD class="label" noWrap align="right">���ⷽ��</TD>
																<TD align="left">
																	<asp:RadioButtonList id="rblQX_JZFS" Runat="server" CssClass="textbox" RepeatColumns="2" RepeatDirection="Vertical" RepeatLayout="Flow">
																		<asp:ListItem Value="0">��Ȼ��</asp:ListItem>
																		<asp:ListItem Value="1">����Ȼ��</asp:ListItem>
																	</asp:RadioButtonList>
																</TD>
																<TD class="labelAuto" noWrap align="right">�ܶ�</TD>
																<TD align="left"><asp:TextBox id="txtQX_YZZE" Runat="server" CssClass="textbox" Columns="10"></asp:TextBox></TD>
																<TD class="labelAuto" noWrap align="right">����</TD>
																<TD class="label" align="left"><asp:TextBox id="txtQX_ZQYS" Runat="server" CssClass="textbox" Columns="2"></asp:TextBox>��</TD>
															</TR>
														</TABLE>
														<% if propEditMode()=false then response.write("</div>") %>
													</TD>
												</TR>
												<TR>
													<TD align="right"><asp:Button id="btnCompute_ZLQX" Runat="server" CssClass="button" Text="�����������"></asp:Button><asp:Button id="btnAddNew_ZLQX" Runat="server" CssClass="button" Text=" �����µ����� "></asp:Button><asp:Button id="btnUpdate_ZLQX" Runat="server" CssClass="button" Text=" ���ĵ�ǰ���� "></asp:Button><asp:Button id="btnDelete_ZLQX" Runat="server" CssClass="button" Text=" ɾ��ѡ������ "></asp:Button></TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
									<TR>
										<TD class="label" align="left" bgColor="#ccff99"><B>&gt;&gt;&gt;&gt;��������</B></TD>
									</TR>
									<TR>
										<TD>
											<TABLE cellSpacing="0" cellPadding="2" width="100%" border="0">
												<TR>
													<TD class="labelAuto" align="left">���������<asp:TextBox id="txtJYZMJ" runat="server" CssClass="textbox" Columns="16"></asp:TextBox>ƽ����(�Է���֤���Ϊ׼)��</TD>
												</TR>
												<TR>
													<TD class="labelAuto" align="left">���ݵ�ַ��<asp:TextBox id="txtFWDZ" runat="server" Width="800px" CssClass="textbox"></asp:TextBox></TD>
												</TR>
												<TR>
													<TD class="labelAuto" align="left">���ޱ�֤��<asp:TextBox id="txtZLBZJ" runat="server" CssClass="textbox" Columns="16"></asp:TextBox>Ԫ�����</TD>
												</TR>
												<TR>
													<TD class="label" align="left">����������<asp:TextBox id="txtZQYS" runat="server" CssClass="textbox" Columns="16"></asp:TextBox>��</TD>
												</TR>
												<TR>
													<TD class="labelNotNull" align="left">����ģʽ��<asp:DropDownList id="ddlFKFS" Runat="server" CssClass="textbox" Width="420px"></asp:DropDownList></TD>
												</TR>
												<TR>
													<TD class="label" align="left">���ⷽʽ��<asp:RadioButtonList id="rblFZFSYD" Runat="server" CssClass="textbox" RepeatColumns="4" RepeatDirection="Vertical" RepeatLayout="Flow">
															<asp:ListItem Value="0">�½�</asp:ListItem>
															<asp:ListItem Value="1">����</asp:ListItem>
															<asp:ListItem Value="2">����</asp:ListItem>
															<asp:ListItem Value="3">���</asp:ListItem>
														</asp:RadioButtonList>&nbsp;&nbsp;&nbsp;&nbsp;�����գ�<asp:TextBox id="txtJZR" Runat="server" CssClass="textbox" Columns="4"></asp:TextBox>
													</TD>
												</TR>
												<TR>
													<TD class="label" align="left">���ɽ������<asp:TextBox id="txtZNJBL" runat="server" CssClass="textbox" Columns="16"></asp:TextBox>%������</TD>
												</TR>
												<TR>
													<TD class="label" align="left">������������<asp:TextBox id="txtNDZBL" runat="server" CssClass="textbox" Columns="16"></asp:TextBox>%�������</TD>
												</TR>
												<TR>
													<TD class="label" align="left">��¥���ڣ�<asp:TextBox id="txtJLRQ" Runat="server" CssClass="textbox" Columns="12"></asp:TextBox></TD>
												</TR>
												<TR>
													<TD class="label" align="left">��¥״����<asp:TextBox id="txtJLZKSM" runat="server" Width="800px" TextMode="MultiLine" Rows="3"></asp:TextBox></TD>
												</TR>
												<TR>
													<TD class="label" align="left">����˰�ѣ�<asp:RadioButtonList id="rblSFZFYD" Runat="server" CssClass="textbox" RepeatColumns="4" RepeatDirection="Vertical" RepeatLayout="Flow" AutoPostBack="False">
															<asp:ListItem Value="0">������˰</asp:ListItem>
															<asp:ListItem Value="1">�׷���˰(������˰)</asp:ListItem>
															<asp:ListItem Value="2">�ҷ���˰(�򷽰�˰)</asp:ListItem>
															<asp:ListItem Value="3">����</asp:ListItem>
														</asp:RadioButtonList>
													</TD>
												</TR>
												<TR>
													<TD class="label" align="left">����йܣ�<asp:RadioButtonList id="rblZJTGYD" Runat="server" CssClass="textbox" RepeatColumns="2" RepeatDirection="Vertical" RepeatLayout="Flow">
															<asp:ListItem Value="0">���й�</asp:ListItem>
															<asp:ListItem Value="1">�й�</asp:ListItem>
														</asp:RadioButtonList>
													</TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
                                    <TR>
                                        <TD class="label" align="left" bgColor="#ccff99"><B>&gt;&gt;&gt;&gt;��ע</B></TD>
                                    </TR>
                                    <tr>
                                        <td>
                                            <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                <TR>
                                                    <TD align="left"><asp:TextBox id="txtBZXX" runat="server" Width="900px" Rows="8" TextMode="MultiLine"></asp:TextBox></TD>
                                                </TR>
                                            </TABLE>
                                        </td>
                                    </tr>
									<TR>
										<TD class="label" align="left" bgColor="#ccff99"><B>&gt;&gt;&gt;&gt;���ҵ��Ա����</B></TD>
									</TR>
									<TR>
										<TD>
											<TABLE cellSpacing="0" cellPadding="0" border="0">
												<TR>
													<TD>
														<DIV id="divYWRY" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 900px; CLIP: rect(0px 900px 200px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 200px">
															<asp:datagrid id="grdYWRY" runat="server" CssClass="label" CellPadding="4" AllowSorting="False"
																BorderWidth="0px" BorderColor="#DEDFDE" PageSize="30" BorderStyle="None" BackColor="White"
																GridLines="Vertical" AutoGenerateColumns="False" AllowPaging="False" UseAccessibleHeader="True">
																<FooterStyle BackColor="#CCCC99"></FooterStyle>
																<SelectedItemStyle ForeColor="#CC0000" VerticalAlign="Middle" BackColor="#FFFFDD"></SelectedItemStyle>
																<EditItemStyle VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
																<AlternatingItemStyle BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
																<ItemStyle BorderWidth="0px" ForeColor="Black" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7"></ItemStyle>
																<HeaderStyle Font-Bold="True" HorizontalAlign="Left" ForeColor="White" VerticalAlign="Middle" BackColor="#6699cc"></HeaderStyle>
																
																<Columns>
																	<asp:TemplateColumn HeaderText="ѡ" ItemStyle-Width="20px">
																		<HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
																		<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																		<ItemTemplate>
																			<asp:CheckBox id="chkYWRY" runat="server" AutoPostBack="False"></asp:CheckBox>
																		</ItemTemplate>
																	</asp:TemplateColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="Ψһ��ʶ" SortExpression="Ψһ��ʶ" HeaderText="Ψһ��ʶ" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="ȷ�����" SortExpression="ȷ�����" HeaderText="ȷ�����" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="��Ա����" SortExpression="��Ա����" HeaderText="��Ա����" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="��Ա����" SortExpression="��Ա����" HeaderText="��Ա����" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="��λ����" SortExpression="��λ����" HeaderText="��λ����" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="300px" DataTextField="��λ����" SortExpression="��λ����" HeaderText="��λ����" CommandName="Select">
                                                                        <HeaderStyle Width="300px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="200px" DataTextField="��������" SortExpression="��������" HeaderText="��������" CommandName="Select">
                                                                        <HeaderStyle Width="200px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="60px" DataTextField="�Ŷӱ��" SortExpression="�Ŷӱ��" HeaderText="�Ŷ�" CommandName="Select">
                                                                        <HeaderStyle Width="60px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="��Աְ��" SortExpression="��Աְ��" HeaderText="��Աְ����" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="240px" DataTextField="��Աְ������" SortExpression="��Աְ������" HeaderText="ְ��" CommandName="Select">
                                                                        <HeaderStyle Width="240px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="120px" DataTextField="�������" SortExpression="�������" HeaderText="�������" CommandName="Select" DataTextFormatString="{0:#.00%}" ItemStyle-HorizontalAlign="Right">
                                                                        <HeaderStyle Width="120px" HorizontalAlign="Right"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="ֱ�ܱ��" SortExpression="ֱ�ܱ��" HeaderText="ֱ�ܱ��" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="80px" DataTextField="ֱ�ܱ������" SortExpression="ֱ�ܱ������" HeaderText="ֱ��" CommandName="Select">
                                                                        <HeaderStyle Width="80px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="״̬��־" SortExpression="״̬��־" HeaderText="״̬��־" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="80px" DataTextField="״̬��־����" SortExpression="״̬��־����" HeaderText="״̬" CommandName="Select">
                                                                        <HeaderStyle Width="80px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
																</Columns>
																
																<PagerStyle Visible="False" NextPageText="��ҳ" PrevPageText="��ҳ" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
															</asp:datagrid><INPUT id="htxtYWRYFixed" type="hidden" value="0" runat="server">
														</DIV>
													</TD>
												</TR>
												<TR>
													<TD align="right"><asp:Button id="btnAddNew_YWRY" Runat="server" CssClass="button" Text=" �����µ�ҵ��Ա "></asp:Button><asp:Button id="btnDelete_YWRY" Runat="server" CssClass="button" Text=" ɾ������ҵ��Ա "></asp:Button></TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
								</TABLE>
							</DIV>
						</TD>
					</TR>
					<TR id="trRow2">
						<TD align="center">
							<TABLE cellSpacing="0" cellPadding="0" border="0">
								<TR>
									<TD height="4"></TD>
								</TR>
								<TR>
									<TD align="center">
										<asp:button id="btnFPBL"   Runat="server" CssClass="button" Text="ҵ������" Height="36px"></asp:button>
										<asp:button id="btnSHQK"   Runat="server" CssClass="button" Text="������" Height="36px"></asp:button>
                                        <asp:button id="btnAJFH"   Runat="server" CssClass="button" Text="���ҷ���" Height="36px"></asp:button>
										<asp:button id="btnSJSZ"   Runat="server" CssClass="button" Text="ʵ����֧" Height="36px"></asp:button>
										<asp:button id="btnYSYF"   Runat="server" CssClass="button" Text="�ƻ���֧" Height="36px"></asp:button>
										<asp:button id="btnSZTZ"   Runat="server" CssClass="button" Text="��̨֧��" Height="36px"></asp:button>
										<asp:button id="btnJSQK"   Runat="server" CssClass="button" Text="�������" Height="36px"></asp:button>
										<asp:button id="btnBAQK"   Runat="server" CssClass="button" Text="�참���" Height="36px"></asp:button>
										<asp:button id="btnHTJA"   Runat="server" CssClass="button" Text="��ͬ�᰸" Height="36px"></asp:button>
                                        <asp:button id="btnJCHT"   Runat="server" CssClass="button" Text="�����ͬ" Height="36px"></asp:button>
                                        <asp:button id="btnBJHZ"   Runat="server" CssClass="button" Text="��ǻ���" Height="36px"></asp:button>
										<asp:button id="btnOK"     Runat="server" CssClass="button" Text="ȷ    ��" Height="36px"></asp:button>
										<asp:button id="btnCancel" Runat="server" CssClass="button" Text="ȡ    ��" Height="36px"></asp:button>
										<asp:button id="btnClose"  Runat="server" CssClass="button" Text="��    ��" Height="36px"></asp:button>
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
									<TD id="tdErrInfo" style="FONT-SIZE: 32pt; COLOR: black; LINE-HEIGHT: 40pt; FONT-FAMILY: ����; LETTER-SPACING: 2pt" align="center"><asp:Label id="lblMessage" Runat="server"></asp:Label><P>&nbsp;&nbsp;</P><P><asp:Button id="btnGoBack" Runat="server" Text=" ���� " Font-Size="24pt"></asp:Button></P></TD>
									<TD>&nbsp;&nbsp;&nbsp;&nbsp;</TD>
								</TR>
							</TABLE>
						</TD>
						<TD width="5%"></TD>
					</TR>
				</TABLE>
			</asp:Panel>
			<TABLE cellSpacing="0" cellPadding="0" align="center" border="0">
				<TR>
					<TD>
						<INPUT id="htxtSessionId_ZLQX" type="hidden" runat="server">
						<INPUT id="htxtSessionId_WYXX" type="hidden" runat="server">
						<INPUT id="htxtSessionId_YWRY" type="hidden" runat="server">
						<INPUT id="htxtDivLeftZLQX" type="hidden" runat="server">
						<INPUT id="htxtDivTopZLQX" type="hidden" runat="server">
						<INPUT id="htxtDivLeftWYXX" type="hidden" runat="server">
						<INPUT id="htxtDivTopWYXX" type="hidden" runat="server">
						<INPUT id="htxtDivLeftYWRY" type="hidden" runat="server">
						<INPUT id="htxtDivTopYWRY" type="hidden" runat="server">
						<INPUT id="htxtDivLeftMain" type="hidden" runat="server">
						<INPUT id="htxtDivTopMain" type="hidden" runat="server">
						<INPUT id="htxtDivLeftBody" type="hidden" runat="server">
						<INPUT id="htxtDivTopBody" type="hidden" runat="server">
					</TD>
				</TR>
				<TR>
					<TD>
						<SCRIPT language="javascript">
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
							function ScrollProc_divMain() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopMain");
								if (oText != null) oText.value = divMain.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftMain");
								if (oText != null) oText.value = divMain.scrollLeft;
								return;
							}
							function ScrollProc_divWYXX() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopWYXX");
								if (oText != null) oText.value = divWYXX.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftWYXX");
								if (oText != null) oText.value = divWYXX.scrollLeft;
								return;
							}
							function ScrollProc_divYWRY() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopYWRY");
								if (oText != null) oText.value = divYWRY.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftYWRY");
								if (oText != null) oText.value = divYWRY.scrollLeft;
								return;
							}
							function ScrollProc_divZLQX() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopZLQX");
								if (oText != null) oText.value = divZLQX.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftZLQX");
								if (oText != null) oText.value = divZLQX.scrollLeft;
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
								oText=document.getElementById("htxtDivTopMain");
								if (oText != null) divMain.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftMain");
								if (oText != null) divMain.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtDivTopWYXX");
								if (oText != null) divWYXX.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftWYXX");
								if (oText != null) divWYXX.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtDivTopYWRY");
								if (oText != null) divYWRY.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftYWRY");
								if (oText != null) divYWRY.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtDivTopZLQX");
								if (oText != null) divZLQX.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftZLQX");
								if (oText != null) divZLQX.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divMain.onscroll = ScrollProc_divMain;
								divWYXX.onscroll = ScrollProc_divWYXX;
								divYWRY.onscroll = ScrollProc_divYWRY;
								divZLQX.onscroll = ScrollProc_divZLQX;
							}
							catch (e) {}
						</SCRIPT>
					</TD>
				</TR>
				<TR>
					<TD>
						<SCRIPT language="javascript">window_onresize();</SCRIPT>
						<UWIN:POPMESSAGE id="popMessageObject" runat="server" Visible="False" EnableViewState="False" PopupWindowType="Normal" ActionType="OpenWindow" height="48px" width="96px"></UWIN:POPMESSAGE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
