﻿using System;
using System.Runtime.InteropServices;
using System.Text;

namespace CleverDock.Interop
{
    public class WindowInterop
    {
        public static int WM_CLOSE = 0x10;

        #region ShowStyle enum

        public enum ShowStyle
        {
            /// <summary>
            ///   Hides the window and activates another window.
            /// </summary>
            Hide = 0,

            /// <summary>
            ///   Activates and displays a window. If the window is minimized or maximized, the system restores it to its original size and position. An application should specify this flag when displaying the window for the first time.
            /// </summary>
            ShowNormal = 1,

            /// <summary>
            ///   Activates the window and displays it as a minimized window.
            /// </summary>
            ShowMinimized = 2,

            /// <summary>
            ///   Activates the window and displays it as a maximized window.
            /// </summary>
            ShowMaximized = 3,

            /// <summary>
            ///   Maximizes the specified window.
            /// </summary>
            Maximize = 3,

            /// <summary>
            ///   Displays a window in its most recent size and position. This value is similar to SW_SHOWNORMAL, except that the window is not activated.
            /// </summary>
            ShowNormalNoActivate = 4,

            /// <summary>
            ///   Activates the window and displays it in its current size and position.
            /// </summary>
            Show = 5,

            /// <summary>
            ///   Minimizes the specified window and activates the next top-level window in the Z order.
            /// </summary>
            Minimize = 6,

            /// <summary>
            ///   Displays the window as a minimized window. This value is similar to SW_SHOWMINIMIZED, except the window is not activated.
            /// </summary>
            ShowMinNoActivate = 7,

            /// <summary>
            ///   Displays the window in its current size and position. This value is similar to SW_SHOW, except that the window is not activated.
            /// </summary>
            ShowNoActivate = 8,

            /// <summary>
            ///   Activates and displays the window. If the window is minimized or maximized, the system restores it to its original size and position. An application should specify this flag when restoring a minimized window.
            /// </summary>
            Restore = 9,

            /// <summary>
            ///   Sets the show state based on the SW_ value specified in the STARTUPINFO structure passed to the CreateProcess function by the program that started the application.
            /// </summary>
            ShowDefault = 10,

            /// <summary>
            ///   Minimizes a window, even if the thread that owns the window is not responding. This flag should only be used when minimizing windows from a different thread.
            /// </summary>
            ForceMinimized = 11
        }

        #endregion

        /// <summary>
        ///   Retains the current size (ignores the cx and cy parameters).
        /// </summary>
        public const int SWP_NOSIZE = 0x1;

        /// <summary>
        ///   Retains the current position (ignores the x and y parameters).
        /// </summary>
        public const int SWP_NOMOVE = 0x2;

        /// <summary>
        ///   The retrieved handle identifies the window of the same type that is highest in the Z order.
        ///   If the specified window is a topmost window, the handle identifies a topmost window. If the specified window is a top-level window, the handle identifies a top-level window. If the specified window is a child window, the handle identifies a sibling window
        /// </summary>
        public const int GW_HWNDFIRST = 0;

        /// <summary>
        ///   The retrieved handle identifies the window of the same type that is lowest in the Z order.
        ///   If the specified window is a topmost window, the handle identifies a topmost window. If the specified window is a top-level window, the handle identifies a top-level window. If the specified window is a child window, the handle identifies a sibling window.
        /// </summary>
        public const int GW_HWNDLAST = 1;

        /// <summary>
        ///   The retrieved handle identifies the window below the specified window in the Z order. 
        ///   If the specified window is a topmost window, the handle identifies a topmost window. If the specified window is a top-level window, the handle identifies a top-level window. If the specified window is a child window, the handle identifies a sibling window.
        /// </summary>
        public const int GW_HWNDNEXT = 2;

        /// <summary>
        ///   The retrieved handle identifies the window above the specified window in the Z order.
        ///   If the specified window is a topmost window, the handle identifies a topmost window. If the specified window is a top-level window, the handle identifies a top-level window. If the specified window is a child window, the handle identifies a sibling window.
        /// </summary>
        public const int GW_HWNDPREV = 3;

