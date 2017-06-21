namespace Lab10
{
    using Android.App;
    using Android.Widget;
    using Android.OS;
    using Android.Media;
    using Android.Content.Res;
    using System.IO;

    [Activity(Label = "@string/ApplicationName", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int Counter = 0;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            TextView ContentHeader = FindViewById<TextView>(Resource.Id.ContentHeader);
            ContentHeader.Text = GetText(Resource.String.ContentHeader);

            Button ClickMeButton = FindViewById<Button>(Resource.Id.ClickMe);
            TextView ClickCounterTextView = FindViewById<TextView>(Resource.Id.ClickCounter);

            ClickMeButton.Click += (s, e) =>
            {
                Counter++;
                ClickCounterTextView.Text = Resources.GetQuantityString(Resource.Plurals.numbersOfClicks, Counter, Counter);

                MediaPlayer Player = MediaPlayer.Create(this, Resource.Raw.sound);
                Player.Start();
            };

            AssetManager Manager = Assets;

            using (var Reader = new StreamReader(Manager.Open("Contenido.txt")))
            {
                ContentHeader.Text += $"\n\n{Reader.ReadToEnd()}";
            }
        }
    }
}

