
namespace Vizualizare_Sortari
{
    class CountingSort : Visualization, Interface1
    {
        private int[] array, frq;

        public CountingSort(int[] array, int[] start_pos, Graphics g, int maxVal, int dly, int bar_width)
            : base(g, start_pos, maxVal, dly, bar_width)
        {
            this.array = array;
            frq = new int[maxVal];
            initialize_frq();
        }

        /**
         * Initializes the frequency array.
         * 
         * Each bucket holds the number of appearances of number i
         **/
        public void initialize_frq()
        {
            for (int j = 0; j < array.Length; j ++)
            {
                frq[array[j]] ++;
            }
        }

        /**
         * Performs the actual sort. Pause is not available for this algorithm.
         **/
        public void NextStep()
        {
            int k = 0;

            for(int i = 0; i < frq.Length; i ++)
                while (frq[i] != 0)
                {
                    if (array[k] != i)
                    {
                        frq[i] --;
                        DrawBar(k, i);
                        array[k ++] = i;
                    }
                    else { k ++; frq[i] --; }
                }
        }

        /**
         * Timple complexity: O(n + N) where n is the size of the array and N is the range of the inputs from the array.
         * Best time complexity: O(n) when N proportional with n.
         * Auxilliary space complexity: S(N) for storing the frequency array.
         **/
    }
}