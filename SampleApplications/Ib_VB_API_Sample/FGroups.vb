' Copyright (C) 2016 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

Friend Class FGroups

    Private mMainWnd As MainForm

    Private mGroupMessagesText As TextboxDisplayManager

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)
        mGroupMessagesText = New TextboxDisplayManager(GroupMessagesText)
    End Sub

    '--------------------------------------------------------------------------------
    ' init Groups dialog and disable some items
    '--------------------------------------------------------------------------------
    Public Sub Init(mainWin As System.Windows.Forms.Form)

        mMainWnd = mainWin

        enableFields(False)

    End Sub

    '================================================================================
    ' Requests
    '================================================================================
    '--------------------------------------------------------------------------------
    ' query display groups
    '--------------------------------------------------------------------------------
    Private Sub queryDisplayGroupsButton_Click(sender As System.Object, e As System.EventArgs) Handles QueryDisplayGroupsButton.Click

        enableFields(False)
        comboDisplayGroups.Items.Clear()

        Dim reqId = CInt(textId.Text)

        mGroupMessagesText.DisplayMessage($"Querying display groups (reqId={reqId})...")

        ' enable this after removing of temp code
        mMainWnd.Api.QueryDisplayGroups(reqId)

    End Sub

    '--------------------------------------------------------------------------------
    ' clear Group Messages listbox
    '--------------------------------------------------------------------------------
    Private Sub resetButton_Click(sender As System.Object, e As System.EventArgs) Handles ResetButton.Click
        mGroupMessagesText.Clear()
        enableFields(False)
        comboDisplayGroups.Items.Clear()
        textContractInfo.Clear()

    End Sub

    '--------------------------------------------------------------------------------
    ' close Groups dialog
    '--------------------------------------------------------------------------------
    Private Sub closeButton_Click(sender As System.Object, e As System.EventArgs) Handles CloseButton.Click
        Hide()
    End Sub

    ''--------------------------------------------------------------------------------
    '' subscribe to group events
    ''--------------------------------------------------------------------------------
    'private sub SubscribeToGroupEventsButton_Click(sender As System.Object, e As System.EventArgs) Handles SubscribeToGroupEventsButton.Click

    '    Dim groupId = CInt(comboDisplayGroups.Text)

    '    Dim reqId = CInt(textId.Text)

    '    mGroupMessagesText.DisplayMessage("Subscribing to group events (reqId=" & reqId & " groupId=" & groupId & ") ...")

    '    ' enable this after removing of temp code
    '    mMainWnd.Api.subscribeToGroupEvents(reqId, groupId)

    'End Sub

    ''--------------------------------------------------------------------------------
    '' unsubscribe from group events
    ''--------------------------------------------------------------------------------
    'private sub unsubscribeFromGroupEventsButton_Click(sender As System.Object, e As System.EventArgs) Handles UnsubscribeFromGroupEventsButton.Click

    '    Dim reqId = CInt(textId.Text)

    '    mGroupMessagesText.DisplayMessage("Unsubscribing from group events (reqId=" & reqId & ") ...")

    '    mMainWnd.Api.unsubscribeFromGroupEvents(reqId)

    'End Sub

    ''--------------------------------------------------------------------------------
    '' update display group
    ''--------------------------------------------------------------------------------
    'private sub updateDisplayGroupButton_Click(sender As System.Object, e As System.EventArgs) Handles UpdateDisplayGroupButton.Click
    '    Dim contractInfo = textContractInfo.Text
    '    Dim reqId = CInt(textId.Text)

    '    If (contractInfo.Length > 0) Then

    '        mGroupMessagesText.DisplayMessage("Updating display group (reqId=" & reqId & " contractInfo=" & contractInfo & ") ...")

    '        mMainWnd.Api.updateDisplayGroup(reqId, contractInfo)

    '    End If

    'End Sub

    '================================================================================
    ' Events
    '================================================================================
    Public Sub DisplayGroupList(reqId As Integer, groups As String)

        If groups.Length > 0 Then

            comboDisplayGroups.Items.Clear()
            enableFields(True)

            ' parse groups
            Dim result() = Split(groups, "|")
            comboDisplayGroups.Items.AddRange(result)
            comboDisplayGroups.SelectedIndex() = 0

            mGroupMessagesText.DisplayMessage($"Display groups: reqId={reqId} groups={groups}")
        Else
            mGroupMessagesText.DisplayMessage($"Display groups: reqId={reqId} groups=<empty>")
        End If

    End Sub

    Public Sub DisplayGroupUpdated(reqId As Integer, contractInfo As String)

        mGroupMessagesText.DisplayMessage($"Display group updated: reqId={reqId} contractInfo={contractInfo}")

    End Sub

    Private Sub enableFields(enable As Boolean)
        comboDisplayGroups.Enabled = enable
        SubscribeToGroupEventsButton.Enabled = enable
        UnsubscribeFromGroupEventsButton.Enabled = enable
        UpdateDisplayGroupButton.Enabled = enable
        textContractInfo.Enabled = enable
    End Sub

End Class
