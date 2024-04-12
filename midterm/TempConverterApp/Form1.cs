namespace TempConverterApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.lblOutput.Text = string.Empty;
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            TemperatureConverter converter = new TemperatureConverter();

            string temp_input = this.temperatureInput.Text;
            string unit_to = this.unitInput.Text;

            decimal temp;
            if (decimal.TryParse(temp_input, out temp))
            {
                decimal converted_temp;
                string unit_from;
                if(unit_to.ToLower() == "c")
                {
                    Celsius temperature = new Celsius(temp);
                    converted_temp = converter.ConvertTemperature(temperature);
                    unit_from = temperature.GetUnit();
                } else
                {
                    Fahrenheit temperature = new Fahrenheit(temp);
                    converted_temp = converter.ConvertTemperature(temperature);
                    unit_from = temperature.GetUnit();

                }
                this.lblOutput.Text = $"{temp_input}{unit_from.ToUpper()} is {converted_temp.ToString()}{unit_to.ToUpper()}";
            }
            else
                this.lblOutput.Text = "Invalid Input"; 
        }
    }
}
