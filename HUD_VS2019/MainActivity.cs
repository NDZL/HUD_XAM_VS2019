using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Com.Symbol.Zebrahud;
using Android.Graphics;
using Java.Lang;
using Android.Util;

namespace HUD_VS2019
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, ZebraHud.IEventListener
    {
        private ZebraHud hud ;
        Button b1;
        Button b2;
        TextView tv2;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            Log.Info("XAMHUD", "ONCREATE: AFTER SETCONTENTVIEW");

            tv2 = (TextView)FindViewById(Resource.Id.textView2);
            tv2.Text ="cxnt48";
                    
            hud = new ZebraHud();
            Log.Info("XAMHUD", "ONCREATE: AFTER NEW ZEBRAHUD ");

            b1 = (Button)FindViewById(Resource.Id.button1);
            b1.Click += delegate
            {
                int A = 0;
            };

            b2 = (Button)FindViewById(Resource.Id.button2);
            b2.Click += delegate
            {

                byte[] res_sm = hud.ShowMessage("HUD XAMARIN by N.DZL", "Hello from Milan Red-Zone");
                Log.Info("XAMHUD", "AFTER SHOWMESSAGE");

            };
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnStart()
        {
            base.OnStart();
            this.hud.OnStart(this);
            Log.Info("XAMHUD", "AFTER ENDOF ONSTART");
        }



        protected override void OnStop()
        {
            base.OnStop();
            this.hud.OnStop(this, Java.Lang.Boolean.False);
            Log.Info("XAMHUD", "AFTER ENDOF ONSTOP");

        }

        protected override void OnPause()
        {
            base.OnPause();
            hud.OnPause(this);
            Log.Info("XAMHUD", "AFTER ENDOF ONPAUSE");
        }

        protected override void OnResume()
        {
            base.OnResume();
            hud.OnResume(this, (ZebraHud.IEventListener)this);
            Log.Info("XAMHUD", "AFTER ENDOF ONRESUME");
        }

        public void OnCameraImage(Bitmap p0)
        {
            throw new System.NotImplementedException();
        }

        public void OnConnected(Boolean p0)
        {
            Log.Info("XAMHUD", "OnConnected "+p0.ToString());
        }

        public void OnImageUpdated(byte[] p0)
        {
            throw new System.NotImplementedException();
        }
    }
}