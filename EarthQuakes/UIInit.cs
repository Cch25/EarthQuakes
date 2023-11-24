namespace EarthQuakes;

internal static class UIInit
{
    public static void InitializeMap(Form1 form, MapSettings settings)
    {
        form.DisableCloseButton();
        form.pictureBox1.LoadAsync(settings.MapUrl());
        form.ddlPeriod.SelectedIndex = 3;
        UIContextMenu.BuildTrayContextMenu(form);
    }

    internal static class UIContextMenu
    {
        public static void BuildTrayContextMenu(Form1 form)
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

