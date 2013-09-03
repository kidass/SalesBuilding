<%@ Page Language="vb" AutoEventWireup="false" Codebehind="estate_rs_renyuanjiagou_rela.aspx.vb" Inherits="Josco.JSOA.web.estate_rs_renyuanjiagou_rela" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
    <HEAD>
        <title>人员之间的领导关系查看窗</title>
        <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
        <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
        <meta content="JavaScript" name="vs_defaultClientScript">
        <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <LINK href="../../../stylesw.css" type="text/css" rel="stylesheet">
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
				
				intWidth   = document.body.clientWidth;   //总宽度
				intWidth  -= 16;                          //滚动条
				strWidth   = intWidth.toString() + "px";
				
				intHeight  = document.body.clientHeight;  //总高度
				intHeight -= 16;                          //滚动条
				intHeight -= trRow1.clientHeight;
				intHeight -= trRow2.clientHeight;
				intHeight -= trRow3.clientHeight;
				intHeight -= trRow4.clientHeight;
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
    <body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onresize="javascript:window_onresize()">
        <form id="frmestate_rs_renyuanjiagou_rela" method="post" runat="server">
            <asp:panel id="panelMain" Runat="server">
                <TABLE cellSpacing="0" cellPadding="0" border="0">
                    <TR>
                        <TD id="trRow1" height="30" class="title" vAlign="middle" align="center">人员之间的领导关系查看窗<asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton></TD>
                    </TR>
                    <tr>
                        <td id="trRow2" height="20" align="center" style="BORDER-BOTTOM: #99cccc 2px solid"><asp:Label ID="lblJCSJ" Runat="server" CssClass="label"></asp:Label></td>
                    </tr>
                    <TR>
                        <TD vAlign="top" align="center">
                            <DIV id="divMain" style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 996px; CLIP: rect(0px 444px 996px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 444px">
                                <TABLE cellSpacing="0" cellPadding="0" border="0" width="100%">
                                    <tr>
                                        <td height="6"></td>
                                    </tr>
                                    <TR>
                                        <td align="center">
                                            <TABLE cellSpacing="0" cellPadding="0" border="0">
                                                <tr>
                                                    <td>
                                                        <iewc:treeview id="tvwMain" runat="server" Font-Size="11pt" Font-Name="宋体" CssClass="label" AutoPostBack="false" DefaultStyle="font-size:11pt;"></iewc:treeview>
                                                    </td>
                                                </tr>
                                            </TABLE>
                                        </td>
                                    </TR>
                                    <tr>
                                        <td height="6"></td>
                                    </tr>
                                </table>
                            </DIV>
                        </TD>
                    </TR>
                    <tr id="trRow3">
						<td align="center" style="BORDER-TOP: #99cccc 2px solid" class="label">
							<!--zengxianglin 2008-11-18 -->
							输入要搜索的人员名称：
							<asp:TextBox ID="txtRYMC" Runat="server" CssClass="textbox" Columns="32"></asp:TextBox>
							<asp:Button id="btnSearch" Runat="server" Text=" 搜索人员 " Font-Size="11pt" Font-Name="宋体" CssClass="button"></asp:Button>
							<!--zengxianglin 2008-11-18 -->
						</td>
                    </tr>
                    <TR id="trRow4">
                        <TD vAlign="middle" align="center" height="36">
                            <asp:Button id="btnOK" Runat="server" Text=" 选值确认 " Font-Size="11pt" Font-Name="宋体" CssClass="button" Height="32px"></asp:Button>
                            <!--zengxianglin 2008-10-14 -->
                            <asp:Button id="btnNull" Runat="server" Text=" 空值确认 " Font-Size="11pt" Font-Name="宋体" CssClass="button" Height="32px"></asp:Button>
                            <!--zengxianglin 2008-10-14 -->
                            <asp:Button id="btnClose" Runat="server" Text=" 返  回 " Font-Size="11pt" Font-Name="宋体" CssClass="button" Height="32px"></asp:Button>
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
                                    <TD style="FONT-SIZE: 32pt; COLOR: black; LINE-HEIGHT: 40pt; FONT-FAMILY: 宋体; LETTER-SPACING: 2pt" align="center"><asp:Label id="lblMessage" Runat="server"></asp:Label><P>&nbsp;&nbsp;</P><P><asp:Button ID="btnGoBack" Runat="server" Font-Size="24pt" Text=" 返回 "></asp:Button></P></TD>
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
                        <uwin:popmessage id="popMessageObject" runat="server" height="48px" width="96px" Visible="False" ActionType="OpenWindow" PopupWindowType="Normal" EnableViewState="False"></uwin:popmessage>
                    </td>
                </tr>
            </table>
        </form>
    </body>
</HTML>
