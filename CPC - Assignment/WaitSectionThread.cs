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
    class WaitSectionThread
    {
        private Point origin;
        private int delay;
        private Panel panel;
        private string moving_direc;
        private Color color;
        private Point car;
        private int xDelta;
        private int yDelta;
        private Buffer buff_this;
        private Buffer buffNxt;
        private Buffer buffPSlot;
        private Buffer buff_turn;
        private Semaphore semaphore;
        private Semaphore semaphoreNxt;
        private bool endPanel; //check whether its the end of the Panel
        private int turn_Point;
        private int panelNo;
        private int destination;
        private int select_position;//if(Left) == 1  if(right) == 2 if(middle) == 3//
        private int moves;


        public WaitSectionThread(Point origin, int delay, string moving_direc,Panel panel, bool endPanel, int panelNo, ParkingCar obj, int select_position, Semaphore semaphore, Semaphore semaphoreNxt, Buffer buff_this, Buffer buffNxt, Buffer buffPSlot, Buffer buff_turn)
        {


            this.origin = origin;
            this.delay = delay;
            this.moving_direc = moving_direc;
            this.panel = panel;
            this.endPanel = endPanel;
            this.panelNo = panelNo;
            this.select_position = select_position;
            this.semaphore = semaphore;
            // this.semaphore = semaphoreNxt;
            this.buff_this = buff_this;
            this.buffNxt = buffNxt;
            this.buffPSlot = buffPSlot;
            this.buff_turn = buff_turn;
            this.car = origin;

            this.panel.Paint += new PaintEventHandler(this.panel_Paint);

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
        //setting the cars initial location
        private void zeroCar()
        {
            car.X = origin.X;
            car.Y = origin.Y;
        }
        //to get coordinates of X and Y while the car is moving (i.e for loop)
        private void newZeroCar(int x, int y)
        {
            car.X = x;
            car.Y = y;
        }

        private void moveCar(int xDelta, int yDelta)
        {
            car.X += xDelta;
            car.Y += yDelta;
        }
        public void Start()
        {

            this.color = Color.FromArgb(0, 0, 0, 50);

            for (int i = 1; i <= 2;)
            {
                semaphore.Signal();

                buff_this.Read(ref this.color, ref this.destination);
               // buff_this.ReadDestination(ref this.destination);


                if ((destination == 4 || destination == 5 || destination == 6 || destination == 7 || destination == 8 || destination == 9) && panelNo == 11)
                {
                    this.newZeroCar(50, -10);
                }

                else if ((destination == 20 || destination == 21) && (panelNo == 13))
                {
                    this.newZeroCar(45, 20);
                    this.moves = 6;
                }
                //how many times you need to blink the car in a panel

                else if ((destination == 20 || destination == 21) && (panelNo == 16))
                {
                    this.newZeroCar(50, -10); this.moves = 6;
                }

                else
                {
                    this.zeroCar();
                }


                switch (destination)
                {
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                        this.turn_Point = 1;
                        break;
                    default:
                        this.turn_Point = 0;
                        break;
                }



                //setting the direction for the car to move

                if (panelNo == 10 || panelNo == 12 || panelNo == 14 || panelNo == 15)
                {
                    this.moves = 59;
                }

                else if (panelNo == destination || (panelNo == 4 && destination == 7) || (panelNo == 5 && destination == 8) || (panelNo == 6 && destination == 9)) {
                    this.moves = 8;
                } 

                else if ((destination == 4 || destination == 5 || destination == 6 || destination == 7 || destination == 8 || destination == 9 || destination == 20 || destination == 21) && (panelNo == 30 || panelNo == 31 || panelNo == 32))
                {
                    this.moves = 7;

                }

                else
                {
                    this.moves = 14;
                }


                for (int j = 1; j <= moves; j++)  //determines the speed of the car with a specific amount appearences withing a panel
                {

                    panel.Invalidate();
                    this.moveCar(xDelta, yDelta);
                    Thread.Sleep(delay);

                }



                if (endPanel == false)
                {
                    if (panelNo == this.destination)
                    {
                        buffPSlot.Write(color, destination);
                       // buffPSlot.WriteDestination(destination);
                    }
                    else if 
                          (panelNo != 32 && turn_Point == 1 && ((panelNo == 30) || (panelNo == 31) || (panelNo == 32)))
                    {
                        buff_turn.Write(color, destination);
                        //buff_turn.WriteDestination(destination);
                    }
                    else if ((destination == 7 || destination == 8 || destination == 9) && (panelNo == 31 || panelNo == 11))
                    {

                        buff_turn.Write(color, destination);
                        //buff_turn.WriteDestination(destination);
                    }
                    else if ((panelNo == 4 && destination == 7) || (panelNo == 5 && destination == 8) ||  (panelNo == 6 && destination == 9))
                    {

                        buff_turn.Write(color, destination);
                        //buff_turn.WriteDestination(destination);
                    }
                    else if (destination == 21 && panelNo == 32)
                    {

                        buffPSlot.Write(color, destination);
                        //buffPSlot.WriteDestination(destination);
                    }

                    else
                    {
                        buffNxt.Write(color, destination);
                       // buffNxt.WriteDestination(destination);
                    }
                }

                this.color = Color.FromArgb(0, 50, 50, 50);// avoids leaving a trace of vehicals on each panel because it replaces the color of the panel
                
                panel.Invalidate();
                
            }
        }

        private void panel_Paint(object sendpointer, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            SolidBrush brush = new SolidBrush(color);
            g.FillRectangle(brush, car.X, car.Y, 20, 25);
            brush.Dispose();
            g.Dispose();
        }
    }
}
