<%@ Page Language="vb" AutoEventWireup="false" Codebehind="estate_rs_renyuanjiagou_mdfy.aspx.vb" Inherits="Josco.JSOA.web.estate_rs_renyuanjiagou_mdfy" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>��Ա�ڲ���������</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../stylesw.css" type="text/css" rel="stylesheet">
		<script src="../../../scripts/transkey.js"></script>
		<style>
			TD.grdRYLocked { ; LEFT: expression(divRY.scrollLeft); POSITION: relative }
			TH.grdRYLocked { ; LEFT: expression(divRY.scrollLeft); POSITION: relative }
			TH.grdRYLocked { Z-INDEX: 99 }
			TD.grdXJLocked { ; LEFT: expression(divXJ.scrollLeft); POSITION: relative }
			TH.grdXJLocked { ; LEFT: expression(divXJ.scrollLeft); POSITION: relative }
			TH.grdXJLocked { Z-INDEX: 99 }
			TD.grdNXJLocked { ; LEFT: expression(divNXJ.scrollLeft); POSITION: relative }
			TH.grdNXJLocked { ; LEFT: expression(divNXJ.scrollLeft); POSITION: relative }
			TH.grdNXJLocked { Z-INDEX: 99 }
			TH { Z-INDEX: 10; POSITION: relative }
		</style>
		<script language="javascript">
		<!--
			//zengxianglin 2008-10-14
			function onclick_btnViewJG()
			{
				var strParams = "";
				strParams = strParams + "height=" + (screen.availHeight - 40).toString() +",";
				strParams = strParams + "width="  + (screen.availWidth  - 12).toString() +",";
				strParams = strParams + "top=0,";
				strParams = strParams + "left=0,";
				strParams = strParams + "location=no,";
				strParams = strParams + "menubar=no,";
				strParams = strParams + "toolbar=no,";
				strParams = strParams + "status=no,";
				strParams = strParams + "resizable=yes,";
				strParams = strParams + "scrollbars=yes,";
				strParams = strParams + "titlebar=yes";
				window.open("estate_rs_renyuanjiagou_bdls.aspx", "_blank", strParams);
			}
			//zengxianglin 2008-10-14
		
			function window_onresize() 
			{
				var dblHeight = 0;
				var dblWidth  = 0;
				var strHeight = "";
				var strWidth  = "";
				
				if (document.all("divMain") == null)
					return;
				
				intWidth   = document.body.clientWidth;   //�ܿ��
				intWidth  -= 16;                          //������
				strWidth   = intWidth.toString() + "px";
				
				intHeight  = document.body.clientHeight;  //�ܸ߶�
				intHeight -= 16;                          //������
				intHeight -= 30;                          //trRow1.clientHeight;
				intHeight -= 36;                          //trRow2.clientHeight;
				strHeight  = intHeight.toString() + "px";
				
				document.all("divMain").style.width  = strWidth;
				document.all("divMain").style.height = strHeight;
				document.all("divMain").style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";
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
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" background="../../../images/bgmain.gif" onresize="javascript:window_onresize()">
		<form id="frmestate_rs_renyuanjiagou_mdfy" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD class="title" id="trRow1" style="BORDER-BOTTOM: #99cccc 2px solid" vAlign="middle" align="left" height="30">��ǰλ�ã����¹���&nbsp;&gt;&gt;&gt;&gt;&nbsp;����ҵ����Ա�ܹ�����&nbsp;&gt;&gt;&gt;&gt;&nbsp;�ڲ�����<asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center">
							<DIV id="divMain" style="OVERFLOW: auto; WIDTH: 996px; CLIP: rect(0px 464px 996px 0px); HEIGHT: 464px">
								<TABLE cellSpacing="0" cellPadding="0" border="0">
									<TR>
										<TD class="title" align="left" bgColor="#ccff99">&gt;&gt;&gt;&gt;�ܹ���������Աһ���� (����<asp:Label id="lblRYSM_RY" Runat="server" CssClass="label"></asp:Label>��)</TD>
									</TR>
									<TR>
										<TD align="center">
											<DIV id="divRY" style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 940px; CLIP: rect(0px 940px 250px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 250px">
												<asp:datagrid id="grdRY" runat="server" CssClass="label" UseAccessibleHeader="True"
													AutoGenerateColumns="False" GridLines="Vertical" BackColor="White" BorderStyle="None" CellPadding="2"
													AllowPaging="True" PageSize="10" BorderColor="#DEDFDE" BorderWidth="0px" AllowSorting="False" Width="1100px">
													<SelectedItemStyle Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
													<EditItemStyle VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
													<AlternatingItemStyle BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
													<ItemStyle BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
													<HeaderStyle Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#87cefa" HorizontalAlign="Left"></HeaderStyle>
													<FooterStyle BackColor="#CCCC99"></FooterStyle>
													
													<Columns>
														<asp:TemplateColumn HeaderText="ѡ" Visible="False">
															<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
															<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
															<ItemTemplate>
																<asp:CheckBox id="chkRY" runat="server" AutoPostBack="False" Visible="False"></asp:CheckBox>
															</ItemTemplate>
														</asp:TemplateColumn>
														
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="��Ա����" SortExpression="��Ա����" HeaderText="����" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="��Ա����" SortExpression="��Ա����" HeaderText="��Ա����" CommandName="Select">
															<HeaderStyle Width="100px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn ItemStyle-Width="80px" DataTextField="��Ա����" SortExpression="��Ա����" HeaderText="��Ա����" CommandName="Select">
															<HeaderStyle Width="80px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="ְ������" SortExpression="ְ������" HeaderText="ְ������" CommandName="Select">
															<HeaderStyle Width="100px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="ְ������" SortExpression="ְ������" HeaderText="ְ������" CommandName="Select">
															<HeaderStyle Width="120px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn ItemStyle-Width="170px" DataTextField="������λ����" SortExpression="������λ����" HeaderText="��λ����" CommandName="Select">
															<HeaderStyle Width="170px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn ItemStyle-Width="110px" DataTextField="��������" SortExpression="��������" HeaderText="��������" CommandName="Select">
															<HeaderStyle Width="110px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn ItemStyle-Width="170px" DataTextField="ֱ�ܵ�λ����" SortExpression="ֱ�ܵ�λ����" HeaderText="ֱ�ܵ�λ" CommandName="Select">
															<HeaderStyle Width="170px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn ItemStyle-Width="80px" DataTextField="�ϼ��쵼����" SortExpression="�ϼ��쵼����" HeaderText="�ϼ��쵼" CommandName="Select">
															<HeaderStyle Width="80px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn ItemStyle-Width="90px" DataTextField="��Чʱ��" SortExpression="��Чʱ��" HeaderText="��Чʱ��" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
															<HeaderStyle Width="90px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn ItemStyle-Width="40px" DataTextField="��Ա״̬����" SortExpression="��Ա״̬����" HeaderText="״̬" CommandName="Select">
															<HeaderStyle Width="40px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn ItemStyle-Width="40px" DataTextField="�Ƿ�ռ��" SortExpression="�Ƿ�ռ��" HeaderText="ռ��" CommandName="Select">
															<HeaderStyle Width="40px"></HeaderStyle>
														</asp:ButtonColumn>
														
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�䶯ԭ������" SortExpression="�䶯ԭ������" HeaderText="�䶯ԭ��" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="Ψһ��ʶ" SortExpression="Ψһ��ʶ" HeaderText="Ψһ��ʶ" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="��Ա״̬" SortExpression="��Ա״̬" HeaderText="��Ա״̬����" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="������λ" SortExpression="������λ" HeaderText="������λ" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="ֱ�ܵ�λ" SortExpression="ֱ�ܵ�λ" HeaderText="ֱ�ܵ�λ��" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�ϼ��쵼" SortExpression="�ϼ��쵼" HeaderText="�ϼ��쵼����" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="ʧЧʱ��" SortExpression="ʧЧʱ��" HeaderText="ʧЧʱ��" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd HH:mm:ss}">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�䶯ԭ��" SortExpression="�䶯ԭ��" HeaderText="�䶯ԭ�����" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
														
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="��׼����" SortExpression="��׼����" HeaderText="��׼����" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�Ŷӱ��" SortExpression="�Ŷӱ��" HeaderText="�Ŷӱ��" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="ֱ���Ŷ�" SortExpression="ֱ���Ŷ�" HeaderText="ֱ���Ŷ�" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="Э���Ŷ�" SortExpression="Э���Ŷ�" HeaderText="Э���Ŷ�" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�Ƿ��ְ" SortExpression="�Ƿ��ְ" HeaderText="�Ƿ��ְ" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
													</Columns>
													
													<PagerStyle Visible="False" NextPageText="��ҳ" PrevPageText="��ҳ" HorizontalAlign="Right" ForeColor="Black" Position="Bottom" BackColor="SkyBlue"></PagerStyle>
												</asp:datagrid><INPUT id="htxtRYFixed" type="hidden" value="0" runat="server">
											</DIV>
										</TD>
									</TR>
									<!-- zengxianglin 2008-10-14 -->
									<tr>
										<td class="label">
											<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
												<TR>
													<TD class="label" vAlign="baseline" align="left">��<asp:linkbutton id="lnkCZRYDeSelectAll" runat="server">��ѡ</asp:linkbutton>��</TD>
													<TD class="label" vAlign="baseline" align="left">��<asp:linkbutton id="lnkCZRYSelectAll" runat="server">ȫѡ</asp:linkbutton>��</TD>
													<TD class="label" vAlign="baseline" align="left">��<asp:linkbutton id="lnkCZRYMoveFirst" runat="server">��ǰ</asp:linkbutton>��</TD>
													<TD class="label" vAlign="baseline" align="left">��<asp:linkbutton id="lnkCZRYMovePrev" runat="server">ǰҳ</asp:linkbutton>��</TD>
													<TD class="label" vAlign="baseline" align="left">��<asp:linkbutton id="lnkCZRYMoveNext" runat="server">��ҳ</asp:linkbutton>��</TD>
													<TD class="label" vAlign="baseline" align="left">��<asp:linkbutton id="lnkCZRYMoveLast" runat="server">���</asp:linkbutton>��</TD>
													<TD class="label" vAlign="middle" align="left">��<asp:linkbutton id="lnkCZRYGotoPage" runat="server">ǰ��</asp:linkbutton>��<asp:textbox id="txtRYPageIndex" runat="server" CssClass="textbox_center" Columns="1">1</asp:textbox>ҳ</TD>
													<TD class="label" vAlign="middle" align="left">��<asp:linkbutton id="lnkCZRYSetPageSize" runat="server">ÿҳ</asp:linkbutton>��<asp:textbox id="txtRYPageSize" runat="server" CssClass="textbox_center" Columns="1">10</asp:textbox>��</TD>
													<TD class="label" vAlign="baseline" noWrap align="right"><asp:label id="lblRYGridLocInfo" runat="server" CssClass="label">1/10 N/15</asp:label></TD>
												</TR>
											</TABLE>
										</td>
									</tr>
									<!-- zengxianglin 2008-10-14 -->
									<TR>
										<TD height="2"></TD>
									</TR>
									<TR>
										<TD vAlign="middle" align="right">&nbsp;��Ա����&nbsp;
											<asp:TextBox id="txtSearch_RY_RYDM" Runat="server" CssClass="textbox" Columns="8"></asp:TextBox>&nbsp;��Ա����&nbsp;
											<asp:TextBox id="txtSearch_RY_RYMC" Runat="server" CssClass="textbox" Columns="8"></asp:TextBox>&nbsp;��λ����&nbsp;
											<asp:TextBox id="txtSearch_RY_DWMC" Runat="server" CssClass="textbox" Columns="8"></asp:TextBox>&nbsp;ְ������&nbsp;
											<asp:TextBox id="txtSearch_RY_ZJDM" Runat="server" CssClass="textbox" Columns="8"></asp:TextBox>
											<asp:Button id="btnSearch_RY" Runat="server" CssClass="button" Text="����"></asp:Button>
											<asp:Button id="btnSearchFull_RY" Runat="server" CssClass="button" Text="ȫ��"></asp:Button>
										</TD>
									</TR>
									<TR>
										<TD height="2"></TD>
									</TR>
									<TR>
										<TD class="title" align="left" bgColor="#ccff99">&gt;&gt;&gt;&gt;������Ҫ����������</TD>
									</TR>
									<TR>
										<TD style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid" align="center">
											<TABLE cellSpacing="0" cellPadding="0" border="0">
												<TR>
													<TD class="labelNotNull" align="right">�䶯ʱ�䣺</TD>
													<TD align="left" colSpan="4"><asp:TextBox id="txtSXSJ" Runat="server" CssClass="textbox" Width="320px"></asp:TextBox>(�������<asp:TextBox id="txtKSSJ" Runat="server" CssClass="textbox" Width="90px" ReadOnly="True"></asp:TextBox>)</TD>
												</TR>
												<TR>
													<TD class="labelNotNull" align="right">�䶯ԭ��</TD>
													<TD align="left" colSpan="4"><asp:DropDownList id="ddlYDYY" Runat="server" CssClass="textbox" Width="320px"></asp:DropDownList></TD>
												</TR>
												<TR>
													<TD class="labelNotNull" align="right"></TD>
													<TD align="left" colSpan="4">
														<asp:CheckBox id="chkTZYXJ" Runat="server" CssClass="textbox" Text="��Ҫ������������"></asp:CheckBox>&nbsp;&nbsp;
														<asp:CheckBox id="chkTZNXJ" Runat="server" CssClass="textbox" Text="��Ҫ�����µ�����"></asp:CheckBox>
													</TD>
												</TR>
												<tr>
													<td colspan="5" height="4"></td>
												</tr>
												<TR>
													<TD class="labelNotNull" align="right">״̬��</TD>
													<TD align="left">
														<asp:RadioButtonList id="rblRYZT" Runat="server" CssClass="textbox" RepeatColumns="2" RepeatDirection="Vertical" RepeatLayout="Table">
															<asp:ListItem Value="1">������Ա</asp:ListItem>
															<asp:ListItem Value="2">��ʽְ��</asp:ListItem>
														</asp:RadioButtonList>
													</TD>
													<TD width="40">&nbsp;</TD>
													<TD class="label" align="right">״̬(ԭ)��</TD>
													<TD align="left">
														<asp:RadioButtonList id="rblRYZT_Old" Runat="server" CssClass="textbox" RepeatColumns="2" RepeatDirection="Vertical" RepeatLayout="Table" Enabled="False">
															<asp:ListItem Value="1">������Ա</asp:ListItem>
															<asp:ListItem Value="2">��ʽְ��</asp:ListItem>
														</asp:RadioButtonList>
													</TD>
												</TR>
												<TR>
													<TD class="labelNotNull" align="right">ռ�ࣺ</TD>
													<TD align="left">
														<asp:RadioButtonList id="rblSFZB" Runat="server" CssClass="textbox" RepeatColumns="2" RepeatDirection="Vertical" RepeatLayout="Table">
															<asp:ListItem Value="0">������Ա</asp:ListItem>
															<asp:ListItem Value="1">������Ա</asp:ListItem>
														</asp:RadioButtonList>
													</TD>
													<TD width="40">&nbsp;</TD>
													<TD class="label" align="right">ռ��(ԭ)��</TD>
													<TD align="left">
														<asp:RadioButtonList id="rblSFZB_Old" Runat="server" CssClass="textbox" RepeatColumns="2" RepeatDirection="Vertical" RepeatLayout="Table" Enabled="False">
															<asp:ListItem Value="0">������Ա</asp:ListItem>
															<asp:ListItem Value="1">������Ա</asp:ListItem>
														</asp:RadioButtonList>
													</TD>
												</TR>
												<TR>
													<TD class="labelNotNull" align="right">ְ����</TD>
													<TD align="left"><asp:DropDownList id="ddlZJDM" Runat="server" CssClass="textbox"></asp:DropDownList></TD>
													<TD width="40">&nbsp;</TD>
													<TD class="label" align="right">ְ��(ԭ)��</TD>
													<TD align="left"><asp:DropDownList id="ddlZJDM_Old" Runat="server" CssClass="textbox" Enabled="False"></asp:DropDownList></TD>
												</TR>
												<TR>
													<TD class="labelNotNull" align="right">��λ��</TD>
													<TD align="left"><asp:TextBox id="txtSSDW" Runat="server" CssClass="textbox" Columns="20" ReadOnly="True"></asp:TextBox><INPUT id="htxtSSDW" type="hidden" size="1" runat="server"><asp:Button id="btnSelectZZDM" Runat="server" CssClass="button" Text="��"></asp:Button></TD>
													<TD width="40">&nbsp;</TD>
													<TD class="label" align="right">��λ(ԭ)��</TD>
													<TD align="left"><asp:TextBox id="txtSSDW_Old" Runat="server" CssClass="textbox" Columns="20" ReadOnly="True"></asp:TextBox><INPUT id="htxtSSDW_Old" type="hidden" size="1" runat="server"></TD>
												</TR>
												<TR>
													<TD class="label" align="right">���飺</TD>
													<TD align="left"><asp:DropDownList id="ddlSSFZ" runat="server" CssClass="textbox" Width="180px"></asp:DropDownList><asp:Button ID="btnJSFZLB" Runat="server" CssClass="button" Text="��"></asp:Button></TD>
													<TD width="40">&nbsp;</TD>
													<TD class="label" align="right">����(ԭ)��</TD>
													<TD align="left"><asp:DropDownList id="ddlSSFZ_Old" runat="server" CssClass="textbox" Width="200px" Enabled =False></asp:DropDownList></TD>
												</TR>
												<TR>
													<TD class="label" align="right">ֱ�ܵ�λ��</TD>
													<TD align="left"><asp:TextBox id="txtZGDW" Runat="server" CssClass="textbox" Columns="20" ReadOnly="True"></asp:TextBox><INPUT id="htxtZGDW" type="hidden" size="1" runat="server" NAME="htxtZGDW"><asp:Button id="btnSelectZGDW" Runat="server" CssClass="button" Text="��"></asp:Button></TD>
													<TD width="40">&nbsp;</TD>
													<TD class="label" align="right">ֱ�ܵ�λ(ԭ)��</TD>
													<TD align="left"><asp:TextBox id="txtZGDW_Old" Runat="server" CssClass="textbox" Columns="20" ReadOnly="True"></asp:TextBox><INPUT id="htxtZGDW_Old" type="hidden" size="1" runat="server" NAME="htxtZGDW_Old"></TD>
												</TR>
												<TR>
													<TD class="label" align="right">�ϼ��쵼��</TD>
													<TD align="left"><asp:TextBox id="txtSJLD" Runat="server" CssClass="textbox" Columns="20" ReadOnly="True"></asp:TextBox><INPUT id="htxtSJLD" type="hidden" size="1" runat="server"><asp:Button id="btnSelectSJLD" Runat="server" CssClass="button" Text="��"></asp:Button><font style="FONT-WEIGHT: bold; COLOR: red; TEXT-DECORATION: underline">(ѡʱ��ȷ��[�䶯ʱ��])</font></TD>
													<TD width="40">&nbsp;</TD>
													<TD class="label" align="right">�ϼ��쵼(ԭ)��</TD>
													<TD align="left"><asp:TextBox id="txtSJLD_Old" Runat="server" CssClass="textbox" Columns="20" ReadOnly="True"></asp:TextBox><INPUT id="htxtSJLD_Old" type="hidden" size="1" runat="server"></TD>
												</TR>
												<TR>
													<TD align="right" colSpan="5"><asp:Button id="btnReset" Runat="server" CssClass="button" Text="��ԭ��ԭʼֵ"></asp:Button></TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
									<TR>
										<TD height="2"></TD>
									</TR>
									<TR>
										<TD class="title" align="left" bgColor="#ccff99">&gt;&gt;&gt;&gt;�������е�ֱ������ (����<asp:Label id="lblRYSM_XJ" Runat="server" CssClass="label"></asp:Label>��)</TD>
									</TR>
									<TR>
										<TD align="center">
											<DIV id="divXJ" style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 940px; CLIP: rect(0px 940px 250px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 250px">
												<asp:datagrid id="grdXJ" runat="server" CssClass="label" UseAccessibleHeader="True"
													AutoGenerateColumns="False" GridLines="Vertical" BackColor="White" BorderStyle="None" CellPadding="2"
													AllowPaging="True" PageSize="10" BorderColor="#DEDFDE" BorderWidth="0px" AllowSorting="False" Width="1240px">
													<SelectedItemStyle Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
													<EditItemStyle VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
													<AlternatingItemStyle BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
													<ItemStyle BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
													<HeaderStyle Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#87cefa" HorizontalAlign="Left"></HeaderStyle>
													<FooterStyle BackColor="#CCCC99"></FooterStyle>
													
													<Columns>
														<asp:TemplateColumn HeaderText="ѡ" Visible="False" ItemStyle-Width="0px">
															<HeaderStyle HorizontalAlign="Center" Width="0px"></HeaderStyle>
															<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
															<ItemTemplate>
																<asp:CheckBox id="chkXJ" runat="server" AutoPostBack="False"></asp:CheckBox>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:ButtonColumn ItemStyle-Width="40px" Visible="False" DataTextField="��Ա����" SortExpression="��Ա����" HeaderText="����" CommandName="Select">
															<HeaderStyle Width="40px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="��Ա����" SortExpression="��Ա����" HeaderText="��Ա����" CommandName="Select">
															<HeaderStyle Width="100px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn ItemStyle-Width="80px" DataTextField="��Ա����" SortExpression="��Ա����" HeaderText="��Ա����" CommandName="Select">
															<HeaderStyle Width="80px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn ItemStyle-Width="100px" Visible="False" DataTextField="ְ������" SortExpression="ְ������" HeaderText="ְ������" CommandName="Select">
															<HeaderStyle Width="100px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="ְ������" SortExpression="ְ������" HeaderText="ְ������" CommandName="Select">
															<HeaderStyle Width="120px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn ItemStyle-Width="170px" DataTextField="������λ����" SortExpression="������λ����" HeaderText="��λ����" CommandName="Select">
															<HeaderStyle Width="170px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn ItemStyle-Width="110px" DataTextField="��������" SortExpression="��������" HeaderText="��������" CommandName="Select">
															<HeaderStyle Width="110px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn ItemStyle-Width="170px" DataTextField="ֱ�ܵ�λ����" SortExpression="ֱ�ܵ�λ����" HeaderText="ֱ�ܵ�λ" CommandName="Select">
															<HeaderStyle Width="170px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn ItemStyle-Width="80px" DataTextField="�ϼ��쵼����" SortExpression="�ϼ��쵼����" HeaderText="�ϼ��쵼" CommandName="Select">
															<HeaderStyle Width="80px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn ItemStyle-Width="40px" DataTextField="��Ա״̬����" SortExpression="��Ա״̬����" HeaderText="״̬" CommandName="Select">
															<HeaderStyle Width="40px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn ItemStyle-Width="40px" DataTextField="�Ƿ�ռ��" SortExpression="�Ƿ�ռ��" HeaderText="ռ��" CommandName="Select">
															<HeaderStyle Width="40px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn ItemStyle-Width="90px" DataTextField="��Чʱ��" SortExpression="��Чʱ��" HeaderText="��Чʱ��" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
															<HeaderStyle Width="90px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="�䶯ԭ������" SortExpression="�䶯ԭ������" HeaderText="�䶯ԭ��" CommandName="Select">
															<HeaderStyle Width="100px"></HeaderStyle>
														</asp:ButtonColumn>
														
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="Ψһ��ʶ" SortExpression="Ψһ��ʶ" HeaderText="Ψһ��ʶ" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="��Ա״̬" SortExpression="��Ա״̬" HeaderText="��Ա״̬����" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="������λ" SortExpression="������λ" HeaderText="������λ" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="ֱ�ܵ�λ" SortExpression="ֱ�ܵ�λ" HeaderText="ֱ�ܵ�λ��" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�ϼ��쵼" SortExpression="�ϼ��쵼" HeaderText="�ϼ��쵼����" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="ʧЧʱ��" SortExpression="ʧЧʱ��" HeaderText="ʧЧʱ��" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd HH:mm:ss}">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�䶯ԭ��" SortExpression="�䶯ԭ��" HeaderText="�䶯ԭ�����" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
														
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="��׼����" SortExpression="��׼����" HeaderText="��׼����" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�Ŷӱ��" SortExpression="�Ŷӱ��" HeaderText="�Ŷӱ��" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="ֱ���Ŷ�" SortExpression="ֱ���Ŷ�" HeaderText="ֱ���Ŷ�" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="Э���Ŷ�" SortExpression="Э���Ŷ�" HeaderText="Э���Ŷ�" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�Ƿ��ְ" SortExpression="�Ƿ��ְ" HeaderText="�Ƿ��ְ" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
													</Columns>
													
													<PagerStyle Visible="False" NextPageText="��ҳ" PrevPageText="��ҳ" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
												</asp:datagrid><INPUT id="htxtXJFixed" type="hidden" value="0" runat="server">
											</DIV>
										</TD>
									</TR>
									<!-- zengxianglin 2008-10-14 -->
									<tr>
										<td class="label"style="BORDER-BOTTOM: #33cccc 1px solid">
											<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
												<TR>
													<TD class="label" vAlign="baseline" align="left">��<asp:linkbutton id="lnkCZXJDeSelectAll" runat="server">��ѡ</asp:linkbutton>��</TD>
													<TD class="label" vAlign="baseline" align="left">��<asp:linkbutton id="lnkCZXJSelectAll" runat="server">ȫѡ</asp:linkbutton>��</TD>
													<TD class="label" vAlign="baseline" align="left">��<asp:linkbutton id="lnkCZXJMoveFirst" runat="server">��ǰ</asp:linkbutton>��</TD>
													<TD class="label" vAlign="baseline" align="left">��<asp:linkbutton id="lnkCZXJMovePrev" runat="server">ǰҳ</asp:linkbutton>��</TD>
													<TD class="label" vAlign="baseline" align="left">��<asp:linkbutton id="lnkCZXJMoveNext" runat="server">��ҳ</asp:linkbutton>��</TD>
													<TD class="label" vAlign="baseline" align="left">��<asp:linkbutton id="lnkCZXJMoveLast" runat="server">���</asp:linkbutton>��</TD>
													<TD class="label" vAlign="middle" align="left">��<asp:linkbutton id="lnkCZXJGotoPage" runat="server">ǰ��</asp:linkbutton>��<asp:textbox id="txtXJPageIndex" runat="server" CssClass="textbox_center" Columns="1">1</asp:textbox>ҳ</TD>
													<TD class="label" vAlign="middle" align="left">��<asp:linkbutton id="lnkCZXJSetPageSize" runat="server">ÿҳ</asp:linkbutton>��<asp:textbox id="txtXJPageSize" runat="server" CssClass="textbox_center" Columns="1">10</asp:textbox>��</TD>
													<TD class="label" vAlign="baseline" noWrap align="right"><asp:label id="lblXJGridLocInfo" runat="server" CssClass="label">1/10 N/15</asp:label></TD>
												</TR>
											</TABLE>
										</td>
									</tr>
									<!-- zengxianglin 2008-10-14 -->
									<TR>
										<TD align="right">
                                            <!-- zengxianglin 2008-10-14 -->
											<table cellpadding="0" cellspacing="0" border="0" width="100%">
												<tr>
													<td align="center" colspan="5"><font style="FONT-WEIGHT: bold; COLOR: red; TEXT-DECORATION: underline">���µ���Ŀ���������б��еĵ�ǰ�е���Աʵ�������д����д������סִ��&lt;&lt;д�뵱ǰ��&gt;&gt;������</font></td>
												</tr>
												<tr>
													<td class="label">���쵼<asp:TextBox ID="txtSJLD_XJ" Runat="server" CssClass="textbox" Columns="12" ReadOnly="True"></asp:TextBox><input id="htxtSJLD_XJ" runat="server" type="hidden" size="1"><asp:Button ID="btnSelectSJLD_XJ" Runat="server" CssClass="button" Text="��"></asp:Button></td>
													<td class="label">��ְ��<asp:DropDownList ID="ddlZJDM_XJ" Runat="server" CssClass="textbox"></asp:DropDownList></td>
													<td class="label">
														<asp:RadioButtonList ID="rblRYZT_XJ" Runat="server" CssClass="textbox" RepeatColumns="2" RepeatDirection="Vertical" RepeatLayout="Flow">
															<asp:ListItem Value="1">������Ա</asp:ListItem>
															<asp:ListItem Value="2" Selected="True">��ʽְ��</asp:ListItem>
														</asp:RadioButtonList>
													</td>
													<td class="label" align="right">�䶯ԭ��<asp:DropDownList ID="ddlYDYY_XJ" Runat="server" CssClass="textbox" Width="243px"></asp:DropDownList></td>
													<td>
													<!--zengxianglin 2008-10-14 -->
													<div style="display:none">
													<asp:Button id="btnSelAll_XJ" Runat="server" Text="ȫѡ" CssClass="button"></asp:Button>
													</div>
													<!--zengxianglin 2008-10-14 -->
													</td>
												</tr>
												<tr>
													<td class="label">�²���<asp:TextBox ID="txtZZDM_XJ" Runat="server" CssClass="textbox" Columns="12" ReadOnly="True"></asp:TextBox><input id="htxtZZDM_XJ" runat="server" type="hidden" size="1"><asp:Button ID="btnSelectZZDM_XJ" Runat="server" CssClass="button" Text="��"></asp:Button></td>
													<td class="label">�·���<asp:DropDownList ID="ddlSSFZ_XJ" Runat="server" CssClass="textbox" Width="180px"></asp:DropDownList><asp:Button ID="btnJSFZLB_XJ" Runat="server" CssClass="button" Text="��"></asp:Button></td>
													<td class="label">
														<asp:RadioButtonList ID="rblSFZB_XJ" Runat="server" CssClass="textbox" RepeatColumns="2" RepeatDirection="Vertical" RepeatLayout="Flow">
															<asp:ListItem Value="0">������Ա</asp:ListItem>
															<asp:ListItem Value="1" Selected="True">������Ա</asp:ListItem>
														</asp:RadioButtonList>
													</td>
													<td class="label" align="right">ֱ�ܵ�λ<asp:TextBox ID="txtZGDW_XJ" Runat="server" CssClass="textbox" ReadOnly="True" Width="220px"></asp:TextBox><input id="htxtZGDW_XJ" runat="server" type="hidden" size="1" NAME="htxtZGDW_XJ"><asp:Button ID="btnSelectZGDW_XJ" Runat="server" CssClass="button" Text="��"></asp:Button></td>
													<td>
													<!--zengxianglin 2008-10-14 -->
													<div style="display:none">
													<asp:Button id="btnDeSelAll_XJ" Runat="server" Text="��ѡ" CssClass="button"></asp:Button>
													</div>
													<!--zengxianglin 2008-10-14 -->
													</td>
												</tr>
												<tr>
													<td align="right" colspan="5"><asp:Button ID="btnSaveSJLD_XJ" Runat="server" CssClass="button" Text="д�뵱ǰ��"></asp:Button>&nbsp;&nbsp;<asp:Button ID="btnGetSJLD_XJ" Runat="server" CssClass="button" Text="��ʾ��ǰ��"></asp:Button></td>
												</tr>
											</table>
                                            <!-- zengxianglin 2008-10-14 -->
										</TD>
									</TR>
									<TR>
										<TD height="2"></TD>
									</TR>
									<TR>
										<TD class="title" align="left" bgColor="#ccff99">&gt;&gt;&gt;&gt;�����µ�������Ա (����<asp:Label id="lblRYSM_NXJ" Runat="server" CssClass="label"></asp:Label>��)</TD>
									</TR>
									<TR>
										<TD align="center">
											<DIV id="divNXJ" style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 940px; CLIP: rect(0px 940px 250px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 250px">
												<asp:datagrid id="grdNXJ" runat="server" CssClass="label" UseAccessibleHeader="True"
													AutoGenerateColumns="False" GridLines="Vertical" BackColor="White" BorderStyle="None" CellPadding="2"
													AllowPaging="True" PageSize="10" BorderColor="#DEDFDE" BorderWidth="0px" AllowSorting="False" Width="1260px">
													<SelectedItemStyle Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
													<EditItemStyle VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
													<AlternatingItemStyle BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
													<ItemStyle BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
													<HeaderStyle Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#87cefa" HorizontalAlign="Left"></HeaderStyle>
													<FooterStyle BackColor="#CCCC99"></FooterStyle>
													<Columns>
														<asp:TemplateColumn HeaderText="ѡ" ItemStyle-Width="20px">
															<HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
															<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
															<ItemTemplate>
																<asp:CheckBox id="chkNXJ" runat="server" AutoPostBack="False"></asp:CheckBox>
															</ItemTemplate>
														</asp:TemplateColumn>
														
														<asp:ButtonColumn ItemStyle-Width="40px" Visible="False" DataTextField="��Ա����" SortExpression="��Ա����" HeaderText="����" CommandName="Select">
															<HeaderStyle Width="40px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="��Ա����" SortExpression="��Ա����" HeaderText="��Ա����" CommandName="Select">
															<HeaderStyle Width="100px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn ItemStyle-Width="80px" DataTextField="��Ա����" SortExpression="��Ա����" HeaderText="��Ա����" CommandName="Select">
															<HeaderStyle Width="80px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn ItemStyle-Width="100px" Visible="False" DataTextField="ְ������" SortExpression="ְ������" HeaderText="ְ������" CommandName="Select">
															<HeaderStyle Width="100px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="ְ������" SortExpression="ְ������" HeaderText="ְ������" CommandName="Select">
															<HeaderStyle Width="120px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn ItemStyle-Width="170px" DataTextField="������λ����" SortExpression="������λ����" HeaderText="��λ����" CommandName="Select">
															<HeaderStyle Width="170px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn ItemStyle-Width="110px" DataTextField="��������" SortExpression="��������" HeaderText="��������" CommandName="Select">
															<HeaderStyle Width="110px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn ItemStyle-Width="170px" DataTextField="ֱ�ܵ�λ����" SortExpression="ֱ�ܵ�λ����" HeaderText="ֱ�ܵ�λ" CommandName="Select">
															<HeaderStyle Width="170px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn ItemStyle-Width="80px" DataTextField="�ϼ��쵼����" SortExpression="�ϼ��쵼����" HeaderText="�ϼ��쵼" CommandName="Select">
															<HeaderStyle Width="80px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn ItemStyle-Width="40px" DataTextField="��Ա״̬����" SortExpression="��Ա״̬����" HeaderText="״̬" CommandName="Select">
															<HeaderStyle Width="40px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn ItemStyle-Width="40px" DataTextField="�Ƿ�ռ��" SortExpression="�Ƿ�ռ��" HeaderText="ռ��" CommandName="Select">
															<HeaderStyle Width="40px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn ItemStyle-Width="90px" DataTextField="��Чʱ��" SortExpression="��Чʱ��" HeaderText="��Чʱ��" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
															<HeaderStyle Width="90px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="�䶯ԭ������" SortExpression="�䶯ԭ������" HeaderText="�䶯ԭ��" CommandName="Select">
															<HeaderStyle Width="100px"></HeaderStyle>
														</asp:ButtonColumn>
														
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="Ψһ��ʶ" SortExpression="Ψһ��ʶ" HeaderText="Ψһ��ʶ" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="��Ա״̬" SortExpression="��Ա״̬" HeaderText="��Ա״̬����" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="������λ" SortExpression="������λ" HeaderText="������λ" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="ֱ�ܵ�λ" SortExpression="ֱ�ܵ�λ" HeaderText="ֱ�ܵ�λ��" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�ϼ��쵼" SortExpression="�ϼ��쵼" HeaderText="�ϼ��쵼����" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="ʧЧʱ��" SortExpression="ʧЧʱ��" HeaderText="ʧЧʱ��" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd HH:mm:ss}">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�䶯ԭ��" SortExpression="�䶯ԭ��" HeaderText="�䶯ԭ�����" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
														
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="��׼����" SortExpression="��׼����" HeaderText="��׼����" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�Ŷӱ��" SortExpression="�Ŷӱ��" HeaderText="�Ŷӱ��" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="ֱ���Ŷ�" SortExpression="ֱ���Ŷ�" HeaderText="ֱ���Ŷ�" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="Э���Ŷ�" SortExpression="Э���Ŷ�" HeaderText="Э���Ŷ�" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�Ƿ��ְ" SortExpression="�Ƿ��ְ" HeaderText="�Ƿ��ְ" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
													</Columns>
													<PagerStyle Visible="False" NextPageText="��ҳ" PrevPageText="��ҳ" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
												</asp:datagrid><INPUT id="htxtNXJFixed" type="hidden" value="0" runat="server">
											</DIV>
										</TD>
									</TR>
									<!-- zengxianglin 2008-10-14 -->
									<tr>
										<td class="label">
											<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
												<TR>
													<TD class="label" vAlign="baseline" align="left">��<asp:linkbutton id="lnkCZNXJDeSelectAll" runat="server">��ѡ</asp:linkbutton>��</TD>
													<TD class="label" vAlign="baseline" align="left">��<asp:linkbutton id="lnkCZNXJSelectAll" runat="server">ȫѡ</asp:linkbutton>��</TD>
													<TD class="label" vAlign="baseline" align="left">��<asp:linkbutton id="lnkCZNXJMoveFirst" runat="server">��ǰ</asp:linkbutton>��</TD>
													<TD class="label" vAlign="baseline" align="left">��<asp:linkbutton id="lnkCZNXJMovePrev" runat="server">ǰҳ</asp:linkbutton>��</TD>
													<TD class="label" vAlign="baseline" align="left">��<asp:linkbutton id="lnkCZNXJMoveNext" runat="server">��ҳ</asp:linkbutton>��</TD>
													<TD class="label" vAlign="baseline" align="left">��<asp:linkbutton id="lnkCZNXJMoveLast" runat="server">���</asp:linkbutton>��</TD>
													<TD class="label" vAlign="middle" align="left">��<asp:linkbutton id="lnkCZNXJGotoPage" runat="server">ǰ��</asp:linkbutton>��<asp:textbox id="txtNXJPageIndex" runat="server" CssClass="textbox_center" Columns="1">1</asp:textbox>ҳ</TD>
													<TD class="label" vAlign="middle" align="left">��<asp:linkbutton id="lnkCZNXJSetPageSize" runat="server">ÿҳ</asp:linkbutton>��<asp:textbox id="txtNXJPageSize" runat="server" CssClass="textbox_center" Columns="1">10</asp:textbox>��</TD>
													<TD class="label" vAlign="baseline" noWrap align="right"><asp:label id="lblNXJGridLocInfo" runat="server" CssClass="label">1/10 N/15</asp:label></TD>
												</TR>
											</TABLE>
										</td>
									</tr>
									<!-- zengxianglin 2008-10-14 -->
									<TR>
										<TD class="label" align="right" style="BORDER-BOTTOM: #33cccc 1px solid">&nbsp;��Ա����&nbsp;
											<asp:TextBox id="txtSearch_NXJ_RYDM" Runat="server" CssClass="textbox" Columns="8"></asp:TextBox>&nbsp;��Ա����&nbsp;
											<asp:TextBox id="txtSearch_NXJ_RYMC" Runat="server" CssClass="textbox" Columns="8"></asp:TextBox>&nbsp;��λ����&nbsp;
											<asp:TextBox id="txtSearch_NXJ_DWMC" Runat="server" CssClass="textbox" Columns="8"></asp:TextBox>&nbsp;ְ������&nbsp;
											<asp:TextBox id="txtSearch_NXJ_ZJDM" Runat="server" CssClass="textbox" Columns="8"></asp:TextBox>
											<!--zengxianglin 2008-10-14 -->
											<div style="display:none">
											<asp:Button id="btnSelAll_NXJ" Runat="server" CssClass="button" Text="ȫѡ"></asp:Button>
											</div>
											<!--zengxianglin 2008-10-14 -->
											<!--zengxianglin 2008-10-14 -->
											<div style="display:none">
											<asp:Button id="btnDeSelAll_NXJ" Runat="server" CssClass="button" Text="��ѡ"></asp:Button>
											</div>
											<!--zengxianglin 2008-10-14 -->
											<asp:Button id="btnSearch_NXJ" Runat="server" CssClass="button" Text="����"></asp:Button>
											<asp:Button id="btnSearchFull_NXJ" Runat="server" CssClass="button" Text="ȫ��"></asp:Button>
											<asp:Button id="btnDelete_NXJ" Runat="server" CssClass="button" Text="�Ƴ�"></asp:Button>
										</TD>
									</TR>
                                    <!-- zengxianglin 2008-10-14 -->
									<tr>
										<td height="2"></td>
									</tr>
									<tr>
										<td align="right">
                                            <!-- zengxianglin 2008-10-14 -->
											<table cellpadding="0" cellspacing="0" border="0" width="100%">
												<tr>
													<td align="center" colspan="4"><font style="FONT-WEIGHT: bold; COLOR: red; TEXT-DECORATION: underline">���µ���Ŀ���������б��еĵ�ǰ�е���Աʵ�������д����д������סִ��&lt;&lt;д�뵱ǰ��&gt;&gt;������</font></td>
												</tr>
												<tr>
													<td class="label"></td>
													<td class="label">��ְ��<asp:DropDownList ID="ddlZJDM_NXJ" Runat="server" CssClass="textbox"></asp:DropDownList></td>
													<td class="label">
														<asp:RadioButtonList ID="rblRYZT_NXJ" Runat="server" CssClass="textbox" RepeatColumns="2" RepeatDirection="Vertical" RepeatLayout="Flow">
															<asp:ListItem Value="1">������Ա</asp:ListItem>
															<asp:ListItem Value="2" Selected="True">��ʽְ��</asp:ListItem>
														</asp:RadioButtonList>
													</td>
													<td class="label" align="right">�䶯ԭ��<asp:DropDownList ID="ddlYDYY_NXJ" Runat="server" CssClass="textbox" Width="243px"></asp:DropDownList></td>
												</tr>
												<tr>
													<td class="label">�²���<asp:TextBox ID="txtZZDM_NXJ" Runat="server" CssClass="textbox" Columns="12" ReadOnly="True"></asp:TextBox><input id="htxtZZDM_NXJ" runat="server" type="hidden" size="1" NAME="htxtZZDM_NXJ"><asp:Button ID="btnSelectZZDM_NXJ" Runat="server" CssClass="button" Text="��"></asp:Button></td>
													<td class="label">�·���<asp:DropDownList ID="ddlSSFZ_NXJ" Runat="server" CssClass="textbox" Width="180px"></asp:DropDownList><asp:Button ID="btnJSFZLB_NXJ" Runat="server" CssClass="button" Text="��"></asp:Button></td>
													<td class="label">
														<asp:RadioButtonList ID="rblSFZB_NXJ" Runat="server" CssClass="textbox" RepeatColumns="2" RepeatDirection="Vertical" RepeatLayout="Flow">
															<asp:ListItem Value="0">������Ա</asp:ListItem>
															<asp:ListItem Value="1" Selected="True">������Ա</asp:ListItem>
														</asp:RadioButtonList>
													</td>
													<td class="label" align="right">ֱ�ܵ�λ<asp:TextBox ID="txtZGDW_NXJ" Runat="server" CssClass="textbox" ReadOnly="True" Width="220px"></asp:TextBox><input id="htxtZGDW_NXJ" runat="server" type="hidden" size="1" NAME="htxtZGDW_NXJ"><asp:Button ID="btnSelectZGDW_NXJ" Runat="server" CssClass="button" Text="��"></asp:Button></td>
												</tr>
												<tr>
													<td align="right" colspan="4"><asp:Button ID="btnSaveSJLD_NXJ" Runat="server" CssClass="button" Text="д�뵱ǰ��"></asp:Button>&nbsp;&nbsp;<asp:Button ID="btnGetSJLD_NXJ" Runat="server" CssClass="button" Text="��ʾ��ǰ��"></asp:Button></td>
												</tr>
											</table>
                                            <!-- zengxianglin 2008-10-14 -->
										</td>
									</tr>
                                    <!-- zengxianglin 2008-10-14 -->
								</TABLE>
							</DIV>
						</TD>
					</TR>
					<TR>
						<TD height="2"></TD>
					</TR>
					<TR id="trRow2">
						<TD style="BORDER-TOP: #99cccc 2px solid" vAlign="middle" align="center" height="36">
							<!-- zengxianglin 2008-10-14-->
							<!--<asp:Button id="btnViewJG" Runat="server" CssClass="button" Text=" ��Ա�ܹ� " Height="32px"></asp:Button>-->
							<input id="btnViewJG" type="button" class="button" value=" ��Ա�ܹ� " style="HEIGHT: 32px" onclick="onclick_btnViewJG()">
							<!-- zengxianglin 2008-10-14-->
							<asp:Button id="btnOK" Runat="server" CssClass="button" Text=" ȷ  �� " Height="32px"></asp:Button>
							<asp:Button id="btnCancel" Runat="server" CssClass="button" Text=" ȡ  �� " Height="32px"></asp:Button>
						</TD>
					</TR>
				</TABLE>
			</asp:panel>
			<asp:Panel id="panelError" Runat="server">
				<TABLE height="98%" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="5%"></TD>
						<TD>
							<TABLE height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD>&nbsp;&nbsp;&nbsp;&nbsp;</TD>
									<TD style="FONT-SIZE: 32pt; COLOR: black; LINE-HEIGHT: 40pt; FONT-FAMILY: ����; LETTER-SPACING: 2pt" align="center"><asp:Label id="lblMessage" Runat="server"></asp:Label><P>&nbsp;&nbsp;</P><P><asp:Button id="btnGoBack" Runat="server" Font-Size="24pt" Text=" ���� "></asp:Button></P></TD>
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
						<!-- zengxianglin 2010-01-05 -->
						<input id="htxtBZXL" type="hidden" runat="server" NAME="htxtBZXL" value="001">
						<!-- zengxianglin 2010-01-05 -->
						<!-- zengxianglin 2008-11-22 -->
						<input id="htxtBDYY_NBTZ" type="hidden" runat="server" NAME="htxtBDYY_NBTZ" value="003">
						<!-- zengxianglin 2008-11-22 -->
						<!-- zengxianglin 2008-10-14 -->
						<input id="htxtRYRows" type="hidden" runat="server">
						<input id="htxtXJRows" type="hidden" runat="server">
						<input id="htxtNXJRows" type="hidden" runat="server">
						<!-- zengxianglin 2008-10-14 -->
						<input id="htxtSessionIdQuery_NXJ" type="hidden" runat="server">
						<input id="htxtSessionId_NXJ" type="hidden" runat="server">
						<input id="htxtQuery_NXJ" type="hidden" runat="server">
						<input id="htxtSessionId_XJ" type="hidden" runat="server">
						<input id="htxtSessionIdQuery_RY" type="hidden" runat="server">
						<input id="htxtQuery_RY" type="hidden" runat="server">
						<input id="htxtDivLeftNXJ" type="hidden" runat="server">
						<input id="htxtDivTopNXJ" type="hidden" runat="server">
						<input id="htxtDivLeftXJ" type="hidden" runat="server">
						<input id="htxtDivTopXJ" type="hidden" runat="server">
						<input id="htxtDivLeftRY" type="hidden" runat="server">
						<input id="htxtDivTopRY" type="hidden" runat="server">
						<input id="htxtDivLeftMain" type="hidden" runat="server">
						<input id="htxtDivTopMain" type="hidden" runat="server">
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
							function ScrollProc_divRY() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopRY");
								if (oText != null) oText.value = divRY.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftRY");
								if (oText != null) oText.value = divRY.scrollLeft;
								return;
							}
							function ScrollProc_divXJ() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopXJ");
								if (oText != null) oText.value = divXJ.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftXJ");
								if (oText != null) oText.value = divXJ.scrollLeft;
								return;
							}
							function ScrollProc_divNXJ() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopNXJ");
								if (oText != null) oText.value = divNXJ.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftNXJ");
								if (oText != null) oText.value = divNXJ.scrollLeft;
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
								oText=document.getElementById("htxtDivTopRY");
								if (oText != null) divRY.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftRY");
								if (oText != null) divRY.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtDivTopXJ");
								if (oText != null) divXJ.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftXJ");
								if (oText != null) divXJ.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtDivTopNXJ");
								if (oText != null) divNXJ.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftNXJ");
								if (oText != null) divNXJ.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divMain.onscroll = ScrollProc_divMain;
								divRY.onscroll = ScrollProc_divRY;
								divXJ.onscroll = ScrollProc_divXJ;
								divNXJ.onscroll = ScrollProc_divNXJ;
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
