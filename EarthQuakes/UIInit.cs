namespace EarthQuakes;

internal class UIInit
{
    private readonly Form1 _form;  

    public UIInit(Form1 form)
    {
        _form = form;  
    }

    public EarthquakeDetector InitializeFormComponents()
    {
        _form.DisableCloseButton();
        _form.pictureBox1.LoadAsync(new MapConfig().MapUrl);
        _form.ddlPeriod.SelectedIndex = 3;
        new UIContextMenu().BuildTrayContextMenu(_form);
        return new EarthquakeDetector(_form);
    }

    internal class UIContextMenu
    {
        public void BuildTrayContextMenu(Form1 form)
        {
            //notification icon
            var cm = new ContextMenuStrip();
            var quit = new ToolStripMenuItem("Quit");
            var show = new ToolStripMenuItem("Show");
            cm.Items.Add(show);
            cm.Items.Add(new ToolStripSeparator());
            cm.Items.Add(quit);
            form.notifyIcon1.ContextMenuStrip = cm;

            show.Click += (s, e) =>
            {
                form.WindowState = FormWindowState.Normal;
                form.ShowInTaskbar = true;
            };
            quit.Click += (s, e) =>
            {
                form.notifyIcon1.Dispose();
                Application.Exit();
            };

        }

    }
}

