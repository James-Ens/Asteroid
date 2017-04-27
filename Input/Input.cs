using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Input
{
    public class InputInterface
    {
        public volatile bool _up;
        public volatile bool _down;
        public volatile bool _right;
        public volatile bool _left;
        public volatile bool _pause;
        public volatile bool _start;
        public volatile bool _x;
        private bool _pastPause;
        private bool _controllerConnected;
        private Thread t;
        private GamePadState oldState;
        public InputInterface()
        {
            t = new Thread(GetInput);
            t.Start();
        }
        /// <summary>
        /// Assign bools based off of key pressed
        /// </summary>
        /// <param name="e"></param>
        /// <param name="pressed"></param>
        public void keyPressed(KeyEventArgs e, bool pressed)
        {
            if (_controllerConnected)
                return;
            if (e.KeyCode == System.Windows.Forms.Keys.Up)
                _up = pressed;
            if (e.KeyCode == System.Windows.Forms.Keys.Down)
                _down = pressed;
            if (e.KeyCode == System.Windows.Forms.Keys.Left)
                _left = pressed;
            if (e.KeyCode == System.Windows.Forms.Keys.Right)
                _right = pressed;
            if (e.KeyCode == System.Windows.Forms.Keys.A)
                _start = pressed;
            //Update pause only on key up of P key
            if (e.KeyCode == System.Windows.Forms.Keys.P && !pressed )
            {
                _pause = !_pause;
                
            }
            ////Pressing and releasing any other key will unpause
            //if (!pressed && _pause)
            //{
            //    _pause = false;
            //}
            _pastPause = _pause;

        }
        /// <summary>
        /// Get controller input thread
        /// </summary>
        private void GetInput()
        {
            // attempt to get the state of controller #1
            GamePadState gps = GamePad.GetState(PlayerIndex.One);
            Console.WriteLine(gps);
            GamePadState previousGamePadState = GamePad.GetState(PlayerIndex.One);
            while (true)
            {


                if (GamePad.GetState(PlayerIndex.One).IsConnected)
                {
                    _controllerConnected = true;
                    if (GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.DPadUp) && oldState.IsButtonUp(Buttons.DPadUp))
                    {
                        _up = !_up;
                    }
                    _down = GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.DPadDown);
                    _left = GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.DPadLeft);
                    _right = GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.DPadRight);
                    _start = GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.A);
                    _x = GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.X);
                    //Pause is pressed
                    if (GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.Start) && oldState.IsButtonUp(Buttons.Start))
                    {
                        _pause = !_pause;
                    }
                    oldState = GamePad.GetState(PlayerIndex.One);
                }
                _controllerConnected = false;
                Thread.Sleep(60);
            }
        }

    }

}
