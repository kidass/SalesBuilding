<%@ Page Language="vb" AutoEventWireup="false" Codebehind="estate_rs_grll_info.aspx.vb" Inherits="Josco.JSOA.web.estate_rs_grll_info" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
    <HEAD>
        <title>求职履历查看与编辑窗</title>
        <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
        <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
        <meta content="JavaScript" name="vs_defaultClientScript">
        <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <LINK href="../../../styles01.css" type="text/css" rel="stylesheet">
        <style>
			TD.grdXXJLLocked { ; LEFT: expression(divXXJL.scrollLeft); POSITION: relative }
			TH.grdXXJLLocked { ; LEFT: expression(divXXJL.scrollLeft); POSITION: relative }
			TH.grdXXJLLocked { Z-INDEX: 99 }
			TD.grdGZJLLocked { ; LEFT: expression(divGZJL.scrollLeft); POSITION: relative }
			TH.grdGZJLLocked { ; LEFT: expression(divGZJL.scrollLeft); POSITION: relative }
			TH.grdGZJLLocked { Z-INDEX: 99 }
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
				intWidth  -= 16;                          //滚动条
				strWidth   = intWidth.toString() + "px";
				
				intHeight  = document.body.clientHeight;  //总高度
				intHeight -= 16;                          //滚动条
				intHeight -= trRow1.clientHeight;
				intHeight -= trRow2.clientHeight;
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
        <script language="javascript" event="onreadystatechange" for="document">
		<!--
			return document_onreadystatechange()
		//-->
        </script>
    </HEAD>
    <body onresize="javascript:window_onresize()" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
        <form id="frmestate_rs_grll_info" method="post" runat="server">
            <asp:panel id="panelMain" Runat="server">
                <TABLE cellSpacing="0" cellPadding="0" border="0">
                    <TR>
                        <TD class="title" id="trRow1" vAlign="middle" align="center" height="30">求职履历<asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton></TD>
                    </TR>
                    <TR>
                        <TD vAlign="top" align="center">
                            <DIV id="divMain" style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 996px; CLIP: rect(0px 444px 996px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 444px">
                                <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                    <TR>
                                        <TD height="6"></TD>
                                    </TR>
                                    <TR>
                                        <TD align="center">
                                            <TABLE cellSpacing="0" borderColorDark="#66cccc" cellPadding="0" borderColorLight="#ffffff" border="1">
                                                <TR>
                                                    <TD class="labelNotNull" align="right" colspan="7" style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none"><span class="labelAuto">简历编号：</span><asp:TextBox id="txtJLBH" Runat="server" Columns="24" CssClass="textbox"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;填表日期：<asp:TextBox id="txtTBRQ" Runat="server" Columns="10" CssClass="textbox"></asp:TextBox><input type="hidden" id="htxtWYBS" runat="server" size="1" NAME="htxtWYBS"></TD>
                                                </TR>
                                                <TR>
                                                    <TD class="label" align="left" bgColor="#ccff99" colSpan="7">&gt;&gt;&gt;&gt;<B>基本资料</B></TD>
                                                </TR>
                                                <TR>
                                                    <TD class="labelNotNull" noWrap align="right">姓&nbsp;&nbsp;&nbsp;&nbsp;名</TD>
                                                    <TD align="left" colSpan="3"><asp:TextBox id="txtRYXM" Runat="server" Columns="36" CssClass="textbox"></asp:TextBox></TD>
                                                    <TD class="label" noWrap align="right">应聘职位</TD>
                                                    <TD align="left"><asp:TextBox id="txtYPZW" Runat="server" Columns="48" CssClass="textbox"></asp:TextBox></TD>
                                                    <TD align="center" rowSpan="11"><% response.write("<IMG height='240' src='" + propTPWZ + "' width='160' border='0'>") %><br><INPUT id="filePicture" style="FONT-SIZE: 12px;" type="file" runat="server" size="12"><BR><asp:LinkButton id="lnkUpload" Runat="server" CssClass="button">上传图片</asp:LinkButton><INPUT id="htxtUploadFile" type="hidden" size="1" runat="server"><INPUT id="htxtRYXP" type="hidden" size="1" runat="server"></TD>
                                                </TR>
                                                <TR>
                                                    <TD class="label" noWrap align="right">英&nbsp;文&nbsp;名</TD>
                                                    <TD align="left" colSpan="3"><asp:TextBox id="txtYWM" Runat="server" Width="100%" CssClass="textbox"></asp:TextBox></TD>
                                                    <TD class="label" noWrap align="right">薪金要求</TD>
                                                    <TD align="left"><asp:TextBox id="txtXJYQ" Runat="server" Width="100%" CssClass="textbox"></asp:TextBox></TD>
                                                </TR>
                                                <TR>
                                                    <TD class="labelNotNull" noWrap align="right">人员代码</TD>
                                                    <TD class="label" align="left" colSpan="3"><asp:TextBox id="txtRYDM" Runat="server" Columns="18" CssClass="textbox"></asp:TextBox>&nbsp;(一般为姓名全拼|唯一)</TD>
                                                    <TD class="label" noWrap align="right">民&nbsp;&nbsp;&nbsp;&nbsp;族</TD>
                                                    <TD align="left"><asp:TextBox id="txtMZ" Runat="server" Width="100%" CssClass="textbox"></asp:TextBox></TD>
                                                </TR>
                                                <TR>
                                                    <TD class="labelNotNull" noWrap align="right">性&nbsp;&nbsp;&nbsp;&nbsp;别</TD>
                                                    <TD align="left" colSpan="3">
                                                        <asp:RadioButtonList id="rblRYXB" Runat="server" Width="100%" CssClass="textbox" RepeatColumns="2" RepeatDirection="Vertical"
                                                            RepeatLayout="Flow">
                                                            <asp:ListItem Value="男">男</asp:ListItem>
                                                            <asp:ListItem Value="女">女</asp:ListItem>
                                                        </asp:RadioButtonList></TD>
                                                    <TD class="label" noWrap align="right">籍&nbsp;&nbsp;&nbsp;&nbsp;贯</TD>
                                                    <TD align="left"><asp:TextBox id="txtJG" Runat="server" Width="100%" CssClass="textbox"></asp:TextBox></TD>
                                                </TR>
                                                <TR>
                                                    <TD class="labelNotNull" noWrap align="right">出生日期</TD>
                                                    <TD align="left" colSpan="3"><asp:TextBox id="txtCSNY" Runat="server" Width="100%" CssClass="textbox"></asp:TextBox></TD>
                                                    <TD class="label" noWrap align="right">户口所在地</TD>
                                                    <TD align="left"><asp:TextBox id="txtHJDZ" Runat="server" Width="100%" CssClass="textbox"></asp:TextBox></TD>
                                                </TR>
                                                <TR>
                                                    <TD class="label" noWrap align="right">最高学历</TD>
                                                    <TD align="left" colSpan="3"><asp:DropDownList id="ddlXL" Runat="server" Width="100%" CssClass="textbox"></asp:DropDownList></TD>
                                                    <TD class="label" noWrap align="right">身份证号码</TD>
                                                    <TD align="left"><asp:TextBox id="txtSFZH" Runat="server" Width="100%" CssClass="textbox"></asp:TextBox></TD>
                                                </TR>
                                                <TR>
                                                    <TD class="label" noWrap align="right">婚育状况</TD>
                                                    <TD align="center">
                                                        <asp:RadioButtonList id="rblHYZK" Runat="server" CssClass="textbox" RepeatColumns="2" RepeatDirection="Horizontal"
                                                            RepeatLayout="Flow">
                                                            <asp:ListItem Value="1">未婚</asp:ListItem>
                                                            <asp:ListItem Value="2">已婚</asp:ListItem>
                                                        </asp:RadioButtonList></TD>
                                                    <TD align="center"><asp:CheckBox id="chkHYZK" Runat="server" CssClass="textbox" Text="离异"></asp:CheckBox></TD>
                                                    <TD align="center">
                                                        <asp:RadioButtonList id="rblSYZK" Runat="server" CssClass="textbox" RepeatColumns="2" RepeatDirection="Horizontal"
                                                            RepeatLayout="Flow">
                                                            <asp:ListItem Value="1">未育</asp:ListItem>
                                                            <asp:ListItem Value="2">已育</asp:ListItem>
                                                        </asp:RadioButtonList></TD>
                                                    <TD class="label" noWrap align="right">移动电话</TD>
                                                    <TD align="left"><asp:TextBox id="txtSJHM" Runat="server" Width="100%" CssClass="textbox"></asp:TextBox></TD>
                                                </TR>
                                                <TR>
                                                    <TD class="label" noWrap align="right">身高(米)</TD>
                                                    <TD align="left" colSpan="3"><asp:TextBox id="txtSG" Runat="server" Width="100%" CssClass="textbox"></asp:TextBox></TD>
                                                    <TD class="label" noWrap align="right">家庭电话</TD>
                                                    <TD align="left"><asp:TextBox id="txtZZDH" Runat="server" Width="100%" CssClass="textbox"></asp:TextBox></TD>
                                                </TR>
                                                <TR>
                                                    <TD class="label" noWrap align="right">体重(公斤)</TD>
                                                    <TD align="left" colSpan="3"><asp:TextBox id="txtTZ" Runat="server" Width="100%" CssClass="textbox"></asp:TextBox></TD>
                                                    <TD class="label" noWrap align="right">现住地址</TD>
                                                    <TD align="left"><asp:TextBox id="txtXZDZ" Runat="server" Width="100%" CssClass="textbox"></asp:TextBox></TD>
                                                </TR>
                                                <TR>
                                                    <TD class="label" noWrap align="right">最高学位</TD>
                                                    <TD align="left" colSpan="3"><asp:DropDownList id="ddlXW" Runat="server" Width="100%" CssClass="textbox"></asp:DropDownList></TD>
                                                    <TD class="label" noWrap align="right">毕业院校</TD>
                                                    <TD align="left"><asp:TextBox id="txtBYYX" Runat="server" Width="100%" CssClass="textbox"></asp:TextBox></TD>
                                                </TR>
                                                <TR>
                                                    <TD class="label" noWrap align="right">专&nbsp;&nbsp;&nbsp;&nbsp;业</TD>
                                                    <TD align="left" colSpan="3"><asp:TextBox id="txtBYZY" Runat="server" Width="100%" CssClass="textbox"></asp:TextBox></TD>
                                                    <TD class="label" noWrap align="right">毕业时间</TD>
                                                    <TD align="left"><asp:TextBox id="txtBYSJ" Runat="server" Width="100%" CssClass="textbox"></asp:TextBox></TD>
                                                </TR>
                                                <TR>
                                                    <TD class="label" noWrap align="right">技术职称</TD>
                                                    <TD align="left" colSpan="3"><asp:DropDownList id="ddlJSZC" Runat="server" Width="100%" CssClass="textbox"></asp:DropDownList></TD>
                                                    <TD class="label" noWrap align="right">取得时间</TD>
                                                    <TD align="left" colSpan="2"><asp:TextBox id="txtZCQDSJ" Runat="server" Width="100%" CssClass="textbox"></asp:TextBox></TD>
                                                </TR>
                                                <TR>
                                                    <TD class="label" noWrap align="right">政治面貌</TD>
                                                    <TD align="left" colSpan="3"><asp:DropDownList id="ddlZZMM" Runat="server" Width="100%" CssClass="textbox"></asp:DropDownList></TD>
                                                    <TD class="label" noWrap align="right">加入时间</TD>
                                                    <TD align="left" colSpan="2"><asp:TextBox id="txtRDSJ" Runat="server" Width="100%" CssClass="textbox"></asp:TextBox></TD>
                                                </TR>
                                                <!-- zengxianglin 2009-05-15-->
                                                <TR>
                                                    <TD class="label" noWrap align="right">&nbsp;</TD>
                                                    <TD align="left" colSpan="3">&nbsp;</TD>
                                                    <TD class="label" noWrap align="right">拟用部门</TD>
                                                    <TD class="label" align="left" colSpan="2"><asp:TextBox id="txtNYBM" Runat="server" Width="280px" CssClass="textbox"></asp:TextBox><asp:Button ID="btnSelectNYBM" Runat="server" CssClass="button" Text="…"></asp:Button><input id="htxtNYBM" type="hidden" runat="server" NAME="htxtNYBM"></TD>
                                                </TR>
                                                <TR>
                                                    <TD class="labelAuto" noWrap align="right">登记人员</TD>
                                                    <TD align="left" colSpan="3"><asp:TextBox id="txtDJRY" Runat="server" Width="330px" CssClass="textbox"></asp:TextBox><asp:Button ID="btnSelectDJRY" Runat="server" CssClass="button" Text="…"></asp:Button><input id="htxtDJRY" type="hidden" runat="server" NAME="htxtDJRY"></TD>
                                                    <TD class="labelAuto" noWrap align="right">登记部门</TD>
                                                    <TD class="labelAuto" align="left" colSpan="2"><asp:TextBox id="txtDJBM" Runat="server" Width="280px" CssClass="textbox"></asp:TextBox><asp:Button ID="btnSelectDJBM" Runat="server" CssClass="button" Text="…"></asp:Button><input id="htxtDJBM" type="hidden" runat="server" NAME="htxtDJBM">&nbsp;&nbsp;登记时间<asp:TextBox id="txtDJSJ" Runat="server" Width="120px" CssClass="textbox"></asp:TextBox></TD>
                                                </TR>
                                                <TR>
                                                    <TD class="label" align="left" bgColor="#ccff99" colSpan="7">&gt;&gt;&gt;&gt;<B>现场管理层意见</B></TD>
                                                </TR>
                                                <TR>
													<TD class="label" align="left" colSpan="7"><asp:TextBox ID="txtXCYJ" Runat="server" CssClass="textbox" Rows="6" TextMode="MultiLine" Width="940px"></asp:TextBox></TD>
                                                </tr>
                                                <!-- zengxianglin 2009-05-15-->
                                                <TR>
                                                    <TD class="label" align="left" bgColor="#ccff99" colSpan="7">&gt;&gt;&gt;&gt;<B>学习经历</B></TD>
                                                </TR>
                                                <TR>
                                                    <TD align="left" colSpan="7">
                                                        <DIV id="divXXJL" style="OVERFLOW: auto; WIDTH: 940px; CLIP: rect(0px 940px 240px 0px); HEIGHT: 240px">
                                                            <asp:datagrid id="grdXXJL" runat="server" CssClass="label" Font-Names="宋体" AllowSorting="False"
                                                                BorderWidth="0px" BorderColor="#DEDFDE" PageSize="30" AllowPaging="False" CellPadding="4"
                                                                BorderStyle="None" GridLines="Vertical" AutoGenerateColumns="False" UseAccessibleHeader="True"
                                                                Font-Size="11pt" Width="100%">
                                                                <SelectedItemStyle Font-Size="11pt" Font-Names="宋体" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
                                                                <EditItemStyle Font-Size="11pt" Font-Names="宋体" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
                                                                <AlternatingItemStyle Font-Size="11pt" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
                                                                <ItemStyle Font-Size="11pt" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
                                                                <HeaderStyle Font-Size="11pt" Font-Names="宋体" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#87cefa" HorizontalAlign="Left"></HeaderStyle>
                                                                <FooterStyle BackColor="#CCCC99"></FooterStyle>
                                                                
                                                                <Columns>
                                                                    <asp:TemplateColumn HeaderText="选" ItemStyle-Width="20px">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox id="chkXXJL" runat="server" AutoPostBack="False"></asp:CheckBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="唯一标识" SortExpression="唯一标识" HeaderText="唯一标识" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="人员代码" SortExpression="人员代码" HeaderText="人员代码" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    
                                                                    <asp:TemplateColumn HeaderText="学习类型" ItemStyle-Width="120px">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="120px"></HeaderStyle>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:DropDownList ID="ddlXXJL_XXLX" Runat="server" CssClass="textbox" Width="100%">
                                                                                <asp:ListItem Value="高中">高中</asp:ListItem>
                                                                                <asp:ListItem Value="职中">职中</asp:ListItem>
                                                                                <asp:ListItem Value="中专">中专</asp:ListItem>
                                                                                <asp:ListItem Value="全日制大专">全日制大专</asp:ListItem>
                                                                                <asp:ListItem Value="业余大专">业余大专</asp:ListItem>
                                                                                <asp:ListItem Value="全日制大学">全日制大学</asp:ListItem>
                                                                                <asp:ListItem Value="业余专升本">业余专升本</asp:ListItem>
                                                                                <asp:ListItem Value="全日制研究生">全日制研究生</asp:ListItem>
                                                                                <asp:ListItem Value="业余攻读研究生">业余攻读研究生</asp:ListItem>
                                                                                <asp:ListItem Value="进修">进修</asp:ListItem>
                                                                                <asp:ListItem Value="">其他</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn HeaderText="开始年月" ItemStyle-Width="80px">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="80px"></HeaderStyle>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtXXJL_KSSJ" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn HeaderText="终止年月" ItemStyle-Width="80px">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="80px"></HeaderStyle>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtXXJL_JSSJ" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn HeaderText="学习院校" ItemStyle-Width="210px">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="210px"></HeaderStyle>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtXXJL_XXYX" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn HeaderText="专业" ItemStyle-Width="140px">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="140px"></HeaderStyle>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtXXJL_XXZY" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn HeaderText="结果" ItemStyle-Width="90px">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="90px"></HeaderStyle>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:DropDownList ID="ddlXXJL_XXJG" Runat="server" CssClass="textbox" Width="100%">
                                                                                <asp:ListItem Value="毕业">毕业</asp:ListItem>
                                                                                <asp:ListItem Value="肄业">肄业</asp:ListItem>
                                                                                <asp:ListItem Value="全日制在读">全日制在读</asp:ListItem>
                                                                                <asp:ListItem Value="业余在读">业余在读</asp:ListItem>
                                                                                <asp:ListItem Value="">其他</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn HeaderText="学位证" ItemStyle-Width="60px">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="60px"></HeaderStyle>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="chkXXJL_XWZ" Runat="server" CssClass="textbox" Width="100%" Text=""></asp:CheckBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn HeaderText="学历证" ItemStyle-Width="60px">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="60px"></HeaderStyle>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="chkXXJL_XLZ" Runat="server" CssClass="textbox" Width="100%" Text=""></asp:CheckBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                </Columns>
                                                                
                                                                <PagerStyle Visible="False" NextPageText="下页" Font-Size="11pt" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
                                                            </asp:datagrid><INPUT id="htxtXXJLFixed" type="hidden" value="0" runat="server">
                                                        </DIV>
                                                    </TD>
                                                </TR>
                                                <TR>
                                                    <TD align="right" colSpan="7"><asp:Button id="btnAddNew_XXJL" Runat="server" CssClass="button" Text="增加新的学习经历"></asp:Button><asp:Button id="btnDelete_XXJL" Runat="server" CssClass="button" Text="删除选定学习经历"></asp:Button></TD>
                                                </TR>
                                                <TR>
                                                    <TD class="label" align="left" bgColor="#ccff99" colSpan="7">&gt;&gt;&gt;&gt;<B>工作经历</B></TD>
                                                </TR>
                                                <TR>
                                                    <TD align="left" colSpan="7">
                                                        <DIV id="divGZJL" style="OVERFLOW: auto; WIDTH: 940px; CLIP: rect(0px 940px 240px 0px); HEIGHT: 240px">
                                                            <asp:datagrid id="grdGZJL" runat="server" CssClass="label" Font-Names="宋体" AllowSorting="False"
                                                                BorderWidth="0px" BorderColor="#DEDFDE" PageSize="30" AllowPaging="False" CellPadding="4"
                                                                BorderStyle="None" GridLines="Vertical" AutoGenerateColumns="False" UseAccessibleHeader="True"
                                                                Font-Size="11pt" BackColor="White" Width="100%">
                                                                <SelectedItemStyle Font-Size="11pt" Font-Names="宋体" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
                                                                <EditItemStyle Font-Size="11pt" Font-Names="宋体" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
                                                                <AlternatingItemStyle Font-Size="11pt" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
                                                                <ItemStyle Font-Size="11pt" Font-Names="宋体" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
                                                                <HeaderStyle Font-Size="11pt" Font-Names="宋体" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#87cefa" HorizontalAlign="Left"></HeaderStyle>
                                                                <FooterStyle BackColor="#CCCC99"></FooterStyle>
                                                                <Columns>
                                                                    <asp:TemplateColumn HeaderText="选" ItemStyle-Width="20px">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox id="chkGZJL" runat="server" AutoPostBack="False"></asp:CheckBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="唯一标识" SortExpression="唯一标识" HeaderText="唯一标识" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="人员代码" SortExpression="人员代码" HeaderText="人员代码" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:TemplateColumn HeaderText="开始年月" ItemStyle-Width="70px">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="70px"></HeaderStyle>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtGZJL_KSSJ" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn HeaderText="终止年月" ItemStyle-Width="70px">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="70px"></HeaderStyle>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtGZJL_JSSJ" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn HeaderText="服务单位" ItemStyle-Width="190px">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="190px"></HeaderStyle>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtGZJL_FWDW" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn HeaderText="担任职务" ItemStyle-Width="130px">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="130px"></HeaderStyle>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtGZJL_DRZW" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn HeaderText="月薪" ItemStyle-Width="90px">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="90px"></HeaderStyle>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtGZJL_YX" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn HeaderText="离职原因" ItemStyle-Width="110px">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="110px"></HeaderStyle>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtGZJL_LZYY" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn HeaderText="证明人" ItemStyle-Width="80px">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="80px"></HeaderStyle>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtGZJL_ZMR" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn HeaderText="电话" ItemStyle-Width="110px">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="110px"></HeaderStyle>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtGZJL_DH" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                </Columns>
                                                                <PagerStyle Visible="False" NextPageText="下页" Font-Size="11pt" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
                                                            </asp:datagrid><INPUT id="htxtGZJLFixed" type="hidden" value="0" runat="server">
                                                        </DIV>
                                                    </TD>
                                                </TR>
                                                <TR>
                                                    <TD align="right" colSpan="7"><asp:Button id="btnAddNew_GZJL" Runat="server" CssClass="button" Text="增加新的工作经历"></asp:Button><asp:Button id="btnDelete_GZJL" Runat="server" CssClass="button" Text="删除选定工作经历"></asp:Button></TD>
                                                </TR>
                                                <TR>
                                                    <TD class="label" align="left" bgColor="#ccff99" colSpan="7">&gt;&gt;&gt;&gt;<B>原工作部门的业绩？你的个人业绩？个人特长、技能？</B></TD>
                                                </TR>
                                                <TR>
                                                    <TD colSpan="7"><asp:TextBox id="txtGRJJ" Runat="server" Width="100%" CssClass="textbox" TextMode="MultiLine" Rows="8"></asp:TextBox></TD>
                                                </TR>
                                                <TR>
                                                    <TD colSpan="7">
                                                        <TABLE cellSpacing="0" cellPadding="0" border="0" width="100%">
                                                            <TR>
                                                                <TD class="label" align="right">现居住地属：</TD>
                                                                <td width="20">&nbsp;</td>
                                                                <TD align="left">
                                                                    <asp:RadioButtonList id="rblXZZDS" Runat="server" CssClass="textbox" RepeatColumns="4" RepeatDirection="Vertical" RepeatLayout="Table">
                                                                        <asp:ListItem Value="自有物业">自有物业</asp:ListItem>
                                                                        <asp:ListItem Value="租赁">租赁</asp:ListItem>
                                                                        <asp:ListItem Value="与家人同住">与家人同住</asp:ListItem>
                                                                        <asp:ListItem Value="与朋友合住">与朋友合住</asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </TD>
                                                            </TR>
                                                            <TR>
                                                                <TD class="label" align="right"><asp:CheckBox id="chkYZGZ" Runat="server" CssClass="textbox" Text="持有房地产执业证"></asp:CheckBox></TD>
                                                                <td width="20">&nbsp;</td>
                                                                <TD align="left"><asp:DropDownList id="ddlZYZG" Runat="server" Width="100%" CssClass="textbox"></asp:DropDownList></TD>
                                                            </TR>
                                                        </TABLE>
                                                    </TD>
                                                </TR>
                                            </TABLE>
                                        </TD>
                                    </TR>
                                    <TR>
                                        <TD height="6"></TD>
                                    </TR>
                                </TABLE>
                            </DIV>
                        </TD>
                    </TR>
                    <TR id="trRow2">
                        <TD style="BORDER-TOP: #99cccc 2px solid" vAlign="middle" align="center">
                            <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                <TR height="36">
                                    <TD align="center" colSpan="3">
                                        <asp:Button id="btnOK"     Runat="server" CssClass="button" Text=" 保  存 " Font-Size="11pt" Font-Name="宋体" Height="32px"></asp:Button>
                                        <asp:Button id="btnCancel" Runat="server" CssClass="button" Text=" 取  消 " Font-Size="11pt" Font-Name="宋体" Height="32px"></asp:Button>
                                        <asp:Button id="btnClose"  Runat="server" CssClass="button" Text=" 返  回 " Font-Size="11pt" Font-Name="宋体" Height="32px"></asp:Button>
                                    </TD>
                                </TR>
                            </TABLE>
                        </TD>
                    </TR>
                </TABLE>
            </asp:panel>
            <asp:panel id="panelError" Runat="server">
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
            </asp:panel>
            <table cellSpacing="0" cellPadding="0" align="center" border="0">
                <tr>
                    <td>
                        <input id="htxtSessionId_GZJL" type="hidden" runat="server">
                        <input id="htxtSessionId_XXJL" type="hidden" runat="server">
                        <input id="htxtDivLeftGZJL" type="hidden" runat="server">
                        <input id="htxtDivTopGZJL" type="hidden" runat="server">
                        <input id="htxtDivLeftXXJL" type="hidden" runat="server">
                        <input id="htxtDivTopXXJL" type="hidden" runat="server">
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
							function ScrollProc_divXXJL() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopXXJL");
								if (oText != null) oText.value = divXXJL.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftXXJL");
								if (oText != null) oText.value = divXXJL.scrollLeft;
								return;
							}
							function ScrollProc_divGZJL() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopGZJL");
								if (oText != null) oText.value = divGZJL.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftGZJL");
								if (oText != null) oText.value = divGZJL.scrollLeft;
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
								oText=document.getElementById("htxtDivTopXXJL");
								if (oText != null) divXXJL.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftXXJL");
								if (oText != null) divXXJL.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtDivTopGZJL");
								if (oText != null) divGZJL.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftGZJL");
								if (oText != null) divGZJL.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divMain.onscroll = ScrollProc_divMain;
								divXXJL.onscroll = ScrollProc_divXXJL;
								divGZJL.onscroll = ScrollProc_divGZJL;
							}
							catch (e) {}
                        </script>
                    </td>
                </tr>
                <tr>
                    <td>
                        <script language="javascript">window_onresize();</script>
                        <uwin:popmessage id="popMessageObject" runat="server" EnableViewState="False" PopupWindowType="Normal" ActionType="OpenWindow" Visible="False" width="96px" height="48px"></uwin:popmessage>
                    </td>
                </tr>
            </table>
        </form>
    </body>
</HTML>
