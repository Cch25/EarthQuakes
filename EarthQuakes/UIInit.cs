namespace EarthQuakes;

internal class UIInit
{
    private readonly Form1 _form;
    private readonly MapConfig _mapConfig;

    public UIInit(Form1 form)
    {
        _form = form;
        _mapConfig = new MapConfig();
    }

    public EarthquakeDetector InitializeFormComponents()
    {
        _form.DisableCloseButton();
        _form.pictureBox1.LoadAsync(_mapConfig.MapUrl());
        _form.ddlPeriod.SelectedIndex = 3;
        new UIContextMenu().BuildTrayContextMenu(_form);
        return new EarthquakeDetector(_form, _mapConfig);
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

