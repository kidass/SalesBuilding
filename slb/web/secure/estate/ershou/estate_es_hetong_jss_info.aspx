<%@ Page Language="vb" AutoEventWireup="false" Codebehind="estate_es_hetong_jss_info.aspx.vb" Inherits="Josco.JSOA.web.estate_es_hetong_jss_info" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
    <HEAD>
        <title>结算书查看与编辑</title>
        <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
        <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
        <meta content="JavaScript" name="vs_defaultClientScript">
        <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <LINK href="../../../styles01.css" type="text/css" rel="stylesheet">
        <style>
			TD.grdJSMXLocked { ; LEFT: expression(divJSMX.scrollLeft); POSITION: relative }
			TH.grdJSMXLocked { ; LEFT: expression(divJSMX.scrollLeft); POSITION: relative }
			TH.grdJSMXLocked { Z-INDEX: 99 }
			TD.grdYEJILocked { ; LEFT: expression(divYEJI.scrollLeft); POSITION: relative }
			TH.grdYEJILocked { ; LEFT: expression(divYEJI.scrollLeft); POSITION: relative }
			TH.grdYEJILocked { Z-INDEX: 99 }
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
        <form id="frmestate_es_hetong_jss_info" method="post" runat="server">
            <asp:panel id="panelMain" Runat="server">
                <TABLE cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
                    <TR id="trRow1">
                        <TD align="center">
                            <TABLE cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
                                <TR>
                                    <TD class="title" align="center">合同结算书<asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton></TD><TD width="20">&nbsp;</TD>
                                </TR>
                                <TR>
                                    <TD class="labelNotNull" vAlign="middle" align="right">结算书号：<asp:TextBox id="txtJSSH" runat="server" CssClass="textbox" Columns="16"></asp:TextBox>&nbsp;&nbsp;结算日期：<asp:TextBox id="txtJSRQ" runat="server" CssClass="textbox" Columns="8"></asp:TextBox>&nbsp;&nbsp;计佣日期：<asp:TextBox id="txtJYRQ" runat="server" CssClass="textbox" Columns="8"></asp:TextBox><INPUT id="htxtWYBS" type="hidden" size="1" runat="server"><INPUT id="htxtQRSH" type="hidden" size="1" runat="server"><INPUT id="htxtZTBZ" type="hidden" size="1" runat="server"></TD>
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
                                        <TD class="label" align="left" bgColor="#ccff99"><B>&gt;&gt;&gt;&gt;基本资料</B></TD>
                                    </TR>
                                    <TR>
                                        <TD>
                                            <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                <TR>
                                                    <TD class="labelAuto" noWrap align="right">合同类型</TD>
                                                    <TD align="left">
                                                        <asp:RadioButtonList id="rblHTLX" Runat="server" Width="360px" CssClass="textbox" RepeatLayout="Flow" RepeatDirection="Vertical" RepeatColumns="3">
                                                            <asp:ListItem Value="二手.租赁">租赁</asp:ListItem>
                                                            <asp:ListItem Value="二手.买卖">买卖</asp:ListItem>
                                                            <asp:ListItem Value="二手.其他">其他</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </TD>
                                                    <TD width="20">&nbsp;</TD>
                                                    <TD class="labelAuto" noWrap align="right">合同编号：</TD>
                                                    <TD align="left"><asp:TextBox id="txtHTBH" Runat="server" Width="360px" CssClass="textbox"></asp:TextBox></TD>
                                                </TR>
                                                <tr>
                                                    <TD class="labelAuto" noWrap align="right">物业地址</TD>
                                                    <TD align="left" colspan="4"><asp:TextBox id="txtWYDZ" Runat="server" Width="100%" CssClass="textbox"></asp:TextBox></td>
                                                </tr>
                                                <TR>
                                                    <TD class="labelNotNull" noWrap align="right">结算类型</TD>
                                                    <TD align="left">
                                                        <asp:RadioButtonList id="rblJSLX" Runat="server" Width="360px" CssClass="textbox" RepeatLayout="Flow" RepeatDirection="Vertical" RepeatColumns="2">
                                                            <asp:ListItem Value="1">中介费</asp:ListItem>
                                                            <asp:ListItem Value="2">律师费</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </TD>
                                                    <TD width="20">&nbsp;</TD>
                                                    <TD class="labelAuto" noWrap align="right">合同折扣：</TD>
                                                    <TD align="left"><asp:TextBox id="txtHTZK" Runat="server" Width="360px" CssClass="textbox"></asp:TextBox></TD>
                                                </TR>
                                                <TR>
                                                    <TD class="labelAuto" noWrap align="right">甲方名称：</TD>
                                                    <TD align="left"><asp:TextBox id="txtJFMC" Runat="server" Width="360px" CssClass="textbox"></asp:TextBox></TD>
                                                    <TD width="20">&nbsp;</TD>
                                                    <TD class="labelAuto" noWrap align="right">乙方名称：</TD>
                                                    <TD align="left"><asp:TextBox id="txtYFMC" Runat="server" Width="360px" CssClass="textbox"></asp:TextBox></TD>
                                                </TR>
                                                <TR>
                                                    <TD class="labelNotNull" noWrap align="right">经办人员：</TD>
                                                    <TD align="left"><asp:TextBox id="txtJBRY" runat="server" Width="360px" CssClass="textbox"></asp:TextBox><asp:Button id="btnSelect_JBRY" Runat="server" CssClass="button" Text="…"></asp:Button><INPUT id="htxtJBRY" type="hidden" size="1" runat="server"></TD>
                                                    <TD width="20">&nbsp;</TD>
                                                    <TD class="labelNotNull" noWrap align="right">结算单位：</TD>
                                                    <TD align="left"><asp:TextBox id="txtJSDW" runat="server" Width="360px" CssClass="textbox"></asp:TextBox><asp:Button id="btnSelect_JSDW" Runat="server" CssClass="button" Text="…"></asp:Button><INPUT id="htxtJSDW" type="hidden" size="1" runat="server"></TD>
                                                </TR>
                                                <TR>
                                                    <TD class="labelAuto" noWrap align="right">结算中介费：</TD>
                                                    <TD align="left" colSpan="4"><asp:TextBox id="txtZJFE" Runat="server" Width="100%" CssClass="textbox"></asp:TextBox></TD>
                                                </TR>
                                                <TR>
                                                    <TD class="labelAuto" noWrap align="right">甲方结算额：</TD>
                                                    <TD align="left"><asp:TextBox id="txtJSEJ" Runat="server" Width="360px" CssClass="textbox"></asp:TextBox></TD>
                                                    <TD width="20">&nbsp;</TD>
                                                    <TD class="labelAuto" noWrap align="right">乙方结算额：</TD>
                                                    <TD align="left"><asp:TextBox id="txtJSEY" Runat="server" Width="360px" CssClass="textbox"></asp:TextBox></TD>
                                                </TR>
                                                <TR>
                                                    <TD class="labelAuto" noWrap align="right">甲方实收额：</TD>
                                                    <TD align="left"><asp:TextBox id="txtSSEJ" runat="server" Width="360px"></asp:TextBox></TD>
                                                    <TD width="20">&nbsp;</TD>
                                                    <TD class="labelAuto" noWrap align="right">乙方实收额：</TD>
                                                    <TD align="left"><asp:TextBox id="txtSSEY" runat="server" Width="360px"></asp:TextBox></TD>
                                                </TR>
                                                <TR>
                                                    <TD class="label" noWrap align="right">备注信息：</TD>
                                                    <TD align="left" colSpan="4"><asp:TextBox id="txtBZXX" Runat="server" Width="100%" CssClass="textbox"></asp:TextBox></TD>
                                                </TR>
                                            </TABLE>
                                        </TD>
                                    </TR>
                                    <TR>
                                        <TD class="label" align="left" bgColor="#ccff99"><B>&gt;&gt;&gt;&gt;费用明细</B></TD>
                                    </TR>
                                    <TR>
                                        <TD>
                                            <TABLE cellSpacing="0" cellPadding="0" border="0">
                                                <TR>
                                                    <TD>
                                                        <DIV id="divJSMX" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 900px; CLIP: rect(0px 900px 200px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 200px">
                                                            <asp:datagrid id="grdJSMX" runat="server" CssClass="label" CellPadding="4" AllowSorting="False"
                                                                BorderWidth="0px" BorderColor="#DEDFDE" PageSize="30" BorderStyle="None" BackColor="White"
                                                                GridLines="Vertical" AutoGenerateColumns="False" AllowPaging="False" UseAccessibleHeader="True">
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
                                                                            <asp:CheckBox id="chkJSMX" runat="server" AutoPostBack="False"></asp:CheckBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="唯一标识" SortExpression="唯一标识" HeaderText="唯一标识" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="确认书号" SortExpression="确认书号" HeaderText="确认书号" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="结算书号" SortExpression="结算书号" HeaderText="结算书号" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:TemplateColumn HeaderText="结算费用" ItemStyle-Width="50%">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="50%"></HeaderStyle>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:DropDownList ID="ddlJSMX_SFDM" Runat="server" CssClass="textbox" Width="100%"></asp:DropDownList>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn HeaderText="甲方" ItemStyle-Width="25%">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="25%"></HeaderStyle>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtJSMX_JSEJ" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn HeaderText="乙方" ItemStyle-Width="25%">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="25%"></HeaderStyle>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtJSMX_JSEY" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="结算金额" SortExpression="结算金额" HeaderText="结算金额" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
                                                                        <HeaderStyle Width="0px" HorizontalAlign="Right"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="结算对象" SortExpression="结算对象" HeaderText="结算对象" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="结算摘要" SortExpression="结算摘要" HeaderText="结算摘要" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                </Columns>
                                                                
                                                                <PagerStyle Visible="False" NextPageText="下页" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
                                                            </asp:datagrid><INPUT id="htxtJSMXFixed" type="hidden" value="0" runat="server">
                                                        </DIV>
                                                    </TD>
                                                </TR>
                                                <TR>
                                                    <TD align="right">
                                                        <asp:Button id="btnAddNew_JSMX"  Runat="server" CssClass="button" Text=" 加入新的费用 "></asp:Button>
                                                        <asp:Button id="btnDelete_JSMX"  Runat="server" CssClass="button" Text=" 删除现有费用 "></asp:Button>
                                                        <asp:Button id="btnCompute_JSMX" Runat="server" CssClass="button" Text=" 计算相关数据 "></asp:Button>
                                                    </TD>
                                                </TR>
                                            </TABLE>
                                        </TD>
                                    </TR>
                                    <TR>
                                        <TD class="label" align="left" bgColor="#ccff99"><B>&gt;&gt;&gt;&gt;结算业绩拆分情况</B></TD>
                                    </TR>
                                    <TR>
                                        <TD>
                                            <TABLE cellSpacing="0" cellPadding="0" border="0">
                                                <TR>
                                                    <TD>
                                                        <DIV id="divYEJI" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 900px; CLIP: rect(0px 900px 300px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 300px">
                                                            <asp:datagrid id="grdYEJI" runat="server" CssClass="label" CellPadding="4" AllowSorting="False"
                                                                BorderWidth="0px" BorderColor="#DEDFDE" PageSize="30" BorderStyle="None" BackColor="White"
                                                                GridLines="Vertical" AutoGenerateColumns="False" AllowPaging="False" UseAccessibleHeader="True" Width="1420px">
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
                                                                            <asp:CheckBox id="chkYEJI" runat="server" AutoPostBack="False"></asp:CheckBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="唯一标识" SortExpression="唯一标识" HeaderText="唯一标识" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="确认书号" SortExpression="确认书号" HeaderText="确认书号" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="结算书号" SortExpression="结算书号" HeaderText="结算书号" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="业绩来源" SortExpression="业绩来源" HeaderText="业绩来源码" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="人员代码" SortExpression="人员代码" HeaderText="人员代码" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="单位代码" SortExpression="单位代码" HeaderText="单位代码" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="人员职级" SortExpression="人员职级" HeaderText="人员职级码" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="业绩来源名称" SortExpression="业绩来源名称" HeaderText="业绩类型" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="人员名称" SortExpression="人员名称" HeaderText="人员名称" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="140px" DataTextField="单位名称" SortExpression="单位名称" HeaderText="单位名称" CommandName="Select">
                                                                        <HeaderStyle Width="140px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="所属分组" SortExpression="所属分组" HeaderText="所属分组" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="60px" DataTextField="团队编号" SortExpression="团队编号" HeaderText="团队" CommandName="Select">
                                                                        <HeaderStyle Width="60px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="140px" DataTextField="人员职级名称" SortExpression="人员职级名称" HeaderText="职级" CommandName="Select">
                                                                        <HeaderStyle Width="140px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="60px" DataTextField="直管标记名称" SortExpression="直管标记名称" HeaderText="直管" CommandName="Select">
                                                                        <HeaderStyle Width="60px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="60px" DataTextField="状态标志名称" SortExpression="状态标志名称" HeaderText="状态" CommandName="Select">
                                                                        <HeaderStyle Width="60px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="120px" DataTextField="考核业绩" SortExpression="考核业绩" HeaderText="考核业绩(元)" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
                                                                        <HeaderStyle Width="120px" HorizontalAlign="Right"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:TemplateColumn HeaderText="本次计提(元)" ItemStyle-Width="120px">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="120px"></HeaderStyle>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtYEJI_BCJT" Runat="server" CssClass="textbox_right" Width="100%"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="120px" DataTextField="私佣基数" SortExpression="私佣基数" HeaderText="私佣基数(元)" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
                                                                        <HeaderStyle Width="120px" HorizontalAlign="Right"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="120px" DataTextField="公佣基数" SortExpression="公佣基数" HeaderText="公佣基数(元)" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
                                                                        <HeaderStyle Width="120px" HorizontalAlign="Right"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="120px" DataTextField="本次总额" SortExpression="本次总额" HeaderText="本次总额(元)" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
                                                                        <HeaderStyle Width="120px" HorizontalAlign="Right"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="120px" DataTextField="本次保留" SortExpression="本次保留" HeaderText="本次保留(元)" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
                                                                        <HeaderStyle Width="120px" HorizontalAlign="Right"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="直管标记" SortExpression="直管标记" HeaderText="直管标记" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="状态标志" SortExpression="状态标志" HeaderText="状态标志" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                </Columns>
                                                                
                                                                <PagerStyle Visible="False" NextPageText="下页" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
                                                            </asp:datagrid><INPUT id="htxtYEJIFixed" type="hidden" value="0" runat="server">
                                                        </DIV>
                                                    </TD>
                                                </TR>
                                                <TR>
                                                    <TD align="right">
                                                        <asp:Button id="btnCompute_YEJI" Runat="server" CssClass="button" Text=" 根据业绩分配比例自动计算 "></asp:Button>
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
                            <asp:button id="btnOK"     Runat="server" CssClass="button" Text=" 确    定 " Height="36px"></asp:button>
                            <asp:button id="btnCancel" Runat="server" CssClass="button" Text=" 取    消 " Height="36px"></asp:button>
                            <asp:button id="btnClose"  Runat="server" CssClass="button" Text=" 返    回 " Height="36px"></asp:button>
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
                        <INPUT id="htxtSessionId_JSMX" type="hidden" runat="server">
                        <INPUT id="htxtSessionId_YEJI" type="hidden" runat="server">
                        <INPUT id="htxtDivLeftJSMX" type="hidden" runat="server">
                        <INPUT id="htxtDivTopJSMX" type="hidden" runat="server">
                        <INPUT id="htxtDivLeftYEJI" type="hidden" runat="server">
                        <INPUT id="htxtDivTopYEJI" type="hidden" runat="server">
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
							function ScrollProc_divJSMX() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopJSMX");
								if (oText != null) oText.value = divJSMX.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftJSMX");
								if (oText != null) oText.value = divJSMX.scrollLeft;
								return;
							}
							function ScrollProc_divYEJI() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopYEJI");
								if (oText != null) oText.value = divYEJI.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftYEJI");
								if (oText != null) oText.value = divYEJI.scrollLeft;
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
								oText=document.getElementById("htxtDivTopJSMX");
								if (oText != null) divJSMX.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftJSMX");
								if (oText != null) divJSMX.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtDivTopYEJI");
								if (oText != null) divYEJI.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftYEJI");
								if (oText != null) divYEJI.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divMain.onscroll = ScrollProc_divMain;
								divJSMX.onscroll = ScrollProc_divJSMX;
								divYEJI.onscroll = ScrollProc_divYEJI;
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
