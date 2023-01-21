using System.ComponentModel;
using System.Data;

namespace Vizualizare_Sortari

{
    public partial class Form1 : Form
    {
        int[] array, array_copy, start_pos;
        int bar_width = 5, dly, current_pos;
        Graphics g;
        BackgroundWorker bgw = null;
        bool Paused = false;

        /**
         * Constructor
         **/
        public Form1()
        {
            InitializeComponent();
            PopulateDropdown();
        }

        /**
         * Populates the dropdown by getting the number of the classes.
         * It uses functional programming to do so.
         **/
        private void PopulateDropdown()
        {
            List<string> ClassList = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                .Where(x => typeof (Interface1).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(x => x.Name).ToList();
            ClassList.Sort();
            foreach (string entry in ClassList)
            {
                comboBox1.Items.Add(entry);
            }
            comboBox1.SelectedIndex = 0;
        }

        /**
         * Closes the program.
         **/
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /**
         * Displays a Message Box that contains instructions on how to use the application.
         **/
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string title = "Help";
            string message = "Use the dropdown menu in order to select the algorithm." + '\n' +
                "Insert a number beetwen 0 and 1000 (miliseconds) in the delay case." + '\n' +
                "Insert a number beetwen 1 and 1000 (pixels) in the bar width case." + '\n' +
                "Click the Reset button in order to generate a random number array" + '\n' +
                "Click the Start button in order to compile the algorithm" + '\n' +
                "Click the Pause/Resume button in order to pause or resume the algorithm." + '\n';
            MessageBox.Show(message, title, MessageBoxButtons.OK);
        }

        /**
         * Updates the delay based on the user-entered value.
         **/
        public void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            dly = Convert.ToInt32(numericUpDown1.Value);
        }

        /**
         * Updates the width of the bars based on the user-entered value.
         **/
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            bar_width = Convert.ToInt32(numericUpDown2.Value);
            if(bar_width > panel1.Width)
                bar_width = panel1.Width;
        }

        /**
         * Resets the array and displays it accordingly.
         **/
        private void button1_Click(object sender, EventArgs e)
        {
            if (bgw != null && !bgw.IsBusy || bgw == null)
            {

                g = panel1.CreateGraphics();
                int NumEntries = panel1.Width / bar_width;
                int MaxVal = panel1.Height;
                current_pos = 0;
                Paused = false;
                array = new int[NumEntries];
                array_copy = new int[NumEntries];
                start_pos = new int[NumEntries];
                g.FillRectangle(new SolidBrush(Color.Black), 0, 0, panel1.Width, MaxVal);
                Random rand = new Random();
                for (int i = 0; i < NumEntries; i ++)
                {
                    array[i] = rand.Next(0, MaxVal);
                    array_copy[i] = array[i];
                }
                for (int i = 0; i < NumEntries; i ++)
                {
                    start_pos[i] = current_pos;
                    int spacing = 0;
                    if (NumEntries - i - 1 != 0) spacing = (1 + panel1.Width - current_pos - (NumEntries - i) * bar_width) / (NumEntries - i - 1);
                    g.FillRectangle(new SolidBrush(Color.White), current_pos, MaxVal - array[i], bar_width - 1, MaxVal);
                    current_pos += spacing + bar_width;
                }
            }
        }

        /**
         * Starts executing the sort based on the selected one from the dropdown menu.
         * It does so by calling the reset button (to initialize the array if it is not initialized yet) and assigns the task to a background worker
         * by calling the DoWork method.
         * It used multithreading to maintain the functionality of the buttons.
         **/
        private void button2_Click(object sender, EventArgs e)
        {
            if (bgw == null || !bgw.IsBusy)
            {
                if (array == null) button1_Click(null, null);
                bgw = new BackgroundWorker();
                bgw.WorkerSupportsCancellation = true;
                bgw.DoWork += new DoWorkEventHandler(bgw_DoWork);
                bgw.RunWorkerAsync(argument: comboBox1.SelectedItem);
            }
        }

        /**
         * Empty method for the event when the selected sort changes.
         **/
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {}

        /**
         * Empty method for the event when an item from the menu strip is clicked.
         **/
        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {}

        /**
         * Handles the event in which the pause/resume button is called.
         **/
        private void button3_Click(object sender, EventArgs e)
        {
            if (bgw != null)
            {
                if (!Paused)
                {
                    bgw.CancelAsync();
                    Paused = true;
                }
                else
                {
                    if (bgw.IsBusy) return;
                    int NumEntries = panel1.Width / bar_width;
                    int MaxVal = panel1.Height;
                    Paused = false;
                    current_pos = 0;
                    for (int i = 0; i < NumEntries; i ++)
                    {
                        g.FillRectangle(new SolidBrush(Color.Black), start_pos[i], 0, bar_width - 1, MaxVal);
                        g.FillRectangle(new SolidBrush(Color.White), start_pos[i], MaxVal - array[i], bar_width - 1, MaxVal);
                    }
                    bgw.RunWorkerAsync(argument: comboBox1.SelectedItem);
                }
            }
        }

        /**
         * Starts the actual sorting on a background worker.
         * Will complete it step by step (by using the next step method).
         **/
        public void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;
            string SortingName = (string) e.Argument;
            Type type = Type.GetType("Vizualizare_Sortari." + SortingName);
            var ctors = type.GetConstructors();
            try
            {
                Interface1 se = (Interface1) ctors[0].Invoke(new object[] {array, start_pos, g, panel1.Height, dly, bar_width});
                while (!IsSorted() && (!bgw.CancellationPending))
                {
                    se.NextStep();
                }
            }
            catch (Exception ex)
            {

            }
        }

        /**
         * Checks whether the array is sorted and returns a boolean.
         **/
        public bool IsSorted()
        {
            for (int i = 0; i < array.Count() - 1; i ++)
            {
                if (array[i] > array[i + 1]) return false;
            }
            return true;
        }

        private void Form1_Load(object sender, EventArgs e) {}
    }
}