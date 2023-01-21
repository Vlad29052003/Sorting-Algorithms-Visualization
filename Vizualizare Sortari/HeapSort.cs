namespace Vizualizare_Sortari

{
    class HeapSort : Visualization, Interface1
    {
        private int[] array;

        public HeapSort(int[] array, int[] start_pos, Graphics g, int maxVal, int dly, int bar_width)
            : base(g, start_pos, maxVal, dly, bar_width)
        {
            this.array = array;
        }

        /**
         * In this case the NextStep method directly sorts the array.
         * The pause/resume option is not available for this sorting method.
         **/
        public void NextStep()
        {
            Sort(array, array.Count());
        }

        /**
         * Performs down heap to check if the elements respect the order.
         **/
        private void DownHeap(int[] array, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && array[left] > array[largest])
                largest = left;

            if (right < n && array[right] > array[largest])
                largest = right;

            if (largest != i)
            {
                Swap(i, largest, array);
                DownHeap(array, n, largest);
            }
        }

        /**
         * Performs the actual sorting.
         * First it applies the heapify algorithm on the array to make it a max-oriented heap.
         * 
         * Then it performs n removals, placing the removed element at the end.
         **/
        private void Sort(int[] array, int n)
        {
            for (int i = n / 2 - 1; i >= 0; i--)
                DownHeap(array, n, i);
            
            for (int i = n - 1; i > 0; i--)
            {
                Swap(0, i, array);
                DownHeap(array, i, 0);
            }
        }

        /**
         * Time complexity: O(n log(n))
         **/
    }
}