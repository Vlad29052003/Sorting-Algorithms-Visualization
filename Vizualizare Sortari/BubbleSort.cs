namespace Vizualizare_Sortari

{
    class BubbleSort : Visualization, Interface1
    {
        private int[] array;

        public BubbleSort(int[] array, int[] start_pos, Graphics g, int maxVal, int dly, int bar_width)
            : base(g, start_pos, maxVal, dly, bar_width)
        {
            this.array = array;
        }

        /**
         * Performs the next step in the algorithm.
         * 
         * Swaps two adjacent positions from the array
         * if they do not respect the order
         **/
        public void NextStep()
        {
            for (int i = 0; i < array.Count() - 1; i ++)
            {
                if (array[i] > array[i + 1]) Swap(i, i + 1, array);
            }
        }

        /**
         * Time complexity: O(n^2).
         * Best time complexity: O(n) when the array is sorted.
         **/
    }
}