﻿using System;
using System.Collections.Generic;
using AiForms.Dialogs;

namespace Sample.Views;

public partial class ManualDialogView : DialogView
{
    public ManualDialogView()
    {
        InitializeComponent();
    }

    void Handle_Clicked(object sender, System.EventArgs e)
    {
        DialogNotifier.Complete();
    }
}
