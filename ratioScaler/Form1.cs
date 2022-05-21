using System;
using System.Windows.Forms;

/*  Ratio Calculator/Scaler

    The purpose of this program is to simulate a ratio calculator.
    A ratio calculator takes two ratios and scales both sides so that
    their ratios are equal.

    Values will be rounded for better viewing. This program was primarily made
    for scaling pictures.

    When the realtime checkbox is checked, the program will update the ratios
    while getting input. This can be disabled by manually unchecking the checkbox
    or pressing enter in one of the textboxes.

    Realtime update will priortize based on the ratios updated. If the A and B fields
    are filled and C  updated, D will be calculated. If A, B, and D are filled, C will
    be calculated. If B, C, and D are filled, A will be updated and so on.

    The textboxes are setup so that only digits can be typed in; however, this does not
    prevent random characters from being copied and pasted in. We do have a safety measure
    in place though with TryParse. Therefore, the result will end up being 0 if a non-number
    character is pasted in a textbox.

    --------------------Update 5/10/2022 - Get Ratio Feature-------------------------------------
    Added feature where a transparent second form is created, the main form is hidden,
    and the second form takes on the image of the computer screen. The user can the snip an image.
    Pressing esc will exit the second form. Pressing any other key afterwards will result in
    the first two textboxes taking on the ratio of the rectangle that the user has created.
*/

namespace ratioScaler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //--------Event Key Handlers, only allows numbers to be typed (Copy and paste still allowed though)-------------
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        //-----------------------------------Button Presses------------------------------------------
        //When Calc button is pressed, calculate the ratios
        private void ButtonCalc_Click(object sender, EventArgs e)
        {
            CalcRatios();
        }
        //Clear all the textboxes
        private void ButtonClr_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
        //Calculates whatever textbox is empty, priority is textbox 4>3>2>1
        private void CalcRatios()
        {
            //If the 4th textbox is the only empty one
            if (!String.IsNullOrEmpty(textBox1.Text) && !String.IsNullOrEmpty(textBox2.Text) && !String.IsNullOrEmpty(textBox3.Text))
            {
                double.TryParse(textBox1.Text, out double A);
                double.TryParse(textBox2.Text, out double B);
                double.TryParse(textBox3.Text, out double C);

                double D = C * (B / A);
                textBox4.Text = "" + Math.Round(D);
            }
            //If the 3rd textbox is the only empty one
            else if (!String.IsNullOrEmpty(textBox1.Text) && !String.IsNullOrEmpty(textBox2.Text) && !String.IsNullOrEmpty(textBox4.Text))
            {
                double.TryParse(textBox1.Text, out double A);
                double.TryParse(textBox2.Text, out double B);
                double.TryParse(textBox4.Text, out double D);

                double C = D*(A/B);
                textBox3.Text = "" + Math.Round(C);
            }
            //If the 2nd textbox is the only empty one
            else if (!String.IsNullOrEmpty(textBox1.Text) && !String.IsNullOrEmpty(textBox3.Text) && !String.IsNullOrEmpty(textBox4.Text))
            {
                double.TryParse(textBox1.Text, out double A);
                double.TryParse(textBox3.Text, out double C);
                double.TryParse(textBox4.Text, out double D);

                double B = D*(A/C);
                textBox2.Text = "" + Math.Round(B);
            }
            //If the 1st textbox is the only empty one
            else if (!String.IsNullOrEmpty(textBox2.Text) && !String.IsNullOrEmpty(textBox3.Text) && !String.IsNullOrEmpty(textBox4.Text))
            {
                double.TryParse(textBox3.Text, out double C);
                double.TryParse(textBox2.Text, out double B);
                double.TryParse(textBox4.Text, out double D);

                double A = B * (C / D);
                textBox1.Text = "" + Math.Round(A);
            }
        }
        //----------------------------------After a number is typed (Real time checked)------------------------------------
        //Update textbox 3 when input is typed in textbox 4
        private void textBox4_KeyUp(object sender, KeyEventArgs e)
        {
            //Update textbox3/C when textbox 4 value is inputted and the other textboxes have values too
            if (!String.IsNullOrEmpty(textBox1.Text) && !String.IsNullOrEmpty(textBox2.Text) &&
                !String.IsNullOrEmpty(textBox4.Text) && checkBox1.Checked)
            {
                double.TryParse(textBox1.Text, out double A);
                double.TryParse(textBox2.Text, out double B);
                double.TryParse(textBox4.Text, out double D);

                double C = D * (A / B);
                textBox3.Text = "" + Math.Round(C);
            }
        }
        //Update textbox 4 when textbox 3 is given input
        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox1.Text) && !String.IsNullOrEmpty(textBox2.Text) &&
                !String.IsNullOrEmpty(textBox3.Text) && checkBox1.Checked)
            {
                double.TryParse(textBox1.Text, out double A);
                double.TryParse(textBox2.Text, out double B);
                double.TryParse(textBox3.Text, out double C);

                double D = C * (B / A);
                textBox4.Text = "" + Math.Round(D);
            }
        }
        //Update textbox 1 when textbox 2 is given input
        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox2.Text) && !String.IsNullOrEmpty(textBox3.Text) &&
                !String.IsNullOrEmpty(textBox4.Text) && checkBox1.Checked)
            {
                double.TryParse(textBox3.Text, out double C);
                double.TryParse(textBox2.Text, out double B);
                double.TryParse(textBox4.Text, out double D);

                double A = B * (C / D);
                textBox1.Text = "" + Math.Round(A);
            }
        }
        //Update textbox 2 when textbox 1 is given input
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox1.Text) && !String.IsNullOrEmpty(textBox3.Text) &&
                !String.IsNullOrEmpty(textBox4.Text) && checkBox1.Checked)
            {
                double.TryParse(textBox1.Text, out double A);
                double.TryParse(textBox3.Text, out double C);
                double.TryParse(textBox4.Text, out double D);

                double B = D * (A / C);
                textBox2.Text = "" + Math.Round(B);
            }
        }
        //---------------------When enter is pressed - Check/Uncheck Realtime-------------------------------------
        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                checkBox1.Checked = !checkBox1.Checked;
            }
        }
        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                checkBox1.Checked = !checkBox1.Checked;
            }
        }
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                checkBox1.Checked = !checkBox1.Checked;
            }
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                checkBox1.Checked = !checkBox1.Checked;
            }
        }
        //Create a transparent form so we can snip a section to get the ratio
        private void BtnRatio_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_TransparentBack form = new Form_TransparentBack();
            var result = form.ShowDialog();
            this.Show();
            
            //Ok returned from form, update ratios and calculate
            if (result == DialogResult.OK)
            {
                //If both width and height are 0, no point in updating
                if (form.returnRect.Width != 0 && form.returnRect.Height != 0)
                {
                    textBox1.Text = form.returnRect.Width.ToString();
                    textBox2.Text = form.returnRect.Height.ToString();
                    CalcRatios();
                }
            }
        }
        public static int addNum(int num1, int num2)
        {
            return num1 + num2;
        }
    }
}
