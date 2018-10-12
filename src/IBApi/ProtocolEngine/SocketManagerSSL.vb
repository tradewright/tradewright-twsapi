#Region "License"

' The MIT License (MIT)
'
' Copyright (c) 2018 Richard L King (TradeWright Software Systems)
' 
' Permission is hereby granted, free of charge, to any person obtaining a copy
' of this software and associated documentation files (the "Software"), to deal
' in the Software without restriction, including without limitation the rights
' to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
' copies of the Software, and to permit persons to whom the Software is
' furnished to do so, subject to the following conditions:
' 
' The above copyright notice and this permission notice shall be included in all
' copies or substantial portions of the Software.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
' IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
' FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
' AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
' LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
' OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
' SOFTWARE.

#End Region

Imports System.Net.Security
Imports System.Security.Cryptography.X509Certificates
Imports System.Threading.Tasks
Imports TradeWright.IBAPI

Friend Class SocketManagerSSL
    Inherits SocketManager
    Friend Sub New(host As String, port As Integer)
        MyBase.New(host, port)
    End Sub

    Friend Overrides Async Function ConnectAsync(connectedAction As Action, closedAction As Action, errorAction As Action(Of SocketEventArgs), keepAlive As Boolean) As Task(Of Boolean)
        Await MyBase.ConnectAsync(connectedAction, closedAction, errorAction, keepAlive)
        Dim sslStream = New SslStream(_ClientStream, False, Function(o As Object, cert As X509Certificate, chain As X509Chain, errors As SslPolicyErrors) True)

        Await sslStream.AuthenticateAsClientAsync(Me.Host)

        Me._ClientStream = sslStream

        Return True
    End Function
End Class