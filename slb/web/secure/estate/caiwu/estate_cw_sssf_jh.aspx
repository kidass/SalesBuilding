<%@ Page Language="vb" AutoEventWireup="false" Codebehind="estate_cw_sssf_jh.aspx.vb" Inherits="Josco.JSOA.web.estate_cw_sssf_jh" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
    <HEAD>
        <title>根据计划进行收付款处理</title>
        <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
        <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
        <meta content="JavaScript" name="vs_defaultClientScript">
        <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <LINK href="../../../styles01.css" type="text/css" rel="stylesheet">
        <style>
		    TD.grdJHSZLocked { ; LEFT: expression(divJHSZ.scrollLeft); POSITION: relative }
		    TH.grdJHSZLocked { ; LEFT: expression(divJHSZ.scrollLeft); POSITION: relative }
		    TH.grdJHSZLocked { Z-INDEX: 99 }
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
				
				if (document.all("divJHSZ") == null)
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
				intHeight -= trRow03.clientHeight;
				intHeight -= trRow04.clientHeight;
				intHeight -= trRow05.clientHeight;
				intHeight -= trRow06.clientHeight;
				intHeight -= trRow07.clientHeight;
				intHeight -= trRow08.clientHeight;
				intHeight -= trRow09.clientHeight;
				strHeight  = intHeight.toString() + "px";
				//if (document.readyState.toLowerCase() == "complete")
                //    alert(strWidth + " " + strHeight);

				divJHSZ.style.width  = strWidth;
				divJHSZ.style.height = strHeight;
				divJHSZ.style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";
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
        <form id="frmestate_cw_sssf_jh" method="post" runat="server">
            <asp:panel id="panelMain" Runat="server">
                <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                    <TR>
                        <TD width="5"></TD>
                        <TD vAlign="top" align="center">
                            <TABLE cellSpacing="0" cellPadding="0" border="0">
                                <TR id="trRow01">
                                    <TD class="title" align="center" colSpan="3" height="30">根据计划进行收付款处理<asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton></TD>
                                </TR>
                                <TR>
                                    <TD width="5"></TD>
                                    <TD vAlign="top">
                                        <DIV id="divMain">
                                            <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                <TR id="trRow02">
                                                    <TD class="label" align="left" bgColor="#ccff99"><B>&gt;&gt;&gt;&gt;交易信息</B></TD>
                                                </TR>
                                                <TR id="trRow03">
                                                    <TD>
                                                        <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                            <TR>
                                                                <TD class="label" noWrap align="right">&nbsp;&nbsp;交易编号：&nbsp;&nbsp;</TD>
                                                                <TD noWrap align="left" width="15%" style="BORDER-BOTTOM: #99cccc 1px solid">&nbsp;<asp:Label id="lblJYBH" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
                                                                <TD class="label" noWrap align="right">&nbsp;&nbsp;交易日期：&nbsp;&nbsp;</TD>
                                                                <TD noWrap align="left" width="15%" style="BORDER-BOTTOM: #99cccc 1px solid">&nbsp;<asp:Label id="lblJYRQ" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
                                                                <TD class="label" noWrap align="right">&nbsp;&nbsp;甲方名称：&nbsp;&nbsp;</TD>
                                                                <TD noWrap align="left" width="18%" style="BORDER-BOTTOM: #99cccc 1px solid">&nbsp;<asp:Label id="lblJFMC" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
                                                                <TD class="label" noWrap align="right">&nbsp;&nbsp;交易价格(元)：&nbsp;&nbsp;</TD>
                                                                <TD noWrap align="right" width="15%" style="BORDER-BOTTOM: #99cccc 1px solid">&nbsp;<asp:Label id="lblJYJG" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
                                                                <TD class="label" noWrap align="right">&nbsp;&nbsp;甲方代理费(元)：&nbsp;&nbsp;</TD>
                                                                <TD noWrap align="right" width="15%" style="BORDER-BOTTOM: #99cccc 1px solid">&nbsp;<asp:Label id="lblJFDLF" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
                                                            </TR>
                                                            <TR>
                                                                <TD class="label" noWrap align="right">&nbsp;&nbsp;合同编号：&nbsp;&nbsp;</TD>
                                                                <TD noWrap align="left" style="BORDER-BOTTOM: #99cccc 1px solid">&nbsp;<asp:Label id="lblHTBH" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
                                                                <TD class="label" noWrap align="right">&nbsp;&nbsp;合同日期：&nbsp;&nbsp;</TD>
                                                                <TD noWrap align="left" style="BORDER-BOTTOM: #99cccc 1px solid">&nbsp;<asp:Label id="lblHTRQ" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
                                                                <TD class="label" noWrap align="right">&nbsp;&nbsp;乙方名称：&nbsp;&nbsp;</TD>
                                                                <TD noWrap align="left" style="BORDER-BOTTOM: #99cccc 1px solid">&nbsp;<asp:Label id="lblYFMC" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
                                                                <TD class="label" noWrap align="right">&nbsp;&nbsp;交易面积(㎡)：&nbsp;&nbsp;</TD>
                                                                <TD noWrap align="right" style="BORDER-BOTTOM: #99cccc 1px solid">&nbsp;<asp:Label id="lblJYMJ" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
                                                                <TD class="label" noWrap align="right">&nbsp;&nbsp;乙方代理费(元)：&nbsp;&nbsp;</TD>
                                                                <TD noWrap align="right" style="BORDER-BOTTOM: #99cccc 1px solid">&nbsp;<asp:Label id="lblYFDLF" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
                                                            </TR>
                                                            <TR>
                                                                <TD class="label" noWrap align="right">&nbsp;&nbsp;物业地址：&nbsp;&nbsp;</TD>
                                                                <TD noWrap align="left" colSpan="9" style="BORDER-BOTTOM: #99cccc 1px solid">&nbsp;<asp:Label id="lblWYDZ" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
                                                            </TR>
                                                        </TABLE>
                                                    </TD>
                                                </TR>
                                                <TR id="trRow04">
                                                    <TD class="label" align="left" bgColor="#ccff99">
                                                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                            <tr height="24" valign="middle">
                                                                <td class="label" align="left"><B>&gt;&gt;&gt;&gt;收付款计划信息</B></td>
                                                                <td class="label" align="right">甲方备用金<asp:TextBox ID="txtBYJ_JF" Runat="server" CssClass="textbox" Columns="14" ReadOnly="True"></asp:TextBox>&nbsp;&nbsp;乙方备用金<asp:TextBox ID="txtBYJ_YF" Runat="server" CssClass="textbox" Columns="14" ReadOnly="True"></asp:TextBox>&nbsp;&nbsp;合同备用金<asp:TextBox ID="txtBYJ_HT" Runat="server" CssClass="textbox" Columns="14" ReadOnly="True"></asp:TextBox></td>
                                                            </tr>
                                                        </table>
                                                    </TD>
                                                </TR>
                                                <TR id="trRow05">
                                                    <TD>
                                                        <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                            <TR>
                                                                <TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;税费&nbsp;</TD>
                                                                <TD class="label" align="left"><asp:DropDownList id="ddlJHSZSearch_SFDM" runat="server" CssClass="textbox"></asp:DropDownList></TD>
                                                                <TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;对象&nbsp;</TD>
                                                                <TD class="label" align="left">
                                                                    <asp:DropDownList id="ddlJHSZSearch_SFDX" runat="server" CssClass="textbox">
                                                                        <asp:ListItem Value=""></asp:ListItem>
                                                                        <asp:ListItem Value="甲">甲方</asp:ListItem>
                                                                        <asp:ListItem Value="乙">乙方</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </TD>
                                                                <TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;收付&nbsp;</TD>
                                                                <TD class="label" align="left">
                                                                    <asp:DropDownList id="ddlJHSZSearch_SFBZ" runat="server" CssClass="textbox">
                                                                        <asp:ListItem Value=""></asp:ListItem>
                                                                        <asp:ListItem Value="收">收</asp:ListItem>
                                                                        <asp:ListItem Value="付">付</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </TD>
                                                                <TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;日期&nbsp;</TD>
                                                                <TD class="label" align="left"><asp:TextBox id="txtJHSZSearch_YSRQMin" Runat="server" Columns="10" CssClass="textbox"></asp:TextBox>~<asp:TextBox id="txtJHSZSearch_YSRQMax" Runat="server" Columns="10" CssClass="textbox"></asp:TextBox></TD>
                                                                <TD class="label">&nbsp;&nbsp;<asp:button id="btnJHSZSearch" Runat="server" CssClass="button" Text=" 快速搜索 "></asp:button><asp:button id="btnJHSZSearch_Full" Runat="server" CssClass="button" Text=" 全文搜索 "></asp:button></TD>
                                                            </TR>
                                                        </TABLE>
                                                    </TD>
                                                </TR>
                                                <TR>
                                                    <TD align="center">
                                                        <DIV id="divJHSZ" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 964px; CLIP: rect(0px 964px 263px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 263px">
                                                            <asp:datagrid id="grdJHSZ" runat="server" CssClass="label" Font-Names="宋体" CellPadding="4" AllowSorting="True"
                                                                BorderWidth="0px" BorderColor="#DEDFDE" PageSize="30" BorderStyle="None" GridLines="Vertical"
                                                                AutoGenerateColumns="False" AllowPaging="True" UseAccessibleHeader="True" Font-Size="12px">
                                                                <SelectedItemStyle Font-Size="12px" Font-Names="宋体" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
                                                                <EditItemStyle Font-Size="12px" Font-Names="宋体" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
                                                                <AlternatingItemStyle Font-Size="12px" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
                                                                <ItemStyle Font-Size="12px" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
                                                                <HeaderStyle Font-Size="12px" Font-Names="宋体" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#6699cc" HorizontalAlign="Left"></HeaderStyle>
                                                                <FooterStyle BackColor="#CCCC99"></FooterStyle>
                                                                
                                                                <Columns>
                                                                    <asp:TemplateColumn HeaderText="选" Visible="False" ItemStyle-Width="20px">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox id="chkJHSZ" runat="server" AutoPostBack="False" Visible="False"></asp:CheckBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="唯一标识" SortExpression="唯一标识" HeaderText="唯一标识" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="确认书号" SortExpression="确认书号" HeaderText="确认书号" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="税费代码" SortExpression="税费代码" HeaderText="税费代码" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn  ItemStyle-Width="180px" DataTextField="税费名称" SortExpression="税费名称" HeaderText="税费" CommandName="Select">
                                                                        <HeaderStyle Width="180px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn  ItemStyle-Width="60px" DataTextField="收付对象" SortExpression="收付对象" HeaderText="对象" CommandName="Select">
                                                                        <HeaderStyle Width="60px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="收付标志" SortExpression="收付标志" HeaderText="收付" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn  ItemStyle-Width="140px" DataTextField="应收日期" SortExpression="应收日期" HeaderText="应收日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
                                                                        <HeaderStyle Width="140px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="应收金额" SortExpression="应收金额" HeaderText="应收金额(元)" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
                                                                        <HeaderStyle Width="0px" HorizontalAlign="Right"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn  ItemStyle-Width="160px" DataTextField="应收金额收" SortExpression="应收金额收" HeaderText="收(元)" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
                                                                        <HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn  ItemStyle-Width="160px" DataTextField="应收金额付" SortExpression="应收金额付" HeaderText="付(元)" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
                                                                        <HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn  ItemStyle-Width="160px" DataTextField="实收金额" SortExpression="实收金额" HeaderText="财务核定(元)" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
                                                                        <HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" DataTextField="收付状态" SortExpression="收付状态" HeaderText="收付状态" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn  ItemStyle-Width="300px" DataTextField="其他描述" SortExpression="其他描述" HeaderText="摘要" CommandName="Select">
                                                                        <HeaderStyle Width="300px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="开始日期" SortExpression="开始日期" HeaderText="开始日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="结束日期" SortExpression="结束日期" HeaderText="结束日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="计租月份" SortExpression="计租月份" HeaderText="计租月份" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="计租区间" SortExpression="计租区间" HeaderText="计租区间" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                </Columns>
                                                                
                                                                <PagerStyle Visible="False" NextPageText="下页" Font-Size="12px" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
                                                            </asp:datagrid><INPUT id="htxtJHSZFixed" type="hidden" value="0" runat="server">
                                                        </DIV>
                                                    </TD>
                                                </TR>
                                                <TR id="trRow06">
                                                    <TD>
                                                        <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                            <TR>
                                                                <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZJHSZDeSelectAll" runat="server">不选</asp:linkbutton></TD>
                                                                <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZJHSZSelectAll" runat="server">全选</asp:linkbutton></TD>
                                                                <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZJHSZMoveFirst" runat="server">最前</asp:linkbutton></TD>
                                                                <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZJHSZMovePrev" runat="server">前页</asp:linkbutton></TD>
                                                                <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZJHSZMoveNext" runat="server">下页</asp:linkbutton></TD>
                                                                <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZJHSZMoveLast" runat="server">最后</asp:linkbutton></TD>
                                                                <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZJHSZGotoPage" runat="server">前往</asp:linkbutton><asp:textbox id="txtJHSZPageIndex" runat="server" Columns="3" CssClass="textbox">1</asp:textbox>页</TD>
                                                                <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZJHSZSetPageSize" runat="server">每页</asp:linkbutton><asp:textbox id="txtJHSZPageSize" runat="server" Columns="3" CssClass="textbox">30</asp:textbox>条</TD>
                                                                <TD class="label" vAlign="middle" noWrap align="right"><asp:label id="lblJHSZGridLocInfo" runat="server" CssClass="label">1/10 N/15</asp:label></TD>
                                                            </TR>
                                                        </TABLE>
                                                    </TD>
                                                </TR>
                                                <TR id="trRow07">
                                                    <TD class="label" align="left" bgColor="#ccff99"><B>&gt;&gt;&gt;&gt;按计划收付款需补充以下信息</B></TD>
                                                </TR>
                                                <TR id="trRow08">
                                                    <TD align="left">
                                                        <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                            <TR>
                                                                <TD class="labelNotNull" noWrap align="right">票据号：</TD>
                                                                <TD align="left" style="BORDER-BOTTOM: #99cccc 1px solid" width="15%"><asp:TextBox id="txtJHPJHM" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox></TD>
                                                                <TD class="labelNotNull" noWrap align="right">金额(元)：</TD>
                                                                <TD align="left" style="BORDER-BOTTOM: #99cccc 1px solid" width="15%"><asp:TextBox id="txtJHFSJE" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox></TD>
                                                                <TD class="labelNotNull" noWrap align="right">经办人：</TD>
                                                                <TD align="left" style="BORDER-BOTTOM: #99cccc 1px solid" width="15%"><asp:TextBox id="txtJHJBRY" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox></TD>
                                                                <td align="left"><asp:Button id="btnSelect_JHJBRY" Runat="server" CssClass="button" Text="…"></asp:Button><INPUT id="htxtJHJBRY" type="hidden" size="1" runat="server" NAME="htxtJHJBRY"></td>
                                                                <TD class="labelNotNull" noWrap align="right">经办单位：</TD>
                                                                <TD align="left" style="BORDER-BOTTOM: #99cccc 1px solid" width="35%"><asp:TextBox id="txtJHJBDW" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox></TD>
                                                                <td align="left"><asp:Button id="btnSelect_JHJBDW" Runat="server" CssClass="button" Text="…"></asp:Button><INPUT id="htxtJHJBDW" type="hidden" size="1" runat="server" NAME="htxtJHJBDW"></td>
                                                            </TR>
                                                            <TR>
                                                                <TD class="label" noWrap align="right">客户：</TD>
                                                                <TD align="left" style="BORDER-BOTTOM: #99cccc 1px solid" width="15%"><asp:TextBox id="txtJHKHMC" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox></TD>
                                                                <TD class="label" noWrap align="right">摘要：</TD>
                                                                <TD align="left" style="BORDER-BOTTOM: #99cccc 1px solid" colspan="7"><asp:TextBox id="txtJHZYSM" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox></TD>
                                                                <td></td>
                                                                <td></td>
                                                            </TR>
                                                        </TABLE>
                                                    </TD>
                                                </TR>
                                            </TABLE>
                                        </DIV>
                                    </TD>
                                    <TD width="5"></TD>
                                </TR>
                                <TR>
                                    <TD colSpan="5" height="3"></TD>
                                </TR>
                            </TABLE>
                        </TD>
                        <TD width="5"></TD>
                    </TR>
                    <TR>
                        <TD colSpan="3" height="3"></TD>
                    </TR>
                    <TR id="trRow09">
                        <TD align="center" colSpan="3">
                            <asp:Button id="btnOK" Runat="server" CssClass="button" Text=" 确    定 " Height="36px"></asp:Button>
                            <asp:Button id="btnClose" Runat="server" CssClass="button" Text=" 返    回 " Height="36px"></asp:Button>
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
            <table cellSpacing="0" cellPadding="0" align="center" border="0">
                <tr>
                    <td>
                        <input id="htxtJHSZSessionIdQuery" type="hidden" runat="server">
                        <input id="htxtJHSZQuery" type="hidden" runat="server">
                        <input id="htxtJHSZRows" type="hidden" runat="server">
                        <input id="htxtJHSZSort" type="hidden" runat="server">
                        <input id="htxtJHSZSortColumnIndex" type="hidden" runat="server">
                        <input id="htxtJHSZSortType" type="hidden" runat="server">
                        <input id="htxtDivLeftJHSZ" type="hidden" runat="server">
                        <input id="htxtDivTopJHSZ" type="hidden" runat="server">
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
							function ScrollProc_divJHSZ() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopJHSZ");
								if (oText != null) oText.value = divJHSZ.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftJHSZ");
								if (oText != null) oText.value = divJHSZ.scrollLeft;
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
								oText=document.getElementById("htxtDivTopJHSZ");
								if (oText != null) divJHSZ.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftJHSZ");
								if (oText != null) divJHSZ.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divMain.onscroll = ScrollProc_divMain;
								divJHSZ.onscroll = ScrollProc_divJHSZ;
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
