<%@ Page Language="vb" AutoEventWireup="false" Codebehind="estate_es_qrsqt_wuye.aspx.vb" Inherits="Josco.JSOA.web.estate_es_qrsqt_wuye" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
    <HEAD>
        <title>其他确认书物业信息查看与编辑</title>
        <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
        <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
        <meta content="JavaScript" name="vs_defaultClientScript">
        <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <LINK href="../../../styles01.css" type="text/css" rel="stylesheet">
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
				intWidth  -= 24;                          //滚动条
				intWidth  -= 2 * 4;                       //左、右空白
				intWidth  -= 16;                          //调整数
				strWidth   = intWidth.toString() + "px";
				
				intHeight  = document.body.clientHeight;  //总高度
				intHeight -= 24;                          //调整数
				intHeight -= trRow1.clientHeight;
				intHeight -= trRow2.clientHeight;
				strHeight  = intHeight.toString() + "px";
				//if (document.readyState.toLowerCase() == "complete")
                //    alert(strWidth + " " + strHeight);

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
        <form id="frmestate_es_qrsqt_wuye" method="post" runat="server">
            <asp:panel id="panelMain" Runat="server">
                <TABLE cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
                    <TR id="trRow1">
                        <TD align="center">
                            <TABLE cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
                                <TR>
                                    <TD class="title" align="center">其他业务的确认书物业信息查看与编辑<asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton></TD>
                                    <TD width="20">&nbsp;</TD>
                                </TR>
                                <TR>
                                    <TD class="labelNotNull" vAlign="middle" align="right">确认书号：<asp:TextBox id="txtQRSH" runat="server" CssClass="textbox" Columns="14"></asp:TextBox><INPUT id="htxtWYBS" type="hidden" size="1" runat="server" NAME="htxtWYBS"><INPUT id="htxtWYBM" type="hidden" size="1" runat="server" NAME="htxtWYBM"></TD>
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
                                        <TD>
                                            <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                <tr height="26" valign="middle">
                                                    <td class="labelNotNull" align="right">房源编号：</td>
                                                    <TD width="8">&nbsp;</TD>
                                                    <TD align="left" colspan="4"><asp:TextBox id="txtFYBH" runat="server" CssClass="textbox" Width="300px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<span class="label">房产证号：</span><asp:TextBox id="txtFCZH" runat="server" CssClass="textbox" Columns="54"></asp:TextBox></TD>
                                                </tr>
                                                <tr height="26" valign="middle">
                                                    <TD class="labelNotNull" align="right">房屋地址：</TD>
                                                    <TD width="8">&nbsp;</TD>
                                                    <TD align="left" colspan="4"><asp:TextBox id="txtFWDZ" runat="server" CssClass="textbox" Width="300px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<span class="label">产权地址：</span><asp:TextBox id="txtFCZDZ" runat="server" CssClass="textbox" Columns="54"></asp:TextBox></TD>
                                                </TR>
                                                <tr height="26" valign="middle">
                                                    <td class="labelNotNull" align="right">楼盘名称：</td>
                                                    <TD width="8">&nbsp;</TD>
                                                    <TD align="left" colspan="4"><asp:TextBox id="txtLP" runat="server" CssClass="textbox" Width="300px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<span class="labelNotNull">栋别：</span><asp:TextBox id="txtLD" runat="server" CssClass="textbox" Columns="30"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<span class="labelNotNull">单元：</span><asp:TextBox id="txtDY" runat="server" CssClass="textbox" Columns="24"></asp:TextBox></TD>
                                                </tr>
                                                <tr height="26" valign="middle">
                                                    <TD class="labelNotNull" align="right">行政区域：</TD>
                                                    <TD width="8">&nbsp;</TD>
                                                    <TD align="left" colspan="4"><asp:DropDownList id="ddlSZQY" runat="server" CssClass="textbox" Width="300px"></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;<span class="labelNotNull">建筑面积：</span><asp:TextBox id="txtMJ" runat="server" CssClass="textbox" Columns="24"></asp:TextBox>平方米&nbsp;&nbsp;&nbsp;&nbsp;<span class="label">建成时间：</span><asp:TextBox id="txtJCSJ" runat="server" CssClass="textbox" Columns="12"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<span class="label">楼龄：</span><asp:TextBox id="txtLL" runat="server" CssClass="textbox" Columns="8"></asp:TextBox></TD>
                                                </TR>
                                                <tr height="26" valign="middle">
                                                    <TD class="label" align="right">空间类型：</TD>
                                                    <TD width="8">&nbsp;</TD>
                                                    <td align="left">
                                                        <asp:RadioButtonList ID="rblKJLX" runat="server" CssClass="textbox" RepeatColumns="3" RepeatDirection="Vertical" RepeatLayout="Flow">
                                                            <asp:ListItem Value="平层">平层</asp:ListItem>
                                                            <asp:ListItem Value="复式">复式</asp:ListItem>
                                                            <asp:ListItem Value="错层">错层</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                    <TD width="8">&nbsp;</TD>
                                                    <TD class="label" align="right">房屋性质：</td>
                                                    <td align="left">
                                                        <asp:RadioButtonList ID="rblFWXZ" runat="server" CssClass="textbox" RepeatColumns="3" RepeatDirection="Vertical" RepeatLayout="Flow">
                                                            <asp:ListItem Value="房改房">房改房</asp:ListItem>
                                                            <asp:ListItem Value="商品房">商品房</asp:ListItem>
                                                            <asp:ListItem Value="其他">其他</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr height="26" valign="middle">
                                                    <TD class="label" align="right">楼高：</TD>
                                                    <TD width="8">&nbsp;</TD>
                                                    <td align="left" colspan="4">共<asp:TextBox id="txtLG" runat="server" CssClass="textbox" Columns="6"></asp:TextBox>层
                                                    &nbsp;&nbsp;&nbsp;&nbsp;本层有<asp:TextBox id="txtDTSL" runat="server" CssClass="textbox" Columns="6"></asp:TextBox>条梯
                                                    &nbsp;&nbsp;&nbsp;&nbsp;本层有<asp:TextBox id="txtLCHS" runat="server" CssClass="textbox" Columns="6"></asp:TextBox>户
                                                    &nbsp;&nbsp;&nbsp;&nbsp;属楼盘第<asp:TextBox id="txtLPQS" runat="server" CssClass="textbox" Columns="6"></asp:TextBox>期(散盘按第一期)
                                                    </td>
                                                </tr>
                                                <tr height="26" valign="middle">
                                                    <TD class="label" align="right">朝向：</TD>
                                                    <TD width="8">&nbsp;</TD>
                                                    <td align="left" colspan="4">
                                                        <asp:RadioButtonList ID="rblCX" runat="server" CssClass="textbox" RepeatColumns="11" RepeatDirection="Vertical" RepeatLayout="Flow">
                                                            <asp:ListItem Value="正东">正东</asp:ListItem>
                                                            <asp:ListItem Value="正南">正南</asp:ListItem>
                                                            <asp:ListItem Value="正西">正西</asp:ListItem>
                                                            <asp:ListItem Value="正北">正北</asp:ListItem>
                                                            <asp:ListItem Value="东南">东南</asp:ListItem>
                                                            <asp:ListItem Value="西南">西南</asp:ListItem>
                                                            <asp:ListItem Value="东北">东北</asp:ListItem>
                                                            <asp:ListItem Value="西北">西北</asp:ListItem>
                                                            <asp:ListItem Value="西北">南北</asp:ListItem>
                                                            <asp:ListItem Value="西北">东西</asp:ListItem>
                                                            <asp:ListItem Value="西北">三面单边</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                        <asp:DropDownList id="ddlZX" runat="server" CssClass="textbox" Visible="false">
                                                            <asp:ListItem Value=""></asp:ListItem>
                                                            <asp:ListItem Value="正东">正东</asp:ListItem>
                                                            <asp:ListItem Value="正南">正南</asp:ListItem>
                                                            <asp:ListItem Value="正西">正西</asp:ListItem>
                                                            <asp:ListItem Value="正北">正北</asp:ListItem>
                                                            <asp:ListItem Value="东南">东南</asp:ListItem>
                                                            <asp:ListItem Value="西南">西南</asp:ListItem>
                                                            <asp:ListItem Value="东北">东北</asp:ListItem>
                                                            <asp:ListItem Value="西北">西北</asp:ListItem>
                                                            <asp:ListItem Value="西北">南北</asp:ListItem>
                                                            <asp:ListItem Value="西北">东西</asp:ListItem>
                                                            <asp:ListItem Value="西北">三面单边</asp:ListItem>
                                                        </asp:DropDownList>                                                  
                                                    </td>
                                                </tr>
                                                <tr height="26" valign="middle">
                                                    <TD class="labelNotNull" align="right">物业属性：</TD>
                                                    <TD width="8">&nbsp;</TD>
                                                    <TD align="left" colspan="4">
                                                        <asp:RadioButtonList ID="rblWYSX" runat="server" CssClass="textbox" RepeatColumns="9" RepeatDirection="Vertical" RepeatLayout="Flow"></asp:RadioButtonList>
                                                        <asp:DropDownList id="ddlWYXZ" runat="server" CssClass="textbox" Visible="false"></asp:DropDownList>
                                                    </TD>
                                                </TR>
                                                <tr height="26" valign="middle">
                                                    <TD class="label" align="right">装修档次：</TD>
                                                    <TD width="8">&nbsp;</TD>
                                                    <td align="left">
                                                        <asp:RadioButtonList ID="rblZXDC" runat="server" CssClass="textbox" RepeatColumns="3" RepeatDirection="Vertical" RepeatLayout="Flow">
                                                            <asp:ListItem Value="普通">普通</asp:ListItem>
                                                            <asp:ListItem Value="豪华">豪华</asp:ListItem>
                                                            <asp:ListItem Value="毛坯">毛坯</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>                                                      
                                                    <TD width="8">&nbsp;</TD>
                                                    <TD class="label" align="right">装修年限：</td>
                                                    <td align="left">
                                                        <asp:RadioButtonList ID="rblZXNX" runat="server" CssClass="textbox" RepeatColumns="3" RepeatDirection="Vertical" RepeatLayout="Flow">
                                                            <asp:ListItem Value="普通">普通</asp:ListItem>
                                                            <asp:ListItem Value="新">新</asp:ListItem>
                                                            <asp:ListItem Value="旧">旧</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr height="26" valign="middle">
                                                    <TD class="label" align="right">噪音影响：</TD>
                                                    <TD width="8">&nbsp;</TD>
                                                    <td align="left">
                                                        <asp:RadioButtonList ID="rblZYYX" runat="server" CssClass="textbox" RepeatColumns="3" RepeatDirection="Vertical" RepeatLayout="Flow">
                                                            <asp:ListItem Value="安静">安静</asp:ListItem>
                                                            <asp:ListItem Value="普通">普通</asp:ListItem>
                                                            <asp:ListItem Value="嘈杂">嘈杂</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                    <TD width="8">&nbsp;</TD>
                                                    <TD class="label" align="right">家具设备：</td>
                                                    <td align="left">
                                                        <asp:RadioButtonList ID="rblJJSB" runat="server" CssClass="textbox" RepeatColumns="3" RepeatDirection="Vertical" RepeatLayout="Flow">
                                                            <asp:ListItem Value="普通">普通</asp:ListItem>
                                                            <asp:ListItem Value="豪华">豪华</asp:ListItem>
                                                            <asp:ListItem Value="吉屋">吉屋</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr height="26" valign="middle">
                                                    <TD class="label" align="right">楼宇交通：</TD>
                                                    <TD width="8">&nbsp;</TD>
                                                    <td align="left">
                                                        <asp:RadioButtonList ID="rblLYJT" runat="server" CssClass="textbox" RepeatColumns="3" RepeatDirection="Vertical" RepeatLayout="Flow">
                                                            <asp:ListItem Value="电梯">电梯</asp:ListItem>
                                                            <asp:ListItem Value="楼梯">楼梯</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                    <TD width="8">&nbsp;</TD>
                                                    <TD class="label" align="right">间隔评价：</td>
                                                    <td align="left">
                                                        <asp:RadioButtonList ID="rblFWJG" runat="server" CssClass="textbox" RepeatColumns="3" RepeatDirection="Vertical" RepeatLayout="Flow">
                                                            <asp:ListItem Value="普通">普通</asp:ListItem>
                                                            <asp:ListItem Value="优良">优良</asp:ListItem>
                                                            <asp:ListItem Value="较差">较差</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr height="26" valign="middle">
                                                    <TD class="label" align="right">景观类型：</TD>
                                                    <TD width="8">&nbsp;</TD>
                                                    <td align="left" colspan="4">
                                                        <asp:RadioButtonList ID="rblJGLX" runat="server" CssClass="textbox" RepeatColumns="9" RepeatDirection="Vertical" RepeatLayout="Flow">
                                                            <asp:ListItem Value="园林">园林</asp:ListItem>
                                                            <asp:ListItem Value="一线江景">一线江景</asp:ListItem>
                                                            <asp:ListItem Value="二线江景">二线江景</asp:ListItem>
                                                            <asp:ListItem Value="山景">山景</asp:ListItem>
                                                            <asp:ListItem Value="公园">公园</asp:ListItem>
                                                            <asp:ListItem Value="马路">马路</asp:ListItem>
                                                            <asp:ListItem Value="楼景">楼景</asp:ListItem>
                                                            <asp:ListItem Value="不良景观">不良景观</asp:ListItem>
                                                            <asp:ListItem Value="标志性建筑">标志性建筑</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr height="26" valign="middle">
                                                    <TD class="label" align="right"></TD>
                                                    <TD width="8">&nbsp;</TD>
                                                    <TD class="label" align="left" colspan="4">拥有上述景观的房间：<asp:TextBox id="txtJGFS" runat="server" CssClass="textbox" Columns="4"></asp:TextBox>个&nbsp;&nbsp;&nbsp;&nbsp;所在楼层：第<asp:TextBox id="txtLC" runat="server" CssClass="textbox" Columns="8"></asp:TextBox>层&nbsp;&nbsp;&nbsp;&nbsp;卧室数量：<asp:TextBox id="txtWSSL" runat="server" CssClass="textbox" Columns="4"></asp:TextBox>个&nbsp;&nbsp;&nbsp;&nbsp;阳台数量：<asp:TextBox id="txtYTSL" runat="server" CssClass="textbox" Columns="4"></asp:TextBox>个</TD>
                                                </TR>
                                                <tr height="26" valign="middle">
                                                    <TD class="labelNotNull" align="right">价格：</TD>
                                                    <TD width="8">&nbsp;</TD>
                                                    <TD align="left" colspan="4"><asp:TextBox id="txtJYJE" runat="server" CssClass="textbox" Columns="24"></asp:TextBox>元人民币</TD>
                                                </TR>
                                                <tr height="26" valign="middle">
                                                    <TD class="label" align="right">户型：</TD>
                                                    <TD width="8">&nbsp;</TD>
                                                    <TD align="left" colspan="4"><asp:DropDownList id="ddlJG" runat="server" CssClass="textbox" Width="300px"></asp:DropDownList></TD>
                                                </TR>
                                                <TR>
                                                    <TD class="label" align="right">备注：</TD>
                                                    <TD width="8">&nbsp;</TD>
                                                    <TD align="left" colspan="4"><asp:TextBox id="txtBZXX" runat="server" Width="100%" CssClass="textbox" Rows="4" TextMode="MultiLine"></asp:TextBox></TD>
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
                            <asp:button id="btnOK" Runat="server" CssClass="button" Height="36px" Text=" 确    定 "></asp:button>
                            <asp:button id="btnCancel" Runat="server" CssClass="button" Height="36px" Text=" 取    消 "></asp:button>
                            <asp:button id="btnClose" Runat="server" CssClass="button" Height="36px" Text=" 返    回 "></asp:button>
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
                                    <TD id="tdErrInfo" style="FONT-SIZE: 32pt; COLOR: black; LINE-HEIGHT: 40pt; FONT-FAMILY: 宋体; LETTER-SPACING: 2pt" align="center"><asp:Label id="lblMessage" Runat="server"></asp:Label><P>&nbsp;&nbsp;</P><P><asp:Button ID="btnGoBack" Runat="server" Font-Size="24pt" Text=" 返回 "></asp:Button></P></TD>
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
                        <INPUT id="htxtDivLeftMain" type="hidden" runat="server" NAME="htxtDivLeftMain">
                        <INPUT id="htxtDivTopMain" type="hidden" runat="server" NAME="htxtDivTopMain">
                        <INPUT id="htxtDivLeftBody" type="hidden" runat="server" NAME="htxtDivLeftBody">
                        <INPUT id="htxtDivTopBody" type="hidden" runat="server" NAME="htxtDivTopBody">
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
