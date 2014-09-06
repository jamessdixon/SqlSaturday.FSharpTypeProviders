namespace Tff.WinForms

open System.Drawing
open System.Windows.Forms

type ShowForm() =
    member this.SayHello() =
        let form = new Form(Width = 400, Height = 100)
        let font = new Font("Times New Roman", 28.0f)
        let label = new Label(Dock=DockStyle.Fill, Font=font,
                                TextAlign=ContentAlignment.MiddleCenter,
                                Text="Hello Sql Saturday!")
 
        do form.Controls.Add(label)
        form.Show()
    