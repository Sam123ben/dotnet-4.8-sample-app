using System;
using System.Globalization;
using System.Web.UI;

namespace WebCalculator
{
    public partial class Default : Page
    {
        private double CurrentValue
        {
            get { return ViewState["CurrentValue"] != null ? (double)ViewState["CurrentValue"] : 0; }
            set { ViewState["CurrentValue"] = value; }
        }

        private string CurrentOperation
        {
            get { return ViewState["CurrentOperation"] != null ? (string)ViewState["CurrentOperation"] : ""; }
            set { ViewState["CurrentOperation"] = value; }
        }

        private bool IsNewEntry
        {
            get { return ViewState["IsNewEntry"] != null ? (bool)ViewState["IsNewEntry"] : true; }
            set { ViewState["IsNewEntry"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtDisplay.Text = "0";
                IsNewEntry = true;
            }
        }

        protected void BtnNumber_Click(object sender, EventArgs e)
        {
            var button = (System.Web.UI.WebControls.Button)sender;
            string number = button.Text;

            if (IsNewEntry || txtDisplay.Text == "0")
            {
                txtDisplay.Text = number;
                IsNewEntry = false;
            }
            else
            {
                txtDisplay.Text += number;
            }
        }

        protected void BtnOperator_Click(object sender, EventArgs e)
        {
            var button = (System.Web.UI.WebControls.Button)sender;
            string operation = button.Text;

            if (!string.IsNullOrEmpty(CurrentOperation) && !IsNewEntry)
            {
                Calculate();
            }
            else
            {
                CurrentValue = double.Parse(txtDisplay.Text);
            }

            CurrentOperation = operation;
            IsNewEntry = true;
        }

        protected void BtnEquals_Click(object sender, EventArgs e)
        {
            Calculate();
        }

        protected void BtnDecimal_Click(object sender, EventArgs e)
        {
            if (IsNewEntry)
            {
                txtDisplay.Text = "0.";
                IsNewEntry = false;
            }
            else if (!txtDisplay.Text.Contains("."))
            {
                txtDisplay.Text += ".";
            }
        }

        protected void BtnFunction_Click(object sender, EventArgs e)
        {
            var button = (System.Web.UI.WebControls.Button)sender;
            string function = button.Text;

            try
            {
                switch (function)
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
                }
            }
            catch (Exception ex)
            {
                txtDisplay.Text = "Error";
                ShowError($"Calculation error: {ex.Message}");
                Clear();
            }
        }

        private void Calculate()
        {
            if (string.IsNullOrEmpty(CurrentOperation) || IsNewEntry)
                return;

            try
            {
                double secondValue = double.Parse(txtDisplay.Text);
                double result = 0;

                switch (CurrentOperation)
                {
                    case "+":
                        result = CurrentValue + secondValue;
                        break;
                    case "-":
                        result = CurrentValue - secondValue;
                        break;
                    case "×":
                        result = CurrentValue * secondValue;
                        break;
                    case "÷":
                        if (secondValue == 0)
                            throw new DivideByZeroException("Cannot divide by zero");
                        result = CurrentValue / secondValue;
                        break;
                }

                txtDisplay.Text = result.ToString(CultureInfo.InvariantCulture);
                CurrentValue = result;
                CurrentOperation = "";
                IsNewEntry = true;
            }
            catch (Exception ex)
            {
                txtDisplay.Text = "Error";
                ShowError($"Calculation error: {ex.Message}");
                Clear();
            }
        }

        private void Clear()
        {
            txtDisplay.Text = "0";
            CurrentValue = 0;
            CurrentOperation = "";
            IsNewEntry = true;
        }

        private void ToggleSign()
        {
            if (double.TryParse(txtDisplay.Text, out double value))
            {
                txtDisplay.Text = (-value).ToString(CultureInfo.InvariantCulture);
            }
        }

        private void Percentage()
        {
            if (double.TryParse(txtDisplay.Text, out double value))
            {
                txtDisplay.Text = (value / 100).ToString(CultureInfo.InvariantCulture);
                IsNewEntry = true;
            }
        }

        private void ShowError(string message)
        {
            // In a real application, you might want to use a proper error display
            Response.Write($"<script>alert('{message}');</script>");
        }
    }
}