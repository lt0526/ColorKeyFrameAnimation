using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MyCompositionAnimation
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Visual _root;
        private SpriteVisual targetVisual;
        private Compositor compositor;

        public MainPage()
        {
            this.InitializeComponent();

            _root = ElementCompositionPreview.GetElementVisual(root);
            compositor = _root.Compositor;

            targetVisual = compositor.CreateSpriteVisual();
            targetVisual.Offset = new Vector3(20.0f, 20.0f, 0.0f);
            targetVisual.Size = new Vector2(100.0f, 100.0f);
            targetVisual.Brush = compositor.CreateColorBrush(Colors.Orange);
            ElementCompositionPreview.SetElementChildVisual(root, targetVisual);
        }

        private void StartAnimation_Click(object sender, RoutedEventArgs e)
        {

            ColorKeyFrameAnimation colorAnimation = compositor.CreateColorKeyFrameAnimation();

            colorAnimation.InsertKeyFrame(1.0f, Colors.Purple);
            colorAnimation.InterpolationColorSpace = CompositionColorSpace.Hsl;
            colorAnimation.Duration = TimeSpan.FromSeconds(5);

            //targetVisual.StartAnimation("SolidColorBrush.Color", colorAnimation);
            targetVisual.Brush.StartAnimation("Color", colorAnimation);


            

            //Vector3KeyFrameAnimation offsetAnimation = compositor.CreateVector3KeyFrameAnimation();
            //offsetAnimation.InsertKeyFrame(1.0f, new Vector3(50, 50, 0));
            //offsetAnimation.Target = "offset";


            //CompositionAnimationGroup group = compositor.CreateAnimationGroup();
            //group.Add(offsetAnimation);
            //targetVisual.StartAnimationGroup(group);



        }

        private void Scroll_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {
            //var manipulation = ElementCompositionPreview.GetScrollViewerManipulationPropertySet(MyScroll);
            //ExpressionAnimation expression = compositor.CreateExpressionAnimation();
            //expression.Expression = "SharedProperty.CenterPoint.y";
            //expression.SetReferenceParameter("SharedProperty", manipulation);
            //expression.SetScalarParameter("ScrollBounds", (float)MyScroll.Height);
            //targetVisual.StartAnimation("Offset.y", expression);
        }
    }



    public class ViewModel
    {
        public ObservableCollection<School> Items { set; get; }


        public ViewModel()
        {
            Items = new ObservableCollection<School>();

            for (int i=1; i<100; i++)
            {
                Items.Add(new School{ Name = "luting" + i });
            }
        }
    }

    public class School
    {
        public string Name { set; get; }
    }
}