        /// <summary>
        ///   The retrieved handle identifies the specified window's owner window, if any.
        /// </summary>
        public const int GW_OWNER = 4;

        /// <summary>
        ///   The retrieved handle identifies the child window at the top of the Z order, if the specified window is a parent window; otherwise, the retrieved handle is NULL. The function examines only child windows of the specified window. It does not examine descendant windows.
        /// </summary>
        public const int GW_CHILD = 5;

        /// <summary>
        ///   The retrieved handle identifies the enabled popup window owned by the specified window (the search uses the first such window found using GW_HWNDNEXT); otherwise, if there are no enabled popup windows, the retrieved handle is that of the specified window.
        /// </summary>
        public const int GW_ENABLEDPOPUP = 6;

        /// <summary>
        ///   Retrieves the extended window styles.
        /// </summary>
        public const int GWL_EXSTYLE = -20;

        /// <summary>
        ///   Retrieves a handle to the application instance.
        /// </summary>
        public const int GWLP_HINSTANCE = -6;

        /// <summary>
        ///   Retrieves a handle to the parent window, if there is one.
        /// </summary>
        public const int GWLP_HWNDPARENT = -8;

        /// <summary>
        ///   Retrieves the identifier of the window.
        /// </summary>
        public const int GWLP_ID = -12;

        /// <summary>
        ///   Retrieves the window styles.
        /// </summary>
        public const int GWL_STYLE = -16;

        /// <summary>
        ///   Retrieves the user data associated with the window. This data is intended for use by the application that created the window. Its value is initially zero.
        /// </summary>
        public const int GWLP_USERDATA = -21;

        /// <summary>
        ///   Retrieves the pointer to the window procedure, or a handle representing the pointer to the window procedure. You must use the CallWindowProc function to call the window procedure.
        /// </summary>
        public const int GWLP_WNDPROC = -4;

        /// <summary>
        ///   Places the window above all non-topmost windows. The window maintains its topmost position even when it is deactivated.
        /// </summary>
        public static IntPtr HWND_TOPMOST = (IntPtr) (-1);

        /// <summary>
        ///   Retrieves a handle to the top-level window whose class name and window name match the specified strings. This function does not search child windows. This function does not perform a case-sensitive search.
        /// </summary>
        /// <param name="lpClassName"> The window class name. If lpClassName is NULL, it finds any window whose title matches the lpWindowName parameter. </param>
        /// <param name="lpWindowName"> The window name (the window's title). If this parameter is NULL, all window names match. </param>
        /// <returns> If the function succeeds, the return value is a handle to the window that has the specified class name and window name. </returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        /// <summary>
        /// Retrieves a handle to a window whose class name and window name match the specified strings. The function searches child windows, beginning with the one following the specified child window. This function does not perform a case-sensitive search.
        /// </summary>
        /// <param name="parentHandle">A handle to the parent window whose child windows are to be searched.</param>
        /// <param name="childAfter">A handle to a child window. The search begins with the next child window in the Z order. The child window must be a direct child window of hwndParent, not just a descendant window.</param>
        /// <param name="className">The class name or a class atom created by a previous call to the RegisterClass or RegisterClassEx function. The atom must be placed in the low-order word of lpszClass; the high-order word must be zero.</param>
        /// <param name="windowTitle">The window name (the window's title). If this parameter is NULL, all window names match.</param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, string windowTitle);

        /// <summary>
        ///   Sets the specified window's show state.
        /// </summary>
        /// <param name="hWnd"> A handle to the window. </param>
        /// <param name="nCmdShow"> Controls how the window is to be shown. Use ShowStyle </param>
        /// <returns> If the window was previously visible, the return value is nonzero. If the window was previously hidden, the return value is zero. </returns>
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, ShowStyle nCmdShow);

