using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Simon
{
    //enumerated type 
    public enum ColorCode { RED, GREEN, BLUE, YELLOW, BUZZER};  

    public partial class Form1 : Form
    {
        //list to store the sequence created
        List<ColorCode> sequence = new List<ColorCode>();
        int index = 0;

        //dictionary (collections) to associate to objects (sound effect for color blue, like lookup table)
        Dictionary<ColorCode, SoundPlayer> sounds = new Dictionary<ColorCode, SoundPlayer>();
        Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
            //map of sound effects
            sounds[ColorCode.BLUE] = new SoundPlayer(Properties.Resources.tone_low_a);
            sounds[ColorCode.RED] = new SoundPlayer(Properties.Resources.tone_middle_c);
            sounds[ColorCode.YELLOW] = new SoundPlayer(Properties.Resources.tone_middle_e);
            sounds[ColorCode.GREEN] = new SoundPlayer(Properties.Resources.tone_high_a);
            sounds[ColorCode.BUZZER] = new SoundPlayer(Properties.Resources.tone_buzzer);
        }

        /// <summary>
        /// Puts a random color code in the list
        /// </summary>
        void AddLight()
        {
            int color = rand.Next(4); //for 0 to 3 random numbers
            sequence.Add((ColorCode)color); //adding to list
        }

        /// <summary>
        /// Plays the sound for the color code
        /// </summary>
        void PlaySound(ColorCode c)
        {
            sounds[c].PlaySync();
        }

        /// <summary>
        /// Set image to light on
        /// </summary>
        void TurnLightOn(ColorCode c)
        {
            //when you have no body but it till runs using this
            //throw new NotImplementedException();
            switch (c)
            {
                case ColorCode.GREEN:
                    pictureBox1.Image = Properties.Resources.Simon_Green_On;
                    pictureBox1.Refresh();
                    break;
                case ColorCode.RED:
                    pictureBox2.Image = Properties.Resources.Simon_Red_On;
                    pictureBox2.Refresh();
                    break;
                case ColorCode.BLUE:
                    pictureBox3.Image = Properties.Resources.Simon_Blue_On;
                    pictureBox3.Refresh();
                    break;
                case ColorCode.YELLOW:
                    pictureBox4.Image = Properties.Resources.Simon_Yellow_On;
                    pictureBox4.Refresh();
                    break;
            }
        }

        /// <summary>
        /// Set image to light off
        /// </summary>
        void TurnLightOff(ColorCode c)
        {
            //can use map (like in ColorCode and sounds) instead of long switch statement
            switch (c)
            {
                case ColorCode.GREEN:
                    pictureBox1.Image = Properties.Resources.Simon_Green_Off;
                    pictureBox1.Refresh();
                    break;
                case ColorCode.RED:
                    pictureBox2.Image = Properties.Resources.Simon_Red_Off;
                    pictureBox2.Refresh();
                    break;                
                case ColorCode.BLUE:
                    pictureBox3.Image = Properties.Resources.Simon_Blue_Off;
                    pictureBox3.Refresh();
                    break;
                case ColorCode.YELLOW:
                    pictureBox4.Image = Properties.Resources.Simon_Yellow_Off;
                    pictureBox4.Refresh();
                    break;
            }
        }

        /// <summary>
        /// Function to flash the light or make the light blink
        /// </summary>
        void FlashLight(ColorCode c)
        {
            TurnLightOn(c);
            PlaySound(c);
            TurnLightOff(c);
        }
        
        /// <summary>
        /// Function to loop over the sequence and call FlashLight
        /// </summary>
        void PlaySequence()
        {
            foreach (ColorCode c in sequence)
            {
                FlashLight(c);
                System.Threading.Thread.Sleep(250); //HACK ==> sleeping is not good for program
            }
            index = 0; //player starts over from the beginning
        }

        /// <summary>
        /// To restart from new sequence
        /// </summary>
        void Restart()
        {
            sequence.Clear();
            AddLight();
            PlaySequence();
        }

        /// <summary>
        /// 
        /// </summary>
        void HandleButton(ColorCode c)
        {
            //all have length but only list has count property in c#
            if (sequence.Count == 0)
            {//start a new game
                Restart();
            }
            else
            {
                if (c == sequence[index])
                {//match
                    //PlaySound(c);
                    FlashLight(c);
                    index++; //for next sound/light

                    if(index == sequence.Count)
                    {//hit the END
                        AddLight();
                        System.Threading.Thread.Sleep(500); //HACK ==> should be done with timers
                        PlaySequence();
                        index = 0; //TODO ==> don't need this
                    }
                    else { // do NOTHING!
                    }
                }
                else
                {//WRONG!!!!!
                    PlaySound(ColorCode.BUZZER);
                    Restart();
                }
            }
        }

        // Just to test the code*****
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            HandleButton(ColorCode.GREEN);
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            HandleButton(ColorCode.RED);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            HandleButton(ColorCode.BLUE);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            HandleButton(ColorCode.YELLOW);
        }
    }
}
