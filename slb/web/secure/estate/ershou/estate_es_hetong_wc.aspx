<%@ Page Language="vb" AutoEventWireup="false" Codebehind="estate_es_hetong_wc.aspx.vb" Inherits="Josco.JSOA.web.estate_es_hetong_wc" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
    <HEAD>
        <title>合同审核处理</title>
        <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
        <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
        <meta content="JavaScript" name="vs_defaultClientScript">
        <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <LINK href="../../../styles01.css" type="text/css" rel="stylesheet">
        <style>
		    TD.grdHTLocked { ; LEFT: expression(divHT.scrollLeft); POSITION: relative }
		    TH.grdHTLocked { ; LEFT: expression(divHT.scrollLeft); POSITION: relative }
		    TH.grdHTLocked { Z-INDEX: 99 }
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
				
				if (document.all("divHT") == null)
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
				intHeight -= trRow3.clientHeight;
				intHeight -= trRow4.clientHeight;
				strHeight  = intHeight.toString() + "px";

				divHT.style.width  = strWidth;
				divHT.style.height = strHeight;
				divHT.style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";
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
        <form id="frmestate_es_hetong_wc" method="post" runat="server">
            <asp:panel id="panelMain" Runat="server">
                <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                    <TR>
                        <TD width="5"></TD>
                        <TD vAlign="top" align="center">
                            <TABLE cellSpacing="0" cellPadding="0" border="0">
                                <TR id="trRow1">
                                    <TD class="title" align="center" colSpan="3" height="30">合同结案处理<asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton></TD>
                                </TR>
                                <TR>
                                    <TD width="5"></TD>
                                    <TD vAlign="top">
                                        <TABLE cellSpacing="0" cellPadding="0" border="0">
                                            <TR>
                                                <TD>
                                                    <TABLE cellSpacing="0" cellPadding="0" align="center" border="0">
                                                        <TR id="trRow2">
                                                            <TD align="left">
                                                                <TABLE cellSpacing="0" cellPadding="0" border="0">
                                                                    <TR>
                                                                        <TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;确认书号&nbsp;</TD>
                                                                        <TD class="label" align="left"><asp:textbox id="txtHTSearch_QRSH" runat="server" Columns="6" CssClass="textbox"></asp:textbox></TD>
                                                                        <TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;合同编号&nbsp;</TD>
                                                                        <TD class="label" align="left"><asp:textbox id="txtHTSearch_HTBH" runat="server" Columns="6" CssClass="textbox"></asp:textbox></TD>
                                                                        <TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;合同日期&nbsp;</TD>
                                                                        <TD class="label" align="left"><asp:textbox id="txtHTSearch_HTRQMin" runat="server" Columns="7" CssClass="textbox"></asp:textbox>~<asp:textbox id="txtHTSearch_HTRQMax" runat="server" Columns="7" CssClass="textbox"></asp:textbox></TD>
                                                                        <TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;状态&nbsp;</TD>
                                                                        <TD class="label" align="left">
                                                                            <asp:DropDownList id="ddlHTSearch_HTZT" runat="server" CssClass="textbox">
                                                                                <asp:ListItem Value=""></asp:ListItem>
                                                                                <asp:ListItem Value="&1=0">未审</asp:ListItem>
                                                                                <asp:ListItem Value="&1=1">已审</asp:ListItem>
                                                                                <asp:ListItem Value="&2=0">未结</asp:ListItem>
                                                                                <asp:ListItem Value="&2=2">已结</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </TD>
                                                                        <TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;甲方&nbsp;</TD>
                                                                        <TD class="label" align="left"><asp:textbox id="txtHTSearch_JFMC" runat="server" Columns="6" CssClass="textbox"></asp:textbox></TD>
                                                                        <TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;乙方&nbsp;</TD>
                                                                        <TD class="label" align="left"><asp:textbox id="txtHTSearch_YFMC" runat="server" Columns="6" CssClass="textbox"></asp:textbox></TD>
                                                                        <TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;房屋地址&nbsp;</TD>
                                                                        <TD class="label" align="left"><asp:textbox id="txtHTSearch_FWDZ" runat="server" Columns="10" CssClass="textbox"></asp:textbox></TD>
                                                                        <TD class="label" align="right" colSpan="2">&nbsp;&nbsp;<asp:button id="btnHTSearch" Runat="server" CssClass="button" Text="快速"></asp:button><asp:button id="btnHTSearch_Full" Runat="server" CssClass="button" Text="全文"></asp:button></TD>
                                                                    </TR>
                                                                </TABLE>
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD>
                                                                <DIV id="divHT" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 964px; CLIP: rect(0px 964px 406px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 406px">
                                                                    <asp:datagrid id="grdHT" runat="server" Width="7730px" CssClass="label" UseAccessibleHeader="True"
                                                                        AllowPaging="True" AutoGenerateColumns="False" GridLines="Vertical" BackColor="White" BorderStyle="None"
                                                                        PageSize="30" BorderColor="#DEDFDE" BorderWidth="0px" AllowSorting="True" CellPadding="4">
                                                                        <SelectedItemStyle Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
                                                                        <EditItemStyle VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
                                                                        <AlternatingItemStyle BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
                                                                        <ItemStyle BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
                                                                        <HeaderStyle Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#6699cc" HorizontalAlign="Left"></HeaderStyle>
                                                                        <FooterStyle BackColor="#CCCC99"></FooterStyle>
                                                                        
                                                                        <Columns>
                                                                            <asp:TemplateColumn HeaderText="选" Visible="False" ItemStyle-Width="20px">
                                                                                <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
                                                                                <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox id="chkHT" runat="server" AutoPostBack="False" Visible="False"></asp:CheckBox>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateColumn>
                                                                            <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="唯一标识" SortExpression="唯一标识" HeaderText="唯一标识" CommandName="Select">
                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="合同唯一标识" SortExpression="合同唯一标识" HeaderText="合同唯一标识" CommandName="Select">
                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="交易类型" SortExpression="交易类型" HeaderText="类型" CommandName="Select">
                                                                                <HeaderStyle Width="100px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="120px" DataTextField="交易编号" SortExpression="交易编号" HeaderText="确认书号" CommandName="OpenDocument">
                                                                                <HeaderStyle Width="120px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="120px" DataTextField="合同编号" SortExpression="合同编号" HeaderText="合同编号" CommandName="OpenDocument">
                                                                                <HeaderStyle Width="120px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="140px" DataTextField="交易日期" SortExpression="交易日期" HeaderText="订购日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
                                                                                <HeaderStyle Width="140px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="140px" DataTextField="合同日期" SortExpression="合同日期" HeaderText="合同日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
                                                                                <HeaderStyle Width="140px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="140px" DataTextField="统计日期" SortExpression="统计日期" HeaderText="统计日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
                                                                                <HeaderStyle Width="140px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="140px" DataTextField="结案日期" SortExpression="结案日期" HeaderText="结案日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
                                                                                <HeaderStyle Width="140px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="交易状态" SortExpression="交易状态" HeaderText="交易状态" CommandName="Select">
                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="合同状态" SortExpression="合同状态" HeaderText="合同状态码" CommandName="Select">
                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="合同状态名称" SortExpression="合同状态名称" HeaderText="合同状态" CommandName="Select">
                                                                                <HeaderStyle Width="100px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="业主名称" SortExpression="业主名称" HeaderText="甲方" CommandName="Select">
                                                                                <HeaderStyle Width="160px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="客户名称" SortExpression="客户名称" HeaderText="乙方" CommandName="Select">
                                                                                <HeaderStyle Width="160px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="700px" DataTextField="物业地址" SortExpression="物业地址" HeaderText="房屋地址" CommandName="Select">
                                                                                <HeaderStyle Width="700px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="交易价格" SortExpression="交易价格" HeaderText="交易金额" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
                                                                                <HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="交易面积" SortExpression="交易面积" HeaderText="交易面积" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
                                                                                <HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="甲方代理费" SortExpression="甲方代理费" HeaderText="甲方代理费" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
                                                                                <HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="乙方代理费" SortExpression="乙方代理费" HeaderText="乙方代理费" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
                                                                                <HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="代理费折扣" SortExpression="代理费折扣" HeaderText="代理费折扣" CommandName="Select" DataTextFormatString="{0:#.00%}" ItemStyle-HorizontalAlign="Right">
                                                                                <HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="200px" DataTextField="甲方联系电话" SortExpression="甲方联系电话" HeaderText="甲方联系电话" CommandName="Select">
                                                                                <HeaderStyle Width="200px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="300px" DataTextField="甲方联系地址" SortExpression="甲方联系地址" HeaderText="甲方联系地址" CommandName="Select">
                                                                                <HeaderStyle Width="300px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="200px" DataTextField="乙方联系电话" SortExpression="乙方联系电话" HeaderText="乙方联系电话" CommandName="Select">
                                                                                <HeaderStyle Width="200px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="300px" DataTextField="乙方联系地址" SortExpression="乙方联系地址" HeaderText="乙方联系地址" CommandName="Select">
                                                                                <HeaderStyle Width="300px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="甲方证件类型" SortExpression="甲方证件类型" HeaderText="甲方证件类型" CommandName="Select">
                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="甲方证照号码" SortExpression="甲方证照号码" HeaderText="甲方证照号码" CommandName="Select">
                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="甲方代理人" SortExpression="甲方代理人" HeaderText="甲方代理人" CommandName="Select">
                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="乙方证件类型" SortExpression="乙方证件类型" HeaderText="乙方证件类型" CommandName="Select">
                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="乙方证照号码" SortExpression="乙方证照号码" HeaderText="乙方证照号码" CommandName="Select">
                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="乙方代理人" SortExpression="乙方代理人" HeaderText="乙方代理人" CommandName="Select">
                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                            </asp:ButtonColumn>

																            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="客源编号" SortExpression="客源编号" HeaderText="客源编号" CommandName="Select">
																	            <HeaderStyle Width="160px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="查册地址" SortExpression="查册地址" HeaderText="查册地址" CommandName="Select">
																	            <HeaderStyle Width="160px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="查册费" SortExpression="查册费" HeaderText="查册费" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																	            <HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="实收佣金" SortExpression="实收佣金" HeaderText="实收佣金" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																	            <HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="合作佣金" SortExpression="合作佣金" HeaderText="合作佣金" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																	            <HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="按揭机构" SortExpression="按揭机构" HeaderText="按揭机构" CommandName="Select">
																	            <HeaderStyle Width="160px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="按揭银行" SortExpression="按揭银行" HeaderText="按揭银行" CommandName="Select">
																	            <HeaderStyle Width="160px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="按揭成数" SortExpression="按揭成数" HeaderText="按揭成数" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																	            <HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="按揭年限" SortExpression="按揭年限" HeaderText="按揭年限" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																	            <HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="业主区码" SortExpression="业主区码" HeaderText="业主地区" CommandName="Select">
																	            <HeaderStyle Width="160px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="业主区名" SortExpression="业主区名" HeaderText="业主地区补充" CommandName="Select">
																	            <HeaderStyle Width="160px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="业主来源" SortExpression="业主来源" HeaderText="业主来源" CommandName="Select">
																	            <HeaderStyle Width="160px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="业源其他" SortExpression="业源其他" HeaderText="业主来源补充" CommandName="Select">
																	            <HeaderStyle Width="160px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="业主电邮" SortExpression="业主电邮" HeaderText="业主电邮" CommandName="Select">
																	            <HeaderStyle Width="160px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="售后意向" SortExpression="售后意向" HeaderText="售后意向" CommandName="Select">
																	            <HeaderStyle Width="160px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="剩余物业" SortExpression="剩余物业" HeaderText="剩余物业" CommandName="Select">
																	            <HeaderStyle Width="160px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="买家区码" SortExpression="买家区码" HeaderText="买家地区" CommandName="Select">
																	            <HeaderStyle Width="160px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="买家区名" SortExpression="买家区名" HeaderText="买家地区补充" CommandName="Select">
																	            <HeaderStyle Width="160px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="客户来源" SortExpression="客户来源" HeaderText="客户来源" CommandName="Select">
																	            <HeaderStyle Width="160px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="客源其他" SortExpression="客源其他" HeaderText="客户来源补充" CommandName="Select">
																	            <HeaderStyle Width="160px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="客户电邮" SortExpression="客户电邮" HeaderText="客户电邮" CommandName="Select">
																	            <HeaderStyle Width="160px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="购买目的" SortExpression="购买目的" HeaderText="购买目的" CommandName="Select">
																	            <HeaderStyle Width="160px"></HeaderStyle>
																            </asp:ButtonColumn>

																            <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="合同标志" SortExpression="合同标志" HeaderText="合同标志" CommandName="Select">
																	            <HeaderStyle Width="100px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="140px" DataTextField="解除日期" SortExpression="解除日期" HeaderText="解除日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	            <HeaderStyle Width="140px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="140px" DataTextField="坏账日期" SortExpression="坏账日期" HeaderText="坏账日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	            <HeaderStyle Width="140px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="坏账金额" SortExpression="坏账金额" HeaderText="坏账金额" CommandName="Select" DataTextFormatString="{0:#,##0.00}">
																	            <HeaderStyle Width="160px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="合同解除" SortExpression="合同解除" HeaderText="合同解除" CommandName="Select">
																	            <HeaderStyle Width="100px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="坏账合同" SortExpression="坏账合同" HeaderText="坏账合同" CommandName="Select">
																	            <HeaderStyle Width="100px"></HeaderStyle>
																            </asp:ButtonColumn>

																            <asp:ButtonColumn ItemStyle-Width="140px" DataTextField="租赁开始" SortExpression="租赁开始" HeaderText="租赁开始" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	            <HeaderStyle Width="140px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="140px" DataTextField="租赁结束" SortExpression="租赁结束" HeaderText="租赁结束" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	            <HeaderStyle Width="140px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="140px" DataTextField="水电煤气" SortExpression="水电煤气" HeaderText="水电煤气" CommandName="Select">
																	            <HeaderStyle Width="140px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="140px" DataTextField="电话费" SortExpression="电话费" HeaderText="电话费" CommandName="Select">
																	            <HeaderStyle Width="140px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="140px" DataTextField="管理费" SortExpression="管理费" HeaderText="管理费" CommandName="Select">
																	            <HeaderStyle Width="140px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="140px" DataTextField="租赁发票" SortExpression="租赁发票" HeaderText="租赁发票" CommandName="Select">
																	            <HeaderStyle Width="140px"></HeaderStyle>
																            </asp:ButtonColumn>
                                                                        </Columns>
                                                                        
                                                                        <PagerStyle Visible="False" NextPageText="下页" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
                                                                    </asp:datagrid><INPUT id="htxtHTFixed" type="hidden" value="0" runat="server">
                                                                </DIV>
                                                            </TD>
                                                        </TR>
                                                        <TR id="trRow3">
                                                            <TD class="label">
                                                                <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                                    <TR>
                                                                        <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZHTDeSelectAll" runat="server">不选</asp:linkbutton></TD>
                                                                        <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZHTSelectAll" runat="server">全选</asp:linkbutton></TD>
                                                                        <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZHTMoveFirst" runat="server">最前</asp:linkbutton></TD>
                                                                        <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZHTMovePrev" runat="server">前页</asp:linkbutton></TD>
                                                                        <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZHTMoveNext" runat="server">下页</asp:linkbutton></TD>
                                                                        <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZHTMoveLast" runat="server">最后</asp:linkbutton></TD>
                                                                        <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZHTGotoPage" runat="server">前往</asp:linkbutton><asp:textbox id="txtHTPageIndex" runat="server" Columns="3" CssClass="textbox">1</asp:textbox>页</TD>
                                                                        <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZHTSetPageSize" runat="server">每页</asp:linkbutton><asp:textbox id="txtHTPageSize" runat="server" Columns="3" CssClass="textbox">30</asp:textbox>条</TD>
                                                                        <TD class="label" vAlign="middle" noWrap align="right"><asp:label id="lblHTGridLocInfo" runat="server" CssClass="label">1/10 N/15</asp:label></TD>
                                                                    </TR>
                                                                </TABLE>
                                                            </TD>
                                                        </TR>
                                                    </TABLE>
                                                </TD>
                                            </TR>
                                        </TABLE>
                                    </TD>
                                    <TD width="5"></TD>
                                </TR>
                            </TABLE>
                        </TD>
                        <TD width="5"></TD>
                    </TR>
                    <TR>
                        <TD colSpan="3" height="3"></TD>
                    </TR>
                    <TR id="trRow4">
                        <TD align="center" colSpan="3">
                            <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                <TR>
                                    <TD height="4"></TD>
                                </TR>
                                <TR>
                                    <TD align="center">
                                        <asp:Button id="btnJiean" Runat="server" CssClass="button" Text="合同结案" Height="36px"></asp:Button>
                                        <asp:Button id="btnClose" Runat="server" CssClass="button" Text="返    回" Height="36px"></asp:Button>
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
                        <input id="htxtSessionIdQueryHT" type="hidden" runat="server">
                        <input id="htxtHTQuery" type="hidden" runat="server">
                        <input id="htxtHTRows" type="hidden" runat="server">
                        <input id="htxtHTSort" type="hidden" runat="server">
                        <input id="htxtHTSortColumnIndex" type="hidden" runat="server">
                        <input id="htxtHTSortType" type="hidden" runat="server">
                        <input id="htxtDivLeftHT" type="hidden" runat="server">
                        <input id="htxtDivTopHT" type="hidden" runat="server">
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
							function ScrollProc_divHT() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopHT");
								if (oText != null) oText.value = divHT.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftHT");
								if (oText != null) oText.value = divHT.scrollLeft;
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
								oText=document.getElementById("htxtDivTopHT");
								if (oText != null) divHT.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftHT");
								if (oText != null) divHT.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divHT.onscroll = ScrollProc_divHT;
								divSHQK.onscroll = ScrollProc_divSHQK;
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
