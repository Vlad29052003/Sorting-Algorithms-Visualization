namespace Vizualizare_Sortari

{
    class ShellSort : Visualization, Interface1
    {
        private int[] array;
        public ShellSort(int[] array, int[] start_pos, Graphics g, int maxVal, int dly, int bar_width)
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
            Sort(array, array.Length);
        }

        /**
         * Performs the actual sorting using the shell sort algorithm.
         * Similar to insertion sort. We make an array h-sorted for a large h and keep halfing h until it becomes 1.
         **/
        private void Sort(int[] array, int n)
        {
            for (int h = n / 2; h > 0; h /= 2)
            {
                for (int i = h; i < n; i += 1)
                {
                    int temp = array[i];
                    int j;
                    for (j = i; j >= h && array[j - h] > temp; j -= h)
                    {
                        array[j] = array[j - h];
                        DrawBar(j, array[j]);
                    }
                    array[j] = temp;
                    DrawBar(j,temp);
                }
            }
        }

        /**
         * Time complexity: O(n log(n)) (average).
         * Worst time complexity: O(n^2) when the array is sorted in descending order.
         **/
    }
}