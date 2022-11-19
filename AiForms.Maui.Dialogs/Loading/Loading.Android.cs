﻿using System;
using AiForms.Dialogs.Droid;

namespace AiForms.Dialogs;

public partial class Loading
{
    internal LoadingPlatformDialog LoadingDialog;
    LoadingConfig _config => Configurations.LoadingConfig;

    DefaultLoading _defaultInstance;
    DefaultLoading DefaultInstance => _defaultInstance ??= new DefaultLoading(LoadingDialog);

    public static readonly string LoadingDialogTag = "LoadingDialog";    

    public Loading()
    {
        LoadingDialog = new LoadingPlatformDialog();
    }

    public IReusableLoading Create<TView>(object viewModel = null) where TView : LoadingView
    {
        var view = ExtraView.InstanceCreator<TView>.Create();
        return Create(view, viewModel);
    }

    public IReusableLoading Create(LoadingView view, object viewModel = null)
    {
        if (viewModel != null)
        {
            view.BindingContext = viewModel;
        }
        return new ReusableLoading(view, LoadingDialog);
    }

    public void Dispose()
    {
        if (_defaultInstance != null)
        {
            _defaultInstance.Dispose();
            _defaultInstance = null;
        }
    }

    public async Task StartAsync(Func<IProgress<double>, Task> action, string message = null, bool isCurrentScope = false)
    {
        await WaitDialogDestroy().ConfigureAwait(false);

        await DefaultInstance.StartAsync(action, message, isCurrentScope);
        Hide();
    }

    public void Show(string message = null, bool isCurrentScope = false)
    {
        if (IsRunning())
        {
            return;
        }

        DefaultInstance.Show(message, isCurrentScope);
    }

    public void Hide()
    {
        DefaultInstance.Hide();
        if (!_config.IsReusable)
        {
            // _defaultInstance is dispoded by not here but the DefaultLoading.
            // Because null exception occurs when the dialog set this contentview.
            //_defaultInstance.Dispose();
            _defaultInstance = null;
        }
    }

    public void SetMessage(string message)
    {
        if (_defaultInstance != null)
        {
            _defaultInstance.SetMessage(message);
        }
    }

    bool IsRunning()
    {
        var dialog = DialogHelpers.FragmentManager.FindFragmentByTag(LoadingDialogTag) as LoadingPlatformDialog;
        return dialog != null;
    }

    async Task WaitDialogDestroy()
    {
        var dialog = DialogHelpers.FragmentManager.FindFragmentByTag(Loading.LoadingDialogTag) as LoadingPlatformDialog;
        if (dialog == null)
        {
            return;
        }

        await dialog.DestroyTcs.Task.ConfigureAwait(false);
        await Task.Delay(100);
    }
}

