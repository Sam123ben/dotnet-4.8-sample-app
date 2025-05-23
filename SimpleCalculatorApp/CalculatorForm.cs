using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace SimpleCalculator
{
    public partial class CalculatorForm : Form
    {
        private TextBox displayTextBox;
        private double currentValue = 0;
        private string currentOperation = "";
        private bool isNewEntry = true;

        public CalculatorForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            
            // Form properties
            this.Text = "Simple Calculator v1.0";
            this.Size = new Size(300, 400);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Display textbox
            displayTextBox = new TextBox
            {
                Size = new Size(260, 30),
                Location = new Point(15, 15),
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                TextAlign = HorizontalAlignment.Right,
                ReadOnly = true,
                Text = "0"
            };
            this.Controls.Add(displayTextBox);

            // Button layout
            string[,] buttonLayout = {
                {"C", "±", "%", "÷"},
                {"7", "8", "9", "×"},
                {"4", "5", "6", "-"},
                {"1", "2", "3", "+"},
                {"0", "", ".", "="}
            };

            int buttonSize = 60;
            int margin = 5;
            int startX = 15;
            int startY = 60;

            for (int row = 0; row < buttonLayout.GetLength(0); row++)
            {
                for (int col = 0; col < buttonLayout.GetLength(1); col++)
                {
                    string buttonText = buttonLayout[row, col];
                    if (string.IsNullOrEmpty(buttonText)) continue;

                    Button btn = new Button
                    {
                        Text = buttonText,
                        Size = buttonText == "0" ? new Size(buttonSize * 2 + margin, buttonSize) : new Size(buttonSize, buttonSize),
                        Location = new Point(startX + col * (buttonSize + margin), startY + row * (buttonSize + margin)),
                        Font = new Font("Segoe UI", 12F, FontStyle.Regular),
                        UseVisualStyleBackColor = true
                    };

                    // Set button colors
                    if ("+-×÷=".Contains(buttonText))
                    {
                        btn.BackColor = Color.Orange;
                        btn.ForeColor = Color.White;
                    }
                    else if ("C±%".Contains(buttonText))
                    {
                        btn.BackColor = Color.LightGray;
                    }
                    else
                    {
                        btn.BackColor = Color.White;
                    }

                    btn.Click += Button_Click;
                    this.Controls.Add(btn);
                }
            }

            this.ResumeLayout(false);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            string buttonText = button.Text;

            try
            {
                switch (buttonText)
                {
                    case "C":
                        Clear();
                        break;
                    case "±":
                        ToggleSign();
                        break;
                    case "%":
                        Percentage();
                        break;
                    case ".":
                        AddDecimal();
                        break;
                    case "=":
                        Calculate();
                        break;
                    case "+":
                    case "-":
                    case "×":
                    case "÷":
                        SetOperation(buttonText);
                        break;
                    default:
                        if (char.IsDigit(buttonText[0]))
                        {
                            InputNumber(buttonText);
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                displayTextBox.Text = "Error";
                MessageBox.Show($"Calculation error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Clear();
            }
        }

        private void Clear()
        {
            displayTextBox.Text = "0";
            currentValue = 0;
            currentOperation = "";
            isNewEntry = true;
        }

        private void ToggleSign()
        {
            if (double.TryParse(displayTextBox.Text, out double value))
            {
                displayTextBox.Text = (-value).ToString(CultureInfo.InvariantCulture);
            }
        }

        private void Percentage()
        {
            if (double.TryParse(displayTextBox.Text, out double value))
            {
                displayTextBox.Text = (value / 100).ToString(CultureInfo.InvariantCulture);
                isNewEntry = true;
            }
        }

        private void AddDecimal()
        {
            if (isNewEntry)
            {
                displayTextBox.Text = "0.";
                isNewEntry = false;
            }
            else if (!displayTextBox.Text.Contains("."))
            {
                displayTextBox.Text += ".";
            }
        }

        private void InputNumber(string number)
        {
            if (isNewEntry || displayTextBox.Text == "0")
            {
                displayTextBox.Text = number;
                isNewEntry = false;
            }
            else
            {
                displayTextBox.Text += number;
            }
        }

        private void SetOperation(string operation)
        {
            if (!string.IsNullOrEmpty(currentOperation) && !isNewEntry)
            {
                Calculate();
            }
            else
            {
                currentValue = double.Parse(displayTextBox.Text);
            }

            currentOperation = operation;
            isNewEntry = true;
        }

        private void Calculate()
        {
            if (string.IsNullOrEmpty(currentOperation) || isNewEntry)
                return;

            double secondValue = double.Parse(displayTextBox.Text);
            double result = 0;

            switch (currentOperation)
            {
                case "+":
                    result = currentValue + secondValue;
                    break;
                case "-":
                    result = currentValue - secondValue;
                    break;
                case "×":
                    result = currentValue * secondValue;
                    break;
                case "÷":
                    if (secondValue == 0)
                        throw new DivideByZeroException("Cannot divide by zero");
                    result = currentValue / secondValue;
                    break;
            }

            displayTextBox.Text = result.ToString(CultureInfo.InvariantCulture);
            currentValue = result;
            currentOperation = "";
            isNewEntry = true;
        }
    }
}