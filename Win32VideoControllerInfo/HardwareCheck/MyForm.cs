using System.Drawing;
using System.Windows.Forms;

namespace HardwareCheck
{
  public class MyForm : Form
  {
    public MyForm(string text, string caption)
    {
      Width = 1200;
      Height = 180;
      FormBorderStyle = FormBorderStyle.None;
      Text = caption;
      ControlBox = false;
      BackColor = Color.White;
      TransparencyKey = Color.White;
      StartPosition = FormStartPosition.CenterScreen;

      var textLabel = new Label()
      {
        Width = this.Width,
        Height = this.Height,
        Text = text,
        AutoSize = false,
        TextAlign = ContentAlignment.MiddleCenter,
        Font = new Font(
          FontFamily.GenericSansSerif,
          30,
          FontStyle.Bold),
        ForeColor = Color.WhiteSmoke,
        FlatStyle = FlatStyle.Flat,
        BorderStyle = BorderStyle.None,
        Dock = DockStyle.Fill
      };
      Controls.Add(textLabel);
    }
  }
}