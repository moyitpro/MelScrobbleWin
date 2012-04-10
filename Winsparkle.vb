Imports Microsoft.VisualBasic
Imports System.Runtime.InteropServices

Class WinSparkle
    ' Note that some of these functions are not implemented by WinSparkle YET.
    <DllImport("WinSparkle.dll", CallingConvention:=CallingConvention.Cdecl)> _
    Public Shared Sub win_sparkle_init()
    End Sub
    <DllImport("WinSparkle.dll", CallingConvention:=CallingConvention.Cdecl)> _
    Public Shared Sub win_sparkle_cleanup()
    End Sub
    <DllImport("WinSparkle.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Shared Sub win_sparkle_set_appcast_url(ByVal url As [String])
    End Sub
    <DllImport("WinSparkle.dll", CallingConvention:=CallingConvention.Cdecl)> _
    Public Shared Sub win_sparkle_set_app_details(ByVal company_name As [String], ByVal app_name As [String], ByVal app_version As [String])
    End Sub
    <DllImport("WinSparkle.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Shared Sub win_sparkle_set_registry_path(ByVal path As [String])
    End Sub
    <DllImport("WinSparkle.dll", CallingConvention:=CallingConvention.Cdecl)> _
    Public Shared Sub win_sparkle_check_update_with_ui()
    End Sub
End Class