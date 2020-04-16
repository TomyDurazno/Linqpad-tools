<Query Kind="Program">
  <Namespace>System.Windows.Controls</Namespace>
</Query>

public enum TextBoxMode
{
	SingleLine,
	MultiLine
}

public enum IOMode
{
	InputOnly,
	InputOutput
}

void Main()
{
	//var textName = CreateTextBox("Name", TextBoxMode.SingleLine);
	/*var textInput = CreateTextBox("Input", TextBoxMode.MultiLine);
	var btnGo = CreateButton("Go");
	var textOutput = CreateTextBox("Output", TextBoxMode.MultiLine);

	btnGo.Click += (s, e) => textOutput.Text = textInput.Text;*/
}

public class MultilineIO
{
	TextBox CreateTextBox(string label, TextBoxMode textBoxMode)
	{
		var lbl = new Label();
		lbl.Content = $"{label}:";
		lbl.Dump();

		var textBox = new TextBox();
		if (textBoxMode == TextBoxMode.MultiLine)
		{
			textBox.AcceptsReturn = true;
			textBox.AcceptsTab = true;
			textBox.Height = 150;
			textBox.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
			textBox.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
		}
		textBox.FontFamily = new System.Windows.Media.FontFamily("Courier New");
		textBox.Dump();

		return textBox;
	}

	Button CreateButton(string caption)
	{
		var button = new Button();
		button.Content = caption;
		button.Width = 200;
		button.Margin = new System.Windows.Thickness(5);
		button.Dump();

		return button;
	}

	public void Create(Action<string> action, IOMode mode = IOMode.InputOnly)
	{
		var textInput = CreateTextBox("Input", TextBoxMode.MultiLine);
		var btnGo = CreateButton("Go");
		
		btnGo.Click += (s, e) => action(textInput.Text);
	}

	public void Create(Func<string, string> func, IOMode mode = IOMode.InputOutput)
	{
		var textInput = CreateTextBox("Input", TextBoxMode.MultiLine);
		var btnGo = CreateButton("Go");
		var textOutput = CreateTextBox("Output", TextBoxMode.MultiLine);

		btnGo.Click += (s, e) => textOutput.Text = func(textInput.Text);
	}
}