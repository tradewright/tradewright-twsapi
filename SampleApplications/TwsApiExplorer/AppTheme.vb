Public Class AppTheme
    Inherits TradeWright.UI.Themes.DarkTheme

    Public Overrides ReadOnly Property ButtonFont As Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular)

    Public Overrides ReadOnly Property TextBoxBackColor As Color = Color.FromArgb(96, 96, 96)


    ' We use ThemedButton1 for the main buttons on forms
    Public Overrides ReadOnly Property Button1Autosize As Boolean = True
    Public Overrides ReadOnly Property Button1ForeColor As Color = Color.DimGray
    Public Overrides ReadOnly Property Button1Font As Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular)
    Public Overrides ReadOnly Property Button1UseVisualStyleBackColor As Boolean = True

    ' We use ThemedLabel1 for titles in panels
    Public Overrides ReadOnly Property Label1Autosize As Boolean = True
    Public Overrides ReadOnly Property Label1Backcolor As Color = Color.DeepSkyBlue
    Public Overrides ReadOnly Property Label1Forecolor As Color = Color.White
    Public Overrides ReadOnly Property Label1Font As Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular)

End Class