        /// <summary>
        ///   Changes the position and dimensions of the specified window. For a top-level window, the position and dimensions are relative to the upper-left corner of the screen. For a child window, they are relative to the upper-left corner of the parent window's client area.
        /// </summary>
        /// <param name="hWnd"> A handle to the window. </param>
        /// <param name="X"> The new position of the left side of the window. </param>
        /// <param name="Y"> The new position of the top of the window. </param>
        /// <param name="nWidth"> The new width of the window. </param>
        /// <param name="nHeight"> The new height of the window. </param>
        /// <param name="bRepaint"> Indicates whether the window is to be repainted. If this parameter is TRUE, the window receives a message. If the parameter is FALSE, no repainting of any kind occurs. This applies to the client area, the nonclient area (including the title bar and scroll bars), and any part of the parent window uncovered as a result of moving a child window. </param>
        /// <returns> If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error information, call GetLastError. </returns>
        [DllImport("user32.dll")]
        public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        /// <summary>
        ///   Minimizes (but does not destroy) the specified window.
        /// </summary>
        /// <param name="hWnd"> A handle to the window to be minimized. </param>
        /// <returns> If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error information, call GetLastError. </returns>
        [DllImport("user32.dll")]
        public static extern bool CloseWindow(IntPtr hWnd);

        /// <summary>
        ///  Copies the text of the specified window's title bar (if it has one) into a buffer. If the specified window is a control, the text of the control is copied. However, GetWindowText cannot retrieve the text of a control in another application.
        /// </summary>
        /// <param name="hWnd"> A handle to the window or control containing the text. </param>
        /// <param name="lpString"> The buffer that will receive the text. If the string is as long or longer than the buffer, the string is truncated and terminated with a null character. </param>
        /// <param name="nMaxCount"> The maximum number of characters to copy to the buffer, including the null character. If the text exceeds this limit, it is truncated. </param>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        /// <summary>
        ///   Determines whether the specified window is minimized (iconic).
        /// </summary>
        /// <param name="hWnd"> A handle to the window to be tested. </param>
        /// <returns> If the window is iconic, the return value is nonzero.If the window is not iconic, the return value is zero. </returns>
        [DllImport("user32.dll")]
        public static extern bool IsIconic(IntPtr hWnd);

        /// <summary>
        ///   Brings the thread that created the specified window into the foreground and activates the window. Keyboard input is directed to the window, and various visual cues are changed for the user. The system assigns a slightly higher priority to the thread that created the foreground window than it does to other threads.
        /// </summary>
        /// <param name="hWnd"> A handle to the window that should be activated and brought to the foreground. </param>
        /// <returns> If the window was brought to the foreground, the return value is nonzero. If the window was not brought to the foreground, the return value is zero. </returns>
        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        /// <summary>
        ///   Retrieves the identifier of the thread that created the specified window and, optionally, the identifier of the process that created the window.
        /// </summary>
        /// <param name="hWnd"> A handle to the window. </param>
        /// <param name="processId"> A pointer to a variable that receives the process identifier. If this parameter is not NULL, GetWindowThreadProcessId copies the identifier of the process to the variable; otherwise, it does not. </param>
        /// <returns> The return value is the identifier of the thread that created the window. </returns>
        [DllImport("user32.dll")]
        public static extern int GetWindowThreadProcessId(IntPtr hWnd, out int processId);

        /// <summary>
        ///   Forcibly closes the specified window.
        /// </summary>
        /// <param name="hWnd"> A handle to the window to be closed. </param>
        /// <param name="fShutDown"> Ignored. Must be FALSE. </param>
        /// <param name="fForce"> A TRUE for this parameter will force the destruction of the window if an initial attempt fails to gently close the window using WM_CLOSE. With a FALSE for this parameter, only the close with WM_CLOSE is attempted. </param>
        /// <returns> If the function succeeds, the return value is nonzero. If the function fails, the return value is FALSE. To get extended error information, call GetLastError. </returns>
        [DllImport("user32.dll")]
        public static extern bool EndTask(IntPtr hWnd, bool fShutDown, bool fForce);

