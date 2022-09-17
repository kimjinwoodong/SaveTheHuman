using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Save_the_human_rev1
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        Random random = new Random();

        public MainPage()
        {

        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            AddEnemy();
        }

        private void AddEnemy()
        {
            ContentControl enemy = new ContentControl();
            enemy.Template = Resources["EnemyTemplate"] as ControlTemplate;
            AnimateEnemy(enemy, 0, PlayArea.ActualWidth - 100, "(Canvas.left)");
            AnimateEnemy(enemy, random.Next((int)PlayArea.ActualHeight - 100),
                random.Next((int)PlayArea.ActualHeight - 100),
                "(Canvas.Top)");
            PlayArea.Children.Add(enemy);
        }

        private void AnimateEnemy(ContentControl enemy, double from, double to, string PropertyToAnimate)
        {
            Storyboard storyboard = new Storyboard()
            { AutoReverse = true, RepeatBehavior = RepeatBehavior.Forever};
            DoubleAnimation animation = new DoubleAnimation()
            {
                From = from,
                To = to,
                Duration = new Duration(TimeSpan.FromSeconds(random.Next(4, 6)))
            };

            Storyboard.SetTarget(animation, enemy);
            Storyboard.SetTargetProperty(animation, new PropertyPath(PropertyToAnimate));
            storyboard.Children.Add(animation);
            storyboard.Begin();

        }
    }
}
