using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class CustomControl1 : TextBox
    {
        private DateTimePicker pick;
        public CustomControl1()
        {
            InitializeComponent();
            pick = new DateTimePicker();
            GotFocus += CustomControl3_GotFocus;
            LostFocus += CustomControl3_LostFocus;
            pick.LostFocus += Pick_LostFocus;
            pick.ValueChanged += Pick_ValueChanged;
            KeyDown += CustomControl3_KeyDown;
            KeyPress += CustomControl3_KeyPress;
        }
        private void CustomControl3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control & e.KeyCode == Keys.Back)
            {
                e.Handled = true;
                SendKeys.SendWait("^+{LEFT}{BACKSPACE}");
            }
            if (e.Control && e.KeyCode == Keys.A)
            {
                ((TextBox)sender).SelectAll();
            }
            if (e.KeyCode == Keys.Escape)
                Clear();
        }
        private void CustomControl3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void Pick_ValueChanged(object sender, EventArgs e)
        {
            Text = pick.Value.ToShortDateString();
        }
        private void Pick_LostFocus(object sender, EventArgs e)
        {
            if (!Focused)
                pick.Hide();
        }
        private void CustomControl3_LostFocus(object sender, EventArgs e)
        {
            if (!pick.Focused)
                pick.Hide();
        }
        private void CustomControl3_GotFocus(object sender, EventArgs e)
        {
            if (Parent.Parent == null)
            {
                Parent.Controls.Add(pick);
                pick.Left = Left;
                pick.Top = Top + Height;
                if (Parent.Bottom < pick.Bottom)
                {
                    pick.Top = Top - pick.Height;
                }
                pick.Show();
                Parent.Controls.SetChildIndex(pick, 0);
                return;
            }
            Parent.Parent.Controls.Add(pick);
            pick.Left = Left + Parent.Left;
            pick.Top = Top + Height + Parent.Top;
            if (Parent.Parent.Bottom < pick.Bottom)
            {
                pick.Top = Parent.Top + Top - pick.Height;
            }
            pick.Show();
            Parent.Parent.Controls.SetChildIndex(pick, 0);
        }
    }
}
