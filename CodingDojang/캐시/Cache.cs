using System.Collections.Generic;

namespace CD152
{
    class Cache
    {
        private Queue<string> queue = null;

        private readonly int cacheSize; // 캐시 크기

        public int ProcessTime { get; private set; } = 0; // 실행 시간

        public Cache(int cacheSize)
        {
            this.cacheSize = cacheSize;
            queue = new Queue<string>(cacheSize);
        }

        public void Lru(string str) // LRU 알고리즘
        {
            str = str.ToLower();

            if (cacheSize == 0)
            {
                ProcessTime += 5;
                return;
            }

            if (queue.Contains(str)) // 큐 내에 존재할 경우 순서 갱신
            {
                Queue<string> tmpQueue = new Queue<string>();

                foreach (var item in queue)
                {
                    if (item != str) { tmpQueue.Enqueue(item); }
                }
                tmpQueue.Enqueue(str);
                queue = tmpQueue;
                ProcessTime += 1; // cache hit
            }
            else // 큐 내에 존재하지 않을 경우 추가 (오래된 큐 제거)
            {
                if (queue.Count == cacheSize) { queue.Dequeue(); }
                queue.Enqueue(str);
                ProcessTime += 5; // cache miss
            }
        }

        public static int GetProcessTime(int cacheSize, List<string> aList)
        {
            Cache cc = new Cache(cacheSize);
            foreach (var item in aList)
            {
                cc.Lru(item);
            }
            return cc.ProcessTime;
        }
    }
}
