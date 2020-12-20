using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlidingPuzzle
{
    public partial class Form1 : Form
    {
        const int BOARD_SIZE = 4;
        const int TILE_SIZE = 100;
        const int EMPTY = 0;

        int[,] board = new int[BOARD_SIZE, BOARD_SIZE];
        Image[] images = new Image[BOARD_SIZE * BOARD_SIZE];
        Point mouseDown, mouseUp; //don't need new operator as it's a structure (value type)
        Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
            //load the 16 tiles
            for (int i = 0; i < BOARD_SIZE*BOARD_SIZE; i++)
            {
                //type cast as bit value was returned from right
                images[i] = (Image) Properties.Resources.ResourceManager.GetObject("Tile" + i);
            }
            //fill up the board
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    board[i,j] = j * BOARD_SIZE + i;
                }
            }
            //shuffle it
            ScrambleBoard();
        }

        /// <summary>
        /// Scrambles the board by switiching random cells 1000 times
        /// </summary>
        void ScrambleBoard()
        {
            for (int i = 0; i < 1000; i++)
            {
                int x1 = rand.Next(BOARD_SIZE);
                int x2 = rand.Next(BOARD_SIZE);
                int y1 = rand.Next(BOARD_SIZE);
                int y2 = rand.Next(BOARD_SIZE);
                int temp = board[x1, y1]; //save coord1
                board[x1, y1] = board[x2, y2]; //copy 2nd coord into 1st
                board[x2, y2] = temp; //copy temp(1st) coord into 2nd
            }
        }

        bool IsValidMove()
        {
            try
            {
                int dx = Math.Abs(mouseDown.X - mouseUp.X);
                int dy = Math.Abs(mouseDown.Y - mouseUp.Y);

                if (board[mouseUp.X, mouseUp.Y] == EMPTY)
                {
                    if ((dx == 0 && dy == 1) || (dx == 1 && dy == 0))
                        return true;
                }                
            }
            catch { }
            return false;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            //0,1,2,3 ==> scale down to grid
            mouseDown.X = e.X / TILE_SIZE;
            mouseDown.Y = e.Y / TILE_SIZE;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            //0,1,2,3 ==> convert 350 to 3
            mouseUp.X = e.X / TILE_SIZE;
            mouseUp.Y = e.Y / TILE_SIZE;

            if (IsValidMove())
            {
                int temp = board[mouseDown.X,mouseDown.Y]; //save coord1
                board[mouseDown.X, mouseDown.Y] = board[mouseUp.X, mouseUp.Y]; //copy 2nd coord into 1st
                board[mouseUp.X, mouseUp.Y] = temp; //copy temp(1st) coord into 2nd
            }

            pictureBox1.Invalidate();
        }

        //display tiles on the picture box
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    int tile = board[i, j]; //get the tile number
                    Image img = images[tile];

                    //convert i,j from array coordinates to screen coordinates
                    e.Graphics.DrawImage(img, i * TILE_SIZE, j * TILE_SIZE);
                }
            }
        }
    }
}
