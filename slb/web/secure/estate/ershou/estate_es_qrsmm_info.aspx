<%@ Page Language="vb" AutoEventWireup="false" Codebehind="estate_es_qrsmm_info.aspx.vb" Inherits="Josco.JSOA.web.estate_es_qrsmm_info" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
    <HEAD>
        <title>买卖确认书查看与编辑</title>
        <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
        <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
        <meta content="JavaScript" name="vs_defaultClientScript">
        <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <LINK href="../../../styles01.css" type="text/css" rel="stylesheet">
        <style>
			TD.grdWYXXLocked { ; LEFT: expression(divWYXX.scrollLeft); POSITION: relative }
			TH.grdWYXXLocked { ; LEFT: expression(divWYXX.scrollLeft); POSITION: relative }
			TH.grdWYXXLocked { Z-INDEX: 99 }
			TD.grdYWRYLocked { ; LEFT: expression(divYWRY.scrollLeft); POSITION: relative }
			TH.grdYWRYLocked { ; LEFT: expression(divYWRY.scrollLeft); POSITION: relative }
			TH.grdYWRYLocked { Z-INDEX: 99 }
			TH { Z-INDEX: 10; POSITION: relative }
        </style>
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
        <form id="frmestate_es_qrsmm_info" method="post" runat="server">
            <asp:panel id="panelMain" Runat="server">
                <TABLE cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
                    <TR id="trRow1">
                        <TD align="center">
                            <TABLE cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
                                <tr>
                                    <td class="title" align="center">委托买卖房屋确认书<asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton></td>
                                    <td width="20">&nbsp;</td>
                                </tr>
                                <TR>
                                    <TD vAlign="middle" align="right" class="labelNotNull"><span class="labelAuto">确认书号：</span><asp:TextBox id="txtQRSH" runat="server" Columns="14" CssClass="textbox"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;客源编号：<asp:TextBox id="txtKYBH" runat="server" Columns="24" CssClass="textbox"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;订购日期：<asp:TextBox id="txtDGRQ" runat="server" Columns="8" CssClass="textbox"></asp:TextBox><INPUT id="htxtWYBS" type="hidden" size="1" runat="server"></TD>
                                    <td width="20">&nbsp;</td>
                                </TR>
                            </TABLE>
                        </TD>
                    </TR>
                    <TR>
                        <TD align="center">
                            <DIV id="divMain" style="BORDER-TOP: #99cccc 2px solid; OVERFLOW: auto; WIDTH: 964px; CLIP: rect(0px 964px 447px 0px); BORDER-BOTTOM: #99cccc 2px solid; HEIGHT: 447px">
                                <TABLE>
                                    <TR>
                                        <TD class="label" align="left" bgColor="#ccff99"><B>&gt;&gt;&gt;&gt;基本资料</B></TD>
                                    </TR>
                                    <tr>
                                        <td>
                                            <table cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                 <tr>
                                                    <td align="left"><span class="labelNotNull">查册地址：</span><asp:TextBox id="txtCCDZ" runat="server" Columns="60" CssClass="textbox"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<span class="labelNotNull">查册费：</span><asp:TextBox id="txtCCF" runat="server" Columns="14" CssClass="textbox"></asp:TextBox></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <TR>
                                        <TD class="label" align="left" bgColor="#ccff99"><B>&gt;&gt;&gt;&gt;佣金资料(RMB)</B></TD>
                                    </TR>
                                    <tr>
                                        <td>
                                            <table cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                <tr>
                                                    <td align="left"><span class="labelAuto">成交总价：</span><asp:TextBox id="txtJYZJG" runat="server" Columns="16" CssClass="textbox"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<span class="labelNotNull">业主佣金：</span><asp:TextBox id="txtJFDLF" runat="server" Columns="16" CssClass="textbox"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<span class="labelNotNull">客户佣金：</span><asp:TextBox id="txtYFDLF" runat="server" Columns="16" CssClass="textbox"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="left"><span class="labelNotNull">兴业实收：</span><asp:TextBox id="txtSSYJ" runat="server" Columns="16" CssClass="textbox"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<span class="labelNotNull">合作佣金：</span><asp:TextBox id="txtHZYJ" runat="server" Columns="16" CssClass="textbox"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<span class="labelNotNull">按揭机构：</span><asp:TextBox id="txtAJJG" runat="server" Columns="48" CssClass="textbox"></asp:TextBox></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <TR>
                                        <TD class="label" align="left" bgColor="#ccff99"><B>&gt;&gt;&gt;&gt;物业楼宇</B></TD>
                                    </TR>
                                    <TR>
                                        <TD>
                                            <TABLE cellSpacing="0" cellPadding="0" border="0">
                                                <TR>
                                                    <TD>
                                                        <DIV id="divWYXX" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 900px; CLIP: rect(0px 900px 260px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 260px">
                                                            <asp:datagrid id="grdWYXX" runat="server" Width="4160px" CssClass="label" UseAccessibleHeader="True"
                                                                AllowPaging="False" AutoGenerateColumns="False" GridLines="Vertical" BackColor="White" BorderStyle="None"
                                                                PageSize="30" BorderColor="#DEDFDE" BorderWidth="0px" AllowSorting="False" CellPadding="4">
                                                                <FooterStyle BackColor="#CCCC99"></FooterStyle>
                                                                <SelectedItemStyle ForeColor="#CC0000" VerticalAlign="Middle" BackColor="#FFFFDD"></SelectedItemStyle>
                                                                <EditItemStyle VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
                                                                <AlternatingItemStyle BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
                                                                <ItemStyle BorderWidth="0px" ForeColor="Black" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7"></ItemStyle>
                                                                <HeaderStyle Font-Bold="True" HorizontalAlign="Left" ForeColor="White" VerticalAlign="Middle" BackColor="#6699cc"></HeaderStyle>
                                                                
                                                                <Columns>
                                                                    <asp:TemplateColumn HeaderText="选" ItemStyle-Width="20px">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox id="chkWYXX" runat="server" AutoPostBack="False"></asp:CheckBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>

                                                                    <asp:ButtonColumn ItemStyle-Width="700px" DataTextField="物业信息" SortExpression="物业信息" HeaderText="物业信息" CommandName="OpenDocument">
                                                                        <HeaderStyle Width="700px"></HeaderStyle>
                                                                    </asp:ButtonColumn>

                                                                    <asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="唯一标识" SortExpression="唯一标识" HeaderText="唯一标识" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="确认书号" SortExpression="确认书号" HeaderText="确认书号" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="物业编码" SortExpression="物业编码" HeaderText="物业编码" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="240px" DataTextField="房屋地址" SortExpression="房屋地址" HeaderText="房屋地址" CommandName="OpenDocument">
                                                                        <HeaderStyle Width="240px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="房产证号" SortExpression="房产证号" HeaderText="房产证号" CommandName="OpenDocument">
                                                                        <HeaderStyle Width="160px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="房产证地址" SortExpression="房产证地址" HeaderText="房产证地址" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="120px" DataTextField="交易金额" SortExpression="交易金额" HeaderText="交易金额" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
                                                                        <HeaderStyle Width="120px" HorizontalAlign="Right"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="120px" DataTextField="面积" SortExpression="面积" HeaderText="面积" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
                                                                        <HeaderStyle Width="120px" HorizontalAlign="Right"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="座向" SortExpression="座向" HeaderText="朝向" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="楼层" SortExpression="楼层" HeaderText="楼层" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="楼龄" SortExpression="楼龄" HeaderText="楼龄" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="间隔" SortExpression="间隔" HeaderText="间隔码" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="间隔名称" SortExpression="间隔名称" HeaderText="户型" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="物业性质" SortExpression="物业性质" HeaderText="物业性质码" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="140px" DataTextField="物业性质名称" SortExpression="物业性质名称" HeaderText="物业性质" CommandName="Select">
                                                                        <HeaderStyle Width="140px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="所在区域" SortExpression="所在区域" HeaderText="所在区域码" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="所在区域名称" SortExpression="所在区域名称" HeaderText="所在区域" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>

                                                                    <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="房源编号" SortExpression="房源编号" HeaderText="房源编号" CommandName="Select">
                                                                        <HeaderStyle Width="160px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="楼盘" SortExpression="楼盘" HeaderText="楼盘" CommandName="Select">
                                                                        <HeaderStyle Width="160px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="楼栋" SortExpression="楼栋" HeaderText="楼栋" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="单元" SortExpression="单元" HeaderText="单元" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="140px" DataTextField="建成时间" SortExpression="建成时间" HeaderText="建成时间" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
                                                                        <HeaderStyle Width="140px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="空间类型" SortExpression="空间类型" HeaderText="空间类型" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="房屋性质" SortExpression="房屋性质" HeaderText="房屋性质" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="装修档次" SortExpression="装修档次" HeaderText="装修档次" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="装修年限" SortExpression="装修年限" HeaderText="装修年限" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="噪音影响" SortExpression="噪音影响" HeaderText="噪音影响" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="家具设备" SortExpression="家具设备" HeaderText="家具设备" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="楼宇交通" SortExpression="楼宇交通" HeaderText="楼宇交通" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="房屋间隔" SortExpression="房屋间隔" HeaderText="房屋间隔" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="景观类型" SortExpression="景观类型" HeaderText="房屋景观" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="景观房数" SortExpression="景观房数" HeaderText="景观房数" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="楼高" SortExpression="楼高" HeaderText="楼高" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="卧室数量" SortExpression="卧室数量" HeaderText="卧室数量" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="阳台数量" SortExpression="阳台数量" HeaderText="阳台数量" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="0px" Visible="false" DataTextField="花园面积" SortExpression="花园面积" HeaderText="花园面积" CommandName="Select" DataTextFormatString="{0:0.00}">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="电梯数量" SortExpression="电梯数量" HeaderText="电梯数量" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="楼层户数" SortExpression="楼层户数" HeaderText="楼层户数" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="楼盘期数" SortExpression="楼盘期数" HeaderText="楼盘期数" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>

                                                                    <asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="备注信息" SortExpression="备注信息" HeaderText="备注信息" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                </Columns>
                                                                
                                                                <PagerStyle Visible="False" NextPageText="下页" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
                                                            </asp:datagrid><INPUT id="htxtWYXXFixed" type="hidden" value="0" runat="server">
                                                        </DIV>
                                                    </TD>
                                                </TR>
                                                <TR>
                                                    <TD align="right">
                                                        <asp:Button id="btnAddNew_WYXX" Runat="server" CssClass="button" Text=" 加入新的物业 "></asp:Button>
                                                        <asp:Button id="btnUpdate_WYXX" Runat="server" CssClass="button" Text=" 更改物业资料 "></asp:Button>
                                                        <asp:Button id="btnDelete_WYXX" Runat="server" CssClass="button" Text=" 删除现有物业 "></asp:Button>
                                                    </TD>
                                                </TR>
                                            </TABLE>
                                        </TD>
                                    </TR>
                                    <TR>
                                        <TD class="label" align="left" bgColor="#ccff99"><B>&gt;&gt;&gt;&gt;交易详情</B></TD>
                                    </TR>
                                    <TR>
                                        <TD>
                                            <TABLE cellSpacing="0" cellPadding="2" width="100%" border="0">
                                                <tr>
                                                    <td align="left"><span class="labelNotNull">付款方式：</span>
                                                        <asp:RadioButtonList id="rblFKFSYD" Runat="server" CssClass="textbox" RepeatLayout="Flow" RepeatDirection="Vertical" RepeatColumns="3">
                                                            <asp:ListItem Value="0">一次性付款</asp:ListItem>
                                                            <asp:ListItem Value="1">亿城按揭</asp:ListItem>
                                                            <asp:ListItem Value="2">其他按揭</asp:ListItem>
                                                        </asp:RadioButtonList>&nbsp;&nbsp;&nbsp;&nbsp;<span class="labelNotNull">按揭：</span><asp:TextBox id="txtAJYH" runat="server" CssClass="textbox" Columns="48"></asp:TextBox><span class="labelNotNull">&nbsp;&nbsp;银行&nbsp;&nbsp;<asp:TextBox id="txtAJCS" runat="server" CssClass="textbox" Columns="6"></asp:TextBox><span class="labelNotNull">&nbsp;&nbsp;成&nbsp;&nbsp;</span><asp:TextBox id="txtAJNX" runat="server" CssClass="textbox" Columns="6"></asp:TextBox><span class="labelNotNull">&nbsp;&nbsp;年按揭</span>
                                                    </td>
                                                </TR>
                                                <tr>
                                                    <td align="left"><span class="labelNotNull">业主名称：</span><asp:TextBox id="txtJFMC" runat="server" CssClass="textbox" Columns="40"></asp:TextBox>&nbsp;&nbsp;代理人：<asp:TextBox id="txtJFDLR" runat="server" Columns="24" CssClass="textbox"></asp:TextBox><span class="labelNotNull">&nbsp;&nbsp;证件号码：</span><asp:DropDownList id="ddlJFZJLB" runat="server" CssClass="textbox" Width="100px">
                                                            <asp:ListItem Value="0">身份证</asp:ListItem>
                                                            <asp:ListItem Value="1">护照</asp:ListItem>
                                                            <asp:ListItem Value="2">营业执照</asp:ListItem>
                                                        </asp:DropDownList>&nbsp;&nbsp;<asp:TextBox id="txtJFZZHM" Runat="server" CssClass="textbox" Columns="36"></asp:TextBox>
                                                    </td>
                                                </TR>
                                                <tr>
                                                    <td align="left"><span class="labelNotNull">业主电话：</span><asp:TextBox id="txtJFLXDH" Runat="server" CssClass="textbox" Columns="48"></asp:TextBox><span class="labelNotNull">&nbsp;&nbsp;地区：</span><asp:RadioButtonList ID="rblYZQC" runat="server" CssClass="textbox" RepeatColumns="2" RepeatLayout="Flow" RepeatDirection="Vertical">
                                                            <asp:ListItem Value="大陆">大陆</asp:ListItem>
                                                            <asp:ListItem Value="其他地区或国家">其他地区或国家</asp:ListItem>
                                                        </asp:RadioButtonList>&nbsp;&nbsp;<asp:TextBox id="txtYZQN" runat="server" CssClass="textbox" Columns="40"></asp:TextBox>
                                                    </td>
                                                </TR>
                                                <tr>
                                                    <td align="left"><span class="labelNotNull">业主来源：</span>
                                                        <asp:RadioButtonList id="rblYZLY" Runat="server" CssClass="textbox" RepeatLayout="Flow" RepeatDirection="Vertical" RepeatColumns="11">
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
                                                        </asp:RadioButtonList>&nbsp;&nbsp;<asp:TextBox id="txtYYQT" runat="server" CssClass="textbox" Columns="20"></asp:TextBox>
                                                    </td>
                                                </TR>
                                                <tr>
                                                    <td align="left">业主地址：<asp:TextBox id="txtJFLXDZ" Runat="server" CssClass="textbox" Columns="70"></asp:TextBox></td>
                                                </TR>
                                                <tr>
                                                    <td align="left">业主电邮：<asp:TextBox id="txtYZDY" Runat="server" CssClass="textbox" Columns="70"></asp:TextBox></td>
                                                </TR>
                                                <tr>
                                                    <td align="left"><span class="labelNotNull">售后意向：</span>
                                                        <asp:RadioButtonList id="rblSHYX" Runat="server" CssClass="textbox" RepeatLayout="Flow" RepeatDirection="Vertical" RepeatColumns="3">
                                                            <asp:ListItem Value="再购房投资">再购房投资</asp:ListItem>
                                                            <asp:ListItem Value="再购房自住">再购房自住</asp:ListItem>
                                                            <asp:ListItem Value="其他">其他</asp:ListItem>
                                                        </asp:RadioButtonList>&nbsp;&nbsp;&nbsp;&nbsp;<span class="labelNotNull">剩余物业：</span>
                                                        <asp:RadioButtonList id="rblSYWY" Runat="server" CssClass="textbox" RepeatLayout="Flow" RepeatDirection="Vertical" RepeatColumns="3">
                                                            <asp:ListItem Value="1套">1套</asp:ListItem>
                                                            <asp:ListItem Value="2-3套">2-3套</asp:ListItem>
                                                            <asp:ListItem Value="4套以上">4套以上</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </TR>
                                                <tr>
                                                    <td align="left"><span class="labelNotNull">买家名称：</span><asp:TextBox id="txtYFMC" runat="server" CssClass="textbox" Columns="40"></asp:TextBox>&nbsp;&nbsp;代理人：<asp:TextBox id="txtYFDLR" runat="server" CssClass="textbox" Columns="24"></asp:TextBox><span class="labelNotNull">&nbsp;&nbsp;证件号码：</span><asp:DropDownList id="ddlYFZJLB" runat="server" CssClass="textbox" Width="100px">
                                                            <asp:ListItem Value="0">身份证</asp:ListItem>
                                                            <asp:ListItem Value="1">护照</asp:ListItem>
                                                            <asp:ListItem Value="2">营业执照</asp:ListItem>
                                                        </asp:DropDownList>&nbsp;&nbsp;<asp:TextBox id="txtYFZZHM" Runat="server" CssClass="textbox" Columns="36"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left"><span class="labelNotNull">客户电话：</span><asp:TextBox id="txtYFLXDH" Runat="server" CssClass="textbox" Columns="48"></asp:TextBox><span class="labelNotNull">&nbsp;&nbsp;地区：</span><asp:RadioButtonList ID="rblMJQC" runat="server" CssClass="textbox" RepeatColumns="2" RepeatLayout="Flow" RepeatDirection="Vertical">
                                                            <asp:ListItem Value="大陆">大陆</asp:ListItem>
                                                            <asp:ListItem Value="其他地区或国家">其他地区或国家</asp:ListItem>
                                                        </asp:RadioButtonList>&nbsp;&nbsp;<asp:TextBox id="txtMJQN" runat="server" CssClass="textbox" Columns="40"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left"><span class="labelNotNull">客户来源：</span>
                                                        <asp:RadioButtonList id="rblKHLY" Runat="server" CssClass="textbox" RepeatLayout="Flow" RepeatDirection="Vertical" RepeatColumns="11">
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
                                                        </asp:RadioButtonList>&nbsp;&nbsp;<asp:TextBox id="txtKYQT" runat="server" CssClass="textbox" Columns="20"></asp:TextBox>
                                                    </td>
                                                </TR>
                                                <tr>
                                                    <td align="left">客户地址：<asp:TextBox id="txtYFLXDZ" Runat="server" CssClass="textbox" Columns="70"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="left">客户电邮：<asp:TextBox id="txtKHDY" Runat="server" CssClass="textbox" Columns="70"></asp:TextBox>&nbsp;&nbsp;购买目的：<asp:RadioButtonList id="rblGMMD" Runat="server" CssClass="textbox" RepeatLayout="Flow" RepeatDirection="Vertical" RepeatColumns="3">
                                                            <asp:ListItem Value="再出售">再出售</asp:ListItem>
                                                            <asp:ListItem Value="出租">出租</asp:ListItem>
                                                            <asp:ListItem Value="自住">自住</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                            </TABLE>
                                        </TD>
                                    </TR>
                                    <TR>
                                        <TD class="label" align="left" bgColor="#ccff99"><B>&gt;&gt;&gt;&gt;其他资料</B></TD>
                                    </TR>
                                    <TR>
                                        <TD>
                                            <TABLE cellSpacing="0" cellPadding="2" width="100%" border="0">
                                                <TR>
                                                    <TD class="labelAuto" align="left">建筑面积：<asp:TextBox id="txtJYZMJ" runat="server" Columns="16" CssClass="textbox"></asp:TextBox>平方米(以房产证面积为准)；</TD>
                                                </TR>
                                                <TR>
                                                    <TD class="labelAuto" align="left">房屋地址：<asp:TextBox id="txtFWDZ" runat="server" Width="800px" CssClass="textbox"></asp:TextBox></TD>
                                                </TR>
                                                <TR>
                                                    <TD class="label" align="left">交易日期：<asp:TextBox id="txtJYRQ" runat="server" Columns="16" CssClass="textbox"></asp:TextBox>前(交易日期即签署合同的日期)；注意大小月份的不同，不能写“待议”。</TD>
                                                </TR>
                                                <TR>
                                                    <TD class="label" align="left">交楼日期：<asp:RadioButtonList id="rblJLRQYD" Runat="server" CssClass="textbox" RepeatLayout="Flow" RepeatDirection="Vertical" RepeatColumns="3">
                                                            <asp:ListItem Value="0">收到全部房款当天</asp:ListItem>
                                                            <asp:ListItem Value="1">自行交接</asp:ListItem>
                                                            <asp:ListItem Value="2">其他约定</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </TD>
                                                </TR>
                                                <TR>
                                                    <TD class="label" align="left">交楼状况：<asp:RadioButtonList id="rblJLZKYD" Runat="server" CssClass="textbox" RepeatLayout="Flow" RepeatDirection="Vertical" RepeatColumns="3">
                                                            <asp:ListItem Value="0">吉屋按现状</asp:ListItem>
                                                            <asp:ListItem Value="1">详见交付清单</asp:ListItem>
                                                            <asp:ListItem Value="2">带租约交付</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </TD>
                                                </TR>
                                                <TR>
                                                    <TD class="label" align="left">交易税费：<asp:RadioButtonList id="rblSFZFYD" Runat="server" CssClass="textbox" RepeatLayout="Flow" RepeatDirection="Vertical" RepeatColumns="4">
                                                            <asp:ListItem Value="0">各付各税</asp:ListItem>
                                                            <asp:ListItem Value="1">甲方包税</asp:ListItem>
                                                            <asp:ListItem Value="2">乙方包税</asp:ListItem>
                                                            <asp:ListItem Value="3">其他</asp:ListItem>
                                                        </asp:RadioButtonList>
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
                                                    <TD align="left"><asp:TextBox id="txtBZXX" runat="server" Width="900px" Rows="8" TextMode="MultiLine"></asp:TextBox></TD>
                                                </TR>
                                            </TABLE>
                                        </td>
                                    </tr>
                                    <TR>
                                        <TD class="label" align="left" bgColor="#ccff99"><B>&gt;&gt;&gt;&gt;相关业务员资料</B></TD>
                                    </TR>
                                    <TR>
                                        <TD>
                                            <TABLE cellSpacing="0" cellPadding="0" border="0">
                                                <TR>
                                                    <TD>
                                                        <DIV id="divYWRY" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 900px; CLIP: rect(0px 900px 200px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 200px">
                                                            <asp:datagrid id="grdYWRY" runat="server" CssClass="label" UseAccessibleHeader="True" AllowPaging="False"
                                                                AutoGenerateColumns="False" GridLines="Vertical" BackColor="White" BorderStyle="None" PageSize="30"
                                                                BorderColor="#DEDFDE" BorderWidth="0px" AllowSorting="False" CellPadding="4">
                                                                <FooterStyle BackColor="#CCCC99"></FooterStyle>
                                                                <SelectedItemStyle ForeColor="#CC0000" VerticalAlign="Middle" BackColor="#FFFFDD"></SelectedItemStyle>
                                                                <EditItemStyle VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
                                                                <AlternatingItemStyle BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
                                                                <ItemStyle BorderWidth="0px" ForeColor="Black" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7"></ItemStyle>
                                                                <HeaderStyle Font-Bold="True" HorizontalAlign="Left" ForeColor="White" VerticalAlign="Middle" BackColor="#6699cc"></HeaderStyle>
                                                                
                                                                <Columns>
                                                                    <asp:TemplateColumn HeaderText="选" ItemStyle-Width="20px">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox id="chkYWRY" runat="server" AutoPostBack="False"></asp:CheckBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="唯一标识" SortExpression="唯一标识" HeaderText="唯一标识" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="确认书号" SortExpression="确认书号" HeaderText="确认书号" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="人员代码" SortExpression="人员代码" HeaderText="人员代码" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="人员名称" SortExpression="人员名称" HeaderText="人员名称" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="单位代码" SortExpression="单位代码" HeaderText="单位代码" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="300px" DataTextField="单位名称" SortExpression="单位名称" HeaderText="单位名称" CommandName="Select">
                                                                        <HeaderStyle Width="300px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="200px" DataTextField="所属分组" SortExpression="所属分组" HeaderText="所属分组" CommandName="Select">
                                                                        <HeaderStyle Width="200px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="60px" DataTextField="团队编号" SortExpression="团队编号" HeaderText="团队" CommandName="Select">
                                                                        <HeaderStyle Width="60px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="人员职级" SortExpression="人员职级" HeaderText="人员职级码" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="300px" DataTextField="人员职级名称" SortExpression="人员职级名称" HeaderText="职级" CommandName="Select">
                                                                        <HeaderStyle Width="300px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="分配比例" SortExpression="分配比例" HeaderText="分配比例" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="直管标记" SortExpression="直管标记" HeaderText="直管标记" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="直管标记名称" SortExpression="直管标记名称" HeaderText="直管" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="状态标志" SortExpression="状态标志" HeaderText="状态标志" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="状态标志名称" SortExpression="状态标志名称" HeaderText="状态" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                </Columns>
                                                                
                                                                <PagerStyle Visible="False" NextPageText="下页" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
                                                            </asp:datagrid><INPUT id="htxtYWRYFixed" type="hidden" value="0" runat="server">
                                                        </DIV>
                                                    </TD>
                                                </TR>
                                                <TR>
                                                    <TD align="right">
                                                        <asp:Button id="btnAddNew_YWRY" Runat="server" CssClass="button" Text=" 加入新的业务员 "></asp:Button>
                                                        <asp:Button id="btnDelete_YWRY" Runat="server" CssClass="button" Text=" 删除现有业务员 "></asp:Button>
                                                    </TD>
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
                            <asp:button id="btnSHCY"   Runat="server" CssClass="button" Text=" 诚意金审核 " Height="36px"></asp:button>
                            <asp:button id="btnSJSZ"   Runat="server" CssClass="button" Text=" 诚意金处理 " Height="36px"></asp:button>
                            <asp:button id="btnYSYF"   Runat="server" CssClass="button" Text=" 收付款计划 " Height="36px"></asp:button>
                            <asp:button id="btnOK"     Runat="server" CssClass="button" Text=" 确      定 " Height="36px"></asp:button>
                            <asp:button id="btnCancel" Runat="server" CssClass="button" Text=" 取      消 " Height="36px"></asp:button>
                            <asp:button id="btnClose"  Runat="server" CssClass="button" Text=" 返      回 " Height="36px"></asp:button>
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
                        <INPUT id="htxtCYJXZ" type="hidden" runat="server" value="^005.001^">
                        <INPUT id="htxtSessionId_WYXX" type="hidden" runat="server">
                        <INPUT id="htxtSessionId_YWRY" type="hidden" runat="server">
                        <INPUT id="htxtDivLeftWYXX" type="hidden" runat="server">
                        <INPUT id="htxtDivTopWYXX" type="hidden" runat="server">
                        <INPUT id="htxtDivLeftYWRY" type="hidden" runat="server">
                        <INPUT id="htxtDivTopYWRY" type="hidden" runat="server">
                        <INPUT id="htxtDivLeftMain" type="hidden" runat="server">
                        <INPUT id="htxtDivTopMain" type="hidden" runat="server">
                        <INPUT id="htxtDivLeftBody" type="hidden" runat="server">
                        <INPUT id="htxtDivTopBody" type="hidden" runat="server">
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
							function ScrollProc_divWYXX() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopWYXX");
								if (oText != null) oText.value = divWYXX.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftWYXX");
								if (oText != null) oText.value = divWYXX.scrollLeft;
								return;
							}
							function ScrollProc_divYWRY() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopYWRY");
								if (oText != null) oText.value = divYWRY.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftYWRY");
								if (oText != null) oText.value = divYWRY.scrollLeft;
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
								oText=document.getElementById("htxtDivTopWYXX");
								if (oText != null) divWYXX.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftWYXX");
								if (oText != null) divWYXX.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtDivTopYWRY");
								if (oText != null) divYWRY.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftYWRY");
								if (oText != null) divYWRY.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divMain.onscroll = ScrollProc_divMain;
								divWYXX.onscroll = ScrollProc_divWYXX;
								divYWRY.onscroll = ScrollProc_divYWRY;
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
