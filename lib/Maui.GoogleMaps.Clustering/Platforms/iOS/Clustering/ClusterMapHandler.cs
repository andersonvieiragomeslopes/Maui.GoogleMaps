using Google.Maps;
using Google.Maps.Utils;
using Maui.GoogleMaps.Clustering.Platforms.iOS.Clustering;
using Maui.GoogleMaps.Handlers;
using Maui.GoogleMaps.Logics.iOS;

namespace Maui.GoogleMaps.Clustering
{   
    public partial class ClusterMapHandler
    {
        public static void MapGeoJson(ClusterMapHandler handler, ClusteredMap map)
        {
            if (!string.IsNullOrEmpty(map.GeoJson))
            {
                var geoJsonParser = new GMUGeoJSONParser(map.GeoJson);
                geoJsonParser.Parse();

                var renderer = new GMUGeometryRenderer(handler.NativeMap, geometries: geoJsonParser.Features);
                renderer.Render();
            }
        }
        public static void MapId(ClusterMapHandler handler, ClusteredMap map)
        {
            if (!string.IsNullOrEmpty(map.MapId))
            {
                var mapViewOptions = new MapViewOptions()
                {
                    //MapId = map.MapId,
                };
                //var camera = new GMSCameraPosition(map.InitialCameraUpdate.Position.Latitude,
                //                                   map.InitialCameraUpdate.Position.Longitude,
                //                                   (float)map.InitialCameraUpdate.Zoom);
                //var mapView = new GMSMapView(frame: CoreGraphics.CGRect.Empty, options: mapViewOptions, camera: camera);
                //handler.PlatformView = mapView;
            }

        }
        public override void InitLogics() => Logics =
        [
          new PolylineLogic(),
                    new PolygonLogic(),
                    new CircleLogic(),
                    new ClusterLogic(Config.ImageFactory, OnMarkerCreating, OnMarkerCreated, OnMarkerDeleting, OnMarkerDeleted),
                    new TileLayerLogic(),
                    new GroundOverlayLogic(Config.GetImageFactory())
        ];     
    }
}
