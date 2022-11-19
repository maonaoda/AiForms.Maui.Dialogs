﻿using System;
using UIKit;

namespace AiForms.Dialogs.iOS;

public class ContentViewController: UIViewController
{
    bool _shouldAutorotate;
    public ContentViewController(bool shouldAutorotate)
    {
        _shouldAutorotate = shouldAutorotate;
    }        

    public override bool ShouldAutorotate()
    {
        return _shouldAutorotate;
    }
}
