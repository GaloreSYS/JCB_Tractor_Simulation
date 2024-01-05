// Copyright (c) 2015 - 2023 Doozy Entertainment. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

//.........................
//.....Generated Class.....
//.........................
//.......Do not edit.......
//.........................

using UnityEngine;
// ReSharper disable All

namespace Doozy.Runtime.Signals
{
    public static partial class SignalsService
    {
        public static SignalStream GetStream(StreamId.OnBoarding id) => GetStream(nameof(StreamId.OnBoarding), id.ToString());   
    }

    public partial class Signal
    {
        public static bool Send(StreamId.OnBoarding id, string message = "") => SignalsService.SendSignal(nameof(StreamId.OnBoarding), id.ToString(), message);
        public static bool Send(StreamId.OnBoarding id, GameObject signalSource, string message = "") => SignalsService.SendSignal(nameof(StreamId.OnBoarding), id.ToString(), signalSource, message);
        public static bool Send(StreamId.OnBoarding id, SignalProvider signalProvider, string message = "") => SignalsService.SendSignal(nameof(StreamId.OnBoarding), id.ToString(), signalProvider, message);
        public static bool Send(StreamId.OnBoarding id, Object signalSender, string message = "") => SignalsService.SendSignal(nameof(StreamId.OnBoarding), id.ToString(), signalSender, message);
        public static bool Send<T>(StreamId.OnBoarding id, T signalValue, string message = "") => SignalsService.SendSignal(nameof(StreamId.OnBoarding), id.ToString(), signalValue, message);
        public static bool Send<T>(StreamId.OnBoarding id, T signalValue, GameObject signalSource, string message = "") => SignalsService.SendSignal(nameof(StreamId.OnBoarding), id.ToString(), signalValue, signalSource, message);
        public static bool Send<T>(StreamId.OnBoarding id, T signalValue, SignalProvider signalProvider, string message = "") => SignalsService.SendSignal(nameof(StreamId.OnBoarding), id.ToString(), signalValue, signalProvider, message);
        public static bool Send<T>(StreamId.OnBoarding id, T signalValue, Object signalSender, string message = "") => SignalsService.SendSignal(nameof(StreamId.OnBoarding), id.ToString(), signalValue, signalSender, message);   
    }

    public partial class SignalStream
    {
        public static SignalStream GetStream(StreamId.OnBoarding id) => SignalsService.GetStream(id);   
    }

    public partial class StreamId
    {
        public enum OnBoarding
        {
            SplashVideoComplete
        }         
    }
}

