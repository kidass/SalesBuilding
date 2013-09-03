<%@ Page Language="vb" AutoEventWireup="false" Codebehind="estate_rs_nbtz_info.aspx.vb" Inherits="Josco.JSOA.web.estate_rs_nbtz_info" %>
<%@ Register TagPrefix="ComponentArt" Namespace="ComponentArt.Web.UI" Assembly="ComponentArt.Web.UI" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
    <head>
        <title>人事调整审批单的显示或编辑窗</title>
        <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR" />
        <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE" />
        <meta content="JavaScript" name="vs_defaultClientScript" />
        <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
        <link href="../../../styles01.css" type="text/css" rel="stylesheet" />
        <link href="../../../mnuStyle01.css" type="text/css" rel="stylesheet" />
        
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
        <script language="javascript" src="../../../scripts/Calendar.js" type="text/javascript"></script>
		
        <script language="javascript">
           
            function onclick_btnViewJG()
			{
				var strParams = "";
				strParams = strParams + "height=" + (screen.availHeight - 40).toString() +",";
				strParams = strParams + "width="  + (screen.availWidth  - 12).toString() +",";
				strParams = strParams + "top=0,";
				strParams = strParams + "left=0,";
				strParams = strParams + "location=no,";
				strParams = strParams + "menubar=no,";
				strParams = strParams + "toolbar=no,";
				strParams = strParams + "status=no,";
				strParams = strParams + "resizable=yes,";
				strParams = strParams + "scrollbars=yes,";
				strParams = strParams + "titlebar=yes";
				window.open("../renshi/estate_rs_renyuanjiagou_bdls_x2.aspx", "_blank", strParams);
			}
			
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
				intWidth  -= 10;                          //滚动条
				strWidth   = intWidth.toString() + "px";
				
				intHeight  = document.body.clientHeight;  //总高度
				intHeight -= 16;                          //滚动条
				intHeight -= trRow1.clientHeight;
				//intHeight -= trRow2.clientHeight;
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
    </head>
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
                                                        <TABLE cellSpacing="0" cellPadding="0"  border="0">
                                                            <TR>
                                                                <TD vAlign="middle" align="center" height="32"><SPAN style="FONT-WEIGHT: bold; FONT-SIZE: 28px; COLOR: red; FONT-FAMILY: 宋体">兴业公司人员调配及岗位职级调整审批表</SPAN></TD>
                                                            </TR>
                                                            <TR>
                                                                <TD height="10"></TD>
                                                            </TR>
                                                            <TR>
                                                                <TD><DIV style="DISPLAY: none">
                                                                    <TABLE cellSpacing="0" cellPadding="0"  border="0">
                                                                        <tr>
                                                                            <td width="30">&nbsp;</td>
                                                                            <td class="labelAuto">编号<asp:TextBox id="txtJGDZ" Runat="server" CssClass="textbox" Columns="10"></asp:TextBox>[<asp:TextBox id="txtWJNF" Runat="server" CssClass="textbox" Columns="4"></asp:TextBox>]第[<asp:TextBox id="txtWJXH" Runat="server" CssClass="textbox" Columns="4"></asp:TextBox>]号</TD>
                                                                            <td class="label">缓急<asp:DropDownList id="ddlJJCD" Runat="server" CssClass="textbox"></asp:DropDownList></TD>
                                                                            <td class="label">密级<asp:DropDownList id="ddlMMDJ" Runat="server" CssClass="textbox"></asp:DropDownList></TD>
                                                                            <td align="right"><asp:CheckBox id="chkDDSZ" Runat="server" CssClass="textbox" Text="不受流转限制" Font-Name="宋体" Font-Size="12px"></asp:CheckBox></TD>
                                                                            <td width="30"><asp:RadioButtonList id="rblSXRQ" Runat="server" CssClass="textbox" RepeatColumns="2" RepeatDirection="Horizontal" RepeatLayout="Table">
											                                                    <asp:ListItem Value="1" Selected="True">2011-10-1</asp:ListItem>
											                                                    <asp:ListItem Value="2">2011-10-15</asp:ListItem>
										                                                    </asp:RadioButtonList></td>
                                                                            <td class="labelAuto" align="right">流水号<asp:TextBox id="txtLSH" Runat="server" CssClass="textbox" Columns="14" Font-Name="宋体" Font-Size="12px"></asp:TextBox><INPUT id="htxtWJBS" type="hidden" size="1" runat="server"></TD>
                                                                            <td class="labelNotNull" align="right">简历编号</td>
                                                                            <td align="left"><asp:TextBox ID="txtJLBH" Runat="server" CssClass="textbox" Columns="12" ReadOnly="true" ></asp:TextBox></td>
                                                                         </tr>
                                                                         <tr>
                                                                            <td><asp:TextBox ID="txtSFJZ" runat="server"></asp:TextBox></td>
                                                                            <td><asp:TextBox ID="txtRTLX" runat="server"></asp:TextBox></td>
                                                                            <td><asp:TextBox ID="txtBZXL" runat="server"></asp:TextBox></td>
                                                                            <td><asp:TextBox ID="txtRTLXMC" runat="server"></asp:TextBox></td>
                                                                            <td><asp:TextBox ID="txtZGDWDM" runat="server"></asp:TextBox></td>
                                                                            <td><asp:TextBox ID="txtZGDWMC" runat="server"></asp:TextBox></td>
                                                                            <td><asp:TextBox ID="txtSJLD" runat="server"></asp:TextBox></td>
                                                                            
                                                                            <td><asp:TextBox ID="txtYWYBS" runat="server"></asp:TextBox> </td>
                                                                         </tr> 
                                                                         <tr>
                                                                            <TD class="label" align="right">标题：</TD>
                                                                            <TD align="left" colspan="5"><asp:TextBox id="txtWJBT" Runat="server" CssClass="textbox" >内部调整申请单</asp:TextBox></TD>
                                                                        </TR>
                                                                    </TABLE>
                                                               </DIV> </TD>
                                                            </TR>                                                           
                                                            <TR>
                                                                <TD align="center">
                                                                    <table cellspacing="0" cellpadding="0" border="1" bordercolordark="#99cccc" bordercolorlight="#ffffff">
                                                                         <TR>
                                                                            <TD >
                                                                                <DIV id="divRYXX" style="TABLE-LAYOUT: fixed; OVERFLOW: auto; WIDTH: 860px; CLIP: rect(0px 860px 200px 0px); HEIGHT: 200px">
                                                                                    <asp:datagrid id="grdRYXX" runat="server" Width="2560px" CssClass="labelGrid" 
                                                                                        AllowPaging="True" AutoGenerateColumns="False" GridLines="Both" BackColor="White"
                                                                                        PageSize="250" BorderColor="#dfdfdf" BorderWidth="1px" AllowSorting="True" CellPadding="4"  UseAccessibleHeader="True" BorderStyle="Solid">
															                             <SelectedItemStyle  Font-Bold="False" VerticalAlign="Middle" HorizontalAlign="Center" ForeColor="blue" ></SelectedItemStyle>
                                                                                        <EditItemStyle   BackColor="#FFCC00" VerticalAlign="Middle" HorizontalAlign="Center" ></EditItemStyle>
                                                                                        <AlternatingItemStyle  BorderWidth="1px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
                                                                                        <ItemStyle  BorderWidth="1px" HorizontalAlign="Center" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
                                                                                        <HeaderStyle   Font-Bold="True" HorizontalAlign="Center"  ForeColor="White" VerticalAlign="Middle" BackColor="#6699cc" ></HeaderStyle>
                                                                                        <FooterStyle BackColor="#CCCC99" HorizontalAlign="Center" ></FooterStyle>
                                                                                        
                                                                                        <Columns>
																                            <asp:TemplateColumn HeaderText="选" ItemStyle-Width="20px">
																	                            <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
																	                            <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																	                            <ItemTemplate>
																		                            <asp:CheckBox id="chkRYXX" runat="server" AutoPostBack="False" Width="20px"></asp:CheckBox>
																	                            </ItemTemplate>
																                            </asp:TemplateColumn>	
																                             <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="原因名称" SortExpression="原因名称" HeaderText="变动名称" CommandName="Select">
                                                                                                <HeaderStyle Width="100px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>                                                                                                                                                                                       
                                                                                            <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="人员姓名" SortExpression="人员姓名" HeaderText="姓名" CommandName="Select">
                                                                                                <HeaderStyle Width="100px"></HeaderStyle>  
                                                                                             </asp:ButtonColumn> 
                                                                                             <asp:ButtonColumn ItemStyle-Width="120px" DataTextField="原职级名称" SortExpression="原职级名称" HeaderText="原职级名称" CommandName="Select">
                                                                                                <HeaderStyle Width="120px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>   
                                                                                            <asp:ButtonColumn ItemStyle-Width="120px" DataTextField="职级名称" SortExpression="职级名称" HeaderText="现职级名称" CommandName="Select">
                                                                                                <HeaderStyle Width="120px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="原单位名称" SortExpression="原单位名称" HeaderText="原单位名称" CommandName="Select">
                                                                                                <HeaderStyle Width="100px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="单位名称" SortExpression="单位名称" HeaderText="现单位名称" CommandName="OpenDocument">
                                                                                                <HeaderStyle Width="100px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>   
                                                                                             <asp:ButtonColumn ItemStyle-Width="60px" DataTextField="原团队编号" SortExpression="原团队编号" HeaderText="原团队" CommandName="OpenDocument">
                                                                                                <HeaderStyle Width="60px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn ItemStyle-Width="60px" DataTextField="团队编号" SortExpression="团队编号" HeaderText="现团队" CommandName="Select">
                                                                                                <HeaderStyle Width="60px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>        
                                                                                            <asp:ButtonColumn  ItemStyle-Width="100px" DataTextField="上级经理" SortExpression="上级经理" HeaderText="原上级经理" CommandName="Select">
                                                                                                <HeaderStyle Width="100px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>  
                                                                                             <asp:ButtonColumn  ItemStyle-Width="100px" DataTextField="上级领导名称" SortExpression="上级领导名称" HeaderText="新上级经理" CommandName="Select">
                                                                                                <HeaderStyle Width="100px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn  ItemStyle-Width="100px" DataTextField="生效日期" SortExpression="生效日期" HeaderText="拟生效日期" CommandName="Select">
                                                                                                <HeaderStyle Width="100px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>                                                                                          
                                                                                            <asp:ButtonColumn  ItemStyle-Width="160px" DataTextField="原直管团队名称" SortExpression="原直管团队名称" HeaderText="原直管团队" CommandName="Select">
                                                                                                <HeaderStyle Width="160px"></HeaderStyle>
                                                                                            </asp:ButtonColumn> 
                                                                                            <asp:ButtonColumn  ItemStyle-Width="160px" DataTextField="直管团队名称" SortExpression="直管团队名称" HeaderText="现直管团队" CommandName="Select">
                                                                                                <HeaderStyle Width="160px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn  ItemStyle-Width="160px" DataTextField="原协管团队名称" SortExpression="原协管团队名称" HeaderText="原协管团队" CommandName="Select">
                                                                                                <HeaderStyle Width="160px"></HeaderStyle>
                                                                                            </asp:ButtonColumn> 
                                                                                            <asp:ButtonColumn  ItemStyle-Width="160px" DataTextField="协管团队名称" SortExpression="协管团队名称" HeaderText="现协管团队" CommandName="Select">
                                                                                                <HeaderStyle Width="160px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>                                              
                                                                                            <asp:ButtonColumn ItemStyle-Width="80px" DataTextField="人员代码" SortExpression="人员代码" HeaderText="人员代码" CommandName="Select">
                                                                                                <HeaderStyle Width="80px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>   
                                                                                            <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="原人员状态名称" SortExpression="原人员状态名称" HeaderText="原人员状态" CommandName="Select">
                                                                                                <HeaderStyle Width="100px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>                                                                                                   
                                                                                            <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="人员状态名称" SortExpression="人员状态名称" HeaderText="现人员状态" CommandName="Select">
                                                                                                <HeaderStyle Width="100px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>  
                                                                                            <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="原占编" SortExpression="原占编" HeaderText="原占编" CommandName="Select">
                                                                                                <HeaderStyle Width="100px"></HeaderStyle>                                                                                                
                                                                                            </asp:ButtonColumn> 
                                                                                            <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="占编" SortExpression="占编" HeaderText="占编" CommandName="Select">
                                                                                                <HeaderStyle Width="100px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>   
                                                                                            <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="审批说明" SortExpression="审批说明" HeaderText="审核说明" CommandName="Select">
                                                                                                <HeaderStyle Width="100px"></HeaderStyle>
                                                                                            </asp:ButtonColumn> 
                                                                                             <asp:ButtonColumn ItemStyle-Width="120px" DataTextField="审批日期" SortExpression="审批日期" HeaderText="审核日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
                                                                                                <HeaderStyle Width="120px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>   
                                                                                             <asp:ButtonColumn ItemStyle-Width="80px" DataTextField="审批状态" SortExpression="审批状态" HeaderText="审核状态" CommandName="OpenDocument">
                                                                                                <HeaderStyle Width="80px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn ItemStyle-Width="80px" DataTextField="审批人" SortExpression="审批人" HeaderText="审核人" CommandName="OpenDocument">
                                                                                                <HeaderStyle Width="80px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>  
                                                                                            <asp:ButtonColumn ItemStyle-Width="120px" DataTextField="报到日期" SortExpression="报到日期" HeaderText="报到日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
                                                                                                <HeaderStyle Width="120px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>                                                                                                                                                                                     
																                             <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="文件标识" SortExpression="文件标识" HeaderText="文件标识" CommandName="Select">
                                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="唯一标识" SortExpression="唯一标识" HeaderText="唯一标识" CommandName="Select">
                                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="原唯一标识" SortExpression="原唯一标识" HeaderText="原唯一标识" CommandName="Select">
                                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>  
                                                                                             <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="原职级代码" SortExpression="原职级代码" HeaderText="原职级代码" CommandName="OpenDocument">
                                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>   
                                                                                             <asp:ButtonColumn  Visible="False" ItemStyle-Width="0px" DataTextField="职级代码" SortExpression="职级代码" HeaderText="职级代码" CommandName="Select">
                                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>  
                                                                                             <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="单位代码" SortExpression="单位代码" HeaderText="单位代码" CommandName="Select">
                                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>   
                                                                                             <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="原单位代码" SortExpression="原单位代码" HeaderText="原单位代码" CommandName="Select">
                                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>  
                                                                                             <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="原人员状态" SortExpression="原人员状态" HeaderText="原人员状态" CommandName="Select">
                                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                                            </asp:ButtonColumn> 
                                                                                              <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="人员状态" SortExpression="人员状态" HeaderText="人员状态" CommandName="Select">
                                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                                            </asp:ButtonColumn> 
                                                                                            <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="原是否占编" SortExpression="原是否占编" HeaderText="原是否占编" CommandName="Select">
                                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>   
                                                                                             <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="是否占编" SortExpression="是否占编" HeaderText="是否占编" CommandName="Select">
                                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>    
                                                                                            <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="原因代码" SortExpression="原因代码" HeaderText="原因代码" CommandName="Select">
                                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>  
                                                                                            <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="原直管团队" SortExpression="原直管团队" HeaderText="原直管团队" CommandName="Select">
                                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>   
                                                                                            <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="直管团队" SortExpression="直管团队" HeaderText="直管团队" CommandName="Select">
                                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                                            </asp:ButtonColumn> 
                                                                                             <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="原协管团队" SortExpression="原协管团队" HeaderText="原协管团队" CommandName="Select">
                                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>   
                                                                                            <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="协管团队" SortExpression="协管团队" HeaderText="协管团队" CommandName="Select">
                                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                                            </asp:ButtonColumn> 
                                                                                            <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="是否兼职" SortExpression="是否兼职" HeaderText="是否兼职" CommandName="Select">
                                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                                            </asp:ButtonColumn> 
                                                                                            <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="人员类型" SortExpression="人员类型" HeaderText="人员类型" CommandName="Select">
                                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                                            </asp:ButtonColumn> 
                                                                                            <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="标准序列" SortExpression="标准序列" HeaderText="标准序列" CommandName="Select">
                                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                                            </asp:ButtonColumn> 
                                                                                            <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="人员类型名称" SortExpression="人员类型名称" HeaderText="人员类型名称" CommandName="Select">
                                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                                            </asp:ButtonColumn> 
                                                                                            <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="直管单位代码" SortExpression="直管单位代码" HeaderText="直管单位代码" CommandName="Select">
                                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                                            </asp:ButtonColumn> 
                                                                                            <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="直管单位名称" SortExpression="直管单位名称" HeaderText="直管单位名称" CommandName="Select">
                                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                                            </asp:ButtonColumn> 
                                                                                            <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="上级领导" SortExpression="上级领导" HeaderText="上级领导" CommandName="Select">
                                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                           
                                                                                            <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="审批结果名称" SortExpression="审批结果名称" HeaderText="审核结果名称" CommandName="Select">
                                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>                                                                                                                                                                              
                                                                                        </Columns>                                                                                        
                                                                                        <PagerStyle Visible="False" NextPageText="下页" Font-Size="12px" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
                                                                                    </asp:datagrid><INPUT id="htxtRYXXFixed" type="hidden" value="0" runat="server">
                                                                                </DIV>
                                                                            </TD>                                                                            
                                                                        </TR>
                                                                        <tr>
                                                                            <td align="left">
                                                                                
                                                                                <table cellpadding="0" cellspacing="0"  border="1" width="100%" bordercolordark="#99cccc" bordercolorlight="#ffffff">
                                                                                    <tr>
                                                                                        <td class="labelNotNull" align="right">调整原因：</TD>
									                                                    <td class="label" align="left"><asp:DropDownList id="ddlYDYY" Runat="server" CssClass="textbox" Width="120px"></asp:DropDownList></TD>
								                                                        <td class="label" align="right">姓名</td>
                                                                                        <td align="left"><asp:TextBox ID="txtRYXM" Runat="server" CssClass="textbox" Columns="12" ReadOnly="true"></asp:TextBox><asp:Button id="btnSelectXM" Runat="server" CssClass="button" Text="…"></asp:Button></td>
                                                                                        <td class="label" align="right">人员代码</td>
                                                                                        <td align="left"><asp:TextBox ID="txtRYDM" Runat="server" CssClass="textbox" Columns="16" ReadOnly="true"></asp:TextBox></td>
                                                                                        <td class="label" align="right">原人员状态</td>
                                                                                        <td align="left"><asp:TextBox ID="txtYRYZT" Runat="server" CssClass="textbox" Columns="16" ReadOnly="true"></asp:TextBox><input id="htxtYRYZTDM" type="hidden" size="1" runat="server" name="htxtYRYZTDM" /></td>
                                                                                       
                                                                                    </tr>
								                                                    <tr>
								                                                        <td class="label" align="right">原职级名称</td>
                                                                                        <td align="left"><asp:TextBox ID="txtYZJMC" runat="server" CssClass="textbox" Columns="14" ReadOnly="true"></asp:TextBox><input id="htxtYZJDM" type="hidden" size="1" runat="server" name="htxtYZJDM" /></td>
                                                                                        <td class="label" align="right">原单位名称</td>
                                                                                        <td align="left"><asp:TextBox ID="txtYBMMC" Runat="server" CssClass="textbox" Columns="16" ReadOnly="true"></asp:TextBox><input id="htxtYBMDM" type="hidden" size="1" runat="server" name="htxtYBMDM" /></td>
                                                                                        <td class="label" align="right">原团队</td>
                                                                                        <td align="left"><asp:TextBox ID="txtYTD" Runat="server" CssClass="textbox" Columns="16" ReadOnly="true"></asp:TextBox></td>
                                                                                         <td class="label" align="right">原占编情况</td>
                                                                                        <td align="left" ><asp:TextBox ID="txtYZBQK" Runat="server" CssClass="textbox" Columns="16" ReadOnly="true"></asp:TextBox><input id="htxtYZBQKDM" type="hidden" size="1" runat="server" name="htxtYZBQKDM" /></td>                                                                                        
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="labelNotNull" align="right">新的职级：</TD>
									                                                    <td align="left"><asp:DropDownList id="ddlZJDM" Runat="server" CssClass="textbox" Width="120px"></asp:DropDownList></TD>
								                                                        
								                                                        <td class="labelNotNull" align="right" >新的单位：</TD>
									                                                    <td class="label" align="left"><asp:TextBox id="txtSSDW" Runat="server" CssClass="textbox" Columns="12" ReadOnly="True"></asp:TextBox><INPUT id="htxtSSDW" type="hidden" size="1" runat="server" NAME="htxtSSDW"><asp:Button id="btnSelectZZDM" Runat="server" CssClass="button" Text="…"></asp:Button></TD>
								                                                        <td class="labelNotNull" align="right">新的团队：</TD>
									                                                    <td class="label" align="left" ><asp:TextBox id="txtTDBH" Runat="server" CssClass="textbox" Columns="12" ></asp:TextBox><asp:Button id="btnSelectTDBH" Runat="server" CssClass="button" Text="…"></asp:Button></TD>
								                                                         <td class="labelNotNull" align="right">新占编情况</td>
								                                                        <td align="left">
										                                                    <asp:RadioButtonList id="rblSFZB" Runat="server" CssClass="textbox" RepeatColumns="2" RepeatDirection="Horizontal" RepeatLayout="Table" Enabled="false">
											                                                    <asp:ListItem Value="0">编外人员</asp:ListItem>
											                                                    <asp:ListItem Value="1" Selected="True">编内人员</asp:ListItem>
										                                                    </asp:RadioButtonList>
									                                                    </td>
								                                                         
									                                                </tr>
									                                                <tr>
									                                                    <td class="labelNotNull" align="right">拟生效日期：</td>
									                                                     <td align="left"><asp:TextBox onfocus="calendar()" ID="txtRQ" Runat="server" CssClass="textbox" Columns="16"></asp:TextBox></td> 
									                                                    <td class="labelNotNull" align="right">原上级经理：</td>
									                                                    <td class="label" align="left" ><asp:TextBox id="txtYSJLDMC" Runat="server" CssClass="textbox" Columns="12"></asp:TextBox><asp:Button id="btnYSJJL" Runat="server" CssClass="button" Text="…"></asp:Button></td>
								                                                        <td class="labelNotNull" align="right">新上级经理：</td>
									                                                    <td class="label" align="left" ><asp:TextBox id="txtSJLDMC" Runat="server" CssClass="textbox" Columns="12"></asp:TextBox><asp:Button id="btnSJJL" Runat="server" CssClass="button" Text="…"></asp:Button></td>
								                                                         <td class="labelNotNull" align="right">新人员状态</td>
									                                                     <td align="left">
										                                                    <asp:RadioButtonList id="rblRYZT" Runat="server" CssClass="textbox" RepeatColumns="3" RepeatDirection="Horizontal" RepeatLayout="Table" Enabled="false" >
											                                                    <asp:ListItem Value="1" Selected="True">试用</asp:ListItem>
											                                                    <asp:ListItem Value="2">正式</asp:ListItem>
											                                                        <asp:ListItem Value="4">实习生</asp:ListItem>
										                                                    </asp:RadioButtonList>
									                                                    </td> 
									                                                </tr>							                                                
								                                                    <tr>
								                                                         <td class="label" align="right">原直管团队：</TD>
									                                                    <td class="label" align="left" valign="top"><asp:ListBox ID="lstYZGTD" Runat="server" CssClass="textbox" Rows="4" SelectionMode="Multiple" Width="120px"></asp:ListBox><input type="hidden" id="htxtYZGTD" runat="server" name="htxtYZGTD" /></TD>
								                                                        <td class="label" align="right">原协管团队：</TD>
									                                                    <td class="label" align="left" valign="top"><asp:ListBox ID="lstYXGTD" Runat="server" CssClass="textbox" Rows="4" SelectionMode="Multiple" Width="120px"></asp:ListBox><input type="hidden" id="htxtYXGTD" runat="server" name="htxtYXGTD" /></TD>
								                                                        <td class="labelNotNull" align="right">新直管团队：</TD>
									                                                    <td class="label" align="left" valign="top"><asp:ListBox ID="lstZGTD" Runat="server" CssClass="textbox" Rows="4" SelectionMode="Multiple" Width="110px"></asp:ListBox><input type="hidden" id="htxtZGTD" runat="server" name="htxtZGTD" />
								                                                        <br /><asp:Button id="btnSelectZGTD" Runat="server" CssClass="button" Text="重选"></asp:Button><asp:Button id="btnAddnewZGTD" Runat="server" CssClass="button" Text="增加"></asp:Button><asp:Button id="btnDeleteZGTD" Runat="server" CssClass="button" Text="删除"></asp:Button></td>
								                                                        <td class="labelNotNull" align="right">新协管团队：</TD>
									                                                    <td class="label" align="left" valign="top"><asp:ListBox ID="lstXGTD" Runat="server" CssClass="textbox" Rows="4" SelectionMode="Multiple" Width="120px"></asp:ListBox><input type="hidden" id="htxtXGTD" runat="server" name="htxtXGTD" />
								                                                        <br /><asp:Button id="btnSelectXGTD" Runat="server" CssClass="button" Text="重选"></asp:Button><asp:Button id="btnAddnewXGTD" Runat="server" CssClass="button" Text="增加"></asp:Button><asp:Button id="btnDeleteXGTD" Runat="server" CssClass="button" Text="删除"></asp:Button></td>
								                                                   
								                                                    </tr>
								                                                    <tr>
									                                                    <td align="left">
														                                    <asp:RadioButtonList id="rblRYLX" Runat="server" CssClass="textbox" RepeatColumns="2" RepeatDirection="Horizontal" RepeatLayout="Table" AutoPostBack="True" Visible="False">
															                                    <asp:ListItem Value="1" Selected="True">业务人员</asp:ListItem>
															                                    <asp:ListItem Value="0">行政助理</asp:ListItem>
														                                    </asp:RadioButtonList>
													                                    </td>
									                                                     <td align="left"><asp:CheckBox id="chkSFJZ" Runat="server" CssClass="textbox" Text="兼职" Enabled="False" AutoPostBack="True" Visible="False"></asp:CheckBox></TD>
								                                                    </tr>
								                                                                                           
                                                                                    <tr>
                                                                                        <td colspan="8" align="right"><% if propEditMode = False then response.write("<div style='display:none'>") %><asp:Button ID="btnRYXX_AddNew" Runat="server" CssClass="button" Text="增加人员"></asp:Button><asp:Button ID="btnRYXX_Delete" Runat="server" CssClass="button" Text="删除人员"></asp:Button> <% if propEditMode = False then response.write("</div>") %></td>
                                                                                    </tr>
                                                                                </table>
                                                                               
                                                                                
                                                                                <% If propSPMode = False Then Response.Write("<div style='display:none'>")%>
                                                                                <table cellpadding="0"  cellspacing="0" width="100%"  border="1" bordercolordark="#99cccc" bordercolorlight="#ffffff">
                                                                                    <tr>
                                                                                        <td>&nbsp;</td>
                                                                                        <td class="labelNotNull" align="right">审核说明
                                                                                        <asp:TextBox ID="txtSPSM" Runat="server" CssClass="textbox" Columns="30"></asp:TextBox>                                                                                        
                                                                                        <asp:Button ID="btnBTG" Runat="server" CssClass="button" Text="不通过"></asp:Button></td>
                                                                                    </tr>                                                                                 
                                                                                </table> 
                                                                                <% If propSPMode = False Then Response.Write("</div>")%>
                                                                                
                                                                                <% If propTGMode = False Then Response.Write("<div style='display:none'>")%>
                                                                                    <table cellpadding="0" cellspacing="0" width="100%"  border="1" bordercolordark="#99cccc" bordercolorlight="#ffffff">
                                                                                        <tr>
                                                                                            <td >&nbsp;</td>
                                                                                            <td class="label" align="right">报到日期
                                                                                            <asp:TextBox ID="txtNBDRQ" Runat="server" CssClass="textbox" Columns="20"></asp:TextBox>   
												                                            <asp:Button ID="btnTG" Runat="server" CssClass="button" Text=" 通过 "></asp:Button></td>                                                                                    
                                                                                        </tr>                                                                                        
                                                                                     </table> 
                                                                                <% If propTGMode = False Then Response.Write("</div>")%>
                                                                            </td>
                                                                            
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <table cellpadding="0" cellspacing="0" width="100%">
                                                                                    <tr>
                                                                                        <td>&nbsp;</td>
																                        <td  valign="top">
																	                        <table cellspacing="0" cellpadding="0" border="0" width="100%">
																	                            <tr>
																	                                <td>
																	                                    <table>
																	                                        <tr>
																			                                    <TD  height="3" colspan="2"></TD>
																		                                    </tr>
																		                                    <tr>
																			                                    <td colspan="2" height="20">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton id="lnkCZQSYJ_FH" Runat="server" CssClass="button">调出售楼部经理意见</asp:LinkButton><asp:LinkButton id="lnkCZQSYJ_FHBJ" Runat="server" CssClass="button">(有便笺)</asp:LinkButton></td>
																		                                    </tr>
																		                                    <tr>
																			                                    <td width="30"></td>
																			                                    <td><div id="divFHYJ" style="TABLE-LAYOUT: fixed; OVERFLOW: auto; WIDTH: 180px; CLIP: rect(0px 180px 50px 0px); HEIGHT: 50px"><asp:label id="lblFHYJ" Runat="server" CssClass="label">lblFHYJ</asp:label></DIV></td>
																		                                    </tr>	
																	                                    </table>
																	                                </td>																	                            
																	                            </tr>
																		                        <tr>
																		                            <td style="BORDER-TOP: #99CCCC thin solid;width:auto" >
																		                                <table>
																		                                    <tr>
																			                                    <TD  height="3" colspan="2"></TD>
																		                                    </tr>
																		                                    <tr>
																			                                    <TD colspan="2" height="20">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="lnkCZQSYJ_HG" Runat="server" CssClass="button">调入售楼部经理意见</asp:LinkButton><asp:LinkButton id="lnkCZQSYJ_HGBJ" Runat="server" CssClass="button">(有便笺)</asp:LinkButton></TD>
																		                                    </tr>
																		                                    <tr>
																			                                    <td width="30"></td>
																			                                    <td><div id="divHGYJ" style="TABLE-LAYOUT: fixed; OVERFLOW: auto; WIDTH: 180px; CLIP: rect(0px 180px 50px 0px); HEIGHT: 50px"><asp:label id="lblHGYJ" Runat="server" CssClass="label">lblHGYJ</asp:label></DIV></td>
																		                                    </tr>
																		                                    
																		                                </table>
																		                            </td>
																		                        </tr>
																	                        </table>
																                        </td>
																                        
																                        <td  style="BORDER-RIGHT: #99CCCC thin solid">&nbsp;</td>
																                        <td valign="top">
																	                        <table cellspacing="0" cellpadding="0" border="0">
																		                        <tr>
																			                        <td  height="3" colspan="2"></td>
																		                        </tr>
																		                        <tr>
																			                        <td colspan="2" height="20">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton id="lnkCZQSYJ_QF" Runat="server" CssClass="button">销售中心审批</asp:LinkButton><asp:LinkButton id="lnkCZQSYJ_QFBJ" Runat="server" CssClass="button">(有便笺)</asp:LinkButton></td>
																		                        </tr>
																		                        <tr>
																			                        <td width="20"></td>
																			                        <td><div id="divQFYJ" style="TABLE-LAYOUT: fixed; OVERFLOW: auto; WIDTH: 180px; CLIP: rect(0px 180px 100px 0px); HEIGHT: 100px"><asp:label id="lblQFYJ" Runat="server" CssClass="labelYj">lblQFYJ</asp:label></DIV></td>
																		                        </tr>																		                       
																	                        </table>
																                        </td>
																                        <td style="BORDER-RIGHT: #99CCCC thin solid">&nbsp;</td> 
																                        <td valign="top">
																	                        <table cellspacing="0" cellpadding="0" border="0">
																		                        <tr>
																			                        <td  height="3" colspan="2"></td>
																		                        </tr>
																		                        <tr>
																			                        <td colspan="2" height="20">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton id="lnkCZQSYJ_SH" Runat="server" CssClass="button">办公室审批</asp:LinkButton><asp:LinkButton id="lnkCZQSYJ_SHBJ" Runat="server" CssClass="button">(有便笺)</asp:LinkButton></td>
																		                        </tr>
																		                        <tr>
																			                        <td width="20"></td>
																			                        <td><div id="divSHYJ" style="TABLE-LAYOUT: fixed; OVERFLOW: auto; WIDTH: 180px; CLIP: rect(0px 180px 100px 0px); HEIGHT: 100px"><asp:label id="lblSHYJ" Runat="server" CssClass="labelYj">lblSHYJ</asp:label></div></td>
																		                        </tr>																		                       
																	                        </table>
																                        </td>
																                        
																                        <td valign="top"><div style="display:none">
																	                        <table cellspacing="0" cellpadding="0" border="0">
																		                        <tr>
																			                        <td  height="3" colspan="2"></td>
																		                        </tr>
																		                        <tr>
																			                        <td colspan="2" height="20">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton id="lnkCZQSYJ_HQ" Runat="server" CssClass="button">领导班子审批</asp:LinkButton><asp:LinkButton id="lnkCZQSYJ_HQBJ" Runat="server" CssClass="button">(有便笺)</asp:LinkButton></td>
																		                        </tr>
																		                        <tr>
																			                        <td width="20"></td>
																			                        <td><div id="divHQYJ" style="TABLE-LAYOUT: fixed; OVERFLOW: auto; WIDTH: 180px; CLIP: rect(0px 180px 100px 0px); HEIGHT: 100px"><asp:label id="lblHQYJ" Runat="server" CssClass="labelYj">lblHQYJ</asp:label></div></td>
																		                        </tr>																		                       
																	                        </table></div>
																                        </td>
																                    </tr>
																                </table>
																            </td>
                                                                        </tr> 
                                                                    </table>
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
                                                                <TD class="label" align="right">备注：</TD>
                                                                <TD align="left" colspan="5"><asp:TextBox id="txtBZXX" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox></TD>
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
                        <input id="htxtBDYY_RYZJ" type="hidden" runat="server" name="htxtBDYY_RYZJ" value="001">
						<input id="htxtBDYY_NBTZ" type="hidden" runat="server" name="htxtBDYY_NBTZ" value="003">
						<input id="htxtBZXL" type="hidden" runat="server" name="htxtBZXL" value="2">
						<input id="htxtSessionId_TDZH" type="hidden" runat="server" name="htxtSessionId_TDZH">
						<input id="htxtSessionId_YTDZH" type="hidden" runat="server" name="htxtSessionId_YTDZH">
                        <input id="htxtRYXM"  type="hidden" runat="server" />
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
</html>

