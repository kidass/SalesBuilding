'----------------------------------------------------------------
' Copyright (C) 2006-2016 Josco Software Corporation
' All rights reserved.
'
' This source code is intended only as a supplement to Microsoft
' Development Tools and/or on-line documentation. See these other
' materials for detailed information regarding Microsoft code samples.
'
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY 
' OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT 
' LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR 
' FITNESS FOR A PARTICULAR PURPOSE.
'----------------------------------------------------------------
Option Strict On
Option Explicit On

Imports Microsoft.VisualBasic

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient

Imports Josco.JSOA.Common
Imports Josco.JSOA.Common.Data
Imports Josco.JsKernal.SystemFramework

Namespace Josco.JSOA.DataAccess
    Public Class dacStaff
        Implements IDisposable

        ' 密码加密字符串
        Private Const m_cstrEncryptString As String = "FDINGWNUEKJYRXZHUXRGSRKRXTGDKJTDSODGNDTVSYSLJAZI"
        Private m_objSqlDataAdapter As System.Data.SqlClient.SqlDataAdapter








        '----------------------------------------------------------------
        ' 构造函数
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()
            m_objSqlDataAdapter = New System.Data.SqlClient.SqlDataAdapter
        End Sub

        '----------------------------------------------------------------
        ' 虚拟析构函数
        '----------------------------------------------------------------
        Public Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
            GC.SuppressFinalize(True)
        End Sub

        '----------------------------------------------------------------
        ' 析构函数重载
        '----------------------------------------------------------------
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If (Not disposing) Then
                Exit Sub
            End If
            If Not m_objSqlDataAdapter Is Nothing Then
                m_objSqlDataAdapter.Dispose()
                m_objSqlDataAdapter = Nothing
            End If
        End Sub

        '----------------------------------------------------------------
        ' 安全释放本身资源
        '----------------------------------------------------------------
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.DataAccess.dacStaff)
            Try
                If Not (obj Is Nothing) Then
                    obj.Dispose()
                End If
            Catch ex As Exception
            End Try
            obj = Nothing
        End Sub

        '----------------------------------------------------------------
        ' 获取完整用户信息数据集
        '     strErrMsg      ：如果错误，则返回错误信息
        '     strUserId      ：用户标识
        '     strPassword    ：用户密码
        '     strRYDM        ：人员代码
        '     blnUnused      ：重载用
        '     objCustomerData：用户信息数据集
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Public Function getRenyuanData( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strRYDM As String, _
            ByVal blnUnused As Boolean, _
            ByRef objCustomerData As Josco.JSOA.Common.Data.staffData) As Boolean

            Dim objTempStaffData As Josco.JSOA.Common.Data.staffData
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand
            Dim objDataTable As System.Data.DataTable
            Dim strSQL As String

            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon

            '初始化
            getRenyuanData = False
            objCustomerData = Nothing
            strErrMsg = ""

            Try
                '检查
                If strUserId Is Nothing Then strUserId = ""
                strUserId = strUserId.Trim
                If strUserId = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If
                If strPassword Is Nothing Then strPassword = ""
                strPassword = strPassword.Trim
               

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '获取数据
                Try
                    '创建数据集
                    objTempStaffData = New Josco.JSOA.Common.Data.staffData(Josco.JSOA.Common.Data.staffData.enumTableType.GG_B_RENYUAN_FULLJOIN)

                    '创建SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '执行检索
                    With Me.m_objSqlDataAdapter
                        '准备SQL
                        strSQL = ""
                        strSQL = strSQL + " select a.*," + vbCr
                        strSQL = strSQL + "   b.组织名称,b.组织别名," + vbCr
                        strSQL = strSQL + "   岗位列表 = dbo.GetGWMCByRydm(a.人员代码,@separate)," + vbCr
                        strSQL = strSQL + "   c.级别名称,c.行政级别," + vbCr
                        strSQL = strSQL + "   秘书名称 = d.人员名称," + vbCr
                        strSQL = strSQL + "   其他由转送名称 = e.人员名称," + vbCr
                        strSQL = strSQL + "   是否申请 = @charfalse" + vbCr
                        strSQL = strSQL + " from " + vbCr
                        strSQL = strSQL + " (" + vbCr
                        strSQL = strSQL + "   select * from 公共_B_人员 " + vbCr
                        strSQL = strSQL + "   where 人员代码 = @rydm" + vbCr
                        strSQL = strSQL + " ) a " + vbCr
                        strSQL = strSQL + " left join 公共_B_组织机构 b on a.组织代码   = b.组织代码 " + vbCr
                        strSQL = strSQL + " left join 公共_B_行政级别 c on a.级别代码   = c.级别代码 " + vbCr
                        strSQL = strSQL + " left join 公共_B_人员     d on a.秘书代码   = d.人员代码 " + vbCr
                        strSQL = strSQL + " left join 公共_B_人员     e on a.其他由转送 = e.人员代码 " + vbCr

                        '设置参数
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        objSqlCommand.Parameters.AddWithValue("@rydm", strRYDM)
                        objSqlCommand.Parameters.AddWithValue("@separate", Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate)
                        objSqlCommand.Parameters.AddWithValue("@charfalse", Josco.JsKernal.Common.Utilities.PulicParameters.CharFalse)
                        .SelectCommand = objSqlCommand

                        .Fill(objTempStaffData.Tables(Josco.JSOA.Common.Data.staffData.TABLE_GG_B_RENYUAN_FULLJOIN))
                    End With

                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
                If objTempStaffData.Tables.Count < 1 Then
                    Josco.JSOA.Common.Data.staffData.SafeRelease(objTempStaffData)
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataTable)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '返回
            objCustomerData = objTempStaffData
            getRenyuanData = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataTable)
            Josco.JSOA.Common.Data.staffData.SafeRelease(objTempStaffData)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取指定组织机构下的人员信息数据集(以组织代码、人员序号升序排序)
        ' 含人员的全部连接数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strZZDM              ：指定组织机构代码
        '     blnBaohanXiaji       ：是否包含下级部门
        '     strWhere             ：搜索字符串(默认表前缀a.)
        '     objRenyuanData       ：指定组织机构下的人员信息数据集
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function getRenyuanInBumenData( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strZZDM As String, _
            ByVal blnBaohanXiaji As Boolean, _
            ByVal strWhere As String, _
            ByRef objRenyuanData As Josco.JSOA.Common.Data.staffData) As Boolean

            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objTempRenyuanData As Josco.JSOA.Common.Data.staffData
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand

            '初始化
            getRenyuanInBumenData = False
            objRenyuanData = Nothing
            strErrMsg = ""

            Try
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strZZDM.Length > 0 Then strZZDM = strZZDM.Trim()
                If strWhere.Length > 0 Then strWhere = strWhere.Trim()

                '检查
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '获取数据
                Dim strSQL As String
                Try
                    '创建数据集
                    objTempRenyuanData = New Josco.JSOA.Common.Data.staffData(Josco.JSOA.Common.Data.staffData.enumTableType.GG_B_RENYUAN_FULLJOIN)

                    '创建SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '执行检索
                    With Me.m_objSqlDataAdapter
                        '准备SQL
                        strSQL = ""
                        strSQL = strSQL + " select a.* from ("
                        strSQL = strSQL + "   select ''as 编号,a.*," + vbCr
                        'strSQL = strSQL + "   select ''as 编号, "
                        'strSQL = strSQL + "  a.用工模式,a.身份证号,a.人员代码, a.人员名称, a.人员真名, a.人员序号,"
                        'strSQL = strSQL + "  a.组织代码, a.级别代码, a.秘书代码, a.联系电话,"
                        'strSQL = strSQL + "  a.手机号码, a.FTP地址, a.邮箱地址, a.自动签收, "
                        'strSQL = strSQL + "  a.交接显示名称, a.可查看姓名, a.可直送人员, a.其他由转送, a.是否加密,"
                        strSQL = strSQL + "     b.组织名称,b.组织别名," + vbCr
                        strSQL = strSQL + "     岗位列表 = dbo.GetGWMCByRydm(a.人员代码,@separate)," + vbCr
                        strSQL = strSQL + "     c.级别名称,c.行政级别," + vbCr
                        strSQL = strSQL + "     秘书名称 = d.人员名称," + vbCr
                        strSQL = strSQL + "     是否申请 = @charfalse" + vbCr
                        strSQL = strSQL + "   from " + vbCr
                        strSQL = strSQL + "   (" + vbCr
                        strSQL = strSQL + "     select * from 公共_B_人员 " + vbCr
                        If blnBaohanXiaji = True Then
                            strSQL = strSQL + "     where rtrim(组织代码) like @zzdm + '%'" + vbCr
                        Else
                            strSQL = strSQL + "     where 组织代码 = @zzdm" + vbCr
                        End If
                        strSQL = strSQL + "   ) a " + vbCr
                        strSQL = strSQL + "   left join 公共_B_组织机构 b on a.组织代码 = b.组织代码 " + vbCr
                        strSQL = strSQL + "   left join 公共_B_行政级别 c on a.级别代码 = c.级别代码 " + vbCr
                        strSQL = strSQL + "   left join 公共_B_人员     d on a.秘书代码 = d.人员代码 " + vbCr
                        strSQL = strSQL + " ) a "
                        If strWhere <> "" Then
                            strSQL = strSQL + " where " + strWhere + vbCr
                        End If
                        strSQL = strSQL + " order by a.组织代码, cast(a.人员序号 as integer)"

                        '设置参数
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        objSqlCommand.Parameters.AddWithValue("@zzdm", strZZDM)
                        objSqlCommand.Parameters.AddWithValue("@separate", Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate)
                        objSqlCommand.Parameters.AddWithValue("@charfalse", Josco.JsKernal.Common.Utilities.PulicParameters.CharFalse)
                        .SelectCommand = objSqlCommand

                        '执行操作
                        .Fill(objTempRenyuanData.Tables(Josco.JSOA.Common.Data.staffData.TABLE_GG_B_RENYUAN_FULLJOIN))
                    End With
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
                If objTempRenyuanData.Tables.Count < 1 Then
                    Josco.JSOA.Common.Data.staffData.SafeRelease(objTempRenyuanData)
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
             Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '返回
            objRenyuanData = objTempRenyuanData
            getRenyuanInBumenData = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JSOA.Common.Data.staffData.SafeRelease(objTempRenyuanData)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function












        '----------------------------------------------------------------
        ' 检查“公共_B_人员”的标识是否已存在
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strNewUserId         ：检查的用户标识
        '     strNewUserZZDM       ：检查的用户组织代码
        ' 返回
        '     intType              ：0-不存在，1-同部门添加，2-不同部门添加
        '     objCustomerData      ：如果存在，就返回存在的纪录集
        '     True                 ：合法
        '     False                ：不合法或其他程序错误

        '----------------------------------------------------------------
        Public Function doVerifyRenyuanData( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strNewUserId As String, _
            ByVal strNewUserZZDM As String, _
            ByRef intType As Integer, _
            ByRef objCustomerData As Josco.JsKernal.Common.Data.CustomerData) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objTempCustomerData As Josco.JsKernal.Common.Data.CustomerData
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objListDictionary As New System.Collections.Specialized.ListDictionary
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand
            Dim objDataTable As System.Data.DataTable
            Dim objDataSet As System.Data.DataSet


            doVerifyRenyuanData = False

            Try
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                strUserId = strUserId.Trim()
                strPassword = strPassword.Trim()
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If

                If strNewUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要检查信息的用户！"
                    GoTo errProc
                End If

                '获取表结构定义
                Dim strSQL As String = ""
                Dim strZZDM As String = ""
                Dim strZZMC As String = ""

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '创建数据集
                objTempCustomerData = New Josco.JsKernal.Common.Data.CustomerData(Josco.JsKernal.Common.Data.CustomerData.enumTableType.GG_B_RENYUAN_FULLJOIN)

                '创建SqlCommand
                objSqlCommand = New System.Data.SqlClient.SqlCommand
                objSqlCommand.Connection = objSqlConnection
                objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                '执行检索
                With Me.m_objSqlDataAdapter
                    '准备SQL
                    strSQL = ""
                    strSQL = "select  * from 公共_B_人员 where 人员代码='" + strNewUserId + "'"

                    '设置参数
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    .SelectCommand = objSqlCommand

                    .Fill(objTempCustomerData.Tables(Josco.JsKernal.Common.Data.CustomerData.TABLE_GG_B_RENYUAN_FULLJOIN))


                    If objTempCustomerData.Tables(0).Rows.Count > 0 Then
                        strZZDM = objPulicParameters.getObjectValue(objTempCustomerData.Tables(Josco.JsKernal.Common.Data.CustomerData.TABLE_GG_B_RENYUAN_FULLJOIN).Rows(0).Item(Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_RENYUAN_ZZDM), "")
                        Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)

                        If strNewUserZZDM = strZZDM Then
                            strErrMsg = "提示：[" + strNewUserId + "]已经在这个部门,请重新确认部门后再保存！"
                            intType = 1
                        Else
                            strSQL = ""
                            strSQL = "select  * from 公共_B_组织机构 where 组织代码='" + strZZDM + "'"
                            If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objDataSet) = False Then
                                GoTo errProc
                            End If
                            strZZMC = objPulicParameters.getObjectValue(objDataSet.Tables(0).Rows(0).Item(1), "")
                            intType = 2
                            strErrMsg = "提示：[" + strNewUserId + "]已经在其他部门！是否在新部门任职此人？"
                        End If
                    Else
                        '准备SQL
                        'objTempCustomerData = Nothing
                        strSQL = ""
                        strSQL = "select  * from 公共_B_人员_兼任 where 人员代码='" + strNewUserId + "'"

                        '设置参数
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        .SelectCommand = objSqlCommand

                        .Fill(objTempCustomerData.Tables(Josco.JsKernal.Common.Data.CustomerData.TABLE_GG_B_RENYUAN_FULLJOIN))
                        If objTempCustomerData.Tables(0).Rows.Count > 0 Then
                            intType = 3
                            strErrMsg = "提示：[" + strNewUserId + "]已经在其他部门！是否在新部门任职此人？"
                        End If
                    End If
                End With

                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                objDataSet = Nothing
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataTable)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            objCustomerData = objTempCustomerData
            doVerifyRenyuanData = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataTable)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取人员已经加入到角色strRoleName的列表
        '----------------------------------------------------------------
        '     strErrMsg                   ：如果错误，则返回错误信息
        '     objConnectionProperty       ：服务器信息
        '     strWhere                    ：搜索字符串(默认表前缀a.)
        '     objRoleData                 ：信息数据集
        '     blnNone                     ：重载
        ' 返回
        '     True                        ：成功
        '     False                       ：失败

        '----------------------------------------------------------------
        Public Function getRoleData( _
            ByRef strErrMsg As String, _
            ByVal objConnectionProperty As Josco.JsKernal.Common.Utilities.ConnectionProperty, _
            ByVal strWhere As String, _
            ByRef objRoleData As Josco.JsKernal.Common.Data.AppManagerData, _
            ByVal blnNone As Boolean) As Boolean

            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objTempRoleData As Josco.JsKernal.Common.Data.AppManagerData
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand

            '初始化
            getRoleData = False
            objRoleData = Nothing
            strErrMsg = ""

            Try
                '检查
                If strWhere Is Nothing Then strWhere = ""
                strWhere = strWhere.Trim()
                If objConnectionProperty Is Nothing Then
                    '创建数据集
                    objTempRoleData = New Josco.JsKernal.Common.Data.AppManagerData(Josco.JsKernal.Common.Data.AppManagerData.enumTableType.GL_B_SHUJUKU_JIAOSE)
                    Exit Try
                End If

                '获取连接
                With objConnectionProperty

                    'If objdacCommon.getConnection(strErrMsg, objSqlConnection, .UserID, .Password, -1, .InitialCatalog, .DataSource) = False Then
                    '    GoTo errProc
                    'End If
                    If objdacCommon.getConnection(strErrMsg, objSqlConnection, .UserID, .Password, Josco.JsKernal.Common.jsoaConfiguration.ConnectionTestTimeout, .InitialCatalog, .DataSource) = False Then
                        GoTo errProc
                    End If

                End With

                '获取数据
                Dim strSQL As String
                Try
                    '创建数据集
                    objTempRoleData = New Josco.JsKernal.Common.Data.AppManagerData(Josco.JsKernal.Common.Data.AppManagerData.enumTableType.GL_B_SHUJUKU_JIAOSE)

                    '创建SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '执行检索
                    With Me.m_objSqlDataAdapter
                        Dim strDefDB As String = Josco.JsKernal.Common.jsoaConfiguration.DatabaseServerUserDB
                        Dim strDatabase As String = objConnectionProperty.InitialCatalog

                        '准备SQL
                        strSQL = ""
                        strSQL = strSQL + " select a.gid as 'UID',a.rollname as 'NAME' from ( " + vbCr
                        strSQL = strSQL + " select a.*,b.*,c.name  from  " + strDatabase + ".dbo.sysmembers a " + vbCr
                        strSQL = strSQL + " Left Join  " + vbCr
                        strSQL = strSQL + " ( " + vbCr
                        strSQL = strSQL + " select gid,name as 'rollname' from  " + strDatabase + ".dbo.sysusers " + vbCr
                        strSQL = strSQL + " where(issqlrole = 1 And gid > 0) " + vbCr
                        strSQL = strSQL + " ) b on a.groupuid = b.gid " + vbCr
                        strSQL = strSQL + " left join  " + strDatabase + ".dbo.sysusers c on a.memberuid = c.uid " + vbCr
                        strSQL = strSQL + " where(b.gid Is Not null) " + vbCr
                        strSQL = strSQL + " and c.uid is not null " + vbCr
                        strSQL = strSQL + " ) a "
                        If strWhere <> "" Then
                            strSQL = strSQL + strWhere + vbCr
                        End If
                        strSQL = strSQL + " order by a.name"

                        '设置参数
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        .SelectCommand = objSqlCommand

                        '执行操作
                        .Fill(objTempRoleData.Tables(Josco.JsKernal.Common.Data.AppManagerData.TABLE_GL_B_SHUJUKU_JIAOSE))
                    End With
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
                If objTempRoleData.Tables.Count < 1 Then
                    Josco.JsKernal.Common.Data.AppManagerData.SafeRelease(objTempRoleData)
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '返回
            objRoleData = objTempRoleData
            getRoleData = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Data.AppManagerData.SafeRelease(objTempRoleData)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function


        '----------------------------------------------------------------
        ' 获取全部的范围主记录的数据集(以范围名称升序排序)
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strWhere             ：搜索条件(默认表前缀a.)
        '     objFenfafanweiData   ：信息数据集
        '     blnNone              ：重载用
        ' 返回
        '     True                 ：成功
        '     False                ：失败

        '----------------------------------------------------------------
        Public Function getFenfafanweiData( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objFenfafanweiData As Josco.JsKernal.Common.Data.FenfafanweiData, _
            ByVal blnNone As Boolean) As Boolean

            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objTempFenfafanweiData As Josco.JsKernal.Common.Data.FenfafanweiData
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand

            '初始化
            getFenfafanweiData = False
            objFenfafanweiData = Nothing
            strErrMsg = ""

            Try
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strWhere.Length > 0 Then strWhere = strWhere.Trim()

                '检查
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '获取数据
                Dim strSQL As String
                Try
                    '创建数据集
                    objTempFenfafanweiData = New Josco.JsKernal.Common.Data.FenfafanweiData(Josco.JsKernal.Common.Data.FenfafanweiData.enumTableType.GW_B_FENFAFANWEI)

                    '创建SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '执行检索
                    With Me.m_objSqlDataAdapter
                        '准备SQL
                        strSQL = ""
                        strSQL = strSQL + " select a.* " + vbCr
                        strSQL = strSQL + " from 公文_B_分发范围 a " + vbCr
                        If strWhere <> "" Then
                            strSQL = strSQL + " where " + strWhere + vbCr
                        End If
                        strSQL = strSQL + " order by a.范围名称 " + vbCr

                        '设置参数
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        .SelectCommand = objSqlCommand

                        '执行操作
                        .Fill(objTempFenfafanweiData.Tables(Josco.JsKernal.Common.Data.FenfafanweiData.TABLE_GW_B_FENFAFANWEI))
                    End With
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
                If objTempFenfafanweiData.Tables.Count < 1 Then
                    Josco.JsKernal.Common.Data.FenfafanweiData.SafeRelease(objTempFenfafanweiData)
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '返回
            objFenfafanweiData = objTempFenfafanweiData
            getFenfafanweiData = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Data.FenfafanweiData.SafeRelease(objTempFenfafanweiData)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '-------------------------------------------------------------------------------------------
        ' 在指定服务器objConnectionProperty指定成员strUserId加入角色(m_objNewDataSet_ChoiceRole)中
        '-------------------------------------------------------------------------------------------
        '     strErrMsg                   ：如果错误，则返回错误信息
        '     objConnectionProperty       ：服务器信息
        '     strUserId                   ：指定成员
        '     m_objNewDataSet_ChoiceRole  ：更新角色数据集
        '     m_objOldDataSet_ChoiceRole  ：原角色数据集
        ' 返回
        '     True                        ：成功
        '     False                       ：失败

        '----------------------------------------------------------------
        Public Function doAddRoleMember( _
            ByRef strErrMsg As String, _
            ByVal objConnectionProperty As Josco.JsKernal.Common.Utilities.ConnectionProperty, _
            ByVal strUserId As String, _
            ByVal m_objNewDataSet_ChoiceRole As Josco.JsKernal.Common.Data.AppManagerData, _
            ByVal m_objOldDataSet_ChoiceRole As Josco.JsKernal.Common.Data.AppManagerData) As Boolean

            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strRoleName As String

            '初始化
            doAddRoleMember = False
            strErrMsg = ""

            Try
                '检查
                If strUserId Is Nothing Then strUserId = ""
                strUserId = strUserId.Trim()
                If objConnectionProperty Is Nothing Then
                    strErrMsg = "错误：未指定服务器参数！"
                    GoTo errProc
                End If

                '获取连接
                With objConnectionProperty

                    'If objdacCommon.getConnection(strErrMsg, objSqlConnection, .UserID, .Password, -1, .InitialCatalog, .DataSource) = False Then
                    '    GoTo errProc
                    'End If
                    If objdacCommon.getConnection(strErrMsg, objSqlConnection, .UserID, .Password, Josco.JsKernal.Common.jsoaConfiguration.ConnectionTestTimeout, .InitialCatalog, .DataSource) = False Then
                        GoTo errProc
                    End If

                End With

                '获取数据
                Dim strSQL As String
                Dim intNewCount As Integer
                Dim intOldCount As Integer
                Dim i As Integer
                Try
                    '创建SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '执行删除操作
                    With m_objOldDataSet_ChoiceRole.Tables(Josco.JsKernal.Common.Data.AppManagerData.TABLE_GL_B_SHUJUKU_JIAOSE)
                        intOldCount = .Rows.Count
                        For i = 0 To intOldCount - 1 Step 1
                            strRoleName = ""
                            strRoleName = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JsKernal.Common.Data.AppManagerData.FIELD_GL_B_SHUJUKU_JIAOSE_NAME), " ")
                            strSQL = "exec sp_droprolemember @rolename, @membername"
                            objSqlCommand.CommandText = strSQL
                            objSqlCommand.Parameters.Clear()
                            objSqlCommand.Parameters.AddWithValue("@rolename", strRoleName)
                            objSqlCommand.Parameters.AddWithValue("@membername", strUserId)
                            objSqlCommand.ExecuteNonQuery()
                        Next i
                    End With

                    '执行加入操作
                    With m_objNewDataSet_ChoiceRole.Tables(Josco.JsKernal.Common.Data.AppManagerData.TABLE_GL_B_SHUJUKU_JIAOSE)
                        intNewCount = .Rows.Count
                        For i = 0 To intNewCount - 1 Step 1
                            If .Rows(i).RowState <> DataRowState.Deleted Then
                                strRoleName = ""
                                strRoleName = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JsKernal.Common.Data.AppManagerData.FIELD_GL_B_SHUJUKU_JIAOSE_NAME), " ")


                                strSQL = "exec sp_addrolemember @rolename, @membername"
                                objSqlCommand.CommandText = strSQL
                                objSqlCommand.Parameters.Clear()
                                objSqlCommand.Parameters.AddWithValue("@rolename", strRoleName)
                                objSqlCommand.Parameters.AddWithValue("@membername", strUserId)
                                objSqlCommand.ExecuteNonQuery()
                            End If
                        Next i
                    End With
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '返回
            doAddRoleMember = True
            Exit Function

            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 保存“公文_B_分发范围”的数据(将成员加入几个常用范围中)
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     objDataSet_ChoiceCYFW     ：新范围数据
        '     objNewData                ：新成员数据
        '     objOldDataSet_ChoiceCYFW  ：旧范围数据
        ' 返回
        '     True                      ：成功
        '     False                     ：失败

        '----------------------------------------------------------------
        Public Function doSaveFenfafanweiData( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objDataSet_ChoiceCYFW As Josco.JsKernal.Common.Data.FenfafanweiData, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objOldDataSet_ChoiceCYFW As Josco.JsKernal.Common.Data.FenfafanweiData) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand

            '初始化
            doSaveFenfafanweiData = False
            strErrMsg = ""

            Try
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""

                '检查
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    strErrMsg = "错误：未传入新的数据！"
                    GoTo errProc
                End If

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                ''开始事务
                'Try
                '    objSqlTransaction = objSqlConnection.BeginTransaction()
                'Catch ex As Exception
                '    strErrMsg = ex.Message
                '    GoTo errProc
                'End Try

                '保存数据
                Dim strSQL As String
                Dim i As Integer
                Dim intOldCount As Integer
                Dim intNewCount As Integer
                Dim intLSH As Integer
                Dim strFWMC As String = ""
                Dim strNewCode As String
                Dim intNewCYWZ As Integer
                Dim strFWBZ As String
                Dim strCYLX As String
                Dim strCYMC As String
                Dim strLXDH As String
                Dim strSJHM As String
                Dim strFTPDZ As String
                Dim strYXDZ As String
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '执行删除操作
                    With objOldDataSet_ChoiceCYFW.Tables(Josco.JsKernal.Common.Data.FenfafanweiData.TABLE_GW_B_FENFAFANWEI)
                        intOldCount = .Rows.Count
                        For i = 0 To intOldCount - 1 Step 1
                            strFWMC = ""
                            strFWMC = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JsKernal.Common.Data.FenfafanweiData.FIELD_GW_B_FENFAFANWEI_FWMC), " ")
                            intLSH = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JsKernal.Common.Data.FenfafanweiData.FIELD_GW_B_FENFAFANWEI_LSH), 0)

                            strSQL = ""
                            strSQL = strSQL + " delete from 公文_B_分发范围 "
                            strSQL = strSQL + " where 流水号 = @lsh"
                            objSqlCommand.Parameters.Clear()
                            objSqlCommand.Parameters.AddWithValue("@lsh", intLSH)
                            objSqlCommand.CommandText = strSQL
                            objSqlCommand.ExecuteNonQuery()
                        Next i
                    End With

                    '执行加入操作
                    With objDataSet_ChoiceCYFW.Tables(Josco.JsKernal.Common.Data.FenfafanweiData.TABLE_GW_B_FENFAFANWEI)
                        intNewCount = .Rows.Count
                        For i = 0 To intNewCount - 1 Step 1
                            If .Rows(i).RowState <> DataRowState.Deleted Then
                                strFWMC = ""
                                strFWMC = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JsKernal.Common.Data.FenfafanweiData.FIELD_GW_B_FENFAFANWEI_FWMC), " ")


                                If objdacCommon.getNewCode(strErrMsg, objSqlConnection, "成员位置", "范围名称", strFWMC, "公文_B_分发范围", True, strNewCode) = False Then
                                    GoTo errProc
                                End If

                                intNewCYWZ = CType(strNewCode, Integer)

                                With objPulicParameters
                                    strFWBZ = CType(Josco.JsKernal.Common.Data.FenfafanweiData.enumFWBZ.CHENGYUAN, Integer).ToString()
                                    strCYLX = .getObjectValue(objNewData(Josco.JsKernal.Common.Data.FenfafanweiData.FIELD_GW_B_FENFAFANWEI_CYLX), " ")
                                    strCYMC = .getObjectValue(objNewData(Josco.JsKernal.Common.Data.FenfafanweiData.FIELD_GW_B_FENFAFANWEI_CYMC), " ")
                                    strLXDH = .getObjectValue(objNewData(Josco.JsKernal.Common.Data.FenfafanweiData.FIELD_GW_B_FENFAFANWEI_LXDH), " ")
                                    strSJHM = .getObjectValue(objNewData(Josco.JsKernal.Common.Data.FenfafanweiData.FIELD_GW_B_FENFAFANWEI_SJHM), " ")
                                    strFTPDZ = .getObjectValue(objNewData(Josco.JsKernal.Common.Data.FenfafanweiData.FIELD_GW_B_FENFAFANWEI_FTPDZ), " ")
                                    strYXDZ = .getObjectValue(objNewData(Josco.JsKernal.Common.Data.FenfafanweiData.FIELD_GW_B_FENFAFANWEI_YXDZ), " ")
                                End With

                                strSQL = ""
                                strSQL = strSQL + " insert into 公文_B_分发范围 (范围名称,范围标志,成员类型,成员名称,成员位置,联系电话,手机号码,FTP地址,邮箱地址)"
                                strSQL = strSQL + " values (@fwmc, @fwbz, @cylx, @cymc, @cywz, @lxdh, @sjhm, @ftpdz, @yxdz)"
                                objSqlCommand.Parameters.Clear()
                                objSqlCommand.Parameters.AddWithValue("@fwmc", strFWMC)
                                objSqlCommand.Parameters.AddWithValue("@fwbz", strFWBZ)
                                objSqlCommand.Parameters.AddWithValue("@cylx", strCYLX)
                                objSqlCommand.Parameters.AddWithValue("@cymc", strCYMC)
                                objSqlCommand.Parameters.AddWithValue("@cywz", intNewCYWZ)
                                objSqlCommand.Parameters.AddWithValue("@lxdh", strLXDH)
                                objSqlCommand.Parameters.AddWithValue("@sjhm", strSJHM)
                                objSqlCommand.Parameters.AddWithValue("@ftpdz", strFTPDZ)
                                objSqlCommand.Parameters.AddWithValue("@yxdz", strYXDZ)
                                objSqlCommand.CommandText = strSQL
                                objSqlCommand.ExecuteNonQuery()
                            End If
                        Next i
                    End With

                Catch ex As Exception
                    'objSqlTransaction.Rollback()
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '提交事务
                'objSqlTransaction.Commit()

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '返回
            doSaveFenfafanweiData = True
            'Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function
        '----------------------------------------------------------------
        ' 检查Login
        '     strErrMsg            ：如果错误，则返回错误信息
        '     blnISNull            ：TRUE-已申请，FALSE-未申请
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strLoginId           ：要检查的loginId
        ' 返回
        '     True                 ：已申请
        '     False                ：未申请

        '----------------------------------------------------------------
        Public Function doCheckId( _
            ByRef strErrMsg As String, _
            ByRef blnISNull As Boolean, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strLoginId As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand
            Dim objDataSet As System.Data.DataSet
            Dim strSQL As String

            '初始化
            doCheckId = False
            strErrMsg = ""
            blnISNull = False

            Try
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strLoginId Is Nothing Then strLoginId = ""
                strUserId = strUserId.Trim()
                strPassword = strPassword.Trim()
                strLoginId = strLoginId.Trim()
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If
                If strLoginId = "" Then
                    strErrMsg = "错误：未指定要注销的Login！"
                    GoTo errProc
                End If
                If strLoginId.ToUpper() = "SA" Then
                    blnISNull = True
                    Exit Try
                End If

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '检查login
                strSQL = ""
                strSQL = strSQL + " select * from master.dbo.syslogins where name='" + strLoginId + "'" + vbCr

                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objDataSet) = False Then
                    GoTo errProc
                End If

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    blnISNull = True
                Else
                    blnISNull = False
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '返回
            doCheckId = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

    End Class
End Namespace

