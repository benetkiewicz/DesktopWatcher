namespace DesktopWatcher
{
    using System;
    using System.Windows.Forms;

    public class GlobalHotkey
    {
        public const int HotkeyMessageId = 0x0312;
        private readonly int modifier;
        private readonly int key;
        private readonly int id;
        private IntPtr hWnd;

        public GlobalHotkey(int modifier, Keys key, Form form)
        {
            this.modifier = modifier;
            this.key = (int)key;
            this.hWnd = form.Handle;
            id = this.GetHashCode();
        }

        public bool Register()
        {
            return NativeMethods.RegisterHotKey(hWnd, id, modifier, key);
        }

        public bool Unregister()
        {
            return NativeMethods.UnregisterHotKey(hWnd, id);
        }

        public override sealed int GetHashCode()
        {
            return modifier ^ key ^ hWnd.ToInt32();
        }
    }
}