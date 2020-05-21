using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper_3._0
{
    public partial class Form1 : Form
    {


        //THIS IS THE ZONE FOR DOING REGULAR THINGS. MOST STUFF GOES HERE 
        //###################################################################################

        public int[,] NumberArray;
        public bool[,] IsFlagged;
        public bool[,] IsSelected;

        //amount of squares on a side of the grid
        public int dimension = 10;
        

        public Form1()
        {
            InitializeComponent();
            //data = new bool[dimension, dimension];

            NumberArray = new int[dimension, dimension];
            IsFlagged = new bool[dimension, dimension];
            IsSelected = new bool[dimension, dimension];

            InitialPopulate();
            Flags = FlagCount;
            lblFlagCount.Text = Convert.ToString(Flags);

            timer1.Start();
        }

        public void InitialPopulate()
        {
            //enters default values for the number array
            for(int ii = 0; ii > NumberArray.GetLength(0); ii++)
            {
                for(int jj = 0; jj > NumberArray.GetLength(1); jj++)
                {
                    NumberArray[ii, jj] = 0;
                }
            }

            //enter default values for the IsSelected array
            for(int ii = 0; ii > IsSelected.GetLength(0); ii++)
            {
                for (int jj = 0; jj > IsSelected.GetLength(1); jj++)
                {
                    IsSelected[ii, jj] = false;
                }
            }

            //enters default values for the IsFlagged array
            for(int ii = 0; ii > IsFlagged.GetLength(0); ii++)
            {
                for (int jj = 0; jj > IsFlagged.GetLength(1); jj++)
                {
                    IsFlagged[ii, jj] = false;
                }
            }

        }

        //pretty self explanitory
        public void FirstClick(int Xvalue, int Yvalue)
        {
            BombPopulate(Xvalue, Yvalue);
            NumberPopulate();

        }

















        //THIS IS THE ZONE FOR DOING GRAPHICS THINGS
        //##############################################################################


        //OLD CRAP

        //making the array
        //public bool[,] data;




        /*
        public int CellWidth
        {
            get
            {
                int w = canvas.Width;
                int dim = data.GetLength(0);
                int width = w / dim;
                return width;
            }
        }
        */

        /*
    //draws the grid
    public void DrawGrid(PaintEventArgs e)
    {
        SolidBrush brushInactive = new SolidBrush(Color.Black);
        SolidBrush brushActive = new SolidBrush(activecolor);
        SolidBrush currentBrush;
        int margin = 1;
        for (int ii = 0; ii < data.GetLength(1); ii++)
        {
            for (int jj = 0; jj < data.GetLength(0); jj++)
            {
                int x = jj * CellWidth + margin;
                int y = ii * CellWidth + margin;
                int w = CellWidth - margin * 2;
                if (data[ii, jj])
                {
                    currentBrush = brushActive;
                }
                else
                {
                    currentBrush = brushInactive;
                }
                e.Graphics.FillRectangle(currentBrush, new Rectangle(x, y, w, w));
            }
        }
    }
    */
        /*
        private int calcCellPosition(int loc)
        {
            return (int)((double)loc / CellWidth);
        }

        private void UpdateGUI()
        {
            canvas.Refresh();
        }      

        private void canvas_MouseClick(object sender, MouseEventArgs e)
        {            
            int r = calcCellPosition(e.Location.Y);
            int c = calcCellPosition(e.Location.X);
            data[r, c] = !data[r, c];
            UpdateGUI();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            DrawGrid(e);
        }





        //This makes the active squares into party mode
        Color activecolor = new Color();
        Random rnd = new Random();
        private void timer1_Tick(object sender, EventArgs e)
        {
            activecolor = Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256));

            UpdateGUI();
        }

        */







        //NEW CRAP

        
        public int CellWidth
        {
            get
            {
                int w = canvas.Width;
                int dim = NumberArray.GetLength(0);
                int width = w / dim;
                return width;
            }
        }
        
        
        //draws the grid
        public void DrawGrid(PaintEventArgs e)
    {
        
        
        SolidBrush currentBrush;
        int margin = 1;
        for (int ii = 0; ii < NumberArray.GetLength(1); ii++)
        {
            for (int jj = 0; jj < NumberArray.GetLength(0); jj++)
            {
                int x = jj * CellWidth + margin;
                int y = ii * CellWidth + margin;
                int w = CellWidth - margin * 2;


                    Color SelectedColor; 
                    

                    if(IsSelected[ii,jj] == false)
                    {
                        SelectedColor = Color.Green;
                    }
                    else
                    {
                      SelectedColor = SelectaColor(NumberArray[ii, jj]);
                    }

                    
                    SolidBrush brushInactive = new SolidBrush(SelectedColor);
                    currentBrush = brushInactive;

                    //e.Graphics.FillRectangle(currentBrush, new Rectangle(x, y, w, w));

                    Image SelectedImage;
                    if(IsSelected[ii,jj] == false)
                    {
                        if(IsFlagged[ii, jj] == true)
                        {
                            SelectedImage = Properties.Resources.MinesweeperGrassFlagged;
                        }
                        else
                        {
                            SelectedImage = Properties.Resources.MinesweeperGrass;
                        }
                        
                    }
                    else
                    {
                        SelectedImage = SelectanImage(NumberArray[ii, jj]);
                    }

                    e.Graphics.DrawImage(SelectedImage, x, y, w, w);
            }
        }
    }

        //gets the color
        public Color SelectaColor(int value)
        {
            if(value == 0)
            {
                return Color.Beige;
            }
            else if(value == 1)
            {
                return Color.Blue;
            }
            else if (value == 2)
            {
                return Color.LightGreen;
            }
            else if (value == 3)
            {
                return Color.Red;
            }
            else if (value == 4)
            {
                return Color.Purple;
            }
            else if (value == 5)
            {
                return Color.Maroon;
            }
            else if (value == 6)
            {
                return Color.Turquoise;
            }
            else if (value == 7)
            {
                return Color.Brown;
            }
            else if (value == 8)
            {
                return Color.Gray;
            }
            else if (value == 9)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }


        }

        public Image SelectanImage(int value)
        {
            if (value == 0)
            {
                return Properties.Resources.MinesweeperStoneBlank;
            }
            else if (value == 1)
            {
                return Properties.Resources.MinesweeperStone1;
            }
            else if (value == 2)
            {
                return Properties.Resources.MinesweeperStone2;
            }
            else if (value == 3)
            {
                return Properties.Resources.MinesweeperStone3;
            }
            else if (value == 4)
            {
                return Properties.Resources.MinesweeperStone4;
            }
            else if (value == 5)
            {
                return Properties.Resources.MinesweeperStone5;
            }
            else if (value == 6)
            {
                return Properties.Resources.MinesweeperStone6;
            }
            else if (value == 7)
            {
                return Properties.Resources.MinesweeperStone7;
            }
            else if (value == 8)
            {
                return Properties.Resources.MinesweeperStone8;
            }
            else if (value == 9)
            {
                return Properties.Resources.MinesweeperBomb;
            }
            else
            {
                return Properties.Resources.MinesweeperDirt;
            }
        }
        
    
        
        private int calcCellPosition(int loc)
        {
            return (int)((double)loc / CellWidth);
        }

        private void UpdateGUI()
        {
            canvas.Refresh();
        }


        //clicking stuff
        public int LeftClickCount = 0;
        public int RightClickCount = 0;
        //Number of bombs vvv
        public int FlagCount = 30;
        public int Flags;

        public int CorrectFlagCount = 0;
        
        private void canvas_MouseClick(object sender, MouseEventArgs e)
        {

            switch (e.Button)
            {

                //all leftclick events go in here
                case MouseButtons.Left:
                    LeftClickCount += 1;
                    //finds the selected tile
                    int Lr = calcCellPosition(e.Location.Y);
                    int Lc = calcCellPosition(e.Location.X);

                    


                    if (LeftClickCount == 1)
                    {
                        FirstClick(Lr, Lc);
                    }                   

                    //BlankChecker(Lr, Lc);

                    if(NumberArray[Lr, Lc] == 0)
                    {
                        BetterBlankCheck(Lr, Lc);
                    }

                    IsSelected[Lr, Lc] = true;
                                                        

                    UpdateGUI();







                    

                    if (NumberArray[Lr, Lc] == 9)
                    {
                        YouLose();
                    }

                    break;




                    //everything that happens when you rightclick
                case MouseButtons.Right:
                    RightClickCount += 1;
                    

                    int Rr = calcCellPosition(e.Location.Y);
                    int Rc = calcCellPosition(e.Location.X);

                    if(IsSelected[Rr, Rc] == false)
                    {
                        if (IsFlagged[Rr, Rc] == false)
                        {
                            IsFlagged[Rr, Rc] = true;
                            Flags -= 1;
                            if(NumberArray[Rr, Rc] == 9)
                            {
                                CorrectFlagCount += 1;
                            }
                        }
                        else
                        {
                            IsFlagged[Rr, Rc] = false;
                            Flags += 1;
                            if (NumberArray[Rr, Rc] == 9)
                            {
                                CorrectFlagCount -= 1;
                            }
                        }
                    }

                    


                    lblFlagCount.Text = Convert.ToString(Flags);

                    UpdateGUI();

                    if (CorrectFlagCount == FlagCount)
                    {
                        MessageBox.Show("Congrats. You Win.");
                        Application.Exit();
                    }


                    break;

                    



            }



            




        }



        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            DrawGrid(e);
        }
     
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateGUI();
        }

        










        //THIS IS THE ZONE FOR MY ALGORITHMS
        //###############################################################################


        public void BombPopulate(int Xvalue, int Yvalue)
        {
            int bombcounter = FlagCount;
            //Random randX = new Random();
            //Random randY = new Random();
            bool isbombaround = false;
            int Bombaroundcounter = 0;
            while (bombcounter > 0)
            {
                //int RandomX = randX.Next(0, NumberArray.GetLength(0));
                //int RandomY = randY.Next(0, NumberArray.GetLength(1));
                int RandomX = RandomNumber(0, NumberArray.GetLength(0));
                int RandomY = RandomNumber(0, NumberArray.GetLength(0));

                //tests whether there is a bomb in a one tile radius of the selected tile
                for (int ii = 0; ii > 3; ii++)
                {
                    for (int jj = 0; jj > 3; jj++)
                    {
                        //this part prevents out of bounds testing
                        if ((Xvalue - 1 + ii) < NumberArray.GetLength(0) || (Xvalue - 1 + ii) > 0)
                        {
                            if ((Yvalue - 1 + jj) < NumberArray.GetLength(1) || (Yvalue - 1 + jj) > 0)
                            {
                                if (NumberArray[Xvalue - 1 + ii, Yvalue - 1 + jj] == 9)
                                {
                                    isbombaround = true;
                                    Bombaroundcounter += 1;
                                }
                            }
                        }
                    }
                }

                if (NumberArray[RandomX, RandomY] != 9 & isbombaround == false & Bombaroundcounter == 0)
                {
                    NumberArray[RandomX, RandomY] = 9;
                    bombcounter -= 1;
                }

                Bombaroundcounter = 0;

            }
        }

        public int RNG()
        {
            int randomnumber;
            Random random = new Random();
            randomnumber = random.Next(0, NumberArray.GetLength(0));


            return randomnumber;
        }

        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        public static int RandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return random.Next(min, max);
            }
        }


        public void NumberPopulate()
        {
            for (int ii = 0; ii < NumberArray.GetLength(0); ii++)
            {
                for (int jj = 0; jj < NumberArray.GetLength(1); jj++)
                {

                    int BombCount = 0;

                    if (NumberArray[ii, jj] != 9)
                    {
                        for (int aa = 0; aa < 3; aa++)
                        {
                            for (int bb = 0; bb < 3; bb++)
                            {

                                if ((ii - 1 + aa) < NumberArray.GetLength(0) & (ii - 1 + aa) > 0)
                                {
                                    if ((jj - 1 + bb) < NumberArray.GetLength(1) & (jj - 1 + bb) > 0)
                                    {

                                        if (NumberArray[ii - 1 + aa, jj - 1 + bb] == 9)
                                        {
                                            BombCount += 1;
                                        }

                                    }
                                }
                            }
                        }
                    }

                    
                    if(NumberArray[ii,jj] != 9)
                    {
                        NumberArray[ii, jj] = BombCount;
                    }
                    

                    


                }
            }
        }

        public void BlankChecker(int Xvalue, int Yvalue)
        {
            //Tile[] CheckedPositions = { SelcTile };

            List<bool> CheckedPostions = new List<bool>();
            //List<int> XValueList = new List<int>();
            //List<int> YValueList = new List<int>();
            CheckedPostions.Add(IsSelected[Xvalue, Yvalue]);
            //XValueList.Add(Xvalue);
            //YValueList.Add(Yvalue);
            bool IsCheckComplete = false;

            int ListNumber;
            

            while (IsCheckComplete == false)
            {

                foreach (bool p in CheckedPostions)
                {

                    /*
                    for(int ii = 0; ii > IsSelected.Length; ii++)
                    {
                        for(int jj = 0; jj > IsSelected.Length; jj++)
                        {
                            if(IsSelected[ii, jj] == p)
                            {
                                Xvalue = ii;
                                Yvalue = jj;
                            }
                        }
                    }
                    */

                    bool[] OneArray = new bool[IsSelected.GetLength(0) * IsSelected.GetLength(1)];
                    int counter = 0;
                    for(int ii = 0; ii > IsSelected.GetLength(0); ii++)
                    {
                        for(int jj = 0; jj > IsSelected.GetLength(1); jj++)
                        {
                            OneArray[counter] = IsSelected[ii, jj];
                            counter += 1;
                        }
                    }




                    ListNumber = CheckedPostions.IndexOf(p);

                    /*
                    Xvalue = XValueList[ListNumber];
                    Yvalue = YValueList[ListNumber];
                    */

                    if (p == false)
                    {

                        for (int ii = 0; ii > 3; ii++)
                        {
                            for (int jj = 0; jj > 3; jj++)
                            {
                                //this part prevents out of bounds testing
                                if ((Xvalue - 1 + ii) < IsSelected.GetLength(0) || (Xvalue - 1 + ii) >= 0)
                                {
                                    if ((Yvalue - 1 + jj) < IsSelected.GetLength(1) || (Yvalue - 1 + jj) >= 0)
                                    {
                                        if (NumberArray[Xvalue - 1 + ii, Yvalue - 1 + jj] == 0)
                                        {
                                            CheckedPostions.Add(IsSelected[Xvalue - 1 + ii, Yvalue - 1 + jj]);
                                            //XValueList.Add(Xvalue - 1 + ii);
                                            //YValueList.Add(Yvalue - 1 + jj);
                                        }
                                    }
                                }
                            }
                        }

                    }




                }

                int CheckedPositionLength = CheckedPostions.Count;
                int HowManyChecked = 0;
                foreach (bool p in CheckedPostions)
                {
                    if (p == true)
                    {
                        HowManyChecked += 1;
                    }

                }

                if (HowManyChecked == CheckedPositionLength)
                {
                    IsCheckComplete = true;
                }


            }

            /*
            foreach (bool p in CheckedPostions)
            {
                p = true;
            }
            */

            for(int ii = 0; ii > CheckedPostions.Count; ii++)
            {
                CheckedPostions[ii] = true;
            }

            

        }

        public void BetterBlankCheck(int Xvalue, int Yvalue)
        {
           

            if(Xvalue >= 0 && Xvalue < IsSelected.GetLength(0) && Yvalue >= 0 && Yvalue < IsSelected.GetLength(1) && IsSelected[Xvalue, Yvalue] == false)
            {
                if(NumberArray[Xvalue, Yvalue] != 9)
                {
                    IsSelected[Xvalue, Yvalue] = true;

                    BetterBlankCheck(Xvalue + 1, Yvalue);
                    BetterBlankCheck(Xvalue - 1, Yvalue);
                    BetterBlankCheck(Xvalue, Yvalue + 1);
                    BetterBlankCheck(Xvalue, Yvalue - 1);
                    
                }
            }





        }


        public void YouLose()
        {
            MessageBox.Show("You fool.");
            Application.Exit();
        }

        public bool HasWon()
        {

            int counter = 0;
            int total = IsSelected.GetLength(0) * IsSelected.GetLength(1);

            for(int ii = 0; ii > IsSelected.GetLength(0); ii++)
            {
                for(int jj = 0; jj > IsSelected.GetLength(1); jj++)
                {

                    if(NumberArray[ii, jj] != 9)
                    {
                        if(IsSelected[ii, jj] == false)
                        {
                            counter += 1;
                        }
                    }

                }
            }

            if(counter > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
            

        }


    }
}
