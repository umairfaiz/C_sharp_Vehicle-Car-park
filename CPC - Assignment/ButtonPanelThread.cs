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
    class ButtonPanelThread
    {
       
        private Point origin;//starting section of each panel
        private int delay;
        private Panel panel;
        private Point carPoint;//current coordinate of the object at a moment
        private Buffer buffNxt;//getting the next buffer available relative to the current location
        private Semaphore semaphoreNxt;
        private Button btnParkA_B;//main buttons to generate car
        private RadioButton rbtn1, rbtn2, rbtn3, rbtn4, rbtn5, rbtn6;//radio buttons
        private int westEast; //if (West(L)) 100; else if(East(R))200;//direction of moving
        private int r, g, b;//vehical color
        private bool locked = true;
        private int endPanel;//location of the car
        //private RadioButton sender;
   
        public ButtonPanelThread(Point origin, int delay, Panel panel, Button btnParkA_B, RadioButton rbtn1, RadioButton rbtn2, RadioButton rbtn3, RadioButton rbtn4, RadioButton rbtn5, RadioButton rbtn6, int westEast, Semaphore semaphoreNxt,Buffer buffNxt)
        {
            this.origin = origin;
            this.delay = delay;
            this.panel = panel;
            this.btnParkA_B = btnParkA_B;
            this.rbtn1 = rbtn1;
            this.rbtn2 = rbtn2;
            this.rbtn3 = rbtn3;
            this.rbtn4 = rbtn4;
            this.rbtn5 = rbtn5;
            this.rbtn6 = rbtn6;
            this.westEast = westEast;
            this.semaphoreNxt = semaphoreNxt;
            this.buffNxt = buffNxt;
            this.carPoint = origin;
            
            this.panel.Paint += new PaintEventHandler(this.panel_Paint);
            this.btnParkA_B.Click += new System.EventHandler(this.mainbtn_Click);


        }
        private void zeroCar()
        {
            carPoint.X = origin.X;
            carPoint.Y = origin.Y;
        }

        private void moveCar(int xDelta, int yDelta)
        {
            carPoint.X += xDelta;
            carPoint.Y += yDelta;
        }



        //Park A and B Click Event Handler    
        private void mainbtn_Click(object sender, System.EventArgs e)
        {

            Random randomColor = new Random(); this.r = randomColor.Next(5, 255); this.g = randomColor.Next(3, 255); this.b = randomColor.Next(8, 255);

            locked = !locked;
            //buttonColor after clicking
            this.btnParkA_B.BackColor = Color.Transparent;

            lock (this)
            {
                if (!locked)
                    Monitor.Pulse(this);
            }
        }
        
        public void Start()
        {

            Thread.Sleep(delay);
            
            for (int i = 1; i <= 10;) //infinte loop for radio buttons
            {
                this.zeroCar();

                panel.Invalidate();

                //locking the panel when its being used by another car
                lock (this)
                {
                    while (locked)
                    {
                        Monitor.Wait(this);
                    }
                }

                //get the relevant destination when radio button is selected
                if (rbtn1.Checked)
                {
                    if (westEast == 100)
                    {
                        this.endPanel = 1;
                    }

                    else
                    {
                        this.endPanel = 7;
                    }
                }
                else if (rbtn2.Checked)
                {
                    if (westEast == 100)
                    {
                        this.endPanel = 2;
                    }
                    else
                    {
                        this.endPanel = 8;
                    }
                }
                else if (rbtn3.Checked)
                {
                    if (westEast == 100)
                    {
                        this.endPanel = 3;
                    }
                    else
                    {
                        this.endPanel = 9;
                    }
                }
                else if (rbtn4.Checked)
                {
                    if (westEast == 100)
                    {
                        this.endPanel = 4;
                    }
                    else {
                        this.endPanel = 52;
                    }
                }
                else if (rbtn5.Checked)
                {
                    if (westEast == 100)
                    {
                        this.endPanel = 5;
                    }
                    else
                    {
                        this.endPanel = 53;
                    }
                }   
                else if (rbtn6.Checked)
                {
                    if (westEast == 100)
                    {
                        this.endPanel = 6;
                    }
                    else
                    {
                        this.endPanel = 0;
                    }
                }
                //RadioButton switch_btn = sender as RadioButton;
                //try
                //{
                //    if (switch_btn.Checked == true)
                //    {
                //        switch (switch_btn.Name)
                //        {
                //            case "rbtn1":
                //                if (westEast == 100) this.destination = 1;
                //                else this.destination = 7;
                //                break;

                //            case "rbtn2":
                //                if (westEast == 100) this.destination = 2;
                //                else this.destination = 8;
                //                break;

                //        }
                //    }
                //}catch
                //{
                //    Console.WriteLine ("error");
                //}

                for (int j = 1; j <= 12; j++)
                {
                    this.moveCar(0, 5);

                    Thread.Sleep(delay);

                    panel.Invalidate();
                }
                
                locked = true;
                semaphoreNxt.Wait();
                buffNxt.Write(Color.FromArgb(100, this.r, this.g, this.b), this.endPanel);
                //buffNxt.WriteDestination(this.endPanel);

            }
            panel.Invalidate();
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            SolidBrush brush = new SolidBrush(Color.FromArgb(100, this.r, this.g, this.b));
            g.FillRectangle(brush, carPoint.X, carPoint.Y, 20, 25);

            //disposing the graphics objects
            brush.Dispose();  
            g.Dispose();      
        }
    }
}