        /// <summary>
        ///   Changes the size, position, and Z order of a child, pop-up, or top-level window. These windows are ordered according to their appearance on the screen. The topmost window receives the highest rank and is the first window in the Z order.
        /// </summary>
        /// <param name="hwnd"> A handle to the window. </param>
        /// <param name="hWndInsertAfter"> A handle to the window to precede the positioned window in the Z order. This parameter must be a window handle or one of the following values. </param>
        /// <param name="x"> The new position of the left side of the window, in client coordinates. </param>
        /// <param name="y"> The new position of the top of the window, in client coordinates. </param>
        /// <param name="cx"> The new width of the window, in pixels. </param>
        /// <param name="cy"> The new height of the window, in pixels. </param>
        /// <param name="wFlags"> The window sizing and positioning flags. </param>
        /// <returns> If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error information, call GetLastError. </returns>
        [DllImport("user32.dll")]
        public static extern int SetWindowPos(IntPtr hwnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, int wFlags);

        /// <summary>
        /// Rectangle used in the GetWindowRect method.
        /// </summary>
        public struct Rect
        {
            public int Left, Top, Right, Bottom;

            public static implicit operator System.Windows.Rect(Rect r)
            {
                return new System.Windows.Rect(r.Left, r.Top, r.Right - r.Left, r.Bottom - r.Top);
            }
        }

