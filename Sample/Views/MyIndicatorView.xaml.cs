﻿using AiForms.Dialogs;

namespace Sample.Views;

public partial class MyIndicatorView : LoadingView
{
    Animation animation;

    public MyIndicatorView()
    {
        InitializeComponent();

        image.Source = ImageSource.FromFile("dotnet_bot");

        animation = new Animation(v=>{
            image.Rotation = 360 * v;

            if(v <= 0.3){
                image.Scale = 1.0 - 0.5 * v / 0.3;
            }
            else if(v <= 0.6){
                image.Scale = 0.5 + 0.8 * (v - 0.3) / 0.3;
            }
            else {
                image.Scale = 1.3 - 0.2 * (v - 0.6) / 0.4;
            }


        },0,1,Easing.Linear,()=>{
            
        });
    }


    public override void RunPresentationAnimation()
    {
        this.Animate("sample", animation, 16, 1440, null, (v, c) => {
            image.Rotation = 0;
            image.Scale = 1;
        }, () => true);
    }

    public override void RunDismissalAnimation()
    {
        this.AbortAnimation("sample");
    }

    public override void Destroy() {}
}
