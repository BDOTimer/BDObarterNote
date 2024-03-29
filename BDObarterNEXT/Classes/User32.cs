﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace BDObarterNEXT
{
    class User32
    {
        [DllImport("User32")]
        private static extern int ShowWindow
            (IntPtr hwnd, ShowWindowCommands nCmdShow);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetWindowPos(
            IntPtr hWnd,
            IntPtr hWndInsertAfter, int X, int Y, int cx, int cy,
            SetWindowPosFlags uFlags
        );

        static readonly IntPtr HWND_TOPMOST   = new IntPtr(-1);
        static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
        static readonly IntPtr HWND_TOP       = new IntPtr( 0);
        static readonly IntPtr HWND_BOTTOM    = new IntPtr( 1);

        enum ShowWindowCommands
        {
            /// <summary>
            /// Hides the window and activates another window.
            /// </summary>
            Hide = 0,
            /// <summary>
            /// Activates and displays a window. If the window is minimized or
            /// maximized, the system restores it to its original size and position.
            /// An application should specify this flag when displaying the window
            /// for the first time.
            /// </summary>
            Normal = 1,
            /// <summary>
            /// Activates the window and displays it as a minimized window.
            /// </summary>
            ShowMinimized = 2,
            /// <summary>
            /// Maximizes the specified window.
            /// </summary>
            Maximize = 3, // is this the right value?
            /// <summary>
            /// Activates the window and displays it as a maximized window.
            /// </summary>
            ShowMaximized = 3,
            /// <summary>
            /// Displays a window in its most recent size and position. This value
            /// is similar to <see cref="Win32.ShowWindowCommand.Normal"/>, except
            /// the window is not activated.
            /// </summary>
            ShowNoActivate = 4,
            /// <summary>
            /// Activates the window and displays it in its current size and position.
            /// </summary>
            Show = 5,
            /// <summary>
            /// Minimizes the specified window and activates the next top-level
            /// window in the Z order.
            /// </summary>
            Minimize = 6,
            /// <summary>
            /// Displays the window as a minimized window. This value is similar to
            /// <see cref="Win32.ShowWindowCommand.ShowMinimized"/>, except the
            /// window is not activated.
            /// </summary>
            ShowMinNoActive = 7,
            /// <summary>
            /// Displays the window in its current size and position. This value is
            /// similar to <see cref="Win32.ShowWindowCommand.Show"/>, except the
            /// window is not activated.
            /// </summary>
            ShowNA = 8,
            /// <summary>
            /// Activates and displays the window. If the window is minimized or
            /// maximized, the system restores it to its original size and position.
            /// An application should specify this flag when restoring a minimized window.
            /// </summary>
            Restore = 9,
            /// <summary>
            /// Sets the show state based on the SW_* value specified in the
            /// STARTUPINFO structure passed to the CreateProcess function by the
            /// program that started the application.
            /// </summary>
            ShowDefault = 10,
            /// <summary>
            /// <b>Windows 2000/XP:</b> Minimizes a window, even if the thread
            /// that owns the window is not responding. This flag should only be
            /// used when minimizing windows from a different thread.
            /// </summary>
            ForceMinimize = 11
        }

        /// <summary>
        ///     Special window handles
        /// </summary>
        public enum SpecialWindowHandles
        {
            // ReSharper disable InconsistentNaming
            /// <summary>
            ///     Places the window at the bottom of the Z order. If the hWnd
            ///     parameter identifies a topmost window, the window loses its
            ///     topmost status and is placed at the bottom of all other 
            ///     windows.
            /// </summary>
            HWND_TOP = 0,
            /// <summary>
            ///     Places the window above all non-topmost windows (that is,
            ///     behind all topmost windows). This flag has no effect if the
            ///     window is already a non-topmost window.
            /// </summary>
            HWND_BOTTOM = 1,
            /// <summary>
            ///     Places the window at the top of the Z order.
            /// </summary>
            HWND_TOPMOST = -1,
            /// <summary>
            ///     Places the window above all non-topmost windows. The window
            ///     maintains its topmost position even when it is deactivated.
            /// </summary>
            HWND_NOTOPMOST = -2
            // ReSharper restore InconsistentNaming
        }

        [Flags]
        public enum SetWindowPosFlags : uint
        {
            // ReSharper disable InconsistentNaming

            /// <summary>
            ///     If the calling thread and the thread that owns the window
            ///     are attached to different input queues, the system posts the
            ///     request to the thread that owns the window. This prevents
            ///     the calling thread from blocking its execution while other
            ///     threads process the request.
            /// </summary>
            SWP_ASYNCWINDOWPOS = 0x4000,

            /// <summary>
            ///     Prevents generation of the WM_SYNCPAINT message.
            /// </summary>
            SWP_DEFERERASE = 0x2000,

            /// <summary>
            ///     Draws a frame (defined in the window's class description)
            ///     around the window.
            /// </summary>
            SWP_DRAWFRAME = 0x0020,

            /// <summary>
            ///     Applies new frame styles set using the SetWindowLong
            ///     function. Sends a WM_NCCALCSIZE message to the window, even 
            ///     if the window's size is not being changed. If this flag is
            ///     not specified, WM_NCCALCSIZE is sent only when the window's
            ///     size is being changed.
            /// </summary>
            SWP_FRAMECHANGED = 0x0020,

            /// <summary>
            ///     Hides the window.
            /// </summary>
            SWP_HIDEWINDOW = 0x0080,

            /// <summary>
            ///     Does not activate the window. 
            ///     If this flag is not set, the window is activated 
            ///     and moved to the top of either the topmost or 
            ///     non-topmost group (depending on the setting of the 
            ///     hWndInsertAfter parameter).
            /// </summary>
            SWP_NOACTIVATE = 0x0010,

            /// <summary>
            ///     Discards the entire contents of the client area. If this 
            ///     flag is not specified, the valid contents of the client area
            ///     are saved and copied back into the client area after the 
            ///     window is sized or repositioned.
            /// </summary>
            SWP_NOCOPYBITS = 0x0100,

            /// <summary>
            ///     Retains the current position (ignores X and Y parameters).
            /// </summary>
            SWP_NOMOVE = 0x0002,

            /// <summary>
            ///     Does not change the owner window's position in the Z order.
            /// </summary>
            SWP_NOOWNERZORDER = 0x0200,

            /// <summary>
            ///     Does not redraw changes. If this flag is set, no repainting 
            ///     of any kind occurs. This applies to the client area, the 
            ///     nonclient area (including the title bar and scroll bars), 
            ///     and any part of the parent window uncovered as a result of 
            ///     the window being moved. When this flag is set, 
            ///     the application must explicitly invalidate or redraw any 
            ///     parts of the window and parent window that need redrawing.
            /// </summary>
            SWP_NOREDRAW = 0x0008,

            /// <summary>
            ///     Same as the SWP_NOOWNERZORDER flag.
            /// </summary>
            SWP_NOREPOSITION = 0x0200,

            /// <summary>
            ///     Prevents the window from receiving the WM_WINDOWPOSCHANGING message.
            /// </summary>
            SWP_NOSENDCHANGING = 0x0400,

            /// <summary>
            ///     Retains the current size (ignores the cx and cy parameters).
            /// </summary>
            SWP_NOSIZE = 0x0001,

            /// <summary>
            ///     Retains the current Z order (ignores the hWndInsertAfter parameter).
            /// </summary>
            SWP_NOZORDER = 0x0004,

            /// <summary>
            ///     Displays the window.
            /// </summary>
            SWP_SHOWWINDOW = 0x0040,

            // ReSharper restore InconsistentNaming
        }

        public  static void xdeActive(Form myform)
        {
            myform.Close();
            ShowWindow(myform.Handle, ShowWindowCommands.ShowMinimized);
            ShowWindow(myform.Handle, ShowWindowCommands.ShowNoActivate);

            //SetWindowPos(
            //    myform.Handle, HWND_TOPMOST, 0, 0, 0, 0,
            //    SetWindowPosFlags.SWP_NOSIZE       |
            //    SetWindowPosFlags.SWP_NOREPOSITION |
            //    SetWindowPosFlags.SWP_NOMOVE       |
            //    SetWindowPosFlags.SWP_NOACTIVATE
            //);
        }

        public  static void deActive_after_click(Form myform)
        {   //myform.Close();
            //ShowWindow(myform.Handle, ShowWindowCommands.ShowMinimized);
            //ShowWindow(myform.Handle, ShowWindowCommands.ShowNoActivate);
            
            ShowWindow(myform.Handle, ShowWindowCommands.Hide          );
            ShowWindow(myform.Handle, ShowWindowCommands.ShowNoActivate);
          
            /*
            SetWindowPos(
                myform.Handle, HWND_TOPMOST, 0, 0, 0, 0,
                SetWindowPosFlags.SWP_NOSIZE       |
                SetWindowPosFlags.SWP_NOREPOSITION |
                SetWindowPosFlags.SWP_NOMOVE       |
                SetWindowPosFlags.SWP_NOACTIVATE
            );
            */
        }
    }
}
