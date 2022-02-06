using System;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;

namespace gtkTest
{
    class MainWindow : Window
    {
        [UI] private Label LabelHelp = null;
        [UI] private Button ButtonHelp = null;
        [UI] private RadioButton RedRadioButton = null;
        [UI] private RadioButton BlueRadioButton = null;
        [UI] private ToggleButton PauseToggle = null;
        private bool m_canAdd = true;
        private int _counter;

        public MainWindow() : this(new Builder("MainWindow.glade")) { }

        private MainWindow(Builder builder) : base(builder.GetRawOwnedObject("MainWindow"))
        {
            builder.Autoconnect(this);

            DeleteEvent += Window_DeleteEvent;
            ButtonHelp.Clicked += Button1_Clicked;
            RedRadioButton.Toggled += Red_Toggled;
            BlueRadioButton.Toggled += Blue_Toggled;
            PauseToggle.Toggled += PauseToggle_Toggled;
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {
            Application.Quit();
        }

        private void Button1_Clicked(object sender, EventArgs a)
        {
            LabelHelp.Text = "SIKE " + _counter;
            _counter++;
        }

        private void Red_Toggled(object sender, EventArgs a)
        {
            if (RedRadioButton.Active) RedRadioButton.Label = "RED";
            else RedRadioButton.Label = "red";
        }

        private void Blue_Toggled(object sender, EventArgs a)
        {
            if (BlueRadioButton.Active) BlueRadioButton.Label = "BLUE";
            else BlueRadioButton.Label = "blue";
        }

        private void PauseToggle_Toggled(object sender, EventArgs a)
        {
            m_canAdd = !PauseToggle.Active;
            if (m_canAdd) PauseToggle.Label = "Pause Counting";
            else PauseToggle.Label = "Resume Counting";
        }

    }
}
