<%@ Page Language="vb" AutoEventWireup="false" Codebehind="selectcolumns.aspx.vb" Inherits="Josco.JsKernal.web.selectcolumns" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
    <HEAD>
        <title>选择打印列</title>
        <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
        <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE"/>
        <meta content="JavaScript" name="vs_defaultClientScript"/>
        <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
        <LINK href="../styles01.css" type="text/css" rel="stylesheet"/>
        <script src="../scripts/transkey.js"></script>
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
				intWidth  -= 24;                          //滚动条
				intWidth  -= 2 * 4;                       //左、右空白
				intWidth  -= 16;                          //调整数
				strWidth   = intWidth.toString() + "px";
				
				intHeight  = document.body.clientHeight;  //总高度
				intHeight -= 24;                          //调整数
				intHeight -= trRow01.clientHeight;
				intHeight -= trRow02.clientHeight;
				strHeight  = intHeight.toString() + "px";

				strWidth = divMain.style.width;
				divMain.style.height = strHeight;
				divMain.style.clip = "rect(0px " + strWidth + " " + strHeight + " 0px)";

				var objElem = null;
				objElem = document.getElementById("lstXY");
				if (objElem) {
				    strWidth = objElem.style.width;
				    objElem.style.height = (intHeight - 16 - trRow03.clientHeight).toString() + "px";
				    objElem.style.clip = "rect(0px " + strWidth + " " + strHeight + " 0px)";
				}
				objElem = document.getElementById("lstXZ");
				if (objElem) {
				    strWidth = objElem.style.width;
				    objElem.style.height = (intHeight - 16 - trRow03.clientHeight).toString() + "px";
				    objElem.style.clip = "rect(0px " + strWidth + " " + strHeight + " 0px)";
				}
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
        <form id="frmselectcolumns" method="post" runat="server">
            <asp:panel id="panelMain" Runat="server">
                <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                    <TR id="trRow01">
                        <TD vAlign="top" align="center" height="30" class="title">选择打印输出列<asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton></TD>
                    </TR>
                    <tr>
                        <td align="center">
                            <DIV id="divMain" style="BORDER-TOP: #99cccc 2px solid; OVERFLOW: auto; WIDTH: 900px; CLIP: rect(0px 900px 447px 0px); BORDER-BOTTOM: #99cccc 2px solid; HEIGHT: 447px">
                                <TABLE cellSpacing="0" cellPadding="0" border="0">
                                    <tr id="trRow03">
                                        <td align="left" class="title">能够输出的数据列</td>
                                        <td></td>
                                        <td align="left" class="title">选择输出的数据列</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:ListBox ID="lstXY" runat="server" CssClass="textbox" Width="380px" Height="400px"></asp:ListBox>
                                        </td>
                                        <td align="center">
                                            <asp:Button id="btnAddOneAfter"  Runat="server" CssClass="button" Text=" 后  插 " Height="36px"></asp:Button><br>
                                            <asp:Button id="btnAddOneBefore" Runat="server" CssClass="button" Text=" 前  插 " Height="36px"></asp:Button><br>
                                            <asp:Button id="btnSelAll"       Runat="server" CssClass="button" Text=" 全  选 " Height="36px"></asp:Button><br><br>
                                            <asp:Button id="btnDelOne"       Runat="server" CssClass="button" Text=" 单  退 " Height="36px"></asp:Button><br>
                                            <asp:Button id="btnSelNon"       Runat="server" CssClass="button" Text=" 全  退 " Height="36px"></asp:Button>
                                        </td>
                                        <td>
                                            <asp:ListBox ID="lstXZ" runat="server" CssClass="textbox" Width="380px" Height="400px"></asp:ListBox>
                                        </td>
                                    </tr>
                                </TABLE>
                            </DIV>
                        </td>
                    </tr>
                    <TR id="trRow02">
                        <TD align="center">
                            <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                <TR>
                                    <TD height="4"></TD>
                                </TR>
                                <TR>
                                    <TD align="center">
                                        <asp:Button id="btnOK"     Runat="server" CssClass="button" Text=" 打    印 " Height="36px"></asp:Button>
                                        <asp:Button id="btnClose"  Runat="server" CssClass="button" Text=" 返    回 " Height="36px"></asp:Button>
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
                                    <TD id="tdErrInfo" style="FONT-SIZE: 32pt; COLOR: black; LINE-HEIGHT: 40pt; FONT-FAMILY: 宋体; LETTER-SPACING: 2pt" align="center"><asp:Label id="lblMessage" Runat="server"></asp:Label><P>&nbsp;&nbsp;</P><P><asp:Button id="btnGoBack" Runat="server" Text=" 返回 " Font-Size="24pt"></asp:Button></P></TD>
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
                        <INPUT id="htxtDivLeftMain" type="hidden" runat="server"/>
                        <INPUT id="htxtDivTopMain" type="hidden" runat="server"/>
                        <input id="htxtDivLeftBody" type="hidden" runat="server"/>
                        <input id="htxtDivTopBody" type="hidden" runat="server"/>
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
							    oText = null;
							    oText = document.getElementById("htxtDivTopMain");
							    if (oText != null) oText.value = divMain.scrollTop;
							    oText = null;
							    oText = document.getElementById("htxtDivLeftMain");
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

								oText = null;
								oText = document.getElementById("htxtDivTopMain");
								if (oText != null) divMain.scrollTop = oText.value;
								oText = null;
								oText = document.getElementById("htxtDivLeftMain");
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
