using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPC___Assignment
{
    public partial class Form1 : Form
    {
        //private ButtonPanelThread p1, p3;
        //private Button btn1, btn3, btn2;
        //private WaitSectionThread waitThread1;
        //private Thread thread1, thread2, thread3, thread4;
        //private Semaphore semaphore;
        //private Buffer buff;
        //private Thread semThread;
        //private Thread buffThread;
        //private Panel pnl1, pnl2, pnl3;

        //definning buffers for panels and junctions
        private Buffer buff1, buff2, buff3, buff4, buff5, buff6, buff7, buff8, buff9, buff10, buff11, buff12, buff13, buff14, buff15, buff16, buff17, buffPark_slot1, buffPark_slot2, buffPark_slot3, buffPark_slot4, buffPark_slot5, buffPark_slot6, buffPark_slot7, buffPark_slot8, buffPark_slot9, buffPark_slot10, buffPark_slot11, buffTurnPanel12, buffTurnPanel13, buffTurnPanel14, buffTurnPanel15;

        private void label17_Click(object sender, EventArgs e)
        {

        }

        //defining the main buttons to park car
        private ButtonPanelThread btnThreadA, btnThreadB;

        //creating objects to park car
        private ParkingCar parkslot1, parkslot2, parkslot3, parkslot4, parkslot5, parkslot6, parkslot7, parkslot8, parkslot9, parkslot10, parkslot11;

        //creating thread objects relevant to hold car 
        private WaitSectionThread waitThread1, waitThread2, waitThread3, waitThread4, waitThread5, waitThread6, waitThread7, waitThread8, waitThread9, waitThread10, waitThread11, waitThread12, waitThread13, waitThread14, waitThread15, waitThread16, waitThread17, waitThread18, waitThread19, waitThread20, waitThread21;

        //threads for buttons and parking slots
        private Thread btnThread1, btnThread2,thread1, thread2, thread3, thread4, thread5, thread6, thread7, thread8, thread9, thread10,thread11, thread12, thread13, thread14, thread15, thread16, thread17, thread18, thread19, thread20, thread21, parkThread1, parkThread2, parkThread3, parkThread4, parkThread5, parkThread6, parkThread7, parkThread8, parkThread9, parkThread10, parkThread11;

        //semaphores for all panels
        private Semaphore semaphore, semaphore2, semaphore3, semaphore4, semaphore5, semaphore6, semaphore7, semaphore8, semaphore9, semaphore10, semaphore11, semaphore12, semaphore13, semaphore14, semaphore15, semaphore16, semaphore17, semaphore18, semaphore19, semaphore20, semaphore21;

        private void s2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void s11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pnl4_Paint(object sender, PaintEventArgs e)
        {

        }

      

        public Form1()
        {
            //running the GUI
            InitializeComponent();


            //Creation of buffer objects for normal panels
            buff1 = new Buffer();

            buff2 = new Buffer();

            buff3 = new Buffer();

            buff4 = new Buffer();

            buff5 = new Buffer();

            buff6 = new Buffer();

            buff7 = new Buffer();

            buff8 = new Buffer();

            buff9 = new Buffer();

            buff10 = new Buffer();

            buff11 = new Buffer();

            buff12 = new Buffer();

            buff13 = new Buffer();

            buff14 = new Buffer();

            buff15 = new Buffer();

            buff16 = new Buffer();

            buff17 = new Buffer();



            //creation of semaphore objects
            semaphore = new Semaphore();

            semaphore2 = new Semaphore();

            semaphore3 = new Semaphore();

            semaphore4 = new Semaphore();

            semaphore5 = new Semaphore();

            semaphore6 = new Semaphore();

            semaphore7 = new Semaphore();

            semaphore8 = new Semaphore();

            semaphore9 = new Semaphore();

            semaphore10 = new Semaphore();

            semaphore11 = new Semaphore();

            semaphore12 = new Semaphore();
            
            semaphore13 = new Semaphore();

            semaphore14 = new Semaphore();

            semaphore15 = new Semaphore();

            semaphore16 = new Semaphore();

            semaphore17 = new Semaphore();

            semaphore18 = new Semaphore();

            semaphore19 = new Semaphore();

            semaphore20 = new Semaphore();

            semaphore21 = new Semaphore();

           // semaphorePark1 = new Semaphore();


          

            //Creation of buffer objects for parking slot panels
            buffPark_slot1 = new Buffer();

            buffPark_slot2 = new Buffer();

            buffPark_slot3 = new Buffer();

            buffPark_slot4 = new Buffer();

            buffPark_slot5 = new Buffer();

            buffPark_slot6 = new Buffer();

            buffPark_slot7 = new Buffer();

            buffPark_slot8 = new Buffer();

            buffPark_slot9 = new Buffer();

            buffPark_slot10 = new Buffer();

            buffPark_slot11 = new Buffer();

            //Creation of buffer objects for junction panels
            buffTurnPanel12 = new Buffer();

            buffTurnPanel13 = new Buffer();

            buffTurnPanel14 = new Buffer();

            buffTurnPanel15 = new Buffer();


            btnThreadA = new ButtonPanelThread(new Point(50, -12),100, pA, btnParkCarA, rb1, rb2, rb3, rb4, rb5, rb6, 100, semaphore,buff1);//last one be speed


            btnThreadB = new ButtonPanelThread(new Point(50, -12),90, pB, btnParkCarB, rb7, rb8, rb9, rb10, rb11, null, 200, semaphore14,buff12);
            
            // Park A and Park B Button Threads    
            btnThread1 = new Thread(new ThreadStart(btnThreadA.Start));

            btnThread2 = new Thread(new ThreadStart(btnThreadB.Start));



            //Park A and Park B Button Thread start
            btnThread1.Start();

            btnThread2.Start();


            // overloading left Panels to hold car
            waitThread1 = new WaitSectionThread(new Point(50, -10), 50, "south", pnl1, false, 30, parkslot1, 1, semaphore, semaphore2, buff1, buff2, null, buffTurnPanel12); //try changing panelID


            waitThread2 = new WaitSectionThread(new Point(50, -10), 100, "south", pnl2, false, 1, parkslot2, 1, semaphore2, semaphore3, buff2, buff3, buffPark_slot1, null);


            waitThread3 = new WaitSectionThread(new Point(50, -10), 100, "south", pnl3, false, 2, parkslot3, 1, semaphore3, semaphore4, buff3, buff4, buffPark_slot2, null);


            waitThread4 = new WaitSectionThread(new Point(50, -10), 100, "south", pnl4, false, 3, parkslot1, 1, semaphore4, semaphore5, buff4, buff5, buffPark_slot3, null);


            waitThread5 = new WaitSectionThread(new Point(50, -10), 100, "south", pnl5, false, 13, parkslot1, 1, semaphore5, semaphore6, buff5, buff6, null, null);


            waitThread6 = new WaitSectionThread(new Point(50, -10), 100, "south", pEA, true, 17, parkslot1, 1, semaphore6, semaphore7, buff6, null, null, null);


            // initializing the thread to aid when turning car
            waitThread7 = new WaitSectionThread(new Point(-5, 25), 40, "east", pnl6, false, 10, parkslot1, 1, semaphore, semaphore8, buffTurnPanel12, buff7, null, null);

            waitThread8 = new WaitSectionThread(new Point(50, -10), 100, "south", pnl8, false, 11, parkslot1, 1, semaphore8, semaphore9, buff7, buff8, null, null);

            waitThread9 = new WaitSectionThread(new Point(50, -10), 100, "south", pnl9, false, 4, parkslot1, 3, semaphore9, semaphore10, buff8, buff9, buffPark_slot4, buffPark_slot7);

            waitThread10 = new WaitSectionThread(new Point(50, -10), 100, "south", pnl10, false, 5, parkslot1, 3, semaphore10, semaphore11, buff9, buff10, buffPark_slot5, buffPark_slot8);

            waitThread11 = new WaitSectionThread(new Point(50, -10), 100, "south", pnl11, false, 6, parkslot1, 3, semaphore11, semaphore12, buff10, buff11, buffPark_slot6, buffPark_slot9);

            waitThread12 = new WaitSectionThread(new Point(50, -10), 100, "south", pnl12, false, 32, parkslot1, 1, semaphore11, semaphore12, buff11, buffTurnPanel13, buffTurnPanel14, null);

            waitThread13 = new WaitSectionThread(new Point(300, 20), 40, "west", pnl7, false, 14, parkslot1, 1, semaphore12, semaphore6, buffTurnPanel13, buff5, null, buff5);


            // overloading right Panels to hold car

            waitThread14 = new WaitSectionThread(new Point(50, -10), 50, "south", pnl15, false, 31, null, 2, semaphore14, semaphore15, buff12, buff13, null, buffTurnPanel15);

            waitThread15 = new WaitSectionThread(new Point(50, -10), 100, "south", pnl16, false, 52, null, 2, semaphore15, semaphore16, buff13, buff14, buffPark_slot10, null);

            waitThread16 = new WaitSectionThread(new Point(50, -10), 100, "south", pnl17, false, 53, null, 2, semaphore16, semaphore17, buff14, buff15, buffPark_slot11, null);

            waitThread17 = new WaitSectionThread(new Point(50, -10), 100, "south", pnl18, false, 9, null, 2, semaphore17, semaphore18, buff15, buff16, null, null);

            waitThread18 = new WaitSectionThread(new Point(50, -10), 100, "south", pnl19, false, 13, null, 2, semaphore18, semaphore19, buff16, buff17, null, null);

            waitThread19 = new WaitSectionThread(new Point(50, -10), 100, "south", pEB, true, 18, null, 2, semaphore19, semaphore20, buff17, null, null, null);

            /*Panel 21 turning panle */
            waitThread20 = new WaitSectionThread(new Point(250, 25), 40, "west", pnl13, false, 12, null, 2, semaphore20, semaphore21, buffTurnPanel15, buff8, null, null);

            waitThread21 = new WaitSectionThread(new Point(0, 20), 40, "east", pnl14, false, 15, null, 2, semaphore21, semaphore20, buffTurnPanel14, buff16, null, null);

            //Overloading the waiting threads

            thread1 = new Thread(new ThreadStart(waitThread1.Start));

            thread2 = new Thread(new ThreadStart(waitThread2.Start));

            thread3 = new Thread(new ThreadStart(waitThread3.Start));

            thread4 = new Thread(new ThreadStart(waitThread4.Start));

            thread5 = new Thread(new ThreadStart(waitThread5.Start));

            thread6 = new Thread(new ThreadStart(waitThread6.Start));

            thread7 = new Thread(new ThreadStart(waitThread7.Start));

            thread8 = new Thread(new ThreadStart(waitThread8.Start));

            thread9 = new Thread(new ThreadStart(waitThread9.Start));

            thread10 = new Thread(new ThreadStart(waitThread10.Start));

            thread11 = new Thread(new ThreadStart(waitThread11.Start));

            thread12 = new Thread(new ThreadStart(waitThread12.Start));

            thread13 = new Thread(new ThreadStart(waitThread13.Start));

            thread14 = new Thread(new ThreadStart(waitThread14.Start));

            thread15 = new Thread(new ThreadStart(waitThread15.Start));

            thread16 = new Thread(new ThreadStart(waitThread16.Start));

            thread17 = new Thread(new ThreadStart(waitThread17.Start));

            thread18 = new Thread(new ThreadStart(waitThread18.Start));

            thread19 = new Thread(new ThreadStart(waitThread19.Start));

            thread20 = new Thread(new ThreadStart(waitThread20.Start));

            thread21 = new Thread(new ThreadStart(waitThread21.Start));

            //waiting panel threads Start
            thread1.Start();

            thread2.Start();

            thread3.Start();

            thread4.Start();

            thread5.Start();

            thread6.Start();

            thread7.Start();

            thread8.Start();

            thread9.Start();

            thread10.Start();

            thread11.Start();

            thread12.Start();

            thread13.Start();

            thread14.Start();

            thread15.Start();

            thread16.Start();

            thread17.Start();

            thread18.Start();

            thread19.Start();

            thread20.Start();

            thread21.Start();

            //threads to park vehical in the relevant spots

            parkslot1 = new ParkingCar(new Point(-10, 20), 100, "east", btnPark1, 40, s1, semaphore3, semaphore2, buffPark_slot1, buff3);

            parkslot2 = new ParkingCar(new Point(-10, 20), 100, "east", btnPark2, 41, s2, semaphore4, semaphore3, buffPark_slot2, buff4);

            parkslot3 = new ParkingCar(new Point(-10, 20), 100, "east", btnPark3, 42, s3, semaphore5, semaphore4, buffPark_slot3, buff5);

            parkslot4 = new ParkingCar(new Point(100, 20), 100, "west", btnPark4, 43, s4, semaphore11, semaphore10, buffPark_slot4, buff9);

            parkslot5 = new ParkingCar(new Point(100, 20), 100, "west", btnPark5, 44, s5, semaphore12, semaphore11, buffPark_slot5, buff10);

            parkslot6 = new ParkingCar(new Point(100, 20), 100, "west", btnPark6, 45, s6, semaphore13, semaphore12, buffPark_slot6, buff11);

            //for parking slots 7,8,9,10,11
            parkslot7 = new ParkingCar(new Point(110, 15), 100, "west", btnPark10, 49, s10, semaphore16, semaphore15, buffPark_slot10, buff14);

            parkslot8 = new ParkingCar(new Point(110, 20), 100, "west", btnPark11, 50, s11, semaphore17, semaphore16, buffPark_slot11, buff15);

            parkslot9 = new ParkingCar(new Point(-10, 20), 100, "east", btnPark7, 46, s7, semaphore10, semaphore10, buffPark_slot7, buff9);

            parkslot10 = new ParkingCar(new Point(-10, 20), 100, "east", btnPark8, 47, s8, semaphore11, semaphore10, buffPark_slot8, buff10);

            parkslot11 = new ParkingCar(new Point(-10, 20), 100, "east", btnPark9, 48, s9, semaphore11, semaphore10, buffPark_slot9, buff11);

            //starting the parking threads
            parkThread1 = new Thread(new ThreadStart(parkslot1.Start));

            parkThread2 = new Thread(new ThreadStart(parkslot2.Start));

            parkThread3 = new Thread(new ThreadStart(parkslot3.Start));

            parkThread4 = new Thread(new ThreadStart(parkslot4.Start));

            parkThread5 = new Thread(new ThreadStart(parkslot5.Start));

            parkThread6 = new Thread(new ThreadStart(parkslot6.Start));

            parkThread7 = new Thread(new ThreadStart(parkslot7.Start));

            parkThread8 = new Thread(new ThreadStart(parkslot8.Start));

            parkThread9 = new Thread(new ThreadStart(parkslot9.Start));

            parkThread10 = new Thread(new ThreadStart(parkslot10.Start));

            parkThread11 = new Thread(new ThreadStart(parkslot11.Start));

            //parking car thread start
            parkThread1.Start();

            parkThread2.Start();

            parkThread3.Start();

            parkThread4.Start();

            parkThread5.Start();

            parkThread6.Start();

            parkThread7.Start();

            parkThread8.Start();

            parkThread9.Start();

            parkThread10.Start();

            parkThread11.Start();
            
         
        }
        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
