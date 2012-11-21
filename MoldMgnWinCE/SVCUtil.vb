Imports System.ServiceModel.Channels
Imports System.ServiceModel
Public Class SVCUtil
    Public Shared Function GetSvc() As SmartDeviceApiClient

        Dim bind As System.ServiceModel.Channels.Binding = SmartDeviceApiClient.CreateDefaultBinding()
        Dim remoteAddress = "http://192.168.0.114:9090/ToolingWCF/SmartDeviceApi/"
        Dim endpoint As EndpointAddress = New EndpointAddress(remoteAddress)
        Dim client As SmartDeviceApiClient = New SmartDeviceApiClient(bind, endpoint)
        Return client

    End Function
End Class
