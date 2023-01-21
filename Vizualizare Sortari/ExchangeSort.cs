namespace Vizualizare_Sortari
{
    class ExchangeSort : Visualization, Interface1
    {
        private int step;
        private int[] array;

        public ExchangeSort(int[] array, int[] start_pos, Graphics g, int maxVal, int dly, int bar_width)
            : base(g, start_pos, maxVal, dly, bar_width)
        {
            this.array = array;
        }

        /**
         * Performs the next step in the algorithm.
         * 
         * Swaps the elements at position step with the next ones if it is bigger.
         **/
        public void NextStep()
        {
                for (int i = step + 1; i < array.Length; i ++)
                {
                    if (array[step] > array[i]) Swap(i, step, array);
                }
            step ++;
        }

        /**
         * Time complexity: O(n^2)
         **/
    }
}