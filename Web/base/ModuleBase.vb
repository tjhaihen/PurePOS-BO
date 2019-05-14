
Option Strict On
Option Explicit On 

Imports System
Imports System.Web
Imports System.Web.UI
Imports System.ComponentModel
Imports System.Data
Imports Microsoft.VisualBasic

Imports Raven.Common

Imports Raven.SystemFramework

Namespace Raven.Web

    Public Class ModuleBase
        Inherits UserControl

        Private Const UNHANDLED_EXCEPTION As String = "Unhandled Exception:"

        Private basePathPrefix As String

        Public Property PathPrefix() As String
            Get
                If basePathPrefix Is Nothing Then
                    basePathPrefix = PageBase.UrlBase
                End If

                PathPrefix = basePathPrefix
            End Get
            Set(ByVal Value As String)
                basePathPrefix = Value
            End Set
        End Property

        Public Sub Logout()
            System.Web.Security.FormsAuthentication.SignOut()
            Session.Abandon()
            Session.Clear()
            Session.RemoveAll()
            Cache.Remove(commonFunction.Key_CacheLoggedOnUser)
            Cache.Remove(commonFunction.Key_CacheErrorMessage)
        End Sub

        Public Property MB_CacheLoggedOnUser() As DataSet
            Get
                'Return CType(Session(commonFunction.Key_CacheLoggedOnUser), DataSet)
                Try
                    Dim str As String = Request.Cookies(commonFunction.Key_CacheLoggedOnUser).Value
                    Dim arrstr() As String = str.Split(CChar("|"))
                    Dim dt As New DataSet
                    Dim dttable As New DataTable
                    dttable.TableName = "User"
                    dttable.Columns.Add("UserID")
                    dttable.Columns.Add("Password")
                    dttable.Columns.Add("UserName")
                    dttable.Columns.Add("UserGroupID")
                    dttable.Columns.Add("CompanyID")
                    dttable.Columns.Add("CompanyName")
                    dttable.Columns.Add("LocationID")
                    dttable.Columns.Add("LocationName")
                    dttable.Columns.Add("UserGroupMenuResult")

                    Dim dtrow As DataRow = dttable.NewRow()
                    For i As Integer = 0 To arrstr.Length - 1
                        dtrow.Item(i) = arrstr(i)
                    Next
                    dttable.Rows.Add(dtrow)
                    dt.Tables.Add(dttable)

                    Return dt
                Catch
                    Return Nothing
                End Try                
            End Get
            Set(ByVal Value As DataSet)
                If Value Is Nothing Then
                    'Logout()
                    Dim myCookie As HttpCookie
                    myCookie = New HttpCookie(commonFunction.Key_CacheLoggedOnUser)
                    myCookie.Expires = DateTime.Now.AddDays(-1D)
                    Response.Cookies.Add(myCookie)
                Else
                    'Session(commonFunction.Key_CacheLoggedOnUser) = Value
                    Dim str As String = ""
                    str += CType(Value.Tables("User").Rows(0)("UserID"), String) + "|"
                    str += CType(Value.Tables("User").Rows(0)("Password"), String) + "|"
                    str += CType(Value.Tables("User").Rows(0)("UserName"), String) + "|"
                    str += CType(Value.Tables("User").Rows(0)("UserGroupID"), String) + "|"
                    str += CType(Value.Tables("User").Rows(0)("CompanyID"), String) + "|"
                    str += CType(Value.Tables("User").Rows(0)("CompanyName"), String) + "|"
                    str += CType(Value.Tables("User").Rows(0)("LocationID"), String) + "|"
                    str += CType(Value.Tables("User").Rows(0)("LocationName"), String) + "|"
                    str += CType(Value.Tables("User").Rows(0)("UserGroupMenuResult"), String)

                    Dim cookie As HttpCookie
                    cookie = New HttpCookie(commonFunction.Key_CacheLoggedOnUser)
                    cookie.Value = str
                    Response.SetCookie(cookie)
                End If
            End Set
        End Property

        Public ReadOnly Property MB_UserID() As String
            Get
                Return CType(MB_CacheLoggedOnUser.Tables("User").Rows(0)("UserID"), String)
            End Get
        End Property

        Public ReadOnly Property MB_pwd() As String
            Get
                Return CType(MB_CacheLoggedOnUser.Tables("User").Rows(0)("Password"), String)
            End Get
        End Property

        Public ReadOnly Property MB_UserName() As String
            Get
                Return CType(MB_CacheLoggedOnUser.Tables("User").Rows(0)("UserName"), String)
            End Get
        End Property

        Public ReadOnly Property MB_UserGroupID() As String
            Get
                Return CType(MB_CacheLoggedOnUser.Tables("User").Rows(0)("UserGroupID"), String)
            End Get
        End Property

        Public ReadOnly Property MB_UserGroupName() As String
            Get
                Return CType(MB_CacheLoggedOnUser.Tables("User").Rows(0)("UserGroupName"), String)
            End Get
        End Property

        Public Property MB_CompanyID() As String
            Get
                Return CType(MB_CacheLoggedOnUser.Tables("User").Rows(0)("CompanyID"), String)
            End Get
            Set(ByVal Value As String)
                MB_CacheLoggedOnUser.Tables("User").Rows(0)("CompanyID") = Value
            End Set
        End Property

        Public Property MB_CompanyName() As String
            Get
                Return CType(MB_CacheLoggedOnUser.Tables("User").Rows(0)("CompanyName"), String)
            End Get
            Set(ByVal Value As String)
                MB_CacheLoggedOnUser.Tables("User").Rows(0)("CompanyName") = Value
            End Set
        End Property

        Public Property MB_LocationID() As String
            Get
                Return CType(MB_CacheLoggedOnUser.Tables("User").Rows(0)("LocationID"), String)
            End Get
            Set(ByVal Value As String)
                MB_CacheLoggedOnUser.Tables("User").Rows(0)("LocationID") = Value
            End Set
        End Property

        Public Property MB_LocationName() As String
            Get
                Return CType(MB_CacheLoggedOnUser.Tables("User").Rows(0)("LocationName"), String)
            End Get
            Set(ByVal Value As String)
                MB_CacheLoggedOnUser.Tables("User").Rows(0)("LocationName") = Value
            End Set
        End Property

        Public ReadOnly Property MB_UserGroupMenuResult() As String
            Get
                Return CType(MB_CacheLoggedOnUser.Tables("User").Rows(0)("UserGroupMenuResult"), String)
            End Get
        End Property

        Public ReadOnly Property MB_UserGroupMenu() As DataTable
            Get
                Return MB_CacheLoggedOnUser.Tables("UserGroupMenu")
            End Get
        End Property

    End Class

End Namespace