namespace Vizualizare_Sortari

{
    class Visualization
    {
        private Graphics g;
        private int dly, bar_width;
        private int[] start_pos;
        private int maxVal;
        Brush WhiteBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
        Brush BlackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
        Brush GreenBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Green);

        public Visualization(Graphics g, int[] start_pos, int maxVal, int dly, int bar_width)
        {
            this.g = g;
            this.start_pos = start_pos;
            this.maxVal = maxVal;
            this.dly = dly;
            this.bar_width = bar_width;
        }

        /**
         * Displays the vertical rectangles that represent the numbers.
         * 
         * pos = the position of the rectangle
         * h = the value of the number which also represents the height
         **/
        public void DrawBar(int pos, int h)
        {
            g.FillRectangle(GreenBrush, start_pos[pos], 0, bar_width - 1, maxVal);
            Task.Delay(dly).Wait();
            g.FillRectangle(BlackBrush, start_pos[pos], 0, bar_width - 1, maxVal);
            g.FillRectangle(WhiteBrush, start_pos[pos], maxVal - h, bar_width - 1, maxVal);
        }

        /**
         * Swaps the elements at positions i and j.
         **/
        public void Swap(int i, int j, int[] array)
        {
            int copy = array[i];
            array[i] = array[j];
            array[j] = copy;
            DrawBar(i, array[i]);
            DrawBar(j, array[j]);
        }
    }
}
