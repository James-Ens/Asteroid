using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Input;
using CMPE2800_AsteROID.Contoller;
using CMPE2800_AsteROID.Models;
using System.Threading;
using System.Diagnostics;
using System.Timers;

namespace CMPE2800_AsteROID
{
    public partial class AsteROID : Form
    {
        InputInterface i = new InputInterface(); //Input class
        GameController gc = new GameController(); //Game controller class
        public AsteROID()
        {
            InitializeComponent();
        }

        private void AsteROID_Load(object sender, EventArgs e)
        {
            //Hide panels for displaying later and center align them
            UI_P_PausedPanel.Hide();
            UI_P_PausedPanel.Location = new Point(ClientSize.Width / 2 - UI_P_PausedPanel.Width / 2,
                                                    ClientSize.Height / 2 - UI_P_PausedPanel.Height * 2);
            UI_P_GameOverPanel.Hide();
            UI_P_GameOverPanel.Location = new Point(ClientSize.Width / 2 - UI_P_GameOverPanel.Width / 2,
                                        ClientSize.Height / 2 - UI_P_GameOverPanel.Height * 2);
            UI_P_NextLevel.Hide();
            UI_P_NextLevel.Location = new Point(ClientSize.Width / 2 - UI_P_NextLevel.Width / 2,
                                        ClientSize.Height / 2 - UI_P_NextLevel.Height * 2);
            gc.StartGame(ClientSize);
        }
        /// <summary>
        /// Main game timer event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UI_T_Timer_Tick(object sender, EventArgs e)
        {
            //Game over start thread to wait for input
            if (gc.GameOver && gc.GameStarted)
            {
                //Show game over screen
                UI_P_GameOverPanel.Show();
                UI_B_Start.Focus();
                //Start a new game
                if (i._start)
                {
                    gc.Rocks = new List<SpaceRock>();
                    gc.StartGame(ClientSize);
                    gc.GameOver = false;
                    gc.GameStarted = false;
                    UI_P_GameOverPanel.Hide();
                    gc.Level = 1;
                    gc.Score = 0;
                    gc.Lives = 3;
                    UI_P_StartPanel.Show();
                    
                }
                //Wait for new game to start
                else
                {
                    return;
                }
            }
            //Start from controller
            if(i._x && !gc.GameStarted)
            {
                UI_P_StartPanel.Hide();
                NextLevel();
                Focus();
                gc.GameStarted = true;
            }
            //Paused state
            if (i._pause && gc.GameStarted)
            {
                UI_P_PausedPanel.Show();
            }
            else
            {
                UI_P_PausedPanel.Hide();
                using (BufferedGraphicsContext bgc = new BufferedGraphicsContext())
                {
                    using (BufferedGraphics bg = bgc.Allocate(CreateGraphics(), ClientRectangle))
                    {
                        //Clear the back buffer
                        bg.Graphics.Clear(Color.Black);

                        //No more rocks start next level
                        if (gc.Rocks.Count == 0)
                        {
                            gc.NextLevel(ClientSize);
                            NextLevel();
                        }
                        //Draw all the shapes
                        foreach (SpaceRock SpaceRock in gc.Rocks)
                        {
                            SpaceRock.Tick(ClientSize);
                            SpaceRock.Render(bg, Color.FromArgb(SpaceRock.Fade, Color.SaddleBrown));
                        }
                        foreach (Bullet bullet in gc.Bullets)
                        {
                            bullet.MoveBullet(ClientSize, gc.S);
                            bullet.Render(bg, Color.HotPink);
                        }
                        gc.S.Render(bg, Color.Red);
                        //Check for bullet hits and if the ship is hit
                        if (gc.GameStarted)
                        {
                            //Move the Ship
                            gc.S.MoveShip(i);
                            //Shooting for controller
                            if (i._up)
                            {
                                gc.Shooting();
                                i._up = false;
                            }
                            gc.Collision(bg.Graphics);
                            //Display Score and lives left
                            Font font = new Font(FontFamily.GenericSansSerif, 16, FontStyle.Bold);
                            Font f = new Font("Moire", 24);
                            string text = string.Format("Score - {0}\nLives - {1}", gc.Score, gc.Lives);
                            bg.Graphics.DrawString(text, font, new SolidBrush(Color.White), 5, 5);
                        }
                        bg.Render();
                    }
                }
            }       
        }
        /// <summary>
        /// Key down event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AsteROID_KeyDown(object sender, KeyEventArgs e)
        {
            //Pass to input class to handle
            i.keyPressed(e, true);
        }
        private void AsteROID_KeyUp(object sender, KeyEventArgs e)
        {
            i.keyPressed(e, false);
        }
        /// <summary>
        /// Exit the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UI_B_Exit_Click(object sender, EventArgs e)
        {
            Close();
            Application.Exit();          
        }
        /// <summary>
        /// Start the game and hide instructions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UI_B_Start_Click(object sender, EventArgs e)
        {
            UI_P_StartPanel.Hide();
            NextLevel();
            Focus();
            gc.GameStarted = true;
        }        /// <summary>
                 /// Start the game and hide instructions
                 /// </summary>
                 /// <param name="sender"></param>
                 /// <param name="e"></param>
        private void UI_B_Start_Click()
        {
            UI_P_StartPanel.Hide();
            NextLevel();
            Focus();
            gc.GameStarted = true;
        }
        /// <summary>
        /// Asynchronous method to pause for 500ms in between levels without blocking
        /// </summary>
        private async void NextLevel()
        {
            UI_LB_Level.Text = "Level " + gc.Level;
            UI_P_NextLevel.Show();
            //Wait 500ms
            await Task.Delay(500);
            UI_P_NextLevel.Hide();
        }
    }
}
