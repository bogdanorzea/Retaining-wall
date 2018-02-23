Public Class Form1

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ordine = Numeric_ordine.Value
        grupa = Numeric_grupa.Value
        Call t1date(ordine, grupa)
        Tema1.Show()
        My.Settings.gr = grupa
        My.Settings.ord = ordine
        My.Settings.Save()
        Me.Close()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If ((Control.ModifierKeys And Keys.Shift) = Keys.Shift) Then
            My.Settings.Reset()
            MsgBox("Predimensionarile au fost resetate!", MsgBoxStyle.Information, "Setări")
        End If

        My.Settings.Reload()
        Numeric_grupa.Value = My.Settings.gr
        Numeric_ordine.Value = My.Settings.ord
    End Sub
End Class