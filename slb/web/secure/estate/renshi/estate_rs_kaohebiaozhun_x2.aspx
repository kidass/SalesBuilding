<%@ Page Language="vb" AutoEventWireup="false" Codebehind="estate_rs_kaohebiaozhun_x2.aspx.vb" Inherits="Josco.JSOA.web.estate_rs_kaohebiaozhun_x2" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>人事考核标准(二)</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../stylesw.css" type="text/css" rel="stylesheet">
		<script src="../../../scripts/transkey.js"></script>
		<style>
			TD.grdYWJYLocked { ; LEFT: expression(divYWJY.scrollLeft); POSITION: relative }
			TH.grdYWJYLocked { ; LEFT: expression(divYWJY.scrollLeft); POSITION: relative }
			TH.grdYWJYLocked { Z-INDEX: 99 }
			TD.grdYWZGLocked { ; LEFT: expression(divYWZG.scrollLeft); POSITION: relative }
			TH.grdYWZGLocked { ; LEFT: expression(divYWZG.scrollLeft); POSITION: relative }
			TH.grdYWZGLocked { Z-INDEX: 99 }
			TH { Z-INDEX: 10; POSITION: relative }
		</style>
		<script language="javascript">
		<!--
			function window_onresize() 
			{
				var dblHeight = 0;
				var dblWidth  = 0;
				var strHeight = "";
				var strWidth  = "";
				
				if (document.all("divYWJY") == null)
					return;
				if (document.all("divYWZG") == null)
					return;
				
				intWidth   = document.body.clientWidth;   //总宽度
				intWidth  -= 16;                          //滚动条
				strWidth   = intWidth.toString() + "px";
				intHeight  = document.body.clientHeight;  //总高度
				intHeight -= 32;                          //滚动条
				intHeight -= trRow01.clientHeight;
				intHeight -= trRow02.clientHeight;
				intHeight -= trRow03.clientHeight;
				intHeight -= trRow04.clientHeight;
				intHeight -= trRow05.clientHeight;
				intHeight -= trRow06.clientHeight;
				intHeight -= trRow07.clientHeight;
				strHeight  = intHeight.toString() + "px";

				document.all("divYWJY").style.width  = strWidth;
				document.all("divYWJY").style.height = strHeight;
				document.all("divYWJY").style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";
				//alert(strWidth + " " + strHeight);
				
				strHeight = divYWZG.style.height;
				document.all("divYWZG").style.width  = strWidth;
				document.all("divYWZG").style.height = strHeight;
				document.all("divYWZG").style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";
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
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onresize="javascript:window_onresize()">
		<form id="frmestate_rs_kaohebiaozhun_x2" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD class="title" id="trRow01" style="BORDER-BOTTOM: #99cccc 2px solid" vAlign="middle" align="left" height="30">当前位置：人事管理&nbsp;&gt;&gt;&gt;&gt;&nbsp;业绩考核标准(二)<asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center">
							<TABLE cellSpacing="0" cellPadding="0" border="0">
								<TR id="trRow02">
									<TD class="title" align="left" bgColor="#ccff99">&gt;&gt;&gt;&gt;业务精英考核指标一览表</TD>
								</TR>
								<TR>
									<TD align="center">
										<DIV id="divYWJY" style="CLIP: rect(0px 996px 200px 0px); BORDER-BOTTOM: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; WIDTH: 996px; HEIGHT: 200px; OVERFLOW: auto; BORDER-TOP: #99cccc 1px solid; BORDER-RIGHT: #99cccc 1px solid">
											<asp:datagrid id="grdYWJY" runat="server" Width="100%" Font-Names="宋体" AllowSorting="False" BorderWidth="0px"
												BorderColor="#DEDFDE" PageSize="30" AllowPaging="False" CellPadding="4" BorderStyle="None"
												BackColor="White" GridLines="Vertical" AutoGenerateColumns="False" UseAccessibleHeader="True"
												CssClass="label" Font-Size="11pt">
												<SelectedItemStyle Font-Size="11pt" Font-Names="宋体" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
												<EditItemStyle Font-Size="11pt" Font-Names="宋体" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
												<AlternatingItemStyle Font-Size="11pt" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
												<ItemStyle Font-Size="11pt" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
												<HeaderStyle Font-Size="11pt" Font-Names="宋体" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#87cefa" HorizontalAlign="Left"></HeaderStyle>
												<FooterStyle BackColor="#CCCC99"></FooterStyle>
												<Columns>
													<asp:TemplateColumn HeaderText="选" ItemStyle-Width="20px">
														<HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
														<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
														<ItemTemplate>
															<asp:CheckBox id="chkYWJY" runat="server" AutoPostBack="False"></asp:CheckBox>
														</ItemTemplate>
													</asp:TemplateColumn>
													
													<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="唯一标识" SortExpression="唯一标识" HeaderText="唯一标识" CommandName="Select">
														<HeaderStyle Width="0px"></HeaderStyle>
													</asp:ButtonColumn>
													<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="职级代码" SortExpression="职级代码" HeaderText="职级代码" CommandName="Select">
														<HeaderStyle Width="0px"></HeaderStyle>
													</asp:ButtonColumn>
													<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="职级名称" SortExpression="职级名称" HeaderText="职级名称" CommandName="Select">
														<HeaderStyle Width="0px"></HeaderStyle>
													</asp:ButtonColumn>
													<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="正式标准" SortExpression="正式标准" HeaderText="正式标准" CommandName="Select">
														<HeaderStyle Width="0px"></HeaderStyle>
													</asp:ButtonColumn>
													<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="试用标准" SortExpression="试用标准" HeaderText="试用标准" CommandName="Select">
														<HeaderStyle Width="0px"></HeaderStyle>
													</asp:ButtonColumn>
													
													<asp:TemplateColumn HeaderText="业务精英职级" ItemStyle-Width="440px">
														<HeaderStyle HorizontalAlign="Center" Width="440px"></HeaderStyle>
														<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
														<ItemTemplate>
															<asp:DropDownList ID="ddlYWJY_ZJDM" Runat="server" CssClass="textbox" Width="360px"></asp:DropDownList>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn HeaderText="正式职工指标" ItemStyle-Width="200px">
														<HeaderStyle HorizontalAlign="Center" Width="200px"></HeaderStyle>
														<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
														<ItemTemplate>
															<asp:TextBox ID="txtYWJY_ZSBZ" Runat="server" CssClass="textbox_right" Width="200px"></asp:TextBox>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn HeaderText="试用员工指标" ItemStyle-Width="200px">
														<HeaderStyle HorizontalAlign="Center" Width="200px"></HeaderStyle>
														<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
														<ItemTemplate>
															<asp:TextBox ID="txtYWJY_SYBZ" Runat="server" CssClass="textbox_right" Width="200px"></asp:TextBox>
														</ItemTemplate>
													</asp:TemplateColumn>
												</Columns>
												
												<PagerStyle Visible="False" NextPageText="下页" Font-Size="11pt" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
											</asp:datagrid><INPUT id="htxtYWJYFixed" type="hidden" value="0" runat="server" NAME="htxtYWJYFixed">
										</DIV>
									</TD>
								</TR>
								<TR>
									<TD height="4"></TD>
								</TR>
								<TR id="trRow03">
									<TD vAlign="middle" align="right">
										<asp:Button id="btnSelAll_YWJY"   Runat="server" CssClass="button" Font-Size="11pt" Height="32px" Font-Name="宋体" Text="全部选定"></asp:Button>
										<asp:Button id="btnDeSelAll_YWJY" Runat="server" CssClass="button" Font-Size="11pt" Height="32px" Font-Name="宋体" Text="全部不选"></asp:Button>
										<asp:Button id="btnAddNew_YWJY"   Runat="server" CssClass="button" Font-Size="11pt" Height="32px" Font-Name="宋体" Text="加入新行"></asp:Button>
										<asp:Button id="btnDelete_YWJY"   Runat="server" CssClass="button" Font-Size="11pt" Height="32px" Font-Name="宋体" Text="删除选定"></asp:Button>
									</TD>
								</TR>
								<TR>
									<TD height="4"></TD>
								</TR>
								<TR id="trRow04">
									<TD class="title" align="left" bgColor="#ccff99">&gt;&gt;&gt;&gt;业务主管考核指标一览表</TD>
								</TR>
								<TR id="trRow05">
									<TD align="center">
										<DIV id="divYWZG" style="CLIP: rect(0px 996px 100px 0px); BORDER-BOTTOM: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; WIDTH: 996px; HEIGHT: 100px; OVERFLOW: auto; BORDER-TOP: #99cccc 1px solid; BORDER-RIGHT: #99cccc 1px solid">
											<asp:datagrid id="grdYWZG" runat="server" Width="100%" Font-Names="宋体" AllowSorting="False" BorderWidth="0px"
												BorderColor="#DEDFDE" PageSize="30" AllowPaging="False" CellPadding="4" BorderStyle="None"
												BackColor="White" GridLines="Vertical" AutoGenerateColumns="False" UseAccessibleHeader="True"
												CssClass="label" Font-Size="11pt">
												<SelectedItemStyle Font-Size="11pt" Font-Names="宋体" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
												<EditItemStyle Font-Size="11pt" Font-Names="宋体" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
												<AlternatingItemStyle Font-Size="11pt" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
												<ItemStyle Font-Size="11pt" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
												<HeaderStyle Font-Size="11pt" Font-Names="宋体" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#87cefa" HorizontalAlign="Left"></HeaderStyle>
												<FooterStyle BackColor="#CCCC99"></FooterStyle>
												<Columns>
													<asp:TemplateColumn HeaderText="选" ItemStyle-Width="20px">
														<HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
														<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
														<ItemTemplate>
															<asp:CheckBox id="chkYWZG" runat="server" AutoPostBack="False"></asp:CheckBox>
														</ItemTemplate>
													</asp:TemplateColumn>
													
													<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="唯一标识" SortExpression="唯一标识" HeaderText="唯一标识" CommandName="Select">
														<HeaderStyle Width="0px"></HeaderStyle>
													</asp:ButtonColumn>
													<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="团队属性" SortExpression="团队属性" HeaderText="团队属性" CommandName="Select">
														<HeaderStyle Width="0px"></HeaderStyle>
													</asp:ButtonColumn>
													<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="基准指标" SortExpression="基准指标" HeaderText="基准指标" CommandName="Select">
														<HeaderStyle Width="0px"></HeaderStyle>
													</asp:ButtonColumn>
													<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="基准人数" SortExpression="基准人数" HeaderText="基准人数" CommandName="Select">
														<HeaderStyle Width="0px"></HeaderStyle>
													</asp:ButtonColumn>
													<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="调整指标" SortExpression="调整指标" HeaderText="调整指标" CommandName="Select">
														<HeaderStyle Width="0px"></HeaderStyle>
													</asp:ButtonColumn>
													<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="团队属性名称" SortExpression="团队属性名称" HeaderText="团队属性名称" CommandName="Select">
														<HeaderStyle Width="0px"></HeaderStyle>
													</asp:ButtonColumn>
													
													<asp:TemplateColumn HeaderText="团队类型" ItemStyle-Width="360px">
														<HeaderStyle HorizontalAlign="Center" Width="360px"></HeaderStyle>
														<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
														<ItemTemplate>
															<asp:DropDownList ID="ddlYWZG_TDSX" Runat="server" CssClass="textbox" Width="360px">
																<asp:ListItem Value="1">营业经理团队</asp:ListItem>
																<asp:ListItem Value="2">业务经理团队</asp:ListItem>
															</asp:DropDownList>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn HeaderText="最低指标" ItemStyle-Width="200px">
														<HeaderStyle HorizontalAlign="Center" Width="200px"></HeaderStyle>
														<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
														<ItemTemplate>
															<asp:TextBox ID="txtYWZG_JZZB" Runat="server" CssClass="textbox_right" Width="200px"></asp:TextBox>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn HeaderText="基准人数" ItemStyle-Width="100px">
														<HeaderStyle HorizontalAlign="Center" Width="100px"></HeaderStyle>
														<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
														<ItemTemplate>
															<asp:TextBox ID="txtYWZG_JZRS" Runat="server" CssClass="textbox_right" Width="100px"></asp:TextBox>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn HeaderText="超编追加" ItemStyle-Width="200px">
														<HeaderStyle HorizontalAlign="Center" Width="200px"></HeaderStyle>
														<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
														<ItemTemplate>
															<asp:TextBox ID="txtYWZG_TZZB" Runat="server" CssClass="textbox_right" Width="200px"></asp:TextBox>
														</ItemTemplate>
													</asp:TemplateColumn>
												</Columns>
												
												<PagerStyle Visible="False" NextPageText="下页" Font-Size="11pt" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
											</asp:datagrid><INPUT id="htxtYWZGFixed" type="hidden" value="0" runat="server" NAME="htxtYWZGFixed">
										</DIV>
									</TD>
								</TR>
								<TR>
									<TD height="4"></TD>
								</TR>
								<TR id="trRow06">
									<TD vAlign="middle" align="right">
										<asp:Button id="btnSelAll_YWZG"   Runat="server" CssClass="button" Font-Size="11pt" Height="32px" Font-Name="宋体" Text="全部选定"></asp:Button>
										<asp:Button id="btnDeSelAll_YWZG" Runat="server" CssClass="button" Font-Size="11pt" Height="32px" Font-Name="宋体" Text="全部不选"></asp:Button>
										<asp:Button id="btnAddNew_YWZG"   Runat="server" CssClass="button" Font-Size="11pt" Height="32px" Font-Name="宋体" Text="加入新行"></asp:Button>
										<asp:Button id="btnDelete_YWZG"   Runat="server" CssClass="button" Font-Size="11pt" Height="32px" Font-Name="宋体" Text="删除选定"></asp:Button>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR id="trRow07">
						<TD style="BORDER-TOP: #99cccc 2px solid" vAlign="middle" align="center" height="36">
							<asp:Button id="btnOK"     Runat="server" CssClass="button" Font-Size="11pt" Height="32px" Font-Name="宋体" Text=" 保  存 "></asp:Button>
							<asp:Button id="btnCancel" Runat="server" CssClass="button" Font-Size="11pt" Height="32px" Font-Name="宋体" Text=" 取  消 "></asp:Button>
							<asp:Button id="btnClose"  Runat="server" CssClass="button" Font-Size="11pt" Height="32px" Font-Name="宋体" Text=" 返  回 "></asp:Button>
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
									<TD style="FONT-SIZE: 32pt; COLOR: black; LINE-HEIGHT: 40pt; FONT-FAMILY: 宋体; LETTER-SPACING: 2pt" align="center"><asp:Label id="lblMessage" Runat="server"></asp:Label><P>&nbsp;&nbsp;</P><P><asp:Button id="btnGoBack" Runat="server" Font-Size="24pt" Text=" 返回 "></asp:Button></P></TD>
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
						<input id="htxtSessionIdYWJY" type="hidden" runat="server" NAME="htxtSessionIdYWJY">
						<input id="htxtSessionIdYWZG" type="hidden" runat="server" NAME="htxtSessionIdYWZG">
						<input id="htxtDivLeftYWZG" type="hidden" runat="server" NAME="htxtDivLeftYWZG">
						<input id="htxtDivTopYWZG" type="hidden" runat="server" NAME="htxtDivTopYWZG">
						<input id="htxtDivLeftYWJY" type="hidden" runat="server" NAME="htxtDivLeftYWJY">
						<input id="htxtDivTopYWJY" type="hidden" runat="server" NAME="htxtDivTopYWJY">
						<input id="htxtDivLeftMain" type="hidden" runat="server" NAME="htxtDivLeftMain">
						<input id="htxtDivTopMain" type="hidden" runat="server" NAME="htxtDivTopMain">
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
							function ScrollProc_divYWJY() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopYWJY");
								if (oText != null) oText.value = divYWJY.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftYWJY");
								if (oText != null) oText.value = divYWJY.scrollLeft;
								return;
							}
							function ScrollProc_divYWZG() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopYWZG");
								if (oText != null) oText.value = divYWZG.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftYWZG");
								if (oText != null) oText.value = divYWZG.scrollLeft;
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
								oText=document.getElementById("htxtDivTopYWJY");
								if (oText != null) divYWJY.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftYWJY");
								if (oText != null) divYWJY.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtDivTopYWZG");
								if (oText != null) divYWZG.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftYWZG");
								if (oText != null) divYWZG.scrollLeft = oText.value;
								
								document.body.onscroll = ScrollProc_Body;
								divYWJY.onscroll = ScrollProc_divYWJY;
								divYWZG.onscroll = ScrollProc_divYWZG;
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
