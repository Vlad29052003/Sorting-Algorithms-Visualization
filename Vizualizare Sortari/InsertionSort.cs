namespace Vizualizare_Sortari

{
    class InsertionSort : Visualization, Interface1
    {
        private int step = 1;
        private int[] array;

        public InsertionSort(int[] array, int[] start_pos, Graphics g, int maxVal, int dly, int bar_width)
            : base(g, start_pos, maxVal, dly, bar_width)
        {
            this.array = array;
        }

        /**
         * Performs the next step in the algorithm.
         * Inserts element at position i in the subarray of positions 0 to i - 1
         * in such a way that the subarray from 0 to i will be sorted.
         **/
        public void NextStep()
        {
            int pos = step;

            while (pos > 0 && array[pos] < array[pos - 1])
            {
                Swap(pos, pos - 1, array);
                pos --;
            }
            step ++;
        }

        /**
         * Time complexity: O(n^2) or O(n + d) where d is the number of swaps.
         * Best time complexity: O(n) if the array is nearly sorted (d is proportional with n).
         **/
    }
}