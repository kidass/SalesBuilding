<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="flow_spyjtx.aspx.vb" Inherits="Josco.JSOA.web.flow_spyjtx"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
    <HEAD>
        <title>填写审批意见或补登领导审批意见窗</title>
        <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
        <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
        <meta name="vs_defaultClientScript" content="JavaScript">
        <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <LINK href="../../stylesGrsw.css" type="text/css" rel="stylesheet">
        <script src="../../scripts/transkey.js"></script>
        <script language="javascript">
		<!--
			function window_onresize() 
			{
				var dblHeight = 0;
				var dblWidth  = 0;
				var strHeight = "";
				var strWidth  = "";
				var dblDeltaY =-380;
				var dblDeltaX =-60;
				
				if (document.all("textareaZSYJ") == null)
					return;
				
				var objControl = null;
				objControl = document.getElementById("textareaZSYJ");
				if (objControl)
				{
					dblHeight = dblDeltaY + document.body.clientHeight; 
					strHeight = parseInt(dblHeight.toString(), 10).toString() + "px";
					dblWidth  = (dblDeltaX + document.body.clientWidth) / 2;
					strWidth = parseInt(dblWidth.toString(), 10).toString() + "px";
					objControl.style.width  = strWidth;
					objControl.style.height = strHeight;
				}

				objControl = document.getElementById("textareaBJYJ");
				if (objControl)
				{
					dblHeight = dblDeltaY + document.body.clientHeight; 
					strHeight = parseInt(dblHeight.toString(), 10).toString() + "px";
					dblWidth  = (dblDeltaX + document.body.clientWidth) / 2;
					strWidth = parseInt(dblWidth.toString(), 10).toString() + "px";
					objControl.style.width  = strWidth;
					objControl.style.height = strHeight;
				}

				objControl = document.getElementById("textareaXZCKRY");
				if (objControl)
				{
					dblWidth = dblDeltaX + document.body.clientWidth;
					strWidth = parseInt(dblWidth.toString(), 10).toString() + "px";
					objControl.style.width  = strWidth;
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
    <body background="../../images/oabk.gif" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onresize="return window_onresize()">
        <form id="frmFLOW_SPYJTX" method="post" runat="server">
            <asp:panel id="panelMain" Runat="server">
                <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                    <TR>
                        <TD colSpan="3" height="3"></TD>
                    </TR>
                    <TR>
                        <TD width="5"></TD>
                        <TD vAlign="top" align="center">
                            <TABLE cellSpacing="0" cellPadding="0" border="0">
                                <TR>
                                    <TD colSpan="3" height="3"></TD>
                                </TR>
                                <TR>
                                    <TD colSpan="3">
                                        <TABLE cellSpacing="0" cellPadding="0" border="0">
                                            <TR>
                                                <TD class="label-text" noWrap align="left"><B>请选择准备补登哪位领导的意见：</B><asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton></TD>
                                                <TD width="100%"><asp:DropDownList id="ddlLDMC" Runat="server" Width="100%" CssClass="textbox-text"  AutoPostBack="True"></asp:DropDownList></TD>
                                            </TR>
                                        </TABLE>
                                    </TD>
                                </TR>
                                <TR>
                                    <TD colSpan="3" height="8"></TD>
                                </TR>
                                <TR>
                                    <TD colSpan="3" align="center" style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid">
                                        <TABLE cellSpacing="0" cellPadding="0" border="0">
                                            <TR>
                                                <TD class="labelNotNull" align="left" colSpan="3" height="26"><B><asp:Label id="lblPrompt" Runat="server" CssClass="labelNotNull" ></asp:Label></B></TD>
                                            </TR>
                                            <TR>
                                                <TD align="left" colSpan="3">
                                                    <TABLE cellSpacing="0" cellPadding="0" border="0">
                                                        <TR>
                                                            <TD class="label-text" noWrap align="right">审批类型：</TD>
                                                            <TD colSpan="3"><asp:RadioButtonList id="rblYJLX" Runat="server" Width="100%"  AutoPostBack="True" RepeatLayout="Table"  RepeatColumns="6" RepeatDirection="Horizontal" CssClass="textbox-text"></asp:RadioButtonList></TD>
                                                        </TR>
                                                        <TR>
                                                            <TD colSpan="4" height="2"></TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="label-text" noWrap align="right">发送人：</TD>
                                                            <TD colSpan="3"><asp:TextBox id="txtFSR" Runat="server" Width="100%" CssClass="textbox-text"  ReadOnly="True"></asp:TextBox></TD>
                                                        </TR>
                                                        <TR>
                                                            <TD colSpan="4" height="2"></TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="label-text" noWrap align="right">审批人：</TD>
                                                            <TD><asp:TextBox id="txtSPR" Runat="server" CssClass="textbox-text"  ReadOnly="True" Columns="34"></asp:TextBox></TD>
                                                            <TD class="label-text" noWrap align="right">补登人：</TD>
                                                            <TD><asp:TextBox id="txtBDR" Runat="server" CssClass="textbox-text"  ReadOnly="True" Columns="34"></asp:TextBox></TD>
                                                        </TR>
                                                        <TR>
                                                            <TD colSpan="4" height="2"></TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="label-text" noWrap align="right">上次批示时间：</TD>
                                                            <TD><asp:TextBox id="txtSCSPSJ" Runat="server" CssClass="textbox-text"  ReadOnly="True" Columns="34"></asp:TextBox></TD>
                                                            <TD class="label-text" noWrap align="right">补登时间：</TD>
                                                            <TD><asp:TextBox id="txtBDSJ" Runat="server" CssClass="textbox-text"  ReadOnly="True" Columns="34"></asp:TextBox></TD>
                                                        </TR>
                                                        <TR>
                                                            <TD colSpan="4" height="2"></TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="label-text" noWrap align="right">上次批示类型：</TD>
                                                            <TD><asp:TextBox id="txtSCSPLX" Runat="server" CssClass="textbox-text"  ReadOnly="True" Columns="34"></asp:TextBox><INPUT id="htxtSFPZ" type="hidden" runat="server"></TD>
                                                            <TD class="labelNotNull" noWrap align="right">&nbsp;领导批示时间：</TD>
                                                            <TD><asp:TextBox id="txtLDPSSJ" Runat="server" CssClass="textbox-text"  Columns="34"></asp:TextBox></TD>
                                                        </TR>
                                                    </TABLE>
                                                </TD>
                                            </TR>
                                        </TABLE>
                                    </TD>
                                </TR>
                                <TR>
                                    <TD colSpan="3" height="8"></TD>
                                </TR>
                                <TR>
                                    <TD colSpan="3">
                                        <TABLE cellSpacing="0" cellPadding="0" border="0">
                                            <TR>
                                                <TD colSpan="3">
                                                    <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                        <TR>
                                                            <TD class="label-text">
                                                                <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                                    <TR>
                                                                        <TD class="title"><B>本次准备填写的正式意见</B></TD>
                                                                        <TD align="right"><asp:Button id="btnSelectZSRY" Runat="server" CssClass="button"  Text="选择人员"></asp:Button><asp:Button id="btnSelectZSYJ" Runat="server" CssClass="button"  Text="常用意见"></asp:Button></TD>
                                                                    </TR>
                                                                </TABLE>
                                                            </TD>
                                                            <TD>&nbsp;</TD>
                                                            <TD class="label-text">
                                                                <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                                    <TR>
                                                                        <TD class="title"><B>本次准备填写的便笺内容</B></TD>
                                                                        <TD align="right"><asp:Button id="btnSelectBJRY" Runat="server" CssClass="button"  Text="选择人员"></asp:Button><asp:Button id="btnSelectBJYJ" Runat="server" CssClass="button"  Text="常用意见"></asp:Button></TD>
                                                                    </TR>
                                                                </TABLE>
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD colSpan="3" height="3"></TD>
                                                        </TR>
                                                        <TR>
                                                            <TD><TEXTAREA class="labelMultiLine" id="textareaZSYJ" runat="server"></TEXTAREA></TD>
                                                            <TD>&nbsp;</TD>
                                                            <TD><TEXTAREA class="labelMultiLine" id="textareaBJYJ" runat="server"></TEXTAREA></TD>
                                                        </TR>
                                                    </TABLE>
                                                </TD>
                                            </TR>
                                        </TABLE>
                                    </TD>
                                </TR>
                                <TR>
                                    <TD colSpan="3" height="3"></TD>
                                </TR>
                                <TR>
                                    <TD colSpan="3">
                                        <TABLE cellSpacing="0" cellPadding="0" border="0">
                                            <TR>
                                                <TD class="label-text" align="left" colSpan="3" height="26">
                                                    <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                        <TR>
                                                            <TD class="label-text"><B>我签署的意见限制以下人员查看</B></TD>
                                                            <TD align="right"><asp:Button id="btnSelectXZRY" Runat="server" CssClass="textbox-text"  Text=" 设置 "></asp:Button></TD>
                                                        </TR>
                                                    </TABLE>
                                                </TD>
                                            </TR>
                                            <TR>
                                                <TD align="left" colSpan="3"><TEXTAREA class="textbox" id="textareaXZCKRY" rows="4" runat="server"></TEXTAREA></TD>
                                            </TR>
                                        </TABLE>
                                    </TD>
                                </TR>
                                <TR>
                                    <TD colSpan="3" height="3"></TD>
                                </TR>
                            </TABLE>
                        </TD>
                        <TD width="5"></TD>
                    </TR>
                    <TR>
                        <TD colSpan="3" height="3"></TD>
                    </TR>
                    <TR>
                        <TD align="center" colSpan="3">
                            <asp:CheckBox id="chkXBBZ" Runat="server" Cssclass="label-text"  Text="文件协办人" Checked="False"></asp:CheckBox>
                            <asp:Button id="btnOK" Runat="server" CssClass="button"  Text=" 确  定 " Height="30px"></asp:Button>
                            <asp:Button id="btnZuofei" Runat="server" CssClass="button"  Text=" 作  废 " Height="30px"></asp:Button>
                            <asp:Button id="btnCancel" Runat="server" CssClass="button"  Text=" 取  消 " Height="30px"></asp:Button>
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
                                    <TD style="FONT-SIZE: 32pt; COLOR: black; LINE-HEIGHT: 40pt; FONT-FAMILY: 宋体; LETTER-SPACING: 2pt" align="center"><asp:Label id="lblMessage" Runat="server"></asp:Label><P>&nbsp;&nbsp;</P><P><INPUT id="btnGoBack" style="FONT-SIZE: 24pt; FONT-FAMILY: 宋体" onclick="javascript:history.back();" type="button" value=" 返回 "></P></TD>
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
                        <input id="htxtYJLX" type="hidden" runat="server">
                        <input id="htxtJJXH" type="hidden" runat="server">
                        <input id="htxtValueC" type="hidden" runat="server">
                        <input id="htxtValueB" type="hidden" runat="server">
                        <input id="htxtValueA" type="hidden" runat="server">
                        <input id="htxtLastYJLX" type="hidden" runat="server">
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
							try {
								var Text;

								oText=null;
								oText=document.getElementById("htxtDivTopBody");
								if (oText != null) document.body.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftBody");
								if (oText != null) document.body.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
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
