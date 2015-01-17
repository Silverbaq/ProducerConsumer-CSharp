using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Model
{
    public class Consumer
    {
        //
        // BUFFER TO CONSUME FROM
        private Buffer _buffer;
        //
        // BOOLEAN TO MAKE THREAD KEEP ACTIVE
        private bool _running;

        //
        // CONSTRUCTOR
        public Consumer(Buffer buffer)
        {
            _buffer = buffer;
        }

        public void Consume()
        {
            //
            // ENABLES THE WHILE LOOP
            _running = true;
            while (_running)
            {
                //
                // CONSUME BOTTLE FROM BUFFER
                Bottle bottle = _buffer.TakeFromBuffer();    
                //
                // MAKE THREAD SLEEP FOR 0.5 SECONDS
                Thread.Sleep(500);
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
