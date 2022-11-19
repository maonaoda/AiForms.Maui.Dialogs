﻿namespace AiForms.Dialogs;

public class LoadingConfig
{
    public int OffsetX { get; set; }
    public int OffsetY { get; set; }
    public Color IndicatorColor { get; set; } = Colors.White;

    public double FontSize { get; set; } = 14;
    public Color FontColor { get; set; } = Colors.White;

    public Color OverlayColor { get; set; } = Color.FromRgb(0, 0, 0);
    public double Opacity { get; set; } = 0.6;

    public string DefaultMessage { get; set; }
    public string ProgressMessageFormat { get; set; } = "{0}\n{1:P0}"; // 0:message, 1:progress

    public bool IsReusable { get; set; }
}
