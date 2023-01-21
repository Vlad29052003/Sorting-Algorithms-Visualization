namespace Vizualizare_Sortari

{
    class QuickSort : Visualization, Interface1
    {
        private int[] array;

        public QuickSort(int[] array, int[] start_pos, Graphics g, int maxVal, int dly, int bar_width)
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
            Sort(array, 0, array.Count() - 1);
        }

        /**
         * Sorts the array using quick sort algorithm which uses Divide-Et-Impera
         * It chooses a random pivot in the given range and then places the elements smaller than the pivot to its left
         * and the elements bigger than the pivot to its right.
         * Then it calls recursively on the left and right subarrays.
         **/
        private void Sort(int[] array, int left, int right)
        {
            if (left < right)
            {
                Random rand = new Random();
                int pivot = rand.Next(left, right);
                Swap(right, pivot, array);
                int i = left, j = right - 1;

                while(i <= j)
                {
                    while (i <= j && array[i] < array[right])
                        i++;
                    while(i <= j && array[j] > array[right])
                        j--;
                    if(i <= j)
                    {
                        Swap(i , j, array);
                        i++;
                        j --;
                    }
                }
                Swap(i, right, array);

                Sort(array, left, i - 1);
                Sort(array, i + 1, right);
            }
        }

        /**
         * Time complexity: O(n log(n)) (expected - if the choice of pivot is good which usually is the case for the random pivot choice)
         * Worst time complexity: O(n^2) when the pivot is always the smallest or the largest element.
         **/
    }
}