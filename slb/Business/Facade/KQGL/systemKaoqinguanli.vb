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
Imports Josco.JSOA.Common.Data

Namespace Josco.JSOA.BusinessFacade
    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.BusinessFacade
    ' 类名    ：systemKaoqinguanli
    '
    ' 功能描述： 
    '   　提供对兴业公司特殊的人事管理处理的表现层支持
    '--------------------------------------------------------------

    Public Class systemKaoqinguanli
        Implements System.IDisposable

        Private m_objrulesKaoqinguanli As Josco.JSOA.BusinessRules.rulesKaoqinguanli

        '----------------------------------------------------------------
        ' 构造函数
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()
            m_objrulesKaoqinguanli = New Josco.JSOA.BusinessRules.rulesKaoqinguanli
        End Sub

        '----------------------------------------------------------------
        ' 安全释放本身资源
        '----------------------------------------------------------------
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.systemKaoqinguanli)
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
            If Not (m_objrulesKaoqinguanli Is Nothing) Then
                m_objrulesKaoqinguanli.Dispose()
                m_objrulesKaoqinguanli = Nothing
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
            With New Josco.JSOA.BusinessRules.rulesKaoqinguanli
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
            With New Josco.JSOA.BusinessRules.rulesKaoqinguanli
                doExportToExcel = .doExportToExcel(strErrMsg, objDataSet, strExcelFile, strColorFieldName, objColors, strMacroName, strMacroValue, strDateFormat)
            End With
        End Function




        '----------------------------------------------------------------
        ' 获取查看所有部门的对应的应休假标准
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     objkqglkqjlData            ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataYXJBZ( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef objkqglkqjlData As Josco.JSOA.Common.Data.kaoqinguanliData) As Boolean

            Try
                With New Josco.JSOA.BusinessRules.rulesKaoqinguanli
                    getDataYXJBZ = .getDataYXJBZ(strErrMsg, strUserId, strPassword, objkqglkqjlData)
                End With
            Catch ex As Exception
                getDataYXJBZ = False
                strErrMsg = ex.Message
            End Try
        End Function


        '----------------------------------------------------------------
        ' 获取查看所有部门的对应的应休假标准
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     objkqglkqjlData            ：信息数据集
        '     strWhere                   : 条件
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataYXJBZ( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef objkqglkqjlData As Josco.JSOA.Common.Data.kaoqinguanliData, _
            ByVal strWhere As String) As Boolean

            Try
                With New Josco.JSOA.BusinessRules.rulesKaoqinguanli
                    getDataYXJBZ = .getDataYXJBZ(strErrMsg, strUserId, strPassword, objkqglkqjlData, strWhere)
                End With
            Catch ex As Exception
                getDataYXJBZ = False
                strErrMsg = ex.Message
            End Try
        End Function

        '----------------------------------------------------------------
        ' 更新指定的单位的应休假标准
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objNewData           ：更新数据
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doUpdate_YXJ( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection) As Boolean

            Try
                With New Josco.JSOA.BusinessRules.rulesKaoqinguanli
                    doUpdate_YXJ = .doUpdate_YXJ(strErrMsg, strUserId, strPassword, objNewData)
                End With
            Catch ex As Exception
                doUpdate_YXJ = False
                strErrMsg = ex.Message
            End Try
        End Function



        '----------------------------------------------------------------
        ' 更新指定的单位的应休假天数
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objNewData           ：更新数据
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doSet_YXJ( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection) As Boolean

            Try
                With New Josco.JSOA.BusinessRules.rulesKaoqinguanli
                    doSet_YXJ = .doSet_YXJ(strErrMsg, strUserId, strPassword, objNewData)
                End With
            Catch ex As Exception
                doSet_YXJ = False
                strErrMsg = ex.Message
            End Try
        End Function

        '----------------------------------------------------------------
        ' 生成指定月份的补休假
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strKSRQ              ：开始日期
        '     strJSRQ              ：结束日期
        '     strZZDM              ：生成的单位
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doSet_BXJ( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strKSRQ As String, _
            ByVal strJSRQ As String, _
            ByVal strZZDM As String) As Boolean

            Try
                With New Josco.JSOA.BusinessRules.rulesKaoqinguanli
                    doSet_BXJ = .doSet_BXJ(strErrMsg, strUserId, strPassword, strKSRQ, strJSRQ, strZZDM)
                End With
            Catch ex As Exception
                doSet_BXJ = False
                strErrMsg = ex.Message
            End Try
        End Function

        '----------------------------------------------------------------
        ' 按指定的信息更新考勤记录
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objNewData          ：更新数据
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doAdd_NXJ( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection) As Boolean

            Try
                With New Josco.JSOA.BusinessRules.rulesKaoqinguanli
                    doAdd_NXJ = .doAdd_NXJ(strErrMsg, strUserId, strPassword, objNewData)
                End With
            Catch ex As Exception
                doAdd_NXJ = False
                strErrMsg = ex.Message
            End Try
        End Function

        '----------------------------------------------------------------
        ' 按指定的信息更新年休假
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objNewData           ：更新数据
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doUpdate_NXJ( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection) As Boolean

            Try
                With New Josco.JSOA.BusinessRules.rulesKaoqinguanli
                    doUpdate_NXJ = .doUpdate_NXJ(strErrMsg, strUserId, strPassword, objNewData)
                End With
            Catch ex As Exception
                doUpdate_NXJ = False
                strErrMsg = ex.Message
            End Try
        End Function

        '----------------------------------------------------------------
        ' 按更新所有人员年休假
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doUpdate_NXJ( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String) As Boolean

            Try
                With New Josco.JSOA.BusinessRules.rulesKaoqinguanli
                    doUpdate_NXJ = .doUpdate_NXJ(strErrMsg, strUserId, strPassword)
                End With
            Catch ex As Exception
                doUpdate_NXJ = False
                strErrMsg = ex.Message
            End Try
        End Function

        '----------------------------------------------------------------
        ' 按指定的信息更新考勤记录
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objNewData          ：更新数据
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doAdd_Kaoqinjilu( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection) As Boolean

            Try
                With New Josco.JSOA.BusinessRules.rulesKaoqinguanli
                    doAdd_Kaoqinjilu = .doAdd_Kaoqinjilu(strErrMsg, strUserId, strPassword, objNewData)
                End With
            Catch ex As Exception
                doAdd_Kaoqinjilu = False
                strErrMsg = ex.Message
            End Try
        End Function

        '----------------------------------------------------------------
        ' 按指定的信息更新考勤记录
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objNewData          ：更新数据
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doDelete_Kaoqinjilu( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection) As Boolean

            Try
                With New Josco.JSOA.BusinessRules.rulesKaoqinguanli
                    doDelete_Kaoqinjilu = .doDelete_Kaoqinjilu(strErrMsg, strUserId, strPassword, objNewData)
                End With
            Catch ex As Exception
                doDelete_Kaoqinjilu = False
                strErrMsg = ex.Message
            End Try
        End Function





        '----------------------------------------------------------------
        ' 获取strUserXM能够查看的补休假
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strZZDM                    ：组织代码
        '     objkqglkqjlData            ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataBuxiujia( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strZZDM As String, _
            ByRef objkaoqinguanliData As Josco.JSOA.Common.Data.kaoqinguanliData) As Boolean
            Try
                With New Josco.JSOA.BusinessRules.rulesKaoqinguanli
                    getDataBuxiujia = .getDataBuxiujia(strErrMsg, strUserId, strPassword, strZZDM, objkaoqinguanliData)
                End With
            Catch ex As Exception
                getDataBuxiujia = False
                strErrMsg = ex.Message
            End Try
        End Function

        '----------------------------------------------------------------
        ' 获取strUserXM能够查看的考勤记录完全数据的数据集(以“人员代码”降序排序)
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strZZDM                    ：组织代码
        '     objkqglkqjlData            ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataNianxiujia( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strZZDM As String, _
            ByRef objkqglkqjlData As Josco.JSOA.Common.Data.kaoqinguanliData) As Boolean
            Try
                With New Josco.JSOA.BusinessRules.rulesKaoqinguanli
                    getDataNianxiujia = .getDataNianxiujia(strErrMsg, strUserId, strPassword, strZZDM, objkqglkqjlData)
                End With
            Catch ex As Exception
                getDataNianxiujia = False
                strErrMsg = ex.Message
            End Try
        End Function

        '----------------------------------------------------------------
        ' 获取strUserXM能够查看的考勤记录完全数据的数据集(以“人员代码”降序排序)
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strNF                      ：年份
        '     strYF                      ：月份
        '     strZZDM                    ：组织代码
        '     objkqglkqjlData            ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSetKqjl_Main( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strNF As String, _
            ByVal strYF As String, _
            ByVal strZZDM As String, _
            ByRef objkqglkqjlData As Josco.JSOA.Common.Data.kaoqinguanliData) As Boolean

            Try
                With New Josco.JSOA.BusinessRules.rulesKaoqinguanli
                    getDataSetKqjl_Main = .getDataSetKqjl_Main(strErrMsg, strUserId, strPassword, strNF, strYF, strZZDM, objkqglkqjlData)
                End With
            Catch ex As Exception
                getDataSetKqjl_Main = False
                strErrMsg = ex.Message
            End Try
        End Function


        '----------------------------------------------------------------
        ' 获取strUserXM能够查看的考勤记录完全数据的数据集(以“人员代码”降序排序)
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strNF                      ：年份
        '     strYF                      ：月份
        '     strZZDM                    ：组织代码
        '     objkqglkqjlData            ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSetKqjl_Print( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strNF As String, _
            ByVal strYF As String, _
            ByVal strZZDM As String, _
            ByRef objkqglkqjlData As Josco.JSOA.Common.Data.kaoqinguanliData) As Boolean

            Try
                With New Josco.JSOA.BusinessRules.rulesKaoqinguanli
                    getDataSetKqjl_Print = .getDataSetKqjl_Print(strErrMsg, strUserId, strPassword, strNF, strYF, strZZDM, objkqglkqjlData)
                End With
            Catch ex As Exception
                getDataSetKqjl_Print = False
                strErrMsg = ex.Message
            End Try
        End Function


        '----------------------------------------------------------------
        ' 获取strUserXM能够查看的全部考勤记录
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strNF                      ：年份
        '     strYF                      ：月份
        '     strZZDM                    ：组织代码
        '     objkqglkqjlData            ：信息数据集
        '     strAll                     :重载
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSetKqjl_Print( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strNF As String, _
            ByVal strYF As String, _
            ByVal strZZDM As String, _
            ByRef objkqglkqjlData As Josco.JSOA.Common.Data.kaoqinguanliData, _
            ByVal strAll As String) As Boolean

            Try
                With New Josco.JSOA.BusinessRules.rulesKaoqinguanli
                    getDataSetKqjl_Print = .getDataSetKqjl_Print(strErrMsg, strUserId, strPassword, strNF, strYF, strZZDM, objkqglkqjlData, strAll)
                End With
            Catch ex As Exception
                getDataSetKqjl_Print = False
                strErrMsg = ex.Message
            End Try
        End Function

        '----------------------------------------------------------------
        ' 获取strUserXM能够查看的工资考勤记录
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strNF                      ：年份
        '     strYF                      ：月份
        '     strZZDM                    ：组织代码
        '     objkqglkqjlData            ：信息数据集
        '     intOption                  ：重载
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSetKqjl_Print( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strNF As String, _
            ByVal strYF As String, _
            ByVal strZZDM As String, _
            ByRef objkqglkqjlData As Josco.JSOA.Common.Data.kaoqinguanliData, _
            ByVal intOption As Integer) As Boolean

            Try
                With New Josco.JSOA.BusinessRules.rulesKaoqinguanli
                    getDataSetKqjl_Print = .getDataSetKqjl_Print(strErrMsg, strUserId, strPassword, strNF, strYF, strZZDM, objkqglkqjlData, intOption)
                End With
            Catch ex As Exception
                getDataSetKqjl_Print = False
                strErrMsg = ex.Message
            End Try
        End Function














        '----------------------------------------------------------------
        ' 获取“地产_B_考勤_考勤类型”的SQL语句(以岗位代码升序排序)
        ' 返回
        '                          ：SQL
        '----------------------------------------------------------------
        Public Function getKaoqingleixingSQL() As String
            Try
                With New Josco.JSOA.BusinessRules.rulesKaoqinguanli
                    getKaoqingleixingSQL = .getKaoqingleixingSQL()
                End With
            Catch ex As Exception
                getKaoqingleixingSQL = ""
            End Try
        End Function

        '----------------------------------------------------------------
        ' 获取“地产_B_考勤_考勤类型”完全数据的数据集(以岗位代码升序排序)
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strWhere             ：搜索字符串(默认表前缀a.)
        '     objKehuguanliData：岗位代码信息数据集
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function getKaoqingleixingData( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objKaoqinguanliData As Josco.JSOA.Common.Data.kaoqinguanliData) As Boolean

            Try
                With New Josco.JSOA.BusinessRules.rulesKaoqinguanli
                    getKaoqingleixingData = .getKaoqingleixingData(strErrMsg, strUserId, strPassword, strWhere, objKaoqinguanliData)
                End With
            Catch ex As Exception
                getKaoqingleixingData = False
                strErrMsg = ex.Message
            End Try

        End Function

        '----------------------------------------------------------------
        ' 保存“地产_B_考勤_考勤类型”的数据
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
        Public Function doSaveKaoqingleixingData( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean

            Try
                With New Josco.JSOA.BusinessRules.rulesKaoqinguanli
                    doSaveKaoqingleixingData = .doSaveKaoqingleixingData(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType)
                End With
            Catch ex As Exception
                doSaveKaoqingleixingData = False
                strErrMsg = ex.Message
            End Try

        End Function

        '----------------------------------------------------------------
        ' 删除“地产_B_考勤_考勤类型”的数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objOldData           ：旧数据
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doDeleteKaoqingleixingData( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow) As Boolean

            Try
                With New Josco.JSOA.BusinessRules.rulesKaoqinguanli
                    doDeleteKaoqingleixingData = .doDeleteKaoqingleixingData(strErrMsg, strUserId, strPassword, objOldData)
                End With
            Catch ex As Exception
                doDeleteKaoqingleixingData = False
                strErrMsg = ex.Message
            End Try

        End Function


        '----------------------------------------------------------------
        ' 获取查看有职级变动的应休假标准
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     objkqglkqjlData            ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_KQZJ( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef objkqglkqjlData As Josco.JSOA.Common.Data.kaoqinguanliData) As Boolean

            Try
                With New Josco.JSOA.BusinessRules.rulesKaoqinguanli
                    getDataSet_KQZJ = .getDataSet_KQZJ(strErrMsg, strUserId, strPassword, objkqglkqjlData)
                End With
            Catch ex As Exception
                getDataSet_KQZJ = False
                strErrMsg = ex.Message
            End Try
        End Function

        '----------------------------------------------------------------
        ' 更新指定的单位的职级应休假标准
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objNewData           ：更新数据
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doUpdate_YXJ_ZJ( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection) As Boolean

            Try
                With New Josco.JSOA.BusinessRules.rulesKaoqinguanli
                    doUpdate_YXJ_ZJ = .doUpdate_YXJ_ZJ(strErrMsg, strUserId, strPassword, objNewData)
                End With
            Catch ex As Exception
                doUpdate_YXJ_ZJ = False
                strErrMsg = ex.Message
            End Try
        End Function


        '----------------------------------------------------------------
        ' 删除指定的单位的职级应休假标准
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strBZBS              ：标准标识
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doDelete_YXJ_ZJ( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strBZBS As String) As Boolean

            Try
                With New Josco.JSOA.BusinessRules.rulesKaoqinguanli
                    doDelete_YXJ_ZJ = .doDelete_YXJ_ZJ(strErrMsg, strUserId, strPassword, strBZBS)
                End With
            Catch ex As Exception
                doDelete_YXJ_ZJ = False
                strErrMsg = ex.Message
            End Try
        End Function


        '----------------------------------------------------------------
        '某月的人员应有假期是多少天
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strRydm                   ：人员代码
        '     sttZzdm                   ：部门代码
        '     strDate                   ：月份日期
        '     fltDay                    : 假期天数（返回）
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        '----------------------------------------------------------------
        Public Function getMonthVacation( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strRydm As String, _
            ByVal strZzdm As String, _
            ByVal strDate As String, _
            ByRef dblDay As Double) As Boolean
            Try
                With New Josco.JSOA.BusinessRules.rulesKaoqinguanli
                    getMonthVacation = .getMonthVacation(strErrMsg, strUserId, strPassword, strRydm, strZzdm, strDate, dblDay)
                End With
            Catch ex As Exception
                getMonthVacation = False
                strErrMsg = ex.Message
            End Try
        End Function

        '----------------------------------------------------------------
        '某月的人员某个考勤有多少天
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strRydm                   ：人员代码
        '     strJldm                   ：记录代码
        '     strDate                   ：月份日期
        '     fltDay                    : 假期天数（返回）
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        '----------------------------------------------------------------
        Public Function getMonthKaoqin( _
              ByVal strErrMsg As String, _
              ByVal strUserId As String, _
              ByVal strPassword As String, _
              ByVal strRydm As String, _
              ByVal strJldm As String, _
              ByVal strDate As String, _
              ByRef dblDay As Double) As Boolean
            Try
                With New Josco.JSOA.BusinessRules.rulesKaoqinguanli
                    getMonthKaoqin = .getMonthKaoqin(strErrMsg, strUserId, strPassword, strRydm, strJldm, strDate, dblDay)
                End With
            Catch ex As Exception
                getMonthKaoqin = False
                strErrMsg = ex.Message
            End Try
        End Function

        '----------------------------------------------------------------
        '检查不能在两个以上的部门，在相同的日期也做了休假或者补休或者年假
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     blnMutilCheck        : 休息日、补休、年假、法定节假日检查=true else FALSE
        '     objNewData           ：检查数据
        '     blnExist             ：是否在其他部门已存在
        '     strBMMC              : 存在部门名称

        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doCheck_Kaoqinjilu( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal blnMutilCheck As Boolean, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection, _
            ByRef blnExist As Boolean, _
            ByRef strBMMC As String) As Boolean
            Try
                With New Josco.JSOA.BusinessRules.rulesKaoqinguanli
                    doCheck_Kaoqinjilu = .doCheck_Kaoqinjilu(strErrMsg, strUserId, strPassword, blnMutilCheck, objNewData, blnExist, strBMMC)
                End With
            Catch ex As Exception
                doCheck_Kaoqinjilu = False
                strErrMsg = ex.Message
            End Try
        End Function
    End Class
End Namespace
