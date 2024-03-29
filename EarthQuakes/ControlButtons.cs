﻿using System.Runtime.InteropServices;

namespace EarthQuakes;
internal static class ControlButtons
{
    [DllImport("user32")]
    public static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

    [DllImport("user32")]
    public static extern bool EnableMenuItem(IntPtr hMenu, uint itemId, uint uEnable);

    public static void DisableCloseButton(this Form form)
    {
        // The 1 parameter means to gray out. 0xF060 is SC_CLOSE.
        EnableMenuItem(GetSystemMenu(form.Handle, false), 0xF060, 1);
    }

    public static void EnableCloseButton(this Form form)
    {
        // The zero parameter means to enable. 0xF060 is SC_CLOSE.
        EnableMenuItem(GetSystemMenu(form.Handle, false), 0xF060, 0);
    }
}

