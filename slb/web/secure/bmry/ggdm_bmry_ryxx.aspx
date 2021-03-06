<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ggdm_bmry_ryxx.aspx.vb" Inherits="Josco.JsKernal.web.ggdm_bmry_ryxx" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>人员信息显示或编辑窗</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../stylesw.css" type="text/css" rel="stylesheet">
		<script src="../../scripts/transkey.js"></script>
		<script language="javascript">
		<!--
			function window_onresize() 
			{
				var dblHeight = 0;
				var dblWidth  = 0;
				var strHeight = "";
				var strWidth  = "";
				var dblDeltaY = 40;
				var dblDeltaX = 0;
				
				if (document.all("divMain") == null)
					return;
				
				dblHeight = 450 + dblDeltaY + document.body.clientHeight - 570; //default state : 450px
				strHeight = parseInt(dblHeight.toString(), 10).toString() + "px";
				dblWidth  = 800 + dblDeltaX + document.body.clientWidth  - 850; //default state : 800px
				strWidth = parseInt(dblWidth.toString(), 10).toString() + "px";
				divMain.style.width  = strWidth;
				divMain.style.height = strHeight;
				divMain.style.clip = "rect(0px " + strWidth + " " + strHeight + " 0px)";
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
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onresize="return window_onresize()" background="../../images/bgmain.gif">
		<form id="frmGGDM_BMRY_RYXX" method="post" runat="server">
			<asp:Panel ID="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD class="title" vAlign="middle" align="center" colSpan="3" height="30">人员信息显示或编辑窗<asp:LinkButton id="lnkBlank" Runat="server" Width="0px" Height="5px"></asp:LinkButton></TD>
					</TR>
					<TR>
						<TD width="5%"></TD>
						<TD style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid" vAlign="top" align="center">
							<div id="divMain" style="OVERFLOW: auto; WIDTH: 800px; CLIP: rect(0px 800px 450px 0px); HEIGHT: 450px">
								<TABLE cellSpacing="0" cellPadding="0" border="0" width="100%">
									<TR vAlign="middle" align="center">
										<TD class="tips" align="center" colSpan="2" height="30">&nbsp;&nbsp;输入框旁带红色*号的内容必须输入，输入完成后按[确定]保存并返回。</TD>
									</TR>
									<tr>
										<td align="center">
											<TABLE cellSpacing="0" cellPadding="0" border="0">
												<TR vAlign="middle">
													<TD class="labelNotNull" align="right" nowrap>人员代码：</TD>
													<TD class="labelNotNull" align="left"><SPAN class="labelNotNull"><asp:textbox id="txtRYDM" runat="server" Height="24px" CssClass="textbox" Columns="16" Font-Names="宋体" Font-Size="11pt" Wrap="False"></asp:textbox><FONT color="#ff0000">*</FONT></SPAN></TD>
												</TR>
												<TR vAlign="middle">
													<TD class="labelNotNull" align="right" nowrap>人员名称：</TD>
													<TD class="labelNotNull" align="left"><SPAN class="labelNotNull"><asp:textbox id="txtRYMC" runat="server" Height="24px" CssClass="textbox" Columns="16" Font-Names="宋体" Font-Size="11pt" Wrap="False"></asp:textbox><FONT color="#ff0000">*</FONT></SPAN></TD>
												</TR>
												<!--曾祥林 2008-04-19 -->
												<tr>
													<TD class="labelNotNull" align="right" nowrap>人员真名：</TD>
													<TD class="labelNotNull" align="left"><SPAN class="labelNotNull"><asp:textbox id="txtRYZM" runat="server" Height="24px" CssClass="textbox" Columns="16" Font-Names="宋体" Font-Size="11pt" Wrap="False"></asp:textbox><FONT color="#ff0000">*</FONT></SPAN></TD>
												</tr>
												<!--曾祥林 2008-04-19 -->
												<!--曾祥林 2008-05-07 -->
												<TR vAlign="middle">
													<TD class="label" align="right"></TD>
													<TD class="label" align="left"><asp:CheckBox id="chkSFYX" runat="server" Height="24px" CssClass="textbox" Font-Names="宋体" Font-Size="11pt" Text="有效人员"></asp:CheckBox></TD>
												</TR>
												<!--曾祥林 2008-05-07 -->
												<!--曾祥林 2008-05-23 -->
												<TR vAlign="middle">
													<TD class="label" align="right"></TD>
													<TD class="label" align="left"><asp:CheckBox id="chkSFZB" runat="server" Height="24px" CssClass="textbox" Font-Names="宋体" Font-Size="11pt" Text="占编制数"></asp:CheckBox></TD>
												</TR>
												<!--曾祥林 2008-05-23 -->
												<TR vAlign="middle">
													<TD class="labelNotNull" align="right" nowrap>所在单位：</TD>
													<TD class="labelNotNull" align="left"><SPAN class="labelNotNull"><asp:textbox id="txtZZMC" runat="server" Height="24px" CssClass="textbox" Columns="48" Font-Names="宋体" Font-Size="11pt" TextMode="SingleLine" ReadOnly="True"></asp:textbox><FONT color="#ff0000">*</FONT></SPAN><asp:Button id="btnSelectZZDM" Runat="server" Font-Size="11pt" Font-Name="宋体" Text=" … "></asp:Button><INPUT id="htxtZZDM" type="hidden" runat="server" NAME="htxtZZDM"></TD>
												</TR>
												<!--曾祥林 2008-10-14 -->
												<TR vAlign="middle">
													<TD class="label" align="right" nowrap>所属分组：</TD>
													<TD class="label" align="left"><asp:DropDownList ID="ddlSSFZ" Runat="server" CssClass="textbox" Width="200px"></asp:DropDownList></TD>
												</TR>
												<!--曾祥林 2008-10-14 -->
												<TR vAlign="middle">
													<TD class="labelNotNull" align="right" nowrap>所在单位内排序号：</TD>
													<TD class="labelNotNull" align="left"><SPAN class="labelNotNull"><asp:textbox id="txtRYXH" runat="server" Height="24px" CssClass="textbox" Columns="4" Font-Names="宋体" Font-Size="11pt" Wrap="False"></asp:textbox><FONT color="#ff0000">*</FONT></SPAN></TD>
												</TR>
												<TR vAlign="middle">
													<TD class="label" align="right" nowrap>行政级别：</TD>
													<TD class="label" align="left"><asp:textbox id="txtJBMC" runat="server" Height="24px" CssClass="textbox" Columns="16" Font-Names="宋体" Font-Size="11pt" TextMode="SingleLine" ReadOnly="True"></asp:textbox><asp:Button id="btnSelectJBDM" Runat="server" Font-Size="11pt" Font-Name="宋体" Text=" … "></asp:Button><INPUT id="htxtJBDM" type="hidden" name="htxtJBDM" runat="server"></TD>
												</TR>
												<TR vAlign="middle">
													<TD class="label" align="right" nowrap>配备秘书：</TD>
													<TD class="label" align="left"><asp:textbox id="txtMSMC" runat="server" Height="24px" CssClass="textbox" Columns="16" Font-Names="宋体" Font-Size="11pt" TextMode="SingleLine" ReadOnly="True"></asp:textbox><asp:Button id="btnSelectMSDM" Runat="server" Font-Size="11pt" Font-Name="宋体" Text=" … "></asp:Button><INPUT id="htxtMSDM" type="hidden" name="htxtMSDM" runat="server"></TD>
												</TR>
												<TR vAlign="middle">
													<TD class="label" align="right" nowrap>联系电话：</TD>
													<TD class="label" align="left"><asp:textbox id="txtLXDH" runat="server" Height="24px" CssClass="textbox" Columns="50" Font-Names="宋体" Font-Size="11pt" TextMode="SingleLine" ReadOnly="False"></asp:textbox></TD>
												</TR>
												<TR vAlign="middle">
													<TD class="label" align="right" nowrap>移动电话：</TD>
													<TD class="label" align="left"><asp:textbox id="txtSJHM" runat="server" Height="24px" CssClass="textbox" Columns="30" Font-Names="宋体" Font-Size="11pt" TextMode="SingleLine" ReadOnly="False"></asp:textbox></TD>
												</TR>
												<TR vAlign="middle">
													<TD class="label" align="right" nowrap>内部邮箱：</TD>
													<TD class="label" align="left"><asp:textbox id="txtFTPDZ" runat="server" Height="24px" CssClass="textbox" Columns="50" Font-Names="宋体" Font-Size="11pt" TextMode="SingleLine" ReadOnly="False"></asp:textbox></TD>
												</TR>
												<TR vAlign="middle">
													<TD class="label" align="right" nowrap>因特网邮箱：</TD>
													<TD class="label" align="left"><asp:textbox id="txtYXDZ" runat="server" Height="24px" CssClass="textbox" Columns="50" Font-Names="宋体" Font-Size="11pt" TextMode="SingleLine" ReadOnly="False"></asp:textbox></TD>
												</TR>
												<TR vAlign="middle">
													<TD class="label" align="right"></TD>
													<TD class="label" align="left"><asp:CheckBox id="chkZDQS" Runat="server" Font-Size="11pt" Font-Name="宋体" Text="别人送来的文件系统自动签收"></asp:CheckBox></TD>
												</TR>
												<TR vAlign="middle">
													<TD class="label" align="right" nowrap>文件交接时可直接送给您的<br>人员、单位、范围：</TD>
													<TD class="label" vAlign="top" align="left"><asp:textbox id="txtKZSRY" runat="server" Height="60px" CssClass="textbox" Columns="48" Font-Names="宋体" Font-Size="11pt" TextMode="MultiLine" ReadOnly="False"></asp:textbox><asp:Button id="btnSelectKZSRY" Runat="server" Font-Size="11pt" Font-Name="宋体" Text=" … "></asp:Button></TD>
												</TR>
												<TR vAlign="middle">
													<TD class="label" align="right" nowrap>其他人员须由：</TD>
													<TD class="label" align="left"><asp:textbox id="txtQTYZS" runat="server" Height="24px" CssClass="textbox" Columns="16" Font-Names="宋体" Font-Size="11pt" TextMode="SingleLine" ReadOnly="True"></asp:textbox><asp:Button id="btnSelectQTYZS" Runat="server" Font-Size="11pt" Font-Name="宋体" Text=" … "></asp:Button>转达<INPUT id="htxtQTYZS" type="hidden" runat="server" NAME="htxtQTYZS"></TD>
												</TR>
												<TR vAlign="middle">
													<TD class="label" align="right" nowrap>查看文件交接信息时能看见<br>您的真实名称的：</TD>
													<TD class="label" vAlign="top" align="left"><asp:textbox id="txtKCKXM" runat="server" Height="60px" CssClass="textbox" Columns="48" Font-Names="宋体" Font-Size="11pt" TextMode="MultiLine" ReadOnly="False"></asp:textbox><asp:Button id="btnSelectKCKXM" Runat="server" Font-Size="11pt" Font-Name="宋体" Text=" … "></asp:Button></TD>
												</TR>
												<TR vAlign="middle">
													<TD class="label" align="right" nowrap>其他人则显示为：</TD>
													<TD class="label" align="left"><asp:textbox id="txtJJXSMC" runat="server" Height="24px" CssClass="textbox" Columns="50" Font-Names="宋体" Font-Size="11pt" TextMode="SingleLine" ReadOnly="False"></asp:textbox></TD>
												</TR>
											</table>
										</td>
									</tr>
									<TR vAlign="middle" align="center">
										<TD colSpan="2" height="3"></TD>
									</TR>
									<TR vAlign="middle" align="center">
										<TD class="label" colSpan="2">
											<TABLE cellSpacing="0" cellPadding="0" border="0" width="98%">
												<TR>
													<TD height="3"></TD>
												</TR>
												<TR>
													<TD class="label" align="center"><B>担任职务情况一览表</B></TD>
												</TR>
												<TR>
													<TD height="3"></TD>
												</TR>
												<TR>
													<TD class="label" style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid" align="left"><asp:CheckBoxList id="cblDRZW" Runat="server" Font-Size="11pt" Font-Name="宋体" RepeatColumns="6" RepeatDirection="Horizontal" RepeatLayout="Table" Width="100%"></asp:CheckBoxList></TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
									<TR vAlign="middle" align="center">
										<TD class="label" colSpan="2" height="3"></TD>
									</TR>
								</TABLE>
							</div>								
						</TD>
						<TD width="5%"></TD>
					</TR>
					<TR vAlign="middle">
						<TD height="6" colspan="3"></TD>
					</TR>
					<TR vAlign="middle">
						<TD align="center" colspan="3">
							<asp:button id="btnOK" Runat="server" Width="94" Height="36" CssClass="button" Font-Names="宋体" Font-Size="11pt" Text=" 确  定 "></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:button id="btnCancel" Runat="server" Width="94px" Height="36px" CssClass="button" Font-Names="宋体" Font-Size="11pt" Text=" 取  消 "></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:button id="btnClose" Runat="server" Width="94px" Height="36px" CssClass="button" Font-Names="宋体" Font-Size="11pt" Text=" 返  回 "></asp:button>
						</TD>
					</TR>
				</TABLE>
			</asp:Panel>
			<asp:Panel id="panelError" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0" height="98%">
					<TR>
						<TD width="5%"></TD>
						<TD>
							<TABLE height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD>&nbsp;&nbsp;&nbsp;&nbsp;</TD>
									<TD style="FONT-SIZE: 32pt; COLOR: black; LINE-HEIGHT: 40pt; FONT-FAMILY: 宋体; LETTER-SPACING: 2pt" align="center"><asp:Label id="lblMessage" Runat="server"></asp:Label><p>&nbsp;&nbsp;</p><p><input type="button" id="btnGoBack" value=" 返回 " style="FONT-SIZE: 24pt; FONT-FAMILY: 宋体" onclick="javascript:history.back();"></p></TD>
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

								document.body.onscroll = ScrollProc_Body;
								divMain.onscroll = ScrollProc_divMain;
							}
							catch (e) {}
						</script>
					</td>
				</tr>
				<tr>
					<td>
						<script language="javascript">window_onresize();</script>
						<uwin:popmessage id="popMessageObject" runat="server" width="96px" height="48px" ActionType="OpenWindow" PopupWindowType="Normal" EnableViewState="False" Visible="False"></uwin:popmessage>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
