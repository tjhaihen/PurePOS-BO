Option Strict On
Option Explicit On

Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Collections
Imports System.ComponentModel
Imports System.Text
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient

Imports Telerik.Web.UI

Imports Raven.Web
Imports Raven.Common
Imports Raven.SystemFramework

Namespace Raven
    Public Enum CSSToolbarItem
        tidNew = 0
        tidSave = 1
        tidDelete = 2
        tidApprove = 3
        tidVoid = 4
        tidPrint = 5
        tidPrevious = 6
        tidNext = 7
        tidOther1 = 8
        tidOther2 = 9
        tidOther3 = 10
    End Enum

    Public MustInherit Class CSSToolbar
        Inherits ModuleBase

        Private _IsValid As Boolean = False
        Private _UserGroupID As String = String.Empty
        Private _MenuID As String = String.Empty

        Public Event CSSToolbarItemClick(ByVal sender As Object, ByVal e As CSSToolbarItem)

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        End Sub

        Public Sub setAuthorizationToolbar()
            If Not MyBase.MB_CacheLoggedOnUser Is Nothing Then
                Dim oUGM As New BussinessRules.UserGroupMenu
                oUGM.UserGroupID = _UserGroupID.Trim
                oUGM.MenuID = _MenuID.Trim

                Dim dv As New DataView(oUGM.SelectOtorisasiMenuByUserGroupIDMenuID)
                'dv.RowFilter = "MenuID = '" + _MenuID.Trim + "'"
                If dv.Count = 1 Then
                    If CType(dv(0)("IsAllowAdd"), Boolean) Then
                        chkIsAllowAdd.Checked = True
                        'lbtnNew.Enabled = True
                        EnableButton(CSSToolbarItem.tidNew) = True
                    Else
                        chkIsAllowAdd.Checked = False
                        'lbtnNew.Enabled = False
                        EnableButton(CSSToolbarItem.tidNew) = False
                    End If
                    If CType(dv(0)("IsAllowEdit"), Boolean) Then
                        chkIsAllowEdit.Checked = True
                    Else
                        chkIsAllowEdit.Checked = False
                    End If
                    If chkIsAllowAdd.Checked Or chkIsAllowEdit.Checked Then
                        'lbtnSave.Enabled = True
                        EnableButton(CSSToolbarItem.tidSave) = True
                    Else
                        'lbtnSave.Enabled = False
                        EnableButton(CSSToolbarItem.tidSave) = False
                    End If

                    If CType(dv(0)("IsAllowDelete"), Boolean) Then
                        chkIsAllowDelete.Checked = True
                        'lbtnDelete.Enabled = True
                        EnableButton(CSSToolbarItem.tidDelete) = True
                    Else
                        chkIsAllowDelete.Checked = False
                        'lbtnDelete.Enabled = False
                        EnableButton(CSSToolbarItem.tidDelete) = False
                    End If

                    If CType(dv(0)("IsAllowApprove"), Boolean) Then
                        chkIsAllowApprove.Checked = True
                        'lbtnApprove.Enabled = True
                        EnableButton(CSSToolbarItem.tidApprove) = True
                    Else
                        chkIsAllowApprove.Checked = False
                        'lbtnApprove.Enabled = False
                        EnableButton(CSSToolbarItem.tidApprove) = False
                    End If

                    If CType(dv(0)("IsAllowVoid"), Boolean) Then
                        chkIsAllowVoid.Checked = True
                        'lbtnVoid.Enabled = True
                        EnableButton(CSSToolbarItem.tidVoid) = True
                    Else
                        chkIsAllowVoid.Checked = False
                        'lbtnVoid.Enabled = False
                        EnableButton(CSSToolbarItem.tidVoid) = False
                    End If

                    If CType(dv(0)("IsAllowPrint"), Boolean) Then
                        chkIsAllowPrint.Checked = True
                        'lbtnPrint.Enabled = True
                        EnableButton(CSSToolbarItem.tidPrint) = True
                    Else
                        chkIsAllowPrint.Checked = False
                        'lbtnPrint.Enabled = False
                        EnableButton(CSSToolbarItem.tidPrint) = False
                    End If
                Else
                    Throw New Exception(commonFunction.MSG_ACCESS_DENIED)
                End If
                dv = Nothing
            End If
        End Sub

        Public Property EnableButton(ByVal item As CSSToolbarItem) As Boolean
            Get
                Select Case item
                    Case CSSToolbarItem.tidNew
                        Return lbtnNew.Enabled
                    Case CSSToolbarItem.tidSave
                        Return lbtnSave.Enabled
                    Case CSSToolbarItem.tidDelete
                        Return lbtnDelete.Enabled
                    Case CSSToolbarItem.tidApprove
                        Return lbtnApprove.Enabled
                    Case CSSToolbarItem.tidVoid
                        Return lbtnVoid.Enabled
                    Case CSSToolbarItem.tidPrevious
                        Return lbtnPrevious.Enabled
                    Case CSSToolbarItem.tidNext
                        Return lbtnNext.Enabled
                    Case CSSToolbarItem.tidPrint
                        Return lbtnPrint.Enabled
                    Case CSSToolbarItem.tidOther1
                        Return lbtnOther1.Enabled
                    Case CSSToolbarItem.tidOther2
                        Return lbtnOther2.Enabled
                    Case CSSToolbarItem.tidOther3
                        Return lbtnOther3.Enabled
                End Select
            End Get
            Set(ByVal Value As Boolean)
                Select Case item
                    Case CSSToolbarItem.tidNew
                        lbtnNew.Enabled = Value
                    Case CSSToolbarItem.tidSave
                        If chkIsAllowAdd.Checked Or chkIsAllowEdit.Checked Then
                            If Value Then
                                lbtnSave.Attributes.Add("OnClick", "javascript: if (!confirm('" + commonFunction.MSG_SAVE + "')) return false; return true;")
                            Else
                                lbtnSave.Attributes.Remove("OnClick")
                            End If
                        End If
                        lbtnSave.Enabled = Value
                    Case CSSToolbarItem.tidDelete
                        If chkIsAllowDelete.Checked Then
                            If Value Then
                                lbtnDelete.Attributes.Add("OnClick", "javascript: if (!confirm('" + commonFunction.MSG_DELETE + "')) return false; return true")
                            Else
                                lbtnDelete.Attributes.Remove("OnClick")
                            End If
                        End If
                        lbtnDelete.Enabled = Value
                    Case CSSToolbarItem.tidApprove
                        If chkIsAllowApprove.Checked Then
                            If Value Then
                                lbtnApprove.Attributes.Add("OnClick", "javascript: if (!confirm('" + commonFunction.MSG_APPROVE + "')) return false; return true")
                            Else
                                lbtnApprove.Attributes.Remove("OnClick")
                            End If
                        End If
                        lbtnApprove.Enabled = Value
                    Case CSSToolbarItem.tidVoid
                        If chkIsAllowVoid.Checked Then
                            If Value Then
                                lbtnVoid.Attributes.Add("OnClick", "javascript: if (!confirm('" + commonFunction.MSG_VOID + "')) return false; return true")
                            Else
                                lbtnVoid.Attributes.Remove("OnClick")
                            End If
                        End If
                        lbtnVoid.Enabled = Value
                    Case CSSToolbarItem.tidPrevious
                        lbtnPrevious.Enabled = Value
                    Case CSSToolbarItem.tidNext
                        lbtnNext.Enabled = Value
                    Case CSSToolbarItem.tidPrint
                        If chkIsAllowPrint.Checked Then
                            If Value Then
                                lbtnPrint.Attributes.Add("OnClick", "javascript: if (!confirm('" + commonFunction.MSG_PRINT + "')) return false; return true")
                            Else
                                lbtnPrint.Attributes.Remove("OnClick")
                            End If
                        End If
                        lbtnPrint.Enabled = Value
                    Case CSSToolbarItem.tidOther1
                        lbtnOther1.Enabled = Value
                    Case CSSToolbarItem.tidOther2
                        lbtnOther2.Enabled = Value
                    Case CSSToolbarItem.tidOther3
                        lbtnOther3.Enabled = Value
                End Select
            End Set
        End Property
        Public Property VisibleButton(ByVal item As CSSToolbarItem) As Boolean
            Get
                Select Case item
                    Case CSSToolbarItem.tidNew
                        Return TMPnlNew.Visible
                    Case CSSToolbarItem.tidSave
                        Return TMPnlSave.Visible
                    Case CSSToolbarItem.tidDelete
                        Return TMPnlDelete.Visible
                    Case CSSToolbarItem.tidApprove
                        Return TMPnlApprove.Visible
                    Case CSSToolbarItem.tidVoid
                        Return TMPnlVoid.Visible
                    Case CSSToolbarItem.tidPrevious
                        Return TMPnlPrevious.Visible
                    Case CSSToolbarItem.tidNext
                        Return TMPnlNext.Visible
                    Case CSSToolbarItem.tidPrint
                        Return TMPnlPrint.Visible
                    Case CSSToolbarItem.tidOther1
                        Return TMPnlOther1.Visible
                    Case CSSToolbarItem.tidOther2
                        Return TMPnlOther2.Visible
                    Case CSSToolbarItem.tidOther3
                        Return TMPnlOther3.Visible
                End Select
            End Get
            Set(ByVal Value As Boolean)
                Select Case item
                    Case CSSToolbarItem.tidNew
                        TMPnlNew.Visible = Value
                    Case CSSToolbarItem.tidSave
                        TMPnlSave.Visible = Value
                    Case CSSToolbarItem.tidDelete
                        TMPnlDelete.Visible = Value
                    Case CSSToolbarItem.tidApprove
                        TMPnlApprove.Visible = Value
                    Case CSSToolbarItem.tidVoid
                        TMPnlVoid.Visible = Value
                    Case CSSToolbarItem.tidPrevious
                        TMPnlPrevious.Visible = Value
                    Case CSSToolbarItem.tidNext
                        TMPnlNext.Visible = Value
                    Case CSSToolbarItem.tidPrint
                        TMPnlPrint.Visible = Value
                    Case CSSToolbarItem.tidOther1
                        TMPnlOther1.Visible = Value
                    Case CSSToolbarItem.tidOther2
                        TMPnlOther2.Visible = Value
                    Case CSSToolbarItem.tidOther3
                        TMPnlOther3.Visible = Value
                End Select
            End Set
        End Property
        Private Sub lbtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnNew.Click, lbtnSave.Click, lbtnDelete.Click, _
                                                                                            lbtnApprove.Click, lbtnVoid.Click, lbtnPrint.Click, _
                                                                                             lbtnPrevious.Click, lbtnNext.Click, lbtnOther1.Click, _
                                                                                             lbtnOther2.Click, lbtnOther3.Click
            Select Case CType(sender, LinkButton).ClientID
                Case lbtnNew.ClientID
                    RaiseEvent CSSToolbarItemClick(sender, CSSToolbarItem.tidNew)
                Case lbtnSave.ClientID
                    RaiseEvent CSSToolbarItemClick(sender, CSSToolbarItem.tidSave)
                Case lbtnDelete.ClientID
                    RaiseEvent CSSToolbarItemClick(sender, CSSToolbarItem.tidDelete)
                Case lbtnApprove.ClientID
                    RaiseEvent CSSToolbarItemClick(sender, CSSToolbarItem.tidApprove)
                Case lbtnVoid.ClientID
                    RaiseEvent CSSToolbarItemClick(sender, CSSToolbarItem.tidVoid)
                Case lbtnPrint.ClientID
                    RaiseEvent CSSToolbarItemClick(sender, CSSToolbarItem.tidPrint)
                Case lbtnPrevious.ClientID
                    RaiseEvent CSSToolbarItemClick(sender, CSSToolbarItem.tidPrevious)
                Case lbtnNext.ClientID
                    RaiseEvent CSSToolbarItemClick(sender, CSSToolbarItem.tidNext)
                Case lbtnOther1.ClientID
                    RaiseEvent CSSToolbarItemClick(sender, CSSToolbarItem.tidOther1)
                Case lbtnOther2.ClientID
                    RaiseEvent CSSToolbarItemClick(sender, CSSToolbarItem.tidOther2)
                Case lbtnOther3.ClientID
                    RaiseEvent CSSToolbarItemClick(sender, CSSToolbarItem.tidOther3)
            End Select
        End Sub

        Public ReadOnly Property TB_IsAllowAdd() As Boolean
            Get
                Return chkIsAllowAdd.Checked
            End Get
        End Property
        Public ReadOnly Property TB_IsAllowEdit() As Boolean
            Get
                Return chkIsAllowEdit.Checked
            End Get
        End Property
        Public ReadOnly Property TB_IsAllowDelete() As Boolean
            Get
                Return chkIsAllowDelete.Checked
            End Get
        End Property
        Public ReadOnly Property TB_IsAllowApprove() As Boolean
            Get
                Return chkIsAllowApprove.Checked
            End Get
        End Property
        Public ReadOnly Property TB_IsAllowVoid() As Boolean
            Get
                Return chkIsAllowVoid.Checked
            End Get
        End Property
        Public ReadOnly Property TB_IsAllowPrint() As Boolean
            Get
                Return chkIsAllowPrint.Checked
            End Get
        End Property
        Public ReadOnly Property IsValid() As Boolean
            Get
                Return _IsValid
            End Get
        End Property
        Public Property [UserGroupID]() As String
            Get
                Return _UserGroupID
            End Get
            Set(ByVal Value As String)
                _UserGroupID = Value
            End Set
        End Property
        Public Property [MenuID]() As String
            Get
                Return _MenuID
            End Get
            Set(ByVal Value As String)
                _MenuID = Value
            End Set
        End Property

        Public Property [lbtnOther1_Text]() As String
            Get
                Return lbtnOther1.ToolTip
            End Get
            Set(ByVal Value As String)
                lbtnOther1.Text = "<img src=""/pureravenslib/images/tbother1.png"" alt="""" border=""0"" /><br />" + Value + ""
                lbtnOther1.ToolTip = Value
            End Set
        End Property

        Public Property [lbtnOther2_Text]() As String
            Get
                Return lbtnOther2.Text
            End Get
            Set(ByVal Value As String)
                lbtnOther2.Text = "<img src=""/pureravenslib/images/tbother2.png"" alt="""" border=""0"" /><br />" + Value + ""
                lbtnOther2.ToolTip = Value
            End Set
        End Property

        Public Property [lbtnOther3_Text]() As String
            Get
                Return lbtnOther3.Text
            End Get
            Set(ByVal Value As String)
                lbtnOther3.Text = "<img src=""/pureravenslib/images/tbother3.png"" alt="""" border=""0"" /><br />" + Value + ""
                lbtnOther3.ToolTip = Value
            End Set
        End Property
    End Class
End Namespace


