namespace Vizualizare_Sortari

{
    class SelectionSort : Visualization, Interface1
    {
        private int step, pos;
        private int[] array;

        public SelectionSort(int[] array, int[] start_pos, Graphics g, int maxVal, int dly, int bar_width)
            : base(g, start_pos, maxVal, dly, bar_width)
        {
            this.array = array;
        }

        /**
         * Performs the next step in the algorithm.
         * Places the minimal element from the remaining unsorted subarray at the next position.
         **/
        public void NextStep()
        {
            pos = DetMin(step);
            if(array[pos] != array[step])
            {
                Swap(step, pos, array);
            }
            step ++;
        }

        /**
         * Determines the minimal element from the subarray position + 1 to n.
         **/
        private int DetMin(int position)
        {
            for (int i = position + 1; i < array.Length; i ++)
            {
                if (array[i] < array[position]) position = i;
            }
            return position;
        }

        /**
         * Time complexity: O(n^2)
         **/
    }
}