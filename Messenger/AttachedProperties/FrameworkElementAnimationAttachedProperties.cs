using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Messenger
{
    /// <summary>
    /// A base class to run any animation method when a boolean is set to true
    /// and a reverse animation when set to false
    /// </summary>
    public abstract class AnimateBaseProperty<Parent> : BaseAttachedProperty<Parent, bool>
        where Parent : BaseAttachedProperty<Parent, bool>, new()
    {
        #region Protected Properties

        /// <summary>
        /// True if this is the very first time the value has been updated
        /// Used to make sure we run the logic at least once during first load
        /// </summary>
        protected Dictionary<DependencyObject, bool> mAlreadyLoaded = new Dictionary<DependencyObject, bool>();

        /// <summary>
        /// The most recent value used if we get a value changed before we do the first load
        /// </summary>
        protected Dictionary<DependencyObject, bool> mFirstLoadValue = new Dictionary<DependencyObject, bool>();

        #endregion

        public override void OnValueUpdated(DependencyObject sender, object value)
        {
            if (!(sender is FrameworkElement element))
                return;

            if ((bool)sender.GetValue(ValueProperty) == (bool)value && mAlreadyLoaded.ContainsKey(sender))
                return;

            if (!mAlreadyLoaded.ContainsKey(sender))
            {
                mAlreadyLoaded[sender] = false;
                
                element.Visibility = Visibility.Hidden;

                RoutedEventHandler onLoaded = null;
                onLoaded = async (ss, ee) =>
                {

                    element.Loaded -= onLoaded;

                    await Task.Delay(5);
                    
                    DoAnimation(element, mFirstLoadValue.ContainsKey(sender) ? mFirstLoadValue[sender] : (bool)value, true);

                    mAlreadyLoaded[sender] = true;
                };

                element.Loaded += onLoaded;
            }

            else if (mAlreadyLoaded[sender] == false)
                mFirstLoadValue[sender] = (bool)value;
            else
                DoAnimation(element, (bool)value, false);
        }

        /// <summary>
        /// The animation method that is fired when the value changes
        /// </summary>
        protected virtual void DoAnimation(FrameworkElement element, bool value, bool firstLoad) { }
    }

    /// <summary>
    /// Animates a framework element sliding it in from the left on show
    /// and sliding out to the left on hide
    /// </summary>
    public class AnimateSlideInFromLeftProperty : AnimateBaseProperty<AnimateSlideInFromLeftProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {
            if (value)
                // Animate in
                await element.SlideAndFadeIn(AnimationSlideInDirection.Left, firstLoad, firstLoad ? 0 : 0.3f, keepMargin: false);
            else
                // Animate out
                await element.SlideAndFadeOut(AnimationSlideInDirection.Left, firstLoad ? 0 : 0.3f, keepMargin: false);
        }
    }

    /// <summary>
    /// Animates a framework element sliding up from the bottom on show
    /// and sliding out to the bottom on hide
    /// </summary>
    public class AnimateSlideInFromBottomProperty : AnimateBaseProperty<AnimateSlideInFromBottomProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {
            if (value)
                // Animate in
                await element.SlideAndFadeIn(AnimationSlideInDirection.Bottom, firstLoad, firstLoad ? 0 : 0.3f, keepMargin: false);
            else
                // Animate out
                await element.SlideAndFadeOut(AnimationSlideInDirection.Bottom, firstLoad ? 0 : 0.3f, keepMargin: false);
        }
    }

    /// <summary>
    /// Animates a framework element sliding it in from the right on show
    /// and sliding out to the right on hide
    /// </summary>
    public class AnimateSlideInFromRightProperty : AnimateBaseProperty<AnimateSlideInFromRightProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {
            if (value)
                // Animate in
                await element.SlideAndFadeIn(AnimationSlideInDirection.Right, firstLoad, firstLoad? 0 : 0.3f, keepMargin: false);
            else
                // Animate out
                await element.SlideAndFadeOut(AnimationSlideInDirection.Right, firstLoad? 0 : 0.3f, keepMargin: false);
        }
    }

    /// <summary>
    /// Animates a framework element sliding it in from the right on show
    /// and sliding out to the right on hide
    /// </summary>
    public class AnimateSlideInFromRightMarginProperty : AnimateBaseProperty<AnimateSlideInFromRightMarginProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {
            if (value)
                // Animate in
                await element.SlideAndFadeIn(AnimationSlideInDirection.Right, firstLoad, firstLoad? 0 : 0.3f, keepMargin: true);
            else
                // Animate out
                await element.SlideAndFadeOut(AnimationSlideInDirection.Right, firstLoad? 0 : 0.3f, keepMargin: true);
        }
    }

    /// <summary>
    /// Animates a framework element sliding up from the bottom on show
    /// and sliding out to the bottom on hide
    /// NOTE: Keeps the margin
    /// </summary>
    public class AnimateSlideInFromBottomMarginProperty : AnimateBaseProperty<AnimateSlideInFromBottomMarginProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {
            if (value)
                // Animate in
                await element.SlideAndFadeIn(AnimationSlideInDirection.Bottom, firstLoad, firstLoad ? 0 : 0.3f, keepMargin: true);
            else
                // Animate out
                await element.SlideAndFadeOut(AnimationSlideInDirection.Bottom, firstLoad ? 0 : 0.3f, keepMargin: true);
        }
    }

    /// <summary>
    /// Animates a framework element fading in on show
    /// and fading out on hide
    /// </summary>
    public class AnimateFadeInProperty : AnimateBaseProperty<AnimateFadeInProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {
            if (value)
                // Animate in
                await element.FadeIn(firstLoad, firstLoad ? 0 : 0.15f);
            else
                // Animate out
                await element.FadeOut(firstLoad ? 0 : 0.15f);
        }
    }

    /// <summary>
    /// Animates a framework element sliding it from right to left and repeating forever
    /// </summary>
    public class AnimateMarqueeProperty : AnimateBaseProperty<AnimateMarqueeProperty>
    {
        protected override void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {
            // Animate in
            element.Marquee(firstLoad ? 0 : 3f);
        }
    }

    /// <summary>
    /// Animates a framework element sliding up from the bottom on load
    /// if the value is true
    /// </summary>
    public class AnimateSlideInFromBottomOnLoadProperty : AnimateBaseProperty<AnimateSlideInFromBottomOnLoadProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {
            // Animate in
            await element.SlideAndFadeIn(AnimationSlideInDirection.Bottom, !value, !value? 0 : 0.3f, keepMargin: false);
        }
    }

    /// <summary>
    /// Fades in an image once the source changes
    /// </summary>
    public class FadeInImageOnLoadProperty : AnimateBaseProperty<FadeInImageOnLoadProperty>
    {
        public override void OnValueUpdated(DependencyObject sender, object value)
        {
            // Make sure we have an image
            if (!(sender is Image image))
                return;

            // If we want to animate in...
            if ((bool) value)
                // Listen for target change
                image.TargetUpdated += Image_TargetUpdated;
            // Otherwise
            else
                // Make sure we unhooked
                image.TargetUpdated -= Image_TargetUpdated;
        }

        private async void Image_TargetUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            // Fade in image
            await(sender as Image).FadeIn(false);
        }
    }
}
