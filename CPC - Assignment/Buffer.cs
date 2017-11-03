using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CPC___Assignment
{
    class Buffer
    {
        private Color carColor;
        private bool empty = true;
        private int destination;

        public void Read(ref Color carColor, ref int destination)
        {
            lock (this)
            {
                // nextBuffer isEmpty??
                if (empty)
                    Monitor.Wait(this);
                empty = true;
                carColor = this.carColor;
                destination = this.destination;

                Monitor.Pulse(this);
            }
        }
        public void Write(Color carColor, int destination)
        {
            lock (this)
            {
                // nextBuffer isFull??
                if (!empty)
                    Monitor.Wait(this);
                empty = false;
                this.carColor = carColor;
                this.destination = destination;

                Monitor.Pulse(this);
            }
        }


        //public void ReadDestination(ref int destination)
        //{
        //    lock (this)
        //    {
        //        // // nextBuffer isEmpty??
        //        if (empty)
        //            Monitor.Wait(this);
        //        empty = true;
        //        destination = this.destination;
        //        Monitor.Pulse(this);
        //    }
        //}
        //public void WriteDestination(int destination)
        //{
        //    lock (this)
        //    {
        //        // nextBuffer isFull??
        //        if (!empty)
        //            Monitor.Wait(this);
        //        empty = false;
        //        this.destination = destination;
        //        Monitor.Pulse(this);
        //    }
        //}

        public void Start()
        {
        }
    }
}
