﻿namespace AiForms.Dialogs;

public interface IDialog
{
    Task<bool> ShowAsync<TView>(object viewModel = null) where TView : DialogView;
    Task<bool> ShowAsync(DialogView view, object viewModel = null);
    IReusableDialog Create<TView>(object viewModel = null) where TView : DialogView;
    IReusableDialog Create(DialogView view, object viewModel = null);

}
