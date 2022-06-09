namespace Lab7
{
    public partial class Start : Form
    {
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer() { Interval = 20000 }; // timer
        public Start()
        {
            InitializeComponent();

            timer.Tick += onEnd; // при окончании таймера вызовется этот метод
            timer.Start();
        }

        void onEnd(object sender, EventArgs e)
        {
            this.Close(); // закрываем окно
        }
    }
}