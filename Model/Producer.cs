using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Model
{
    public class Producer
    {
        //
        // BUFFER TO CONSUME FROM
        private Buffer _buffer;
        //
        // BOOLEAN TO MAKE THREAD KEEP ACTIVE
        private bool _running;

        //
        // CONSTRUCTOR
        public Producer(Buffer buffer)
        {
            _buffer = buffer;
        }

        public void Produce()
        {
            //
            // ENABLES THE WHILE LOOP
            _running = true;
            while (_running)
            {
                //
                // PRODUCE NEW BOTTLE
                Bottle bottle = new Bottle();
                //
                // ADD BOTTLE TO THE BUFFER
                _buffer.AddToBuffer(bottle);

                //
                // MAKES THREAD SLEEP FOR 0.4 SECONDS
                Thread.Sleep(400);
            }
        }

        public void StopConsumer()
        {
            //
            // SETS THE BOOLEAN FOR WHILE LOOP
            _running = false;
        }

    }
}