        /// <summary>
        /// Retrieves the dimensions of the bounding rectangle of the specified window. The dimensions are given in screen coordinates that are relative to the upper-left corner of the screen.
        /// </summary>
        /// <param name="hwnd">A handle to the window.</param>
        /// <param name="rectangle">A pointer to a RECT structure that receives the screen coordinates of the upper-left and lower-right corners of the window.</param>
        /// <returns>Returns nonzero if successful or zero otherwise. To get extended error information, call GetLastError.</returns>
        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hwnd, ref Rect rectangle);

        /// <summary>
        /// Point structure used in GetCursorPos.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct Point
        {
            public int X, Y;

            public static implicit operator System.Windows.Point(Point point)
            {
                return new System.Windows.Point(point.X, point.Y);
            }
        }

        /// <summary>
        /// Retrieves the position of the mouse cursor, in screen coordinates.
        /// </summary>
        /// <param name="lpPoint">A pointer to a POINT structure that receives the screen coordinates of the cursor.</param>
        /// <returns>Returns nonzero if successful or zero otherwise. To get extended error information, call GetLastError.</returns>
        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out Point lpPoint);

        /// <summary>
        ///   Enumerates all top-level windows on the screen by passing the handle to each window, in turn, to an application-defined callback function. EnumWindows continues until the last top-level window is enumerated or the callback function returns FALSE.
        ///   This function is more reliable than calling the GetWindow function in a loop. An application that calls GetWindow to perform this task risks being caught in an infinite loop or referencing a handle to a window that has been destroyed.
        /// </summary>
        /// <param name="lpEnumFunc"> A pointer to an application-defined callback function. For more information, see EnumWindowsProc. </param>
        /// <param name="lParam"> An application-defined value to be passed to the callback function. </param>
        /// <returns> If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error information, call GetLastError. </returns>
        [DllImport("user32.dll")]
        public static extern int EnumWindows(EnumWindowsCallback lpEnumFunc, int lParam);

        public delegate bool EnumThreadDelegate(IntPtr Hwnd, IntPtr lParam);
        /// <summary>
        /// Enumerates all nonchild windows associated with a thread by passing the handle to each window, in turn, to an application-defined callback function. EnumThreadWindows continues until the last window is enumerated or the callback function returns FALSE. To enumerate child windows of a particular window, use the EnumChildWindows function.
        /// </summary>
        /// <param name="threadId">The identifier of the thread whose windows are to be enumerated.</param>
        /// <param name="pfnEnum">A pointer to an application-defined callback function. For more information, see EnumThreadWndProc.</param>
        /// <param name="lParam">An application-defined value to be passed to the callback function.</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumThreadWindows(int threadId, EnumThreadDelegate pfnEnum, IntPtr lParam);

        /// <summary>
        ///   Determines the visibility state of the specified window.
        /// </summary>
        /// <param name="hWnd"> A handle to the window to be tested. </param>
        /// <returns> If the specified window, its parent window, its parent's parent window, and so forth, have the WS_VISIBLE style, the return value is nonzero. Otherwise, the return value is zero. Because the return value specifies whether the window has the WS_VISIBLE style, it may be nonzero even if the window is totally obscured by other windows. </returns>
        [DllImport("user32.dll")]
        public static extern bool IsWindowVisible(IntPtr hWnd);

        /// <summary>
        ///   Retrieves a handle to the specified window's parent or owner.
        /// </summary>
        /// <param name="hWnd"> A handle to the window whose parent window handle is to be retrieved. </param>
        /// <returns> If the window is a child window, the return value is a handle to the parent window. If the window is a top-level window with the WS_POPUP style, the return value is a handle to the owner window. </returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetParent(IntPtr hWnd);

        /// <summary>
        ///   Retrieves a handle to a window that has the specified relationship (Z-Order or owner) to the specified window.
        /// </summary>
        /// <param name="hWnd"> A handle to a window. The window handle retrieved is relative to this window, based on the value of the uCmd parameter. </param>
        /// <param name="wFlag"> The relationship between the specified window and the window whose handle is to be retrieved. </param>
        /// <returns> </returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindow(IntPtr hWnd, int wFlag);

        /// <summary>
        ///   Retrieves a handle to the foreground window (the window with which the user is currently working). The system assigns a slightly higher priority to the thread that creates the foreground window than it does to other threads.
        /// </summary>
        /// <returns>The handle to the foreground window.</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        /// <summary>
        /// Activates the window. Do not use this value with AW_HIDE.
        /// </summary>
        public const int AW_ACTIVATE = 0x00020000;

        /// <summary>
        /// Uses a fade effect. This flag can be used only if hwnd is a top-level window.
        /// </summary>
        public const int AW_BLEND = 0x00080000;

        /// <summary>
        /// Makes the window appear to collapse inward if AW_HIDE is used or expand outward if the AW_HIDE is not used. The various direction flags have no effect.
        /// </summary>
        public const int AW_CENTER = 0x00000010;

        /// <summary>
        /// Hides the window. By default, the window is shown.
        /// </summary>
        public const int AW_HIDE = 0x00010000;

        /// <summary>
        /// Animates the window from left to right. This flag can be used with roll or slide animation. It is ignored when used with AW_CENTER or AW_BLEND.
        /// </summary>
        public const int AW_HOR_POSITIVE = 0x00000001;

        /// <summary>
        /// Animates the window from right to left. This flag can be used with roll or slide animation. It is ignored when used with AW_CENTER or AW_BLEND.
        /// </summary>
        public const int AW_HOR_NEGATIVE = 0x00000002;

        /// <summary>
        /// Uses slide animation. By default, roll animation is used. This flag is ignored when used with AW_CENTER.
        /// </summary>
        public const int AW_SLIDE = 0x00040000;

        /// <summary>
        /// Animates the window from top to bottom. This flag can be used with roll or slide animation. It is ignored when used with AW_CENTER or AW_BLEND.
        /// </summary>
        public const int AW_VER_POSITIVE = 0x00000004;

        /// <summary>
        /// Animates the window from bottom to top. This flag can be used with roll or slide animation. It is ignored when used with AW_CENTER or AW_BLEND.
        /// </summary>
        public const int AW_VER_NEGATIVE = 0x00000008;

        /// <summary>
        /// Enables you to produce special effects when showing or hiding windows. There are four types of animation: roll, slide, collapse or expand, and alpha-blended fade.
        /// </summary>
        /// <param name="hwnd">A handle to the window to animate. The calling thread must own this window.</param>
        /// <param name="dwTime">The time it takes to play the animation, in milliseconds. Typically, an animation takes 200 milliseconds to play.</param>
        /// <param name="dwFlags">The type of animation. This parameter can be one or more of the following values. Note that, by default, these flags take effect when showing a window. To take effect when hiding a window, use AW_HIDE and a logical OR operator with the appropriate flags.</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool AnimateWindow(IntPtr hwnd, long dwTime, long dwFlags);

        [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
        private static extern long GetWindowLongPtr32(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "GetWindowLongPtr")]
        private static extern long GetWindowLongPtr64(IntPtr hWnd, int nIndex);

        /// <summary>
        ///   Retrieves information about the specified window. The function also retrieves the value at a specified offset into the extra window memory.
        /// </summary>
        /// <param name="hWnd"> A handle to the window and, indirectly, the class to which the window belongs. </param>
        /// <param name="nIndex"> The zero-based offset to the value to be retrieved. Valid values are in the range zero through the number of bytes of extra window memory, minus the size of an integer. To retrieve any other value, specify one of the following values. </param>
        /// <returns> If the function succeeds, the return value is the requested value. </returns>
        public static long GetWindowLongPtr(IntPtr hWnd, int nIndex)
        {
            if (IntPtr.Size == 8)
                return GetWindowLongPtr64(hWnd, nIndex);
            return GetWindowLongPtr32(hWnd, nIndex);
        }

        #region Nested type: EnumWindowsCallback

        /// <summary>
        ///   An application-defined callback function used with the EnumWindows or EnumDesktopWindows function. It receives top-level window handles. The WNDENUMPROC type defines a pointer to this callback function. EnumWindowsProc is a placeholder for the application-defined function name.
        /// </summary>
        /// <param name="hwnd"> A handle to a top-level window. </param>
        /// <param name="lParam"> The application-defined value given in EnumWindows or EnumDesktopWindows. </param>
        /// <returns> </returns>
        public delegate bool EnumWindowsCallback(IntPtr hwnd, int lParam);

        #endregion

        /// <summary>
        /// Retrieves a handle to the small icon associated with the class.
        /// </summary>
        public const int GCL_HICONSM = -34;

        /// <summary>
        /// Retrieves a handle to the icon associated with the class.
        /// </summary>
        public const int GCL_HICON = -14;

        /// <summary>
        /// Retrieve the small icon for the window.
        /// </summary>
        public const int ICON_SMALL = 0;
        /// <summary>
        /// Retrieve the large icon for the window.
        /// </summary>
        public const int ICON_BIG = 1;
        /// <summary>
        /// Retrieves the small icon provided by the application. If the application does not provide one, the system uses the system-generated icon for that window.
        /// </summary>
        public const int ICON_SMALL2 = 2;

        /// <summary>
        /// Sent to a window to retrieve a handle to the large or small icon associated with a window. The system displays the large icon in the ALT+TAB dialog, and the small icon in the window caption.
        /// </summary>
        public const int WM_GETICON = 0x7F;

        /// <summary>
        /// Retrieves the specified 32-bit (DWORD) value from the WNDCLASSEX structure associated with the specified window.
        /// </summary>
        /// <param name="hWnd">A handle to the window and, indirectly, the class to which the window belongs.</param>
        /// <param name="nIndex">The value to be retrieved.</param>
        /// <returns></returns>
        public static IntPtr GetClassLongPtr(IntPtr hWnd, int nIndex)
        {
            if (IntPtr.Size > 4)
                return GetClassLongPtr64(hWnd, nIndex);
            return new IntPtr(GetClassLongPtr32(hWnd, nIndex));
        }

        [DllImport("user32.dll", EntryPoint = "GetClassLong")]
        private static extern int GetClassLongPtr32(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "GetClassLongPtr")]
        private static extern IntPtr GetClassLongPtr64(IntPtr hWnd, int nIndex);

        /// <summary>
        /// Sends the specified message to a window or windows. The SendMessage function calls the window procedure for the specified window and does not return until the window procedure has processed the message.
        /// </summary>
        /// <param name="hWnd">A handle to the window whose window procedure will receive the message.</param>
        /// <param name="Msg">The message to be sent.</param>
        /// <param name="wParam">Additional message-specific information.</param>
        /// <param name="lParam">Additional message-specific information.</param>
        /// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
    }
}