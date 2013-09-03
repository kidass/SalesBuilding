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

Imports System
Imports System.Data
Imports System.Security.Cryptography
Imports Microsoft.VisualBasic

Imports Josco.JsKernal.SystemFramework
Imports Josco.JsKernal.Common.Data
Imports Josco.JsKernal.BusinessRules
Imports Josco.JSOA.BusinessRules

Namespace Josco.JSOA.BusinessFacade
    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.BusinessFacade
    ' 类名    ：systemEstateRenshiXingye
    '
    ' 功能描述： 
    '   　提供对兴业公司特殊的人事管理处理的表现层支持
    '----------------------------------------------------------------
    Public Class systemEstateRenshiXingye
        Implements System.IDisposable

        Private m_objrulesEstateRenshiXingye As Josco.JSOA.BusinessRules.rulesEstateRenshiXingye

        '----------------------------------------------------------------
        ' 构造函数
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()
            m_objrulesEstateRenshiXingye = New Josco.JSOA.BusinessRules.rulesEstateRenshiXingye
        End Sub

        '----------------------------------------------------------------
        ' 安全释放本身资源
        '----------------------------------------------------------------
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.systemEstateRenshiXingye)
            Try
                If Not (obj Is Nothing) Then
                    obj.Dispose()
                End If
            Catch ex As Exception
            End Try
            obj = Nothing
        End Sub

        '----------------------------------------------------------------
        ' 虚拟析构函数
        '----------------------------------------------------------------
        Public Sub Dispose() Implements System.IDisposable.Dispose
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
            If Not (m_objrulesEstateRenshiXingye Is Nothing) Then
                m_objrulesEstateRenshiXingye.Dispose()
                m_objrulesEstateRenshiXingye = Nothing
            End If
        End Sub









        '----------------------------------------------------------------
        ' 将数据从DataSet导出到Excel
        '     strErrMsg              ：如果错误，则返回错误信息
        '     objDataSet             ：要导出的数据集
        '     strExcelFile           ：导出到WEB服务器中的Excel文件路径
        '     strMacroName           ：宏名列表
        '     strMacroValue          ：宏值列表
        '     strDateFormat          ：日期格式字符串
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
        '----------------------------------------------------------------
        Public Function doExportToExcel( _
            ByRef strErrMsg As String, _
            ByVal objDataSet As System.Data.DataSet, _
            ByVal strExcelFile As String, _
            Optional ByVal strMacroName As String = "", _
            Optional ByVal strMacroValue As String = "", _
            Optional ByVal strDateFormat As String = "") As Boolean
            With Me.m_objrulesEstateRenshiXingye
                doExportToExcel = .doExportToExcel(strErrMsg, objDataSet, strExcelFile, strMacroName, strMacroValue, strDateFormat)
            End With
        End Function

        '----------------------------------------------------------------
        ' 将数据从DataSet导出到Excel
        '     strErrMsg              ：如果错误，则返回错误信息
        '     objDataSet             ：要导出的数据集
        '     strExcelFile           ：导出到WEB服务器中的Excel文件路径
        '     strColorFieldName      ：用来确定行颜色的字段名
        '     objColors              ：字段值对应的颜色集合
        '     strMacroName           ：宏名列表
        '     strMacroValue          ：宏值列表
        '     strDateFormat          ：日期格式字符串
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
        '----------------------------------------------------------------
        Public Function doExportToExcel( _
            ByRef strErrMsg As String, _
            ByVal objDataSet As System.Data.DataSet, _
            ByVal strExcelFile As String, _
            ByVal strColorFieldName As String, _
            ByVal objColors As System.Collections.Specialized.ListDictionary, _
            Optional ByVal strMacroName As String = "", _
            Optional ByVal strMacroValue As String = "", _
            Optional ByVal strDateFormat As String = "") As Boolean
            With Me.m_objrulesEstateRenshiXingye
                doExportToExcel = .doExportToExcel(strErrMsg, objDataSet, strExcelFile, strColorFieldName, objColors, strMacroName, strMacroValue, strDateFormat)
            End With
        End Function

        '----------------------------------------------------------------
        ' 将strSrcFile中的strSrcSheet复制到strDesFile中的strDesSheet
        '     strErrMsg              ：如果错误，则返回错误信息
        '     strSrcFile             ：源文件的完整路径
        '     strSrcSheet            ：源文件的sheet名
        '     strDesFile             ：目标文件的完整路径
        '     strDesSheet            ：目标文件的sheet名
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
        ' 更改描述
        '     zengxianglin 2009-05-18 创建
        '----------------------------------------------------------------
        Public Function doExcelAddCopy( _
            ByRef strErrMsg As String, _
            ByVal strSrcFile As String, _
            ByVal strSrcSheet As String, _
            ByVal strDesFile As String, _
            ByVal strDesSheet As String) As Boolean
            With m_objrulesEstateRenshiXingye
                doExcelAddCopy = .doExcelAddCopy(strErrMsg, strSrcFile, strSrcSheet, strDesFile, strDesSheet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 删除strSrcFile中的strSrcSheet
        '     strErrMsg              ：如果错误，则返回错误信息
        '     strSrcFile             ：源文件的完整路径
        '     strSrcSheet            ：源文件的sheet名
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
        ' 更改描述
        '     zengxianglin 2009-05-18 创建
        '----------------------------------------------------------------
        Public Function doExcelSheetDelete( _
            ByRef strErrMsg As String, _
            ByVal strSrcFile As String, _
            ByVal strSrcSheet As String) As Boolean
            With Me.m_objrulesEstateRenshiXingye
                doExcelSheetDelete = .doExcelSheetDelete(strErrMsg, strSrcFile, strSrcSheet)
            End With
        End Function












        '----------------------------------------------------------------
        ' 获取“地产_B_人事_职级定义”的SQL语句(以“职级代码”升序排序)
        ' 返回
        '                          ：SQL
        '----------------------------------------------------------------
        Public Function getTableSQL_ZhijiDingyi() As String
            With m_objrulesEstateRenshiXingye
                getTableSQL_ZhijiDingyi = .getTableSQL_ZhijiDingyi()
            End With
        End Function

        '----------------------------------------------------------------
        ' 获取“地产_B_人事_职级定义”完全数据的数据集(以“职级代码”升序排序)
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strWhere                  ：搜索字符串
        '     objestateRenshiXingyeData ：信息数据集
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_ZhijiDingyi( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_ZhijiDingyi = .getDataSet_ZhijiDingyi(strErrMsg, strUserId, strPassword, strWhere, objestateRenshiXingyeData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 根据“职级代码”获取“职级名称”
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strZjdm                   ：职级代码
        '     strZjmc                   ：职级名称(返回)
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        '----------------------------------------------------------------
        Public Function getZjmc( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strZjdm As String, _
            ByRef strZjmc As String) As Boolean
            With m_objrulesEstateRenshiXingye
                getZjmc = .getZjmc(strErrMsg, strUserId, strPassword, strZjdm, strZjmc)
            End With
        End Function

        '----------------------------------------------------------------
        ' 保存“地产_B_人事_职级定义”的数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objOldData           ：旧数据
        '     objNewData           ：新数据
        '     objenumEditType      ：编辑类型
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doSaveData_ZhijiDingyi( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean
            With m_objrulesEstateRenshiXingye
                doSaveData_ZhijiDingyi = .doSaveData_ZhijiDingyi(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType)
            End With
        End Function

        '----------------------------------------------------------------
        ' 删除“地产_B_人事_职级定义”的数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objOldData           ：旧数据
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doDeleteData_ZhijiDingyi( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow) As Boolean
            With m_objrulesEstateRenshiXingye
                doDeleteData_ZhijiDingyi = .doDeleteData_ZhijiDingyi(strErrMsg, strUserId, strPassword, objOldData)
            End With
        End Function













        '----------------------------------------------------------------
        ' 计算佣金计提标准-公佣部分
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     objestateRenshiXingyeData ：信息数据集
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_Yjjtbz_GY( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_Yjjtbz_GY = .getDataSet_Yjjtbz_GY(strErrMsg, strUserId, strPassword, objestateRenshiXingyeData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算佣金计提标准-私佣部分-定义的职级列表
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     objestateRenshiXingyeData ：信息数据集
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_Yjjtbz_SYZJ( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_Yjjtbz_SYZJ = .getDataSet_Yjjtbz_SYZJ(strErrMsg, strUserId, strPassword, objestateRenshiXingyeData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算佣金计提标准-私佣部分-定义的各职级指标定义相同的指标列表
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     objestateRenshiXingyeData ：信息数据集
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_Yjjtbz_SYZB( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_Yjjtbz_SYZB = .getDataSet_Yjjtbz_SYZB(strErrMsg, strUserId, strPassword, objestateRenshiXingyeData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 保存佣金计提标准数据
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     objDataSet_GY             ：公佣指标数据集
        '     objDataSet_SYZJ           ：私佣指标数据集-职级部分
        '     objDataSet_SYZB           ：私佣指标数据集-指标部分
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        '----------------------------------------------------------------
        Public Function doSaveData_YongjinJitiBiaozhun( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objDataSet_GY As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByVal objDataSet_SYZJ As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByVal objDataSet_SYZB As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                doSaveData_YongjinJitiBiaozhun = .doSaveData_YongjinJitiBiaozhun(strErrMsg, strUserId, strPassword, objDataSet_GY, objDataSet_SYZJ, objDataSet_SYZB)
            End With
        End Function












        '----------------------------------------------------------------
        ' 计算考核指标定义包含的序列数据
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     objestateRenshiXingyeData ：信息数据集
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_Khbz_XL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_Khbz_XL = .getDataSet_Khbz_XL(strErrMsg, strUserId, strPassword, objestateRenshiXingyeData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算定义在指定考核标准序列下的单位数据
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     intZbxl                   ：指标序列(1,2,3三个值)
        '     intDwbz                   ：指定单位标志(1-管理处,3-分行)
        '     objestateRenshiXingyeData ：信息数据集
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_Khbz_DW( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal intZbxl As Integer, _
            ByVal intDwbz As Integer, _
            ByRef objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_Khbz_DW = .getDataSet_Khbz_DW(strErrMsg, strUserId, strPassword, intZbxl, intDwbz, objestateRenshiXingyeData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 保存业绩考核标准数据
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     objDataSet_XL             ：序列数据集
        '     objDataSet_DWFH01         ：指标一定义的分行
        '     objDataSet_DWFH02         ：指标二定义的分行
        '     objDataSet_DWFH03         ：指标三定义的分行
        '     objDataSet_DWGLC01        ：指标一定义的管理处
        '     objDataSet_DWGLC02        ：指标二定义的管理处
        '     objDataSet_DWGLC03        ：指标三定义的管理处
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        '----------------------------------------------------------------
        Public Function doSaveData_KaoheBiaozhun( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objDataSet_XL As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByVal objDataSet_DWFH01 As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByVal objDataSet_DWFH02 As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByVal objDataSet_DWFH03 As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByVal objDataSet_DWGLC01 As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByVal objDataSet_DWGLC02 As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByVal objDataSet_DWGLC03 As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                doSaveData_KaoheBiaozhun = .doSaveData_KaoheBiaozhun(strErrMsg, strUserId, strPassword, objDataSet_XL, objDataSet_DWFH01, objDataSet_DWFH02, objDataSet_DWFH03, objDataSet_DWGLC01, objDataSet_DWGLC02, objDataSet_DWGLC03)
            End With
        End Function










        '----------------------------------------------------------------
        ' 计算指定时间点的人员架构的单位数据
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     objTime                   ：时间点
        '     strWhere                  ：搜索条件
        '     objestateRenshiXingyeData ：信息数据集
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_RYJG_DW( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objTime As System.DateTime, _
            ByVal strWhere As String, _
            ByRef objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_RYJG_DW = .getDataSet_RYJG_DW(strErrMsg, strUserId, strPassword, objTime, strWhere, objestateRenshiXingyeData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算指定时间点的指定单位的人员架构的所有人员数据
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     objTime                   ：时间点
        '     strZZDM                   ：组织代码
        '     strWhere                  ：搜索条件
        '     objestateRenshiXingyeData ：信息数据集
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_RYJG_RY( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objTime As System.DateTime, _
            ByVal strZZDM As String, _
            ByVal strWhere As String, _
            ByRef objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_RYJG_RY = .getDataSet_RYJG_RY(strErrMsg, strUserId, strPassword, objTime, strZZDM, strWhere, objestateRenshiXingyeData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算指定时间点的指定职级列表的人员架构的最大人员数目
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     objTime                   ：时间点
        '     strZJLIST                 ：职级列表(标准SQL列表格式)
        '     intMaxCount               ：最大数目
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        '----------------------------------------------------------------
        Public Function getRYJG_MaxRYSM( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objTime As System.DateTime, _
            ByVal strZJLIST As String, _
            ByRef intMaxCount As Integer) As Boolean
            With m_objrulesEstateRenshiXingye
                getRYJG_MaxRYSM = .getRYJG_MaxRYSM(strErrMsg, strUserId, strPassword, objTime, strZJLIST, intMaxCount)
            End With
        End Function

        '----------------------------------------------------------------
        ' 获取没有在架构中定义的人员列表
        ' 适用于人员管理模式一
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strWhere                  ：搜索条件
        '     objestateRenshiXingyeData ：信息数据集
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_RYJG_RY_NotIn( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_RYJG_RY_NotIn = .getDataSet_RYJG_RY_NotIn(strErrMsg, strUserId, strPassword, strWhere, objestateRenshiXingyeData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 获取在指定时间的管理架构数据集
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     objTime                   ：指定时间
        '     strWhere                  ：搜索条件
        '     objestateRenshiXingyeData ：信息数据集
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_GuanliJiagou( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objTime As System.DateTime, _
            ByVal strWhere As String, _
            ByRef objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_GuanliJiagou = .getDataSet_GuanliJiagou(strErrMsg, strUserId, strPassword, objTime, strWhere, objestateRenshiXingyeData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 获取在指定时间的助理架构数据集
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     objTime                   ：指定时间
        '     strWhere                  ：搜索条件
        '     objestateRenshiXingyeData ：信息数据集
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_ZhuliJiagou( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objTime As System.DateTime, _
            ByVal strWhere As String, _
            ByRef objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_ZhuliJiagou = .getDataSet_ZhuliJiagou(strErrMsg, strUserId, strPassword, objTime, strWhere, objestateRenshiXingyeData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 获取在架构中有定义的人员列表(包括管理架构和助理架构)
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strWhere                  ：搜索条件
        '     objestateRenshiXingyeData ：信息数据集
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_RYJG_RY_In( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_RYJG_RY_In = .getDataSet_RYJG_RY_In(strErrMsg, strUserId, strPassword, strWhere, objestateRenshiXingyeData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 获取在架构中有定义的人员列表(包括管理架构和助理架构)
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strWhere                  ：搜索条件
        '     objRetDataSet             ：信息数据集
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_RYJG_RY_In( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByVal blnOption As Boolean) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_RYJG_RY_In = .getDataSet_RYJG_RY_In(strErrMsg, strUserId, strPassword, strWhere, objestateRenshiXingyeData, blnOption)
            End With
        End Function











        '----------------------------------------------------------------
        ' 获取“地产_B_人事_个人履历”完全数据的数据集(以“人员代码”升序排序)
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strWhere                   ：搜索字符串
        '     objestateRenshiXingyeData  ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_GRLL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_GRLL = .getDataSet_GRLL(strErrMsg, strUserId, strPassword, strWhere, objestateRenshiXingyeData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 获取“地产_B_人事_学习经历”完全数据的数据集(以“开始年月”升序排序)
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strRYDM                    ：人员代码
        '     strWhere                   ：搜索字符串
        '     objestateRenshiXingyeData  ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_GRLL_XXJL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strRYDM As String, _
            ByVal strWhere As String, _
            ByRef objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_GRLL_XXJL = .getDataSet_GRLL_XXJL(strErrMsg, strUserId, strPassword, strRYDM, strWhere, objestateRenshiXingyeData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 获取“地产_B_人事_工作经历”完全数据的数据集(以“开始年月”升序排序)
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strRYDM                    ：人员代码
        '     strWhere                   ：搜索字符串
        '     objestateRenshiXingyeData  ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_GRLL_GZJL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strRYDM As String, _
            ByVal strWhere As String, _
            ByRef objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_GRLL_GZJL = .getDataSet_GRLL_GZJL(strErrMsg, strUserId, strPassword, strRYDM, strWhere, objestateRenshiXingyeData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 保存“地产_B_人事_个人履历”数据记录(整个事务完成)
        '     strErrMsg              ：如果错误，则返回错误信息
        '     strUserId              ：用户标识
        '     strPassword            ：用户密码
        '     objNewData             ：记录新值(返回保存后的新值)
        '     objOldData             ：记录旧值
        '     objenumEditType        ：编辑类型
        '     strUploadFile          ：上载文件的WEB本地完全路径
        '     strAppRoot             ：应用根Http路径(不带/)
        '     strBasePath            ：从应用根到存放地的相对HTTP目录(开头不带/)
        '     objServer              ：服务器对象
        '     objDataSet_XXJL        ：学习经历数据集
        '     objDataSet_GZJL        ：工作经历数据集
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
        '----------------------------------------------------------------
        Public Function doSaveData_GRLL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objOldData As System.Data.DataRow, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType, _
            ByVal strUploadFile As String, _
            ByVal strAppRoot As String, _
            ByVal strBasePath As String, _
            ByVal objServer As System.Web.HttpServerUtility, _
            ByVal objDataSet_XXJL As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByVal objDataSet_GZJL As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                doSaveData_GRLL = .doSaveData_GRLL(strErrMsg, strUserId, strPassword, objNewData, objOldData, objenumEditType, strUploadFile, strAppRoot, strBasePath, objServer, objDataSet_XXJL, objDataSet_GZJL)
            End With
        End Function

        '----------------------------------------------------------------
        ' 删除“地产_B_人事_个人履历”记录及相关记录
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：连接用户名
        '     strPassword          ：连接用户密码
        '     strWYBS              ：要删除的唯一标识
        '     objServer            ：System.Web.HttpServerUtility
        '     strHttpPathPrefix    ：Http目录前缀部分(末尾=/)
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doDeleteData_GRLL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWYBS As String, _
            ByVal objServer As System.Web.HttpServerUtility, _
            ByVal strHttpPathPrefix As String) As Boolean
            With m_objrulesEstateRenshiXingye
                doDeleteData_GRLL = .doDeleteData_GRLL(strErrMsg, strUserId, strPassword, strWYBS, objServer, strHttpPathPrefix)
            End With
        End Function

        '----------------------------------------------------------------
        ' 获取简历编号搜索SQL
        '----------------------------------------------------------------
        Public Function getSearchSQL_JLBH() As String
            With m_objrulesEstateRenshiXingye
                getSearchSQL_JLBH = .getSearchSQL_JLBH()
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算指定人员在指定时间点的所有下属人员
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strRYDM              ：人员代码
        '     objJCSJ              ：时间点
        '     objXJRY              ：下属人员的代码列表
        ' 返回
        '     True                 ：合法
        '     False                ：不合法或其他程序错误
        '----------------------------------------------------------------
        Public Function getAllXiashuRenyuan( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strRYDM As String, _
            ByVal objJCSJ As System.DateTime, _
            ByRef objXJRY As System.Collections.Specialized.NameValueCollection) As Boolean
            With m_objrulesEstateRenshiXingye
                getAllXiashuRenyuan = .getAllXiashuRenyuan(strErrMsg, strUserId, strPassword, strRYDM, objJCSJ, objXJRY)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算指定人员在指定时间点的所有担任行政助理的单位列表
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strRYDM              ：人员代码
        '     objJCSJ              ：时间点
        '     objDWLB              ：单位列表
        ' 返回
        '     True                 ：合法
        '     False                ：不合法或其他程序错误
        '----------------------------------------------------------------
        Public Function getAllXingzhengZhuliDanwei( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strRYDM As String, _
            ByVal objJCSJ As System.DateTime, _
            ByRef objDWLB As System.Collections.Specialized.NameValueCollection) As Boolean
            With m_objrulesEstateRenshiXingye
                getAllXingzhengZhuliDanwei = .getAllXingzhengZhuliDanwei(strErrMsg, strUserId, strPassword, strRYDM, objJCSJ, objDWLB)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算指定人员在指定时间点的所担任的职级
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strRYDM              ：人员代码
        '     objJCSJ              ：时间点
        '     strZJDM              ：职级代码
        '     strZJMC              ：职级名称
        ' 返回
        '     True                 ：合法
        '     False                ：不合法或其他程序错误
        '----------------------------------------------------------------
        Public Function getRenyuanZhiji( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strRYDM As String, _
            ByVal objJCSJ As System.DateTime, _
            ByRef strZJDM As String, _
            ByRef strZJMC As String) As Boolean
            With m_objrulesEstateRenshiXingye
                getRenyuanZhiji = .getRenyuanZhiji(strErrMsg, strUserId, strPassword, strRYDM, objJCSJ, strZJDM, strZJMC)
            End With
        End Function

        '----------------------------------------------------------------
        ' 按指定信息将人员从架构中注销
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objEnvInfo           ：变动通用参数（BDLX,BDSJ,BDYY,BDYYMC）
        '     objMainInfo          ：主变动人当前人员架构参数
        '     objDataSet_XJ        ：受影响的直接下属调整后的信息
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        ' 更改备注
        '     zengxianglin 2008-10-14创建
        '----------------------------------------------------------------
        Public Function doDelete_RenyuanJiagou( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objEnvInfo As System.Collections.Specialized.NameValueCollection, _
            ByVal objMainInfo As System.Data.DataRow, _
            ByVal objDataSet_XJ As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                doDelete_RenyuanJiagou = .doDelete_RenyuanJiagou(strErrMsg, strUserId, strPassword, objEnvInfo, objMainInfo, objDataSet_XJ)
            End With
        End Function

        '----------------------------------------------------------------
        ' 检查入职输入的时间有效性
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     intRYLX              ：人员类型(1-业务人员，0-行政助理
        '     strRYDM              ：人员代码
        '     strRYMC              ：人员名称
        '     strSSDW              ：所属单位代码
        '     strBDSJ              ：变动时间
        '     blnValid             ：返回True-有效 False-无效
        ' 返回
        '     True                 ：合法
        '     False                ：不合法或其他程序错误
        ' 变更说明
        '     zengxianglin 2008-10-14 创建
        '----------------------------------------------------------------
        Public Function doValidParamsJG_Add( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal intRYLX As Integer, _
            ByVal strRYDM As String, _
            ByVal strRYMC As String, _
            ByVal strSSDW As String, _
            ByVal strBDSJ As String, _
            ByRef blnValid As Boolean) As Boolean
            With m_objrulesEstateRenshiXingye
                doValidParamsJG_Add = .doValidParamsJG_Add(strErrMsg, strUserId, strPassword, intRYLX, strRYDM, strRYMC, strSSDW, strBDSJ, blnValid)
            End With
        End Function

        '----------------------------------------------------------------
        ' 按指定的信息调整人员架构
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objEnvInfo           ：变动通用参数（BDSJ,BDYY,BDYYMC）
        '     objOldData           ：主变动人旧数据
        '     objNewData           ：主变动人新数据
        '     objDataSet_XJ        ：要调整的下级人员信息列表
        '     objDataSet_TDZH      ：团队组合缓存数据
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        ' 更改
        '     zengxianglin 2008-10-14 创建
        '     zengxianglin 2010-01-05 更新
        '----------------------------------------------------------------
        Public Function doAdjust_RenyuanJiagou( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objEnvInfo As System.Collections.Specialized.NameValueCollection, _
            ByVal objOldData As System.Data.DataRow, _
            ByVal objNewData As System.Data.DataRow, _
            ByVal objDataSet_XJ As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByVal objDataSet_TDZH As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                doAdjust_RenyuanJiagou = .doAdjust_RenyuanJiagou(strErrMsg, strUserId, strPassword, objEnvInfo, objOldData, objNewData, objDataSet_XJ, objDataSet_TDZH)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算指定时间点的指定职级序列集中各序列的人员架构的最大人员数目数据集
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     objTime                   ：时间点
        '     strZJLIST                 ：职级列表(标准SQL列表格式)
        '     objRetDataSet             ：最大人员数目数据集
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        ' 更改描述
        '     zengxianglin 2008-10-14 创建
        '----------------------------------------------------------------
        Public Function getRYJG_MaxRYSM( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objTime As System.DateTime, _
            ByVal strZJLIST As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getRYJG_MaxRYSM = .getRYJG_MaxRYSM(strErrMsg, strUserId, strPassword, objTime, strZJLIST, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 获取在架构中有定义的人员列表(仅含管理架构中的人员)
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     blnOnlyGLJG               ：接口重载
        '     strWhere                  ：搜索条件
        '     objRetDataSet             ：信息数据集
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        ' 更改描述
        '     zengxianglin 2008-10-14 创建
        '----------------------------------------------------------------
        Public Function getDataSet_RYJG_RY_In( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal blnOnlyGLJG As Boolean, _
            ByVal strWhere As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_RYJG_RY_In = .getDataSet_RYJG_RY_In(strErrMsg, strUserId, strPassword, blnOnlyGLJG, strWhere, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 获取在架构中有定义的人员列表(包括管理架构和助理架构)
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strWhere                  ：搜索条件
        '     objRetDataSet             ：(返回)信息数据集
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        ' 更改描述
        '     zengxianglin 2008-10-14 创建
        '----------------------------------------------------------------
        Public Function getDataSet_RYJG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_RYJG = .getDataSet_RYJG(strErrMsg, strUserId, strPassword, strWhere, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 保存“地产_B_人事_管理架构”或“地产_B_人事_助理架构”数据记录(整个事务完成)
        ' 适用管理模式一、二
        '     strErrMsg              ：如果错误，则返回错误信息
        '     strUserId              ：用户标识
        '     strPassword            ：用户密码
        '     objNewData             ：记录新值(TABLE_DC_V_RS_RENYUANJIAGOU记录格式)
        '     objOldData             ：记录旧值(TABLE_DC_V_RS_RENYUANJIAGOU记录格式)
        '     objenumEditType        ：编辑类型
        '     objDataSet_TDZH        ：团队组合缓存数据
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
        ' 更改描述
        '     zengxianglin 2008-10-14 创建
        '     zengxianglin 2010-01-04 更改
        '----------------------------------------------------------------
        Public Function doSaveData_RYJG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objNewData As System.Data.DataRow, _
            ByVal objOldData As System.Data.DataRow, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType, _
            ByVal objDataSet_TDZH As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                doSaveData_RYJG = .doSaveData_RYJG(strErrMsg, strUserId, strPassword, objNewData, objOldData, objenumEditType, objDataSet_TDZH)
            End With
        End Function

        '----------------------------------------------------------------
        ' 删除“地产_B_人事_管理架构”或“地产_B_人事_助理架构”记录及相关记录
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：连接用户名
        '     strPassword          ：连接用户密码
        '     objOldData           ：记录旧值(TABLE_DC_V_RS_RENYUANJIAGOU记录格式)
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        ' 更改描述
        '     zengxianglin 2008-10-14 创建
        '----------------------------------------------------------------
        Public Function doDeleteData_RYJG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow) As Boolean
            With m_objrulesEstateRenshiXingye
                doDeleteData_RYJG = .doDeleteData_RYJG(strErrMsg, strUserId, strPassword, objOldData)
            End With
        End Function










        '----------------------------------------------------------------
        ' 将[人员架构]中的[所属单位]、[所属分组]同步到[公共_B_人员]
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：连接用户名
        '     strPassword          ：连接用户密码
        '     strJCSJ              ：检测时间
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        ' 更改描述
        '     zengxianglin 2008-11-18 创建
        '----------------------------------------------------------------
        Public Function doTongbuRyxx( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strJCSJ As String) As Boolean
            With m_objrulesEstateRenshiXingye
                doTongbuRyxx = .doTongbuRyxx(strErrMsg, strUserId, strPassword, strJCSJ)
            End With
        End Function

        '----------------------------------------------------------------
        ' 获取指定时间的人员架构报表的所有数据
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strJCSJ                    ：检测时间
        '     objRetDataSet              ：数据集(返回)
        '                        table(0)：报表参数
        '                        table(1)：索引数据
        '                        table(2)：业务经理
        '                        table(3)：营业经理
        '                        table(4)：区域经理
        '                        table(5)：区域总监
        '                        table(6)：管理架构
        '                        table(7)：助理架构
        '                        table(8)：单位信息
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改描述
        '     zengxianglin 2008-11-18 创建
        '----------------------------------------------------------------
        Public Function getDataSet_RYJG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strJCSJ As String, _
            ByRef objRetDataSet As System.Data.DataSet) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_RYJG = .getDataSet_RYJG(strErrMsg, strUserId, strPassword, strJCSJ, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 获取指定人员在指定时间可操作的部门SQL列表
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strRYDM              ：人员代码
        '     strJCSJ              ：检测时间
        '     strList              ：返回部门SQL列表
        '     blnSFFH              ：返回是否售楼部人员
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        ' 更改描述
        '     zengxianglin 2008-11-22 创建
        '----------------------------------------------------------------
        Public Function getBumenSqlList( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strRYDM As String, _
            ByVal strJCSJ As String, _
            ByRef strList As String, _
            ByRef blnSFFH As Boolean) As Boolean
            With m_objrulesEstateRenshiXingye
                getBumenSqlList = .getBumenSqlList(strErrMsg, strUserId, strPassword, strRYDM, strJCSJ, strList, blnSFFH)
            End With
        End Function

        '----------------------------------------------------------------
        ' 获取指定人员在指定时间所在部门以及管理的部门SQL列表
        ' 如果碰到不是分行的单位，则终止搜索
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strRYDM              ：人员代码
        '     strJCSJ              ：检测时间
        '     blnSZBM_GLBM         ：接口重载
        '     strList              ：返回部门SQL列表
        '     blnSFFH              ：返回是否售楼部人员
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        ' 更改描述
        '     zengxianglin 2008-11-22 创建
        '----------------------------------------------------------------
        Public Function getBumenSqlList( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strRYDM As String, _
            ByVal strJCSJ As String, _
            ByVal blnSZBM_GLBM As Boolean, _
            ByRef strList As String, _
            ByRef blnSFFH As Boolean) As Boolean
            With m_objrulesEstateRenshiXingye
                getBumenSqlList = .getBumenSqlList(strErrMsg, strUserId, strPassword, strRYDM, strJCSJ, blnSZBM_GLBM, strList, blnSFFH)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算指定部门指定年、季度的正式职工业绩考核数据
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strBMDM                    ：统计部门
        '     intND                      ：考核年度
        '     intJD                      ：考核季度
        '     intYJZR                    ：月截止日
        '     strCHCR                    ：换行字符串
        '     objRetDataSet              ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改描述
        '     zengxianglin 2008-12-08 创建
        '----------------------------------------------------------------
        Public Function getDataSet_BB_RSRYKH_ZSZG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strBMDM As String, _
            ByVal intND As Integer, _
            ByVal intJD As Integer, _
            ByVal intYJZR As Integer, _
            ByVal strCHCR As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_BB_RSRYKH_ZSZG = .getDataSet_BB_RSRYKH_ZSZG(strErrMsg, strUserId, strPassword, strBMDM, intND, intJD, intYJZR, strCHCR, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 输出正式职工的考核报表
        '     strErrMsg              ：如果错误，则返回错误信息
        '     strUserId              ：用户标识
        '     strPassword            ：用户密码
        '     strBMDM                ：考核单位代码
        '     intND                  ：考核年度
        '     intJD                  ：考核季度
        '     intYJZR                ：月截止日
        '     objDataSet             ：要导出的数据集
        '     strExcelFile           ：导出到WEB服务器中的Excel文件路径
        '     strMacroName           ：宏名列表
        '     strMacroValue          ：宏值列表
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
        ' 更改描述
        '     zengxianglin 2008-11-09 创建
        '----------------------------------------------------------------
        Public Function doPrint_BB_RSRYKH_ZSZG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strBMDM As String, _
            ByVal intND As Integer, _
            ByVal intJD As Integer, _
            ByVal intYJZR As Integer, _
            ByVal objDataSet As System.Data.DataSet, _
            ByVal strExcelFile As String, _
            Optional ByVal strMacroName As String = "", _
            Optional ByVal strMacroValue As String = "") As Boolean
            With m_objrulesEstateRenshiXingye
                doPrint_BB_RSRYKH_ZSZG = .doPrint_BB_RSRYKH_ZSZG(strErrMsg, strUserId, strPassword, strBMDM, intND, intJD, intYJZR, objDataSet, strExcelFile, strMacroName, strMacroValue)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算指定人员、指定时间段内的试用期职工考核数据
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strRYDM                    ：考核人员
        '     strKSRQ                    ：开始日期
        '     strZZRQ                    ：终止日期
        '     intSYQY                    ：试用期(月)
        '     objRetDataSet              ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改描述
        '     zengxianglin 2008-12-08 创建
        '----------------------------------------------------------------
        Public Function getDataSet_BB_RSRYKH_SYZG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strRYDM As String, _
            ByVal strKSRQ As String, _
            ByVal strZZRQ As String, _
            ByVal intSYQY As Integer, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_BB_RSRYKH_SYZG = .getDataSet_BB_RSRYKH_SYZG(strErrMsg, strUserId, strPassword, strRYDM, strKSRQ, strZZRQ, intSYQY, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算指定时间段内的发生试用的人员数据
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strKSRQ                    ：开始日期
        '     strZZRQ                    ：终止日期
        '     intSYQY                    ：试用期(月)
        '     objRetDataSet              ：信息数据集(Table(0))
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改描述
        '     zengxianglin 2008-12-08 创建
        '----------------------------------------------------------------
        Public Function getDataSet_BB_RSRYKH_SYZG_RY( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strKSRQ As String, _
            ByVal strZZRQ As String, _
            ByVal intSYQY As Integer, _
            ByRef objRetDataSet As System.Data.DataSet) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_BB_RSRYKH_SYZG_RY = .getDataSet_BB_RSRYKH_SYZG_RY(strErrMsg, strUserId, strPassword, strKSRQ, strZZRQ, intSYQY, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 获取新的“简历编号”
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strJLBH              ：简历编号
        ' 返回
        '     True                 ：合法
        '     False                ：不合法或其他程序错误
        ' 更改记录：
        '     zengxianglin 2009-05-14 更改
        '----------------------------------------------------------------
        Public Function getNewJLBH( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef strJLBH As String) As Boolean
            With m_objrulesEstateRenshiXingye
                getNewJLBH = .getNewJLBH(strErrMsg, strUserId, strPassword, strJLBH)
            End With
        End Function







        '----------------------------------------------------------------
        ' 增加“地产_B_人事_管理架构”的新数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objNewData           ：新数据
        '     strYDYY              ：变动原因代码
        '     blnSFJZ              ：True-兼职,False-不是兼职
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doAddNew_GuanliJiagou( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal strYDYY As String, _
            ByVal blnSFJZ As Boolean) As Boolean
            With m_objrulesEstateRenshiXingye
                doAddNew_GuanliJiagou = .doAddNew_GuanliJiagou(strErrMsg, strUserId, strPassword, objNewData, strYDYY, blnSFJZ)
            End With
        End Function


        '----------------------------------------------------------------
        ' 增加“地产_B_人事_管理架构”的新数据
        ' 适用于管理模式一、二
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objNewData           ：新数据
        '     strYDYY              ：变动原因代码
        '     blnSFJZ              ：True-兼职,False-不是兼职
        '     objDataSet_TDZH      ：要创建的团队组合数据
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        ' 更改
        '     zengxianglin 2010-01-04 更改
        '     zengxianglin 2009-12-31 重新设计
        '----------------------------------------------------------------
        Public Function doAddNew_GuanliJiagou( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal strYDYY As String, _
            ByVal blnSFJZ As Boolean, _
            ByVal objDataSet_TDZH As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                doAddNew_GuanliJiagou = .doAddNew_GuanliJiagou(strErrMsg, strUserId, strPassword, objNewData, strYDYY, blnSFJZ, objDataSet_TDZH)
            End With
        End Function

        '----------------------------------------------------------------
        ' 增加“地产_B_人事_助理架构”的新数据
        ' 适用于人事管理模式一、二
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objNewData           ：新数据
        '     strYDYY              ：变动原因代码
        '     blnSFJZ              ：True-兼职,False-不是兼职
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        ' 更改
        '     zengxianglin 2010-01-04 更改
        '     zengxianglin 2009-12-31 重新设计
        '----------------------------------------------------------------
        Public Function doAddNew_ZhuliJiagou( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal strYDYY As String, _
            ByVal blnSFJZ As Boolean) As Boolean
            With m_objrulesEstateRenshiXingye
                doAddNew_ZhuliJiagou = .doAddNew_ZhuliJiagou(strErrMsg, strUserId, strPassword, objNewData, strYDYY, blnSFJZ)
            End With
        End Function













        '----------------------------------------------------------------
        ' 计算指定时间执行的人员管理模式
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strJCSJ                   ：检测时间
        '     intBZXL                   ：标准序列(返回)
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        ' 更改记录
        '     zengxianglin 2009-12-29 创建
        '----------------------------------------------------------------
        Public Function getBZXL_RSJG( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strJCSJ As String, _
            ByRef intBZXL As Integer) As Boolean
            With m_objrulesEstateRenshiXingye
                getBZXL_RSJG = .getBZXL_RSJG(strErrMsg, strUserId, strPassword, strJCSJ, intBZXL)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算strZBBS指定的团队组合数据(如果数据库中不存在,则从缓存数据集中检索)
        ' 适用于人员管理模式二
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strZBBS                   ：组别标识
        '     objBufDataSet             ：缓存数据集
        '     objRetDataSet             ：信息数据集
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        ' 更改记录
        '     zengxianglin 2009-12-29 创建
        '----------------------------------------------------------------
        Public Function getDataSet_TDZH( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strZBBS As String, _
            ByVal objBufDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_TDZH = .getDataSet_TDZH(strErrMsg, strUserId, strPassword, strZBBS, objBufDataSet, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算指定时间生效的团队列表
        ' 适用于人员管理模式二
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strJCSJ                   ：检测时间
        '     strWhere                  ：搜索条件
        '     objRetDataSet             ：信息数据集
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        ' 更改记录
        '     zengxianglin 2009-12-29 创建
        '----------------------------------------------------------------
        Public Function getDataSet_TEAM( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strJCSJ As String, _
            ByVal strWhere As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_TEAM = .getDataSet_TEAM(strErrMsg, strUserId, strPassword, strJCSJ, strWhere, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 检查入职输入的时间有效性
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     intRYLX              ：人员类型(1-业务人员，0-行政助理)
        '     strRYDM              ：人员代码
        '     strRYMC              ：人员名称
        '     strSSDW              ：所属单位代码
        '     strBDSJ              ：变动时间
        '     blnValid             ：返回True-有效 False-无效
        ' 返回
        '     True                 ：合法
        '     False                ：不合法或其他程序错误
        ' 变更说明
        '     zengxianglin 2009-12-31 创建
        '----------------------------------------------------------------
        Public Function doValidParamsJG_Add_X2( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal intRYLX As Integer, _
            ByVal strRYDM As String, _
            ByVal strRYMC As String, _
            ByVal strSSDW As String, _
            ByVal strBDSJ As String, _
            ByRef blnValid As Boolean) As Boolean
            With m_objrulesEstateRenshiXingye
                doValidParamsJG_Add_X2 = .doValidParamsJG_Add_X2(strErrMsg, strUserId, strPassword, intRYLX, strRYDM, strRYMC, strSSDW, strBDSJ, blnValid)
            End With
        End Function

        '----------------------------------------------------------------
        ' 获取指定时间的人员架构报表的所有数据
        ' 适用于人事管理模式二
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strJCSJ                    ：检测时间
        '     objRetDataSet              ：数据集(返回)
        '                        table(0)：报表参数
        '                        table(1)：索引数据
        '                        table(2)：业务经理
        '                        table(3)：营业经理协管
        '                        table(4)：营业经理直管
        '                        table(5)：区域经理
        '                        table(6)：区域总监
        '                        table(7)：管理架构
        '                        table(8)：助理架构
        '                        table(9)：单位信息
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改描述
        '     zengxianglin 2010-01-01 创建
        '----------------------------------------------------------------
        Public Function getDataSet_RYJG_X2( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strJCSJ As String, _
            ByRef objRetDataSet As System.Data.DataSet) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_RYJG_X2 = .getDataSet_RYJG_X2(strErrMsg, strUserId, strPassword, strJCSJ, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 获取[地产_B_人事_考核标准_X2_精英]数据
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strWhere                  ：搜索条件
        '     objRetDataSet             ：信息数据集
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        ' 更改记录
        '     zengxianglin 2010-01-13 创建
        '----------------------------------------------------------------
        Public Function getDataSet_X2_KHBZ_JY( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_X2_KHBZ_JY = .getDataSet_X2_KHBZ_JY(strErrMsg, strUserId, strPassword, strWhere, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 获取[地产_B_人事_考核标准_X2_管理]数据
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strWhere                  ：搜索条件
        '     objRetDataSet             ：信息数据集
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        ' 更改记录
        '     zengxianglin 2010-01-13 创建
        '----------------------------------------------------------------
        Public Function getDataSet_X2_KHBZ_GL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_X2_KHBZ_GL = .getDataSet_X2_KHBZ_GL(strErrMsg, strUserId, strPassword, strWhere, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 完整事务保存
        '     [地产_B_人事_考核标准_X2_精英]
        '     [地产_B_人事_考核标准_X2_管理]
        ' 数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objDataSet_JY        ：要保存的[地产_B_人事_考核标准_X2_精英]
        '     objDataSet_GL        ：要保存的[地产_B_人事_考核标准_X2_管理]
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        ' 更改
        '     zengxianglin 2010-01-13 创建
        '----------------------------------------------------------------
        Public Function doSave_X2_KHBZ( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objDataSet_JY As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByVal objDataSet_GL As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                doSave_X2_KHBZ = .doSave_X2_KHBZ(strErrMsg, strUserId, strPassword, objDataSet_JY, objDataSet_GL)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算业务精英的季度考核结果
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strJDKS                   ：考核季度开始日期
        '     strJDJS                   ：考核季度结束日期
        '     strWhere                  ：搜索条件
        '     objRetDataSet             ：信息数据集
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        ' 更改
        '     zengxianglin 2010-01-13 创建
        '     zengxianglin 2010-05-06 更改(指定年度、季度、月截止日 -> 季度开始日期、季度结束日期)
        '----------------------------------------------------------------
        Public Function getDataSet_TJBB_X2_KHJG_JY( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strJDKS As String, _
            ByVal strJDJS As String, _
            ByVal strWhere As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_TJBB_X2_KHJG_JY = .getDataSet_TJBB_X2_KHJG_JY(strErrMsg, strUserId, strPassword, strJDKS, strJDJS, strWhere, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算业务主管的季度考核结果
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strJDKS                   ：考核季度开始日期
        '     strJDJS                   ：考核季度结束日期
        '     strWhere                  ：搜索条件
        '     objRetDataSet             ：信息数据集
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        ' 更改记录
        '     zengxianglin 2010-01-13 创建
        '     zengxianglin 2010-05-06 更改(指定年度、季度、月截止日 -> 季度开始日期、季度结束日期)
        '----------------------------------------------------------------
        Public Function getDataSet_TJBB_X2_KHJG_GL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strJDKS As String, _
            ByVal strJDJS As String, _
            ByVal strWhere As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_TJBB_X2_KHJG_GL = .getDataSet_TJBB_X2_KHJG_GL(strErrMsg, strUserId, strPassword, strJDKS, strJDJS, strWhere, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算佣金计提标准-公佣直提部分
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     objestateRenshiXingyeData ：信息数据集
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        ' 更改
        '     lijie 2010-1-17 创建
        '----------------------------------------------------------------
        Public Function getDataSet_Yjjtbz_GYZT( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_Yjjtbz_GYZT = .getDataSet_Yjjtbz_GYZT(strErrMsg, strUserId, strPassword, objestateRenshiXingyeData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算佣金计提标准-公佣协管部分
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     objestateRenshiXingyeData ：信息数据集
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        ' 更改
        '     lijie 2010-1-17 创建
        '----------------------------------------------------------------
        Public Function getDataSet_Yjjtbz_GYXGZB( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_Yjjtbz_GYXGZB = .getDataSet_Yjjtbz_GYXGZB(strErrMsg, strUserId, strPassword, objestateRenshiXingyeData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算佣金计提标准-公佣直管标准部分
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     objestateRenshiXingyeData ：信息数据集
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        ' 更改
        '     lijie 2010-1-17 创建
        '----------------------------------------------------------------
        Public Function getDataSet_Yjjtbz_GYZGZB( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByVal strWhere As String) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_Yjjtbz_GYZGZB = .getDataSet_Yjjtbz_GYZGZB(strErrMsg, strUserId, strPassword, objestateRenshiXingyeData, strWhere)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算佣金计提标准-公佣直管职级标准部分
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     objestateRenshiXingyeData ：信息数据集
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        ' 更改
        '     lijie 2010-1-17 创建
        '----------------------------------------------------------------
        Public Function getDataSet_Yjjtbz_GYZG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_Yjjtbz_GYZG = .getDataSet_Yjjtbz_GYZG(strErrMsg, strUserId, strPassword, objestateRenshiXingyeData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算佣金计提标准-私佣标准部分
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     objestateRenshiXingyeData ：信息数据集
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        ' 更改
        '     lijie 2010-1-17 创建
        '----------------------------------------------------------------
        Public Function getDataSet_Yjjtbz_SY( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_Yjjtbz_SY = .getDataSet_Yjjtbz_SY(strErrMsg, strUserId, strPassword, objestateRenshiXingyeData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 保存地产_B_人事_佣金标准_X2_私佣计提标准数据
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     objDataSet_SYZB           ：私佣指标数据集-指标部分
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        ' 更改
        '     lijie 2010-1-17 创建
        '----------------------------------------------------------------
        Public Function doSaveData_YongjinJitiBiaozhun_SY( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objDataSet_SYZB As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                doSaveData_YongjinJitiBiaozhun_SY = .doSaveData_YongjinJitiBiaozhun_SY(strErrMsg, strUserId, strPassword, objDataSet_SYZB)
            End With
        End Function

        '----------------------------------------------------------------
        ' 保存地产_B_人事_佣金标准_X2_公佣_直提计提标准数据
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     objDataSet_GYZT           ：直提指标数据集-指标部分
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        ' 更改
        '     lijie 2010-1-17 创建
        '----------------------------------------------------------------
        Public Function doSaveData_YongjinJitiBiaozhun_GYZT( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objDataSet_GYZT As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                doSaveData_YongjinJitiBiaozhun_GYZT = .doSaveData_YongjinJitiBiaozhun_GYZT(strErrMsg, strUserId, strPassword, objDataSet_GYZT)
            End With
        End Function

        '----------------------------------------------------------------
        ' 保存地产_B_人事_佣金标准_X2_公佣_协管计提标准数据
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     objDataSet_GYXGZB         ：协管指标数据集-指标部分
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        ' 更改
        '     lijie 2010-1-17 创建
        '----------------------------------------------------------------
        Public Function doSaveData_YongjinJitiBiaozhun_GYXG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objDataSet_GYXGZB As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                doSaveData_YongjinJitiBiaozhun_GYXG = .doSaveData_YongjinJitiBiaozhun_GYXG(strErrMsg, strUserId, strPassword, objDataSet_GYXGZB)
            End With
        End Function

        '----------------------------------------------------------------
        ' 保存地产_B_人事_佣金标准_X2_公佣_直管计提标准数据
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     objDataSet_GYXGZB         ：直管指标数据集-指标部分
        '     strJJDM                   ：职级代码
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        ' 更改
        '     lijie 2010-1-17 创建
        '----------------------------------------------------------------
        Public Function doSaveData_YongjinJitiBiaozhun_GYZGZB( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objDataSet_GYZGZB As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByVal strJJDM As String) As Boolean
            With m_objrulesEstateRenshiXingye
                doSaveData_YongjinJitiBiaozhun_GYZGZB = .doSaveData_YongjinJitiBiaozhun_GYZGZB(strErrMsg, strUserId, strPassword, objDataSet_GYZGZB, strJJDM)
            End With
        End Function

        '----------------------------------------------------------------
        ' 删除地产_B_人事_佣金标准_X2_公佣_直管计提标准数据
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strJJDM                   ：职级代码
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        ' 更改
        '     lijie 2010-1-17 创建
        '----------------------------------------------------------------
        Public Function doDelete_GYZG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strJJDM As String) As Boolean
            With m_objrulesEstateRenshiXingye
                doDelete_GYZG = .doDelete_GYZG(strErrMsg, strUserId, strPassword, strJJDM)
            End With
        End Function









        '----------------------------------------------------------------
        ' 计算佣金计提标准[X3]-私佣标准部分
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strWhere                  ：搜索条件
        '     objRetDataSet             ：信息数据集
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        ' 更改
        '     zengxianglin 2010-05-04 创建
        '----------------------------------------------------------------
        Public Function getDataSet_YJBZ_X3_SY( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_YJBZ_X3_SY = .getDataSet_YJBZ_X3_SY(strErrMsg, strUserId, strPassword, strWhere, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算佣金计提标准[X3]-直管公佣标准部分的涉及职级数据
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strWhere                  ：搜索条件
        '     objRetDataSet             ：信息数据集
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        ' 更改
        '     zengxianglin 2010-05-04 创建
        '----------------------------------------------------------------
        Public Function getDataSet_YJBZ_X3_GY_ZG_ZJ( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_YJBZ_X3_GY_ZG_ZJ = .getDataSet_YJBZ_X3_GY_ZG_ZJ(strErrMsg, strUserId, strPassword, strWhere, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算佣金计提标准[X3]-直管公佣标准部分的涉及指标数据
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strWhere                  ：搜索条件
        '     objRetDataSet             ：信息数据集
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        ' 更改
        '     zengxianglin 2010-05-04 创建
        '----------------------------------------------------------------
        Public Function getDataSet_YJBZ_X3_GY_ZG_ZB( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_YJBZ_X3_GY_ZG_ZB = .getDataSet_YJBZ_X3_GY_ZG_ZB(strErrMsg, strUserId, strPassword, strWhere, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算佣金计提标准[X3]-协管公佣标准部分
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strWhere                  ：搜索条件
        '     objRetDataSet             ：信息数据集
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        ' 更改
        '     zengxianglin 2010-05-04 创建
        '----------------------------------------------------------------
        Public Function getDataSet_YJBZ_X3_GY_XG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_YJBZ_X3_GY_XG = .getDataSet_YJBZ_X3_GY_XG(strErrMsg, strUserId, strPassword, strWhere, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算佣金计提标准[X3]-直提公佣标准部分的涉及职级数据
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strWhere                  ：搜索条件
        '     objRetDataSet             ：信息数据集
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        ' 更改
        '     zengxianglin 2010-05-04 创建
        '----------------------------------------------------------------
        Public Function getDataSet_YJBZ_X3_GY_ZT_ZJ( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_YJBZ_X3_GY_ZT_ZJ = .getDataSet_YJBZ_X3_GY_ZT_ZJ(strErrMsg, strUserId, strPassword, strWhere, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算佣金计提标准[X3]-直提公佣标准部分的涉及指标数据
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strWhere                  ：搜索条件
        '     objRetDataSet             ：信息数据集
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        ' 更改
        '     zengxianglin 2010-05-04 创建
        '----------------------------------------------------------------
        Public Function getDataSet_YJBZ_X3_GY_ZT_ZB( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_YJBZ_X3_GY_ZT_ZB = .getDataSet_YJBZ_X3_GY_ZT_ZB(strErrMsg, strUserId, strPassword, strWhere, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 保存[地产_B_人事_佣金标准_X3_私佣]
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     objDataSet_SY             ：私佣指标
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        ' 更改
        '     zengxianglin 2010-05-04 创建
        '----------------------------------------------------------------
        Public Function doSaveData_YJBZ_X3_SY( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objDataSet_SY As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                doSaveData_YJBZ_X3_SY = .doSaveData_YJBZ_X3_SY(strErrMsg, strUserId, strPassword, objDataSet_SY)
            End With
        End Function

        '----------------------------------------------------------------
        ' 保存[地产_B_人事_佣金标准_X3_公佣_直管]
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     objDataSet_GY_ZG_ZB       ：指标数据
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        ' 更改
        '     zengxianglin 2010-05-04 创建
        '----------------------------------------------------------------
        Public Function doSaveData_YJBZ_X3_GY_ZG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objDataSet_GY_ZG_ZB As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                doSaveData_YJBZ_X3_GY_ZG = .doSaveData_YJBZ_X3_GY_ZG(strErrMsg, strUserId, strPassword, objDataSet_GY_ZG_ZB)
            End With
        End Function

        '----------------------------------------------------------------
        ' 保存[地产_B_人事_佣金标准_X3_公佣_协管]
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     objDataSet_GY_XG          ：私佣指标
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        ' 更改
        '     zengxianglin 2010-05-04 创建
        '----------------------------------------------------------------
        Public Function doSaveData_YJBZ_X3_GY_XG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objDataSet_GY_XG As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                doSaveData_YJBZ_X3_GY_XG = .doSaveData_YJBZ_X3_GY_XG(strErrMsg, strUserId, strPassword, objDataSet_GY_XG)
            End With
        End Function

        '----------------------------------------------------------------
        ' 保存[地产_B_人事_佣金标准_X3_公佣_直提]
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     objDataSet_GY_ZT_ZB       ：指标数据
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        ' 更改
        '     zengxianglin 2010-05-04 创建
        '----------------------------------------------------------------
        Public Function doSaveData_YJBZ_X3_GY_ZT( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objDataSet_GY_ZT_ZB As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                doSaveData_YJBZ_X3_GY_ZT = .doSaveData_YJBZ_X3_GY_ZT(strErrMsg, strUserId, strPassword, objDataSet_GY_ZT_ZB)
            End With
        End Function












        '----------------------------------------------------------------
        ' 计算佣金计提标准[X4]-私佣标准部分-职级列表
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strWhere                  ：搜索条件
        '     objRetDataSet             ：信息数据集
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        ' 更改
        '     zengxianglin 2011-01-10 创建
        '----------------------------------------------------------------
        Public Function getDataSet_YJBZ_X4_SY_ZJ( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_YJBZ_X4_SY_ZJ = .getDataSet_YJBZ_X4_SY_ZJ(strErrMsg, strUserId, strPassword, strWhere, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算佣金计提标准[X4]-私佣标准部分-全部数据
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strWhere                  ：搜索条件
        '     objRetDataSet             ：信息数据集
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        ' 更改
        '     zengxianglin 2011-01-10 创建
        '----------------------------------------------------------------
        Public Function getDataSet_YJBZ_X4_SY( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_YJBZ_X4_SY = .getDataSet_YJBZ_X4_SY(strErrMsg, strUserId, strPassword, strWhere, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算佣金计提标准[X4]-直管公佣标准部分-职级列表
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strWhere                  ：搜索条件
        '     objRetDataSet             ：信息数据集
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        ' 更改
        '     zengxianglin 2011-01-10 创建
        '----------------------------------------------------------------
        Public Function getDataSet_YJBZ_X4_GY_ZG_ZJ( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_YJBZ_X4_GY_ZG_ZJ = .getDataSet_YJBZ_X4_GY_ZG_ZJ(strErrMsg, strUserId, strPassword, strWhere, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算佣金计提标准[X4]-直管公佣标准部分-全部数据
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strWhere                  ：搜索条件
        '     objRetDataSet             ：信息数据集
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        ' 更改
        '     zengxianglin 2011-01-10 创建
        '----------------------------------------------------------------
        Public Function getDataSet_YJBZ_X4_GY_ZG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_YJBZ_X4_GY_ZG = .getDataSet_YJBZ_X4_GY_ZG(strErrMsg, strUserId, strPassword, strWhere, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算佣金计提标准[X4]-协管公佣标准部分-职级列表
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strWhere                  ：搜索条件
        '     objRetDataSet             ：信息数据集
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        ' 更改
        '     zengxianglin 2011-01-10 创建
        '----------------------------------------------------------------
        Public Function getDataSet_YJBZ_X4_GY_XG_ZJ( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_YJBZ_X4_GY_XG_ZJ = .getDataSet_YJBZ_X4_GY_XG_ZJ(strErrMsg, strUserId, strPassword, strWhere, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算佣金计提标准[X4]-协管公佣标准部分-全部数据
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strWhere                  ：搜索条件
        '     objRetDataSet             ：信息数据集
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        ' 更改
        '     zengxianglin 2011-01-10 创建
        '----------------------------------------------------------------
        Public Function getDataSet_YJBZ_X4_GY_XG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_YJBZ_X4_GY_XG = .getDataSet_YJBZ_X4_GY_XG(strErrMsg, strUserId, strPassword, strWhere, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算佣金计提标准[X4]-直接计提公佣标准部分-职级列表
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strWhere                  ：搜索条件
        '     objRetDataSet             ：信息数据集
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        ' 更改
        '     zengxianglin 2011-01-10 创建
        '----------------------------------------------------------------
        Public Function getDataSet_YJBZ_X4_GY_ZT_ZJ( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_YJBZ_X4_GY_ZT_ZJ = .getDataSet_YJBZ_X4_GY_ZT_ZJ(strErrMsg, strUserId, strPassword, strWhere, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算佣金计提标准[X4]-直接计提公佣标准部分-全部数据
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strWhere                  ：搜索条件
        '     objRetDataSet             ：信息数据集
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        ' 更改
        '     zengxianglin 2011-01-10 创建
        '----------------------------------------------------------------
        Public Function getDataSet_YJBZ_X4_GY_ZT( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_YJBZ_X4_GY_ZT = .getDataSet_YJBZ_X4_GY_ZT(strErrMsg, strUserId, strPassword, strWhere, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 保存[地产_B_人事_佣金标准_X4_私佣]
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     objDataSet_SY             ：私佣指标
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        ' 更改
        '     zengxianglin 2011-01-10 创建
        '----------------------------------------------------------------
        Public Function doSaveData_YJBZ_X4_SY( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objDataSet_SY As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                doSaveData_YJBZ_X4_SY = .doSaveData_YJBZ_X4_SY(strErrMsg, strUserId, strPassword, objDataSet_SY)
            End With
        End Function

        '----------------------------------------------------------------
        ' 保存[地产_B_人事_佣金标准_X4_公佣_直管]
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     objDataSet_GY_ZG          ：直管公佣指标
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        ' 更改
        '     zengxianglin 2011-01-10 创建
        '----------------------------------------------------------------
        Public Function doSaveData_YJBZ_X4_GY_ZG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objDataSet_GY_ZG As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                doSaveData_YJBZ_X4_GY_ZG = .doSaveData_YJBZ_X4_GY_ZG(strErrMsg, strUserId, strPassword, objDataSet_GY_ZG)
            End With
        End Function

        '----------------------------------------------------------------
        ' 保存[地产_B_人事_佣金标准_X4_公佣_协管]
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     objDataSet_GY_XG          ：协管公佣指标
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        ' 更改
        '     zengxianglin 2011-01-10 创建
        '----------------------------------------------------------------
        Public Function doSaveData_YJBZ_X4_GY_XG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objDataSet_GY_XG As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                doSaveData_YJBZ_X4_GY_XG = .doSaveData_YJBZ_X4_GY_XG(strErrMsg, strUserId, strPassword, objDataSet_GY_XG)
            End With
        End Function

        '----------------------------------------------------------------
        ' 保存[地产_B_人事_佣金标准_X4_公佣_协管]
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     objDataSet_GY_ZT          ：直接计提公佣指标
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        ' 更改
        '     zengxianglin 2011-01-10 创建
        '----------------------------------------------------------------
        Public Function doSaveData_YJBZ_X4_GY_ZT( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objDataSet_GY_ZT As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                doSaveData_YJBZ_X4_GY_ZT = .doSaveData_YJBZ_X4_GY_ZT(strErrMsg, strUserId, strPassword, objDataSet_GY_ZT)
            End With
        End Function





        '----------------------------------------------------------------
        ' 获取“客户_B_客户类型”的SQL语句(以岗位代码升序排序)
        ' 返回
        '                          ：SQL
        '----------------------------------------------------------------
        Public Function getZhaopinqudaoSQL() As String
            Try
                With New Josco.JSOA.BusinessRules.rulesEstateRenshiXingye
                    getZhaopinqudaoSQL = .getZhaopinqudaoSQL()
                End With
            Catch ex As Exception
                getZhaopinqudaoSQL = ""
            End Try
        End Function

        '----------------------------------------------------------------
        ' 获取“客户_B_客户类型”完全数据的数据集(以岗位代码升序排序)
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strWhere             ：搜索字符串(默认表前缀a.)
        '     objKehuguanliData：岗位代码信息数据集
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function getZhaopinqudaoData( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean

            Try
                With New Josco.JSOA.BusinessRules.rulesEstateRenshiXingye
                    getZhaopinqudaoData = .getZhaopinqudaoData(strErrMsg, strUserId, strPassword, strWhere, objestateRenshiXingyeData)
                End With
            Catch ex As Exception
                getZhaopinqudaoData = False
                strErrMsg = ex.Message
            End Try

        End Function

        '----------------------------------------------------------------
        ' 保存“客户_B_客户类型”的数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objOldData           ：旧数据
        '     objNewData           ：新数据
        '     objenumEditType      ：编辑类型
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doSaveZhaopinqudaoData( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean

            Try
                With New Josco.JSOA.BusinessRules.rulesEstateRenshiXingye
                    doSaveZhaopinqudaoData = .doSaveZhaopinqudaoData(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType)
                End With
            Catch ex As Exception
                doSaveZhaopinqudaoData = False
                strErrMsg = ex.Message
            End Try

        End Function

        '----------------------------------------------------------------
        ' 删除“客户_B_客户类型”的数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objOldData           ：旧数据
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doDeleteZhaopinqudaoData( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow) As Boolean

            Try
                With New Josco.JSOA.BusinessRules.rulesEstateRenshiXingye
                    doDeleteZhaopinqudaoData = .doDeleteZhaopinqudaoData(strErrMsg, strUserId, strPassword, objOldData)
                End With
            Catch ex As Exception
                doDeleteZhaopinqudaoData = False
                strErrMsg = ex.Message
            End Try

        End Function

        '----------------------------------------------------------------
        '获取入职信息的简历编号
        '     strErrMsg      ：如果错误，则返回错误信息
        '     strUserId      ：用户标识
        '     strPassword    ：用户密码
        '     strJLBH        ：简历编号
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Public Function getNewRZJLBH( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef strJLBH As String) As Boolean
            Try
                With New Josco.JSOA.BusinessRules.rulesEstateRenshiXingye
                    getNewRZJLBH = .getNewRZJLBH(strErrMsg, strUserId, strPassword, strJLBH)
                End With
            Catch ex As Exception
                getNewRZJLBH = False
                strErrMsg = ex.Message
            End Try

        End Function

        '----------------------------------------------------------------
        ' 保存不通过“地产_B_人事_入职审批_人员信息”数据
        '     strErrMsg      ：如果错误，则返回错误信息
        '     strUserId      ：用户标识
        '     strPassword    ：用户密码
        '     strWJBS                ：文件标识
        '     objNewData             ：记录新值(返回保存后的新值)
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Public Function doSaveRyxx_BTG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWJBS As String, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection) As Boolean
            Try
                With New Josco.JSOA.BusinessRules.rulesEstateRenshiXingye
                    doSaveRyxx_BTG = .doSaveRyxx_BTG(strErrMsg, strUserId, strPassword, strWJBS, objNewData)
                End With
            Catch ex As Exception
                doSaveRyxx_BTG = False
                strErrMsg = ex.Message
            End Try

        End Function

        '----------------------------------------------------------------
        ' 保存不通过“地产_B_人事_调整审批_人员信息”数据
        '     strErrMsg      ：如果错误，则返回错误信息
        '     strUserId      ：用户标识
        '     strPassword    ：用户密码
        '     strWJBS                ：文件标识
        '     objNewData             ：记录新值(返回保存后的新值)
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Public Function doSaveRyxx_BTG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWJBS As String, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal blnTZ As Boolean) As Boolean

            Try
                With New Josco.JSOA.BusinessRules.rulesEstateRenshiXingye
                    doSaveRyxx_BTG = .doSaveRyxx_BTG(strErrMsg, strUserId, strPassword, strWJBS, objNewData, blnTZ)
                End With
            Catch ex As Exception
                doSaveRyxx_BTG = False
                strErrMsg = ex.Message
            End Try

        End Function

        '----------------------------------------------------------------
        ' 保存不通过“地产_B_人事_离职审批_人员信息”数据
        '     strErrMsg      ：如果错误，则返回错误信息
        '     strUserId      ：用户标识
        '     strPassword    ：用户密码
        '     strWJBS                ：文件标识
        '     objNewData             ：记录新值(返回保存后的新值)
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Public Function doSaveRyxx_BTG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWJBS As String, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal strLZ As String) As Boolean

            Try
                With New Josco.JSOA.BusinessRules.rulesEstateRenshiXingye
                    doSaveRyxx_BTG = .doSaveRyxx_BTG(strErrMsg, strUserId, strPassword, strWJBS, objNewData, strLZ)
                End With
            Catch ex As Exception
                doSaveRyxx_BTG = False
                strErrMsg = ex.Message
            End Try

        End Function

        '----------------------------------------------------------------
        ' 保存不通过“地产_B_人事_实习生审批_人员信息”数据
        '     strErrMsg      ：如果错误，则返回错误信息
        '     strUserId      ：用户标识
        '     strPassword    ：用户密码
        '     strWJBS                ：文件标识
        '     objNewData             ：记录新值(返回保存后的新值)
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Public Function doSaveRyxx_BTG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWJBS As String, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal intSXS As Integer) As Boolean

            Try
                With New Josco.JSOA.BusinessRules.rulesEstateRenshiXingye
                    doSaveRyxx_BTG = .doSaveRyxx_BTG(strErrMsg, strUserId, strPassword, strWJBS, objNewData, intSXS)
                End With
            Catch ex As Exception
                doSaveRyxx_BTG = False
                strErrMsg = ex.Message
            End Try

        End Function

        '----------------------------------------------------------------
        ' 保存通过“地产_B_人事_入职审批_人员信息”数据
        '     strErrMsg      ：如果错误，则返回错误信息
        '     strUserId      ：用户标识
        '     strPassword    ：用户密码
        '     strWJBS                ：文件标识
        '     objNewData             ：记录新值(返回保存后的新值)
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Public Function doSaveRyxx_TG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWJBS As String, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal strLZ As String) As Boolean
            Try
                With New Josco.JSOA.BusinessRules.rulesEstateRenshiXingye
                    doSaveRyxx_TG = .doSaveRyxx_TG(strErrMsg, strUserId, strPassword, strWJBS, objNewData, strLZ)
                End With
            Catch ex As Exception
                doSaveRyxx_TG = False
                strErrMsg = ex.Message
            End Try

        End Function


        '----------------------------------------------------------------
        ' 保存通过“地产_B_人事_入职审批_人员信息”数据
        '     strErrMsg      ：如果错误，则返回错误信息
        '     strUserId      ：用户标识
        '     strPassword    ：用户密码
        '     strWJBS                ：文件标识
        '     objNewData             ：记录新值(返回保存后的新值)
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Public Function doSaveRyxx_TG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWJBS As String, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection) As Boolean
            Try
                With New Josco.JSOA.BusinessRules.rulesEstateRenshiXingye
                    doSaveRyxx_TG = .doSaveRyxx_TG(strErrMsg, strUserId, strPassword, strWJBS, objNewData)
                End With
            Catch ex As Exception
                doSaveRyxx_TG = False
                strErrMsg = ex.Message
            End Try

        End Function

        '----------------------------------------------------------------
        ' 保存通过“地产_B_人事_调整审批_人员信息”数据
        '     strErrMsg      ：如果错误，则返回错误信息
        '     strUserId      ：用户标识
        '     strPassword    ：用户密码
        '     strWJBS                ：文件标识
        '     objNewData             ：记录新值(返回保存后的新值)
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Public Function doSaveRyxx_TG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWJBS As String, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal blnTZ As Boolean) As Boolean
            Try
                With New Josco.JSOA.BusinessRules.rulesEstateRenshiXingye
                    doSaveRyxx_TG = .doSaveRyxx_TG(strErrMsg, strUserId, strPassword, strWJBS, objNewData, blnTZ)
                End With
            Catch ex As Exception
                doSaveRyxx_TG = False
                strErrMsg = ex.Message
            End Try

        End Function

        '----------------------------------------------------------------
        ' 保存通过“地产_B_人事_实习生审批_人员信息”数据
        '     strErrMsg      ：如果错误，则返回错误信息
        '     strUserId      ：用户标识
        '     strPassword    ：用户密码
        '     strWJBS                ：文件标识
        '     objNewData             ：记录新值(返回保存后的新值)
        ' 返回
        '     True           ：成功
        '     False          ：失败
        '----------------------------------------------------------------
        Public Function doSaveRyxx_TG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWJBS As String, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal intSXS As Integer) As Boolean
            Try
                With New Josco.JSOA.BusinessRules.rulesEstateRenshiXingye
                    doSaveRyxx_TG = .doSaveRyxx_TG(strErrMsg, strUserId, strPassword, strWJBS, objNewData, intSXS)
                End With
            Catch ex As Exception
                doSaveRyxx_TG = False
                strErrMsg = ex.Message
            End Try

        End Function


        '----------------------------------------------------------------
        ' 获取审批人员打印数据
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strUserXM                 :打印者姓名
        '     strWhere                  ：搜索条件
        '     objDataSet                ：信息数据集

        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        '----------------------------------------------------------------
        Public Function getPrintRyxxData( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strUserXM As String, _
            ByVal strWhere As String, _
            ByRef objDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean

            Try
                With New Josco.JSOA.BusinessRules.rulesEstateRenshiXingye
                    getPrintRyxxData = .getPrintRyxxData(strErrMsg, strUserId, strPassword, strUserXM, strWhere, objDataSet)
                End With
            Catch ex As Exception
                getPrintRyxxData = False
                strErrMsg = ex.Message
            End Try

        End Function

        '----------------------------------------------------------------
        ' 获取调整审批人员打印数据
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strUserXM                 :打印者姓名
        '     strWhere                  ：搜索条件
        '     objDataSet                ：信息数据集

        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        '----------------------------------------------------------------
        Public Function getPrintRyxxData( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strUserXM As String, _
            ByVal strWhere As String, _
            ByRef objDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByVal strTZ As String) As Boolean

            Try
                With New Josco.JSOA.BusinessRules.rulesEstateRenshiXingye
                    getPrintRyxxData = .getPrintRyxxData(strErrMsg, strUserId, strPassword, strUserXM, strWhere, objDataSet, strTZ)
                End With
            Catch ex As Exception
                getPrintRyxxData = False
                strErrMsg = ex.Message
            End Try

        End Function


        '----------------------------------------------------------------
        ' 获取实习生审批人员打印数据
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strUserXM                 :打印者姓名
        '     strWhere                  ：搜索条件
        '     objDataSet                ：信息数据集

        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        '----------------------------------------------------------------
        Public Function getPrintRyxxData( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strUserXM As String, _
            ByVal strWhere As String, _
            ByRef objDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByVal intSXS As Integer) As Boolean

            Try
                With New Josco.JSOA.BusinessRules.rulesEstateRenshiXingye
                    getPrintRyxxData = .getPrintRyxxData(strErrMsg, strUserId, strPassword, strUserXM, strWhere, objDataSet, intSXS)
                End With
            Catch ex As Exception
                getPrintRyxxData = False
                strErrMsg = ex.Message
            End Try

        End Function

        '----------------------------------------------------------------
        ' 保存团队临时数据
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     objNewData                :准备数据
        '     intZTLX                   :审批状态类型
        '     objDataSet_TDZH           ：团队数据

        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        '----------------------------------------------------------------
        Public Function doSaveTDTempData( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal intZTLX As Integer, _
            ByVal objNewData As System.Data.DataRow, _
            ByRef objDataSet_TDZH As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            Try
                With New Josco.JSOA.BusinessRules.rulesEstateRenshiXingye
                    doSaveTDTempData = .doSaveTDTempData(strErrMsg, strUserId, strPassword, intZTLX, objNewData, objDataSet_TDZH)
                End With
            Catch ex As Exception
                doSaveTDTempData = False
                strErrMsg = ex.Message
            End Try

        End Function


        '----------------------------------------------------------------
        '删除团队临时数据
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strZBBS                   :组别标识
        '     intZTLX                   :审批状态类型
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        '----------------------------------------------------------------
        Public Function doDeleteTDTempData( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strZBBS As String, _
            ByVal intZTLX As Integer) As Boolean
            Try
                With New Josco.JSOA.BusinessRules.rulesEstateRenshiXingye
                    doDeleteTDTempData = .doDeleteTDTempData(strErrMsg, strUserId, strPassword, strZBBS, intZTLX)
                End With
            Catch ex As Exception
                doDeleteTDTempData = False
                strErrMsg = ex.Message
            End Try

        End Function

        '----------------------------------------------------------------
        ' 按指定信息将人员从架构中注销
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objEnvInfo           ：变动通用参数（BDLX,BDSJ,BDYY,BDYYMC）
        '     objMainInfo          ：主变动人当前人员架构参数
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        ' 更改备注
        '     zengxianglin 2008-10-14创建
        '----------------------------------------------------------------
        Public Function doDelete_RenyuanJiagou( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objEnvInfo As System.Collections.Specialized.NameValueCollection, _
            ByVal objMainInfo As System.Data.DataRow) As Boolean
            With m_objrulesEstateRenshiXingye
                doDelete_RenyuanJiagou = .doDelete_RenyuanJiagou(strErrMsg, strUserId, strPassword, objEnvInfo, objMainInfo)
            End With
        End Function

        '----------------------------------------------------------------
        ' 按指定的信息调整人员架构
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objEnvInfo           ：变动通用参数（BDSJ,BDYY,BDYYMC）
        '     objOldData           ：主变动人旧数据
        '     objNewData           ：主变动人新数据
        '     objDataSet_XJ        ：要调整的下级人员信息列表
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doAdjust_RenyuanJiagou( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objEnvInfo As System.Collections.Specialized.NameValueCollection, _
            ByVal objOldData As System.Data.DataRow, _
            ByVal objNewData As System.Data.DataRow, _
            ByVal objDataSet_XJ As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByVal blnTZ As Boolean) As Boolean
            With m_objrulesEstateRenshiXingye
                doAdjust_RenyuanJiagou = .doAdjust_RenyuanJiagou(strErrMsg, strUserId, strPassword, objEnvInfo, objOldData, objNewData, objDataSet_XJ, blnTZ)
            End With
        End Function

        '----------------------------------------------------------------
        ' 检查人员代码
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strRYDM                   : 人员代码
        '     strSFZHM                  : 身份证号码
        '     strRYXM                   : 人员姓名
        '     intReturn                 : 0-通过；1-有ID，身份证号码不同；2-无ID，身份证号码相同；3-有ID,身份证号码相同；
        '     intLXTable                : 0-入职；1-实习生
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        '----------------------------------------------------------------
        Public Function doCheckRydmData( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strRYDM As String, _
            ByVal strSFZHM As String, _
            ByVal strRYXM As String, _
            ByRef intReturn As Integer, _
            ByVal intLXTable As Integer) As Boolean

            With m_objrulesEstateRenshiXingye
                doCheckRydmData = .doCheckRydmData(strErrMsg, strUserId, strPassword, strRYDM, strSFZHM, strRYXM, intReturn, intLXTable)
            End With
        End Function


        '----------------------------------------------------------------
        ' 检查人员代码
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     objenumEditType           : 编辑类型
        '     strRYDM                   ：人员代码
        '     strSFZHM                  : 身份证号码

        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        '----------------------------------------------------------------
        Public Function doSaveSFZHM( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strRYDM As String, _
            ByVal strSFZHM As String, _
            ByVal intLXTable As Integer) As Boolean

            With m_objrulesEstateRenshiXingye
                doSaveSFZHM = .doSaveSFZHM(strErrMsg, strUserId, strPassword, strRYDM, strSFZHM, intLXTable)
            End With
        End Function



        '----------------------------------------------------------------
        ' 根据strRYDM获取用户信息数据集
        '     strErrMsg      ：如果错误，则返回错误信息
        '     strUserId      ：用户标识
        '     strPassword    ：用户密码
        '     strRYDM        ：人员代码
        '     strOptions     ：获取数据选项ABCD
        '                      A=1 获取人员单表数据
        '                      B=1 获取人员的组织机构单表数据
        '                      C=1 获取人员的上岗单表数据
        '                      D=1 获取人员的完全连接的表数据
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
            ByVal strOptions As String, _
            ByRef objCustomerData As Josco.JsKernal.Common.Data.CustomerData) As Boolean

            Try
                With New Josco.JsKernal.BusinessRules.rulesCustomer
                    getRenyuanData = .getRenyuanData(strErrMsg, strUserId, strPassword, strRYDM, strOptions, objCustomerData)
                End With
            Catch ex As Exception
                getRenyuanData = False
                strErrMsg = ex.Message
            End Try

        End Function


        '----------------------------------------------------------------
        ' 获取上级领导
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strRYDM                   : 人员代码
        '     strZZDM                   : 组织代码
        '     strZJDM                   : 职级代码
        '     strTDBH                   : 团队编号
        '     strSJLD                   : 返回的上级领导名称
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        '----------------------------------------------------------------
        Public Function getSJLD( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strRYDM As String, _
            ByVal strZZDM As String, _
            ByVal strZJDM As String, _
            ByVal strTDBH As String, _
            ByRef strSJLD As String) As Boolean


            Try
                With New Josco.JSOA.BusinessRules.rulesEstateRenshiXingye
                    getSJLD = .getSJLD(strErrMsg, strUserId, strPassword, strRYDM, strZZDM, strZJDM, strTDBH, strSJLD)
                End With
            Catch ex As Exception
                getSJLD = False
                strErrMsg = ex.Message
            End Try

        End Function



        '----------------------------------------------------------------
        ' 计算strZBBS审批中的团队组合数据
        ' 适用管理模式二
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strZBBS                   ：组别标识
        '     objBufDataSet             ：缓存数据集
        '     objRetDataSet             ：信息数据集
        '     blnOption                 : 重载
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        ' 更改记录
        '     LJ 2011-07-19 创建
        '----------------------------------------------------------------
        Public Function getDataSet_TDZH( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strZBBS As String, _
            ByVal objBufDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByVal blnOption As Boolean) As Boolean

            With m_objrulesEstateRenshiXingye
                getDataSet_TDZH = .getDataSet_TDZH(strErrMsg, strUserId, strPassword, strZBBS, objBufDataSet, objRetDataSet, blnOption)
            End With
        End Function


        '----------------------------------------------------------------
        ' 检查调整或者离职时间是否有效
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strRYDM                   : 人员代码
        '     strZZDM                   : 组织代码（用于区域行助的辨识）
        '     strRYLX                   : 人员类型 1-业务人员，0-行政助理
        '     strSPSJ                   : 审批时间
        '     blnSJ                     : 有效-true;无效-false
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        '----------------------------------------------------------------
        Public Function checkBDSJ( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strRYDM As String, _
            ByVal strZZDM As String, _
            ByVal strRYLX As String, _
            ByVal strSPSJ As String, _
            ByRef blnSJ As Boolean) As Boolean


            Try
                With New Josco.JSOA.BusinessRules.rulesEstateRenshiXingye
                    checkBDSJ = .checkBDSJ(strErrMsg, strUserId, strPassword, strRYDM, strZZDM, strRYLX, strSPSJ, blnSJ)
                End With
            Catch ex As Exception
                checkBDSJ = False
                strErrMsg = ex.Message
            End Try
        End Function

        '----------------------------------------------------------------
        ' 检查流程人员是否在流程中
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strRYDM                   : 人员代码
        '     blnSJ                     : 有-true;无-false
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        '----------------------------------------------------------------
        Public Function checkFlowRy( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strRYDM As String, _
            ByRef blnSJ As Boolean) As Boolean

            Try
                With New Josco.JSOA.BusinessRules.rulesEstateRenshiXingye
                    checkFlowRy = .checkFlowRy(strErrMsg, strUserId, strPassword, strRYDM, blnSJ)
                End With
            Catch ex As Exception
                checkFlowRy = False
                strErrMsg = ex.Message
            End Try
        End Function
    End Class

End Namespace
