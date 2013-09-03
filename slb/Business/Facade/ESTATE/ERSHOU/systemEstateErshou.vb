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

Namespace Josco.JSOA.BusinessFacade
    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.BusinessFacade
    ' 类名    ：systemEstateErshou
    '
    ' 功能描述： 
    '   　提供对二手业务处理的表现层支持
    '----------------------------------------------------------------
    Public Class systemEstateErshou
        Implements System.IDisposable

        Private m_objrulesEstateErshou As Josco.JSOA.BusinessRules.rulesEstateErshou

        '----------------------------------------------------------------
        ' 构造函数
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()
            m_objrulesEstateErshou = New Josco.JSOA.BusinessRules.rulesEstateErshou
        End Sub

        '----------------------------------------------------------------
        ' 安全释放本身资源
        '----------------------------------------------------------------
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.systemEstateErshou)
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
            If Not (m_objrulesEstateErshou Is Nothing) Then
                m_objrulesEstateErshou.Dispose()
                m_objrulesEstateErshou = Nothing
            End If
        End Sub










        '----------------------------------------------------------------
        ' 将objDataTable中的选定列导出到Excel的当前活动Sheet并自动写标题行
        '     strErrMsg              ：如果错误，则返回错误信息
        '     objDataTable           ：要导出的数据表
        '     objFields              ：要导出的列
        '     strExcelFile           ：导出到WEB服务器中的Excel文件路径
        '     strDateFormat          ：日期格式字符串
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
        ' 更改
        '     zengxianglin 2011-01-03 创建
        '----------------------------------------------------------------
        Public Function doExportToExcel( _
            ByRef strErrMsg As String, _
            ByVal objDataTable As System.Data.DataTable, _
            ByVal objFields As System.Collections.Specialized.NameValueCollection, _
            ByVal strExcelFile As String, _
            ByVal strDateFormat As String) As Boolean
            With Me.m_objrulesEstateErshou
                doExportToExcel = .doExportToExcel(strErrMsg, objDataTable, objFields, strExcelFile, strDateFormat)
            End With
        End Function

        '----------------------------------------------------------------
        ' 将数据从DataSet导出到Excel
        '     strErrMsg              ：如果错误，则返回错误信息
        '     objDataTable           ：要导出的数据
        '     strExcelFile           ：导出到WEB服务器中的Excel文件路径
        '     strSheetName           ：数据导出到strSheetName
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
        '----------------------------------------------------------------
        Public Function doExportToExcel( _
            ByRef strErrMsg As String, _
            ByVal objDataTable As System.Data.DataTable, _
            ByVal strExcelFile As String, _
            ByVal strSheetName As String) As Boolean
            With Me.m_objrulesEstateErshou
                doExportToExcel = .doExportToExcel(strErrMsg, objDataTable, strExcelFile, strSheetName)
            End With
        End Function

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
            With Me.m_objrulesEstateErshou
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
            With Me.m_objrulesEstateErshou
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
            With Me.m_objrulesEstateErshou
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
            With Me.m_objrulesEstateErshou
                doExcelSheetDelete = .doExcelSheetDelete(strErrMsg, strSrcFile, strSrcSheet)
            End With
        End Function












        '----------------------------------------------------------------
        ' 获取“地产_V_全部交易”的搜索SQL
        '----------------------------------------------------------------
        Public Function getSearchSQL_QBJY() As String
            With m_objrulesEstateErshou
                getSearchSQL_QBJY = .getSearchSQL_QBJY()
            End With
        End Function

        '----------------------------------------------------------------
        ' 根据“确认书号”获取“地产_V_全部交易”完全数据的数据集
        ' 以“交易日期”降序排序
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strQRSH                    ：确认书号
        '     strWhere                   ：搜索字符串
        '     objestateErshouData      ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_ES_JYXX( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal strWhere As String, _
            ByRef objestateErshouData As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_JYXX = .getDataSet_ES_JYXX(strErrMsg, strUserId, strPassword, strQRSH, strWhere, objestateErshouData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 判断给定的确认书号是否存在？
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strQRSH              ：确认书号
        '     blnIS                ：返回是否
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function isQrshExist( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByRef blnIS As Boolean) As Boolean
            With m_objrulesEstateErshou
                isQrshExist = .isQrshExist(strErrMsg, strUserId, strPassword, strQRSH, blnIS)
            End With
        End Function

        '----------------------------------------------------------------
        ' 获取“地产_V_全部交易”完全数据的数据集
        ' 以“交易日期”降序排序
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strWhere                   ：搜索字符串
        '     objestateErshouData      ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_ES_JYXX( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objestateErshouData As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_JYXX = .getDataSet_ES_JYXX(strErrMsg, strUserId, strPassword, strWhere, objestateErshouData)
            End With
        End Function











        '----------------------------------------------------------------
        ' 获取“地产_B_二手_确认书买卖”完全数据的数据集
        ' 以“订购日期”排序
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strWhere                   ：搜索字符串
        '     blnControl                 ：进行查看限制
        '     objestateErshouData        ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_ES_QRS_MM( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByVal blnControl As Boolean, _
            ByRef objestateErshouData As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_QRS_MM = .getDataSet_ES_QRS_MM(strErrMsg, strUserId, strPassword, strWhere, blnControl, objestateErshouData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 根据“确认书号”获取“地产_B_二手_确认书买卖”完全数据的数据集
        ' 以“订购日期”排序
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strQRSH                    ：确认书号
        '     strWhere                   ：搜索字符串
        '     objestateErshouData        ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_ES_QRS_MM( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal strWhere As String, _
            ByRef objestateErshouData As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_QRS_MM = .getDataSet_ES_QRS_MM(strErrMsg, strUserId, strPassword, strQRSH, strWhere, objestateErshouData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 根据“确认书号”获取“地产_B_二手_物业买卖”完全数据的数据集
        ' 以“房屋地址”排序
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strQRSH                    ：确认书号
        '     strWhere                   ：搜索字符串
        '     objestateErshouData        ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_ES_WUYE_MM( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal strWhere As String, _
            ByRef objestateErshouData As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_WUYE_MM = .getDataSet_ES_WUYE_MM(strErrMsg, strUserId, strPassword, strQRSH, strWhere, objestateErshouData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 根据“确认书号”获取“地产_B_二手_交易合同分配比例”完全数据的数据集
        ' 以“人员代码”排序
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strQRSH                    ：确认书号
        '     strWhere                   ：搜索字符串
        '     objestateErshouData        ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_ES_HETONG_FPBL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal strWhere As String, _
            ByRef objestateErshouData As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_HETONG_FPBL = .getDataSet_ES_HETONG_FPBL(strErrMsg, strUserId, strPassword, strQRSH, strWhere, objestateErshouData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 获取“地产_B_二手_确认书买卖”中的新的“确认书号”
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strJLBH              ：确认书号
        ' 返回
        '     True                 ：合法
        '     False                ：不合法或其他程序错误
        '----------------------------------------------------------------
        Public Function getNewQRSH_MM( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef strQRSH As String) As Boolean
            With m_objrulesEstateErshou
                getNewQRSH_MM = .getNewQRSH_MM(strErrMsg, strUserId, strPassword, strQRSH)
            End With
        End Function



        '----------------------------------------------------------------
        ' 获取“地产_B_二手_确认书租赁”中的新的“确认书号”
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strJLBH              ：确认书号
        ' 返回
        '     True                 ：合法
        '     False                ：不合法或其他程序错误
        '----------------------------------------------------------------
        Public Function getNewQRSH_ZL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef strQRSH As String) As Boolean
            With m_objrulesEstateErshou
                getNewQRSH_ZL = .getNewQRSH_ZL(strErrMsg, strUserId, strPassword, strQRSH)
            End With
        End Function


        '----------------------------------------------------------------
        ' 获取“地产_B_二手_交易合同”中的新的买卖“合同编号”
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strHTBH              ：合同编号
        ' 返回
        '     True                 ：合法
        '     False                ：不合法或其他程序错误
        '----------------------------------------------------------------
        Public Function getNewHTBH_MM( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef strHTBH As String) As Boolean

            With m_objrulesEstateErshou
                getNewHTBH_MM = .getNewHTBH_MM(strErrMsg, strUserId, strPassword, strHTBH)
            End With
        End Function

        '----------------------------------------------------------------
        ' 获取“地产_B_二手_交易合同”中的新的租赁“合同编号”
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strHTBH              ：合同编号
        ' 返回
        '     True                 ：合法
        '     False                ：不合法或其他程序错误
        '----------------------------------------------------------------
        Public Function getNewHTBH_ZL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef strHTBH As String) As Boolean

            With m_objrulesEstateErshou
                getNewHTBH_ZL = .getNewHTBH_ZL(strErrMsg, strUserId, strPassword, strHTBH)
            End With
        End Function


        '----------------------------------------------------------------
        ' 判断给定的确认书号是否已签署合同？
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strQRSH              ：确认书号
        '     blnIS                ：返回是否
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function isQianHetong( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByRef blnIS As Boolean) As Boolean
            With m_objrulesEstateErshou
                isQianHetong = .isQianHetong(strErrMsg, strUserId, strPassword, strQRSH, blnIS)
            End With
        End Function

        '----------------------------------------------------------------
        ' 检查“地产_B_二手_物业买卖”的数据类型的合法性
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objNewData           ：新数据
        ' 返回
        '     True                 ：合法
        '     False                ：不合法或其他程序错误
        '----------------------------------------------------------------
        Public Function doVerifyData_ES_WUYE_MM( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection) As Boolean
            With m_objrulesEstateErshou
                doVerifyData_ES_WUYE_MM = .doVerifyData_ES_WUYE_MM(strErrMsg, strUserId, strPassword, objNewData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 保存“地产_B_二手_确认书买卖”数据记录(整个事务完成)
        '     strErrMsg              ：如果错误，则返回错误信息
        '     strUserId              ：用户标识
        '     strPassword            ：用户密码
        '     objNewData             ：记录新值(返回保存后的新值)
        '     objOldData             ：记录旧值
        '     objenumEditType        ：编辑类型
        '     objDataSet_WYXX        ：物业信息数据集
        '     objDataSet_YWRY        ：业务人员数据集
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
        '----------------------------------------------------------------
        Public Function doSaveData_ES_QRS_MM( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objOldData As System.Data.DataRow, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType, _
            ByVal objDataSet_WYXX As Josco.JSOA.Common.Data.estateErshouData, _
            ByVal objDataSet_YWRY As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                doSaveData_ES_QRS_MM = .doSaveData_ES_QRS_MM(strErrMsg, strUserId, strPassword, objNewData, objOldData, objenumEditType, objDataSet_WYXX, objDataSet_YWRY)
            End With
        End Function

        '----------------------------------------------------------------
        ' 删除“地产_B_二手_确认书买卖”记录及相关记录
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：连接用户名
        '     strPassword          ：连接用户密码
        '     strWYBS              ：要删除的唯一标识
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doDeleteData_ES_QRS_MM( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWYBS As String) As Boolean
            With m_objrulesEstateErshou
                doDeleteData_ES_QRS_MM = .doDeleteData_ES_QRS_MM(strErrMsg, strUserId, strPassword, strWYBS)
            End With
        End Function

        '----------------------------------------------------------------
        ' “地产_B_二手_确认书买卖”挞定处理
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：连接用户名
        '     strPassword          ：连接用户密码
        '     strWYBS              ：唯一标识
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doTading_ES_QRS_MM( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWYBS As String) As Boolean
            With m_objrulesEstateErshou
                doTading_ES_QRS_MM = .doTading_ES_QRS_MM(strErrMsg, strUserId, strPassword, strWYBS)
            End With
        End Function

        '----------------------------------------------------------------
        ' 获取“地产_V_全部交易”完全数据的数据集
        ' 以“交易日期”排序
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strWhere                   ：搜索字符串
        '     blnControl                 ：进行查看限制
        '     objestateErshouData        ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_ES_JYXX( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByVal blnControl As Boolean, _
            ByRef objestateErshouData As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_JYXX = .getDataSet_ES_JYXX(strErrMsg, strUserId, strPassword, strWhere, blnControl, objestateErshouData)
            End With
        End Function













        '----------------------------------------------------------------
        ' 获取“地产_B_二手_确认书租赁”完全数据的数据集
        ' 以“订购日期”排序
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strWhere                   ：搜索字符串
        '     blnControl                 ：进行查看限制
        '     objestateErshouData        ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_ES_QRS_ZL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByVal blnControl As Boolean, _
            ByRef objestateErshouData As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_QRS_ZL = .getDataSet_ES_QRS_ZL(strErrMsg, strUserId, strPassword, strWhere, blnControl, objestateErshouData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 根据“确认书号”获取“地产_B_二手_物业租赁”完全数据的数据集
        ' 以“房屋地址”排序
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strQRSH                    ：确认书号
        '     strWhere                   ：搜索字符串
        '     objestateErshouData        ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_ES_WUYE_ZL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal strWhere As String, _
            ByRef objestateErshouData As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_WUYE_ZL = .getDataSet_ES_WUYE_ZL(strErrMsg, strUserId, strPassword, strQRSH, strWhere, objestateErshouData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 根据“确认书号”获取“地产_B_二手_确认书租赁”完全数据的数据集
        ' 以“订购日期”排序
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strQRSH                    ：确认书号
        '     strWhere                   ：搜索字符串
        '     objestateErshouData        ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_ES_QRS_ZL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal strWhere As String, _
            ByRef objestateErshouData As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_QRS_ZL = .getDataSet_ES_QRS_ZL(strErrMsg, strUserId, strPassword, strQRSH, strWhere, objestateErshouData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 删除“地产_B_二手_确认书租赁”记录及相关记录
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：连接用户名
        '     strPassword          ：连接用户密码
        '     strWYBS              ：要删除的唯一标识
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doDeleteData_ES_QRS_ZL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWYBS As String) As Boolean
            With m_objrulesEstateErshou
                doDeleteData_ES_QRS_ZL = .doDeleteData_ES_QRS_ZL(strErrMsg, strUserId, strPassword, strWYBS)
            End With
        End Function

        '----------------------------------------------------------------
        ' “地产_B_二手_确认书租赁”挞定处理
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：连接用户名
        '     strPassword          ：连接用户密码
        '     strWYBS              ：唯一标识
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doTading_ES_QRS_ZL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWYBS As String) As Boolean
            With m_objrulesEstateErshou
                doTading_ES_QRS_ZL = .doTading_ES_QRS_ZL(strErrMsg, strUserId, strPassword, strWYBS)
            End With
        End Function

        '----------------------------------------------------------------
        ' 检查“地产_B_二手_物业租赁”的数据类型的合法性
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objNewData           ：新数据
        ' 返回
        '     True                 ：合法
        '     False                ：不合法或其他程序错误
        '----------------------------------------------------------------
        Public Function doVerifyData_ES_WUYE_ZL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection) As Boolean
            With m_objrulesEstateErshou
                doVerifyData_ES_WUYE_ZL = .doVerifyData_ES_WUYE_ZL(strErrMsg, strUserId, strPassword, objNewData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 保存“地产_B_二手_确认书租赁”数据记录(整个事务完成)
        '     strErrMsg              ：如果错误，则返回错误信息
        '     strUserId              ：用户标识
        '     strPassword            ：用户密码
        '     objNewData             ：记录新值(返回保存后的新值)
        '     objOldData             ：记录旧值
        '     objenumEditType        ：编辑类型
        '     objDataSet_WYXX        ：物业信息数据集
        '     objDataSet_YWRY        ：业务人员数据集
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
        '----------------------------------------------------------------
        Public Function doSaveData_ES_QRS_ZL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objOldData As System.Data.DataRow, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType, _
            ByVal objDataSet_WYXX As Josco.JSOA.Common.Data.estateErshouData, _
            ByVal objDataSet_YWRY As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                doSaveData_ES_QRS_ZL = .doSaveData_ES_QRS_ZL(strErrMsg, strUserId, strPassword, objNewData, objOldData, objenumEditType, objDataSet_WYXX, objDataSet_YWRY)
            End With
        End Function










        '----------------------------------------------------------------
        ' 根据“确认书号”获取“地产_B_二手_交易合同”完全数据的数据集
        ' 以“合同日期”排序
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strQRSH                    ：确认书号
        '     strWhere                   ：搜索字符串
        '     objestateErshouData        ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_ES_HETONG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal strWhere As String, _
            ByRef objestateErshouData As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_HETONG = .getDataSet_ES_HETONG(strErrMsg, strUserId, strPassword, strQRSH, strWhere, objestateErshouData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 保存“地产_B_二手_交易合同”数据记录(整个事务完成)
        '     strErrMsg              ：如果错误，则返回错误信息
        '     strUserId              ：用户标识
        '     strPassword            ：用户密码
        '     strYWLX                ：业务类型
        '     objNewDataHT           ：合同记录新值(返回保存后的新值)
        '     objOldDataHT           ：合同记录旧值
        '     objNewDataQRS          ：确认书记录新值(返回保存后的新值)
        '     objOldDataQRS          ：确认书记录旧值
        '     objenumEditType        ：编辑类型
        '     objDataSet_WYXX        ：物业信息数据集
        '     objDataSet_YWRY        ：业务人员数据集
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
        '----------------------------------------------------------------
        Public Function doSaveData_ES_HETONG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strYWLX As String, _
            ByRef objNewDataHT As System.Collections.Specialized.NameValueCollection, _
            ByVal objOldDataHT As System.Data.DataRow, _
            ByRef objNewDataQRS As System.Collections.Specialized.NameValueCollection, _
            ByVal objOldDataQRS As System.Data.DataRow, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType, _
            ByVal objDataSet_WYXX As Josco.JSOA.Common.Data.estateErshouData, _
            ByVal objDataSet_YWRY As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                doSaveData_ES_HETONG = .doSaveData_ES_HETONG(strErrMsg, strUserId, strPassword, strYWLX, objNewDataHT, objOldDataHT, objNewDataQRS, objOldDataQRS, objenumEditType, objDataSet_WYXX, objDataSet_YWRY)
            End With
        End Function

        '----------------------------------------------------------------
        ' 删除“地产_B_二手_交易合同”记录及相关记录
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：连接用户名
        '     strPassword          ：连接用户密码
        '     strWYBS              ：要删除的唯一标识
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doDeleteData_ES_HETONG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWYBS As String) As Boolean
            With m_objrulesEstateErshou
                doDeleteData_ES_HETONG = .doDeleteData_ES_HETONG(strErrMsg, strUserId, strPassword, strWYBS)
            End With
        End Function

        '----------------------------------------------------------------
        ' 根据“确认书号”获取“地产_B_二手_租赁期限”完全数据的数据集
        ' 以“开始日期”排序
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strQRSH                    ：确认书号
        '     strWhere                   ：搜索字符串
        '     objestateErshouData        ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_ES_ZulinQixian( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal strWhere As String, _
            ByRef objestateErshouData As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_ZulinQixian = .getDataSet_ES_ZulinQixian(strErrMsg, strUserId, strPassword, strQRSH, strWhere, objestateErshouData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 保存“地产_B_二手_交易合同”数据记录(整个事务完成)
        '     strErrMsg              ：如果错误，则返回错误信息
        '     strUserId              ：用户标识
        '     strPassword            ：用户密码
        '     strYWLX                ：业务类型
        '     objNewDataHT           ：合同记录新值(返回保存后的新值)
        '     objOldDataHT           ：合同记录旧值
        '     objNewDataQRS          ：确认书记录新值(返回保存后的新值)
        '     objOldDataQRS          ：确认书记录旧值
        '     objenumEditType        ：编辑类型
        '     objDataSet_WYXX        ：物业信息数据集
        '     objDataSet_YWRY        ：业务人员数据集
        '     objDataSet_ZLQX        ：租赁期限数据集
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
        '----------------------------------------------------------------
        Public Function doSaveData_ES_HETONG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strYWLX As String, _
            ByRef objNewDataHT As System.Collections.Specialized.NameValueCollection, _
            ByVal objOldDataHT As System.Data.DataRow, _
            ByRef objNewDataQRS As System.Collections.Specialized.NameValueCollection, _
            ByVal objOldDataQRS As System.Data.DataRow, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType, _
            ByVal objDataSet_WYXX As Josco.JSOA.Common.Data.estateErshouData, _
            ByVal objDataSet_YWRY As Josco.JSOA.Common.Data.estateErshouData, _
            ByVal objDataSet_ZLQX As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                doSaveData_ES_HETONG = .doSaveData_ES_HETONG(strErrMsg, strUserId, strPassword, strYWLX, objNewDataHT, objOldDataHT, objNewDataQRS, objOldDataQRS, objenumEditType, objDataSet_WYXX, objDataSet_YWRY, objDataSet_ZLQX)
            End With
        End Function

        '----------------------------------------------------------------
        ' 根据时间段、月租金、计租方法计算该段时间的总租金、租期（月）
        '     strErrMsg              ：如果错误，则返回错误信息
        '     strKSRQ                ：开始日期
        '     strZZRQ                ：终止日期
        '     dblYZJ                 ：月租金
        '     intJZFF                ：计租方法(0-自然月 1非自然月)
        '     dblZZJ                 ：总租金
        '     dblZZQ                 ：租期
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
        '----------------------------------------------------------------
        Public Function getZujinAndZuqi( _
            ByRef strErrMsg As String, _
            ByVal strKSRQ As String, _
            ByVal strZZRQ As String, _
            ByVal dblYZJ As Double, _
            ByVal intJZFF As Integer, _
            ByRef dblZZJ As Double, _
            ByRef dblZZQ As Double) As Boolean
            With m_objrulesEstateErshou
                getZujinAndZuqi = .getZujinAndZuqi(strErrMsg, strKSRQ, strZZRQ, dblYZJ, intJZFF, dblZZJ, dblZZQ)
            End With
        End Function

        '----------------------------------------------------------------
        ' 判断给定的合同是否已审核？
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strQRSH              ：确认书号
        '     blnIS                ：返回是否
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function isHetongYiShen( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByRef blnIS As Boolean) As Boolean
            With m_objrulesEstateErshou
                isHetongYiShen = .isHetongYiShen(strErrMsg, strUserId, strPassword, strQRSH, blnIS)
            End With
        End Function

        '----------------------------------------------------------------
        ' 判断给定的合同是否已完成？
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strQRSH              ：确认书号
        '     blnIS                ：返回是否
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function isHetongComplete( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByRef blnIS As Boolean) As Boolean
            With m_objrulesEstateErshou
                isHetongComplete = .isHetongComplete(strErrMsg, strUserId, strPassword, strQRSH, blnIS)
            End With
        End Function

        '----------------------------------------------------------------
        ' 获取指定人员在当前时间点的职级代码、职级名称
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strRYDM              ：人员代码
        '     strZJDM              ：返回职级代码
        '     strZJMC              ：返回职级名称
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function getZjdmAndZjmc( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strRYDM As String, _
            ByRef strZJDM As String, _
            ByRef strZJMC As String) As Boolean
            With m_objrulesEstateErshou
                getZjdmAndZjmc = .getZjdmAndZjmc(strErrMsg, strUserId, strPassword, strRYDM, strZJDM, strZJMC)
            End With
        End Function

        '----------------------------------------------------------------
        ' 获取指定私佣分配信息自动计算公佣分配数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strQRSH              ：确认书号
        '     objDataSet_SY        ：私佣分配信息
        '     objDataSet_GY        ：返回公佣分配数据
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function getGongyongInfo( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal objDataSet_SY As Josco.JSOA.Common.Data.estateErshouData, _
            ByRef objDataSet_GY As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getGongyongInfo = .getGongyongInfo(strErrMsg, strUserId, strPassword, strQRSH, objDataSet_SY, objDataSet_GY)
            End With
        End Function

        '----------------------------------------------------------------
        ' 保存“地产_B_二手_交易合同分配比例”数据记录(整个事务完成)
        '     strErrMsg              ：如果错误，则返回错误信息
        '     strUserId              ：用户标识
        '     strPassword            ：用户密码
        '     strQRSH                ：确认书号
        '     objDataSet_SYBL        ：私佣信息数据集
        '     objDataSet_GYBL        ：公佣信息数据集
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
        '----------------------------------------------------------------
        Public Function doSaveData_ES_HETONG_FPBL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal objDataSet_SYBL As Josco.JSOA.Common.Data.estateErshouData, _
            ByVal objDataSet_GYBL As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                doSaveData_ES_HETONG_FPBL = .doSaveData_ES_HETONG_FPBL(strErrMsg, strUserId, strPassword, strQRSH, objDataSet_SYBL, objDataSet_GYBL)
            End With
        End Function

        '----------------------------------------------------------------
        ' 检查“地产_B_二手_交易合同分配比例”私佣比例和=1？
        '     strErrMsg              ：如果错误，则返回错误信息
        '     objDataSet_SYBL        ：私佣信息数据集
        '     blnValid               ：判断结果
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
        '----------------------------------------------------------------
        Public Function doVerify_ES_HETONG_FPBL( _
            ByRef strErrMsg As String, _
            ByVal objDataSet_SYBL As Josco.JSOA.Common.Data.estateErshouData, _
            ByRef blnValid As Boolean) As Boolean
            With m_objrulesEstateErshou
                doVerify_ES_HETONG_FPBL = .doVerify_ES_HETONG_FPBL(strErrMsg, objDataSet_SYBL, blnValid)
            End With
        End Function

        '----------------------------------------------------------------
        ' 如果给定“确认书号”，则根据“确认书号”获取“地产_V_全部合同”完全数据的数据集
        ' 否则计算所有满足条件strWhere的数据
        ' 以“合同日期”排序
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strQRSH                    ：确认书号
        '     strWhere                   ：搜索字符串
        '     blnControl                 ：是否限制查看
        '     objestateErshouData        ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_ES_JYXX( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal strWhere As String, _
            ByVal blnControl As Boolean, _
            ByRef objestateErshouData As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_JYXX = .getDataSet_ES_JYXX(strErrMsg, strUserId, strPassword, strQRSH, strWhere, blnControl, objestateErshouData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 根据“确认书号”获取“地产_B_二手_交易合同审核签名”完全数据的数据集
        ' 以“审核日期”排序
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strQRSH                    ：确认书号
        '     strWhere                   ：搜索字符串
        '     objestateErshouData        ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_ES_HETONG_SHQK( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal strWhere As String, _
            ByRef objestateErshouData As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_HETONG_SHQK = .getDataSet_ES_HETONG_SHQK(strErrMsg, strUserId, strPassword, strQRSH, strWhere, objestateErshouData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 合同审核处理
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：连接用户名
        '     strPassword          ：连接用户密码
        '     strQRSH              ：确认书号
        '     strSHRDM             ：审核人代码
        '     objSHLX              ：审核类型
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doShenHe_ES_HETONG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal strSHRDM As String, _
            ByVal objSHLX As Josco.JSOA.Common.Data.estateErshouData.enumShenheStatus) As Boolean
            With m_objrulesEstateErshou
                doShenHe_ES_HETONG = .doShenHe_ES_HETONG(strErrMsg, strUserId, strPassword, strQRSH, strSHRDM, objSHLX)
            End With
        End Function











        '----------------------------------------------------------------
        ' 根据“确认书号”获取“地产_B_二手_交易合同办案计划”完全数据的数据集
        ' 以“计划开始”排序
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strQRSH                    ：确认书号
        '     strWhere                   ：搜索字符串
        '     objestateErshouData        ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_ES_HETONG_BAJH( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal strWhere As String, _
            ByRef objestateErshouData As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_HETONG_BAJH = .getDataSet_ES_HETONG_BAJH(strErrMsg, strUserId, strPassword, strQRSH, strWhere, objestateErshouData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 根据“确认书号”、“计划标识”获取“地产_B_二手_交易合同办案记录”完全数据的数据集
        ' 以“办理日期”排序
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strQRSH                    ：确认书号
        '     strJHBS                    ：办理计划对应的唯一标识
        '     strWhere                   ：搜索字符串
        '     objestateErshouData        ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_ES_HETONG_BLJL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal strJHBS As String, _
            ByVal strWhere As String, _
            ByRef objestateErshouData As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_HETONG_BLJL = .getDataSet_ES_HETONG_BLJL(strErrMsg, strUserId, strPassword, strQRSH, strJHBS, strWhere, objestateErshouData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 保存“地产_B_二手_交易合同办案计划”的数据
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
        Public Function doSaveData_ES_HETONG_BAJH( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean
            With m_objrulesEstateErshou
                doSaveData_ES_HETONG_BAJH = .doSaveData_ES_HETONG_BAJH(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType)
            End With
        End Function

        '----------------------------------------------------------------
        ' 删除“地产_B_二手_交易合同办案计划”的数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strWYBS              ：唯一标识
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doDeleteData_ES_HETONG_BAJH( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWYBS As String) As Boolean
            With m_objrulesEstateErshou
                doDeleteData_ES_HETONG_BAJH = .doDeleteData_ES_HETONG_BAJH(strErrMsg, strUserId, strPassword, strWYBS)
            End With
        End Function

        '----------------------------------------------------------------
        ' 保存“地产_B_二手_交易合同办案记录”的数据
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
        Public Function doSaveData_ES_HETONG_BLJL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean
            With m_objrulesEstateErshou
                doSaveData_ES_HETONG_BLJL = .doSaveData_ES_HETONG_BLJL(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType)
            End With
        End Function

        '----------------------------------------------------------------
        ' 删除“地产_B_二手_交易合同办案记录”的数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strWYBS              ：唯一标识
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doDeleteData_ES_HETONG_BLJL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWYBS As String) As Boolean
            With m_objrulesEstateErshou
                doDeleteData_ES_HETONG_BLJL = .doDeleteData_ES_HETONG_BLJL(strErrMsg, strUserId, strPassword, strWYBS)
            End With
        End Function

        '----------------------------------------------------------------
        ' 标记“地产_B_二手_交易合同办案计划”业务开始办理
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strWYBS              ：唯一标识
        '     strKSRQ              ：开始日期
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doMarkBegin_ES_HETONG_BAJH( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWYBS As String, _
            ByVal strKSRQ As String) As Boolean
            With m_objrulesEstateErshou
                doMarkBegin_ES_HETONG_BAJH = .doMarkBegin_ES_HETONG_BAJH(strErrMsg, strUserId, strPassword, strWYBS, strKSRQ)
            End With
        End Function

        '----------------------------------------------------------------
        ' 标记“地产_B_二手_交易合同办案计划”业务办理完毕
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strWYBS              ：唯一标识
        '     strJSRQ              ：结束日期
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doMarkComplete_ES_HETONG_BAJH( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWYBS As String, _
            ByVal strJSRQ As String) As Boolean
            With m_objrulesEstateErshou
                doMarkComplete_ES_HETONG_BAJH = .doMarkComplete_ES_HETONG_BAJH(strErrMsg, strUserId, strPassword, strWYBS, strJSRQ)
            End With
        End Function

        '----------------------------------------------------------------
        ' 标记“地产_B_二手_交易合同”办结
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strQRSH              ：确认书号
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doMarkComplete_ES_HETONG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String) As Boolean
            With m_objrulesEstateErshou
                doMarkComplete_ES_HETONG = .doMarkComplete_ES_HETONG(strErrMsg, strUserId, strPassword, strQRSH)
            End With
        End Function

        '----------------------------------------------------------------
        ' 关闭“地产_B_二手_交易合同办案计划”指定业务的提醒
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strWYBS              ：唯一标识
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doClearTixing_ES_HETONG_BAJH( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWYBS As String) As Boolean
            With m_objrulesEstateErshou
                doClearTixing_ES_HETONG_BAJH = .doClearTixing_ES_HETONG_BAJH(strErrMsg, strUserId, strPassword, strWYBS)
            End With
        End Function

        '----------------------------------------------------------------
        ' 打开“地产_B_二手_交易合同办案计划”指定业务的提醒
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strWYBS              ：唯一标识
        '     intKBTS              ：开办天数
        '     intBWTS              ：办完天数
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doSetupTixing_ES_HETONG_BAJH( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWYBS As String, _
            ByVal intKBTS As Integer, _
            ByVal intBWTS As Integer) As Boolean
            With m_objrulesEstateErshou
                doSetupTixing_ES_HETONG_BAJH = .doSetupTixing_ES_HETONG_BAJH(strErrMsg, strUserId, strPassword, strWYBS, intKBTS, intBWTS)
            End With
        End Function

        '----------------------------------------------------------------
        ' 获取指定strQRSH的指定审核类型intSHLX的折扣审核签名
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strQRSH              ：确认书号
        '     intSHLX              ：审核类型
        '     strSHQM              ：返回折扣审核签名
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function getHetongZhekouSHQM( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal intSHLX As Integer, _
            ByRef strSHQM As String) As Boolean
            With m_objrulesEstateErshou
                getHetongZhekouSHQM = .getHetongZhekouSHQM(strErrMsg, strUserId, strPassword, strQRSH, intSHLX, strSHQM)
            End With
        End Function

        '----------------------------------------------------------------
        ' 获取指定审核类型的上限、下限折扣
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     intSHLX              ：审核类型
        '     dblZKSX              ：返回折扣上限
        '     dblZKXX              ：返回折扣下限
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function getHetongZhekouSXX( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal intSHLX As Integer, _
            ByRef dblZKSX As Double, _
            ByRef dblZKXX As Double) As Boolean
            With m_objrulesEstateErshou
                getHetongZhekouSXX = .getHetongZhekouSXX(strErrMsg, strUserId, strPassword, intSHLX, dblZKSX, dblZKXX)
            End With
        End Function

        '----------------------------------------------------------------
        ' 获取指定折扣的需要的折扣审核最高级别
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     dblZK                ：指定折扣
        '     intSHLX              ：返回折扣审核最高级别(0,1,2,4)
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function getHetongZhekouSHJB( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal dblZK As Double, _
            ByRef intSHLX As Integer) As Boolean
            With m_objrulesEstateErshou
                getHetongZhekouSHJB = .getHetongZhekouSHJB(strErrMsg, strUserId, strPassword, dblZK, intSHLX)
            End With
        End Function

        '----------------------------------------------------------------
        ' 获取合同结算中介费总额
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strQRSH              ：确认书号
        '     dblSum               ：结算中介费总额
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function getHetongJiesuanSum( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByRef dblSum As Double) As Boolean
            With m_objrulesEstateErshou
                getHetongJiesuanSum = .getHetongJiesuanSum(strErrMsg, strUserId, strPassword, strQRSH, dblSum)
            End With
        End Function











        '----------------------------------------------------------------
        ' 根据“确认书号”获取“地产_B_二手_交易合同结算书”完全数据的数据集
        ' 以“结算日期”排序
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strQRSH                    ：确认书号
        '     strWhere                   ：搜索字符串
        '     objestateErshouData        ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_ES_HETONG_JSS( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal strWhere As String, _
            ByRef objestateErshouData As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_HETONG_JSS = .getDataSet_ES_HETONG_JSS(strErrMsg, strUserId, strPassword, strQRSH, strWhere, objestateErshouData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 根据“结算书号”获取“地产_B_二手_交易合同结算书”完全数据的数据集
        ' 以“结算日期”排序
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strJSSH                    ：结算书号
        '     objestateErshouData        ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_ES_HETONG_JSS( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strJSSH As String, _
            ByRef objestateErshouData As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_HETONG_JSS = .getDataSet_ES_HETONG_JSS(strErrMsg, strUserId, strPassword, strJSSH, objestateErshouData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 根据“结算书号”获取“地产_B_二手_交易合同结算书明细表”完全数据的数据集
        ' 以“税费代码”排序
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strJSSH                    ：结算书号
        '     objestateErshouData        ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_ES_HETONG_JSS_MX( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strJSSH As String, _
            ByRef objestateErshouData As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_HETONG_JSS_MX = .getDataSet_ES_HETONG_JSS_MX(strErrMsg, strUserId, strPassword, strJSSH, objestateErshouData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 根据“结算书号”获取“地产_B_二手_交易合同结算书业绩”完全数据的数据集
        ' 以“单位代码”、“人员职级”排序
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strJSSH                    ：结算书号
        '     objestateErshouData        ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_ES_HETONG_JSS_YEJI( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strJSSH As String, _
            ByRef objestateErshouData As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_HETONG_JSS_YEJI = .getDataSet_ES_HETONG_JSS_YEJI(strErrMsg, strUserId, strPassword, strJSSH, objestateErshouData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 保存“地产_B_二手_交易合同结算书”数据记录(整个事务完成)
        '     strErrMsg              ：如果错误，则返回错误信息
        '     strUserId              ：用户标识
        '     strPassword            ：用户密码
        '     objNewData             ：记录新值(返回保存后的新值)
        '     objOldData             ：记录旧值
        '     objenumEditType        ：编辑类型
        '     objDataSet_JSMX        ：结算明细数据集
        '     objDataSet_YEJI        ：结算业绩数据集
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
        '----------------------------------------------------------------
        Public Function doSaveData_ES_HETONG_JSS( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objOldData As System.Data.DataRow, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType, _
            ByVal objDataSet_JSMX As Josco.JSOA.Common.Data.estateErshouData, _
            ByVal objDataSet_YEJI As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                doSaveData_ES_HETONG_JSS = .doSaveData_ES_HETONG_JSS(strErrMsg, strUserId, strPassword, objNewData, objOldData, objenumEditType, objDataSet_JSMX, objDataSet_YEJI)
            End With
        End Function

        '----------------------------------------------------------------
        ' 删除“地产_B_二手_交易合同结算书”记录及相关记录
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：连接用户名
        '     strPassword          ：连接用户密码
        '     strWYBS              ：要删除的唯一标识
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doDeleteData_ES_HETONG_JSS( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWYBS As String) As Boolean
            With m_objrulesEstateErshou
                doDeleteData_ES_HETONG_JSS = .doDeleteData_ES_HETONG_JSS(strErrMsg, strUserId, strPassword, strWYBS)
            End With
        End Function

        '----------------------------------------------------------------
        ' 获取“确认书号”获取“代理费折扣”
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strQRSH              ：确认书号
        '     dblHTZK              ：(返回)代理费折扣
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function getHtzkByQrsh( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByRef dblHTZK As Double) As Boolean
            With m_objrulesEstateErshou
                getHtzkByQrsh = .getHtzkByQrsh(strErrMsg, strUserId, strPassword, strQRSH, dblHTZK)
            End With
        End Function

        '----------------------------------------------------------------
        ' 根据“确认书号”、“合同折扣”、“中介费额”、“结算类型”计算
        ' 私佣、公佣、考核业绩等数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strQRSH              ：确认书号
        '     dblHTZK              ：代理费折扣
        '     dblZJFE              ：中介费额
        '     intJSLX              ：结算类型
        '     objDataSet_Yeji      ：返回业绩数据集
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doComputeYeji( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal dblHTZK As Double, _
            ByVal dblZJFE As Double, _
            ByVal intJSLX As Integer, _
            ByRef objDataSet_Yeji As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                doComputeYeji = .doComputeYeji(strErrMsg, strUserId, strPassword, strQRSH, dblHTZK, dblZJFE, intJSLX, objDataSet_Yeji)
            End With
        End Function











        '----------------------------------------------------------------
        ' 根据“确认书号”获取“地产_B_二手_交易合同折扣审核”完全数据的数据集
        ' 以“审核日期”排序
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strQRSH                    ：确认书号
        '     strWhere                   ：搜索字符串
        '     objestateErshouData        ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_ES_HETONG_ZKSH( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal strWhere As String, _
            ByRef objestateErshouData As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_HETONG_ZKSH = .getDataSet_ES_HETONG_ZKSH(strErrMsg, strUserId, strPassword, strQRSH, strWhere, objestateErshouData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 合同折扣审核处理
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：连接用户名
        '     strPassword          ：连接用户密码
        '     strQRSH              ：确认书号
        '     strSHRDM             ：审核人代码
        '     objSHLX              ：审核类型
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doZhekouShenHe_ES_HETONG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal strSHRDM As String, _
            ByVal objSHLX As Josco.JSOA.Common.Data.estateErshouData.enumZhekouShenheType) As Boolean
            With m_objrulesEstateErshou
                doZhekouShenHe_ES_HETONG = .doZhekouShenHe_ES_HETONG(strErrMsg, strUserId, strPassword, strQRSH, strSHRDM, objSHLX)
            End With
        End Function











        '----------------------------------------------------------------
        ' 获取“地产_B_二手_交易合同结算书”完全数据的数据集
        ' 以“结算日期”排序
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strJSSH                    ：结算书号
        '     strWhere                   ：搜索字符串
        '     blnControl                 ：权限控制
        '     objestateErshouData        ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_ES_HETONG_JSS( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strJSSH As String, _
            ByVal strWhere As String, _
            ByVal blnControl As Boolean, _
            ByRef objestateErshouData As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_HETONG_JSS = .getDataSet_ES_HETONG_JSS(strErrMsg, strUserId, strPassword, strJSSH, strWhere, blnControl, objestateErshouData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 结算书审核处理
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：连接用户名
        '     strPassword          ：连接用户密码
        '     strQRSH              ：确认书号
        '     strJSSH              ：结算书号
        '     strSHRDM             ：审核人代码
        '     objSHLX              ：审核类型
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doShenHe_ES_HETONG_JSS( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal strJSSH As String, _
            ByVal strSHRDM As String, _
            ByVal objSHLX As Josco.JSOA.Common.Data.estateErshouData.enumShenheStatus) As Boolean
            With m_objrulesEstateErshou
                doShenHe_ES_HETONG_JSS = .doShenHe_ES_HETONG_JSS(strErrMsg, strUserId, strPassword, strQRSH, strJSSH, strSHRDM, objSHLX)
            End With
        End Function

        '----------------------------------------------------------------
        ' 根据“结算书号”获取“地产_B_二手_交易合同结算书审核签名”完全数据的数据集
        ' 以“审核日期”排序
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strJSSH                    ：结算书号
        '     strWhere                   ：搜索字符串
        '     objestateErshouData        ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_ES_HETONG_JSS_SHQK( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strJSSH As String, _
            ByVal strWhere As String, _
            ByRef objestateErshouData As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_HETONG_JSS_SHQK = .getDataSet_ES_HETONG_JSS_SHQK(strErrMsg, strUserId, strPassword, strJSSH, strWhere, objestateErshouData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 判断给定的结算书是否已审核？
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strJSSH              ：结算书号
        '     blnIS                ：返回是否
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function isJiesuanshuYiShen( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strJSSH As String, _
            ByRef blnIS As Boolean) As Boolean
            With m_objrulesEstateErshou
                isJiesuanshuYiShen = .isJiesuanshuYiShen(strErrMsg, strUserId, strPassword, strJSSH, blnIS)
            End With
        End Function

        '----------------------------------------------------------------
        ' 获取“确认书号”获取“合同日期”
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：人员代码
        '     strQRSH              ：确认书号
        '     strHTBH              ：(返回)合同编号
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        ' 更改描述
        '     zengxianglin 2008-10-14 创建
        '----------------------------------------------------------------
        Public Function getHtrqByQrsh( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByRef strHTRQ As String) As Boolean
            With m_objrulesEstateErshou
                getHtrqByQrsh = .getHtrqByQrsh(strErrMsg, strUserId, strPassword, strQRSH, strHTRQ)
            End With
        End Function

        '----------------------------------------------------------------
        ' 根据[人员代码]、[指定时间]计算业务人员的所属单位、职级、所属分组信息
        ' 适用于[管理架构]中的人员
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：人员代码
        '     strRYDM              ：确认书号
        '     strJCSJ              ：指定时间
        '     objRYJGXX            ：(返回)业务人员的所属单位、职级、所属分组信息
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        ' 更改描述
        '     zengxianglin 2008-10-14 创建
        '----------------------------------------------------------------
        Public Function getRYJGXX( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strRYDM As String, _
            ByVal strJCSJ As String, _
            ByRef objRYJGXX As System.Collections.Specialized.NameValueCollection) As Boolean
            With m_objrulesEstateErshou
                getRYJGXX = .getRYJGXX(strErrMsg, strUserId, strPassword, strRYDM, strJCSJ, objRYJGXX)
            End With
        End Function











        '----------------------------------------------------------------
        ' 获取“地产_B_二手_确认书其他”完全数据的数据集
        ' 以“订购日期”排序
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strWhere                   ：搜索字符串
        '     blnControl                 ：进行查看限制
        '     objestateErshouData        ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改记录
        '     zengxianglin 2008-11-17 创建
        '----------------------------------------------------------------
        Public Function getDataSet_ES_QRS_QT( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByVal blnControl As Boolean, _
            ByRef objestateErshouData As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_QRS_QT = .getDataSet_ES_QRS_QT(strErrMsg, strUserId, strPassword, strWhere, blnControl, objestateErshouData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 根据“确认书号”获取“地产_B_二手_确认书其他”完全数据的数据集
        ' 以“订购日期”排序
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strQRSH                    ：确认书号
        '     strWhere                   ：搜索字符串
        '     objestateErshouData        ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改记录
        '     zengxianglin 2008-11-17 创建
        '----------------------------------------------------------------
        Public Function getDataSet_ES_QRS_QT( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal strWhere As String, _
            ByRef objestateErshouData As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_QRS_QT = .getDataSet_ES_QRS_QT(strErrMsg, strUserId, strPassword, strQRSH, strWhere, objestateErshouData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 根据“确认书号”获取“地产_B_二手_物业其他”完全数据的数据集
        ' 以“房屋地址”排序
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strQRSH                    ：确认书号
        '     strWhere                   ：搜索字符串
        '     objestateErshouData        ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改记录
        '     zengxianglin 2008-11-17 创建
        '----------------------------------------------------------------
        Public Function getDataSet_ES_WUYE_QT( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal strWhere As String, _
            ByRef objestateErshouData As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_WUYE_QT = .getDataSet_ES_WUYE_QT(strErrMsg, strUserId, strPassword, strQRSH, strWhere, objestateErshouData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 获取“地产_B_二手_确认书其他”中的新的“确认书号”
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strQRSH              ：确认书号
        ' 返回
        '     True                 ：合法
        '     False                ：不合法或其他程序错误
        ' 更改记录
        '     zengxianglin 2008-11-17 创建
        '----------------------------------------------------------------
        Public Function getNewQRSH_QT( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef strQRSH As String) As Boolean
            With m_objrulesEstateErshou
                getNewQRSH_QT = .getNewQRSH_QT(strErrMsg, strUserId, strPassword, strQRSH)
            End With
        End Function

        '----------------------------------------------------------------
        ' 检查“地产_B_二手_物业其他”的数据类型的合法性
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objNewData           ：新数据
        ' 返回
        '     True                 ：合法
        '     False                ：不合法或其他程序错误
        ' 更改记录
        '     zengxianglin 2008-11-17 创建
        '----------------------------------------------------------------
        Public Function doVerifyData_ES_WUYE_QT( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection) As Boolean
            With m_objrulesEstateErshou
                doVerifyData_ES_WUYE_QT = .doVerifyData_ES_WUYE_QT(strErrMsg, strUserId, strPassword, objNewData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 保存“地产_B_二手_确认书其他”数据记录(整个事务完成)
        '     strErrMsg              ：如果错误，则返回错误信息
        '     strUserId              ：用户标识
        '     strPassword            ：用户密码
        '     objNewData             ：记录新值(返回保存后的新值)
        '     objOldData             ：记录旧值
        '     objenumEditType        ：编辑类型
        '     objDataSet_WYXX        ：物业信息数据集
        '     objDataSet_YWRY        ：业务人员数据集
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
        ' 更改记录
        '     zengxianglin 2008-11-17 创建
        '----------------------------------------------------------------
        Public Function doSaveData_ES_QRS_QT( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objOldData As System.Data.DataRow, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType, _
            ByVal objDataSet_WYXX As Josco.JSOA.Common.Data.estateErshouData, _
            ByVal objDataSet_YWRY As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                doSaveData_ES_QRS_QT = .doSaveData_ES_QRS_QT(strErrMsg, strUserId, strPassword, objNewData, objOldData, objenumEditType, objDataSet_WYXX, objDataSet_YWRY)
            End With
        End Function

        '----------------------------------------------------------------
        ' 删除“地产_B_二手_确认书其他”记录及相关记录
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：连接用户名
        '     strPassword          ：连接用户密码
        '     strWYBS              ：要删除的唯一标识
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        ' 更改记录
        '     zengxianglin 2008-11-17 创建
        '----------------------------------------------------------------
        Public Function doDeleteData_ES_QRS_QT( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWYBS As String) As Boolean
            With m_objrulesEstateErshou
                doDeleteData_ES_QRS_QT = .doDeleteData_ES_QRS_QT(strErrMsg, strUserId, strPassword, strWYBS)
            End With
        End Function

        '----------------------------------------------------------------
        ' “地产_B_二手_确认书其他”挞定处理
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：连接用户名
        '     strPassword          ：连接用户密码
        '     strWYBS              ：唯一标识
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        ' 更改记录
        '     zengxianglin 2008-11-17 创建
        '----------------------------------------------------------------
        Public Function doTading_ES_QRS_QT( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWYBS As String) As Boolean
            With m_objrulesEstateErshou
                doTading_ES_QRS_QT = .doTading_ES_QRS_QT(strErrMsg, strUserId, strPassword, strWYBS)
            End With
        End Function

        '----------------------------------------------------------------
        ' 获取“地产_B_二手_交易合同”中的新的其他业务的“合同编号”
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strHTBH              ：合同编号
        ' 返回
        '     True                 ：合法
        '     False                ：不合法或其他程序错误
        ' 更改记录
        '     zengxianglin 2008-11-17 创建
        '----------------------------------------------------------------
        Public Function getNewHTBH_QT( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef strHTBH As String) As Boolean
            With m_objrulesEstateErshou
                getNewHTBH_QT = .getNewHTBH_QT(strErrMsg, strUserId, strPassword, strHTBH)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算交易的客户名称
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strJYBH              ：交易编号
        '     strSFDX              ：甲/乙
        '     strKHMC              ：客户名称(返回)
        ' 返回
        '     True                 ：合法
        '     False                ：不合法或其他程序错误
        ' 更改记录
        '     zengxianglin 2008-11-17 创建
        '----------------------------------------------------------------
        Public Function getKHMC( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strJYBH As String, _
            ByVal strSFDX As String, _
            ByRef strKHMC As String) As Boolean
            With m_objrulesEstateErshou
                getKHMC = .getKHMC(strErrMsg, strUserId, strPassword, strJYBH, strSFDX, strKHMC)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算交易的业务类型
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strJYBH              ：交易编号
        '     strYWLX              ：业务类型(返回)
        ' 返回
        '     True                 ：合法
        '     False                ：不合法或其他程序错误
        ' 更改记录
        '     zengxianglin 2008-11-18 创建
        '----------------------------------------------------------------
        Public Function getYWLX( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strJYBH As String, _
            ByRef strYWLX As String) As Boolean
            With m_objrulesEstateErshou
                getYWLX = .getYWLX(strErrMsg, strUserId, strPassword, strJYBH, strYWLX)
            End With
        End Function

        '----------------------------------------------------------------
        ' 判断指定人员是否为指定单位的直管？
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strRYDM              ：人员代码
        '     strDWDM              ：单位代码
        '     strJCSJ              ：检测时间
        '     blnIS                ：是否(返回)
        ' 返回
        '     True                 ：合法
        '     False                ：不合法或其他程序错误
        ' 更改记录
        '     zengxianglin 2008-11-18 创建
        '----------------------------------------------------------------
        Public Function IsZhiguan( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strRYDM As String, _
            ByVal strDWDM As String, _
            ByVal strJCSJ As String, _
            ByRef blnIS As Boolean) As Boolean
            With m_objrulesEstateErshou
                IsZhiguan = .IsZhiguan(strErrMsg, strUserId, strPassword, strRYDM, strDWDM, strJCSJ, blnIS)
            End With
        End Function

        '----------------------------------------------------------------
        ' 保存“地产_B_二手_交易合同办案计划”的数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strQRSH              ：确认书号
        '     objDataSet           ：要保存的数据
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        ' 更改描述
        '     zengxianglin 2008-11-18 创建
        '----------------------------------------------------------------
        Public Function doSaveData_ES_HETONG_BAJH( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal objDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                doSaveData_ES_HETONG_BAJH = .doSaveData_ES_HETONG_BAJH(strErrMsg, strUserId, strPassword, strQRSH, objDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算指定人员的开办提醒的业务数目
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strRYDM                   ：人员代码
        '     intYWSM                   ：业务数目(返回)
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        ' 更改描述
        '     zengxianglin 2008-11-18 创建
        '----------------------------------------------------------------
        Public Function getCount_KBTX( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strRYDM As String, _
            ByRef intYWSM As Integer) As Boolean
            With m_objrulesEstateErshou
                getCount_KBTX = .getCount_KBTX(strErrMsg, strUserId, strPassword, strRYDM, intYWSM)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算指定人员的办完提醒的业务数目
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strRYDM                   ：人员代码
        '     intYWSM                   ：业务数目(返回)
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        ' 更改描述
        '     zengxianglin 2008-11-18 创建
        '----------------------------------------------------------------
        Public Function getCount_BWTX( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strRYDM As String, _
            ByRef intYWSM As Integer) As Boolean
            With m_objrulesEstateErshou
                getCount_BWTX = .getCount_BWTX(strErrMsg, strUserId, strPassword, strRYDM, intYWSM)
            End With
        End Function

        '----------------------------------------------------------------
        ' 判断给定的合同是否有人审核？
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strQRSH              ：确认书号
        '     blnIS                ：返回是否
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        ' 更改描述
        '     zengxianglin 2008-11-22 创建
        '----------------------------------------------------------------
        Public Function isHetongDoneShenhe( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByRef blnIS As Boolean) As Boolean
            With m_objrulesEstateErshou
                isHetongDoneShenhe = .isHetongDoneShenhe(strErrMsg, strUserId, strPassword, strQRSH, blnIS)
            End With
        End Function

        '----------------------------------------------------------------
        ' 判断给定的合同是否有做办案计划？
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strQRSH              ：确认书号
        '     blnIS                ：返回是否
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        ' 更改描述
        '     zengxianglin 2008-11-22 创建
        '----------------------------------------------------------------
        Public Function isHetongDoneBAJH( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByRef blnIS As Boolean) As Boolean
            With m_objrulesEstateErshou
                isHetongDoneBAJH = .isHetongDoneBAJH(strErrMsg, strUserId, strPassword, strQRSH, blnIS)
            End With
        End Function

        '----------------------------------------------------------------
        ' 判断给定的合同是否有做业绩分配方案？
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strQRSH              ：确认书号
        '     blnIS_SY             ：返回是否做私俑
        '     blnIS_GY             ：返回是否做公俑
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        ' 更改描述
        '     zengxianglin 2008-11-22 创建
        '----------------------------------------------------------------
        Public Function isHetongDoneFPBL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByRef blnIS_SY As Boolean, _
            ByRef blnIS_GY As Boolean) As Boolean
            With m_objrulesEstateErshou
                isHetongDoneFPBL = .isHetongDoneFPBL(strErrMsg, strUserId, strPassword, strQRSH, blnIS_SY, blnIS_GY)
            End With
        End Function

        '----------------------------------------------------------------
        ' 判断给定的结算书是否有做业绩分配？
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strJSSH              ：结算书号
        '     blnIS                ：返回是否
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        ' 更改描述
        '     zengxianglin 2008-11-22 创建
        '----------------------------------------------------------------
        Public Function isJssDoneYJFP( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strJSSH As String, _
            ByRef blnIS As Boolean) As Boolean
            With m_objrulesEstateErshou
                isJssDoneYJFP = .isJssDoneYJFP(strErrMsg, strUserId, strPassword, strJSSH, blnIS)
            End With
        End Function











        '----------------------------------------------------------------
        ' 计算中介部二手代理结算情况表（各分行）的数据
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strKSRQ                    ：开始日期
        '     strZZRQ                    ：终止日期
        '     objestateErshouData        ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改描述
        '     zengxianglin 2008-11-24 创建
        '----------------------------------------------------------------
        Public Function getDataSet_BB_ESDLJSQKB_GFH( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strKSRQ As String, _
            ByVal strZZRQ As String, _
            ByRef objDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_ESDLJSQKB_GFH = .getDataSet_BB_ESDLJSQKB_GFH(strErrMsg, strUserId, strPassword, strKSRQ, strZZRQ, objDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 更改“地产_B_二手_交易合同”指定记录的[按揭返还]字段
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：连接用户名
        '     strPassword          ：连接用户密码
        '     strQRSH              ：确认书号
        '     dblAJFH              ：按揭返还额
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        ' 更改描述
        '     zengxianglin 2008-11-25 创建
        '----------------------------------------------------------------
        Public Function doUpdateData_ES_HETONG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal dblAJFH As Double) As Boolean
            With m_objrulesEstateErshou
                doUpdateData_ES_HETONG = .doUpdateData_ES_HETONG(strErrMsg, strUserId, strPassword, strQRSH, dblAJFH)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算中介部二手代理结算情况表（各业务）的数据
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strKSRQ                    ：开始日期
        '     strZZRQ                    ：终止日期
        '     objestateErshouData        ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改描述
        '     zengxianglin 2008-11-26 创建
        '----------------------------------------------------------------
        Public Function getDataSet_BB_ESDLJSQKB_GYW( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strKSRQ As String, _
            ByVal strZZRQ As String, _
            ByRef objDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_ESDLJSQKB_GYW = .getDataSet_BB_ESDLJSQKB_GYW(strErrMsg, strUserId, strPassword, strKSRQ, strZZRQ, objDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算中介部二手代理接案情况表（各分行）的数据
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strKSRQ                    ：开始日期
        '     strZZRQ                    ：终止日期
        '     objestateErshouData        ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改描述
        '     zengxianglin 2008-11-26 创建
        '----------------------------------------------------------------
        Public Function getDataSet_BB_ESDLJAQKB_GFH( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strKSRQ As String, _
            ByVal strZZRQ As String, _
            ByRef objDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_ESDLJAQKB_GFH = .getDataSet_BB_ESDLJAQKB_GFH(strErrMsg, strUserId, strPassword, strKSRQ, strZZRQ, objDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算中介部二手代理结案情况表（各分行）的数据
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strKSRQ                    ：开始日期
        '     strZZRQ                    ：终止日期
        '     objestateErshouData        ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改描述
        '     zengxianglin 2008-11-26 创建
        '----------------------------------------------------------------
        Public Function getDataSet_BB_ESDLWCQKB_GFH( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strKSRQ As String, _
            ByVal strZZRQ As String, _
            ByRef objDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_ESDLWCQKB_GFH = .getDataSet_BB_ESDLWCQKB_GFH(strErrMsg, strUserId, strPassword, strKSRQ, strZZRQ, objDataSet)
            End With
        End Function










        '----------------------------------------------------------------
        ' 获取[地产_B_二手_交易年度计划]数据
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strWhere                   ：搜索条件
        '     objDataSet                 ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改描述
        '     zengxianglin 2008-11-28 创建
        '----------------------------------------------------------------
        Public Function getDataSet_ES_JYNDJH( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_JYNDJH = .getDataSet_ES_JYNDJH(strErrMsg, strUserId, strPassword, strWhere, objDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 获取[地产_B_二手_交易年度计划]数据
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     intJHND                    ：计划年度
        '     objDataSet                 ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改描述
        '     zengxianglin 2008-11-28 创建
        '----------------------------------------------------------------
        Public Function getDataSet_ES_JYNDJH( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal intJHND As Integer, _
            ByRef objDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_JYNDJH = .getDataSet_ES_JYNDJH(strErrMsg, strUserId, strPassword, intJHND, objDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 保存“地产_B_二手_交易年度计划”数据记录(整个事务完成)
        '     strErrMsg              ：如果错误，则返回错误信息
        '     strUserId              ：用户标识
        '     strPassword            ：用户密码
        '     intJHND                ：计划年度
        '     objDataSet             ：计划新值
        '     objenumEditType        ：编辑模式
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
        ' 更改描述
        '     zengxianglin 2008-11-28 创建
        '----------------------------------------------------------------
        Public Function doSaveData_ES_JYNDJH( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal intJHND As Integer, _
            ByVal objNewData As Josco.JSOA.Common.Data.estateErshouData, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean
            With m_objrulesEstateErshou
                doSaveData_ES_JYNDJH = .doSaveData_ES_JYNDJH(strErrMsg, strUserId, strPassword, intJHND, objNewData, objenumEditType)
            End With
        End Function

        '----------------------------------------------------------------
        ' 删除“地产_B_二手_交易年度计划”记录
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：连接用户名
        '     strPassword          ：连接用户密码
        '     strWYBS              ：要删除的唯一标识
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        ' 更改描述
        '     zengxianglin 2008-11-28 创建
        '----------------------------------------------------------------
        Public Function doDeleteData_ES_JYNDJH( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWYBS As String) As Boolean
            With m_objrulesEstateErshou
                doDeleteData_ES_JYNDJH = .doDeleteData_ES_JYNDJH(strErrMsg, strUserId, strPassword, strWYBS)
            End With
        End Function

        '----------------------------------------------------------------
        ' 删除“地产_B_二手_交易年度计划”记录
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：连接用户名
        '     strPassword          ：连接用户密码
        '     intJHND              ：要删除的计划年度
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        ' 更改描述
        '     zengxianglin 2008-11-28 创建
        '----------------------------------------------------------------
        Public Function doDeleteData_ES_JYNDJH( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal intJHND As Integer) As Boolean
            With m_objrulesEstateErshou
                doDeleteData_ES_JYNDJH = .doDeleteData_ES_JYNDJH(strErrMsg, strUserId, strPassword, intJHND)
            End With
        End Function

        '----------------------------------------------------------------
        ' 判断指定年度的[地产_B_二手_交易年度计划]是否存在？
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     intJHND              ：计划年度
        '     blnHas               ：是否存在(返回)
        ' 返回
        '     True                 ：合法
        '     False                ：不合法或其他程序错误
        ' 更改记录
        '     zengxianglin 2008-11-28 创建
        '----------------------------------------------------------------
        Public Function isJyndjhExisted( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal intJHND As Integer, _
            ByRef blnHas As Boolean) As Boolean
            With m_objrulesEstateErshou
                isJyndjhExisted = .isJyndjhExisted(strErrMsg, strUserId, strPassword, intJHND, blnHas)
            End With
        End Function












        '----------------------------------------------------------------
        ' 计算中介部二手代理结算情况表（各月度）的数据
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     intND                      ：年度
        '     intYD                      ：月度
        '     intYJZR                    ：月截止日
        '     objestateErshouData        ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改描述
        '     zengxianglin 2008-11-28 创建
        '----------------------------------------------------------------
        Public Function getDataSet_BB_ESDLJSQKB_GYD( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal intND As Integer, _
            ByVal intYD As Integer, _
            ByVal intYJZR As Integer, _
            ByRef objDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_ESDLJSQKB_GYD = .getDataSet_BB_ESDLJSQKB_GYD(strErrMsg, strUserId, strPassword, intND, intYD, intYJZR, objDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算中介部二手业务代理清单(接案)的数据
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strKSRQ                    ：开始日期
        '     strZZRQ                    ：终止日期
        '     strBMDM                    ：部门代码
        '     objestateErshouData        ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改描述
        '     zengxianglin 2008-11-28 创建
        '----------------------------------------------------------------
        Public Function getDataSet_BB_ESYWDLQD_JA( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strKSRQ As String, _
            ByVal strZZRQ As String, _
            ByVal strBMDM As String, _
            ByRef objDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_ESYWDLQD_JA = .getDataSet_BB_ESYWDLQD_JA(strErrMsg, strUserId, strPassword, strKSRQ, strZZRQ, strBMDM, objDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算中介部二手业务代理清单(接案)的数据(未审合同)
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strKSRQ                    ：开始日期
        '     strZZRQ                    ：终止日期
        '     strBMDM                    ：部门代码
        '     objDataSet                 ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改描述
        '     zengxianglin 2009-02-24 创建
        '----------------------------------------------------------------
        Public Function getDataSet_BB_ESYWDLQD_JA_WS( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strKSRQ As String, _
            ByVal strZZRQ As String, _
            ByVal strBMDM As String, _
            ByRef objDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_ESYWDLQD_JA_WS = .getDataSet_BB_ESYWDLQD_JA_WS(strErrMsg, strUserId, strPassword, strKSRQ, strZZRQ, strBMDM, objDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算中介部二手业务代理清单(结案)的数据
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strKSRQ                    ：开始日期
        '     strZZRQ                    ：终止日期
        '     strBMDM                    ：部门代码
        '     objestateErshouData        ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改描述
        '     zengxianglin 2008-11-28 创建
        '----------------------------------------------------------------
        Public Function getDataSet_BB_ESYWDLQD_WC( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strKSRQ As String, _
            ByVal strZZRQ As String, _
            ByVal strBMDM As String, _
            ByRef objDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_ESYWDLQD_WC = .getDataSet_BB_ESYWDLQD_WC(strErrMsg, strUserId, strPassword, strKSRQ, strZZRQ, strBMDM, objDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算中介部二手业务代理清单(已接未结案)的数据
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strKSRQ                    ：开始日期
        '     strZZRQ                    ：终止日期
        '     strBMDM                    ：部门代码
        '     objestateErshouData        ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改描述
        '     zengxianglin 2008-11-28 创建
        '----------------------------------------------------------------
        Public Function getDataSet_BB_ESYWDLQD_YJWJ( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strKSRQ As String, _
            ByVal strZZRQ As String, _
            ByVal strBMDM As String, _
            ByRef objDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_ESYWDLQD_YJWJ = .getDataSet_BB_ESYWDLQD_YJWJ(strErrMsg, strUserId, strPassword, strKSRQ, strZZRQ, strBMDM, objDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算中介部二手业务计佣清单(私佣)的数据
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strKSRQ                    ：开始日期
        '     strZZRQ                    ：终止日期
        '     strBMDM                    ：部门代码
        '     objestateErshouData        ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改描述
        '     zengxianglin 2008-12-01 创建
        '----------------------------------------------------------------
        Public Function getDataSet_BB_ESJYQD_SY( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strKSRQ As String, _
            ByVal strZZRQ As String, _
            ByVal strBMDM As String, _
            ByRef objDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_ESJYQD_SY = .getDataSet_BB_ESJYQD_SY(strErrMsg, strUserId, strPassword, strKSRQ, strZZRQ, strBMDM, objDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算中介部二手业务计佣清单(公佣)的数据
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strKSRQ                    ：开始日期
        '     strZZRQ                    ：终止日期
        '     strBMDM                    ：部门代码
        '     objestateErshouData        ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改描述
        '     zengxianglin 2008-12-01 创建
        '----------------------------------------------------------------
        Public Function getDataSet_BB_ESJYQD_GY( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strKSRQ As String, _
            ByVal strZZRQ As String, _
            ByVal strBMDM As String, _
            ByRef objDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_ESJYQD_GY = .getDataSet_BB_ESJYQD_GY(strErrMsg, strUserId, strPassword, strKSRQ, strZZRQ, strBMDM, objDataSet)
            End With
        End Function










        '----------------------------------------------------------------
        ' 计算中介部二手计佣清单(公佣补发)的数据
        ' 重新计算指定月底时应补发的数据
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     intND                      ：年度
        '     intYD                      ：月度
        '     intYJZR                    ：月截止日
        '     blnNew                     ：接口重载
        '     objestateErshouData        ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改描述
        '     zengxianglin 2008-12-01 创建
        '----------------------------------------------------------------
        Public Function getDataSet_BB_ESJYQD_GYBF( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal intND As Integer, _
            ByVal intYD As Integer, _
            ByVal intYJZR As Integer, _
            ByVal blnNew As Boolean, _
            ByRef objDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_ESJYQD_GYBF = .getDataSet_BB_ESJYQD_GYBF(strErrMsg, strUserId, strPassword, intND, intYD, intYJZR, blnNew, objDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算中介部二手计佣清单(公佣补发)的数据
        ' 获取现有数据
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     intND                      ：年度
        '     intYD                      ：月度
        '     intYJZR                    ：月截止日
        '     objestateErshouData        ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改描述
        '     zengxianglin 2008-12-01 创建
        '----------------------------------------------------------------
        Public Function getDataSet_BB_ESJYQD_GYBF( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal intND As Integer, _
            ByVal intYD As Integer, _
            ByVal intYJZR As Integer, _
            ByRef objDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_ESJYQD_GYBF = .getDataSet_BB_ESJYQD_GYBF(strErrMsg, strUserId, strPassword, intND, intYD, intYJZR, objDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 判断给定年度、月度的公佣补发[地产_B_二手_交易合同结算书业绩补发]数据是否存在？
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     intND                ：年度
        '     intYD                ：月度
        '     intMode              ：0-等于,1-大于
        '     blnHas               ：返回是否存在
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        ' 更改描述
        '     zengxianglin 2008-12-01 创建
        '----------------------------------------------------------------
        Public Function isGYBFExisted( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal intND As Integer, _
            ByVal intYD As Integer, _
            ByVal intMode As Integer, _
            ByRef blnHas As Boolean) As Boolean
            With m_objrulesEstateErshou
                isGYBFExisted = .isGYBFExisted(strErrMsg, strUserId, strPassword, intND, intYD, intMode, blnHas)
            End With
        End Function

        '----------------------------------------------------------------
        ' 保存“地产_B_二手_交易合同结算书业绩补发”数据记录(整个事务完成)
        '     strErrMsg              ：如果错误，则返回错误信息
        '     strUserId              ：用户标识
        '     strPassword            ：用户密码
        '     intND                  ：年度
        '     intYD                  ：月度
        '     objDataSet_YJBF        ：要保存的数据
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
        '----------------------------------------------------------------
        Public Function doSaveData_ES_JYHTJSSYJBF( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal intND As Integer, _
            ByVal intYD As Integer, _
            ByVal objDataSet_YJBF As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                doSaveData_ES_JYHTJSSYJBF = .doSaveData_ES_JYHTJSSYJBF(strErrMsg, strUserId, strPassword, intND, intYD, objDataSet_YJBF)
            End With
        End Function











        '----------------------------------------------------------------
        ' 计算中介部二手代理区域情况表的数据
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strKSRQ                    ：开始日期
        '     strZZRQ                    ：终止日期
        '     intType                    ：统计类型：0-接案，1-结案，2-已接未结案
        '     objestateErshouData        ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改描述
        '     zengxianglin 2008-12-01 创建
        '----------------------------------------------------------------
        Public Function getDataSet_BB_ESDLQYQKB( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strKSRQ As String, _
            ByVal strZZRQ As String, _
            ByVal intType As Integer, _
            ByRef objDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_ESDLQYQKB = .getDataSet_BB_ESDLQYQKB(strErrMsg, strUserId, strPassword, strKSRQ, strZZRQ, intType, objDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算中介部二手区域业绩排行榜的数据
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strKSRQ                    ：开始日期
        '     strZZRQ                    ：终止日期
        '     intType                    ：统计类型：0-接案，1-结案，2-已接未结案
        '     objDataSet                 ：信息数据集
        '                                  0-排序:面积
        '                                  1-排序:套数
        '                                  2-排序:宗数
        '                                  3-排序:代理费
        '                                  4-排序:按揭返还
        '                                  5-排序:交易金额
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改描述
        '     zengxianglin 2008-12-01 创建
        '----------------------------------------------------------------
        Public Function getDataSet_BB_ESPHBQYYJ( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strKSRQ As String, _
            ByVal strZZRQ As String, _
            ByVal intType As Integer, _
            ByRef objDataSet As System.Data.DataSet) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_ESPHBQYYJ = .getDataSet_BB_ESPHBQYYJ(strErrMsg, strUserId, strPassword, strKSRQ, strZZRQ, intType, objDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算中介部二手部门业绩排行榜的数据
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strKSRQ                    ：开始日期
        '     strZZRQ                    ：终止日期
        '     intType                    ：统计类型：0-接案，1-结案，2-已接未结案
        '     objDataSet                 ：信息数据集
        '                                  0-排序:面积
        '                                  1-排序:套数
        '                                  2-排序:宗数
        '                                  3-排序:代理费
        '                                  4-排序:按揭返还
        '                                  5-排序:交易金额
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改描述
        '     zengxianglin 2008-12-01 创建
        '----------------------------------------------------------------
        Public Function getDataSet_BB_ESPHBBMYJ( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strKSRQ As String, _
            ByVal strZZRQ As String, _
            ByVal intType As Integer, _
            ByRef objDataSet As System.Data.DataSet) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_ESPHBBMYJ = .getDataSet_BB_ESPHBBMYJ(strErrMsg, strUserId, strPassword, strKSRQ, strZZRQ, intType, objDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算中介部二手人员业绩排行榜的数据
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strKSRQ                    ：开始日期
        '     strZZRQ                    ：终止日期
        '     intType                    ：统计类型：0-接案，1-结案，2-已接未结案
        '     objDataSet                 ：信息数据集
        '                                  0-排序:面积
        '                                  1-排序:套数
        '                                  2-排序:宗数
        '                                  3-排序:代理费
        '                                  4-排序:按揭返还
        '                                  5-排序:交易金额
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改描述
        '     zengxianglin 2008-12-01 创建
        '----------------------------------------------------------------
        Public Function getDataSet_BB_ESPHBRYYJ( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strKSRQ As String, _
            ByVal strZZRQ As String, _
            ByVal intType As Integer, _
            ByRef objDataSet As System.Data.DataSet) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_ESPHBRYYJ = .getDataSet_BB_ESPHBRYYJ(strErrMsg, strUserId, strPassword, strKSRQ, strZZRQ, intType, objDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算中介部二手业绩年度对比的数据
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     intKSND                    ：开始年度
        '     intZZND                    ：终止年度
        '     intYJZR                    ：月截止日
        '     intType                    ：统计类型：0-接案，1-结案
        '     strYWLX                    ：业务类型：二手.买卖|二手.租赁|二手.其他
        '     strBMDM                    ：统计部门
        '     objDataSet                 ：信息数据集
        '                                  0-排序:面积
        '                                  1-排序:套数
        '                                  2-排序:宗数
        '                                  3-排序:代理费
        '                                  4-排序:按揭返还
        '                                  5-排序:交易金额
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改描述
        '     zengxianglin 2008-12-01 创建
        '----------------------------------------------------------------
        Public Function getDataSet_BB_ESNDDB( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal intKSND As Integer, _
            ByVal intZZND As Integer, _
            ByVal intYJZR As Integer, _
            ByVal intType As Integer, _
            ByVal strYWLX As String, _
            ByVal strBMDM As String, _
            ByRef objDataSet As System.Data.DataSet) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_ESNDDB = .getDataSet_BB_ESNDDB(strErrMsg, strUserId, strPassword, intKSND, intZZND, intYJZR, intType, strYWLX, strBMDM, objDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算中介部二手佣金分配表的数据
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strKSRQ                    ：开始日期
        '     strZZRQ                    ：终止日期
        '     strBMDM                    ：统计部门
        '     dblLVBL                    ：律师费提佣比例
        '     objDataSet                 ：信息数据集
        '                                  0-佣金数据
        '                                  1-私佣计提区段数据
        '                                  2-公佣计提数据
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改描述
        '     zengxianglin 2008-12-04 创建
        '----------------------------------------------------------------
        Public Function getDataSet_BB_ESYJFPB( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strKSRQ As String, _
            ByVal strZZRQ As String, _
            ByVal strBMDM As String, _
            ByVal dblLVBL As Double, _
            ByRef objDataSet As System.Data.DataSet) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_ESYJFPB = .getDataSet_BB_ESYJFPB(strErrMsg, strUserId, strPassword, strKSRQ, strZZRQ, strBMDM, dblLVBL, objDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 更改“地产_B_二手_交易合同”的[统计日期]
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：连接用户名
        '     strPassword          ：连接用户密码
        '     strQRSH              ：[确认书号]
        '     strTJRQ              ：[统计日期]
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        ' 更改记录：
        '     zengxianglin 2009-02-24 创建
        '----------------------------------------------------------------
        Public Function doUpdateData_ES_HETONG_TJRQ( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal strTJRQ As String) As Boolean
            With m_objrulesEstateErshou
                doUpdateData_ES_HETONG_TJRQ = .doUpdateData_ES_HETONG_TJRQ(strErrMsg, strUserId, strPassword, strQRSH, strTJRQ)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算[地产_B_二手_交易合同]的[统计日期]
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strQRSH                   ：确认书号
        '     strTJRQ                   ：统计日期(返回)
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        ' 更改描述
        '     zengxianglin 2009-02-24 创建
        '----------------------------------------------------------------
        Public Function getES_HETONG_TJRQ( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByRef strTJRQ As String) As Boolean
            With m_objrulesEstateErshou
                getES_HETONG_TJRQ = .getES_HETONG_TJRQ(strErrMsg, strUserId, strPassword, strQRSH, strTJRQ)
            End With
        End Function

        '----------------------------------------------------------------
        ' 更改“地产_B_二手_交易合同”的[备注信息]
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：连接用户名
        '     strPassword          ：连接用户密码
        '     strQRSH              ：[确认书号]
        '     strBZXX              ：[备注信息]
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        ' 更改记录：
        '     zengxianglin 2009-02-24 创建
        '----------------------------------------------------------------
        Public Function doUpdateData_ES_HETONG_BZXX( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal strBZXX As String) As Boolean
            With m_objrulesEstateErshou
                doUpdateData_ES_HETONG_BZXX = .doUpdateData_ES_HETONG_BZXX(strErrMsg, strUserId, strPassword, strQRSH, strBZXX)
            End With
        End Function










        '----------------------------------------------------------------
        ' 获取“地产_B_二手_确认书买卖_打印”完全数据的数据集
        ' 以“订购日期”排序
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strWhere                   ：搜索字符串
        '     blnControl                 ：进行查看限制
        '     objestateErshouData        ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改记录
        '     zengxianglin 2009-05-17 创建
        '----------------------------------------------------------------
        Public Function getDataSet_ES_QRS_MM_PRN( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByVal blnControl As Boolean, _
            ByRef objestateErshouData As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_QRS_MM_PRN = .getDataSet_ES_QRS_MM_PRN(strErrMsg, strUserId, strPassword, strWhere, blnControl, objestateErshouData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 获取“地产_B_二手_确认书租赁_打印”完全数据的数据集
        ' 以“订购日期”排序
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strWhere                   ：搜索字符串
        '     blnControl                 ：进行查看限制
        '     objestateErshouData        ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改记录
        '     zengxianglin 2009-05-17 创建
        '----------------------------------------------------------------
        Public Function getDataSet_ES_QRS_ZL_PRN( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByVal blnControl As Boolean, _
            ByRef objestateErshouData As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_QRS_ZL_PRN = .getDataSet_ES_QRS_ZL_PRN(strErrMsg, strUserId, strPassword, strWhere, blnControl, objestateErshouData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 获取“地产_B_二手_确认书其他_打印”完全数据的数据集
        ' 以“订购日期”排序
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strWhere                   ：搜索字符串
        '     blnControl                 ：进行查看限制
        '     objestateErshouData        ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改记录
        '     zengxianglin 2009-05-17 创建
        '----------------------------------------------------------------
        Public Function getDataSet_ES_QRS_QT_PRN( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByVal blnControl As Boolean, _
            ByRef objestateErshouData As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_QRS_QT_PRN = .getDataSet_ES_QRS_QT_PRN(strErrMsg, strUserId, strPassword, strWhere, blnControl, objestateErshouData)
            End With
        End Function











        '----------------------------------------------------------------
        ' 获取“地产_V_全部交易”中[二手.买卖]类型完全数据的数据集
        ' 以“交易日期”排序
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strWhere                   ：搜索字符串
        '     strQueryDG                 ：订购书搜索串
        '     strQueryHT                 ：合同搜索串
        '     strQueryDY                 ：物业搜索串
        '     strQueryRY                 ：业务员搜索串
        '     blnControl                 ：进行查看限制
        '     objRetDataSet              ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改
        '     zengxianglin 2009-05-18 创建
        '     zengxianglin 2011-01-03 更改
        '----------------------------------------------------------------
        Public Function getDataSet_ES_JYXX_MM( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByVal strQueryDG As String, _
            ByVal strQueryHT As String, _
            ByVal strQueryDY As String, _
            ByVal strQueryRY As String, _
            ByVal blnControl As Boolean, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_JYXX_MM = .getDataSet_ES_JYXX_MM(strErrMsg, strUserId, strPassword, strWhere, strQueryDG, strQueryHT, strQueryDY, strQueryRY, blnControl, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 获取“地产_V_全部交易”中[二手.其他]类型完全数据的数据集
        ' 以“交易日期”排序
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strWhere                   ：搜索字符串
        '     strQueryDG                 ：订购书搜索串
        '     strQueryHT                 ：合同搜索串
        '     strQueryDY                 ：物业搜索串
        '     strQueryRY                 ：业务员搜索串
        '     blnControl                 ：进行查看限制
        '     objRetDataSet              ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改
        '     zengxianglin 2009-05-18 创建
        '     zengxianglin 2011-01-04 更改
        '----------------------------------------------------------------
        Public Function getDataSet_ES_JYXX_QT( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByVal strQueryDG As String, _
            ByVal strQueryHT As String, _
            ByVal strQueryDY As String, _
            ByVal strQueryRY As String, _
            ByVal blnControl As Boolean, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_JYXX_QT = .getDataSet_ES_JYXX_QT(strErrMsg, strUserId, strPassword, strWhere, strQueryDG, strQueryHT, strQueryDY, strQueryRY, blnControl, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 获取“地产_V_全部交易”中[二手.租赁]类型完全数据的数据集
        ' 以“交易日期”排序
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strWhere                   ：搜索字符串
        '     strQueryDG                 ：订购书搜索串
        '     strQueryHT                 ：合同搜索串
        '     strQueryDY                 ：物业搜索串
        '     strQueryRY                 ：业务员搜索串
        '     blnControl                 ：进行查看限制
        '     objRetDataSet              ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改
        '     zengxianglin 2009-05-18 创建
        '     zengxianglin 2011-01-05 更改
        '----------------------------------------------------------------
        Public Function getDataSet_ES_JYXX_ZL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByVal strQueryDG As String, _
            ByVal strQueryHT As String, _
            ByVal strQueryDY As String, _
            ByVal strQueryRY As String, _
            ByVal blnControl As Boolean, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_JYXX_ZL = .getDataSet_ES_JYXX_ZL(strErrMsg, strUserId, strPassword, strWhere, strQueryDG, strQueryHT, strQueryDY, strQueryRY, blnControl, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 自动调整合同的分配比例数据以及合同涉及的结算书的业绩数据
        ' 以[合同日期]时的管理架构数据为基准
        '     strErrMsg              ：如果错误，则返回错误信息
        '     strUserId              ：用户标识
        '     strPassword            ：用户密码
        '     strQRSH                ：确认书号
        '     strBZXX                ：备注信息
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
        ' 更改记录
        '     zengxianglin 2009-05-19 创建
        '----------------------------------------------------------------
        Public Function doUpdate_ES_HETONG_FPBL_JSYJ( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal strBZXX As String) As Boolean
            With m_objrulesEstateErshou
                doUpdate_ES_HETONG_FPBL_JSYJ = .doUpdate_ES_HETONG_FPBL_JSYJ(strErrMsg, strUserId, strPassword, strQRSH, strBZXX)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算中介部二手业务代理清单(接案)(各种状态)的数据
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strKSRQ                    ：开始日期
        '     strZZRQ                    ：终止日期
        '     strBMDM                    ：部门代码
        '     objDataSet                 ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改描述
        '     zengxianglin 2009-05-21 创建
        '----------------------------------------------------------------
        Public Function getDataSet_BB_ESYWDLQD_JA_ALL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strKSRQ As String, _
            ByVal strZZRQ As String, _
            ByVal strBMDM As String, _
            ByRef objDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_ESYWDLQD_JA_ALL = .getDataSet_BB_ESYWDLQD_JA_ALL(strErrMsg, strUserId, strPassword, strKSRQ, strZZRQ, strBMDM, objDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算中介部二手业务代理清单(接案)(各种状态)的数据
        ' 按[总计][片区][分行][明细]分级汇总
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strKSRQ                    ：开始日期
        '     strZZRQ                    ：终止日期
        '     strBMDM                    ：部门代码
        '     objDataSet                 ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改描述
        '     zengxianglin 2009-05-21 创建
        '----------------------------------------------------------------
        Public Function getDataSet_BB_ESYWDLQD_JA1_ALL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strKSRQ As String, _
            ByVal strZZRQ As String, _
            ByVal strBMDM As String, _
            ByRef objDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_ESYWDLQD_JA1_ALL = .getDataSet_BB_ESYWDLQD_JA1_ALL(strErrMsg, strUserId, strPassword, strKSRQ, strZZRQ, strBMDM, objDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算中介部二手业务代理清单(接案)(已审合同)的数据
        ' 按[总计][片区][分行][明细]分级汇总
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strKSRQ                    ：开始日期
        '     strZZRQ                    ：终止日期
        '     strBMDM                    ：部门代码
        '     objDataSet                 ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改描述
        '     zengxianglin 2009-05-21 创建
        '----------------------------------------------------------------
        Public Function getDataSet_BB_ESYWDLQD_JA1_YS( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strKSRQ As String, _
            ByVal strZZRQ As String, _
            ByVal strBMDM As String, _
            ByRef objDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_ESYWDLQD_JA1_YS = .getDataSet_BB_ESYWDLQD_JA1_YS(strErrMsg, strUserId, strPassword, strKSRQ, strZZRQ, strBMDM, objDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算中介部二手业务代理清单(已接未结完)的数据
        ' 按[总计][片区][分行][明细]分级汇总
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strKSRQ                    ：开始日期
        '     strZZRQ                    ：终止日期
        '     strBMDM                    ：部门代码
        '     objDataSet                 ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改描述
        '     zengxianglin 2009-05-21 创建
        '----------------------------------------------------------------
        Public Function getDataSet_BB_ESYWDLQD_YJWJW( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strKSRQ As String, _
            ByVal strZZRQ As String, _
            ByVal strBMDM As String, _
            ByRef objDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_ESYWDLQD_YJWJW = .getDataSet_BB_ESYWDLQD_YJWJW(strErrMsg, strUserId, strPassword, strKSRQ, strZZRQ, strBMDM, objDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 更改“地产_B_二手_交易合同结算书”的[计佣日期]
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：连接用户名
        '     strPassword          ：连接用户密码
        '     strJSID              ：唯一标识
        '     strJYRQ              ：计佣日期
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        ' 更改记录
        '     zengxianglin 2009-12-26 创建
        '----------------------------------------------------------------
        Public Function doUpdate_ES_HETONG_JSS_JYRQ( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strJSID As String, _
            ByVal strJYRQ As String) As Boolean
            With m_objrulesEstateErshou
                doUpdate_ES_HETONG_JSS_JYRQ = .doUpdate_ES_HETONG_JSS_JYRQ(strErrMsg, strUserId, strPassword, strJSID, strJYRQ)
            End With
        End Function

        '----------------------------------------------------------------
        ' 获取“确认书号”获取“订购日期”
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：人员代码
        '     strQRSH              ：确认书号
        '     strDGRQ              ：(返回)订购日期
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        ' 更改描述
        '     zengxianglin 2010-01-13 创建
        '----------------------------------------------------------------
        Public Function getDgrqByQrsh( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByRef strDGRQ As String) As Boolean
            With m_objrulesEstateErshou
                getDgrqByQrsh = .getDgrqByQrsh(strErrMsg, strUserId, strPassword, strQRSH, strDGRQ)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算中介部二手业务计佣清单(私佣)的数据
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strCzyId                   ：操作人员
        '     intTJND                    ：统计年度
        '     intTJYD                    ：统计月度
        '     intYJZR                    ：月截止日
        '     objRetDataSet              ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改描述
        '     zengxianglin 2010-01-18 创建
        '----------------------------------------------------------------
        Public Function getDataSet_BB_ESJYQD_SY_X2( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strCzyId As String, _
            ByVal intTJND As Integer, _
            ByVal intTJYD As Integer, _
            ByVal intYJZR As Integer, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_ESJYQD_SY_X2 = .getDataSet_BB_ESJYQD_SY_X2(strErrMsg, strUserId, strPassword, strCzyId, intTJND, intTJYD, intYJZR, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算中介部二手业务计佣清单(公佣)的数据
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strCzyId                   ：操作人员
        '     intTJND                    ：统计年度
        '     intTJYD                    ：统计月度
        '     intYJZR                    ：月截止日
        '     objRetDataSet              ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改描述
        '     zengxianglin 2010-01-18 创建
        '----------------------------------------------------------------
        Public Function getDataSet_BB_ESJYQD_GY_X2( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strCzyId As String, _
            ByVal intTJND As Integer, _
            ByVal intTJYD As Integer, _
            ByVal intYJZR As Integer, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_ESJYQD_GY_X2 = .getDataSet_BB_ESJYQD_GY_X2(strErrMsg, strUserId, strPassword, strCzyId, intTJND, intTJYD, intYJZR, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算中介部二手业务佣金分配表的数据
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strCzyId                   ：操作人员
        '     intTJND                    ：统计年度
        '     intTJYD                    ：统计月度
        '     intYJZR                    ：月截止日
        '     objRetDataSet              ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改描述
        '     zengxianglin 2010-01-20 创建
        '----------------------------------------------------------------
        Public Function getDataSet_BB_YJFPB_X2( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strCzyId As String, _
            ByVal intTJND As Integer, _
            ByVal intTJYD As Integer, _
            ByVal intYJZR As Integer, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_YJFPB_X2 = .getDataSet_BB_YJFPB_X2(strErrMsg, strUserId, strPassword, strCzyId, intTJND, intTJYD, intYJZR, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算中介部二手业务计佣清单(私佣)的数据(按自然月计算)
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strCzyId                   ：操作人员
        '     strKSRQ                    ：开始日期(月初日期)
        '     strZZRQ                    ：终止日期(月末日期)
        '     objRetDataSet              ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改
        '     zengxianglin 2010-04-27 创建
        '     zengxianglin 2011-01-18 更改
        '----------------------------------------------------------------
        Public Function getDataSet_BB_ESJYQD_SY_X2( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strCzyId As String, _
            ByVal strKSRQ As String, _
            ByVal strZZRQ As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_ESJYQD_SY_X2 = .getDataSet_BB_ESJYQD_SY_X2(strErrMsg, strUserId, strPassword, strCzyId, strKSRQ, strZZRQ, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算中介部二手业务计佣清单(公佣)的数据(按自然月计算)
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strCzyId                   ：操作人员
        '     strKSRQ                    ：开始日期(月初日期)
        '     strZZRQ                    ：终止日期(月末日期)
        '     objRetDataSet              ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改
        '     zengxianglin 2010-04-27 创建
        '     zengxianglin 2011-01-18 更改
        '----------------------------------------------------------------
        Public Function getDataSet_BB_ESJYQD_GY_X2( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strCzyId As String, _
            ByVal strKSRQ As String, _
            ByVal strZZRQ As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_ESJYQD_GY_X2 = .getDataSet_BB_ESJYQD_GY_X2(strErrMsg, strUserId, strPassword, strCzyId, strKSRQ, strZZRQ, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算中介部二手业务佣金分配表的数据(按自然月计算)
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strCzyId                   ：操作人员
        '     strKSRQ                    ：开始日期(月初日期)
        '     strZZRQ                    ：终止日期(月末日期)
        '     objRetDataSet              ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改描述
        '     zengxianglin 2010-04-27 创建
        '----------------------------------------------------------------
        Public Function getDataSet_BB_YJFPB_X2( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strCzyId As String, _
            ByVal strKSRQ As String, _
            ByVal strZZRQ As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_YJFPB_X2 = .getDataSet_BB_YJFPB_X2(strErrMsg, strUserId, strPassword, strCzyId, strKSRQ, strZZRQ, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 根据物业信息数据集计算[物业信息]的web格式(买卖)
        '     objWYSJ：[地产_B_二手_物业买卖]数据
        ' 更改
        '     zengxianglin 2010-12-27 创建
        '----------------------------------------------------------------
        Public Function getWYXX_MM(ByVal objWYSJ As System.Collections.Specialized.NameValueCollection) As String
            With m_objrulesEstateErshou
                getWYXX_MM = .getWYXX_MM(objWYSJ)
            End With
        End Function

        '----------------------------------------------------------------
        ' 根据物业信息数据集计算[物业信息]的web格式(租赁)
        '     objWYSJ：[地产_B_二手_物业租赁]数据
        ' 更改
        '     zengxianglin 2010-12-27 创建
        '----------------------------------------------------------------
        Public Function getWYXX_ZL(ByVal objWYSJ As System.Collections.Specialized.NameValueCollection) As String
            With m_objrulesEstateErshou
                getWYXX_ZL = .getWYXX_ZL(objWYSJ)
            End With
        End Function

        '----------------------------------------------------------------
        ' 根据物业信息数据集计算[物业信息]的web格式(其他)
        '     objWYSJ：[地产_B_二手_物业其他]数据
        ' 更改
        '     zengxianglin 2010-12-27 创建
        '----------------------------------------------------------------
        Public Function getWYXX_QT(ByVal objWYSJ As System.Collections.Specialized.NameValueCollection) As String
            With m_objrulesEstateErshou
                getWYXX_QT = .getWYXX_QT(objWYSJ)
            End With
        End Function

        '----------------------------------------------------------------
        ' 标记“地产_B_二手_交易合同”解除合同
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strQRSH              ：确认书号
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        ' 更改
        '     zengxianglin 2010-12-30 创建
        '----------------------------------------------------------------
        Public Function doMarkJiechu_ES_HETONG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String) As Boolean
            With m_objrulesEstateErshou
                doMarkJiechu_ES_HETONG = .doMarkJiechu_ES_HETONG(strErrMsg, strUserId, strPassword, strQRSH)
            End With
        End Function

        '----------------------------------------------------------------
        ' 标记“地产_B_二手_交易合同”存在坏账
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strQRSH              ：确认书号
        '     dblHZJE              ：坏账金额
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        ' 更改
        '     zengxianglin 2010-12-30 创建
        '----------------------------------------------------------------
        Public Function doMarkHuaizhang_ES_HETONG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal dblHZJE As Double) As Boolean
            With m_objrulesEstateErshou
                doMarkHuaizhang_ES_HETONG = .doMarkHuaizhang_ES_HETONG(strErrMsg, strUserId, strPassword, strQRSH, dblHZJE)
            End With
        End Function

        '----------------------------------------------------------------
        ' 买卖业务列表打印的数据集(1行最多显示4个单元9个业务员)
        ' 以“交易日期”排序
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strWhere                   ：搜索字符串
        '     strQueryDG                 ：订购书搜索串
        '     strQueryHT                 ：合同搜索串
        '     strQueryDY                 ：物业搜索串
        '     strQueryRY                 ：业务员搜索串
        '     blnControl                 ：进行查看限制
        '     objRetDataSet              ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改
        '     zengxianglin 2011-01-03 创建
        '----------------------------------------------------------------
        Public Function getDataSet_ES_JYXX_MM_PRN( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByVal strQueryDG As String, _
            ByVal strQueryHT As String, _
            ByVal strQueryDY As String, _
            ByVal strQueryRY As String, _
            ByVal blnControl As Boolean, _
            ByRef objRetDataSet As System.Data.DataSet) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_JYXX_MM_PRN = .getDataSet_ES_JYXX_MM_PRN(strErrMsg, strUserId, strPassword, strWhere, strQueryDG, strQueryHT, strQueryDY, strQueryRY, blnControl, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 其他代办业务列表打印的数据集(1行最多显示4个单元9个业务员)
        ' 以“交易日期”排序
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strWhere                   ：搜索字符串
        '     strQueryDG                 ：订购书搜索串
        '     strQueryHT                 ：合同搜索串
        '     strQueryDY                 ：物业搜索串
        '     strQueryRY                 ：业务员搜索串
        '     blnControl                 ：进行查看限制
        '     objRetDataSet              ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改
        '     zengxianglin 2011-01-04 创建
        '----------------------------------------------------------------
        Public Function getDataSet_ES_JYXX_QT_PRN( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByVal strQueryDG As String, _
            ByVal strQueryHT As String, _
            ByVal strQueryDY As String, _
            ByVal strQueryRY As String, _
            ByVal blnControl As Boolean, _
            ByRef objRetDataSet As System.Data.DataSet) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_JYXX_QT_PRN = .getDataSet_ES_JYXX_QT_PRN(strErrMsg, strUserId, strPassword, strWhere, strQueryDG, strQueryHT, strQueryDY, strQueryRY, blnControl, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 租赁业务列表打印的数据集(1行最多显示4个单元9个业务员)
        ' 以“交易日期”排序
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strWhere                   ：搜索字符串
        '     strQueryDG                 ：订购书搜索串
        '     strQueryHT                 ：合同搜索串
        '     strQueryDY                 ：物业搜索串
        '     strQueryRY                 ：业务员搜索串
        '     blnControl                 ：进行查看限制
        '     objRetDataSet              ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改
        '     zengxianglin 2011-01-05 创建
        '----------------------------------------------------------------
        Public Function getDataSet_ES_JYXX_ZL_PRN( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByVal strQueryDG As String, _
            ByVal strQueryHT As String, _
            ByVal strQueryDY As String, _
            ByVal strQueryRY As String, _
            ByVal blnControl As Boolean, _
            ByRef objRetDataSet As System.Data.DataSet) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_JYXX_ZL_PRN = .getDataSet_ES_JYXX_ZL_PRN(strErrMsg, strUserId, strPassword, strWhere, strQueryDG, strQueryHT, strQueryDY, strQueryRY, blnControl, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算中介部二手应收未收佣金表的数据
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strWhere                   ：搜索条件
        '     objestateErshouData        ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改
        '     zengxianglin 2010-01-07 创建
        '----------------------------------------------------------------
        Public Function getDataSet_BB_YSWSYJB( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_YSWSYJB = .getDataSet_BB_YSWSYJB(strErrMsg, strUserId, strPassword, strWhere, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算中介部二手客源信息表的数据
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strWhere                   ：搜索条件
        '     objRetDataSet              ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改
        '     zengxianglin 2010-01-09 创建
        '----------------------------------------------------------------
        Public Function getDataSet_BB_KYXXB( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_KYXXB = .getDataSet_BB_KYXXB(strErrMsg, strUserId, strPassword, strWhere, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算中介部二手房源信息表的数据
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strWhere                   ：搜索条件
        '     objRetDataSet              ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改
        '     zengxianglin 2010-01-09 创建
        '----------------------------------------------------------------
        Public Function getDataSet_BB_FYXXB( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_FYXXB = .getDataSet_BB_FYXXB(strErrMsg, strUserId, strPassword, strWhere, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 获取“地产_B_二手_佣金计提”完全数据的数据集
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strWhere                   ：搜索字符串
        '     objRetDataSet              ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_ES_YJJT( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_YJJT = .getDataSet_ES_YJJT(strErrMsg, strUserId, strPassword, strWhere, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 保存“地产_B_二手_佣金计提”数据(X4)
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：连接用户名
        '     strPassword          ：连接用户密码
        '     strKSRQ              ：开始日期
        '     strZZRQ              ：结束日期
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        ' 更改
        '     zengxianglin 2011-01-19 创建
        '----------------------------------------------------------------
        Public Function doSaveData_ES_YJJT_X4( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strKSRQ As String, _
            ByVal strZZRQ As String) As Boolean
            With m_objrulesEstateErshou
                doSaveData_ES_YJJT_X4 = .doSaveData_ES_YJJT_X4(strErrMsg, strUserId, strPassword, strKSRQ, strZZRQ)
            End With
        End Function

    End Class

End Namespace
