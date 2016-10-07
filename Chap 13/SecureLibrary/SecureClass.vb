Imports System
Imports System.Security
Imports System.Security.Permissions


Public Class SecureClass

   <StrongNameIdentityPermissionAttribute(SecurityAction.LinkDemand, _
        PublicKey:="00240000048000009400000006020000002400005253413" _
      & "1000400000100010067106E89E18E7CA82EA95CE79D2D6CCF6C22B30F1" _
      & "70B094F20F2DB4480C4E9FC13B79CABC808879C93498FEB20C2003F748" _
      & "D469B44A5176D15FB788C10E85E6456337BE54ACEF7348A6AD4CC4294F" _
      & "2367C39597F7344A6E83B0846DCA3A63262F867EA8ABCC09FB7F7F8319" _
      & "DFF17DDA38A9FDC3885397459715D11B57C66BD98")> _
   Public Function GetSecureString() As String
      Return "Secret Phrase: Confucious say, Penny Saved a Day is " _
      & "Seven Cents a Week."
   End Function

End Class
