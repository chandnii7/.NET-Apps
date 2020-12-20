using System ;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace FloodIt
{
    public partial class Form1 : Form
    {
        public const int YELLOW = 0;
        public const int BLUE = 1;
        public const int RED = 2;
        public const int GREEN = 3;
        public const int PURPLE = 4;
        public const int PINK = 5;

        const int SQUARE_SIZE = 30;
        const int BOARD_SIZE = 14;
        const int NUM_COLORS = 6;
        const int MAX_TURNS = 25;

        int turns = 0;
        int oldColor;
        int newColor;

        Square[,] board = new Square[BOARD_SIZE, BOARD_SIZE]; //the board
        
        Brush[] brushes = new Brush[NUM_COLORS]; //look up table of brushes

        Random r = new Random();
        
        struct Square
        {
            public int x, y, color;
            public bool marked;
        }

        List<Point> fillQueue = new List<Point>();

        public Form1()
        {
            InitializeComponent();

            //build a lookup table of Brushes
            brushes[YELLOW] = Brushes.Yellow;
            brushes[RED] = Brushes.Red;
            brushes[BLUE] = Brushes.Blue;
            brushes[PINK] = Brushes.Pink;
            brushes[GREEN] = Brushes.Lime;
            brushes[PURPLE] = Brushes.Purple;

            Reset();
        }


        void Reset()
        {
            //TODO complete the reset function
            //when it works, you should have a multicolored board

            //set turns to 0
            turns = 0;

            //set the color property of each cell in board[,]
            //to a random number between 0 and NUM_COLORS
            //See the Draw() function for a hint on how you
            //could do this with nested loops.
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    board[i, j].color = r.Next(0, NUM_COLORS);
                }
            }
        }

        void Draw()
        {
            pictureBox1.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            DrawBoard(e.Graphics);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Fill(YELLOW);   
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Fill(BLUE);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Fill(RED);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Fill(PURPLE);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Fill(PINK);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Fill(GREEN);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Application.Exit();
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reset();
            pictureBox1.Invalidate();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
 
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        public void ClearMarks()
        {
            //TODO set all marked flags to false
            //Set the marked flag of every square in the board to false
            //you could use nested for loops or a foreach loop
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    board[i, j].marked = false;
                }
            }
        }


        void Fill(int color)
        {
            //remove marks from previous fills
            ClearMarks();

            //save the original color of square 0,0
            oldColor = board[0, 0].color;
            
            //save the new color to bucket fill with
            newColor = color;

            if (newColor == oldColor)
                return;

            if (turns < 30)
            {
                turns++;
                textBox1.Text = "" + turns + "/30";

                //put the top left square in the queue       
                Enqueue(0,0);

                timer1.Start();
            }
            else
            {
                MessageBox.Show("You Lost!");
            }
        }

        public bool IsFilled()
        {
            //TODO return true if the board is filled
            //Use a foreach loop (or nested for loop) to compare the 
            //color of every square in the board to the color of the 
            //square at 0,0.  If you find one that's not equal, return
            //false.
            //After the loop(s) return true
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    if (board[i, j].color != board[0, 0].color)
                        return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Puts the square x,y in the queue if it is
        /// in bounds, unmarked, and its color is the old color
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        void Enqueue(int x, int y)
        {
            //TODO put a x,y into the queue
            //if x,y is within the board's boundries AND
            //the square board[x,y]'s color is the old color AND
            //the square board[x,y]'s marked flag is false...
            //      set board[x,y]'s marked flag to true
            //      Make a new Point using x,y
            //      Put that point in the list using the list's Add() function
            if (x >= 0 && x < BOARD_SIZE && y >= 0 && y < BOARD_SIZE)
            {
                if (board[x,y].color == oldColor && board[x,y].marked == false)
                {
                    board[x, y].marked = true;
                    fillQueue.Add(new Point(x, y));
                }
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            //TODO -perform the bucket fills
            //See the flowchart in the PDF
            
            if(fillQueue.Count == 0)
            {//empty
                timer1.Stop();
                if (IsFilled())
                {
                    MessageBox.Show("You Won!");
                }                
            }
            else
            {//do the BFS algorithm
                Point p = fillQueue.First(); //get 1st thing
                fillQueue.RemoveAt(0);

                board[p.X, p.Y].color = newColor; //bucket fill it!

                Enqueue(p.X, p.Y + 1);
                Enqueue(p.X, p.Y - 1);
                Enqueue(p.X + 1, p.Y);
                Enqueue(p.X - 1, p.Y);

                pictureBox1.Invalidate(); //paints again
            }
        }

        public void DrawBoard(Graphics g)
        {
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    int color = board[i, j].color; //get square's color
                    Brush brush = brushes[color]; //lookup brush
                    g.FillRectangle(brush, i * SQUARE_SIZE, j * SQUARE_SIZE, SQUARE_SIZE, SQUARE_SIZE); //fill square
                }
            }
        }

        void PlayAgain()
        {
            //TODO ask the player to play again.
            //see the PDF for code 
        }
    }
}
