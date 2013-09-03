<%@ Page Language="vb" AutoEventWireup="false" Codebehind="grsw_wdsy.aspx.vb" Inherits="Josco.JsKernal.web.grsw_wdsy" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Register TagPrefix="componentart" Namespace="ComponentArt.Web.UI" Assembly="ComponentArt.Web.UI" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
    <HEAD>
        <title>我的事宜</title>
        <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
        <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
        <meta content="JavaScript" name="vs_defaultClientScript">
        <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <LINK href="../../styles01.css" type="text/css" rel="stylesheet">
        <link href="../../mnuStyle01.css" type="text/css" rel="stylesheet">
        <style>
			TD.grdFILELocked { ; LEFT: expression(divFILE.scrollLeft); POSITION: relative }
			TH.grdFILELocked { ; LEFT: expression(divFILE.scrollLeft); POSITION: relative }
			TH.grdFILELocked { Z-INDEX: 99 }
			TD.grdTASKLocked { ; LEFT: expression(divTASK.scrollLeft); POSITION: relative }
			TH.grdTASKLocked { ; LEFT: expression(divTASK.scrollLeft); POSITION: relative }
			TH.grdTASKLocked { Z-INDEX: 99 }
			TH { Z-INDEX: 10; POSITION: relative }
        </style>
        <script src="../../scripts/transkey.js"></script>
        <script language="javascript">
			function doMenuItemClick(menuItemId) {
				try {
					document.all("htxtSelectMenuID").value = menuItemId;
					window.setTimeout("__doPostBack('lnkMenu', '');", 500);
				} catch (e) {}
			}
        </script>
        <script language="javascript">
		<!--
			function window_onresize() 
			{
				var dblHeight = 0;
				var dblWidth  = 0;
				var strHeight = "";
				var strWidth  = "";
				var dblDeltaY = 20;
				var dblDeltaX = 0;
				
				if (document.all("divFILE") == null)
					return;
				
				dblHeight = 318 + dblDeltaY + document.body.clientHeight - 570; //default state : 318px
				strHeight = parseInt(dblHeight.toString(), 10).toString() + "px";
				dblWidth  = 660 + dblDeltaX + document.body.clientWidth  - 850; //default state : 660px
				strWidth = parseInt(dblWidth.toString(), 10).toString() + "px";
				divFILE.style.width  = strWidth;
				divFILE.style.height = strHeight;
				divFILE.style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";

				strHeight = divTASK.style.height;
				dblWidth  = 660 + dblDeltaX + document.body.clientWidth  - 850; //default state : 660px
				strWidth = parseInt(dblWidth.toString(), 10).toString() + "px";
				divTASK.style.width  = strWidth;
				divTASK.style.height = strHeight;
				divTASK.style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";
				
				var objTreeView = null;
				dblHeight = 498 + dblDeltaY + document.body.clientHeight - 570; //default state : 498px
				strHeight = parseInt(dblHeight.toString(), 10).toString() + "px";
				objTreeView = document.getElementById("tvwTASK");
				if (objTreeView)
					objTreeView.style.height = strHeight;
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
    <body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" background="../../images/oabk.gif" onresize="return window_onresize()">
        <form id="frmGRSW_WDSY" method="post" runat="server">
            <asp:panel id="panelMain" Runat="server">
                <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                    <TR>
                        <TD vAlign="top" align="left" width="100%" colSpan="3">
                            <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                <TR>
                                    <TD><asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton><asp:LinkButton id="lnkMenu" Runat="server" Width="0px"></asp:LinkButton></TD>
                                    <TD>
                                        <ComponentArt:Menu id="mnuMain" runat="server" width="100%" Orientation="Horizontal" CssClass="TopGroup"
                                            DefaultGroupCssClass="MenuGroup" DefaultSubGroupExpandOffsetX="-10" DefaultSubGroupExpandOffsetY="-5"
                                            DefaultItemLookID="DefaultItemLook" TopGroupItemSpacing="1" DefaultGroupItemSpacing="2" ImagesBaseUrl="../images/"
                                            EnableViewState="false" ExpandDelay="100" DefaultTarget="mainFrame">
                                            <Items>
                                                <componentart:MenuItem ID="mnuNew" Text="新的文件" Target="mainFrame">
                                                    <componentart:MenuItem ID="mnuNew_RSLY" Text="草拟新的人事录用审批单" ClientSideCommand="doMenuItemClick('mnuNew_RSLY');" Target="mainFrame"></componentart:MenuItem>
                                                </componentart:MenuItem>
                                                <componentart:MenuItem ID="mnuOpen" Text="打开文件" ClientSideCommand="doMenuItemClick('mnuOpen');" Target="mainFrame"></componentart:MenuItem>
                                                <componentart:MenuItem ID="mnuDelete" Text="删除文件" ClientSideCommand="doMenuItemClick('mnuDelete');" Target="mainFrame"></componentart:MenuItem>
                                                <componentart:MenuItem ID="mnuBWTX" Text="备忘提醒" Target="mainFrame">
                                                    <componentart:MenuItem ID="mnuBWTX_SZTX" Text="设置备忘提醒" ClientSideCommand="doMenuItemClick('mnuBWTX_SZTX');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuBWTX_QCTX" Text="清除备忘提醒" ClientSideCommand="doMenuItemClick('mnuBWTX_QCTX');" Target="mainFrame"></componentart:MenuItem>
                                                </componentart:MenuItem>
                                                <componentart:MenuItem ID="mnuYJJS" Text="移交接收" Target="mainFrame">
                                                    <componentart:MenuItem ID="mnuYJJS_YJWJ" Text="移交我的文件" ClientSideCommand="doMenuItemClick('mnuYJJS_YJWJ');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuYJJS_JSWJ" Text="接收移交文件" ClientSideCommand="doMenuItemClick('mnuYJJS_JSWJ');" Target="mainFrame"></componentart:MenuItem>
                                                </componentart:MenuItem>
                                                <componentart:MenuItem ID="mnuLKLY" Text="我的留言" ClientSideCommand="doMenuItemClick('mnuLKLY');" Target="mainFrame"></componentart:MenuItem>
                                                <componentart:MenuItem ID="mnuRefresh" Text="刷新显示" ClientSideCommand="doMenuItemClick('mnuRefresh');" Target="mainFrame"></componentart:MenuItem>
                                                <componentart:MenuItem ID="mnuClose" Text="返回上级" ClientSideCommand="doMenuItemClick('mnuClose');" Target="mainFrame"></componentart:MenuItem>
                                            </Items>
                                            <ItemLooks>
                                                <COMPONENTART:ItemLook LookID="TopItemLook" CssClass="TopMenuItem" HoverCssClass="TopMenuItemHover" LabelPaddingLeft="15" LabelPaddingRight="15" LabelPaddingTop="4" LabelPaddingBottom="4" />
                                                <COMPONENTART:ItemLook LookID="DefaultItemLook" CssClass="MenuItem" HoverCssClass="MenuItemHover" ExpandedCssClass="MenuItemHover" LabelPaddingLeft="18" LabelPaddingRight="12" LabelPaddingTop="4" LabelPaddingBottom="4" />
                                                <COMPONENTART:ItemLook LookID="MenuItemDisabledLook" CssClass="MenuItemDisabled" HoverCssClass="" ExpandedCssClass="" LabelPaddingLeft="18" LabelPaddingRight="12" LabelPaddingTop="4" LabelPaddingBottom="4" />
                                                <COMPONENTART:ItemLook LookID="BreakItem" CssClass="MenuBreak" ImageHeight="2" ImageWidth="100%" ImageUrl="../images/menu01/break.gif" />
                                            </ItemLooks>
                                        </ComponentArt:Menu>
                                    </TD>
                                </TR>
                            </TABLE>
                        </TD>
                    </TR>
                    <TR>
                        <TD></TD>
                        <TD vAlign="top" align="center">
                            <TABLE cellSpacing="0" cellPadding="0" border="0">
                                <TR>
                                    <TD height="4"></TD>
                                </TR>
                                <TR>
                                    <TD width="5"></TD>
                                    <TD style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid" vAlign="top" align="left" width="144">
                                        <IEWC:TREEVIEW id="tvwTASK" runat="server" Width="144px" CssClass="label" Font-Size="12px" Font-Name="宋体" AutoPostBack="true" Height="498px"></IEWC:TREEVIEW>
                                    </TD>
                                    <TD width="5"></TD>
                                    <TD vAlign="top">
                                        <TABLE cellSpacing="0" cellPadding="0" border="0">
                                            <TR>
                                                <TD height="2"></TD>
                                            </TR>
                                            <TR>
                                                <TD class="label" align="left">
                                                    <TABLE cellSpacing="0" cellPadding="0" border="0">
                                                        <TR>
                                                            <TD class="label" vAlign="middle">类型&nbsp;</TD>
                                                            <TD class="label" align="left"><asp:textbox id="txtFILESearch_WJLX" runat="server" CssClass="textbox" Font-Size="12px" Font-Names="宋体" Columns="12"></asp:textbox></TD>
                                                            <TD class="label" vAlign="middle">&nbsp;&nbsp;标题&nbsp;</TD>
                                                            <TD class="label" align="left"><asp:textbox id="txtFILESearch_WJBT" runat="server" CssClass="textbox" Font-Size="12px" Font-Names="宋体" Columns="36"></asp:textbox></TD>
                                                            <TD class="label" vAlign="middle">&nbsp;&nbsp;<asp:Label id="lblFILESearch_WJRQ" Runat="server" CssClass="label">发送日期</asp:Label>&nbsp;</TD>
                                                            <TD class="label" align="left"><asp:textbox id="txtFILESearch_WJRQMin" runat="server" CssClass="textbox" Font-Size="12px" Font-Names="宋体" Columns="8"></asp:textbox>~<asp:textbox id="txtFILESearch_WJRQMax" runat="server" CssClass="textbox" Font-Size="12px" Font-Names="宋体" Columns="10"></asp:textbox></TD>
                                                            <TD class="label" vAlign="middle">&nbsp;&nbsp;文号&nbsp;</TD>
                                                            <TD class="label" align="left"><asp:textbox id="txtFILESearch_WJZH" runat="server" CssClass="textbox" Font-Size="12px" Font-Names="宋体" Columns="12"></asp:textbox></TD>
                                                            <TD class="label">&nbsp;&nbsp;<asp:button id="btnFILESearch" Runat="server" CssClass="button" Font-Size="12px" Font-Name="宋体" Text="搜索"></asp:button><asp:button id="btnFileSearchFull" Runat="server" CssClass="button" Font-Size="12px" Font-Name="宋体" Text="全文"></asp:button></TD>
                                                        </TR>
                                                    </TABLE>
                                                </TD>
                                            </TR>
                                            <TR>
                                                <TD>
                                                    <DIV id="divFILE" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 660px; CLIP: rect(0px 660px 318px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 318px">
                                                        <asp:datagrid id="grdFILE" runat="server" Width="2020px" CssClass="label" Font-Size="12px" Font-Names="宋体"
                                                            AllowPaging="True" AutoGenerateColumns="False" GridLines="Vertical" BackColor="White" BorderStyle="None"
                                                            PageSize="30" BorderColor="#DEDFDE" BorderWidth="0px" AllowSorting="True" CellPadding="4"
                                                            UseAccessibleHeader="True">
                                                            <SelectedItemStyle Font-Size="12px" Font-Names="宋体" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
                                                            <EditItemStyle Font-Size="12px" Font-Names="宋体" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
                                                            <AlternatingItemStyle Font-Size="12px" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
                                                            <ItemStyle Font-Size="12px" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
                                                            <HeaderStyle Font-Size="12px" Font-Names="宋体" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#6699cc" HorizontalAlign="Left"></HeaderStyle>
                                                            <FooterStyle BackColor="#CCCC99"></FooterStyle>
                                                            <Columns>
                                                                <asp:TemplateColumn HeaderText="选">
                                                                    <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
                                                                    <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox id="chkFILE" runat="server" AutoPostBack="False"></asp:CheckBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                                <asp:ButtonColumn DataTextField="文件类型" SortExpression="文件类型" HeaderText="类型" CommandName="Select">
                                                                    <HeaderStyle Width="100px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn DataTextField="备忘提醒" SortExpression="备忘提醒" HeaderText="备忘" CommandName="Select">
                                                                    <HeaderStyle Width="60px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn DataTextField="文件标题" SortExpression="文件标题" HeaderText="标题" CommandName="OpenDocument">
                                                                    <HeaderStyle Width="420px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn DataTextField="紧急程度" SortExpression="紧急程度" HeaderText="紧急" CommandName="Select">
                                                                    <HeaderStyle Width="60px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn DataTextField="秘密等级" SortExpression="秘密等级" HeaderText="密级" CommandName="Select">
                                                                    <HeaderStyle Width="60px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn DataTextField="办理状态" SortExpression="办理状态" HeaderText="状态" CommandName="Select">
                                                                    <HeaderStyle Width="100px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn DataTextField="主送单位" SortExpression="主送单位" HeaderText="主送或来文单位" CommandName="Select">
                                                                    <HeaderStyle Width="240px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn DataTextField="文件字号" SortExpression="文件字号" HeaderText="文号" CommandName="Select">
                                                                    <HeaderStyle Width="240px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn DataTextField="发送日期" SortExpression="发送日期" HeaderText="发送日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd HH:mm:ss}">
                                                                    <HeaderStyle Width="240px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn DataTextField="办理期限" SortExpression="办理期限" HeaderText="办理期限" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd HH:mm:ss}">
                                                                    <HeaderStyle Width="240px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn DataTextField="完成日期" SortExpression="完成日期" HeaderText="完成日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd HH:mm:ss}">
                                                                    <HeaderStyle Width="240px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn Visible="False" DataTextField="文件标识" SortExpression="文件标识" HeaderText="文件标识" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn Visible="False" DataTextField="流水号" SortExpression="流水号" HeaderText="流水号" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn Visible="False" DataTextField="办理类型" SortExpression="办理类型" HeaderText="办理类型" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn Visible="False" DataTextField="文件子类" SortExpression="文件子类" HeaderText="文件子类" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn Visible="False" DataTextField="机关代字" SortExpression="机关代字" HeaderText="机关代字" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn Visible="False" DataTextField="文件年份" SortExpression="文件年份" HeaderText="文件年份" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn Visible="False" DataTextField="文件序号" SortExpression="文件序号" HeaderText="文件序号" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn Visible="False" DataTextField="主办单位" SortExpression="主办单位" HeaderText="主办单位" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn Visible="False" DataTextField="拟稿人" SortExpression="拟稿人" HeaderText="拟稿人" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn Visible="False" DataTextField="拟稿日期" SortExpression="拟稿日期" HeaderText="拟稿日期" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn Visible="False" DataTextField="主题词" SortExpression="主题词" HeaderText="主题词" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn Visible="False" DataTextField="快速收文" SortExpression="快速收文" HeaderText="快速收文" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                            </Columns>
                                                            <PagerStyle Visible="False" NextPageText="下页" Font-Size="12px" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
                                                        </asp:datagrid><INPUT id="htxtFILEFixed" type="hidden" value="0" runat="server">
                                                    </DIV>
                                                </TD>
                                            </TR>
                                            <TR>
                                                <TD class="label">
                                                    <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                        <TR>
                                                            <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZFILEDeSelectAll" runat="server" Font-Size="12px" Font-Name="宋体">不选</asp:linkbutton></TD>
                                                            <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZFILESelectAll" runat="server" Font-Size="12px" Font-Name="宋体">全选</asp:linkbutton></TD>
                                                            <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZFILEMoveFirst" runat="server" Font-Size="12px" Font-Name="宋体">最前</asp:linkbutton></TD>
                                                            <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZFILEMovePrev" runat="server" Font-Size="12px" Font-Name="宋体">前页</asp:linkbutton></TD>
                                                            <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZFILEMoveNext" runat="server" Font-Size="12px" Font-Name="宋体">下页</asp:linkbutton></TD>
                                                            <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZFILEMoveLast" runat="server" Font-Size="12px" Font-Name="宋体">最后</asp:linkbutton></TD>
                                                            <TD class="label" vAlign="middle" noWrap align="left"><asp:linkbutton id="lnkCZFILEGotoPage" runat="server" Font-Size="12px" Font-Name="宋体">前往</asp:linkbutton><asp:textbox id="txtFILEPageIndex" runat="server" CssClass="textbox" Font-Size="12px" Font-Name="宋体" Columns="3">1</asp:textbox>页</TD>
                                                            <TD class="label" vAlign="middle" noWrap align="left"><asp:linkbutton id="lnkCZFILESetPageSize" runat="server" Font-Size="12px" Font-Name="宋体">每页</asp:linkbutton><asp:textbox id="txtFILEPageSize" runat="server" CssClass="textbox" Font-Size="12px" Font-Name="宋体" Columns="3">30</asp:textbox>条</TD>
                                                            <TD class="label" vAlign="middle" align="right" width="200"><asp:label id="lblFILEGridLocInfo" runat="server" CssClass="label" Font-Size="12px" Font-Name="宋体">1/10 N/15</asp:label></TD>
                                                        </TR>
                                                    </TABLE>
                                                </TD>
                                            </TR>
                                            <TR>
                                                <TD height="4"></TD>
                                            </TR>
                                            <TR>
                                                <TD>
                                                    <DIV id="divTASK" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 660px; CLIP: rect(0px 660px 136px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 136px">
                                                        <asp:datagrid id="grdTASK" runat="server" CssClass="label" Font-Size="12px" Font-Names="宋体" AllowPaging="False"
                                                            AutoGenerateColumns="False" GridLines="Vertical" BackColor="White" BorderStyle="None" PageSize="30"
                                                            BorderColor="#DEDFDE" BorderWidth="0px" AllowSorting="True" CellPadding="4" UseAccessibleHeader="True">
                                                            <SelectedItemStyle Font-Size="12px" Font-Names="宋体" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
                                                            <EditItemStyle Font-Size="12px" Font-Names="宋体" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
                                                            <AlternatingItemStyle Font-Size="12px" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
                                                            <ItemStyle Font-Size="12px" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
                                                            <HeaderStyle Font-Size="12px" Font-Names="宋体" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#6699cc" HorizontalAlign="Left"></HeaderStyle>
                                                            <FooterStyle BackColor="#CCCC99"></FooterStyle>
                                                            <Columns>
                                                                <asp:ButtonColumn DataTextField="办理子类" SortExpression="办理子类" HeaderText="事宜名称" CommandName="Select">
                                                                    <HeaderStyle Width="100px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn DataTextField="办理状态" SortExpression="办理状态" HeaderText="办理状态" CommandName="Select">
                                                                    <HeaderStyle Width="100px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn DataTextField="接收人" SortExpression="接收人" HeaderText="办理人" CommandName="Select">
                                                                    <HeaderStyle Width="100px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn DataTextField="发送人" SortExpression="发送人" HeaderText="发送人" CommandName="Select">
                                                                    <HeaderStyle Width="100px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn DataTextField="委托人" SortExpression="委托人" HeaderText="委托人" CommandName="Select">
                                                                    <HeaderStyle Width="100px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn DataTextField="交接说明" SortExpression="交接说明" HeaderText="说明" CommandName="Select">
                                                                    <HeaderStyle Width="360px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn Visible="False" DataTextField="文件标识" SortExpression="文件标识" HeaderText="文件标识" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn Visible="False" DataTextField="流水号" SortExpression="流水号" HeaderText="流水号" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn Visible="False" DataTextField="文件类型" SortExpression="文件类型" HeaderText="文件类型" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn Visible="False" DataTextField="办理类型" SortExpression="办理类型" HeaderText="办理类型" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn Visible="False" DataTextField="文件子类" SortExpression="文件子类" HeaderText="文件子类" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn Visible="False" DataTextField="文件标题" SortExpression="文件标题" HeaderText="文件标题" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn Visible="False" DataTextField="机关代字" SortExpression="机关代字" HeaderText="机关代字" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn Visible="False" DataTextField="文件年份" SortExpression="文件年份" HeaderText="文件年份" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn Visible="False" DataTextField="文件序号" SortExpression="文件序号" HeaderText="文件序号" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn Visible="False" DataTextField="主办单位" SortExpression="主办单位" HeaderText="主办单位" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                            </Columns>
                                                            <PagerStyle Visible="False" NextPageText="下页" Font-Size="12px" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
                                                        </asp:datagrid><INPUT id="htxtTASKFixed" type="hidden" value="0" runat="server">
                                                    </DIV>
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
                                    <TD id="tdErrInfo" style="FONT-SIZE: 32pt; COLOR: black; LINE-HEIGHT: 40pt; FONT-FAMILY: 宋体; LETTER-SPACING: 2pt" align="center"><asp:Label id="lblMessage" Runat="server"></asp:Label><P>&nbsp;&nbsp;</P><P><INPUT id="btnGoBack" style="FONT-SIZE: 24pt; FONT-FAMILY: 宋体" onclick="javascript:history.back();" type="button" value=" 返回 "></P></TD>
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
                        <input id="htxtSessionIdQueryFILE" type="hidden" runat="server">
                        <input id="htxtSelectMenuID" type="hidden" runat="server">
                        <input id="htxtTASKQuery" type="hidden" runat="server">
                        <input id="htxtTASKRows" type="hidden" runat="server">
                        <input id="htxtTASKSort" type="hidden" runat="server">
                        <input id="htxtTASKSortColumnIndex" type="hidden" runat="server">
                        <input id="htxtTASKSortType" type="hidden" runat="server">
                        <input id="htxtFILEQuery" type="hidden" runat="server">
                        <input id="htxtFILERows" type="hidden" runat="server">
                        <input id="htxtFILESort" type="hidden" runat="server">
                        <input id="htxtFILESortColumnIndex" type="hidden" runat="server">
                        <input id="htxtFILESortType" type="hidden" runat="server">
                        <input id="htxtDivLeftFILE" type="hidden" runat="server">
                        <input id="htxtDivTopFILE" type="hidden" runat="server">
                        <input id="htxtDivLeftTASK" type="hidden" runat="server">
                        <input id="htxtDivTopTASK" type="hidden" runat="server">
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
							function ScrollProc_divFILE() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopFILE");
								if (oText != null) oText.value = divFILE.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftFILE");
								if (oText != null) oText.value = divFILE.scrollLeft;
								return;
							}
							function ScrollProc_divTASK() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopTASK");
								if (oText != null) oText.value = divTASK.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftTASK");
								if (oText != null) oText.value = divTASK.scrollLeft;
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
								oText=document.getElementById("htxtDivTopFILE");
								if (oText != null) divFILE.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftFILE");
								if (oText != null) divFILE.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtDivTopTASK");
								if (oText != null) divTASK.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftTASK");
								if (oText != null) divTASK.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divFILE.onscroll = ScrollProc_divFILE;
								divTASK.onscroll = ScrollProc_divTASK;
							}
							catch (e) {}
                        </script>
                    </td>
                </tr>
                <tr>
                    <td>
                        <script language="javascript">window_onresize();</script>
                        <uwin:popmessage id="popMessageObject" runat="server" width="100px" height="60px" Visible="False" ActionType="OpenWindow" EnableViewState="False"></uwin:popmessage>
                    </td>
                </tr>
            </table>
        </form>
    </body>
</HTML>
