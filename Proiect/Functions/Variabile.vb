Module Variabile

    Public ordine As Integer = 14
    Public grupa As Integer = 15
    Public g, fi, q, f, h, pconv As Decimal
    Public gb As Decimal = 25
    Public df As Decimal = 1.2

    Public a, hcor, hf, b As Decimal
    Public pg, pq, pa, ka, hp As Decimal
    Public g1, g2, g3, g4, vl As Decimal
    Public N, M, b1, b2, b3, b4, ar, w, pmax, pmin As Decimal
    Public vr, ms, mr As Decimal

    Public hb, pb, hc, pc, s1b, s3b, s1c, s3c As Decimal
    Public bc, pbc_tr, pbc_pl As Decimal
    Public pqab, pqcd, pgab, pgcd As Decimal
    Public g42, vl2, vr2, ms2, mr2 As Decimal
    Public pbctrv, pbctrh, pbcplv, pbcplh, ob, oc As Decimal
    Public m2, n2, pmax2, pmin2 As Decimal

    Public kn As String = " kN"
    Public knmp As String = " kN/m²"
    Public knm As String = " kN*m"

    'Date de ordine
    Sub t1date(ByVal ord As Integer, ByVal grup As Integer)
        g = 19 - 0.1 * grup
        fi = 31 + 0.5 * 1
        q = 10 + 2.5 * 1
        f = 0.44 + Int(grup / 4) * 0.01
        h = 3.5 + 0.1 * ord
        pconv = 350 - 10 * grup
    End Sub

    'Functie aproximare la 5cm
    Function round(ByVal a As Decimal)
        Dim b As Long
        b = a / 0.05
        a = b * 0.05
        round = a

    End Function

    'Calcul elementelor pentru predimensionare
    Sub predim()
        With Tema1
            .Label_a2.Text = (h / 12)
            .Label_a3.Text = (h / 10)
            .Label_hc2.Text = (h / 24)
            .Label_hc3.Text = (0.3)
            .Label_hf2.Text = (h / 10)
            .Label_hf3.Text = (h / 8)
            .Label_b2.Text = (h / 2)
            .Label_b3.Text = (2 * h / 3)
        End With
        With Tema1.Predim_a
            .Minimum = round(h / 12) - 0.05
            .Maximum = round(h / 10) + 0.05
        End With
        With Tema1.Predim_hc
            .Minimum = round(h / 24) - 0.05
            .Maximum = 0.3
        End With
        With Tema1.Predim_hf
            .Minimum = round(h / 10) - 0.05
            .Maximum = round(h / 8) + 0.05
        End With
        With Tema1.Predim_b
            .Minimum = round(h / 2) - 0.05
            .Maximum = round(2 * h / 3) + 0.05
        End With
    End Sub
    Sub predim_val_noi()
        Dim max As Decimal = 0.3
        If (round(h / 24) > 0.3) Then max = (h / 24)
        Tema1.Predim_a.Value = round(h / 12)
        Tema1.Predim_hc.Value = round(max)
        Tema1.Predim_hf.Value = round(h / 10)
        Tema1.Predim_b.Value = round(h / 2)
    End Sub
    Sub predim_val_atrib()
        a = Tema1.Predim_a.Value
        hcor = Tema1.Predim_hc.Value
        hf = Tema1.Predim_hf.Value
        b = Tema1.Predim_b.Value
    End Sub
    Sub predim_val()
        Tema1.Predim_a.Value = a
        Tema1.Predim_hc.Value = hcor
        Tema1.Predim_hf.Value = hf
        Tema1.Predim_b.Value = b
    End Sub

    'Verificari ale digului Ipoteza 1
    Sub impingere()

        ka = (Math.Tan((45 - fi / 2) * Math.PI / 180)) ^ 2
        pg = g * h ^ 2 * ka / 2
        pq = q * ka * h
        pa = pg + pq
        hp = (pg * h / 3 + pq * h / 2) / pa

        Tema1.Label_ka.Text = Tema1.Label_ka.Text + Left(ka, 7)
        Tema1.Label_pg.Text = Tema1.Label_pg.Text + Left(pg, 7) + kn
        Tema1.Label_pq.Text = Tema1.Label_pq.Text + Left(pq, 7) + kn
        Tema1.Label_pa.Text = Tema1.Label_pa.Text + Left(pa, 7) + kn
        Tema1.Label_hp.Text = Tema1.Label_hp.Text + Left(hp, 5) + " m"

    End Sub
    Sub alunecare()

        g1 = (h - hf) * (a - hcor) * 1.0 * gb / 2
        g2 = (h - hf) * hcor * 1.0 * gb
        g3 = b * hf * 1.0 * gb
        g4 = (b - 2 * a) * (h - hf) * 1.0 * g + q * (b - 2 * a) * 1.0
        vl = (g1 + g2 + g3 + g4) * f / pa

        If (vl < 1.3) Or (vl > 1.4) Then
            MsgBox("Digul nu se verifică la alunecare!", MsgBoxStyle.Critical)
        End If

        Tema1.Label_g1.Text = Tema1.Label_g1.Text + Left(g1, 7) + kn
        Tema1.Label_g2.Text = Tema1.Label_g2.Text + Left(g2, 7) + kn
        Tema1.Label_g3.Text = Tema1.Label_g3.Text + Left(g3, 7) + kn
        Tema1.Label_g4.Text = Tema1.Label_g4.Text + Left(g4, 7) + kn

        Tema1.Label_vl.Text = Tema1.Label_vl.Text + Left(vl, 5)



    End Sub
    Sub rasturnare()

        b1 = 5 * a / 3 - hcor * 2 / 3
        b2 = 2 * a - hcor / 2
        b3 = b / 2
        b4 = a + b / 2

        ms = g1 * b1 + g2 * b2 + g3 * b3 + g4 * b4
        mr = pa * hp
        vr = ms / mr

        If vr < 1.5 Then
            MsgBox("Digul nu se verifică la răsturnare!", MsgBoxStyle.Critical)
        End If

        Tema1.Label_ms.Text = Tema1.Label_ms.Text + Left(ms, 7) + knm
        Tema1.Label_mr.Text = Tema1.Label_mr.Text + Left(mr, 7) + knm

        Tema1.Label_vr.Text = Tema1.Label_vr.Text + Left(vr, 5)

    End Sub
    Sub presiuni()

        Dim x1, x2, x3, x4 As Decimal

        x1 = b / 2 - b1
        x2 = b / 2 - b2
        x3 = 0
        x4 = b4 - b / 2

        ar = b * 1.0
        w = 1 * (b ^ 2) / 6

        N = g1 + g2 + g3 + g4
        M = pa * hp + g1 * x1 + g2 * x2 + g3 * x3 - g4 * x4

        pmax = N / ar + M / w
        pmin = N / ar - M / w

        If (pmax > 1.2 * pconv) Or (pmin < 0) Then
            MsgBox("Exista o problemă cu transmiterea presiunilor terenului!", MsgBoxStyle.Critical)
        End If

        Tema1.Label_pmin.Text = Tema1.Label_pmin.Text + Left(pmin, 7) + knmp
        Tema1.Label_pmax.Text = Tema1.Label_pmax.Text + Left(pmax, 7) + knmp

    End Sub

    'Verificari ale digului Ipoteza 2
    Sub det_pb()
        Dim x, r As Decimal
        hb = h - hf - (b - 2 * a) * Math.Tan((45 + fi / 2) * Math.PI / 180)
        s1b = hb * g + q
        s3b = s1b * ka
        x = (s1b + s3b) / 2
        r = (s1b - s3b) / 2
        pb = Math.Sqrt(x ^ 2 - r ^ 2)

        Tema1.Label_pb.Text = Tema1.Label_pb.Text + Left(pb, 7) + kn

    End Sub
    Sub det_pc()
        Dim x, r As Decimal

        hc = h - hf
        s1c = hc * g + q
        s3c = s1c * ka
        x = (s1c + s3c) / 2
        r = (s1c - s3c) / 2
        pc = Math.Sqrt(x ^ 2 - r ^ 2)

        Tema1.Label_pc.Text = Tema1.Label_pc.Text + Left(pc, 7) + kn
    End Sub
    Sub det_bc()
        Call det_pb()
        Call det_pc()
        bc = (b - 2 * a) / Math.Cos((45 + fi / 2) * Math.PI / 180)
        pbc_pl = bc * pb '* Math.Cos(fi * Math.PI / 180)
        pbc_tr = (pc - pb) * bc / 2 'bc * Math.Cos(fi * Math.PI / 180) * (pc - pb) / 2

    End Sub
    Sub det_forte2()
        Call det_bc()
        pgab = g * hb ^ 2 * ka / 2
        pqab = q * hb * ka
        pgcd = (2 * h - hf) * g * ka * hf / 2
        pqcd = q * hf * ka
    End Sub
    Sub alunecare2()

        g1 = (h - hf) * (a - hcor) * 1.0 * gb / 2
        g2 = (h - hf) * hcor * 1.0 * gb
        g3 = b * hf * 1.0 * gb
        g42 = (b - 2 * a) * (h - hb - hf) * 1.0 * g / 2
        pbctrv = pbc_tr * Math.Cos((45 - fi / 2) * Math.PI / 180)
        pbcplv = pbc_pl * Math.Cos((45 - fi / 2) * Math.PI / 180)
        pbctrh = pbc_tr * Math.Sin((45 - fi / 2) * Math.PI / 180)
        pbcplh = pbc_pl * Math.Sin((45 - fi / 2) * Math.PI / 180)

        vl2 = (g1 + g2 + g3 + g42 + pbctrv + pbcplv) * f / (pbctrh + pbcplh + pqab + pqcd + pgab + pgcd)
        If (vl2 < 1.3) Or (vl2 > 1.4) Then
            MsgBox("Digul nu se verifică la alunecare in ipoteza 2!", MsgBoxStyle.Critical)
        End If

        'Tema1.Label_g1.Text = Tema1.Label_g1.Text + Left(g1, 7) + kn
        'Tema1.Label_g2.Text = Tema1.Label_g2.Text + Left(g2, 7) + kn
        'Tema1.Label_g3.Text = Tema1.Label_g3.Text + Left(g3, 7) + kn
        'Tema1.Label_g4.Text = Tema1.Label_g4.Text + Left(g4, 7) + kn
        Tema1.Label_vl2.Text = Tema1.Label_vl2.Text + Left(vl2, 5)



    End Sub
    Sub rasturnare2()

        oc = (b - 2 * a)
        ob = (b - 2 * a) * Math.Tan((45 + fi / 2) * Math.PI / 180)
        b1 = 5 * a / 3 - hcor * 2 / 3
        b2 = 2 * a - hcor / 2
        b3 = b / 2
        b4 = b - oc * 2 / 3

        ms2 = g1 * b1 + g2 * b2 + g3 * b3 + g42 * b4 + _
              pbctrv * (2 * a + 2 * oc / 3) + _
              pbcplv * (2 * a + oc / 2)

        mr2 = pgab * (h - 2 * hb / 3) + _
              pqab * (h - hb / 2) + _
              pbcplh * (hf + ob / 2) + _
              pbctrh * (hf + ob / 3) + _
              pqcd * (hf / 2) + _
              hc * g * hf * 0.5 * hf * ka + _
              q * hf * ka * 0.5 * hf + _
              g * ka * hf ^ 2 * 0.5 * 0.5 * hf
        vr2 = ms2 / mr2

        If vr < 1.5 Then
            MsgBox("Digul nu se verifică la răsturnare in ipoteza 2!", MsgBoxStyle.Critical)
        End If

        Tema1.Label_ms2.Text = Tema1.Label_ms2.Text + Left(ms2, 7) + knm
        Tema1.Label_mr2.Text = Tema1.Label_mr2.Text + Left(mr2, 7) + knm
        Tema1.Label_vr2.Text = Tema1.Label_vr2.Text + Left(vr2, 5)

    End Sub
    Sub presiuni2()

        n2 = g1 + g2 + g3 + g42 + pbcplv + pbctrv

        m2 = g1 * (b / 2 - b1) + g2 * (b / 2 - b2) + g3 * (0) + g42 * (b / 2 - b4) + _
              pbctrv * (b / 2 - (2 * a + 2 * oc / 3)) + pbcplv * (b / 2 - (2 * a + oc / 2)) + _
              mr2

        pmax2 = n2 / ar + m2 / w
        pmin2 = n2 / ar - m2 / w

        If (pmax2 > 1.2 * pconv) Or (pmin2 < 0) Then
            MsgBox("Exista o problemă cu transmiterea presiunilor terenului in ipoteza 2!", MsgBoxStyle.Critical)
        End If

        Tema1.Label_pmin2.Text = Tema1.Label_pmin2.Text + Left(pmin2, 7) + knmp
        Tema1.Label_pmax2.Text = Tema1.Label_pmax2.Text + Left(pmax2, 7) + knmp

    End Sub

    'Atribuirea numelor etichetelor
    Sub labels()
        With Tema1
            .Label_g1.Text = "G1= "

            .Label_g1.Text = "G1= "
            .Label_g2.Text = "G2= "
            .Label_g3.Text = "G3= "
            .Label_g4.Text = "G4= "

            .Label_ka.Text = "ka= "
            .Label_pg.Text = "pg= "
            .Label_pq.Text = "pq= "
            .Label_pa.Text = "pa= "
            .Label_hp.Text = "hp= "
            .Label_pb.Text = "pb= "
            .Label_pc.Text = "pc= "



            .Label_vl.Text = "νl= "
            .Label_vl2.Text = "νl= "

            .Label_ms.Text = "Ms= "
            .Label_mr.Text = "Mr= "
            .Label_vr.Text = "νs= "
            .Label_ms2.Text = "Ms= "
            .Label_mr2.Text = "Mr= "
            .Label_vr2.Text = "νs= "

            .Label_pmin.Text = "Pmin= "
            .Label_pmax.Text = "Pmax= "
            .Label_pmin2.Text = "Pmin= "
            .Label_pmax2.Text = "Pmax= "
        End With
    End Sub
    Sub text_labels()
        Tema1.g1.Text = "γ= " + Left(g, 7) + knmp
        Tema1.fi1.Text = "ɸ= " + Left(fi, 7) + "°"
        Tema1.q1.Text = "q= " + Left(q, 7) + knmp
        Tema1.f1.Text = "f= " + Left(f, 7) + " m"
        Tema1.H1.Text = "H= " + Left(h, 7) + " m"
        Tema1.Df1.Text = "Df= " + Left(df, 7) + " m"
        Tema1.pconv1.Text = "pconv= " + Left(pconv, 7) + knmp
        Call labels()

    End Sub

    'Ascundere elemente de calcul
    Sub ascundere()
        With Tema1
            'Atentionare
            .Label_atimp.Text = "Alegeți dimensiuniile zidului de sprijin!"
            .Label_atalunec.Text = "Alegeți dimensiuniile zidului de sprijin!"
            .Label_atpres.Text = "Alegeți dimensiuniile zidului de sprijin!"
            .Label_atrast.Text = "Alegeți dimensiuniile zidului de sprijin!"

            'Impingere
            .Label_ka.Visible = False
            .Label_pg.Visible = False
            .Label_pq.Visible = False
            .Label_pa.Visible = False
            .Label_hp.Visible = False
            .Label_pb.Visible = False
            .Label_pc.Visible = False

            'Alunecare
            .Label_g1.Visible = False
            .Label_g2.Visible = False
            .Label_g3.Visible = False
            .Label_g4.Visible = False
            .Label_vl.Visible = False
            .Label_vl2.Visible = False

            'Rasturnare
            .Label_ms.Visible = False
            .Label_mr.Visible = False
            .Label_vr.Visible = False
            .Label_ms2.Visible = False
            .Label_mr2.Visible = False
            .Label_vr2.Visible = False

            'Presiuni
            .Label_pmax.Visible = False
            .Label_pmin.Visible = False
            .Label_pmax2.Visible = False
            .Label_pmin2.Visible = False
        End With
    End Sub
    Sub arata()
        With Tema1
            'Afisare ipoteze
            .Label8.Visible = True
            .Label9.Visible = True
            .Label10.Visible = True
            .Label11.Visible = True
            .Label12.Visible = True
            .Label13.Visible = True
            .Label14.Visible = True
            .Label15.Visible = True
            'Atentionare calcul
            .Label_atimp.Visible = False
            .Label_atalunec.Visible = False
            .Label_atpres.Visible = False
            .Label_atrast.Visible = False
            'Impingere
            .Label_ka.Visible = True
            .Label_pg.Visible = True
            .Label_pq.Visible = True
            .Label_pa.Visible = True
            .Label_hp.Visible = True
            .Label_pb.Visible = True
            .Label_pc.Visible = True
            'Alunecare
            .Label_g1.Visible = True
            .Label_g2.Visible = True
            .Label_g3.Visible = True
            .Label_g4.Visible = True
            .Label_vl.Visible = True
            .Label_vl2.Visible = True
            'Rasturnare
            .Label_ms.Visible = True
            .Label_mr.Visible = True
            .Label_vr.Visible = True
            .Label_ms2.Visible = True
            .Label_mr2.Visible = True
            .Label_vr2.Visible = True
            'Presiuni
            .Label_pmax.Visible = True
            .Label_pmin.Visible = True
            .Label_pmax2.Visible = True
            .Label_pmin2.Visible = True
        End With

    End Sub
    Sub ipoteze_nu()
        With Tema1
            .Label8.Visible = False
            .Label9.Visible = False
            .Label10.Visible = False
            .Label11.Visible = False
            .Label12.Visible = False
            .Label13.Visible = False
            .Label14.Visible = False
            .Label15.Visible = False
        End With
    End Sub

End Module
