Imports System.ServiceModel.Channels
Imports System.ServiceModel
Imports System.IO
Public Class SVCUtil
    Private Shared Function GetRemoteAddress() As String


    End Function
    Public Shared Function GetSvc() As SmartDeviceApiClient

        Dim bind As System.ServiceModel.Channels.Binding = SmartDeviceApiClient.CreateDefaultBinding()
        Dim remoteAddress = "http://192.168.0.240:9090/ToolingWCF/SmartDeviceApi/basic"
        Dim endpoint As EndpointAddress = New EndpointAddress(remoteAddress)
        Dim client As SmartDeviceApiClient = New SmartDeviceApiClient(bind, endpoint)
        Return client

    End Function
End Class
