<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="staff_information.aspx.vb" Inherits="Josco.JSOA.web.staff_information" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>人员信息显示或编辑窗</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../filecss/styles01.css" type="text/css" rel="stylesheet">
		<style>
			TD.grdRYLocked { ; LEFT: expression(divTASK.scrollLeft); POSITION: relative }
			TH.grdRYLocked { ; LEFT: expression(divTASK.scrollLeft); POSITION: relative }
			TH.grdRYLocked { Z-INDEX: 99 }
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
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onresize="return window_onresize()" background="../../images/oabk.gif">
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
													<TD class="labelNotNull" align="right">人员代码：</TD>
													<TD class="labelNotNull" align="left">><asp:textbox id="txtRYDM" runat="server" Height="24px" CssClass="textbox" Columns="16" Font-Names="宋体" Font-Size="12px" Wrap="False" ReadOnly="true"></asp:textbox></TD>
												</TR>
												<TR vAlign="middle">
													<TD class="labelNotNull" align="right">人员名称：</TD>
													<TD class="labelNotNull" align="left"><asp:textbox id="txtRYMC" runat="server" Height="24px" CssClass="textbox" Columns="16" Font-Names="宋体" Font-Size="12px" Wrap="False" ReadOnly="true"></asp:textbox></TD>
												</TR>												
												<tr>
													<TD class="labelNotNull" align="right">用工模式：</TD>													
												     <td align="left"><asp:DropDownList id="ddlYGMS" Runat="server" CssClass="textbox" Columns="12" OnSelectedIndexChanged="ddlZPSM_SelectedIndexChanged" AutoPostBack="true">
                                                                                             <asp:ListItem Value="劳动合同" Selected="True">劳动合同</asp:ListItem>
														                                    <asp:ListItem Value="实习生">实习生</asp:ListItem>
														                                    <asp:ListItem Value="非全日制用工">非全日制用工</asp:ListItem>
														                                    <asp:ListItem Value="返聘">返聘</asp:ListItem>
														                                    <asp:ListItem Value="无固定期限">无固定期限</asp:ListItem>
                                                                                            </asp:DropDownList>
                                                     </td>													
												</tr>
																								
											</table>
										</td>
									</tr>
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
							<asp:button id="btnOK" Runat="server" Width="94" Height="36" CssClass="button" Font-Names="宋体" Font-Size="12px" Text=" 确  定 "></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:button id="btnCancel" Runat="server" Width="94px" Height="36px" CssClass="button" Font-Names="宋体" Font-Size="12px" Text=" 取  消 "></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:button id="btnClose" Runat="server" Width="94px" Height="36px" CssClass="button" Font-Names="宋体" Font-Size="12px" Text=" 返  回 "></asp:button>
						</TD>
					</TR>
				</TABLE>
			</asp:Panel>
			<asp:Panel id="panelError" Runat="server">
				<TABLE id="tabErrMain" height="98%" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="5%"></TD>
						<TD>
							<TABLE height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD>&nbsp;&nbsp;&nbsp;&nbsp;</TD>
									<TD id="tdErrInfo" style="FONT-SIZE: 32pt; COLOR: black; LINE-HEIGHT: 40pt; FONT-FAMILY: 宋体; LETTER-SPACING: 2pt" align="center"><asp:Label id="lblMessage" Runat="server"></asp:Label><p>&nbsp;&nbsp;</p><p><input type="button" id="btnGoBack" value=" 返回 " style="FONT-SIZE: 24pt; FONT-FAMILY: 宋体" onclick="javascript:history.back();"></p></TD>
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
						<input id="htxtBH" type="hidden" runat="server" NAME="htxtBH">
						<input id="htxtDivLeftMain" type="hidden" runat="server">
						<input id="htxtDivTopMain" type="hidden" runat="server">
						<input id="htxtDivLeftBody" type="hidden" runat="server">
						<input id="htxtDivTopBody" type="hidden" runat="server">
						<input id="htxtTASKQuery" type="hidden" runat="server" NAME="htxtTASKQuery">
                        <input id="htxtTASKRows" type="hidden" runat="server" NAME="htxtTASKRows">
                        <input id="htxtTASKSort" type="hidden" runat="server" NAME="htxtTASKSort">
                        <input id="htxtTASKSortColumnIndex" type="hidden" runat="server" NAME="htxtTASKSortColumnIndex">
                        <input id="htxtTASKSortType" type="hidden" runat="server" NAME="htxtTASKSortType">
                        <input id="htxtDivLeftTASK" type="hidden" runat="server" NAME="htxtDivLeftTASK">
                        <input id="htxtDivTopTASK" type="hidden" runat="server" NAME="htxtDivTopTASK">
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
							
							function ScrollProc_divTASK() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopTASK");
								if (oText != null) oText.value = divTASK.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftTASK");
								if (oText != null) oText.value = divTASK.scrollLeft;
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
								oText=document.getElementById("htxtDivTopTASK");
								if (oText != null) divTASK.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftTASK");
								if (oText != null) divTASK.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divMain.onscroll = ScrollProc_divMain;
								divTASK.onscroll = ScrollProc_divTASK;
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