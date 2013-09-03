<%@ Page Language="vb" AutoEventWireup="false" Codebehind="estate_rs_luyong_info.aspx.vb" Inherits="Josco.JSOA.web.estate_rs_luyong_info" %>
<%@ Register TagPrefix="ComponentArt" Namespace="ComponentArt.Web.UI" Assembly="ComponentArt.Web.UI" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
    <HEAD>
        <title>人事录用审批单的显示或编辑窗</title>
        <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
        <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
        <meta content="JavaScript" name="vs_defaultClientScript">
        <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <LINK href="../../../styles01.css" type="text/css" rel="stylesheet">
        <link href="../../../mnuStyle01.css" type="text/css" rel="stylesheet">
        <style>
			TD.grdFJLocked { ; LEFT: expression(divFJ.scrollLeft); POSITION: relative }
			TH.grdFJLocked { ; LEFT: expression(divFJ.scrollLeft); POSITION: relative }
			TH.grdFJLocked { Z-INDEX: 99 }
			TD.grdXGWJLocked { ; LEFT: expression(divXGWJ.scrollLeft); POSITION: relative }
			TH.grdXGWJLocked { ; LEFT: expression(divXGWJ.scrollLeft); POSITION: relative }
			TH.grdXGWJLocked { Z-INDEX: 99 }
			TD.grdRYXXLocked { ; LEFT: expression(divRYXX.scrollLeft); POSITION: relative }
			TH.grdRYXXLocked { ; LEFT: expression(divRYXX.scrollLeft); POSITION: relative }
			TH.grdRYXXLocked { Z-INDEX: 99 }
			TH { Z-INDEX: 10; POSITION: relative }
        </style>
        <script src="../../../scripts/transkey.js"></script>
        <script language="javascript">
			function doMenuItemClick(menuItemId) 
			{
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
				
				if (document.all("divContent") == null)
					return;
				
				intWidth   = document.body.clientWidth;   //总宽度
				intWidth  -= 16;                          //滚动条
				strWidth   = intWidth.toString() + "px";
				
				intHeight  = document.body.clientHeight;  //总高度
				intHeight -= 16;                          //滚动条
				intHeight -= trRow1.clientHeight;
				intHeight -= trRow2.clientHeight;
				strHeight  = intHeight.toString() + "px";
				
				document.all("divContent").style.width  = strWidth;
				document.all("divContent").style.height = strHeight;
				document.all("divContent").style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";
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
        <form id="frmestate_rs_luyong_info" method="post" runat="server">
            <asp:panel id="panelMain" Runat="server">
                <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                    <TR id="trRow1">
                        <TD><asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton><asp:LinkButton id="lnkMenu" Runat="server" Width="0px"></asp:LinkButton><INPUT id="htxtSelectMenuID" type="hidden" size="1" runat="server"></TD>
                        <TD align="center">
                            <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                <TR>
                                    <TD>
                                        <ComponentArt:Menu id="mnuMain" runat="server" DefaultTarget="mainFrame" ExpandDelay="100" EnableViewState="false"
                                            ImagesBaseUrl="../../images/" DefaultGroupItemSpacing="2" TopGroupItemSpacing="1" DefaultItemLookID="DefaultItemLook"
                                            DefaultSubGroupExpandOffsetY="-5" DefaultSubGroupExpandOffsetX="-10" DefaultGroupCssClass="MenuGroup"
                                            CssClass="TopGroup" Orientation="Horizontal" width="100%">
                                            <Items>
                                                <componentart:MenuItem ID="mnuFILE" DisabledLookId="MenuItemDisabledLook" Text="文件编辑" Target="mainFrame">
                                                    <componentart:MenuItem ID="mnuFILE_XGWJ" DisabledLookId="MenuItemDisabledLook" Text="修改文件" ClientSideCommand="doMenuItemClick('mnuFILE_XGWJ');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuFILE_BCWJ" DisabledLookId="MenuItemDisabledLook" Text="保存文件" ClientSideCommand="doMenuItemClick('mnuFILE_BCWJ');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuFILE_QXXG" DisabledLookId="MenuItemDisabledLook" Text="取消文件" ClientSideCommand="doMenuItemClick('mnuFILE_QXXG');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuFILE_SXWJ" DisabledLookId="MenuItemDisabledLook" Text="重新获取数据" ClientSideCommand="doMenuItemClick('mnuFILE_SXWJ');" Target="mainFrame"></componentart:MenuItem>
                                                </componentart:MenuItem>
                                                <componentart:MenuItem ID="mnuJJCL" DisabledLookId="MenuItemDisabledLook" Text="交接处理" Target="mainFrame">
                                                    <componentart:MenuItem ID="mnuJJCL_FSWJ" DisabledLookId="MenuItemDisabledLook" Text="发送文件" ClientSideCommand="doMenuItemClick('mnuJJCL_FSWJ');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuJJCL_JSWJ" DisabledLookId="MenuItemDisabledLook" Text="接收文件" ClientSideCommand="doMenuItemClick('mnuJJCL_JSWJ');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuJJCL_SHWJ" DisabledLookId="MenuItemDisabledLook" Text="收回文件" ClientSideCommand="doMenuItemClick('mnuJJCL_SHWJ');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuJJCL_THWJ" DisabledLookId="MenuItemDisabledLook" Text="退回文件" ClientSideCommand="doMenuItemClick('mnuJJCL_THWJ');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuJJCL_WTBL" DisabledLookId="MenuItemDisabledLook" Text="委托他人办理" ClientSideCommand="doMenuItemClick('mnuJJCL_WTBL');" Target="mainFrame"></componentart:MenuItem>
                                                </componentart:MenuItem>
                                                <componentart:MenuItem ID="mnuSPCL" DisabledLookId="MenuItemDisabledLook" Text="审批处理" Target="mainFrame">
                                                    <componentart:MenuItem ID="mnuSPCL_TXYJ" DisabledLookId="MenuItemDisabledLook" Text="填写我的意见" ClientSideCommand="doMenuItemClick('mnuSPCL_TXYJ');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuSPCL_BDPS" DisabledLookId="MenuItemDisabledLook" Text="补登领导批示" ClientSideCommand="doMenuItemClick('mnuSPCL_BDPS');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuSPCL_BYBL" DisabledLookId="MenuItemDisabledLook" Text="我不需要办理" ClientSideCommand="doMenuItemClick('mnuSPCL_BYBL');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuSPCL_BLWB" DisabledLookId="MenuItemDisabledLook" Text="我已办理完毕" ClientSideCommand="doMenuItemClick('mnuSPCL_BLWB');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuSPCL_WYYZ" DisabledLookId="MenuItemDisabledLook" Text="我已看过文件" ClientSideCommand="doMenuItemClick('mnuSPCL_WYYZ');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuSPCL_ZHBL" DisabledLookId="MenuItemDisabledLook" Text="文件暂缓办理" ClientSideCommand="doMenuItemClick('mnuSPCL_ZHBL');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuSPCL_JXBL" DisabledLookId="MenuItemDisabledLook" Text="缓办文件能办" ClientSideCommand="doMenuItemClick('mnuSPCL_JXBL');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuSPCL_ZFWJ" DisabledLookId="MenuItemDisabledLook" Text="作废当前文件" ClientSideCommand="doMenuItemClick('mnuSPCL_ZFWJ');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuSPCL_QYWJ" DisabledLookId="MenuItemDisabledLook" Text="启用作废文件" ClientSideCommand="doMenuItemClick('mnuSPCL_QYWJ');" Target="mainFrame"></componentart:MenuItem>
                                                </componentart:MenuItem>
                                                <componentart:MenuItem ID="mnuCBDB" DisabledLookId="MenuItemDisabledLook" Text="催办督办" Target="mainFrame">
                                                    <componentart:MenuItem ID="mnuCBDB_CBWJ" DisabledLookId="MenuItemDisabledLook" Text="催办文件" ClientSideCommand="doMenuItemClick('mnuCBDB_CBWJ');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuCBDB_DBWJ" DisabledLookId="MenuItemDisabledLook" Text="督办文件" ClientSideCommand="doMenuItemClick('mnuCBDB_DBWJ');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuCBDB_DBJG" DisabledLookId="MenuItemDisabledLook" Text="填写督办结果" ClientSideCommand="doMenuItemClick('mnuCBDB_DBJG');" Target="mainFrame"></componentart:MenuItem>
                                                </componentart:MenuItem>
                                                <componentart:MenuItem ID="mnuXXCY" DisabledLookId="MenuItemDisabledLook" Text="查阅信息" Target="mainFrame">
                                                    <componentart:MenuItem ID="mnuXXCY_CYYJ" DisabledLookId="MenuItemDisabledLook" Text="查看领导批示" ClientSideCommand="doMenuItemClick('mnuXXCY_CYYJ');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuXXCY_CKLZ" DisabledLookId="MenuItemDisabledLook" Text="查看流转情况" ClientSideCommand="doMenuItemClick('mnuXXCY_CKLZ');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuXXCY_CKBY" DisabledLookId="MenuItemDisabledLook" Text="查看补阅情况" ClientSideCommand="doMenuItemClick('mnuXXCY_CKBY');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuXXCY_CKRZ" DisabledLookId="MenuItemDisabledLook" Text="查看操作日志" ClientSideCommand="doMenuItemClick('mnuXXCY_CKRZ');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuXXCY_CKCB" DisabledLookId="MenuItemDisabledLook" Text="查看催办情况" ClientSideCommand="doMenuItemClick('mnuXXCY_CKCB');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuXXCY_CKDB" DisabledLookId="MenuItemDisabledLook" Text="查看督办情况" ClientSideCommand="doMenuItemClick('mnuXXCY_CKDB');" Target="mainFrame"></componentart:MenuItem>
                                                </componentart:MenuItem>
                                                <componentart:MenuItem ID="mnuXXDY" DisabledLookId="MenuItemDisabledLook" Text="打印信息" Target="mainFrame">
                                                    <componentart:MenuItem ID="mnuXXDY_DYGZ" DisabledLookId="MenuItemDisabledLook" Text="打印审批稿纸" ClientSideCommand="doMenuItemClick('mnuXXDY_DYGZ');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuXXDY_DYBJ" DisabledLookId="MenuItemDisabledLook" Text="打印便笺稿纸" ClientSideCommand="doMenuItemClick('mnuXXDY_DYBJ');" Target="mainFrame"></componentart:MenuItem>
                                                </componentart:MenuItem>
                                                <componentart:MenuItem ID="mnuQTCL" DisabledLookId="MenuItemDisabledLook" Text="其他处理" Target="mainFrame">
                                                    <componentart:MenuItem ID="mnuQTCL_WJBY" DisabledLookId="MenuItemDisabledLook" Text="文件补阅处理" ClientSideCommand="doMenuItemClick('mnuQTCL_WJBY');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuQTCL_BWTX" DisabledLookId="MenuItemDisabledLook" Text="进行备忘提醒" ClientSideCommand="doMenuItemClick('mnuQTCL_BWTX');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuQTCL_DRQP" DisabledLookId="MenuItemDisabledLook" Text="导入签批文件" ClientSideCommand="doMenuItemClick('mnuQTCL_DRQP');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuQTCL_DRZS" DisabledLookId="MenuItemDisabledLook" Text="导入扫描文件" ClientSideCommand="doMenuItemClick('mnuQTCL_DRZS');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuQTCL_WJBJ" DisabledLookId="MenuItemDisabledLook" Text="整个文件办完" ClientSideCommand="doMenuItemClick('mnuQTCL_WJBJ');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuQTCL_RYLY" DisabledLookId="MenuItemDisabledLook" Text="录用选定人员" ClientSideCommand="doMenuItemClick('mnuQTCL_RYLY');" Target="mainFrame"></componentart:MenuItem>
                                                </componentart:MenuItem>
                                                <componentart:MenuItem ID="mnuFHSJ" DisabledLookId="MenuItemDisabledLook" Text="返回上级" ClientSideCommand="doMenuItemClick('mnuFHSJ');" Target="mainFrame"></componentart:MenuItem>
                                            </Items>
                                            <ItemLooks>
                                                <COMPONENTART:ItemLook LookID="TopItemLook" CssClass="TopMenuItem" HoverCssClass="TopMenuItemHover" LabelPaddingLeft="15" LabelPaddingRight="15" LabelPaddingTop="4" LabelPaddingBottom="4" />
                                                <COMPONENTART:ItemLook LookID="DefaultItemLook" CssClass="MenuItem" HoverCssClass="MenuItemHover" ExpandedCssClass="MenuItemHover" LabelPaddingLeft="18" LabelPaddingRight="12" LabelPaddingTop="4" LabelPaddingBottom="4" />
                                                <COMPONENTART:ItemLook LookID="MenuItemDisabledLook" CssClass="MenuItemDisabled" HoverCssClass="" ExpandedCssClass="" LabelPaddingLeft="18" LabelPaddingRight="12" LabelPaddingTop="4" LabelPaddingBottom="4" />
                                                <COMPONENTART:ItemLook LookID="BreakItem" CssClass="MenuBreak" ImageHeight="2" ImageWidth="100%" ImageUrl="../../images/menu01/break.gif" />
                                            </ItemLooks>
                                        </ComponentArt:Menu>
                                    </TD>
                                </TR>
                            </TABLE>
                        </TD>
                        <TD></TD>
                    </TR>
                    <TR>
                        <TD></TD>
                        <TD vAlign="top" align="center">
                            <TABLE cellSpacing="0" cellPadding="0" border="0">
                                <TR>
                                    <TD height="3"></TD>
                                </TR>
                                <TR>
                                    <TD>
                                        <DIV id="divContent" style="OVERFLOW: auto; WIDTH: 820px; CLIP: rect(0px 820px 476px 0px); HEIGHT: 476px">
                                            <TABLE cellSpacing="0" cellPadding="0" align="center" border="0">
                                                <TR>
                                                    <TD>
                                                        <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                            <TR>
                                                                <TD vAlign="middle" align="center" height="32"><SPAN style="FONT-WEIGHT: bold; FONT-SIZE: 28px; COLOR: red; FONT-FAMILY: 宋体"><%=Josco.JsKernal.Common.jsoaConfiguration.LicencingTo%>新进人员审批表</SPAN></TD>
                                                            </TR>
                                                            <TR>
                                                                <TD height="10"></TD>
                                                            </TR>
                                                            <TR>
                                                                <TD>
                                                                    <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                                        <TR>
                                                                            <td width="30">&nbsp;</td>
                                                                            <TD class="labelAuto">编号<asp:TextBox id="txtJGDZ" Runat="server" CssClass="textbox" Columns="10"></asp:TextBox>[<asp:TextBox id="txtWJNF" Runat="server" CssClass="textbox" Columns="4"></asp:TextBox>]第[<asp:TextBox id="txtWJXH" Runat="server" CssClass="textbox" Columns="4"></asp:TextBox>]号</TD>
                                                                            <TD class="label">缓急<asp:DropDownList id="ddlJJCD" Runat="server" CssClass="textbox"></asp:DropDownList></TD>
                                                                            <TD class="label">密级<asp:DropDownList id="ddlMMDJ" Runat="server" CssClass="textbox"></asp:DropDownList></TD>
                                                                            <TD noWrap align="right"><asp:CheckBox id="chkDDSZ" Runat="server" CssClass="textbox" Text="不受流转限制" Font-Name="宋体" Font-Size="12px"></asp:CheckBox></TD>
                                                                            <TD width="30">&nbsp;</TD>
                                                                        </TR>
                                                                    </TABLE>
                                                                </TD>
                                                            </TR>
                                                            <TR>
                                                                <TD align="center">
                                                                    <TABLE cellSpacing="0" cellPadding="0" border="1" bordercolordark="#99cccc" bordercolorlight="#ffffff">
                                                                        <TR>
                                                                            <TD></TD>
                                                                            <TD></TD>
                                                                            <TD></TD>
                                                                            <TD></TD>
                                                                            <TD></TD>
                                                                            <TD></TD>
                                                                        </TR>
                                                                        <TR>
                                                                            <TD colSpan="5">
                                                                                <DIV id="divRYXX" style="TABLE-LAYOUT: fixed; OVERFLOW: auto; WIDTH: 640px; CLIP: rect(0px 640px 300px 0px); HEIGHT: 300px">
                                                                                    <asp:datagrid id="grdRYXX" runat="server" CssClass="label" Font-Size="12px" UseAccessibleHeader="True"
                                                                                        AutoGenerateColumns="False" GridLines="Vertical" BorderStyle="None" CellPadding="4" AllowPaging="false"
                                                                                        PageSize="30" AllowSorting="False" BorderWidth="0px" BorderColor="#DEDFDE" Font-Names="宋体" Width="1400px">
                                                                                        <FooterStyle BackColor="#CCCC99"></FooterStyle>
                                                                                        <SelectedItemStyle Font-Size="12px" Font-Names="宋体" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
                                                                                        <EditItemStyle Font-Size="12px" Font-Names="宋体" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
                                                                                        <AlternatingItemStyle Font-Size="12px" Font-Names="宋体" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
                                                                                        <ItemStyle Font-Size="12px" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
                                                                                        <HeaderStyle Font-Size="12px" Font-Names="宋体" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#006699" HorizontalAlign="Left"></HeaderStyle>
                                                                                        
                                                                                        <Columns>
																                            <asp:TemplateColumn HeaderText="选" ItemStyle-Width="20px">
																	                            <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
																	                            <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																	                            <ItemTemplate>
																		                            <asp:CheckBox id="chkRYXX" runat="server" AutoPostBack="False" Width="20px"></asp:CheckBox>
																	                            </ItemTemplate>
																                            </asp:TemplateColumn>
                                                                                        
                                                                                            <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="文件标识" SortExpression="文件标识" HeaderText="文件标识" CommandName="Select">
                                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="唯一标识" SortExpression="唯一标识" HeaderText="唯一标识" CommandName="Select">
                                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="人员代码" SortExpression="人员代码" HeaderText="人员代码" CommandName="Select">
                                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn ItemStyle-Width="80px" DataTextField="人员序号" SortExpression="人员序号" HeaderText="序号" CommandName="Select">
                                                                                                <HeaderStyle Width="80px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn ItemStyle-Width="80px" DataTextField="人员姓名" SortExpression="人员姓名" HeaderText="姓名" CommandName="OpenDocument">
                                                                                                <HeaderStyle Width="80px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn ItemStyle-Width="60px" DataTextField="人员性别" SortExpression="人员性别" HeaderText="性别" CommandName="Select">
                                                                                                <HeaderStyle Width="60px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn ItemStyle-Width="60px" DataTextField="人员年龄" SortExpression="人员年龄" HeaderText="年龄" CommandName="Select">
                                                                                                <HeaderStyle Width="60px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="人员学历" SortExpression="人员学历" HeaderText="学历" CommandName="Select">
                                                                                                <HeaderStyle Width="100px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="简历编号" SortExpression="简历编号" HeaderText="简历编号" CommandName="OpenDocument">
                                                                                                <HeaderStyle Width="100px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn ItemStyle-Width="140px" DataTextField="拟分配部门" SortExpression="拟分配部门" HeaderText="拟分配部门" CommandName="Select">
                                                                                                <HeaderStyle Width="140px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="拟担任职位" SortExpression="拟担任职位" HeaderText="拟担任职位" CommandName="Select">
                                                                                                <HeaderStyle Width="160px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="招聘说明" SortExpression="招聘说明" HeaderText="招聘说明" CommandName="Select">
                                                                                                <HeaderStyle Width="160px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="现有人员数" SortExpression="现有人员数" HeaderText="拟分配部门现有人员" CommandName="Select">
                                                                                                <HeaderStyle Width="160px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="定编人员数" SortExpression="定编人员数" HeaderText="拟分配部门定编人数" CommandName="Select">
                                                                                                <HeaderStyle Width="160px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn ItemStyle-Width="140px" DataTextField="拟报到日期" SortExpression="拟报到日期" HeaderText="拟报到日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
                                                                                                <HeaderStyle Width="140px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                        </Columns>
                                                                                        
                                                                                        <PagerStyle Visible="False" NextPageText="下页" Font-Size="12px" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
                                                                                    </asp:datagrid><INPUT id="htxtRYXXFixed" type="hidden" value="0" runat="server">
                                                                                </DIV>
                                                                            </TD>
                                                                            <TD>
                                                                                <TABLE cellSpacing="0" cellPadding="0" border="0">
                                                                                    <TR>
                                                                                        <TD vAlign="middle" align="center" height="20"><asp:LinkButton id="lnkCZQSYJ_SH" Runat="server" CssClass="button"><img src="../../../images/gqsyj.ico" border="0" width="16" height="16" align="absmiddle">部门经理意见</asp:LinkButton><asp:LinkButton id="lnkCZQSYJ_SHBJ" Runat="server" CssClass="button">(有便笺)</asp:LinkButton></TD>
                                                                                    </TR>
                                                                                    <TR>
                                                                                        <TD>
                                                                                            <DIV id="divSHYJ" style="TABLE-LAYOUT: fixed; OVERFLOW: auto; WIDTH: 240px; CLIP: rect(0px 240px 280px 0px); HEIGHT: 280px"><asp:label id="lblSHYJ" Runat="server" CssClass="label">lblSHYJ</asp:label></DIV>
                                                                                        </TD>
                                                                                    </TR>
                                                                                </TABLE>
                                                                            </TD>
                                                                        </TR>
                                                                        <tr>
                                                                            <td colspan="6">
                                                                                <% if propEditMode = False then response.write("<div style='display:none'>") %>
                                                                                <table cellpadding="0" cellspacing="0" width="100%" border="1" bordercolordark="#99cccc" bordercolorlight="#ffffff">
                                                                                    <tr>
                                                                                        <td class="labelNotNull" align="right" nowrap>简历编号</td>
                                                                                        <td align="left"><asp:TextBox ID="txtJLBH" Runat="server" CssClass="textbox" Columns="12"></asp:TextBox><asp:Button id="btnSelect_JLBH" Runat="server" CssClass="button" Text="…"></asp:Button></td>
                                                                                        <td class="labelNotNull" align="right" nowrap>人员代码</td>
                                                                                        <td align="left"><asp:TextBox ID="txtRYDM" Runat="server" CssClass="textbox" Columns="12"></asp:TextBox></td>
                                                                                        <td class="label" align="right">姓名</td>
                                                                                        <td align="left"><asp:TextBox ID="txtRYXM" Runat="server" CssClass="textbox" Columns="12"></asp:TextBox></td>
                                                                                        <td class="label" align="right">性别</td>
                                                                                        <td align="left"><asp:RadioButtonList ID="rblRYXB" Runat="server" CssClass="textbox" RepeatColumns="2" RepeatDirection="Vertical" RepeatLayout="Flow"><asp:ListItem Value="男">男</asp:ListItem><asp:ListItem Value="女">女</asp:ListItem></asp:RadioButtonList></td>
                                                                                        <td class="label" align="right">年龄</td>
                                                                                        <td align="left"><asp:TextBox ID="txtRYNN" Runat="server" CssClass="textbox" Columns="6"></asp:TextBox></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="label" align="right">学历</td>
                                                                                        <td align="left"><asp:DropDownList ID="ddlXL" Runat="server" CssClass="textbox" Width="100%"></asp:DropDownList></td>
                                                                                        <td class="label" align="right">拟分配部门</td>
                                                                                        <td align="left" colspan="3"><asp:TextBox ID="txtNFPBM" Runat="server" CssClass="textbox" Columns="30"></asp:TextBox><asp:Button id="btnSelect_ZZDM" Runat="server" CssClass="button" Text="…"></asp:Button></td>
                                                                                        <td class="label" align="right">拟担任职位</td>
                                                                                        <td align="left" colspan="3"><asp:TextBox ID="txtNDRZW" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="label" align="right">拟报到日期</td>
                                                                                        <td align="left"><asp:TextBox ID="txtNBDRQ" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox></td>
                                                                                        <td class="label" align="right">招聘说明</td>
                                                                                        <td align="left" colspan="3"><asp:TextBox ID="txtZPSM" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
                                                                                        <td class="label" align="right">现有人员数</td>
                                                                                        <td align="left"><asp:TextBox ID="txtXYRYS" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
                                                                                        <td class="label" align="right">定编人员数</td>
                                                                                        <td align="left"><asp:TextBox ID="txtDBRYS" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="10" align="right"><asp:Button ID="btnRYXX_AddNew" Runat="server" CssClass="button" Text="增加人员"></asp:Button><asp:Button ID="btnRYXX_Update" Runat="server" CssClass="button" Text="更改人员"></asp:Button><asp:Button ID="btnRYXX_Delete" Runat="server" CssClass="button" Text="删除人员"></asp:Button></td>
                                                                                    </tr>
                                                                                </table>
                                                                                <% if propEditMode = False then response.write("</div>") %>
                                                                            </td>
                                                                        </tr>
                                                                        <TR>
                                                                            <TD align="center"><asp:LinkButton id="lnkCZQSYJ_FH" Runat="server" CssClass="button"><img src="../../../images/gqsyj.ico" border="0" width="16" height="16" align="absmiddle">主管副总经理意见</asp:LinkButton><asp:LinkButton id="lnkCZQSYJ_FHBJ" Runat="server" CssClass="button">(有便笺)</asp:LinkButton></TD>
                                                                            <TD align="center"><asp:LinkButton id="lnkCZQSYJ_QF" Runat="server" CssClass="button"><img src="../../../images/gqsyj.ico" border="0" width="16" height="16" align="absmiddle">总经理审批</asp:LinkButton><asp:LinkButton id="lnkCZQSYJ_QFBJ" Runat="server" CssClass="button">(有便笺)</asp:LinkButton></TD>
                                                                            <TD class="label" vAlign="middle" align="center" colSpan="2" rowSpan="2">现有人员编制情况核实<BR>计划定编人数核实</TD>
                                                                            <TD vAlign="middle" align="center" rowSpan="3" nowrap><asp:LinkButton id="lnkCZQSYJ_HQ" Runat="server" CssClass="button"><img src="../../../images/gqsyj.ico" border="0" width="16" height="16" align="absmiddle">办公室主任意见</asp:LinkButton><br><asp:LinkButton id="lnkCZQSYJ_HQBJ" Runat="server" CssClass="button">(有便笺)</asp:LinkButton></TD>
                                                                            <TD rowSpan="3" valign="top"><DIV id="divHQYJ" style="TABLE-LAYOUT: fixed; OVERFLOW: auto; WIDTH: 240px; CLIP: rect(0px 240px 260px 0px); HEIGHT: 260px"><asp:label id="lblHQYJ" Runat="server" CssClass="label">lblHQYJ</asp:label></DIV></TD>
                                                                        </TR>
                                                                        <TR>
                                                                            <TD vAlign="top" rowSpan="5"><DIV id="divFHYJ" style="TABLE-LAYOUT: fixed; OVERFLOW: auto; WIDTH: 180px; CLIP: rect(0px 180px 178px 0px); HEIGHT: 178px"><asp:label id="lblFHYJ" Runat="server" CssClass="label">lblFHYJ</asp:label></DIV></TD>
                                                                            <TD vAlign="top" rowSpan="4"><DIV id="divQFYJ" style="TABLE-LAYOUT: fixed; OVERFLOW: auto; WIDTH: 180px; CLIP: rect(0px 180px 160px 0px); HEIGHT: 160px"><asp:label id="lblQFYJ" Runat="server" CssClass="label">lblQFYJ</asp:label></DIV></TD>
                                                                        </TR>
                                                                        <TR>
                                                                            <TD class="label" noWrap align="center">办公室核实</TD>
                                                                            <TD><asp:TextBox id="txtDBRS" Runat="server" CssClass="textbox" Columns="6"></asp:TextBox></TD>
                                                                        </TR>
                                                                        <TR>
                                                                            <TD class="label" colSpan="4">1、办公室通知所属部门审批结果，各部门通知相关人员到办公室办理入职手续</TD>
                                                                        </TR>
                                                                        <TR>
                                                                            <TD class="label" colSpan="4">2、入职时间以办理入职手续为准；提前试用人员的底薪以最终审批日期起计算</TD>
                                                                        </TR>
                                                                        <TR>
                                                                            <TD style="FONT-FAMILY: 黑体" align="right" style="BORDER-TOP-STYLE: none">签名：<asp:Label id="lblQFR" Runat="server"></asp:Label></TD>
                                                                            <TD class="label" colSpan="4">3、需办理保证书的人员，须办妥后方可办理入职手续</TD>
                                                                        </TR>
                                                                    </TABLE>
                                                                </TD>
                                                            </TR>
                                                        </TABLE>
                                                    </TD>
                                                </TR>
                                                <TR>
                                                    <TD align="center">
                                                        <TABLE cellSpacing="0" cellPadding="0" width="100%" border="1" bordercolordark="#99cccc" bordercolorlight="#ffffff">
                                                            <tr>
                                                                <td></td>
                                                                <td></td>
                                                                <td></td>
                                                                <td></td>
                                                                <td></td>
                                                                <td></td>
                                                            </tr>
                                                            <TR>
                                                                <TD class="labelAuto" align="right">经办单位：</TD>
                                                                <TD align="left"><asp:TextBox id="txtJBDW" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox></TD>
                                                                <TD class="labelAuto" align="right">经办人员：</TD>
                                                                <TD align="left"><asp:TextBox id="txtJBRY" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox></TD>
                                                                <TD class="labelAuto" align="right">经办日期：</TD>
                                                                <TD align="left"><asp:TextBox id="txtJBRQ" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox></TD>
                                                            </TR>
                                                            <TR>
                                                                <TD class="label" align="right">标题：</TD>
                                                                <TD align="left" colSpan="5"><asp:TextBox id="txtWJBT" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox></TD>
                                                            </TR>
                                                            <TR>
                                                                <TD class="label" align="right">备注：</TD>
                                                                <TD align="left" colSpan="5"><asp:TextBox id="txtBZXX" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox></TD>
                                                            </TR>
                                                        </TABLE>
                                                    </TD>
                                                </TR>
                                                <TR>
                                                    <TD align="center">
                                                        <DIV style="DISPLAY: none">
                                                            <TABLE cellSpacing="0" cellPadding="0" border="0">
                                                                <TR>
                                                                    <TD colSpan="4" height="3"></TD>
                                                                </TR>
                                                                <TR>
                                                                    <TD class="title" vAlign="middle" align="center" width="30">文<BR>件<BR>附<BR>件</TD>
                                                                    <TD>
                                                                        <DIV id="divFJ" style="TABLE-LAYOUT: fixed; OVERFLOW: auto; WIDTH: 370px; CLIP: rect(0px 370px 120px 0px); HEIGHT: 120px">
                                                                            <asp:datagrid id="grdFJ" runat="server" CssClass="label" Font-Size="12px" UseAccessibleHeader="True"
                                                                                AutoGenerateColumns="False" GridLines="Vertical" BorderStyle="None" CellPadding="4" AllowPaging="false"
                                                                                PageSize="30" AllowSorting="False" BorderWidth="0px" BorderColor="#DEDFDE" Font-Names="宋体">
                                                                                <FooterStyle BackColor="#CCCC99"></FooterStyle>
                                                                                <SelectedItemStyle Font-Size="12px" Font-Names="宋体" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
                                                                                <EditItemStyle Font-Size="12px" Font-Names="宋体" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
                                                                                <AlternatingItemStyle Font-Size="12px" Font-Names="宋体" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
                                                                                <ItemStyle Font-Size="12px" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
                                                                                <HeaderStyle Font-Size="12px" Font-Names="宋体" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#6699cc" HorizontalAlign="Left"></HeaderStyle>
                                                                                
                                                                                <Columns>
                                                                                    <asp:ButtonColumn ItemStyle-Width="40px" DataTextField="显示序号" SortExpression="显示序号" HeaderText="序号" CommandName="Select">
                                                                                        <HeaderStyle Width="40px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                    <asp:ButtonColumn ItemStyle-Width="340px" DataTextField="说明" SortExpression="说明" HeaderText="标题" CommandName="OpenDocument">
                                                                                        <HeaderStyle Width="340px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="文件标识" SortExpression="文件标识" HeaderText="文件标识" CommandName="Select">
                                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="序号" SortExpression="序号" HeaderText="序号" CommandName="Select">
                                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="页数" SortExpression="页数" HeaderText="页数" CommandName="Select">
                                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="位置" SortExpression="位置" HeaderText="位置" CommandName="Select">
                                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="本地文件" SortExpression="本地文件" HeaderText="本地文件" CommandName="Select">
                                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="下载标志" SortExpression="下载标志" HeaderText="下载标志" CommandName="Select">
                                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                </Columns>
                                                                                
                                                                                <PagerStyle Visible="False" NextPageText="下页" Font-Size="12px" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
                                                                            </asp:datagrid><INPUT id="htxtFJFixed" type="hidden" value="0" runat="server">
                                                                        </DIV>
                                                                    </TD>
                                                                    <TD class="title" vAlign="middle" align="center" width="30">链<BR>接<BR>文<BR>件</TD>
                                                                    <TD>
                                                                        <DIV id="divXGWJ" style="TABLE-LAYOUT: fixed; OVERFLOW: auto; WIDTH: 370px; CLIP: rect(0px 370px 120px 0px); HEIGHT: 120px">
                                                                            <asp:datagrid id="grdXGWJ" runat="server" CssClass="label" Font-Size="12px" UseAccessibleHeader="True"
                                                                                AutoGenerateColumns="False" GridLines="Vertical" BorderStyle="None" CellPadding="4" AllowPaging="false"
                                                                                PageSize="30" AllowSorting="False" BorderWidth="0px" BorderColor="#DEDFDE" Font-Names="宋体">
                                                                                <FooterStyle BackColor="#CCCC99"></FooterStyle>
                                                                                <SelectedItemStyle Font-Size="12px" Font-Names="宋体" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
                                                                                <EditItemStyle Font-Size="12px" Font-Names="宋体" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
                                                                                <AlternatingItemStyle Font-Size="12px" Font-Names="宋体" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
                                                                                <ItemStyle Font-Size="12px" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
                                                                                <HeaderStyle Font-Size="12px" Font-Names="宋体" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#6699cc" HorizontalAlign="Left"></HeaderStyle>
                                                                                
                                                                                <Columns>
                                                                                    <asp:ButtonColumn ItemStyle-Width="40px" DataTextField="显示序号" SortExpression="显示序号" HeaderText="序号" CommandName="Select">
                                                                                        <HeaderStyle Width="40px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                    <asp:ButtonColumn ItemStyle-Width="340px" DataTextField="文件标题" SortExpression="文件标题" HeaderText="标题" CommandName="OpenDocument">
                                                                                        <HeaderStyle Width="340px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="类别标识" SortExpression="类别标识" HeaderText="类别标识" CommandName="Select">
                                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="文件标识" SortExpression="文件标识" HeaderText="文件标识" CommandName="Select">
                                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="流水号" SortExpression="流水号" HeaderText="流水号" CommandName="Select">
                                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="文件类型" SortExpression="文件类型" HeaderText="文件类型" CommandName="Select">
                                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="办理类型" SortExpression="办理类型" HeaderText="办理类型" CommandName="Select">
                                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="文件子类" SortExpression="文件子类" HeaderText="文件子类" CommandName="Select">
                                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="办理状态" SortExpression="办理状态" HeaderText="办理状态" CommandName="Select">
                                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="主送单位" SortExpression="主送单位" HeaderText="主送单位" CommandName="Select">
                                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="机关代字" SortExpression="机关代字" HeaderText="机关代字" CommandName="Select">
                                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="文件年份" SortExpression="文件年份" HeaderText="文件年份" CommandName="Select">
                                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="文件序号" SortExpression="文件序号" HeaderText="文件序号" CommandName="Select">
                                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="主办单位" SortExpression="主办单位" HeaderText="主办单位" CommandName="Select">
                                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="拟稿人" SortExpression="拟稿人" HeaderText="拟稿人" CommandName="Select">
                                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="拟稿日期" SortExpression="拟稿日期" HeaderText="拟稿日期" CommandName="Select">
                                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="主题词" SortExpression="主题词" HeaderText="主题词" CommandName="Select">
                                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="快速收文" SortExpression="快速收文" HeaderText="快速收文" CommandName="Select">
                                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="序号" SortExpression="序号" HeaderText="序号" CommandName="Select">
                                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="页数" SortExpression="页数" HeaderText="页数" CommandName="Select">
                                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="位置" SortExpression="位置" HeaderText="位置" CommandName="Select">
                                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="本地文件" SortExpression="本地文件" HeaderText="本地文件" CommandName="Select">
                                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="下载标志" SortExpression="下载标志" HeaderText="下载标志" CommandName="Select">
                                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                </Columns>
                                                                                
                                                                                <PagerStyle Visible="False" NextPageText="下页" Font-Size="12px" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
                                                                            </asp:datagrid><INPUT id="htxtXGWJFixed" type="hidden" value="0" runat="server">
                                                                        </DIV>
                                                                    </TD>
                                                                </TR>
                                                            </TABLE>
                                                        </DIV>
                                                    </TD>
                                                </TR>
                                            </TABLE>
                                        </DIV>
                                    </TD>
                                </TR>
                                <TR>
                                    <TD height="3"></TD>
                                </TR>
                            </TABLE>
                        </TD>
                        <TD></TD>
                    </TR>
                    <TR id="trRow2">
                        <TD style="BORDER-TOP: #006699 2px solid" align="center" colSpan="3">
                            <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                <TR>
                                    <TD align="center">
                                        <div style="display:">
                                            <TABLE cellSpacing="0" cellPadding="0" border="0">
                                                <TR>
                                                    <TD vAlign="baseline"><asp:LinkButton id="lnkCZCYGJ" Runat="server" CssClass="button" Visible="False">查阅稿件</asp:LinkButton></TD>
                                                    <TD vAlign="baseline"><asp:LinkButton id="lnkCZCYFJ" Runat="server" CssClass="button" Visible="False">查阅附件</asp:LinkButton></TD>
                                                    <TD vAlign="baseline"><asp:LinkButton id="lnkCZCYXGWJ" Runat="server" CssClass="button" Visible="False">查阅相关文件</asp:LinkButton></TD>
                                                    <TD vAlign="baseline"><asp:LinkButton id="lnkCZCYQPWJ" Runat="server" CssClass="button">查阅电子签批件</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;</TD>
                                                    <TD vAlign="baseline"><asp:LinkButton id="lnkCZCYZSWJ" Runat="server" CssClass="button">查阅原件扫描件</asp:LinkButton></TD>
                                                </TR>
                                            </TABLE>
                                        </div>
                                    </TD>
                                    <TD class="labelAuto" align="right">流水号<asp:TextBox id="txtLSH" Runat="server" CssClass="textbox" Columns="14" Font-Name="宋体" Font-Size="12px"></asp:TextBox><INPUT id="htxtWJBS" type="hidden" size="1" runat="server"></TD>
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
                        <input id="htxtSessionIDRYXX" type="hidden" runat="server">
                        <input id="htxtSessionIDXGWJ" type="hidden" runat="server">
                        <input id="htxtSessionIDFJ" type="hidden" runat="server">
                        <input id="htxtEnforeEdit" type="hidden" runat="server">
                        <input id="htxtEditMode" type="hidden" runat="server">
                        <input id="htxtEditType" type="hidden" runat="server">
                        <input id="htxtZWNRFileName" type="hidden" runat="server">
                        <input id="htxtRYXXSort" type="hidden" runat="server">
                        <input id="htxtRYXXSortColumnIndex" type="hidden" runat="server">
                        <input id="htxtRYXXSortType" type="hidden" runat="server">
                        <input id="htxtXGWJSort" type="hidden" runat="server">
                        <input id="htxtXGWJSortColumnIndex" type="hidden" runat="server">
                        <input id="htxtXGWJSortType" type="hidden" runat="server">
                        <input id="htxtFJSort" type="hidden" runat="server">
                        <input id="htxtFJSortColumnIndex" type="hidden" runat="server">
                        <input id="htxtFJSortType" type="hidden" runat="server">
                        <input id="htxtDivLeftRYXX" type="hidden" runat="server">
                        <input id="htxtDivTopRYXX" type="hidden" runat="server">
                        <input id="htxtDivLeftXGWJ" type="hidden" runat="server">
                        <input id="htxtDivTopXGWJ" type="hidden" runat="server">
                        <input id="htxtDivLeftFJ" type="hidden" runat="server">
                        <input id="htxtDivTopFJ" type="hidden" runat="server">
                        <input id="htxtDivLeftSHYJ" type="hidden" runat="server">
                        <input id="htxtDivTopSHYJ" type="hidden" runat="server">
                        <input id="htxtDivLeftHQYJ" type="hidden" runat="server">
                        <input id="htxtDivTopHQYJ" type="hidden" runat="server">
                        <input id="htxtDivLeftFHYJ" type="hidden" runat="server">
                        <input id="htxtDivTopFHYJ" type="hidden" runat="server">
                        <input id="htxtDivLeftQFYJ" type="hidden" runat="server">
                        <input id="htxtDivTopQFYJ" type="hidden" runat="server">
                        <input id="htxtDivLeftContent" type="hidden" runat="server">
                        <input id="htxtDivTopContent" type="hidden" runat="server">
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
							function ScrollProc_divContent() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopContent");
								if (oText != null) oText.value = divContent.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftContent");
								if (oText != null) oText.value = divContent.scrollLeft;
								return;
							}
							function ScrollProc_divQFYJ() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopQFYJ");
								if (oText != null) oText.value = divQFYJ.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftQFYJ");
								if (oText != null) oText.value = divQFYJ.scrollLeft;
								return;
							}
							function ScrollProc_divFHYJ() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopFHYJ");
								if (oText != null) oText.value = divFHYJ.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftFHYJ");
								if (oText != null) oText.value = divFHYJ.scrollLeft;
								return;
							}
							function ScrollProc_divHQYJ() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopHQYJ");
								if (oText != null) oText.value = divHQYJ.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftHQYJ");
								if (oText != null) oText.value = divHQYJ.scrollLeft;
								return;
							}
							function ScrollProc_divSHYJ() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopSHYJ");
								if (oText != null) oText.value = divSHYJ.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftSHYJ");
								if (oText != null) oText.value = divSHYJ.scrollLeft;
								return;
							}
							function ScrollProc_divFJ() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopFJ");
								if (oText != null) oText.value = divFJ.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftFJ");
								if (oText != null) oText.value = divFJ.scrollLeft;
								return;
							}
							function ScrollProc_divXGWJ() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopXGWJ");
								if (oText != null) oText.value = divXGWJ.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftXGWJ");
								if (oText != null) oText.value = divXGWJ.scrollLeft;
								return;
							}
							function ScrollProc_divRYXX() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopRYXX");
								if (oText != null) oText.value = divRYXX.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftRYXX");
								if (oText != null) oText.value = divRYXX.scrollLeft;
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
								oText=document.getElementById("htxtDivTopContent");
								if (oText != null) divContent.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftContent");
								if (oText != null) divContent.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtDivTopQFYJ");
								if (oText != null) divQFYJ.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftQFYJ");
								if (oText != null) divQFYJ.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtDivTopFHYJ");
								if (oText != null) divFHYJ.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftFHYJ");
								if (oText != null) divFHYJ.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtDivTopHQYJ");
								if (oText != null) divHQYJ.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftHQYJ");
								if (oText != null) divHQYJ.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtDivTopSHYJ");
								if (oText != null) divSHYJ.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftSHYJ");
								if (oText != null) divSHYJ.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtDivTopFJ");
								if (oText != null) divFJ.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftFJ");
								if (oText != null) divFJ.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtDivTopXGWJ");
								if (oText != null) divXGWJ.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftXGWJ");
								if (oText != null) divXGWJ.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtDivTopRYXX");
								if (oText != null) divRYXX.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftRYXX");
								if (oText != null) divRYXX.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divContent.onscroll = ScrollProc_divContent;
								divQFYJ.onscroll = ScrollProc_divQFYJ;
								divFHYJ.onscroll = ScrollProc_divFHYJ;
								divHQYJ.onscroll = ScrollProc_divHQYJ;
								divSHYJ.onscroll = ScrollProc_divSHYJ;
								divFJ.onscroll = ScrollProc_divFJ;
								divXGWJ.onscroll = ScrollProc_divXGWJ;
								divRYXX.onscroll = ScrollProc_divRYXX;
							}
							catch (e) {}
                        </script>
                    </td>
                </tr>
                <tr>
                    <td>
                        <script language="javascript">window_onresize();</script>
                        <uwin:popmessage id="popMessageObject" runat="server" Visible="False" EnableViewState="False" PopupWindowType="Normal" ActionType="OpenWindow" height="48px" width="96px"></uwin:popmessage>
                    </td>
                </tr>
            </table>
        </form>
    </body>
</HTML>
