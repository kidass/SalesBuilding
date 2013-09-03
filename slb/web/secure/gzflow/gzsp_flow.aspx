<%@ Page Language="vb" AutoEventWireup="false" Codebehind="gzsp_flow.aspx.vb" Inherits="Josco.JSOA.web.gzsp_flow" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Register TagPrefix="componentart" Namespace="ComponentArt.Web.UI" Assembly="ComponentArt.Web.UI" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
    <HEAD>       
        <title>审批工作</title>        
        <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
        <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
        <meta HTTP-EQUIV="refresh" CONTENT="3600" url="gzsp_flow.aspx">
        <meta content="JavaScript" name="vs_defaultClientScript">
        <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <LINK href="../../stylesGrsw.css" type="text/css" rel="stylesheet">
        <link href="../../StyleMnuGrsw.css" type="text/css" rel="stylesheet"> 
        <LINK href="../../styles01.css" type="text/css" rel="stylesheet">
        <link href="../../mnuStyle01.css" type="text/css" rel="stylesheet">  
        <script language="vb" runat="server">
            '获取Unicode的字符串转换为MBCS字符串的字节长度
            Public Function getStringLength(ByVal strValue As String) As Integer
                Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
                getStringLength = objPulicParameters.getStringLength(strValue)
                Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            End Function

            '从Unicode的字符串中获取指定长度的字符串，长度按MBCS计算
            Public Function getSubString(ByVal strValue As String, ByVal intLen As Integer) As String
                Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
                getSubString = objPulicParameters.getSubString(strValue, intLen)
                Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            End Function

            '获取应用根目录HTTP路径
            Public Function getApplicationPath() As String
                getApplicationPath = Request.ApplicationPath
            End Function
            
            '----------------------------------------------------------------
            ' 隐藏没有权限的菜单
            '----------------------------------------------------------------
            Private Sub mnuMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuMain.Load
                Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
                Dim objsystemAppManager As New Josco.JsKernal.BusinessFacade.systemAppManager
                Dim objMokuaiQXData As Josco.JsKernal.Common.Data.AppManagerData = Nothing
                Dim strErrMsg As String = ""
                Try
                    '根据登录用户获取模块权限数据
                    If MyBase.UserId.ToUpper() = "SA" Then
                        Exit Try
                    End If
                    '普通用户权限
                    If objsystemAppManager.getDBUserMokuaiQXData(strErrMsg, MyBase.UserId, MyBase.UserPassword, MyBase.UserId, objMokuaiQXData) = True Then
                        Dim strMKMC As String = Josco.JsKernal.Common.Data.AppManagerData.FIELD_GL_B_YINGYONGXITONG_MOKUAIQX_MKMC
                        Dim blnVisible As Boolean = False
                        Dim strParamValue As String = ""
                        Dim strFilter As String = ""
                        With objMokuaiQXData.Tables(Josco.JsKernal.Common.Data.AppManagerData.TABLE_GL_B_YINGYONGXITONG_MOKUAIQX)
                            strParamValue = "应用系统-人事管理-人事变动-批量转发"
                            strFilter = strMKMC + " = '" + strParamValue + "'"
                            .DefaultView.RowFilter = strFilter
                            If .DefaultView.Count < 1 Then
                                Me.mnuMain.FindItemById("mnuZF").Visible = False
                            End If
                        End With
                    End If
                Catch ex As Exception
                End Try
                Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
                Josco.JsKernal.BusinessFacade.systemAppManager.SafeRelease(objsystemAppManager)
                Josco.JsKernal.Common.Data.AppManagerData.SafeRelease(objMokuaiQXData)
            End Sub
        </script>        
        <style type=text/css>
			body { 
					SCROLLBAR-HIGHLIGHT-COLOR:#ffffff;   /*滚动条及箭头的亮边色*/   
					SCROLLBAR-SHADOW-COLOR:#aca899;         /*滚动条及箭头的暗边色*/   
					SCROLLBAR-3DLIGHT-COLOR:#f1efe2;       /*滚动条及箭头的3D亮边色*/   
					SCROLLBAR-TRACK-COLOR:#ece9d8;           /*滚动条底色*/   
					SCROLLBAR-DARKSHADOW-COLOR:#716f64;   /*滚动条及箭头的暗边阴影色*/   
					SCROLLBAR-BASE-COLOR: white;             /*滚动条的基本颜色*/   
					SCROLLBAR-ARROW-COLOR:black;           /*箭头的颜色*/   
					SCROLLBAR-FACE-COLOR:#Ece9d8;             /*滚动条及箭头的颜色*/   
				}
		</style> 
        <style>
			TD.grdFILELocked { ; LEFT: expression(divFILE.scrollLeft); POSITION: relative }
			TH.grdFILELocked { ; LEFT: expression(divFILE.scrollLeft); POSITION: relative }
			TH.grdFILELocked { Z-INDEX: 99 }
			TD.grdTASKLocked { ; LEFT: expression(divTASK.scrollLeft); POSITION: relative }
			TH.grdTASKLocked { ; LEFT: expression(divTASK.scrollLeft); POSITION: relative }
			TH.grdTASKLocked { Z-INDEX: 99 }
			TH { Z-INDEX: 10; POSITION: relative }
        </style>
        <style type="text/css">
			.FixedHead
			{
			position:relative;
			top:expression(this.offsetParent.scrollTop);
			}
			.FixedDiv
			{
			height:100px;
			overflow-y:scroll;
			}
		</style>
        <script src="../../scripts/transkey.js"></script>
        <script language="javascript">
			function doMenuItemClick(menuItemId) {
				try {
					doToFullScreen();
					document.all("htxtSelectMenuID").value = menuItemId;
					window.setTimeout("__doPostBack('lnkMenu', '');", 500);
					//zengxianglin 2008-08-03
					document.activeElement.disabled = true;
					//zengxianglin 2008-08-03
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
			function doToFullScreen()
			{
				try
				{
					var objTopFrame = getFrame(window.parent.frames, "topFrame");
					if (objTopFrame)
						objTopFrame.window.doToFullScreen("../");
				} catch (e) {}
			}			
			function openWindow(url) 
            {
				var objTopFrame = null;
				objTopFrame = getFrame(window.parent.frames, "topFrame");
				if (objTopFrame)
					objTopFrame.window.doFullScreen();
				try 
				{
					url = encodeURI(url);
					window.open(url,"mainFrame");
				} catch (e) {}
            }
            function closeWindow() 
            {
				try 
				{
					if (window.parent)
						window.parent.close();
				} catch (e) {}
            } 
			function document_onreadystatechange() 
			{
				doToFullScreen();
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
                                                    <componentart:MenuItem ID="mnuNew_FW" Text="新的入职文件" ClientSideCommand="doMenuItemClick('mnuNew_RZ');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuNew_TZ" Text="新的内部调整文件" ClientSideCommand="doMenuItemClick('mnuNew_TZ');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuNew_LZ" Text="新的离职文件" ClientSideCommand="doMenuItemClick('mnuNew_LZ');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuNew_SXS" Text="新的实习生入职文件" ClientSideCommand="doMenuItemClick('mnuNew_SXS');" Target="mainFrame"></componentart:MenuItem>
                                                </componentart:MenuItem>
                                                <COMPONENTART:MENUITEM id="mnuZF" DisabledLookId="MenuItemDisabledLook" Target="mainFrame" Text="批量转发文件" ClientSideCommand="doMenuItemClick('mnuZF','');"></COMPONENTART:MENUITEM>
                                                <componentart:MenuItem ID="mnuPrint" Text="打印文件" Target="mainFrame">
                                                    <componentart:MenuItem ID="mnuPrint_RUZHI" Text="打印入职文件" ClientSideCommand="doMenuItemClick('mnuPrint_RUZHI');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuPrint_NBTZ" Text="打印内部调整文件" ClientSideCommand="doMenuItemClick('mnuPrint_NBTZ');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuPrint_SXS" Text="打印实习生入职文件" ClientSideCommand="doMenuItemClick('mnuPrint_SXS');" Target="mainFrame"></componentart:MenuItem>
                                                </componentart:MenuItem>
                                                <componentart:MenuItem ID="mnuList" Text="人员一览表" Target="mainFrame">
                                                    <componentart:MenuItem ID="mnuList_RUZHI" Text="入职人员一览表" ClientSideCommand="doMenuItemClick('mnuList_RUZHI');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuList_NBTZ" Text="内部调整人员一览表" ClientSideCommand="doMenuItemClick('mnuList_NBTZ');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuList_SXS" Text="实习生入职人员一览表" ClientSideCommand="doMenuItemClick('mnuList_SXS');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuList_LIZHI" Text="离职人员一览表" ClientSideCommand="doMenuItemClick('mnuList_LIZHI');" Target="mainFrame"></componentart:MenuItem>
                                                </componentart:MenuItem>
                                                <componentart:MenuItem ID="mnuOpen" Text="打开文件" ClientSideCommand="doMenuItemClick('mnuOpen');" Target="mainFrame"></componentart:MenuItem>
                                                <componentart:MenuItem ID="mnuDelete" Text="删除文件" ClientSideCommand="doMenuItemClick('mnuDelete');" Target="mainFrame"></componentart:MenuItem>                                                
                                                <componentart:MenuItem ID="mnuRefresh" Text="刷新显示" ClientSideCommand="doMenuItemClick('mnuRefresh');" Target="mainFrame"></componentart:MenuItem>
                                                <componentart:MenuItem ID="mnuClose" Text="返回主页" ClientSideCommand="doMenuItemClick('mnuClose');" Target="mainFrame"></componentart:MenuItem>
                                            </Items>
                                            <ItemLooks>
                                                <COMPONENTART:ItemLook LookID="TopItemLook" CssClass="TopMenuItem" HoverCssClass="TopMenuItemHover" LabelPaddingLeft="15" LabelPaddingRight="15" LabelPaddingTop="4" LabelPaddingBottom="4" />
                                                <COMPONENTART:ItemLook LookID="DefaultItemLook" CssClass="MenuItem" HoverCssClass="MenuItemHover" ExpandedCssClass="MenuItemHover" LabelPaddingLeft="18" LabelPaddingRight="12" LabelPaddingTop="4" LabelPaddingBottom="4" />
                                                <COMPONENTART:ItemLook LookID="MenuItemDisabledLook" CssClass="MenuItemDisabled" HoverCssClass="" ExpandedCssClass="" LabelPaddingLeft="18" LabelPaddingRight="12" LabelPaddingTop="4" LabelPaddingBottom="4" />
                                                <COMPONENTART:ItemLook LookID="BreakItem" CssClass="MenuBreak" ImageHeight="2" ImageWidth="100%" ImageUrl="../images/menu01/break.gif" />
                                            </ItemLooks>
                                        </ComponentArt:Menu></TD>
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
                                        <div style="labletree"><IEWC:TREEVIEW id="tvwTASK" runat="server" DefaultStyle="Font-Size=20px;" Width="144px"  Font-Size="12px" Font-Name="宋体" AutoPostBack="true" Height="498px"></IEWC:TREEVIEW></div>
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
                                                            <TD vAlign="middle" style="FONT-SIZE: 12px; COLOR: blue">类型&nbsp;</TD>
                                                            <TD  align="left"  style="FONT-SIZE: 12px; COLOR: blue"><asp:DropDownList id="ddlGWJKSearch_WJLX" Runat="server" CssClass="textbox" Width="100px" AutoPostBack="True"></asp:DropDownList></TD>
                                                            <TD  vAlign="middle"  style="FONT-SIZE: 12px; COLOR: blue">&nbsp;&nbsp;标题&nbsp;</TD>
                                                            <TD  align="left"  style="FONT-SIZE: 12px; COLOR: blue"><asp:textbox id="txtFILESearch_WJBT" runat="server" CssClass="textbox"  Columns="20"></asp:textbox></TD>
                                                            <TD  vAlign="middle"  style="FONT-SIZE: 12px; COLOR: blue">&nbsp;&nbsp;<asp:Label id="lblFILESearch_WJRQ" Runat="server" >发送日期</asp:Label>&nbsp;</TD>
                                                            <TD  align="left"  style="FONT-SIZE: 12px; COLOR: blue"><asp:textbox id="txtFILESearch_WJRQMin" runat="server" CssClass="textbox"  Columns="8"></asp:textbox>~<asp:textbox id="txtFILESearch_WJRQMax" runat="server" CssClass="textbox"  Columns="10"></asp:textbox></TD>
                                                            <TD  vAlign="middle"  style="FONT-SIZE: 12px; COLOR: blue">&nbsp;&nbsp;备注&nbsp;</TD>
                                                            <TD  align="left"  style="FONT-SIZE: 12px; COLOR: blue"><asp:textbox id="txtFILESearch_WJZH" runat="server" CssClass="textbox"  Columns="12"></asp:textbox></TD>
                                                            <TD >&nbsp;&nbsp;<asp:button id="btnFILESearch" Runat="server" CssClass="button" Font-Size="12px" Font-Name="宋体" Text="搜索"></asp:button><asp:button id="btnFileSearchFull" Runat="server" CssClass="button" Font-Size="12px" Font-Name="宋体" Text="全文检索" Visible="False"></asp:button></TD>
                                                        </TR>
                                                    </TABLE>
                                                </TD>
                                            </TR>
                                            <TR>
                                                <TD>
                                                    <DIV id="divFILE" class="FixedDiv" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 660px; CLIP: rect(0px 660px 318px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 318px">
                                                        <asp:datagrid id="grdFILE" runat="server" Width="1540px" CssClass="labelGrid" 
                                                            AllowPaging="True" AutoGenerateColumns="False" GridLines="Both" BackColor="White"
                                                            PageSize="30" BorderColor="#dfdfdf" BorderWidth="1px" AllowSorting="True" CellPadding="4"  UseAccessibleHeader="True" BorderStyle="Solid">
                                                            <SelectedItemStyle  Font-Bold="False" VerticalAlign="top" ForeColor="blue" ></SelectedItemStyle>
                                                            <EditItemStyle   BackColor="#FFCC00" VerticalAlign="top"></EditItemStyle>
                                                            <AlternatingItemStyle  BorderWidth="1px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="top" BackColor="White"></AlternatingItemStyle>
                                                            <ItemStyle  BorderWidth="1px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="top" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
                                                            <HeaderStyle CssClass="FixedHead"  Font-Bold="True" ForeColor="White" VerticalAlign="top" BackColor="#6699cc" HorizontalAlign="Left"></HeaderStyle>
                                                            <FooterStyle BackColor="#CCCC99"></FooterStyle>
                                                            <Columns>
                                                                <asp:TemplateColumn  HeaderText="选">
                                                                    <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
                                                                    <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox id="chkFILE" runat="server" AutoPostBack="False"></asp:CheckBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                                <asp:ButtonColumn DataTextField="文件类型" SortExpression="文件类型" HeaderText="类型" CommandName="Select">
                                                                    <HeaderStyle Width="110px"></HeaderStyle>
                                                                </asp:ButtonColumn> 
                                                                <asp:ButtonColumn Visible="false" DataTextField="主送单位" SortExpression="主送单位" HeaderText="主送/来文单位" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>                                                               
                                                                <asp:ButtonColumn DataTextField="文件标题" SortExpression="文件标题" HeaderText="标题" CommandName="OpenDocument">
                                                                    <HeaderStyle Width="320px"></HeaderStyle>
                                                                </asp:ButtonColumn>                                                                
                                                                <asp:ButtonColumn  DataTextField="主办单位" SortExpression="主办单位" HeaderText="主办单位" CommandName="Select">
                                                                    <HeaderStyle Width="120px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn DataTextField="发送日期" SortExpression="发送日期" HeaderText="发送日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd HH:mm:ss}">
                                                                    <HeaderStyle Width="240px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn Visible="False"   DataTextField="紧急程度" SortExpression="紧急程度" HeaderText="紧急" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn Visible="False"  DataTextField="秘密等级" SortExpression="秘密等级" HeaderText="密级" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn DataTextField="办理状态" SortExpression="办理状态" HeaderText="状态" CommandName="Select">
                                                                    <HeaderStyle Width="100px"></HeaderStyle>
                                                                </asp:ButtonColumn>                                                                
                                                                <asp:ButtonColumn Visible="False" DataTextField="文件字号" SortExpression="文件字号" HeaderText="文号" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>                                                                
                                                                <asp:ButtonColumn DataTextField="办理期限" SortExpression="办理期限" HeaderText="办理期限" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd HH:mm:ss}">
                                                                    <HeaderStyle Width="240px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn DataTextField="完成日期" SortExpression="完成日期" HeaderText="完成日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd HH:mm:ss}">
                                                                    <HeaderStyle Width="240px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn Visible="False" DataTextField="备忘提醒" SortExpression="备忘提醒" HeaderText="备忘" CommandName="Select" ItemStyle-HorizontalAlign="Center">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
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
                                                            <PagerStyle Visible="False" NextPageText="下页"  PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
                                                        </asp:datagrid><INPUT id="htxtFILEFixed" type="hidden" value="0" runat="server"></DIV>
                                                </TD>
                                            </TR>
                                            <TR>
                                                <TD class="label">
                                                    <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                        <TR>
                                                            <TD class="labelBlack" vAlign="middle" align="left"><asp:linkbutton id="lnkCZFILEDeSelectAll" runat="server" Font-Size="12px" Font-Name="宋体" Enabled =False>不选</asp:linkbutton></TD>
                                                            <TD class="labelBlack" vAlign="middle" align="left"><asp:linkbutton id="lnkCZFILESelectAll" runat="server" Font-Size="12px" Font-Name="宋体" Enabled=False >全选</asp:linkbutton></TD>
                                                            <TD class="labelBlack" vAlign="middle" align="left"><asp:linkbutton id="lnkCZFILEMoveFirst" runat="server" CssClass="labelBlack">最前</asp:linkbutton></TD>
                                                            <TD class="labelBlack" vAlign="middle" align="left"><asp:linkbutton id="lnkCZFILEMovePrev" runat="server" CssClass="labelBlack">前页</asp:linkbutton></TD>
                                                            <TD class="labelBlack" vAlign="middle" align="left"><asp:linkbutton id="lnkCZFILEMoveNext" runat="server" CssClass="labelBlack">下页</asp:linkbutton></TD>
                                                            <TD class="labelBlack" vAlign="middle" align="left"><asp:linkbutton id="lnkCZFILEMoveLast" runat="server" CssClass="labelBlack">最后</asp:linkbutton></TD>
                                                            <TD class="labelBlack" vAlign="middle" noWrap align="left"><asp:linkbutton id="lnkCZFILEGotoPage" runat="server"  CssClass="labelBlack">前往</asp:linkbutton><asp:textbox id="txtFILEPageIndex" runat="server" CssClass="textbox" Font-Size="12px" Font-Name="宋体" Columns="3">1</asp:textbox>页</TD>
                                                            <TD class="labelBlack" vAlign="middle" noWrap align="left"><asp:linkbutton id="lnkCZFILESetPageSize" runat="server" CssClass="labelBlack">每页</asp:linkbutton><asp:textbox id="txtFILEPageSize" runat="server" CssClass="textbox" Font-Size="12px" Font-Name="宋体" Columns="3">30</asp:textbox>条</TD>
                                                            <TD class="labelBlack" vAlign="middle" align="right" width="200"><asp:label id="lblFILEGridLocInfo" runat="server" CssClass="labelBlack">1/10 N/15</asp:label></TD>
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
                                                        <asp:datagrid id="grdTASK" runat="server" CssClass="label"  AllowPaging="False"
                                                            AutoGenerateColumns="False" GridLines="Vertical" BackColor="White" BorderStyle="None" PageSize="30"
                                                            BorderColor="#DEDFDE" BorderWidth="0px" AllowSorting="True" CellPadding="4" UseAccessibleHeader="True">
                                                           <SelectedItemStyle  Font-Bold="False" VerticalAlign="top" ForeColor="blue" ></SelectedItemStyle>
                                                            <EditItemStyle   BackColor="#FFCC00" VerticalAlign="top"></EditItemStyle>
                                                            <AlternatingItemStyle  BorderWidth="1px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="top" BackColor="White"></AlternatingItemStyle>
                                                            <ItemStyle  BorderWidth="1px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="top" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
                                                            <HeaderStyle  Font-Bold="True" ForeColor="White" VerticalAlign="top" BackColor="#6699cc" HorizontalAlign="Left"></HeaderStyle>
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
                                                            <PagerStyle Visible="False" NextPageText="下页"  PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
                                                        </asp:datagrid><INPUT id="htxtTASKFixed" type="hidden" value="0" runat="server"></DIV>
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
                        <input id="htxtPageCloseWindow" type="hidden" runat="server">
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

