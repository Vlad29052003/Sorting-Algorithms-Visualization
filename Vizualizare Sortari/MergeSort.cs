namespace Vizualizare_Sortari

{
    class MergeSort : Visualization, Interface1
    {
        private int[] array, copy;

        public MergeSort(int[] array, int[] start_pos, Graphics g, int maxVal, int dly, int bar_width)
            : base(g, start_pos, maxVal, dly, bar_width)
        {
            this.array = array;
            copy = new int[array.Length];
        }

        /**
         * In this case the NextStep method directly sorts the array.
         * The pause/resume option is not available for this sorting method.
         **/
        public void NextStep()
        {
            Merge(array,0, array.Count() - 1);
        }

        /**
         * Performs the actual merge sort.
         * Uses Divide-Et-Impera to divide the array into 2 equal sized sub-arrays and sort them.
         * After returning from the recursive calls, it merges the 2 sorted sub-arrays.
         **/
        private void Merge(int[] array, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;

                Merge(array, left, middle);
                Merge(array, middle + 1, right);

                int i = left, j = middle + 1, k = -1;

                while (i <= middle && j <= right)
                    if (array[i] < array[j])
                    {
                        copy[++ k] = array[i ++];
                    }
                    else
                    {
                        copy[++ k] = array[j ++];
                    }
                while (i <= middle)
                {
                    copy[++ k] = array[i ++];
                }
                while (j <= right)
                {
                    copy[++ k] = array[j ++];
                }

                for (i = left, j = 0; i <= right; i ++, j ++)
                {
                    DrawBar(i, copy[j]);
                    array[i] = copy[j];
                }
            }
        }

        /**
         * Time complexity: O(n log(n)).
         * Auxilliary space complexity: O(n).
         **/
    }
}