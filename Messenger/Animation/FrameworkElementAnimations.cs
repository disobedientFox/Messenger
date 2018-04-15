using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows;

namespace Messenger
{
    public static class FrameworkElementAnimations
    {
        #region Slide in from right

        /// <summary>
        /// Slides an element in from the right
        /// </summary>
        /// <param name="element"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromRight(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true, int width = 0)
        {
            // Create the storyboard
            var sb = new Storyboard();
            sb.AddSlideFromRight(seconds, width == 0 ? element.ActualWidth : width, keepMargin: keepMargin);

            sb.AddFadeIn(seconds);

            sb.Begin(element);

            element.Visibility = Visibility.Visible;

            await Task.Delay((int)(seconds * 1000));
        }

        /// <summary>
        /// Slides an element out to the right
        /// </summary>
        /// <param name="element"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToRight(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true, int width = 0)
        {
            // Create the storyboard
            var sb = new Storyboard();
            sb.AddSlideToRight(seconds, width == 0 ? element.ActualWidth : width, keepMargin: keepMargin);

            sb.AddFadeOut(seconds);

            sb.Begin(element);

            element.Visibility = Visibility.Visible;

            await Task.Delay((int)(seconds * 1000));
        }

        #endregion

        #region Slide in from left

        /// <summary>
        /// Slides an element in from the left
        /// </summary>
        /// <param name="element"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromLeft(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true, int width = 0)
        {
            // Create the storyboard
            var sb = new Storyboard();
            sb.AddSlideFromLeft(seconds, width == 0 ? element.ActualWidth : width, keepMargin: keepMargin);

            sb.AddFadeIn(seconds);

            sb.Begin(element);

            element.Visibility = Visibility.Visible;

            await Task.Delay((int)(seconds * 1000));
        }

        /// <summary>
        /// Slides an element out to the left
        /// </summary>
        /// <param name="element"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToLeft(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true, int width = 0)
        {
            // Create the storyboard
            var sb = new Storyboard();
            sb.AddSlideToLeft(seconds, width == 0 ? element.ActualWidth : width, keepMargin: keepMargin);

            sb.AddFadeOut(seconds);

            sb.Begin(element);

            element.Visibility = Visibility.Visible;

            await Task.Delay((int)(seconds * 1000));
        }

        #endregion

        #region Slide in from bottom

        /// <summary>
        /// Slides an element in from the buttom
        /// </summary>
        /// <param name="element"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromBottom(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true, int height = 0)
        {
            // Create the storyboard
            var sb = new Storyboard();
            sb.AddSlideFromBottom(seconds, height == 0 ? element.ActualHeight : height, keepMargin: keepMargin);

            sb.AddFadeIn(seconds);

            sb.Begin(element);

            element.Visibility = Visibility.Visible;

            await Task.Delay((int)(seconds * 1000));
        }

        /// <summary>
        /// Slides an element out to the buttom
        /// </summary>
        /// <param name="element"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToBottom(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true, int height = 0)
        {
            // Create the storyboard
            var sb = new Storyboard();
            sb.AddSlideToBottom(seconds, height == 0 ? element.ActualHeight : height, keepMargin: keepMargin);

            sb.AddFadeOut(seconds);

            sb.Begin(element);

            element.Visibility = Visibility.Visible;

            await Task.Delay((int)(seconds * 1000));
        }

        #endregion
    }
}
