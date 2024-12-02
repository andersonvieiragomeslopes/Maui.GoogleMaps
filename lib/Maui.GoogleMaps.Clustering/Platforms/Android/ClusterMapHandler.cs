﻿// Original code from https://github.com/mierzynskim/Xamarin.Forms.GoogleMaps.Clustering/
// Original author code from https://github.com/sferhah

using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Gms.Maps.Utils.Data.GeoJson;
using Maui.GoogleMaps.Clustering.Platforms.Android;
using Maui.GoogleMaps.Handlers;
using Maui.GoogleMaps.Logics;
using Maui.GoogleMaps.Logics.Android;
using Maui.GoogleMaps.Platforms.Android.Callbacks;

namespace Maui.GoogleMaps.Clustering
{
    public partial class ClusterMapHandler
    {
        /// <summary>
        /// Call when before marker create.
        /// You can override your custom renderer for customize marker.
        /// </summary>
        /// <param name="outerItem">the pin.</param>
        /// <param name="innerItem">the marker options.</param>
        public static void MapGeoJson(ClusterMapHandler handler, ClusteredMap map)
        {
            if (!string.IsNullOrEmpty(map.GeoJson))
            {
                var layer = new GeoJsonLayer(handler.NativeMap, new Org.Json.JSONObject(map.GeoJson));
                layer.AddLayerToMap();
            }
        }
        public static void MapId(MapHandler handler, ClusteredMap map)
        {
            if (!string.IsNullOrEmpty(map.MapId))
            {
                GoogleMapOptions options = new GoogleMapOptions();
                options.InvokeMapId(map.MapId);
                var mapFragment = SupportMapFragment.NewInstance(options);

                var activity = Platform.CurrentActivity as AndroidX.Fragment.App.FragmentActivity;
                if (activity != null)
                {
                    var fragmentManager = activity.SupportFragmentManager;
                    var transaction = fragmentManager.BeginTransaction();
                    transaction.Replace(global::Android.Resource.Id.Content, mapFragment);
                    transaction.Commit();

                    mapFragment.GetMapAsync(new OnMapReadyCallback(googleMap =>
                    {
                        handler.OnMapReady();
                    }));
                }
            }
        }
        protected virtual void OnClusteredMarkerCreating(Pin outerItem, MarkerOptions innerItem)
        {

        }
        /// <summary>
        /// Call when after marker create.
        /// You can override your custom renderer for customize marker.
        /// </summary>
        /// <param name="outerItem">the pin.</param>
        /// <param name="innerItem">the clustered marker.</param>
        protected virtual void OnClusteredMarkerCreated(Pin outerItem, ClusteredMarker innerItem)
        {
        }

        /// <summary>
        /// Call when before marker delete.
        /// You can override your custom renderer for customize marker.
        /// </summary>
        /// <param name="outerItem">the pin.</param>
        /// <param name="innerItem">the clustered marker.</param>
        protected virtual void OnClusteredMarkerDeleting(Pin outerItem, ClusteredMarker innerItem)
        {
        }
        /// <summary>
        /// Call when after marker delete.
        /// You can override your custom renderer for customize marker.
        /// </summary>
        /// <param name="outerItem">the pin.</param>
        /// <param name="innerItem">the clustered marker.</param>
        /// 
        protected virtual void OnClusteredMarkerDeleted(Pin outerItem, ClusteredMarker innerItem)
        {
        }
        public override void OnMapReady()
        {
            base.OnMapReady();
            var cluster = VirtualView as ClusteredMap;
        }
        public override void InitLogics() => Logics = new List<BaseLogic<GoogleMap>>
        {
            new PolylineLogic(),
            new PolygonLogic(),
            new CircleLogic(),
            new ClusterLogic(this.Context, Config.GetBitmapdescriptionFactory(), OnClusteredMarkerCreating, OnClusteredMarkerCreated, OnClusteredMarkerDeleting, OnClusteredMarkerDeleted),
            new TileLayerLogic(),
            new GroundOverlayLogic(Config.GetBitmapdescriptionFactory())
        };

    }   
}
