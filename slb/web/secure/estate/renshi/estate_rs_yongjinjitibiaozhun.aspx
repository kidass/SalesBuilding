<%@ Page Language="vb" AutoEventWireup="false" Codebehind="estate_rs_yongjinjitibiaozhun.aspx.vb" Inherits="Josco.JSOA.web.estate_rs_yongjinjitibiaozhun" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
    <HEAD>
        <title>佣金计提标准(一)</title>
        <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
        <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
        <meta content="JavaScript" name="vs_defaultClientScript">
        <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <LINK href="../../../stylesw.css" type="text/css" rel="stylesheet">
        <script src="../../../scripts/transkey.js"></script>
		<style>
			TD.grdGYLocked { ; LEFT: expression(divGY.scrollLeft); POSITION: relative }
			TH.grdGYLocked { ; LEFT: expression(divGY.scrollLeft); POSITION: relative }
			TH.grdGYLocked { Z-INDEX: 99 }
			TD.grdSYZJLocked { ; LEFT: expression(divSYZJ.scrollLeft); POSITION: relative }
			TH.grdSYZJLocked { ; LEFT: expression(divSYZJ.scrollLeft); POSITION: relative }
			TH.grdSYZJLocked { Z-INDEX: 99 }
			TD.grdSYZBLocked { ; LEFT: expression(divSYZB.scrollLeft); POSITION: relative }
			TH.grdSYZBLocked { ; LEFT: expression(divSYZB.scrollLeft); POSITION: relative }
			TH.grdSYZBLocked { Z-INDEX: 99 }
			TH { Z-INDEX: 10; POSITION: relative }
		</style>
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
				intHeight -= 30;                          //trRow1.clientHeight;
				intHeight -= 36;                          //trRow2.clientHeight;
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
    <body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" background="../../../images/bgmain.gif" onresize="javascript:window_onresize()">
        <form id="frmestate_rs_yongjinjitibiaozhun" method="post" runat="server">
            <asp:panel id="panelMain" Runat="server">
                <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                    <TR>
                        <TD id="trRow1" height="30" class="title" style="BORDER-BOTTOM: #99cccc 2px solid" vAlign="middle" align="left">当前位置：人事管理&nbsp;&gt;&gt;&gt;&gt;&nbsp;佣金计提标准(一)<asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton></TD>
                    </TR>
                    <TR>
                        <TD vAlign="top" align="center">
                            <DIV id="divMain" style="OVERFLOW: auto; WIDTH: 996px; CLIP: rect(0px 464px 996px 0px); HEIGHT: 464px">
                                <TABLE cellSpacing="0" cellPadding="0" border="0">
                                    <TR>
                                        <TD class="title" align="left" bgcolor="#ccff99">>>>>团队业绩佣金计提标准</TD>
                                    </TR>
                                    <TR>
                                        <TD align="center">
                                            <DIV id="divGY" style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid">
                                                <asp:datagrid id="grdGY" runat="server" Font-Size="11pt" CssClass="label" Width="910px" UseAccessibleHeader="True"
                                                    AutoGenerateColumns="False" GridLines="Vertical" BackColor="White" BorderStyle="None" CellPadding="4"
                                                    AllowPaging="False" PageSize="30" BorderColor="#DEDFDE" BorderWidth="0px" AllowSorting="False"
                                                    Font-Names="宋体">
                                                    <SelectedItemStyle Font-Size="11pt" Font-Names="宋体" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
                                                    <EditItemStyle Font-Size="11pt" Font-Names="宋体" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
                                                    <AlternatingItemStyle Font-Size="11pt" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
                                                    <ItemStyle Font-Size="11pt" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
                                                    <HeaderStyle Font-Size="11pt" Font-Names="宋体" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#87cefa" HorizontalAlign="Left"></HeaderStyle>
                                                    <FooterStyle BackColor="#CCCC99"></FooterStyle>
                                                    
                                                    <Columns>
                                                        <asp:TemplateColumn HeaderText="选" ItemStyle-Width="30px">
                                                            <HeaderStyle HorizontalAlign="Center" Width="30px"></HeaderStyle>
                                                            <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                            <ItemTemplate>
                                                                <asp:CheckBox id="chkGY" runat="server" AutoPostBack="False"></asp:CheckBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        
                                                        <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="职级代码" SortExpression="职级代码" HeaderText="职级代码" CommandName="Select">
                                                            <HeaderStyle Width="160px"></HeaderStyle>
                                                        </asp:ButtonColumn>
                                                        <asp:ButtonColumn ItemStyle-Width="240px" DataTextField="职级名称" SortExpression="职级名称" HeaderText="职级名称" CommandName="Select">
                                                            <HeaderStyle Width="240px"></HeaderStyle>
                                                        </asp:ButtonColumn>
                                                        <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="适用方法" SortExpression="适用方法" HeaderText="适用方法" CommandName="Select">
                                                            <HeaderStyle Width="0px"></HeaderStyle>
                                                        </asp:ButtonColumn>
                                                        <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="业绩标记" SortExpression="业绩标记" HeaderText="业绩标记" CommandName="Select">
                                                            <HeaderStyle Width="0px"></HeaderStyle>
                                                        </asp:ButtonColumn>
                                                        <asp:TemplateColumn HeaderText="直管直接计提" ItemStyle-Width="120px">
                                                            <HeaderStyle HorizontalAlign="Center" Width="120px"></HeaderStyle>
                                                            <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtZGZJJT" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn HeaderText="直管保留计提" ItemStyle-Width="120px">
                                                            <HeaderStyle HorizontalAlign="Center" Width="120px"></HeaderStyle>
                                                            <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtZGBLJT" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn HeaderText="协管直接计提" ItemStyle-Width="120px">
                                                            <HeaderStyle HorizontalAlign="Center" Width="120px"></HeaderStyle>
                                                            <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtXGZJJT" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn HeaderText="协管保留计提" ItemStyle-Width="120px">
                                                            <HeaderStyle HorizontalAlign="Center" Width="120px"></HeaderStyle>
                                                            <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtXGBLJT" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                    </Columns>
                                                    
                                                    <PagerStyle Visible="False" NextPageText="下页" Font-Size="11pt" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
                                                </asp:datagrid><INPUT id="htxtGYFixed" type="hidden" value="0" runat="server">
                                            </DIV>
                                        </TD>
                                    </TR>
                                    <tr>
                                        <td height="4"></td>
                                    </tr>
                                    <TR>
                                        <TD align="right" valign="middle">
                                            <asp:Button id="btnSelAll_GY" Runat="server" Text="全部选定" Font-Size="11pt" Font-Name="宋体" CssClass="button" Height="32px"></asp:Button>
                                            <asp:Button id="btnDeSelAll_GY" Runat="server" Text="全部不选" Font-Size="11pt" Font-Name="宋体" CssClass="button" Height="32px"></asp:Button>
                                            <asp:Button id="btnAddNew_GY" Runat="server" Text="加入新的职级" Font-Size="11pt" Font-Name="宋体" CssClass="button" Height="32px"></asp:Button>
                                            <asp:Button id="btnDelete_GY" Runat="server" Text="删除选定职级" Font-Size="11pt" Font-Name="宋体" CssClass="button" Height="32px"></asp:Button>
                                        </TD>
                                    </TR>
                                    <TR>
                                        <TD align="left">
                                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                <tr>
                                                    <td align="left" class="label" bgcolor="#ccff99">填写说明：</td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="label">&nbsp;&nbsp;&nbsp;&nbsp;(1) 计提比例录入百分数的实际值，如35%，则录入0.35</td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="label">&nbsp;&nbsp;&nbsp;&nbsp;(2) 比例不设置请填0</td>
                                                </tr>
                                            </table>
                                        </TD>
                                    </TR>
                                    <TR>
                                        <TD class="title" align="left" bgcolor="#ccff99">>>>>私人业绩佣金计提标准</TD>
                                    </TR>
                                    <TR>
                                        <TD align="center">
                                            <TABLE cellSpacing="0" cellPadding="0" border="0">
                                                <TR>
                                                    <TD vAlign="top">
                                                        <TABLE cellSpacing="0" cellPadding="0" border="0">
                                                            <TR>
                                                                <TD vAlign="top">
                                                                    <DIV id="divSYZJ" style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid">
                                                                        <asp:datagrid id="grdSYZJ" runat="server" Font-Size="11pt" CssClass="label" Width="520px" UseAccessibleHeader="True"
                                                                            AutoGenerateColumns="False" GridLines="Vertical" BackColor="White" BorderStyle="None" CellPadding="4"
                                                                            AllowPaging="False" PageSize="30" BorderColor="#DEDFDE" BorderWidth="0px" AllowSorting="False"
                                                                            Font-Names="宋体">
                                                                            <SelectedItemStyle Font-Size="11pt" Font-Names="宋体" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
                                                                            <EditItemStyle Font-Size="11pt" Font-Names="宋体" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
                                                                            <AlternatingItemStyle Font-Size="11pt" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
                                                                            <ItemStyle Font-Size="11pt" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
                                                                            <HeaderStyle Font-Size="11pt" Font-Names="宋体" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#87cefa" HorizontalAlign="Left"></HeaderStyle>
                                                                            <FooterStyle BackColor="#CCCC99"></FooterStyle>
                                                                           
                                                                            <Columns>
                                                                                <asp:TemplateColumn HeaderText="选" ItemStyle-Width="30px">
                                                                                    <HeaderStyle HorizontalAlign="Center" Width="30px"></HeaderStyle>
                                                                                    <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                                    <ItemTemplate>
                                                                                        <asp:CheckBox id="chkSYZJ" runat="server" AutoPostBack="False"></asp:CheckBox>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateColumn>
                                                                                <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="职级代码" SortExpression="职级代码" HeaderText="职级代码" CommandName="Select">
                                                                                    <HeaderStyle Width="160px"></HeaderStyle>
                                                                                </asp:ButtonColumn>
                                                                                <asp:ButtonColumn ItemStyle-Width="330px" DataTextField="职级名称" SortExpression="职级名称" HeaderText="职级名称" CommandName="Select">
                                                                                    <HeaderStyle Width="330px"></HeaderStyle>
                                                                                </asp:ButtonColumn>
                                                                                <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="适用方法" SortExpression="适用方法" HeaderText="适用方法" CommandName="Select">
                                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                                </asp:ButtonColumn>
                                                                                <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="直管标记" SortExpression="直管标记" HeaderText="直管标记" CommandName="Select">
                                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                                </asp:ButtonColumn>
                                                                                <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="业绩标记" SortExpression="业绩标记" HeaderText="业绩标记" CommandName="Select">
                                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                                </asp:ButtonColumn>
                                                                            </Columns>
                                                                            
                                                                            <PagerStyle Visible="False" NextPageText="下页" Font-Size="11pt" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
                                                                        </asp:datagrid><INPUT id="htxtSYZJFixed" type="hidden" value="0" runat="server">
                                                                    </DIV>
                                                                </TD>
                                                            </TR>
                                                            <tr>
                                                                <td height="4"></td>
                                                            </tr>
                                                            <TR>
                                                                <TD align="right" valign="middle">
                                                                    <asp:Button id="btnSelAll_SYZJ" Runat="server" Text="全部选定" Font-Size="11pt" Font-Name="宋体" CssClass="button" Height="32px"></asp:Button>
                                                                    <asp:Button id="btnDeSelAll_SYZJ" Runat="server" Text="全部不选" Font-Size="11pt" Font-Name="宋体" CssClass="button" Height="32px"></asp:Button>
                                                                    <asp:Button id="btnAddNew_SYZJ" Runat="server" Text="加入新的职级" Font-Size="11pt" Font-Name="宋体" CssClass="button" Height="32px"></asp:Button>
                                                                    <asp:Button id="btnDelete_SYZJ" Runat="server" Text="删除选定职级" Font-Size="11pt" Font-Name="宋体" CssClass="button" Height="32px"></asp:Button>
                                                                </TD>
                                                            </TR>
                                                            <tr>
                                                                <td height="4"></td>
                                                            </tr>
                                                        </TABLE>
                                                    </TD>
                                                    <TD width="8">&nbsp;</TD>
                                                    <TD vAlign="top">
                                                        <TABLE cellSpacing="0" cellPadding="0" border="0">
                                                            <TR>
                                                                <TD>
                                                                    <DIV id="divSYZB" style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid">
                                                                        <asp:datagrid id="grdSYZB" runat="server" Font-Size="11pt" CssClass="label" Width="380px" UseAccessibleHeader="True"
                                                                            AutoGenerateColumns="False" GridLines="Vertical" BackColor="White" BorderStyle="None" CellPadding="4"
                                                                            AllowPaging="False" PageSize="30" BorderColor="#DEDFDE" BorderWidth="0px" AllowSorting="False"
                                                                            Font-Names="宋体">
                                                                            <SelectedItemStyle Font-Size="11pt" Font-Names="宋体" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
                                                                            <EditItemStyle Font-Size="11pt" Font-Names="宋体" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
                                                                            <AlternatingItemStyle Font-Size="11pt" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
                                                                            <ItemStyle Font-Size="11pt" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
                                                                            <HeaderStyle Font-Size="11pt" Font-Names="宋体" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#87cefa" HorizontalAlign="Left"></HeaderStyle>
                                                                            <FooterStyle BackColor="#CCCC99"></FooterStyle>
                                                                            
                                                                            <Columns>
                                                                                <asp:TemplateColumn HeaderText="选" Visible="False" ItemStyle-Width="30px">
                                                                                    <HeaderStyle HorizontalAlign="Center" Width="30px"></HeaderStyle>
                                                                                    <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                                    <ItemTemplate>
                                                                                        <asp:CheckBox id="chkSYZB" runat="server" AutoPostBack="False" Visible="False"></asp:CheckBox>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateColumn>
                                                                                <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="适用方法" SortExpression="适用方法" HeaderText="适用方法" CommandName="Select">
                                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                                </asp:ButtonColumn>
                                                                                <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="直管标记" SortExpression="直管标记" HeaderText="直管标记" CommandName="Select">
                                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                                </asp:ButtonColumn>
                                                                                <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="业绩标记" SortExpression="业绩标记" HeaderText="业绩标记" CommandName="Select">
                                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                                </asp:ButtonColumn>
                                                                                <asp:TemplateColumn HeaderText="区间小值" ItemStyle-Width="120px">
                                                                                    <HeaderStyle HorizontalAlign="Center" Width="120px"></HeaderStyle>
                                                                                    <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox ID="txtQJZX" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateColumn>
                                                                                <asp:TemplateColumn HeaderText="区间大值" ItemStyle-Width="120px">
                                                                                    <HeaderStyle HorizontalAlign="Center" Width="120px"></HeaderStyle>
                                                                                    <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox ID="txtQJZD" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateColumn>
                                                                                <asp:TemplateColumn HeaderText="计提比例" ItemStyle-Width="120px">
                                                                                    <HeaderStyle HorizontalAlign="Center" Width="120px"></HeaderStyle>
                                                                                    <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox ID="txtJTBL" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateColumn>
                                                                            </Columns>
                                                                            
                                                                            <PagerStyle Visible="False" NextPageText="下页" Font-Size="11pt" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
                                                                        </asp:datagrid><INPUT id="htxtSYZBFixed" type="hidden" value="0" runat="server">
                                                                    </DIV>
                                                                </TD>
                                                            </TR>
                                                            <tr>
                                                                <td height="4"></td>
                                                            </tr>
                                                            <TR>
                                                                <TD align="right" valign="middle">
                                                                    <asp:Button id="btnAddNew_SYZB" Runat="server" Text="添加末尾区间" Font-Size="11pt" Font-Name="宋体" CssClass="button" Height="32px"></asp:Button>
                                                                    <asp:Button id="btnDelete_SYZB" Runat="server" Text="删除末尾区间" Font-Size="11pt" Font-Name="宋体" CssClass="button" Height="32px"></asp:Button>
                                                                </TD>
                                                            </TR>
                                                            <tr>
                                                                <td height="4"></td>
                                                            </tr>
                                                        </TABLE>
                                                    </TD>
                                                </TR>
                                            </TABLE>
                                        </TD>
                                    </TR>
                                    <TR>
                                        <TD align="left">
                                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                <tr>
                                                    <td align="left" class="label" bgcolor="#ccff99">填写说明：</td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="label">&nbsp;&nbsp;&nbsp;&nbsp;(1) 第一个[区间小值]固定=0，不能改动</td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="label">&nbsp;&nbsp;&nbsp;&nbsp;(2) 最后一个[区间大值]固定=0，不能改动</td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="label">&nbsp;&nbsp;&nbsp;&nbsp;(3) [区间大值]不能改动，系统自动设置：上行的[区间大值] = 下行的[区间小值] - 1</td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="label">&nbsp;&nbsp;&nbsp;&nbsp;(4) [区间小值]按从上到下顺序逐渐增大，至少大1</td>
                                                </tr>
                                            </table>
                                        </TD>
                                    </TR>
                                </TABLE>
                            </DIV>
                        </TD>
                    </TR>
                    <TR id="trRow2">
                        <TD style="BORDER-TOP: #99cccc 2px solid" vAlign="middle" align="center" height="36">
                            <asp:Button id="btnOK" Runat="server" Text=" 保  存 " Font-Size="11pt" Font-Name="宋体" CssClass="button" Height="32px"></asp:Button>
                            <asp:Button id="btnCancel" Runat="server" Text=" 取  消 " Font-Size="11pt" Font-Name="宋体" CssClass="button" Height="32px"></asp:Button>
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
                        <input id="htxtSessionId_GY" type="hidden" runat="server">
                        <input id="htxtSessionId_SYZB" type="hidden" runat="server">
                        <input id="htxtSessionId_SYZJ" type="hidden" runat="server">
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
