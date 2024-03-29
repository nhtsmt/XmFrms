﻿using System;
using ClockApp.Core.Forms.Services;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(ClockApp.iOS.ClipBoardImplementation))]
namespace ClockApp.iOS
{

    public class ClipBoardImplementation : IClipboard
    {
        public string GetTextFromClipBoard()
        {
            UIPasteboard clipboard = UIPasteboard.General;
            return clipboard.String;
        }

        public void OnCopy(string text)
        {
            UIPasteboard clipboard = UIPasteboard.General;
            clipboard.String = text;

            Xamarin.Forms.MessagingCenter.Send<ClockApp.Core.Forms.App, String>(
                (ClockApp.Core.Forms.App)Xamarin.Forms.Application.Current,
                "ClipBoardOnCopy",
                GetTextFromClipBoard()
            );
        }
    }
}