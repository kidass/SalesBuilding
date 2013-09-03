<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="kqgl_qjd_info.aspx.vb" Inherits="Josco.JSOA.web.kqgl_qjd_info" %>
<%@ Register TagPrefix="ComponentArt" Namespace="ComponentArt.Web.UI" Assembly="ComponentArt.Web.UI" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>

<!DOCTYPE HTML PUBLIC "-//W3C//Dtd HTML 4.0 transitional//EN">
<html>
    <head>
        <title>人事请假审批单的显示或编辑窗</title>
        <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR" />
        <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE" />
        <meta content="JavaScript" name="vs_defaultClientScript" />
        <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />       
        <link href="../../mnuStyle01.css" type="text/css" rel="stylesheet" />
        <LINK href="../../stylegw.css" type="text/css" rel="stylesheet">
        <link href="../../mnuStyle01.css" type="text/css" rel="stylesheet" />
		<link rel="stylesheet" type="text/css" href="../../css/jscal2.css" />
        <link rel="stylesheet" type="text/css" href="../../css/border-radius.css" />
        <link rel="stylesheet" type="text/css" href="../../css/steel/steel.css" />
        <style>
			td.grdFJLocked { ; LEFT: expression(divFJ.scrollLeft); POSITION: relative }
			TH.grdFJLocked { ; LEFT: expression(divFJ.scrollLeft); POSITION: relative }
			TH.grdFJLocked { Z-INDEX: 99 }
			td.grdXGWJLocked { ; LEFT: expression(divXGWJ.scrollLeft); POSITION: relative }
			TH.grdXGWJLocked { ; LEFT: expression(divXGWJ.scrollLeft); POSITION: relative }
			TH.grdXGWJLocked { Z-INDEX: 99 }
			td.grdRYXXLocked { ; LEFT: expression(divRYXX.scrollLeft); POSITION: relative }
			TH.grdRYXXLocked { ; LEFT: expression(divRYXX.scrollLeft); POSITION: relative }
			TH.grdRYXXLocked { Z-INDEX: 99 }
			TH { Z-INDEX: 10; POSITION: relative }
        </style>
         <script src="../../scripts/js/jscal2.js"></script>
        <script src="../../scripts/js/lang/en.js"></script>
        <script src="../../scripts/transkey.js"></script>
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
				intWidth  -= 216;                          //滚动条
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
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr id="trRow1">
                        <td><asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton><asp:LinkButton id="lnkMenu" Runat="server" Width="0px"></asp:LinkButton><INPUT id="htxtSelectMenuID" type="hidden" size="1" runat="server"><asp:LinkButton id="lnkRq" Runat="server" CssClass="button"></asp:LinkButton></td>
                        <td align="center">
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td>
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
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td vAlign="top" align="center">
                            <table cellspacing="0" cellpadding="0" border="0">
                                <tr>
                                    <td height="3"></td>
                                </tr>
                                <tr>
                                    <td>
                                        <DIV id="divContent" style="OVERFLOW: auto; WIDTH: 820px; CLIP: rect(0px 820px 476px 0px); HEIGHT: 476px">
                                            <table cellspacing="0" cellpadding="0" align="center" border="0">
                                                <tr>
                                                    <td vAlign="middle" align="center" height="32">
                                                        <SPAN style="FONT-WEIGHT: bold; FONT-SIZE: 28px; COLOR: red; FONT-FAMILY: 宋体"><%=Josco.JsKernal.Common.jsoaConfiguration.LicencingTo%>员工休（请）假申请表</SPAN></td>
                                                </tr>
                                                <tr>                                                  
                                                    <td>
                                                        <DIV style="DISPLAY: none">
                                                        <table cellspacing="0" cellpadding="0"  border="0">
                                                            <tr>
                                                                <td width="30">&nbsp;</td>
                                                                <td class="labelAuto">编号<asp:TextBox id="txtJGDZ" Runat="server" CssClass="textbox" Columns="10"></asp:TextBox>[<asp:TextBox id="txtWJNF" Runat="server" CssClass="textbox" Columns="4"></asp:TextBox>]第[<asp:TextBox id="txtWJXH" Runat="server" CssClass="textbox" Columns="4"></asp:TextBox>]号</td>
                                                                <td class="label">缓急<asp:DropDownList id="ddlJJCD" Runat="server" CssClass="textbox"></asp:DropDownList></td>
                                                                <td class="label">密级<asp:DropDownList id="ddlMMDJ" Runat="server" CssClass="textbox"></asp:DropDownList></td>
                                                                <td align="right"><asp:CheckBox id="chkDDSZ" Runat="server" CssClass="textbox" Text="不受流转限制" Font-Name="宋体" Font-Size="12px"></asp:CheckBox></td>
                                                                <td width="30">&nbsp;</td>
                                                                <td class="labelAuto" align="right">流水号<asp:TextBox id="txtLSH" Runat="server" CssClass="textbox" Columns="14" Font-Name="宋体" Font-Size="12px"></asp:TextBox><INPUT id="htxtWJBS" type="hidden" size="1" runat="server"></td>
                                                              </tr>
                                                             <tr>
                                                                <td class="label" align="right">标题：</td>
                                                                <td align="left" colspan="5"><asp:TextBox id="txtWJBT" Runat="server" CssClass="textbox" >入职申请单</asp:TextBox></td>
                                                            </tr>
                                                        </table>
                                                        </DIV>                                                 
                                                    </td>
                                                 </tr>
                                                 <tr>
                                                    <td align="center">
                                                        <table cellspacing="0" cellpadding="0" border="0" bordercolordark="#99cccc" bordercolorlight="#ffffff">
                                                             <tr>
                                                                <td align="left">                                                                   
                                                                      <table cellpadding="0" cellspacing="0" border="1"   width="100%" bordercolordark="#99cccc" bordercolorlight="#ffffff">
                                                                        <tr>                                                                            
                                                                            <td class="labelNotNull" align="right" style="height:30px" valign="bottom" >申请人：</td>
                                                                            <td align="left" valign="bottom">&nbsp;&nbsp;<asp:TextBox ID="txtRYXM" Runat="server" CssClass="textbox" Columns="15"></asp:TextBox><input id="htxtRYDM" type="hidden" size="1" runat="server" name="htxtRYDM" />
                                                                                <asp:Button id="btnSelect_ZZDM" Runat="server" CssClass="button" Text="…"></asp:Button></td>
                                                                            <td class="labelNotNull" align="right" valign="bottom">所属部门：</td>
                                                                            <td align="left" valign="bottom">&nbsp;&nbsp;<asp:TextBox ID="txtSSDW" Runat="server" CssClass="textbox" Columns="15" ReadOnly="true"></asp:TextBox><input id="htxtSSDW" type="hidden" size="1" runat="server" name="htxtSSDW" />
                                                                                <asp:Button id="btnFPBM" Runat="server" CssClass="button" Text="…"></asp:Button></td>
                                                                            <td class="labelNotNull" align="right" valign="bottom">职务/岗位：</td>
                                                                            <td align="left" valign="bottom">&nbsp;&nbsp;<asp:TextBox ID="txtZW" Runat="server" CssClass="textbox" Columns="15"></asp:TextBox></td>
                                                                        </tr>                                                           
                                                                        <tr>
                                                                            <td class="labelNotNull" align="right" style="height:30px">事由：</td>
                                                                            <td align="center" colspan="5" >&nbsp;&nbsp;<asp:TextBox ID="txtYY" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="labelNotNull" align="right" style="height:30px">外出或休假地点：</td>
                                                                            <td align="left" >&nbsp;&nbsp;<asp:TextBox ID="txtDD" Runat="server" CssClass="textbox" Columns="15"></asp:TextBox></td>
                                                                            <td class="labelNotNull" align="right">联系电话：</td>
                                                                            <td align="left" colspan="3">&nbsp;&nbsp;<asp:TextBox ID="txtLXDH" runat="server" CssClass="textbox" Columns="30"></asp:TextBox></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="labelNotNull" align="right" style="height:30px">申请休(请)假时间：<br/>(含各休假在内的连休)</td>
										                                    <td class="labelNotNull" align="left" colspan="3">&nbsp;&nbsp;<asp:TextBox id="txtStartSQRQ" Runat="server" CssClass="textbox" Columns="12" ></asp:TextBox>至&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox id="txtEndSQRQ" Runat="server" CssClass="textbox" Columns="15" ></asp:TextBox></td>
									                                         <script type="text/javascript" >
									                                            var cal=Calendar.setup({
									                                                onSelect:function(cal){cal.hide()},
									                                                showtime:true 
									                                            });
									                                            cal.manageFields("txtStartSQRQ","txtStartSQRQ","%Y-%m-%d");
									                                            cal.manageFields("txtEndSQRQ","txtEndSQRQ","%Y-%m-%d");
									                                            cal.addEventListener("onSelect", function(){__doPostBack("lnkRq","");});									                                            
									                                         </script>
									                                         <td class="labelNotNull" align="right">合计天数：</td>
                                                                            <td align="left">&nbsp;&nbsp;<asp:TextBox ID="txtTS" Runat="server" CssClass="textbox" Columns="15" ReadOnly="true"></asp:TextBox></td>                                                                           
									                                    </tr> 
                                                                        
                                                                        <tr>                           
										                                    <td class="labelNotNull" align="right" style="height:30px">外出/休(请)假期间&nbsp;&nbsp;<br />何人主持工作：</td>
                                                                            <td align="left" colspan="5">&nbsp;&nbsp;<asp:TextBox ID="txtWTGZ" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox></td> 
                                                                       </tr>  
                                                                       
                                                                        <tr>
                                                                            <td class="labelAuto" align="right" style="height:30px">经办单位：</td>
                                                                            <td align="left">&nbsp;&nbsp;<asp:TextBox id="txtJBDW" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox></td>
                                                                            <td class="labelAuto" align="right">经办人员：</td>
                                                                            <td align="left">&nbsp;&nbsp;<asp:TextBox id="txtJBRY" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox></td>
                                                                            <td class="labelAuto" align="right">经办日期：</td>
                                                                            <td align="left">&nbsp;&nbsp;<asp:TextBox id="txtJBRQ" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox></td>
                                                                        </tr>
                                                                       
                                                                        <tr>
                                                                            <td class="labelNotNull" align="right" style="height:30px">备注：</td>
                                                                            <td align="left" colspan="5">&nbsp;&nbsp;<asp:TextBox id="txtBZXX" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="labelNotNull" align="right">休假假别及天数：</td> 
                                                                            <td colspan="5">
                                                                                <table cellpadding="0" cellspacing="0" border="0"   width="100%" bordercolordark="#99cccc" bordercolorlight="#ffffff">                                                                                    
                                                                                    <tr>
                                                                                        <td colspan="3">
                                                                                            <div id="divRYXX" style="table-LAYOUT: fixed; OVERFLOW: auto; WIDTH: 300px; CLIP: rect(0px 300px 100px 0px); HEIGHT: 100px">
                                                                                                <asp:datagrid id="grdRYXX" runat="server" Width="220px" CssClass="labelGrid" 
                                                                                                    AllowPaging="false" AutoGenerateColumns="False" GridLines="Both" BackColor="White"
                                                                                                    PageSize="250" BorderColor="#dfdfdf" BorderWidth="1px" AllowSorting="true" cellpadding="4"  UseAccessibleHeader="true" BorderStyle="None">
												                                                     <SelectedItemStyle  Font-Bold="False" VerticalAlign="Middle" HorizontalAlign="Center" ForeColor="blue" ></SelectedItemStyle>
                                                                                                    <EditItemStyle   BackColor="#FFCC00" VerticalAlign="Middle" HorizontalAlign="Center" ></EditItemStyle>
                                                                                                    <AlternatingItemStyle  BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
                                                                                                    <ItemStyle  BorderWidth="0px" HorizontalAlign="Center" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
                                                                                                    <HeaderStyle   Font-Bold="true" HorizontalAlign="Center"  ForeColor="White" VerticalAlign="Middle" BackColor="#6699cc" ></HeaderStyle>
                                                                                                    <FooterStyle BackColor="#CCCC99" HorizontalAlign="Center"></FooterStyle>                                                                                                    
                                                                                                    <Columns>	
                                                                                                          															                                                                                             
                                                                                                        <asp:ButtonColumn Visible="false" ItemStyle-Width="0px" DataTextField="记录代码" SortExpression="记录代码" HeaderText="记录代码" CommandName="Select">
                                                                                                            <HeaderStyle Width="0px"></HeaderStyle>
                                                                                                        </asp:ButtonColumn>
                                                                                                        <asp:ButtonColumn   ItemStyle-Width="20px" DataTextField="序号" SortExpression="序号" HeaderText="序号" CommandName="Select">
                                                                                                            <HeaderStyle Width="20px"></HeaderStyle>
                                                                                                        </asp:ButtonColumn> 
                                                                                                        <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="记录名称" SortExpression="记录名称" HeaderText="记录名称" CommandName="Select">
                                                                                                            <HeaderStyle Width="100px"></HeaderStyle>
                                                                                                        </asp:ButtonColumn> 
                                                                                                        <asp:ButtonColumn Visible="false" ItemStyle-Width="0px" DataTextField="天数" SortExpression="天数" HeaderText="天数" CommandName="Select">
                                                                                                            <HeaderStyle Width="0px"></HeaderStyle>
                                                                                                        </asp:ButtonColumn> 
                                                                                                        <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="显示天数" SortExpression="显示天数" HeaderText="显示天数" CommandName="Select">
                                                                                                            <HeaderStyle Width="100px"></HeaderStyle>
                                                                                                        </asp:ButtonColumn> 
                                                                                                         <asp:ButtonColumn Visible="false"  ItemStyle-Width="0px" DataTextField="唯一标识" SortExpression="唯一标识" HeaderText="唯一标识" CommandName="Select">
                                                                                                            <HeaderStyle Width="0px"></HeaderStyle>
                                                                                                        </asp:ButtonColumn> 
                                                                                                         <asp:ButtonColumn Visible="false"  ItemStyle-Width="0px" DataTextField="文件标识" SortExpression="文件标识" HeaderText="文件标识" CommandName="Select">
                                                                                                            <HeaderStyle Width="0px"></HeaderStyle>
                                                                                                        </asp:ButtonColumn>                                                                                                                                                                                                                                                                      
                                                                                                    </Columns>                                                                                                    
                                                                                                    <PagerStyle Visible="False" NextPageText="下页" Font-Size="12px" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
                                                                                                </asp:datagrid><INPUT id="htxtRYXXFixed" type="hidden" value="0" runat="server">
                                                                                            </div>
                                                                                        </td>  
                                                                                        <td colspan="2">
                                                                                            <% if propEditMode = False then response.write("<div style='display:none'>") %>
                                                                                            <table >
                                                                                                <tr>
                                                                                                    <td class="labelNotNull" align="right">假期类型：</td>
													                                                <td align="left" ><asp:DropDownList id="ddlJQ" Runat="server" CssClass="textbox" ></asp:DropDownList></td>
													                                                <td align="left"><asp:TextBox ID="txtJQTS" Runat="server" CssClass="textbox_bottom" Columns="4"></asp:TextBox></td>
                                                                                                </tr>
													                                            <tr>
												                                                    <td align="center" colspan="3"><asp:Button ID="btnJQ_AddNew" Runat="server" CssClass="button" Text="增加"></asp:Button>
                                                                                                        <asp:Button ID="btnJQ_Delete" Runat="server" CssClass="button" Text="删除"></asp:Button></td>
                                                                                               </tr>
                                                                                            </table>
                                                                                             <% if propEditMode = False then response.write("</div>") %>
                                                                                        </td>                                                                          
                                                                                    </tr>
                                                                                </table>
                                                                            </td> 
                                                                        </tr>
                                                                    </table>                                                                  
                                                                </td>
                                                            </tr>  
                                                            <tr>
                                                                <td>
                                                                    <table cellpadding="0" cellspacing="0" border="1">
                                                                        <tr>                                                                            
													                        <td  valign="top">
														                        <table cellspacing="0" cellpadding="0" border="0">
															                        <tr>
																                        <td  height="3" colspan="2" ></td>
															                        </tr>
															                        <tr>
																                        <td  height="20" align="center" style="BORDER-RIGHT: #99CCCC thin solid;WIDTH: 155px;"><asp:LinkButton id="lnkCZQSYJ_FH" Runat="server" CssClass="button">售楼部/分行经理意见</asp:LinkButton>
                                                                                            <asp:LinkButton id="lnkCZQSYJ_FHBJ" Runat="server" CssClass="button">(有便笺)</asp:LinkButton></td>
															                            <td ><div id="divFHYJ" style="table-LAYOUT: fixed; OVERFLOW: auto; WIDTH: 600px; CLIP: rect(0px 600px 60px 0px); HEIGHT: 60px">&nbsp;&nbsp;<asp:label id="lblFHYJ" Runat="server" CssClass="label">lblFHYJ</asp:label></DIV></td>
															                        </tr>	
														                        </table>
													                        </td>
													                     </tr>
													                     <tr>
													                        <td valign="top">
														                        <table cellspacing="0" cellpadding="0" border="0">
															                        <tr>
																                        <td  height="3" colspan="2"></td>
															                        </tr>
															                        <tr>
																                        <td height="20" align="center" style="BORDER-RIGHT: #99CCCC thin solid;WIDTH: 155px;"><asp:LinkButton id="lnkCZQSYJ_QF" Runat="server" CssClass="button">项目经理/区域经理/总监意见</asp:LinkButton>
                                                                                            <asp:LinkButton id="lnkCZQSYJ_QFBJ" Runat="server" CssClass="button">(有便笺)</asp:LinkButton></td>
															                            <td><div id="divQFYJ" style="table-LAYOUT: fixed; OVERFLOW: auto; WIDTH: 600px; CLIP: rect(0px 600px 60px 0px); HEIGHT: 60px">&nbsp;&nbsp;<asp:label id="lblQFYJ" Runat="server" CssClass="labelYj">lblQFYJ</asp:label></DIV></td>
															                        </tr>																		                       
														                        </table>
													                        </td>
													                     </tr>
													                     <tr>
													                        <td valign="top">
														                        <table cellspacing="0" cellpadding="0" border="0">
															                        <tr>
																                        <td  height="3" colspan="2"></td>
															                        </tr>
															                        <tr>
																                        <td  height="20" align="center" style="BORDER-RIGHT: #99CCCC thin solid;WIDTH: 155px;"><asp:LinkButton id="lnkCZQSYJ_SH" Runat="server" CssClass="button">部门经理意见</asp:LinkButton>
                                                                                            <asp:LinkButton id="lnkCZQSYJ_SHBJ" Runat="server" CssClass="button">(有便笺)</asp:LinkButton></td>
															                            <td valign="middle" ><div id="divSHYJ" style="table-LAYOUT: fixed; OVERFLOW: auto; WIDTH: 600px; CLIP: rect(0px 600px 60px 0px); HEIGHT: 60px">&nbsp;&nbsp;<asp:label id="lblSHYJ" Runat="server" CssClass="labelYj">lblSHYJ</asp:label></div></td>
															                        </tr>																		                       
														                        </table>
													                        </td>
													                     </tr>
													                     <tr>
													                        <td valign="top">
														                        <table cellspacing="0" cellpadding="0" border="0">
															                        <tr>
																                        <td  height="3" colspan="2"></td>
															                        </tr>
															                        <tr>
																                        <td height="20" align="center"  style="BORDER-RIGHT: #99CCCC thin solid;WIDTH: 155px;"><asp:LinkButton id="lnkCZQSYJ_HQ" Runat="server" CssClass="button">办公室意见</asp:LinkButton>
                                                                                            <asp:LinkButton id="lnkCZQSYJ_HQBJ" Runat="server" CssClass="button">(有便笺)</asp:LinkButton></td>
															                            <td valign="middle"><div id="divHQYJ" style="table-LAYOUT: fixed; OVERFLOW: auto; WIDTH: 600px; CLIP: rect(0px 600px 60px 0px); HEIGHT: 60px; ">&nbsp;&nbsp;<asp:label  id="lblHQYJ" Runat="server" CssClass="labelYj">lblHQYJ</asp:label></div></td>
															                        </tr>																		                       
														                        </table>
													                        </td>
													                    </tr>
													                    <tr>
													                        <td valign="top">
														                        <table cellspacing="0" cellpadding="0" border="0">
															                        <tr>
																                        <td  height="3" colspan="2"></td>
															                        </tr>
															                        <tr>
																                        <td height="20" align="center"  style="BORDER-RIGHT: #99CCCC thin solid;WIDTH: 155px;"><asp:LinkButton id="lnkCZQSYJ_FGLD" Runat="server" CssClass="button">分管领导意见</asp:LinkButton>
                                                                                            <asp:LinkButton id="lnkCZQSYJ_FGLDBJ" Runat="server" CssClass="button">(有便笺)</asp:LinkButton></td>
															                            <td><div id="divFGLDYJ" style="table-LAYOUT: fixed; OVERFLOW: auto; WIDTH: 600px; CLIP: rect(0px 600px 60px 0px); HEIGHT: 60px">&nbsp;&nbsp;<asp:label id="lblFGLDYJ" Runat="server" CssClass="labelYj">lblFGLDYJ</asp:label></div></td>
															                        </tr>																		                       
														                        </table>
													                        </td>
													                    </tr>
													                    <tr>
													                        <td valign="top">
														                        <table cellspacing="0" cellpadding="0" border="0">
															                        <tr>
																                        <td  height="3" colspan="2"></td>
															                        </tr>
															                        <tr>
																                        <td height="20" align="center"  style="BORDER-RIGHT: #99CCCC thin solid;WIDTH: 155px;"><asp:LinkButton id="lnkCZQSYJ_ZJL" Runat="server" CssClass="button">总经理审批</asp:LinkButton>
                                                                                            <asp:LinkButton id="lnkCZQSYJ_ZJLBJ" Runat="server" CssClass="button">(有便笺)</asp:LinkButton></td>
															                            <td><div id="divZJLYJ" style="table-LAYOUT: fixed; OVERFLOW: auto; WIDTH: 600px; CLIP: rect(0px 600px 60px 0px); HEIGHT: 60px">&nbsp;&nbsp;<asp:label id="lblZJLYJ" Runat="server" CssClass="labelYj">lblZJLYJ</asp:label></div></td>
															                        </tr>																		                       
														                        </table>
													                        </td>
													                    </tr>
													                </table>
													            </td>
                                                            </tr> 
                                                        </table>
                                                    </td>
                                                </tr>                                                
                                                <tr>
                                                    <td align="center">
                                                        <DIV style="DISPLAY: none">
                                                            <table cellspacing="0" cellpadding="0" border="0">
                                                                <tr>
                                                                    <td colSpan="4" height="3"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="title" vAlign="middle" align="center" width="30">文<BR>件<BR>附<BR>件</td>
                                                                    <td>
                                                                        <DIV id="divFJ" style="table-LAYOUT: fixed; OVERFLOW: auto; WIDTH: 370px; CLIP: rect(0px 370px 120px 0px); HEIGHT: 120px">
                                                                            <asp:datagrid id="grdFJ" runat="server" CssClass="label" Font-Size="12px" UseAccessibleHeader="true"
                                                                                AutoGenerateColumns="False" GridLines="Vertical" BorderStyle="None" cellpadding="4" AllowPaging="false"
                                                                                PageSize="30" AllowSorting="False" BorderWidth="0px" BorderColor="#DEDFDE" Font-Names="宋体">
                                                                                <FooterStyle BackColor="#CCCC99"></FooterStyle>
                                                                                <SelectedItemStyle Font-Size="12px" Font-Names="宋体" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
                                                                                <EditItemStyle Font-Size="12px" Font-Names="宋体" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
                                                                                <AlternatingItemStyle Font-Size="12px" Font-Names="宋体" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
                                                                                <ItemStyle Font-Size="12px" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
                                                                                <HeaderStyle Font-Size="12px" Font-Names="宋体" Font-Bold="true" ForeColor="White" VerticalAlign="Middle" BackColor="#6699cc" HorizontalAlign="Left"></HeaderStyle>
                                                                                
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
                                                                    </td>
                                                                    <td class="title" vAlign="middle" align="center" width="30">链<BR>接<BR>文<BR>件</td>
                                                                    <td>
                                                                        <DIV id="divXGWJ" style="table-LAYOUT: fixed; OVERFLOW: auto; WIDTH: 370px; CLIP: rect(0px 370px 120px 0px); HEIGHT: 120px">
                                                                            <asp:datagrid id="grdXGWJ" runat="server" CssClass="label" Font-Size="12px" UseAccessibleHeader="true"
                                                                                AutoGenerateColumns="False" GridLines="Vertical" BorderStyle="None" cellpadding="4" AllowPaging="false"
                                                                                PageSize="30" AllowSorting="False" BorderWidth="0px" BorderColor="#DEDFDE" Font-Names="宋体">
                                                                                <FooterStyle BackColor="#CCCC99"></FooterStyle>
                                                                                <SelectedItemStyle Font-Size="12px" Font-Names="宋体" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
                                                                                <EditItemStyle Font-Size="12px" Font-Names="宋体" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
                                                                                <AlternatingItemStyle Font-Size="12px" Font-Names="宋体" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
                                                                                <ItemStyle Font-Size="12px" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
                                                                                <HeaderStyle Font-Size="12px" Font-Names="宋体" Font-Bold="true" ForeColor="White" VerticalAlign="Middle" BackColor="#6699cc" HorizontalAlign="Left"></HeaderStyle>
                                                                                
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
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </DIV>
                                                    </td>
                                                </tr>
                                            </table>
                                        </DIV>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="3"></td>
                                </tr>
                            </table>
                        </td>
                        <td></td>
                    </tr>
                    
                </table>
            </asp:panel>
            <asp:Panel id="panelError" Runat="server">
                <table id="tabErrMain" height="98%" cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td width="5%"></td>
                        <td>
                            <table id="tabErrInfo" height="100%" cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                    <td id="tdErrInfo" style="FONT-SIZE: 32pt; COLOR: black; LINE-HEIGHT: 40pt; FONT-FAMILY: 宋体; LETTER-SPACING: 2pt" align="center"><asp:Label id="lblMessage" Runat="server"></asp:Label><P>&nbsp;&nbsp;</P><P><asp:Button ID="btnGoBack" Runat="server" Font-Size="24pt" Text=" 返回 "></asp:Button></P></td>
                                    <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                </tr>
                            </table>
                        </td>
                        <td width="5%"></td>
                    </tr>
                </table>
            </asp:Panel>
            <table cellspacing="0" cellpadding="0" align="center" border="0">
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
                        <input id="htxtdivLeftrYXX" type="hidden" runat="server">
                        <input id="htxtdivTopRYXX" type="hidden" runat="server">
                        <input id="htxtdivLeftXGWJ" type="hidden" runat="server">
                        <input id="htxtdivTopXGWJ" type="hidden" runat="server">
                        <input id="htxtdivLeftFJ" type="hidden" runat="server">
                        <input id="htxtdivTopFJ" type="hidden" runat="server">
                        <input id="htxtdivLeftSHYJ" type="hidden" runat="server">
                        <input id="htxtdivTopSHYJ" type="hidden" runat="server">
                        <input id="htxtdivLeftHQYJ" type="hidden" runat="server">
                        <input id="htxtdivTopHQYJ" type="hidden" runat="server">
                        <input id="htxtdivLeftFHYJ" type="hidden" runat="server">
                        <input id="htxtdivTopFHYJ" type="hidden" runat="server">
                        <input id="htxtdivLeftQFYJ" type="hidden" runat="server">
                        <input id="htxtdivTopQFYJ" type="hidden" runat="server">
                        <input id="htxtdivLeftContent" type="hidden" runat="server">
                        <input id="htxtdivTopContent" type="hidden" runat="server">
                        <input id="htxtdivLeftBody" type="hidden" runat="server">
                        <input id="htxtdivTopBody" type="hidden" runat="server">
                        <input id="htxtBDYY_RYZJ" type="hidden" runat="server" name="htxtBDYY_RYZJ" value="001">
						<input id="htxtBDYY_NBTZ" type="hidden" runat="server" name="htxtBDYY_NBTZ" value="003">
						<input id="htxtBZXL" type="hidden" runat="server" name="htxtBZXL" value="2">
						 <input id="htxtRYXM" type="hidden" runat="server">
						
                    </td>
                </tr>
                <tr>
                    <td>
                        <script language="javascript">
							function ScrollProc_Body() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtdivTopBody");
								if (oText != null) oText.value = document.body.scrollTop;
								oText=null;
								oText=document.getElementById("htxtdivLeftBody");
								if (oText != null) oText.value = document.body.scrollLeft;
								return;
							}
							function ScrollProc_divContent() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtdivTopContent");
								if (oText != null) oText.value = divContent.scrollTop;
								oText=null;
								oText=document.getElementById("htxtdivLeftContent");
								if (oText != null) oText.value = divContent.scrollLeft;
								return;
							}
							function ScrollProc_divQFYJ() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtdivTopQFYJ");
								if (oText != null) oText.value = divQFYJ.scrollTop;
								oText=null;
								oText=document.getElementById("htxtdivLeftQFYJ");
								if (oText != null) oText.value = divQFYJ.scrollLeft;
								return;
							}
							function ScrollProc_divFHYJ() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtdivTopFHYJ");
								if (oText != null) oText.value = divFHYJ.scrollTop;
								oText=null;
								oText=document.getElementById("htxtdivLeftFHYJ");
								if (oText != null) oText.value = divFHYJ.scrollLeft;
								return;
							}
							function ScrollProc_divHQYJ() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtdivTopHQYJ");
								if (oText != null) oText.value = divHQYJ.scrollTop;
								oText=null;
								oText=document.getElementById("htxtdivLeftHQYJ");
								if (oText != null) oText.value = divHQYJ.scrollLeft;
								return;
							}
							function ScrollProc_divSHYJ() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtdivTopSHYJ");
								if (oText != null) oText.value = divSHYJ.scrollTop;
								oText=null;
								oText=document.getElementById("htxtdivLeftSHYJ");
								if (oText != null) oText.value = divSHYJ.scrollLeft;
								return;
							}
							function ScrollProc_divFJ() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtdivTopFJ");
								if (oText != null) oText.value = divFJ.scrollTop;
								oText=null;
								oText=document.getElementById("htxtdivLeftFJ");
								if (oText != null) oText.value = divFJ.scrollLeft;
								return;
							}
							function ScrollProc_divXGWJ() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtdivTopXGWJ");
								if (oText != null) oText.value = divXGWJ.scrollTop;
								oText=null;
								oText=document.getElementById("htxtdivLeftXGWJ");
								if (oText != null) oText.value = divXGWJ.scrollLeft;
								return;
							}
							function ScrollProc_divRYXX() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtdivTopRYXX");
								if (oText != null) oText.value = divRYXX.scrollTop;
								oText=null;
								oText=document.getElementById("htxtdivLeftrYXX");
								if (oText != null) oText.value = divRYXX.scrollLeft;
								return;
							}
							try {
								var Text;

								oText=null;
								oText=document.getElementById("htxtdivTopBody");
								if (oText != null) document.body.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtdivLeftBody");
								if (oText != null) document.body.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtdivTopContent");
								if (oText != null) divContent.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtdivLeftContent");
								if (oText != null) divContent.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtdivTopQFYJ");
								if (oText != null) divQFYJ.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtdivLeftQFYJ");
								if (oText != null) divQFYJ.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtdivTopFHYJ");
								if (oText != null) divFHYJ.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtdivLeftFHYJ");
								if (oText != null) divFHYJ.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtdivTopHQYJ");
								if (oText != null) divHQYJ.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtdivLeftHQYJ");
								if (oText != null) divHQYJ.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtdivTopSHYJ");
								if (oText != null) divSHYJ.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtdivLeftSHYJ");
								if (oText != null) divSHYJ.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtdivTopFJ");
								if (oText != null) divFJ.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtdivLeftFJ");
								if (oText != null) divFJ.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtdivTopXGWJ");
								if (oText != null) divXGWJ.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtdivLeftXGWJ");
								if (oText != null) divXGWJ.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtdivTopRYXX");
								if (oText != null) divRYXX.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtdivLeftrYXX");
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
