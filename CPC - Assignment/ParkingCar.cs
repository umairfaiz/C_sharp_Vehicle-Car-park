using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPC___Assignment
{
    class ParkingCar
    {
        private Point origin;//starting section of each panel
        private int delay;
        private Panel panel;
        private string moving_direc;//gets direction of the car
        private Color color;
        private Point car;
        private int xDelta;
        private int yDelta;
        private Semaphore semaphore;//semaphore for the current panel
        private Semaphore semaphoreNxt;//semaphore for the next panel
        private Buffer buff;//buffer for the current panel
        private Buffer buffNxt;//getting the next buffer available relative to the current location
        private Button rbtn;//radio button to dittermne user slection
        private bool locked = true;
        private int destination;
        private int panelNo;

        public ParkingCar(Point origin, int delay, string moving_direc, Button rbtn, int panelNo, Panel panel,Semaphore semaphore, Semaphore semaphoreNxt, Buffer buff, Buffer buffNxt)
        {
            // Setting of instance variables from the constructor
            this.origin = origin;
            this.delay = delay;
            this.moving_direc = moving_direc;
            this.rbtn = rbtn;
            this.panelNo = panelNo;
            this.panel = panel;
            this.semaphore = semaphore;
            this.semaphoreNxt = semaphoreNxt;
            this.buff = buff;
            this.buffNxt = buffNxt;
            this.car = origin;

            this.panel.Paint += new PaintEventHandler(this.panel_Paint);
            this.rbtn.Click += new System.EventHandler(this.btn_Click);//assigning an event handler when the radio button is selected

            //setting the direction based on the panels and cars moving direction  
            switch (moving_direc)
            {
                //case "north":
                //    this.xDelta = 0;
                //    this.yDelta = -5;
                //    break;

                case "south":
                    this.xDelta = 0;
                    this.yDelta = 5;
                    break;

                case "east":
                    this.xDelta = 5;
                    this.yDelta = 0;
                    break;

                case "west":
                    this.xDelta = -5;
                    this.yDelta = 0;
                    break;

                default:
                    break;
            }
            

        }
        
        private void btn_Click(object sender, System.EventArgs e)
        {
            locked = !locked;

            lock (this)
            {
                if (!locked)
                    Monitor.Pulse(this);
            }
        }
        

        public void Start()
        {
            {
               this.color = Color.FromArgb(0, 12, 12, 12);// panel near Exit A gets the color of the previous of car if not resetted properly
                for (int i = 1; i <= 10; i++)
                {
                    semaphore.Signal();
                    this.zeroCar();

                    buff.Read(ref this.color, ref this.destination);
                  //  buff.ReadDestination(ref this.destination);

                    for (int j = 1; j <= 10; j++)
                    {

                        panel.Invalidate();
                        this.moveCar(xDelta, yDelta);
                        Thread.Sleep(delay);

                    }
                    this.rbtn.BackColor = Color.Red;
                    locked = true;
                    lock (this)
                    {
                        while (locked)
                        {
                            Monitor.Wait(this);

                        }
                    }

                    this.rbtn.BackColor = Color.Green;//color of the car slot buttons after releasing the vehical
                    //this.btn.BackColor = Color.FromArgb(100, 0, 192, 0);
                    int tmpox = this.xDelta;
                    int tmpoy = this.yDelta;
                    this.xDelta = origin.X == -10 ? -5 : 5;
                    this.yDelta = 0;
                    for (int k = 1; k <= 6; k++)
                    {

                        panel.Invalidate();
                        this.moveCar(xDelta, yDelta);
                        Thread.Sleep(delay);

                    }
                    this.xDelta = tmpox;
                    this.yDelta = tmpoy;
                   // buffNxt.Write(color);

                    //if(20=turn west) , if(21 = turn east))
                    switch (panelNo)
                    {
                        case 43:
                        case 44:
                        case 45:
                            this.destination = 20;
                            break;
                        case 46:
                        case 47:
                        case 48:
                            this.destination = 21;
                            break;
                        case 40:
                        case 42:
                        case 50:
                        case 41:
                        case 49:
                            this.destination = 22;
                            break;
                        default:
                            this.destination = 0;
                            break;
                    }

                    buffNxt.Write(color,this.destination);
                    this.color = Color.FromArgb(0, 12, 12, 12);//when leaving the parking slot this avoids the program nor reseting the color
                    panel.Invalidate();
                    
                }
               // this.colour = Color.FromArgb(0, 12, 12, 12);
                panel.Invalidate();

            }
        }

        private void zeroCar()
        {
            car.X = origin.X;
            car.Y = origin.Y;
        }

        private void moveCar(int xDelta, int yDelta)
        {
            car.X += xDelta;
            car.Y += yDelta;
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            SolidBrush brush = new SolidBrush(color);
            g.FillRectangle(brush, car.X, car.Y, 20, 25);

            brush.Dispose();
            g.Dispose();
        }
    }
}
