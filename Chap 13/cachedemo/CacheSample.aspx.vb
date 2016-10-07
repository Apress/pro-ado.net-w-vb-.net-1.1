Public Class CacheSample
    Inherits System.Web.UI.Page
   Protected WithEvents CacheLabel As System.Web.UI.WebControls.Label
   Protected WithEvents LiveLabel As System.Web.UI.WebControls.Label

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

   End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

   Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      'Put user code to initialize the page here
      If Cache("CachedValue") = Nothing Then
         Cache.Insert("CachedValue", _
                      "Cached At : " + DateTime.Now.ToString(), _
                      Nothing, DateTime.Now.AddMinutes(1), _
                      System.Web.Caching.Cache.NoSlidingExpiration)
      End If
      CacheLabel.Text = CType(Cache("CachedValue"), String)
      LiveLabel.Text = DateTime.Now.ToString()
   End Sub

End Class
