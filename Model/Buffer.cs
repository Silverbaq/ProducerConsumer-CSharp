using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Model
{
    public class Buffer
    {
        //
        // OBJECT TO LOCK RESOURCES
        private object _lock = new object();
        //
        // A QUEUE TO HOLD DATA
        private Queue<Bottle> _queue;
        //
        // THE SIZE OF THE BUFFER
        int _size;

        //
        // CONSTRUCTOR
        public Buffer(int size)
        {
            _queue = new Queue<Bottle>(size);
            _size = size;
        }

        public void AddToBuffer(Bottle bottle)
        {
            //
            // LOCK THE RESOURCES / ISOLATING THE THREADS
            lock (_lock)
            {
                //
                // CHECKS IF THE BUFFER IS FULL
                if (_queue.Count == _size)
                {
                    //
                    // WAKES ALL THREADS THERE ARE WAITING FOR THE LOCK
                    Monitor.PulseAll(_lock);
                    //
                    // RELEASE THE LOCK AND WAIT TO GET IT BACK 
                    Monitor.Wait(_lock);
                }
                //
                // ADD OBJECT TO BUFFER
                _queue.Enqueue(bottle);
                Console.WriteLine("Bottle Added: " + _queue.Count + "/10");
            }
        }

        public Bottle TakeFromBuffer()
        {
            Bottle bottle = null;
            //
            // LOCK THE RESOURCES / ISOLATING THE THREADS
            lock (_lock)
            {
                //
                // CHECKS IF THERE ARE ANYTHING IN THE BUFFER
                if (_queue.Count == 0)
                {
                    //
                    // WAKES ALL THREADS THERE ARE WAITING FOR THE LOCK
                    Monitor.PulseAll(_lock);
                    //
                    // RELEASE THE LOCK AND WAIT TO GET IT BACK 
                    Monitor.Wait(_lock);
                }
                //
                // TAKES AN OBJECT FROM THE BUFFER
                bottle = _queue.Dequeue();
                Console.WriteLine("Bottle Taken: " + _queue.Count+"/10");
            }
            return bottle;
        }
    }

}
