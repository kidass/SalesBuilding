<%@ Page Language="vb" AutoEventWireup="false" Codebehind="estate_rs_bb_kh_gl.aspx.vb" Inherits="Josco.JSOA.web.estate_rs_bb_kh_gl"%>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>ҵ�����ܿ��˱�</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../styles01.css" type="text/css" rel="stylesheet">
		<script src="../../../scripts/transkey.js"></script>
		<style>
			TD.grdTJSJLocked { ; LEFT: expression(divTJSJ.scrollLeft); POSITION: relative }
			TH.grdTJSJLocked { ; LEFT: expression(divTJSJ.scrollLeft); POSITION: relative }
			TH.grdTJSJLocked { Z-INDEX: 99 }
			TH { Z-INDEX: 10; POSITION: relative }
		</style>
		<script language="javascript">
			function window_onresize() 
			{
				var intHeight = 0;
				var intWidth  = 0;
				var strHeight = "";
				var strWidth  = "";
				
				if (document.all("divTJSJ") == null)
					return;
				
				intWidth   = document.body.clientWidth;   //�ܿ��
				intWidth  -= 2 * 4;                       //���ҿհ�
				intWidth  -= 20;                          //�пհ�
				
				intHeight  = document.body.clientHeight;  //�ܸ߶�
				intHeight -= trRow01.clientHeight;
				intHeight -= trRow04.clientHeight;
				intHeight -= 20;                          //������

				strHeight = (intHeight - trRow02.clientHeight - trRow03.clientHeight).toString() + "px";
				strWidth  = (intWidth).toString() + "px";
				divTJSJ.style.width  = strWidth;
				divTJSJ.style.height = strHeight;
				divTJSJ.style.clip = "rect(0px " + strWidth + " " + strHeight + " 0px)";
				//alert(strHeight + "|" + strWidth);
			}
			function document_onreadystatechange() 
			{
				return window_onresize();
			}
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
			function ScrollProc_divTJSJ() {
				var oText;
				oText=null;
				oText=document.getElementById("htxtDivTopTJSJ");
				if (oText != null) oText.value = divTJSJ.scrollTop;
				oText=null;
				oText=document.getElementById("htxtDivLeftTJSJ");
				if (oText != null) oText.value = divTJSJ.scrollLeft;
				return;
			}
			function doRestoreScrollPos()
			{
				try 
				{
					var Text;
					oText=null;
					oText=document.getElementById("htxtDivTopBody");
					if (oText != null) document.body.scrollTop = oText.value;
					oText=null;
					oText=document.getElementById("htxtDivLeftBody");
					if (oText != null) document.body.scrollLeft = oText.value;
					oText=null;
					oText=document.getElementById("htxtDivTopTJSJ");
					if (oText != null) divTJSJ.scrollTop = oText.value;
					oText=null;
					oText=document.getElementById("htxtDivLeftTJSJ");
					if (oText != null) divTJSJ.scrollLeft = oText.value;
					document.body.onscroll = ScrollProc_Body;
					divTJSJ.onscroll = ScrollProc_divTJSJ;
				}
				catch (e) {}
			}
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onresize="return window_onresize()" onreadystatechange="document_onreadystatechange()" >
		<form id="frmestate_rs_bb_kh_gl" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR id="trRow01">
						<TD width="4"><asp:LinkButton id="lnkBlank" Runat="server" Height="5px" Width="0px"></asp:LinkButton></TD>
						<TD align="left" class="title" height="30" style="BORDER-BOTTOM: #0099cc 2px solid">��ǰλ�ã����¹���&nbsp;&gt;&gt;&gt;&gt;&nbsp;ְԱҵ������&nbsp;&gt;&gt;&gt;&gt;&nbsp;ҵ�����ܿ���</TD>
						<TD width="4"></TD>
					</TR>
					<tr>
						<td colspan="3" height="2"></td>
					</tr>
					<TR>
						<TD width="4"></TD>
						<TD vAlign="top" align="left">
							<TABLE cellSpacing="0" cellPadding="0" border="0">
								<TR>
									<TD vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" border="0">
											<TR id="trRow02">
												<TD class="label" align="left">
													<TABLE cellSpacing="0" cellPadding="0" border="0">
														<TR>
															<TD class="labelNotNull" vAlign="middle" align="right"><div style="display:none">&nbsp;�������</div></TD>
															<TD class="label" align="left"><div style="display:none"><asp:textbox id="txtTJND" runat="server" CssClass="textbox" Columns="4"></asp:textbox></div></TD>
															<TD class="labelNotNull" vAlign="middle" align="right"><div style="display:none">&nbsp;���˼���</div></TD>
															<TD class="label" align="left">
																<div style="display:none">
																<asp:DropDownList ID="ddlTJJD" Runat="server" CssClass="textbox" Width="120px">
																	<asp:ListItem Value="1">һ����</asp:ListItem>
																	<asp:ListItem Value="2">������</asp:ListItem>
																	<asp:ListItem Value="3">������</asp:ListItem>
																	<asp:ListItem Value="4">�ļ���</asp:ListItem>
																</asp:DropDownList>
																</div>
															</td>
															<TD class="labelNotNull" vAlign="middle" align="right"><div style="display:none">&nbsp;�½�ֹ��</div></TD>
															<TD class="label" align="left"><div style="display:none"><asp:textbox id="txtYJZR" runat="server" CssClass="textbox" Columns="4">26</asp:textbox></div></TD>
															<TD class="labelNotNull" vAlign="middle" align="right">&nbsp;���˼��ȿ�ʼ����</TD>
															<TD class="label" align="left"><asp:textbox id="txtJDKS" runat="server" CssClass="textbox" Columns="10"></asp:textbox></TD>
															<TD class="labelNotNull" vAlign="middle" align="right">&nbsp;���˼��Ƚ�������</TD>
															<TD class="label" align="left"><asp:textbox id="txtJDJS" runat="server" CssClass="textbox" Columns="10"></asp:textbox></TD>
															<TD class="label" nowrap>&nbsp;<asp:button id="btnCompute" Runat="server" CssClass="button" Text=" ���㱨������ "></asp:button></TD>
															<TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
															<TD class="label" align="left">
																<asp:DropDownList ID="ddlTJSJSearch_XSJB" Runat="server" CssClass="textbox" Width="300px">
																	<asp:ListItem Value=""></asp:ListItem>
																	<asp:ListItem Value=" =  1">����ʾ��Ա���Ȼ���</asp:ListItem>
																	<asp:ListItem Value=" =  2">����ʾ��Ա�¶Ȼ���</asp:ListItem>
																	<asp:ListItem Value=" <= 2">��ʾ����Ա�¶Ȼ���</asp:ListItem>
																	<asp:ListItem Value=" =  3">����ʾ��Ա�¶��Ŷӻ���</asp:ListItem>
																	<asp:ListItem Value=" <= 3">��ʾ����Ա�¶��Ŷӻ���</asp:ListItem>
																	<asp:ListItem Value=" =  4">����ʾ��Ա�¶��Ŷӽ�����ϸ</asp:ListItem>
																	<asp:ListItem Value=" <= 4">��ʾ����Ա�¶��Ŷӽ�����ϸ</asp:ListItem>
																</asp:DropDownList>
															</td>
															<TD class="label" nowrap>&nbsp;<asp:button id="btnDisplay" Runat="server" CssClass="button" Text=" ��ʾָ������ "></asp:button></TD>
														</tr>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD>
													<DIV id="divTJSJ" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 967px; CLIP: rect(0px 967px 410px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 410px">
														<asp:datagrid id="grdTJSJ" runat="server" CssClass="label" UseAccessibleHeader="True" CellPadding="3" BorderColor="#DEDFDE" BorderStyle="Solid" BorderWidth="1px" BackColor="White" AutoGenerateColumns="False" 
															GridLines="Both" PageSize="30" AllowSorting="True" AllowPaging="True" Width="3690px" >
															<SelectedItemStyle Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
															<EditItemStyle VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
															<AlternatingItemStyle BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
															<ItemStyle BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
															<HeaderStyle Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#006699" HorizontalAlign="Left"></HeaderStyle>
															<FooterStyle BackColor="#CCCC99"></FooterStyle>
															<Columns>
																<asp:TemplateColumn HeaderText="ѡ" ItemStyle-Width="0px" Visible="False">
																	<HeaderStyle HorizontalAlign="Center" Width="0px"></HeaderStyle>
																	<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																	<ItemTemplate>
																		<asp:CheckBox id="chkTJSJ" runat="server" AutoPostBack="False" Visible="False"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>

																<asp:ButtonColumn ItemStyle-Width="190px" DataTextField="��ʾ����" SortExpression="��ʾ����" HeaderText="��Ŀ" CommandName="Select">
																	<HeaderStyle Width="190px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="��ʾ����" SortExpression="��ʾ����" HeaderText="��ʾ����" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																
																<asp:ButtonColumn ItemStyle-Width="40px" DataTextField="�������" SortExpression="�������" HeaderText="���" CommandName="Select">
																	<HeaderStyle Width="40px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="40px" DataTextField="���˼���" SortExpression="���˼���" HeaderText="����" CommandName="Select">
																	<HeaderStyle Width="40px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="��ʼ����" SortExpression="��ʼ����" HeaderText="��ʼ����" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="��ֹ����" SortExpression="��ֹ����" HeaderText="��ֹ����" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�������" SortExpression="�������" HeaderText="�������" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="��Ա����" SortExpression="��Ա����" HeaderText="��Ա����" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="��Ա����" SortExpression="��Ա����" HeaderText="��Ա����" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>

																<asp:ButtonColumn ItemStyle-Width="40px" DataTextField="�����¶�" SortExpression="�����¶�" HeaderText="�¶�" CommandName="Select">
																	<HeaderStyle Width="40px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="��Աְ��" SortExpression="��Աְ��" HeaderText="��Աְ��" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="ְ������" SortExpression="ְ������" HeaderText="ְ��" CommandName="Select">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="40px" DataTextField="������Ա" SortExpression="������Ա" HeaderText="����" CommandName="Select">
																	<HeaderStyle Width="40px"></HeaderStyle>
																</asp:ButtonColumn>
																
																<asp:ButtonColumn ItemStyle-Width="110px" DataTextField="����ҵ��" SortExpression="����ҵ��" HeaderText="����ҵ������" CommandName="Select" ItemStyle-HorizontalAlign="Right" DataTextFormatString="{0:#,##0.00}">
																	<HeaderStyle Width="110px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="110px" DataTextField="�Ŷ�ҵ��" SortExpression="�Ŷ�ҵ��" HeaderText="����ҵ���Ŷ�" CommandName="Select" ItemStyle-HorizontalAlign="Right" DataTextFormatString="{0:#,##0.00}">
																	<HeaderStyle Width="110px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�Ŷ�����" SortExpression="�Ŷ�����" HeaderText="�Ŷ����ʹ���" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="�Ŷ���������" SortExpression="�Ŷ���������" HeaderText="�Ŷ�����" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="40px" DataTextField="�Ŷ�����" SortExpression="�Ŷ�����" HeaderText="��ģ" CommandName="Select" ItemStyle-HorizontalAlign="Right" DataTextFormatString="{0:#,##0.00}">
																	<HeaderStyle Width="40px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="110px" DataTextField="�¶�ָ��" SortExpression="�¶�ָ��" HeaderText="����ָ��" CommandName="Select" ItemStyle-HorizontalAlign="Right" DataTextFormatString="{0:#,##0.00}">
																	<HeaderStyle Width="110px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="40px" DataTextField="�¶ȴ��" SortExpression="�¶ȴ��" HeaderText="���" CommandName="Select">
																	<HeaderStyle Width="40px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="110px" DataTextField="����Ѷ�" SortExpression="����Ѷ�" HeaderText="��������" CommandName="Select" ItemStyle-HorizontalAlign="Right" DataTextFormatString="{0:#,##0.00}">
																	<HeaderStyle Width="110px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="110px" DataTextField="��ʦ�Ѷ�" SortExpression="��ʦ�Ѷ�" HeaderText="������ʦ��" CommandName="Select" ItemStyle-HorizontalAlign="Right" DataTextFormatString="{0:#,##0.00}">
																	<HeaderStyle Width="110px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>

																<asp:ButtonColumn ItemStyle-Width="40px" DataTextField="ֱ�ܱ��" SortExpression="ֱ�ܱ��" HeaderText="ֱ��" CommandName="Select">
																	<HeaderStyle Width="40px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="��λ����" SortExpression="��λ����" HeaderText="��λ����" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="160px" DataTextField="��λ����" SortExpression="��λ����" HeaderText="��λ����" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="��λ���" SortExpression="��λ���" HeaderText="��λ���" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="40px" DataTextField="�Ŷӱ��" SortExpression="�Ŷӱ��" HeaderText="�Ŷ�" CommandName="Select">
																	<HeaderStyle Width="40px"></HeaderStyle>
																</asp:ButtonColumn>

																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�Ϲ���ʶ" SortExpression="�Ϲ���ʶ" HeaderText="�Ϲ���ʶ" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="��ͬ��ʶ" SortExpression="��ͬ��ʶ" HeaderText="��ͬ��ʶ" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="ȷ�����" SortExpression="ȷ�����" HeaderText="ȷ�����" CommandName="Select">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="��ͬ���" SortExpression="��ͬ���" HeaderText="��ͬ���" CommandName="Select">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="�������" SortExpression="�������" HeaderText="�������" CommandName="Select">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="��������" SortExpression="��������" HeaderText="��������" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="��ͬ����" SortExpression="��ͬ����" HeaderText="��ͬ����" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="��������" SortExpression="��������" HeaderText="��������" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="��Ӷ����" SortExpression="��Ӷ����" HeaderText="��Ӷ����" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="�᰸����" SortExpression="�᰸����" HeaderText="�᰸����" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="ͳ������" SortExpression="ͳ������" HeaderText="ǩԼͳ��" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="ҵ������" SortExpression="ҵ������" HeaderText="ҵ��" CommandName="Select">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="140px" DataTextField="�ͻ�����" SortExpression="�ͻ�����" HeaderText="�ͻ�" CommandName="Select">
																	<HeaderStyle Width="140px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="240px" DataTextField="��ҵ��ַ" SortExpression="��ҵ��ַ" HeaderText="��ҵ��ַ" CommandName="Select">
																	<HeaderStyle Width="240px"></HeaderStyle>
																</asp:ButtonColumn>
																
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="���׼۸�" SortExpression="���׼۸�" HeaderText="���׶�" CommandName="Select" ItemStyle-HorizontalAlign="Right" DataTextFormatString="{0:#,##0.00}">
																	<HeaderStyle Width="120px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="�������" SortExpression="�������" HeaderText="�������" CommandName="Select" ItemStyle-HorizontalAlign="Right" DataTextFormatString="{0:#,##0.00}">
																	<HeaderStyle Width="120px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="���������" SortExpression="���������" HeaderText="�����" CommandName="Select" ItemStyle-HorizontalAlign="Right" DataTextFormatString="{0:#,##0.00}">
																	<HeaderStyle Width="120px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>

																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="�׷������" SortExpression="�׷������" HeaderText="�׷������" CommandName="Select" ItemStyle-HorizontalAlign="Right" DataTextFormatString="{0:#,##0.00}">
																	<HeaderStyle Width="120px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="�ҷ������" SortExpression="�ҷ������" HeaderText="�ҷ������" CommandName="Select" ItemStyle-HorizontalAlign="Right" DataTextFormatString="{0:#,##0.00}">
																	<HeaderStyle Width="120px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="�ܴ����" SortExpression="�ܴ����" HeaderText="�ܴ����" CommandName="Select" ItemStyle-HorizontalAlign="Right" DataTextFormatString="{0:#,##0.00}">
																	<HeaderStyle Width="120px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="������ۿ�" SortExpression="������ۿ�" HeaderText="�����ۿ�(%)" CommandName="Select" ItemStyle-HorizontalAlign="Right" DataTextFormatString="{0:##0.00%}">
																	<HeaderStyle Width="120px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="����ʦ��" SortExpression="����ʦ��" HeaderText="����ʦ��" CommandName="Select" ItemStyle-HorizontalAlign="Right" DataTextFormatString="{0:#,##0.00}">
																	<HeaderStyle Width="120px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="�������" SortExpression="�������" HeaderText="�������(%)" CommandName="Select" ItemStyle-HorizontalAlign="Right" DataTextFormatString="{0:##0.00%}">
																	<HeaderStyle Width="120px" HorizontalAlign="Right"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="״̬��־" SortExpression="״̬��־" HeaderText="ҵ������" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="��������" SortExpression="��������" HeaderText="��������" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="��ͬ����" SortExpression="��ͬ����" HeaderText="��ͬ����" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
															</Columns>
															<PagerStyle Visible="False" NextPageText="��ҳ" PrevPageText="��ҳ" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
														</asp:datagrid><INPUT id="htxtTJSJFixed" type="hidden" size="0" value="2" runat="server" NAME="htxtTJSJFixed"><INPUT id="htxtTJSJColor" type="hidden" size="0" value="1" name="htxtTJSJColor" runat="server">
													</DIV>
												</TD>
											</TR>
											<TR id="trRow03">
												<TD class="label">
													<TABLE cellSpacing="0" cellPadding="0" border="0" width="100%">
														<TR>
															<TD class="label" vAlign="baseline" align="left">��<asp:linkbutton id="lnkCZTJSJDeSelectAll" runat="server" CssClass="label">��ѡ</asp:linkbutton>��</TD>
															<TD class="label" vAlign="baseline" align="left">��<asp:linkbutton id="lnkCZTJSJSelectAll" runat="server" CssClass="label">ȫѡ</asp:linkbutton>��</TD>
															<TD class="label" vAlign="baseline" align="left">��<asp:linkbutton id="lnkCZTJSJMoveFirst" runat="server" CssClass="label">��ǰ</asp:linkbutton>��</TD>
															<TD class="label" vAlign="baseline" align="left">��<asp:linkbutton id="lnkCZTJSJMovePrev" runat="server" CssClass="label">ǰҳ</asp:linkbutton>��</TD>
															<TD class="label" vAlign="baseline" align="left">��<asp:linkbutton id="lnkCZTJSJMoveNext" runat="server" CssClass="label">��ҳ</asp:linkbutton>��</TD>
															<TD class="label" vAlign="baseline" align="left">��<asp:linkbutton id="lnkCZTJSJMoveLast" runat="server" CssClass="label">���</asp:linkbutton>��</TD>
															<TD class="label" vAlign="middle" align="left">��<asp:linkbutton id="lnkCZTJSJGotoPage" runat="server" CssClass="label">ǰ��</asp:linkbutton>��<asp:textbox id="txtTJSJPageIndex" runat="server" CssClass="textbox" Columns="3">1</asp:textbox>ҳ</TD>
															<TD class="label" vAlign="middle" align="left">��<asp:linkbutton id="lnkCZTJSJSetPageSize" runat="server" CssClass="label">ÿҳ</asp:linkbutton>��<asp:textbox id="txtTJSJPageSize" runat="server" CssClass="textbox" Columns="3">30</asp:textbox>��</TD>
															<TD class="label" vAlign="baseline" align="right"><asp:label id="lblTJSJGridLocInfo" runat="server" CssClass="label">1/10 N/15</asp:label></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</TD>
						<TD width="4"></TD>
					</TR>
					<tr>
						<TD width="4"></TD>
						<TD height="2"></TD>
						<TD width="4"></TD>
					</tr>
					<tr id="trRow04">
						<TD width="4"></TD>
						<td align="center" style="BORDER-TOP: #3399cc 2px solid" height="36">
							<asp:Button ID="btnOK"     Runat="server" CssClass="button" Text=" ������� " Height="32px"></asp:Button>
							<asp:Button ID="btnClose"  Runat="server" CssClass="button" Text=" �����ϼ� " Height="32px"></asp:Button>
						</td>
						<TD width="4"></TD>
					</tr>
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
									<TD id="tdErrInfo" style="FONT-SIZE: 32pt; COLOR: black; LINE-HEIGHT: 40pt; FONT-FAMILY: ����; LETTER-SPACING: 2pt" align="center"><asp:Label id="lblMessage" Runat="server"></asp:Label><P>&nbsp;&nbsp;</P><P><INPUT id="btnGoBack" style="FONT-SIZE: 24pt; FONT-FAMILY: ����" onclick="javascript:history.back();" type="button" value=" ���� "></P></TD>
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
						<input id="htxtTJSJSessionId" type="hidden" runat="server" NAME="htxtTJSJSessionId">
						<input id="htxtTJSJQuery" type="hidden" runat="server" NAME="htxtTJSJQuery">
						<input id="htxtTJSJRows" type="hidden" runat="server" NAME="htxtTJSJRows">
						<input id="htxtTJSJSort" type="hidden" runat="server" NAME="htxtTJSJSort">
						<input id="htxtTJSJSortColumnIndex" type="hidden" runat="server" NAME="htxtTJSJSortColumnIndex">
						<input id="htxtTJSJSortType" type="hidden" runat="server" NAME="htxtTJSJSortType">
						<input id="htxtDivLeftTJSJ" type="hidden" runat="server" NAME="htxtDivLeftTJSJ">
						<input id="htxtDivTopTJSJ" type="hidden" runat="server" NAME="htxtDivTopTJSJ">
						<input id="htxtDivLeftBody" type="hidden" runat="server" NAME="htxtDivLeftBody">
						<input id="htxtDivTopBody" type="hidden" runat="server" NAME="htxtDivTopBody">
					</td>
				</tr>
				<tr>
					<td>
						<script language="javascript">doRestoreScrollPos();</script>
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
