using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Queues
{
    class LimitedQueue<T>
    {
        Queue<T> _queue = new Queue<T>();
        SemaphoreSlim _semaphore;
        object _lock = new object();

        public LimitedQueue(int maximumQueueSize)
        {
            _semaphore = new SemaphoreSlim(maximumQueueSize, maximumQueueSize);
        }

        public void Enque(T item)
        {
            _semaphore.Wait();
            lock (_lock)
                _queue.Enqueue(item);
        }

        public T Deque()
        {
            _semaphore.Release();
            lock (_lock)
                return _queue.Dequeue();
        }
    }
}
