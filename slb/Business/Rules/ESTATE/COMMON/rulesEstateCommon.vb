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
Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic

Imports Josco.JsKernal.SystemFramework
Imports Josco.JsKernal.Common
Imports Josco.JsKernal.Common.Data
Imports Josco.JsKernal.DataAccess

Namespace Josco.JSOA.BusinessRules

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.BusinessRules
    ' 类名    ：rulesEstateCommon
    '
    ' 功能描述： 
    '   　提供对通用地产管理处理的业务规则
    '----------------------------------------------------------------
    Public Class rulesEstateCommon
        Implements System.IDisposable

        Private m_objdacEstateCommon As Josco.JSOA.DataAccess.dacEstateCommon

        '----------------------------------------------------------------
        ' 构造函数
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()
            m_objdacEstateCommon = New Josco.JSOA.DataAccess.dacEstateCommon
        End Sub

        '----------------------------------------------------------------
        ' 安全释放本身资源
        '----------------------------------------------------------------
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessRules.rulesEstateCommon)
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
            If Not (m_objdacEstateCommon Is Nothing) Then
                m_objdacEstateCommon.Dispose()
                m_objdacEstateCommon = Nothing
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
            With Me.m_objdacEstateCommon
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
            With Me.m_objdacEstateCommon
                doExportToExcel = .doExportToExcel(strErrMsg, objDataSet, strExcelFile, strColorFieldName, objColors, strMacroName, strMacroValue, strDateFormat)
            End With
        End Function










        '----------------------------------------------------------------
        ' 获取“地产_B_公共_税费目录”的SQL语句(以“税费代码”升序排序)
        ' 返回
        '                          ：SQL
        '----------------------------------------------------------------
        Public Function getTableSQL_ShuifeiMulu() As String
            With m_objdacEstateCommon
                getTableSQL_ShuifeiMulu = .getTableSQL_ShuifeiMulu()
            End With
        End Function

        '----------------------------------------------------------------
        ' 根据“税费代码”获取“税费名称”
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strSfdm                   ：税费代码
        '     strSfmc                   ：税费名称(返回)
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        '----------------------------------------------------------------
        Public Function getSfmc( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strSfdm As String, _
            ByRef strSfmc As String) As Boolean
            With m_objdacEstateCommon
                getSfmc = .getSfmc(strErrMsg, strUserId, strPassword, strSfdm, strSfmc)
            End With
        End Function

        '----------------------------------------------------------------
        ' 根据“税费名称”获取“税费代码”
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strSfmc                   ：税费名称
        '     strSfdm                   ：税费代码(返回)
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        '----------------------------------------------------------------
        Public Function getSfdm( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strSfmc As String, _
            ByRef strSfdm As String) As Boolean
            With m_objdacEstateCommon
                getSfdm = .getSfdm(strErrMsg, strUserId, strPassword, strSfmc, strSfdm)
            End With
        End Function

        '----------------------------------------------------------------
        ' 获取“地产_B_公共_税费目录”完全数据的数据集(以“税费代码”升序排序)
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strWhere                   ：搜索字符串
        '     objestateCommonData        ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_ShuifeiMulu( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objestateCommonData As Josco.JSOA.Common.Data.estateCommonData) As Boolean
            With m_objdacEstateCommon
                getDataSet_ShuifeiMulu = .getDataSet_ShuifeiMulu(strErrMsg, strUserId, strPassword, strWhere, objestateCommonData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 保存“地产_B_公共_税费目录”的数据
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
        Public Function doSaveData_ShuifeiMulu( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean
            With m_objdacEstateCommon
                doSaveData_ShuifeiMulu = .doSaveData_ShuifeiMulu(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType)
            End With
        End Function

        '----------------------------------------------------------------
        ' 删除“地产_B_公共_税费目录”的数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objOldData           ：旧数据
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doDeleteData_ShuifeiMulu( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow) As Boolean
            With m_objdacEstateCommon
                doDeleteData_ShuifeiMulu = .doDeleteData_ShuifeiMulu(strErrMsg, strUserId, strPassword, objOldData)
            End With
        End Function










        '----------------------------------------------------------------
        ' 获取“地产_B_公共_物业间隔”的SQL语句(以“间隔代码”升序排序)
        ' 返回
        '                          ：SQL
        '----------------------------------------------------------------
        Public Function getTableSQL_WuyeJiange() As String
            With m_objdacEstateCommon
                getTableSQL_WuyeJiange = .getTableSQL_WuyeJiange()
            End With
        End Function

        '----------------------------------------------------------------
        ' 根据“间隔代码”获取“间隔名称”
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strWyjgdm                 ：间隔代码
        '     strWyjgmc                 ：间隔名称(返回)
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        '----------------------------------------------------------------
        Public Function getWyjgmc( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWyjgdm As String, _
            ByRef strWyjgmc As String) As Boolean
            With m_objdacEstateCommon
                getWyjgmc = .getWyjgmc(strErrMsg, strUserId, strPassword, strWyjgdm, strWyjgmc)
            End With
        End Function

        '----------------------------------------------------------------
        ' 根据“间隔名称”获取“间隔代码”
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strWyjgmc                 ：间隔名称
        '     strWyjgdm                 ：间隔代码(返回)
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        '----------------------------------------------------------------
        Public Function getWyjgdm( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWyjgmc As String, _
            ByRef strWyjgdm As String) As Boolean
            With m_objdacEstateCommon
                getWyjgdm = .getWyjgdm(strErrMsg, strUserId, strPassword, strWyjgmc, strWyjgdm)
            End With
        End Function

        '----------------------------------------------------------------
        ' 获取“地产_B_公共_物业间隔”完全数据的数据集(以“间隔代码”升序排序)
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strWhere                   ：搜索字符串
        '     objestateCommonData        ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_WuyeJiange( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objestateCommonData As Josco.JSOA.Common.Data.estateCommonData) As Boolean
            With m_objdacEstateCommon
                getDataSet_WuyeJiange = .getDataSet_WuyeJiange(strErrMsg, strUserId, strPassword, strWhere, objestateCommonData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 保存“地产_B_公共_物业间隔”的数据
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
        Public Function doSaveData_WuyeJiange( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean
            With m_objdacEstateCommon
                doSaveData_WuyeJiange = .doSaveData_WuyeJiange(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType)
            End With
        End Function

        '----------------------------------------------------------------
        ' 删除“地产_B_公共_物业间隔”的数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objOldData           ：旧数据
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doDeleteData_WuyeJiange( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow) As Boolean
            With m_objdacEstateCommon
                doDeleteData_WuyeJiange = .doDeleteData_WuyeJiange(strErrMsg, strUserId, strPassword, objOldData)
            End With
        End Function












        '----------------------------------------------------------------
        ' 获取“地产_B_公共_物业性质”的SQL语句(以“性质代码”升序排序)
        ' 返回
        '                          ：SQL
        '----------------------------------------------------------------
        Public Function getTableSQL_WuyeXingzhi() As String
            With m_objdacEstateCommon
                getTableSQL_WuyeXingzhi = .getTableSQL_WuyeXingzhi()
            End With
        End Function

        '----------------------------------------------------------------
        ' 根据“性质代码”获取“性质名称”
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strWyxzdm                 ：性质代码
        '     strWyxzmc                 ：性质名称(返回)
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        '----------------------------------------------------------------
        Public Function getWyxzmc( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWyxzdm As String, _
            ByRef strWyxzmc As String) As Boolean
            With m_objdacEstateCommon
                getWyxzmc = .getWyxzmc(strErrMsg, strUserId, strPassword, strWyxzdm, strWyxzmc)
            End With
        End Function

        '----------------------------------------------------------------
        ' 根据“性质名称”获取“性质代码”
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strWyxzmc                 ：性质名称
        '     strWyxzdm                 ：性质代码(返回)
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        '----------------------------------------------------------------
        Public Function getWyxzdm( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWyxzmc As String, _
            ByRef strWyxzdm As String) As Boolean
            With m_objdacEstateCommon
                getWyxzdm = .getWyxzdm(strErrMsg, strUserId, strPassword, strWyxzmc, strWyxzdm)
            End With
        End Function

        '----------------------------------------------------------------
        ' 获取“地产_B_公共_物业性质”完全数据的数据集(以“性质代码”升序排序)
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strWhere                   ：搜索字符串
        '     objestateCommonData        ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_WuyeXingzhi( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objestateCommonData As Josco.JSOA.Common.Data.estateCommonData) As Boolean
            With m_objdacEstateCommon
                getDataSet_WuyeXingzhi = .getDataSet_WuyeXingzhi(strErrMsg, strUserId, strPassword, strWhere, objestateCommonData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 保存“地产_B_公共_物业性质”的数据
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
        Public Function doSaveData_WuyeXingzhi( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean
            With m_objdacEstateCommon
                doSaveData_WuyeXingzhi = .doSaveData_WuyeXingzhi(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType)
            End With
        End Function

        '----------------------------------------------------------------
        ' 删除“地产_B_公共_物业性质”的数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objOldData           ：旧数据
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doDeleteData_WuyeXingzhi( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow) As Boolean
            With m_objdacEstateCommon
                doDeleteData_WuyeXingzhi = .doDeleteData_WuyeXingzhi(strErrMsg, strUserId, strPassword, objOldData)
            End With
        End Function











        '----------------------------------------------------------------
        ' 获取“地产_B_公共_应收应付模版”的SQL语句(以“模版代码”升序排序)
        ' 返回
        '                          ：SQL
        '----------------------------------------------------------------
        Public Function getTableSQL_YingshouYingfuMoban() As String
            With m_objdacEstateCommon
                getTableSQL_YingshouYingfuMoban = .getTableSQL_YingshouYingfuMoban()
            End With
        End Function

        '----------------------------------------------------------------
        ' 根据“模版代码”获取“模版名称”
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strMbdm                   ：模版代码
        '     strMbmc                   ：模版名称(返回)
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        '----------------------------------------------------------------
        Public Function getMbmc( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strMbdm As String, _
            ByRef strMbmc As String) As Boolean
            With m_objdacEstateCommon
                getMbmc = .getMbmc(strErrMsg, strUserId, strPassword, strMbdm, strMbmc)
            End With
        End Function

        ''----------------------------------------------------------------
        '' 根据“模版名称”获取“模版代码”
        ''     strErrMsg                 ：如果错误，则返回错误信息
        ''     strUserId                 ：用户标识
        ''     strPassword               ：用户密码
        ''     strMbmc                   ：模版名称
        ''     strMbdm                   ：模版代码(返回)
        '' 返回
        ''     True                      ：成功
        ''     False                     ：失败
        ''----------------------------------------------------------------
        'Public Function getMbdm( _
        '    ByVal strErrMsg As String, _
        '    ByVal strUserId As String, _
        '    ByVal strPassword As String, _
        '    ByVal strMbmc As String, _
        '    ByRef strMbdm As String) As Boolean
        '    With m_objdacEstateCommon
        '        getMbdm = .getMbdm(strErrMsg, strUserId, strPassword, strMbmc, strMbdm)
        '    End With
        'End Function

        '----------------------------------------------------------------
        ' 获取“地产_B_公共_应收应付模版”完全数据的数据集(以“模版代码”升序排序)
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strWhere                   ：搜索字符串
        '     objestateCommonData        ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_YingshouYingfuMoban( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objestateCommonData As Josco.JSOA.Common.Data.estateCommonData) As Boolean
            With m_objdacEstateCommon
                getDataSet_YingshouYingfuMoban = .getDataSet_YingshouYingfuMoban(strErrMsg, strUserId, strPassword, strWhere, objestateCommonData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 保存“地产_B_公共_应收应付模版”的数据
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
        Public Function doSaveData_YingshouYingfuMoban( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean
            With m_objdacEstateCommon
                doSaveData_YingshouYingfuMoban = .doSaveData_YingshouYingfuMoban(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType)
            End With
        End Function

        '----------------------------------------------------------------
        ' 删除“地产_B_公共_应收应付模版”的数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objOldData           ：旧数据
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doDeleteData_YingshouYingfuMoban( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow) As Boolean
            With m_objdacEstateCommon
                doDeleteData_YingshouYingfuMoban = .doDeleteData_YingshouYingfuMoban(strErrMsg, strUserId, strPassword, objOldData)
            End With
        End Function










        '----------------------------------------------------------------
        ' 获取“地产_B_公共_区域划分”的SQL语句(以“区域代码”升序排序)
        ' 返回
        '                          ：SQL
        '----------------------------------------------------------------
        Public Function getTableSQL_QuyuHuafen() As String
            With m_objdacEstateCommon
                getTableSQL_QuyuHuafen = .getTableSQL_QuyuHuafen()
            End With
        End Function

        '----------------------------------------------------------------
        ' 根据“区域代码”获取“区域名称”
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strQydm                   ：区域代码
        '     strQymc                   ：区域名称(返回)
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        '----------------------------------------------------------------
        Public Function getQymc( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQydm As String, _
            ByRef strQymc As String) As Boolean
            With m_objdacEstateCommon
                getQymc = .getQymc(strErrMsg, strUserId, strPassword, strQydm, strQymc)
            End With
        End Function

        '----------------------------------------------------------------
        ' 根据“区域名称”获取“区域代码”
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strQymc                   ：区域名称
        '     strQydm                   ：区域代码(返回)
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        '----------------------------------------------------------------
        Public Function getQydm( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQymc As String, _
            ByRef strQydm As String) As Boolean
            With m_objdacEstateCommon
                getQydm = .getQydm(strErrMsg, strUserId, strPassword, strQymc, strQydm)
            End With
        End Function

        '----------------------------------------------------------------
        ' 获取“地产_B_公共_区域划分”完全数据的数据集(以“区域代码”升序排序)
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strWhere                   ：搜索字符串
        '     objestateCommonData        ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_QuyuHuafen( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objestateCommonData As Josco.JSOA.Common.Data.estateCommonData) As Boolean
            With m_objdacEstateCommon
                getDataSet_QuyuHuafen = .getDataSet_QuyuHuafen(strErrMsg, strUserId, strPassword, strWhere, objestateCommonData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 保存“地产_B_公共_区域划分”的数据
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
        Public Function doSaveData_QuyuHuafen( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean
            With m_objdacEstateCommon
                doSaveData_QuyuHuafen = .doSaveData_QuyuHuafen(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType)
            End With
        End Function

        '----------------------------------------------------------------
        ' 删除“地产_B_公共_区域划分”的数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objOldData           ：旧数据
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doDeleteData_QuyuHuafen( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow) As Boolean
            With m_objdacEstateCommon
                doDeleteData_QuyuHuafen = .doDeleteData_QuyuHuafen(strErrMsg, strUserId, strPassword, objOldData)
            End With
        End Function









        '----------------------------------------------------------------
        ' 获取“地产_B_公共_办案项目”的SQL语句(以“项目代码”升序排序)
        ' 返回
        '                          ：SQL
        ' 更改描述
        '     zengxianglin 2008-11-18 创建
        '----------------------------------------------------------------
        Public Function getTableSQL_BAXM() As String
            With m_objdacEstateCommon
                getTableSQL_BAXM = .getTableSQL_BAXM()
            End With
        End Function

        '----------------------------------------------------------------
        ' 根据“项目代码”获取“项目名称”
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strXmdm                   ：项目代码
        '     strXmmc                   ：项目名称(返回)
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        ' 更改描述
        '     zengxianglin 2008-11-18 创建
        '----------------------------------------------------------------
        Public Function getBaxm_Xmmc( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strXmdm As String, _
            ByRef strXmmc As String) As Boolean
            With m_objdacEstateCommon
                getBaxm_Xmmc = .getBaxm_Xmmc(strErrMsg, strUserId, strPassword, strXmdm, strXmmc)
            End With
        End Function

        '----------------------------------------------------------------
        ' 根据“项目名称”获取“项目代码”
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strXmmc                   ：项目名称
        '     strXmdm                   ：项目代码(返回)
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        ' 更改描述
        '     zengxianglin 2008-11-18 创建
        '----------------------------------------------------------------
        Public Function getBaxm_Xmdm( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strXmmc As String, _
            ByRef strXmdm As String) As Boolean
            With m_objdacEstateCommon
                getBaxm_Xmdm = .getBaxm_Xmdm(strErrMsg, strUserId, strPassword, strXmmc, strXmdm)
            End With
        End Function

        '----------------------------------------------------------------
        ' 获取“地产_B_公共_办案项目”完全数据的数据集(以“项目代码”升序排序)
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strWhere                   ：搜索字符串
        '     objestateCommonData        ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改描述
        '     zengxianglin 2008-11-18 创建
        '----------------------------------------------------------------
        Public Function getDataSet_BAXM( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objestateCommonData As Josco.JSOA.Common.Data.estateCommonData) As Boolean
            With m_objdacEstateCommon
                getDataSet_BAXM = .getDataSet_BAXM(strErrMsg, strUserId, strPassword, strWhere, objestateCommonData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 保存“地产_B_公共_办案项目”的数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objOldData           ：旧数据
        '     objNewData           ：新数据
        '     objenumEditType      ：编辑类型
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        ' 更改描述
        '     zengxianglin 2008-11-18 创建
        '----------------------------------------------------------------
        Public Function doSaveData_BAXM( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean
            With m_objdacEstateCommon
                doSaveData_BAXM = .doSaveData_BAXM(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType)
            End With
        End Function

        '----------------------------------------------------------------
        ' 删除“地产_B_公共_办案项目”的数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objOldData           ：旧数据
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        ' 更改描述
        '     zengxianglin 2008-11-18 创建
        '----------------------------------------------------------------
        Public Function doDeleteData_BAXM( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow) As Boolean
            With m_objdacEstateCommon
                doDeleteData_BAXM = .doDeleteData_BAXM(strErrMsg, strUserId, strPassword, objOldData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 获取“地产_B_公共_物业性质”选择列表数据集
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strWhere                   ：搜索字符串
        '     objestateCommonData        ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改
        '     zengxianglin 2010-12-25 创建
        '----------------------------------------------------------------
        Public Function getDataSet_WuyeXingzhi_List( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objDataSet As Josco.JSOA.Common.Data.estateCommonData) As Boolean
            With m_objdacEstateCommon
                getDataSet_WuyeXingzhi_List = .getDataSet_WuyeXingzhi_List(strErrMsg, strUserId, strPassword, strWhere, objDataSet)
            End With
        End Function

    End Class 'rulesEstateCommon

End Namespace 'Josco.JsKernal.BusinessRules
