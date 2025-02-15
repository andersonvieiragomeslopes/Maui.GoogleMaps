using Maui.GoogleMaps;

namespace MauiGoogleMapSample
{
    public partial class TilesPage : ContentPage
    {
        public TilesPage()
        {
            InitializeComponent();
#if ANDROID
            Java.Lang.JavaSystem.SetProperty("http.agent", "Onion.Maui.GoogleMaps.Android");
#endif
            TileLayer objTile  = null;
            Button currentDisable = buttonRemove;
            buttonRemove.IsEnabled = false;

            //Android
            var andString = "data:image/png;base64,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";
            var andImage = Convert.FromBase64String(andString.Split(",".ToCharArray(), 2)[1]);
            //Apple
            var appString = "data:image/png;base64,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";
            var appImage = Convert.FromBase64String(appString.Split(",".ToCharArray(), 2)[1]);

            // Open Railway Map
            buttonORMTile.Clicked += (sender, e) =>
            {
                if (objTile != null) map.TileLayers.Remove(objTile);

                objTile = TileLayer.FromTileUri((int x, int y, int zoom) =>
                    new Uri($"https://{"abc".Substring(new Random().Next(3), 1)}.tiles.openrailwaymap.org/standard/{zoom}/{x}/{y}.png")
                , 512);
                objTile.Tag = "ORMTILE"; // Can set any object

                map.TileLayers.Add(objTile);

                currentDisable.IsEnabled = true;
                currentDisable = (Button)sender;
                currentDisable.IsEnabled = false;
                map.MapType = MapType.Satellite;
            };

            // Open Street Map
            buttonOSMITile.Clicked += (sender, e) =>
            {
                if (objTile != null) map.TileLayers.Remove(objTile);

                objTile = TileLayer.FromTileUri((int x, int y, int zoom) =>
                    new Uri($"https://tile.openstreetmap.org/{zoom}/{x}/{y}.png"));
                objTile.Tag = "OSMTILE"; // Can set any object

                map.TileLayers.Add(objTile);

                currentDisable.IsEnabled = true;
                currentDisable = (Button)sender;
                currentDisable.IsEnabled = false;
                map.MapType = MapType.None;
            };

            // Image Sync
            buttonSyncImage.Clicked += (sender, e) =>
            {
                if (objTile != null) map.TileLayers.Remove(objTile);

                objTile = TileLayer.FromSyncImage((int x, int y, int zoom) =>  andImage);
                objTile.Tag = "SYNCTILE"; // Can set any object

                map.TileLayers.Add(objTile);

                currentDisable.IsEnabled = true;
                currentDisable = (Button)sender;
                currentDisable.IsEnabled = false;
                map.MapType = MapType.Street;
            };

            // Image Async
            buttonAsyncImage.Clicked += (sender, e) =>
            {
                if (objTile != null) map.TileLayers.Remove(objTile);

                objTile = TileLayer.FromAsyncImage(async (int x, int y, int zoom) =>
                {
                    return await Task.Run(() =>
                    {
                        return appImage;
                    });
                });
                objTile.Tag = "ASYNCTILE"; // Can set any object

                map.TileLayers.Add(objTile);

                currentDisable.IsEnabled = true;
                currentDisable = (Button)sender;
                currentDisable.IsEnabled = false;
                map.MapType = MapType.Street;
            };

            buttonRemove.Clicked += (sender, e) =>
            {
                map.TileLayers.Remove(objTile);
                objTile = null;

                currentDisable.IsEnabled = true;
                currentDisable = (Button)sender;
                currentDisable.IsEnabled = false;
                map.MapType = MapType.Street;
            };

            buttonZIndex.Clicked += (sender, e) => 
            {
                if (objTile == null)
                {
                    return;
                }

                if (objTile.ZIndex == -1) 
                {
                    buttonZIndex.Text = "Tile ZIndex(-1 to 1)";
                    objTile.ZIndex = 1;
                }
                else
                {
                    buttonZIndex.Text = "Tile ZIndex(1 to -1)";
                    objTile.ZIndex = -1;
                }
            };

            var line = new Polyline
            {
                StrokeColor = Colors.Blue,
                StrokeWidth = 5
            };
            line.Positions.Add(new Position(35.708011, 139.722536));
            line.Positions.Add(new Position(35.681167, 139.767052));
            line.Positions.Add(new Position(35.610243, 139.750374));
            map.Polylines.Add(line);

            map.InitialCameraUpdate = CameraUpdateFactory.NewPositionZoom(new Position(35.69d, 139.75d), 11);
        }

        //Android
        //data:image/png;base64,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
        //Apple
        //data:image/png;base64,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
    }
}

