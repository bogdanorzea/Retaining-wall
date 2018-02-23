Public Class Tema1

    Private Sub Start_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim val As Decimal

        Call ipoteze_nu()
        Call text_labels()
        Call ascundere()
        With Me
            .Label_a2.Text = (h / 12)
            .Label_a3.Text = (h / 10)
            .Label_hc2.Text = (h / 24)
            .Label_hc3.Text = (0.3)
            .Label_hf2.Text = (h / 10)
            .Label_hf3.Text = (h / 8)
            .Label_b2.Text = (h / 2)
            .Label_b3.Text = (2 * h / 3)
        End With
        With Me.Predim_a
            .Minimum = round(h / 12) - 0.05
            .Maximum = round(h / 10) + 0.05
            .Value = round(h / 12)
        End With
        With Me.Predim_hc
            .Minimum = round(h / 24) - 0.05
            .Maximum = 0.3
            .Value = round(h / 24)
        End With
        With Me.Predim_hf
            .Minimum = round(h / 10) - 0.05
            .Maximum = round(h / 8) + 0.05
            .Value = round(h / 10)
        End With
        With Me.Predim_b
            .Minimum = round(h / 2) - 0.05
            .Maximum = round(2 * h / 3) + 0.05
            .Value = round(h / 2)
        End With

        Call predim()
        Call predim_val_noi()
        Call predim_val_atrib()
        Tab.SelectTab(0)

        val = My.Settings.a
        If val <> 0 And val < Predim_a.Maximum And val > Predim_a.Minimum Then
            Predim_a.Value = My.Settings.a
        End If

        val = My.Settings.b
        If val <> 0 And val < Predim_b.Maximum And val > Predim_b.Minimum Then
            Predim_b.Value = My.Settings.b
        End If

        val = My.Settings.hcor
        If val <> 0 And val < Predim_hc.Maximum And val > Predim_hc.Minimum Then
            Predim_hc.Value = My.Settings.hcor
        End If

        val = My.Settings.hf
        If val <> 0 And val < Predim_hf.Maximum And val > Predim_hf.Minimum Then
            Predim_hf.Value = My.Settings.hf
        End If

    End Sub

    Private Sub Button_predim_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_predim.Click


        Call labels()
        Call predim_val_atrib()
        Call impingere()
        Call alunecare()
        Call rasturnare()
        Call presiuni()
        Call arata()
        Call det_forte2()
        Call alunecare2()
        Call rasturnare2()
        Call presiuni2()


        My.Settings.a = Predim_a.Value
        My.Settings.b = Predim_b.Value
        My.Settings.hcor = Predim_hc.Value
        My.Settings.hf = Predim_hf.Value
        My.Settings.Save()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        My.Settings.Save()
        Form1.Show()
        Me.Close()

    End Sub
End Class
