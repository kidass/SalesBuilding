<%@ Page Language="vb" AutoEventWireup="false" Codebehind="estate_cw_ysyf.aspx.vb" Inherits="Josco.JSOA.web.estate_cw_ysyf" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
    <HEAD>
        <title>收付款计划查看与编辑窗</title>
        <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
        <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
        <meta content="JavaScript" name="vs_defaultClientScript">
        <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <LINK href="../../../styles01.css" type="text/css" rel="stylesheet">
        <style>
		    TD.grdYSYFJHLocked { ; LEFT: expression(divYSYFJH.scrollLeft); POSITION: relative }
		    TH.grdYSYFJHLocked { ; LEFT: expression(divYSYFJH.scrollLeft); POSITION: relative }
		    TH.grdYSYFJHLocked { Z-INDEX: 99 }
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
				
				if (document.all("divYSYFJH") == null)
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
				intHeight -= trRow10.clientHeight;
				intHeight -= trRow11.clientHeight;
				strHeight  = intHeight.toString() + "px";
				//if (document.readyState.toLowerCase() == "complete")
                //    alert(strWidth + " " + strHeight);

				divYSYFJH.style.width  = strWidth;
				divYSYFJH.style.height = strHeight;
				divYSYFJH.style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";
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
        <form id="frmestate_cw_ysyf" method="post" runat="server">
            <asp:panel id="panelMain" Runat="server">
                <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                    <TR>
                        <TD width="5"></TD>
                        <TD vAlign="top" align="center">
                            <TABLE cellSpacing="0" cellPadding="0" border="0">
                                <TR id="trRow01">
                                    <TD class="title" align="center" colSpan="3" height="30">收付款计划查看与编辑窗<asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton></TD>
                                </TR>
                                <TR>
                                    <TD colSpan="3" height="4"></TD>
                                </TR>
                                <TR>
                                    <TD width="5"></TD>
                                    <TD vAlign="top">
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
                                                <TD class="label" align="left" bgColor="#ccff99"><B>&gt;&gt;&gt;&gt;现有计划信息</B></TD>
                                            </TR>
                                            <TR id="trRow05">
                                                <TD class="label" style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid" align="left">
                                                    <TABLE cellSpacing="0" cellPadding="0" border="0" width="100%">
                                                        <TR>
                                                            <TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;税费&nbsp;</TD>
                                                            <TD class="label" align="left"><asp:DropDownList id="ddlYSYFJHSearch_SFDM" runat="server" CssClass="textbox"></asp:DropDownList></TD>
                                                            <TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;对象&nbsp;</TD>
                                                            <TD class="label" align="left">
                                                                <asp:DropDownList id="ddlYSYFJHSearch_SFDX" runat="server" CssClass="textbox">
                                                                    <asp:ListItem Value=""></asp:ListItem>
                                                                    <asp:ListItem Value="甲">甲方</asp:ListItem>
                                                                    <asp:ListItem Value="乙">乙方</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </TD>
                                                            <TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;收付&nbsp;</TD>
                                                            <TD class="label" align="left">
                                                                <asp:DropDownList id="ddlYSYFJHSearch_SFBZ" runat="server" CssClass="textbox">
                                                                    <asp:ListItem Value=""></asp:ListItem>
                                                                    <asp:ListItem Value="收">收</asp:ListItem>
                                                                    <asp:ListItem Value="付">付</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </TD>
                                                            <TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;日期&nbsp;</TD>
                                                            <TD class="label" align="left"><asp:TextBox id="txtYSYFJHSearch_YSRQMin" Runat="server" CssClass="textbox" Columns="10"></asp:TextBox>~<asp:TextBox id="txtYSYFJHSearch_YSRQMax" Runat="server" CssClass="textbox" Columns="10"></asp:TextBox></TD>
                                                            <TD class="label">&nbsp;&nbsp;<asp:button id="btnYSYFJHSearch" Runat="server" CssClass="button" Text=" 快速搜索 "></asp:button><asp:button id="btnYSYFJHSearch_Full" Runat="server" CssClass="button" Text=" 全文搜索 "></asp:button></TD>
                                                        </TR>
                                                    </TABLE>
                                                </TD>
                                            </TR>
                                            <TR>
                                                <TD>
                                                    <DIV id="divYSYFJH" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 964px; CLIP: rect(0px 964px 221px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 221px">
                                                        <asp:datagrid id="grdYSYFJH" runat="server" CssClass="label" Font-Size="12px" UseAccessibleHeader="True"
                                                            AllowPaging="True" AutoGenerateColumns="False" GridLines="Vertical" BorderStyle="None" PageSize="30"
                                                            BorderColor="#DEDFDE" BorderWidth="0px" AllowSorting="True" CellPadding="4" Font-Names="宋体">
                                                            <SelectedItemStyle Font-Size="12px" Font-Names="宋体" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
                                                            <EditItemStyle Font-Size="12px" Font-Names="宋体" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
                                                            <AlternatingItemStyle Font-Size="12px" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
                                                            <ItemStyle Font-Size="12px" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
                                                            <HeaderStyle Font-Size="12px" Font-Names="宋体" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#6699cc" HorizontalAlign="Left"></HeaderStyle>
                                                            <FooterStyle BackColor="#CCCC99"></FooterStyle>
                                                            
                                                            <Columns>
                                                                <asp:TemplateColumn HeaderText="选" ItemStyle-Width="20px">
                                                                    <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
                                                                    <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox id="chkYSYFJH" runat="server" AutoPostBack="False"></asp:CheckBox>
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
                                                                <asp:ButtonColumn ItemStyle-Width="180px" DataTextField="税费名称" SortExpression="税费名称" HeaderText="税费" CommandName="Select">
                                                                    <HeaderStyle Width="180px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn ItemStyle-Width="60px" DataTextField="收付对象" SortExpression="收付对象" HeaderText="对象" CommandName="Select">
                                                                    <HeaderStyle Width="60px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn Visible="False" DataTextField="收付标志" SortExpression="收付标志" HeaderText="收付" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn ItemStyle-Width="140px" DataTextField="应收日期" SortExpression="应收日期" HeaderText="应收日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
                                                                    <HeaderStyle Width="140px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="应收金额" SortExpression="应收金额" HeaderText="应收金额(元)" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
                                                                    <HeaderStyle Width="0px" HorizontalAlign="Right"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="应收金额收" SortExpression="应收金额收" HeaderText="收(元)" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
                                                                    <HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="应收金额付" SortExpression="应收金额付" HeaderText="付(元)" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
                                                                    <HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="实收金额" SortExpression="实收金额" HeaderText="财务核定(元)" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
                                                                    <HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="收付状态" SortExpression="收付状态" HeaderText="收付状态" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn ItemStyle-Width="300px" DataTextField="其他描述" SortExpression="其他描述" HeaderText="摘要" CommandName="Select">
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
                                                        </asp:datagrid><INPUT id="htxtYSYFJHFixed" type="hidden" value="0" runat="server">
                                                    </DIV>
                                                </TD>
                                            </TR>
                                            <TR id="trRow06">
                                                <TD class="label">
                                                    <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                        <TR>
                                                            <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZYSYFJHDeSelectAll" runat="server">不选</asp:linkbutton></TD>
                                                            <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZYSYFJHSelectAll" runat="server">全选</asp:linkbutton></TD>
                                                            <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZYSYFJHMoveFirst" runat="server">最前</asp:linkbutton></TD>
                                                            <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZYSYFJHMovePrev" runat="server">前页</asp:linkbutton></TD>
                                                            <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZYSYFJHMoveNext" runat="server">下页</asp:linkbutton></TD>
                                                            <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZYSYFJHMoveLast" runat="server">最后</asp:linkbutton></TD>
                                                            <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZYSYFJHGotoPage" runat="server">前往</asp:linkbutton><asp:textbox id="txtYSYFJHPageIndex" runat="server" CssClass="textbox" Columns="3">1</asp:textbox>页</TD>
                                                            <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZYSYFJHSetPageSize" runat="server" >每页</asp:linkbutton><asp:textbox id="txtYSYFJHPageSize" runat="server" CssClass="textbox" Columns="3">30</asp:textbox>条</TD>
                                                            <TD class="label" vAlign="middle" noWrap align="right"><asp:label id="lblYSYFJHGridLocInfo" runat="server" CssClass="label" >1/10 N/15</asp:label></TD>
                                                        </TR>
                                                    </TABLE>
                                                </TD>
                                            </TR>
                                            <TR id="trRow07">
                                                <TD class="label" align="left" bgColor="#ccff99"><% if propEditMode = true then response.write("<div style='display:none'>") %><B>&gt;&gt;&gt;&gt;根据付款方式生成</B><% if propEditMode = true then response.write("</div>") %></TD>
                                            </TR>
                                            <TR id="trRow08">
                                                <TD>
                                                    <% if propEditMode = true then response.write("<div style='display:none'>") %>
                                                    <TABLE cellSpacing="0" cellPadding="0" border="0" width="100%">
                                                        <TR>
                                                            <TD class="label" align="right" nowrap>指定付款方式：</TD>
                                                            <TD class="label" align="left" width="60%"><asp:DropDownList id="ddlFKFS" Runat="server" CssClass="textbox" Width="100%"></asp:DropDownList></TD>
                                                            <td class="label" align="center" nowrap><asp:CheckBox ID="chkQCXY" Runat="server" CssClass="textbox" Text="清除现有计划数据" Checked="False"></asp:CheckBox></td>
                                                            <TD align="center"><asp:Button id="btnMakeJH" Runat="server" CssClass="button" Text="生成收款计划"></asp:Button></TD>
                                                        </TR>
                                                    </TABLE>
                                                    <% if propEditMode = true then response.write("</div>") %>
                                                </TD>
                                            </TR>
                                            <TR id="trRow09">
                                                <TD class="label" align="left" bgColor="#ccff99"><% if propEditMode = false then response.write("<div style='display:none'>") %><B>&gt;&gt;&gt;&gt;手工编辑收款计划</B><% if propEditMode = false then response.write("</div>") %><INPUT id="htxtSFZT" type="hidden" size="1" runat="server"><INPUT id="htxtWYBS" type="hidden" size="1" runat="server"><INPUT id="htxtQRSH" type="hidden" size="1" runat="server"></TD>
                                            </TR>
                                            <TR id="trRow10">
                                                <TD class="label" align="center">
                                                    <% if propEditMode = false then response.write("<div style='display:none'>") %>
                                                    <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                        <TR>
                                                            <TD class="labelNotNull" noWrap align="right">&nbsp;&nbsp;对象</TD>
                                                            <TD class="label" align="left" width="15%" style="BORDER-BOTTOM: #99cccc 1px solid">
                                                                <asp:RadioButtonList id="rblSFDX" Runat="server" CssClass="textbox" RepeatLayout="Flow" RepeatDirection="Vertical" RepeatColumns="2">
                                                                    <asp:ListItem Value="甲">甲方</asp:ListItem>
                                                                    <asp:ListItem Value="乙">乙方</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </TD>
                                                            <TD class="labelNotNull" align="right">&nbsp;&nbsp;日期</TD>
                                                            <TD class="label" align="left" width="15%" style="BORDER-BOTTOM: #99cccc 1px solid"><asp:TextBox id="txtYSRQ" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox></TD>
                                                            <TD class="labelNotNull" noWrap align="right">&nbsp;&nbsp;税费</TD>
                                                            <TD class="label" align="left" width="50%" style="BORDER-BOTTOM: #99cccc 1px solid"><asp:DropDownList id="ddlSFDM" Runat="server" CssClass="textbox" Width="100%"></asp:DropDownList></TD>
                                                            <TD align="center"><asp:button id="btnSave" Runat="server" CssClass="button" Text=" 保    存 "></asp:button></TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="labelNotNull" noWrap align="right">&nbsp;&nbsp;收付</TD>
                                                            <TD class="label" align="left" style="BORDER-BOTTOM: #99cccc 1px solid">
                                                                <asp:RadioButtonList id="rblSFBZ" Runat="server" CssClass="textbox" RepeatLayout="Flow" RepeatDirection="Vertical" RepeatColumns="2">
                                                                    <asp:ListItem Value="收">收</asp:ListItem>
                                                                    <asp:ListItem Value="付">付</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </TD>
                                                            <TD class="label" align="right" nowrap>&nbsp;&nbsp;金额(元)</TD>
                                                            <TD class="label" align="left" style="BORDER-BOTTOM: #99cccc 1px solid"><asp:textbox id="txtYSJE" Runat="server" CssClass="textbox" Width="100%"></asp:textbox></TD>
                                                            <TD class="label" align="right">&nbsp;&nbsp;摘要</TD>
                                                            <TD class="label" align="left" style="BORDER-BOTTOM: #99cccc 1px solid"><asp:textbox id="txtQTMS" Runat="server" CssClass="textbox" Width="100%"></asp:textbox></TD>
                                                            <TD align="center"><asp:button id="btnCancel" Runat="server" CssClass="button" Text=" 取    消 "></asp:button></TD>
                                                        </TR>
                                                    </TABLE>
                                                    <% if propEditMode = false then response.write("</div>") %>
                                                </TD>
                                            </TR>
                                        </TABLE>
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
                    <TR id="trRow11">
                        <TD align="center" colSpan="3">
                            <asp:Button id="btnAddNew" Runat="server" CssClass="button" Text=" 增    加 " Height="36px"></asp:Button>
                            <asp:Button id="btnUpdate" Runat="server" CssClass="button" Text=" 修    改 " Height="36px"></asp:Button>
                            <asp:Button id="btnDelete" Runat="server" CssClass="button" Text=" 删    除 " Height="36px"></asp:Button>
                            <asp:Button id="btnPrint" Runat="server" CssClass="button" Text=" 打    印 " Height="36px"></asp:Button>
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
                        <input id="htxtCurrentPage" type="hidden" runat="server">
                        <input id="htxtCurrentRow" type="hidden" runat="server">
                        <input id="htxtEditMode" type="hidden" runat="server">
                        <input id="htxtEditType" type="hidden" runat="server">
                        <input id="htxtSessionIdQuery" type="hidden" runat="server">
                        <input id="htxtYSYFJHQuery" type="hidden" runat="server">
                        <input id="htxtYSYFJHRows" type="hidden" runat="server">
                        <input id="htxtYSYFJHSort" type="hidden" runat="server">
                        <input id="htxtYSYFJHSortColumnIndex" type="hidden" runat="server">
                        <input id="htxtYSYFJHSortType" type="hidden" runat="server">
                        <input id="htxtDivLeftYSYFJH" type="hidden" runat="server">
                        <input id="htxtDivTopYSYFJH" type="hidden" runat="server">
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
							function ScrollProc_divYSYFJH() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopYSYFJH");
								if (oText != null) oText.value = divYSYFJH.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftYSYFJH");
								if (oText != null) oText.value = divYSYFJH.scrollLeft;
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
								oText=document.getElementById("htxtDivTopYSYFJH");
								if (oText != null) divYSYFJH.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftYSYFJH");
								if (oText != null) divYSYFJH.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divYSYFJH.onscroll = ScrollProc_divYSYFJH;
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
