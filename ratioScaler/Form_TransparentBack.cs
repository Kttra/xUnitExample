using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ratioScaler
{
    public partial class Form_TransparentBack : Form
    {
        Rectangle rect; //Instance of rectangle
        public Rectangle returnRect { get; set; } //Return rectangle
        private Point LocationXY; //For starting location
        private Point LocationX1Y1; //For ending location
        bool isMouseDown = false; //Becomes true when left click is pressed
        public Form_TransparentBack()
        {
            InitializeComponent();

            //Make the form transparent
            BackColor = Color.Lime;
            TransparencyKey = Color.Lime;

            //Set the form image to be a screenshot of the background
            CreateTransparentForm();

            //Make the border transparent
            FormBorderStyle = FormBorderStyle.None;

            //Prevent the screen from flickering while drawing the rectangle
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
        }
        //Screenshots the desktop
        private async void CreateTransparentForm()
        {
            //Need to pause so form1 can hide in time for slower devices
            await Task.Delay(1);

            //Creating a new Bitmap object
            Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            //Creating a Rectangle object which will capture our screen
            Rectangle captureRectangle = Screen.AllScreens[0].Bounds;

            //Creating a New Graphics Object
            using (Graphics g = Graphics.FromImage(bmp))
            {
                //Copying Image from The Screen
                g.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);
            }

            //Set the form to be the desktop background
            this.BackgroundImage = bmp;
        }
        //Start of the drawing, left click is pressed
        private void Form_TransparentBack_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true; //Left click is pressed
            LocationXY = e.Location; //Starting location of X & Y
        }
        //While left click is held and the mouse if moved
        private void Form_TransparentBack_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                LocationX1Y1 = e.Location; //Get the real time location of X & Y
                Refresh(); //Refresh the form
            }
        }
        //Left click is released, this will be our final coordinates
        private void Form_TransparentBack_MouseUp(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                LocationX1Y1 = e.Location; //Get the final location of X & Y
                isMouseDown = false; //Set back to false
            }
        }
        //Draw the rectangle
        private void Form_TransparentBack_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.Red, GetRect());
        }
        //Get the rectangle dimensions based on mouse location
        private Rectangle GetRect()
        {
            rect = new Rectangle(); //Create rectangle, defined rect at top
            rect.X = Math.Min(LocationXY.X, LocationX1Y1.X); //The x-values of our rectangle
            rect.Y = Math.Min(LocationXY.Y, LocationX1Y1.Y); //The y-values of our rectangle

            rect.Width = Math.Abs(LocationXY.X - LocationX1Y1.X); //Width of our rectangle
            rect.Height = Math.Abs(LocationXY.Y - LocationX1Y1.Y); //Height of our rectangle

            return rect;
        }
        //Key presses
        private void Form_TransparentBack_KeyDown(object sender, KeyEventArgs e)
        {
            //Successfully close if any other key other than escape is pressed
            if (e.KeyCode != Keys.Escape)
            {
                returnRect = rect;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            //Just close if esc is pressed
            this.Close();
        }
    }
}
