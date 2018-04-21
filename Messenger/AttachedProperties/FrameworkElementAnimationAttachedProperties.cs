using System;
using System.Threading.Tasks;
using System.Windows;

namespace Messenger
{
    /// <summary>
    /// A base class to run any animation method when a boolean is set
    /// to true and a reverse animation when set to false
    /// </summary>
    /// <typeparam name="Parent"></typeparam>
    public abstract class AnimateBaseProperty<Parent> : BaseAttachedProperty<Parent, bool>
        where Parent : BaseAttachedProperty<Parent, bool>, new()
    {
        #region Public Properties

        public bool FirstLoad { get; set; } = true;

        #endregion

        public override void OnValueUpdated(DependencyObject sender, object value)
        {
            // Get the framework element
            if (!(sender is FrameworkElement element))
                return;

            // Don't fire if the value doesn't change
            if (sender.GetValue(ValueProperty) == value && !FirstLoad)
                return;

            // On first load...
            if (FirstLoad)
            {

                //element.Visibility = Visibility.Hidden; 

                // Create a single self-unnhookable event
                // for the element Loaded event

                RoutedEventHandler onLoaded = null;

                onLoaded =  (ss, ee) =>
                {
                    //await Task.Delay(5);
                    // Unhook ourselves
                    element.Loaded -= onLoaded;

                    // Do desired animation
                    DoAnimation(element, (bool)value);

                    // No longer in first load
                    FirstLoad = false;
                };

                // Hook into the Loaded event of the element
                element.Loaded += onLoaded;
            }
            else
            {
                // Do desired animation
                DoAnimation(element, (bool)value);
            }
        }

        protected virtual void DoAnimation(FrameworkElement element, bool value)
        {
        }
    }


    /// <summary>
    /// Animates a framework element slideing it in from the left on show
    /// and sliding out to the left on hide
    /// 
    /// </summary>
    public class AnimateSlideInFromLeftProperty : AnimateBaseProperty<AnimateSlideInFromLeftProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value)
                // Animate in
                await element.SlideAndFadeInFromLeft(FirstLoad ? 0 : 0.3f, keepMargin: false);
            else
                await element.SlideAndFadeOutToLeft(FirstLoad ? 0 : 0.3f, keepMargin: false);
        }

    }

    public class AnimateSlideInFromBottomProperty : AnimateBaseProperty<AnimateSlideInFromBottomProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value)
                // Animate in
                await element.SlideAndFadeInFromBottom(FirstLoad ? 0 : 0.3f, keepMargin: false);
            else
                await element.SlideAndFadeOutToBottom(FirstLoad ? 0 : 0.3f, keepMargin: false);
        }

    }

    public class AnimateSlideInFromBottomMarginProperty : AnimateBaseProperty<AnimateSlideInFromBottomMarginProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value)
                // Animate in
                await element.SlideAndFadeInFromBottom(FirstLoad ? 0 : 0.3f, keepMargin: true);
            else
                await element.SlideAndFadeOutToBottom(FirstLoad ? 0 : 0.3f, keepMargin: true);
        }

    }

    public class AnimateFadeInProperty : AnimateBaseProperty<AnimateFadeInProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value)
                // Animate in
                await element.FadeIn(FirstLoad ? 0 : 0.1f);
            else
                // Animate out
                await element.FadeOut(FirstLoad ? 0 : 0.1f);
        }
    }
}
