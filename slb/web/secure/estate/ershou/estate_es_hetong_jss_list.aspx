<%@ Page Language="vb" AutoEventWireup="false" Codebehind="estate_es_hetong_jss_list.aspx.vb" Inherits="Josco.JSOA.web.estate_es_hetong_jss_list" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>��ͬ�������</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../styles01.css" type="text/css" rel="stylesheet">
		<style>
		    TD.grdHTLocked { ; LEFT: expression(divHT.scrollLeft); POSITION: relative }
		    TH.grdHTLocked { ; LEFT: expression(divHT.scrollLeft); POSITION: relative }
		    TH.grdHTLocked { Z-INDEX: 99 }
		    TD.grdJSSLocked { ; LEFT: expression(divJSS.scrollLeft); POSITION: relative }
		    TH.grdJSSLocked { ; LEFT: expression(divJSS.scrollLeft); POSITION: relative }
		    TH.grdJSSLocked { Z-INDEX: 99 }
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
				
				if (document.all("divJSS") == null)
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
				divHT.style.width = strWidth;

				divJSS.style.width  = strWidth;
				divJSS.style.height = strHeight;
				divJSS.style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";
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
		<form id="frmestate_es_hetong_jss_list" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="5"></TD>
						<TD vAlign="top" align="center">
							<TABLE cellSpacing="0" cellPadding="0" border="0">
								<TR id="trRow1">
									<TD class="title" align="center" colSpan="3" height="30">��ͬ�������<asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton></TD>
								</TR>
								<TR>
									<TD width="5"></TD>
									<TD vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" border="0">
											<TR id="trRow2">
												<TD><% if propQRSH()<>"" then response.write("<div style='display:none'>") %>
													<TABLE cellSpacing="0" cellPadding="0" align="center" border="0">
														<TR>
															<TD class="label" align="left" bgColor="#ccff99"><B>&gt;&gt;&gt;&gt;ȷ����ͬ</B></TD>
														</TR>
														<TR>
															<TD align="left">
																<TABLE cellSpacing="0" cellPadding="0" border="0">
																	<TR>
																		<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;ȷ�����&nbsp;</TD>
																		<TD class="label" align="left"><asp:textbox id="txtHTSearch_QRSH" runat="server" CssClass="textbox" Columns="6"></asp:textbox></TD>
																		<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;��ͬ���&nbsp;</TD>
																		<TD class="label" align="left"><asp:textbox id="txtHTSearch_HTBH" runat="server" CssClass="textbox" Columns="6"></asp:textbox></TD>
																		<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;��ͬ����&nbsp;</TD>
																		<TD class="label" align="left"><asp:textbox id="txtHTSearch_HTRQMin" runat="server" CssClass="textbox" Columns="7"></asp:textbox>~<asp:textbox id="txtHTSearch_HTRQMax" runat="server" CssClass="textbox" Columns="7"></asp:textbox></TD>
																		<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;״̬&nbsp;</TD>
																		<TD class="label" align="left">
																			<asp:DropDownList id="ddlHTSearch_HTZT" runat="server" CssClass="textbox" Enabled="False">
																				<asp:ListItem Value=""></asp:ListItem>
																				<asp:ListItem Value="&1=0">δ��</asp:ListItem>
																				<asp:ListItem Value="&1=1" Selected="True">����</asp:ListItem>
																			</asp:DropDownList>
																		</TD>
																		<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;�׷�&nbsp;</TD>
																		<TD class="label" align="left"><asp:textbox id="txtHTSearch_JFMC" runat="server" CssClass="textbox" Columns="6"></asp:textbox></TD>
																		<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;�ҷ�&nbsp;</TD>
																		<TD class="label" align="left"><asp:textbox id="txtHTSearch_YFMC" runat="server" CssClass="textbox" Columns="6"></asp:textbox></TD>
																		<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;���ݵ�ַ&nbsp;</TD>
																		<TD class="label" align="left"><asp:textbox id="txtHTSearch_FWDZ" runat="server" CssClass="textbox" Columns="10"></asp:textbox></TD>
																		<TD class="label" align="right" colSpan="2">&nbsp;&nbsp;<asp:button id="btnHTSearch" Runat="server" CssClass="button" Text="����"></asp:button><asp:button id="btnHTSearch_Full" Runat="server" CssClass="button" Text="ȫ��"></asp:button></TD>
																	</TR>
																</TABLE>
															</TD>
														</TR>
														<TR>
															<TD>
																<DIV id="divHT" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 964px; CLIP: rect(0px 964px 240px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 240px">
																	<asp:datagrid id="grdHT" runat="server" Width="7450px" CssClass="label" CellPadding="4" AllowSorting="True"
																		BorderWidth="0px" BorderColor="#DEDFDE" PageSize="30" BorderStyle="None" BackColor="White"
																		GridLines="Vertical" AutoGenerateColumns="False" AllowPaging="True" UseAccessibleHeader="True">
																		<SelectedItemStyle Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
																		<EditItemStyle VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
																		<AlternatingItemStyle BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
																		<ItemStyle BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
																		<HeaderStyle Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#6699cc" HorizontalAlign="Left"></HeaderStyle>
																		<FooterStyle BackColor="#CCCC99"></FooterStyle>
																		
																		<Columns>
																			<asp:TemplateColumn HeaderText="ѡ" Visible="False" ItemStyle-Width="20px">
																				<HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
																				<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																				<ItemTemplate>
																					<asp:CheckBox id="chkHT" runat="server" AutoPostBack="False" Visible="False"></asp:CheckBox>
																				</ItemTemplate>
																			</asp:TemplateColumn>
																			<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="Ψһ��ʶ" SortExpression="Ψһ��ʶ" HeaderText="Ψһ��ʶ" CommandName="Select">
																				<HeaderStyle Width="0px"></HeaderStyle>
																			</asp:ButtonColumn>
																			<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="��ͬΨһ��ʶ" SortExpression="��ͬΨһ��ʶ" HeaderText="��ͬΨһ��ʶ" CommandName="Select">
																				<HeaderStyle Width="0px"></HeaderStyle>
																			</asp:ButtonColumn>
																			<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="��������" SortExpression="��������" HeaderText="����" CommandName="Select">
																				<HeaderStyle Width="100px"></HeaderStyle>
																			</asp:ButtonColumn>
																			<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="���ױ��" SortExpression="���ױ��" HeaderText="ȷ�����" CommandName="OpenDocument">
																				<HeaderStyle Width="120px"></HeaderStyle>
																			</asp:ButtonColumn>
																			<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="��ͬ���" SortExpression="��ͬ���" HeaderText="��ͬ���" CommandName="OpenDocument">
																				<HeaderStyle Width="120px"></HeaderStyle>
																			</asp:ButtonColumn>
																			<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="��������" SortExpression="��������" HeaderText="��������" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																				<HeaderStyle Width="140px"></HeaderStyle>
																			</asp:ButtonColumn>
																			<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="��ͬ����" SortExpression="��ͬ����" HeaderText="��ͬ����" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																				<HeaderStyle Width="140px"></HeaderStyle>
																			</asp:ButtonColumn>
																			<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="����״̬" SortExpression="����״̬" HeaderText="����״̬" CommandName="Select">
																				<HeaderStyle Width="0px"></HeaderStyle>
																			</asp:ButtonColumn>
																			<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="��ͬ״̬" SortExpression="��ͬ״̬" HeaderText="��ͬ״̬��" CommandName="Select">
																				<HeaderStyle Width="0px"></HeaderStyle>
																			</asp:ButtonColumn>
																			<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="��ͬ״̬����" SortExpression="��ͬ״̬����" HeaderText="��ͬ״̬" CommandName="Select">
																				<HeaderStyle Width="100px"></HeaderStyle>
																			</asp:ButtonColumn>
																			<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="ҵ������" SortExpression="ҵ������" HeaderText="�׷�" CommandName="Select">
																				<HeaderStyle Width="160px"></HeaderStyle>
																			</asp:ButtonColumn>
																			<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="�ͻ�����" SortExpression="�ͻ�����" HeaderText="�ҷ�" CommandName="Select">
																				<HeaderStyle Width="160px"></HeaderStyle>
																			</asp:ButtonColumn>
																			<asp:ButtonColumn ItemStyle-Width="700px" DataTextField="��ҵ��ַ" SortExpression="��ҵ��ַ" HeaderText="���ݵ�ַ" CommandName="Select">
																				<HeaderStyle Width="700px"></HeaderStyle>
																			</asp:ButtonColumn>
																			<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="���׼۸�" SortExpression="���׼۸�" HeaderText="���׽��" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																				<HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
																			</asp:ButtonColumn>
																			<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="�������" SortExpression="�������" HeaderText="�������" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																				<HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
																			</asp:ButtonColumn>
																			<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="�׷������" SortExpression="�׷������" HeaderText="�׷������" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																				<HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
																			</asp:ButtonColumn>
																			<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="�ҷ������" SortExpression="�ҷ������" HeaderText="�ҷ������" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																				<HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
																			</asp:ButtonColumn>
																			<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="������ۿ�" SortExpression="������ۿ�" HeaderText="������ۿ�" CommandName="Select" DataTextFormatString="{0:#.00%}" ItemStyle-HorizontalAlign="Right">
																				<HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
																			</asp:ButtonColumn>
																			<asp:ButtonColumn ItemStyle-Width="200px" DataTextField="�׷���ϵ�绰" SortExpression="�׷���ϵ�绰" HeaderText="�׷���ϵ�绰" CommandName="Select">
																				<HeaderStyle Width="200px"></HeaderStyle>
																			</asp:ButtonColumn>
																			<asp:ButtonColumn ItemStyle-Width="300px" DataTextField="�׷���ϵ��ַ" SortExpression="�׷���ϵ��ַ" HeaderText="�׷���ϵ��ַ" CommandName="Select">
																				<HeaderStyle Width="300px"></HeaderStyle>
																			</asp:ButtonColumn>
																			<asp:ButtonColumn ItemStyle-Width="200px" DataTextField="�ҷ���ϵ�绰" SortExpression="�ҷ���ϵ�绰" HeaderText="�ҷ���ϵ�绰" CommandName="Select">
																				<HeaderStyle Width="200px"></HeaderStyle>
																			</asp:ButtonColumn>
																			<asp:ButtonColumn ItemStyle-Width="300px" DataTextField="�ҷ���ϵ��ַ" SortExpression="�ҷ���ϵ��ַ" HeaderText="�ҷ���ϵ��ַ" CommandName="Select">
																				<HeaderStyle Width="300px"></HeaderStyle>
																			</asp:ButtonColumn>
																			<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�׷�֤������" SortExpression="�׷�֤������" HeaderText="�׷�֤������" CommandName="Select">
																				<HeaderStyle Width="0px"></HeaderStyle>
																			</asp:ButtonColumn>
																			<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�׷�֤�պ���" SortExpression="�׷�֤�պ���" HeaderText="�׷�֤�պ���" CommandName="Select">
																				<HeaderStyle Width="0px"></HeaderStyle>
																			</asp:ButtonColumn>
																			<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�׷�������" SortExpression="�׷�������" HeaderText="�׷�������" CommandName="Select">
																				<HeaderStyle Width="0px"></HeaderStyle>
																			</asp:ButtonColumn>
																			<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�ҷ�֤������" SortExpression="�ҷ�֤������" HeaderText="�ҷ�֤������" CommandName="Select">
																				<HeaderStyle Width="0px"></HeaderStyle>
																			</asp:ButtonColumn>
																			<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�ҷ�֤�պ���" SortExpression="�ҷ�֤�պ���" HeaderText="�ҷ�֤�պ���" CommandName="Select">
																				<HeaderStyle Width="0px"></HeaderStyle>
																			</asp:ButtonColumn>
																			<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�ҷ�������" SortExpression="�ҷ�������" HeaderText="�ҷ�������" CommandName="Select">
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
																		
																		<PagerStyle Visible="False" NextPageText="��ҳ" PrevPageText="��ҳ" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
																	</asp:datagrid><INPUT id="htxtHTFixed" type="hidden" value="0" runat="server">
																</DIV>
															</TD>
														</TR>
														<TR>
															<TD class="label">
																<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
																	<TR>
																		<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZHTDeSelectAll" runat="server">��ѡ</asp:linkbutton></TD>
																		<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZHTSelectAll" runat="server">ȫѡ</asp:linkbutton></TD>
																		<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZHTMoveFirst" runat="server">��ǰ</asp:linkbutton></TD>
																		<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZHTMovePrev" runat="server">ǰҳ</asp:linkbutton></TD>
																		<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZHTMoveNext" runat="server">��ҳ</asp:linkbutton></TD>
																		<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZHTMoveLast" runat="server">���</asp:linkbutton></TD>
																		<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZHTGotoPage" runat="server">ǰ��</asp:linkbutton><asp:textbox id="txtHTPageIndex" runat="server" CssClass="textbox" Columns="3">1</asp:textbox>ҳ</TD>
																		<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZHTSetPageSize" runat="server">ÿҳ</asp:linkbutton><asp:textbox id="txtHTPageSize" runat="server" CssClass="textbox" Columns="3">30</asp:textbox>��</TD>
																		<TD class="label" vAlign="middle" noWrap align="right"><asp:label id="lblHTGridLocInfo" runat="server" CssClass="label">1/10 N/15</asp:label></TD>
																	</TR>
																</TABLE>
															</TD>
														</TR>
													</TABLE>
													<% if propQRSH()="" then response.write("</div>") %>
												</TD>
											</TR>
											<TR id="trRow3">
												<TD><% if propQRSH()="" then response.write("<div style='display:none'>") %>
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD class="label" align="left" bgColor="#ccff99"><B>&gt;&gt;&gt;&gt;������Ϣ</B></TD>
														</TR>
														<TR>
															<TD>
																<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
																	<TR>
																		<TD class="label" noWrap align="right">&nbsp;&nbsp;���ױ�ţ�&nbsp;&nbsp;</TD>
																		<TD style="BORDER-BOTTOM: #99cccc 1px solid" noWrap align="left" width="15%">&nbsp;<asp:Label id="lblJYBH" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
																		<TD class="label" noWrap align="right">&nbsp;&nbsp;�������ڣ�&nbsp;&nbsp;</TD>
																		<TD style="BORDER-BOTTOM: #99cccc 1px solid" noWrap align="left" width="15%">&nbsp;<asp:Label id="lblJYRQ" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
																		<TD class="label" noWrap align="right">&nbsp;&nbsp;�׷����ƣ�&nbsp;&nbsp;</TD>
																		<TD style="BORDER-BOTTOM: #99cccc 1px solid" noWrap align="left" width="18%">&nbsp;<asp:Label id="lblJFMC" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
																		<TD class="label" noWrap align="right">&nbsp;&nbsp;���׼۸�(Ԫ)��&nbsp;&nbsp;</TD>
																		<TD style="BORDER-BOTTOM: #99cccc 1px solid" noWrap align="right" width="15%">&nbsp;<asp:Label id="lblJYJG" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
																		<TD class="label" noWrap align="right">&nbsp;&nbsp;�׷������(Ԫ)��&nbsp;&nbsp;</TD>
																		<TD style="BORDER-BOTTOM: #99cccc 1px solid" noWrap align="right" width="15%">&nbsp;<asp:Label id="lblJFDLF" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
																	</TR>
																	<TR>
																		<TD class="label" noWrap align="right">&nbsp;&nbsp;��ͬ��ţ�&nbsp;&nbsp;</TD>
																		<TD style="BORDER-BOTTOM: #99cccc 1px solid" noWrap align="left">&nbsp;<asp:Label id="lblHTBH" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
																		<TD class="label" noWrap align="right">&nbsp;&nbsp;��ͬ���ڣ�&nbsp;&nbsp;</TD>
																		<TD style="BORDER-BOTTOM: #99cccc 1px solid" noWrap align="left">&nbsp;<asp:Label id="lblHTRQ" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
																		<TD class="label" noWrap align="right">&nbsp;&nbsp;�ҷ����ƣ�&nbsp;&nbsp;</TD>
																		<TD style="BORDER-BOTTOM: #99cccc 1px solid" noWrap align="left">&nbsp;<asp:Label id="lblYFMC" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
																		<TD class="label" noWrap align="right">&nbsp;&nbsp;�������(�O)��&nbsp;&nbsp;</TD>
																		<TD style="BORDER-BOTTOM: #99cccc 1px solid" noWrap align="right">&nbsp;<asp:Label id="lblJYMJ" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
																		<TD class="label" noWrap align="right">&nbsp;&nbsp;�ҷ������(Ԫ)��&nbsp;&nbsp;</TD>
																		<TD style="BORDER-BOTTOM: #99cccc 1px solid" noWrap align="right">&nbsp;<asp:Label id="lblYFDLF" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
																	</TR>
																	<TR>
																		<TD class="label" noWrap align="right">&nbsp;&nbsp;��ҵ��ַ��&nbsp;&nbsp;</TD>
																		<TD style="BORDER-BOTTOM: #99cccc 1px solid" noWrap align="left" colSpan="9">&nbsp;<asp:Label id="lblWYDZ" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
																	</TR>
																</TABLE>
															</TD>
														</TR>
													</TABLE>
													<% if propQRSH()="" then response.write("</div>") %>
												</TD>
											</TR>
											<TR id="trRow4">
												<TD class="label" align="left" bgColor="#ccff99"><B>&gt;&gt;&gt;&gt;��ͬ�������һ����</B></TD>
											</TR>
											<TR>
												<TD>
													<DIV id="divJSS" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 964px; CLIP: rect(0px 964px 200px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 200px">
														<asp:datagrid id="grdJSS" runat="server" Width="1730px" CssClass="label" CellPadding="4" AllowSorting="False"
															BorderWidth="0px" BorderColor="#DEDFDE" PageSize="30" BorderStyle="None" BackColor="White"
															GridLines="Vertical" AutoGenerateColumns="False" AllowPaging="False" UseAccessibleHeader="True">
															<SelectedItemStyle Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
															<EditItemStyle VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
															<AlternatingItemStyle BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
															<ItemStyle BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
															<HeaderStyle Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#6699cc" HorizontalAlign="Left"></HeaderStyle>
															<FooterStyle BackColor="#CCCC99"></FooterStyle>
															
															<Columns>
																<asp:TemplateColumn HeaderText="ѡ" Visible="False" ItemStyle-Width="20px">
																	<HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
																	<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																	<ItemTemplate>
																		<asp:CheckBox id="chkJSS" runat="server" AutoPostBack="False" Visible="False"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="Ψһ��ʶ" SortExpression="Ψһ��ʶ" HeaderText="Ψһ��ʶ" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="���㵥λ" SortExpression="���㵥λ" HeaderText="���㵥λ��" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="������Ա" SortExpression="������Ա" HeaderText="������Ա��" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="��������" SortExpression="��������" HeaderText="��������" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="״̬��־" SortExpression="״̬��־" HeaderText="״̬��־" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="50px" DataTextField="״̬��־����" SortExpression="״̬��־����" HeaderText="���" CommandName="Select">
																	<HeaderStyle Width="50px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="80px" DataTextField="������������" SortExpression="������������" HeaderText="����" CommandName="Select">
																	<HeaderStyle Width="80px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="ȷ�����" SortExpression="ȷ�����" HeaderText="ȷ�����" CommandName="Select">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="�������" SortExpression="�������" HeaderText="�������" CommandName="OpenDocument">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="��������" SortExpression="��������" HeaderText="��������" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="��Ӷ����" SortExpression="��Ӷ����" HeaderText="��Ӷ����" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="�н�Ѷ�" SortExpression="�н�Ѷ�" HeaderText="�н�Ѷ�(Ԫ)" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="140px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="������" SortExpression="������" HeaderText="�׷�����(Ԫ)" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="140px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="�������" SortExpression="�������" HeaderText="�ҷ�����(Ԫ)" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="140px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="ʵ�ն��" SortExpression="ʵ�ն��" HeaderText="�׷�ʵ��(Ԫ)" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="140px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="ʵ�ն���" SortExpression="ʵ�ն���" HeaderText="�ҷ�ʵ��(Ԫ)" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																	<HeaderStyle Width="140px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="180px" DataTextField="���㵥λ����" SortExpression="���㵥λ����" HeaderText="���㵥λ" CommandName="Select">
																	<HeaderStyle Width="180px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="������Ա����" SortExpression="������Ա����" HeaderText="������Ա" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="��ע��Ϣ" SortExpression="��ע��Ϣ" HeaderText="��ע��Ϣ" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
															</Columns>
															
															<PagerStyle Visible="False" NextPageText="��ҳ" PrevPageText="��ҳ" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
														</asp:datagrid><INPUT id="htxtJSSFixed" type="hidden" value="0" runat="server">
													</DIV>
												</TD>
											</TR>
										</TABLE>
									</TD>
									<TD width="5"></TD>
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
									<TD height="4"></TD>
								</TR>
								<TR>
									<TD align="center">
										<asp:Button id="btnAddNew" Runat="server" CssClass="button" Text="�½�����" Height="36px"></asp:Button>
										<asp:Button id="btnUpdate" Runat="server" CssClass="button" Text="�Ľ�����" Height="36px"></asp:Button>
										<asp:Button id="btnDelete" Runat="server" CssClass="button" Text="ɾ������" Height="36px"></asp:Button>
										<asp:Button id="btnBJYJ"   Runat="server" CssClass="button" Text="����Ӷ��" Height="36px"></asp:Button>
										<asp:Button id="btnSZTZ"   Runat="server" CssClass="button" Text="��̨֧��" Height="36px"></asp:Button>
										<asp:Button id="btnSHQM"   Runat="server" CssClass="button" Text="��˴���" Height="36px"></asp:Button>
										<asp:Button id="btnClose"  Runat="server" CssClass="button" Text="��    ��" Height="36px"></asp:Button>
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
			<table cellSpacing="0" cellPadding="0" align="center" border="0">
				<tr>
					<td>
						<input id="htxtSessionIdQueryHT" type="hidden" runat="server">
						<input id="htxtHTQuery" type="hidden" runat="server">
						<input id="htxtHTRows" type="hidden" runat="server">
						<input id="htxtHTSort" type="hidden" runat="server">
						<input id="htxtHTSortColumnIndex" type="hidden" runat="server">
						<input id="htxtHTSortType" type="hidden" runat="server">
						<input id="htxtDivLeftJSS" type="hidden" runat="server">
						<input id="htxtDivTopJSS" type="hidden" runat="server">
						<input id="htxtDivLeftHT" type="hidden" runat="server">
						<input id="htxtDivTopHT" type="hidden" runat="server">
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
							function ScrollProc_divHT() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopHT");
								if (oText != null) oText.value = divHT.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftHT");
								if (oText != null) oText.value = divHT.scrollLeft;
								return;
							}
							function ScrollProc_divJSS() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopJSS");
								if (oText != null) oText.value = divJSS.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftJSS");
								if (oText != null) oText.value = divJSS.scrollLeft;
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
								oText=document.getElementById("htxtDivTopHT");
								if (oText != null) divHT.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftHT");
								if (oText != null) divHT.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtDivTopJSS");
								if (oText != null) divJSS.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftJSS");
								if (oText != null) divJSS.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divHT.onscroll = ScrollProc_divHT;
								divJSS.onscroll = ScrollProc_divJSS;
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
