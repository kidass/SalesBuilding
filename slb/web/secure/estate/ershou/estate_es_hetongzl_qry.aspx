<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="estate_es_hetongzl_qry.aspx.vb" Inherits="Josco.JSOA.web.estate_es_hetongzl_qry" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
    <HEAD>
        <title>租赁合同全屏查询</title>
        <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
        <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE"/>
        <meta content="JavaScript" name="vs_defaultClientScript"/>
        <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
        <LINK href="../../../styles01.css" type="text/css" rel="stylesheet"/>
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
    <body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onresize="return window_onresize()">
        <form id="frmestate_es_hetongzl_qry" method="post" runat="server">
            <asp:panel id="panelMain" Runat="server">
                <TABLE cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
                    <TR id="trRow1">
                        <TD align="center">
                            <TABLE cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
                                <TR>
                                    <TD class="title" align="center">房屋租赁合同全屏查询<asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton></TD>
                                    <TD width="20">&nbsp;</TD>
                                </TR>
                            </TABLE>
                        </TD>
                    </TR>
                    <TR>
                        <TD align="center">
                            <DIV id="divMain" style="BORDER-TOP: #99cccc 2px solid; OVERFLOW: auto; WIDTH: 964px; CLIP: rect(0px 964px 447px 0px); BORDER-BOTTOM: #99cccc 2px solid; HEIGHT: 447px">
                                <TABLE cellSpacing="0" cellPadding="0" border="0">
                                    <tr>
                                        <td align="left">
                                            <TABLE cellSpacing="0" cellPadding="0" border="0" width="100%">
                                                <tr>
                                                    <td align="left">确认书号：<asp:TextBox id="txtQRSH" runat="server" Columns="28" CssClass="textbox"></asp:TextBox></td>
                                                    <td align="left">合同编号：<asp:TextBox id="txtHTBH" runat="server" Columns="28" CssClass="textbox"></asp:TextBox></td>
                                                    <td align="left">客源编号：<asp:TextBox id="txtKYBH" runat="server" Columns="28" CssClass="textbox"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="left">认购日期：<asp:TextBox id="txtDGRQMin" runat="server" CssClass="textbox" Columns="10"></asp:TextBox>-<asp:TextBox id="txtDGRQMax" runat="server" CssClass="textbox" Columns="10"></asp:TextBox></td>
                                                    <td align="left">合同日期：<asp:TextBox id="txtHTRQMin" runat="server" CssClass="textbox" Columns="10"></asp:TextBox>-<asp:TextBox id="txtHTRQMax" runat="server" CssClass="textbox" Columns="10"></asp:TextBox></td>
                                                    <td align="left">统计日期：<asp:TextBox id="txtTJRQMin" runat="server" CssClass="textbox" Columns="10"></asp:TextBox>-<asp:TextBox id="txtTJRQMax" runat="server" CssClass="textbox" Columns="10"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="left">结案日期：<asp:TextBox id="txtJARQMin" runat="server" CssClass="textbox" Columns="10"></asp:TextBox>-<asp:TextBox id="txtJARQMax" runat="server" CssClass="textbox" Columns="10"></asp:TextBox></td>
                                                    <TD align="left">合同结案：<asp:CheckBoxList id="cblHTJA" Runat="server" CssClass="textbox" RepeatColumns="3" RepeatDirection="Vertical" RepeatLayout="Flow">
                                                            <asp:ListItem Value="0">合同未结</asp:ListItem>
                                                            <asp:ListItem Value="2">合同结案</asp:ListItem>
                                                        </asp:CheckBoxList></td>
                                                    <TD align="left">合同审核：<asp:CheckBoxList id="cblHTSH" Runat="server" CssClass="textbox" RepeatColumns="3" RepeatDirection="Vertical" RepeatLayout="Flow">
                                                            <asp:ListItem Value="0">合同未审</asp:ListItem>
                                                            <asp:ListItem Value="1">合同已审</asp:ListItem>
                                                        </asp:CheckBoxList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <TD align="left"></td>
                                                    <TD align="left">合同解除：<asp:CheckBoxList id="cblHTJC" Runat="server" CssClass="textbox" RepeatColumns="3" RepeatDirection="Vertical" RepeatLayout="Flow">
                                                            <asp:ListItem Value="0">正常合同</asp:ListItem>
                                                            <asp:ListItem Value="1">解除合同</asp:ListItem>
                                                        </asp:CheckBoxList></td>
                                                    <TD align="left">合同坏账：<asp:CheckBoxList id="cblHTHZ" Runat="server" CssClass="textbox" RepeatColumns="3" RepeatDirection="Vertical" RepeatLayout="Flow">
                                                            <asp:ListItem Value="0">没有坏账</asp:ListItem>
                                                            <asp:ListItem Value="2">存在坏账</asp:ListItem>
                                                        </asp:CheckBoxList>
                                                     </td>
                                                </tr>
                                            </TABLE>
                                        </td>
                                    </tr>
                                    <TR>
                                        <TD class="label" align="left" bgColor="#ccff99"><B>&gt;&gt;&gt;&gt;基本资料</B></TD>
                                    </TR>
                                    <tr>
                                        <td>
                                            <table cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                 <tr>
                                                    <td align="left">查册地址：<asp:TextBox id="txtCCDZ" runat="server" Columns="60" CssClass="textbox"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;查册费：<asp:TextBox id="txtCCFMin" runat="server" Columns="14" CssClass="textbox"></asp:TextBox>-<asp:TextBox id="txtCCFMax" runat="server" Columns="14" CssClass="textbox"></asp:TextBox></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <TR>
                                        <TD class="label" align="left" bgColor="#ccff99"><B>&gt;&gt;&gt;&gt;佣金资料</B></TD>
                                    </TR>
                                    <tr>
                                        <td>
                                            <table cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                <tr>
                                                    <td align="left">月租金额：<asp:TextBox id="txtJYYZJMin" runat="server" Columns="16" CssClass="textbox"></asp:TextBox>-<asp:TextBox id="txtJYYZJMax" runat="server" Columns="16" CssClass="textbox"></asp:TextBox></td>
                                                    <td align="left">业主佣金：<asp:TextBox id="txtJFDLFMin" runat="server" Columns="16" CssClass="textbox"></asp:TextBox>-<asp:TextBox id="txtJFDLFMax" runat="server" Columns="16" CssClass="textbox"></asp:TextBox></td>
                                                    <td align="left">客户佣金：<asp:TextBox id="txtYFDLFMin" runat="server" Columns="16" CssClass="textbox"></asp:TextBox>-<asp:TextBox id="txtYFDLFMax" runat="server" Columns="16" CssClass="textbox"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="left">租金总额：<asp:TextBox id="txtJYZZJMin" runat="server" Columns="16" CssClass="textbox"></asp:TextBox>-<asp:TextBox id="txtJYZZJMax" runat="server" Columns="16" CssClass="textbox"></asp:TextBox></td>
                                                    <td align="left">兴业实收：<asp:TextBox id="txtSSYJMin" runat="server" Columns="16" CssClass="textbox"></asp:TextBox>-<asp:TextBox id="txtSSYJMax" runat="server" Columns="16" CssClass="textbox"></asp:TextBox></td>
                                                    <td align="left">合作佣金：<asp:TextBox id="txtHZYJMin" runat="server" Columns="16" CssClass="textbox"></asp:TextBox>-<asp:TextBox id="txtHZYJMax" runat="server" Columns="16" CssClass="textbox"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="left">代理折扣：<asp:TextBox id="txtDLFZKMin" runat="server" CssClass="textbox" Columns="16"></asp:TextBox>-<asp:TextBox id="txtDLFZKMax" runat="server" CssClass="textbox" Columns="16"></asp:TextBox></td>
                                                    <td align="left">按揭返还：<asp:TextBox id="txtAJFHMin" runat="server" CssClass="textbox" Columns="16"></asp:TextBox>-<asp:TextBox id="txtAJFHMax" runat="server" CssClass="textbox" Columns="16"></asp:TextBox></td>
                                                    <td align="left"></td>
                                                </tr>
                                                <tr>
                                                    <td align="left">解除日期：<asp:TextBox id="txtJCRQMin" runat="server" Columns="16" CssClass="textbox"></asp:TextBox>-<asp:TextBox id="txtJCRQMax" runat="server" Columns="16" CssClass="textbox"></asp:TextBox></td>
                                                    <td align="left">坏账金额：<asp:TextBox id="txtHZJEMin" runat="server" Columns="16" CssClass="textbox"></asp:TextBox>-<asp:TextBox id="txtHZJEMax" runat="server" Columns="16" CssClass="textbox"></asp:TextBox></td>
                                                    <td align="left">坏账日期：<asp:TextBox id="txtHZRQMin" runat="server" Columns="16" CssClass="textbox"></asp:TextBox>-<asp:TextBox id="txtHZRQMax" runat="server" Columns="16" CssClass="textbox"></asp:TextBox></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <TR>
                                        <TD class="label" align="left" bgColor="#ccff99"><B>&gt;&gt;&gt;&gt;物业楼宇</B></TD>
                                    </TR>
                                    <TR>
                                        <TD>
                                            <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                <tr>
                                                    <td class="label" align="right">房源编号：</td>
                                                    <TD width="8">&nbsp;</TD>
                                                    <TD align="left" colspan="4"><asp:TextBox id="txtFYBH" runat="server" CssClass="textbox" Width="300px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;房产证号：<asp:TextBox id="txtFCZH" runat="server" CssClass="textbox" Columns="50"></asp:TextBox></TD>
                                                </tr>
                                                <tr>
                                                    <TD class="label" align="right">房屋地址：</TD>
                                                    <TD width="8">&nbsp;</TD>
                                                    <TD align="left" colspan="4"><asp:TextBox id="txtFWDZ" runat="server" CssClass="textbox" Width="300px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;产权地址：<asp:TextBox id="txtFCZDZ" runat="server" CssClass="textbox" Columns="50"></asp:TextBox></TD>
                                                </TR>
                                                <tr>
                                                    <td class="label" align="right">楼盘名称：</td>
                                                    <TD width="8">&nbsp;</TD>
                                                    <TD align="left" colspan="4"><asp:TextBox id="txtLP" runat="server" CssClass="textbox" Width="300px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;楼盘栋别：<asp:TextBox id="txtLD" runat="server" CssClass="textbox" Columns="50"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;单元：<asp:TextBox id="txtDY" runat="server" CssClass="textbox" Columns="24"></asp:TextBox></TD>
                                                </tr>
                                                <tr>
                                                    <TD class="label" align="right">行政区域：</TD>
                                                    <TD width="8">&nbsp;</TD>
                                                    <TD align="left" colspan="4"><asp:DropDownList id="ddlSZQY" runat="server" CssClass="textbox" Width="320px" AutoPostBack="true"></asp:DropDownList><asp:TextBox id="txtSZQYList" runat="server" CssClass="textbox" ReadOnly="true" Width="530px"></asp:TextBox></TD>
                                                </TR>
                                                <tr>
                                                    <TD class="label" align="right">建筑面积：</TD>
                                                    <TD width="8">&nbsp;</TD>
                                                    <TD align="left" colspan="4"><asp:TextBox id="txtMJMin" runat="server" CssClass="textbox" Columns="16"></asp:TextBox>-<asp:TextBox id="txtMJMax" runat="server" CssClass="textbox" Columns="16"></asp:TextBox>平方米&nbsp;&nbsp;&nbsp;&nbsp;建成时间：<asp:TextBox id="txtJCSJMin" runat="server" CssClass="textbox" Columns="12"></asp:TextBox>-<asp:TextBox id="txtJCSJMax" runat="server" CssClass="textbox" Columns="12"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;楼龄：<asp:TextBox id="txtLLMin" runat="server" CssClass="textbox" Columns="6"></asp:TextBox>-<asp:TextBox id="txtLLMax" runat="server" CssClass="textbox" Columns="6"></asp:TextBox></TD>
                                                </tr>
                                                <tr>
                                                    <TD class="label" align="right">空间类型：</TD>
                                                    <TD width="8">&nbsp;</TD>
                                                    <td align="left">
                                                        <asp:CheckBoxList ID="cblKJLX" runat="server" CssClass="textbox" RepeatColumns="3" RepeatDirection="Vertical" RepeatLayout="Flow">
                                                            <asp:ListItem Value="平层">平层</asp:ListItem>
                                                            <asp:ListItem Value="复式">复式</asp:ListItem>
                                                            <asp:ListItem Value="错层">错层</asp:ListItem>
                                                        </asp:CheckBoxList>
                                                    </td>
                                                    <TD width="8">&nbsp;</TD>
                                                    <TD class="label" align="right">房屋性质：</td>
                                                    <td align="left">
                                                        <asp:CheckBoxList ID="cblFWXZ" runat="server" CssClass="textbox" RepeatColumns="3" RepeatDirection="Vertical" RepeatLayout="Flow">
                                                            <asp:ListItem Value="房改房">房改房</asp:ListItem>
                                                            <asp:ListItem Value="商品房">商品房</asp:ListItem>
                                                            <asp:ListItem Value="其他">其他</asp:ListItem>
                                                        </asp:CheckBoxList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <TD class="label" align="right">楼高：</TD>
                                                    <TD width="8">&nbsp;</TD>
                                                    <td align="left" colspan="4">共<asp:TextBox id="txtLGMin" runat="server" CssClass="textbox" Columns="4"></asp:TextBox>-<asp:TextBox id="txtLGMax" runat="server" CssClass="textbox" Columns="4"></asp:TextBox>层
                                                    &nbsp;&nbsp;&nbsp;&nbsp;本层有<asp:TextBox id="txtDTSLMin" runat="server" CssClass="textbox" Columns="4"></asp:TextBox>-<asp:TextBox id="txtDTSLMax" runat="server" CssClass="textbox" Columns="4"></asp:TextBox>条梯
                                                    &nbsp;&nbsp;&nbsp;&nbsp;本层有<asp:TextBox id="txtLCHSMin" runat="server" CssClass="textbox" Columns="4"></asp:TextBox>-<asp:TextBox id="txtLCHSMax" runat="server" CssClass="textbox" Columns="4"></asp:TextBox>户
                                                    &nbsp;&nbsp;&nbsp;&nbsp;属楼盘第<asp:TextBox id="txtLPQSMin" runat="server" CssClass="textbox" Columns="4"></asp:TextBox>-<asp:TextBox id="txtLPQSMax" runat="server" CssClass="textbox" Columns="4"></asp:TextBox>期
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <TD class="label" align="right">朝向：</TD>
                                                    <TD width="8">&nbsp;</TD>
                                                    <td align="left" colspan="4">
                                                        <asp:CheckBoxList ID="cblCX" runat="server" CssClass="textbox" RepeatColumns="11" RepeatDirection="Vertical" RepeatLayout="Flow">
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
                                                        </asp:CheckBoxList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <TD class="label" align="right">物业属性：</TD>
                                                    <TD width="8">&nbsp;</TD>
                                                    <TD align="left" colspan="4">
                                                        <asp:CheckBoxList ID="cblWYSX" runat="server" CssClass="textbox" RepeatColumns="9" RepeatDirection="Vertical" RepeatLayout="Flow"></asp:CheckBoxList>
                                                    </TD>
                                                </TR>
                                                <tr>
                                                    <TD class="label" align="right">装修档次：</TD>
                                                    <TD width="8">&nbsp;</TD>
                                                    <td align="left">
                                                        <asp:CheckBoxList ID="cblZXDC" runat="server" CssClass="textbox" RepeatColumns="3" RepeatDirection="Vertical" RepeatLayout="Flow">
                                                            <asp:ListItem Value="普通">普通</asp:ListItem>
                                                            <asp:ListItem Value="豪华">豪华</asp:ListItem>
                                                            <asp:ListItem Value="毛坯">毛坯</asp:ListItem>
                                                        </asp:CheckBoxList>
                                                    </td>                                                      
                                                    <TD width="8">&nbsp;</TD>
                                                    <TD class="label" align="right">装修年限：</td>
                                                    <td align="left">
                                                        <asp:CheckBoxList ID="cblZXNX" runat="server" CssClass="textbox" RepeatColumns="3" RepeatDirection="Vertical" RepeatLayout="Flow">
                                                            <asp:ListItem Value="普通">普通</asp:ListItem>
                                                            <asp:ListItem Value="新">新</asp:ListItem>
                                                            <asp:ListItem Value="旧">旧</asp:ListItem>
                                                        </asp:CheckBoxList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <TD class="label" align="right">噪音影响：</TD>
                                                    <TD width="8">&nbsp;</TD>
                                                    <td align="left">
                                                        <asp:CheckBoxList ID="cblZYYX" runat="server" CssClass="textbox" RepeatColumns="3" RepeatDirection="Vertical" RepeatLayout="Flow">
                                                            <asp:ListItem Value="安静">安静</asp:ListItem>
                                                            <asp:ListItem Value="普通">普通</asp:ListItem>
                                                            <asp:ListItem Value="嘈杂">嘈杂</asp:ListItem>
                                                        </asp:CheckBoxList>
                                                    </td>
                                                    <TD width="8">&nbsp;</TD>
                                                    <TD class="label" align="right">家具设备：</td>
                                                    <td align="left">
                                                        <asp:CheckBoxList ID="cblJJSB" runat="server" CssClass="textbox" RepeatColumns="3" RepeatDirection="Vertical" RepeatLayout="Flow">
                                                            <asp:ListItem Value="普通">普通</asp:ListItem>
                                                            <asp:ListItem Value="豪华">豪华</asp:ListItem>
                                                            <asp:ListItem Value="吉屋">吉屋</asp:ListItem>
                                                        </asp:CheckBoxList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <TD class="label" align="right">楼宇交通：</TD>
                                                    <TD width="8">&nbsp;</TD>
                                                    <td align="left">
                                                        <asp:CheckBoxList ID="cblLYJT" runat="server" CssClass="textbox" RepeatColumns="3" RepeatDirection="Vertical" RepeatLayout="Flow">
                                                            <asp:ListItem Value="电梯">电梯</asp:ListItem>
                                                            <asp:ListItem Value="楼梯">楼梯</asp:ListItem>
                                                        </asp:CheckBoxList>
                                                    </td>
                                                    <TD width="8">&nbsp;</TD>
                                                    <TD class="label" align="right">间隔评价：</td>
                                                    <td align="left">
                                                        <asp:CheckBoxList ID="cblFWJG" runat="server" CssClass="textbox" RepeatColumns="3" RepeatDirection="Vertical" RepeatLayout="Flow">
                                                            <asp:ListItem Value="普通">普通</asp:ListItem>
                                                            <asp:ListItem Value="优良">优良</asp:ListItem>
                                                            <asp:ListItem Value="较差">较差</asp:ListItem>
                                                        </asp:CheckBoxList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <TD class="label" align="right">景观类型：</TD>
                                                    <TD width="8">&nbsp;</TD>
                                                    <td align="left" colspan="4">
                                                        <asp:CheckBoxList ID="cblJGLX" runat="server" CssClass="textbox" RepeatColumns="9" RepeatDirection="Vertical" RepeatLayout="Flow">
                                                            <asp:ListItem Value="园林">园林</asp:ListItem>
                                                            <asp:ListItem Value="一线江景">一线江景</asp:ListItem>
                                                            <asp:ListItem Value="二线江景">二线江景</asp:ListItem>
                                                            <asp:ListItem Value="山景">山景</asp:ListItem>
                                                            <asp:ListItem Value="公园">公园</asp:ListItem>
                                                            <asp:ListItem Value="马路">马路</asp:ListItem>
                                                            <asp:ListItem Value="楼景">楼景</asp:ListItem>
                                                            <asp:ListItem Value="不良景观">不良景观</asp:ListItem>
                                                            <asp:ListItem Value="标志性建筑">标志性建筑</asp:ListItem>
                                                        </asp:CheckBoxList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <TD class="label" align="right"></TD>
                                                    <TD width="8">&nbsp;</TD>
                                                    <TD class="label" align="left" colspan="4">拥有上述景观的房间：<asp:TextBox id="txtJGFSMin" runat="server" CssClass="textbox" Columns="4"></asp:TextBox>-<asp:TextBox id="txtJGFSMax" runat="server" CssClass="textbox" Columns="4"></asp:TextBox>个&nbsp;&nbsp;&nbsp;&nbsp;所在楼层：第<asp:TextBox id="txtLCMin" runat="server" CssClass="textbox" Columns="4"></asp:TextBox>-<asp:TextBox id="txtLCMax" runat="server" CssClass="textbox" Columns="4"></asp:TextBox>层&nbsp;&nbsp;&nbsp;&nbsp;卧室数量：<asp:TextBox id="txtWSSLMin" runat="server" CssClass="textbox" Columns="4"></asp:TextBox>-<asp:TextBox id="txtWSSLMax" runat="server" CssClass="textbox" Columns="4"></asp:TextBox>个&nbsp;&nbsp;&nbsp;&nbsp;阳台数量：<asp:TextBox id="txtYTSLMin" runat="server" CssClass="textbox" Columns="4"></asp:TextBox>-<asp:TextBox id="txtYTSLMax" runat="server" CssClass="textbox" Columns="4"></asp:TextBox>个</TD>
                                                </TR>
                                                <tr>
                                                    <TD class="label" align="right">月租金：</TD>
                                                    <TD width="8">&nbsp;</TD>
                                                    <TD align="left" colspan="4"><asp:TextBox id="txtYZJEMin" runat="server" CssClass="textbox" Columns="24"></asp:TextBox>-<asp:TextBox id="txtYZJEMax" runat="server" CssClass="textbox" Columns="24"></asp:TextBox>元人民币</TD>
                                                </TR>
                                                <tr>
                                                    <TD class="label" align="right">户型：</TD>
                                                    <TD width="8">&nbsp;</TD>
                                                    <TD align="left" colspan="4"><asp:DropDownList id="ddlJG" runat="server" CssClass="textbox" Width="320px" AutoPostBack="true"></asp:DropDownList><asp:TextBox id="txtJGList" runat="server" CssClass="textbox" ReadOnly="true" Width="530px"></asp:TextBox></TD>
                                                </TR>
                                            </TABLE>
                                        </TD>
                                    </TR>
                                    <TR>
                                        <TD class="label" align="left" bgColor="#ccff99"><B>&gt;&gt;&gt;&gt;交易详情</B></TD>
                                    </TR>
                                    <TR>
                                        <TD>
                                            <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                <tr>
                                                    <td align="left">租期：从<asp:TextBox id="txtZLKSMin" runat="server" Columns="12" CssClass="textbox"></asp:TextBox>-<asp:TextBox id="txtZLKSMax" runat="server" Columns="12" CssClass="textbox"></asp:TextBox>至<asp:TextBox id="txtZLJSMin" runat="server" Columns="12" CssClass="textbox"></asp:TextBox>-<asp:TextBox id="txtZLJSMax" runat="server" Columns="12" CssClass="textbox"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="left"><span style="width:96px">水、电、煤气：</span>
                                                        <asp:CheckBoxList id="cblSDMQ" Runat="server" CssClass="textbox" RepeatLayout="Flow" RepeatDirection="Vertical" RepeatColumns="2">
                                                            <asp:ListItem Value="包括">包括</asp:ListItem>
                                                            <asp:ListItem Value="不包括">不包括</asp:ListItem>
                                                        </asp:CheckBoxList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="width:84px">电话费：</span>
                                                        <asp:CheckBoxList id="cblDHF" Runat="server" CssClass="textbox" RepeatLayout="Flow" RepeatDirection="Vertical" RepeatColumns="2">
                                                            <asp:ListItem Value="包括">包括</asp:ListItem>
                                                            <asp:ListItem Value="不包括">不包括</asp:ListItem>
                                                        </asp:CheckBoxList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left"><span style="width:96px">管理费：</span>
                                                        <asp:CheckBoxList id="cblGLF" Runat="server" CssClass="textbox" RepeatLayout="Flow" RepeatDirection="Vertical" RepeatColumns="2">
                                                            <asp:ListItem Value="包括">包括</asp:ListItem>
                                                            <asp:ListItem Value="不包括">不包括</asp:ListItem>
                                                        </asp:CheckBoxList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="width:84px">租赁发票：</span>
                                                        <asp:CheckBoxList id="cblZLFP" Runat="server" CssClass="textbox" RepeatLayout="Flow" RepeatDirection="Vertical" RepeatColumns="2">
                                                            <asp:ListItem Value="包括">包括</asp:ListItem>
                                                            <asp:ListItem Value="不包括">不包括</asp:ListItem>
                                                        </asp:CheckBoxList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">业主名称：<asp:TextBox id="txtJFMC" runat="server" CssClass="textbox" Columns="36"></asp:TextBox>&nbsp;&nbsp;代理人：<asp:TextBox id="txtJFDLR" runat="server" Columns="24" CssClass="textbox"></asp:TextBox>&nbsp;&nbsp;证件号码：<asp:CheckBoxList id="cblJFZJLB" runat="server" CssClass="textbox" RepeatColumns="3" RepeatLayout="Flow" RepeatDirection="Vertical">
                                                            <asp:ListItem Value="0">身份证</asp:ListItem>
                                                            <asp:ListItem Value="1">护照</asp:ListItem>
                                                            <asp:ListItem Value="2">营业执照</asp:ListItem>
                                                        </asp:CheckBoxList>&nbsp;&nbsp;<asp:TextBox id="txtJFZZHM" Runat="server" CssClass="textbox" Columns="28"></asp:TextBox>
                                                    </td>
                                                </TR>
                                                <tr>
                                                    <td align="left">剩余物业：<asp:CheckBoxList id="cblSYWY" Runat="server" CssClass="textbox" RepeatLayout="Flow" RepeatDirection="Vertical" RepeatColumns="3">
                                                            <asp:ListItem Value="1套">1套</asp:ListItem>
                                                            <asp:ListItem Value="2-3套">2-3套</asp:ListItem>
                                                            <asp:ListItem Value="4套以上">4套以上</asp:ListItem>
                                                        </asp:CheckBoxList>
                                                    </td>
                                                </TR>
                                                <tr>
                                                    <td align="left">业主电话：<asp:TextBox id="txtJFLXDH" Runat="server" CssClass="textbox" Columns="48"></asp:TextBox>&nbsp;&nbsp;地区：<asp:CheckBoxList ID="cblYZQC" runat="server" CssClass="textbox" RepeatColumns="2" RepeatLayout="Flow" RepeatDirection="Vertical">
                                                            <asp:ListItem Value="大陆">大陆</asp:ListItem>
                                                            <asp:ListItem Value="其他地区或国家">其他地区或国家</asp:ListItem>
                                                        </asp:CheckBoxList>&nbsp;&nbsp;<asp:TextBox id="txtYZQN" runat="server" CssClass="textbox" Columns="40"></asp:TextBox>
                                                    </td>
                                                </TR>
                                                <tr>
                                                    <td align="left">业主来源：<asp:CheckBoxList id="cblYZLY" Runat="server" CssClass="textbox" RepeatLayout="Flow" RepeatDirection="Vertical" RepeatColumns="11">
                                                            <asp:ListItem Value="Call in">Call in</asp:ListItem>
                                                            <asp:ListItem Value="Walk in">Walk in</asp:ListItem>
                                                            <asp:ListItem Value="Cold Call">Cold Call</asp:ListItem>
                                                            <asp:ListItem Value="转介">转介</asp:ListItem>
                                                            <asp:ListItem Value="旧客">旧客</asp:ListItem>
                                                            <asp:ListItem Value="广州日报">广州日报</asp:ListItem>
                                                            <asp:ListItem Value="搜房">搜房</asp:ListItem>
                                                            <asp:ListItem Value="安居客">安居客</asp:ListItem>
                                                            <asp:ListItem Value="超经">超经</asp:ListItem>
                                                            <asp:ListItem Value="焦点">焦点</asp:ListItem>
                                                            <asp:ListItem Value="其他">其他</asp:ListItem>
                                                        </asp:CheckBoxList>&nbsp;&nbsp;<asp:TextBox id="txtYYQT" runat="server" CssClass="textbox" Columns="20"></asp:TextBox>
                                                    </td>
                                                </TR>
                                                <tr>
                                                    <td align="left">业主地址：<asp:TextBox id="txtJFLXDZ" Runat="server" CssClass="textbox" Columns="70"></asp:TextBox></td>
                                                </TR>
                                                <tr>
                                                    <td align="left">业主电邮：<asp:TextBox id="txtYZDY" Runat="server" CssClass="textbox" Columns="70"></asp:TextBox></td>
                                                </TR>
                                                <tr>
                                                    <td align="left">租客名称：<asp:TextBox id="txtYFMC" runat="server" CssClass="textbox" Columns="36"></asp:TextBox>&nbsp;&nbsp;代理人：<asp:TextBox id="txtYFDLR" runat="server" CssClass="textbox" Columns="24"></asp:TextBox>&nbsp;&nbsp;证件号码：<asp:CheckBoxList id="cblYFZJLB" runat="server" CssClass="textbox" RepeatColumns="3" RepeatLayout="Flow" RepeatDirection="Vertical">
                                                            <asp:ListItem Value="0">身份证</asp:ListItem>
                                                            <asp:ListItem Value="1">护照</asp:ListItem>
                                                            <asp:ListItem Value="2">营业执照</asp:ListItem>
                                                        </asp:CheckBoxList>&nbsp;&nbsp;<asp:TextBox id="txtYFZZHM" Runat="server" CssClass="textbox" Columns="28"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">租客电话：<asp:TextBox id="txtYFLXDH" Runat="server" CssClass="textbox" Columns="48"></asp:TextBox>&nbsp;&nbsp;地区：<asp:CheckBoxList ID="cblMJQC" runat="server" CssClass="textbox" RepeatColumns="2" RepeatLayout="Flow" RepeatDirection="Vertical">
                                                            <asp:ListItem Value="大陆">大陆</asp:ListItem>
                                                            <asp:ListItem Value="其他地区或国家">其他地区或国家</asp:ListItem>
                                                        </asp:CheckBoxList>&nbsp;&nbsp;<asp:TextBox id="txtMJQN" runat="server" CssClass="textbox" Columns="40"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">租客来源：<asp:CheckBoxList id="cblKHLY" Runat="server" CssClass="textbox" RepeatLayout="Flow" RepeatDirection="Vertical" RepeatColumns="11">
                                                            <asp:ListItem Value="Call in">Call in</asp:ListItem>
                                                            <asp:ListItem Value="Walk in">Walk in</asp:ListItem>
                                                            <asp:ListItem Value="Cold Call">Cold Call</asp:ListItem>
                                                            <asp:ListItem Value="转介">转介</asp:ListItem>
                                                            <asp:ListItem Value="旧客">旧客</asp:ListItem>
                                                            <asp:ListItem Value="广州日报">广州日报</asp:ListItem>
                                                            <asp:ListItem Value="搜房">搜房</asp:ListItem>
                                                            <asp:ListItem Value="安居客">安居客</asp:ListItem>
                                                            <asp:ListItem Value="超经">超经</asp:ListItem>
                                                            <asp:ListItem Value="焦点">焦点</asp:ListItem>
                                                            <asp:ListItem Value="其他">其他</asp:ListItem>
                                                        </asp:CheckBoxList>&nbsp;&nbsp;<asp:TextBox id="txtKYQT" runat="server" CssClass="textbox" Columns="20"></asp:TextBox>
                                                    </td>
                                                </TR>
                                                <tr>
                                                    <td align="left">租客地址：<asp:TextBox id="txtYFLXDZ" Runat="server" CssClass="textbox" Columns="70"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="left">租客电邮：<asp:TextBox id="txtKHDY" Runat="server" CssClass="textbox" Columns="70"></asp:TextBox></td>
                                                </tr>
                                            </TABLE>
                                        </TD>
                                    </TR>
                                    <TR>
                                        <TD class="label" align="left" bgColor="#ccff99"><B>&gt;&gt;&gt;&gt;其他资料</B></TD>
                                    </TR>
                                    <TR>
                                        <TD>
                                            <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                <TR>
                                                    <TD align="left">建筑面积：<asp:TextBox id="txtJYZMJMin" runat="server" CssClass="textbox" Columns="16"></asp:TextBox>-<asp:TextBox id="txtJYZMJMax" runat="server" CssClass="textbox" Columns="16"></asp:TextBox>平方米</TD>
                                                </TR>
                                                <TR>
                                                    <TD align="left">物业地址：<asp:TextBox id="txtHTFWDZ" runat="server" Width="800px" CssClass="textbox"></asp:TextBox></TD>
                                                </TR>
                                                <tr>
                                                    <TD align="left">租赁保证金：<asp:TextBox id="txtZLBZJMin" runat="server" CssClass="textbox" Columns="16"></asp:TextBox>-<asp:TextBox id="txtZLBZJMax" runat="server" CssClass="textbox" Columns="16"></asp:TextBox>元人民币</TD>
                                                </tr>
                                                <tr>
                                                    <TD align="left">租期月数：<asp:TextBox id="txtZQYSMin" runat="server" CssClass="textbox" Columns="16"></asp:TextBox>-<asp:TextBox id="txtZQYSMax" runat="server" CssClass="textbox" Columns="16"></asp:TextBox>月</TD>
                                                </tr>
                                                <TR>
                                                    <TD align="left">付款模式：<asp:DropDownList id="ddlFKFS" Runat="server" CssClass="textbox" Width="320px" AutoPostBack="true"></asp:DropDownList><asp:TextBox id="txtFKFSList" runat="server" CssClass="textbox" ReadOnly="true" Width="530px"></asp:TextBox></TD>
                                                </TR>
                                                <tr>
                                                    <TD align="left">缴租方式：<asp:CheckBoxList id="cblFZFSYD" Runat="server" CssClass="textbox" RepeatColumns="4" RepeatDirection="Vertical" RepeatLayout="Flow">
															<asp:ListItem Value="0">月缴</asp:ListItem>
															<asp:ListItem Value="1">季缴</asp:ListItem>
															<asp:ListItem Value="2">半年</asp:ListItem>
															<asp:ListItem Value="3">年缴</asp:ListItem>
														</asp:CheckBoxList>&nbsp;&nbsp;&nbsp;&nbsp;缴租日：<asp:TextBox id="txtJZRMin" Runat="server" CssClass="textbox" Columns="4"></asp:TextBox>-<asp:TextBox id="txtJZRMax" Runat="server" CssClass="textbox" Columns="4"></asp:TextBox>
													</td>
                                                </tr>
												<TR>
													<TD align="left">滞纳金比例：<asp:TextBox id="txtZNJBLMin" runat="server" CssClass="textbox" Columns="16"></asp:TextBox>-<asp:TextBox id="txtZNJBLMax" runat="server" CssClass="textbox" Columns="16"></asp:TextBox>%月租金额</TD>
												</TR>
												<TR>
													<TD align="left">租金递增比例：<asp:TextBox id="txtNDZBLMin" runat="server" CssClass="textbox" Columns="16"></asp:TextBox>-<asp:TextBox id="txtNDZBLMax" runat="server" CssClass="textbox" Columns="16"></asp:TextBox>%按年递增</TD>
												</TR>
                                                <TR>
                                                    <TD align="left">交楼日期：<asp:TextBox id="txtJLRQMin" Runat="server" CssClass="textbox" Columns="12"></asp:TextBox>-<asp:TextBox id="txtJLRQMax" Runat="server" CssClass="textbox" Columns="12"></asp:TextBox>
                                                    </TD>
                                                </TR>
                                                <TR>
                                                    <TD align="left">交楼状况：<asp:TextBox id="txtJLZKSM" runat="server" CssClass="textbox" Width="800px"></asp:TextBox></TD>
                                                </TR>
                                                <TR>
                                                    <TD align="left">交易税费：<asp:CheckBoxList id="cblSFZFYD" Runat="server" CssClass="textbox" RepeatColumns="4" RepeatDirection="Vertical" RepeatLayout="Flow" AutoPostBack="False">
                                                            <asp:ListItem Value="0">各付各税</asp:ListItem>
                                                            <asp:ListItem Value="1">甲方包税(卖方包税)</asp:ListItem>
                                                            <asp:ListItem Value="2">乙方包税(买方包税)</asp:ListItem>
                                                            <asp:ListItem Value="3">其他</asp:ListItem>
                                                        </asp:CheckBoxList>
                                                    </TD>
                                                </TR>
                                                <TR>
                                                    <TD align="left">租金托管：<asp:CheckBoxList id="cblZJTGYD" Runat="server" CssClass="textbox" RepeatColumns="2" RepeatDirection="Vertical" RepeatLayout="Flow">
                                                            <asp:ListItem Value="0">不托管</asp:ListItem>
                                                            <asp:ListItem Value="1">托管</asp:ListItem>
                                                        </asp:CheckBoxList>
                                                    </TD>
                                                </TR>
                                            </TABLE>
                                        </TD>
                                    </TR>
                                    <TR>
                                        <TD class="label" align="left" bgColor="#ccff99"><B>&gt;&gt;&gt;&gt;非亿城公司承办按揭的原因</B></TD>
                                    </TR>
                                    <tr>
                                        <td>
                                            <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                <TR>
                                                    <TD align="left"><asp:TextBox id="txtBZXX" runat="server" Width="920px"></asp:TextBox></TD>
                                                </TR>
                                            </TABLE>
                                        </td>
                                    </tr>
                                    <TR>
                                        <TD class="label" align="left" bgColor="#ccff99"><B>&gt;&gt;&gt;&gt;相关业务员资料</B></TD>
                                    </TR>
                                    <TR>
                                        <td>
                                            <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                <tr>
                                                    <td align="right" nowrap>业务人员：</td>
                                                    <td align="left"><asp:TextBox id="txtYWRYMC" runat="server" Columns="32" CssClass="textbox"></asp:TextBox></td>
                                                    <td align="right">业务部门：</td>
                                                    <td align="left" nowrap><asp:TextBox id="txtYWBMMC" runat="server" Columns="48" CssClass="textbox"></asp:TextBox></td>
                                                    <td align="right" nowrap>团队编号：</td>
                                                    <td align="left"><asp:TextBox id="txtTDBHMin" runat="server" Columns="14" CssClass="textbox"></asp:TextBox>-<asp:TextBox id="txtTDBHMax" runat="server" Columns="14" CssClass="textbox"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" nowrap valign="top">人员职级：</td>
                                                    <td align="left" colspan="3"><asp:CheckBoxList id="cblYWRYZJ" Runat="server" CssClass="textbox" RepeatColumns="5" RepeatDirection="Horizontal" RepeatLayout="Table"></asp:CheckBoxList></td>
                                                    <td align="right" nowrap valign="top">分配比例：</td>
                                                    <td align="left" valign="top"><asp:TextBox id="txtFPBLMin" runat="server" Columns="14" CssClass="textbox"></asp:TextBox>-<asp:TextBox id="txtFPBLMax" runat="server" Columns="14" CssClass="textbox"></asp:TextBox></td>
                                                 </tr>
                                            </TABLE>
                                        </td>
                                    </TR>
                                </TABLE>
                            </DIV>
                        </TD>
                    </TR>
                    <TR id="trRow2">
                        <TD align="center">
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td height="4"></td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:button id="btnOK"     Runat="server" CssClass="button" Text=" 确    定 " Height="36px"></asp:button>
                                        <asp:button id="btnReset"  Runat="server" CssClass="button" Text=" 清    空 " Height="36px"></asp:button>
                                        <asp:button id="btnClose"  Runat="server" CssClass="button" Text=" 返    回 " Height="36px"></asp:button>
                                    </td>
                                </tr>
                            </table>
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
            <TABLE cellSpacing="0" cellPadding="0" align="center" border="0">
                <TR>
                    <TD>
                        <INPUT id="htxtDivLeftMain" type="hidden" runat="server"/>
                        <INPUT id="htxtDivTopMain" type="hidden" runat="server"/>
                        <INPUT id="htxtDivLeftBody" type="hidden" runat="server"/>
                        <INPUT id="htxtDivTopBody" type="hidden" runat="server"/>
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
